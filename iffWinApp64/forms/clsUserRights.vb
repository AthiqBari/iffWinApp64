Public Class clsUserRights
    Public landModule64 As Boolean = False
    Public landRatesForm As Boolean = False
    Public landbillAccess As Boolean = False
    Public landGenerateWaybill As Boolean = False
    Public landUpdateWaybill As Boolean = False
    Public landBillingTabAccess As Boolean = False
    Public landAllowToChangeITRRate As Boolean = False
    Public landITRPost As Boolean = False
    Public landSetupMasterFiles As Boolean = False
    Public iffVATBilling As Boolean = False
    Public landReportTab As Boolean = False


    Public Sub New()
        landModule64 = False
        landRatesForm = False
        landbillAccess = False
        landGenerateWaybill = False
        landUpdateWaybill = False
        landBillingTabAccess = False
        landAllowToChangeITRRate = False
        landITRPost = False
        iffVATBilling = False
        landSetupMasterFiles = False
        landReportTab = False
    End Sub
End Class
