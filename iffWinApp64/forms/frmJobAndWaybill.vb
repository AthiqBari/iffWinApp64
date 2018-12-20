'02-JUN-2018
'Land Transport Form for TransArab and JEDEX

Imports Telerik.WinControls.UI
Imports System.Data.Sql
Imports System.Data
Imports System.Data.SqlClient
Imports System.Exception
Imports System.Data.OleDb
Imports System.IO
Imports Excel = Microsoft.Office.Interop.Excel

Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frmJobAndWaybill
    Dim lovcalendar As New CTradeListOfValues.clsCTCalendar
    Dim recID As Integer = 0
    Dim action As String = ""
    Dim ds As New DataSet
    Dim appPath As String = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase)
    Dim dsPrintSearch As New DataSet
    Dim ActNoINT As Integer = 0
    Dim ActNoStr As String = ""
    Dim keychange As Boolean = False

    Dim strpolcountry As String = "SA"
    Dim strpodcountry As String = "SA"

    Dim locid1 As Integer = 0
    Dim locid2 As Integer = 0

    Dim strpolcountryname As String = ""
    Dim strpodcountryname As String = ""
    Dim orgInvRecID As Integer = 0
    Dim firstDay = New DateTime(Today.Year, Today.Month, 1)

    Dim POLOrgAddrRecID As Integer
    Dim PODOrgAddrRecID As Integer
    Dim BatchNoint As Integer = 0

    Dim unloco1 As String = ""
    Dim unloco2 As String = ""

    Private Sub frmJobAndWaybill_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        appPath = New Uri(appPath).LocalPath
        Me.Left = 1
        Me.Top = 1

        TabControlMain.TabPages(0).Enabled = True 'listview
        '        TabControlMain.TabPages(1).Enabled = False 'formview
        '       TabControlMain.TabPages(2).Enabled = False 'waybills
        TabControlMain.SelectedIndex = 0    'listview

        cmbTransportMode.SelectedIndex = 0
        cmbServiceProductID.SelectedIndex = 0


        Call initFormLoad()
        clearForm(False)
        btnAddNewRequest.Focus()
        cmbSearchBy.SelectedIndex = 0



        If Not appUserInfo.isAdmin Then panelBillingTabMain.Visible = appUserRights.landBillingTabAccess

    End Sub

    Private Sub clearForm(onlyPOLot As Boolean)
        cmbTransportMode.SelectedIndex = 0
        cmbServiceProductID.SelectedIndex = 0
        txtActNo.Clear()
        txtActNo.Tag = 0
        txtactStat.Text = "NEW"
        txtactStat.Tag = 0
        txtActCommodity.Clear()
        txtActDescription.Clear()
        strpolcountryname = ""
        strpodcountryname = ""
        cmbPOLCountryCode.Text = strpolcountry : cmbPOLCountryCode.Tag = 185
        CmbPODCountryCode.Text = strpodcountry : CmbPODCountryCode.Tag = 185


        radSBar1.Text = "Created By:" & appUserInfo.Name
        radSBarCreatedOn.Text = "Created On:" & Today.Date
        radSBar2.Text = "Updated By "
        radSBar3.Text = ""
        txtClientRef.Clear()
        txtPlaceOfReceipt.Clear()
        txtPodDesc.Clear()
        cmbPOLCity.Text = "" : cmbPOLCity.Tag = 0
        cmbPODCity.Text = "" : cmbPODCity.Tag = 0
        txtETA.SetToNullValue()
        txtETD.SetToNullValue()
        cmbShipperList.Text = "" : cmbShipperList.Tag = 0
        cmbConsignee.Text = "" : cmbConsignee.Tag = 0
        cmbTransporter.Text = "" : cmbTransporter.Tag = 0
        cmbLocalClient.Text = "" : cmbLocalClient.Tag = 0
        cmbEquipmentType.Text = "" : cmbEquipmentType.Tag = 0

        txtTotalTrips.Clear()
        cmbPackingType.Text = "" : cmbPackingType.Tag = 0
        txtGrossWght.Clear()
        txtNetWgt.Clear()
        txtNoOfPcs.Clear()
        txtVolWgt.Clear()
        lblMessage.Text = ""

        txtVesselName.Clear()
        txtVoyage.Clear()
        txtBLAWB.Clear()
        locid1 = 0
        locid2 = 0
        radGridTransportOrders.DataSource = Nothing
        unloco1 = ""
        unloco2 = ""


    End Sub



    'Private Sub refresh_cities(iCountrycode As Integer, cmbName As Object)
    '    If iCountrycode < 0 Then lblMessage.Text = "Invalid Country Code" : Exit Sub
    '    Me.Cursor = Cursors.WaitCursor
    '    sql_String = "select name,recid,countryid from [cities] where recid>0 and countryid=" & iCountrycode & " order by name;"
    '    Call fillCombo(cmbName, sql_String, 0, 300, 200, 0)
    '    cmbName.Columns(1).VisibleInColumnChooser = False
    '    cmbName.Columns(2).VisibleInColumnChooser = False
    '    cmbName.Tag = 0 : cmbName.Text = ""
    '    Me.Cursor = Cursors.Default
    '    keychange = False
    'End Sub

    Private Sub refresh_organization(cmbObj As Object, orgFldName As String)
        Me.Cursor = Cursors.WaitCursor
        sql_String = "select Name,address1 [Address],recid from [organization] where block=0 and " & orgFldName & " and branchID=" & appCompanyInfo.branchID
        sql_String += " order by name"
        Call fillCombo(cmbObj, sql_String, 0, 300, 100, 100)
        cmbObj.Columns(2).VisibleInColumnChooser = False

        cmbObj.Tag = 0 : cmbObj.Text = ""
        Me.Cursor = Cursors.Default
    End Sub


    Private Sub refresh_EquipmentList(cmbObj As Object, orgFldName As String)
        Me.Cursor = Cursors.WaitCursor
        sql_String = "select Name,etype [Type],recid from [EquipmentGroup] where IsActive=1"
        Call fillCombo(cmbObj, sql_String, 200, 300, 100, 0)
        cmbObj.Columns("recid").VisibleInColumnChooser = False
        cmbObj.Tag = 0 : cmbObj.Text = ""
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub loadOrgPOLPOD(cmbObj As Object, orgFldName As String)
        Me.Cursor = Cursors.WaitCursor
        sql_String = " select  o.name [Organization],o.recID from organization o "
        sql_String += " where o.recID in (select v.shprRecID from jobFileSearch_viewY2013 v where actRecID=" & txtJobNumberSearchWB.Tag & ")"
        sql_String += " union "
        sql_String += " select o.name [Organization],o.recID from organization o "
        sql_String += " where o.recID in (select v.cnerecid from jobFileSearch_viewY2013 v where actRecID=" & txtJobNumberSearchWB.Tag & ")"
        sql_String += " union "
        sql_String += " select o.name [Organization],o.recID from organization o "
        sql_String += " where o.recID in (select v.cltRecID from jobFileSearch_viewY2013 v where actRecID=" & txtJobNumberSearchWB.Tag & ")"
        sql_String += " union "
        sql_String += " select o.name [Organization],o.recID from organization o where o.IsCFSCYD=1"
        Call fillCombo(cmbObj, sql_String, 200, 300, 200, 0)

        cmbObj.Tag = 0 : cmbObj.Text = ""
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub initFormLoad()
        frmWaitForm.lblTitle.Text = "Loading Master Data. please wait..!"
        frmWaitForm.Show()
        frmWaitForm.Refresh()
        Me.Cursor = Cursors.WaitCursor

        sql_String = "select codename,recid from [packingtype] where block=0 and transport='ROA' order by codename;"
        Call fillCombo(cmbPackingType, sql_String, 0, 0, 500, 0)
        cmbPackingType.Columns(1).VisibleInColumnChooser = False
        cmbPackingType.Tag = 0 : cmbPackingType.Text = ""

        Call refresh_country()
        cmbPOLCountryCode.Text = strpolcountry : cmbPOLCountryCode.Tag = 185
        Call refresh_cities(cmbPOLCountryCode.Text, cmbPOLCity)
        CmbPODCountryCode.Text = strpodcountry : CmbPODCountryCode.Tag = 185
        Call refresh_cities(CmbPODCountryCode.Tag, cmbPODCity)

        Call refresh_organization(cmbShipperList, "IsShipper=1")
        Call refresh_organization(cmbConsignee, "IsConsignee=1")
        Call refresh_organization(cmbTransporter, "IsTransporter=1")
        Call refresh_organization(cmbLocalClient, "IsConsignee=1 or IsShipper=1")

        Call refresh_EquipmentList(cmbEquipmentType, "")
        Me.Cursor = Cursors.Default
        frmWaitForm.Close()
    End Sub

    Private Sub hideRefreshButtons()
        btnShipperRefresh.Visible = False
        btnConsigneeRefresh.Visible = False
        btnTransporterRefresh.Visible = False
    End Sub
    Private Sub cmbShipperList_GotFocus(sender As Object, e As EventArgs) Handles cmbShipperList.GotFocus
        hideRefreshButtons()
        btnShipperRefresh.Visible = True
    End Sub
    Private Sub cmbConsignee_GotFocus(sender As Object, e As EventArgs) Handles cmbConsignee.GotFocus
        hideRefreshButtons()
        btnConsigneeRefresh.Visible = True
    End Sub
    Private Sub cmbLocalClient_GotFocus(sender As Object, e As EventArgs) Handles cmbLocalClient.GotFocus
        hideRefreshButtons()
        btnClientRefresh.Visible = True
    End Sub
    Private Sub cmbTransporter_GotFocus(sender As Object, e As EventArgs) Handles cmbTransporter.GotFocus
        hideRefreshButtons()
        btnTransporterRefresh.Visible = True
    End Sub
    Private Sub btnShipperRefresh_Click(sender As Object, e As EventArgs) Handles btnShipperRefresh.Click
        If action = "" Then Exit Sub
        Call refresh_organization(cmbShipperList, "IsShipper=1")
    End Sub
    Private Sub btnTransporterRefresh_Click(sender As Object, e As EventArgs) Handles btnTransporterRefresh.Click
        If action = "" Then Exit Sub
        Call refresh_organization(cmbTransporter, "IsTransporter=1")
    End Sub
    Private Sub btnClientRefresh_Click(sender As Object, e As EventArgs) Handles btnClientRefresh.Click
        If action = "" Then Exit Sub
        Call refresh_organization(cmbLocalClient, "IsConsignee=1 or IsShipper=1")
    End Sub
    Private Sub btnConsigneeRefresh_Click(sender As Object, e As EventArgs) Handles btnConsigneeRefresh.Click
        If action = "" Then Exit Sub
        Call refresh_organization(cmbConsignee, "IsConsignee=1")
    End Sub

    Private Sub cmbShipperList_LostFocus(sender As Object, e As EventArgs) Handles cmbShipperList.LostFocus
        If cmbShipperList.SelectedValue <> "" Then
            cmbShipperList.Tag = 0
            Dim selectedRow As GridViewDataRowInfo = DirectCast(cmbShipperList.SelectedItem, GridViewDataRowInfo)
            cmbShipperList.Tag = (selectedRow.Cells("recid").Value.ToString())
        End If

    End Sub

    Private Sub btnAddShipment_Click(sender As Object, e As EventArgs) Handles btnAddShipment.Click
        'If loggedRepairFinance Then
        '    MsgBox("You are not authorized to create a new request record", MsgBoxStyle.Exclamation, Me.Text)
        '    Exit Sub
        'End If
        action = "A"
        recID = 0
        Call clearForm(0)
        TabControlMain.SelectedIndex = 1 'shipment form
        '        TabControlMain.TabPages(0).Enabled = True
        radBox1.Enabled = True
        radBox2.Enabled = True
        radBox3.Enabled = True

        btnSave.Enabled = True
        btnSave.ForeColor = Color.DodgerBlue

        Call generateJobNumber()
        EnableShipmentInput(True)
        txtActDescription.Focus()
        'btnAddShipment.Enabled = False
        btnAddShipment.Visible = False
        btnCancelButton.Visible = True
        btnEditThisJob.Visible = False
        lblMessage.Text = ""
    End Sub

    Private Sub EnableShipmentInput(bVal As Boolean)
        radBox1.Enabled = bVal
        radBox2.Enabled = bVal
        radBox3.Enabled = bVal
    End Sub

    Private Sub generateJobNumber()
        Dim ds As New DataSet
        Dim rtnval As Integer = 0
        Dim jobnostr As String = ""
        Try
            txtActNo.Clear()
            txtActNo.Tag = 0
            sql_String = "select (slno)+1 [id] from [parameter] where name='JOBFILE' and branchid=" & appCompanyInfo.branchID & ";"
            Me.Cursor = Cursors.WaitCursor
            ds = setDataList(sql_String)
            If ds.Tables(0).Rows.Count > 0 Then
                rtnval = ds.Tables("cdata").Rows(0).Item("id")
                jobnostr = "LT" & appCompanyInfo.branchDocPrefix & CStr(Format(rtnval, "000000"))
                txtActNo.Text = jobnostr
                txtActNo.Tag = ds.Tables("cdata").Rows(0).Item("id")
                ActNoINT = txtActNo.Tag
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cmbConsignee_LostFocus(sender As Object, e As EventArgs) Handles cmbConsignee.LostFocus
        If cmbConsignee.SelectedValue <> "" Then
            cmbConsignee.Tag = 0
            Dim selectedRow As GridViewDataRowInfo = DirectCast(cmbConsignee.SelectedItem, GridViewDataRowInfo)
            cmbConsignee.Tag = (selectedRow.Cells("recid").Value.ToString())
            If cmbLocalClient.Text = "" Then cmbLocalClient.Text = cmbConsignee.Text : cmbLocalClient.Tag = cmbConsignee.Tag
        End If
    End Sub
    Private Sub cmbLocalClient_LostFocus(sender As Object, e As EventArgs) Handles cmbLocalClient.LostFocus
        If cmbLocalClient.SelectedValue <> "" Then
            cmbLocalClient.Tag = 0
            Dim selectedRow As GridViewDataRowInfo = DirectCast(cmbLocalClient.SelectedItem, GridViewDataRowInfo)
            cmbLocalClient.Tag = (selectedRow.Cells("recid").Value.ToString())
        End If
        lblFormTitle.Text = txtActNo.Text & IIf(String.IsNullOrEmpty(cmbLocalClient.Text), "", " - " & cmbLocalClient.Text)


    End Sub

    Private Sub cmbTransporter_LostFocus(sender As Object, e As EventArgs) Handles cmbTransporter.LostFocus
        If cmbTransporter.SelectedValue <> "" Then
            cmbTransporter.Tag = 0
            Dim selectedRow As GridViewDataRowInfo = DirectCast(cmbTransporter.SelectedItem, GridViewDataRowInfo)
            cmbTransporter.Tag = (selectedRow.Cells("recid").Value.ToString())
        End If
    End Sub

    Private Sub CmbPODCountryCode_LostFocus(sender As Object, e As EventArgs) Handles CmbPODCountryCode.LostFocus
        If CmbPODCountryCode.SelectedValue <> "" Then
            CmbPODCountryCode.Tag = 0
            Dim selectedRow As GridViewDataRowInfo = DirectCast(CmbPODCountryCode.SelectedItem, GridViewDataRowInfo)
            CmbPODCountryCode.Tag = (selectedRow.Cells("recid").Value.ToString())
            CmbPODCountryCode.Text = (selectedRow.Cells("shortname").Value.ToString())
            strpodcountryname = (selectedRow.Cells("name").Value.ToString())

            refresh_cities(CmbPODCountryCode.Text, cmbPODCity)
        End If
    End Sub

    Private Sub cmbPOLCountryCode_LostFocus(sender As Object, e As EventArgs) Handles cmbPOLCountryCode.LostFocus
        If cmbPOLCountryCode.SelectedValue <> "" Then
            cmbPOLCountryCode.Tag = 0
            Dim selectedRow As GridViewDataRowInfo = DirectCast(cmbPOLCountryCode.SelectedItem, GridViewDataRowInfo)
            cmbPOLCountryCode.Tag = (selectedRow.Cells("recid").Value.ToString())
            cmbPOLCountryCode.Text = (selectedRow.Cells("shortname").Value.ToString())
            strpolcountryname = (selectedRow.Cells("name").Value.ToString())

            refresh_cities(cmbPOLCountryCode.Text, cmbPOLCity)
        End If
    End Sub

    'Private Sub CmbPODCountryCode_SelectedValueChanged(sender As Object, e As EventArgs) Handles CmbPODCountryCode.SelectedValueChanged
    '    If action <> "" Then keychange = True
    'End Sub

    Private Function saveCheck() As Boolean
        Dim obj As Object
        Dim msg As String = ""
        If action = "" Then Return False

        If String.IsNullOrEmpty(cmbShipperList.Text) Then cmbShipperList.Tag = 0
        If String.IsNullOrEmpty(cmbConsignee.Text) Then cmbConsignee.Tag = 0
        If String.IsNullOrEmpty(cmbTransporter.Text) Then cmbTransporter.Tag = 0
        If String.IsNullOrEmpty(cmbLocalClient.Text) Then cmbLocalClient.Tag = 0

        If Not IsNumeric(txtTotalTrips.Text) Then txtTotalTrips.Text = 0

        If String.IsNullOrEmpty(txtActNo.Text) Then msg = "Incorrect Shipment Number" : obj = txtActNo : GoTo err
        If String.IsNullOrEmpty(txtActDescription.Text) Then msg = "Shipment Description is Missing" : obj = txtActDescription : GoTo err
        ' If cmbPOLCountryCode.Tag = 0 Then msg = "Place Of Loading Country Missing" : obj = cmbPOLCountryCode : GoTo err
        If String.IsNullOrEmpty(cmbPOLCountryCode.Text) Then msg = "Place Of Loading Country Missing" : obj = cmbPOLCountryCode : GoTo err
        If String.IsNullOrEmpty(strpolcountryname) Then strpolcountryname = GetCountryName(cmbPOLCountryCode.Text)


        'If CmbPODCountryCode.Tag = 0 Then msg = "Place Of Destination Country Missing" : obj = CmbPODCountryCode : GoTo err
        If String.IsNullOrEmpty(CmbPODCountryCode.Text) Then msg = "Place Of Destination Country Missing" : obj = CmbPODCountryCode : GoTo err
        If String.IsNullOrEmpty(strpodcountryname) Then strpodcountryname = GetCountryName(CmbPODCountryCode.Text)

        '   If cmbPODCity.Tag = 0 Then msg = "Place Of Destination City Missing" : obj = cmbPODCity : GoTo err

        If String.IsNullOrEmpty(cmbPODCity.Text) Then msg = "Place Of Destination Country Missing" : obj = cmbPODCity : GoTo err
        ' If cmbPOLCity.Tag = 0 Then msg = "Place Of Loading City Missing" : obj = cmbPOLCity : GoTo err
        If String.IsNullOrEmpty(cmbPOLCity.Text) Then msg = "Place Of Loading Country Missing" : obj = cmbPOLCity : GoTo err

        If cmbLocalClient.Tag = 0 Then msg = "Local Client Missing" : obj = cmbLocalClient : GoTo err
        If String.IsNullOrEmpty(cmbLocalClient.Text) Then msg = "Local Client Missing" : cmbLocalClient.Tag = 0 : obj = cmbLocalClient : GoTo err

        If cmbPackingType.Tag = 0 Then msg = "Select Cargo Type FCL/LCL" : obj = cmbPackingType : GoTo err
        If String.IsNullOrEmpty(cmbPackingType.Text) Then msg = "Select Cargo Type FCL/LCL" : cmbPackingType.Tag = 0 : obj = cmbPackingType : GoTo err

        If Not IsNumeric(txtTotalTrips.Text) Then txtTotalTrips.Text = 0
        If txtTotalTrips.Text < 1 Then msg = "Total Trips Expected " : obj = txtTotalTrips : GoTo err
        If Not IsNumeric(txtGrossWght.Text) Then txtGrossWght.Text = 0
        If Not IsNumeric(txtNetWgt.Text) Then txtNetWgt.Text = 0
        If Not IsNumeric(txtVolWgt.Text) Then txtVolWgt.Text = 0
        If Not IsNumeric(txtNoOfPcs.Text) Then txtNoOfPcs.Text = 0

        Return True
        Exit Function
