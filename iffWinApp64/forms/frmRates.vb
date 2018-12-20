'Rates Table Form
'04-Sep-2018
Imports Telerik.WinControls.UI
Imports System.Data.Sql
Imports System.Data
Imports System.Data.SqlClient
Imports System.Exception
Imports System.Data.OleDb
Imports System.IO
Imports Excel = Microsoft.Office.Interop.Excel

Public Class frmRates
    Dim recID As Integer = 0
    Dim TariffRateHeaderID As Integer = 0
    Dim TariffRateHeaderIDCopy As Integer = 0
    Dim ds As New DataSet
    Dim appPath As String = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase)

    Private Sub frmRates_Load(sender As Object, e As EventArgs) Handles Me.Load
        appPath = New Uri(appPath).LocalPath
        Me.Left = 1
        Me.Top = 1
        TabControlMain.SelectedIndex = 0    'org tab
        Call initFormLoad()
        clearForm()
        cmbOrg.Focus()



    End Sub
    Private Sub initFormLoad()
        frmWaitForm.lblTitle.Text = "Loading Master Data. please wait..!"
        frmWaitForm.Show()
        frmWaitForm.Refresh()
        Me.Cursor = Cursors.WaitCursor
        Call refresh_location(cmbLocationFrom)
        Call refresh_location(cmbDestinationTo)
        Call refresh_organization(cmbOrg, "IsShipper=1 or IsConsignee=1 or IsTransporter=1 or isReceivableAccount=1 or isPayableAccount=1")
        Call refresh_eqpGroup(cmbEqpGroupTab1, "")

        'driver rates
        Call refresh_location(cmbLocationFromTab2)
        Call refresh_location(cmbDestinationToTab2)
        Call refresh_eqpGroup(cmbEqpGroupTab2, "")


        Me.Cursor = Cursors.Default
        frmWaitForm.Close()
    End Sub
    Private Sub refresh_location(cmbObj As Object)
        Me.Cursor = Cursors.WaitCursor
        sql_String = "select area [Location],unloco [UnLoco],recid from [LocationMaster] where isActive=1"
        Call fillCombo(cmbObj, sql_String, 0, 0, (cmbOrg.Width - 100), 50)
        cmbObj.Columns(2).IsVisible = False
        cmbObj.Tag = 0 : cmbObj.Text = ""
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub refresh_organization(cmbObj As Object, orgFldName As String)
        Me.Cursor = Cursors.WaitCursor
        sql_String = "select Name, recid, TariffRateHeaderID from [organization] where block=0 and (" & orgFldName & ") and branchID=" & appCompanyInfo.branchID
        Call fillCombo(cmbObj, sql_String, 0, 0, (cmbObj.Width - 50), 0)
        cmbObj.Columns(1).IsVisible = False
        cmbObj.Tag = 0 : cmbObj.Text = ""
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub refresh_eqpGroup(cmbObj As Object, orgFldName As String)
        Me.Cursor = Cursors.WaitCursor
        sql_String = "select  distinct etype as Name, 0 as recid from [EquipmentGroup] where isActive=1 "
        Call fillCombo(cmbObj, sql_String, 0, 0, (cmbObj.Width - 50), 0)
        cmbObj.Columns(1).IsVisible = False
        cmbObj.Tag = 0 : cmbObj.Text = ""
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub clearForm()
        lblUnloco1.Text = ""
        lblUnloco2.Text = ""
    End Sub

    Private Sub cmbOrg_LostFocus(sender As Object, e As EventArgs) Handles cmbOrg.LostFocus
        If cmbOrg.SelectedValue <> "" Then
            cmbOrg.Tag = 0 : TariffRateHeaderID = 0
            Dim selectedRow As GridViewDataRowInfo = DirectCast(cmbOrg.SelectedItem, GridViewDataRowInfo)
            cmbOrg.Tag = (selectedRow.Cells("recid").Value.ToString())
            TariffRateHeaderID = (selectedRow.Cells("TariffRateHeaderID").Value.ToString())
            RadGridEqpRates.DataSource = Nothing
            If cmbOrg.Tag > 0 Then Call listAllRatesTab1()
        End If
    End Sub
    Private Sub cmbCopyOrganization_LostFocus(sender As Object, e As EventArgs) Handles cmbCopyOrganization.LostFocus
        If cmbCopyOrganization.SelectedValue <> "" Then
            cmbCopyOrganization.Tag = 0 : TariffRateHeaderIDCopy = 0
            Dim selectedRow As GridViewDataRowInfo = DirectCast(cmbCopyOrganization.SelectedItem, GridViewDataRowInfo)
            cmbCopyOrganization.Tag = (selectedRow.Cells("recid").Value.ToString())
            TariffRateHeaderIDCopy = (selectedRow.Cells("TariffRateHeaderID").Value.ToString())
        End If
    End Sub

    Private Sub ListEquipmentForRates()
        Dim rtnval As Integer = 0
        'add header row
        Me.Cursor = Cursors.Default

        If TariffRateHeaderID = 0 Then TariffRateHeaderID = InsertTariffRatesHeader()

        lblMessage.Visible = False
        lblMessage.Text = ""
        If String.IsNullOrEmpty(cmbOrg.Text) Then lblMessage.Text = "Select Organization Account" : GoTo a
        If cmbOrg.Tag = 0 Then lblMessage.Text = "Select Organization Account" : GoTo a
        If String.IsNullOrEmpty(cmbLocationFrom.Text) Then lblMessage.Text = "Location Cannot be blank" : GoTo a
        If cmbLocationFrom.Tag = 0 Then lblMessage.Text = "Location Cannot be blank" : GoTo a
        If String.IsNullOrEmpty(cmbDestinationTo.Text) Then lblMessage.Text = "Location Cannot be blank" : GoTo a
        If cmbDestinationTo.Tag = 0 Then lblMessage.Text = "Location Cannot be blank" : GoTo a
        lblBelowRatesTab1.Text = "Below Rates For Route [" & cmbLocationFrom.Text & "] To [" & cmbDestinationTo.Text & "]"

        frmWaitForm.lblTitle.Text = "Getting Data. Please Wait..!"
        frmWaitForm.Show()
        frmWaitForm.Refresh()

        sql_String = " SELECT eq.name AS TrkName, ISNULL(t2.costAmt, 0) AS [Buying Rate], ISNULL(t2.costAmtOther, 0) AS [Other Cost], "
        sql_String += " ISNULL(t2.revenueAmt, 0) AS [Selling Rate], ISNULL(t2.revenueOther, 0) AS [Other Selling Rate], ISNULL(t2.lineNote, '') AS Note, "
        sql_String += " isnull(t2.isactive,0) [isActive], ISNULL(t2.recid, 0) AS orateRecID, eq.recid [eqrecid]"
        sql_String += " FROM  dbo.EquipmentGroup AS eq LEFT OUTER JOIN"
        sql_String += " (SELECT or1.equipType, or1.costAmt, or1.costAmtOther, or1.revenueAmt, or1.revenueOther, or1.lineNote, or1.locidA, or1.locidB, or1.recid, or1.IsActive"
        sql_String += " FROM  dbo.organizationRates AS or1 INNER JOIN"
        sql_String += " dbo.TariffRatesHeader AS th ON or1.TariffRateHeaderID = th.recid"
        sql_String += " WHERE   (th.orgRecID = " & cmbOrg.Tag & ") AND (or1.locidA = " & cmbLocationFrom.Tag & ") AND (or1.locidB = " & cmbDestinationTo.Tag & ")) AS t2 ON eq.recID = t2.equipType"
        sql_String += " WHERE  (eq.IsActive = 1) AND (eq.name NOT IN ('N/A')) ORDER BY EQ.SLNO"

        If (Not chkListAllTab1.Checked) And (Not String.IsNullOrEmpty(cmbEqpGroupTab1.SelectedValue)) Then sql_String += " AND (eq.etype = '" & cmbEqpGroupTab1.Text & "');"

        Try
            Me.Cursor = Cursors.WaitCursor
            RadGridEqpRates.DataSource = Nothing
            ds = setDataList(sql_String)
            If ds.Tables(0).Rows.Count > 0 Then
                RadGridEqpRates.DataSource = ds.Tables(0)
                RadGridEqpRates.Columns("oraterecid").IsVisible = False
                RadGridEqpRates.Columns("eqrecid").IsVisible = False
                RadGridEqpRates.MasterTemplate.BestFitColumns()
                RadGridEqpRates.Columns(0).Width = 129
                RadGridEqpRates.Columns(1).Width = 80
                RadGridEqpRates.Columns(2).Width = 80
                RadGridEqpRates.Columns(3).Width = 80
                RadGridEqpRates.Columns(4).Width = 114
                RadGridEqpRates.Columns(5).Width = 327
                RadGridEqpRates.Columns(6).Width = 50

            Else
                lblMessage.Visible = True
                lblMessage.Text = "Data Not Found"
            End If
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            lblMessage.Visible = True
            lblMessage.Text = ex.Message
        End Try
        Me.Cursor = Cursors.Default
        frmWaitForm.Close()

        Exit Sub
