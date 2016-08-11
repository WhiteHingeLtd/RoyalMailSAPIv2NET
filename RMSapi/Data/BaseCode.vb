'###################################################################################
'##    BaseCode.vb                                          RoyalMailSAPIv2NET    ##
'##                           © 2016 White Hinge Ltd                              ##
'##                                                                               ##
'##   ==== Authored By (Enter your name here if you contributed ===============   ##
'##       Lee Butler (WHL),  Colin McAloon (WHL)                                  ##
'##                                                                               ##
'###################################################################################

'This file does not build.

Namespace SapiData

    Public Enum <Name>
            
    End Enum

    Friend Class <Name>Dict
        Inherits Dictionary(Of String, String)

        Public Function GetItem(item) As String
            If Not item = 0 Then
                Return Me(item.ToString)
            Else
                Return ""
            End If
        End Function

        Public Sub New()

        End Sub
    End Class


End Namespace
