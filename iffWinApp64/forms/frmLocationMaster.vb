'iff general forms
Imports Telerik.WinControls.UI
Imports System.Data.Sql
Imports System.Data
Imports System.Data.SqlClient
Imports System.Exception
Imports System.Data.OleDb
Imports System.IO
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Text.RegularExpressions

Public Class frmlocationmaster
    Dim recID As Integer = 0
    Dim action As String = ""
    Dim countrycode As String = ""
    Dim unloco As String = ""
    Dim ds As New DataSet
    Dim cp = New clsParam()


    Private Sub frmlocationmaster_Load(sender As Object, e As EventArgs) Handles Me.Load
        appPath = New Uri(appPath).LocalPath
        Me.Left = 1
        Me.Top = 1
        TabControlMain.TabPages(0).Enabled = True
        TabControlMain.TabPages(1).Enabled = True
        TabControlMain.SelectedIndex = 1
        cmbSearchBy.SelectedIndex = 0
        Call initFormLoad()
        clearForm()

    End Sub

    Private Sub btnAddNewRequest_Click(sender As Object, e As EventArgs) Handles btnAddNewRequest.Click
        TabControlMain.TabPages(0).Enabled = True
        TabControlMain.SelectedIndex = 0
        clearForm()
        action = "A"
        txtName.Focus()
    End Sub

    Private Function saveCheck() As Boolean
        Dim rtnval As Boolean = True
        lblMessage.Text = ""
        If countrycode = "" Then lblMessage.Text = "Country Group is Required" : cmbGroup.Focus() : rtnval = False
        If unloco = "" Then lblMessage.Text = "City Group is Required" : cmbGroup.Focus() : rtnval = False
        If String.IsNullOrEmpty(cmbGroup.Text) Then lblMessage.Text = "Country Group is Required" : cmbGroup.Focus() : rtnval = False
        If String.IsNullOrEmpty(cmbCity.Text) Then lblMessage.Text = "City Group is Required" : cmbCity.Focus() : rtnval = False
        If String.IsNullOrEmpty(txtName.Text) Then lblMessage.Text = "Area/Location Name is Required" : txtName.Focus() : rtnval = False

        btnSave.BackColor = IIf(rtnval, Color.DodgerBlue, Color.DarkOrange)
        Me.Cursor = Cursors.Default
        Return rtnval
    End Function


    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Not saveCheck() Then Exit Sub
        Call UpdateRecord()
        lblMessage.Text = "Save Complete!"

        'lock screen
        TabControlMain.TabPages(0).Enabled = False

    End Sub

    Private Sub UpdateRecord()
        If action = "" Then Return
        If Not saveCheck() Then Return

        Dim adapter As New SqlDataAdapter
        Dim ds As New DataSet
        Dim dr As DataRow
        Dim cmdbuilder As SqlCommandBuilder
        Try
            Me.Cursor = Cursors.WaitCursor
            cmdbuilder = New SqlCommandBuilder(adapter)
            With adapter
                sql_String = "select * from [locationmaster] where recid=" & recID
                .SelectCommand = New SqlCommand(sql_String, sql_CNN)
                .Fill(ds, "cdata")
            End With
            If ds.Tables("cdata").Rows.Count = 0 Then
                dr = ds.Tables("cdata").NewRow 'addnew
                ds.Tables("cdata").Rows.Add(dr) 'add the row to dataset
            Else
                dr = ds.Tables("cdata").Rows(0)
            End If
            dr.Item("area") = txtName.Text
            dr.Item("unloco") = unloco
            dr.Item("IsActive") = chkIsActive.Checked
            dr.Item("countrycode") = countrycode

            adapter.Update(ds, "cdata")
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            lblMessage.Visible = True
            lblMessage.Text = Err.Description
        End Try
    End Sub


    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim dsx As New DataSet
        lblToolTip.Text = ""
        Dim val1 As VariantType = 0
        Dim val2 As VariantType = 0
        recID = -1
        Dim myStr As String = ""
        lblToolTip.Text = ""

        Dim vfldName As String = ""
        Select Case cmbSearchBy.SelectedIndex
            Case 0 : vfldName = "u.name"
            Case 1 : vfldName = "u.code"
        End Select
        Try
            sql_String = "select c.name Country, u.name [City], u.code [unloco], l.area [Area], l.isactive [Active], c.recid crecid, u.id urecid, l.recid [lrecid]"
            sql_String += " from locationmaster l inner join unloco u on l.unloco=u.code inner join countries c on u.countrycode=c.shortname"
            sql_String += " where l.recid>0 "
            If Not String.IsNullOrEmpty(txtShipmentNumberFind.Text) Then
                If Not String.IsNullOrEmpty(cmbSearchBy.Text) Then
                    If cmbSearchBy.SelectedIndex = 1 Then
                        sql_String += " and " & vfldName & " like '" & txtShipmentNumberFind.Text & "%';"
                    Else
                        sql_String += " and " & vfldName & " like '%" & txtShipmentNumberFind.Text & "%';"

                    End If
                End If
            End If

            Me.Cursor = Cursors.WaitCursor
            RadGridView2.DataSource = Nothing
            dsx = setDataList(sql_String)
            If dsx.Tables(0).Rows.Count > 0 Then
                lblToolTip.Text = "Found: " & dsx.Tables(0).Rows.Count
                RadGridView2.DataSource = dsx.Tables(0)
                RadGridView2.MasterTemplate.BestFitColumns()
                RadGridView2.Columns("urecid").IsVisible = False
                RadGridView2.Columns("crecid").IsVisible = False
                RadGridView2.Columns("lrecid").IsVisible = False
                ' dsPrintSearch = dsx
            End If
        Catch ex As Exception
            lblToolTip.Text = ex.Message
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub RadGridView2_CellDoubleClick(sender As Object, e As GridViewCellEventArgs) Handles RadGridView2.CellDoubleClick
        Try
            recID = Me.RadGridView2.Rows(e.RowIndex).Cells("lrecid").Value

            Call getItemData(recID)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub getItemData(mRecID As Integer)
        If recID < 1 Then Exit Sub
        Dim ds As New DataSet
        Call clearForm()
        sql_String = " select c.name Country, u.name [City], u.code [unloco], l.area [Area], u.countrycode , l.isactive [lisactive], c.recid crecid, u.id urecid, l.recid"
        sql_String += " from locationmaster l inner join unloco u on l.unloco=u.code inner join countries c on u.countrycode=c.shortname"
        sql_String += " where l.recid=" & mRecID

        Try
            Me.Cursor = Cursors.WaitCursor
            ds = setDataList(sql_String)
            If ds.Tables(0).Rows.Count > 0 Then
                With ds.Tables(0).Rows(0)
                    recID = mRecID
                    lblID.Text = recID
                    radSBar3.Text = "ID " & recID
                    cmbGroup.Text = .Item("Country")
                    cmbGroup.Tag = .Item("crecid")
                    cmbCity.Text = .Item("City")
                    cmbCity.Tag = .Item("urecid")
                    txtName.Text = .Item("area")
                    lblUnLoco.Text = .Item("unloco")
                    countrycode = .Item("countrycode")
                    unloco = .Item("unloco")
                    chkIsActive.Checked = CBool(.Item("lisactive"))
                    lblItemCodeName.Text = txtName.Text
                End With

                TabControlMain.SelectedIndex = 0
                TabControlMain.TabPages(0).Enabled = True
                txtName.Focus()
                txtName.SelectAll()
                action = "E"
            End If

            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)

        End Try

    End Sub
    Private Sub clearForm()
        cmbGroup.Text = ""
        cmbGroup.Tag = 0
        txtName.Clear()
        cmbCity.Text = ""
        cmbCity.Tag = 0
        unloco = ""
        countrycode = ""
        lblUnLoco.Text = ""
        txtName.Clear()
        chkIsActive.Checked = True
        lblID.Text = 0
        recID = -1
        lblMessage.Text = ""
        lblToolTip.Text = ""
        lblMessage.Text = ""
        action = ""
    End Sub
    Private Sub initFormLoad()
        frmWaitForm.lblTitle.Text = "Loading Master Data. please wait..!"
        frmWaitForm.Show()
        frmWaitForm.Refresh()
        Me.Cursor = Cursors.WaitCursor
        sql_String = "select Name, shortname,recid from [countries] where recid>-1 order by Name"
        Call fillCombo(cmbGroup, sql_String, 300, 100, 400, 100)
        Me.Cursor = Cursors.Default
        frmWaitForm.Close()
    End Sub


    Private Sub BtnExportToExcel_Click(sender As Object, e As EventArgs) Handles BtnExportToExcel.Click
        Dim excelFile As String = ""
        If RadGridView2.Rows.Count > 0 Then
            If MsgBox("This action will export data to excel, Continue (Y/N)", vbQuestion + vbYesNo, "Export Data") = MsgBoxResult.Yes Then
                excelFile = ExportToExcel()
                If chkPDF.CheckState = CheckState.Checked Then
                    If Not String.IsNullOrEmpty(excelFile) Then ExportToPDF(excelFile, "")
                End If
            End If
        End If
    End Sub

    Private Function ExportToExcel() As String
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim i As Integer = 0
            Dim endColumnIndex As Integer = 0

            Dim cellRowIndex As Integer = 1
            Dim cellColumnIndex As Integer = 1

            Dim destinationFile As String = copyTemplate("iffReportTemplate.xls", "Driver List")
            If IO.File.Exists(destinationFile) = False Then
                Me.Cursor = Cursors.WaitCursor
                MsgBox("File does not exists " & destinationFile, MsgBoxStyle.Exclamation, "File Not Found")
                Return ""
                Exit Function
            End If

            frmWaitForm.lblTitle.Text = "Preparing Report (Excel). please wait..!"
            frmWaitForm.Show()
            frmWaitForm.Refresh()
            Me.Cursor = Cursors.WaitCursor

            '.net 4.5
            Dim xlApp As New Excel.Application ' Microsoft.Office.Interop.Excel.ApplicationClass
            Dim xlWorkBook As Microsoft.Office.Interop.Excel.Workbook
            Dim xlWorkSheet As Microsoft.Office.Interop.Excel.Worksheet
            Dim objRadGrid As RadGridView = Nothing
            objRadGrid = RadGridView2
            xlWorkBook = xlApp.Workbooks.Open(destinationFile)
            xlWorkSheet = xlWorkBook.Worksheets("Sheet1")

            'write company/branch report header section ---------------------------------------------------------------------------
            xlWorkSheet.Cells(1, 1) = appCompanyInfo.companyName
            xlWorkSheet.Cells(2, 1) = appCompanyInfo.branchName
            xlWorkSheet.Cells(3, 1) = appCompanyInfo.branchAddress
            xlWorkSheet.Cells(4, 1) = appCompanyInfo.branchContact & " E-Mail:" & appCompanyInfo.branchEmail
            xlWorkSheet.Cells(5, 1) = appCompanyInfo.companyWebsite
            '---------------------------------------------------------------------------'-------------------------------------------

            xlWorkSheet.Cells(6, 1) = "Country/City Location List"

            'If rType <> 10 Then xlWorkSheet.Cells(4, 1) = "Pickup Period From [" & RadDateTimePicker3.Text & "] - [" & RadDateTimePicker4.Text & "]"

            'start writing data from 
            cellRowIndex = 8    'columns
            cellColumnIndex = 1 'start reading fromgrid
            endColumnIndex = 4 'dont print columns after this value

            For i = 0 To objRadGrid.Columns.Count - 1
                If cellColumnIndex <= endColumnIndex Then
                    'If objRadGrid.Columns(i).IsVisible Then

                    'End If
                    xlWorkSheet.Cells(cellRowIndex, cellColumnIndex) = objRadGrid.Columns(i).HeaderText.ToString
                End If
                cellColumnIndex += 1
            Next

            ProgressBar1.Minimum = 0
            ProgressBar1.Maximum = objRadGrid.Rows.Count + 1
            ProgressBar1.Value = 0
            ProgressBar1.Visible = True

            cellColumnIndex = 1
            cellRowIndex = 9
            Dim cellvalue As String
            'Loop through each row and read value from each column.
            For i = 0 To objRadGrid.Rows.Count - 1
                For j As Integer = 0 To objRadGrid.Columns.Count - 1
                    '   If cellColumnIndex <= endColumnIndex Then
                    'If objRadGrid.Columns(i).IsVisible Then
                    cellvalue = objRadGrid.Rows(i).Cells(j).Value.ToString()
                    If objRadGrid.Columns(i).IsVisible = False Then cellvalue = ""
                    xlWorkSheet.Cells(cellRowIndex, cellColumnIndex) = cellvalue
                    'End If
                    '  End If
                    cellColumnIndex += 1
                Next
                cellColumnIndex = 1
                cellRowIndex += 1

                If (ProgressBar1.Value < ProgressBar1.Maximum) Then ProgressBar1.Value = i

            Next

            ProgressBar1.Visible = False

            xlWorkBook.Close(SaveChanges:=True)
            xlApp.Quit()

            'If chkPDF.CheckState = CheckState.Unchecked Then
            '    xlApp.Workbooks.Open(destinationFile)
            '     xlWorkSheet = xlWorkBook.Worksheets("Sheet1")
            '    xlApp.Visible = True
            '                xlWorkBook.PrintPreview()
            '               xlApp.Visible = True
            'End If

            releaseObject(xlApp)
            releaseObject(xlWorkBook)
            releaseObject(xlWorkSheet)


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
            frmWaitForm.Close()
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, vbCritical, Me.Text)
            Return ""
        End Try

    End Function

    Private Sub txtNameEN_TextChanged(sender As Object, e As EventArgs) Handles txtName.TextChanged
        lblItemCodeName.Text = txtName.Text
    End Sub

    Private Sub cmbGroup_LostFocus(sender As Object, e As EventArgs) Handles cmbGroup.LostFocus
        If cmbGroup.SelectedValue <> "" Then
            cmbGroup.Tag = 0
            Dim selectedRow As GridViewDataRowInfo = DirectCast(cmbGroup.SelectedItem, GridViewDataRowInfo)
            cmbGroup.Tag = (selectedRow.Cells("recid").Value.ToString())
            countrycode = (selectedRow.Cells("shortname").Value.ToString())

            If cmbGroup.Tag > 0 And countrycode <> "" Then
                Me.Cursor = Cursors.WaitCursor
                sql_String = "select Name, code,id from [unloco] where id>0 and countrycode='" & countrycode & "' order by Name"
                Call fillCombo(cmbCity, sql_String, 300, 100, 400, 100)
                Me.Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub cmbCity_LostFocus(sender As Object, e As EventArgs) Handles cmbCity.LostFocus
        If cmbCity.SelectedValue <> "" Then
            cmbCity.Tag = 0 : unloco = ""
            Dim selectedRow As GridViewDataRowInfo = DirectCast(cmbCity.SelectedItem, GridViewDataRowInfo)
            cmbCity.Tag = (selectedRow.Cells("id").Value.ToString())
            lblUnLoco.Text = (selectedRow.Cells("code").Value.ToString())
            unloco = lblUnLoco.Text
        End If
    End Sub

    Private Sub cmbGroup_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbGroup.SelectedIndexChanged

    End Sub
End Class