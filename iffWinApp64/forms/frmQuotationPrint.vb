Imports Telerik.WinControls.UI
Imports System.Data.Sql
Imports System.Data
Imports System.Data.SqlClient
Imports System.Exception
Imports System.Data.OleDb
Imports System.IO
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Text.RegularExpressions
Public Class frmQuotationPrint

    Dim dsPrint As New DataSet()

    Dim quoteRecID As Integer
    Dim quoteApproved As Boolean = False
    Dim quoteNumber As String = ""
    Private Sub frmQuotationPrint_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call getRecentPrintedItems()
        Me.Top = 1
        Me.Left = 1
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim ds As New DataSet
        Dim i As Integer = 0
        If String.IsNullOrEmpty(txtQuotationNumber.Text) Then Exit Sub
        lblMsg.Text = ""
        quoteRecID = 0
        quoteNumber = ""
        quoteApproved = False

        Try
            sql_String = "select * from [crmQuoteMaster] where qcode=" & txtQuotationNumber.Text
            Me.Cursor = Cursors.WaitCursor
            ds = setDataList(sql_String)
            If ds.Tables(0).Rows.Count > 0 Then
                quoteRecID = ds.Tables(0).Rows(0).Item("id")
                quoteNumber = ds.Tables(0).Rows(0).Item("quotenumber")
                quoteApproved = ds.Tables(0).Rows(0).Item("approved")
                If Not quoteApproved Then lblMsg.Text = "This Quote is not approved"
                Call printQuote()
            Else
                lblMsg.Text = "Quotation Number does not exists..."
                txtQuotationNumber.Focus()
                txtQuotationNumber.SelectAll()
            End If

            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)

        End Try

    End Sub
    Private Sub printQuote()
        Dim excelFile As String = ""
        If quoteRecID = 0 Then Exit Sub
        If String.IsNullOrEmpty(appCompanyInfo.crmQuoteTemplate) Then MsgBox("Missing Quote Template File, Cannot Print", vbCritical, "Print Request") : Exit Sub
        excelFile = ExportToExcel()
        If Not String.IsNullOrEmpty(excelFile) Then ExportToPDF(excelFile, "5512730")
        Call dumpLOG(quoteRecID)
        Call getRecentPrintedItems()
    End Sub

    Private Sub txtQuotationNumber_KeyDown(sender As Object, e As KeyEventArgs) Handles txtQuotationNumber.KeyDown
        lblMsg.Text = ""
    End Sub


    Private Function ExportToExcel() As String
        Try

            Dim font As Font = New System.Drawing.Font("arial", 40)
            Dim watermark As [String] = "Confidential"

            Dim dsQM As New DataSet()
            Dim dsQItems As New DataSet()
            Dim QItems As Boolean = True

            Me.Cursor = Cursors.WaitCursor
            If quoteRecID > 0 Then
                sql_String = "select * from [viewCRMQuotations] where id=" & quoteRecID
                dsQM = setDataList(sql_String)
                If dsQM.Tables(0).Rows.Count < 1 Then
                    Me.Cursor = Cursors.WaitCursor
                    MsgBox("Quote ID not found...", MsgBoxStyle.Exclamation, "File Not Found")
                    Return ""
                    Exit Function
                End If
            End If

            Dim i As Integer = 0
            Dim endColumnIndex As Integer = 0

            Dim cellRowIndex As Integer = 1
            Dim cellColumnIndex As Integer = 1

            Dim destinationFile As String = copyTemplate(appCompanyInfo.crmQuoteTemplate & ".xls", quoteNumber & "-" & quoteRecID)
            If IO.File.Exists(destinationFile) = False Then
                Me.Cursor = Cursors.WaitCursor
                MsgBox("File does not exists " & destinationFile, MsgBoxStyle.Exclamation, "File Not Found")
                Return ""
                Exit Function
            End If

            frmWaitForm.lblTitle.Text = "Preparing Quote. Please Wait..!"
            frmWaitForm.Show()
            frmWaitForm.Refresh()
            Me.Cursor = Cursors.WaitCursor

            '.net 4.5
            Dim xlApp As New Excel.Application ' Microsoft.Office.Interop.Excel.ApplicationClass
            Dim xlWorkBook As Microsoft.Office.Interop.Excel.Workbook
            Dim xlWorkSheet As Microsoft.Office.Interop.Excel.Worksheet
            Dim objRadGrid As RadGridView = Nothing

            'objRadGrid = RadGridView2
            'xlWorkBook = xlApp.Workbooks.Open(destinationFile)
            xlWorkBook = xlApp.Workbooks.Open(destinationFile, Password:="5512730")
            xlWorkSheet = xlWorkBook.Worksheets("Sheet1")

            'write company/branch report header section -------------------------------------------*--------------------------------
            xlWorkSheet.Cells(1, 4) = appCompanyInfo.companyName
            xlWorkSheet.Cells(2, 4) = appCompanyInfo.branchName
            xlWorkSheet.Cells(3, 4) = appCompanyInfo.branchAddress
            xlWorkSheet.Cells(5, 4) = appCompanyInfo.companyWebsite ' appCompanyInfo.branchContact & " " & appCompanyInfo.branchEmail
            '---------------------------------------------------------------------------'---*----------------------------------------
            xlWorkSheet.Cells(3, 11) = quoteNumber.ToString
            xlWorkSheet.Cells(5, 11) = dsQM.Tables(0).Rows(0).Item("oppcodeformat")


            xlWorkSheet.Cells(7, 10) = dsQM.Tables(0).Rows(0).Item("createdon")
            xlWorkSheet.Cells(9, 2) = dsQM.Tables(0).Rows(0).Item("quotetitle")

            '            xlWorkSheet.Cells(8, 2) = "FREIGHT QUOTE - " & "<COMPANY NAME....>"
            xlWorkSheet.Cells(12, 2) = "Dear " & dsQM.Tables(0).Rows(0).Item("contactperson") & ","
            xlWorkSheet.Cells(14, 2) = dsQM.Tables(0).Rows(0).Item("client")
            xlWorkSheet.Cells(30, 2) = appCompanyInfo.companyName
            xlWorkSheet.Cells(31, 2) = appCompanyInfo.branchName
            xlWorkSheet.Cells(57, 8) = "Prepared/Printed By " & appUserInfo.Name

            'page2
            xlWorkSheet.Cells(59, 2) = dsQM.Tables(0).Rows(0).Item("quotetitle")

            xlWorkSheet.Cells(61, 6) = dsQM.Tables(0).Rows(0).Item("validfrom")
            xlWorkSheet.Cells(62, 6) = dsQM.Tables(0).Rows(0).Item("validtill")
            xlWorkSheet.Cells(63, 6) = dsQM.Tables(0).Rows(0).Item("transittime")
            xlWorkSheet.Cells(62, 2) = quoteNumber

            xlWorkSheet.Cells(61, 9) = dsQM.Tables(0).Rows(0).Item("client")
            xlWorkSheet.Cells(62, 9) = dsQM.Tables(0).Rows(0).Item("contactperson")
            xlWorkSheet.Cells(63, 9) = dsQM.Tables(0).Rows(0).Item("email")
            xlWorkSheet.Cells(64, 9) = dsQM.Tables(0).Rows(0).Item("contactnumber")

            xlWorkSheet.Cells(69, 4) = "Freight Forwarding"
            xlWorkSheet.Cells(70, 4) = dsQM.Tables(0).Rows(0).Item("contactperson")
            xlWorkSheet.Cells(71, 4) = dsQM.Tables(0).Rows(0).Item("srvType")
            xlWorkSheet.Cells(72, 4) = dsQM.Tables(0).Rows(0).Item("crgType")

            xlWorkSheet.Cells(69, 11) = dsQM.Tables(0).Rows(0).Item("incoterm")
            xlWorkSheet.Cells(70, 11) = dsQM.Tables(0).Rows(0).Item("grossweight")
            xlWorkSheet.Cells(71, 11) = dsQM.Tables(0).Rows(0).Item("volume")
            xlWorkSheet.Cells(72, 11) = dsQM.Tables(0).Rows(0).Item("chargeable")

            xlWorkSheet.Cells(75, 3) = dsQM.Tables(0).Rows(0).Item("commodity")
            xlWorkSheet.Cells(79, 3) = dsQM.Tables(0).Rows(0).Item("cargodetails")

            xlWorkSheet.Cells(83, 3) = dsQM.Tables(0).Rows(0).Item("pol")
            xlWorkSheet.Cells(83, 8) = dsQM.Tables(0).Rows(0).Item("pod")

            xlWorkSheet.Cells(86, 3) = dsQM.Tables(0).Rows(0).Item("pickupAddress")
            xlWorkSheet.Cells(86, 8) = dsQM.Tables(0).Rows(0).Item("deliveryAddress")

            xlWorkSheet.Cells(60, 11) = "Opportunity ID - " & dsQM.Tables(0).Rows(0).Item("oppcodeformat")

            xlWorkSheet.PageSetup.LeftFooter = quoteNumber
            If Not quoteApproved Then xlWorkSheet.PageSetup.CenterHeader = "DRAFT COPY - THIS QUOTE IS NOT APPROVED"
            ''---- line items goes here...


            xlWorkSheet.Cells(146, 2) = dsQM.Tables(0).Rows(0).Item("rateExcludes")
            xlWorkSheet.Cells(152, 2) = dsQM.Tables(0).Rows(0).Item("paymentTerm")

            xlWorkSheet.Cells(164, 2) = appCompanyInfo.companyName
            xlWorkSheet.Cells(164, 11) = System.DateTime.Now.ToString("dd MMMM yyyy")
            xlWorkSheet.Cells(165, 2) = appCompanyInfo.branchName
            xlWorkSheet.Cells(166, 2) = appCompanyInfo.branchAddress
            ' xlWorkSheet.Cells(159, 2) = appCompanyInfo.branchContact


            xlWorkSheet.Cells(168, 10) = quoteNumber
            xlWorkSheet.Cells(179, 2) = dsQM.Tables(0).Rows(0).Item("contactperson")
            xlWorkSheet.Cells(180, 2) = dsQM.Tables(0).Rows(0).Item("client")

            xlWorkSheet.Cells(154, 2) = dsQM.Tables(0).Rows(0).Item("quoteheader")


            cellRowIndex = 106 'start from
            Dim dsQItemLevel2 As New DataSet()
            Dim cellRowIndexInner As Integer = 0
            cellRowIndexInner = cellRowIndex
            Dim total As Double = 0
            Dim dblValue1 As Double = 0
            Dim dblValue2 As Double = 0
            Dim succeed As Boolean = False


            sql_String = "select * from [crmQuoteServices] where quoteMasterID=" & quoteRecID & " order by id"
            dsQItems = setDataList(sql_String)
            If dsQItems.Tables(0).Rows.Count > 0 Then
                For Each Row As DataRow In dsQItems.Tables(0).Rows  'print outer service level1 item
                    xlWorkSheet.Cells(cellRowIndex, 2) = Row("serviceType").ToString() & " " & Row("servicenote").ToString()
                    xlWorkSheet.Cells(cellRowIndex, 2).Font.Bold = True
                    xlWorkSheet.Cells(cellRowIndex, 2).font.Underline = Excel.XlUnderlineStyle.xlUnderlineStyleSingle

                    cellRowIndex += 1
                    'now read inner service level items
                    sql_String = "select * from [crmQuoteServicesLevel2] where quoteServiceID=" & Row("id") & " order by id"
                    dsQItemLevel2 = setDataList(sql_String)
                    If dsQItemLevel2.Tables(0).Rows.Count > 0 Then
                        cellRowIndexInner = cellRowIndex
                        For Each RowInner As DataRow In dsQItemLevel2.Tables(0).Rows 'print inner service level2 items
                            dblValue1 = Double.Parse(RowInner("rate1"))
                            dblValue2 = Double.Parse(RowInner("qty"))
                            If dblValue2 < 1 Then dblValue2 = 1

                            xlWorkSheet.Cells(cellRowIndexInner, 2) = RowInner("serviceType").ToString() & " " & RowInner("ratenote").ToString()
                            xlWorkSheet.Cells(cellRowIndexInner, 10) = RowInner("currency").ToString()

                            xlWorkSheet.Cells(cellRowIndexInner, 11) = dblValue1
                            xlWorkSheet.Cells(cellRowIndexInner, 12) = dblValue2
                            total += (dblValue1 * dblValue2)
                            xlWorkSheet.Cells(cellRowIndexInner, 13) = (dblValue1 * dblValue2)
                            cellRowIndexInner += 1
                            dblValue1 = 0
                            dblValue2 = 0
                        Next
                        xlWorkSheet.Cells(cellRowIndexInner + 1, 13) = total
                        xlWorkSheet.Cells(cellRowIndexInner + 1, 13).Font.Bold = True
                        xlWorkSheet.Cells(cellRowIndexInner + 1, 13).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                        total = 0

                    End If
                    cellRowIndex = (cellRowIndexInner + 2)
                Next
            End If

            'lets delete blank item rows
            xlWorkSheet.Rows("" & (cellRowIndex + 2) & ":" & 140 & "").delete()


            xlWorkBook.Close(SaveChanges:=True)
            xlApp.Quit()

            'If chkPDF.CheckState = CheckState.Unchecked Then
            '    xlApp.Workbooks.Open(destinationFile, Password:="5512730")
            '    ' xlWorkSheet = xlWorkBook.Worksheets("Sheet1")
            '    xlApp.Visible = True
            '    '            xlWorkBook.PrintPreview()
            '    '           xlApp.Visible = True
            'End If

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

    Private Sub dumpLOG(recID As Integer)
        Try
            Me.Cursor = Cursors.WaitCursor
            If sql_CNN.State = ConnectionState.Closed Then createConnection()
            If sql_CNN.State = ConnectionState.Closed Then Exit Sub
            Dim qryString As String = "insert into [printlog] (userid,recid,doc) values('" & appUserInfo.Code & "'," & recID & ",'RFQ')"
            Dim commandy As New SqlCommand(qryString, sql_CNN)
            commandy.ExecuteNonQuery()
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, vbCritical, "Log Dump()")
        End Try

    End Sub



    Private Sub getRecentPrintedItems()
        Try
            Dim dsPrint As New DataSet
            Me.Cursor = Cursors.WaitCursor
            RadGridView2.DataSource = Nothing

            sql_String = "select top 100 qcode [Code],quoteNumber [Quotation #],quoteTitle [Title] from crmQuoteMaster where id in "
            sql_String += " (select top 100 recid from printLog where DOC='RFQ' AND  userid='" & appUserInfo.Code & "' order by logdate desc)"

            dsPrint = setDataList(sql_String)
            If dsPrint.Tables(0).Rows.Count > 0 Then
                RadGridView2.DataSource = dsPrint.Tables(0)
                ' RadGridView2.Columns(5).IsVisible = False
                RadGridView2.MasterTemplate.BestFitColumns()
                End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "getRecentPrintedItems()")
        Finally
            Me.Cursor = Cursors.Default
        End Try



    End Sub

    Private Sub RadGridView2_CellDoubleClick(sender As Object, e As GridViewCellEventArgs) Handles RadGridView2.CellDoubleClick
        Try
            txtQuotationNumber.Text = RadGridView2.Rows(e.RowIndex).Cells("code").Value
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub
End Class