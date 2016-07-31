Namespace SapiData

    Public Enum ShipmentTypes
        _Delivery = 1
        _Return = 2
    End Enum

    Friend Class ShipmentTypesDict
        Inherits Dictionary(Of String, String)

        Public Function GetItem(item) As String
            Return Me(item.ToString)
        End Function

        Public Sub New()
            Me.Add("_Delivery", "Delivery")
            Me.Add("_Return", "Return")
        End Sub
    End Class


End Namespace
