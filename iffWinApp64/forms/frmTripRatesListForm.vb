'Waybill/ProofOfDelivery POD Form developed for TransArab And JEDEX
'27-July-2018 - Today is my birthday :-) home alone
Imports Telerik.WinControls.UI
Imports System.Data.Sql
Imports System.Data
Imports System.Data.SqlClient
Imports System.Exception

Public Class frmTripRatesListForm
    Dim unlocoA As String
    Dim eqpType As Integer
    Dim contractID As Integer
    Dim tariffType As Integer
    Dim eqpName As String
    Dim recID As Integer = 0
    Dim orgrecID As Integer = 0
    Dim appPath As String = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase)

    Public Sub New(munlocoA As String, meqpType As Integer, mcontractID As Integer, mtariffType As Integer, meqpname As String, morgrecID As Integer, mtitle As String)
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        unlocoA = munlocoA
        eqpType = meqpType
        contractID = mcontractID
        tariffType = mtariffType
        eqpName = meqpname
        orgrecID = morgrecID
        Me.Text = mTitle

    End Sub
    Private Sub frmTripRatesListForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        lblTitle.Text = "Listing Tariff of all Destination from [" & unlocoA & "] for " & vbCrLf & "Selected Equipment [" & eqpName.ToString & "]"
        cmbListLocation.Tag = 0
        cmbListLocation.Visible = False
        If tariffType = 0 Then 'tariff data from cost table
            sql_String = "select distinct lm.area [Location], "
            sql_String += " tb.TripRate,tb.OtherAmount, tb.TripRate+tb.OtherAmount [TotalRate],  tb.DistanceKM,tb.DistanceKMRoundTrip [RoundTrip KM],tb.CommisionPerKM [Commission By KM],lm.recid [lrecid], tb.recid [tbrecid],th.recid [ContractID]"
            sql_String += " from TariffRatesHeader th inner join TariffRatesDriverTrip tb "
            sql_String += " on th.recid=tb.headerID inner join LocationMaster lm"
            sql_String += " on tb.LocationIDFrom=lm.recid and tb.unlocoA=lm.unloco"
            sql_String += " where tb.unlocoA='" & unlocoA & "' and  tb.equipType=" & eqpType & " and th.isActive=1 and th.recid=" & contractID & ";"
            Call loadData(sql_String)
        ElseIf tariffType = 1 Then 'selling
            sql_String = "select vo.ToCity,SellingRate [TotalRate],vo.Equipment,lineNote,vo.orgrateid [tbrecid], headerid [lrecid] "
            sql_String += " from dbo.vieworganizationrates vo "
            sql_String += "  where vo.orgrecid=" & orgrecID & " and vo.eqprecid=" & eqpType & " and vo.SellingRate>0 "
            sql_String += " and vo.unlocoA='" & unlocoA & "' and vo.headerid=" & contractID
            Call loadData(sql_String)
        End If
    End Sub

    Private Sub refresh_loadingRoute(cmbObj As Object, orgFldName As String)
        Me.Cursor = Cursors.WaitCursor
        sql_String = " select distinct lm.area [From Route],  th.recid [ContractID],lm.recid [lrecid],tb.recid [tbrecid]"
        sql_String += " from TariffRatesHeader th inner join TariffRatesDriverTrip tb "
        sql_String += " on th.recid=tb.headerID inner join LocationMaster lm"
        sql_String += " on tb.LocationIDFrom=lm.recid and tb.unlocoA=lm.unloco"
        sql_String += " where tb.unlocoA='" & unlocoA & "' and  tb.equipType=" & eqpType & " and th.recid=" & contractID & ";"
        Call fillCombo(cmbObj, sql_String, 0, 300, 300, 50)
        cmbObj.Columns(2).VisibleInColumnChooser = False
        cmbObj.Tag = 0 : cmbObj.Text = ""
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub lnkLoadRouteList_Click(sender As Object, e As EventArgs) Handles lnkLoadRouteList.Click
        Call refresh_loadingRoute(cmbListLocation, "")
        cmbListLocation.Visible = True
    End Sub

    Private Sub cmbListLocation_LostFocus(sender As Object, e As EventArgs) Handles cmbListLocation.LostFocus
        Try
            If cmbListLocation.SelectedValue <> "" Then
                cmbListLocation.Tag = 0
                Dim selectedRow As GridViewDataRowInfo = DirectCast(cmbListLocation.SelectedItem, GridViewDataRowInfo)
                cmbListLocation.Tag = (selectedRow.Cells("lrecid").Value.ToString())
                btnOK.Enabled = True
            Else
                btnOK.Enabled = False
            End If
        Catch ex As Exception
            lblMessage.Text = ex.Message
        End Try
    End Sub


    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If cmbListLocation.Tag > 0 Then
            Me.Cursor = Cursors.WaitCursor
            sql_String = " select distinct lm.area [Route],  "
            sql_String += " tb.TripRate,tb.OtherAmount, tb.TripRate+tb.OtherAmount [TotalRate],  tb.DistanceKM,tb.DistanceKMRoundTrip,tb.CommisionPerKM,"
            sql_String += " th.recid [ContractID],lm.recid [lrecid],tb.recid [tbrecid]"
            sql_String += " from TariffRatesHeader th inner join TariffRatesDriverTrip tb "
            sql_String += " on th.recid=tb.headerID inner join LocationMaster lm"
            sql_String += " on tb.LocationIDTo=lm.recid and tb.unlocoA=lm.unloco"
            sql_String += " where tb.unlocoA='" & unlocoA & "' and  tb.equipType=" & eqpType & " and tb.LocationIDFrom=" & cmbListLocation.Tag
            sql_String += " and lm.recid not in(" & cmbListLocation.Tag & ")"
            Call loadData(sql_String)
        End If

    End Sub

    Private Sub loadData(sqlstr As String)
        Dim dsx As New DataSet
        Try
            Me.Cursor = Cursors.WaitCursor
            lblMessage.Text = ""
            formReturnValueDBL = 0 : formReturnValueINT = 0
            DgridWaybillList.DataSource = Nothing
            dsx = setDataList(sqlstr)
            If dsx.Tables(0).Rows.Count > 0 Then
                DgridWaybillList.DataSource = dsx.Tables(0)
                DgridWaybillList.Columns("lrecid").IsVisible = False
                DgridWaybillList.Columns("tbrecid").IsVisible = False
                lblMessage.Text = "Rows Found " & dsx.Tables(0).Rows.Count
                DgridWaybillList.Columns(0).Width = 200
                DgridWaybillList.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill
                ' DgridWaybillList.MasterTemplate.BestFitColumns()
            Else
                lblMessage.Text = "Rates Not Found for this Route"
            End If

        Catch ex As Exception
            lblMessage.Text = ex.Message
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub DgridWaybillList_CellDoubleClick(sender As Object, e As GridViewCellEventArgs) Handles DgridWaybillList.CellDoubleClick
        Try
            formReturnValueINT = DgridWaybillList.Rows(e.RowIndex).Cells("tbrecid").Value
            formReturnValueDBL = DgridWaybillList.Rows(e.RowIndex).Cells("totalrate").Value
            Me.Close()
        Catch ex As Exception
            lblMessage.Text = ex.Message
        End Try
    End Sub

    Private Sub btnSaveEntry_Click(sender As Object, e As EventArgs) Handles btnSaveEntry.Click
        If DgridWaybillList.Rows.Count > 0 Then Call DgridWaybillList_CellDoubleClick(sender, e)
    End Sub

    Private Sub TextBox1_GotFocus(sender As Object, e As EventArgs) Handles TextBox1.GotFocus
        'unlocode
        TextBox1.SelectAll()
    End Sub

End Class