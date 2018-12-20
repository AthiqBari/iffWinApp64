Public Class clsCompanyAndBranch
    Public companyID As Integer
    Public companyName As String
    Public companyAddress As String
    Public companyAddress2 As String
    Public companyWebsite As String
    Public branchID As Integer
    Public branchName As String
    Public branchAddress As String
    Public branchEmail As String
    Public branchContact As String
    Public branchCode As String
    Public companyEmail As String
    Public VATRegNo As String
    Public branchReportFolder As String
    Public companyContactPerson As String
    Public invoiceTemplateVAT As String
    Public crmQuoteTemplate As String
    Public branchDocPrefix As String

    Public customizerptpath As String


    Public VATPercentage As Double
    Public Sub New()
        companyID = 0
        companyName = ""
        companyAddress = ""
        companyAddress2 = ""
        companyWebsite = ""
        branchID = 0
        branchName = ""
        branchAddress = ""
        branchEmail = ""
        branchContact = ""
        companyEmail = ""
        companyContactPerson = ""
        invoiceTemplateVAT = ""
        VATRegNo = ""
        branchCode = ""
        branchReportFolder = ""
        crmQuoteTemplate = ""
        branchDocPrefix = ""
        customizerptpath = ""
        VATPercentage = 0
    End Sub
End Class
