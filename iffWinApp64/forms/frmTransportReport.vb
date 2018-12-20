'report form - 25/10/2018
Imports System.IO
Imports Excel = Microsoft.Office.Interop.Excel
Imports Microsoft.Office.Interop
Imports Telerik.WinControls.UI
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient

Public Class frmTransportReports
    Dim hidecolfrom As Integer = 0
    Dim pdfexport As Boolean = False
    Dim excelexport As Boolean = False
    Dim rptOnly As Boolean = False
    Dim rptFileName As String = ""
    Dim byBranch As Boolean = False

    Private Sub frmTransportReports_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Top = 1
        Me.Left = 1
        txtBranchName.Text = appCompanyInfo.branchName
        txtBranchName.Tag = appCompanyInfo.branchID
        Dim firstDay = New DateTime(Today.Year, Today.Month, 1)
        txtFromDate.Text = firstDay
        txtToDate.Text = Today.Date
        Call refresh_reporttype(cmbReportType, "")
        Call refresh_clientlist(cmbClient, "")
        Call refresh_transporterlist(cmbTransporter, "")
        Call refresh_driverlist(cmbDriver, "")
        Call refresh_broker(cmbSupervisor, "")
        cmbReportType.EditorControl.TableElement.Font = New System.Drawing.Font("Arial", 10)
        cmbReportType.Focus()
    End Sub

    Private Sub refresh_reporttype(cmbObj As Object, orgFldName As String)
        Dim ctr As Integer = 0
        Try
            Me.Cursor = Cursors.WaitCursor
            sql_String = "select Name [ReportName], trim(reportcode) [repcode], hidecolfrom,pdf,excel,rptonly,rptname,bybranch "
            sql_String += " from TransportReportMenuList where groupcode='transport' and isActive=1 "
            sql_String += IIf(appUserInfo.isAdmin = False, " and adminAccess=0 ", "")
            sql_String += " order by slno"
            Call fillCombo(cmbObj, sql_String, 0, 400, (cmbReportType.Width - 20), 1)
            ' cmbObj.Columns(1).VisibleInColumnChooser = False
            For ctr = 1 To cmbReportType.Columns.Count - 1
                cmbReportType.Columns(ctr).IsVisible = False
            Next
            cmbObj.Tag = 0 : cmbObj.Text = ""
        Catch ex As Exception
            lblMsg.Text = ex.Message
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cmbReportType_LostFocus(sender As Object, e As EventArgs) Handles cmbReportType.LostFocus
        Try
            Me.Cursor = Cursors.WaitCursor
            If cmbReportType.SelectedValue <> "" Then
                cmbReportType.Tag = 0
                hidecolfrom = 0
                rptFileName = "" : rptOnly = False : excelexport = False : pdfexport = False
                Dim selectedRow As GridViewDataRowInfo = DirectCast(cmbReportType.SelectedItem, GridViewDataRowInfo)
                cmbReportType.Tag = (selectedRow.Cells("repcode").Value.ToString())
                hidecolfrom = (selectedRow.Cells("hidecolfrom").Value.ToString())
                pdfexport = (selectedRow.Cells("pdf").Value.ToString())
                excelexport = (selectedRow.Cells("excel").Value.ToString())
                rptOnly = (selectedRow.Cells("rptonly").Value.ToString())
                rptFileName = (selectedRow.Cells("rptname").Value.ToString())
                byBranch = (selectedRow.Cells("bybranch").Value.ToString())
                lblFormTitle.Text = cmbReportType.Text
                Call showHideParameter(cmbReportType.Tag)
            End If
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            lblMsg.Text = ex.Message
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub showHideParameter(rptcode As String)

        initParam()
        chkPDF.Visible = pdfexport
        btnExcel.Visible = excelexport
        chkITRDues.Enabled = False

        Select Case Trim(rptcode)
            Case "disporder"
                chkCompanyT.Checked = True : chkRentalT.Checked = True
            Case "tprofitdet"
                chkCompanyT.Checked = True : chkRentalT.Checked = True
            Case "itrform"
                lblSpecialValue.Text = "Enter ITR#:"
            Case "wblistrev" : lblSpecialValue.Text = "Job#(number format)"
            Case "invapprove" : pnlApproveInvoice.Visible = True
            Case "itrlist" : chkITRDues.Enabled = True

        End Select
    End Sub

    Private Sub initParam()
        chkCompanyT.Checked = True : chkRentalT.Checked = True
        panelExport.Visible = False
        lblMsg.Visible = False
        lblSpecialValue.Text = "Enter Value:"
        txtValue.Text = 0
        pnlApproveInvoice.Visible = False
        imgApproveOK.Visible = False
        ' hidecolfrom = 0
    End Sub
    Private Sub refresh_clientlist(cmbObj As Object, orgFldName As String)
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.Cursor = Cursors.WaitCursor
            sql_String = "select Name,recID from organization where IsReceivableAccount=1 and recid in (select cltrecid from viewTransportDispatchTTS where branchID=" & appUserInfo.BranchId & ")"
            Call fillCombo(cmbObj, sql_String, 0, 400, (cmbReportType.Width - 20), 1)
            cmbObj.Columns(1).IsVisible = False
            cmbObj.Tag = 0 : cmbObj.Text = ""
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            lblMsg.Text = ex.Message
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub refresh_transporterlist(cmbObj As Object, orgFldName As String)
        Try
            Me.Cursor = Cursors.WaitCursor
            sql_String = "select Name,recID from organization where istransporter=1 and recid in (select OrgTrnID from viewTransportDispatchTTS where branchID=" & appUserInfo.BranchId & ")"
            Call fillCombo(cmbObj, sql_String, 0, 400, (cmbReportType.Width - 20), 1)
            ' cmbObj.Columns(1).VisibleInColumnChooser = False
            cmbObj.Columns(1).IsVisible = False
            cmbObj.Tag = 0 : cmbObj.Text = ""

        Catch ex As Exception
            lblMsg.Text = ex.Message
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub refresh_driverlist(cmbObj As Object, orgFldName As String)
        Try
            Me.Cursor = Cursors.WaitCursor
            sql_String = "select Name,recID from [drivers] where isactive=1 and branchID=" & appUserInfo.BranchId
            Call fillCombo(cmbObj, sql_String, 0, 400, (cmbReportType.Width - 20), 1)
            ' cmbObj.Columns(1).VisibleInColumnChooser = False
            cmbObj.Columns(1).IsVisible = False
            cmbObj.Tag = 0 : cmbObj.Text = ""
        Catch ex As Exception
            lblMsg.Text = ex.Message
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub refresh_broker(cmbObj As Object, orgFldName As String)
        Try
            Me.Cursor = Cursors.WaitCursor
            sql_String = "select Name,recID from organization where isbroker=1 and branchID=" & appUserInfo.BranchId
            Call fillCombo(cmbObj, sql_String, 0, 400, (cmbReportType.Width - 20), 1)
            ' cmbObj.Columns(1).VisibleInColumnChooser = False
            cmbObj.Columns(1).IsVisible = False
            cmbObj.Tag = 0 : cmbObj.Text = ""
        Catch ex As Exception
            lblMsg.Text = ex.Message
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub cmbTransporter_LostFocus(sender As Object, e As EventArgs) Handles cmbTransporter.LostFocus
        Try
            Me.Cursor = Cursors.WaitCursor
            If cmbTransporter.SelectedValue <> "" Then
                cmbTransporter.Tag = 0
                Dim selectedRow As GridViewDataRowInfo = DirectCast(cmbTransporter.SelectedItem, GridViewDataRowInfo)
                cmbTransporter.Tag = (selectedRow.Cells("recid").Value.ToString())
            End If
        Catch ex As Exception
            lblMsg.Text = ex.Message
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub cmbClient_LostFocus(sender As Object, e As EventArgs) Handles cmbClient.LostFocus
        If cmbClient.SelectedValue <> "" Then
            cmbClient.Tag = 0
            Dim selectedRow As GridViewDataRowInfo = DirectCast(cmbClient.SelectedItem, GridViewDataRowInfo)
            cmbClient.Tag = (selectedRow.Cells("recid").Value.ToString())
        End If
    End Sub

    Private Sub btnclear1_Click(sender As Object, e As EventArgs) Handles btnclear1.Click
        cmbClient.Text = ""
        cmbClient.Tag = 0
    End Sub

    Private Sub btnclear2_Click(sender As Object, e As EventArgs) Handles btnclear2.Click
        cmbTransporter.Text = ""
        cmbTransporter.Tag = 0
    End Sub

    Private Function verifyInput() As Boolean
        Dim msg As String = ""
        Dim rtnval As Boolean = True

        If Not IsDate(txtFromDate.Text) Then msg = "Check Date Value" : GoTo err
        If Not IsDate(txtToDate.Text) Then msg = "Check Date Value" : GoTo err
        If String.IsNullOrEmpty(cmbReportType.Text) Then msg = "Report Type is missing" : GoTo err
        If cmbReportType.Tag = "itrform" Then
            If Not IsNumeric(txtValue.Text) Then txtValue.Text = 0
            If txtValue.Text < 1 Then msg = "Enter ITR Document Number" : GoTo err
        End If
        Return rtnval

        Exit Function