a:
        Me.Cursor = Cursors.Default
        frmWaitForm.Close()
        lblMessage.Visible = True
    End Sub

    'check to see if no record found in TariffRatesHeader then create a new row and return recid
    Private Function InsertTariffRatesHeader() As Integer
        Dim tRecID As Integer = 0
        Dim adapter As New SqlDataAdapter
        Dim ds As New DataSet
        Dim dr As DataRow
        Dim cmdbuilder As SqlCommandBuilder
        lblMessage.Text = ""
        Try
            Me.Cursor = Cursors.WaitCursor
            cmdbuilder = New SqlCommandBuilder(adapter)
            With adapter
                sql_String = "select * from [TariffRatesHeader] where orgRecID=" & cmbOrg.Tag
                .SelectCommand = New SqlCommand(sql_String, sql_CNN)
                .Fill(ds, "cdata")
            End With
            If ds.Tables(0).Rows.Count = 0 Then
                dr = ds.Tables("cdata").NewRow 'addnew
                ds.Tables("cdata").Rows.Add(dr) 'add the row to dataset
                dr.Item("branchID") = appUserInfo.BranchId
                dr.Item("tariffType") = 0
                dr.Item("ratesEffectiveFrom") = Today.Date
                dr.Item("ratesEffectiveTill") = Today.Date
                dr.Item("CreatedBy") = appUserInfo.Name
                dr.Item("UpdatedOn") = Today.Date
                dr.Item("IsActive") = 1
                dr.Item("orgRecID") = cmbOrg.Tag
                adapter.Update(ds, "cdata")

                'now get new recid
                Dim dsi As New DataSet()
                sql_String = "select recid from [TariffRatesHeader] where branchid=" & appCompanyInfo.branchID & " and orgrecid=" & cmbOrg.Tag & ";"
                dsi = setDataList(sql_String)
                If dsi.Tables(0).Rows.Count > 0 Then tRecID = dsi.Tables(0).Rows(0).Item("recid")
                Me.Cursor = Cursors.Default

                sql_String = "update [organization] set TariffRateHeaderID=" & tRecID & " where recid=" & cmbOrg.Tag
                Dim commandy As New SqlCommand(sql_String, sql_CNN)
                commandy.ExecuteNonQuery()
            Else
                tRecID = ds.Tables("cdata").Rows(0).Item("recid")
            End If

        Catch ex As Exception
            lblMessage.Text = ex.Message
            lblMessage.Visible = True
        End Try

        Return tRecID
    End Function

    Private Sub btnEditThisJob_Click(sender As Object, e As EventArgs) Handles btnEditThisJob.Click
        Call ListEquipmentForRates()
    
    End Sub

    Private Sub listAllRatesTab1()
        lblListingRatesText.Text = "Listing Rates for " & cmbOrg.SelectedValue
        sql_String = " select "
        sql_String += " lmA.area [LoadArea],  lmB.area [DestArea], eq.name [EqpGroup], "
        sql_String += " or1.costAmt+or1.costAmtOther [Buying Rate],"
        sql_String += " or1.revenueAmt+or1.revenueOther [Selling Rate],or1.lineNote [Note],"
        sql_String += " or1.unlocoA [LoadCity], or1.unlocoB [DestCity],th.orgRecID, or1.recid [orateRecID]"
        sql_String += " from organizationRates or1 inner join TariffRatesHeader th on or1.TariffRateHeaderID=th.recid"
        sql_String += " inner join EquipmentGroup eq on or1.equipType=eq.recID"
        sql_String += " inner join LocationMaster lmA on or1.locidA=lmA.recid"
        sql_String += " inner join LocationMaster lmB on or1.locidB=lmB.recid"
        sql_String += " where th.orgrecid=" & cmbOrg.Tag
        sql_String += " order by eq.slno"
        Try
            Me.Cursor = Cursors.WaitCursor

            RadGridEqpRatesList.DataSource = Nothing
            ds = setDataList(sql_String)
            If ds.Tables(0).Rows.Count > 0 Then
                RadGridEqpRatesList.DataSource = ds.Tables(0)
                RadGridEqpRatesList.Columns("orgrecid").IsVisible = False
                RadGridEqpRatesList.Columns("oraterecid").IsVisible = False
                RadGridEqpRatesList.MasterTemplate.BestFitColumns()
            Else
                lblMessage.Visible = True
                lblMessage.Text = "Data Not Found"
            End If
        Catch ex As Exception
            lblMessage.Visible = True
            lblMessage.Text = ex.Message
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cmbDestinationTo_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbDestinationTo.KeyDown
        If e.KeyCode = Keys.Enter Then
            cmbDestinationTo_LostFocus(sender, e)
        End If
    End Sub

    Private Sub cmbDestinationTo_LostFocus(sender As Object, e As EventArgs) Handles cmbDestinationTo.LostFocus
        If cmbDestinationTo.SelectedValue <> "" Then
            cmbDestinationTo.Tag = 0
            Dim selectedRow As GridViewDataRowInfo = DirectCast(cmbDestinationTo.SelectedItem, GridViewDataRowInfo)
            cmbDestinationTo.Tag = (selectedRow.Cells("recid").Value.ToString())
            lblUnloco2.Text = (selectedRow.Cells("unloco").Value.ToString())
            lblToLocation1.Text = " To " & cmbDestinationTo.Text
            Call ListEquipmentForRates()
            RadGridEqpRates.Focus()

        End If
    End Sub

    Private Sub cmbLocationFrom_LostFocus(sender As Object, e As EventArgs) Handles cmbLocationFrom.LostFocus
        If cmbLocationFrom.SelectedValue <> "" Then
            cmbLocationFrom.Tag = 0
            Dim selectedRow As GridViewDataRowInfo = DirectCast(cmbLocationFrom.SelectedItem, GridViewDataRowInfo)
            cmbLocationFrom.Tag = (selectedRow.Cells("recid").Value.ToString())
            lblUnloco1.Text = (selectedRow.Cells("unloco").Value.ToString())
            lblFromLocation1.Text = " To " & cmbLocationFrom.Text
        End If
    End Sub

    Private Sub cmbEqpGroupTab1_LostFocus(sender As Object, e As EventArgs) Handles cmbEqpGroupTab1.LostFocus
        If cmbEqpGroupTab1.SelectedValue <> "" Then
            cmbEqpGroupTab1.Tag = 0
            Dim selectedRow As GridViewDataRowInfo = DirectCast(cmbEqpGroupTab1.SelectedItem, GridViewDataRowInfo)
            cmbEqpGroupTab1.Tag = (selectedRow.Cells("recid").Value.ToString())
        End If
    End Sub

    Private Sub TabControl2_Click(sender As Object, e As EventArgs) Handles TabControl2.Click
        If TabControl2.SelectedIndex = 1 Then 'listall
            Call listAllRatesTab1()
        End If
    End Sub
    Private Sub btnFilterTab1_Click(sender As Object, e As EventArgs) Handles btnFilterTab1.Click
        Call ListEquipmentForRates()
    End Sub

    Private Sub btnCopyBlue_Click(sender As Object, e As EventArgs) Handles btnCopyBlue.Click
        If cmbOrg.Tag > 0 Then
            If RadGridEqpRatesList.Rows.Count > 0 Then
                PanelCopy.Visible = True
                lblMessage2.Text = ""
                Call refresh_organization(cmbCopyOrganization, "IsShipper=1 or IsConsignee=1 or IsTransporter=1 or isReceivableAccount=1 or isPayableAccount=1")
                cmbCopyOrganization.Focus()
            End If
        End If
    End Sub


    Private Sub btnCopy_Click(sender As Object, e As EventArgs) Handles btnCopy.Click
        lblMessage2.Visible = True
        lblMessage2.Text = ""
        Dim intOpt As Integer = -1
        If cmbCopyOrganization.Tag = 0 Then Return
        If chkCopyDel.CheckState = CheckState.Checked Then    'delete existing data from target org. first
            If MsgBox("All Rates From Selected Organization will be Removed, Proceed with this Action ?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Remove Rates") = MsgBoxResult.No Then Return
            If sql_CNN.State = ConnectionState.Closed Then createConnection()
            Dim sqlcmd As SqlCommand = sql_CNN.CreateCommand()

            sqlcmd.CommandText = "delete from [organizationrates] where tariffrateheaderid in (select tariffrateheaderid from organization where recid=" & cmbCopyOrganization.Tag & ");"
            sqlcmd.ExecuteNonQuery()

            sqlcmd.CommandText = "delete from [tariffratesheader] where orgrecid=" & cmbCopyOrganization.Tag & ";"
            sqlcmd.ExecuteNonQuery()

            sqlcmd.CommandText = "update organization set tariffrateheaderid=0 where recid=" & cmbCopyOrganization.Tag
            sqlcmd.ExecuteNonQuery()

            lblMessage2.Text = "All Rates from Organzation " & cmbCopyOrganization.Text & " has been removed"
            chkCopyDel.Checked = False
            Return
        End If

        If rbCopyBuying.Checked Then intOpt = 0
        If rbCopySelling.Checked Then intOpt = 1
        If rbCopyBoth.Checked Then intOpt = 2
        If intOpt < 0 Then lblMessage2.Text = "Select Copy Option" : Return

        Dim rtnval As Double = 0
        Dim paramFld() As String = {"@sourceOrgRecID", "@destOrgRecID", "@rateType"}
        Dim paramVal() As String = {0, 0, intOpt}

        'MsgBox("This Feature is blocked for further updates", MsgBoxStyle.Exclamation, Label5.Text)
        'Return

        Try
            If cmbOrg.Tag = cmbCopyOrganization.Tag Then
                lblMessage2.Text = "Cannot Copy to same Organization Account"
                lblMessage2.Visible = True
                Exit Sub
            End If
            If cmbCopyOrganization.SelectedValue <> "" Then
                If MsgBox("Copying Rates to Other Organization will Overwrite Data if exists, Continue ?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Copy Rates") = MsgBoxResult.No Then Exit Sub

                If cmbCopyOrganization.Tag > 0 Then
                    paramVal(0) = cmbOrg.Tag
                    paramVal(1) = cmbCopyOrganization.Tag
                    paramVal(2) = intOpt
                    Try
                        rtnval = Convert.ToDouble(spCopyRates("CopyRatesFromOrganization", paramFld, paramVal))
                        MsgBox("Data Copied Successfully", MsgBoxStyle.Information, "Copy Rates")
                        lblMessage2.Text = "Rates Copied Successfully to " & cmbCopyOrganization.Text
                        lblMessage2.Visible = True
                        PanelCopy.Visible = False
                        rbCopyBoth.Checked = False
                        rbCopyBuying.Checked = False
                        rbCopySelling.Checked = False
                    Catch ex As Exception
                        lblMessage2.Text = ex.Message
                        Return
                    End Try
                End If
            End If

        Catch ex As Exception
            lblMessage2.Visible = True
            lblMessage2.Text = ex.Message
        End Try
    End Sub

    Private Function spCopyRates(spName As String, ByVal ParamNm() As String, ByVal ParamVal() As String, _
                                  Optional ExecuteScalar As Boolean = False) As Double
        Dim TmpCmd As New SqlCommand
        Dim SPParam As New SqlParameter
        Dim dblReturnValue As Double = 0
        Dim i As Integer
        dblReturnValue = 0
        Try
            If sql_CNN.State = ConnectionState.Closed Then createConnection()
            TmpCmd = New SqlCommand
            With TmpCmd
                .Connection = sql_CNN
                .CommandType = CommandType.StoredProcedure
                .CommandTimeout = (24 * 3600)
                .CommandText = spName
                For i = 0 To ParamNm.GetUpperBound(0)
                    If Len(ParamNm(i)) = 0 Then ParamVal(i) = "0"
                    If Len(ParamNm(i)) > 2 Then SPParam = TmpCmd.Parameters.Add(ParamNm(i), SqlDbType.NVarChar) : SPParam.Value = ParamVal(i)
                Next
            End With
            ' AddTransactionToCmd(TmpCmd)
            If ExecuteScalar Then
                TmpCmd.Parameters.Add("@stat", SqlDbType.BigInt)
                TmpCmd.Parameters("@stat").Direction = ParameterDirection.Output
                TmpCmd.ExecuteScalar()
                dblReturnValue = TmpCmd.Parameters("@stat").Value
            Else
                dblReturnValue = Convert.ToInt32(TmpCmd.ExecuteNonQuery())
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "iffWinApp64.spCopyRates(..)")
            dblReturnValue = -1
        End Try
        Return dblReturnValue
    End Function

    Private Sub cmbDestinationToTab2_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbDestinationToTab2.KeyDown
        If e.KeyCode = Keys.Enter Then
            cmbDestinationToTab2_LostFocus(sender, e)
        End If
    End Sub

    Private Sub cmbDestinationToTab2_LostFocus(sender As Object, e As EventArgs) Handles cmbDestinationToTab2.LostFocus
        If cmbDestinationToTab2.SelectedValue <> "" Then
            cmbDestinationToTab2.Tag = 0
            Dim selectedRow As GridViewDataRowInfo = DirectCast(cmbDestinationToTab2.SelectedItem, GridViewDataRowInfo)
            cmbDestinationToTab2.Tag = (selectedRow.Cells("recid").Value.ToString())
            lblUnloco2Tab2.Text = (selectedRow.Cells("unloco").Value.ToString())
            RadGridEqpRatesTab2.DataSource = Nothing
            lblToLocation2.Text = " To " & cmbDestinationToTab2.Text
            RadGridEqpRatesList.DataSource = Nothing
            Call ListEquipmentForRatesTab2()
            RadGridEqpRatesTab2.Focus()
        End If
    End Sub

    Private Sub cmbLocationFromTab2_LostFocus(sender As Object, e As EventArgs) Handles cmbLocationFromTab2.LostFocus
        If cmbLocationFromTab2.SelectedValue <> "" Then
            cmbLocationFromTab2.Tag = 0
            Dim selectedRow As GridViewDataRowInfo = DirectCast(cmbLocationFromTab2.SelectedItem, GridViewDataRowInfo)
            cmbLocationFromTab2.Tag = (selectedRow.Cells("recid").Value.ToString())
            lblUnloco1Tab2.Text = (selectedRow.Cells("unloco").Value.ToString())
            RadGridEqpRatesTab2.DataSource = Nothing
            lblFromLocation2.Text = "From " & cmbLocationFromTab2.Text
        End If
    End Sub

    Private Sub cmbEqpGroupTab2_LostFocus(sender As Object, e As EventArgs) Handles cmbEqpGroupTab2.LostFocus
        If cmbEqpGroupTab2.SelectedValue <> "" Then
            cmbEqpGroupTab2.Tag = 0
            Dim selectedRow As GridViewDataRowInfo = DirectCast(cmbEqpGroupTab2.SelectedItem, GridViewDataRowInfo)
            cmbEqpGroupTab2.Tag = (selectedRow.Cells("recid").Value.ToString())
        End If
    End Sub

    Private Sub btnEditThisJobTab2_Click(sender As Object, e As EventArgs) Handles btnEditThisJobTab2.Click
        Call ListEquipmentForRatesTab2()
    End Sub


    Private Sub ListEquipmentForRatesTab2()
        Dim rtnval As Integer = 0
        Me.Cursor = Cursors.Default
        'add header row

        lblMessageTab2.Visible = False
        lblMessageTab2.Text = ""
        If String.IsNullOrEmpty(cmbLocationFromTab2.Text) Then lblMessageTab2.Text = "Location Cannot be blank" : GoTo a
        If cmbLocationFromTab2.Tag = 0 Then lblMessage2.Text = "Location Cannot be blank" : GoTo a
        If String.IsNullOrEmpty(cmbDestinationToTab2.Text) Then lblMessageTab2.Text = "Location Cannot be blank" : GoTo a
        If cmbDestinationToTab2.Tag = 0 Then lblMessageTab2.Text = "Location Cannot be blank" : GoTo a
        lblBelowRatesTab2.Text = "Below Driver Trip Money For The Route [" & cmbLocationFromTab2.Text & "] To [" & cmbDestinationToTab2.Text & "]"

        Me.Cursor = Cursors.WaitCursor

        frmWaitForm.lblTitle.Text = "Getting Data. Please Wait..!"
        frmWaitForm.Show()
        frmWaitForm.Refresh()

        sql_String = "SELECT eq.name AS [EqpGroup], isnull(tr.TripRate,0) [TripRate], ISNULL(tr.OtherAmount,0) [OtherAmt], isnull(Total,0) [Total], isnull(tr.lineNote,'') [LineNote], tr.isactive [Active], isnull(tr.recid,0) [trrecid],eq.recid [eqrecid] "
        sql_String += " from dbo.EquipmentGroup AS eq LEFT OUTER JOIN (select recid,equipType, TripRate,OtherAmount, (TripRate+OtherAmount) [Total],linenote,isactive from TariffRatesDriverTrip"
        sql_String += " where headerID=1 and LocationIDFrom=" & cmbLocationFromTab2.Tag & " and LocationIDTo= " & cmbDestinationToTab2.Tag & ") tr on eq.recid=tr.equipType"
        sql_String += " WHERE  (eq.IsActive = 1) AND (eq.name NOT IN ('N/A')) ORDER BY EQ.SLNO"

        If (Not chkListAllTab2.Checked) And (Not String.IsNullOrEmpty(cmbEqpGroupTab2.SelectedValue)) Then sql_String += " AND (eq.etype = '" & cmbEqpGroupTab2.Text & "');"

        Try
            Me.Cursor = Cursors.WaitCursor
            RadGridEqpRatesTab2.DataSource = Nothing
            ds = setDataList(sql_String)
            If ds.Tables(0).Rows.Count > 0 Then
                RadGridEqpRatesTab2.DataSource = ds.Tables(0)
                RadGridEqpRatesTab2.MasterTemplate.BestFitColumns()
                RadGridEqpRatesTab2.Columns(0).Width = 188
                RadGridEqpRatesTab2.Columns(1).Width = 90
                RadGridEqpRatesTab2.Columns(2).Width = 90
                RadGridEqpRatesTab2.Columns(3).Width = 90
                RadGridEqpRatesTab2.Columns(4).Width = 362
                RadGridEqpRatesTab2.Columns("trrecid").IsVisible = False
                RadGridEqpRatesTab2.Columns("eqrecid").IsVisible = False

            Else
                lblMessageTab2.Visible = True
                lblMessageTab2.Text = "Data Not Found"
            End If
            Me.Cursor = Cursors.Default
            frmWaitForm.Close()
        Catch ex As Exception
            frmWaitForm.Close()
            Me.Cursor = Cursors.Default
            lblMessageTab2.Visible = True
            lblMessageTab2.Text = ex.Message
        End Try
        Me.Cursor = Cursors.Default

        Exit Sub
