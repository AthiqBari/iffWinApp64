'Customized Trip Cost Form ITR Form developed for TransArab And JEDEX
'05-Aug-2018 - 
Imports Telerik.WinControls.UI
Imports System.Data.Sql
Imports System.Data
Imports System.Data.SqlClient
Imports System.Exception
Imports System.Data.OleDb
Imports System.IO
Imports Excel = Microsoft.Office.Interop.Excel
Public Class frmRentalChargesITR

    Dim intWBRecID As Integer = 0
    Dim intActRecID As Integer = 0
    Dim dblAdvancePayment As Double = 0
    Dim strAdvancePaymentNote As String = ""
    Dim action As String = ""
    Dim jobNumber As String = ""

    Dim locid1 As Integer = 0
    Dim locid2 As Integer = 0

    Dim batchslno As String = ""
    Dim drivername As String = ""
    Dim containerstr As String = ""
    Dim qtypallet As String = ""
    Dim netwgt As String = ""
    Dim polstr As String = ""
    Dim podstr As String = ""
    Dim loadingdt As String = ""
    Dim deliverydt As String = ""

    Public Sub New(mactrecid As Integer, mwbrecid As Integer, mAdvancePayment As Double, mAdvancePaymentText As String, mTitle As String)
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        intWBRecID = mwbrecid
        intActRecID = mactrecid
        dblAdvancePayment = mAdvancePayment
        lblFormTitle.Text = mTitle
        strAdvancePaymentNote = mAdvancePaymentText
    End Sub

    Private Sub frmRentalChargesITR_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call clearForm()
        Call refresh_chargecodes(cmbChargeList)
        If intWBRecID > 0 Then
            Call getITRHeaderInfo()
            Call fillGrid()
            Call calcTotal()
        End If
        If txtITRNumber.Text = 0 Then
            txtITRNumber.Text = generateITRNo()
            txtITRDate.Text = Now
            txtAdvancePayment.Text = dblAdvancePayment.ToString("N")
            txtRemarks.Text = strAdvancePaymentNote
        End If

    End Sub

    Private Function generateITRNo() As Integer
        Dim rtnval As Integer = 0
        sql_String = "select (isnull(max(itrno),1)+1) [itrno] from [waybills] where branchID=" & appUserInfo.BranchId
        Try
            Dim ds As New DataSet
            ds = setDataList(sql_String)
            If ds.Tables(0).Rows.Count > 0 Then rtnval = ds.Tables(0).Rows(0).Item("itrno")
        Catch ex As Exception
            rtnval = 0
            lblMessage.Text = ex.Message
        End Try
        Return rtnval
    End Function

    Private Sub getITRHeaderInfo()
        Dim rtnval As Boolean = False
        sql_String = "select  * "
        '[Job No], wbno, itrno,itrdate,itrrefno,itrnote, client,  TransporterName, OrgTrnID,DriverNameLocal,goodsdesc,EqpName,EqpType,PlateNo,"
        '      sql_String += " unloco1, unloco2, PickupAddress, DeliveryAddress, AdvanceCost, actRecID, WBID,itrissuedby,itrupdatedby,AdvanceCostNote,"
        '    sql_String += " LocArea1,LocArea2, locid1, locid2,EqpGrpID,batchslno"
        sql_String += " from [dbo].[viewQueryWaybillRecord2018]"
        sql_String += " where WBID=" & intWBRecID
        lblMessage.Text = "" : PanelMessage.Visible = False
        Me.Cursor = Cursors.WaitCursor
        Try
            Dim dstmp As New DataSet
            dstmp = setDataList(sql_String)
            If dstmp.Tables(0).Rows.Count > 0 Then
                With dstmp.Tables(0).Rows(0)
                    txtITRNumber.Text = .Item("itrno")
                    If IsDate(.Item("itrdate")) Then txtITRDate.Text = .Item("itrdate")
                    txtCreditorNameCompany.Text = .Item("TransporterName") & " - " & .Item("DriverNameLocal")
                    txtCreditorNameCompany.Tag = .Item("OrgTrnID")
                    jobNumber = .Item("Job No")

                    txtRemarks.Text = .Item("itrnote")
                    txtRefNo.Text = .Item("itrrefno")
                    txtCargoDesc.Text = .Item("goodsdesc")
                    txtEqpType.Text = .Item("EqpType")
                    txtEqpType.Tag = .Item("eqpgrpid")
                    txtEqpNo.Text = .Item("eqpname") & " " & .Item("plateno")
                    lblPOLPOD.Text = .Item("unloco1") & " - " & .Item("unloco2")
                    txtPOLPOD.Text = .Item("DeliveryAddress")



                    batchslno = .Item("batchslno")
                    drivername = .Item("DriverNameLocal") & " " & .Item("drivercontact")
                    containerstr = .Item("containerNo") & " " & .Item("containerType") & " " & .Item("cntrRefNo")
                    qtypallet = .Item("loadqty")
                    netwgt = .Item("netwght")
                    polstr = .Item("pickupaddress") & " " & .Item("UNLOCO1")
                    podstr = .Item("deliveryaddress") & " " & .Item("UNLOCO2")
                    loadingdt = .Item("loadingdate")
                    deliverydt = .Item("deliverydate")


                    locid1 = .Item("locid1")
                    locid2 = .Item("locid2")
                    lblOriginLocation.Text = .Item("LocArea1")
                    lblDestinationLocation.Text = .Item("LocArea2")


                    If IsDate(.Item("itrdate")) Then
                        lblCreatedBy.Text = "Issued By / On  [" & .Item("itrissuedby") & " " & .Item("itrdate") & "]"
                        lblUpdatedBy.Text = "Last Updated By / On [" & .Item("itrupdatedby") & "]"
                    End If
                    txtAdvancePayment.Text = .Item("AdvanceCost")
                    lblRecordID.Text = "Record ID:[" & intWBRecID & "]"
                End With


                rtnval = True
            Else
                lblMessage.Text = "Waybill Details Not Found" : PanelMessage.Visible = True
            End If
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            lblMessage.Text = ex.Message
            PanelMessage.Visible = True
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub calcTotal()
        Dim dblVal1 As Double = 0
        Dim dblVal2 As Double = 0
        Dim dblVal3 As Double = 0
        Dim dblValVAT As Double = 0
        Dim rowIndex As Integer = 0
        dblVal1 = txtAdvancePayment.Text
        txtAdvancePayment.Text = dblVal1.ToString("N")
        'read thru grid and get the value
        With DGridView
            For rowIndex = 0 To .RowCount - 1
                If IsNumeric(.Rows(rowIndex).Cells("Cost").Value) Then dblVal2 += Double.Parse(.Rows(rowIndex).Cells("Cost").Value)
                If IsNumeric(.Rows(rowIndex).Cells("vat").Value) Then dblValVAT += Double.Parse(.Rows(rowIndex).Cells("vat").Value)
            Next
        End With

        dblVal3 = (dblVal2 - dblVal1)
        txtTotalCharges.Text = dblVal2.ToString("N")
        txtTotalvAT.Text = dblValVAT.ToString("N")
        txtAmountToPay.Text = (dblVal3).ToString("N")
    End Sub


    Private Sub clearForm()

        txtITRNumber.Text = 0 : txtITRDate.Clear()
        txtCreditorNameCompany.Clear()
        txtRefNo.Clear()
        txtCargoDesc.Clear()
        txtEqpNo.Clear() : txtEqpType.Clear()
        txtEqpType.Tag = 0
        txtEqpType.Clear()
        txtPOLPOD.Clear()
        lblCreatedBy.Text = "Created By"
        lblRecordID.Text = "Record ID:[" & intWBRecID & "]"
        lblUpdatedBy.Text = "Updated By"
        formReturnValueDBL = 0
        formReturnValueINT = 0
        Call clearChargeInput()
        DGridView.DataSource = Nothing

        txtTotalCharges.Text = 0
        txtAmountToPay.Text = 0
        txtTotalvAT.Text = 0
    End Sub
    Private Sub clearChargeInput()
        txtServiceAmount.Clear()
        cmbChargeList.Text = "" : cmbChargeList.Tag = 0
        txtServiceAmount.Text = 0
        txtChargeDesc.Clear()
        txtServiceAmount.Tag = 0
        txtVATCost.Text = 0

    End Sub

    Private Sub btnSaveAnPrint_Click(sender As Object, e As EventArgs) Handles btnSaveAnPrint.Click

        Try
            Me.Cursor = Cursors.WaitCursor
            If sql_CNN.State = ConnectionState.Closed Then createConnection()
            sql_String = "update dbo.waybills set itrno=" & txtITRNumber.Text & ",itrdate='" & CDate(txtITRDate.Text) & "',"
            sql_String += " itrrefno='" & Replace(txtRefNo.Text, "'", "") & "',itrnote='" & Replace(txtRemarks.Text, "'", "") & "',itruser1='" & Microsoft.VisualBasic.Left(appUserInfo.Name, 20) & "',"
            sql_String += " itruser2='" & Microsoft.VisualBasic.Left(appUserInfo.Name, 20) & "' "
            sql_String += " where recid=" & intWBRecID
            Dim commandx As New SqlCommand(sql_String, sql_CNN)
            commandx.ExecuteNonQuery()
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try

        ' Me.Close()
    End Sub
    Private Sub frmRentalChargesITR_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        formReturnValueDBL = txtTotalCharges.Text
        formReturnValueINT = txtITRNumber.Text
        formReturnValyeSTR = txtITRDate.Text
    End Sub

   

    Private Sub txtChargeCode_GotFocus(sender As Object, e As EventArgs) Handles txtChargeCode.GotFocus
        txtChargeCode.SelectAll()
    End Sub

    Private Sub txtChargeCode_LostFocus(sender As Object, e As EventArgs) Handles txtChargeCode.LostFocus
        lblMessage.Text = "" : PanelMessage.Visible = False
        ' If cmbChargeList.Tag = txtChargeCode.Tag Then Exit Sub
        If Not String.IsNullOrEmpty(txtChargeCode.Text) Then
            sql_String = "select recid,name from [chargeElements] where shortname='" & txtChargeCode.Text & "' and block=0"
            Try
                Me.Cursor = Cursors.WaitCursor
                Dim ds As New DataSet
                ds = setDataList(sql_String)
                If ds.Tables(0).Rows.Count > 0 Then
                    cmbChargeList.Text = ds.Tables(0).Rows(0).Item("name")
                    txtChargeCode.Tag = ds.Tables(0).Rows(0).Item("recid")
                    cmbChargeList.Tag = txtChargeCode.Tag
                Else
                    lblMessage.Text = "Charge Code Not Found"
                    PanelMessage.Visible = True
                    cmbChargeList.Tag = 0 : cmbChargeList.Text = ""
                    txtChargeCode.Tag = 0
                End If
            Catch ex As Exception
                Me.Cursor = Cursors.Default
                lblMessage.Text = ex.Message
                PanelMessage.Visible = True
            End Try
            Me.Cursor = Cursors.Default
        End If
    End Sub
    Private Sub refresh_chargecodes(cmbName As Object)
        Me.Cursor = Cursors.WaitCursor
        sql_String = "select Name,  shortname [Code], recid from [chargeElements] where block=0 order by shortname;"
        Call fillCombo(cmbName, sql_String, 0, 0, 100, 50)
        cmbName.Columns(2).VisibleInColumnChooser = False
        cmbName.Tag = 0 : cmbName.Text = ""
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub fillGrid()
        Dim dsx As New DataSet
        lblMessage.Text = "" : PanelMessage.Visible = False
        Try
            sql_String = "select c.shortname [Code],c.name [Charge],wb.vatcost [VAT], wb.cost [Cost],wb.linenotecost [LineNote],c.recid [crecid],wb.recid [wcrecid] "
            sql_String += " from WaybillCosting wb inner join chargeElements c on wb.chargeID=c.recID "
            sql_String += " where wb.wbID=" & intWBRecID
            Me.Cursor = Cursors.WaitCursor
            DGridView.DataSource = Nothing
            dsx = setDataList(sql_String)
            If dsx.Tables(0).Rows.Count > 0 Then
                DGridView.DataSource = dsx.Tables(0)
                DGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
                DGridView.ReadOnly = True
                DGridView.Columns(5).Visible = False
                DGridView.Columns(6).Visible = False
                DGridView.Columns("vat").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGridView.Columns("cost").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If
        Catch ex As Exception
            lblMessage.Text = ex.Message
            PanelMessage.Visible = True
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub cmbChargeList_LostFocus(sender As Object, e As EventArgs) Handles cmbChargeList.LostFocus
        If cmbChargeList.SelectedValue <> "" Then
            cmbChargeList.Tag = 0
            Dim selectedRow As GridViewDataRowInfo = DirectCast(cmbChargeList.SelectedItem, GridViewDataRowInfo)
            cmbChargeList.Tag = (selectedRow.Cells("recid").Value.ToString())
            txtChargeCode.Text = (selectedRow.Cells("code").Value.ToString())
            cmbChargeList.Text = (selectedRow.Cells("name").Value.ToString())
            txtChargeCode.Tag = cmbChargeList.Tag
        End If
    End Sub
    Private Sub DGridView_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGridView.CellDoubleClick
        txtChargeCode.Text = DGridView.Rows(e.RowIndex).Cells("code").Value
        txtChargeCode.Tag = DGridView.Rows(e.RowIndex).Cells("crecid").Value
        cmbChargeList.Text = DGridView.Rows(e.RowIndex).Cells("charge").Value
        cmbChargeList.Tag = DGridView.Rows(e.RowIndex).Cells("crecid").Value
        txtServiceAmount.Text = DGridView.Rows(e.RowIndex).Cells("Cost").Value
        txtChargeDesc.Text = DGridView.Rows(e.RowIndex).Cells("linenote").Value
        txtServiceAmount.Tag = DGridView.Rows(e.RowIndex).Cells("wcrecid").Value
        txtVATCost.Text = DGridView.Rows(e.RowIndex).Cells("vat").Value

        action = "E"
        txtServiceAmount.Focus()
        txtServiceAmount.SelectAll()
    End Sub
    Private Sub txtServiceAmount_GotFocus(sender As Object, e As EventArgs) Handles txtServiceAmount.GotFocus
        txtServiceAmount.SelectAll()
    End Sub
    Private Sub btnAddEntry_Click(sender As Object, e As EventArgs) Handles btnAddEntry.Click
        Call clearChargeInput()
        action = "A"
        txtChargeCode.Focus()
    End Sub
    Private Sub txtServiceAmount_LostFocus(sender As Object, e As EventArgs) Handles txtServiceAmount.LostFocus
        Dim dblval As Double = 0
        If Not IsNumeric(txtServiceAmount.Text) Then txtServiceAmount.Text = 0
        dblval = txtServiceAmount.Text
        txtServiceAmount.Text = dblval.ToString("N")
    End Sub
    Private Sub txtChargeDesc_GotFocus(sender As Object, e As EventArgs) Handles txtChargeDesc.GotFocus
        txtChargeDesc.SelectAll()
    End Sub

    Private Sub btnSaveEntry_Click(sender As Object, e As EventArgs) Handles btnSaveEntry.Click
        If action = "" Then Exit Sub
        If txtChargeCode.Tag = 0 Or String.IsNullOrEmpty(txtChargeCode.Text) Then
            lblMessage.Text = "Check Input Values"
            PanelMessage.Visible = True
            Exit Sub
        End If


        If action = "A" Then    'adding newitem
            sql_String = "insert into [waybillcosting] (actrecid,wbid,chargeid,cost,linenotecost,vatcost,vatcostpercent)"
            sql_String += " values(" & intActRecID & "," & intWBRecID & "," & txtChargeCode.Tag & "," & txtServiceAmount.Text & ",'" & Replace(txtChargeDesc.Text, "'", "") & "',"
            sql_String += Val(txtVATCost.Text) & "," & IIf(txtVATCost.Text > 0, appCompanyInfo.VATPercentage, 0) & ");"
        End If

        If action = "E" Then 'edited item
            sql_String = "update [WaybillCosting] set chargeid=" & txtChargeCode.Tag & ","
            sql_String += " cost=" & CDbl(txtServiceAmount.Text) & ",linenotecost='" & Replace(txtChargeDesc.Text, "'", "") & "',"
            sql_String += " vatcost=" & CDbl(txtVATCost.Text) & ",vatcostpercent=" & IIf(txtVATCost.Text > 0, appCompanyInfo.VATPercentage, 0)
            sql_String += " where recid=" & txtServiceAmount.Tag
        End If

        Try
            Me.Cursor = Cursors.WaitCursor
            If sql_CNN.State = ConnectionState.Closed Then createConnection()
            Dim commandy As New SqlCommand(sql_String, sql_CNN)
            commandy.ExecuteNonQuery()
            Me.Cursor = Cursors.Default
            action = ""
            clearChargeInput()

            Call fillGrid()
            Call calcTotal()

        Catch ex As Exception
            lblMessage.Text = ex.Message : PanelMessage.Visible = True
        End Try
        Me.Cursor = Cursors.Default


    End Sub

    Private Sub btnOkVendor_Click(sender As Object, e As EventArgs) Handles btnOkVendor.Click
        If IsNumeric(lblVendorBuyingRate.Text) Then txtServiceAmount.Text = lblVendorBuyingRate.Text
        panelVendorBuyingRate.Visible = False
        btnSaveAnPrint.Enabled = True
        btnPrint.Enabled = True
        If Not IsNumeric(txtVendorTotalRate.Text) Then txtVendorTotalRate.Text = 0
        If txtVendorTotalRate.Text > 0 Then
            txtServiceAmount.Text = txtVendorTotalRate.Text
            If String.IsNullOrEmpty(txtChargeDesc.Text) Then txtChargeDesc.Text = txtVendorLineNote.Text

        End If
    End Sub

    Private Sub lblListTariffRates_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblListTariffRates.LinkClicked
        btnSaveAnPrint.Enabled = False
        PanelMessage.Visible = False
        btnPrint.Enabled = False
        lblVendorName.Text = txtCreditorNameCompany.Text
        lblVendorEqpType.Text = txtEqpType.Text

        txtVendorBaseRate.Text = 0
        txtVendorAdditionalRate.Text = 0
        txtVendorTotalRate.Text = 0
        txtVendorLineNote.Text = 0
        'get rates
        Dim rtnval As Integer = 0
        sql_String = "select  isnull(costAmt,0) [baserate], isnull(costAmtOther,0) [otheramt], ISNULL(costamt,0)+ISNULL(costamtother,0) [cost], isnull(lineNote,'') [note]"
        sql_String += " from [dbo].[viewOrganizationRates] "
        sql_String += " where orgrecid=" & txtCreditorNameCompany.Tag & " and loc1recid=" & locid1 & " and loc2recid=" & locid2 & ";"
        Try
            Dim ds As New DataSet
            ds = setDataList(sql_String)
            If ds.Tables(0).Rows.Count > 0 Then
                txtVendorBaseRate.Text = ds.Tables(0).Rows(0).Item("baserate")
                txtVendorAdditionalRate.Text = ds.Tables(0).Rows(0).Item("otheramt")
                txtVendorTotalRate.Text = ds.Tables(0).Rows(0).Item("cost")
                txtVendorLineNote.Text = ds.Tables(0).Rows(0).Item("note")
            End If
        Catch ex As Exception
            rtnval = 0
            lblMessage.Text = ex.Message
            PanelMessage.Visible = True
        End Try
        panelVendorBuyingRate.Visible = True
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        panelVendorBuyingRate.Visible = False
        btnSaveAnPrint.Enabled = True
        btnPrint.Enabled = True
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        If txtITRNumber.Text = 0 Then Exit Sub
        Dim excelFile As String = ""
        Try
            'excelFile = ExportToExcel_ITR()
            'If Not String.IsNullOrEmpty(excelFile) Then ExportToPDF(excelFile, "551")
            Dim rptname As String = ""
            Dim rptformula As String = ""
            rptformula = "{viewQueryWaybillRecord2018.branchid}=" & appCompanyInfo.branchID & " and {viewQueryWaybillRecord2018.itrno}=" & Val(txtITRNumber.Text)
            rptformula += " and {WaybillCosting.cost} > 0"
            '            rptformula = "{viewQueryWaybillRecord2018.itrno}=" & txtITRNumber.Text
            rptname = Application.StartupPath & appCompanyInfo.customizerptpath & "\iffWaybillITR002.rpt"
            Dim frm As New frmCrystalReportViewer(rptname, rptformula, False, "", "", "")
            frm.Show()
            frm.Focus()
        Catch ex As Exception
            frmWaitForm.Close()
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try
        frmWaitForm.Close()
    End Sub

