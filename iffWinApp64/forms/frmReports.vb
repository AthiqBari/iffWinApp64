Imports CTradeListOfValues.frmCTCalendarControl
Imports System.IO
Imports Excel = Microsoft.Office.Interop.Excel
Imports Microsoft.Office.Interop
Imports Telerik.WinControls.UI

Public Class frmReports
    Dim lovcalendar As New CTradeListOfValues.clsCTCalendar

    Private Sub btnDateFrom_Click(sender As Object, e As EventArgs) Handles btnDateFrom.Click
        lovcalendar.showCalendarForm("Invoice Date", txtDateFrom.Location.X, txtDateFrom.Location.Y)
        If lovcalendar.isSelected Then txtDateFrom.Text = lovcalendar.getSelectedDate()
    End Sub
    Private Sub btnDateTo_Click(sender As Object, e As EventArgs) Handles btnDateTo.Click
        lovcalendar.showCalendarForm("Invoice Date", txtDateTo.Location.X, txtDateTo.Location.Y)
        If lovcalendar.isSelected Then txtDateTo.Text = lovcalendar.getSelectedDate()
    End Sub
    Private Sub txtDateFrom_GotFocus(sender As Object, e As EventArgs) Handles txtDateFrom.GotFocus
        txtDateFrom.SelectAll()
    End Sub
    Private Sub btnDateTo_GotFocus(sender As Object, e As EventArgs) Handles btnDateTo.GotFocus
        txtDateTo.SelectAll()
    End Sub

    Private Sub frmReports_Load(sender As Object, e As EventArgs) Handles Me.Load
        txtBranchName.Text = appCompanyInfo.branchName
        Dim firstDay = New DateTime(Today.Year, Today.Month, 1)
        txtDateFrom.Text = firstDay
        txtDateTo.Text = Today.Date
        cmbReportType.SelectedIndex = 0
        cmbInputOutput.SelectedIndex = 0
        cmbTAXType.SelectedIndex = 0
    End Sub


    Private Function copyTemplate(rType As Integer) As String
        Try
            Dim templateFile As String = ""
            Dim newFileName As String = ""
            Dim appPath As String = "" 'System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase)
            appPath = Directory.GetCurrentDirectory()

            If rType = 1 Then templateFile = "iffReportLineTemplate01"
            If rType = 2 Then templateFile = "iffReportLineTemplate02"
            newFileName = templateFile
            If rType = 1 Then newFileName = "iffVATLineTransactions"
            If rType = 1 Then newFileName = "iffVATSummaryReport"

            Dim destinationFolder As String = appPath & "\excel files\"
            Dim sourceFile As String = appPath & "\template\" & templateFile & ".xls"
            Dim destinationFileName As String = templateFile & " "
            destinationFileName = newFileName & "" & DateTime.Now.Hour.ToString + "" + DateTime.Now.Minute.ToString + "" + DateTime.Now.Second.ToString & ".xls"
            destinationFileName = destinationFolder & destinationFileName
            File.Copy(sourceFile, destinationFileName)
            Return destinationFileName
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "copyTemplate(...")
            Return ""
        End Try
    End Function



    Private Function ExportToExcel(rType As Integer, rTitle As String, rFilterText As String) As String
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim i As Integer = 0

            Dim str1 As String = ""
            Dim str2 As String = ""
            Dim cellRowIndex As Integer = 1
            Dim cellColumnIndex As Integer = 1
            ToolStripStatusLabel1.Text = ""
            Dim cellrangex As Excel.Range


            Dim destinationFile As String = copyTemplate(rType)
            If String.IsNullOrEmpty(destinationFile) Then Return "" : Exit Function
            If IO.File.Exists(destinationFile) = False Then
                Me.Cursor = Cursors.WaitCursor
                MsgBox("File does not exists " & destinationFile, MsgBoxStyle.Exclamation, "File Not Found")
                Return ""
                Exit Function
            End If


            frmWaitForm.lblTitle.Text = "Exporting Data to Excel. Please Wait..!"
            frmWaitForm.Show()
            frmWaitForm.Refresh()
            Me.Cursor = Cursors.WaitCursor



            '.net 4.5
            Dim xlApp As New Excel.Application ' Microsoft.Office.Interop.Excel.ApplicationClass
            Dim xlWorkBook As Microsoft.Office.Interop.Excel.Workbook
            Dim xlWorkSheet As Microsoft.Office.Interop.Excel.Worksheet

            Dim objRadGrid As RadGridView = Nothing
            objRadGrid = RadGridView1

            '            If IO.File.Exists(destinationFile) 
            xlWorkBook = xlApp.Workbooks.Open(destinationFile)
            xlWorkSheet = xlWorkBook.Worksheets("Sheet1")

            xlWorkSheet.Cells(1, 1) = appCompanyInfo.companyName
            xlWorkSheet.Cells(2, 1) = appCompanyInfo.branchName
            xlWorkSheet.Cells(2, 15) = Today.Date
            xlWorkSheet.Cells(3, 15) = appUserInfo.Name
            str1 = "Date From : " & txtDateFrom.Text & " To: " & txtDateTo.Text
            xlWorkSheet.Cells(4, 1) = rTitle
            xlWorkSheet.Cells(5, 1) = str1.ToString
            xlWorkSheet.Cells(6, 1) = rFilterText.ToString

            'start writing data from 
            cellRowIndex = 8
            cellColumnIndex = 1

            ProgressBar1.Minimum = 0
            ProgressBar1.Maximum = objRadGrid.Rows.Count + 1
            ProgressBar1.Value = 0
            ProgressBar1.Visible = True

            'Loop through each row and read value from each column.
            For i = 0 To objRadGrid.Rows.Count - 1
                For j As Integer = 0 To objRadGrid.Columns.Count - 1
                    xlWorkSheet.Cells(cellRowIndex, cellColumnIndex) = objRadGrid.Rows(i).Cells(j).Value.ToString()
                    cellColumnIndex += 1
                Next
                cellColumnIndex = 1
                cellRowIndex += 1

                If (ProgressBar1.Value < ProgressBar1.Maximum) Then ProgressBar1.Value = i '

                ' If cellRowIndex = objRadGrid.Rows.Count - 1 Then Exit For
            Next
            ProgressBar1.Visible = False
            If rType = 1 Then 'VAT LINE TRANSACTION REPORT
                xlWorkSheet.Cells(cellRowIndex + 1, 10) = "Total"
                xlWorkSheet.Cells(cellRowIndex + 1, 11) = "=SUM(K8:K" & cellRowIndex & ")"
                xlWorkSheet.Cells(cellRowIndex + 1, 13) = "=SUM(M8:M" & cellRowIndex & ")"
                xlWorkSheet.Cells(cellRowIndex + 1, 14) = "=SUM(N8:N" & cellRowIndex & ")"
                cellrangex = xlWorkSheet.Range("J" & cellRowIndex + 1, "N" & cellRowIndex + 1)
                cellrangex.Font.Bold = True
            ElseIf rType = 2 Then 'VAT SUMMARY
                xlWorkSheet.Cells(cellRowIndex + 1, 1) = "Total"
                xlWorkSheet.Cells(cellRowIndex + 1, 2) = "=SUM(B8:B" & cellRowIndex & ")"
                xlWorkSheet.Cells(cellRowIndex + 1, 3) = "=SUM(C8:C" & cellRowIndex & ")"
                xlWorkSheet.Cells(cellRowIndex + 1, 4) = "=SUM(D8:D" & cellRowIndex & ")"
                cellrangex = xlWorkSheet.Range("A" & cellRowIndex + 1, "D" & cellRowIndex + 1)
                cellrangex.Font.Bold = True

            End If


            '   Me.Refresh()
            xlWorkBook.Close(SaveChanges:=True)
            xlApp.Quit()

            '   xlApp.Workbooks.Open(destinationFile)
            'xlWorkSheet = xlWorkBook.Worksheets("Sheet1")
            '    xlApp.Visible = True
            '            xlWorkBook.PrintPreview()


            releaseObject(xlApp)
            releaseObject(xlWorkBook)
            releaseObject(xlWorkSheet)
            ToolStripStatusLabel1.Text = "Output File Created [" & destinationFile & "]"


            Dim proc As Process = Nothing
            Dim startInfo As New ProcessStartInfo
            startInfo.FileName = "EXCEL.EXE"
            startInfo.Arguments = """" & destinationFile & """"
            Process.Start(startInfo)
            'System.Diagnostics.Process.Start("FilePath")

            Me.Cursor = Cursors.Default
            frmWaitForm.Close()
            Return destinationFile

        Catch ex As Exception
            Me.Cursor = Cursors.Default
            frmWaitForm.Close()
            MsgBox(ex.Message, vbCritical, Me.Text)
            Return ""
        End Try

    End Function


    Public Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click

        Dim ds As New DataSet
        Dim i As Integer = 0
        Dim rptTypeID As Integer = 0
        Dim viewName As String = ""
        Dim vatType As String = ""
        lblFound.Text = ""
        '  If String.IsNullOrEmpty(txtSearchBy.Text) Then Exit Sub

        '0 - <...>
        '1 - VAT LineTrx
        '2 - VAT Summary
        rptTypeID = cmbReportType.SelectedIndex
        RadGridView1.DataSource = Nothing
        If rptTypeID = 0 Then Exit Sub

        If rptTypeID = 1 Or rptTypeID = 2 Then 'VAT TRX/VAT SUMMARY
            If cmbInputOutput.SelectedIndex = 0 Then viewName = "[viewVATTransactionLineReport_Purchase]" 'input
            If cmbInputOutput.SelectedIndex = 1 Then viewName = "[viewVATTransactionLineReport_Sales]" 'output

            If cmbTAXType.SelectedIndex = 0 Then vatType = "All"
            If cmbTAXType.SelectedIndex = 1 Then vatType = "VAT"
            If cmbTAXType.SelectedIndex = 2 Then vatType = "Zero-VAT"
            If cmbTAXType.SelectedIndex = 3 Then vatType = "EXEMPT"

            If rptTypeID = 1 Then sql_String = "select * from " & viewName & " where branchID=" & appCompanyInfo.branchID
            If rptTypeID = 2 Then sql_String = "select [VATType],sum([AmtExcludingVAT]) [AmtExcludingVAT],sum([VATAmount]) [VATAmount],sum([Total]) [Total] from " & viewName & " where branchID=" & appCompanyInfo.branchID

            sql_String += " and InvDate between '" & Date.Parse(txtDateFrom.Text).ToString("yyyy'/'MM'/'dd") & "' and '" & Date.Parse(txtDateTo.Text).ToString("yyyy'/'MM'/'dd") & "'"

            If rptTypeID = 1 AndAlso vatType <> "All" Then sql_String += " and VATType in ('" & vatType & "') "
            If rptTypeID = 1 Then sql_String += "order by [invno],[invdate]"
            If rptTypeID = 2 Then sql_String += " group by [VATType]"
        End If

        Try
            Me.Cursor = Cursors.WaitCursor
            RadGridView1.DataSource = Nothing
            ds = setDataList(sql_String)
            If ds.Tables(0).Rows.Count > 0 Then
                RadGridView1.DataSource = ds.Tables(0)
                lblFound.Text = "Found :" & ds.Tables(0).Rows.Count
                'For i = RadGridView1.Columns.Count - 1 To RadGridView1.Columns.Count - 1
                '    RadGridView1.Columns(i).IsVisible = False
                'Next i
                RadGridView1.MasterTemplate.BestFitColumns()
            End If

            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub


    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        Dim strFltr As String = ""
        strFltr = ""
        If cmbReportType.SelectedIndex = 1 Or cmbReportType.SelectedIndex = 2 Then 'vat reports
            strFltr = "Input/Output: [" & cmbInputOutput.Text & "] | VAT Type: [" & cmbTAXType.Text & "]"
        End If
        Call ExportToExcel(cmbReportType.SelectedIndex, cmbReportType.Text, strFltr)
    End Sub
End Class