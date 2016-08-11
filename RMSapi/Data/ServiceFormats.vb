'###################################################################################
'##    ServiceFormats.vb                                    RoyalMailSAPIv2NET    ##
'##                           © 2016 White Hinge Ltd                              ##
'##                                                                               ##
'##   ==== Authored By (Enter your name here if you contributed ===============   ##
'##       Lee Butler (WHL),  Colin McAloon (WHL)                                  ##
'##                                                                               ##
'###################################################################################
Namespace SapiData

    Public Enum ServiceFormats
        None = 0
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
            If Not item = 0 Then
                Return Me(item.ToString)
            Else
                Return ""
            End If
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

