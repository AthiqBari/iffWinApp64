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

Public Class frmOrganizationData
    Dim recID As Integer = 0
    Dim action As String = ""
    Dim ds As New DataSet
    Dim dsPrintSearch As New DataSet
    Dim cp = New clsParam()

    Dim mCountryName As String
    Dim mCityName As String
    Dim mcityCode As String
    Dim uncode As String

    Private Sub frmOrganizationData_Load(sender As Object, e As EventArgs) Handles Me.Load

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
        action = "A"
        Call clearForm()
        TabControl1.TabPages(1).Enabled = True 'multiple address
        TabControl1.TabPages(0).Enabled = True 'main address
        TabControlMain.SelectedIndex = 0
        TabControlMain.TabPages(0).Enabled = True

        clearForm()
        txtNameEN.Focus()
    End Sub

    Private Function saveCheck() As Boolean
        Dim rtnval As Boolean = True
        lblMessage.Text = ""

        If (rbClient.Checked = False And rbVendor.Checked = False) Then lblMessage.Text = "Choose Vendor or Client" : rtnval = False : GoTo a

        If String.IsNullOrEmpty(txtNameEN.Text) Then lblMessage.Text = "Name (EN) is Required" : txtNameEN.Focus() : rtnval = False : GoTo a

        If String.IsNullOrEmpty(txtNameAR.Text) Then
            If MsgBox("You are saving data without required Arabic Name, Continue and Save ?(Y/N)", vbExclamation + MsgBoxStyle.YesNo, "Verification") = MsgBoxResult.No Then
                rtnval = False
                GoTo a
            End If
        End If

        If Not String.IsNullOrEmpty(txtVATRegNo.Text) Then
            If action = "A" And ValidateFieldValue(txtVATRegNo.Text, recID) Then
                If MsgBox("Note.... VAT Reg No. already found for the following Organization(s)" & vbCrLf & cp.strVal1.ToString, MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Validate") = MsgBoxResult.No Then
                    rtnval = False
                    Return rtnval
                End If
            End If
        End If

        If String.IsNullOrEmpty(txtShortName.Text) Then lblMessage.Text = "Organization Short Name is missing" : txtShortName.Focus() : rtnval = False : GoTo a
        If String.IsNullOrEmpty(radAddress.Text) Then lblMessage.Text = "Address is mandatory" : radAddress.Focus() : rtnval = False : GoTo a
        If String.IsNullOrEmpty(radCity.Text) Then lblMessage.Text = "City is mandatory" : radCity.Focus() : rtnval = False : GoTo a
        If String.IsNullOrEmpty(radCountry.Text) Then lblMessage.Text = "Country is mandatory" : radCountry.Focus() : rtnval = False : GoTo a
        If String.IsNullOrEmpty(uncode) Then lblMessage.Text = "City is mandatory" : radCity.Focus() : rtnval = False : GoTo a
        If String.IsNullOrEmpty(radSalesRep.Text) Then lblMessage.Text = "Sales Rep is required" : radSalesRep.Focus() : rtnval = False : GoTo a
        If (radSalesRep.Tag = 0) Then lblMessage.Text = "Sales Rep is required" : radSalesRep.Focus() : rtnval = False : GoTo a


        If (rbClient.Checked And chkCNEE.CheckState = CheckState.Unchecked) Then chkCNEE.CheckState = CheckState.Checked


        rtnval = validateShortCode()
        If Not rtnval Then GoTo a
        'If Not Regex.Match(txtVATRegNo.Text, "^[a-zA-Z0-9]+$", RegexOptions.IgnoreCase).Success Then
        '    lblMessage.Text = "Cannot Save! Item/Part No. should be only Nubmer or Alphabets"
        '    rtnval = False
        'End If
        Return True
a:

        btnSave.BackColor = IIf(rtnval, Color.DodgerBlue, Color.DarkOrange)
        Return rtnval
    End Function



    Private Sub UpdateRecord()
        Try

            'If MsgBox("Update changes made?(Y/N)", vbQuestion + vbYesNo, "") = MsgBoxResult.No Then Exit Sub
            'frmWaitForm.lblTitle.Text = "Updating Data. please wait..!"
            'frmWaitForm.Show()
            'frmWaitForm.Refresh()
            Me.Cursor = Cursors.WaitCursor

            Dim queryStringx As String 'updating arabic text
            queryStringx = "update [organization] set "
            queryStringx += " VATRegNo='" & Microsoft.VisualBasic.Left(txtVATRegNo.Text, 20) & "',"
            queryStringx += " Name = '" & Replace(Microsoft.VisualBasic.Left(txtNameEN.Text, 100), "'", " ") & "',"
            queryStringx += " shortname = '" & Replace(Microsoft.VisualBasic.Left(txtShortName.Text, 8), "'", " ") & "',"
            queryStringx += " NameAR = N'" & Replace(Microsoft.VisualBasic.Left(txtNameAR.Text, 200), "'", " ") & "',"
            queryStringx += " Address1 = '" & Replace(Microsoft.VisualBasic.Left(radAddress.Text, 200), "'", " ") & "',"
            queryStringx += " Telephone = '" & Replace(Microsoft.VisualBasic.Left(radTelephone.Text, 100), "'", " ") & "',"
            queryStringx += " Email = '" & Replace(Microsoft.VisualBasic.Left(radEmail.Text, 100), "'", " ") & "',"
            queryStringx += " ContactPerson1 = '" & Replace(Microsoft.VisualBasic.Left(radContactPerson.Text, 100), "'", " ") & "',"
            queryStringx += " unlocode='" & uncode & "',"
            queryStringx += "isreceivableaccount=" & IIf(rbClient.Checked, 1, 0) & ","
            queryStringx += "ispayableaccount=" & IIf(rbVendor.Checked, 1, 0) & ","
            queryStringx += "salesrecID=" & radSalesRep.Tag & ","
            queryStringx += "isbroker=" & IIf(chkbroker.Checked, 1, 0) & ","
            queryStringx += "istransporter=" & IIf(chkTransporter.Checked, 1, 0) & ","
            queryStringx += "IsConsignee=" & IIf(chkCNEE.Checked, 1, 0) & ","
            queryStringx += "IsShipper=" & IIf(chkShipper.Checked, 1, 0) & ","
            queryStringx += "block=" & IIf(chkIsActive.Checked, 0, 1) & ","
            queryStringx += "updatedby='" & appUserInfo.Name & "'"
            queryStringx += "  where recid=" & recID
            Dim commandx As New SqlCommand(queryStringx, sql_CNN)
            commandx.ExecuteNonQuery()
            'commandx.Dispose()


            Me.Cursor = Cursors.Default
            lblMessage.Text = "Successfully Saved!"
            'frmWaitForm.Close()
            'MsgBox("Changes saved!", MsgBoxStyle.Information)
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Function ValidateFieldValue(ByVal fldValue As String, fldID As Integer) As Boolean
        Dim rtnVal As Boolean = False
        Dim adapter1 As New SqlDataAdapter
        Dim cmdbuilder1 As SqlCommandBuilder
        Dim ds1 As New DataSet
        cp = New clsParam()
        Try
            If sql_CNN.State = ConnectionState.Closed Then createConnection()
            If sql_CNN.State = ConnectionState.Open Then
                cmdbuilder1 = New SqlCommandBuilder(adapter1) 'create command builder object to automatically generate insert,update and delete stmt
                With adapter1
                    sql_String = "select id,name from [organization] where VATRegNo='" & Microsoft.VisualBasic.Trim(fldValue.ToString) & "' "
                    sql_String += " and id not in (" & fldID & ");"
                    .SelectCommand = New SqlCommand(sql_String, sql_CNN) 'add object select command
                    .Fill(ds1, "cdata1")
                End With
                If ds1.Tables(0).Rows.Count > 0 Then
                    cp.strVal1 = ds1.Tables(0).Rows(0).Item("name")
                    cp.intVal1 = ds1.Tables(0).Rows(0).Item("id")

                    rtnVal = True
                End If
            End If
            Return rtnVal
        Catch ex As Exception
            Return False
        End Try
        ds1.Dispose()
    End Function

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim dsx As New DataSet
        dsPrintSearch = Nothing
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
            sql_String = "select org.recid [ID],org.name [NameEN],nameAR [NameAR], shortname [Code],vatregno [VAT], isTransporter,isBroker,IsConsignee,IsShipper,"
            sql_String += " case  isreceivableaccount when 1 then 'Yes' else 'No' end [Receivable], "
            sql_String += " case  ispayableaccount when 1 then 'Yes' else 'No' end [Payable], branch.name [Branch],org.address1 [address],org.Telephone,org.Email,org.Contactperson1 [ContactPerson], createdby,createdon,updatedby,updatedon, org.recid,org.branchid"
            sql_String += " from [organization] org inner join branch on org.branchid=branch.recid"
            sql_String += " where org.branchid=" & appCompanyInfo.branchID
            If chkARAP.CheckState = CheckState.Checked Then sql_String += " and (IsReceivableAccount=1 or IsPayableAccount=1) "
            sql_String += " and org." & vfldName & " like '%" & txtShipmentNumberFind.Text & "%';"

            Me.Cursor = Cursors.WaitCursor
            RadGridView2.DataSource = Nothing
            dsx = setDataList(sql_String)
            If dsx.Tables(0).Rows.Count > 0 Then
                lblToolTip.Text = "Found: " & dsx.Tables(0).Rows.Count
                RadGridView2.DataSource = dsx.Tables(0)
                RadGridView2.MasterTemplate.BestFitColumns()
                RadGridView2.Columns(15).IsVisible = False
                RadGridView2.Columns(16).IsVisible = False
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
        sql_String = "select org.name,org.namear,org.shortname,org.vatregno,org.isreceivableaccount,org.ispayableaccount,istransporter,isbroker, br.name [branch],"
        sql_String += "org.address1, u.code [UnLoco], u.name [City], org.telephone, org.contactperson1, org.IsConsignee, org.IsShipper, "
        sql_String += " s.name sname, org.email,org.createdby, org.createdon, org.updatedby, org.updatedon, s.recid srecid, org.block"
        sql_String += "  from [organization] org inner join branch br on org.branchid=br.recid "
        sql_String += " inner join [salesman] s on org.salesrecid=s.recid"
        sql_String += " inner join [unloco] u on org.unlocode=u.code"
        sql_String += " where u.id>0 and org.recid = " & mRecID

        Try
            Me.Cursor = Cursors.WaitCursor
            ds = setDataList(sql_String)
            If ds.Tables(0).Rows.Count > 0 Then
                With ds.Tables(0).Rows(0)
                    '                    txtItemBarCode.Text = .Item("")
                    recID = mRecID
                    lblID.Text = recID
                    radSBar3.Text = "ID " & recID
                    txtNameEN.Text = Trim(.Item("name"))
                    txtNameAR.Text = .Item("nameAR")
                    lblItemCodeName.Text = txtNameEN.Text
                    txtShortName.Text = Trim(.Item("shortname"))
                    txtVATRegNo.Text = Trim(.Item("vatregno"))
                    If .Item("isreceivableaccount") = 1 And .Item("ispayableaccount") = 1 Then txtType.Text = "Receivable/Payable"
                    If .Item("isreceivableaccount") = 1 And .Item("ispayableaccount") = 0 Then txtType.Text = "Receivable"
                    If .Item("isreceivableaccount") = 0 And .Item("ispayableaccount") = 1 Then txtType.Text = "Payable"
                    If .Item("isreceivableaccount") = 0 And .Item("ispayableaccount") = 0 Then txtType.Text = "Non ARAP"
                    txtBranch.Text = .Item("branch")
                    radSBar1.Text = "Created By/On : " & .Item("createdby") & " " & .Item("createdon")
                    radSBar2.Text = "Updated By/On : " & .Item("updatedby") & " " & .Item("updatedon")
                    If Not IsDBNull(.Item("address1")) Then radAddress.Text = .Item("address1")
                    If Not IsDBNull(.Item("telephone")) Then radTelephone.Text = .Item("telephone")
                    If Not IsDBNull(.Item("email")) Then radEmail.Text = .Item("email")
                    If Not IsDBNull(.Item("contactperson1")) Then radContactPerson.Text = .Item("contactperson1")
                    '    If IsDate(.Item("tmOldPartsReceivedOn")) Then txttmOldPartsReceivedOn.Text = .Item("tmOldPartsReceivedOn")
                    If .Item("isreceivableaccount") = 1 Then rbClient.Checked = True
                    If .Item("ispayableaccount") = 1 Then rbVendor.Checked = True

                    radSalesRep.Tag = .Item("srecid")
                    radSalesRep.Text = .Item("sname")


                    If .Item("IsBroker") = 1 Then chkbroker.Checked = True
                    If .Item("IsTransporter") = 1 Then chkTransporter.Checked = True
                    If .Item("IsConsignee") = 1 Then chkCNEE.Checked = True
                    If .Item("IsShipper") = 1 Then chkShipper.Checked = True


                    radCountry.Text = Microsoft.VisualBasic.Left(.Item("unloco"), 2)

                    mCityName = .Item("city")
                    uncode = .Item("unloco")
                    radCity.Text = mCityName
                    mcityCode = uncode

                    If .Item("block") = 1 Then chkIsActive.Checked = False
                    If .Item("block") = 0 Then chkIsActive.Checked = True


                End With

                TabControlMain.TabPages(1).Enabled = True 'location
                TabControlMain.TabPages(0).Enabled = True
                TabControlMain.SelectedIndex = 0
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
        txtShortName.Clear()
        recID = 0
        txtNameAR.Clear()
        txtBranch.Clear()
        txtVATRegNo.Clear()
        txtType.Clear()
        lblMessage.Text = ""
        lblToolTip.Text = ""
        lblMessage.Text = ""
        action = ""
        rbClient.Checked = False
        rbVendor.Checked = False
        ' radSalesRep.Tag = 0
        radAddress.Clear()
        radCity.Tag = 0
        mcityCode = 0
        radCountry.Tag = 0
        mCountryName = ""
        uncode = ""
        Label15.ForeColor = Color.Black
        chkIsActive.Checked = True
        chkbroker.Checked = False
        chkTransporter.Checked = False
        chkCNEE.CheckState = False
        chkShipper.CheckState = False


    End Sub

    Private Sub initFormLoad()

        frmWaitForm.lblTitle.Text = "Loading Master Data. please wait..!"
        frmWaitForm.Show()
        frmWaitForm.Refresh()
        Me.Cursor = Cursors.WaitCursor
        Call refresh_country(radCountry)
        Call refresh_salesrep(radSalesRep)
        Me.Cursor = Cursors.Default
        frmWaitForm.Close()
        radAddress.Multiline = True

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

    Private Sub txtNameAR_GotFocus(sender As Object, e As EventArgs) Handles txtNameAR.GotFocus
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

            Dim destinationFile As String = copyTemplate("iffReportTemplate.xls", "OrganizationList")
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

            xlWorkSheet.Cells(6, 1) = "Organization List"

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



    Private Sub radAddress_GotFocus(sender As Object, e As EventArgs)
        radAddress.SelectAll()
    End Sub

    Private Sub radTelephone_GotFocus(sender As Object, e As EventArgs) Handles radTelephone.GotFocus
        radTelephone.SelectAll()
    End Sub

    Private Sub radEmail_GotFocus(sender As Object, e As EventArgs) Handles radEmail.GotFocus
        radEmail.SelectAll()
    End Sub

    Private Sub radContactPerson_GotFocus(sender As Object, e As EventArgs) Handles radContactPerson.GotFocus
        radContactPerson.SelectAll()
    End Sub

    Private Sub refresh_country(cmbObj As Object)
        Me.Cursor = Cursors.WaitCursor
        sql_String = "select shortname [Code],Name,recid from [countries] where shortname in (select countrycode from unloco where IsActive=1) "
        Call fillCombo(cmbObj, sql_String, 0, 0, (cmbObj.Width - 100), 50)
        cmbObj.Columns(2).IsVisible = False
        cmbObj.Tag = 0 : cmbObj.Text = ""
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub refresh_salesrep(cmbObj As Object)
        Me.Cursor = Cursors.WaitCursor
        sql_String = "select Name, Code,recid as id from [salesman] where branchid=" & appUserInfo.BranchId
        Call fillCombo(cmbObj, sql_String, 0, 0, (cmbObj.Width - 100), 50)
        cmbObj.Columns(2).IsVisible = False
        cmbObj.Tag = 0 : cmbObj.Text = ""
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub refresh_cities(cmbObj As Object)
        Me.Cursor = Cursors.WaitCursor
        sql_String = "select Name [City], code [Code],id from [unloco] where countrycode='" & radCountry.Text & "';"
        Call fillCombo(cmbObj, sql_String, 0, 0, (cmbObj.Width - 100), 200)
        cmbObj.Columns(2).IsVisible = False
        cmbObj.Tag = 0 : cmbObj.Text = ""
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub refresh_location(cmbObj As Object)
        Me.Cursor = Cursors.WaitCursor
        cmbObj.tag = 0
        sql_String = "select Area,unloco [Code],recid from [LocationMaster] where isactive=1 and left(unloco,2)='" & Microsoft.VisualBasic.Left(radCountry.Text, 2) & "';"
        Call fillCombo(cmbObj, sql_String, 0, 0, (cmbObj.Width - 100), 200)
        'cmbObj.Columns("recid").IsVisible = False
        cmbObj.Tag = 0 : cmbObj.Text = ""
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub radCountry_LostFocus(sender As Object, e As EventArgs) Handles radCountry.LostFocus
        If radCountry.SelectedValue <> "" Then
            radCountry.Tag = 0
            mCountryName = ""
            Dim selectedRow As GridViewDataRowInfo = DirectCast(radCountry.SelectedItem, GridViewDataRowInfo)
            radCountry.Tag = (selectedRow.Cells("recid").Value.ToString())
            mCountryName = (selectedRow.Cells("name").Value.ToString())
            If radCountry.Tag > 0 Then
                Call refresh_cities(radCity)
            End If
        End If
    End Sub
    Private Sub radCity_LostFocus(sender As Object, e As EventArgs) Handles radCity.LostFocus
        If radCity.SelectedValue <> "" Then
            radCity.Tag = 0 : mcityCode = ""
            Dim selectedRow As GridViewDataRowInfo = DirectCast(radCity.SelectedItem, GridViewDataRowInfo)
            radCity.Tag = (selectedRow.Cells("id").Value.ToString())
            mcityCode = (selectedRow.Cells("code").Value.ToString())
            uncode = mcityCode
            lblCountryCity.Text = mCountryName & "," & (selectedRow.Cells("city").Value.ToString())
        End If
    End Sub

    Private Sub radSales_LostFocus(sender As Object, e As EventArgs) Handles radSalesRep.LostFocus
        If radSalesRep.SelectedValue <> "" Then
            radSalesRep.Tag = 0 : mcityCode = ""
            Dim selectedRow As GridViewDataRowInfo = DirectCast(radSalesRep.SelectedItem, GridViewDataRowInfo)
            radSalesRep.Tag = (selectedRow.Cells("id").Value.ToString())
        End If
    End Sub


    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Not saveCheck() Then Exit Sub
        lblMessage.Text = ""
        Dim rtnval As Boolean = False

        If recID > 0 Then
            Call UpdateRecord()
            TabControlMain.TabPages(0).Enabled = False
        Else
            rtnval = InsertRecord()
            If Not rtnval Then
                MsgBox("Not Saved!", MsgBoxStyle.Critical, Me.Text)
            Else
                TabControlMain.TabPages(0).Enabled = False
            End If
        End If
        '  lblMessage.Text = "Save Complete!"

        'If action = "A" Then
        'ElseIf action = "E" Then
        '    Call UpdateRecord()
        '    lblMessage.Text = "Save Complete!"
        'End If

        'lock screen

    End Sub


    Private Function InsertRecord() As Boolean
        Dim rtnv As Boolean = True
        Dim adapter As New SqlDataAdapter
        Dim ds As New DataSet
        Dim dr As DataRow
        Dim cd As Integer = 0
        Dim cmdbuilder As SqlCommandBuilder
        Try
            Me.Cursor = Cursors.WaitCursor
            cmdbuilder = New SqlCommandBuilder(adapter)
            With adapter
                sql_String = "select * from [organization] where recid=" & recID
                .SelectCommand = New SqlCommand(sql_String, sql_CNN)
                .Fill(ds)
            End With

            If ds.Tables(0).Rows.Count = 0 Then
                cd = GenBatchNo()
                dr = ds.Tables(0).NewRow 'addnew
                ds.Tables(0).Rows.Add(dr) 'add the row to dataset
                dr.Item("code") = cd
                dr.Item("branchid") = appCompanyInfo.branchID
                dr.Item("createdby") = appUserInfo.Name
            Else
                dr = ds.Tables(0).Rows(0) 'get record pointer
            End If
            dr.Item("name") = Microsoft.VisualBasic.Left(txtNameEN.Text, 100)
            dr.Item("shortname") = Trim(Microsoft.VisualBasic.Left(txtShortName.Text, 10))
            dr.Item("VATRegNo") = Microsoft.VisualBasic.Left(txtVATRegNo.Text, 20)
            dr.Item("Address1") = Microsoft.VisualBasic.Left(radAddress.Text, 200)
            dr.Item("Telephone") = Microsoft.VisualBasic.Left(radTelephone.Text, 100)
            dr.Item("Email") = Microsoft.VisualBasic.Left(radEmail.Text, 100)
            dr.Item("ContactPerson1") = Microsoft.VisualBasic.Left(radContactPerson.Text, 20)
            dr.Item("unlocode") = uncode
            dr.Item("ispayableaccount") = 0
            dr.Item("IsConsignee") = 0
            dr.Item("isShipper") = 0

            If rbClient.Checked Then dr.Item("isreceivableaccount") = 1

            If rbVendor.Checked Then
                dr.Item("ispayableaccount") = 1
                dr.Item("isTransporter") = 1
            End If

            dr.Item("salesrecID") = radSalesRep.Tag
            If chkIsActive.Checked Then dr.Item("block") = 0
            If Not chkIsActive.Checked Then dr.Item("block") = 1
            dr.Item("istransporter") = 0
            dr.Item("isbroker") = 0

            If chkbroker.Checked Then dr.Item("isbroker") = 1
            If chkTransporter.Checked Then dr.Item("istransporter") = 1
            If chkCNEE.Checked Then dr.Item("IsConsignee") = 1
            If chkShipper.Checked Then dr.Item("IsShipper") = 1

            adapter.Update(ds)
            '            Call UpdateRecord()
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            lblMessage.Text = ex.Message ' "Not Saved!"
            rtnv = False
        End Try
        Return rtnv
    End Function
    Private Function GenBatchNo() As Integer
        Dim ds As New DataSet
        Dim cd As Integer = 0
        Try
            sql_String = "select isnull(max(code)+1,1) [cd] from dbo.organization;" ' where branchID=" & appCompanyInfo.branchID & ";"
            Me.Cursor = Cursors.WaitCursor
            ds = setDataList(sql_String)
            If ds.Tables(0).Rows.Count > 0 Then cd = ds.Tables("cdata").Rows(0).Item("cd")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try
        Me.Cursor = Cursors.Default
        Return cd
    End Function
    Private Sub btnAddAddr1_Click(sender As Object, e As EventArgs) Handles btnAddAddr1.Click
        Dim frm As New frmAddAddress(0, recID, txtNameEN.Text)
        frm.ShowDialog(Me)
        If formReturnValueINT > 0 Then
            Call fillAddress()
        End If
    End Sub
    Private Sub fillAddress()
        If recID > 0 Then
            sql_String = "select o.Title,o.Address1,o.Telephone,o.Email,o.ContactPerson1,  isnull(lm.area,'') [Area],o.isActive,o.unlocode,"
            sql_String += " ct.countryname [Country], ct.cityname [City],o.locID,ct.countrycode, o.recID [orecid], o.orgRecID"
            sql_String += " from organizationAddress o left outer join LocationMaster lm on o.locID=lm.recid "
            sql_String += " left outer join (select c.name countryname, u.name [cityname], u.code,c.shortname [countrycode] from unloco u inner join countries c on u.countrycode=c.shortname where u.id>0) ct on o.unlocode=ct.code"
            sql_String += " where o.orgRecID = " & recID
            sql_String += " order by o.recid desc;"

            Dim dsx As New DataSet
            Try
                Me.Cursor = Cursors.WaitCursor
                RadGridAddress.DataSource = Nothing
                dsx = setDataList(sql_String)
                If dsx.Tables(0).Rows.Count > 0 Then
                    RadGridAddress.DataSource = dsx.Tables(0)
                    RadGridAddress.Columns("orecid").IsVisible = False
                    RadGridAddress.Columns("orgRecID").IsVisible = False
                    RadGridAddress.Columns("locID").IsVisible = False
                    '                    RadGridAddress.Columns("countrycode").IsVisible = False
                    RadGridAddress.MasterTemplate.BestFitColumns()
                End If
            Catch ex As Exception
                lblMessage.Text = ex.Message
            End Try
            Me.Cursor = Cursors.Default
        End If
    End Sub
    Private Sub RadGridAddress_CellDoubleClick(sender As Object, e As GridViewCellEventArgs) Handles RadGridAddress.CellDoubleClick
        Try
            Dim morgAddrRecID As Integer = RadGridAddress.Rows(e.RowIndex).Cells("orecid").Value
            If morgAddrRecID > 0 Then
                Dim frm As New frmAddAddress(morgAddrRecID, recID, txtNameEN.Text)
                frm.ShowDialog(Me)
                If formReturnValueINT > 0 Then
                    Call fillAddress()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub TabControl1_Click(sender As Object, e As EventArgs) Handles TabControl1.Click
        If TabControl1.SelectedIndex = 1 Then 'addresslist
            If recID > 0 Then Call fillAddress()
        End If
    End Sub
    Private Sub txtNameEN_TextChanged(sender As Object, e As EventArgs) Handles txtNameEN.TextChanged
        lblItemCodeName.Text = txtNameEN.Text
    End Sub
    Private Sub txtNameEN_LostFocus(sender As Object, e As EventArgs) Handles txtNameEN.LostFocus
        'generate code on given name
        If String.IsNullOrEmpty(txtShortName.Text) Then txtShortName.Text = UCase(Replace(Microsoft.VisualBasic.Left(txtNameEN.Text, 8), " ", ""))
    End Sub


    Private Function validateShortCode() As Boolean
        Dim ds As New DataSet
        Dim rtnval As Boolean = True
        lblMessage.Text = "" : Label15.ForeColor = Color.Black
        Try
            frmWaitForm.lblTitle.Text = "Validating Short Name. please wait..!"
            frmWaitForm.Show()
            frmWaitForm.Refresh()
            sql_String = "select recid from dbo.organization where branchID=" & appCompanyInfo.branchID
            sql_String += " and shortname='" & Trim(txtShortName.Text) & "' and recID <> " & recID
            Me.Cursor = Cursors.WaitCursor
            ds = setDataList(sql_String)
            If ds.Tables(0).Rows.Count > 0 Then
                lblMessage.Text = "Cannot Save. Short Name already taken"
                rtnval = False
                Label15.ForeColor = Color.OrangeRed
                txtShortName.SelectAll()
                txtShortName.Focus()
            End If
        Catch ex As Exception
            lblMessage.Text = ex.Message
        End Try
        frmWaitForm.Close()
        Me.Cursor = Cursors.Default
        Return rtnval
    End Function
    Private Sub btnSearchByDriverID_Click(sender As Object, e As EventArgs) Handles btnSearchByDriverID.Click
        Call validateShortCode()
    End Sub
    Private Sub txtShortName_GotFocus(sender As Object, e As EventArgs) Handles txtShortName.GotFocus
        txtShortName.SelectAll()
    End Sub
    Private Sub radAddress_GotFocus1(sender As Object, e As EventArgs) Handles radAddress.GotFocus
        radAddress.SelectAll()
    End Sub

    Private Sub rbClient_CheckedChanged(sender As Object, e As EventArgs) Handles rbClient.CheckedChanged

    End Sub
End Class