#Region "ExcelExport"
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
    Private Function copyTemplate() As String
        Try
            Dim destinationFile As String = Application.StartupPath & "\excel files\"
            Dim sourceFile As String = Application.StartupPath & "\template\iffITR" & appUserInfo.BranchId & ".xls"
            Dim destinationFileName As String = jobNumber & " ITR" & txtITRNumber.Text & "-" & DateTime.Now.Hour.ToString + "" + DateTime.Now.Minute.ToString + "" + DateTime.Now.Second.ToString & ".xls"
            destinationFile = destinationFile.ToString & destinationFileName
            File.Copy(sourceFile, destinationFile)
            Return destinationFile
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "copyTemplate(...")
            Return ""
        End Try
    End Function
    Private Function ExportToExcel_ITR() As String
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim i As Integer = 0
            Dim endColumnIndex As Integer = 0

            Dim cellRowIndex As Integer = 1
            Dim cellColumnIndex As Integer = 1

            Dim destinationFile As String = copyTemplate()
            If IO.File.Exists(destinationFile) = False Then
                Me.Cursor = Cursors.Default
                MsgBox("File does not exists " & destinationFile, MsgBoxStyle.Exclamation, "File Not Found")
                Return ""
                Exit Function
            End If

            frmWaitForm.lblTitle.Text = "Preparing Document. Please Wait..!"
            frmWaitForm.Show()
            frmWaitForm.Refresh()
            Me.Cursor = Cursors.WaitCursor

            '.net 4.5
            Dim xlApp As New Excel.Application ' Microsoft.Office.Interop.Excel.ApplicationClass
            Dim xlWorkBook As Microsoft.Office.Interop.Excel.Workbook
            Dim xlWorkSheet As Microsoft.Office.Interop.Excel.Worksheet
            Dim objRadGrid As RadGridView = Nothing

            'objRadGrid = RadGridView2
            xlWorkBook = xlApp.Workbooks.Open(destinationFile, Password:="551")
            xlWorkSheet = xlWorkBook.Worksheets("Sheet1")

            'write company/branch report header section -------------------------------------------*--------------------------------
            xlWorkSheet.Cells(2, 8) = appCompanyInfo.companyName
            xlWorkSheet.Cells(3, 8) = appCompanyInfo.branchName
            xlWorkSheet.Cells(4, 8) = appCompanyInfo.branchAddress
            xlWorkSheet.Cells(6, 8) = appCompanyInfo.companyWebsite ' appCompanyInfo.branchContact & " " & appCompanyInfo.branchEmail
            '---------------------------------------------------------------------------'---*----------------------------------------
            xlWorkSheet.Cells(8, 4) = jobNumber.ToString
            xlWorkSheet.Cells(8, 11) = txtITRNumber.Text
            xlWorkSheet.Cells(9, 11) = txtITRDate.Text
            xlWorkSheet.Cells(10, 11) = txtRefNo.Text
            xlWorkSheet.Cells(9, 4) = txtCargoDesc.Text

            xlWorkSheet.Cells(12, 4) = intWBRecID
            xlWorkSheet.Cells(12, 6) = "'" & batchslno
            xlWorkSheet.Cells(13, 4) = polstr
            xlWorkSheet.Cells(15, 4) = podstr
            xlWorkSheet.Cells(13, 11) = loadingdt
            xlWorkSheet.Cells(15, 11) = deliverydt

            xlWorkSheet.Cells(17, 4) = txtCreditorNameCompany.Text
            xlWorkSheet.Cells(17, 11) = txtEqpType.Text & " " & txtEqpNo.Text
            xlWorkSheet.Cells(18, 4) = drivername
            xlWorkSheet.Cells(20, 4) = containerstr
            xlWorkSheet.Cells(20, 8) = qtypallet
            xlWorkSheet.Cells(20, 11) = netwgt


            xlWorkSheet.Cells(35, 7) = txtAdvancePayment.Text
            xlWorkSheet.Cells(37, 4) = txtRemarks.Text
            xlWorkSheet.Cells(43, 2) = lblCreatedBy.Text
            xlWorkSheet.Cells(43, 10) = Today.Date

            'read dsprint for invoice line items
            Dim colDescE As String = ""
            Dim colDescA As String = ""
            Dim dblRate As Double = 0
            Dim dblVATPercent As Double = 0
            Dim dblAdvanceAR As Double = 0

            cellRowIndex = 24 'start from

            For i = 0 To DGridView.Rows.Count - 1
                xlWorkSheet.Cells(cellRowIndex, 2) = DGridView.Rows(i).Cells("Charge").Value.ToString()
                xlWorkSheet.Cells(cellRowIndex, 7) = DGridView.Rows(i).Cells("Cost").Value.ToString()
                xlWorkSheet.Cells(cellRowIndex, 9) = DGridView.Rows(i).Cells("LineNote").Value.ToString()
                cellRowIndex += 1
            Next

            xlWorkSheet.Rows("" & (cellRowIndex + 1) & ":" & 33 & "").delete()
            'If dsPrint.Tables(0).Rows.Count > 0 Then
            '    For Each Row As DataRow In dsPrint.Tables(0).Rows
            '        'For Each Coll As DataColumn In dsPrint.Tables(0).Columns
            '        colDescE = Row("chgNameE").ToString()
            '        colDescA = Row("chgNameA").ToString()
            '        dblRate = CDbl(Row("revenue"))
            '        dblVATPercent = CDbl(Row("vatpercent"))
            '        dblAdvanceAR = CDbl(Row("AdvRev"))
            '        xlWorkSheet.Cells(cellRowIndex, 1) = colDescE & " " & colDescA
            '        xlWorkSheet.Cells(cellRowIndex, 6) = dblRate
            '        xlWorkSheet.Cells(cellRowIndex, 8) = dblVATPercent
            '        xlWorkSheet.Cells(cellRowIndex, 11) = dblAdvanceAR


            '        cellRowIndex += 1
            '        colDescA = ""
            '        colDescE = ""
            '        dblRate = 0
            '        dblVATPercent = 0
            '        dblAdvanceAR = 0
            '        'Next
            '    Next

            '    'lets delete blank item rows
            '    xlWorkSheet.Cells((cellRowIndex), 1) = "*****End Of Item List******"
            '    xlWorkSheet.Cells(53, 1) = "TXID " & arBillMaster.invRecID

            '    xlWorkSheet.Rows("" & (cellRowIndex + 1) & ":" & 38 & "").delete()
            'End If

            xlWorkBook.Close(SaveChanges:=True)
            xlApp.Quit()

            'If chkPDF.CheckState = CheckState.Unchecked Then
            '    xlApp.Workbooks.Open(destinationFile, Password:="5512730")
            '    ' xlWorkSheet = xlWorkBook.Worksheets("Sheet1")
            '    xlApp.Visible = True
            '    '            xlWorkBook.PrintPreview()
            '    '           xlApp.Visible = True
            'End If

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
#End Region
    Private Sub txtVATCost_GotFocus(sender As Object, e As EventArgs) Handles txtVATCost.GotFocus
        txtVATCost.SelectAll()
    End Sub

    Private Sub lnkVATCalculation_Click(sender As Object, e As EventArgs) Handles lnkVATCalculation.Click
        'lnkVATCalculation_LinkClicked(sender, e)
    End Sub

    Private Sub lnkVATCalculation_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkVATCalculation.LinkClicked
        Dim val1 As Double
        If Not IsNumeric(txtServiceAmount.Text) Then txtServiceAmount.Text = 0
        val1 = txtServiceAmount.Text
        If appCompanyInfo.VATPercentage > 0 Then txtVATCost.Text = ((txtServiceAmount.Text * appCompanyInfo.VATPercentage) / 100)
        txtChargeDesc.Focus()
    End Sub

    Private Sub DGridView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGridView.CellContentClick

    End Sub
End Class