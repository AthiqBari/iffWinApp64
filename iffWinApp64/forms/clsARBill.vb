Public Class clsARBillMaster
    Public invRecID As Integer
    Public iNumber As String
    Public iDate As Date
    Public iDueDate As Date
    Public invRemarks As String
    Public invPost As String
    Public ClientNameEnglish As String
    Public ClientNameArabic As String
    Public ClientVATNumber As String
    Public ClientAddress As String

    Public ShipmentNumber As String
    Public Shipper As String
    Public Consignee As String
    Public POL As String
    Public POD As String
    Public RefNo As String
    Public BL As String
    Public ETA As String
    Public ETD As String
    Public ServiceType As String
    Public Qty As String
    Public GrossWgt As String
    Public ChgblWgt As String
    Public CargoDetail As String
    Public InvoiceNotes As String
    Public PackingType As String
    Public JobCreatedOn As String

    Public invAdvanceAmount As Double

    Public invCreatedBy As String

    Public bankAccountName As String
    Public bankName As String
    Public bankAccountNumber As String
    Public bankIBAN As String
    Public bankSWIFT As String
    Public bankAddress As String




    Public Sub New()

        invRecID = 0
        iNumber = ""
        iDate = Nothing
        iDueDate = Nothing
        invPost = ""
        invRemarks = ""
        invAdvanceAmount = 0
        ClientNameEnglish = ""
        ClientNameArabic = ""
        ClientVATNumber = ""
        ClientAddress = ""
        ShipmentNumber = ""
        Shipper = ""
        Consignee = ""
        POL = ""
        POD = ""
        RefNo = ""
        BL = ""
        ETA = ""
        ETD = ""
        ServiceType = ""
        Qty = ""
        GrossWgt = ""
        ChgblWgt = ""
        invCreatedBy = ""
        CargoDetail = ""
        bankAccountName = ""
        bankName = ""
        bankAccountNumber = ""
        bankIBAN = ""
        bankSWIFT = ""
        bankAddress = ""
        InvoiceNotes = ""
        PackingType = ""
        JobCreatedOn = ""


    End Sub
End Class
