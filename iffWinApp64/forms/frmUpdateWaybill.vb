'Waybill/ProofOfDelivery POD Form developed for TransArab And JEDEX
'27-July-2018 - Today is my birthday :-) home alone
Imports Telerik.WinControls.UI
Imports System.Data.Sql
Imports System.Data
Imports System.Data.SqlClient
Imports System.Exception
Imports System.Data.OleDb
Imports System.IO
Imports Excel = Microsoft.Office.Interop.Excel

Public Class frmUpdateWaybill
    Dim recID As Integer = 0
    Dim actRecID As Integer = 0
    Dim orgRecID As Integer = 0
    Dim action As String = ""
    Dim ds As New DataSet
    Dim appPath As String = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase)
    Dim wbBillingDataExists As Boolean = False

    Dim locid1 As Integer = 0
    Dim locid2 As Integer = 0
    Dim wbPost As Boolean = False
    Dim wbCancelled As Boolean = False

    Dim POLOrgAddrRecID As Integer
    Dim PODOrgAddrRecID As Integer
    Dim POLOrgRecID As Integer
    Dim PODOrgRecID As Integer




    Public Sub New(mWBRecID As Integer, mActRecID As Integer)
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        recID = mWBRecID
        actRecID = mActRecID
    End Sub

    Private Sub frmUpdateWaybill_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        txtActCommodityWB.Focus()
        txtActCommodityWB.SelectAll()
    End Sub

    Private Sub frmUpdateWaybill_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        ' Me.Dispose()
    End Sub

    Private Sub frmUpdateWaybill_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.Control Then
            If e.KeyCode = Keys.S Then btnSaveAnPrint.PerformClick()
            If e.KeyCode = Keys.P Then btnPrint.PerformClick()
        End If
        If e.KeyCode = Keys.Escape Then If MsgBox("Close Waybill Form?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Close Request") = MsgBoxResult.Yes Then Me.Close()
    End Sub

    Private Sub frmUpdateWaybill_Load(sender As Object, e As EventArgs) Handles Me.Load

        appPath = New Uri(appPath).LocalPath
        Call clearForm()
        Call initFormLoad()
        If recID > 0 Then
            Call QueryWaybillData()
            txtActCommodityWB.Focus()
            txtActCommodityWB.SelectAll()
        End If

        'user rights
        If Not appUserInfo.isAdmin Then
            btnCreateBillingData.Enabled = appUserRights.landbillAccess
            PanelCreateBillingButton.Enabled = appUserRights.landbillAccess
            PanelWaybillFrame.Enabled = appUserRights.landUpdateWaybill
            btnSaveAnPrint.Enabled = appUserRights.landUpdateWaybill
            btnPrint.Enabled = appUserRights.landUpdateWaybill
        End If

        If wbPost Then
            Me.Text += " - NOT EDITABLE ALREADY POSTED TO INVOICE"
            lblStatus.Text = "Status - BILLED AND POSTED"
        End If
        If wbCancelled Then
            Me.Text += " - NOT EDITABLE WAYBILL CANCELLED"
            lblStatus.Text = "Status - CANCELLED"
        End If

        If wbPost Or wbCancelled Then
            PanelWaybillFrame.Enabled = False
            Panel1.Enabled = False
        End If

    End Sub

    Private Sub QueryWaybillData()
        If recID < 1 Then Exit Sub
        lblMessage.Text = ""
        cmbDriverName.Visible = False : txtDriverName.Visible = False
        panelEquipmentDetail.Enabled = cmbOrgPlaceOfLoading.Enabled


        PanelMessage.Visible=False
        Me.Cursor = Cursors.WaitCursor
        Try
            Dim dstmp As New DataSet
            sql_String = "select * from [viewQueryWaybillRecord2018] where wbid=" & recID

            dstmp = setDataList(sql_String)
            If dstmp.Tables(0).Rows.Count > 0 Then
                With dstmp.Tables(0).Rows(0)

                    lblStatus.Text = "Status - " & .Item("wbstatus")
                    wbPost = .Item("wbpost")
                    wbCancelled = .Item("wbcancelled")
                    lblInvNo.Text = .Item("invno")
                    lblFormTitle.Text = .Item("job no") & " - " & .Item("Client")
                    lblClientName.Text = .Item("Client")
                    lblClientAddress.Text = .Item("ClientAddress")
                    orgRecID = .Item("cltrecid")
                    lblBatchNo.Text = .Item("batchno")
                    If IsDate(.Item("batchdate")) Then lblBatchDate.Text = .Item("batchdate")
                    lblBatchSlNo.Text = .Item("batchslno")
                    lblJobNumber.Text = .Item("job no") : lblJobNumber.Tag = .Item("actrecid")
                    lblWaybillNumber.Text = .Item("wbno")
                    lblWaybillDate.Text = .Item("wbdate")
                    txtActCommodityWB.Text = .Item("goodsdesc")
                    txtContainerNoWB.Text = .Item("containerNo")
                    txtContainerSizeWB.Text = .Item("containerType")
                    txtContainerTypeWB.Text = .Item("cntrRefNo")

                    txtUnitTypeWB.Text = .Item("goodsunittype")
                    txtQtyWB.Text = .Item("loadQty")
                    txtWeightWB.Text = .Item("netWght")
                    txtVolumeWB.Text = .Item("grossWght")


                    If IsDate(.Item("cntrEmptyReturned")) Then txtContainerReturn.Text = .Item("cntrEmptyReturned")
                    txtTerminalName.Text = .Item("StorageYard")
                    txtEIRNo.Text = .Item("eirno")

                    'cmbOrgPlaceOfLoading.Text = .Item("Consignee") : cmbOrgPlaceOfLoading.Tag = .Item("cneRecId")
                    'cmbOrgPlaceOfDelivery.Text = .Item("Consignee") : cmbOrgPlaceOfDelivery.Tag = .Item("cneRecId")


                    POLOrgRecID = .Item("orgrecidPOL")
                    PODOrgRecID = .Item("orgrecidPOD")
                    cmbOrgPlaceOfLoading.Text = .Item("OrgPOL") : cmbOrgPlaceOfLoading.Tag = POLOrgRecID
                    cmbOrgPlaceOfDelivery.Text = .Item("OrgPOD") : cmbOrgPlaceOfDelivery.Tag = PODOrgRecID
                    lblOrgLoading.Text = cmbOrgPlaceOfLoading.Text
                    lblOrgDelivery.Text = cmbOrgPlaceOfDelivery.Text


                    txtPickupAddress1.Text = .Item("PickupAddress") : lblUnlocoA.Text = .Item("unloco1")
                    txtDeliveryAddress1.Text = .Item("DeliveryAddress") : lblUnlocoB.Text = .Item("unloco2")
                    txtAdditionalRoute.Text = .Item("AdditionalRoute")

                    POLOrgAddrRecID = .Item("polorgaddrrecid")
                    PODOrgAddrRecID = .Item("podorgaddrrecid")

                    cmbPOLCountry.Text = .Item("polcntrycd")
                    cmbPOLCity.Tag = .Item("locid1") : cmbPOLCity.Text = .Item("locarea1")
                    cmbPOdCountry.Text = .Item("podcntrycd")
                    cmbPODCity.Tag = .Item("locid2") : cmbPODCity.Text = .Item("locarea2")

                    lblUnlocoA.Text = .Item("unloco1")
                    lblUnlocoB.Text = .Item("unloco2")

                    txtLoadingAddressWB.Text = txtPickupAddress1.Text : lblUnloco1.Text = lblUnlocoA.Text
                    txtDeliveryAddressWB.Text = txtDeliveryAddress1.Text : lblUnloco2.Text = lblUnlocoB.Text

                    cmbLocalAgentBroker.Text = .Item("Broker") : cmbLocalAgentBroker.Tag = .Item("orgBrokerRecId")
                    txtRefWB.Text = .Item("wbRefNo")

                    If IsDate(.Item("loadingDate")) Then txtExpectedLoadingDate.Text = .Item("loadingDate")
                    txtWaitingTimeLoading.Text = .Item("WaitingTimePOL")

                    txtDriverName.Text = .Item("DriverNameLocal")
                    cmbDriverName.Tag = .Item("DriverRecID")
                    cmbDriverName.Text = txtDriverName.Text
                    txtDriverID.Text = .Item("driverID")
                    txtMobileNumber.Text = .Item("DriverContact")

                    If .Item("companyowntruck") = 0 Then rbCompanyTruck.Checked = True
                    If .Item("companyowntruck") = 1 Then rbRental.Checked = True

                    cmbEquipmentType.Text = .Item("EqpType") : cmbEquipmentType.Tag = .Item("EqpGrpID")
                    cmbEquipmentNumber.Text = .Item("EqpName") : cmbEquipmentNumber.Tag = .Item("EqpRecID")
                    txtPlateNumber.Text = .Item("PlateNo")
                    cmbTransporter.Text = .Item("TransporterName") : cmbTransporter.Tag = .Item("OrgTrnID")

                    lblEqpType1.Text = cmbEquipmentType.Text
                    'lblEqpType2.Text = lblEqpType1.Text

                    If rbCompanyTruck.Checked Then cmbDriverName.Visible = True
                    If rbRental.Checked Then txtDriverName.Visible = True

                    If IsDate(.Item("deliverydate")) Then txtDateOfDelivery.Text = .Item("deliverydate")
                    If IsDate(.Item("TrkRtnToYard")) Then txtTruckReturnToYard.Text = .Item("TrkRtnToYard")
                    txtWaitingTimeDelivery.Text = .Item("WaitingTimePOD")

                    txtITRNumber.Text = .Item("itrno")
                    If IsDate(.Item("itrdate")) Then lblITRDate.Text = .Item("itrdate")
                    txtAdvancePayment.Text = .Item("AdvanceCost")
                    txtAdvancePaymentNote.Text = .Item("AdvanceCostNote")

                    txtCreditorNameCompany.Text = cmbDriverName.Text
                    txtCreditorNameCompany.Tag = cmbDriverName.Tag

                    txtDeliveryInstrution.Text = .Item("DeliveryInstruction")
                    txtbackloadNote.Text = .Item("BackLoadNotes")

                    txtTotalServiceCharges.Text = 0
                    If .Item("bkload") = 1 Then chkBackload.Checked = True
                    lblCreatedBy.Text = "Issued By / On  [" & .Item("createdBy") & " " & .Item("CreatedOn") & "]"
                    lblUpdatedBy.Text = "Last Updated By / On [" & .Item("updatedby") & " " & .Item("UpdatedOn") & "]"

                    'billing section
                    If Not String.IsNullOrEmpty(cmbDriverName.Text) Then txtCreditorNameCompany.Text = cmbTransporter.Text & "," & txtDriverName.Text
                    txtDebitorRevenue.Text = lblClientName.Text
                    txtITRNumber.Text = .Item("itrno")
                    If IsDate(.Item("itrdate")) Then lblITRDate.Text = .Item("itrdate")

                    If String.IsNullOrEmpty(txtBrokerCommissionNote.Text) Then txtBrokerCommissionNote.Text = cmbLocalAgentBroker.Text

                    txtDriverOtherAmountNote.Text = .Item("cosNote1")

                    locid1 = .Item("locid1")
                    lblOriginLocation1.Text = .Item("LocArea1")
                    locid2 = .Item("locid2")
                    lblDestinationLocation1.Text = .Item("LocArea2")


                    'block eqp owner check if itr alredy issued
                    If .Item("itrno") > 0 Then panelEquipmentDetail.Enabled = False


                End With
                'check if wb billing data exists
                wbBillingDataExists = IsBillingDataExists()
                If wbBillingDataExists Then
                    Call GetChargeAmountFromWaybillCosting()
                    Call Totals()
                End If
                txtActCommodityWB.Focus()

            Else
                lblMessage.Text = "Unable to fetch job file"
                PanelMessage.Visible = True

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            lblMessage.Text = ex.Message
            PanelMessage.Visible = True
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Function IsBillingDataExists() As Boolean
        Dim rtnval As Boolean = False
        Try
            Dim dstmp As New DataSet
            sql_String = "select * from [WaybillCosting] where wbid=" & recID
            dstmp = setDataList(sql_String)
            If dstmp.Tables(0).Rows.Count > 0 Then rtnval = True
        Catch ex As Exception
            rtnval = False
        End Try
        Return rtnval
    End Function

