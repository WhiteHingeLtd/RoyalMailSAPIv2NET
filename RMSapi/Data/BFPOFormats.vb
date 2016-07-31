Namespace SapiData

    Public Enum BFPOFormats
        _SD_0___100G_GBP500_COMP = 1
        _SD_101___500G_GBP500_COMP = 2
        _SD_501__1KG_GBP500_COMP = 3
        _SD_1001G___2KG_GBP500_COMP = 4
        _SD_0___100G_GBP1000_COMP = 5
        _SD_101___500G_GBP1000_COMP = 6
        _SD_501G__1KG_GBP1000_COMP = 7
        _SD_1001G___2KG_GBP1000_COMP = 8
        _SD_0___100G_GBP2500_COMP = 9
        _SD_501G__1KG_GBP2500_COMP = 10
        _SD_1001G___2KG_GBP2500_COMP = 11
        _SD_101___500G_GBP2500_COMP = 12
        _FORCES_AEROGRAMMES = 13

    End Enum

    Friend Class BFPOFormatsDict
        Inherits Dictionary(Of String, String)

        Public Function GetItem(item) As String
            Return Me(item.ToString)
        End Function

        Public Sub New()
            Me.Add("_SD_0___100G_GBP500_COMP", "EAA")
            Me.Add("_SD_101___500G_GBP500_COMP", "EAB")
            Me.Add("_SD_501__1KG_GBP500_COMP", "EAC")
            Me.Add("_SD_1001G___2KG_GBP500_COMP", "EAD")
            Me.Add("_SD_0___100G_GBP1000_COMP", "EBA")
            Me.Add("_SD_101___500G_GBP1000_COMP", "EBB")
            Me.Add("_SD_501G__1KG_GBP1000_COMP", "EBC")
            Me.Add("_SD_1001G___2KG_GBP1000_COMP", "EBD")
            Me.Add("_SD_0___100G_GBP2500_COMP", "ECA")
            Me.Add("_SD_501G__1KG_GBP2500_COMP", "ECC")
            Me.Add("_SD_1001G___2KG_GBP2500_COMP", "ECD")
            Me.Add("_SD_101___500G_GBP2500_COMP", "EVB")
            Me.Add("_FORCES_AEROGRAMMES", "FAE")

        End Sub
    End Class


End Namespace
