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

Public Class frmChargeCodeMaster
    Dim recID As Integer = 0
    Dim action As String = ""
    Dim ds As New DataSet
    Dim cp = New clsParam()


    Private Sub frmChargeCodeMaster_Load(sender As Object, e As EventArgs) Handles Me.Load

        appPath = New Uri(appPath).LocalPath
        Me.Left = 1
        Me.Top = 1
        TabControlMain.TabPages(0).Enabled = False
        TabControlMain.TabPages(1).Enabled = True
        TabControlMain.SelectedIndex = 1
        cmbSearchBy.SelectedIndex = 0
        Call initFormLoad()
        clearForm()

        ' btnAddNewRequest.Focus()
    End Sub


    Private Sub btnAddNewRequest_Click(sender As Object, e As EventArgs) Handles btnAddNewRequest.Click
    End Sub

    Private Function saveCheck() As Boolean
        Dim rtnval As Boolean = True
        lblMessage.Text = ""

        If String.IsNullOrEmpty(txtNameEN.Text) Then lblMessage.Text = "Name (EN) is Required" : txtNameEN.Focus() : rtnval = False

        If String.IsNullOrEmpty(txtNameAR.Text) Then
            If MsgBox("You are saving data without required Arabic Name, Continue and Save ?(Y/N)", vbQuestion + MsgBoxStyle.YesNo, "Verification") = MsgBoxResult.No Then
                rtnval = False
            End If
        End If

        'If Not String.IsNullOrEmpty(txtVATRegNo.Text) Then
        '    If action = "A" And ValidateFieldValue(txtVATRegNo.Text, recID) Then
        '        If MsgBox("Note.... VAT Reg No. already found for the following Organization(s)" & vbCrLf & cp.strVal1.ToString, MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Validate") = MsgBoxResult.No Then
        '            rtnval = False
        '            Return rtnval
        '        End If
        '    End If
        'End If


        'If Not Regex.Match(txtVATRegNo.Text, "^[a-zA-Z0-9]+$", RegexOptions.IgnoreCase).Success Then
        '    lblMessage.Text = "Cannot Save! Item/Part No. should be only Nubmer or Alphabets"
        '    rtnval = False
        'End If



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
        Try
            If MsgBox("Update changes made?(Y/N)", vbQuestion + vbYesNo, "") = MsgBoxResult.No Then Exit Sub
            frmWaitForm.lblTitle.Text = "Updating Data. please wait..!"
            frmWaitForm.Show()
            frmWaitForm.Refresh()
            Me.Cursor = Cursors.WaitCursor

            Dim queryStringx As String 'updating arabic text
            queryStringx = "update [chargeElements] set "
            queryStringx += " Name = N'" & Microsoft.VisualBasic.Left(txtNameEN.Text, 100) & "',"
            queryStringx += " fullNameAR = N'" & Microsoft.VisualBasic.Left(txtNameAR.Text, 200) & "',"
            queryStringx += " VATApplicable = " & Convert.ToInt32(chkVAT.Checked)

            queryStringx += "  where recid=" & recID
            Dim commandx As New SqlCommand(queryStringx, sql_CNN)
            commandx.ExecuteNonQuery()
            'commandx.Dispose()


            Me.Cursor = Cursors.Default
            frmWaitForm.Close()
            'MsgBox("Changes saved!", MsgBoxStyle.Information)
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            frmWaitForm.Close()

            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    'Private Function ValidateFieldValue(ByVal fldValue As String, fldID As Integer) As Boolean
    '    Dim rtnVal As Boolean = False
    '    Dim adapter1 As New SqlDataAdapter
    '    Dim cmdbuilder1 As SqlCommandBuilder
    '    Dim ds1 As New DataSet
    '    cp = New clsParam()
    '    Try
    '        If sql_CNN.State = ConnectionState.Closed Then createConnection()
    '        If sql_CNN.State = ConnectionState.Open Then
    '            cmdbuilder1 = New SqlCommandBuilder(adapter1) 'create command builder object to automatically generate insert,update and delete stmt
    '            With adapter1
    '                sql_String = "select id,name from [chargeElements] where VATRegNo='" & Microsoft.VisualBasic.Trim(fldValue.ToString) & "' "
    '                sql_String += " and id not in (" & fldID & ");"
    '                .SelectCommand = New SqlCommand(sql_String, sql_CNN) 'add object select command
    '                .Fill(ds1, "cdata1")
    '            End With
    '            If ds1.Tables(0).Rows.Count > 0 Then
    '                cp.strVal1 = ds1.Tables(0).Rows(0).Item("name")
    '                cp.intVal1 = ds1.Tables(0).Rows(0).Item("id")

    '                rtnVal = True
    '            End If
    '        End If
    '        Return rtnVal
    '    Catch ex As Exception
    '        Return False
    '    End Try
    '    ds1.Dispose()
    'End Function



    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim dsx As New DataSet
        lblToolTip.Text = ""
        Dim val1 As VariantType = 0
        Dim val2 As VariantType = 0
        recID = 0
        Dim myStr As String = ""
        lblToolTip.Text = ""

        Dim vfldName As String = "name"
        Select Case cmbSearchBy.SelectedIndex
            Case 0 : vfldName = "name"
                'Case 1 : vfldName = "itemdescription"
                'Case 2 : vfldName = "[group]"
        End Select

        Try

            sql_String = "select c.recid [ID], c.name [NameEN],c.fullnameAR [NameAR],case block when 0 then 'Active' else 'Blocked' end [status],  case vatapplicable  when 1 then 'Applicable' else 'NotApplicable' end [VAT], c.recid from [chargeElements] c"
            sql_String += " where c." & vfldName & " like '%" & txtShipmentNumberFind.Text & "%';"

            Me.Cursor = Cursors.WaitCursor
            RadGridView2.DataSource = Nothing
            dsx = setDataList(sql_String)
            If dsx.Tables(0).Rows.Count > 0 Then
                lblToolTip.Text = "Found: " & dsx.Tables(0).Rows.Count
                RadGridView2.DataSource = dsx.Tables(0)
                RadGridView2.MasterTemplate.BestFitColumns()
                RadGridView2.Columns(5).IsVisible = False
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
        sql_String = "select c.name, c.fullnameAR, code, case block when 0 then 'Active' else 'Blocked' end [status],createdby,createdon,vatapplicable "
        sql_String += "  from [chargeElements] c where c.recid=" & mRecID

        Try
            Me.Cursor = Cursors.WaitCursor
            ds = setDataList(sql_String)
            If ds.Tables(0).Rows.Count > 0 Then
                With ds.Tables(0).Rows(0)
                    '                    txtItemBarCode.Text = .Item("")
                    recID = mRecID
                    lblID.Text = recID
                    radSBar3.Text = "ID " & recID
                    txtNameEN.Text = .Item("name")
                    txtNameAR.Text = .Item("fullnameAR")
                    lblItemCodeName.Text = txtNameEN.Text
                    txtType.Text = .Item("code")
                    txtBranch.Text = .Item("status")
                    radSBar1.Text = "Created By/On : " & .Item("createdby") & " " & .Item("createdon")
                    chkVAT.Checked = CBool(.Item("vatapplicable"))
                    '   radSBar2.Text = "Updated By/On : " & .Item("updatedby") & " " & .Item("updatedon")
                    '    If Not IsDBNull(.Item("tmOldPartsReceivedBy")) Then txttmOldPartsReceivedBy.Text = .Item("tmOldPartsReceivedBy")
                    '    If IsDate(.Item("tmOldPartsReceivedOn")) Then txttmOldPartsReceivedOn.Text = .Item("tmOldPartsReceivedOn")
                End With

                TabControlMain.SelectedIndex = 0
                TabControlMain.TabPages(0).Enabled = True
                txtNameEN.Focus()
                action = "E"
            End If

            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)

        End Try

    End Sub




    Private Sub clearForm()
        txtNameEN.Clear()
        lblID.Text = 0
        recID = 0
        txtNameAR.Clear()
        txtBranch.Clear()
        txtVATRegNo.Clear()
        txtType.Clear()
        lblMessage.Text = ""
        lblToolTip.Text = ""
        lblMessage.Text = ""
        action = ""
    End Sub
    Private Sub initFormLoad()
        'frmWaitForm.lblTitle.Text = "Loading Master Data. please wait..!"
        'frmWaitForm.Show()
        'frmWaitForm.Refresh()
        'Me.Cursor = Cursors.WaitCursor
        'sql_String = "select Name, ID from [wsItemGroup] where block=0 and id>0 order by name"
        'Call fillCombo(cmbItemGroup, sql_String, 0, 0, 500, 0)
        'Me.Cursor = Cursors.Default
        'frmWaitForm.Close()
    End Sub

    Private Sub txtNameEN_GotFocus(sender As Object, e As EventArgs) Handles txtNameEN.GotFocus
        txtNameEN.SelectAll()
    End Sub

    Private Sub txtNameAR_TextChanged(sender As Object, e As EventArgs) Handles txtNameAR.TextChanged
        txtNameAR.SelectAll()
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

            xlWorkSheet.Cells(6, 1) = "Charge Code List"

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


    Private Sub txtNameEN_TextChanged(sender As Object, e As EventArgs) Handles txtNameEN.TextChanged
        lblItemCodeName.Text = txtNameEN.Text
    End Sub

    Private Sub RadGridView2_Click(sender As Object, e As EventArgs) Handles RadGridView2.Click

    End Sub
End Class