#Region "FORM_INIT"
    Private Sub clearForm()
        POLOrgRecID = 0
        PODOrgRecID = 0
        lblStatus.Text = ""
        wbPost = False
        wbCancelled = False
        lblClientName.Text = ""
        lblInvNo.Text = ""
        orgRecID = 0
        lblClientAddress.Text = ""
        lblBatchNo.Text = "" : lblBatchDate.Text = "" : lblBatchSlNo.Text = ""
        lblJobNumber.Text = ""
        lblFormTitle.Text = ""
        txtActCommodityWB.Clear()
        txtContainerNoWB.Clear()
        txtContainerSizeWB.Clear()
        txtContainerTypeWB.Clear()
        txtUnitTypeWB.Clear()
        txtWeightWB.Clear()
        txtVolumeWB.Clear()
        txtQtyWB.Clear()
        txtContainerReturn.SetToNullValue()
        txtTerminalName.Clear()
        txtEIRNo.Clear()
        RadGridMultipleGoods.DataSource = Nothing
        txtPickupAddress1.Clear()
        txtDeliveryAddress1.Clear()
        txtAdditionalRoute.Clear()
        cmbLocalAgentBroker.Text = "" : cmbLocalAgentBroker.Tag = 0
        txtRefWB.Clear()
        txtExpectedLoadingDate.SetToNullValue()
        txtWaitingTimeLoading.Clear()
        cmbDriverName.Text = "" : cmbDriverName.Tag = 0
        txtDriverName.Clear()
        txtDriverID.Clear()
        txtMobileNumber.Clear()
        rbRental.Checked = False : rbCompanyTruck.Checked = False
        cmbEquipmentType.Text = "" : cmbEquipmentType.Tag = 0
        cmbEquipmentNumber.Text = "" : cmbEquipmentNumber.Tag = 0
        txtPlateNumber.Clear()
        txtDateOfDelivery.SetToNullValue()
        txtWaitingTimeDelivery.Clear()
        txtContainerReturn.SetToNullValue()
        txtDeliveryInstrution.Clear()
        lblCreatedBy.Text = "Issued By/On - "
        lblUpdatedBy.Text = "Last Updated By/On - "
        lblRecordID.Text = "Record ID -" & recID
        txtBackLoadNote.Clear()
        'billing section
        'rental
        txtITRNumber.Clear()
        lblITRDate.Text = ""
        txtAdvancePayment.Clear() : txtAdvancePaymentNote.Clear()
        txtTotalServiceCharges.Clear()
        'company
        lblEqpType1.Text = ""
        txtDriverTripAmount.Clear()
        txtDriverOtherAmount.Clear() : txtDriverOtherAmountNote.Clear()
        txtBrokerCommission.Clear() : txtBrokerCommissionNote.Clear()
        txtTotalCost.Clear()
        txtCreditorNameCompany.Clear()
        'revenue
        txtDebitorRevenue.Clear() : txtDebitorRevenue.Tag = 0
        txtTotalRevenue.Clear()
        txtBackLoadNote.Clear()

        lblUnloco1.Text = ""
        lblUnloco2.Text = ""
        lblUnlocoA.Text = ""
        lblUnlocoB.Text = ""
        lblOriginLocation1.Text = ""
        lblDestinationLocation1.Text = ""
        lblOriginLocation2.Text = ""
        lblDestinationLocation2.Text = ""

        TabControlGoods.TabIndex = 0
        TabControlAddress.TabIndex = 0
        TabControlDetail.TabIndex = 0
        PanelMessage.Visible = False
        lblMessage.Text = ""
        chkBackload.Checked = False

        PanelCreateBillingButton.Visible = False
        panelEquipmentDetail.Enabled = True
        lblOrgLoading.Text = ""
        lblOrgDelivery.Text = ""



    End Sub
    Private Sub initFormLoad()
        frmWaitForm.lblTitle.Text = "Opening Waybill Form. please wait..!"
        frmWaitForm.Show()
        frmWaitForm.Refresh()
        Me.Cursor = Cursors.WaitCursor
        POLOrgAddrRecID = 0
        PODOrgAddrRecID = 0
        'Call loadOrgPOLPOD(cmbOrgPlaceOfDelivery, "")
        Call loadOrgPOLPOD(cmbOrgPlaceOfLoading, "")

        Call refresh_country()
        'temp
        cmbPOLCountry.Text = "SA" : cmbPOLCountry.Tag = 185
        cmbPOdCountry.Text = "SA" : cmbPOdCountry.Tag = 185
        Call refresh_cities(cmbPOLCountry.Text, cmbPOLCity)
        Call refresh_cities(cmbPOdCountry.Text, cmbPODCity)

        cmbDeliveryAddressWB.Visible = False
        cmbLoadingAddressWB.Visible = False
        lnkSelectAddressPOD.Visible = True
        lnkSelectAddressPOL.Visible = True
        Call refresh_organization(cmbLocalAgentBroker, "IsAgent=1 or IsBroker=1")
        Call refresh_organization(cmbTransporter, "IsTransporter=1")
        Call refresh_driver(cmbDriverName, "")
        Call refresh_eqpGroup(cmbEquipmentType, "")
        Me.Cursor = Cursors.Default
        frmWaitForm.Close()
    End Sub
