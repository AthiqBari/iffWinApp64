Imports System
Imports System.IO
Public Class clsLogFile
    Private str As String = ""

    Public Sub logMessage(logFileName As String, logText As String)
        Using w As StreamWriter = File.AppendText(logFileName)
            Log(logText, w)
            'Log("Test2", w)
        End Using

        Using r As StreamReader = File.OpenText(logFileName) '"C:\atq.projects\iffWinApp64\iffWinApp64\bin\Debug\recentinvoices.txt")
            str = DumpLog(r)
        End Using
    End Sub

    Public Sub Log(logMessage As String, w As TextWriter)
        On Error Resume Next
        w.Write(logMessage)
        'w.Write(vbCrLf + "Log Entry : ")
        'w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(), _
        '    DateTime.Now.ToLongDateString())
        'w.WriteLine("  :")
        'w.WriteLine("  :{0}", logMessage)
        'w.WriteLine("-------------------------------")
    End Sub

    Public Function DumpLog(r As StreamReader) As String
        'Return r.ReadLine()
        Dim lines As Integer = 50 'read only first 
        Dim line As String = ""
        line = r.ReadLine()
        MsgBox(line)
        line = r.Read()
        MsgBox(line)

        While Not (line Is Nothing)

            'Console.WriteLine(line)
            MsgBox(line.ToString)
            line = r.ReadLine()
        End While
        Return line
    End Function

End Class