a:
        Me.Cursor = Cursors.Default
        lblMessage.Visible = True
    End Sub

    Private Sub btnFilterTab2_Click(sender As Object, e As EventArgs) Handles btnFilterTab2.Click
        Call ListEquipmentForRatesTab2()
    End Sub

   

    Private Sub TabControl3_Click(sender As Object, e As EventArgs) Handles TabControl3.Click
        If TabControl3.SelectedIndex = 1 Then 'listall
            Call listAllRatesTab2(False)
        End If
    End Sub

    Private Sub listAllRatesTab2(mlistall As Boolean)
        sql_String = "select "
        If mlistall Then sql_String += " lm.area Origin, lm2.area [Destination],"
        sql_String += "  egrp.name [EquipGroup], tp.OtherAmount+tp.TripRate [Rate], DistanceKM, DistanceKMRoundTrip,tp.linenote [Note], tp.isActive [Active],tp.recid [trecid]"
        sql_String += "  from TariffRatesDriverTrip tp left outer join LocationMaster lm on tp.LocationIDFrom=lm.recid"
        sql_String += "  left outer join LocationMaster lm2 on tp.LocationIDTo=lm2.recid"
        sql_String += "  inner join EquipmentGroup egrp on tp.equipType=egrp.recid"
        sql_String += "  where tp.headerID = 1 "
        If Not mlistall Then sql_String += " And tp.LocationIDFrom = " & cmbLocationFromTab2.Tag & " And tp.LocationIDTo = " & cmbDestinationToTab2.Tag & ""
        sql_String += " order by tp.recid desc"

        Try
            Me.Cursor = Cursors.WaitCursor
            RadGridView2.DataSource = Nothing
            ds = setDataList(sql_String)
            If ds.Tables(0).Rows.Count > 0 Then
                RadGridView2.DataSource = ds.Tables(0)
                RadGridView2.Columns("trecid").IsVisible = False
                RadGridView2.MasterTemplate.BestFitColumns()
            Else
                lblMessageTab2.Visible = True
                lblMessageTab2.Text = "Data Not Found"
            End If

        Catch ex As Exception
            lblMessageTab2.Visible = True
            lblMessageTab2.Text = ex.Message
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        lblMessageTab2.Text = ""
        sql_String = " select * from [viewDriverTripRates_TTS] where branchID=" & appUserInfo.BranchId
        Try
            Me.Cursor = Cursors.WaitCursor
            RadGridView1.DataSource = Nothing
            ds = setDataList(sql_String)
            If ds.Tables(0).Rows.Count > 0 Then
                RadGridView1.DataSource = ds.Tables(0)
                RadGridView1.MasterTemplate.BestFitColumns()
            End If
        Catch ex As Exception
            lblMessageTab2.Text = ex.Message
        End Try
        Me.Cursor = Cursors.Default
        If RadGridView1.Rows.Count > 0 Then Call exportDriverTripRates(1)
    End Sub

    Private Sub exportDriverTripRates(tempID As Integer)
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim i As Integer = 0

            Dim str1 As String = ""
            Dim str2 As String = ""
            Dim cellRowIndex As Integer = 1
            Dim cellColumnIndex As Integer = 1
            'Dim cellrangex As Excel.Range


            Dim destinationFile As String = copyTemplate(tempID)
            If String.IsNullOrEmpty(destinationFile) Then Exit Sub
            If IO.File.Exists(destinationFile) = False Then
                Me.Cursor = Cursors.WaitCursor
                MsgBox("File does not exists " & destinationFile, MsgBoxStyle.Exclamation, "File Not Found")
                Exit Sub
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
            If tempID = 1 Then objRadGrid = RadGridView1
            If tempID = 2 Then objRadGrid = RadGridEqpRatesList
            xlWorkBook = xlApp.Workbooks.Open(destinationFile)
            xlWorkSheet = xlWorkBook.Worksheets("Sheet1")

            xlWorkSheet.Cells(1, 1) = appCompanyInfo.companyName
            xlWorkSheet.Cells(2, 1) = appCompanyInfo.branchName
            xlWorkSheet.Cells(1, 8) = Today.Date

            If tempID = 2 Then xlWorkSheet.Cells(5, 1) = cmbOrg.Text 'org rates
            'start writing data from 
            cellRowIndex = 8
            cellColumnIndex = 1

            ProgressBar1.Minimum = 0
            ProgressBar1.Maximum = objRadGrid.Rows.Count + 1
            ProgressBar1.Value = 0
            ProgressBar1.Visible = True

            'Loop through each row and read value from each column.
            For i = 0 To objRadGrid.Rows.Count - 1
                For j As Integer = 0 To objRadGrid.Columns.Count - 2

                    xlWorkSheet.Cells(cellRowIndex, cellColumnIndex) = objRadGrid.Rows(i).Cells(j).Value.ToString()
                    cellColumnIndex += 1
                Next
                cellColumnIndex = 1
                cellRowIndex += 1

                If (ProgressBar1.Value < ProgressBar1.Maximum) Then ProgressBar1.Value = i '

            Next
            ProgressBar1.Visible = False

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
            MsgBox("Output File Created [" & destinationFile & "]", MsgBoxStyle.Information, Me.Text)


            Dim proc As Process = Nothing
            Dim startInfo As New ProcessStartInfo
            startInfo.FileName = "EXCEL.EXE"
            startInfo.Arguments = """" & destinationFile & """"
            Process.Start(startInfo)
            'System.Diagnostics.Process.Start("FilePath")

            Me.Cursor = Cursors.Default
            frmWaitForm.Close()

        Catch ex As Exception
            Me.Cursor = Cursors.Default
            frmWaitForm.Close()
            MsgBox(ex.Message, vbCritical, Me.Text)
        End Try
    End Sub
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

    Private Function copyTemplate(rType As Integer) As String
        Try
            Dim templateFile As String = ""
            Dim newFileName As String = ""
            Dim appPath As String = "" 'System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase)
            appPath = Directory.GetCurrentDirectory()
            If rType = 1 Then templateFile = "iffDriverTripRates"
            If rType = 2 Then templateFile = "iffOrgTripRates"
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
    Private Sub btnExcel2_Click(sender As Object, e As EventArgs) Handles btnExcel2.Click
        If RadGridEqpRatesList.Rows.Count > 0 Then Call exportDriverTripRates(2)
    End Sub
    Private Sub lnkListAllRatesOrg_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkListAllRatesOrg.LinkClicked
        Call listAllRatesTab1()
    End Sub
    Private Sub lnkDriverRates_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkDriverRates.LinkClicked
        Call listAllRatesTab2(True)
    End Sub
    Private Sub btnReLoad1_Click(sender As Object, e As EventArgs) Handles btnReLoad1.Click
        Call refresh_location(cmbLocationFrom)
    End Sub
    Private Sub btnReLoad2_Click(sender As Object, e As EventArgs) Handles btnReLoad2.Click
        Call refresh_location(cmbDestinationTo)
    End Sub

    Private Sub RadGridEqpRates_KeyDown(sender As Object, e As KeyEventArgs) Handles RadGridEqpRates.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Dim rowindex As Integer = 0
                rowindex = RadGridEqpRates.CurrentCell.RowIndex
                If RadGridEqpRates.Rows.Count > 0 Then Call CellEnter(rowindex)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub RadGridEqpRates_CellDoubleClick(sender As Object, e As GridViewCellEventArgs) Handles RadGridEqpRates.CellDoubleClick
        Call CellEnter(e.RowIndex)
    End Sub

    Private Sub CellEnter(rowindex As Integer)
        Dim eqpid As Integer
        Dim eqpname As String = ""
        Dim eqpGroupID As Integer = 0
        recID = RadGridEqpRates.Rows(rowindex).Cells("oraterecid").Value
        eqpid = 0 'RadGridEqpRates.Rows(e.RowIndex).Cells("eqrecid").Value
        eqpname = RadGridEqpRates.Rows(rowindex).Cells("trkname").Value
        eqpGroupID = RadGridEqpRates.Rows(rowindex).Cells("eqrecid").Value
        Dim frm As New frmRateInput(recID, TariffRateHeaderID, eqpid, eqpGroupID, lblUnloco1.Text, lblUnloco2.Text, cmbLocationFrom.Tag, cmbDestinationTo.Tag, _
                                    cmbLocationFrom.SelectedValue, cmbDestinationTo.SelectedValue, cmbOrg.SelectedValue, eqpname, cmbOrg.Tag)
        frm.ShowDialog(Me)
        If formReturnValueINT > 0 Then
            Call ListEquipmentForRates()
        End If

    End Sub