#End Region
#Region "RefreshOrg"
    Private Sub refresh_country()
        Me.Cursor = Cursors.WaitCursor
        sql_String = "select shortname, name, recid from countries where shortname in (select distinct countrycode from unloco) order by name"
        Call fillCombo(cmbPOLCountry, sql_String, 0, 300, 100, 300)
        cmbPOLCountry.Columns(2).VisibleInColumnChooser = False
        cmbPOLCountry.Tag = 0 : cmbPOLCountry.Text = ""

        Call fillCombo(cmbPOdCountry, sql_String, 0, 300, 100, 300)
        cmbPOdCountry.Columns(2).VisibleInColumnChooser = False
        cmbPOdCountry.Tag = 0 : cmbPOdCountry.Text = ""
        Me.Cursor = Cursors.Default

    End Sub
    Private Sub loadOrgPOLPOD(cmbObj As Object, orgFldName As String)
        Try
            Me.Cursor = Cursors.WaitCursor
            sql_String = " select  o.name [Organization],o.recID from organization o "
            sql_String += " where o.recID in (select v.shprRecID from jobFileSearch_viewY2013 v where actRecID=" & actRecID & ")"
            sql_String += " union "
            sql_String += " select o.name [Organization],o.recID from organization o "
            sql_String += " where o.recID in (select v.cnerecid from jobFileSearch_viewY2013 v where actRecID=" & actRecID & ")"
            sql_String += " union "
            sql_String += " select o.name [Organization],o.recID from organization o "
            sql_String += " where o.recID in (select v.cltRecID from jobFileSearch_viewY2013 v where actRecID=" & actRecID & ")"
            'sql_String += " union "
            'sql_String += " select o.name [Organization],o.recID from organization o where o.IsCFSCYD=1"
            Call fillCombo(cmbObj, sql_String, 0, 300, cmbObj.width, 100)
            cmbObj.Columns("recid").VisibleInColumnChooser = False
            cmbObj.Tag = 0 : cmbObj.Text = ""

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub refresh_organization(cmbObj As Object, orgFldName As String)
        Me.Cursor = Cursors.WaitCursor
        sql_String = "select Name,address1 [Address],recid from [organization] where block=0 and (" & orgFldName & ") and branchID=" & appCompanyInfo.branchID
        sql_String += " order by name"
        Call fillCombo(cmbObj, sql_String, 0, 300, 100, 100)
        ' cmbObj.Columns(2).VisibleInColumnChooser = False
        cmbObj.Tag = 0 : cmbObj.Text = ""
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub refresh_organizationCNEE(cmbObj As Object, orgFldName As String)
        Me.Cursor = Cursors.WaitCursor
        sql_String = "select Name [Organization], recid from [organization] where block=0 and (" & orgFldName & ") and branchID=" & appCompanyInfo.branchID
        sql_String += " order by name"
        Call fillCombo(cmbObj, sql_String, 0, 300, 100, 100)
        ' cmbObj.Columns(2).VisibleInColumnChooser = False
        cmbObj.Tag = 0 : cmbObj.Text = ""
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub refresh_driver(cmbObj As Object, orgFldName As String)
        Me.Cursor = Cursors.WaitCursor
        sql_String = "select Name,mobile,isnull(idno,'')[id],recid from [drivers] where isActive=1 and branchID=" & appCompanyInfo.branchID
        Call fillCombo(cmbObj, sql_String, 500, 300, 100, 100)
        ' cmbObj.Columns(2).VisibleInColumnChooser = False
        cmbObj.Tag = 0 : cmbObj.Text = ""
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub refresh_Area(cmbObj As Object, orgFldName As String)
        Me.Cursor = Cursors.WaitCursor
        sql_String = "select Area,unloco,recid from [LocationMaster] where isActive=1"
        Call fillCombo(cmbObj, sql_String, 500, 300, 100, 100)
        ' cmbObj.Columns(2).VisibleInColumnChooser = False
        cmbObj.Tag = 0 : cmbObj.Text = ""
        Me.Cursor = Cursors.Default
    End Sub
#End Region
#Region "Address"
    Private Sub lnkSelectAddressPOL_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkSelectAddressPOL.LinkClicked
        cmbLoadingAddressWB.Visible = True
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
        sql_String = "SELECT  Address1 [address], isnull(lm.area,'') Location, o.unlocode, o.recID, o.orgRecID,o.locID FROM organizationAddress o"
        sql_String += " left outer join LocationMaster lm on o.locid=lm.recid"
        sql_String += " where o.isActive=1 and orgRecID=" & orgrecid
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
            POLOrgAddrRecID = 0
            POLOrgRecID = cmbOrgPlaceOfLoading.Tag
        End If
    End Sub

    Private Sub cmbOrgPlaceOfDelivery_LostFocus(sender As Object, e As EventArgs) Handles cmbOrgPlaceOfDelivery.LostFocus
        If cmbOrgPlaceOfDelivery.SelectedValue <> "" Then
            cmbOrgPlaceOfDelivery.Tag = 0
            Dim selectedRow As GridViewDataRowInfo = DirectCast(cmbOrgPlaceOfDelivery.SelectedItem, GridViewDataRowInfo)
            cmbOrgPlaceOfDelivery.Tag = (selectedRow.Cells("recid").Value.ToString())
            Call LoadAddressList(cmbDeliveryAddressWB, cmbOrgPlaceOfDelivery.Tag)
            PODOrgAddrRecID = 0
            PODOrgRecID = cmbOrgPlaceOfDelivery.Tag
        End If
    End Sub

    Private Sub cmbLoadingAddressWB_LostFocus(sender As Object, e As EventArgs) Handles cmbLoadingAddressWB.LostFocus
        If cmbLoadingAddressWB.SelectedValue <> "" Then
            cmbLoadingAddressWB.Tag = 0 : locid1 = 0
            Dim selectedRow As GridViewDataRowInfo = DirectCast(cmbLoadingAddressWB.SelectedItem, GridViewDataRowInfo)
            cmbLoadingAddressWB.Tag = (selectedRow.Cells("recid").Value.ToString())
            txtLoadingAddressWB.Text = (selectedRow.Cells("Address").Value.ToString())
            lblUnloco1.Text = (selectedRow.Cells("unlocode").Value.ToString())
            locid1 = (selectedRow.Cells("locid").Value.ToString())
            lblOriginLocation2.Text = (selectedRow.Cells("Location").Value.ToString())
            POLOrgAddrRecID = (selectedRow.Cells("recid").Value.ToString())

        End If
    End Sub

    Private Sub cmbDeliveryAddressWB_LostFocus(sender As Object, e As EventArgs) Handles cmbDeliveryAddressWB.LostFocus
        If cmbDeliveryAddressWB.SelectedValue <> "" Then
            cmbDeliveryAddressWB.Tag = 0 : locid2 = 0
            Dim selectedRow As GridViewDataRowInfo = DirectCast(cmbDeliveryAddressWB.SelectedItem, GridViewDataRowInfo)
            cmbDeliveryAddressWB.Tag = (selectedRow.Cells("recid").Value.ToString())
            txtDeliveryAddressWB.Text = (selectedRow.Cells("Address").Value.ToString())
            lblUnloco2.Text = (selectedRow.Cells("unlocode").Value.ToString())
            locid2 = (selectedRow.Cells("locid").Value.ToString())
            lblDestinationLocation2.Text = (selectedRow.Cells("Location").Value.ToString())
            PODOrgAddrRecID = (selectedRow.Cells("recid").Value.ToString())

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
            lblOriginLocation2.Text = (selectedRow.Cells("Location").Value.ToString())
            POLOrgAddrRecID = (selectedRow.Cells("recid").Value.ToString())
            'refresh area in city
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
            lblDestinationLocation2.Text = (selectedRow.Cells("Location").Value.ToString())
            PODOrgAddrRecID = (selectedRow.Cells("recid").Value.ToString())
        End If
    End Sub
