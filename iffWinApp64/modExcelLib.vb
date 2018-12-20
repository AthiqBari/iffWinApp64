Imports Telerik.WinControls.UI
Imports System.Data.Sql
Imports System.Data
Imports System.Data.SqlClient
Imports System.Exception
Imports System.Data.OleDb
Imports System.IO
Imports Excel = Microsoft.Office.Interop.Excel

Module modExcelLib
    Public appPath As String = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase)
    Public Function copyTemplate(templateFileName As String, title As String) As String
        Try
            Dim destinationFile As String = Application.StartupPath & "\excel files\"
            Dim sourceFile As String = Application.StartupPath & "\template\" & templateFileName 'WorkshopReportsHeader.xls" 'RepairRequestFormTemplate
            Dim destinationFileName As String = title & "-" & DateTime.Now.Hour.ToString + "" + DateTime.Now.Minute.ToString + "" + DateTime.Now.Second.ToString & ".xls"
            destinationFile = destinationFile.ToString & destinationFileName
            File.Copy(sourceFile, destinationFile)
            Return destinationFile
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "copyTemplate(...")
            Return ""
        End Try
    End Function


    Public Sub ExportToPDF(sourceFile As String, password As String)
        Dim justFileName As String = ""
        Dim xlApp As Excel.Application
        xlApp = New Excel.Application
        'Dim xlApp As New Microsoft.Office.Interop.Excel.ApplicationClass
        Dim xlWorkBook As Microsoft.Office.Interop.Excel.Workbook
        Dim xlWorkSheet As Microsoft.Office.Interop.Excel.Worksheet
        Dim pdfFile As String = ""

        Try

            frmWaitForm.lblTitle.Text = "Converting to PDF. please wait..!"
            frmWaitForm.Show()
            frmWaitForm.Refresh()


            xlWorkBook = xlApp.Workbooks.Open(sourceFile, Password:=password)           ' WORKBOOK TO OPEN THE EXCEL FILE.
            justFileName = xlWorkBook.Name()
            xlWorkSheet = xlWorkBook.Worksheets(1)    ' THE NAME OF THE WORK SHEET. 

            xlWorkSheet.ExportAsFixedFormat( _
                        Excel.XlFixedFormatType.xlTypePDF, _
                        pdfFile, _
                     Excel.XlFixedFormatQuality.xlQualityStandard, _
                          True, _
                        True, _
                        1, _
                        10, _
                          True)
            '
            xlWorkBook.Close()

            ''open excel f ile after writing data
            'xlApp.Workbooks.Open(sourceFile)
            'xlApp.Visible = True
            releaseObject(xlApp)
            releaseObject(xlWorkBook)
            releaseObject(xlWorkSheet)

            'MsgBox("PDF Saved to your Documents Folder", vbInformation, "PDF Export Complete")


        Catch ex As Exception
            frmWaitForm.Close()
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "ExportToPDF")
        Finally
            frmWaitForm.Close()
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


    Public Function DrawText(text As [String], font As System.Drawing.Font, textColor As Color, backColor As Color, height As Double, width As Double) As System.Drawing.Image
        'create a bitmap image with specified width and height
        Dim img As Image = New Bitmap(CInt(Math.Truncate(width)), CInt(Math.Truncate(height)))
        Dim drawing As Graphics = Graphics.FromImage(img)

        'get the size of text
        Dim textSize As SizeF = drawing.MeasureString(text, font)
        'set rotation point
        drawing.TranslateTransform((CInt(Math.Truncate(width)) - textSize.Width) \ 2, (CInt(Math.Truncate(height)) - textSize.Height) \ 2)

        'rotate text   
        drawing.RotateTransform(-45)

        'reset translate transform 
        drawing.TranslateTransform(-(CInt(Math.Truncate(width)) - textSize.Width) \ 2, -(CInt(Math.Truncate(height)) - textSize.Height) \ 2)

        'paint the background
        drawing.Clear(backColor)

        'create a brush for the text
        Dim textBrush As Brush = New SolidBrush(textColor)

        'draw text on the image at center position
        drawing.DrawString(text, font, textBrush, (CInt(Math.Truncate(width)) - textSize.Width) \ 2, (CInt(Math.Truncate(height)) - textSize.Height) \ 2)
        drawing.Save()
        Return img
    End Function


End Module