#Region "drivers"
    Private Sub RadGridEqpRatesTab2_CellDoubleClick(sender As Object, e As GridViewCellEventArgs) Handles RadGridEqpRatesTab2.CellDoubleClick
        Call CellEnter2(e.RowIndex)
    End Sub
    Private Sub CellEnter2(rowindex As Integer)
        Dim eqpid As Integer
        Dim eqpname As String = ""
        Dim eqpGroupID As Integer = 0
        recID = RadGridEqpRatesTab2.Rows(rowindex).Cells("trrecid").Value
        eqpid = 0 'RadGridEqpRates.Rows(e.RowIndex).Cells("eqrecid").Value
        eqpname = RadGridEqpRatesTab2.Rows(rowindex).Cells("eqpGroup").Value
        eqpGroupID = RadGridEqpRatesTab2.Rows(rowindex).Cells("eqrecid").Value
        Dim frm As New frmRateInput(recID, 1, eqpid, eqpGroupID, lblUnloco1Tab2.Text, lblUnloco2Tab2.Text, cmbLocationFromTab2.Tag, cmbDestinationToTab2.Tag, _
                            cmbLocationFromTab2.SelectedValue, cmbDestinationToTab2.SelectedValue, "", eqpname, 0)
        frm.ShowDialog(Me)
        If formReturnValueINT > 0 Then
            Call ListEquipmentForRatesTab2()
        End If
    End Sub
    Private Sub RadGridEqpRatesTab2_KeyDown(sender As Object, e As KeyEventArgs) Handles RadGridEqpRatesTab2.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Dim rowindex As Integer = 0
                rowindex = RadGridEqpRatesTab2.CurrentCell.RowIndex
                If RadGridEqpRatesTab2.Rows.Count > 0 Then Call CellEnter2(rowindex)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub
#End Region



    Private Sub cmbDestinationTo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDestinationTo.SelectedIndexChanged

    End Sub

    Private Sub cmbDestinationToTab2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDestinationToTab2.SelectedIndexChanged

    End Sub

    Private Sub RadGridEqpRates_Click(sender As Object, e As EventArgs) Handles RadGridEqpRates.Click

    End Sub
End Class