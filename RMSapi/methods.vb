'###################################################################################
'##    methods.vb                                           RoyalMailSAPIv2NET    ##
'##                           © 2016 White Hinge Ltd                              ##
'##                                                                               ##
'##   ==== Authored By (Enter your name here if you contributed) ==============   ##
'##       Lee Butler (WHL),  Colin McAloon (WHL)                                  ##
'##                                                                               ##
'###################################################################################
Imports RMaPI_v2.Sapi_209
Public Class ShippingAPIMethods

    Private Function GenerateClient(ClientID As String, ClientSecret As String, Username As String, Sha1Password As String)
        'WCF is so damn stupid. 

        'Create binding
        Dim newbinding As New System.ServiceModel.BasicHttpsBinding(ServiceModel.BasicHttpsSecurityMode.Transport)
        newbinding.Security.Transport.ClientCredentialType = ServiceModel.HttpClientCredentialType.Basic
        'Create Credentials
        Dim Creds As PasswordDigest.DigestData = PasswordDigest.GetDigest(Sha1Password, Username)
        Dim wsse As ServiceModel.Channels.AddressHeader

        'Create Headers
        Dim clid As ServiceModel.Channels.AddressHeader = ServiceModel.Channels.AddressHeader.CreateAddressHeader("X-IBM-Client-Id", "", ClientID)
        Dim clsec As ServiceModel.Channels.AddressHeader = ServiceModel.Channels.AddressHeader.CreateAddressHeader("X-IBM-Client-Secret", "", ClientSecret)
        'Create Endpoint
        Dim BaseURI As New Uri("https://api.royalmail.net/shipping/v2")
        Dim ep As New ServiceModel.EndpointAddress(BaseURI, {clid, clsec})
        'Create and set client

        Shipping = New shippingAPIPortTypeClient(newbinding, ep)


    End Function

    Dim CustomerAccountNumber As String
    Dim Shipping As shippingAPIPortTypeClient

    Public Sub New(AccountNumber As String)
        GenerateClient("97b330f9-acdf-43ed-a083-b612ae5bbb75", "", "bugs@whitehinge.com", "f0fc0c146e023bd778b91db452a00249dd375619")
        CustomerAccountNumber = AccountNumber
    End Sub




    ''' <summary>
    ''' Automatically generates a header to send with the request.
    ''' </summary>
    ''' <returns></returns>
    Friend Function GenerateIntegrationHeader() As integrationHeader
        Dim NewHeader As New integrationHeader
        NewHeader.dateTime = Now
        NewHeader.dateTimeSpecified = True 'What's this?
        NewHeader.version = 2
        NewHeader.versionSpecified = True 'Isn't this meant to be readonly? Mabe triggered when the property is set. 

        'Apparently the flags aren't used. Huh.

        'Create an Identification thing.
        Dim NH_ID As New identificationStructure
        NH_ID.applicationId = CustomerAccountNumber
        NH_ID.transactionId = Now.Ticks.ToString 'It can be anything, and it's not running async seemingly so why not.

        NewHeader.identification = NH_ID

        Return NewHeader

    End Function


    ''' <summary>
    ''' Creates a shipment with the supplied details. Then sends the details.
    ''' </summary>
    ''' <param name="ShipData">Contains all of the required data to send the request.</param>
    ''' <returns></returns>
    Public Function CreateShipment(ShipData As ShipmentClasses.CreateShipmentDetails) As createShipmentResponse
        Dim SecurityType As New SecurityHeaderType

        Dim CSRRequest As New requestedShipment

        'Shipment Type & ShipmentType/Code
        Dim ShipType As New referenceDataType   '
        Dim shiptypeDict As New SapiData.ShipmentTypesDict
        ShipType.code = shiptypeDict.GetItem(ShipData.ShipmentType)          '
        CSRRequest.shipmentType = ShipType

        'ServiceType & ServiceType/Code
        Dim ServiceType As New referenceDataType
        Dim servDict As New SapiData.ServiceTypesDict
        ServiceType.code = servDict.GetItem(ShipData.ServiceType)
        CSRRequest.serviceType = ServiceType

        'Service Occirence
        CSRRequest.serviceOccurrence = ShipData.ServiceOccurence

        'Service Offering 
        Dim ServiceOffering As New serviceOfferingType                                  'This
        Dim ServiceOfferingCode As New referenceDataType                                'Is
        Dim serviceOfferDict As New SapiData.ServiceOfferingsDict                       'So
        ServiceOfferingCode.code = serviceOfferDict.GetItem(ShipData.ServiceOffering)   'stupid
        ServiceOffering.serviceOfferingCode = ServiceOfferingCode                       'whhhhyyyyyyyyyyyyyyyyyyyyyyyy
        CSRRequest.serviceOffering = ServiceOffering                                    'Just use a string in the first place. It'd be so much easier.

        'ServiceFormat
        Dim ServiceFormat As New serviceFormatType                                      '
        Dim ServiceFormatCode As New referenceDataType                                  '
        Dim serviceFormatDict As New SapiData.ServiceFormatsDict                        ' Oh god. 
        ServiceFormatCode.code = serviceFormatDict.GetItem(ShipData.ServiceFormat)      ' They did it again.
        ServiceFormat.serviceFormatCode = ServiceFormatCode                             '
        CSRRequest.serviceFormat = ServiceFormat                                        ' Yes Ozzy, I'll be going off the rails if I have to do this again. This is one *crazy* train.

        'BFPOFormat
        Dim BFPOFormat As New bFPOFormatType                                            '   ___     _       _                ___     ___     ___     ___     ___     ___  
        Dim BFPOFormatCode As New referenceDataType                                     '  /   \   | |     | |       o O O  /   \   | _ )   / _ \   /   \   | _ \   |   \       That's the
        Dim BFPOFormatDict As New SapiData.BFPOFormatsDict                              '  | - |   | |__   | |__    o       | - |   | _ \  | (_) |  | - |   |   /   | |) |      Crazy Train®
        BFPOFormatCode.code = BFPOFormatDict.GetItem(ShipData.BFPOFormat)               '  |_|_|   |____|  |____|  TS__[O]  |_|_|   |___/   \___/   |_|_|   |_|_\   |___/  
        BFPOFormat.bFPOFormatCode = BFPOFormatCode                                      '_|"""""|_|"""""|_|"""""| {======|_|"""""|_|"""""|_|"""""|_|"""""|_|"""""|_|"""""|      CHOO CHOO
        CSRRequest.bfpoFormat = BFPOFormat                                              '"`-0-0-'"`-0-0-'"`-0-0-'./o--000'"`-0-0-'"`-0-0-'"`-0-0-'"`-0-0-'"`-0-0-'"`-0-0-'

        'ServiceEnhancements
        CSRRequest.serviceEnhancements = ShipData.ServiceEnhancementsAPICompatible      'I've already done the stupidity for this one inside the function.

        'Signature
        CSRRequest.signature = ShipData.Signature

        'ShipDate
        CSRRequest.shippingDate = ShipData.ShippingDate

        'Recipient Contact 
        Dim RecipientContact As New contact
        RecipientContact.name = ShipData.Recipient.Name
        RecipientContact.complementaryName = ShipData.Recipient.BusinessName
        'We have to create a telephone numnber what the fuck
        Dim tele As New telephoneNumber
        tele.telephoneNumber1 = ShipData.Recipient.Telephone
        RecipientContact.telephoneNumber = tele
        'And an email address. Why can't it be easy?
        Dim email As New digitalAddress
        email.electronicAddress = ShipData.Recipient.Email
        RecipientContact.electronicAddress = email
        'Back to "normal"
        CSRRequest.recipientContact = RecipientContact

        Dim RecipientAddress As New address
        RecipientAddress.addressLine1 = ShipData.Recipient.AddressLine1
        RecipientAddress.addressLine2 = ShipData.Recipient.AddressLine2
        RecipientAddress.addressLine3 = ShipData.Recipient.Addressline3
        RecipientAddress.addressLine4 = ShipData.Recipient.Addressline4                 'Address Line 4 is undocumented! Boo
        RecipientAddress.postTown = ShipData.Recipient.PostTown
        RecipientAddress.postcode = ShipData.Recipient.Postcode
        'HERE WE GO AGAIN BOYS
        Dim RecipientCountry As New countryType
        Dim RecipientCountryCode As New referenceDataType
        Dim RecipientCountryDict As New SapiData.CountriesDict
        RecipientCountryCode.code = RecipientCountryDict.GetItem(ShipData.Recipient.Country)
        RecipientCountry.countryCode = RecipientCountryCode
        RecipientAddress.country = RecipientCountry
        'And of the silliness
        'RecipientAddress.County is also undocumented, but it's another stupid nesty nesty string type so I don't feel like doing it. They can use AL4.
        CSRRequest.recipientAddress = RecipientAddress

        'The 3 referenketeers
        CSRRequest.departmentReference = ShipData.References.Department
        CSRRequest.customerReference = ShipData.References.Customer
        CSRRequest.senderReference = ShipData.References.Sender


        Dim CSR As New createShipmentRequest
        CSR.integrationHeader = GenerateIntegrationHeader()
        CSR.requestedShipment = CSRRequest

        Return Shipping.createShipment(SecurityType, CSR)


    End Function



End Class