err:
        lblMsg.Text = msg
        lblMsg.Visible = True
        Return False
    End Function

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        RadGridView1.DataSource = Nothing
        Dim rptgroup As Boolean = False
        If Not verifyInput() Then Exit Sub
        Dim rptformula As String = ""
        Dim rptFullPath As String = ""
        Dim companyowntruck As Integer = -1
        Dim dt1 As Date
        Dim dt2 As Date
        dt1 = txtFromDate.Text
        dt2 = txtToDate.Text

        Try
            Me.Cursor = Cursors.WaitCursor

            If (chkRentalT.Checked = False And chkCompanyT.Checked = True) Then companyowntruck = 0
            If (chkRentalT.Checked = True And chkCompanyT.Checked = False) Then companyowntruck = 1
            If (chkRentalT.Checked = True And chkCompanyT.Checked = True) Then companyowntruck = -1


            'write report param 
            If sql_CNN.State = ConnectionState.Closed Then createConnection()
            Dim sqlcmd As SqlCommand = sql_CNN.CreateCommand()
            sqlcmd.CommandText = "delete from [reportparam]"
            sqlcmd.ExecuteNonQuery()
            sql_String = "From [" & txtFromDate.Text & "] Thru [" & txtToDate.Text & "]"
            sqlcmd.CommandText = "insert into reportparam(branchid,rptid,rptothervalue1) values (" & appCompanyInfo.branchID & ",1,'" & sql_String & "');"
            sqlcmd.ExecuteNonQuery()

            If rptOnly Then
                rptFullPath = Application.StartupPath & IIf(byBranch, appCompanyInfo.customizerptpath, "\reports") & "\" & rptFileName '  rptfolderbr & "\" & rptFileName
                TabControl1.SelectedIndex = 1 'rpt
                Select Case Trim(cmbReportType.Tag)
                    Case "itrform"
                        rptformula = "{viewQueryWaybillRecord2018.branchid}=" & txtBranchName.Tag & " and {viewQueryWaybillRecord2018.itrno}=" & txtValue.Text
                        rptformula += " and {WaybillCosting.cost} > 0"
                    Case "wblistrev"
                        rptformula = "{viewWaybillRevenueTTS.branchid}=" & txtBranchName.Tag
                        rptformula += " and {viewWaybillRevenueTTS.Date} in """ & dt1.ToString("yyyy-MM-dd") & """ to """ & dt2.ToString("yyyy-MM-dd") & """"
                        If Not String.IsNullOrEmpty(txtValue.Text) And txtValue.Text <> "0" Then rptformula += " and {actMaster_SEA.jobRunningNo}=" & txtValue.Text
                    Case "tprofitdet"
                        rptformula = "{viewTransportProfitibilityTTS.branchid} =" & txtBranchName.Tag
                        rptformula += " and {viewTransportProfitibilityTTS.ldate} in """ & dt1.ToString("yyyy-MM-dd") & """ to """ & dt2.ToString("yyyy-MM-dd") & """"
                        If cmbClient.Tag > 0 Then rptformula += " and {viewTransportProfitibilityTTS.cltrecid} =" & cmbClient.Tag

                    Case "sprofitsum"
                        rptformula = "{viewJobProfitibilityTTS.branchid} =" & txtBranchName.Tag
                        rptformula += " and {viewJobProfitibilityTTS.invdt} in """ & dt1.ToString("yyyy-MM-dd") & """ to """ & dt2.ToString("yyyy-MM-dd") & """"
                    Case "dailytrip"
                        rptformula = "{viewTransportDispatchTTS.wbcancelled} = 0 and {viewTransportDispatchTTS.branchid} =" & txtBranchName.Tag
                        If cmbClient.Tag > 0 Then rptformula += " and {viewTransportDispatchTTS.cltRecID} =" & cmbClient.Tag
                        If cmbTransporter.Tag > 0 Then rptformula += " and {viewTransportDispatchTTS.orgTrnID} =" & cmbTransporter.Tag
                        If companyowntruck <> -1 Then rptformula += " and {viewTransportDispatchTTS.companyowntruck} =" & companyowntruck

                        rptformula += " and {viewTransportDispatchTTS.loadingdate} in """ & dt1.ToString("yyyy-MM-dd") & """ to """ & dt2.ToString("yyyy-MM-dd") & """"
                    Case "itrlist"
                        rptformula = "{viewTransportProfitibilityTTS.itrno}>0 and {viewTransportProfitibilityTTS.branchid} =" & txtBranchName.Tag
                        If cmbTransporter.Tag > 0 Then rptformula += " and {viewTransportProfitibilityTTS.orgTrnID} =" & cmbTransporter.Tag
                        rptformula += " and {viewTransportProfitibilityTTS.itrdt} in """ & dt1.ToString("yyyy-MM-dd") & """ to """ & dt2.ToString("yyyy-MM-dd") & """"
                        If chkITRDues.Checked Then rptformula += " and {@TotalDue} < 0"
                    Case "drivertrip"
                        rptformula = "{viewTransportDispatchTTS.companyowntruck}=0 and {viewTransportDispatchTTS.itrAmount}>0 and {viewTransportDispatchTTS.branchid} =" & txtBranchName.Tag
                        rptformula += " and {viewTransportDispatchTTS.loadingdate} in """ & dt1.ToString("yyyy-MM-dd") & """ to """ & dt2.ToString("yyyy-MM-dd") & """"
                        If cmbDriver.Tag > 0 Then rptformula += " and {viewTransportDispatchTTS.driverrecid} =" & cmbDriver.Tag
                    Case "pendingwb"
                        rptformula = "{viewTransportDispatchTTS.wbcancelled} = 0 and {viewTransportDispatchTTS.status}='NEW' and {viewTransportDispatchTTS.branchid} =" & txtBranchName.Tag
                        rptformula += " and {viewTransportDispatchTTS.wbdate} in """ & dt1.ToString("yyyy-MM-dd") & """ to """ & dt2.ToString("yyyy-MM-dd") & """"
                    Case "pendingitr"
                        rptformula = "{viewTransportDispatchTTS.wbcancelled} = 0 and {viewTransportDispatchTTS.branchid} =" & txtBranchName.Tag
                        rptformula += " and {viewTransportDispatchTTS.loadingdate} in """ & dt1.ToString("yyyy-MM-dd") & """ to """ & dt2.ToString("yyyy-MM-dd") & """"
                        rptformula += " and {viewTransportDispatchTTS.itramount}=0"
                    Case "wbbroker"
                        rptformula = "{viewTransportDispatchTTS.wbcancelled} = 0 and {viewTransportDispatchTTS.branchid} =" & txtBranchName.Tag
                        rptformula += " and {viewTransportDispatchTTS.loadingdate} in """ & dt1.ToString("yyyy-MM-dd") & """ to """ & dt2.ToString("yyyy-MM-dd") & """"
                        rptformula += " and {viewTransportDispatchTTS.commission}>0"
                        If cmbSupervisor.Tag > 0 Then rptformula += " and {viewTransportDispatchTTS.brokerid} =" & cmbSupervisor.Tag

                End Select
                ' MsgBox(rptFullPath)
                ConfigureCrystalReports(rptFullPath, rptformula, rptgroup)
            Else
                Call FillGrid()
                TabControl1.SelectedIndex = 0
            End If

        Catch ex As Exception
            lblMsg.Text = ex.Message
        End Try
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub FillGrid()
        imgApproveOK.Visible = False
        panelExport.Visible = False
        sql_String = ""
        Dim ctr As Integer = 0
        Dim companyowntruck As Integer = -1
        Dim datestr As String = ""
        datestr = " between '" & Date.Parse(txtFromDate.Text).ToString("yyyy'/'MM'/'dd") & "' and '" & Date.Parse(txtToDate.Text).ToString("yyyy'/'MM'/'dd") & "'"

        If (chkRentalT.Checked = False And chkCompanyT.Checked = True) Then companyowntruck = 0
        If (chkRentalT.Checked = True And chkCompanyT.Checked = False) Then companyowntruck = 1
        If (chkRentalT.Checked = False And chkCompanyT.Checked = False) Then companyowntruck = -1


        Select Case cmbReportType.Tag
            Case "disporder"
                sql_String = "select * from [viewTransportDispatchTTS] where branchID=" & txtBranchName.Tag
                If Not String.IsNullOrEmpty(cmbClient.Text) Then sql_String += " and cltrecid=" & cmbClient.Tag
                If Not String.IsNullOrEmpty(cmbTransporter.Text) Then sql_String += " and orgTrnID=" & cmbTransporter.Tag
                sql_String += " and loadingdate " & datestr
                If companyowntruck >= 0 Then sql_String += " and companyowntruck=" & companyowntruck

            Case "invapprove"
                sql_String = "select * from [viewarbillsforapproval] where branchid=" & txtBranchName.Tag & " and [INVDT] " & datestr

        End Select


        If Not String.IsNullOrEmpty(sql_String) Then
            Dim dsx As New DataSet
            Try
                frmWaitForm.lblTitle.Text = "Reading Data..."
                frmWaitForm.Show()
                frmWaitForm.Refresh()

                Me.Cursor = Cursors.WaitCursor

                RadGridView1.DataSource = Nothing
                dsx = setDataList(sql_String)
                If dsx.Tables(0).Rows.Count > 0 Then

                    RadGridView1.DataSource = dsx.Tables(0)

                    'dont display id columns 
                    If hidecolfrom > 0 Then
                        For ctr = hidecolfrom To RadGridView1.Columns.Count - 1
                            RadGridView1.Columns(ctr).IsVisible = False
                        Next ctr
                    End If

                    RadGridView1.MasterTemplate.BestFitColumns()
                    panelExport.Visible = True
                End If

            Catch ex As Exception
                lblMsg.Text = ex.Message
            End Try
            Me.Cursor = Cursors.Default
            frmWaitForm.Close()
        End If
    End Sub

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        Dim destfile As String = ""
        destfile = ExportToExcel(cmbReportType.Text, "")
        If chkPDF.Checked Then ExportToPDF(destfile, "")
    End Sub

#Region "Report Export Section"
    Private Function copyTemplate() As String
        Try
            Dim templateFile As String = ""
            Dim newFileName As String = ""
            Dim appPath As String = "" 'System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase)
            appPath = Directory.GetCurrentDirectory()

            Select Case cmbReportType.Tag
                Case "disporder" : templateFile = "iffTransportDispatchReport"
                Case "tprofitdet" : templateFile = "iffTransportProfitiblityReport"

            End Select
            newFileName = templateFile
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
    Private Function ExportToExcel(rTitle As String, rFilterText As String) As String
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim i As Integer = 0

            Dim str1 As String = ""
            Dim str2 As String = ""
            Dim cellRowIndex As Integer = 1
            Dim cellColumnIndex As Integer = 1
            Dim cellrangex As Excel.Range


            Dim destinationFile As String = copyTemplate()
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
            xlWorkSheet.Cells(3, 1) = appCompanyInfo.branchAddress

            'xlWorkSheet.Cells(2, 15) = Today.Date
            'xlWorkSheet.Cells(3, 15) = appUserInfo.Name
            str1 = "Transaction Period From : " & txtFromDate.Text & " To: " & txtToDate.Text
            'xlWorkSheet.Cells(4, 1) = rTitle
            xlWorkSheet.Cells(6, 1) = str1.ToString
            'xlWorkSheet.Cells(6, 1) = rFilterText.ToString

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
                    If objRadGrid.Columns(j).IsVisible = False Then Exit For
                    xlWorkSheet.Cells(cellRowIndex, cellColumnIndex) = objRadGrid.Rows(i).Cells(j).Value.ToString()
                    cellColumnIndex += 1
                Next
                cellColumnIndex = 1
                cellRowIndex += 1

                If (ProgressBar1.Value < ProgressBar1.Maximum) Then ProgressBar1.Value = i '

                ' If cellRowIndex = objRadGrid.Rows.Count - 1 Then Exit For
            Next
            ProgressBar1.Visible = False

            If cmbReportType.Tag = "tprofitdet" Then    'require totals
                xlWorkSheet.Cells(cellRowIndex, 6) = "Total"
                xlWorkSheet.Cells(cellRowIndex, 7) = "=SUM(G8:G" & (cellRowIndex - 1) & ")"
                xlWorkSheet.Cells(cellRowIndex, 8) = "=SUM(H8:H" & (cellRowIndex - 1) & ")"
                xlWorkSheet.Cells(cellRowIndex, 12) = "=SUM(L8:L" & (cellRowIndex - 1) & ")"
                cellrangex = xlWorkSheet.Range("A" & cellRowIndex, "N" & cellRowIndex + 1)
                cellrangex.Font.Bold = True
                cellrangex.Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
            End If
            '    xlWorkSheet.Cells(cellRowIndex + 1, 14) = "=SUM(N8:N" & cellRowIndex & ")"
            '    cellrangex = xlWorkSheet.Range("J" & cellRowIndex + 1, "N" & cellRowIndex + 1)
            '    cellrangex.Font.Bold = True
            'ElseIf rType = 2 Then 'VAT SUMMARY
            '    xlWorkSheet.Cells(cellRowIndex + 1, 1) = "Total"
            '    xlWorkSheet.Cells(cellRowIndex + 1, 2) = "=SUM(B8:B" & cellRowIndex & ")"
            '    xlWorkSheet.Cells(cellRowIndex + 1, 3) = "=SUM(C8:C" & cellRowIndex & ")"
            '    xlWorkSheet.Cells(cellRowIndex + 1, 4) = "=SUM(D8:D" & cellRowIndex & ")"
            '    cellrangex = xlWorkSheet.Range("A" & cellRowIndex + 1, "D" & cellRowIndex + 1)
            '    cellrangex.Font.Bold = True
            'End If

            xlWorkSheet.Cells(cellRowIndex + 1, 1) = "End Of Report"
            xlWorkSheet.Cells(cellRowIndex + 2, 1) = "Total Rows [" & objRadGrid.Rows.Count & "]"

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

            If chkPDF.Checked = False Then
                MsgBox("Output File Created [" & destinationFile & "]", MsgBoxStyle.Information, "Export File")
                Dim proc As Process = Nothing
                Dim startInfo As New ProcessStartInfo
                startInfo.FileName = "EXCEL.EXE"
                startInfo.Arguments = """" & destinationFile & """"
                Process.Start(startInfo)
            End If


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
    Public Sub ExportToPDF(sourceFile As String, password As String)
        Dim justFileName As String = ""
        Dim xlApp As Excel.Application
        xlApp = New Excel.Application
        'Dim xlApp As New Microsoft.Office.Interop.Excel.ApplicationClass
        Dim xlWorkBook As Microsoft.Office.Interop.Excel.Workbook
        Dim xlWorkSheet As Microsoft.Office.Interop.Excel.Worksheet
        Dim pdfFile As String = ""

        Try

            frmWaitForm.lblTitle.Text = "Converting to PDF. please wait..!"
            frmWaitForm.Show()
            frmWaitForm.Refresh()


            xlWorkBook = xlApp.Workbooks.Open(sourceFile) ' , Password:=password)           ' WORKBOOK TO OPEN THE EXCEL FILE.
            justFileName = xlWorkBook.Name()
            xlWorkSheet = xlWorkBook.Worksheets(1)    ' THE NAME OF THE WORK SHEET. 
            xlWorkSheet.ExportAsFixedFormat( _
                        Excel.XlFixedFormatType.xlTypePDF, _
                        pdfFile, _
                     Excel.XlFixedFormatQuality.xlQualityStandard, _
                          True, _
                        True, _
                        1, _
                        10, _
                          True)
            '
            xlWorkBook.Close()

            ''open excel f ile after writing data
            'xlApp.Workbooks.Open(sourceFile)
            'xlApp.Visible = True
            releaseObject(xlApp)
            releaseObject(xlWorkBook)
            releaseObject(xlWorkSheet)

            'MsgBox("PDF Saved to your Documents Folder", vbInformation, "PDF Export Complete")


        Catch ex As Exception
            frmWaitForm.Close()
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "ExportToPDF")
        Finally
            frmWaitForm.Close()
        End Try

    End Sub
#End Region
#Region "Crystal Report Viewer Section"
    Private Sub ConfigureCrystalReports(rptName As String, rptFormula As String, blShowGroupTree As Boolean)
        Try
            lblMsg.Text = ""
            Me.Cursor = Cursors.WaitCursor
            Dim rpt As New ReportDocument()
            rpt.Load(rptName)
            Dim connectionInfo As ConnectionInfo = New ConnectionInfo()
            connectionInfo.DatabaseName = "iff2009"
            connectionInfo.UserID = RemoteUserName ' "iffrptremote"
            connectionInfo.Password = RemotePassword ' "Admin@123456"
            SetDBLogonForReport(connectionInfo, rpt)
            With CrystalReportViewer2
                .SelectionFormula = rptFormula
                .Dock = DockStyle.Fill
                .ShowPrintButton = True
                .ShowExportButton = True
                .ShowGroupTreeButton = blShowGroupTree
                .ShowParameterPanelButton = False
                .ToolPanelView = IIf(blShowGroupTree, _
                         CrystalDecisions.Windows.Forms.ToolPanelViewType.GroupTree, _
                         CrystalDecisions.Windows.Forms.ToolPanelViewType.None)
                .ReportSource = rpt
            End With
        Catch ex As Exception
            lblMsg.Text = ex.Message
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub SetDBLogonForReport(ByVal connectionInfo As ConnectionInfo, ByVal reportDocument As ReportDocument)
        Dim tables As Tables = reportDocument.Database.Tables
        For Each table As CrystalDecisions.CrystalReports.Engine.Table In tables
            Dim tableLogonInfo As TableLogOnInfo = table.LogOnInfo
            tableLogonInfo.ConnectionInfo = connectionInfo
            table.ApplyLogOnInfo(tableLogonInfo)
        Next
    End Sub
#End Region

    Private Sub cmbReportType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbReportType.SelectedIndexChanged
        lblReportTitle.Text = cmbReportType.Text
    End Sub

    Private Sub txtValue_GotFocus(sender As Object, e As EventArgs) Handles txtValue.GotFocus
        txtValue.SelectAll()
    End Sub

    Private Sub lnkApproveInvoice_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkApproveInvoice.LinkClicked
        imgApproveOK.Visible = False
        If RadGridView1.Rows.Count < 1 Then Return
        Dim invrecid As Integer = 0
        invrecid = RadGridView1.Rows(RadGridView1.CurrentRow.Index).Cells("invrecid").Value
        If MsgBox("Approve This Invoice# " & RadGridView1.Rows(RadGridView1.CurrentRow.Index).Cells("inv#").Value & " for Final Print ?", vbExclamation + MsgBoxStyle.YesNo, "Invoice Approval") = MsgBoxResult.Yes Then
            Dim rtnval As Boolean = True
            sql_String = "update [billinginvoicedetail] set invapprove=1 where recid=" & invrecid
            Try
                Me.Cursor = Cursors.WaitCursor
                If sql_CNN.State = ConnectionState.Closed Then createConnection()
                Dim commandy As New SqlCommand(sql_String, sql_CNN)
                commandy.ExecuteNonQuery()
                imgApproveOK.Visible = True
                Me.Cursor = Cursors.Default
            Catch ex As Exception
                rtnval = False
                lblMsg.Text = ex.Message
            End Try
            Me.Cursor = Cursors.Default
        End If

    End Sub

    Private Sub lnkPreviewInvoice_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkPreviewInvoice.LinkClicked
        Dim rptFullPath As String = ""
        Dim invrecid As Integer = 0
        invrecid = RadGridView1.Rows(RadGridView1.CurrentRow.Index).Cells("invrecid").Value
        rptFullPath = Application.StartupPath & IIf(byBranch, appCompanyInfo.customizerptpath, "\reports") & "\" & rptFileName
        Try
            If RadGridView1.Rows.Count > 0 Then
                Dim rptformula As String = ""
                Select Case cmbReportType.Tag
                    Case "invapprove"
                        rptformula = "{viewARBillForFinalPrintTTS.recid} = " & invrecid
                        TabControl1.SelectedIndex = 1
                        ConfigureCrystalReports(rptFullPath, rptformula, False)
                End Select
            End If

        Catch ex As Exception
            lblMsg.Text = ex.Message
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        cmbDriver.Text = ""
        cmbDriver.Tag = 0
    End Sub

    Private Sub cmbDriver_LostFocus(sender As Object, e As EventArgs) Handles cmbDriver.LostFocus
        Try
            Me.Cursor = Cursors.WaitCursor
            If cmbDriver.SelectedValue <> "" Then
                cmbDriver.Tag = 0
                Dim selectedRow As GridViewDataRowInfo = DirectCast(cmbDriver.SelectedItem, GridViewDataRowInfo)
                cmbDriver.Tag = (selectedRow.Cells("recid").Value.ToString())
            End If
        Catch ex As Exception
            lblMsg.Text = ex.Message
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        cmbSupervisor.Text = ""
        cmbSupervisor.Tag = 0
    End Sub

    Private Sub cmbSupervisor_LostFocus(sender As Object, e As EventArgs) Handles cmbSupervisor.LostFocus
        Try
            Me.Cursor = Cursors.WaitCursor
            If cmbSupervisor.SelectedValue <> "" Then
                cmbSupervisor.Tag = 0
                Dim selectedRow As GridViewDataRowInfo = DirectCast(cmbSupervisor.SelectedItem, GridViewDataRowInfo)
                cmbSupervisor.Tag = (selectedRow.Cells("recid").Value.ToString())
            End If
        Catch ex As Exception
            lblMsg.Text = ex.Message
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

End Class