Namespace SapiData

    Public Enum ServiceTypes
        _Royal_Mail_24___1st_Class = 1
        _Royal_Mail_48___2nd_Class = 2
        _Special_Delivery_Guaranteed = 3
        _HM_Forces__BFPO_ = 4
        _International = 5
        _Tracked_Returns = 6
        _Royal_Mail_Tracked___ = 7
    End Enum

    Friend Class ServiceTypesDict
        Inherits Dictionary(Of String, String)

        Public Function GetItem(item) As String
            Return Me(item.ToString)
        End Function

        Public Sub New()
            Me.Add("_Royal_Mail_24___1st_Class", "1")
            Me.Add("_Royal_Mail_48___2nd_Class", "2")
            Me.Add("_Special_Delivery_Guaranteed", "D")
            Me.Add("_HM_Forces__BFPO_", "H")
            Me.Add("_International", "I")
            Me.Add("_Tracked_Returns", "R")
            Me.Add("_Royal_Mail_Tracked___", "T")
        End Sub
    End Class


End Namespace