err:
        lblMessage.Text = msg
        obj.focus()
        Return False
    End Function
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If action = "" Then Exit Sub
        If saveCheck() Then

            frmWaitForm.lblTitle.Text = "Updating Data. please wait..!"
            frmWaitForm.Show()
            frmWaitForm.Refresh()
            Me.Cursor = Cursors.WaitCursor

            If recID = 0 And action = "A" Then
                Call generateJobNumber() 'generate new number just in case if other user have taken it
            End If

            If ActNoINT > 0 Then
                If InsertNewRecord() Then
                    lblMessage.Text = "Save Complete!"
                Else
                    lblMessage.Text = "Write Failure"
                End If
            Else
                lblMessage.Text = "Record Not Saved - Job ID found null"
            End If
            frmWaitForm.Close()
            Me.Cursor = Cursors.Default


            action = ""

            'lock screen
            btnCancelButton.Visible = False
            btnAddShipment.Visible = True
            btnSave.Enabled = False
            btnAddShipment.Focus()

            radBox1.Enabled = False
            radBox2.Enabled = False
            radBox3.Enabled = False
        End If

    End Sub




    Private Function AddUpdate_ActDates(mrecid As Integer) As Boolean
        Dim rtnval As Boolean = True
        Dim adapter As New SqlDataAdapter
        Dim ds As New DataSet
        Dim dr As DataRow
        Dim cmdbuilder As SqlCommandBuilder
        Try
            Me.Cursor = Cursors.WaitCursor
            cmdbuilder = New SqlCommandBuilder(adapter)
            With adapter
                sql_String = "select * from [actmaster_sea_dates] where actrecid=" & mrecid
                .SelectCommand = New SqlCommand(sql_String, sql_CNN)
                .Fill(ds, "cdata")
            End With
            If ds.Tables("cdata").Rows.Count = 0 Then
                dr = ds.Tables("cdata").NewRow 'addnew
                ds.Tables("cdata").Rows.Add(dr) 'add the row to dataset
                dr.Item("actrecid") = mrecid
                dr.Item("jobno") = Trim(txtActNo.Text)
            Else
                dr = ds.Tables("cdata").Rows(0)
            End If
            If IsDate(txtETA.Text) Then dr.Item("eta") = txtETA.Text
            If IsDate(txtETD.Text) Then dr.Item("etd") = txtETD.Text
            adapter.Update(ds, "cdata")

        Catch ex As Exception
            rtnval = False
            Me.Cursor = Cursors.Default
            MsgBox(Err.Description, MsgBoxStyle.Exclamation, "Update_ActDates")
        End Try
        Me.Cursor = Cursors.Default
        Return rtnval
    End Function

    Private Function Add_ActDescription(mrecid As Integer) As Boolean
        Dim rtnval As Boolean = True
        Dim adapter As New SqlDataAdapter
        Dim ds As New DataSet
        Dim dr As DataRow
        Dim cmdbuilder As SqlCommandBuilder
        Try
            Me.Cursor = Cursors.WaitCursor
            cmdbuilder = New SqlCommandBuilder(adapter)
            With adapter
                sql_String = "select * from [actmaster_sea_description] where actrecid=" & mrecid
                .SelectCommand = New SqlCommand(sql_String, sql_CNN)
                .Fill(ds, "des")
            End With
            If ds.Tables("des").Rows.Count = 0 Then
                dr = ds.Tables("des").NewRow 'addnew
                ds.Tables("des").Rows.Add(dr) 'add the row to dataset
                dr.Item("actrecid") = mrecid
                dr.Item("blnote") = Trim(txtActNo.Text)
            End If
            adapter.Update(ds, "des")


        Catch ex As Exception
            rtnval = False
            Me.Cursor = Cursors.Default
            MsgBox(Err.Description, MsgBoxStyle.Exclamation, "Update_ActDescription")
        End Try
        Me.Cursor = Cursors.Default
        Return rtnval
    End Function


    Private Function Add_ActFCL(mrecid As Integer) As Boolean
        Dim rtnval As Boolean = True
        Dim adapter As New SqlDataAdapter
        Dim ds As New DataSet
        Dim dr As DataRow
        Dim cmdbuilder As SqlCommandBuilder
        Try
            Me.Cursor = Cursors.WaitCursor
            cmdbuilder = New SqlCommandBuilder(adapter)

            With adapter
                sql_String = "select * from [actMaster_FCL] where actrecid=" & mrecid
                .SelectCommand = New SqlCommand(sql_String, sql_CNN)
                .Fill(ds, "fcl")
            End With
            If ds.Tables("fcl").Rows.Count = 0 Then
                dr = ds.Tables("fcl").NewRow 'addnew
                ds.Tables("fcl").Rows.Add(dr) 'add the row to dataset
                dr.Item("actrecid") = mrecid
                dr.Item("actNo") = Trim(txtActNo.Text)

                dr.Item("slno") = 1
                dr.Item("linetype") = "FCL&LCL"
                dr.Item("grossWght") = txtGrossWght.Text
                dr.Item("totalWght") = txtGrossWght.Text
                dr.Item("volumeCBM") = txtVolWgt.Text
                '  dr.Item("netwgt") = txtNetWgt.Text
                ' dr.Item("chgblwt") = txtVolWgt.Text
                dr.Item("grosswght") = txtGrossWght.Text
                'dr.Item("netwgtkg") = txtNetWgt.Text
            End If
            adapter.Update(ds, "fcl")

        Catch ex As Exception
            rtnval = False
            Me.Cursor = Cursors.Default
            MsgBox(Err.Description, MsgBoxStyle.Exclamation, "Update_ActFCL")
        End Try
        Me.Cursor = Cursors.Default
        Return rtnval
    End Function


    Private Function InsertNewRecord() As Boolean
        Dim ds0 As New DataSet
        Dim adapter As New SqlDataAdapter
        Dim ds As New DataSet
        Dim dr As DataRow
        Dim rtnval = False
        Dim cmdbuilder As SqlCommandBuilder
        If action = "A" Then recID = 0

        Try
            If sql_CNN.State = ConnectionState.Closed Then createConnection()
            If sql_CNN.State = ConnectionState.Open Then
                cmdbuilder = New SqlCommandBuilder(adapter)
                With adapter
                    sql_String = "select * from [actMaster_SEA] where recid=" & recID
                    .SelectCommand = New SqlCommand(sql_String, sql_CNN) 'add object select command
                    .Fill(ds0, "cdata")
                End With
                If ds0.Tables("cdata").Rows.Count = 0 Then 'new row
                    dr = ds0.Tables("cdata").NewRow 'addnew
                    ds0.Tables("cdata").Rows.Add(dr) 'add the row to dataset
                    dr.Item("branchID") = appUserInfo.BranchId
                    dr.Item("actNo") = Trim(txtActNo.Text)
                    dr.Item("jobRunningNo") = ActNoINT
                    dr.Item("transportmode") = 5 'LT
                    dr.Item("serviceProductID") = 1 ' cmbServiceProductID.SelectedIndex
                    dr.Item("actStatus") = 0
                    'write default values 
                Else
                    dr = ds0.Tables("cdata").Rows(0)
                End If

                With dr
                    .Item("actDescription") = txtActDescription.Text
                    .Item("actCommodity") = txtActCommodity.Text
                    .Item("clientRef") = txtClientRef.Text
                    .Item("placeofreceipt") = txtPlaceOfReceipt.Text

                    .Item("pol_country") = strpolcountryname
                    .Item("portID_POL") = cmbPOLCity.Tag
                    .Item("polCountryCD") = cmbPOLCountryCode.Text
                    .Item("pod_country") = strpodcountryname
                    .Item("portID_POD") = cmbPODCity.Tag
                    .Item("podCountryCD") = CmbPODCountryCode.Text
                    .Item("placeofDelivery") = txtPodDesc.Text

                    .Item("vesselID") = 0
                    .Item("blno") = ""
                    .Item("hblno") = ""
                    .Item("sLineID") = 0
                    .Item("netwgt") = txtNetWgt.Text
                    .Item("salesID") = 0
                    .Item("notes") = ""
                    .Item("volwgt") = txtVolWgt.Text
                    .Item("GrossWght") = txtGrossWght.Text
                    .Item("NoOfPcs") = txtNoOfPcs.Text
                    'chgblwt
                    .Item("PackingType") = 1
                    If Not String.IsNullOrEmpty(cmbPackingType.Text) Then .Item("PackingType") = cmbPackingType.Tag
                    .Item("createdBy") = Microsoft.VisualBasic.Left(appUserInfo.Name, 15)
                    .Item("lastEditedBy") = Microsoft.VisualBasic.Left(appUserInfo.Name, 15)
                    .Item("totaltrips") = txtTotalTrips.Text

                    .Item("orgShipperRecID") = cmbShipperList.Tag
                    .Item("orgConsigneeRecID") = cmbConsignee.Tag
                    .Item("orgTransporterRecID") = cmbTransporter.Tag
                    .Item("orgLocalClient") = cmbLocalClient.Tag
                    'other table
                    'If IsDate(txtETA.Text) Then .Item("eta") = txtETA.Text
                    'If IsDate(txtETD.Text) Then .Item("etd") = txtETD.Text

                    .Item("VesselName") = txtVesselName.Text
                    .Item("blno") = txtBLAWB.Text
                    .Item("voyageNo") = txtVoyage.Text

                    .Item("unloco1") = unloco1
                    .Item("unloco2") = unloco2

                End With
                adapter.Update(ds0, "cdata")

                'get scope_identity()
                If recID = 0 Then
                    recID = get_scope_Identity()
                    'update serial no
                    sql_String = "update [parameter] set slno=" & ActNoINT & " where name='JOBFILE' and branchID=" & appCompanyInfo.branchID
                    Dim commandz As New SqlCommand(sql_String, sql_CNN)
                    commandz.ExecuteNonQuery()
                    'add record in supporting tables
                End If                'now add 

                Call AddUpdate_ActDates(recID)
                Call Add_ActDescription(recID)
                Call Add_ActFCL(recID)

                radSBar3.Text = "RID " & recID
                rtnval = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            rtnval = False
        End Try

        Return rtnval

    End Function

    Private Function get_scope_Identity() As Integer
        Dim rtnval As Integer = 0
        Dim dsi As New DataSet()
        sql_String = "select recid from [actmaster_SEA] where branchid=" & appCompanyInfo.branchID & " and actno='" & Trim(txtActNo.Text) & "';"
        dsi = setDataList(sql_String)
        If dsi.Tables(0).Rows.Count > 0 Then rtnval = dsi.Tables(0).Rows(0).Item("recid")
        Return rtnval
    End Function

    Private Sub cmbPOLCity_LostFocus(sender As Object, e As EventArgs) Handles cmbPOLCity.LostFocus
        If cmbPOLCity.SelectedValue <> "" Then
            cmbPOLCity.Tag = 0
            unloco1 = ""
            Dim selectedRow As GridViewDataRowInfo = DirectCast(cmbPOLCity.SelectedItem, GridViewDataRowInfo)
            cmbPOLCity.Tag = (selectedRow.Cells("id").Value.ToString())
            cmbPOLCity.Text = (selectedRow.Cells("name").Value.ToString())
            unloco1 = (selectedRow.Cells("code").Value.ToString())
        End If
    End Sub

    Private Sub cmbPODCity_LostFocus(sender As Object, e As EventArgs) Handles cmbPODCity.LostFocus
        If cmbPODCity.SelectedValue <> "" Then
            cmbPODCity.Tag = 0
            Dim selectedRow As GridViewDataRowInfo = DirectCast(cmbPODCity.SelectedItem, GridViewDataRowInfo)
            cmbPODCity.Tag = (selectedRow.Cells("id").Value.ToString())
            cmbPODCity.Text = (selectedRow.Cells("name").Value.ToString())
            unloco2 = (selectedRow.Cells("code").Value.ToString())
        End If

    End Sub

    Private Sub cmbPackingType_LostFocus(sender As Object, e As EventArgs) Handles cmbPackingType.LostFocus
        If cmbPackingType.SelectedValue <> "" Then
            cmbPackingType.Tag = 0
            Dim selectedRow As GridViewDataRowInfo = DirectCast(cmbPackingType.SelectedItem, GridViewDataRowInfo)
            cmbPackingType.Tag = (selectedRow.Cells("recid").Value.ToString())
        End If
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim dsx As New DataSet
        dsPrintSearch = Nothing
        lblToolTip.Text = ""
        recID = 0
        If String.IsNullOrEmpty(cmbSearchBy.Text) Then lblToolTip.Text = "Search By ?" : Exit Sub
        Try
            sql_String = "select "
            If cmbSearchBy.SelectedIndex <= 1 Then 'job#/clientname
                If String.IsNullOrEmpty(txtShipmentNumberFind.Text) Then sql_String = "select top 200 " : lblTip.Text = "Listing Last 200 Rows "
                sql_String += " v.[Job No], isnull(wb.trips,0) [Waybills Issued], isnull(itrs,0) [ITR Count], isnull(b.invno,0) [Inv#], Client,v.[Loading Point],v.[Place Of Delivery], "
                sql_String += " actDescription [Job Description],convert(varchar(10),v.JobAddedOn,103) [JobCreated],  v.actRecID actrecidx,v.jobrunningno"
                sql_String += "  from jobFileSearch_viewY2013 v "
                sql_String += " left outer join (select top 1 actrecid, invno from billinginvoicedetail where invtype=0 order by invno desc) b on v.actrecid=b.actrecid"
                sql_String += " left outer join (select w.actRecID, count(w.wbno) trips from [Waybills] w group by w.actRecID) wb  on v.actRecID=wb.actRecID "
                sql_String += " left outer join (select w.actRecID, count(w.itrno) itrs from [Waybills] w where itrno>0 group by w.actRecID) wb1 on v.actRecID=wb1.actRecID  "
                sql_String += " where left(v.[job no],2)='LT' and v.actrecid>0  and v.branchid=" & appUserInfo.BranchId
                If Not String.IsNullOrEmpty(txtShipmentNumberFind.Text) Then
                    If cmbSearchBy.SelectedIndex = 0 Then sql_String += " and [Job No] ='" & txtShipmentNumberFind.Text & "'"
                    If cmbSearchBy.SelectedIndex = 1 Then sql_String += " and [Client]  like '%" & txtShipmentNumberFind.Text & "%'"
                End If
                sql_String += " order by v.actRecID desc "
            ElseIf cmbSearchBy.SelectedIndex >= 2 Then    'bywb/itrno
                sql_String = " select v.[Job No], isnull(wb.trips,0) [Waybills Issued], isnull(itrs,0) [ITR Count],  isnull(b.invno,0) [Inv#],Client,v.[Loading Point],v.[Place Of Delivery], "
                sql_String += " actDescription [Job Description],convert(varchar(10),v.JobAddedOn,103) [JobCreated],  v.actRecID actrecidx,v.jobrunningno"
                sql_String += "  from jobFileSearch_viewY2013 v "
                sql_String += " left outer join (select top 1 actrecid, invno from billinginvoicedetail where invtype=0 order by invno desc) b on v.actrecid=b.actrecid"
                sql_String += " left outer join (select w.actRecID, count(w.wbno) trips from [Waybills] w group by w.actRecID) wb  on v.actRecID=wb.actRecID "
                sql_String += " left outer join (select w.actRecID, count(w.itrno) itrs from [Waybills] w where itrno>0 group by w.actRecID) wb1 on v.actRecID=wb1.actRecID  "
                sql_String += " where left(v.[job no],2)='LT' and v.actrecid>0  and v.branchid=" & appUserInfo.BranchId

                If Not String.IsNullOrEmpty(txtShipmentNumberFind.Text) Then
                    If cmbSearchBy.SelectedIndex = 2 Then sql_String += " and v.actRecID in (select actRecID from Waybills where wbno=" & txtShipmentNumberFind.Text & ")"
                    If cmbSearchBy.SelectedIndex = 3 Then sql_String += " and v.actRecID in (select actRecID from Waybills where itrno=" & txtShipmentNumberFind.Text & ")"
                End If
            End If

            If String.IsNullOrEmpty(txtShipmentNumberFind.Text) Then lblTip.Text = "Listing Top 200 Items"

            Me.Cursor = Cursors.WaitCursor
            radGridShipmentList.DataSource = Nothing
            dsx = setDataList(sql_String)
            If dsx.Tables(0).Rows.Count > 0 Then
                lblToolTip.Text = "Found: " & dsx.Tables(0).Rows.Count
                radGridShipmentList.DataSource = dsx.Tables(0)
                radGridShipmentList.Columns("actrecidx").IsVisible = False
                radGridShipmentList.Columns("jobrunningno").IsVisible = False
                radGridShipmentList.MasterTemplate.BestFitColumns()
                ' dsPrintSearch = dsx
                radGridShipmentList.Focus()
            End If

        Catch ex As Exception
            lblToolTip.Text = ex.Message
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnGenerateWaybills_Click(sender As Object, e As EventArgs) Handles btnGenerateWaybills.Click
        If (Not appUserRights.landGenerateWaybill) And (Not appUserInfo.isAdmin) Then MsgBox("No User Rights", MsgBoxStyle.Exclamation, "Insufficient Rights") : Exit Sub

        If txtJobNumberSearchWB.Tag = 0 Then Exit Sub
        txtJobNumberSearchWB.Enabled = False
        btnSearchWB.Enabled = False
        cmbEquipmentType.Tag = 0

        POLOrgAddrRecID = 0
        PODOrgAddrRecID = 0
        cmbPODCity2.Tag = 0 : cmbPOLCity2.Tag = 0

        btnGenerateWaybills.Enabled = False
        btnViewTransportWaybills.Enabled = False
        PanelNewJobList.Visible = False

        'Call loadOrgPOLPOD(cmbOrgPlaceOfDelivery, "")
        'Call loadOrgPOLPOD(cmbOrgPlaceOfLoading, "")
        'cmbOrgPlaceOfLoading.Columns("recid").IsVisible = False ' .VisibleInColumnChooser = False
        'cmbOrgPlaceOfDelivery.Columns("recid").IsVisible = False ' .VisibleInColumnChooser = False

        cmbDeliveryAddressWB.Visible = False
        cmbLoadingAddressWB.Visible = False
        lnkSelectAddressPOD.Visible = True
        lnkSelectAddressPOL.Visible = True

        'get job basic details
        Call clearGenerateInputPanel()
        Call refresh_organization(cmbLocalAgentBroker, "IsAgent=1 or IsBroker=1")

        Call refresh_country2()

        Dim rtnval As Boolean = False
        Dim dstmp As New DataSet
        sql_String = "select * "
        sql_String += " from [jobFileSearch_viewY2013] where actRecID=" & txtJobNumberSearchWB.Tag
        Me.Cursor = Cursors.WaitCursor
        Try
            dstmp = setDataList(sql_String)
            If dstmp.Tables(0).Rows.Count > 0 Then
                With dstmp.Tables(0).Rows(0)
                    lblJobNumber.Text = .Item("job no")
                    lblShipperNameGenerateWB.Text = .Item("Shipper") : lblCneeNameGenerateWB.Tag = .Item("shprRecId")
                    lblCneeNameGenerateWB.Text = .Item("cnee") : lblCneeNameGenerateWB.Tag = .Item("cneRecId")
                    'load default consignee details
                    cmbOrgPlaceOfLoading.Text = lblCneeNameGenerateWB.Text : cmbOrgPlaceOfLoading.Tag = .Item("cneRecId")
                    cmbOrgPlaceOfDelivery.Text = lblCneeNameGenerateWB.Text : cmbOrgPlaceOfDelivery.Tag = .Item("cneRecId")

                    lblUnloco1.Text = 0
                    lblUnloco2.Text = 0

                    txtNoOfPcs.Text = .Item("totaltrips")
                    txtRefWB.Text = .Item("clientRef")
                    txtActCommodityWB.Text = .Item("actDescription")
                    txtQtyWB.Text = .Item("NoOfCntrs")
                    txtWeightWB.Text = .Item("Wght")

                    txtWBNosWB.Text = .Item("totaltrips")
                    txtTransportCoWB.Text = .Item("transporter")
                    txtTransportCoWB.Tag = .Item("trnRecID")

                    unloco1 = .Item("unloco1")
                    unloco2 = .Item("unloco2")

                    cmbPOLCountry2.Text = .Item("polcountrycd")
                    cmbPOLCity2.Text = .Item("polnameland")

                    cmbPODCountry2.Text = .Item("podcountrycd")
                    cmbPODCity2.Text = .Item("podnameland")
                    cmbPOLCity2.Tag = .Item("portid_pol")
                    cmbPODCity2.Tag = .Item("portid_pod")
                    txtLoadingAddressWB.Text = cmbPOLCity2.Text
                    txtDeliveryAddressWB.Text = cmbPODCity2.Text

                End With
            End If
            'generate batch#
            Call GenBatchNo()

            PanelWBGenerateWaybills.Visible = True
            PanelWBGenerateWaybills.BringToFront()



            txtActCommodityWB.Focus()
            txtActCommodityWB.SelectAll()
        Catch ex As Exception
            lblMessageTabWB.Text = ex.Message
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub GenBatchNo()
        Dim ds As New DataSet
        Try
            BatchNoint = 0
            sql_String = "select isnull(max(batchno)+1,1) [bno] from dbo.Waybills where branchID=" & appCompanyInfo.branchID & ";"
            Me.Cursor = Cursors.WaitCursor
            ds = setDataList(sql_String)
            If ds.Tables(0).Rows.Count > 0 Then
                BatchNoint = ds.Tables("cdata").Rows(0).Item("bno")
                lblBatchNo.Text = BatchNoint
                lblBatchDate.Text = Date.Today
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub clearGenerateInputPanel()
        lblShipperNameGenerateWB.Text = ""
        lblCneeNameGenerateWB.Text = ""
        lblBatchDate.Text = ""
        lblBatchNo.Text = ""

        txtActCommodityWB.Clear()
        txtContainerNoWB.Clear()
        txtContainerSealWB.Clear()
        txtContainerSizeWB.Clear()
        txtContainerTypeWB.Clear()
        txtUnitTypeWB.Clear()
        txtWeightWB.Clear()
        txtQtyWB.Clear()
        txtVolumeWB.Clear()

        cmbOrgPlaceOfLoading.Text = "" : cmbOrgPlaceOfLoading.Tag = 0
        cmbOrgPlaceOfDelivery.Text = "" : cmbOrgPlaceOfDelivery.Tag = 0
        cmbLoadingAddressWB.Text = "" : cmbLoadingAddressWB.Tag = 0
        cmbDeliveryAddressWB.Text = "" : cmbDeliveryAddressWB.Tag = 0
        cmbEquipmentType.Text = "" : cmbEquipmentType.Tag = 0

        cmbLoadingAddressWB.Visible = False
        cmbDeliveryAddressWB.Visible = False

        txtLoadingAddressWB.Clear() : txtLoadingAddressWB.Tag = 0
        txtDeliveryAddressWB.Clear() : txtDeliveryAddressWB.Tag = 0
        txtActCommodityWB.Clear()
        txtExpectedLoadingDate.SetToNullValue()
        cmbLocalAgentBroker.Text = "" : cmbLocalAgentBroker.Tag = 0
        txtRefWB.Clear()
        txtRemarksWB.Clear()
        txtWBNosWB.Clear()
        txtTransportCoWB.Clear()
        chkBlankLoadingDates.Checked = False
        chkCompanyTrucks.Checked = False

        unloco1 = ""
        unloco2 = ""
    End Sub
    Private Sub btnCancelButton_Click(sender As Object, e As EventArgs) Handles btnCancelButton.Click
        btnCancelButton.Visible = False
        btnAddShipment.Visible = True
        btnSave.Enabled = False
        Call clearForm(False)

        radBox1.Enabled = False
        radBox2.Enabled = False
        radBox3.Enabled = False
    End Sub



    Private Function GetJobFile(mrecid As Integer) As Boolean
        Dim rtnval As Boolean = False
        Dim dstmp As New DataSet
        sql_String = "select * "
        sql_String += " from [jobFileSearch_viewY2013] where actRecID=" & mrecid

        Me.Cursor = Cursors.WaitCursor
        Try
            dstmp = setDataList(sql_String)
            If dstmp.Tables(0).Rows.Count > 0 Then
                With dstmp.Tables(0).Rows(0)

                    txtActNo.Text = .Item("job no")
                    txtactStat.Text = "NEW" : txtactStat.Tag = 0
                    txtActDescription.Text = .Item("actDescription")
                    txtActCommodity.Text = .Item("actCommodity")
                    txtClientRef.Text = .Item("clientRef")

                    cmbPOLCountryCode.Tag = 0
                    cmbPOLCountryCode.Text = .Item("polcountrycd")
                    strpolcountryname = .Item("polcountryName")

                    unloco1 = .Item("unloco1")
                    unloco1 = .Item("unloco2")

                    txtPlaceOfReceipt.Text = .Item("Place of Receipt")
                    cmbPOLCity.Tag = .Item("portID_POL")

                    CmbPODCountryCode.Tag = 0
                    CmbPODCountryCode.Text = .Item("podcountrycd")
                    strpodcountryname = .Item("podcountryName")


                    txtPodDesc.Text = .Item("placeofDelivery")
                    cmbPODCity.Tag = .Item("portID_POD")

                    cmbPOLCity.Text = .Item("Loading Point")
                    cmbPODCity.Text = .Item("Place Of Delivery")

                    txtVesselName.Text = .Item("VesselName")
                    txtBLAWB.Text = .Item("blno")
                    txtVoyage.Text = .Item("voyageNo")

                    If IsDate(.Item("Departure Date")) Then txtETD.Text = .Item("Departure Date")
                    If IsDate(.Item("ArrivalDate")) Then txtETA.Text = .Item("ArrivalDate")

                    cmbShipperList.Text = .Item("Shipper") : cmbShipperList.Tag = .Item("shprRecId")
                    cmbConsignee.Text = .Item("cnee") : cmbConsignee.Tag = .Item("cneRecId")
                    cmbTransporter.Text = .Item("transporter") : cmbTransporter.Tag = .Item("trnRecId")
                    cmbLocalClient.Text = .Item("client") : cmbLocalClient.Tag = .Item("cltRecId")


                    If Not IsDBNull(.Item("packing type")) Then
                        cmbPackingType.Text = .Item("Packing Type") : cmbPackingType.Tag = 1
                    End If
                    txtGrossWght.Text = .Item("Wght")
                    txtVolWgt.Text = .Item("netwgt")
                    txtNetWgt.Text = .Item("netwgt")
                    txtTotalTrips.Text = .Item("totaltrips")
                    txtNoOfPcs.Text = .Item("NoOfCntrs")

                    'form footer section
                    radSBar1.Text = "Created By - " & .Item("createdby")
                    radSBarCreatedOn.Text = "Shipment Created On - " & .Item("JobAddedOn")
                    radSBar2.Text = "Last Edited By - " & .Item("lastEditedBy")
                    radSBar3.Text = "RID " & .Item("actRecID")

                    'display grid

                    If mrecid > 0 Then Call fillwblist(mrecid)


                End With
                rtnval = True
            Else
                lblToolTip.Text = "Unable to fetch job file"
            End If
        Catch ex As Exception
            lblToolTip.Text = ex.Message
        End Try
        Me.Cursor = Cursors.Default
        Return rtnval
    End Function

    Private Sub txtActNo_TextChanged(sender As Object, e As EventArgs) Handles txtActNo.TextChanged
        lblFormTitle.Text = txtActNo.Text & IIf(String.IsNullOrEmpty(cmbLocalClient.Text), "", " - " & cmbLocalClient.Text)
    End Sub

    Private Sub cmbLocalClient_TextChanged(sender As Object, e As EventArgs) Handles cmbLocalClient.TextChanged
        lblFormTitle.Text = txtActNo.Text & " - " & cmbLocalClient.Text
    End Sub

    Private Sub btnEditThisJob_Click(sender As Object, e As EventArgs) Handles btnEditThisJob.Click
        radBox1.Enabled = True
        radBox2.Enabled = True
        radBox3.Enabled = True
        btnEditThisJob.Visible = False
        action = "E"
        txtActDescription.Focus()
        btnSave.Enabled = True
    End Sub



    Private Sub btnViewTransportWaybills_Click(sender As Object, e As EventArgs) Handles btnViewTransportWaybills.Click
        If txtJobNumberSearchWB.Tag = 0 Then Exit Sub
        If String.IsNullOrEmpty(txtJobNumberSearchWB.Text) Then Exit Sub

        PanelWBGenerateWaybills.Visible = False
        PanelNewJobList.Visible = False

        cmbFilterByWaybillList.SelectedIndex = 0
        lblJobNumberWaybillList.Text = txtJobNumberSearchWB.Text
        Call btnSearchWaybillsList_Click(sender, e)
        btnGenerateWaybills.Enabled = True
        PanelWaybillList.Visible = True
        txtJobNumberSearchWB.Enabled = True
        btnSearchWB.Enabled = True
        If DgridWaybillList.Rows.Count > 0 Then
            DgridWaybillList.Rows(0).IsSelected = True
            DgridWaybillList.Focus()
        End If
    End Sub


    Private Sub btnSearchWB_Click(sender As Object, e As EventArgs) Handles btnSearchWB.Click

        If String.IsNullOrEmpty(txtJobNumberSearchWB.Text) Then
            Call listNewJobs()
        Else

            Dim dsx As New DataSet
            txtJobNumberSearchWB.Tag = 0
            lblMessageTabWB.Text = ""
            lblFormTitle.Text = ""
            recID = 0
            picChecked.Visible = False : picCrossed.Visible = False
            If String.IsNullOrEmpty(txtJobNumberSearchWB.Text) Then lblMessageTabWB.Text = "Enter Job Number" : txtJobNumberSearchWB.Focus() : Exit Sub
            If Not IsNumeric(txtJobNumberSearchWB.Text) Then lblMessageTabWB.Text = "Expected Number Format" : txtJobNumberSearchWB.Focus() : Exit Sub
            Try
                sql_String = "select actrecid, [job no] as [jobno] from  [jobFileSearch_viewY2013] v "
                sql_String += " where left(v.[job no],2)='LT' and v.actrecid>0 "
                '            sql_String += " and [Job No] ='" & txtJobNumberSearchWB.Text & "'"
                sql_String += " and jobRunningNo=" & txtJobNumberSearchWB.Text
                sql_String += " and branchID=" & appUserInfo.BranchId
                sql_String += " order by v.jobRunningNo desc"

                Me.Cursor = Cursors.WaitCursor
                dsx = setDataList(sql_String)
                If dsx.Tables(0).Rows.Count > 0 Then
                    lblMessageTabWB.Text = "Found One Job"
                    txtJobNumberSearchWB.Tag = dsx.Tables(0).Rows(0).Item("actrecid")
                    txtJobNumberSearchWB.BackColor = Color.LemonChiffon
                    lblFormTitle.Text = dsx.Tables(0).Rows(0).Item("jobno") '  txtJobNumberSearchWB.Text
                    picChecked.Visible = True
                    btnViewTransportWaybills.Enabled = True
                    btnGenerateWaybills.Enabled = True
                    Call btnViewTransportWaybills_Click(sender, e)
                Else
                    lblMessageTabWB.Text = "Job Not Found"
                    lblFormTitle.Text = "Enter Job Number"

                    txtJobNumberSearchWB.BackColor = Color.Orange
                    picCrossed.Visible = True
                End If

            Catch ex As Exception
                lblMessageTabWB.Text = ex.Message
            End Try
        End If
        Me.Cursor = Cursors.Default
    End Sub


    Private Sub btnWBClose2_Click_2(sender As Object, e As EventArgs) Handles btnWBClose2.Click
        PanelWBGenerateWaybills.Visible = False
        btnGenerateWaybills.Enabled = True
        txtJobNumberSearchWB.Enabled = True
        btnSearchWB.Enabled = True
        btnViewTransportWaybills.Enabled = True

    End Sub

    Private Sub txtJobNumberSearchWB_KeyDown(sender As Object, e As KeyEventArgs) Handles txtJobNumberSearchWB.KeyDown
        If txtJobNumberSearchWB.BackColor <> Color.LemonChiffon Then txtJobNumberSearchWB.BackColor = Color.LemonChiffon
    End Sub

    Private Sub btnRefreshLocalAgentWB_Click(sender As Object, e As EventArgs) Handles btnRefreshLocalAgentWB.Click
        Call refresh_organization(cmbLocalAgentBroker, "IsAgent=1 or IsBroker=1")
    End Sub

    Private Sub lnkSelectAddressPOL_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkSelectAddressPOL.LinkClicked
        Call LoadAddressList(cmbLoadingAddressWB, cmbOrgPlaceOfLoading.Tag)
        cmbLoadingAddressWB.Visible = True
    End Sub

    Private Sub lnkSelectAddressPOD_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkSelectAddressPOD.LinkClicked
        cmbDeliveryAddressWB.Visible = True
        Call LoadAddressList(cmbDeliveryAddressWB, cmbOrgPlaceOfDelivery.Tag)
        cmbLoadingAddressWB.Visible = True
    End Sub

    Private Sub LoadAddressList(cmbName As Object, orgrecid As Integer)
        If orgrecid < 0 Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        sql_String = "SELECT  Address1 [Address], isnull(lm.area,'') Location, o.unlocode, o.recID, o.orgRecID,o.locID FROM organizationAddress o"
        sql_String += " left outer join LocationMaster lm on o.locid=lm.recid"
        sql_String += " where o.isActive=1 and orgRecID=" & orgrecid

        'sql_String = "SELECT  Address1 + '' + Telephone + ' ' + Email [Address], unlocode, recID, orgRecID,locID FROM organizationAddress"
        'sql_String += " where isActive=1 and orgRecID=" & orgrecid
        If fillCombo(cmbName, sql_String, 0, 300, 200, 0) Then
            cmbName.Columns(2).VisibleInColumnChooser = False
            cmbName.Columns(3).VisibleInColumnChooser = False
            cmbName.Columns(4).VisibleInColumnChooser = False
        End If
        cmbName.Tag = 0 : cmbName.Text = ""
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub cmbOrgPlaceOfLoading_LostFocus(sender As Object, e As EventArgs) Handles cmbOrgPlaceOfLoading.LostFocus
        If cmbOrgPlaceOfLoading.SelectedValue <> "" Then
            cmbOrgPlaceOfLoading.Tag = 0
            Dim selectedRow As GridViewDataRowInfo = DirectCast(cmbOrgPlaceOfLoading.SelectedItem, GridViewDataRowInfo)
            cmbOrgPlaceOfLoading.Tag = (selectedRow.Cells("recid").Value.ToString())
            Call LoadAddressList(cmbLoadingAddressWB, cmbOrgPlaceOfLoading.Tag)
        End If
    End Sub

    Private Sub cmbOrgPlaceOfDelivery_LostFocus(sender As Object, e As EventArgs) Handles cmbOrgPlaceOfDelivery.LostFocus
        If cmbOrgPlaceOfDelivery.SelectedValue <> "" Then
            cmbOrgPlaceOfDelivery.Tag = 0
            Dim selectedRow As GridViewDataRowInfo = DirectCast(cmbOrgPlaceOfDelivery.SelectedItem, GridViewDataRowInfo)
            cmbOrgPlaceOfDelivery.Tag = (selectedRow.Cells("recid").Value.ToString())
            Call LoadAddressList(cmbDeliveryAddressWB, cmbOrgPlaceOfDelivery.Tag)
        End If
    End Sub

    Private Sub cmbLoadingAddressWB_LostFocus(sender As Object, e As EventArgs) Handles cmbLoadingAddressWB.LostFocus
        If cmbLoadingAddressWB.SelectedValue <> "" Then
            cmbLoadingAddressWB.Tag = 0 : locid1 = 0
            POLOrgAddrRecID = 0
            Dim selectedRow As GridViewDataRowInfo = DirectCast(cmbLoadingAddressWB.SelectedItem, GridViewDataRowInfo)
            cmbLoadingAddressWB.Tag = (selectedRow.Cells("recid").Value.ToString())
            POLOrgAddrRecID = (selectedRow.Cells("recid").Value.ToString())
            txtLoadingAddressWB.Text = (selectedRow.Cells("Address").Value.ToString())
            lblUnloco1.Text = (selectedRow.Cells("unlocode").Value.ToString())
            locid1 = (selectedRow.Cells("locid").Value.ToString())
        End If
    End Sub

    Private Sub cmbDeliveryAddressWB_LostFocus(sender As Object, e As EventArgs) Handles cmbDeliveryAddressWB.LostFocus
        If cmbDeliveryAddressWB.SelectedValue <> "" Then
            cmbDeliveryAddressWB.Tag = 0 : locid2 = 0
            PODOrgAddrRecID = 0
            Dim selectedRow As GridViewDataRowInfo = DirectCast(cmbDeliveryAddressWB.SelectedItem, GridViewDataRowInfo)
            cmbDeliveryAddressWB.Tag = (selectedRow.Cells("recid").Value.ToString())
            PODOrgAddrRecID = (selectedRow.Cells("recid").Value.ToString())

            txtDeliveryAddressWB.Text = (selectedRow.Cells("Address").Value.ToString())
            lblUnloco2.Text = (selectedRow.Cells("unlocode").Value.ToString())
            locid2 = (selectedRow.Cells("locid").Value.ToString())
        End If
    End Sub

    Private Sub cmbLoadingAddressWB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbLoadingAddressWB.SelectedIndexChanged
        If cmbLoadingAddressWB.SelectedValue <> "" Then
            cmbLoadingAddressWB.Tag = 0
            Dim selectedRow As GridViewDataRowInfo = DirectCast(cmbLoadingAddressWB.SelectedItem, GridViewDataRowInfo)
            cmbLoadingAddressWB.Tag = (selectedRow.Cells("recid").Value.ToString())
            txtLoadingAddressWB.Text = (selectedRow.Cells("Address").Value.ToString())
            lblUnloco1.Text = (selectedRow.Cells("unlocode").Value.ToString())
            locid1 = (selectedRow.Cells("locid").Value.ToString())
            'lblOriginLocation2.Text = (selectedRow.Cells("area").Value.ToString())

            'get location from address

        End If
    End Sub

    Private Sub cmbDeliveryAddressWB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDeliveryAddressWB.SelectedIndexChanged
        If cmbDeliveryAddressWB.SelectedValue <> "" Then
            cmbDeliveryAddressWB.Tag = 0
            Dim selectedRow As GridViewDataRowInfo = DirectCast(cmbDeliveryAddressWB.SelectedItem, GridViewDataRowInfo)
            cmbDeliveryAddressWB.Tag = (selectedRow.Cells("recid").Value.ToString())
            txtDeliveryAddressWB.Text = (selectedRow.Cells("Address").Value.ToString())
            lblUnloco2.Text = (selectedRow.Cells("unlocode").Value.ToString())
            locid2 = (selectedRow.Cells("locid").Value.ToString())

        End If
    End Sub

    Private Sub btnSubmitWB_Click(sender As Object, e As EventArgs) Handles btnSubmitWB.Click
        btnSubmitWB.BackColor = Color.Orange
        If Val(txtWBNosWB.Text) < 1 Then lblMessageGeneratePanel.Text = "Missing Waybills Count." : txtWBNosWB.Focus() : Exit Sub
        If String.IsNullOrEmpty(txtLoadingAddressWB.Text) Or String.IsNullOrEmpty(lblUnloco1.Text) Then lblMessageGeneratePanel.Text = "Loading Address is missing" : txtLoadingAddressWB.Focus() : Exit Sub
        If String.IsNullOrEmpty(txtDeliveryAddressWB.Text) Or String.IsNullOrEmpty(lblUnloco2.Text) Then lblMessageGeneratePanel.Text = "Delivery Address is missing" : txtDeliveryAddressWB.Focus() : Exit Sub
        If chkBlankLoadingDates.CheckState = CheckState.Checked Then
            If MsgBox("You have choosen to print Empty load date or an open Waybill, Continue ?", vbExclamation + MsgBoxStyle.YesNo, "Genereate Waybills") = MsgBoxResult.No Then Exit Sub
        End If
        If cmbLocalAgentBroker.Text = "" Then
            If MsgBox("Supervisor is not selected, Proceed ?", vbExclamation + MsgBoxStyle.YesNo, "Generate Waybill") = MsgBoxResult.No Then cmbLocalAgentBroker.Focus() : Exit Sub
        End If
        '        If (POLOrgAddrRecID = 0 Or PODOrgAddrRecID = 0) Then MsgBox("You Need to Select Address From List", MsgBoxStyle.Critical, "Generate Waybill") : Exit Sub
        If (String.IsNullOrEmpty(cmbPOLCountry2.Text) Or cmbPOLCity2.Tag = 0) Then lblMessageGeneratePanel.Text = "Please Select Loading Country/City From List" : Exit Sub
        If (String.IsNullOrEmpty(cmbPODCountry2.Text) Or cmbPODCity2.Tag = 0) Then lblMessageGeneratePanel.Text = "Please Select Loading Country/City From List" : Exit Sub

        '  If Not IsNumeric(txtTotalTrips) Then

        btnSubmitWB.BackColor = Color.LightSkyBlue
        If MsgBox("System is About to Generate [" & txtWBNosWB.Text & "] Waybills or POD" & vbCrLf & "Proceed with the Action ?", vbQuestion + MsgBoxStyle.YesNo, "Generate Waybill") = MsgBoxResult.No Then Exit Sub
        If String.IsNullOrEmpty(cmbEquipmentType.Text) Then cmbEquipmentType.Tag = 0


        Try
            Dim wbno As Integer = 0
            wbno = GenWaybillNo()
            Dim slno As String = ""
            For ctr As Integer = 1 To Val(txtWBNosWB.Text)
                slno = ctr & "/" & Val(txtWBNosWB.Text)
                If Not AddWaybill(txtJobNumberSearchWB.Tag, slno, wbno) Then lblMessageTabWB.Text = "There was error when creating Waybill!" : Exit For
                wbno += 1
            Next

            If MsgBox("Print Generated Waybills Now ?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Printing Waybills") = MsgBoxResult.Yes Then
                Call callPrintBatchWaybill(BatchNoint, chkBlankLoadingDates.CheckState)
            End If

            btnViewTransportWaybills.Enabled = True
            btnViewTransportWaybills_Click(sender, e)

            'PanelWBGenerateWaybills.Visible =
            'btnGenerateWaybills.Enabled = True
            'txtJobNumberSearchWB.Enabled = True


        Catch ex As Exception

        End Try
    End Sub

    Private Sub callPrintBatchWaybill(intBatchNo As Integer, blankDate As Boolean)
        Try
            Dim rptformula As String = ""
            Dim rptName As String = ""

            frmWaitForm.lblTitle.Text = "Preparing Print. please wait..!"
            frmWaitForm.Show()
            frmWaitForm.Refresh()

            rptformula = "{viewQueryWaybillRecord2018.batchno}=" & intBatchNo
            rptName = Application.StartupPath & appCompanyInfo.customizerptpath & "\iffWaybillTTS004.rpt"
            Dim frm As New frmCrystalReportViewer(rptName, rptformula, False, "", "", chkBlankLoadingDates.CheckState) ' IIf(chkBlankLoadingDates.CheckState = CheckState.Checked, "  ", txtExpectedLoadingDate.Text))
            frm.Show()
            frm.Focus()
            'End If

        Catch ex As Exception
            frmWaitForm.Close()
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try
        frmWaitForm.Close()
    End Sub


    Private Function AddWaybill(actrecid As Integer, batchslno As String, mwbno As Integer) As Boolean
        Dim rtnval As Boolean = True
        Dim adapter As New SqlDataAdapter
        Dim ds As New DataSet
        Dim dr As DataRow
        Dim cmdbuilder As SqlCommandBuilder
        Try
            Me.Cursor = Cursors.WaitCursor
            cmdbuilder = New SqlCommandBuilder(adapter)
            With adapter
                sql_String = "select * from dbo.waybills where actrecid=" & actrecid & " and batchno=-1"
                .SelectCommand = New SqlCommand(sql_String, sql_CNN)
                .Fill(ds)
            End With
            If ds.Tables(0).Rows.Count = 0 Then
                dr = ds.Tables(0).NewRow 'addnew
                ds.Tables(0).Rows.Add(dr) 'add the row to dataset

                dr.Item("actRecID") = actrecid
                dr.Item("branchID") = appUserInfo.BranchId
                dr.Item("actNo") = txtJobNumberSearchWB.Text
                dr.Item("wbno") = mwbno
                dr.Item("wbdate") = Date.Today

                dr.Item("goodsdesc") = Trim(txtActCommodityWB.Text)
                dr.Item("loadQty") = txtQtyWB.Text
                dr.Item("goodsunittype") = txtUnitTypeWB.Text
                dr.Item("netWght") = txtWeightWB.Text
                dr.Item("grossWght") = txtVolumeWB.Text



                dr.Item("batchno") = lblBatchNo.Text
                dr.Item("batchdate") = Now ' lblBatchDate.Text
                dr.Item("batchslno") = batchslno


                dr.Item("containerNo") = txtContainerNoWB.Text
                dr.Item("containerType") = txtContainerTypeWB.Text
                dr.Item("cntrRefNo") = txtContainerSizeWB.Text & "-" & txtContainerSealWB.Text

                dr.Item("transporterName") = txtTransportCoWB.Text
                dr.Item("orgIsTransporterID") = txtTransportCoWB.Tag

                dr.Item("wbRemarks") = txtRemarksWB.Text

                dr.Item("PickupAddress") = txtLoadingAddressWB.Text
                dr.Item("DeliveryAddress") = txtDeliveryAddressWB.Text
                dr.Item("unloco1") = unloco1 ' lblUnloco1.Text
                dr.Item("unloco2") = unloco2 ' lblUnloco2.Text
                ' adapter.Update(ds, "cdata")

                dr.Item("equipType") = cmbEquipmentType.Tag
                dr.Item("equipID") = 0

                dr.Item("orgIsBrokerRecID") = cmbLocalAgentBroker.Tag
                dr.Item("wbRefNo") = txtRefWB.Text
                dr.Item("wbRemarks") = txtRemarksWB.Text

                dr.Item("createdBy") = Microsoft.VisualBasic.Left(appUserInfo.Name, 19)
                dr.Item("CreatedOn") = Now ' Date.Today

                dr.Item("batchblankdt") = chkBlankLoadingDates.CheckState

                dr.Item("companyowntruck") = IIf(chkCompanyTrucks.Checked, 0, 1)

                dr.Item("polorgaddrrecid") = cmbLoadingAddressWB.Tag ' cmbOrgPlaceOfLoading.Tag
                dr.Item("podorgaddrrecid") = cmbDeliveryAddressWB.Tag ' cmbOrgPlaceOfDelivery.Tag


                dr.Item("orgrecidPOL") = cmbOrgPlaceOfLoading.Tag
                dr.Item("orgrecidPOD") = cmbOrgPlaceOfDelivery.Tag

                'dr.Item("locid1") = locid1
                'dr.Item("locid2") = locid2

                dr.Item("locid1") = cmbPOLCity2.Tag
                dr.Item("locid2") = cmbPODCity2.Tag
                dr.Item("wbpost") = 0
                dr.Item("wbstatus") = "NEW"

                If IsDate(txtExpectedLoadingDate.Text) Then dr.Item("loadingDate") = txtExpectedLoadingDate.Text

                adapter.Update(ds)
            End If


        Catch ex As Exception
            rtnval = False
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "AddWaybill")
        End Try
        Me.Cursor = Cursors.Default
        Return rtnval
    End Function

    Private Function GenWaybillNo() As Integer
        Dim ds As New DataSet
        Dim rtnval As Integer = 0
        Try
            sql_String = "select isnull(max(wbno)+1,1) [wbno] from dbo.Waybills " 'where branchID=" & appCompanyInfo.branchID & ";"
            Me.Cursor = Cursors.WaitCursor
            ds = setDataList(sql_String)
            If ds.Tables(0).Rows.Count > 0 Then rtnval = ds.Tables("cdata").Rows(0).Item("wbno")
            Return rtnval
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
            Return rtnval
        End Try
        Me.Cursor = Cursors.Default
    End Function

    Private Sub btnSearchWaybillsList_Click(sender As Object, e As EventArgs) Handles btnSearchWaybillsList.Click
        PanelMessageWaybillList.Visible = False
        If txtJobNumberSearchWB.Tag = 0 Then lblMsgWaybillList.Text = "Select Job Number " : PanelMessageWaybillList.Visible = True
        If String.IsNullOrEmpty(txtSearchWaybillList.Text) Then cmbFilterByWaybillList.SelectedIndex = 0
        sql_String = "select v.[Waybill No], v.[Batch no], v.[batch slno] [slno],CityFrom, CityTo,ContainerNo,TruckType,Driver, ITR,Invno, LoadingDate,CltCode [Client], "
        sql_String += " OrgCodePOD [Consignee],Brokrcode,Transcode,[status],actrecid,wbid,v.[job no],WaybillDate  from [viewPODListTransArab] v where actrecid=" & txtJobNumberSearchWB.Tag
        If Not String.IsNullOrEmpty(txtSearchWaybillList.Text) Then
            If cmbFilterByWaybillList.SelectedIndex = 1 Then sql_String += " and [batch no]='" & txtSearchWaybillList.Text & "'"
            If cmbFilterByWaybillList.SelectedIndex = 2 Then sql_String += " and broker='" & txtSearchWaybillList.Text & "'"
        End If
        sql_String += " order by wbid;"

        Dim dsx As New DataSet
        Try
            Me.Cursor = Cursors.WaitCursor
            DgridWaybillList.DataSource = Nothing
            dsx = setDataList(sql_String)
            If dsx.Tables(0).Rows.Count > 0 Then
                DgridWaybillList.DataSource = dsx.Tables(0)
                DgridWaybillList.Columns("ActRecID").IsVisible = False
                DgridWaybillList.Columns("WBID").IsVisible = False
                DgridWaybillList.Columns("Job No").IsVisible = False
                DgridWaybillList.Columns("WaybillDate").IsVisible = False
                DgridWaybillList.MasterTemplate.BestFitColumns()
                DgridWaybillList.Columns("CityFrom").Width = 100
                DgridWaybillList.Columns("CityTo").Width = 100
                PanelWaybillList.BringToFront()

                ' dsPrintSearch = dsx
            Else
                lblMsgWaybillList.Text = "Data Not Found" : PanelMessageWaybillList.Visible = True
            End If
            btnPrintBatchWaybillList.Focus()

        Catch ex As Exception
            PanelMessageWaybillList.Visible = True
            lblMsgWaybillList.Text = ex.Message
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub fillwblist(mrecidi As Integer)
        'sql_String = " select v.[Waybill No], [Status],LoadingDate,cityfrom Origin, cityto Destination,containerNo [Container],ITR,TruckOwner,transcode [Trucker],Driver,brokrcode [Supervisor] "
        'sql_String += "  from [viewPODListTransArab] v Where v.actRecID=" & mrecidi & " order by v.LoadingDate "


        sql_String = "select  v.[Waybill No], v.[Batch no], v.[batch slno] [slno],CityFrom, CityTo,ContainerNo,TruckType,Driver, ITR,Invno, LoadingDate,CltCode [Client], "
        sql_String += " OrgCodePOD [Consignee],Brokrcode,Transcode,[status]  from [viewPODListTransArab] v where actrecid=" & mrecidi & " order by v.[waybill no] "

        Dim dsx As New DataSet
        Try
            Me.Cursor = Cursors.WaitCursor
            radGridTransportOrders.DataSource = Nothing
            dsx = setDataList(sql_String)
            If dsx.Tables(0).Rows.Count > 0 Then
                radGridTransportOrders.DataSource = dsx.Tables(0)
                radGridTransportOrders.MasterTemplate.BestFitColumns()
            End If

        Catch ex As Exception
            PanelMessageWaybillList.Visible = True
            lblMsgWaybillList.Text = ex.Message
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub btnCloseWaybillList_Click(sender As Object, e As EventArgs) Handles btnCloseWaybillList.Click
        PanelWaybillList.Visible = False
        txtJobNumberSearchWB.Enabled = True
        btnSearchWB.Enabled = True
    End Sub

    Private Sub cmbEquipmentType_LostFocus(sender As Object, e As EventArgs) Handles cmbEquipmentType.LostFocus
        If cmbEquipmentType.SelectedValue <> "" Then
            cmbEquipmentType.Tag = 0
            Dim selectedRow As GridViewDataRowInfo = DirectCast(cmbEquipmentType.SelectedItem, GridViewDataRowInfo)
            cmbEquipmentType.Tag = (selectedRow.Cells("recid").Value.ToString())
        End If
    End Sub
    Private Sub cmbLocalAgentBroker_LostFocus(sender As Object, e As EventArgs) Handles cmbLocalAgentBroker.LostFocus
        If cmbLocalAgentBroker.SelectedValue <> "" Then
            cmbLocalAgentBroker.Tag = 0
            Dim selectedRow As GridViewDataRowInfo = DirectCast(cmbLocalAgentBroker.SelectedItem, GridViewDataRowInfo)
            cmbLocalAgentBroker.Tag = (selectedRow.Cells("recid").Value.ToString())
        End If
    End Sub
    Private Sub btnAddAddr1_Click(sender As Object, e As EventArgs) Handles btnAddAddr1.Click
        If cmbOrgPlaceOfLoading.Tag < 1 Then Exit Sub
        Dim frm As New frmAddAddress(cmbLoadingAddressWB.Tag, cmbOrgPlaceOfLoading.Tag, cmbOrgPlaceOfLoading.Text)
        frm.ShowDialog(Me)
        If formReturnValueINT > 0 Then
            Call LoadAddressList(cmbLoadingAddressWB, cmbOrgPlaceOfLoading.Tag)
        End If
    End Sub
    Private Sub btnAddAddr2_Click(sender As Object, e As EventArgs) Handles btnAddAddr2.Click
        If cmbOrgPlaceOfDelivery.Tag < 1 Then Exit Sub
        Dim frm As New frmAddAddress(cmbDeliveryAddressWB.Tag, cmbOrgPlaceOfDelivery.Tag, cmbOrgPlaceOfDelivery.Text)
        frm.ShowDialog(Me)
        If formReturnValueINT > 0 Then
            Call LoadAddressList(cmbDeliveryAddressWB, cmbOrgPlaceOfDelivery.Tag)
        End If
    End Sub

    Private Sub btnPrintBatchWaybillList_Click(sender As Object, e As EventArgs) Handles btnPrintBatchWaybillList.Click
        Dim rptname As String = ""
        Dim rptformula As String = ""

        PanelMessageWaybillList.Visible = False
        If (cmbFilterByWaybillList.SelectedIndex <> 1) Then lblMsgWaybillList.Text = "Select Batch to Print" : PanelMessageWaybillList.Visible = True : Exit Sub
        If (cmbFilterByWaybillList.SelectedIndex = 1) And String.IsNullOrEmpty(txtSearchWaybillList.Text) Then lblMsgWaybillList.Text = "Select Batch to Print" : PanelMessageWaybillList.Visible = True : Exit Sub

        If DgridWaybillList.Rows.Count > 0 Then
            Try

                frmWaitForm.lblTitle.Text = "Loading Report Data. please wait..!"
                frmWaitForm.Show()
                frmWaitForm.Refresh()

                rptformula = "{viewQueryWaybillRecord2018.batchno}=" & Val(txtSearchWaybillList.Text)

                '                If writeWaybillDataToLocalDBAccess(0, Val(txtSearchWaybillList.Text), chkBlankDate.Checked) Then
                rptname = Application.StartupPath & appCompanyInfo.customizerptpath & "\iffWaybillTTS004.rpt"
                'Dim frm As New frmCrystalReportViewer(rptname, rptformula, False, "", "", txtExpectedLoadingDate.Text)
                '                Dim frm As New frmCrystalReportViewer(rptname, rptformula, False, "", "", IIf(chkBlankDate.CheckState = CheckState.Checked, "   ", txtExpectedLoadingDate.Text))
                Dim frm As New frmCrystalReportViewer(rptname, rptformula, False, "", "", chkBlankDate.CheckState)

                frm.Show()
                frm.Focus()
                'End If

            Catch ex As Exception
                frmWaitForm.Close()
                MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
            End Try
            frmWaitForm.Close()
        End If
    End Sub

    Private Sub listNewJobs()
        sql_String = "select top 100 v.[Job No],  isnull(t.wbnos,0) [WBIssued],"
        If Not chkListOnlyNewShipments.Checked Then sql_String += " isnull(itrs,0) [ITRIssued], "
        sql_String += " Client,v.[Loading Point],v.[Place Of Delivery],"
        sql_String += " actDescription [Job Description],convert(varchar(10),v.JobAddedOn,103) [JobCreated],v.jobRunningNo,v.actRecID"
        sql_String += " from jobFileSearch_viewY2013 v "

        sql_String += " left outer join (select actrecid, count(wbno) wbnos	from Waybills group by actRecID"
        If chkListOnlyNewShipments.Checked Then sql_String += " having count(wbno)=0"
        sql_String += ") t on v.actRecID=t.actRecID"
        If Not chkListOnlyNewShipments.Checked Then sql_String += " left outer join (select w.actRecID, count(w.itrno) itrs from [Waybills] w where itrno>0 group by w.actRecID) wb1 on v.actRecID=wb1.actRecID"
        sql_String += " where left(v.[job no],2)='LT' and v.actrecid>0  and v.branchid=" & appUserInfo.BranchId
        '        sql_String += " order by v.JobAddedOn desc"
        sql_String += " order by jobRunningNo desc"

        Dim dsx As New DataSet
        Try
            Me.Cursor = Cursors.WaitCursor
            radGridNewJob.DataSource = Nothing
            dsx = setDataList(sql_String)
            If dsx.Tables(0).Rows.Count > 0 Then
                radGridNewJob.DataSource = dsx.Tables(0)
                radGridNewJob.Columns("jobRunningNo").IsVisible = False
                radGridNewJob.Columns("actrecid").IsVisible = False
                radGridNewJob.MasterTemplate.BestFitColumns()
                ' dsPrintSearch = dsx
                PanelNewJobList.Visible = True
                PanelNewJobList.BringToFront()
                radGridNewJob.Focus()
            Else
                lblMsgWaybillList.Text = "Data Not Found" : PanelMessageWaybillList.Visible = True
            End If
        Catch ex As Exception
            PanelMessageWaybillList.Visible = True
            lblMsgWaybillList.Text = ex.Message
        End Try
        Me.Cursor = Cursors.Default

    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        PanelNewJobList.Visible = False
    End Sub
    Private Sub txtActDescription_LostFocus(sender As Object, e As EventArgs) Handles txtActDescription.LostFocus
        If String.IsNullOrEmpty(txtActCommodity.Text) Then txtActCommodity.Text = txtActDescription.Text
    End Sub

    Private Sub TabControlMain_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControlMain.SelectedIndexChanged
        If TabControlMain.SelectedIndex = 3 Then 'billing
            If txtInvJobNumber.Tag = 0 Then
                txtInvJobNumber.Enabled = True
                txtInvJobNumber.ReadOnly = False
                txtInvJobNumber.Focus()
                'PanelInvTabControl.Enabled = False
                btnInvCreateInvoice.Enabled = False
            End If
        End If
    End Sub

    Private Sub btnInvJobSearch_Click(sender As Object, e As EventArgs) Handles btnInvJobSearch.Click
        Dim dsx As New DataSet
        txtInvJobNumber.Tag = 0
        ActNoStr = ""
        lblInvActNo.Text = ""
        lblInvMessage.Text = ""
        orgInvRecID = 0
        DGridViewInvList.Visible = False
        DGridViewInvList.DataSource = Nothing
        btnInvCreateInvoice.Enabled = False
        PanelInvHeaderTab.Enabled = False

        Call clsInvTab()
        DGridViewInv.DataSource = Nothing
        '        PanelInvTabControl.Enabled = False


        lblMessage.Text = ""
        If String.IsNullOrEmpty(txtInvJobNumber.Text) Then lblInvMessage.Text = "Missing Job Number..." : Exit Sub
        If Not IsNumeric(txtInvJobNumber.Text) Then lblMessage.Text = "Input Number Format..." : Exit Sub

        Try
            Me.Cursor = Cursors.WaitCursor
            sql_String = "select a.recid,a.actno,a.orglocalclient from [actMaster_SEA] a  where a.jobRunningNo=" & txtInvJobNumber.Text
            sql_String += " and a.branchid=" & appCompanyInfo.branchID
            dsx = setDataList(sql_String)
            If dsx.Tables(0).Rows.Count > 0 Then
                txtInvJobNumber.Tag = dsx.Tables(0).Rows(0).Item("recid").ToString
                ActNoStr = dsx.Tables(0).Rows(0).Item("actno").ToString
                lblInvActNo.Text = ActNoStr
                orgInvRecID = dsx.Tables(0).Rows(0).Item("orglocalclient").ToString
                btnInvCreateInvoice.Enabled = True
                TabControl1.SelectedIndex = 0

            Else
                Me.Cursor = Cursors.Default
                lblMessage.Text = "Invalid Job Number..."
                txtInvJobNumber.SelectAll()
                txtInvJobNumber.Focus()
                Return
            End If
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            lblInvMessage.Text = Err.Description
            Me.Cursor = Cursors.Default
            Return
        End Try

        Call FillInvList()
        lblFormTitle.Text = ActNoStr

    End Sub


    Private Sub btnInvCreateInvoice_Click(sender As Object, e As EventArgs) Handles btnInvCreateInvoice.Click
        If txtInvJobNumber.Tag = 0 Then lblMessage.Text = "Invalid Job Number" : Return
        If MsgBox("Creating New Invoice. Proceed ?", vbQuestion + MsgBoxStyle.YesNo, "New Invoice Request") = MsgBoxResult.No Then Return
        Call clsInvTab()
        txtInvNo.Tag = 0
        'get billing party

        If SaveInvoice() Then
            Call FillInvList()
            Call QueryInvoice(btnInvCreateInvoice.Tag)
            PanelInvTabControl.Enabled = True
            PanelInvHeaderTab.Enabled = True
            TabControl1.SelectedIndex = 0
            txtInvNote.SelectAll()
            txtInvNote.Focus()
        End If

    End Sub
    Private Sub DGridViewInvList_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGridViewInvList.CellContentDoubleClick
        Dim invno As Integer = 0
        invno = DGridViewInvList.Rows(e.RowIndex).Cells("InvNo").Value
        Call QueryInvoice(invno)
        PanelInvHeaderTab.Enabled = False
        CrystalReportViewer2.Visible = False
        '        PanelInvTabControl.Enabled = False
        'If rowid > 0 Then
        '    Dim frm As New frmWaybillSellingChargeList(rowid, orgRecID, locid1, locid2)
        '    frm.ShowDialog()
        '    Call InitDataGridRevenue()
        'End If
    End Sub

    Private Sub DGridViewInvList_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGridViewInvList.CellDoubleClick
        Call DGridViewInvList_CellContentDoubleClick(sender, e)
    End Sub
    Private Sub FillInvList()
        Dim dsx As New DataSet
        'fill invoice list first
        sql_String = "select t1.invno [InvNo], t1.invdate [Date], isnull(t2.invamt,0) [Amount],"
        sql_String += " t2.clt [BillTo], t2.cltid, t1.recid from billingInvoiceDetail t1 "
        sql_String += " left outer join (select b.actRecID,sellInvoiceNo, cast(sum(sellamtlocal)+sum(sellvatamount) as decimal(10,2)) [invamt],"
        sql_String += " orgisreceivableaccountrecid [cltid], o.name [clt]  from billing  b "
        sql_String += " inner join organization o on b.orgisreceivableaccountrecid=o.recid"
        sql_String += " group by b.actRecID,b.sellInvoiceNo,b.orgisreceivableaccountrecid,o.name) t2 on t1.actRecID=t2.actRecID and t1.invno=t2.sellInvoiceNo"
        sql_String += " where t1.invtype = 0 And t1.actrecid =" & txtInvJobNumber.Tag & " and t1.branchid=" & appCompanyInfo.branchID

        Try
            Me.Cursor = Cursors.WaitCursor
            dsx = setDataList(sql_String)
            If dsx.Tables(0).Rows.Count > 0 Then
                With DGridViewInvList
                    .DataSource = Nothing
                    .DataSource = dsx.Tables(0)
                    .Columns("recid").Visible = False
                    .Columns("cltid").Visible = False
                    .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
                    .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                    .Columns("Amount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .RowHeadersVisible = False
                    .Font = New Font("Arial", 8, FontStyle.Bold)
                    .RowsDefaultCellStyle.Font = New Font("Arial", 8, FontStyle.Regular)
                    .Visible = True
                    'point to last row
                    .Rows(.Rows.Count - 1).Selected = True
                    .CurrentCell = .Rows(.Rows.Count - 1).Cells(0)
                End With
            End If
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            lblInvMessage.Text = Err.Description
            Me.Cursor = Cursors.Default
            Return
        End Try
    End Sub


    Private Sub QueryInvoice(qInvNo As Integer)
        'invoice header and footer
        Call clsInvTab()
        frmWaitForm.lblTitle.Text = "Loading Data Please Wait..!"
        frmWaitForm.Show()
        frmWaitForm.Refresh()
        Me.Cursor = Cursors.WaitCursor

        sql_String = "select t1.invno [InvNo], t1.invdate [Date], t1.invduedate [DueDate],t1.invremarks [Rem],isnull(t2.cltname,'') [Client],"
        sql_String += " t1.advanceamount,isnull(t2.cltrecid,0) [cltrecid], t1.recid [invrecid],t1.createdby, t1.createddate, isnull(t1.updatedby,'') [updtby], isnull(t1.updatedon,'') [updton]"
        sql_String += "   from billingInvoiceDetail t1  "
        sql_String += " left outer join (select distinct orgisreceivableaccountrecid [cltrecid], o.name [CltName], b.actrecid,sellInvoiceNo  "
        sql_String += " from billing b inner join organization o on b.orgisreceivableaccountrecid=o.recid) t2 "
        sql_String += " on t1.actRecID=t2.actRecID and t1.invno=t2.sellInvoiceNo  "
        sql_String += " where t1.invtype=0  and  t1.actrecid=" & txtInvJobNumber.Tag & " and t1.invno=" & qInvNo
        ' MsgBox(sql_String)
        Dim ds As New DataSet
        Try
            Me.Cursor = Cursors.WaitCursor
            ds = setDataList(sql_String)
            If ds.Tables(0).Rows.Count > 0 Then
                txtInvNo.Tag = ds.Tables("cdata").Rows(0).Item("invrecid")
                txtInvNo.Text = ds.Tables("cdata").Rows(0).Item("InvNo")
                txtInvDate.Text = ds.Tables("cdata").Rows(0).Item("date")
                txtInvDueDate.Text = ds.Tables("cdata").Rows(0).Item("DueDate")
                txtInvBillToParty.Tag = ds.Tables("cdata").Rows(0).Item("cltrecid")
                txtInvBillToParty.Text = ds.Tables("cdata").Rows(0).Item("Client")
                txtInvNote.Text = ds.Tables("cdata").Rows(0).Item("rem")
                radSBar1.Text = "Created By " & ds.Tables("cdata").Rows(0).Item("createdby")
                radSBarCreatedOn.Text = "Created On " & ds.Tables("cdata").Rows(0).Item("createddate")
                radSBar2.Text = "Updated By/On " & ds.Tables("cdata").Rows(0).Item("updtby") & " " & ds.Tables("cdata").Rows(0).Item("updton")
                txtInvAdvancePaid.Text = ds.Tables("cdata").Rows(0).Item("advanceamount")
            End If
        Catch ex As Exception
            lblInvMessage.Text = ex.Message
        End Try
        Me.Cursor = Cursors.Default
        Call FillInvGrid()
        frmWaitForm.Close()
        txtInvNote.Focus()
        txtInvNote.SelectAll()
    End Sub
    Private Sub FillInvGrid()
        Dim dsx As New DataSet
        sql_String = "select v.[Description], v.[vat sell] [VAT], v.[revenue] [Amount], v.[vat sell]+v.[revenue] [Total], v.sellrefno [Ref#], v.recid,v.invno"
        sql_String += " from viewbillingitems v where v.actrecid=" & txtInvJobNumber.Tag & " and v.invno=" & txtInvNo.Text
        sql_String += " order by v.recid"
        Try
            Me.Cursor = Cursors.WaitCursor
            dsx = setDataList(sql_String)
            If dsx.Tables(0).Rows.Count > 0 Then
                With DGridViewInv
                    .DataSource = Nothing
                    .DataSource = dsx.Tables(0)

                    .Columns("recid").Visible = False
                    .Columns("invno").Visible = False
                    '  .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
                    DGridViewInv.Columns(0).Width = 279
                    .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                    .RowHeadersVisible = False

                    .Columns("vat").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Columns("amount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Columns("total").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Font = New Font("Arial", 8, FontStyle.Bold)
                    .RowsDefaultCellStyle.Font = New Font("Arial", 8, FontStyle.Regular)
                    .Visible = True
                End With
            End If
            sql_String = "select sum([vat sell]) [vat], sum(revenue) [rev], sum([vat sell])+sum(revenue) [invamt] from [viewbillingitems] v "
            sql_String += " where v.actrecid=" & txtInvJobNumber.Tag & " and v.invno=" & txtInvNo.Text
            dsx = setDataList(sql_String)
            If dsx.Tables(0).Rows.Count > 0 Then
                txtInvTotalVAT.Text = dsx.Tables("cdata").Rows(0).Item("vat")
                txtInvTotalAmt.Text = dsx.Tables("cdata").Rows(0).Item("invamt")
            End If


            Me.Cursor = Cursors.Default
        Catch ex As Exception
            lblInvMessage.Text = Err.Description
            Me.Cursor = Cursors.Default
            Return
        End Try
    End Sub

    Private Sub clsInvTab()
        txtInvNo.Tag = 0
        txtInvNo.Clear()
        txtInvDate.SetToNullValue()
        txtInvDueDate.SetToNullValue()
        txtInvBillToParty.Tag = 0
        txtInvBillToParty.Clear()
        txtInvNote.Clear()
        txtInvAdvancePaid.Text = 0
        txtInvTotalAmt.Text = 0
        txtInvTotalVAT.Text = 0
        radSBar1.Text = "Created By " & appUserInfo.Name
        radSBarCreatedOn.Text = ""
        radSBar2.Text = ""
        lblInvStatus.Text = ""
        lblInvMsg2.Text = ""
        lblMessage.Text = ""
        lblMsgInvTBills.Text = ""

        DGridInvTBills.DataSource = Nothing
        DGridInvTBills.Visible = False
        DGridViewInv.DataSource = Nothing
        txtInvTBillInvNo.Text = 0
        txtInvTBillsTotal.Text = 0
        TxtInvTBillsTotalVAT.Text = 0
        txtInvTBillsTotalTrips.Text = 0
    End Sub

    Private Function GenInvNo() As Integer
        Dim invno As Integer = 0
        Dim ds As New DataSet
        Try
            sql_String = "select isnull(max(invno)+1,1) [inv] from dbo.billingInvoiceDetail where invtype=0 and branchID=" & appCompanyInfo.branchID & ";"
            Me.Cursor = Cursors.WaitCursor
            ds = setDataList(sql_String)
            If ds.Tables(0).Rows.Count > 0 Then invno = ds.Tables("cdata").Rows(0).Item("inv")
        Catch ex As Exception
            lblInvMessage.Text = ex.Message
        End Try
        Me.Cursor = Cursors.Default
        Return invno
    End Function
    Private Function SaveInvoice() As Boolean
        PanelInvTabControl.Enabled = True
        btnInvCreateInvoice.Tag = 0
        sql_String = "select * from billingInvoiceDetail where recid=" & txtInvNo.Tag
        Dim adapter As New SqlDataAdapter
        Dim ds As New DataSet
        Dim dr As DataRow
        Dim minvno As Integer = 0
        Dim cmdbuilder As SqlCommandBuilder
        Try
            frmWaitForm.lblTitle.Text = "Saving Data Please Wait..!"
            frmWaitForm.Show()
            frmWaitForm.Refresh()
            Me.Cursor = Cursors.WaitCursor

            cmdbuilder = New SqlCommandBuilder(adapter)
            With adapter
                .SelectCommand = New SqlCommand(sql_String, sql_CNN)
                .Fill(ds)
            End With

            If ds.Tables(0).Rows.Count = 0 Then
                minvno = GenInvNo()
                btnInvCreateInvoice.Tag = minvno
                dr = ds.Tables(0).NewRow 'addnew
                ds.Tables(0).Rows.Add(dr) 'add the row to dataset
                dr.Item("actRecID") = txtInvJobNumber.Tag
                dr.Item("branchID") = appCompanyInfo.branchID
                dr.Item("InvNo") = minvno
                dr.Item("actNo") = ActNoStr
                dr.Item("createdBy") = appUserInfo.Name
                dr.Item("InvType") = 0
                dr.Item("InvDate") = Today.Date
                dr.Item("InvDueDate") = Today.Date
                dr.Item("InvRefNo") = txtInvJobNumber.Text
                dr.Item("InvNoStr") = setInvoiceNoFormat(minvno)
            Else
                dr = ds.Tables(0).Rows(0) 'get record pointer
            End If
            If IsDate(txtInvDate.Text) Then dr.Item("InvDate") = txtInvDate.Text
            If IsDate(txtInvDueDate.Text) Then dr.Item("InvDueDate") = txtInvDueDate.Text
            dr.Item("InvRemarks") = txtInvNote.Text
            dr.Item("AdvanceAmount") = txtInvAdvancePaid.Text

            adapter.Update(ds)
            'insert default TRK invoice item in billing against job in billing table
            If txtInvNo.Tag = 0 Then
                sql_String = " Insert into [billing] (actRecID,actNo,branchID,slno,elementID,elementSName,elementName,sellCurr,orgIsReceivableAccountRecID,createdBy,"
                sql_String += " sellInvoiceNo,sellInvoiceNoForCost)"
                sql_String += " Values(" & txtInvJobNumber.Tag & ",'" & ActNoStr & "'," & appCompanyInfo.branchID & ",1,364,'TRK',"
                sql_String += " 'Trucking & Transportation','SAR'," & orgInvRecID & ",'" & appUserInfo.Name & "',"
                sql_String += minvno & "," & minvno & ");"
                '                MsgBox(sql_String)
                Dim cmdx As New SqlCommand(sql_String, sql_CNN)
                cmdx.ExecuteNonQuery()
            End If
            lblInvMsg2.Text = "Invoice Save Complete!"

            Me.Cursor = Cursors.Default
            frmWaitForm.Close()
            Return True
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            lblInvMessage.Text = ex.Message ' "Not Saved!"
            frmWaitForm.Close()
            Return False
        End Try
    End Function
    Private Sub txtInvAdvancePaid_GotFocus(sender As Object, e As EventArgs) Handles txtInvAdvancePaid.GotFocus
        txtInvAdvancePaid.SelectAll()
    End Sub

    Private Sub btnInvEdit_Click(sender As Object, e As EventArgs) Handles btnInvEdit.Click
        PanelInvHeaderTab.Enabled = True
        PanelInvTabControl.Enabled = True
        txtInvDate.Focus()

    End Sub

    Private Sub lnkInvAddChargeItem_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkInvAddChargeItem.LinkClicked
        If txtInvNo.Tag = 0 Then Return
        lblInvMsg2.Text = ""
        If txtInvBillToParty.Tag = 0 Then lblInvMsg2.Text = "Bill To Party is missing" : Return
        Dim frm As New frmInvoiceSellingChargeList(0, txtInvNo.Text, ActNoStr, txtInvBillToParty.Tag, txtInvJobNumber.Tag, lblInvActNo.Text)
        frm.ShowDialog()
        Call FillInvGrid()
        DGridViewInvList.Rows(DGridViewInvList.Rows.Count - 1).Selected = True
        DGridViewInvList.CurrentCell = DGridViewInvList.Rows(DGridViewInvList.Rows.Count - 1).Cells(0)
    End Sub

    Private Sub btnInvSave_Click(sender As Object, e As EventArgs) Handles btnInvSave.Click
        If Not chkInvSave() Then Return
        Call SaveInvoice()
        Call FillInvList()
        PanelInvHeaderTab.Enabled = False
    End Sub
    Private Function chkInvSave() As Boolean
        Dim msg As String = ""
        If Not IsDate(txtInvDate.Text) Then msg = "Invalid Invoice Date" : GoTo a
        If String.IsNullOrEmpty(txtInvNo.Text) Then msg = "Invalid Invoice No" : GoTo a
        Return True
        Exit Function
a:
        lblInvMsg2.Text = msg
        Return False
    End Function

    Private Sub DGridViewInv_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGridViewInv.CellDoubleClick
        Dim rowid As Integer = 0
        lblInvMsg2.Text = ""
        If txtInvBillToParty.Tag = 0 Then lblInvMsg2.Text = "Bill To Party is missing" : Return

        rowid = DGridViewInv.Rows(e.RowIndex).Cells("recid").Value
        If rowid > 0 Then
            Dim frm As New frmInvoiceSellingChargeList(rowid, txtInvNo.Text, txtInvJobNumber.Text, txtInvBillToParty.Tag, txtInvJobNumber.Tag, lblInvActNo.Text)
            frm.ShowDialog()
            Call FillInvGrid()
        End If

    End Sub

    Private Sub btnInvTBillsSubmit_Click(sender As Object, e As EventArgs) Handles btnInvTBillsSubmit.Click
        Dim mstr As String = ""
        txtInvTBillsTotal.Text = 0
        txtInvTBillsTotalTrips.Text = 0
        TxtInvTBillsTotalVAT.Text = 0
        DGridInvTBills.DataSource = Nothing
        DGridInvTBills.Visible = False

        lblMsgInvTBills.Text = ""
        chkInvTBillsUnbilled.Tag = 0
        If Not IsNumeric(txtInvNo.Text) Then txtInvNo.Text = 0
        If txtInvJobNumber.Tag = 0 Or txtInvJobNumber.Text = 0 Then lblMsgInvTBills.Text = "Job Number is Required" : Return

        If cmbInvTBillsFilter.SelectedIndex = 0 Then 'by loading dt
            If Not IsDate(txtInvTBillsDate1.Text) Then lblMsgInvTBills.Text = "Enter From Loading Date" : Return
            If Not IsDate(txtInvTBillsDate2.Text) Then lblMsgInvTBills.Text = "Enter To Loading Date" : Return
            mstr = " and [Date] between '" & Date.Parse(txtInvTBillsDate1.Text).ToString("yyyy'/'MM'/'dd") & "' and '" & Date.Parse(txtInvTBillsDate2.Text).ToString("yyyy'/'MM'/'dd") & "'"
            mstr += IIf(chkInvTBillsUnbilled.Checked, " and InvNo=0", "")
        ElseIf cmbInvTBillsFilter.SelectedIndex = 1 Then 'by inv
            If Not IsNumeric(txtInvTBillInvNo.Text) Then txtInvTBillInvNo.Text = 0
            If txtInvTBillInvNo.Text = 0 Then lblMsgInvTBills.Text = "Invoice Number is Required" : Return
            'validate invoice number
            If txtInvNo.Text = 0 Then lblMsgInvTBills.Text = "First Select Invoice in [Invoice Header] Tab" : Return
            If txtInvNo.Tag = 0 Then lblMsgInvTBills.Text = "First Select Invoice in [Invoice Header] Tab" : Return
            If txtInvTBillInvNo.Text <> txtInvNo.Text Then lblMsgInvTBills.Text = "Entered Invoice Number is not select in [Invoice Header] Tab" : Return
            mstr = " and [InvNo]=" & txtInvTBillInvNo.Text
        End If

        sql_String = "select v.[waybill#],v.[Date],v.VehCode,v.[From],v.[To], sum(VatAmt) [VatAmt], sum(Amount) [Amt],[Vat%],InvNo,branchid,wbid"
        sql_String += " from viewWaybillRevenueTTS v where wbcancelled=0 and branchid=" & appCompanyInfo.branchID & " and actrecid=" & txtInvJobNumber.Tag
        sql_String += mstr
        sql_String += " group by [waybill#],[date],vehcode,[from],[to],[vat%],InvNo,branchid,wbid"

        Dim dsx As New DataSet
        Try
            frmWaitForm.lblTitle.Text = "Loading Data Please Wait..!"
            frmWaitForm.Show()
            frmWaitForm.Refresh()
            Me.Cursor = Cursors.WaitCursor
            dsx = setDataList(sql_String)
            If dsx.Tables(0).Rows.Count > 0 Then
                With DGridInvTBills
                    .DataSource = Nothing
                    .DataSource = dsx.Tables(0)

                    .Columns("branchid").Visible = False
                    .Columns("wbid").Visible = False
                    .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
                    .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                    .RowHeadersVisible = False
                    .ReadOnly = True
                    .Columns("VatAmt").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Columns("Amt").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Columns("Vat%").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Font = New Font("Arial", 8, FontStyle.Bold)
                    .RowsDefaultCellStyle.Font = New Font("Arial", 8, FontStyle.Regular)
                    .Visible = True
                End With
                If chkInvTBillsUnbilled.CheckState = CheckState.Checked Then chkInvTBillsUnbilled.Tag = 1


                'get totals
                sql_String = "select  sum(VatAmt) [vat], sum(Amount) [amt] from viewWaybillRevenueTTS where branchid=" & appCompanyInfo.branchID & " and actrecid=" & txtInvJobNumber.Tag
                sql_String += mstr
                dsx = setDataList(sql_String)
                If dsx.Tables(0).Rows.Count > 0 Then
                    txtInvTBillsTotalTrips.Text = DGridInvTBills.Rows.Count
                    txtInvTBillsTotal.Text = dsx.Tables("cdata").Rows(0).Item("amt")
                    txtInvTBillsTotal.Text = Format(CDbl(txtInvTBillsTotal.Text), "###,###.00")

                    TxtInvTBillsTotalVAT.Text = dsx.Tables("cdata").Rows(0).Item("vat")
                    TxtInvTBillsTotalVAT.Text = Format(CDbl(TxtInvTBillsTotalVAT.Text), "###,###.00")
                End If
            End If

            Me.Cursor = Cursors.Default
            frmWaitForm.Close()
        Catch ex As Exception
            lblMsgInvTBills.Text = Err.Description
            frmWaitForm.Close()
            Me.Cursor = Cursors.Default
            Return
        End Try

    End Sub
    Private Sub cmbInvTBillsFilter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbInvTBillsFilter.SelectedIndexChanged
        If cmbInvTBillsFilter.SelectedIndex = 0 Then 'loading dt
            PanelInvTBillsDates.Visible = True
            chkInvTBillsUnbilled.Visible = True
            txtInvTBillsDate1.Focus()
        ElseIf cmbInvTBillsFilter.SelectedIndex = 1 Then 'inv 
            PanelInvTBillsDates.Visible = False
            chkInvTBillsUnbilled.Visible = False
            txtInvTBillInvNo.Focus()
        End If
    End Sub

    Private Sub btnInvTBillsAttach_Click(sender As Object, e As EventArgs) Handles btnInvTBillsAttach.Click
        Try
            Dim rstr As String = ""
            lblMsgInvTBills.Text = ""
            rstr = txtInvTBillsTotalTrips.Text & " Trips " & txtInvTBillsDate1.Text & " To " & txtInvTBillsDate2.Text
            If cmbInvTBillsFilter.SelectedIndex <> 0 Then lblMsgInvTBills.Text = "Select Transport Bills by Date" : cmbInvTBillsFilter.Focus() : Return 'inv
            If txtInvJobNumber.Tag = 0 Then lblMsgInvTBills.Text = "Missing Job Number, Search again and try" : Return
            If txtInvBillToParty.Tag = 0 Then lblMsgInvTBills.Text = "Bill To Party is missing, Search again and try" : Return
            If txtInvNo.Tag = 0 Then lblMsgInvTBills.Text = "First Select Invoice in [Invoice Header] Tab" : Return
            If chkInvTBillsUnbilled.CheckState = CheckState.Unchecked Then lblMsgInvTBills.Text = "List Waybills with Check Unbilled Option and Try Again" : Return
            If chkInvTBillsUnbilled.Tag = 0 Then lblMsgInvTBills.Text = "List Waybills with Check Unbilled Option and Try Again" : Return
            If DGridInvTBills.Rows.Count < 1 Then lblMsgInvTBills.Text = "No Bills to transfer" : Return
            sql_String = "The Amount [" & txtInvTBillsTotal.Text & "] of [" & txtInvTBillsTotalTrips.Text & "] Trips will be added to the Invoice Line Item. Do you want to Proceed ?"
            If MsgBox(sql_String, MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Add Transport Bills Request") = MsgBoxResult.No Then Return

            frmWaitForm.lblTitle.Text = "Processing Request. please wait..!"
            frmWaitForm.Show()
            frmWaitForm.Refresh()
            Me.Cursor = Cursors.WaitCursor

            If sql_CNN.State = ConnectionState.Closed Then createConnection()
            Dim sqlcmd As SqlCommand = sql_CNN.CreateCommand()


            'insert row in billing and then update invno in waybills
            sql_String = ""
            sql_String = " Insert into [billing] (actRecID,actNo,branchID,slno,elementID,elementSName,elementName,sellCurr,orgIsReceivableAccountRecID,createdBy,"
            sql_String += " sellInvoiceNo,sellInvoiceNoForCost,sellamtlocal,sellvatamount,sellrefno,sellvatpercentage,linkedtowaybills)"
            sql_String += " Values(" & txtInvJobNumber.Tag & ",'" & ActNoStr & "'," & appCompanyInfo.branchID & ",1,364,'TRK',"
            sql_String += " 'Trucking & Transportation','SAR'," & txtInvBillToParty.Tag & ",'" & appUserInfo.Name & "',"
            sql_String += txtInvNo.Text & "," & txtInvNo.Text & "," & CDbl(txtInvTBillsTotal.Text) & "," & CDbl(TxtInvTBillsTotalVAT.Text) & ",'" & rstr & "'," & appCompanyInfo.VATPercentage & ",1);"
            '        MsgBox(sql_String)
            sqlcmd.CommandText = sql_String
            sqlcmd.ExecuteNonQuery()

            'get newly added recid into var
            Dim dsi As New DataSet()
            Dim newid As Integer = 0
            sql_String = "SELECT SCOPE_IDENTITY() AS [recid]; "
            dsi = setDataList(sql_String)
            If dsi.Tables(0).Rows.Count > 0 Then newid = dsi.Tables(0).Rows(0).Item("recid")

            'update invno in waybills table
            rstr = ""
            For ctr = 0 To DGridInvTBills.Rows.Count - 1
                rstr += DGridInvTBills.Rows(ctr).Cells("wbid").Value & ","
            Next ctr
            sql_String = "update [waybills] set wbpost=1,wbstatus='BILLED',  invno=" & txtInvNo.Text & ",billingRecID=" & newid & " where recid in (" & rstr & "0) and actrecid=" & txtInvJobNumber.Tag
            sqlcmd.CommandText = sql_String
            sqlcmd.ExecuteNonQuery()

            'finally remove waybillcosting table recs where no cost and revenue found
            sql_String = "delete from [waybillcosting] where wbid in (" & rstr & "0) and cost=0 and revenue=0 and vat=0 and vatcost=0"
            sqlcmd.CommandText = sql_String
            sqlcmd.ExecuteNonQuery()


            'remove single TRK with 0 sell amount if found
            sql_String = "delete from billing where sellinvoiceno=" & txtInvNo.Text & " and actrecid=" & txtInvJobNumber.Tag & " and elementSName='TRK' and sellamtlocal=0"
            sqlcmd.CommandText = sql_String
            sqlcmd.ExecuteNonQuery()

            txtInvTBillInvNo.Tag = 0
            txtInvTBillsTotal.Text = 0 : txtInvTBillsTotalTrips.Text = 0 : TxtInvTBillsTotalVAT.Text = 0
            DGridInvTBills.DataSource = Nothing
            DGridInvTBills.Visible = False
            lblMsgInvTBills.Text = "Success! Transport Bills added to Invoice"

            Call FillInvGrid()


            frmWaitForm.Close()
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            frmWaitForm.Close()
            Me.Cursor = Cursors.Default
            lblMsgInvTBills.Text = ex.Message
        End Try


        'refresh invoice grid on tab1

    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.SelectedIndex = 1 Then 'tbills
            If String.IsNullOrEmpty(cmbInvTBillsFilter.Text) Then cmbInvTBillsFilter.SelectedIndex = 0
            If Not IsDate(txtInvTBillsDate1.Text) Then txtInvTBillsDate1.Text = firstDay
        End If
    End Sub
#Region "Crystal Report Viewer Section"
    Private Sub ConfigureCrystalReports(rptName As String, rptFormula As String, blShowGroupTree As Boolean)
        Try
            lblInvMessage.Text = ""
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
            lblInvMessage.Text = ex.Message
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

    Private Sub lnkPrintInvoice_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkPrintInvoice.LinkClicked
        Dim rptFullPath As String = ""
        lblInvMsg2.Text = ""
        Dim invno As Integer = 0
        CrystalReportViewer2.Visible = True
        rptFullPath = Application.StartupPath & IIf(True, appCompanyInfo.customizerptpath, "\reports") & "\" & "iffARBillTTS.rpt"
        Try
            If DGridViewInv.Rows.Count > 0 Then
                invno = txtInvNo.Text
                If invno < 1 Then Return
                Dim rptformula As String = ""
                '{viewARBillForFinalPrintTTS.InvNo} = 3
                rptformula = "{viewARBillForFinalPrintTTS.InvNo} = " & txtInvNo.Text
                TabControl1.SelectedIndex = 2
                CrystalReportViewer2.Visible = True
                ConfigureCrystalReports(rptFullPath, rptformula, False)
                'CrystalReportViewer2.Zoom(1) 'pgwidth

            End If

        Catch ex As Exception
            lblInvMsg2.Text = ex.Message
        End Try
    End Sub

    Private Sub lnkPrintTransportBills_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkPrintTransportBills.LinkClicked
        Dim rptFullPath As String = ""
        lblInvMsg2.Text = ""
        Dim invrecid As Integer = 0
        If Not IsNumeric(txtInvNo.Tag) Then txtInvNo.Tag = 0
        If txtInvNo.Tag < 1 Then lblInvMsg2.Text = "Select Invoice" : Return
        CrystalReportViewer2.Visible = True
        rptFullPath = Application.StartupPath & IIf(True, appCompanyInfo.customizerptpath, "\reports") & "\" & "iffTransportBills.rpt"
        Try
            If DGridViewInv.Rows.Count > 0 Then
                invrecid = txtInvNo.Tag
                If invrecid < 1 Then Return
                Dim rptformula As String = ""
                '{viewARBillForFinalPrintTTS.InvNo} = 3
                rptformula = "{viewWaybillRevenueTTS.invrecid}= " & invrecid
                TabControl1.SelectedIndex = 2
                ConfigureCrystalReports(rptFullPath, rptformula, False)
            End If

        Catch ex As Exception
            lblInvMsg2.Text = ex.Message
        End Try

    End Sub
    Private Sub txtInvTBillsDate2_GotFocus(sender As Object, e As EventArgs) Handles txtInvTBillsDate2.GotFocus
        If Not IsDate(txtInvTBillsDate2.Text) Then txtInvTBillsDate2.Text = Today.Date
    End Sub


    Private Function setInvoiceNoFormat(intInvNo As Integer) As String
        Dim invstr As String = ""
        If intInvNo > 0 Then invstr = appCompanyInfo.branchCode & intInvNo.ToString.PadLeft(5, "0"c)
        Return invstr
    End Function

    Private Function GetCountryName(strcountrycode As String) As String
        Dim ds As New DataSet
        Dim strval As String = ""
        Try
            sql_String = "select name  from dbo.countries where shortname='" & strcountrycode & "';"
            Me.Cursor = Cursors.WaitCursor
            ds = setDataList(sql_String)
            If ds.Tables(0).Rows.Count > 0 Then strval = ds.Tables("cdata").Rows(0).Item("name")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try
        Me.Cursor = Cursors.Default
        Return strval
    End Function

#Region "CountryAndCity2"
    Private Sub cmbPOLCountry2_LostFocus(sender As Object, e As EventArgs) Handles cmbPOLCountry2.LostFocus
        If cmbPOLCountry2.SelectedValue <> "" Then
            cmbPOLCountry2.Tag = 0
            Dim selectedRow As GridViewDataRowInfo = DirectCast(cmbPOLCountry2.SelectedItem, GridViewDataRowInfo)
            cmbPOLCountry2.Tag = (selectedRow.Cells("recid").Value.ToString())
            cmbPOLCountry2.Text = (selectedRow.Cells("shortname").Value.ToString())
            refresh_cities(cmbPOLCountry2.Text, cmbPOLCity2)
        End If
    End Sub

    Private Sub cmbPODCountry2_LostFocus(sender As Object, e As EventArgs) Handles cmbPODCountry2.LostFocus
        If cmbPODCountry2.SelectedValue <> "" Then
            Dim selectedRow As GridViewDataRowInfo = DirectCast(cmbPODCountry2.SelectedItem, GridViewDataRowInfo)
            cmbPODCountry2.Tag = (selectedRow.Cells("recid").Value.ToString())
            cmbPODCountry2.Text = (selectedRow.Cells("shortname").Value.ToString())
            refresh_cities(cmbPODCountry2.Text, cmbPODCity2)
        End If
    End Sub

    Private Sub cmbPODCity2_LostFocus(sender As Object, e As EventArgs) Handles cmbPODCity2.LostFocus
        If cmbPODCity2.SelectedValue <> "" Then
            Dim selectedRow As GridViewDataRowInfo = DirectCast(cmbPODCity2.SelectedItem, GridViewDataRowInfo)
            cmbPODCity2.Tag = (selectedRow.Cells("id").Value.ToString())
            cmbPODCity2.Text = (selectedRow.Cells("name").Value.ToString())
            lblUnloco2.Text = (selectedRow.Cells("code").Value.ToString())
            If String.IsNullOrEmpty(txtDeliveryAddressWB.Text) Then txtDeliveryAddressWB.Text = cmbPODCity2.Text

        End If
    End Sub

    Private Sub cmbPOLCity2_LostFocus(sender As Object, e As EventArgs) Handles cmbPOLCity2.LostFocus
        If cmbPOLCity2.SelectedValue <> "" Then
            Dim selectedRow As GridViewDataRowInfo = DirectCast(cmbPOLCity2.SelectedItem, GridViewDataRowInfo)
            cmbPOLCity2.Tag = (selectedRow.Cells("id").Value.ToString())
            cmbPOLCity2.Text = (selectedRow.Cells("name").Value.ToString())
            lblUnloco1.Text = (selectedRow.Cells("code").Value.ToString())
            If String.IsNullOrEmpty(txtLoadingAddressWB.Text) Then txtLoadingAddressWB.Text = cmbPOLCity2.Text
        End If
    End Sub

    Private Sub refresh_cities(iCountryCode As String, cmbName As Object)
        If iCountryCode = "" Then lblMessage.Text = "Invalid Country Code" : Exit Sub
        Me.Cursor = Cursors.WaitCursor
        sql_String = " select area  name, unloco  code, recid  id, countrycode from [locationmaster] where isActive=1 and countrycode='" & iCountryCode & "' order by name"
        Call fillCombo(cmbName, sql_String, 0, 300, 100, 50)
        ' cmbName.Columns(2).VisibleInColumnChooser = False
        cmbName.Tag = 0 : cmbName.Text = ""
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub refresh_country()
        Me.Cursor = Cursors.WaitCursor
        sql_String = "select shortname, name, recid from countries where recid in (select distinct countryID from cities) order by name"
        Call fillCombo(cmbPOLCountryCode, sql_String, 300, 300, 100, 300)
        cmbPOLCountryCode.Columns(2).VisibleInColumnChooser = False
        cmbPOLCountryCode.Tag = 0 : cmbPOLCountryCode.Text = ""
        strpolcountryname = ""
        Call fillCombo(CmbPODCountryCode, sql_String, 300, 300, 100, 300)
        CmbPODCountryCode.Columns(2).VisibleInColumnChooser = False
        CmbPODCountryCode.Tag = 0 : CmbPODCountryCode.Text = ""
        strpodcountryname = ""
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub refresh_country2()
        Me.Cursor = Cursors.WaitCursor
        sql_String = "select shortname, name, recid from countries where shortname in (select distinct countrycode from unloco) order by name"
        '        sql_String = "select shortname, name, recid from countries where recid in (select distinct countryID from cities) order by name"
        Call fillCombo(cmbPOLCountry2, sql_String, 0, 300, 100, 300)
        cmbPOLCountry2.Columns(2).VisibleInColumnChooser = False
        cmbPOLCountry2.Tag = 0 : cmbPOLCountry2.Text = ""
        strpolcountryname = ""
        Call fillCombo(cmbPODCountry2, sql_String, 0, 300, 100, 300)
        cmbPODCountry2.Columns(2).VisibleInColumnChooser = False
        cmbPODCountry2.Tag = 0 : cmbPODCountry2.Text = ""
        strpodcountryname = ""
        Me.Cursor = Cursors.Default
    End Sub
#End Region


    Private Sub DgridWaybillList_CellDoubleClick(sender As Object, e As GridViewCellEventArgs) Handles DgridWaybillList.CellDoubleClick
        recID = DgridWaybillList.Rows(e.RowIndex).Cells("wbid").Value
            If recID > 0 Then Call callWaybillUpdate(recID)
    End Sub
    Private Sub DgridWaybillList_KeyDown(sender As Object, e As KeyEventArgs) Handles DgridWaybillList.KeyDown
        If e.KeyCode = Keys.Enter Then
            Try
                If Not IsNothing(DgridWaybillList.CurrentRow.Index) Then
                    recID = DgridWaybillList.Rows(DgridWaybillList.CurrentRow.Index).Cells("wbid").Value
                    If recID > 0 Then Call callWaybillUpdate(recID)
                End If

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try
        End If
    End Sub
    Private Sub callWaybillUpdate(recid As Integer)
        Try
            Dim frm As New frmUpdateWaybill(recid, txtJobNumberSearchWB.Tag)
            frm.ShowDialog(Me)
            frm.Focus()
            btnSearchWaybillsList.PerformClick()
            DgridWaybillList.Focus()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "callWaybillUpdate(...")
        End Try
    End Sub

    Private Sub radGridNewJob_CellDoubleClick(sender As Object, e As GridViewCellEventArgs) Handles radGridNewJob.CellDoubleClick
        Call callShowWaybillList()

        'ActNoINT = 0
        'recID = 0
        'Dim rtnval As Boolean = False
        'Try
        '    '  recID = radGridNewJob.Rows(e.RowIndex).Cells("actrecid").Value
        '    'ActNoINT = radGridNewJob.Rows(e.RowIndex).Cells("jobRunningNo").Value
        '    'txtJobNumberSearchWB.Text = ActNoINT

        '    'lblMessageTabWB.Text = "Found One Job"
        '    'txtJobNumberSearchWB.Tag = recID
        '    'txtJobNumberSearchWB.BackColor = Color.LemonChiffon
        '    'lblFormTitle.Text = radGridNewJob.Rows(e.RowIndex).Cells("Job No").Value
        '    'picChecked.Visible = True
        '    'btnViewTransportWaybills.Enabled = True
        '    'btnGenerateWaybills.Enabled = True
        '    'PanelNewJobList.Visible = False
        '    'Call btnViewTransportWaybills_Click(sender, e)

        'Catch ex As Exception
        '    MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        'End Try
    End Sub


    Private Sub radGridNewJob_KeyDown(sender As Object, e As KeyEventArgs) Handles radGridNewJob.KeyDown
        If e.KeyCode = Keys.Enter Then Call callShowWaybillList()
    End Sub
    Private Sub callShowWaybillList()
        ActNoINT = 0
        recid = 0
        Try
            recID = radGridNewJob.Rows(radGridNewJob.CurrentRow.Index).Cells("actrecid").Value
            If recID > 0 Then
                ActNoINT = radGridNewJob.Rows(radGridNewJob.CurrentRow.Index).Cells("jobRunningNo").Value
                txtJobNumberSearchWB.Text = ActNoINT

                lblMessageTabWB.Text = "Found One Job"
                txtJobNumberSearchWB.Tag = recID
                txtJobNumberSearchWB.BackColor = Color.LemonChiffon
                lblFormTitle.Text = radGridNewJob.Rows(radGridNewJob.CurrentRow.Index).Cells("Job No").Value
                picChecked.Visible = True
                btnViewTransportWaybills.Enabled = True
                btnGenerateWaybills.Enabled = True
                PanelNewJobList.Visible = False
                Call btnViewTransportWaybills_Click(Nothing, Nothing)
                'now focus on first row
                If DgridWaybillList.Rows.Count > 0 Then
                    DgridWaybillList.Rows(0).IsSelected = True
                    DgridWaybillList.Focus()
                End If


            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "callShowWaybillList(...")
        End Try
    End Sub

    Private Sub radGridShipmentList_CellDoubleClick(sender As Object, e As GridViewCellEventArgs) Handles radGridShipmentList.CellDoubleClick
        Call OpenShipmentTab()
    End Sub
    Private Sub OpenShipmentTab()
        ActNoINT = 0
        recID = 0
        Dim rtnval As Boolean = False

        Try
            recID = radGridShipmentList.Rows(radGridShipmentList.CurrentRow.Index).Cells("actrecidx").Value
            If recID > 0 Then
                ActNoINT = radGridShipmentList.Rows(radGridShipmentList.CurrentRow.Index).Cells("jobRunningNo").Value
                rtnval = GetJobFile(recID)
                If rtnval Then
                    TabControlMain.SelectedIndex = 1 'show shipment record
                End If
                radBox1.Enabled = False
                radBox2.Enabled = False
                radBox3.Enabled = False
                btnEditThisJob.Visible = True
                btnEditThisJob.BringToFront()
                btnSave.Enabled = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try

    End Sub

    Private Sub radGridShipmentList_KeyDown(sender As Object, e As KeyEventArgs) Handles radGridShipmentList.KeyDown
        If e.KeyCode = Keys.Enter Then Call OpenShipmentTab()
    End Sub

    Private Sub radGridNewJob_Click(sender As Object, e As EventArgs) Handles radGridNewJob.Click

    End Sub

    Private Sub cmbPOLCountryCode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPOLCountryCode.SelectedIndexChanged

    End Sub

    Private Sub cmbPOLCity_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPOLCity.SelectedIndexChanged

    End Sub
End Class