#End Region
    Private Sub btnSaveAddress_Click(sender As Object, e As EventArgs) Handles btnSaveAddress.Click
        '  If POLOrgAddrRecID = 0 Or PODOrgAddrRecID = 0 Then lblAddrSelect.Visible = True : Return
        lblUnlocoA.Text = lblUnloco1.Text
        lblUnlocoB.Text = lblUnloco2.Text
        lblOriginLocation1.Text = lblOriginLocation2.Text
        lblDestinationLocation1.Text = lblDestinationLocation2.Text
        txtPickupAddress1.Text = txtLoadingAddressWB.Text
        txtDeliveryAddress1.Text = txtDeliveryAddressWB.Text
        TabControlAddress.SelectedIndex = 0
        lblOrgLoading.Text = cmbOrgPlaceOfLoading.Text
        lblOrgDelivery.Text = cmbOrgPlaceOfDelivery.Text


    End Sub

    Private Sub cmbDriverName_LostFocus(sender As Object, e As EventArgs) Handles cmbDriverName.LostFocus
        If cmbDriverName.SelectedValue <> "" Then
            cmbDriverName.Tag = 0
            Dim selectedRow As GridViewDataRowInfo = DirectCast(cmbDriverName.SelectedItem, GridViewDataRowInfo)
            cmbDriverName.Tag = (selectedRow.Cells("recid").Value.ToString())
            cmbDriverName.Text = (selectedRow.Cells("Name").Value.ToString())
            txtDriverID.Text = (selectedRow.Cells("id").Value.ToString())
            txtMobileNumber.Text = (selectedRow.Cells("mobile").Value.ToString())
            txtDriverName.Text = cmbDriverName.Text
        End If
    End Sub

    Private Sub btnSearchByDriverID_Click(sender As Object, e As EventArgs) Handles btnSearchByDriverID.Click
        If String.IsNullOrEmpty(txtDriverID.Text) Then Exit Sub
        Call getDriverRecord(" idno='" & txtDriverID.Text & "';")
    End Sub

    Private Sub btnSearchByDriverMobile_Click(sender As Object, e As EventArgs) Handles btnSearchByDriverMobile.Click
        If String.IsNullOrEmpty(txtMobileNumber.Text) Then Exit Sub
        Call getDriverRecord(" mobile='" & txtMobileNumber.Text & "';")
    End Sub


    Private Function getDriverRecord(searchstring As String) As Boolean
        Dim rtnval As Boolean = False
        If String.IsNullOrEmpty(searchstring) Then Return rtnval
        lblMessage.Text = "" : PanelMessage.Visible = False
        Me.Cursor = Cursors.WaitCursor
        Try
            Dim dstmp As New DataSet
            sql_String = "select * from [drivers] where recid>0 and " & searchstring
            dstmp = setDataList(sql_String)
            If dstmp.Tables(0).Rows.Count > 0 Then
                With dstmp.Tables(0).Rows(0)
                    cmbDriverName.Text = .Item("name")
                    cmbDriverName.Tag = .Item("recid")
                    txtDriverName.Text = cmbDriverName.Text
                    txtDriverID.Text = .Item("idno")
                    txtMobileNumber.Text = .Item("mobile")
                End With
                rtnval = True
            Else
                lblMessage.Text = "Driver Details Not Found" : PanelMessage.Visible = True
            End If
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            lblMessage.Text = ex.Message
            PanelMessage.Visible = True
        End Try
        Me.Cursor = Cursors.Default
        Return rtnval
    End Function

    Private Sub rbCompanyTruck_Click(sender As Object, e As EventArgs) Handles rbCompanyTruck.Click
        If rbCompanyTruck.Checked Then
            txtDriverName.SendToBack()
            cmbDriverName.BringToFront()
            cmbDriverName.Visible = True
            txtDriverName.Visible = False
            PanelCostRental.Visible = False
            PanelCostCompany.Visible = True
            txtTotalServiceCharges.Text = 0
            Call Totals()
        End If
    End Sub

    Private Sub rbRental_Click(sender As Object, e As EventArgs) Handles rbRental.Click
        If rbRental.Checked Then
            cmbDriverName.SendToBack()
            txtDriverName.BringToFront()
            cmbDriverName.Visible = False
            txtDriverName.Visible = True
            PanelCostCompany.Visible = False
            PanelCostRental.Visible = True
            txtDriverTripAmount.Text = 0
            txtDriverOtherAmount.Text = 0
            Call Totals()

        End If
    End Sub


    Private Sub refresh_eqpGroup(cmbObj As Object, orgFldName As String)
        Me.Cursor = Cursors.WaitCursor
        sql_String = "select Name,shortname,etype,recid from [EquipmentGroup] where isActive=1"
        Call fillCombo(cmbObj, sql_String, 200, 300, 100, 100)
        ' cmbObj.Columns(2).VisibleInColumnChooser = False
        cmbObj.Tag = 0 : cmbObj.Text = ""
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub refresh_eqpType(cmbObj As Object, orgFldName As String)
        Me.Cursor = Cursors.WaitCursor
        sql_String = "select internalcode [Code], Name, PlateNumber,IsCompanyown,recid from [equipment] where isactive=1 and " & orgFldName & ";"
        Call fillCombo(cmbObj, sql_String, 200, 300, 100, 100)
        ' cmbObj.Columns(2).VisibleInColumnChooser = False
        cmbObj.Tag = 0 : cmbObj.Text = ""
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub cmbEquipmentType_LostFocus(sender As Object, e As EventArgs) Handles cmbEquipmentType.LostFocus
        If String.IsNullOrEmpty(cmbEquipmentType.Text) Then Exit Sub

        If cmbEquipmentType.SelectedValue <> "" Then
            cmbEquipmentType.Tag = 0
            Dim selectedRow As GridViewDataRowInfo = DirectCast(cmbEquipmentType.SelectedItem, GridViewDataRowInfo)
            cmbEquipmentType.Tag = (selectedRow.Cells("recid").Value.ToString())
            cmbEquipmentType.Text = (selectedRow.Cells("Name").Value.ToString())
            If cmbEquipmentType.Tag > 0 Then Call refresh_eqpType(cmbEquipmentNumber, "eqpgroup=" & cmbEquipmentType.Tag)
        End If
    End Sub

    Private Sub cmbEquipmentNumber_LostFocus(sender As Object, e As EventArgs) Handles cmbEquipmentNumber.LostFocus
        If String.IsNullOrEmpty(cmbEquipmentNumber.Text) Then Exit Sub

        If cmbEquipmentNumber.SelectedValue <> "" Then
            cmbEquipmentNumber.Tag = 0
            Dim selectedRow As GridViewDataRowInfo = DirectCast(cmbEquipmentNumber.SelectedItem, GridViewDataRowInfo)
            cmbEquipmentNumber.Tag = (selectedRow.Cells("recid").Value.ToString())
            cmbEquipmentNumber.Text = (selectedRow.Cells("Name").Value.ToString())
            txtPlateNumber.Text = (selectedRow.Cells("platenumber").Value.ToString())
        End If
    End Sub


    Private Sub cmbTransporter_LostFocus(sender As Object, e As EventArgs) Handles cmbTransporter.LostFocus
        If String.IsNullOrEmpty(cmbTransporter.Text) Then Exit Sub

        If cmbTransporter.SelectedValue <> "" Then
            cmbTransporter.Tag = 0
            Dim selectedRow As GridViewDataRowInfo = DirectCast(cmbTransporter.SelectedItem, GridViewDataRowInfo)
            cmbTransporter.Tag = (selectedRow.Cells("recid").Value.ToString())
            cmbTransporter.Text = (selectedRow.Cells("Name").Value.ToString())
            '            txtPlateNumber.Text = (selectedRow.Cells("platenumber").Value.ToString())
        End If
    End Sub

    Private Sub cmbLocalAgentBroker_LostFocus(sender As Object, e As EventArgs) Handles cmbLocalAgentBroker.LostFocus
        If String.IsNullOrEmpty(cmbLocalAgentBroker.Text) Then Exit Sub
        If cmbLocalAgentBroker.SelectedValue <> "" Then
            cmbLocalAgentBroker.Tag = 0
            Dim selectedRow As GridViewDataRowInfo = DirectCast(cmbLocalAgentBroker.SelectedItem, GridViewDataRowInfo)
            cmbLocalAgentBroker.Tag = (selectedRow.Cells("recid").Value.ToString())
            cmbLocalAgentBroker.Text = (selectedRow.Cells("Name").Value.ToString())
            If String.IsNullOrEmpty(txtBrokerCommissionNote.Text) Then txtBrokerCommissionNote.Text = cmbLocalAgentBroker.Text
        End If
    End Sub

    Private Sub btnSaveAnPrint_Click(sender As Object, e As EventArgs) Handles btnSaveAnPrint.Click
        '4:03p


        If Not savecheck() Then Exit Sub
        Dim adapter As New SqlDataAdapter
        Dim ds As New DataSet
        Dim dr As DataRow
        Dim rtnval = False
        Dim cmdbuilder As SqlCommandBuilder
        Try

            frmWaitForm.lblTitle.Text = "Sending Data to Remote Server.."
            frmWaitForm.Show()
            frmWaitForm.Refresh()
            Me.Cursor = Cursors.WaitCursor
            If sql_CNN.State = ConnectionState.Closed Then createConnection()
            If sql_CNN.State = ConnectionState.Open Then
                cmdbuilder = New SqlCommandBuilder(adapter)
                With adapter
                    sql_String = "select * from [Waybills] where recid=" & recID
                    .SelectCommand = New SqlCommand(sql_String, sql_CNN) 'add object select command
                    .Fill(ds, "cdata")
                End With
                If ds.Tables("cdata").Rows.Count > 0 Then 'found row to update
                    dr = ds.Tables("cdata").Rows(0)
                    With dr

                        .Item("goodsdesc") = txtActCommodityWB.Text
                        .Item("containerNo") = txtContainerNoWB.Text
                        .Item("containerType") = Microsoft.VisualBasic.Left(txtContainerTypeWB.Text, 10)
                        .Item("cntrRefNo") = txtContainerSizeWB.Text
                        If IsDate(txtContainerReturn.Text) Then .Item("cntrEmptyReturned") = txtContainerReturn.Text
                        .Item("StorageYard") = txtTerminalName.Text
                        .Item("StorageOUT") = txtEIRNo.Text

                        .Item("goodsunittype") = txtUnitTypeWB.Text
                        .Item("loadQty") = txtQtyWB.Text
                        .Item("netWght") = txtWeightWB.Text
                        .Item("grossWght") = txtVolumeWB.Text

                        .Item("PickupAddress") = txtPickupAddress1.Text
                        .Item("DeliveryAddress") = txtDeliveryAddress1.Text
                        .Item("unloco1") = lblUnlocoA.Text
                        .Item("unloco2") = lblUnlocoB.Text
                        .Item("AdditionalRoute") = txtAdditionalRoute.Text
                        .Item("orgIsBrokerRecID") = cmbLocalAgentBroker.Tag
                        .Item("wbrefno") = txtRefWB.Text
                        If IsDate(txtExpectedLoadingDate.Text) Then .Item("loadingDate") = txtExpectedLoadingDate.Text
                        'time
                        .Item("WaitingTimePOL") = txtWaitingTimeLoading.Text
                        If chkBackload.Checked = True Then .Item("backloaded") = 1

                        .Item("polorgaddrrecid") = POLOrgAddrRecID
                        .Item("podorgaddrrecid") = PODOrgAddrRecID

                        .Item("orgrecidPOL") = cmbOrgPlaceOfLoading.Tag
                        .Item("orgrecidPOd") = cmbOrgPlaceOfDelivery.Tag


                        .Item("driverRecordID") = cmbDriverName.Tag
                        .Item("driverNameLocal") = txtDriverName.Text
                        .Item("driverID") = txtDriverID.Text
                        .Item("driverContactLocal") = txtMobileNumber.Text
                        If rbCompanyTruck.Checked = True Then .Item("companyowntruck") = 0
                        If rbRental.Checked = True Then .Item("companyowntruck") = 1

                        .Item("equipType") = 0
                        .Item("equipID") = 0
                        If Not String.IsNullOrEmpty(cmbEquipmentType.Text) Then .Item("equipType") = cmbEquipmentType.Tag
                        If Not String.IsNullOrEmpty(cmbEquipmentNumber.Text) Then .Item("equipID") = cmbEquipmentNumber.Tag
                        .Item("truckno") = txtPlateNumber.Text

                        If String.IsNullOrEmpty(cmbTransporter.Text) Then cmbTransporter.Tag = 0
                        .Item("transporterName") = cmbTransporter.Text
                        .Item("orgIsTransporterID") = cmbTransporter.Tag

                        If IsDate(txtDateOfDelivery.Text) Then .Item("dischargeDate") = txtDateOfDelivery.Text
                        'time
                        .Item("WaitingTimePOD") = txtWaitingTimeDelivery.Text
                        If IsDate(txtTruckReturnToYard.Text) Then .Item("TrkRtnToYard") = txtTruckReturnToYard.Text
                        .Item("wbRemarks") = txtDeliveryInstrution.Text
                        .Item("BackLoadNotes") = txtBackLoadNote.Text

                        'write costing 

                        If Not IsNumeric(txtAdvancePayment.Text) Then txtAdvancePayment.Text = 0
                        .Item("AdvanceCost") = txtAdvancePayment.Text
                        .Item("AdvanceCostNote") = txtAdvancePaymentNote.Text
                        If Not IsNumeric(txtAdvancePayment.Text) Then txtBrokerCommission.Text = 0
                        'saving brokercost for reporting purpose

                        .Item("BrokerCost") = Val(txtBrokerCommission.Text)
                        .Item("BrokerCostNote") = txtBrokerCommissionNote.Text

                        .Item("cosNote1") = txtDriverOtherAmountNote.Text

                        .Item("UpdatedBy") = Microsoft.VisualBasic.Left(appUserInfo.Name, 25)
                        .Item("UpdatedOn") = Now ' Today.Date

                        .Item("locid1") = cmbPOLCity.Tag
                        .Item("locid2") = cmbPODCity.Tag


                        'update status
                        If (Not IsDate(txtExpectedLoadingDate.Text)) And (Not IsDate(txtDateOfDelivery.Text)) Then sql_String = "NEW"
                        If (IsDate(txtExpectedLoadingDate.Text)) And (Not IsDate(txtDateOfDelivery.Text)) Then sql_String = "NOT-DELIVERED"
                        If (IsDate(txtExpectedLoadingDate.Text)) And (IsDate(txtDateOfDelivery.Text)) And (Val(txtTotalRevenue.Text) = 0) Then sql_String = "NOT-BILLED"

                        If Val(txtTotalRevenue.Text) > 0 Then sql_String = "BILLED"

                        .Item("wbstatus") = sql_String
                        lblStatus.Text = "Status - " & sql_String

                    End With
                    adapter.Update(ds, "cdata")

                    'TRK OTHER  DTRIP COMM
                    'we neeed to update cost and revenue to waybillscosting tables
                    If Val(txtBrokerCommission.Text) > 0 Then _
                        Call UpdateWaybillCostingTable("COMM", txtBrokerCommission.Text, txtBrokerCommissionNote.Text, 0)
                    If Val(txtDriverTripAmount.Text) > 0 Then _
                        Call UpdateWaybillCostingTable("DTRIP", txtDriverTripAmount.Text, "Driver Trip Allowances", 0)
                    If Val(txtDriverOtherAmount.Text) > 0 Then _
                        Call UpdateWaybillCostingTable("OTHER", txtDriverOtherAmount.Text, txtDriverOtherAmountNote.Text, 0)

                    'write revenue chgs
                    'If Val(txtOtherChargeRevenue.Text) > 0 Then _
                    '    Call UpdateWaybillCostingTable("OTHER", txtOtherChargeRevenue.Text, txtOtherChargeRevenueNote.Text, 1)
                    'If Val(txtServiceChargesRevenue.Text) > 0 Then _
                    '    Call UpdateWaybillCostingTable("TRK", txtServiceChargesRevenue.Text, txtServiceChargeNote.Text, 1)


                    'Me.Close()
                    lblMessage.Text = ""
                    PanelMessage.Visible = False
                    frmWaitForm.Close()
                Else
                    frmWaitForm.Close()
                    lblMessage.Text = "Unable to Fetch Waybill Information" : PanelMessage.Visible = True
                End If


            End If
            '  frmWaitForm.Close()

        Catch ex As Exception
            Me.Cursor = Cursors.Default
            frmWaitForm.Close()
            lblMessage.Text = ex.Message
            PanelMessage.Visible = True
            MsgBox("There was error while saving, Report Admin with ID [" & recID & "]", MsgBoxStyle.Critical, "Not Saved")
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    

