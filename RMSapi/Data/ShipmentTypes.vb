Namespace SapiData

    Public Enum ShipmentTypes
        None = 0
        _Delivery = 1
        _Return = 2
    End Enum

    Friend Class ShipmentTypesDict
        Inherits Dictionary(Of String, String)

        Public Function GetItem(item) As String
            If Not item = 0 Then
                Return Me(item.ToString)
            Else
                Return ""
            End If
        End Function

        Public Sub New()
            Me.Add("_Delivery", "Delivery")
            Me.Add("_Return", "Return")
        End Sub
    End Class


End Namespace
