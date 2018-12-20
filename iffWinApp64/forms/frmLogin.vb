
Imports System.Data.Sql
Imports System.Data
Imports System.Data.SqlClient
Imports System.Xml

Public Class frmLogin

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' read setting xml
        Call readSetting()
        If Me.Visible Then radTextUser.Focus()
    End Sub

    Private Sub RadButton1_Click(sender As Object, e As EventArgs) Handles RadButton1.Click
        'verify user
        frmWaitForm.lblTitle.Text = "Validating Credentials. Please Wait..!"
        frmWaitForm.Show()
        frmWaitForm.Refresh()
        Me.Cursor = Cursors.WaitCursor

        If getUserDetails(radTextUser.Text) Then
            If radTextPassword.Text <> appUserInfo.Password Then
                'MsgBox("Incorrect password... verify your login and try again", MsgBoxStyle.Exclamation, Me.Text)
                lblMsg.Text = "Incorrect password... verify your login and try again"
                radTextPassword.Focus()
                radTextPassword.SelectAll()
            Else

                If appUserInfo.Active = False Then
                    lblMsg.Text = "User status is marked as In-Active, Contact Admin"
                    radTextUser.Focus()
                    radTextUser.SelectAll()
                Else
                    Me.Text += " | " & appUserInfo.Name ' & " - " & loggedStation & IIf(readOnlyUser, " (ReadOnly)", "")
                    Call getUserRights(radTextUser.Text)
                    Call getCompanyAndBranchDetails(appUserInfo.BranchId)
                    If appCompanyInfo.companyID = 0 Then MsgBox("Unable to find company details, contact admin", MsgBoxStyle.Critical, "Closing Application") : End
                    Me.Hide()

                    iffMainMenu.Show()
                    iffMainMenu.Focus()

                End If
            End If
        Else
            'MsgBox("Invalid user name... verify your login and try again", MsgBoxStyle.Exclamation, Me.Text)
            lblMsg.Text = "Invalid user name... verify your login and try again"
            radTextUser.Focus()
            radTextUser.SelectAll()
        End If

        frmWaitForm.Close()

        Me.Cursor = Cursors.Default

    End Sub


    Public Function getUserDetails(ByVal userID As String) As Boolean
        Dim tmpSQL As SqlDataReader
        Dim tmpCMD As New SqlCommand
        Try
            createConnection()
            If sql_CNN.State = ConnectionState.Open Then 'valid cnn
                With tmpCMD
                    .Connection = sql_CNN
                    .CommandType = CommandType.Text
                    .CommandTimeout = (24 * 3600)
                    .CommandText = "select * from [users] where userid='" & userID & "'" ' and (cwuser=1 or workshopuser=1);"
                End With
                tmpSQL = tmpCMD.ExecuteReader()
                If tmpSQL.HasRows Then
                    While (tmpSQL.Read())
                        appUserInfo.Id = tmpSQL("recid").ToString()
                        appUserInfo.Name = tmpSQL("name").ToString()
                        appUserInfo.Password = tmpSQL("password").ToString()
                        appUserInfo.BranchId = tmpSQL("branchid").ToString()
                        appUserInfo.Active = tmpSQL("status").ToString()
                        ' appUserInfo.Active = IIf(tmpSQL("status").ToString() = 0, False, True)
                        appUserInfo.Code = tmpSQL("userid").ToString()
                        appUserInfo.Email = tmpSQL("email").ToString()
                        appUserInfo.isAdmin = tmpSQL("isAdmin")
                    End While
                    Return True
                Else
                    Return False
                End If

            Else
                Return False
            End If

        Catch ex As Exception
            Return False
        End Try
        tmpCMD.Dispose()
    End Function
    Private Sub radTextUser_GotFocus(sender As Object, e As EventArgs) Handles radTextUser.GotFocus
        radTextUser.SelectAll()
    End Sub
    Private Sub radTextUser_KeyPress(sender As Object, e As KeyPressEventArgs) Handles radTextUser.KeyPress
        lblMsg.Text = ""
    End Sub
    Private Sub radTextPassword_GotFocus(sender As Object, e As EventArgs) Handles radTextPassword.GotFocus
        radTextPassword.SelectAll()
    End Sub
    Private Sub radTextPassword_KeyDown(sender As Object, e As KeyEventArgs) Handles radTextPassword.KeyDown
        If e.KeyValue = Keys.Return Then
            Call RadButton1_Click(sender, e)
        End If
    End Sub

    Private Sub radTextPassword_KeyPress(sender As Object, e As KeyPressEventArgs) Handles radTextPassword.KeyPress
        lblMsg.Text = ""
    End Sub

    Public Sub getUserRights(ByVal userID As String)
        Dim tmpSQL As SqlDataReader
        Dim tmpCMD As New SqlCommand
        appUserInfo.OnlyJobCost = False
        Try
            createConnection()
            If sql_CNN.State = ConnectionState.Open Then 'valid cnn
                With tmpCMD
                    .Connection = sql_CNN
                    .CommandType = CommandType.Text
                    .CommandTimeout = (24 * 3600)
                    .CommandText = "select * from [UsersAccess] where userid='" & userID & "'" ' and (cwuser=1 or workshopuser=1);"
                End With
                tmpSQL = tmpCMD.ExecuteReader()
                If tmpSQL.HasRows Then
                    While (tmpSQL.Read())
                        appUserInfo.OnlyJobCost = tmpSQL("OnlyShipmentJobCost")
                        appUserRights.landRatesForm = tmpSQL("landRatesForm")
                        appUserRights.landModule64 = tmpSQL("landModule64")
                        appUserRights.landbillAccess = tmpSQL("landbillAccess")
                        appUserRights.landGenerateWaybill = tmpSQL("landGenerateWaybill")
                        appUserRights.landUpdateWaybill = tmpSQL("landUpdateWaybill")
                        appUserRights.landBillingTabAccess = tmpSQL("landBillingTabAccess")
                        appUserRights.landAllowToChangeITRRate = tmpSQL("landAllowToChangeITRRate")
                        appUserRights.landITRPost = tmpSQL("landITRPost")
                        appUserRights.iffVATBilling = tmpSQL("iffVATBilling")
                        appUserRights.landSetupMasterFiles = tmpSQL("landSetupMasterFiles")
                        appUserRights.landReportTab = tmpSQL("landReportTab")

                    End While
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try
        tmpCMD.Dispose()
    End Sub

    Private Sub radTextUser_TextChanged(sender As Object, e As EventArgs) Handles radTextUser.TextChanged

    End Sub

    Private Sub radTextPassword_TextChanged(sender As Object, e As EventArgs) Handles radTextPassword.TextChanged

    End Sub
End Class
