Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared ' .[Shared]
Public Class frmCrystalReportViewer
    Dim rptName As String
    Dim rptFormula As String
    Dim blShowGroupTree As Boolean
    Dim strdbUser As String = ""
    Dim strdbPwd As String = ""
    Dim strParamValue As String = ""

    Public Sub New(reportName As String, reportFormula As String, showGroupTree As Boolean, dbUser As String, dbPassword As String, paramValue1 As String)
        ' This call is required by the designer.
        InitializeComponent()
        rptName = reportName
        rptFormula = reportFormula
        blShowGroupTree = showGroupTree
        strdbUser = dbUser.ToString
        strdbPwd = dbPassword.ToString
        strParamValue = paramValue1
        Me.Text = reportName.ToString
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub frmCrystalReportViewer_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            Dim RptObj As New ReportDocument()
            If String.IsNullOrEmpty(rptName) Then Exit Sub
            ConfigureCrystalReports()
            ''RptObj.Load(rptName)
            ''RptObj.SetDatabaseLogon(strdbUser, strdbPwd)
            ''RptObj.DataSourceConnections.Clear()
            ''RptObj.DataSourceConnections.Item(0).SetConnection("162.241.154.60", "iff2009", 1)
            'With CrystalReportViewer1
            '    .SelectionFormula = rptFormula
            '    '.DisplayGroupTree = False
            '    .ReportSource = RptObj
            'End With
            'RptObj.Refresh()
            ' RptObj.Refresh()

            Me.Text = rptName.ToString
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Load Report Failed")
        End Try
    End Sub

    Private Sub ConfigureCrystalReports()
        Dim rpt As New ReportDocument()
        rpt.Load(rptName)
        Dim connectionInfo As ConnectionInfo = New ConnectionInfo()
        connectionInfo.DatabaseName = "iff2009"
        connectionInfo.UserID = RemoteUserName ' "iffrptremote"
        connectionInfo.Password = RemotePassword ' "Admin@123456"
        SetDBLogonForReport(connectionInfo, rpt)
        With CrystalReportViewer1
            '// passing paramater value
            If Not String.IsNullOrEmpty(strParamValue) Then
                Dim crParameterFieldDefinitions As ParameterFieldDefinitions
                Dim crParameterFieldDefinition As ParameterFieldDefinition
                Dim crParameterValues As New ParameterValues
                Dim crParameterDiscreteValue As New ParameterDiscreteValue
                crParameterDiscreteValue.Value = strParamValue.ToString
                crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields()
                crParameterFieldDefinition = crParameterFieldDefinitions.Item("paramValue1")
                crParameterValues = crParameterFieldDefinition.CurrentValues
                crParameterValues.Clear()
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
            End If
            '//.............

            .SelectionFormula = rptFormula
            .Dock = DockStyle.Fill
            .ShowPrintButton = True
            .ShowExportButton = True
            .ShowGroupTreeButton = blShowGroupTree
            .ToolPanelView = IIf(blShowGroupTree, _
                     CrystalDecisions.Windows.Forms.ToolPanelViewType.GroupTree, _
                     CrystalDecisions.Windows.Forms.ToolPanelViewType.None)
            .ReportSource = rpt
        End With
    End Sub

    Private Sub SetDBLogonForReport(ByVal connectionInfo As ConnectionInfo, ByVal reportDocument As ReportDocument)
        Dim tables As Tables = reportDocument.Database.Tables
        For Each table As CrystalDecisions.CrystalReports.Engine.Table In tables
            Dim tableLogonInfo As TableLogOnInfo = table.LogOnInfo
            tableLogonInfo.ConnectionInfo = connectionInfo
            table.ApplyLogOnInfo(tableLogonInfo)
        Next
    End Sub
End Class