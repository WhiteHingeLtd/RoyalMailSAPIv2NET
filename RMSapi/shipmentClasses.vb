Imports RMaPI_v2.SapiData
Namespace ShipmentClasses
    ''' <summary>
    ''' Contains details which are passed into the CreateShipment function
    ''' </summary>
    Public Class CreateShipmentDetails


        Public Class ShipmentReferences
            ''' <summary>
            ''' This is the department reference code that customers can define in OBA. This is visible in the system departmental references GUI.
            ''' </summary>
            Public Department As String

            ''' <summary>
            ''' This field allows customers to supply a reference that applies to multiple shipments and is included to mirror the functionality offered by the Customer Reference field in OBA, whereby a reference can be associated to a group of items. For references that apply to a single shipment, the senderReference field should be used. Warning: Misuse of this field may result in incorrect billing.  
            ''' </summary>
            Public Customer As String

            ''' <summary>
            ''' This field allows the user to supply their own reference number. Where supported (e.g. Tracked Returns) this number will appear on the label. 
            ''' </summary>
            Public Sender As String
        End Class

        Public Class RecipientDetails
            ''' <summary>
            ''' Mandatory. Contact name 
            ''' </summary>
            Public Name As String
            Public BusinessName As String
            ''' <summary>
            ''' Required if the SMS or SMS and Email enhancements are used.
            ''' </summary>
            Public Telephone As String            'Royal mail suggests storing this as an integer. WHAT COULD POSSIBLY GO WRONG.
            ''' <summary>
            ''' Required if the Email or SMS and Email enhancements are used.
            ''' </summary>
            Public Email As String

            ''' <summary>
            ''' Mandatory.
            ''' </summary>
            Public AddressLine1 As String
            Public AddressLine2 As String
            Public Addressline3 As String
            Public Addressline4 As String
            ''' <summary>
            ''' Mandatory. Although it gets replaced with the one they parse on a UK postcode anyway. 
            ''' </summary>
            Public PostTown As String
            ''' <summary>
            ''' Mandatory for UK addresses. If the shippingType is return, this has to match the registered return address. 
            ''' </summary>
            Public Postcode As String

            Public Country As SapiData.Countries

        End Class

        Public ShipmentType As ShipmentTypes
        ''' <summary>
        ''' Not entirely sure what this is. Waiting for clarification from Royal Mail.
        ''' </summary>
        Public ServiceOccurence As String
        Public ServiceType As ServiceTypes
        Public ServiceOffering As ServiceOfferings
        Public ServiceFormat As ServiceFormats
        Public BFPOFormat As BFPOFormats
        Public ServiceEnhancements As New List(Of SapiData.ServiceEnhancements)
        ''' <summary>
        ''' For RM Tracked items only, this element specifies whether a signature is required on delivery. If this element is not included then it defaults to false. 
        ''' </summary>
        Public Signature As Boolean = False
        ''' <summary>
        ''' The date the parcel will actually be shipped. Can be up to 28 days in the future. Must be provided for 
        ''' </summary>
        Public ShippingDate As DateTime

        Public Recipient As New RecipientDetails

        Public References As New ShipmentReferences


        Friend Function ServiceEnhancementsAPICompatible()                                  '
            Dim EnhaDict As New ServiceEnhancementsDict                                     ' "Oops!... I Did It Again" is a song by American singer Britney Spears from her 2000 second studio album 
            Dim SEs As New List(Of Sapi.serviceEnhancementType)                             ' of the same name. It was released on March 27, 2000, by JIVE Records as the lead single from the album.
            For Each SE As SapiData.ServiceEnhancements In ServiceEnhancements                        ' The song was written and produced by Max Martin and Rami Yacoub. "Oops!... I Did It Again" is a song that
                Dim NewEnhancement As New Sapi.serviceEnhancementType                       ' lyrically speaks of a female who views love as a game, and she decides to use that to her advantage by 
                Dim NewEnhancementRefType As New Sapi.referenceDataType                     ' playing with her lover's emotions. Its bridge features a dialogue which references the blockbuster film Titanic 
                NewEnhancementRefType.code = EnhaDict.GetItem(SE)                           ' (1997).
                NewEnhancement.serviceEnhancementCode = NewEnhancementRefType               ' 
                SEs.Add(NewEnhancement)                                                     ' It just reminded me of the song. Thanks
            Next                                                                            ' 
            Return SEs.ToArray                                                              ' Source: https://en.wikipedia.org/wiki/Oops!..._I_Did_It_Again_(song)
        End Function                                                                        ' 

    End Class

End Namespace
