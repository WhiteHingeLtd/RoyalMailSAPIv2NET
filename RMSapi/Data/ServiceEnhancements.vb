Namespace SapiData

    Public Enum ServiceEnhancements
        _Consequential_Loss_GBP1000 = 1
        _Consequential_Loss_GBP2500 = 2
        _Consequential_Loss_GBP5000 = 3
        _Consequential_Loss_GBP7500 = 4
        _Consequential_Loss_GBP10000 = 5
        _Recorded = 6
        _Consequential_Loss_GBP750 = 7
        _Tracked_Signature = 8
        _SMS_Notification = 9
        _E_Mail_Notification = 10
        _Safeplace = 11
        _SMS_and_E_Mail_Notification = 12
        _Local_Collect = 13
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
