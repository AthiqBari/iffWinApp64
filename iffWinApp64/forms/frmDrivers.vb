﻿'iff general forms
Imports Telerik.WinControls.UI
Imports System.Data.Sql
Imports System.Data
Imports System.Data.SqlClient
Imports System.Exception
Imports System.Data.OleDb
Imports System.IO
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Text.RegularExpressions

Public Class frmDrivers
    Dim recID As Integer = 0
    Dim action As String = ""
    Dim ds As New DataSet
    Dim cp = New clsParam()


    Private Sub frmDrivers_Load(sender As Object, e As EventArgs) Handles Me.Load
        appPath = New Uri(appPath).LocalPath
        Me.Left = 1
        Me.Top = 1
        TabControlMain.TabPages(0).Enabled = True
        TabControlMain.TabPages(1).Enabled = True
        TabControlMain.SelectedIndex = 1
        cmbSearchBy.SelectedIndex = 0
        Call initFormLoad()
        clearForm()
        lblBranch.Text = appCompanyInfo.branchName

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
        If String.IsNullOrEmpty(cmbGroup.Text) Then lblMessage.Text = "Driver Nationality Group is Required" : cmbGroup.Focus() : rtnval = False
        If String.IsNullOrEmpty(txtid.Text) Then lblMessage.Text = "Driver ID Number is Required" : txtid.Focus() : rtnval = False
        If String.IsNullOrEmpty(txtmobile.Text) Then lblMessage.Text = "Driver Mobile Number is Required" : txtmobile.Focus() : rtnval = False
        If RadioButton1.Checked = False And RadioButton2.Checked = False Then lblMessage.Text = "Equipment Ownership is Required" : RadioButton1.Focus() : rtnval = False

        '  Validate(mobile / id)
        sql_String = "select * from [drivers] where (mobile='" & txtmobile.Text & "' or idno='" & txtid.Text & "')"
        If action = "E" Then sql_String += " and name not in('" & txtName.Text & "');"
        Me.Cursor = Cursors.WaitCursor
        Dim dstmp As New DataSet
        dstmp = setDataList(sql_String)

        If dstmp.Tables(0).Rows.Count > 0 Then
            Me.Cursor = Cursors.Default
            lblMessage.Text = "Not Saved.. Mobile Or ID Number already found for [" & dstmp.Tables(0).Rows(0).Item("name") & "]"
            rtnval = False
        End If


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
                sql_String = "select * from [drivers] where recid=" & recID
                .SelectCommand = New SqlCommand(sql_String, sql_CNN)
                .Fill(ds, "cdata")
            End With
            If ds.Tables("cdata").Rows.Count = 0 Then
                dr = ds.Tables("cdata").NewRow 'addnew
                ds.Tables("cdata").Rows.Add(dr) 'add the row to dataset
                dr.Item("branchID") = appUserInfo.BranchId
            Else
                dr = ds.Tables("cdata").Rows(0)
            End If
            dr.Item("name") = txtName.Text
            dr.Item("nation_ID") = cmbGroup.Tag
            dr.Item("mobile") = txtmobile.Text
            dr.Item("idNo") = txtid.Text
            If IsDate(txtHireDate.Text) Then dr.Item("licexpirydt") = txtHireDate.Text
            dr.Item("licno") = txtlicno.Text
            If RadioButton1.Checked Then dr.Item("hired") = 1
            If RadioButton2.Checked Then dr.Item("hired") = 0
            dr.Item("note") = txtnote.Text
            dr.Item("status") = chkIsActive.Checked
            dr.Item("IsActive") = chkIsActive.Checked

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
            Case 0 : vfldName = "d.name"
                'Case 1 : vfldName = "e2.etype"
                'Case 2 : vfldName = "[group]"
        End Select

        Try
            sql_String = " select d.name [DriverName], n.name [Nationality], br.brcode [Branch],"
            sql_String += " case d.hired when 0 then 'Company' ELSE 'Rental' end [Sponsorship],"
            sql_String += " isnull(d.licexpirydt,'') [HireDate],isnull(d.mobile,'') [Mobile#],"
            sql_String += " isnull(d.idno,'') [ID#], isnull(d.licno,'') [License#],d.isActive [Active], d.note [Note],d.recid,n.recid [nrecid]"
            sql_String += " from drivers d inner join nationality n on d.nation_ID=n.recID inner join branch br on d.branchid=br.recid"
            sql_String += " and d.branchid=" & appUserInfo.BranchId
            If Not String.IsNullOrEmpty(txtShipmentNumberFind.Text) Then
                If Not String.IsNullOrEmpty(cmbSearchBy.Text) Then
                    sql_String += " and " & vfldName & " like '%" & txtShipmentNumberFind.Text & "%';"
                End If
            End If

            Me.Cursor = Cursors.WaitCursor
            RadGridView2.DataSource = Nothing
            dsx = setDataList(sql_String)
            If dsx.Tables(0).Rows.Count > 0 Then
                lblToolTip.Text = "Found: " & dsx.Tables(0).Rows.Count
                RadGridView2.DataSource = dsx.Tables(0)
                RadGridView2.MasterTemplate.BestFitColumns()
                RadGridView2.Columns("recid").IsVisible = False
                RadGridView2.Columns("nrecid").IsVisible = False
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
        sql_String = " select d.name [DriverName], n.name [Nationality],"
        sql_String += " d.hired ,"
        sql_String += " isnull(d.licexpirydt,'') [HireDate],isnull(d.mobile,'') [Mobile#],"
        sql_String += " isnull(d.idno,'') [ID#], isnull(d.licno,'') [License#],d.isActive [Active], d.note [Note],d.recid, n.recid [nrecid]"
        sql_String += " from drivers d inner join nationality n on d.nation_ID=n.recID inner join branch br on d.branchid=br.recid"
        sql_String += " where d.recid=" & mRecID

        Try
            Me.Cursor = Cursors.WaitCursor
            ds = setDataList(sql_String)
            If ds.Tables(0).Rows.Count > 0 Then
                With ds.Tables(0).Rows(0)
                    recID = mRecID
                    lblID.Text = recID
                    radSBar3.Text = "ID " & recID
                    txtName.Text = .Item("DriverName")
                    cmbGroup.Text = .Item("Nationality")
                    cmbGroup.Tag = .Item("nrecid")
                    If IsDate(.Item("hiredate")) Then txtHireDate.Text = .Item("hiredate")
                    txtmobile.Text = .Item("Mobile#")
                    txtid.Text = .Item("id#")
                    txtlicno.Text = .Item("license#")
                    txtnote.Text = .Item("note")
                    If .Item("hired") = 0 Then RadioButton1.Checked = True
                    If .Item("hired") = 1 Then RadioButton2.Checked = True
                    chkIsActive.Checked = CBool(.Item("Active"))
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
        cmbGroup.Text = ""
        cmbGroup.Tag = 0
        txtName.Clear()
        txtHireDate.SetToNullValue()
        txtmobile.Clear()
        txtid.Clear()
        txtlicno.Clear()
        txtnote.Clear()
        RadioButton1.Checked = False
        RadioButton2.Checked = False
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
        sql_String = "select Name, recid from [nationality] where recid>-1 order by Name"
        Call fillCombo(cmbGroup, sql_String, 300, 0, 300, 100)
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

            xlWorkSheet.Cells(6, 1) = "Driver List"

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

            ProgressBar1.Minimum = 0
            ProgressBar1.Maximum = objRadGrid.Rows.Count + 1
            ProgressBar1.Value = 0
            ProgressBar1.Visible = True

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
        End If
    End Sub
End Class