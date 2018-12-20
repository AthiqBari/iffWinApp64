Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Public Class frmWaitForm
    Dim con As New SqlConnection
    Dim conStr As String

    Private Sub frmWaitForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Try
        '    wbClass.getConnectionString()
        '    con = New SqlConnection(wbClass.sql_cnnSTR)
        '    con.Open()
        '    con.Close()
        'Catch ex As Exception
        '    MsgBox("Please check internet connectivity at your site", MsgBoxStyle.Critical, "Internet down")
        '    End
        'End Try
    End Sub
End Class