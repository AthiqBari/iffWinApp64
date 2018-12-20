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

Public Class frmEqpGroup
    Dim recID As Integer = 0
    Dim action As String = ""
    Dim ds As New DataSet
    Dim cp = New clsParam()


    Private Sub frmChargeCodeMaster_Load(sender As Object, e As EventArgs) Handles Me.Load
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

        If String.IsNullOrEmpty(txtName.Text) Then lblMessage.Text = "Name is Required" : txtName.Focus() : rtnval = False
        If String.IsNullOrEmpty(cmbType.Text) Then lblMessage.Text = "Equipment is Required" : cmbType.Focus() : rtnval = False
        If String.IsNullOrEmpty(txtShortName.Text) Then lblMessage.Text = "Short Name is Required" : txtShortName.Focus() : rtnval = False

        btnSave.BackColor = IIf(rtnval, Color.DodgerBlue, Color.DarkOrange)
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
                sql_String = "select * from [equipmentgroup] where recid=" & recID
                .SelectCommand = New SqlCommand(sql_String, sql_CNN)
                .Fill(ds, "cdata")
            End With

            If ds.Tables("cdata").Rows.Count = 0 Then
                dr = ds.Tables("cdata").NewRow 'addnew
                ds.Tables("cdata").Rows.Add(dr) 'add the row to dataset
            Else
                dr = ds.Tables("cdata").Rows(0)
            End If
            dr.Item("name") = txtName.Text
            dr.Item("shortname") = txtShortName.Text
            dr.Item("etype") = cmbType.Text
            dr.Item("IsActive") = chkIsActive.Checked
            dr.Item("tripratepercentage") = 0
            adapter.Update(ds, "cdata")
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            lblMessage.Text = "Not Saved!"
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

        Dim vfldName As String = "name"
        Select Case cmbSearchBy.SelectedIndex
            Case 0 : vfldName = "name"
                'Case 1 : vfldName = "itemdescription"
                'Case 2 : vfldName = "[group]"
        End Select

        Try
            sql_String = "select Name, ShortName, etype [Type], isActive,recid,slno from equipmentgroup where recid>0"
            If Not String.IsNullOrEmpty(txtShipmentNumberFind.Text) Then
                If Not String.IsNullOrEmpty(cmbSearchBy.Text) Then
                    sql_String += " and " & vfldName & " like '%" & txtShipmentNumberFind.Text & "%';"
                End If
            Else
                sql_String += " order by slno"

            End If

            Me.Cursor = Cursors.WaitCursor
            RadGridView2.DataSource = Nothing
            dsx = setDataList(sql_String)
            If dsx.Tables(0).Rows.Count > 0 Then
                lblToolTip.Text = "Found: " & dsx.Tables(0).Rows.Count
                RadGridView2.DataSource = dsx.Tables(0)
                RadGridView2.MasterTemplate.BestFitColumns()
                RadGridView2.Columns("recid").IsVisible = False
                ' dsPrintSearch = dsx
            End If
        Catch ex As Exception
            lblToolTip.Text = ex.Message
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub RadGridView2_CellDoubleClick(sender As Object, e As GridViewCellEventArgs) Handles RadGridView2.CellDoubleClick
        Try
            recID = Me.RadGridView2.Rows(e.RowIndex).Cells("recid").Value

            Call getItemData(recID)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub getItemData(mRecID As Integer)
        If recID < 1 Then Exit Sub
        Dim ds As New DataSet
        Call clearForm()
        sql_String = "select * from equipmentgroup  where recid=" & mRecID

        Try
            Me.Cursor = Cursors.WaitCursor
            ds = setDataList(sql_String)
            If ds.Tables(0).Rows.Count > 0 Then
                With ds.Tables(0).Rows(0)
                    recID = mRecID
                    lblID.Text = recID
                    radSBar3.Text = "ID " & recID
                    txtName.Text = .Item("name")
                    txtShortName.Text = .Item("shortname")
                    chkIsActive.Checked = CBool(.Item("isactive"))
                    cmbType.Text = .Item("etype")
                    lblItemCodeName.Text = txtName.Text
                    '                    radSBar1.Text = "Created By/On : " & .Item("createdby") & " " & .Item("createdon")
                    '   radSBar2.Text = "Updated By/On : " & .Item("updatedby") & " " & .Item("updatedon")
                    '    If Not IsDBNull(.Item("tmOldPartsReceivedBy")) Then txttmOldPartsReceivedBy.Text = .Item("tmOldPartsReceivedBy")
                    '    If IsDate(.Item("tmOldPartsReceivedOn")) Then txttmOldPartsReceivedOn.Text = .Item("tmOldPartsReceivedOn")
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
        txtName.Clear()
        lblID.Text = 0
        recID = -1
        txtShortName.Clear()
        chkIsActive.Checked = True
        cmbType.Tag = 0
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
        sql_String = "select Name, ID from [equipmenttype] where isActive=1 order by name"
        Call fillCombo(cmbType, sql_String, 0, 0, 200, 0)
        Me.Cursor = Cursors.Default
        frmWaitForm.Close()
    End Sub

    Private Sub txtNameEN_GotFocus(sender As Object, e As EventArgs) Handles txtName.GotFocus
        '   txtName.SelectAll()
    End Sub

    Private Sub txtNameAR_TextChanged(sender As Object, e As EventArgs) Handles txtShortName.TextChanged
        '     txtShortName.SelectAll()
    End Sub

    Private Sub BtnExportToExcel_Click(sender As Object, e As EventArgs) Handles BtnExportToExcel.Click
        MsgBox("Not Available Now", MsgBoxStyle.Information, Me.Text)
        'Dim excelFile As String = ""
        'Return
        'If RadGridView2.Rows.Count > 0 Then
        '    If MsgBox("This action will export data to excel, Continue (Y/N)", vbQuestion + vbYesNo, "Export Data") = MsgBoxResult.Yes Then
        '        excelFile = ExportToExcel()
        '        If chkPDF.CheckState = CheckState.Checked Then
        '            If Not String.IsNullOrEmpty(excelFile) Then ExportToPDF(excelFile, "")
        '        End If
        '    End If
        'End If
    End Sub

    Private Function ExportToExcel() As String
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim i As Integer = 0
            Dim endColumnIndex As Integer = 0

            Dim cellRowIndex As Integer = 1
            Dim cellColumnIndex As Integer = 1

            Dim destinationFile As String = copyTemplate("iffReportTemplate.xls", "ChargeCodeList")
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
            xlWorkSheet.Cells(1, 3) = appCompanyInfo.companyName
            xlWorkSheet.Cells(2, 3) = appCompanyInfo.branchName
            xlWorkSheet.Cells(3, 3) = appCompanyInfo.branchAddress
            xlWorkSheet.Cells(4, 3) = appCompanyInfo.branchContact & " E-Mail:" & appCompanyInfo.branchEmail
            xlWorkSheet.Cells(5, 3) = appCompanyInfo.companyWebsite
            '---------------------------------------------------------------------------'-------------------------------------------

            xlWorkSheet.Cells(6, 1) = "Equipment Groups"

            'If rType <> 10 Then xlWorkSheet.Cells(4, 1) = "Pickup Period From [" & RadDateTimePicker3.Text & "] - [" & RadDateTimePicker4.Text & "]"

            'start writing data from 
            cellRowIndex = 8    'columns
            cellColumnIndex = 1 'start reading fromgrid
            endColumnIndex = 10 'dont print columns after this value

            For i = 0 To objRadGrid.Columns.Count - 1
                If cellColumnIndex <= endColumnIndex Then
                    xlWorkSheet.Cells(cellRowIndex, cellColumnIndex) = objRadGrid.Columns(i).HeaderText.ToString
                End If
                cellColumnIndex += 1
            Next


            cellColumnIndex = 1
            cellRowIndex = 9
            'Loop through each row and read value from each column.
            For i = 0 To objRadGrid.Rows.Count - 1
                For j As Integer = 0 To objRadGrid.Columns.Count - 1
                    If cellColumnIndex <= endColumnIndex Then
                        xlWorkSheet.Cells(cellRowIndex, cellColumnIndex) = objRadGrid.Rows(i).Cells(j).Value.ToString()
                    End If
                    cellColumnIndex += 1
                Next
                cellColumnIndex = 1
                cellRowIndex += 1
            Next

            xlWorkBook.Close(SaveChanges:=True)
            xlApp.Quit()

            If chkPDF.CheckState = CheckState.Unchecked Then
                xlApp.Workbooks.Open(destinationFile)
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

    Private Sub txtNameEN_TextChanged(sender As Object, e As EventArgs) Handles txtName.TextChanged
        lblItemCodeName.Text = txtName.Text
    End Sub


End Class