Namespace SapiData

    Public Enum ServiceEnhancements
        ''' <summary>
        ''' Consequential Loss Insurance to the value of £1000. Can't be used with another Consequential Loss Insurance.
        ''' </summary>
        _Consequential_Loss_GBP1000 = 1
        ''' <summary>
        ''' Consequential Loss Insurance to the value of £2500. Can't be used with another Consequential Loss Insurance.
        ''' </summary>
        _Consequential_Loss_GBP2500 = 2
        ''' <summary>
        ''' Consequential Loss Insurance to the value of £5000. Can't be used with another Consequential Loss Insurance.
        ''' </summary>
        _Consequential_Loss_GBP5000 = 3
        ''' <summary>
        ''' Consequential Loss Insurance to the value of £7500. Can't be used with another Consequential Loss Insurance.
        ''' </summary>
        _Consequential_Loss_GBP7500 = 4
        ''' <summary>
        ''' Consequential Loss Insurance to the value of £10000. Can't be used with another Consequential Loss Insurance.
        ''' </summary>
        _Consequential_Loss_GBP10000 = 5
        ''' <summary>
        ''' Recorded Signed For Mail
        ''' </summary>
        _Recorded = 6
        ''' <summary>
        ''' Consequential Loss Insurance to the value of £750. Can't be used with another Consequential Loss Insurance.
        ''' </summary>
        _Consequential_Loss_GBP750 = 7
        ''' <summary>
        ''' Tracked Delivery option. Can't be used with Safeplace
        ''' </summary>
        _Tracked_Signature = 8
        ''' <summary>
        ''' SMS tracking notifications. Can't be used with Email notifications - Maybe try "SMS and E-Mail notifications instead"
        ''' </summary>
        _SMS_Notification = 9
        ''' <summary>
        ''' SMS tracking notifications. Can't be used with SMS notifications - Maybe try "SMS and E-Mail notifications instead"
        ''' </summary>
        _E_Mail_Notification = 10
        ''' <summary>
        ''' Not supported.
        ''' </summary>
        _Safeplace = 11
        ''' <summary>
        ''' SMS AND Email tracking notifications. Can't be used with just Email or SMS notifications. "
        ''' </summary>
        _SMS_and_E_Mail_Notification = 12
        ''' <summary>
        ''' Local colleciton from a post office.
        ''' </summary>
        _Local_Collect = 13
        ''' <summary>
        ''' Saturday delivery - Only works for guaranteed services, and will not work if the booking date is not a friday.
        ''' </summary>
        _Saturday_Guaranteed = 14
    End Enum

    Friend Class ServiceEnhancementsDict
        Inherits Dictionary(Of String, String)

        Public Function GetItem(item) As String
            Return Me(item.ToString)
        End Function

        Public Sub New()
            Me.Add("_Consequential_Loss_GBP1000", "1")
            Me.Add("_Consequential_Loss_GBP2500", "2")
            Me.Add("_Consequential_Loss_GBP5000", "3")
            Me.Add("_Consequential_Loss_GBP7500", "4")
            Me.Add("_Consequential_Loss_GBP10000", "5")
            Me.Add("_Recorded", "6")
            Me.Add("_Consequential_Loss_GBP750", "11")
            Me.Add("_Tracked_Signature", "12")
            Me.Add("_SMS_Notification", "13")
            Me.Add("_E_Mail_Notification", "14")
            Me.Add("_Safeplace", "15")
            Me.Add("_SMS_and_E_Mail_Notification", "16")
            Me.Add("_Local_Collect", "22")
            Me.Add("_Saturday_Guaranteed", "24")
        End Sub
    End Class


End Namespace