#Region "Form Input Validation"
    Private Function savecheck() As Boolean
        Dim rtnval As Boolean = True
        Dim msg1 As String = ""
        PanelMessage.Visible = False
        If actRecID < 1 Then msg1 = "Job ID not found" : GoTo msg
        If recID < 1 Then msg1 = "Waybill ID not found" : GoTo msg
        If String.IsNullOrEmpty(txtActCommodityWB.Text) Then msg1 = "Cargo Description is missing" : GoTo msg

        If String.IsNullOrEmpty(txtPickupAddress1.Text) Then msg1 = "Pickup From Address is missing" : GoTo msg
        If String.IsNullOrEmpty(txtDeliveryAddress1.Text) Then msg1 = "Delivery Address is missing" : GoTo msg

        If rbCompanyTruck.Checked = False And rbRental.Checked = False Then msg1 = "Equipment Owner (Company/Rental)" : GoTo msg
        If rbCompanyTruck.Checked = False And rbRental.Checked = False Then msg1 = "Equipment Owner (Company/Rental)" : GoTo msg

        If IsDate(txtDateOfDelivery.Text) And IsDate(txtExpectedLoadingDate.Text) Then
            If CDate(txtDateOfDelivery.Text) < CDate(txtExpectedLoadingDate.Text) Then msg1 = "Check Delivery Dt. With Loading Dt." : GoTo msg
        End If
        If IsDate(txtContainerReturn.Text) Then
            If IsDate(txtExpectedLoadingDate.Text) Then
                If CDate(txtContainerReturn.Text) < CDate(txtExpectedLoadingDate.Text) Then msg1 = "Check Container Return Dt. With Loading Dt." : GoTo msg
            End If
            If IsDate(txtDateOfDelivery.Text) Then
                If CDate(txtContainerReturn.Text) < CDate(txtDateOfDelivery.Text) Then msg1 = "Check Container Return Dt. With Delivery Dt." : GoTo msg
            End If
        End If
        If IsDate(txtTruckReturnToYard.Text) Then
            If CDate(txtTruckReturnToYard.Text) < CDate(txtExpectedLoadingDate.Text) Then msg1 = "Check Company Truck Return Dt. With Loading Dt." : GoTo msg
            If CDate(txtTruckReturnToYard.Text) < CDate(txtDateOfDelivery.Text) Then msg1 = "Check  Company Truck Return Dt. With Delivery Dt." : GoTo msg
        End If

        If rbRental.Checked And String.IsNullOrEmpty(cmbTransporter.Text) Then msg1 = "Rented Trucks Requires Transporter Name" : GoTo msg
        If rbRental.Checked And cmbTransporter.Tag = 0 Then msg1 = "Rented Trucks Requires Transporter Name" : GoTo msg

        '        If POLOrgAddrRecID = 0 Or PODOrgAddrRecID = 0 Then msg1 = "Pickup/Delivery Address is not selected properly" : GoTo msg

        If (String.IsNullOrEmpty(cmbPOLCountry.Text) Or cmbPOLCity.Tag = 0) Then msg1 = "Please Select Loading Country/City From List" : GoTo msg
        If (String.IsNullOrEmpty(cmbPOdCountry.Text) Or cmbPODCity.Tag = 0) Then msg1 = "Please Select Loading Country/City From List" : GoTo msg


        Return rtnval
        Exit Function
