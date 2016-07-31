Imports RMaPI_v2.Sapi
Public Class ShippingAPIMethods
    Dim Shipping As New RMaPI_v2.Sapi.shippingAPIPortTypeClient()

    Dim CustomerAccountNumber As String

    Public Sub AccountDetails(AccountNumber As String)
        CustomerAccountNumber = AccountNumber
    End Sub

    ''' <summary>
    ''' Automatically generates a header to send with the request.
    ''' </summary>
    ''' <returns></returns>
    Public Function GenerateIntegrationHeader() As Sapi.integrationHeader
        Dim NewHeader As New Sapi.integrationHeader
        NewHeader.dateTime = Now
        NewHeader.dateTimeSpecified = True 'What's this?
        NewHeader.version = 2
        NewHeader.version = True 'Isn't this meant to be readonly? Mabe triggered when the property is set. 

        'Apparently the flags aren't used. Huh.

        'Create an Identification thing.
        Dim NH_ID As New Sapi.identificationStructure
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
    Public Function CreateShipment(ShipData As ShipmentClasses.CreateShipmentDetails)
        Dim SecurityType As New Sapi.SecurityHeaderType

        Dim CSRRequest As New Sapi.requestedShipment

        'Shipment Type & ShipmentType/Code
        Dim ShipType As New referenceDataType   '
        ShipType.code = ShipData.API_ShipmentType              '
        CSRRequest.shipmentType = ShipType

        'ServiceType & ServiceType/Code
        Dim ServiceType As New referenceDataType
        ServiceType.code = ShipData.API_ServiceType
        CSRRequest.serviceType = ServiceType




        Dim CSR As New Sapi.createShipmentRequest
        CSR.integrationHeader = GenerateIntegrationHeader()
        CSR.requestedShipment = CSRRequest

        Shipping.createShipment(SecurityType, CSR)


    End Function



End Class
