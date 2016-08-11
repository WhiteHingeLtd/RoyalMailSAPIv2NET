Namespace SapiData

    Public Enum ServiceFormats
        _Inland_Large_Letter = 1
        _Inland_Letter = 2
        _Inland_format_Not_Applicable = 3
        _Inland_Parcel = 4
        _International_Parcel = 5
        _International_Large_Letter = 6
        _International_Format_Not_Applicable = 7
        _International_Letter = 8

    End Enum

    Friend Class ServiceFormatsDict
        Inherits Dictionary(Of String, String)

        Public Function GetItem(item) As String
            Return Me(item.ToString)
        End Function

        Public Sub New()
            Me.Add("_Inland_Large_Letter", "F")
            Me.Add("_Inland_Letter", "L")
            Me.Add("_Inland_format_Not_Applicable", "N")
            Me.Add("_Inland_Parcel", "P")
            Me.Add("_International_Parcel", "E")
            Me.Add("_International_Large_Letter", "G")
            Me.Add("_International_Format_Not_Applicable", "N")
            Me.Add("_International_Letter", "P")

        End Sub
    End Class


End Namespace

