Namespace SapiData

    Public Enum <Name>
            
    End Enum

    Friend Class <Name>Dict
        Inherits Dictionary(Of String, String)

        Public Function GetItem(item) As String
            Return Me(item.ToString)
        End Function

        Public Sub New()

        End Sub
    End Class


End Namespace