msg:
        rtnval = False
        lblMessage.Text = msg1
        PanelMessage.Visible = True
        Return rtnval
    End Function

    Private Function ValidateDataBeforeBilling() As Boolean
        Dim rtn As Boolean = True
        Dim msg1 As String = ""
        PanelMessage.Visible = False : lblMissingBillingDataMessage.Visible = False
        If String.IsNullOrEmpty(cmbEquipmentType.Text) Then msg1 = "Equipment Type is missing" : GoTo msg
        If (cmbEquipmentType.Tag = 0) Then msg1 = "Equipment Type is missing" : GoTo msg
        If rbCompanyTruck.Checked = True Then
            If String.IsNullOrEmpty(cmbEquipmentNumber.Text) Then msg1 = "Equipment Number is missing" : GoTo msg
            If (cmbEquipmentNumber.Tag = 0) Then msg1 = "Equipment Number is missing" : GoTo msg
        End If
        If (cmbTransporter.Tag = 0) Then msg1 = "Transporter is missing" : GoTo msg
        If String.IsNullOrEmpty(cmbTransporter.Text) Then msg1 = "Transporter is missing" : GoTo msg
        If String.IsNullOrEmpty(txtDriverName.Text) Then msg1 = "Driver is missing" : GoTo msg
        If (cmbLocalAgentBroker.Tag = 0) Then msg1 = "Supervisor Agent is missing" : GoTo msg
        If String.IsNullOrEmpty(cmbLocalAgentBroker.Text) Then msg1 = "Local Agent/Broker is missing" : GoTo msg
        If Not IsDate(txtDateOfDelivery.Text) Then msg1 = "Delivery Date is missing" : GoTo msg

        Return rtn
        Exit Function
msg:
        rtn = False
        lblMessage.Text = msg1
        PanelMessage.Visible = True
        lblMissingBillingDataMessage.Visible = True
        Return rtn
    End Function


