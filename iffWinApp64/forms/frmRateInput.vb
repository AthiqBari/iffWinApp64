'06-Sep-2018
Imports System.Data.Sql
Imports System.Data
Imports System.Data.SqlClient

Public Class frmRateInput
    Dim recid As Integer
    Dim rateheaderID As Integer
    Dim eqpID As Integer
    Dim eqpGroupID As Integer
    Dim unlocoA As String
    Dim unlocoB As String
    Dim locidA As Integer
    Dim locidB As Integer
    Dim locstrA As String
    Dim locstrB As String
    Dim orgName As String
    Dim eqpName As String
    Dim orgRecID As Integer
    Public Sub New(mrecid As Integer, mTariffRateHeaderID As Integer, meqpID As Integer, meqpGroupID As Integer, munlocoA As String, munlocoB As String, _
                   mlocidA As Integer, mlocidB As Integer, mlocstrA As String, mlocstrB As String, morgName As String, _
                   meqpName As String, morgRecID As Integer)
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        recid = mrecid
        rateheaderID = mTariffRateHeaderID
        eqpID = meqpID
        eqpGroupID = meqpGroupID
        unlocoA = munlocoA
        unlocoB = munlocoB
        locidA = mlocidA
        locidB = mlocidB
        locstrA = mlocstrA
        locstrB = mlocstrB
        orgName = morgName
        eqpName = meqpName
        orgRecID = morgRecID
    End Sub

    Private Sub frmRateInput_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        'If orgRecID = 0 Then txtTripRate.Focus()
        'If orgRecID > 0 Then SendKeys.Send("{TAB}{TAB}")
        'SendKeys.Send("{TAB}{TAB}{TAB}{TAB}{TAB}")
        'txtTripRate.Focus()
    End Sub
    Private Sub frmRateInput_Load(sender As Object, e As EventArgs) Handles Me.Load
        formReturnValueINT = 0


        txtOrgName.Text = orgName
        txtEquipment.Text = eqpName
        txtLocationFrom.Text = locstrA & " (" & unlocoA & ")"
        txtDestination.Text = locstrB & " (" & unlocoB & ")"
        chkIsActive.Checked = True
        chkIsActive2.Checked = True
        groupboxtrip.Visible = False : groupboxrate.Visible = False


        If orgRecID = 0 Then    'rates for drivers
            lblORg.Visible = False
            txtOrgName.Visible = False
            groupboxtrip.Visible = True
            lblFormTitle.Text = "Manage Driver Trip Rates"
        ElseIf orgRecID > 0 Then 'rates for org
            groupboxrate.Visible = True
            lblFormTitle.Text = "Manage Transport Rates"
        End If


        If orgRecID > 0 And recid > 0 Then 'read from existing table for org rates
            Me.Cursor = Cursors.WaitCursor
            Dim dsi As New DataSet()
            sql_String = "select * from [organizationRates] where recid=" & recid
            dsi = setDataList(sql_String)
            If dsi.Tables(0).Rows.Count > 0 Then
                txtCostRate1.Text = dsi.Tables(0).Rows(0).Item("costAmt")
                txtCostRate2.Text = dsi.Tables(0).Rows(0).Item("costAmtOther")
                txtSellRate1.Text = dsi.Tables(0).Rows(0).Item("revenueAmt")
                txtSellRate2.Text = dsi.Tables(0).Rows(0).Item("revenueOther")
                txtActDescription.Text = dsi.Tables(0).Rows(0).Item("lineNote")
                chkIsActive.Checked = dsi.Tables(0).Rows(0).Item("isActive")
            End If
        End If

        If orgRecID = 0 And recid > 0 Then 'driver rates
            Me.Cursor = Cursors.WaitCursor
            Dim dsi As New DataSet()
            sql_String = "select * from [TariffRatesDriverTrip] where recid=" & recid
            dsi = setDataList(sql_String)
            If dsi.Tables(0).Rows.Count > 0 Then
                txtTripRate.Text = dsi.Tables(0).Rows(0).Item("TripRate")
                txtOtherAmount.Text = dsi.Tables(0).Rows(0).Item("OtherAmount")
                txtDistance1.Text = dsi.Tables(0).Rows(0).Item("DistanceKM")
                txtDistance2.Text = dsi.Tables(0).Rows(0).Item("DistanceKMRoundTrip")
                txtLineNote.Text = dsi.Tables(0).Rows(0).Item("lineNote")
                chkIsActive2.Checked = dsi.Tables(0).Rows(0).Item("isActive")
                calctot()
            End If
            txtCostRate1.SelectAll()
            txtCostRate1.Focus()
        End If

        If orgRecID = 0 Then 'drv
            txtTripRate.Focus()
            txtTripRate.SelectAll()
            SendKeys.Send("{TAB}")
        ElseIf orgRecID > 0 Then    'orgrate
            '            SendKeys.Send("{TAB}{TAB}")
            txtCostRate1.Focus()
            txtCostRate1.SelectAll()
        End If




        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnSaveEntry_Click(sender As Object, e As EventArgs) Handles btnSaveEntry.Click
        If Not IsNumeric(txtCostRate1.Text) Then txtCostRate1.Text = 0
        If Not IsNumeric(txtCostRate2.Text) Then txtCostRate2.Text = 0
        If Not IsNumeric(txtSellRate1.Text) Then txtSellRate1.Text = 0
        If Not IsNumeric(txtSellRate2.Text) Then txtSellRate2.Text = 0

        Dim adapter As New SqlDataAdapter
        Dim ds As New DataSet
        Dim dr As DataRow
        Dim cmdbuilder As SqlCommandBuilder
        Try
            Me.Cursor = Cursors.WaitCursor
            cmdbuilder = New SqlCommandBuilder(adapter)
            With adapter
                sql_String = "select * from [organizationRates] where recid=" & recid
                .SelectCommand = New SqlCommand(sql_String, sql_CNN)
                .Fill(ds, "cdata")
            End With

            If ds.Tables("cdata").Rows.Count = 0 Then
                dr = ds.Tables("cdata").NewRow 'addnew
                ds.Tables("cdata").Rows.Add(dr) 'add the row to dataset
            Else
                dr = ds.Tables("cdata").Rows(0)
            End If
            dr.Item("TariffRateHeaderID") = rateheaderID
            dr.Item("equipType") = eqpGroupID        'eqpgroupid
            dr.Item("unlocoA") = unlocoA
            dr.Item("locidA") = locidA
            dr.Item("unlocoB") = unlocoB
            dr.Item("locidB") = locidB
            dr.Item("costAmt") = txtCostRate1.Text
            dr.Item("costAmtOther") = txtCostRate2.Text
            dr.Item("revenueAmt") = txtSellRate1.Text
            dr.Item("revenueOther") = txtSellRate2.Text
            dr.Item("lineNote") = Microsoft.VisualBasic.Left(txtActDescription.Text, 20)
            dr.Item("IsActive") = chkIsActive.Checked
            adapter.Update(ds, "cdata")

            formReturnValueINT = 1
            Me.Cursor = Cursors.Default
            Me.Close()
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Not Saved!")
        End Try
    End Sub

    Private Sub btnSaveEntry2_Click(sender As Object, e As EventArgs) Handles btnSaveEntry2.Click
        If Not IsNumeric(txtTripRate.Text) Then txtTripRate.Text = 0
        If Not IsNumeric(txtOtherAmount.Text) Then txtOtherAmount.Text = 0
        If Not IsNumeric(txtDistance1.Text) Then txtDistance1.Text = 0
        If Not IsNumeric(txtDistance2.Text) Then txtDistance2.Text = 0

        Dim adapter As New SqlDataAdapter
        Dim ds As New DataSet
        Dim dr As DataRow
        Dim cmdbuilder As SqlCommandBuilder
        Try
            Me.Cursor = Cursors.WaitCursor
            cmdbuilder = New SqlCommandBuilder(adapter)
            With adapter
                sql_String = "select * from [TariffRatesDriverTrip] where recid=" & recid
                .SelectCommand = New SqlCommand(sql_String, sql_CNN)
                .Fill(ds, "cdata")
            End With

            If ds.Tables("cdata").Rows.Count = 0 Then
                dr = ds.Tables("cdata").NewRow 'addnew
                ds.Tables("cdata").Rows.Add(dr) 'add the row to dataset
                dr.Item("branchID") = appUserInfo.BranchId
                dr.Item("headerID") = rateheaderID        'eqpgroupid
            Else
                dr = ds.Tables("cdata").Rows(0)
            End If
            dr.Item("unlocoA") = unlocoA
            dr.Item("LocationIDFrom") = locidA
            dr.Item("unlocoB") = unlocoB
            dr.Item("LocationIDTo") = locidB
            dr.Item("DistanceKM") = txtDistance1.Text
            dr.Item("DistanceKMRoundTrip") = txtDistance2.Text
            dr.Item("equipType") = eqpGroupID
            dr.Item("TripRate") = txtTripRate.Text
            dr.Item("OtherAmount") = txtOtherAmount.Text
            dr.Item("lineNote") = Microsoft.VisualBasic.Left(txtLineNote.Text, 20)
            dr.Item("IsActive") = chkIsActive2.Checked
            adapter.Update(ds, "cdata")

            formReturnValueINT = 1
            Me.Cursor = Cursors.Default
            Me.Close()
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Not Saved!")
        End Try
    End Sub

    Private Sub txtTripRate_GotFocus(sender As Object, e As EventArgs) Handles txtTripRate.GotFocus
        txtTripRate.SelectAll()
    End Sub

    Private Sub txtTripRate_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTripRate.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSaveEntry2_Click(sender, e)
        End If
    End Sub

    Private Sub txtTripRate_LostFocus(sender As Object, e As EventArgs) Handles txtTripRate.LostFocus
        Call calctot()
    End Sub
    Private Sub calctot()
        Dim dbl1 As Double
        Dim dbl2 As Double
        dbl1 = 0
        dbl2 = 0
        txtTotal.Text = 0
        If Not IsNumeric(txtTripRate.Text) Then txtTripRate.Text = 0
        If Not IsNumeric(txtOtherAmount.Text) Then txtOtherAmount.Text = 0
        dbl1 = txtTripRate.Text
        dbl2 = txtOtherAmount.Text
        txtTotal.Text = (dbl1 + dbl2).ToString("N2")
    End Sub

    Private Sub txtOtherAmount_GotFocus(sender As Object, e As EventArgs) Handles txtOtherAmount.GotFocus
        txtOtherAmount.SelectAll()
    End Sub

    Private Sub txtOtherAmount_LostFocus(sender As Object, e As EventArgs) Handles txtOtherAmount.LostFocus
        Call calctot()
    End Sub

    Private Sub txtCostRate1_GotFocus(sender As Object, e As EventArgs) Handles txtCostRate1.GotFocus
        txtCostRate1.SelectAll()
    End Sub

    Private Sub txtCostRate2_GotFocus(sender As Object, e As EventArgs) Handles txtCostRate2.GotFocus
        txtCostRate2.SelectAll()
    End Sub

    Private Sub txtSellRate1_GotFocus(sender As Object, e As EventArgs) Handles txtSellRate1.GotFocus
        txtSellRate1.SelectAll()
    End Sub

    Private Sub txtSellRate2_GotFocus(sender As Object, e As EventArgs) Handles txtSellRate2.GotFocus
        txtSellRate2.SelectAll()
    End Sub

    Private Sub txtSellRate1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSellRate1.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSaveEntry_Click(sender, e)
        End If
    End Sub


    Private Sub txtCostRate1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCostRate1.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSaveEntry_Click(sender, e)
        End If
    End Sub

    Private Sub txtTripRate_TextChanged(sender As Object, e As EventArgs) Handles txtTripRate.TextChanged

    End Sub
End Class