'Address
Imports System.Data.Sql
Imports System.Data
Imports System.Data.SqlClient
Imports Telerik.WinControls.UI
Public Class frmAddAddress

    Dim morgAddrRecID As Integer
    Dim morgRecID As Integer
    Dim morgName As String

    Dim mCountryName As String
    Dim mCityName As String
    Dim mcityCode As String
    Public Sub New(orgAddrRecID As Integer, orgRecID As Integer, orgName As String)
        morgAddrRecID = orgAddrRecID
        morgRecID = orgRecID
        morgName = orgName
        InitializeComponent()
    End Sub

    Private Sub frmAddAddress_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        txtTitle.Focus()
    End Sub

    Private Sub frmAddAddress_Load(sender As Object, e As EventArgs) Handles Me.Load
        formReturnValueINT = 0
        lblOrganziationName.Text = morgName
        Call initFormLoad()
        radCountry.Text = "SA"
        Call fillAddress()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        lblMessage.Visible = False
        If radCountry.Text = "" Then lblMessage.Text = "Choose Country from list" : lblMessage.Visible = True : Exit Sub
        If radCity.Text = "" Then lblMessage.Text = "Choose City from list" : lblMessage.Visible = True : Exit Sub
        If radLocation.Tag = 0 Then lblMessage.Text = "Choose Location from list" : lblMessage.Visible = True : Exit Sub

        Dim adapter As New SqlDataAdapter
        Dim ds As New DataSet
        Dim dr As DataRow
        Dim cmdbuilder As SqlCommandBuilder
        Try
            Me.Cursor = Cursors.WaitCursor
            cmdbuilder = New SqlCommandBuilder(adapter)
            With adapter
                sql_String = "select * from [organizationAddress] where recid=" & morgAddrRecID
                .SelectCommand = New SqlCommand(sql_String, sql_CNN)
                .Fill(ds, "cdata")
            End With

            If ds.Tables("cdata").Rows.Count = 0 Then
                dr = ds.Tables("cdata").NewRow 'addnew
                ds.Tables("cdata").Rows.Add(dr) 'add the row to dataset
                dr.Item("orgRecID") = morgRecID
            Else
                dr = ds.Tables("cdata").Rows(0)
            End If
            dr.Item("Title") = txtTitle.Text
            dr.Item("Address1") = txtAddress1.Text
            dr.Item("Telephone") = txtTelephone.Text
            dr.Item("Email") = txtEmail.Text
            dr.Item("ContactPerson1") = txtContactPerson1.Text
            dr.Item("unlocode") = mcityCode
            dr.Item("locID") = radLocation.Tag
            dr.Item("IsActive") = chkIsActive.Checked
            adapter.Update(ds, "cdata")

            formReturnValueINT = 1
            Me.Cursor = Cursors.Default
            Me.Close()
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            lblMessage.Text = "Not Saved!"
        End Try
    End Sub

    Private Sub initFormLoad()
        frmWaitForm.lblTitle.Text = "Loading Master Data. please wait..!"
        frmWaitForm.Show()
        frmWaitForm.Refresh()
        Me.Cursor = Cursors.WaitCursor
        Call refresh_country(radCountry)
        Me.Cursor = Cursors.Default
        frmWaitForm.Close()
    End Sub

    Private Sub refresh_country(cmbObj As Object)
        Me.Cursor = Cursors.WaitCursor
        sql_String = "select shortname [Code],Name,recid from [countries] where shortname in (select countrycode from unloco where IsActive=1) "
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
                Call refresh_location(radLocation)
            End If
        End If
    End Sub
    Private Sub radLocation_LostFocus(sender As Object, e As EventArgs) Handles radLocation.LostFocus
        If radLocation.SelectedValue <> "" Then
            radLocation.Tag = 0
            Dim selectedRow As GridViewDataRowInfo = DirectCast(radLocation.SelectedItem, GridViewDataRowInfo)
            radLocation.Tag = (selectedRow.Cells("recid").Value.ToString())
        End If
    End Sub

    Private Sub radCity_LostFocus(sender As Object, e As EventArgs) Handles radCity.LostFocus
        If radCity.SelectedValue <> "" Then
            radCity.Tag = 0 : mcityCode = ""
            Dim selectedRow As GridViewDataRowInfo = DirectCast(radCity.SelectedItem, GridViewDataRowInfo)
            radCity.Tag = (selectedRow.Cells("id").Value.ToString())
            mcityCode = (selectedRow.Cells("code").Value.ToString())
            lblCountryCity.Text = mCountryName & "," & (selectedRow.Cells("city").Value.ToString())
        End If
    End Sub

    Private Sub getAddressData(recordID As Integer)
        If recordID > 0 Then
            Me.Cursor = Cursors.WaitCursor
            Dim dsi As New DataSet()
            sql_String = "select o.recID [orecid], o.orgRecID, o.Title,o.Address1,o.Telephone,o.Email,o.ContactPerson1,o.isActive,o.unlocode,"
            sql_String += " isnull(lm.area,'') [Area],  ct.countryname [Country], ct.cityname [City],o.locID,ct.countrycode "
            sql_String += " from organizationAddress o left outer join LocationMaster lm on o.locID=lm.recid"
            sql_String += " left outer join (select c.name countryname, u.name [cityname], u.code,c.shortname [countrycode] from unloco u inner join countries c on u.countrycode=c.shortname) ct"
            sql_String += " on o.unlocode=ct.code"
            sql_String += " where o.recid=" & recordID

            dsi = setDataList(sql_String)
            If dsi.Tables(0).Rows.Count > 0 Then
                txtTitle.Text = dsi.Tables(0).Rows(0).Item("Title")
                txtAddress1.Text = dsi.Tables(0).Rows(0).Item("Address1")
                txtContactPerson1.Text = dsi.Tables(0).Rows(0).Item("ContactPerson1")
                txtTelephone.Text = dsi.Tables(0).Rows(0).Item("Telephone")
                txtEmail.Text = dsi.Tables(0).Rows(0).Item("Email")
                chkIsActive.Checked = dsi.Tables(0).Rows(0).Item("IsActive")
                mcityCode = dsi.Tables(0).Rows(0).Item("unlocode")
                radCity.Text = dsi.Tables(0).Rows(0).Item("City")
                radCountry.Text = dsi.Tables(0).Rows(0).Item("countrycode")
                lblCountryCity.Text = dsi.Tables(0).Rows(0).Item("country") & "," & dsi.Tables(0).Rows(0).Item("city")
                radLocation.Tag = dsi.Tables(0).Rows(0).Item("locid")
                radLocation.Text = dsi.Tables(0).Rows(0).Item("area")
            End If

        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub fillAddress()
        If morgRecID > 0 Then
            sql_String = "select o.Title,o.Address1,o.Telephone,o.Email,o.ContactPerson1,  isnull(lm.area,'') [Area],o.isActive,o.unlocode,"
            sql_String += " ct.countryname [Country], ct.cityname [City],o.locID,ct.countrycode, o.recID [orecid], o.orgRecID"
            sql_String += " from organizationAddress o left outer join LocationMaster lm on o.locID=lm.recid "
            sql_String += " left outer join (select c.name countryname, u.name [cityname], u.code,c.shortname [countrycode] "
            sql_String += " from unloco u inner join countries c on u.countrycode=c.shortname where u.id>0) ct on o.unlocode=ct.code"
            sql_String += " where o.orgRecID = " & morgRecID
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
                    '  RadGridAddress.Columns("countrycode").IsVisible = False
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
            morgAddrRecID = RadGridAddress.Rows(e.RowIndex).Cells("orecid").Value
            If morgAddrRecID > 0 Then
                Call getAddressData(morgAddrRecID)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try

    End Sub
End Class