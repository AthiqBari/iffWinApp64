

'Common Application Functions
Imports System.Data.SqlClient
Imports System.Xml
Imports System.IO
Imports Excel = Microsoft.Office.Interop.Excel
Imports Microsoft.Office.Interop
Imports System.Data.OleDb

Module modCommonLib

    Private sql_cnnSTR As String
    Public sql_CNN As New SqlConnection
    Public sql_String As String
    Public sql_CNNLocalDB As New SqlConnection
    Public appLocalServer As String
    Public mdbPath As String


    Public RemoteServerAddress As String
    Public RemoteUserName As String
    Public RemotePassword As String
    Public appeDocsPath As String
    Public appExcelFilesPath As String
    Public appUserInfo As New clsUserInfo()
    Public appCompanyInfo As New clsCompanyAndBranch()
    Public appUserRights As New clsUserRights()

    Public formReturnValueINT As Integer
    Public formReturnValueDBL As Double
    Public formReturnValyeSTR As String


    Public Sub createConnection()
        Try
            Dim cnnStr As String = ""
            cnnStr = "Data Source=" & RemoteServerAddress & ";Initial Catalog=iff2009;Persist Security Info=True;User ID=" & RemoteUserName & ";Password=" & RemotePassword
            sql_CNN = New SqlConnection(cnnStr.ToString) ' My.Settings.remote_gesksa.ToString)
            sql_CNN.Open()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "DB Connection Error")
        End Try
    End Sub

    Public Sub createConnectionLocalServer()
        Try
            Dim cnnStr As String = ""
            cnnStr = "Data Source=" & appLocalServer & ";Initial Catalog=iff2009;Persist Security Info=True;User ID=" & RemoteUserName & ";Password=" & RemotePassword
            sql_CNNLocalDB = New SqlConnection(cnnStr.ToString) ' My.Settings.remote_gesksa.ToString)
            sql_CNNLocalDB.Open()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Local DB Connection Error")
        End Try
    End Sub

    Public Function setDataList(ByVal sqlString As String) As DataSet
        Dim ds As New DataSet
        Dim command As New SqlCommand
        Dim adapter As New SqlDataAdapter
        sql_String = sqlString
        If sql_CNN.State = ConnectionState.Closed Then createConnection()
        Try
            If sql_CNN.State = ConnectionState.Open Then 'valid cnn
                command = New SqlCommand(sql_String, sql_CNN)
                command.CommandTimeout = (24 * 3600)
                adapter.SelectCommand = command
                adapter.Fill(ds, "cdata")
            End If
            Return ds
        Catch ex As Exception
            Return Nothing
        End Try
        '  closeConnection()
    End Function

    Public Function Integer_To_Date(ByVal IntDate As String) As String
        Dim StrDate As String
        StrDate = Mid(IntDate, 7, 2) & "/" & Mid(IntDate, 5, 2) & "/" & Mid(IntDate, 1, 4)
        Return StrDate
    End Function
    Public Function Date_To_Integer(ByVal IntDate As String) As String
        Dim StrYear As String
        Dim StrMonth As String
        Dim StrDay As String
        Dim StrDate As String
        If Len(IntDate) <> 10 Then MsgBox("Date Format should be dd/mm/yyyy ...") : Return False
        StrYear = Mid(IntDate, 7, 4)
        If Val(StrYear) < 1300 Then MsgBox("Year is in wrong format ...") : Return False
        StrMonth = Mid(IntDate, 4, 2)
        If Val(StrMonth) = 0 Or Val(StrMonth) > 12 Then MsgBox("Month in wrong format ") : Return False
        StrDay = Mid(IntDate, 1, 2)
        If Val(StrDay) > 31 Or Val(StrDay) = 0 Then MsgBox("Day in wrong format ...") : Return False
        StrDate = StrYear & StrMonth & StrDay
        Return StrDate
    End Function

    Public Function fillCombo(objName As Object, sqlString As String, _
              dropDownWidth As Integer, dropDownHeight As Integer, _
              col0Width As Integer, col1Width As Integer) As Boolean
        '        Call createConnection()
        Dim ds As New DataSet
        If sql_CNN.State = ConnectionState.Closed Then Call createConnection()
        If sql_CNN.State = ConnectionState.Closed Then MsgBox("Unable to connect to data server...", MsgBoxStyle.Critical, "FillCombo") : End
        Try
            ds = setDataList(sqlString)
            objName.DataSource = Nothing
            If ds.Tables(0).Rows.Count > 0 Then
                objName.DataSource = ds.Tables(0)
                Call RadComboSetting(objName, dropDownWidth, dropDownHeight, col0Width, col1Width)
                Return True
            Else

                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "fillCombo(...")
            Return False
        End Try

    End Function

    Public Sub RadComboSetting(objName As Object, dropDownWidth As Integer, dropDownHeight As Integer, col0Width As Integer, col1Width As Integer)

        With objName
            .Tag = 0
            .DropDownSizingMode = Telerik.WinControls.UI.SizingMode.UpDownAndRightBottom
            .EditorControl.MasterTemplate.AutoGenerateColumns = True
            .DropDownMinSize = New Size(dropDownWidth, dropDownHeight)
            .AutoCompleteMode = AutoCompleteMode.SuggestAppend

            If col0Width > 0 Then .Columns(0).Width = col0Width
            If col1Width > 0 Then .Columns(1).Width = col1Width
        End With
    End Sub


    Public Sub readSetting()
        Dim appPath As String = ""
        appPath = Application.StartupPath ' New Uri(appPath).LocalPath
        RemoteUserName = My.Settings.remote_user  ' "sa"
        RemotePassword = My.Settings.remote_pwd ' "Admin@123"
        RemoteServerAddress = ""
        appeDocsPath = ""
        appExcelFilesPath = ""

        Dim xmlDoc As New XmlDocument()
        xmlDoc.Load(appPath & "\settings.xml")
        Dim nodes As XmlNodeList = xmlDoc.DocumentElement.SelectNodes("/settings/connections")
        '        Dim nodes2 As XmlNodeList = xmlDoc.DocumentElement.SelectNodes("/settings/format")
        For Each node As XmlNode In nodes
            RemoteServerAddress = node.SelectSingleNode("server").InnerText
            appLocalServer = node.SelectSingleNode("localdb").InnerText
            appeDocsPath = node.SelectSingleNode("edocs").InnerText
            appExcelFilesPath = node.SelectSingleNode("excelFilesLocation").InnerText
            mdbPath = node.SelectSingleNode("mdbpath").InnerText
            'MessageBox.Show(RemoteServerAddress & " " & appeDocsPath & " " & appExcelFilesPath)
        Next
    End Sub

 

    Public Function getCompanyAndBranchDetails(ByVal branchID As Integer) As Boolean
        Dim tmpSQL As SqlDataReader
        Dim tmpCMD As New SqlCommand
        Dim sqlString As String
        Try
            createConnection()
            sqlString = "select br.recid [brid], br.name [brname], br.address1 + ' Tel:'+ br.tel + ' ' + br.email [brAddr], br.email [bremail],br.brcode,"
            sqlString += "co.recid [coid], co.name [coname],co.address1 + ' Tel:' + co.tel [coadd1], co.website [coweb],co.vatregno [covatno],co.contactperson [coperson],"
            sqlString += "co.email [coemail],br.VATInvoiceTemplate [vatinvtemplate],br.docprefix,QuoteTemplate,customizerptpath,isnull(vatpercentage,0) vatp"
            sqlString += " from branch br inner join company co on br.companyid=co.recid and br.recid=" & branchID
            sqlString += " left outer join [settingsnew] s on br.recid=s.brid"


            If sql_CNN.State = ConnectionState.Open Then 'valid cnn
                With tmpCMD
                    .Connection = sql_CNN
                    .CommandType = CommandType.Text
                    .CommandTimeout = (24 * 3600)
                    .CommandText = sqlString
                End With
                tmpSQL = tmpCMD.ExecuteReader()
                If tmpSQL.HasRows Then
                    While (tmpSQL.Read())
                        With appCompanyInfo
                            .companyID = tmpSQL("coid").ToString()
                            .companyName = tmpSQL("coname").ToString()
                            .companyAddress = tmpSQL("coadd1").ToString()
                            .companyAddress2 = ""
                            .companyWebsite = tmpSQL("coweb").ToString()
                            .companyContactPerson = tmpSQL("coperson").ToString
                            .branchID = tmpSQL("brid").ToString()
                            .branchCode = tmpSQL("brcode").ToString()
                            .branchName = tmpSQL("brname").ToString()
                            .branchAddress = tmpSQL("braddr").ToString()
                            .branchEmail = tmpSQL("bremail").ToString()
                            .branchContact = tmpSQL("coperson").ToString
                            .companyEmail = tmpSQL("coemail").ToString()
                            .invoiceTemplateVAT = tmpSQL("vatinvtemplate").ToString()
                            .VATRegNo = tmpSQL("covatno").ToString()
                            .crmQuoteTemplate = tmpSQL("QuoteTemplate").ToString
                            .branchDocPrefix = tmpSQL("docprefix").ToString
                            .customizerptpath = tmpSQL("customizerptpath").ToString
                            .VATPercentage = tmpSQL("vatp").ToString
                        End With
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


    Public Function writeWaybillDataToLocalDB(intwbno As Integer, intbatchno As Integer, printblankdate As Boolean) As Boolean
        Dim adapter As New SqlDataAdapter
        Dim ds As New DataSet
        Dim dr As DataRow
        Dim cmdbuilder As SqlCommandBuilder
        Dim rtnval As Boolean = True

        Try
            Call createConnectionLocalServer()
            If sql_CNNLocalDB.State = ConnectionState.Closed Then
                frmWaitForm.Close()
                MsgBox("Unable to connect to local server, check the service and try again", MsgBoxStyle.Critical, "Connection Error")
                rtnval = False
                Return rtnval
            End If
            sql_String = "truncate table [rptWaybillTTS001]"
            Dim commandy As New SqlCommand(sql_String, sql_CNNLocalDB)
            commandy.ExecuteNonQuery()


            'get data into datatable from remote and write to local server
            sql_String = "select * from [viewquerywaybillrecord2018] "
            If intwbno > 0 Then sql_String += " where wbid=" & intwbno
            If intbatchno > 0 Then sql_String += " where batchno=" & intbatchno
            Dim dstmp As New DataSet
            dstmp = setDataList(sql_String)
            If dstmp.Tables(0).Rows.Count > 0 Then
                For i = 0 To dstmp.Tables(0).Rows.Count - 1
                    With dstmp.Tables(0).Rows(i)
                        cmdbuilder = New SqlCommandBuilder(adapter)
                        With adapter
                            sql_String = "select * from [rptWaybillTTS001] where wbno=-1"
                            .SelectCommand = New SqlCommand(sql_String, sql_CNNLocalDB)
                            .Fill(ds, "cdata")
                        End With
                        dr = ds.Tables("cdata").NewRow
                        ds.Tables("cdata").Rows.Add(dr) 'add the row to dataset
                        dr.Item("branchid") = .Item("branchid")
                        dr.Item("wbno") = .Item("wbno")
                        dr.Item("jobnumber") = .Item("Job No")
                        dr.Item("batchno") = .Item("batchslno")
                        dr.Item("vesselname") = .Item("VesselName")
                        dr.Item("voyage") = .Item("voyageNo")
                        dr.Item("netwgt") = .Item("netwght")
                        dr.Item("freezer") = .Item("grosswght")
                        dr.Item("wbrefno") = .Item("wbRefNo")
                        dr.Item("client") = .Item("Client")
                        dr.Item("blno") = .Item("blno")
                        dr.Item("clientaddress") = .Item("ClientAddress")
                        dr.Item("contactperson") = .Item("ContactPerson1")
                        dr.Item("telephone") = .Item("Telephone")
                        dr.Item("pol") = .Item("PickupAddress") & " " & .Item("LocArea1")
                        dr.Item("pod") = .Item("DeliveryAddress") & " " & .Item("LocArea2")
                        dr.Item("eqpname") = .Item("EqpName")
                        dr.Item("drivername") = .Item("DriverNameLocal")
                        dr.Item("drivercontact") = .Item("DriverContact") & " ID " & .Item("driverID")
                        dr.Item("eqptype") = .Item("EqpType")
                        dr.Item("qty") = .Item("loadQty")
                        dr.Item("gooddesc") = .Item("goodsdesc")
                        dr.Item("containerno") = .Item("containerNo") & " " & .Item("containerType")
                        dr.Item("deliveryinstruction") = .Item("DeliveryInstruction")
                        dr.Item("createdby") = .Item("createdBy")
                        If Not printblankdate Then dr.Item("createdon") = Microsoft.VisualBasic.Left(dstmp.Tables(0).Rows(i).Item("CreatedOn"), 9)
                        adapter.Update(ds, "cdata")
                    End With
                Next
            End If

        Catch ex As Exception
            rtnval = False
            frmWaitForm.Close()
            MsgBox(ex.Message, MsgBoxStyle.Critical, "writeWaybillDataToLocalDB")
        End Try
        Return rtnval
    End Function

    Public Function writeWaybillDataToLocalDBAccess(intwbno As Integer, intbatchno As Integer, printblankdate As Boolean) As Boolean
        Dim adapter As New SqlDataAdapter
        Dim ds As New DataSet
        'Dim dr As DataRow
        '     Dim cmdbuilder As SqlCommandBuilder
        Dim rtnval As Boolean = True

        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor

        Try
            Dim Con = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & mdbPath & "\iffrpt.mdb")
            Dim objCmd As New OleDbCommand
            Con.Open()
            objCmd = New OleDbCommand("delete * from rptWaybillTTS001;", Con)
            objCmd.ExecuteNonQuery()


            'get data into datatable from remote and write to local server
            sql_String = "select * from [viewquerywaybillrecord2018] "
            If intwbno > 0 Then sql_String += " where wbid=" & intwbno
            If intbatchno > 0 Then sql_String += " where batchno=" & intbatchno
            Dim dstmp As New DataSet
            dstmp = setDataList(sql_String)
            If dstmp.Tables(0).Rows.Count > 0 Then
                For i = 0 To dstmp.Tables(0).Rows.Count - 1
                    With dstmp.Tables(0).Rows(i)
                        sql_String = "insert into [rptWaybillTTS001] (branchid,wbno,jobnumber,batchno,vesselname,voyage,netwgt,freezer,"
                        sql_String += "wbrefno,client,blno,clientaddress,contactperson,telephone,pol,pod,"
                        sql_String += "eqpname,drivername,drivercontact,eqptype,qty,gooddesc,containerno,deliveryinstruction,createdby,createdon)"
                        sql_String += " values(" & .Item("branchid") & "," & .Item("wbno") & ",'" & .Item("Job No") & "','" & .Item("batchslno") _
                            & "','" & .Item("VesselName") & "','" _
                            & Replace(.Item("voyageNo"), "'", "") & "','" _
                            & Replace(.Item("netwght"), "'", "") & "','" _
                            & Replace(.Item("grosswght"), "'", "") & "','" _
                            & Replace(.Item("wbRefNo"), "'", "") & "','" _
                            & Replace(.Item("Client"), "'", "") & "','" _
                            & Replace(.Item("blno"), "'", "") & "','" _
                            & Replace(.Item("ClientAddress"), "'", "") _
                            & "','" & Replace(.Item("ContactPerson1"), "'", "") _
                            & "','" & Replace(.Item("Telephone"), "'", "") & "','" _
                            & Replace(.Item("PickupAddress"), "'", "") & " " & Replace(.Item("LocArea1"), "'", "") & "','" _
                            & Replace(.Item("DeliveryAddress"), "'", "") & " " & Replace(.Item("LocArea2"), "'", "") & "','" _
                            & Replace(.Item("EqpName"), "'", "") & "','" & Replace(.Item("DriverNameLocal"), "'", "") & "','" _
                            & Replace(.Item("DriverContact"), "'", "") & " ID " & Replace(.Item("driverID"), "'", "") & "','" _
                            & Replace(.Item("EqpType"), "'", "") & "','" _
                            & Replace(.Item("loadQty"), "'", "") & "','" _
                            & Replace(.Item("goodsdesc"), "'", "") & "','" _
                            & Replace(.Item("containerNo"), "'", "") & " " & Replace(.Item("containerType"), "'", "") & "','" _
                            & Replace(.Item("DeliveryInstruction"), "'", "") & "','" _
                            & Replace(.Item("createdBy"), "'", "") & "',"
                        sql_String += "'" & IIf(printblankdate, "", Microsoft.VisualBasic.Left(Replace(.Item("createdon"), "'", ""), 9)) & "');"
                        '   MsgBox(sql_String)
                        objCmd = New OleDbCommand(sql_String, Con)
                        objCmd.ExecuteNonQuery()
                    End With
                Next
                Con.Close()
            End If

        Catch ex As Exception
            rtnval = False
            frmWaitForm.Close()
            System.Windows.Forms.Cursor.Current = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Critical, "writeWaybillDataToLocalDBAccess")

        End Try
        System.Windows.Forms.Cursor.Current = Cursors.Default
        Return rtnval
    End Function


End Module



