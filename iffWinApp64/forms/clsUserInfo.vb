Public Class clsUserInfo

    Public Id As Integer
    Public Code As String
    Public Name As String
    Public Email As String
    Public Active As Boolean
    Public BranchId As Integer
    Public Password As String
    Public OnlyJobCost As Boolean
    Public isAdmin As Boolean
    Public Sub New()
        Id = 0
        Code = ""
        Name = ""
        Email = ""
        Active = False
        BranchId = 0
        Password = ""
        isAdmin = False
        OnlyJobCost = False
    End Sub
End Class
