'###################################################################################
'##    ServiceOfferings.vb                                  RoyalMailSAPIv2NET    ##
'##                           © 2016 White Hinge Ltd                              ##
'##                                                                               ##
'##   ==== Authored By (Enter your name here if you contributed ===============   ##
'##       Lee Butler (WHL),  Colin McAloon (WHL)                                  ##
'##                                                                               ##
'###################################################################################
Namespace SapiData
    ''' <summary>
    ''' Automatically generated using the Shipping API Reference Excel sheet.
    ''' </summary>
    Public Enum ServiceOfferings
        None = 0
        _ROYAL_MAIL_24_48 = 1
        _INTL_BUS_PARCELS_ZERO_SORT_HI_VOL_PRIORITY_I = 3
        _INTL_BUS_PARCELS_ZERO_SORT_HI_VOL_ECONOMY_ = 4
        _INTL_BUS_PARCELS_ZERO_SRT_LO_VOL_PRIORITY_ = 5
        _INTL_BUS_PARCELS_ZERO_SRT_LO_VOL_ECONOMY_ = 6
        _INTL_BUS_MAIL_L_LTR_CTRY_SRT_HI_VOL_PRIORITY_ = 7
        _INTL_BUS_MAIL_L_LTR_CTRY_SRT_HI_VOL_ECONOMY_ = 8
        _INTL_BUS_MAIL_L_LTR_CTRY_SRT_LO_VOL_PRIORITY_ = 9
        _INTL_BUS_MAIL_L_LTR_CTRY_SRT_LO_VOL_ECONOMY_ = 10
        _ROYAL_MAIL_24__SORT8___LL__FLAT_RATE = 11
        _ROYAL_MAIL_48__SORT8___LL__FLAT_RATE = 12
        _INTL_BUS_PARCELS_ZONE_SORT_PRIORITY_ = 13
        _INTL_BUS_PARCELS_ZONE_SORT_ECONOMY = 14
        _INTL_BUS_MAIL_LRG_LTR_ZONE_SORT_PRI = 15
        _INTL_BUS_MAIL_LRG_LTR_ZONE_SORT_ECONOMY = 16
        _INTL_BUS_MAIL_LRG_LTR_ZONE_SRT_PRI_MCH = 17
        _INTL_BUS_MAIL_L_LTR_ZONE_SRT_ECONOMY_MCH_ = 18
        _INTL_BUS_PARCELS_PRINT_DIRECT_PRIORITY = 19
        _INTL_BUS_PARCELS_PRINT_DIRECT_STANDARD = 20
        _INTL_BUS_PARCELS_PRINT_DIRECT_ECONOMY = 21
        _INTL_BUS_PARCELS_SIGNED_EXTRA_COMP_CTRY = 22
        _INTL_BUS_PARCELS_TRACKED = 23
        _INTL_BUS_PARCELS_TRACKED_EXTRA_COMP = 24
        _INTL_BUS_PARCELS_SIGNED = 25
        _INTL_BUS_PARCELS_SIGNED_EXTRA_COMP = 26
        _INTL_BUS_PARCELS_TRACKED_COUNTRY_PRICED = 27
        _INTL_BUS_PARCELS_TRACKED_EXTRA_COMP_CTRY = 28
        _INTL_BUS_PARCELS_SIGNED_COUNTRY_PRICED = 29
        _INTL_BUS_PARCELS_TRACKED_and_SIGNED = 30
        _INTL_BUS_PARCELS_TRACKED_SIGNED_XTR_COMP = 31
        _INTL_BUS_MAIL_TRACKED_and_SIGNED = 32
        _INTL_BUS_MAIL_TRACKED_and_SIGNED_XTR_COMP = 33
        _INTL_BUS_PARCELS_TRACKED_and_SIGNED__CTRY = 34
        _INTL_BUS_PARCEL_TRACKandSIGN_XTR_CMP_CTRY = 35
        _INTL_BUS_MAIL_TRACKED_and_SIGNED_COUNTRY = 36
        _INTL_BUS_MAIL_TRACK_and_SIGN_XTR_COMP_CTRY = 37
        _INTL_BUS_MAIL_TRACKED = 38
        _INTL_BUS_MAIL_TRACKED_EXTRA_COMP = 39
        _INTL_BUS_MAIL_TRACKED_COUNTRY_PRICED = 40
        _INTL_BUS_MAIL_TRACKED_EXTRA_COMP_CTRY = 41
        _INTL_BUS_MAIL_SIGNED = 42
        _INTL_BUS_MAIL_SIGNED_EXTRA_COMP = 43
        _INTL_BUS_MAIL_SIGNED_COUNTRY_PRICED = 44
        _INTL_BUS_MAIL_SIGNED_EXTRA_COMP_COUNTRY = 45
        _INTL_BUS_PARCELS_ZONE_SORT_PLUS_PRIORITY = 46
        _INTL_BUS_PARCELS_ZONE_SRT_PLUS_ECONOMY = 47
        _INTL_STANDARD_ON_ACCOUNT = 48
        _INTL_ECONOMY_ON_ACCOUNT = 49
        _INTERNATIONAL_SIGNED_ON_ACCOUNT = 50
        _INTL_SIGNED_ON_ACCOUNT_EXTRA_COMP = 51
        _INTERNATIONAL_TRACKED_ON_ACCOUNT = 52
        _INTL_TRACKED_ON_ACCOUNT_EXTRA_COMP = 53
        _INTERNATIONAL_TRACKED_and_SIGNED_ON_ACCT = 54
        _INTL_TRACKED_and_SIGNED_ON_ACCT_EXTRA_COMP = 55
        _INTL_BUS_MAIL_MIXED_ZONE_SORT_PRIORITY = 56
        _INTL_BUS_MAIL_MIXED_ZONE_SORT_ECONOMY = 57
        _INTL_BUS_MAIL_MIXED_ZONE_SORT_PRI_MCH = 58
        _INTL_BUS_MAIL_MIXED_ZONE_SRT_ECONOMY_MCH = 59
        _ROYAL_MAIL_48__LL__FLAT_RATE = 60
        _ROYAL_MAIL_24__SORT8___P__FLAT_RATE = 61
        _ROYAL_MAIL_48__SORT8___P__FLAT_RATE = 62
        _ROYAL_MAIL_24__SORT8___LL_P__DAILY_RATE = 63
        _ROYAL_MAIL_48__SORT8___LL_P__DAILY_RATE = 64
        _ROYAL_MAIL_24__LL__FLAT_RATE = 65
        _ROYAL_MAIL_24_48__P__FLAT_RATE = 66
        _INTL_BUS_PARCELS_MAX_SORT_ECONOMY = 68
        _INTL_BUS_PARCELS_MAX_SORT_STANDARD = 69
        _INTL_BUS_PARCELS_MAX_SORT_PRIORITY = 70
        _INTL_BUS_MAIL_LRG_LTR_MAX_SORT_ECONOMY = 71
        _INTL_BUS_MAIL_LRG_LTR_MAX_SORT_STANDARD = 72
        _INTL_BUS_MAIL_LRG_LTR_MAX_SORT_PRIORITY = 73
        '_ROYAL_MAIL_TRACKED_RETURNS_24 = 74        'These services no longer available on this value.
        '_ROYAL_MAIL_TRACKED_RETURNS_48 = 75        'These services no longer available on this value.
        _ROYAL_MAIL_48__SORT8___P__DAILY_RATE = 76
        _ROYAL_MAIL_24__LL__DAILY_RATE = 77
        _ROYAL_MAIL_24__P__DAILY_RATE = 78
        _ROYAL_MAIL_48__LL__DAILY_RATE = 79
        _ROYAL_MAIL_48__P__DAILY_RATE = 80
        _ROYAL_MAIL_24__P__FLAT_RATE = 81
        _ROYAL_MAIL_48__P__FLAT_RATE = 82
        _ROYAL_MAIL_24__SORT8___LL__DAILY_RATE = 83
        _ROYAL_MAIL_24__SORT8___P__DAILY_RATE = 84
        _ROYAL_MAIL_48__SORT8___LL__DAILY_RATE = 85
        _SD_GUARANTEED_BY_1PM = 86
        _SD_GUARANTEED_BY_1PM__GBP1000_ = 87
        _SD_GUARANTEED_BY_1PM__GBP2500_ = 88
        _SD_GUARANTEED_BY_9AM = 89
        _SD_GUARANTEED_BY_9AM__GBP1000_ = 90
        _SD_GUARANTEED_BY_9AM__GBP2500_ = 91
        _1ST_AND_2ND_CLASS_ACCOUNT_MAIL = 92
        _ROYAL_MAIL_TRACKED_48__HV_ = 94
        _ROYAL_MAIL_TRACKED_24 = 95
        _ROYAL_MAIL_TRACKED_48 = 96
        _ROYAL_MAIL_TRACKED_24__HV_ = 97
        _ROYAL_MAIL_TRACKED_24__LBT_ = 98
        _ROYAL_MAIL_TRACKED_48__LBT_ = 99
        _ROYAL_MAIL_TRACKED_RETURNS_24 = 100        'New! 23rd Feb 2015
        _ROYAL_MAIL_TRACKED_RETURNS_48 = 101        'New! 23rd Feb 2015
        _INTL_BUS_PARCELS_ZERO_SORT_PRIORITY = 102
        _INTL_BUS_PARCELS_ZERO_SORT_ECONOMY = 103
        _INTL_BUS_MAIL_LRG_LTR_ZERO_SRT_PRIORITY = 104
        _INTL_BUS_MAIL_LRG_LTR_ZERO_SORT_ECONOMY = 105
        _INTL_BUS_MAIL_LRG_LTR_ZERO_SRT_PRI_MCH = 106
        _INTL_BUS_MAIL_L_LTR_ZERO_SRT_ECONOMY_MCH = 107
        _INTL_BUS_MAIL_MIXED_ZERO_SORT_PRIORITY = 108
        _INTL_BUS_MAIL_MIXED_ZERO_SORT_ECONOMY = 109
        _INTL_BUS_MAIL_MIXED_ZERO_SORT_PRI_MCH = 110
        _INTL_BUS_MAIL_MIXD_ZERO_SRT_ECONOMY_MCH = 111
        _INTL_BUS_MAIL_MIXED_ZERO_SORT_PREMIUM = 112
    End Enum

    'Not an enum, but ti's going here anyway.
    Friend Class ServiceOfferingsDict
        Inherits Dictionary(Of String, String)

        Public Function GetItem(item) As String
            If Not item = 0 Then
                Return Me(item.ToString)
            Else
                Return ""
            End If
        End Function

        Public Sub New()
            Me.Add("_ROYAL_MAIL_24_48", "CRL")
            Me.Add("_INTL_BUS_PARCELS_ZERO_SORT_HI_VOL_PRIORITY_I", "DE1")
            Me.Add("_INTL_BUS_PARCELS_ZERO_SORT_HI_VOL_ECONOMY_", "DE3")
            Me.Add("_INTL_BUS_PARCELS_ZERO_SRT_LO_VOL_PRIORITY_", "DE4")
            Me.Add("_INTL_BUS_PARCELS_ZERO_SRT_LO_VOL_ECONOMY_", "DE6")
            Me.Add("_INTL_BUS_MAIL_L_LTR_CTRY_SRT_HI_VOL_PRIORITY_", "DG1")
            Me.Add("_INTL_BUS_MAIL_L_LTR_CTRY_SRT_HI_VOL_ECONOMY_", "DG3")
            Me.Add("_INTL_BUS_MAIL_L_LTR_CTRY_SRT_LO_VOL_PRIORITY_", "DG4")
            Me.Add("_INTL_BUS_MAIL_L_LTR_CTRY_SRT_LO_VOL_ECONOMY_", "DG6")
            Me.Add("_ROYAL_MAIL_24__SORT8___LL__FLAT_RATE", "FS1")
            Me.Add("_ROYAL_MAIL_48__SORT8___LL__FLAT_RATE", "FS2")
            Me.Add("_INTL_BUS_PARCELS_ZONE_SORT_PRIORITY_", "IE1")
            Me.Add("_INTL_BUS_PARCELS_ZONE_SORT_ECONOMY", "IE3")
            Me.Add("_INTL_BUS_MAIL_LRG_LTR_ZONE_SORT_PRI", "IG1")
            Me.Add("_INTL_BUS_MAIL_LRG_LTR_ZONE_SORT_ECONOMY", "IG3")
            Me.Add("_INTL_BUS_MAIL_LRG_LTR_ZONE_SRT_PRI_MCH", "IG4")
            Me.Add("_INTL_BUS_MAIL_L_LTR_ZONE_SRT_ECONOMY_MCH_", "IG6")
            Me.Add("_INTL_BUS_PARCELS_PRINT_DIRECT_PRIORITY", "MB1")
            Me.Add("_INTL_BUS_PARCELS_PRINT_DIRECT_STANDARD", "MB2")
            Me.Add("_INTL_BUS_PARCELS_PRINT_DIRECT_ECONOMY", "MB3")
            Me.Add("_INTL_BUS_PARCELS_SIGNED_EXTRA_COMP_CTRY", "MP0")
            Me.Add("_INTL_BUS_PARCELS_TRACKED", "MP1")
            Me.Add("_INTL_BUS_PARCELS_TRACKED_EXTRA_COMP", "MP4")
            Me.Add("_INTL_BUS_PARCELS_SIGNED", "MP5")
            Me.Add("_INTL_BUS_PARCELS_SIGNED_EXTRA_COMP", "MP6")
            Me.Add("_INTL_BUS_PARCELS_TRACKED_COUNTRY_PRICED", "MP7")
            Me.Add("_INTL_BUS_PARCELS_TRACKED_EXTRA_COMP_CTRY", "MP8")
            Me.Add("_INTL_BUS_PARCELS_SIGNED_COUNTRY_PRICED", "MP9")
            Me.Add("_INTL_BUS_PARCELS_TRACKED_and_SIGNED", "MTA")
            Me.Add("_INTL_BUS_PARCELS_TRACKED_SIGNED_XTR_COMP", "MTB")
            Me.Add("_INTL_BUS_MAIL_TRACKED_and_SIGNED", "MTC")
            Me.Add("_INTL_BUS_MAIL_TRACKED_and_SIGNED_XTR_COMP", "MTD")
            Me.Add("_INTL_BUS_PARCELS_TRACKED_and_SIGNED__CTRY", "MTE")
            Me.Add("_INTL_BUS_PARCEL_TRACKandSIGN_XTR_CMP_CTRY", "MTF")
            Me.Add("_INTL_BUS_MAIL_TRACKED_and_SIGNED_COUNTRY", "MTG")
            Me.Add("_INTL_BUS_MAIL_TRACK_and_SIGN_XTR_COMP_CTRY", "MTH")
            Me.Add("_INTL_BUS_MAIL_TRACKED", "MTI")
            Me.Add("_INTL_BUS_MAIL_TRACKED_EXTRA_COMP", "MTJ")
            Me.Add("_INTL_BUS_MAIL_TRACKED_COUNTRY_PRICED", "MTK")
            Me.Add("_INTL_BUS_MAIL_TRACKED_EXTRA_COMP_CTRY", "MTL")
            Me.Add("_INTL_BUS_MAIL_SIGNED", "MTM")
            Me.Add("_INTL_BUS_MAIL_SIGNED_EXTRA_COMP", "MTN")
            Me.Add("_INTL_BUS_MAIL_SIGNED_COUNTRY_PRICED", "MTO")
            Me.Add("_INTL_BUS_MAIL_SIGNED_EXTRA_COMP_COUNTRY", "MTP")
            Me.Add("_INTL_BUS_PARCELS_ZONE_SORT_PLUS_PRIORITY", "MTQ")
            Me.Add("_INTL_BUS_PARCELS_ZONE_SRT_PLUS_ECONOMY", "MTS")
            Me.Add("_INTL_STANDARD_ON_ACCOUNT", "OLA")
            Me.Add("_INTL_ECONOMY_ON_ACCOUNT", "OLS")
            Me.Add("_INTERNATIONAL_SIGNED_ON_ACCOUNT", "OSA")
            Me.Add("_INTL_SIGNED_ON_ACCOUNT_EXTRA_COMP", "OSB")
            Me.Add("_INTERNATIONAL_TRACKED_ON_ACCOUNT", "OTA")
            Me.Add("_INTL_TRACKED_ON_ACCOUNT_EXTRA_COMP", "OTB")
            Me.Add("_INTERNATIONAL_TRACKED_and_SIGNED_ON_ACCT", "OTC")
            Me.Add("_INTL_TRACKED_and_SIGNED_ON_ACCT_EXTRA_COMP", "OTD")
            Me.Add("_INTL_BUS_MAIL_MIXED_ZONE_SORT_PRIORITY", "OZ1")
            Me.Add("_INTL_BUS_MAIL_MIXED_ZONE_SORT_ECONOMY", "OZ3")
            Me.Add("_INTL_BUS_MAIL_MIXED_ZONE_SORT_PRI_MCH", "OZ4")
            Me.Add("_INTL_BUS_MAIL_MIXED_ZONE_SRT_ECONOMY_MCH", "OZ6")
            Me.Add("_ROYAL_MAIL_48__LL__FLAT_RATE", "PK0")
            Me.Add("_ROYAL_MAIL_24__SORT8___P__FLAT_RATE", "PK1")
            Me.Add("_ROYAL_MAIL_48__SORT8___P__FLAT_RATE", "PK2")
            Me.Add("_ROYAL_MAIL_24__SORT8___LL_P__DAILY_RATE", "PK3")
            Me.Add("_ROYAL_MAIL_48__SORT8___LL_P__DAILY_RATE", "PK4")
            Me.Add("_ROYAL_MAIL_24__LL__FLAT_RATE", "PK9")
            Me.Add("_ROYAL_MAIL_24_48__P__FLAT_RATE", "PPF")
            Me.Add("_INTL_BUS_PARCELS_MAX_SORT_ECONOMY", "PS0")
            Me.Add("_INTL_BUS_PARCELS_MAX_SORT_STANDARD", "PSC")
            Me.Add("_INTL_BUS_PARCELS_MAX_SORT_PRIORITY", "PS9")
            Me.Add("_INTL_BUS_MAIL_LRG_LTR_MAX_SORT_ECONOMY", "PS8")
            Me.Add("_INTL_BUS_MAIL_LRG_LTR_MAX_SORT_STANDARD", "PSB")
            Me.Add("_INTL_BUS_MAIL_LRG_LTR_MAX_SORT_PRIORITY", "PS7")
            Me.Add("_ROYAL_MAIL_48__SORT8___P__DAILY_RATE", "RM0")
            Me.Add("_ROYAL_MAIL_24__LL__DAILY_RATE", "RM1")
            Me.Add("_ROYAL_MAIL_24__P__DAILY_RATE", "RM2")
            Me.Add("_ROYAL_MAIL_48__LL__DAILY_RATE", "RM3")
            Me.Add("_ROYAL_MAIL_48__P__DAILY_RATE", "RM4")
            Me.Add("_ROYAL_MAIL_24__P__FLAT_RATE", "RM5")
            Me.Add("_ROYAL_MAIL_48__P__FLAT_RATE", "RM6")
            Me.Add("_ROYAL_MAIL_24__SORT8___LL__DAILY_RATE", "RM7")
            Me.Add("_ROYAL_MAIL_24__SORT8___P__DAILY_RATE", "RM8")
            Me.Add("_ROYAL_MAIL_48__SORT8___LL__DAILY_RATE", "RM9")
            Me.Add("_SD_GUARANTEED_BY_1PM", "SD1")
            Me.Add("_SD_GUARANTEED_BY_1PM__GBP1000_", "SD2")
            Me.Add("_SD_GUARANTEED_BY_1PM__GBP2500_", "SD3")
            Me.Add("_SD_GUARANTEED_BY_9AM", "SD4")
            Me.Add("_SD_GUARANTEED_BY_9AM__GBP1000_", "SD5")
            Me.Add("_SD_GUARANTEED_BY_9AM__GBP2500_", "SD6")
            Me.Add("_1ST_AND_2ND_CLASS_ACCOUNT_MAIL", "STL")
            Me.Add("_ROYAL_MAIL_TRACKED_48__HV_", "TPL")
            Me.Add("_ROYAL_MAIL_TRACKED_24", "TPN")
            Me.Add("_ROYAL_MAIL_TRACKED_48", "TPS")
            Me.Add("_ROYAL_MAIL_TRACKED_24__HV_", "TRM")
            Me.Add("_ROYAL_MAIL_TRACKED_24__LBT_", "TRN")
            Me.Add("_ROYAL_MAIL_TRACKED_48__LBT_", "TRS")
            Me.Add("_ROYAL_MAIL_TRACKED_RETURNS_24", "TSN")
            Me.Add("_ROYAL_MAIL_TRACKED_RETURNS_48", "TSS")
            Me.Add("_INTL_BUS_PARCELS_ZERO_SORT_PRIORITY", "WE1")
            Me.Add("_INTL_BUS_PARCELS_ZERO_SORT_ECONOMY", "WE3")
            Me.Add("_INTL_BUS_MAIL_LRG_LTR_ZERO_SRT_PRIORITY", "WG1")
            Me.Add("_INTL_BUS_MAIL_LRG_LTR_ZERO_SORT_ECONOMY", "WG3")
            Me.Add("_INTL_BUS_MAIL_LRG_LTR_ZERO_SRT_PRI_MCH", "WG4")
            Me.Add("_INTL_BUS_MAIL_L_LTR_ZERO_SRT_ECONOMY_MCH", "WG6")
            Me.Add("_INTL_BUS_MAIL_MIXED_ZERO_SORT_PRIORITY", "WW1")
            Me.Add("_INTL_BUS_MAIL_MIXED_ZERO_SORT_ECONOMY", "WW3")
            Me.Add("_INTL_BUS_MAIL_MIXED_ZERO_SORT_PRI_MCH", "WW4")
            Me.Add("_INTL_BUS_MAIL_MIXD_ZERO_SRT_ECONOMY_MCH", "WW6")
            Me.Add("_INTL_BUS_MAIL_MIXED_ZERO_SORT_PREMIUM", "ZC1")
        End Sub

    End Class
End Namespace
