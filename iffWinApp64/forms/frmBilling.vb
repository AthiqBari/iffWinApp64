
'billing section
Imports Telerik.WinControls.UI
Imports System.Data.Sql
Imports System.Data
Imports System.Data.SqlClient
Imports System.Exception
Imports System.Data.OleDb
Imports System.IO
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Text.RegularExpressions


Public Class frmBilling
    'temp code
    'Dim invoiceTemplateVAT As String = "iffInvoiceTemplateVAT001"
    Dim arBillMaster As New clsARBillMaster()
    Dim dsPrint As New DataSet()
    Dim actRecID As Integer
    Dim actno As String = ""
    Dim invNoStr As String = ""



    Private Sub frmBilling_Load(sender As Object, e As EventArgs) Handles Me.Load
        cmbSearchBy.SelectedIndex = 0   'arbill
        ComboBox1.SelectedIndex = 0 'shipmentno
        panelText.Visible = True
        txtSearchBy.Focus()

        radDateFrom.Text = Today.Date
        radDateTo.Text = Today.Date
        rbFinalInvoice.Checked = True

        Call getRecentPrintedItems()
        Me.Top = 1
        Me.Left = 1

        If appUserInfo.OnlyJobCost Then
            rbFinalInvoice.Checked = False
            rbFinalInvoice.Visible = False
        End If
        'radDeliveryDate.SetToNullValue()
    End Sub

    Private Sub getRecentPrintedItems()
        Try
            Dim dsPrint As New DataSet
            Me.Cursor = Cursors.WaitCursor
            RadGridView2.DataSource = Nothing
            sql_String = "select top 15 actno [Job],Inv#,[date] [InvDate],Client,invremarks [Remarks],invrecid from [viewshipmentinvoicingreport_y2017] "
            sql_String += " where invrecid in (select top 15 recid from printlog where userid='" & appUserInfo.Code & "' order by logdate desc)"
            dsPrint = setDataList(sql_String)
            If dsPrint.Tables(0).Rows.Count > 0 Then
                RadGridView2.DataSource = dsPrint.Tables(0)
                RadGridView2.Columns(5).IsVisible = False
                RadGridView2.MasterTemplate.BestFitColumns()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, vbCr, "getRecentPrintedItems()")
        Finally
            Me.Cursor = Cursors.Default
        End Try



    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim ds As New DataSet
        Dim i As Integer = 0

        '  If String.IsNullOrEmpty(txtSearchBy.Text) Then Exit Sub


        Dim vfldName As String = "[actno]"

        Select Case ComboBox1.SelectedIndex
            Case 0 : vfldName = "[actno]"
            Case 1 : vfldName = "[inv#]"
            Case 2 : vfldName = "[date]"
        End Select

        If vfldName <> "[date]" And String.IsNullOrEmpty(txtSearchBy.Text) Then Exit Sub

        Try
            sql_String = "select * from [viewshipmentinvoicingreport_y2017] where branchid=" & appCompanyInfo.branchID
            If vfldName = "[date]" Then sql_String += " and [Date] between '" & Date.Parse(radDateFrom.Text).ToString("yyyy'/'MM'/'dd") & "' and '" & Date.Parse(radDateTo.Text).ToString("yyyy'/'MM'/'dd") & "'"
            If vfldName = "[actno]" Then sql_String += " and actno like '%" & txtSearchBy.Text & "%'"
            If vfldName = "[inv#]" Then sql_String += " and [inv#]=" & txtSearchBy.Text
            sql_String += " order by [date] "

            Me.Cursor = Cursors.WaitCursor
            RadGridView1.DataSource = Nothing
            ds = setDataList(sql_String)
            If ds.Tables(0).Rows.Count > 0 Then
                'lblToolTip.Text = "Found: " & ds.Tables(0).Rows.Count
                RadGridView1.DataSource = ds.Tables(0)
                RadGridView1.Columns("actno").HeaderText = "Job"
                RadGridView1.Columns("date").HeaderText = "InvDate"
                RadGridView1.Columns("InvAmt").HeaderText = "Amount"
                'dsPrintSearch = ds
                For i = 9 To RadGridView1.Columns.Count - 1
                    RadGridView1.Columns(i).IsVisible = False
                Next i
                RadGridView1.MasterTemplate.BestFitColumns()
            End If

            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try

    End Sub

    Private Sub getDocumentList(invRecid As Integer)
        If invRecid = 0 Then Exit Sub
        'get invoice details
        dsPrint = getARBill(invRecid)
        Dim excelFile As String = ""

        If String.IsNullOrEmpty(appCompanyInfo.invoiceTemplateVAT) Then MsgBox("Missing Template File, Cannot Print Invoice", vbCritical, "Print Request") : Exit Sub
        If chkPDF.CheckState = CheckState.Checked Then

            If rbFinalInvoice.Checked Then excelFile = ExportToExcel_Invoice()
            If rbJobCost.Checked Then excelFile = ExportToExcel_JobCost()


            If Not String.IsNullOrEmpty(excelFile) Then ExportToPDF(excelFile, "5512730")
        End If
        Call getRecentPrintedItems()
    End Sub

    Private Function getARBill(BillingInvoiceDetail_RecID As Integer) As DataSet

        Dim ds As New DataSet
        Dim command As New SqlCommand
        Dim adapter As New SqlDataAdapter

        Try
            If sql_CNN.State = ConnectionState.Closed Then createConnection()
            If sql_CNN.State = ConnectionState.Open Then 'valid cnn

                Dim str1 As String
                str1 = "EXEC getARBillY2018 " & BillingInvoiceDetail_RecID
                Dim adpt As New SqlDataAdapter(str1, sql_CNN)
                adpt.Fill(ds)
                adpt.Dispose()

                If ds.Tables(0).Rows.Count > 0 Then 'invoice details
                    arBillMaster.ClientNameEnglish = ds.Tables(0).Rows(0).Item("cltnameE")
                    arBillMaster.ClientNameArabic = ds.Tables(0).Rows(0).Item("cltnameA")
                    arBillMaster.ClientVATNumber = ds.Tables(0).Rows(0).Item("vatno")
                    arBillMaster.ClientAddress = ds.Tables(0).Rows(0).Item("cltaddr")

                    arBillMaster.iNumber = ds.Tables(0).Rows(0).Item("brcode") & "" & Format(ds.Tables(0).Rows(0).Item("invno"), "00000")
                    arBillMaster.invRecID = BillingInvoiceDetail_RecID
                    arBillMaster.iDate = ds.Tables(0).Rows(0).Item("invdate")
                    arBillMaster.iDueDate = ds.Tables(0).Rows(0).Item("invduedate")
                    arBillMaster.invPost = ds.Tables(0).Rows(0).Item("invpost")
                    arBillMaster.ShipmentNumber = ds.Tables(0).Rows(0).Item("actno")
                    arBillMaster.invAdvanceAmount = ds.Tables(0).Rows(0).Item("AdvRev")
                    If Not IsDBNull(ds.Tables(0).Rows(0).Item("invrem")) Then arBillMaster.invRemarks = ds.Tables(0).Rows(0).Item("invrem")

                End If

                If ds.Tables(1).Rows.Count > 0 Then 'bank branch details
                    If Not IsDBNull(ds.Tables(1).Rows(0).Item("aname")) Then arBillMaster.bankAccountName = ds.Tables(1).Rows(0).Item("aname")
                    If Not IsDBNull(ds.Tables(1).Rows(0).Item("bname")) Then arBillMaster.bankName = ds.Tables(1).Rows(0).Item("bname")
                    If Not IsDBNull(ds.Tables(1).Rows(0).Item("acc")) Then arBillMaster.bankAccountNumber = ds.Tables(1).Rows(0).Item("acc")
                    If Not IsDBNull(ds.Tables(1).Rows(0).Item("iban")) Then arBillMaster.bankIBAN = ds.Tables(1).Rows(0).Item("iban")
                    If Not IsDBNull(ds.Tables(1).Rows(0).Item("baddr")) Then arBillMaster.bankAddress = ds.Tables(1).Rows(0).Item("baddr")
                    If Not IsDBNull(ds.Tables(1).Rows(0).Item("swift")) Then arBillMaster.bankSWIFT = ds.Tables(1).Rows(0).Item("swift")
                End If

                If ds.Tables(2).Rows.Count > 0 Then 'shipment details
                    If Not IsDBNull(ds.Tables(2).Rows(0).Item("shipper")) Then arBillMaster.Shipper = ds.Tables(2).Rows(0).Item("shipper")
                    If Not IsDBNull(ds.Tables(2).Rows(0).Item("cnee")) Then arBillMaster.Consignee = ds.Tables(2).Rows(0).Item("cnee")

                    If Microsoft.VisualBasic.Left(arBillMaster.ShipmentNumber, 1) = "L" Then
                        If Not IsDBNull(ds.Tables(2).Rows(0).Item("loading point")) Then arBillMaster.POL = UCase(ds.Tables(2).Rows(0).Item("loading point"))
                        If Not IsDBNull(ds.Tables(2).Rows(0).Item("place of delivery")) Then arBillMaster.POD = UCase(ds.Tables(2).Rows(0).Item("place of delivery"))
                    Else
                        If Not IsDBNull(ds.Tables(2).Rows(0).Item("polname")) Then arBillMaster.POL = ds.Tables(2).Rows(0).Item("polname") & " " & ds.Tables(2).Rows(0).Item("polcountry")
                        If Not IsDBNull(ds.Tables(2).Rows(0).Item("podname")) Then arBillMaster.POD = ds.Tables(2).Rows(0).Item("podname") & " " & ds.Tables(2).Rows(0).Item("podcountry")
                    End If

                    'If Not IsDBNull(ds.Tables(2).Rows(0).Item("polname")) Then arBillMaster.POL = ds.Tables(2).Rows(0).Item("polname")
                    'If Not IsDBNull(ds.Tables(2).Rows(0).Item("podname")) Then arBillMaster.POD = ds.Tables(2).Rows(0).Item("podname")
                    If Not IsDBNull(ds.Tables(2).Rows(0).Item("clientref")) Then arBillMaster.RefNo = ds.Tables(2).Rows(0).Item("clientref")
                    If Not IsDBNull(ds.Tables(2).Rows(0).Item("blno")) Then arBillMaster.BL = ds.Tables(2).Rows(0).Item("blno")
                    If Not IsDBNull(ds.Tables(2).Rows(0).Item("arrivaldate")) Then arBillMaster.ETA = ds.Tables(2).Rows(0).Item("arrivaldate")
                    If Not IsDBNull(ds.Tables(2).Rows(0).Item("departure date")) Then arBillMaster.ETD = ds.Tables(2).Rows(0).Item("departure date")
                    If Not IsDBNull(ds.Tables(2).Rows(0).Item("service")) Then arBillMaster.ServiceType = ds.Tables(2).Rows(0).Item("service")
                    If Not IsDBNull(ds.Tables(2).Rows(0).Item("pcs")) Then arBillMaster.Qty = ds.Tables(2).Rows(0).Item("pcs")
                    If Not IsDBNull(ds.Tables(2).Rows(0).Item("wght")) Then arBillMaster.GrossWgt = ds.Tables(2).Rows(0).Item("wght")
                    If Not IsDBNull(ds.Tables(2).Rows(0).Item("chgblwght")) Then arBillMaster.ChgblWgt = ds.Tables(2).Rows(0).Item("chgblwght")
                    If Not IsDBNull(ds.Tables(2).Rows(0).Item("actdescription")) Then arBillMaster.CargoDetail = ds.Tables(2).Rows(0).Item("actdescription")
                    If Not IsDBNull(ds.Tables(2).Rows(0).Item("packing type")) Then arBillMaster.CargoDetail = ds.Tables(2).Rows(0).Item("packing type")
                    arBillMaster.JobCreatedOn = ds.Tables(2).Rows(0).Item("JobAddedOn")
                End If

                Return ds
                ' Return True
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
            Return Nothing
        Finally
            command.Dispose()
        End Try



    End Function

    Private Function ExportToExcel_Invoice() As String
        Try

            Me.Cursor = Cursors.WaitCursor
            Dim i As Integer = 0
            Dim endColumnIndex As Integer = 0

            Dim cellRowIndex As Integer = 1
            Dim cellColumnIndex As Integer = 1

            Dim destinationFile As String = copyTemplate(appCompanyInfo.invoiceTemplateVAT & ".xls", "VAT INVOICE-" & actno & "-" & arBillMaster.iNumber)
            If IO.File.Exists(destinationFile) = False Then
                Me.Cursor = Cursors.WaitCursor
                MsgBox("File does not exists " & destinationFile, MsgBoxStyle.Exclamation, "File Not Found")
                Return ""
                Exit Function
            End If

            frmWaitForm.lblTitle.Text = "Preparing Invoice. Please Wait..!"
            frmWaitForm.Show()
            frmWaitForm.Refresh()
            Me.Cursor = Cursors.WaitCursor

            '.net 4.5
            Dim xlApp As New Excel.Application ' Microsoft.Office.Interop.Excel.ApplicationClass
            Dim xlWorkBook As Microsoft.Office.Interop.Excel.Workbook
            Dim xlWorkSheet As Microsoft.Office.Interop.Excel.Worksheet
            Dim objRadGrid As RadGridView = Nothing

            'objRadGrid = RadGridView2
            xlWorkBook = xlApp.Workbooks.Open(destinationFile, Password:="5512730")
            xlWorkSheet = xlWorkBook.Worksheets("Sheet1")

            'write company/branch report header section -------------------------------------------*--------------------------------
            xlWorkSheet.Cells(1, 3) = appCompanyInfo.companyName
            xlWorkSheet.Cells(2, 3) = appCompanyInfo.branchName
            xlWorkSheet.Cells(3, 3) = appCompanyInfo.branchAddress
            xlWorkSheet.Cells(4, 3) = appCompanyInfo.companyWebsite ' appCompanyInfo.branchContact & " " & appCompanyInfo.branchEmail
            xlWorkSheet.Cells(10, 9) = appCompanyInfo.VATRegNo.ToString
            'xlWorkSheet.Cells(5, 3) = appCompanyInfo.companyWebsite
            '---------------------------------------------------------------------------'---*----------------------------------------
            xlWorkSheet.Cells(7, 1) = arBillMaster.ClientNameArabic
            xlWorkSheet.Cells(8, 1) = arBillMaster.ClientNameEnglish
            xlWorkSheet.Cells(9, 1) = arBillMaster.ClientAddress
            xlWorkSheet.Cells(10, 4) = arBillMaster.ClientVATNumber

            xlWorkSheet.Cells(6, 9) = arBillMaster.iNumber
            xlWorkSheet.Cells(7, 9) = arBillMaster.iDate
            xlWorkSheet.Cells(8, 9) = arBillMaster.iDueDate
            xlWorkSheet.Cells(9, 9) = arBillMaster.ShipmentNumber


            xlWorkSheet.Cells(12, 1) = arBillMaster.Shipper
            xlWorkSheet.Cells(12, 6) = arBillMaster.Consignee

            xlWorkSheet.Cells(14, 9) = arBillMaster.RefNo
            xlWorkSheet.Cells(15, 9) = arBillMaster.BL
            xlWorkSheet.Cells(16, 9) = arBillMaster.ETA
            xlWorkSheet.Cells(17, 9) = arBillMaster.ETD

            xlWorkSheet.Cells(15, 1) = arBillMaster.POL
            xlWorkSheet.Cells(17, 1) = arBillMaster.POD

            xlWorkSheet.Cells(19, 1) = arBillMaster.ServiceType
            xlWorkSheet.Cells(19, 3) = arBillMaster.Qty
            xlWorkSheet.Cells(19, 5) = arBillMaster.GrossWgt
            xlWorkSheet.Cells(19, 7) = arBillMaster.ChgblWgt

            xlWorkSheet.Cells(21, 1) = arBillMaster.CargoDetail
            xlWorkSheet.Cells(44, 1) = arBillMaster.invRemarks

            xlWorkSheet.Cells(46, 8) = "Printed By " & appUserInfo.Name
            xlWorkSheet.Cells(47, 4) = arBillMaster.bankAccountName
            xlWorkSheet.Cells(48, 4) = arBillMaster.bankName
            xlWorkSheet.Cells(49, 4) = arBillMaster.bankAccountNumber
            xlWorkSheet.Cells(50, 4) = arBillMaster.bankIBAN
            xlWorkSheet.Cells(51, 4) = arBillMaster.bankSWIFT

            'read dsprint for invoice line items
            Dim colDescE As String = ""
            Dim colDescA As String = ""
            Dim dblRate As Double = 0
            Dim dblVATPercent As Double = 0
            Dim dblAdvanceAR As Double = 0

            cellRowIndex = 24 'start from

            If dsPrint.Tables(0).Rows.Count > 0 Then
                For Each Row As DataRow In dsPrint.Tables(0).Rows
                    'For Each Coll As DataColumn In dsPrint.Tables(0).Columns
                    colDescE = Row("chgNameE").ToString()
                    colDescA = Row("chgNameA").ToString()
                    dblRate = CDbl(Row("revenue"))
                    dblVATPercent = CDbl(Row("vatpercent"))
                    dblAdvanceAR = CDbl(Row("AdvRev"))
                    xlWorkSheet.Cells(cellRowIndex, 1) = colDescE & " " & colDescA
                    xlWorkSheet.Cells(cellRowIndex, 6) = dblRate
                    xlWorkSheet.Cells(cellRowIndex, 8) = dblVATPercent
                    xlWorkSheet.Cells(cellRowIndex, 11) = dblAdvanceAR
                    cellRowIndex += 1
                    colDescA = ""
                    colDescE = ""
                    dblRate = 0
                    dblVATPercent = 0
                    dblAdvanceAR = 0
                    'Next
                Next

                'lets delete blank item rows
                xlWorkSheet.Cells((cellRowIndex), 1) = "*****End Of Item List******"
                xlWorkSheet.Cells(53, 1) = "TXID " & arBillMaster.invRecID

                xlWorkSheet.Rows("" & (cellRowIndex + 1) & ":" & 38 & "").delete()
            End If

            xlWorkBook.Close(SaveChanges:=True)
            xlApp.Quit()
            chkPDF.CheckState = CheckState.Checked

            If chkPDF.CheckState = CheckState.Unchecked Then
                xlApp.Workbooks.Open(destinationFile, Password:="5512730")
                ' xlWorkSheet = xlWorkBook.Worksheets("Sheet1")
                xlApp.Visible = True
                '            xlWorkBook.PrintPreview()
                '           xlApp.Visible = True
            End If

            releaseObject(xlApp)
            releaseObject(xlWorkBook)
            releaseObject(xlWorkSheet)
            Me.Cursor = Cursors.Default
            frmWaitForm.Close()

            Return destinationFile

        Catch ex As Exception
            frmWaitForm.Close()
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, vbCritical, Me.Text)
            Return ""
        End Try

    End Function


    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedIndex = 2 Then 'dates
            panelDate.Visible = True
            panelText.Visible = False
            radDateFrom.Focus()
        Else
            panelText.Visible = True
            panelDate.Visible = False
            txtSearchBy.Focus()
        End If
    End Sub

    Private Sub txtSearchBy_GotFocus(sender As Object, e As EventArgs) Handles txtSearchBy.GotFocus
        txtSearchBy.SelectAll()
    End Sub

    Private Sub RadGridView1_CellDoubleClick(sender As Object, e As GridViewCellEventArgs) Handles RadGridView1.CellDoubleClick
        Dim invrecid As Integer = 0
        actno = ""

        Try
            invrecid = RadGridView1.Rows(e.RowIndex).Cells("invrecid").Value
            actno = RadGridView1.Rows(e.RowIndex).Cells("actno").Value

            If rbFinalInvoice.Checked Then
                If RadGridView1.Rows(e.RowIndex).Cells("approvestatus").Value = "Not-Approved" Then
                    MsgBox("Invoice should be approved before printing Final Invoice", vbExclamation, "Print Invoice")
                    Exit Sub
                End If
                If MsgBox("Print Final Invoice ?", vbQuestion + MsgBoxStyle.YesNo, "Print Request PDF Version") = vbNo Then Exit Sub
            Else
                MsgBox("You have no rights to print this invoice", vbInformation, Me.Text)
            End If

            Call getDocumentList(invrecid)
            Call dumpLOG(invrecid)


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub dumpLOG(recID As Integer)
        Try
            Me.Cursor = Cursors.WaitCursor
            If sql_CNN.State = ConnectionState.Closed Then createConnection()
            If sql_CNN.State = ConnectionState.Closed Then Exit Sub
            Dim qryString As String = "insert into [printlog] (userid,recid,doc) values('" & appUserInfo.Code & "'," & recID & ",'INV')"
            Dim commandy As New SqlCommand(qryString, sql_CNN)
            commandy.ExecuteNonQuery()
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, vbCritical, "Log Dump()")
        End Try

    End Sub

    Private Sub RadGridView2_CellDoubleClick(sender As Object, e As GridViewCellEventArgs) Handles RadGridView2.CellDoubleClick
        Try
            cmbSearchBy.SelectedIndex = 0   'arbill
            ComboBox1.SelectedIndex = 1 'inv#
            txtSearchBy.Text = RadGridView2.Rows(e.RowIndex).Cells("Inv#").Value
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub


    Private Function ExportToExcel_JobCost() As String
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim i As Integer = 0
            Dim endColumnIndex As Integer = 0

            Dim cellRowIndex As Integer = 1
            Dim cellColumnIndex As Integer = 1

            Dim destinationFile As String = copyTemplate("iffJobCost001.xls", "JOBCOST-" & actno & "-" & arBillMaster.iNumber)
            If IO.File.Exists(destinationFile) = False Then
                Me.Cursor = Cursors.WaitCursor
                MsgBox("File does not exists " & destinationFile, MsgBoxStyle.Exclamation, "File Not Found")
                Return ""
                Exit Function
            End If

            frmWaitForm.lblTitle.Text = "Preparing Jobcost Report. Please Wait..!"
            frmWaitForm.Show()
            frmWaitForm.Refresh()
            Me.Cursor = Cursors.WaitCursor

            '.net 4.5
            Dim xlApp As New Excel.Application ' Microsoft.Office.Interop.Excel.ApplicationClass
            Dim xlWorkBook As Microsoft.Office.Interop.Excel.Workbook
            Dim xlWorkSheet As Microsoft.Office.Interop.Excel.Worksheet
            Dim objRadGrid As RadGridView = Nothing

            'objRadGrid = RadGridView2
            xlWorkBook = xlApp.Workbooks.Open(destinationFile, Password:="5512730")
            xlWorkSheet = xlWorkBook.Worksheets("Sheet1")

            'write company/branch report header section -------------------------------------------*--------------------------------
            xlWorkSheet.Cells(1, 1) = appCompanyInfo.companyName
            xlWorkSheet.Cells(2, 1) = appCompanyInfo.branchName
            xlWorkSheet.Cells(3, 1) = appCompanyInfo.branchAddress
            xlWorkSheet.Cells(4, 1) = appCompanyInfo.companyWebsite ' appCompanyInfo.branchContact & " " & appCompanyInfo.branchEmail
            '---------------------------------------------------------------------------'---*----------------------------------------
            xlWorkSheet.Cells(7, 3) = arBillMaster.ShipmentNumber
            xlWorkSheet.Cells(7, 5) = arBillMaster.ServiceType
            xlWorkSheet.Cells(7, 11) = arBillMaster.JobCreatedOn
            xlWorkSheet.Cells(9, 3) = arBillMaster.CargoDetail
            xlWorkSheet.Cells(12, 3) = arBillMaster.Consignee
            xlWorkSheet.Cells(13, 3) = arBillMaster.Shipper

            xlWorkSheet.Cells(9, 8) = arBillMaster.ETD
            xlWorkSheet.Cells(10, 8) = arBillMaster.ETA
            xlWorkSheet.Cells(11, 8) = arBillMaster.PackingType
            xlWorkSheet.Cells(12, 8) = arBillMaster.Qty
            xlWorkSheet.Cells(13, 8) = arBillMaster.GrossWgt
            xlWorkSheet.Cells(14, 8) = arBillMaster.ChgblWgt


            xlWorkSheet.Cells(9, 10) = arBillMaster.POL
            xlWorkSheet.Cells(10, 10) = arBillMaster.pod
            xlWorkSheet.Cells(11, 10) = "Carrier"
            xlWorkSheet.Cells(12, 10) = arBillMaster.BL

            xlWorkSheet.Cells(17, 3) = arBillMaster.iNumber
            xlWorkSheet.Cells(17, 11) = arBillMaster.iDate
            xlWorkSheet.Cells(18, 11) = arBillMaster.iDueDate
            xlWorkSheet.Cells(19, 11) = arBillMaster.invPost
            xlWorkSheet.Cells(20, 11) = arBillMaster.RefNo

            xlWorkSheet.Cells(18, 3) = arBillMaster.ClientNameEnglish
            xlWorkSheet.Cells(19, 3) = arBillMaster.invRemarks


            'read dsprint for invoice line items
            Dim dblVAT As Double = 0
            Dim dblCost As Double = 0
            Dim dblRevenue As Double = 0
            cellRowIndex = 26 'start from

            'print cost items
            If dsPrint.Tables(3).Rows.Count > 0 Then
                For Each Row As DataRow In dsPrint.Tables(3).Rows
                    dblVAT = CDbl(Row("vatcost"))
                    dblCost = CDbl(Row("Cost"))
                    xlWorkSheet.Cells(cellRowIndex, 1) = Row("description").ToString
                    xlWorkSheet.Cells(cellRowIndex, 4) = dblVAT
                    xlWorkSheet.Cells(cellRowIndex, 5) = dblCost
                    xlWorkSheet.Cells(cellRowIndex, 6) = Row("party").ToString
                    cellRowIndex += 1
                    dblVAT = 0
                    dblCost = 0
                    'Next
                Next
            End If
            cellRowIndex += 1
            'print revenue items
            If dsPrint.Tables(0).Rows.Count > 0 Then
                For Each Row As DataRow In dsPrint.Tables(0).Rows
                    dblVAT = CDbl(Row("VAT Sell"))
                    dblRevenue = CDbl(Row("revenue"))
                    xlWorkSheet.Cells(cellRowIndex, 1) = Row("chgNameE").ToString
                    xlWorkSheet.Cells(cellRowIndex, 10) = dblVAT
                    xlWorkSheet.Cells(cellRowIndex, 11) = dblRevenue
                    cellRowIndex += 1
                    dblVAT = 0
                    dblRevenue = 0
                    'Next
                Next
            End If
            'lets delete blank item rows
            xlWorkSheet.Cells(70, 10) = appUserInfo.Name
            xlWorkSheet.Cells(71, 10) = "Printed On :" & Today.Date
            xlWorkSheet.Cells((cellRowIndex), 1) = "*****End Of Item List******"
            xlWorkSheet.Rows("" & (cellRowIndex + 1) & ":" & 65 & "").delete()

            xlWorkBook.Close(SaveChanges:=True)
            xlApp.Quit()
            chkPDF.CheckState = CheckState.Checked

            If chkPDF.CheckState = CheckState.Unchecked Then
                xlApp.Workbooks.Open(destinationFile, Password:="5512730")
                ' xlWorkSheet = xlWorkBook.Worksheets("Sheet1")
                xlApp.Visible = True
                '            xlWorkBook.PrintPreview()
                '           xlApp.Visible = True
            End If

            releaseObject(xlApp)
            releaseObject(xlWorkBook)
            releaseObject(xlWorkSheet)
            Me.Cursor = Cursors.Default
            frmWaitForm.Close()

            Return destinationFile

        Catch ex As Exception
            frmWaitForm.Close()
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, vbCritical, Me.Text)
            Return ""
        End Try

    End Function

    Private Sub RadGridView1_Click(sender As Object, e As EventArgs) Handles RadGridView1.Click

    End Sub
End Class