#End Region


    Private Sub btnCreateBillingData_Click(sender As Object, e As EventArgs) Handles btnCreateBillingData.Click
        Me.Cursor = Cursors.Default
        If Not ValidateDataBeforeBilling() Then Exit Sub
        PanelCreateBillingButton.Visible = False
        'creditor is driver+transporter
        txtCreditorNameCompany.Text = cmbTransporter.Text & "," & txtDriverName.Text
        txtDebitorRevenue.Text = lblClientName.Text
        lblEqpType1.Text = cmbEquipmentType.Text

        Dim tripincentive As Double = 0
        Dim otheramount As Double = 0
        'create billing data by adding charges common
        If AddChargeItemsToWaybillCosting() Then
            'having added common charges, get buying/selling rates from tariff table

            'get selling rates by locationA to locationB
            '    Call getOrganizationTariffRate(orgRecID)
            InitDataGridRevenue()
        End If
        wbBillingDataExists = True
        txtBrokerCommission.Focus()
        Me.Cursor = Cursors.Default
    End Sub

   

    Private Sub GetChargeAmountFromWaybillCosting()
        Dim dblAmt As Double = 0
        Dim dblAmtOther As Double = 0
        Dim dblAmtRev As Double = 0
        Dim dblAmtCos As Double = 0
        Dim rtnval As Boolean = False
        If recID < 1 Then Exit Sub
        lblMessage.Text = "" : PanelMessage.Visible = False
        Me.Cursor = Cursors.WaitCursor
        Try
            Dim dstmp As New DataSet
            'get total rental itr cost
            sql_String = " select isnull(sum(W.revenue),0) [rev] from WaybillCosting w inner join chargeElements c on w.chargeID=c.recID"
            sql_String += " where w.wbID=" & recID & " and c.shortname not in ('COMM','OTHER')"
            sql_String += " select isnull(sum(W.revenue),0) [revother] from WaybillCosting w inner join chargeElements c on w.chargeID=c.recID"
            sql_String += " where w.wbID=" & recID & " and c.shortname in ('OTHER')"
            sql_String += " select isnull(sum(w.cost),0) [cos] from WaybillCosting w inner join chargeElements c on w.chargeID=c.recID"
            sql_String += " where w.wbID=" & recID & " and c.shortname not in ('COMM','OTHER')"
            sql_String += " select isnull(sum(w.cost),0) [commission] from WaybillCosting w inner join chargeElements c on w.chargeID=c.recID"
            sql_String += " where w.wbID=" & recID & " and c.shortname in ('COMM')"
            sql_String += " select isnull(sum(w.cost),0) [costother] from WaybillCosting w inner join chargeElements c on w.chargeID=c.recID"
            sql_String += " where w.wbID=" & recID & " and c.shortname in ('OTHER')"
            dstmp = setDataList(sql_String)

            'If dstmp.Tables(0).Rows.Count > 0 Then dblAmtRev = dstmp.Tables(0).Rows(0).Item("rev")
            'txtServiceChargesRevenue.Text = dblAmtRev.ToString("N")
            'dblAmt = 0
            'If dstmp.Tables(1).Rows.Count > 0 Then dblAmt = dstmp.Tables(1).Rows(0).Item("revother")
            'txtOtherChargeRevenue.Text = dblAmt.ToString("N")
            ''dblAmt = 0

            If dstmp.Tables(2).Rows.Count > 0 Then dblAmtCos = dstmp.Tables(2).Rows(0).Item("cos")
            If dstmp.Tables(4).Rows.Count > 0 Then dblAmtOther = dstmp.Tables(4).Rows(0).Item("costother")

            If rbCompanyTruck.Checked Then
                txtDriverTripAmount.Text = dblAmtCos.ToString("N")
                txtDriverOtherAmount.Text = dblAmtOther.ToString("N")
            End If
            If rbRental.Checked Then txtTotalServiceCharges.Text = (dblAmtCos + dblAmtOther).ToString("N")

            dblAmt = 0
            If dstmp.Tables(3).Rows.Count > 0 Then dblAmt = dstmp.Tables(3).Rows(0).Item("commission")
            txtBrokerCommission.Text = dblAmt.ToString("N")
            dblAmt = 0

        Catch ex As Exception
            Me.Cursor = Cursors.Default
            lblMessage.Text = ex.Message
            PanelMessage.Visible = True
        End Try
        Me.Cursor = Cursors.Default
    End Sub


    Private Sub TabControlDetail_Click(sender As Object, e As EventArgs) Handles TabControlDetail.Click
        If TabControlDetail.SelectedIndex = 1 Then 'billing clicked
            PanelCostCompany.Visible = False : PanelCostRental.Visible = False
            If rbCompanyTruck.Checked Then PanelCostCompany.Visible = True
            If rbRental.Checked Then PanelCostRental.Visible = True
            PanelCreateBillingButton.Visible = False
            txtCreditorNameCompany.Text = cmbTransporter.Text
            If Not String.IsNullOrEmpty(txtDriverName.Text) Then txtCreditorNameCompany.Text = cmbTransporter.Text & "," & txtDriverName.Text
            txtCreditorNameCompany.Tag = cmbTransporter.Tag
            Call InitDataGridRevenue()
            'check for 
            If Not wbBillingDataExists Then
                PanelCreateBillingButton.Visible = True
                PanelCreateBillingButton.BringToFront()
                btnCreateBillingData.Focus()

            End If
        End If
    End Sub
    Private Sub lnkIssueITR_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkIssueITR.LinkClicked
        Dim bkcommission As Double = 0
        If Not IsNumeric(txtBrokerCommission.Text) Then txtBrokerCommission.Text = 0
        bkcommission = txtBrokerCommission.Text
        If Not ValidateDataBeforeBilling() Then Exit Sub
        formReturnValueINT = 0 : formReturnValueDBL = 0 : formReturnValyeSTR = ""

        If recID > 0 Then
            Dim mtitle As String = lblJobNumber.Text & " - " & lblWaybillNumber.Text & " Delivered On [" & txtDateOfDelivery.Text & "]"
            Dim frm As New frmRentalChargesITR(actRecID, recID, txtAdvancePayment.Text, txtAdvancePaymentNote.Text, mtitle)
            frm.ShowDialog(Me)
            If formReturnValueINT > 0 Then
                txtTotalServiceCharges.Text = (formReturnValueDBL - bkcommission).ToString("N")
                txtTotalServiceCharges.Tag = formReturnValueINT
                txtITRNumber.Text = formReturnValueINT
                lblITRDate.Text = formReturnValyeSTR
                Call Totals()
                txtTotalServiceCharges.Focus()
                txtTotalServiceCharges.SelectAll()
            End If
        End If
    End Sub

    Private Sub txtBrokerCommission_LostFocus(sender As Object, e As EventArgs) Handles txtBrokerCommission.LostFocus
        If Not IsNumeric(txtBrokerCommission.Text) Then txtBrokerCommission.Text = 0
        Call Totals()
    End Sub
    Private Sub txtServiceChargesRevenue_LostFocus(sender As Object, e As EventArgs)
        Call Totals()
    End Sub
    Private Sub txtOtherChargeRevenue_LostFocus(sender As Object, e As EventArgs)
        Call Totals()
    End Sub
    Private Sub txtDriverTripAmount_LostFocus(sender As Object, e As EventArgs) Handles txtDriverTripAmount.LostFocus
        Call Totals()
    End Sub


    Private Sub Totals()
        Dim dblVal1 As Double = 0
        Dim dblVal2 As Double = 0
        Dim dblVal3 As Double = 0
        Dim dblVal4 As Double = 0
        Dim TotalCostCharges As Double = 0
        Dim dblcost, dblrev As Double
        Dim dblTotalServiceChargesRental As Double = 0


        If Not IsNumeric(txtTotalCost.Text) Then txtTotalCost.Text = 0
        If Not IsNumeric(txtAdvancePayment.Text) Then txtAdvancePayment.Text = 0
        If Not IsNumeric(txtBrokerCommission.Text) Then txtBrokerCommission.Text = 0
        If Not IsNumeric(txtDriverTripAmount.Text) Then txtDriverTripAmount.Text = 0
        If Not IsNumeric(txtDriverOtherAmount.Text) Then txtDriverOtherAmount.Text = 0
        If Not IsNumeric(txtTotalServiceCharges.Text) Then txtTotalServiceCharges.Text = 0

        dblTotalServiceChargesRental = txtTotalServiceCharges.Text

        'company trk cost
        dblVal1 = txtDriverTripAmount.Text
        dblVal2 = txtDriverOtherAmount.Text
        dblVal4 = txtBrokerCommission.Text
        dblVal3 = (dblVal1 + dblVal2 + dblVal4 + dblTotalServiceChargesRental)
        dblcost = dblVal3
        txtTotalCost.Text = dblVal3.ToString("N")
        dblVal3 = (dblVal1 + dblVal2)
        dblrev = dblVal3

        '
        '    txtTotalRevenue.Text = dblVal3.ToString("N")

        'lblTotalProfit.Text = (dblrev - dblcost).ToString("N")


    End Sub

    Private Function AddChargeItemsToWaybillCosting() As Boolean
        Dim rtnval As Boolean = True
        PanelMessage.Visible = False
        sql_String = "insert into WaybillCosting(actRecID,wbID,chargeID) "
        sql_String += " select " & actRecID & "," & recID & ",c.recid from [chargeElements] c Where c.block=0 and c.AddToWaybillAuto=1"
        Try
            Me.Cursor = Cursors.WaitCursor
            If sql_CNN.State = ConnectionState.Closed Then createConnection()
            Dim commandy As New SqlCommand(sql_String, sql_CNN)
            commandy.ExecuteNonQuery()
            Me.Cursor = Cursors.Default

        Catch ex As Exception
            rtnval = False
            lblMessage.Text = ex.Message : PanelMessage.Visible = True
        End Try
        Me.Cursor = Cursors.Default
        Return rtnval
    End Function

    Private Sub txtDriverOtherAmountNote_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDriverOtherAmountNote.KeyDown
        If e.KeyCode = Keys.Tab Then
            txtBrokerCommission.Focus()
            txtBrokerCommission.SelectAll()
        End If
    End Sub

    Private Function UpdateWaybillCostingTable(chargecode As String, chargeamount As Double, chargenote As String, chargetype As Integer) As Boolean
        Dim rtnval As Boolean = True
        PanelMessage.Visible = False
        sql_String = " update w set "
        If chargetype = 0 Then
            sql_String += " w.cost=" & chargeamount & ",w.linenotecost=N'" & Replace(chargenote, "'", "") & "'"
        Else
            sql_String += " w.revenue=" & chargeamount & ",w.linenoterevenue=N'" & Replace(chargenote, "'", "") & "'"
        End If

        sql_String += " from WaybillCosting w inner join chargeElements c on w.chargeID=c.recID"
        sql_String += "  where w.actrecid=" & actRecID & " and wbid=" & recID & " and c.shortname in ('" & chargecode & "')"
        Try
            Me.Cursor = Cursors.WaitCursor
            If sql_CNN.State = ConnectionState.Closed Then createConnection()
            Dim commandy As New SqlCommand(sql_String, sql_CNN)
            commandy.ExecuteNonQuery()
            Me.Cursor = Cursors.Default

        Catch ex As Exception
            rtnval = False
            lblMessage.Text = ex.Message : PanelMessage.Visible = True
        End Try
        Return rtnval
    End Function

    Private Sub txtBackLoadNote_GotFocus(sender As Object, e As EventArgs) Handles txtBackLoadNote.GotFocus
        txtBackLoadNote.SelectAll()
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


    'driver cost
    Private Sub lblListTariffRates_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblListTariffRates.LinkClicked
        sql_String = "select isnull(triprate,0)+isnull(otheramount,0) [amt] from [viewDriverTripRates_TTS] "
        sql_String += " where locid1=" & locid1 & " and locid2=" & locid2 & " and eqprecid=" & cmbEquipmentType.Tag
        If locid1 > 0 And locid2 > 0 And cmbEquipmentType.Tag > 0 Then
            Me.Cursor = Cursors.WaitCursor
            Try
                Dim dstmp As New DataSet
                dstmp = setDataList(sql_String)
                If dstmp.Tables(0).Rows.Count > 0 Then
                    txtDriverTripAmount.Text = dstmp.Tables(0).Rows(0).Item("amt")
                    Call Totals()
                    txtDriverTripAmount.Focus()
                End If
            Catch ex As Exception
                lblMessage.Text = ex.Message
                PanelMessage.Visible = True
            End Try
            Me.Cursor = Cursors.Default
        End If

        'If recID > 0 Then
        '    Dim mtitle As String = "Driver Trip Rates"

        '    Dim frm As New frmTripRatesListForm(lblUnlocoA.Text, cmbEquipmentType.Tag, 1, 0, lblEqpType1.Text, 0, mtitle)
        '    frm.ShowDialog(Me)
        '    If formReturnValueINT > 0 Then
        '        txtDriverTripAmount.Text = formReturnValueDBL.ToString("N")
        '        txtDriverTripAmount.Tag = formReturnValueINT
        '        Call Totals()
        '        txtDriverTripAmount.SelectAll()
        '        txtDriverTripAmount.Focus()

        '    End If
        'End If
    End Sub

    Private Sub lblRecordID_DoubleClick(sender As Object, e As EventArgs) Handles lblRecordID.DoubleClick
        panelEquipmentDetail.Enabled = True
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Dim rptname As String = ""
        Dim rptformula As String = ""
        Dim paramval As String = ""
        Try
            paramval = IIf(String.IsNullOrEmpty(txtExpectedLoadingDate.Text), "   ", txtExpectedLoadingDate.Text)
            'If writeWaybillDataToLocalDBAccess(recID, 0, False) Then
            If recID = 0 Then Return
            frmWaitForm.lblTitle.Text = "Loading Master Data. please wait..!"
            frmWaitForm.Show()
            frmWaitForm.Refresh()
            rptname = Application.StartupPath & appCompanyInfo.customizerptpath & "\iffWaybillTTS004.rpt"
            rptformula = "{viewQueryWaybillRecord2018.WBID}=" & recID
            Dim frm As New frmCrystalReportViewer(rptname, rptformula, False, "", "", False)
            frm.Show()
            frm.Focus()
            ' End If

        Catch ex As Exception
            frmWaitForm.Close()
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try
        frmWaitForm.Close()
    End Sub

    Private Sub InitDataGridRevenue()
        PanelMessage.Visible = False
        sql_String = " select c.name [Service Charge], cast(w.revenue as decimal(10,2))[Amount], cast(w.VAT as decimal(10,2)) [Tax Amount], cast(w.revenue+w.vat as decimal(10,2)) [Total], w.linenoterevenue [Note], w.recid "
        sql_String += " from waybillcosting w inner join chargeElements c on w.chargeid=c.recid"
        sql_String += " where   (c.revenue = 1) and w.wbid=" & recID
        Dim dsx As New DataSet
        Try
            Me.Cursor = Cursors.WaitCursor
            DGridView.DataSource = Nothing
            dsx = setDataList(sql_String)
            If dsx.Tables(0).Rows.Count > 0 Then
                DGridView.DataSource = dsx.Tables(0)
                DGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
                DGridView.ReadOnly = True
                DGridView.Columns("recid").Visible = False
                DGridView.Columns("Amount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGridView.Columns("Tax Amount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGridView.Columns("total").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                '  DGridView.RowHeadersDefaultCellStyle.Padding = New Padding(DGridView.RowHeadersWidth)
                DGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect
                DGridView.RowHeadersVisible = False
                DGridView.Font = New Font("Arial", 8, FontStyle.Bold)
                DGridView.RowsDefaultCellStyle.Font = New Font("Arial", 8, FontStyle.Regular)
                'get total revenue
                sql_String = " select isnull(sum(revenue),0) [revtot] from waybillcosting where revenue>0 and wbid=" & recID
                dsx = setDataList(sql_String)
                If dsx.Tables(0).Rows.Count > 0 Then txtTotalRevenue.Text = dsx.Tables(0).Rows(0).Item("revtot")
                Call Totals()
            End If
        Catch ex As Exception
            lblMessage.Text = ex.Message
            PanelMessage.Visible = True
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub DGridView_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGridView.CellDoubleClick
        Dim rowid As Integer = 0
        rowid = DGridView.Rows(e.RowIndex).Cells("recid").Value
        If rowid > 0 Then
            Dim frm As New frmWaybillSellingChargeList(rowid, orgRecID, locid1, locid2, recID)
            frm.ShowDialog()
            Call InitDataGridRevenue()
        End If
    End Sub

    Private Sub lblCancelWaybill_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblCancelWaybill.LinkClicked
        PanelMessage.Visible = False
        Try
            If MsgBox("You are about to cancel this Waybill. Continue  ?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo + vbDefaultButton2, "Cancel Waybill") = MsgBoxResult.No Then Return
            Me.Cursor = Cursors.WaitCursor

            If sql_CNN.State = ConnectionState.Closed Then createConnection()
            Dim sqlcmd As SqlCommand = sql_CNN.CreateCommand()
            sql_String = "delete from [waybillcosting] where wbid=" & recID
            sqlcmd.CommandText = sql_String
            sqlcmd.ExecuteNonQuery()

            sql_String = "update [waybills] set wbcancelled=1,  wbstatus='CANCELLED' where recid=" & recID
            sqlcmd.CommandText = sql_String
            sqlcmd.ExecuteNonQuery()

            lblStatus.Text = "Status - CANCELLED"

            TabControlDetail.SelectedIndex = 0
            PanelWaybillFrame.Enabled = False
            Panel1.Enabled = False
            Me.Cursor = Cursors.Default

        Catch ex As Exception
            PanelMessage.Visible = True
            lblMessage.Text = ex.Message : PanelMessage.Visible = True
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub DGridView_KeyDown(sender As Object, e As KeyEventArgs) Handles DGridView.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim rowid As Integer = 0
            rowid = DGridView.Rows(DGridView.CurrentRow.Index).Cells("recid").Value
            If rowid > 0 Then
                Dim frm As New frmWaybillSellingChargeList(rowid, orgRecID, locid1, locid2, recID)
                frm.ShowDialog()
                Call InitDataGridRevenue()
            End If
        End If
    End Sub

    Private Sub lnkListOtherPOD_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkListOtherPOD.LinkClicked
        Call refresh_organizationCNEE(cmbOrgPlaceOfDelivery, "IsConsignee=1")
        cmbOrgPlaceOfDelivery.Focus()
    End Sub

    Private Sub TabControlAddress_Click(sender As Object, e As EventArgs) Handles TabControlAddress.Click
        If TabControlAddress.SelectedIndex = 1 Then lblAddrSelect.Visible = False
    End Sub

    Private Sub cmbPOLCountry_LostFocus(sender As Object, e As EventArgs) Handles cmbPOLCountry.LostFocus
        If cmbPOLCountry.SelectedValue <> "" Then
            cmbPOLCountry.Tag = 0
            Dim selectedRow As GridViewDataRowInfo = DirectCast(cmbPOLCountry.SelectedItem, GridViewDataRowInfo)
            cmbPOLCountry.Tag = (selectedRow.Cells("recid").Value.ToString())
            cmbPOLCountry.Text = (selectedRow.Cells("shortname").Value.ToString())
            refresh_cities(cmbPOLCountry.Text, cmbPOLCity)
        End If
    End Sub

    Private Sub cmbPODCountry_LostFocus(sender As Object, e As EventArgs) Handles cmbPOdCountry.LostFocus
        If cmbPOdCountry.SelectedValue <> "" Then
            Dim selectedRow As GridViewDataRowInfo = DirectCast(cmbPOdCountry.SelectedItem, GridViewDataRowInfo)
            cmbPOdCountry.Tag = (selectedRow.Cells("recid").Value.ToString())
            cmbPOdCountry.Text = (selectedRow.Cells("shortname").Value.ToString())
            refresh_cities(cmbPOdCountry.Text, cmbPODCity)
        End If
    End Sub

    Private Sub cmbPODCity_LostFocus(sender As Object, e As EventArgs) Handles cmbPODCity.LostFocus
        If cmbPODCity.SelectedValue <> "" Then
            Dim selectedRow As GridViewDataRowInfo = DirectCast(cmbPODCity.SelectedItem, GridViewDataRowInfo)
            cmbPODCity.Tag = (selectedRow.Cells("id").Value.ToString())
            cmbPODCity.Text = (selectedRow.Cells("name").Value.ToString())
            lblUnlocoB.Text = (selectedRow.Cells("code").Value.ToString())
        End If
    End Sub

    Private Sub cmbPOLCity_LostFocus(sender As Object, e As EventArgs) Handles cmbPOLCity.LostFocus
        If cmbPOLCity.SelectedValue <> "" Then
            Dim selectedRow As GridViewDataRowInfo = DirectCast(cmbPOLCity.SelectedItem, GridViewDataRowInfo)
            cmbPOLCity.Tag = (selectedRow.Cells("id").Value.ToString())
            cmbPOLCity.Text = (selectedRow.Cells("name").Value.ToString())
            lblUnlocoA.Text = (selectedRow.Cells("code").Value.ToString())
        End If
    End Sub

    Private Sub refresh_cities(iCountryCode As String, cmbName As Object)
        If iCountryCode = "" Then lblMessage.Text = "Invalid Country Code" : Exit Sub
        Me.Cursor = Cursors.WaitCursor
        sql_String = " select area as name, unloco as code, recid as id, countrycode from [locationmaster] where isActive=1 and countrycode='" & iCountryCode & "' order by name"
        '        sql_String = " select name, code,id from [unloco] where id>0 and isActive=1 and countrycode='" & iCountryCode & "' order by name"
        Call fillCombo(cmbName, sql_String, 0, 300, 100, 50)
        cmbName.Columns(2).VisibleInColumnChooser = False
        cmbName.Tag = 0 : cmbName.Text = ""
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cmbOrgPlaceOfDelivery_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbOrgPlaceOfDelivery.SelectedIndexChanged

    End Sub
End Class