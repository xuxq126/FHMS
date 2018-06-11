Imports System
Imports System.IO
Imports System.Xml
Imports System.Text
Imports System.Security.Cryptography
Imports System.Data.SqlClient
Imports System.Configuration
Public Class SqlClass
    '  Public connectionstring As String = ConfigurationSettings.AppSettings("DBConnection")


    Public connectionString As String = "Data Source=ROMONE-PC\SQL2008EXP;Initial Catalog=FHMS2;Integrated Security=True"

    Public Function GetAge(ByVal Birthdate As System.DateTime, _
    Optional ByVal AsOf As System.DateTime = #1/1/1700#) _
    As String

        'Don't set second parameter if you want Age as of today

        'Demo 1: get age of person born 2/11/1954
        'Dim objDate As New System.DateTime(1954, 2, 11)
        'Debug.WriteLine(GetAge(objDate))

        'Demo 1: get same person's age 10 years from now
        'Dim objDate As New System.DateTime(1954, 2, 11)
        'Dim objdate2 As System.DateTime
        'objdate2 = Now.AddYears(10)
        'Debug.WriteLine(GetAge(objDate, objdate2))

        Dim iMonths As Integer
        Dim iYears As Integer
        Dim dYears As Decimal
        Dim lDayOfBirth As Long
        Dim lAsOf As Long
        Dim iBirthMonth As Integer
        Dim iAsOFMonth As Integer

        If AsOf = "#1/1/1700#" Then
            AsOf = DateTime.Now
        End If
        lDayOfBirth = DatePart(DateInterval.Day, Birthdate)
        lAsOf = DatePart(DateInterval.Day, AsOf)

        iBirthMonth = DatePart(DateInterval.Month, Birthdate)
        iAsOFMonth = DatePart(DateInterval.Month, AsOf)

        iMonths = DateDiff(DateInterval.Month, Birthdate, AsOf)

        dYears = iMonths / 12

        iYears = Math.Floor(dYears)

        If iBirthMonth = iAsOFMonth Then
            If lAsOf < lDayOfBirth Then
                iYears = iYears - 1
            End If
        End If

        Return iYears
    End Function
    Public Function GetImageBytes(ByVal img As Image) As Byte()

        If img Is Nothing Then Return Nothing

        Dim bImg() As Byte
        Dim imgLength As ImageConverter

        imgLength = New ImageConverter

        bImg = imgLength.ConvertTo(img, GetType(Byte()))

        Return bImg
    End Function

    Function updatePicture(ByVal image As Byte(), ByVal Id As String)

        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(connectionString)

        Dim queryString As String = "Update ApplicantsInfo set picture=@image where AppId=@id"
        Dim dbCommand As System.Data.IDbCommand = New System.Data.SqlClient.SqlCommand
        dbCommand.CommandText = queryString
        dbCommand.Connection = dbConnection


        Dim dbParam_facName As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_facName.ParameterName = "@image"
        dbParam_facName.Value = image
        dbParam_facName.DbType = SqlDbType.Binary
        dbCommand.Parameters.Add(dbParam_facName)

        Dim dbParam_parId As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_parId.ParameterName = "@Id"
        dbParam_parId.Value = Id
        dbParam_parId.DbType = DbType.String
        dbCommand.Parameters.Add(dbParam_parId)


        Dim rowsAffected As Integer = 0
        dbConnection.Open()
        Try
            rowsAffected = dbCommand.ExecuteNonQuery
        Finally
            dbConnection.Close()
        End Try

        Return rowsAffected


    End Function

    Function getParishes() As System.Data.DataSet

        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(connectionString)
        Dim queryString As String = "select * from ParishList"
        Dim dbCommand As System.Data.IDbCommand = New System.Data.SqlClient.SqlCommand
        dbCommand.CommandText = queryString
        dbCommand.Connection = dbConnection

        dbConnection.Open()

        Dim dataAdapter As System.Data.IDbDataAdapter = New System.Data.SqlClient.SqlDataAdapter
        dataAdapter.SelectCommand = dbCommand
        Dim dataSet As System.Data.DataSet = New System.Data.DataSet
        dataAdapter.Fill(dataSet)

        Return dataSet


    End Function

    Function getTrainers(ByVal parID As Integer, ByVal acLevel As Integer) As System.Data.DataSet

        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(connectionString)
        Dim queryString As String = "select FirstName,Lastname from Users where Access_Level=@acLevel or Access_Level= @acLevel and ParishId=@parID"
        Dim dbCommand As System.Data.IDbCommand = New System.Data.SqlClient.SqlCommand
        dbCommand.CommandText = queryString
        dbCommand.Connection = dbConnection

        Dim dbParam_acLevel As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_acLevel.ParameterName = "@acLevel"
        dbParam_acLevel.Value = acLevel
        dbParam_acLevel.DbType = DbType.Int32
        dbCommand.Parameters.Add(dbParam_acLevel)


        Dim dbParam_parID As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_parID.ParameterName = "@parID"
        dbParam_parID.Value = parID
        dbParam_parID.DbType = DbType.Int32
        dbCommand.Parameters.Add(dbParam_parID)

        dbConnection.Open()

        Dim dataAdapter As System.Data.IDbDataAdapter = New System.Data.SqlClient.SqlDataAdapter
        dataAdapter.SelectCommand = dbCommand
        Dim dataSet As System.Data.DataSet = New System.Data.DataSet
        dataAdapter.Fill(dataSet)

        Return dataSet


    End Function
    Function getFacility() As System.Data.DataSet

        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(connectionString)
        Dim queryString As String = "select * from ParishList"
        Dim dbCommand As System.Data.IDbCommand = New System.Data.SqlClient.SqlCommand
        dbCommand.CommandText = queryString
        dbCommand.Connection = dbConnection

        dbConnection.Open()

        Dim dataAdapter As System.Data.IDbDataAdapter = New System.Data.SqlClient.SqlDataAdapter
        dataAdapter.SelectCommand = dbCommand
        Dim dataSet As System.Data.DataSet = New System.Data.DataSet
        dataAdapter.Fill(dataSet)

        Return dataSet


    End Function


    Function GetSchedules() As System.Data.IDataReader
        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(connectionString)

        'Dim queryString As String = "select * from ParishList"
        Dim dbCommand As System.Data.IDbCommand = New System.Data.SqlClient.SqlCommand
        ' dbCommand.CommandText = queryString
        dbCommand.Connection = dbConnection
        dbConnection.Open()
        Dim dataReader As System.Data.IDataReader = dbCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection)

        Return dataReader

    End Function

    Function AddSchedule(ByVal sdate As Date, ByVal stime As String, ByVal strId As String, ByVal facID As Integer, ByVal handID As Integer, ByVal schType As String, ByVal recNo As String, ByVal parId As Integer) As Integer
        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(connectionString)

        Dim queryString As String = "Insert Into Schedules (SchDate,SchTime,TrainID,facilityID,HandlerID,ScheduleType,onsiteRecNo,ParishId)Values (@sdate,@stime,@strId,@facID,@handID,@schtype,@recNo,@parID)"
        Dim dbCommand As System.Data.IDbCommand = New System.Data.SqlClient.SqlCommand
        dbCommand.CommandText = queryString
        dbCommand.Connection = dbConnection


        Dim dbParam_sdate As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_sdate.ParameterName = "@sdate"
        dbParam_sdate.Value = sdate
        dbParam_sdate.DbType = DbType.Date
        dbCommand.Parameters.Add(dbParam_sdate)

        Dim dbParam_stime As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_stime.ParameterName = "@stime"
        dbParam_stime.Value = stime
        dbParam_stime.DbType = DbType.String
        dbCommand.Parameters.Add(dbParam_stime)

        Dim dbParam_strId As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_strId.ParameterName = "@strId"
        dbParam_strId.Value = strId
        dbParam_strId.DbType = DbType.String
        dbCommand.Parameters.Add(dbParam_strId)

        Dim dbParam_facID As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_facID.ParameterName = "@facID"
        dbParam_facID.Value = facID
        dbParam_facID.DbType = DbType.String
        dbCommand.Parameters.Add(dbParam_facID)

        Dim dbParam_handID As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_handID.ParameterName = "@handID"
        dbParam_handID.Value = handID
        dbParam_handID.DbType = DbType.Int32
        dbCommand.Parameters.Add(dbParam_handID)

        Dim dbParam_schType As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_schType.ParameterName = "@schtype"
        dbParam_schType.Value = schType
        dbParam_schType.DbType = DbType.String
        dbCommand.Parameters.Add(dbParam_schType)

        Dim dbParam_recNo As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_recNo.ParameterName = "@recNo"
        dbParam_recNo.Value = recNo
        dbParam_recNo.DbType = DbType.String
        dbCommand.Parameters.Add(dbParam_recNo)

        Dim dbParam_ParID As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_ParID.ParameterName = "@ParID"
        dbParam_ParID.Value = parId
        dbParam_ParID.DbType = DbType.Int32
        dbCommand.Parameters.Add(dbParam_ParID)


        Dim rowsAffected As Integer = 0
        dbConnection.Open()
        Try
            rowsAffected = dbCommand.ExecuteNonQuery
        Finally
            dbConnection.Close()
        End Try

        Return rowsAffected

    End Function

    Function AddFacility(ByVal facName As String, ByVal parId As Integer, ByVal FacType As Integer) As Integer
        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(connectionString)

        Dim queryString As String = "Insert Into Facility (FacilityName,ParishID,FacilityType)Values (@facname,@parId,@facType)"
        Dim dbCommand As System.Data.IDbCommand = New System.Data.SqlClient.SqlCommand
        dbCommand.CommandText = queryString
        dbCommand.Connection = dbConnection


        Dim dbParam_facName As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_facName.ParameterName = "@facName"
        dbParam_facName.Value = facName
        dbParam_facName.DbType = DbType.String
        dbCommand.Parameters.Add(dbParam_facName)

        Dim dbParam_parId As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_parId.ParameterName = "@parId"
        dbParam_parId.Value = parId
        dbParam_parId.DbType = DbType.Int32
        dbCommand.Parameters.Add(dbParam_parId)

        Dim dbParam_FacType As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_FacType.ParameterName = "@FacType"
        dbParam_FacType.Value = FacType
        dbParam_FacType.DbType = DbType.Int32
        dbCommand.Parameters.Add(dbParam_FacType)

        Dim rowsAffected As Integer = 0
        dbConnection.Open()
        Try
            rowsAffected = dbCommand.ExecuteNonQuery
        Finally
            dbConnection.Close()
        End Try

        Return rowsAffected

    End Function


    Function SelectFacilities(ByVal facType As Integer, ByVal parID As Integer) As System.Data.DataSet
        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(connectionString)
        Dim queryString As String = "select * from Facility Where facilityType=@facType and ParishId=@parID"
        Dim dbCommand As System.Data.IDbCommand = New System.Data.SqlClient.SqlCommand
        dbCommand.CommandText = queryString
        dbCommand.Connection = dbConnection

        Dim dbParam_facType As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_facType.ParameterName = "@facType"
        dbParam_facType.Value = facType
        dbParam_facType.DbType = DbType.Int32
        dbCommand.Parameters.Add(dbParam_facType)

        Dim dbParam_parID As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_parID.ParameterName = "@parID"
        dbParam_parID.Value = parID
        dbParam_parID.DbType = DbType.Int32
        dbCommand.Parameters.Add(dbParam_parID)

        dbConnection.Open()

        Dim dataAdapter As System.Data.IDbDataAdapter = New System.Data.SqlClient.SqlDataAdapter
        dataAdapter.SelectCommand = dbCommand
        Dim dataSet As System.Data.DataSet = New System.Data.DataSet
        dataAdapter.Fill(dataSet)

        Return dataSet


    End Function
    Function AllFacilities() As System.Data.DataSet
        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(connectionString)
        Dim queryString As String = "select * from Facility"
        Dim dbCommand As System.Data.IDbCommand = New System.Data.SqlClient.SqlCommand
        dbCommand.CommandText = queryString
        dbCommand.Connection = dbConnection


        dbConnection.Open()

        Dim dataAdapter As System.Data.IDbDataAdapter = New System.Data.SqlClient.SqlDataAdapter
        dataAdapter.SelectCommand = dbCommand
        Dim dataSet As System.Data.DataSet = New System.Data.DataSet
        dataAdapter.Fill(dataSet)

        Return dataSet


    End Function

    Function Years() As System.Data.IDataReader
        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(connectionString)
        Dim queryString As String = "select distinct datepart(yy,schdate) as Syear from schedules"
        Dim dbCommand As System.Data.IDbCommand = New System.Data.SqlClient.SqlCommand
        dbCommand.CommandText = queryString
        dbCommand.Connection = dbConnection

        dbConnection.Open()
        Dim dataReader As System.Data.IDataReader = dbCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
        Return dataReader

    End Function

    Function SelectHandler(ByVal cat As String) As System.Data.DataSet
        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(connectionString)
        Dim queryString As String = "select * from FoodHandlersCategories where [Description]=@cat"
        Dim dbCommand As System.Data.IDbCommand = New System.Data.SqlClient.SqlCommand
        dbCommand.CommandText = queryString
        dbCommand.Connection = dbConnection

        Dim dbParam_cat As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_cat.ParameterName = "@cat"
        dbParam_cat.Value = cat
        dbParam_cat.DbType = DbType.String
        dbCommand.Parameters.Add(dbParam_cat)

        dbConnection.Open()

        Dim dataAdapter As System.Data.IDbDataAdapter = New System.Data.SqlClient.SqlDataAdapter
        dataAdapter.SelectCommand = dbCommand
        Dim dataSet As System.Data.DataSet = New System.Data.DataSet
        dataAdapter.Fill(dataSet)

        Return dataSet


    End Function

    Function GetAllSchedules(ByVal month As Integer) As System.Data.DataSet
        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(connectionString)
        Dim queryString As String = "SELECT Schedules.SchDate AS Date,Schedules.SchTime AS Time, FoodHandlersCategories.Handlername AS Category, Facility.Facilityname AS Facility," &
                                    " Schedules.RID as ID FROM Schedules, FoodHandlersCategories, Facility WHERE Schedules.handlerId=FoodHandlersCategories.HandlerID" &
                                    " and Schedules.facilityID=Facility.FacId and DATEPART(yy,schdate)=@month"

        Dim dbCommand As System.Data.IDbCommand = New System.Data.SqlClient.SqlCommand
        dbCommand.CommandText = queryString
        dbCommand.Connection = dbConnection

        Dim dbParam_month As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_month.ParameterName = "@month"
        dbParam_month.Value = month
        dbParam_month.DbType = DbType.Int32
        dbCommand.Parameters.Add(dbParam_month)


        dbConnection.Open()

        Dim dataAdapter As System.Data.IDbDataAdapter = New System.Data.SqlClient.SqlDataAdapter
        dataAdapter.SelectCommand = dbCommand
        Dim dataSet As System.Data.DataSet = New System.Data.DataSet
        dataAdapter.Fill(dataSet)

        Return dataSet
    End Function

    Function GetCurrSchedule(ByVal trainID As Integer) As System.Data.DataSet
        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(connectionString)
        Dim queryString As String = "select Schedules.SchDate as Date,Schedules.SchTime as Time,FoodHandlersCategories.Handlername as Category,Facility.Facilityname as Facility," & _
                                    " Schedules.RID as ID from Schedules,FoodHandlersCategories,Facility where Schedules.handlerId=FoodHandlersCategories.HandlerID" & _
                                    " and Schedules.facilityID=Facility.FacId and Schedules.rid=@trainID"


        Dim dbCommand As System.Data.IDbCommand = New System.Data.SqlClient.SqlCommand
        dbCommand.CommandText = queryString
        dbCommand.Connection = dbConnection

        Dim dbParam_trainID As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_trainID.ParameterName = "@trainID"
        dbParam_trainID.Value = trainID
        dbParam_trainID.DbType = DbType.Int32
        dbCommand.Parameters.Add(dbParam_trainID)


        dbConnection.Open()

        Dim dataAdapter As System.Data.IDbDataAdapter = New System.Data.SqlClient.SqlDataAdapter
        dataAdapter.SelectCommand = dbCommand
        Dim dataSet As System.Data.DataSet = New System.Data.DataSet
        dataAdapter.Fill(dataSet)

        Return dataSet
    End Function


    Function GetFullSch() As System.Data.DataSet
        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(connectionString)
        Dim queryString As String = "select Schedules.SchDate as Date,Schedules.SchTime as Time,FoodHandlersCategories.Handlername as Category,Facility.Facilityname as Facility," & _
                                    " Schedules.RID as ID from Schedules,FoodHandlersCategories,Facility where Schedules.handlerId=FoodHandlersCategories.HandlerID" & _
                                    " and Schedules.facilityID=Facility.FacId" ' and DATEPART(m,schdate)=@month"

        Dim dbCommand As System.Data.IDbCommand = New System.Data.SqlClient.SqlCommand
        dbCommand.CommandText = queryString
        dbCommand.Connection = dbConnection

        'Dim dbParam_month As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        'dbParam_month.ParameterName = "@month"
        'dbParam_month.Value = month
        'dbParam_month.DbType = DbType.Int32
        'dbCommand.Parameters.Add(dbParam_month)


        dbConnection.Open()

        Dim dataAdapter As System.Data.IDbDataAdapter = New System.Data.SqlClient.SqlDataAdapter
        dataAdapter.SelectCommand = dbCommand
        Dim dataSet As System.Data.DataSet = New System.Data.DataSet
        dataAdapter.Fill(dataSet)

        Return dataSet
    End Function

    Function AddRegApplication(ByVal AppID As String, _
                                ByVal Apdate As Date, _
                                ByVal fname As String, _
                                ByVal mname As String, _
                                ByVal lname As String, _
                                ByVal dob As Date, _
                                ByVal gender As String, _
                                ByVal tel As String, _
                                ByVal add1 As String, _
                                ByVal add2 As String, _
                                ByVal parish As String, _
                                ByVal empname As String, _
                                ByVal empadd As String, _
                                ByVal empParish As String, _
                                ByVal picture As Byte()) As Integer

        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(connectionString)
        Dim queryString As String = "Insert Into ApplicantsInfo (AppID,AppDate,fname,mname,lname,Dob,gender,telephone,address1," & _
                                    " address2,parish,emp_name,emp_address, emp_parish,picture) Values (@AppID,@apdate,@fname," & _
                                    " @mname,@lname,@dob,@gender,@tel,@add1,@add2,@parish,@empname,@empadd,@empParish,@picture)"
        Dim dbCommand As System.Data.IDbCommand = New System.Data.SqlClient.SqlCommand
        dbCommand.CommandText = queryString
        dbCommand.Connection = dbConnection

        Dim dbParam_AppID As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_AppID.ParameterName = "@AppID"
        dbParam_AppID.Value = AppID
        dbParam_AppID.DbType = DbType.String
        dbCommand.Parameters.Add(dbParam_AppID)


        Dim dbParam_Apdate As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_Apdate.ParameterName = "@Apdate"
        dbParam_Apdate.Value = Apdate
        dbParam_Apdate.DbType = DbType.Date
        dbCommand.Parameters.Add(dbParam_Apdate)

        Dim dbParam_fname As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_fname.ParameterName = "@fname"
        dbParam_fname.Value = fname
        dbParam_fname.DbType = DbType.String
        dbCommand.Parameters.Add(dbParam_fname)

        Dim dbParam_mname As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_mname.ParameterName = "@mname"
        dbParam_mname.Value = mname
        dbParam_mname.DbType = DbType.String
        dbCommand.Parameters.Add(dbParam_mname)

        Dim dbParam_lname As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_lname.ParameterName = "@lname"
        dbParam_lname.Value = lname
        dbParam_lname.DbType = DbType.String
        dbCommand.Parameters.Add(dbParam_lname)

        Dim dbParam_dob As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_dob.ParameterName = "@dob"
        dbParam_dob.Value = dob
        dbParam_dob.DbType = DbType.Date
        dbCommand.Parameters.Add(dbParam_dob)

        Dim dbParam_gender As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_gender.ParameterName = "@gender"
        dbParam_gender.Value = gender
        dbParam_gender.DbType = DbType.String
        dbCommand.Parameters.Add(dbParam_gender)

        Dim dbParam_tel As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_tel.ParameterName = "@tel"
        dbParam_tel.Value = tel
        dbParam_tel.DbType = DbType.String
        dbCommand.Parameters.Add(dbParam_tel)

        Dim dbParam_add1 As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_add1.ParameterName = "@add1"
        dbParam_add1.Value = add1
        dbParam_add1.DbType = DbType.String
        dbCommand.Parameters.Add(dbParam_add1)

        Dim dbParam_add2 As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_add2.ParameterName = "@add2"
        dbParam_add2.Value = add2
        dbParam_add2.DbType = DbType.String
        dbCommand.Parameters.Add(dbParam_add2)

        Dim dbParam_parish As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_parish.ParameterName = "@parish"
        dbParam_parish.Value = parish
        dbParam_parish.DbType = DbType.String
        dbCommand.Parameters.Add(dbParam_parish)

        Dim dbParam_empname As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_empname.ParameterName = "@empname"
        dbParam_empname.Value = empname
        dbParam_empname.DbType = DbType.String
        dbCommand.Parameters.Add(dbParam_empname)

        Dim dbParam_empadd As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_empadd.ParameterName = "@empadd"
        dbParam_empadd.Value = empadd
        dbParam_empadd.DbType = DbType.String
        dbCommand.Parameters.Add(dbParam_empadd)


        Dim dbParam_empParish As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_empParish.ParameterName = "@empParish"
        dbParam_empParish.Value = empParish
        dbParam_empParish.DbType = DbType.String
        dbCommand.Parameters.Add(dbParam_empParish)

        Dim dbParam_picture As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_picture.ParameterName = "@picture"
        dbParam_picture.Value = picture
        dbParam_picture.DbType = DbType.Binary
        dbCommand.Parameters.Add(dbParam_picture)


        Dim rowsAffected As Integer = 0
        dbConnection.Open()
        Try
            rowsAffected = dbCommand.ExecuteNonQuery
        Catch ex As Exception
            Return ex.Message
        Finally
            dbConnection.Close()
        End Try
        Return rowsAffected

    End Function

    Function getPermitINfo(ByVal parishId As Integer) As System.Data.IDataReader

        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(connectionString)

        Dim queryString As String = "Select PermitCode,Range from PermitNumber Where ParishID=@parishId"
        Dim dbCommand As System.Data.IDbCommand = New System.Data.SqlClient.SqlCommand
        dbCommand.CommandText = queryString
        dbCommand.Connection = dbConnection

        Dim dbParam_parishId As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_parishId.ParameterName = "@parishId"
        dbParam_parishId.Value = parishId
        dbParam_parishId.DbType = System.Data.DbType.Int32
        dbCommand.Parameters.Add(dbParam_parishId)

        dbConnection.Open()
        Dim dataReader As System.Data.IDataReader = dbCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection)

        Return dataReader
    End Function

    Function AddUser(ByVal fname As String, ByVal lname As String, ByVal username As String, ByVal psw As String, _
                     ByVal accessLevel As Integer, ByVal parId As Integer) As Integer

        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(connectionString)

        Dim queryString As String = "Insert Into Users (Firstname , Lastname, UserName, Password, Access_Level,ParishId)" &
                                    " Values(@fname, @lname, @username, @psw, @accessLevel, @parId)"
        Dim dbCommand As System.Data.IDbCommand = New System.Data.SqlClient.SqlCommand
        dbCommand.CommandText = queryString
        dbCommand.Connection = dbConnection

        Dim dbParam_fname As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_fname.ParameterName = "@fname"
        dbParam_fname.Value = fname
        dbParam_fname.DbType = System.Data.DbType.String
        dbCommand.Parameters.Add(dbParam_fname)

        Dim dbParam_lname As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_lname.ParameterName = "@lname"
        dbParam_lname.Value = lname
        dbParam_lname.DbType = System.Data.DbType.String
        dbCommand.Parameters.Add(dbParam_lname)

        Dim dbParam_username As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_username.ParameterName = "@username"
        dbParam_username.Value = username
        dbParam_username.DbType = System.Data.DbType.String
        dbCommand.Parameters.Add(dbParam_username)

        Dim dbParam_psw As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_psw.ParameterName = "@psw"
        dbParam_psw.Value = psw
        dbParam_psw.DbType = System.Data.DbType.String
        dbCommand.Parameters.Add(dbParam_psw)

        Dim dbParam_accessLevel As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_accessLevel.ParameterName = "@accessLevel"
        dbParam_accessLevel.Value = accessLevel
        dbParam_accessLevel.DbType = System.Data.DbType.Int32
        dbCommand.Parameters.Add(dbParam_accessLevel)

        Dim dbParam_parId As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_parId.ParameterName = "@parId"
        dbParam_parId.Value = parId
        dbParam_parId.DbType = System.Data.DbType.Int32
        dbCommand.Parameters.Add(dbParam_parId)


        Dim rowsAffected As Integer = 0
        dbConnection.Open()
        Try
            rowsAffected = dbCommand.ExecuteNonQuery
        Finally
            dbConnection.Close()
        End Try

        Return rowsAffected
    End Function

    Public Shared Function EncryptText(ByVal strText As String) As String
        Return Encrypt(strText, "&%#@?,:*")
    End Function


    'The function used to encrypt the text
    Private Shared Function Encrypt(ByVal strText As String, ByVal strEncrKey As String) As String

        Dim byKey() As Byte = {}
        Dim IV() As Byte = {&H12, &H34, &H56, &H78, &H90, &HAB, &HCD, &HEF}

        Try
            byKey = System.Text.Encoding.UTF8.GetBytes(Left(strEncrKey, 8))

            Dim des As New Security.Cryptography.DESCryptoServiceProvider
            Dim inputByteArray() As Byte = Encoding.UTF8.GetBytes(strText)
            Dim ms As New IO.MemoryStream
            Dim cs As New Security.Cryptography.CryptoStream(ms, des.CreateEncryptor(byKey, IV), CryptoStreamMode.Write)

            cs.Write(inputByteArray, 0, inputByteArray.Length)
            cs.FlushFinalBlock()

            Return Convert.ToBase64String(ms.ToArray())

        Catch ex As Exception
            Return ex.Message
        End Try

    End Function


    Function GetUser(ByVal userName As String, ByVal psw As String) As System.Data.IDataReader

        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(connectionString)

        Dim queryString As String = "SELECT * FROM Users WHERE username=@userName and Password=@psw"
        Dim dbCommand As System.Data.IDbCommand = New System.Data.SqlClient.SqlCommand
        dbCommand.CommandText = queryString
        dbCommand.Connection = dbConnection

        Dim dbParam_userName As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_userName.ParameterName = "@userName"
        dbParam_userName.Value = userName
        dbParam_userName.DbType = System.Data.DbType.String
        dbCommand.Parameters.Add(dbParam_userName)

        Dim dbParam_psw As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_psw.ParameterName = "@psw"
        dbParam_psw.Value = psw
        dbParam_psw.DbType = System.Data.DbType.String
        dbCommand.Parameters.Add(dbParam_psw)


        dbConnection.Open()
        Dim dataReader As System.Data.IDataReader = dbCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection)

        Return dataReader
    End Function


    Function UpdatePermitNumber(ByVal pnum As Integer, ByVal parId As Integer) As Integer

        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(connectionString)

        Dim queryString As String = "update PermitNumber set Range=@pnum where ParishID=@parId"
        Dim dbCommand As System.Data.IDbCommand = New System.Data.SqlClient.SqlCommand
        dbCommand.CommandText = queryString
        dbCommand.Connection = dbConnection

        Dim dbParam_pnum As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_pnum.ParameterName = "@pnum"
        dbParam_pnum.Value = pnum
        dbParam_pnum.DbType = System.Data.DbType.Int32
        dbCommand.Parameters.Add(dbParam_pnum)

        Dim dbParam_parId As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_parId.ParameterName = "@parId"
        dbParam_parId.Value = parId
        dbParam_parId.DbType = System.Data.DbType.Int32
        dbCommand.Parameters.Add(dbParam_parId)

        Dim rowsAffected As Integer = 0
        dbConnection.Open()
        Try
            rowsAffected = dbCommand.ExecuteNonQuery
        Finally
            dbConnection.Close()
        End Try

        Return rowsAffected

    End Function
    Function addMedicalCond(ByVal trainID As Integer, ByVal appId As String, ByVal condition As String) As Integer

        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(connectionString)

        Dim queryString As String = "Insert Into HealthCondition (TrainId,AppId,condition)Values(@trainID,@appId,@condition)"
        Dim dbCommand As System.Data.IDbCommand = New System.Data.SqlClient.SqlCommand
        dbCommand.CommandText = queryString
        dbCommand.Connection = dbConnection

        Dim dbParam_trainID As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_trainID.ParameterName = "@trainID"
        dbParam_trainID.Value = trainID
        dbParam_trainID.DbType = System.Data.DbType.Int32
        dbCommand.Parameters.Add(dbParam_trainID)

        Dim dbParam_appId As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_appId.ParameterName = "@appId"
        dbParam_appId.Value = appId
        dbParam_appId.DbType = System.Data.DbType.String
        dbCommand.Parameters.Add(dbParam_appId)

        Dim dbParam_condition As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_condition.ParameterName = "@condition"
        dbParam_condition.Value = condition
        dbParam_condition.DbType = System.Data.DbType.String
        dbCommand.Parameters.Add(dbParam_condition)


        Dim rowsAffected As Integer = 0
        dbConnection.Open()
        Try
            rowsAffected = dbCommand.ExecuteNonQuery
        Finally
            dbConnection.Close()
        End Try

        Return rowsAffected
    End Function

    Function AddTrainingInfo(ByVal trainID As Integer, ByVal appId As String, ByVal score As Integer, ByVal TestName As String, ByVal Trainer As String) As Integer

        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(connectionString)

        Dim queryString As String = "Insert Into Score_reg (AppId,TrainId,Score,TestName,Trainer)Values(@appId,@trainID,@score,@testName,@Trainer)"
        Dim dbCommand As System.Data.IDbCommand = New System.Data.SqlClient.SqlCommand
        dbCommand.CommandText = queryString
        dbCommand.Connection = dbConnection

        Dim dbParam_trainID As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_trainID.ParameterName = "@trainID"
        dbParam_trainID.Value = trainID
        dbParam_trainID.DbType = System.Data.DbType.Int32
        dbCommand.Parameters.Add(dbParam_trainID)

        Dim dbParam_appId As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_appId.ParameterName = "@appId"
        dbParam_appId.Value = appId
        dbParam_appId.DbType = System.Data.DbType.String
        dbCommand.Parameters.Add(dbParam_appId)

        Dim dbParam_score As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_score.ParameterName = "@score"
        dbParam_score.Value = score
        dbParam_score.DbType = System.Data.DbType.Int32
        dbCommand.Parameters.Add(dbParam_score)

        Dim dbParam_TestName As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_TestName.ParameterName = "@testName"
        dbParam_TestName.Value = TestName
        dbParam_TestName.DbType = System.Data.DbType.String
        dbCommand.Parameters.Add(dbParam_TestName)


        Dim dbParam_trainer As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_trainer.ParameterName = "@Trainer"
        dbParam_trainer.Value = Trainer
        dbParam_trainer.DbType = System.Data.DbType.String
        dbCommand.Parameters.Add(dbParam_trainer)


        Dim rowsAffected As Integer = 0
        dbConnection.Open()
        Try
            rowsAffected = dbCommand.ExecuteNonQuery
        Finally
            dbConnection.Close()
        End Try

        Return rowsAffected
    End Function
    Function UpdateTrainingInfo(ByVal trainID As Integer, ByVal OldTrainID As Integer, ByVal appId As String, ByVal score As Integer, ByVal TestName As String, ByVal Trainer As String) As Integer

        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(connectionString)

        Dim queryString As String = "Update Score_reg Set TrainId=@TrainID,Score=@score,TestName=@TestName,Trainer=@Trainer Where AppId=@AppID and TrainID=@OldTrainID"
        Dim dbCommand As System.Data.IDbCommand = New System.Data.SqlClient.SqlCommand
        dbCommand.CommandText = queryString
        dbCommand.Connection = dbConnection

        Dim dbParam_trainID As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_trainID.ParameterName = "@trainID"
        dbParam_trainID.Value = trainID
        dbParam_trainID.DbType = System.Data.DbType.Int32
        dbCommand.Parameters.Add(dbParam_trainID)

        Dim dbParam_OldTrainID As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_OldTrainID.ParameterName = "@oldTrainID"
        dbParam_OldTrainID.Value = OldTrainID
        dbParam_OldTrainID.DbType = System.Data.DbType.Int32
        dbCommand.Parameters.Add(dbParam_OldTrainID)

        Dim dbParam_appId As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_appId.ParameterName = "@appId"
        dbParam_appId.Value = appId
        dbParam_appId.DbType = System.Data.DbType.String
        dbCommand.Parameters.Add(dbParam_appId)

        Dim dbParam_score As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_score.ParameterName = "@score"
        dbParam_score.Value = score
        dbParam_score.DbType = System.Data.DbType.Int32
        dbCommand.Parameters.Add(dbParam_score)

        Dim dbParam_TestName As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_TestName.ParameterName = "@testName"
        dbParam_TestName.Value = TestName
        dbParam_TestName.DbType = System.Data.DbType.String
        dbCommand.Parameters.Add(dbParam_TestName)


        Dim dbParam_trainer As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_trainer.ParameterName = "@Trainer"
        dbParam_trainer.Value = Trainer
        dbParam_trainer.DbType = System.Data.DbType.String
        dbCommand.Parameters.Add(dbParam_trainer)


        Dim rowsAffected As Integer = 0
        dbConnection.Open()
        Try
            rowsAffected = dbCommand.ExecuteNonQuery
        Finally
            dbConnection.Close()
        End Try

        Return rowsAffected
    End Function
    Function AddToSignOff(ByVal trainID As Integer, ByVal appId As String, ByVal MOHId As Integer, ByVal review As Integer, ByVal Signed As Integer, ByVal inbatch As Integer) As Integer

        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(connectionString)

        Dim queryString As String = "Insert Into SignOff (TrainId,review,signed,MOH_ID,AppID,InBatch)Values(@trainID,@review,@signed,@MOHId,@AppId,@inbatch)"
        Dim dbCommand As System.Data.IDbCommand = New System.Data.SqlClient.SqlCommand
        dbCommand.CommandText = queryString
        dbCommand.Connection = dbConnection

        Dim dbParam_trainID As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_trainID.ParameterName = "@trainID"
        dbParam_trainID.Value = trainID
        dbParam_trainID.DbType = System.Data.DbType.Int32
        dbCommand.Parameters.Add(dbParam_trainID)

        Dim dbParam_appId As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_appId.ParameterName = "@appId"
        dbParam_appId.Value = appId
        dbParam_appId.DbType = System.Data.DbType.String
        dbCommand.Parameters.Add(dbParam_appId)

        Dim dbParam_review As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_review.ParameterName = "@review"
        dbParam_review.Value = review
        dbParam_review.DbType = System.Data.DbType.Int32
        dbCommand.Parameters.Add(dbParam_review)


        Dim dbParam_Signed As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_Signed.ParameterName = "@Signed"
        dbParam_Signed.Value = Signed
        dbParam_Signed.DbType = System.Data.DbType.Int32
        dbCommand.Parameters.Add(dbParam_Signed)

        Dim dbParam_MOHId As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_MOHId.ParameterName = "@MOHId"
        dbParam_MOHId.Value = MOHId
        dbParam_MOHId.DbType = System.Data.DbType.Int32
        dbCommand.Parameters.Add(dbParam_MOHId)

        Dim dbParam_Inbatch As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_Inbatch.ParameterName = "@Inbatch"
        dbParam_Inbatch.Value = inbatch
        dbParam_Inbatch.DbType = System.Data.DbType.Int32
        dbCommand.Parameters.Add(dbParam_Inbatch)


        Dim rowsAffected As Integer = 0
        dbConnection.Open()
        Try
            rowsAffected = dbCommand.ExecuteNonQuery
        Finally
            dbConnection.Close()
        End Try

        Return rowsAffected
    End Function

    Function AddDoctorsInfo(ByVal trainID As Integer, ByVal appId As String, _
                            ByVal liveAbrd As Integer, ByVal abrdAdd As String, _
                            ByVal liveabrdPeriod As String, ByVal travRecently As Integer, _
                            ByVal travWhere As String, ByVal travWhen As String, _
                            ByVal medAcceptable As String, ByVal Literate As Integer, _
                            ByVal DocName As String, ByVal docAddress As String, _
                            ByVal DocTele As String) As Integer

        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(connectionString)

        Dim queryString As String = "Insert Into DoctorsInfo" & _
                                    " (TrainId,AppID,LivedAbroad,AbroadAddress,LivedAbroadPeriod,travelledRecently," & _
                                    " travelledWhere,travelledWhen,MedicallyAccepted,Literate,DoctorsName,DoctorsAddress," & _
                                    " TelephoneNo)Values(@trainID,@AppId,@liveAbrd,@abrdAdd,@liveabrdPeriod,@travRecently," & _
                                    " @travWhere,@travWhen,@medAcceptable,@literate,@DocName,@docAddress,@Doctele)"
        Dim dbCommand As System.Data.IDbCommand = New System.Data.SqlClient.SqlCommand
        dbCommand.CommandText = queryString
        dbCommand.Connection = dbConnection

        Dim dbParam_trainID As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_trainID.ParameterName = "@trainID"
        dbParam_trainID.Value = trainID
        dbParam_trainID.DbType = System.Data.DbType.Int32
        dbCommand.Parameters.Add(dbParam_trainID)

        Dim dbParam_appId As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_appId.ParameterName = "@appId"
        dbParam_appId.Value = appId
        dbParam_appId.DbType = System.Data.DbType.String
        dbCommand.Parameters.Add(dbParam_appId)

        Dim dbParam_liveAbrd As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_liveAbrd.ParameterName = "@liveAbrd"
        dbParam_liveAbrd.Value = liveAbrd
        dbParam_liveAbrd.DbType = System.Data.DbType.Int32
        dbCommand.Parameters.Add(dbParam_liveAbrd)

        Dim dbParam_abrdAdd As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_abrdAdd.ParameterName = "@abrdAdd"
        dbParam_abrdAdd.Value = abrdAdd
        dbParam_abrdAdd.DbType = System.Data.DbType.String
        dbCommand.Parameters.Add(dbParam_abrdAdd)

        Dim dbParam_liveabrdPeriod As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_liveabrdPeriod.ParameterName = "@liveabrdPeriod"
        dbParam_liveabrdPeriod.Value = liveabrdPeriod
        dbParam_liveabrdPeriod.DbType = System.Data.DbType.String
        dbCommand.Parameters.Add(dbParam_liveabrdPeriod)

        Dim dbParam_travRecently As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_travRecently.ParameterName = "@travRecently"
        dbParam_travRecently.Value = travRecently
        dbParam_travRecently.DbType = System.Data.DbType.Int32
        dbCommand.Parameters.Add(dbParam_travRecently)

        Dim dbParam_travWhere As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_travWhere.ParameterName = "@travWhere"
        dbParam_travWhere.Value = travWhere
        dbParam_travWhere.DbType = System.Data.DbType.String
        dbCommand.Parameters.Add(dbParam_travWhere)

        Dim dbParam_travWhen As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_travWhen.ParameterName = "@travWhen"
        dbParam_travWhen.Value = travWhen
        dbParam_travWhen.DbType = System.Data.DbType.String
        dbCommand.Parameters.Add(dbParam_travWhen)

        Dim dbParam_medAcceptable As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_medAcceptable.ParameterName = "@medAcceptable"
        dbParam_medAcceptable.Value = medAcceptable
        dbParam_medAcceptable.DbType = System.Data.DbType.String
        dbCommand.Parameters.Add(dbParam_medAcceptable)

        Dim dbParam_Literate As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_Literate.ParameterName = "@Literate"
        dbParam_Literate.Value = Literate
        dbParam_Literate.DbType = System.Data.DbType.Int32
        dbCommand.Parameters.Add(dbParam_Literate)

        Dim dbParam_DocName As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_DocName.ParameterName = "@DocName"
        dbParam_DocName.Value = DocName
        dbParam_DocName.DbType = System.Data.DbType.String
        dbCommand.Parameters.Add(dbParam_DocName)

        Dim dbParam_docAddress As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_docAddress.ParameterName = "@docAddress"
        dbParam_docAddress.Value = docAddress
        dbParam_docAddress.DbType = System.Data.DbType.String
        dbCommand.Parameters.Add(dbParam_docAddress)

        Dim dbParam_DocTele As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_DocTele.ParameterName = "@DocTele"
        dbParam_DocTele.Value = DocTele
        dbParam_DocTele.DbType = System.Data.DbType.String
        dbCommand.Parameters.Add(dbParam_DocTele)


        Dim rowsAffected As Integer = 0
        dbConnection.Open()
        Try
            rowsAffected = dbCommand.ExecuteNonQuery
        Finally
            dbConnection.Close()
        End Try

        Return rowsAffected
    End Function

    Function AddCardInfo(ByVal AppDate As Date, ByVal ExpDate As Date, ByVal trainId As Integer, _
                         ByVal AppId As String, ByVal rec_no As Integer, ByVal amntPaid As Double, _
                         ByVal handlerId As Integer) As Integer

        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(connectionString)

        Dim queryString As String = "Insert Into Card_Info" & _
                                    " (Iss_date,Exp_date,TrainID,AppID,RecNo,Paid,HandlerID)" & _
                                    " Values(@AppDate,@Expdate,@TrainId,@AppId,@Rec_no,@amntPaid," & _
                                    " @handlerId)"

        Dim dbCommand As System.Data.IDbCommand = New System.Data.SqlClient.SqlCommand
        dbCommand.CommandText = queryString
        dbCommand.Connection = dbConnection

        Dim dbParam_AppDate As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_AppDate.ParameterName = "@AppDate"
        dbParam_AppDate.Value = AppDate
        dbParam_AppDate.DbType = System.Data.DbType.Date
        dbCommand.Parameters.Add(dbParam_AppDate)

        Dim dbParam_ExpDate As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_ExpDate.ParameterName = "@ExpDate"
        dbParam_ExpDate.Value = ExpDate
        dbParam_ExpDate.DbType = System.Data.DbType.Date
        dbCommand.Parameters.Add(dbParam_ExpDate)

        Dim dbParam_trainId As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_trainId.ParameterName = "@trainId"
        dbParam_trainId.Value = trainId
        dbParam_trainId.DbType = System.Data.DbType.Int32
        dbCommand.Parameters.Add(dbParam_trainId)

        Dim dbParam_AppId As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_AppId.ParameterName = "@AppId"
        dbParam_AppId.Value = AppId
        dbParam_AppId.DbType = System.Data.DbType.String
        dbCommand.Parameters.Add(dbParam_AppId)

        Dim dbParam_liveabrdPeriod As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_liveabrdPeriod.ParameterName = "@rec_no"
        dbParam_liveabrdPeriod.Value = rec_no
        dbParam_liveabrdPeriod.DbType = System.Data.DbType.Int32
        dbCommand.Parameters.Add(dbParam_liveabrdPeriod)

        Dim dbParam_amntPaid As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_amntPaid.ParameterName = "@amntPaid"
        dbParam_amntPaid.Value = amntPaid
        dbParam_amntPaid.DbType = System.Data.DbType.Double
        dbCommand.Parameters.Add(dbParam_amntPaid)

        

        Dim dbParam_handlerId As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_handlerId.ParameterName = "@handlerId"
        dbParam_handlerId.Value = handlerId
        dbParam_handlerId.DbType = System.Data.DbType.Int32
        dbCommand.Parameters.Add(dbParam_handlerId)

        Dim rowsAffected As Integer = 0
        dbConnection.Open()
        Try
            rowsAffected = dbCommand.ExecuteNonQuery
        Finally
            dbConnection.Close()
        End Try

        Return rowsAffected
    End Function
    Function UpdateCardInfo(ByVal AppDate As Date, ByVal ExpDate As Date, ByVal trainId As Integer, ByVal OldTrainID As Integer, _
                        ByVal AppId As String, ByVal rec_no As Integer, ByVal amntPaid As Double, _
                        ByVal handlerId As Integer) As Integer

        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(connectionString)

        Dim queryString As String = " Update Card_Info Set" & _
                                    " Iss_date=@AppDate,Exp_date=@Expdate,TrainID=@TrainId,RecNo=@Rec_no,Paid=@amntPaid,HandlerID=@handlerId" & _
                                    " Where AppID=@AppId and TrainID=@oldTrainID"

        Dim dbCommand As System.Data.IDbCommand = New System.Data.SqlClient.SqlCommand
        dbCommand.CommandText = queryString
        dbCommand.Connection = dbConnection

        Dim dbParam_AppDate As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_AppDate.ParameterName = "@AppDate"
        dbParam_AppDate.Value = AppDate
        dbParam_AppDate.DbType = System.Data.DbType.Date
        dbCommand.Parameters.Add(dbParam_AppDate)

        Dim dbParam_ExpDate As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_ExpDate.ParameterName = "@ExpDate"
        dbParam_ExpDate.Value = ExpDate
        dbParam_ExpDate.DbType = System.Data.DbType.Date
        dbCommand.Parameters.Add(dbParam_ExpDate)

        Dim dbParam_trainId As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_trainId.ParameterName = "@trainId"
        dbParam_trainId.Value = trainId
        dbParam_trainId.DbType = System.Data.DbType.Int32
        dbCommand.Parameters.Add(dbParam_trainId)

        Dim dbParam_OldTrainID As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_OldTrainID.ParameterName = "@OldtrainId"
        dbParam_OldTrainID.Value = OldTrainID
        dbParam_OldTrainID.DbType = System.Data.DbType.Int32
        dbCommand.Parameters.Add(dbParam_OldTrainID)

        Dim dbParam_AppId As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_AppId.ParameterName = "@AppId"
        dbParam_AppId.Value = AppId
        dbParam_AppId.DbType = System.Data.DbType.String
        dbCommand.Parameters.Add(dbParam_AppId)

        Dim dbParam_liveabrdPeriod As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_liveabrdPeriod.ParameterName = "@rec_no"
        dbParam_liveabrdPeriod.Value = rec_no
        dbParam_liveabrdPeriod.DbType = System.Data.DbType.Int32
        dbCommand.Parameters.Add(dbParam_liveabrdPeriod)

        Dim dbParam_amntPaid As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_amntPaid.ParameterName = "@amntPaid"
        dbParam_amntPaid.Value = amntPaid
        dbParam_amntPaid.DbType = System.Data.DbType.Double
        dbCommand.Parameters.Add(dbParam_amntPaid)



        Dim dbParam_handlerId As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_handlerId.ParameterName = "@handlerId"
        dbParam_handlerId.Value = handlerId
        dbParam_handlerId.DbType = System.Data.DbType.Int32
        dbCommand.Parameters.Add(dbParam_handlerId)

        Dim rowsAffected As Integer = 0
        dbConnection.Open()
        Try
            rowsAffected = dbCommand.ExecuteNonQuery
        Finally
            dbConnection.Close()
        End Try

        Return rowsAffected
    End Function


    Function SearchGeneralInfo(ByVal AppID As String) As System.Data.IDataReader

        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(connectionString)

        Dim queryString As String = "SELECT AI.*, DI.* FROM ApplicantsInfo AI LEFT OUTER JOIN DoctorsInfo DI ON AI.AppID = DI.AppID WHERE AI.AppID = @AppID"

        Dim dbCommand As System.Data.IDbCommand = New System.Data.SqlClient.SqlCommand
        dbCommand.CommandText = queryString
        dbCommand.Connection = dbConnection

        Dim dbParam_AppId As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_AppId.ParameterName = "@AppId"
        dbParam_AppId.Value = AppID
        dbParam_AppId.DbType = System.Data.DbType.String
        dbCommand.Parameters.Add(dbParam_AppId)

        dbConnection.Open()
        Dim dataReader As System.Data.IDataReader = dbCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection)

        Return dataReader

    End Function
    Function getImage(ByVal AppId As String) As Byte()
        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(connectionString)
        Dim queryString As String = "select Picture from ApplicantsInfo where AppID=@AppId"
        Dim dbCommand As System.Data.IDbCommand = New System.Data.SqlClient.SqlCommand
        dbCommand.CommandText = queryString
        dbCommand.Connection = dbConnection

        Dim dbParam_AppId As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_AppId.ParameterName = "@AppId"
        dbParam_AppId.Value = AppId
        dbParam_AppId.DbType = System.Data.DbType.String
        dbCommand.Parameters.Add(dbParam_AppId)
        dbConnection.Open()

        Dim reader As System.Data.IDataReader = dbCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
        If reader.Read Then
            Dim picbit As Byte()
            picbit = reader("picture")

        End If


    End Function

    Function gethealth(ByVal AppId As String) As System.Data.IDataReader
        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(connectionString)
        Dim queryString As String = "select * from HealthCondition where AppID=@AppId"
        Dim dbCommand As System.Data.IDbCommand = New System.Data.SqlClient.SqlCommand
        dbCommand.CommandText = queryString
        dbCommand.Connection = dbConnection

        Dim dbParam_AppId As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_AppId.ParameterName = "@AppId"
        dbParam_AppId.Value = AppId
        dbParam_AppId.DbType = System.Data.DbType.String
        dbCommand.Parameters.Add(dbParam_AppId)
        dbConnection.Open()

        Dim reader As System.Data.IDataReader = dbCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
        Return reader

    End Function

    Function GetCardHistory(ByVal AppId As String) As System.Data.DataSet
        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(connectionString)
        Dim queryString As String = " select CI.Iss_date as [Application Date],CI.Exp_date as [Expiration Date]," & _
                                    " FHC.handlername as Category,FC.Facilityname as Facility, CI.TrainID From Card_Info CI,FoodHandlersCategories FHC, Facility FC,Schedules" & _
                                    " where CI.HandlerID=FHC.HandlerID and Schedules.facilityID = FC.FacId and Schedules.rid =CI.TrainID and CI.AppID=@AppId"

        Dim dbCommand As System.Data.IDbCommand = New System.Data.SqlClient.SqlCommand
        dbCommand.CommandText = queryString
        dbCommand.Connection = dbConnection

        Dim dbParam_AppId As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_AppId.ParameterName = "@AppId"
        dbParam_AppId.Value = AppId
        dbParam_AppId.DbType = System.Data.DbType.String
        dbCommand.Parameters.Add(dbParam_AppId)
        dbConnection.Open()

        Dim dataAdapter As System.Data.IDbDataAdapter = New System.Data.SqlClient.SqlDataAdapter
        dataAdapter.SelectCommand = dbCommand
        Dim dataSet As System.Data.DataSet = New System.Data.DataSet
        dataAdapter.Fill(dataSet)

        Return dataSet

    End Function
    Function GetsignedOnes(ByVal AppId As String) As System.Data.DataSet
        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(connectionString)
        Dim queryString As String = "select signed from SignOff where AppID=@AppID"
        Dim dbCommand As System.Data.IDbCommand = New System.Data.SqlClient.SqlCommand
        dbCommand.CommandText = queryString
        dbCommand.Connection = dbConnection

        Dim dbParam_AppId As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_AppId.ParameterName = "@AppId"
        dbParam_AppId.Value = AppId
        dbParam_AppId.DbType = System.Data.DbType.String
        dbCommand.Parameters.Add(dbParam_AppId)
        dbConnection.Open()

        Dim dataAdapter As System.Data.IDbDataAdapter = New System.Data.SqlClient.SqlDataAdapter
        dataAdapter.SelectCommand = dbCommand
        Dim dataSet As System.Data.DataSet = New System.Data.DataSet
        dataAdapter.Fill(dataSet)

        Return dataSet

    End Function

    Function GetReviewOnes(ByVal AppId As String) As System.Data.DataSet
        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(connectionString)
        Dim queryString As String = "select review from SignOff where AppID=@AppID"
        Dim dbCommand As System.Data.IDbCommand = New System.Data.SqlClient.SqlCommand
        dbCommand.CommandText = queryString
        dbCommand.Connection = dbConnection

        Dim dbParam_AppId As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_AppId.ParameterName = "@AppId"
        dbParam_AppId.Value = AppId
        dbParam_AppId.DbType = System.Data.DbType.String
        dbCommand.Parameters.Add(dbParam_AppId)
        dbConnection.Open()

        Dim dataAdapter As System.Data.IDbDataAdapter = New System.Data.SqlClient.SqlDataAdapter
        dataAdapter.SelectCommand = dbCommand
        Dim dataSet As System.Data.DataSet = New System.Data.DataSet
        dataAdapter.Fill(dataSet)

        Return dataSet

    End Function
    Function GetScoreCard(ByVal AppId As String, ByVal trainId As Integer) As System.Data.IDataReader
        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(connectionString)
        Dim queryString As String = "select CI.*,SR.* from Card_Info CI,Score_Reg SR where CI.TrainID=SR.TrainID and SR.AppId=@AppID and SR.TrainID=@trainID"

        Dim dbCommand As System.Data.IDbCommand = New System.Data.SqlClient.SqlCommand
        dbCommand.CommandText = queryString
        dbCommand.Connection = dbConnection

        Dim dbParam_AppId As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_AppId.ParameterName = "@AppId"
        dbParam_AppId.Value = AppId
        dbParam_AppId.DbType = System.Data.DbType.String
        dbCommand.Parameters.Add(dbParam_AppId)

        Dim dbParam_trainId As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_trainId.ParameterName = "@trainId"
        dbParam_trainId.Value = trainId
        dbParam_trainId.DbType = System.Data.DbType.Int32
        dbCommand.Parameters.Add(dbParam_trainId)

        dbConnection.Open()

        Dim reader As System.Data.IDataReader = dbCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
        Return reader


    End Function
    Function GetScoreDS(ByVal AppId As String, ByVal trainId As Integer) As System.Data.DataSet
        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(connectionString)
        Dim queryString As String = "select CI.*,SR.* from Card_Info CI,Score_Reg SR where CI.TrainID=SR.TrainID and SR.AppId=@AppID and SR.TrainID=@trainID"

        Dim dbCommand As System.Data.IDbCommand = New System.Data.SqlClient.SqlCommand
        dbCommand.CommandText = queryString
        dbCommand.Connection = dbConnection

        Dim dbParam_AppId As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_AppId.ParameterName = "@AppId"
        dbParam_AppId.Value = AppId
        dbParam_AppId.DbType = System.Data.DbType.String
        dbCommand.Parameters.Add(dbParam_AppId)

        Dim dbParam_trainId As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_trainId.ParameterName = "@trainId"
        dbParam_trainId.Value = trainId
        dbParam_trainId.DbType = System.Data.DbType.Int32
        dbCommand.Parameters.Add(dbParam_trainId)

        dbConnection.Open()

        Dim dataAdapter As System.Data.IDbDataAdapter = New System.Data.SqlClient.SqlDataAdapter
        dataAdapter.SelectCommand = dbCommand
        Dim dataSet As System.Data.DataSet = New System.Data.DataSet
        dataAdapter.Fill(dataSet)

        Return dataSet

    End Function



    Function GetInfoForSignOff() As System.Data.DataSet
        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(connectionString)
        Dim queryString As String = "select SD.schDate as [Date of Training], SD.SchTime as [Time of training],Fl.Facilityname as [Facility Name],FHC.HandlerName as [Category],count(SO.AppID) as [Total Applicants],SD.rid as [ID] from Schedules SD," & _
                                    " Facility FL,FoodHandlersCategories FHC,SignOff SO where FL.FacId=SD.facilityID and FHC.HandlerID=SD.handlerID and" & _
                                    " SD.rid=SO.TrainID and SO.signed='0' group by SD.SchDate,SD.SchTime,FL.Facilityname, FHC.Handlername,SD.RID"


        Dim dbCommand As System.Data.IDbCommand = New System.Data.SqlClient.SqlCommand
        dbCommand.CommandText = queryString
        dbCommand.Connection = dbConnection


        dbConnection.Open()

        Dim dataAdapter As System.Data.IDbDataAdapter = New System.Data.SqlClient.SqlDataAdapter
        dataAdapter.SelectCommand = dbCommand
        Dim dataSet As System.Data.DataSet = New System.Data.DataSet
        dataAdapter.Fill(dataSet)

        Return dataSet

    End Function

    Function GetSignOffIndividual(ByVal trainID As Integer) As System.Data.DataSet
        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(connectionString)
        Dim queryString As String = "select AI.*,DI.*,SO.Signed from ApplicantsInfo AI,Schedules SD,SignOff SO, DoctorsInfo DI where " & _
                                    " AI.AppID=SO.AppID and SO.TrainID=SD.RID and DI.AppID=SO.AppID and DI.TrainID=SO.TrainID" & _
                                    " and SD.Rid=@trainID and SO.signed='0' and SO.Inbatch='0'"

        Dim dbCommand As System.Data.IDbCommand = New System.Data.SqlClient.SqlCommand
        dbCommand.CommandText = queryString
        dbCommand.Connection = dbConnection

        Dim dbParam_trainId As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_trainId.ParameterName = "@trainId"
        dbParam_trainId.Value = trainID
        dbParam_trainId.DbType = System.Data.DbType.Int32
        dbCommand.Parameters.Add(dbParam_trainId)

        dbConnection.Open()

        Dim dataAdapter As System.Data.IDbDataAdapter = New System.Data.SqlClient.SqlDataAdapter
        dataAdapter.SelectCommand = dbCommand
        Dim dataSet As System.Data.DataSet = New System.Data.DataSet
        dataAdapter.Fill(dataSet)

        Return dataSet

    End Function

    Function MohSignOff(ByVal appId As String, ByVal trainId As Integer, mohid As Integer) As Integer
        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(connectionString)
        Dim queryString As String = "Update SignOff Set Signed='1', MOH_ID=@mohid where AppID=@appId and TrainID=@trainId"
        Dim dbCommand As System.Data.IDbCommand = New System.Data.SqlClient.SqlCommand
        dbCommand.CommandText = queryString
        dbCommand.Connection = dbConnection

        Dim dbParam_appId As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_appId.ParameterName = "@appId"
        dbParam_appId.Value = appId
        dbParam_appId.DbType = System.Data.DbType.String
        dbCommand.Parameters.Add(dbParam_appId)

        Dim dbParam_trainId As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_trainId.ParameterName = "@trainId"
        dbParam_trainId.Value = trainId
        dbParam_trainId.DbType = System.Data.DbType.Int32
        dbCommand.Parameters.Add(dbParam_trainId)

        Dim dbParam_mohid As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_mohid.ParameterName = "@mohid"
        dbParam_mohid.Value = mohid
        dbParam_mohid.DbType = System.Data.DbType.Int32
        dbCommand.Parameters.Add(dbParam_mohid)

        Dim rowsAffected As Integer = 0
        dbConnection.Open()
        Try
            rowsAffected = dbCommand.ExecuteNonQuery
        Finally
            dbConnection.Close()
        End Try

        Return rowsAffected
    End Function

    Function ReviewSignOff(ByVal appId As String, ByVal trainId As Integer) As Integer


        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(connectionString)
        Dim queryString As String = "Update SignOff Set review='1' where AppID=@appId and TrainID=@trainId"
        Dim dbCommand As System.Data.IDbCommand = New System.Data.SqlClient.SqlCommand
        dbCommand.CommandText = queryString
        dbCommand.Connection = dbConnection

        Dim dbParam_appId As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_appId.ParameterName = "@appId"
        dbParam_appId.Value = appId
        dbParam_appId.DbType = System.Data.DbType.String
        dbCommand.Parameters.Add(dbParam_appId)

        Dim dbParam_trainId As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_trainId.ParameterName = "@trainId"
        dbParam_trainId.Value = trainId
        dbParam_trainId.DbType = System.Data.DbType.Int32
        dbCommand.Parameters.Add(dbParam_trainId)

        Dim rowsAffected As Integer = 0
        dbConnection.Open()
        Try
            rowsAffected = dbCommand.ExecuteNonQuery
        Finally
            dbConnection.Close()
        End Try

        Return rowsAffected

    End Function
    Function GetTrainingType(ByVal trainId As Integer) As String


        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(connectionString)
        Dim queryString As String = "Select ScheduleType from Schedules Where RID=@trainId"
        Dim dbCommand As System.Data.IDbCommand = New System.Data.SqlClient.SqlCommand
        dbCommand.CommandText = queryString
        dbCommand.Connection = dbConnection


        Dim dbParam_trainId As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_trainId.ParameterName = "@trainId"
        dbParam_trainId.Value = trainId
        dbParam_trainId.DbType = System.Data.DbType.Int32
        dbCommand.Parameters.Add(dbParam_trainId)

        dbConnection.Open()

        Dim reader As System.Data.IDataReader = dbCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
        If reader.Read Then
            Return reader("ScheduleType")
        End If


    End Function
    Function GetTests() As System.Data.DataSet


        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(connectionString)
        Dim queryString As String = "Select Testname from OnsiteTest"
        Dim dbCommand As System.Data.IDbCommand = New System.Data.SqlClient.SqlCommand
        dbCommand.CommandText = queryString
        dbCommand.Connection = dbConnection

        dbConnection.Open()

        Dim dataAdapter As System.Data.IDbDataAdapter = New System.Data.SqlClient.SqlDataAdapter
        dataAdapter.SelectCommand = dbCommand
        Dim dataSet As System.Data.DataSet = New System.Data.DataSet
        dataAdapter.Fill(dataSet)

        Return dataSet


    End Function

    Function GetFees() As System.Data.IDataReader


        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(connectionString)
        Dim queryString As String = "Select Fees from FeesTable"
        Dim dbCommand As System.Data.IDbCommand = New System.Data.SqlClient.SqlCommand
        dbCommand.CommandText = queryString
        dbCommand.Connection = dbConnection

        dbConnection.Open()


        Dim reader As System.Data.IDataReader = dbCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
        If reader.Read Then
            Return reader
        End If

    End Function

   Function SearchApplByName(name As String) As System.Data.DataSet
        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(connectionString)
        Dim queryString As String = "Select AppID as 'Applicant ID', fname as 'First Name', lname as 'Last Name', Address2 as 'Address', Parish FROM ApplicantsInfo WHERE fname like '%'+ @name +'%' OR lname like '%'+ @name +'%'"
        Dim dbCommand As System.Data.IDbCommand = New System.Data.SqlClient.SqlCommand
        dbCommand.CommandText = queryString
        dbCommand.Connection = dbConnection
        Dim dbParam_name As System.Data.IDataParameter = New SqlParameter
        dbParam_name.ParameterName = "@name"
        dbParam_name.Value = name
        dbParam_name.DbType = System.Data.DbType.String
        dbCommand.Parameters.Add(dbParam_name)
        dbConnection.Open()
        Dim dataAdapter As System.Data.IDbDataAdapter = New System.Data.SqlClient.SqlDataAdapter
        dataAdapter.SelectCommand = dbCommand
        Dim dataSet As System.Data.DataSet = New System.Data.DataSet
        dataAdapter.Fill(dataSet)
        Return dataSet
    End Function

    
    Function SelectAllApplicants() As System.Data.DataSet


        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(connectionString)
        Dim queryString As String = "Select AppID,fname,lname,Address2,Parish from ApplicantsInfo"
        Dim dbCommand As System.Data.IDbCommand = New System.Data.SqlClient.SqlCommand
        dbCommand.CommandText = queryString
        dbCommand.Connection = dbConnection


        dbConnection.Open()

        Dim dataAdapter As System.Data.IDbDataAdapter = New System.Data.SqlClient.SqlDataAdapter
        dataAdapter.SelectCommand = dbCommand
        Dim dataSet As System.Data.DataSet = New System.Data.DataSet
        dataAdapter.Fill(dataSet)

        Return dataSet


    End Function

    Function AppExists(ByVal AppId As String) As Boolean

        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(connectionString)
        Dim queryString As String = "Select * from ApplicantsInfo where AppID=@AppId"
        Dim dbCommand As System.Data.IDbCommand = New System.Data.SqlClient.SqlCommand
        dbCommand.CommandText = queryString
        dbCommand.Connection = dbConnection

        Dim dbParam_appId As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_appId.ParameterName = "@appId"
        dbParam_appId.Value = AppId
        dbParam_appId.DbType = System.Data.DbType.String
        dbCommand.Parameters.Add(dbParam_appId)


        dbConnection.Open()

       
        Dim reader As System.Data.IDataReader = dbCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
        If reader.Read Then
            Return True
        Else
            Return False
        End If


    End Function
    Function UpdateAppInfo2(ByVal AppID As String, ByVal Apdate As Date, ByVal fname As String, ByVal mname As String, ByVal lname As String, _
                           ByVal dob As Date, ByVal gender As String, ByVal tel As String, ByVal add1 As String, _
                           ByVal add2 As String, ByVal parish As String, ByVal empname As String, ByVal empAdd As String, _
                           ByVal empparish As String, ByVal picture As Byte()) As Integer


        Dim connection As SqlConnection = New SqlConnection(connectionString)
        connection.Open()
        Try

            Dim command As SqlCommand = _
            New SqlCommand("[UpdateApplicants]", connection)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@AppID", AppID)
            command.Parameters.AddWithValue("@Apdate", Apdate)
            command.Parameters.AddWithValue("@fname", fname)
            command.Parameters.AddWithValue("@mname", mname)
            command.Parameters.AddWithValue("@lname", lname)
            command.Parameters.AddWithValue("@dob", dob)
            command.Parameters.AddWithValue("@gender", gender)
            command.Parameters.AddWithValue("@tel", tel)
            command.Parameters.AddWithValue("@add1", add1)
            command.Parameters.AddWithValue("@add2", add2)
            command.Parameters.AddWithValue("@parish", parish)
            command.Parameters.AddWithValue("@empname", empname)
            command.Parameters.AddWithValue("@empAdd", empAdd)
            command.Parameters.AddWithValue("@empparish", empparish)
            command.Parameters.AddWithValue("@picture", picture)
            If command.ExecuteNonQuery() > 0 Then
                MsgBox("Successfully Update", MsgBoxStyle.Information + vbOKOnly)
            End If

        Catch ex As Exception

        End Try

        

    End Function

    Function UpdateAppInfo(ByVal AppID As String, ByVal Apdate As Date, ByVal fname As String, ByVal mname As String, ByVal lname As String, _
                            ByVal dob As Date, ByVal gender As String, ByVal tel As String, ByVal add1 As String, _
                            ByVal add2 As String, ByVal parish As String, ByVal empname As String, ByVal empAdd As String, _
                            ByVal empparish As String, ByVal picture As Byte()) As Integer

        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(connectionString)
        Dim queryString As String = "Update ApplicantsInfo Set AppDate=@Apdate,fname=@fname,mname=@mname,lname=@lname," & _
                                    " Dob=@dob,Gender=@gender,Telephone=@tel,Address1=@add1,Address2=@add2,Parish=@parish," & _
                                    " Emp_name=@empname,Emp_address=@empAdd,Emp_parish=@empparish,Picture=@picture where" & _
                                    " AppId=@AppID"
        Dim dbCommand As System.Data.IDbCommand = New System.Data.SqlClient.SqlCommand
        dbCommand.CommandText = queryString
        dbCommand.Connection = dbConnection


        Dim dbParam_appId As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_appId.ParameterName = "@appId"
        dbParam_appId.Value = AppID
        dbParam_appId.DbType = System.Data.DbType.String
        dbCommand.Parameters.Add(dbParam_appId)

        Dim dbParam_Apdate As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_Apdate.ParameterName = "@Apdate"
        dbParam_Apdate.Value = Apdate
        dbParam_Apdate.DbType = DbType.Date
        dbCommand.Parameters.Add(dbParam_Apdate)

        Dim dbParam_fname As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_fname.ParameterName = "@fname"
        dbParam_fname.Value = fname
        dbParam_fname.DbType = DbType.String
        dbCommand.Parameters.Add(dbParam_fname)

        Dim dbParam_mname As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_mname.ParameterName = "@mname"
        dbParam_mname.Value = mname
        dbParam_mname.DbType = DbType.String
        dbCommand.Parameters.Add(dbParam_mname)

        Dim dbParam_lname As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_lname.ParameterName = "@lname"
        dbParam_lname.Value = lname
        dbParam_lname.DbType = DbType.String
        dbCommand.Parameters.Add(dbParam_lname)

        Dim dbParam_dob As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_dob.ParameterName = "@dob"
        dbParam_dob.Value = dob
        dbParam_dob.DbType = DbType.Date
        dbCommand.Parameters.Add(dbParam_dob)

        Dim dbParam_gender As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_gender.ParameterName = "@gender"
        dbParam_gender.Value = gender
        dbParam_gender.DbType = DbType.String
        dbCommand.Parameters.Add(dbParam_gender)

        Dim dbParam_tel As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_tel.ParameterName = "@tel"
        dbParam_tel.Value = tel
        dbParam_tel.DbType = DbType.String
        dbCommand.Parameters.Add(dbParam_tel)

        Dim dbParam_add1 As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_add1.ParameterName = "@add1"
        dbParam_add1.Value = add1
        dbParam_add1.DbType = DbType.String
        dbCommand.Parameters.Add(dbParam_add1)

        Dim dbParam_add2 As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_add2.ParameterName = "@add2"
        dbParam_add2.Value = add2
        dbParam_add2.DbType = DbType.String
        dbCommand.Parameters.Add(dbParam_add2)

        Dim dbParam_parish As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_parish.ParameterName = "@parish"
        dbParam_parish.Value = parish
        dbParam_parish.DbType = DbType.String
        dbCommand.Parameters.Add(dbParam_parish)

        Dim dbParam_empname As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_empname.ParameterName = "@empname"
        dbParam_empname.Value = empname
        dbParam_empname.DbType = DbType.String
        dbCommand.Parameters.Add(dbParam_empname)

        Dim dbParam_empadd As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_empadd.ParameterName = "@empadd"
        dbParam_empadd.Value = empAdd
        dbParam_empadd.DbType = DbType.String
        dbCommand.Parameters.Add(dbParam_empadd)


        Dim dbParam_empParish As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_empParish.ParameterName = "@empParish"
        dbParam_empParish.Value = empparish
        dbParam_empParish.DbType = DbType.String
        dbCommand.Parameters.Add(dbParam_empParish)

        Dim dbParam_picture As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_picture.ParameterName = "@picture"
        dbParam_picture.Value = picture
        dbParam_picture.DbType = DbType.Binary
        dbCommand.Parameters.Add(dbParam_picture)


        Dim rowsAffected As Integer = 0
        dbConnection.Open()
        Try
            rowsAffected = dbCommand.ExecuteNonQuery
        Finally
            dbConnection.Close()
        End Try

        Return rowsAffected



    End Function
    Function UpateDoctorInfo(ByVal trainID As Integer, ByVal appId As String, _
                            ByVal liveAbrd As Integer, ByVal abrdAdd As String, _
                            ByVal liveabrdPeriod As String, ByVal travRecently As Integer, _
                            ByVal travWhere As String, ByVal travWhen As String, _
                            ByVal medAcceptable As String, ByVal Literate As Integer, _
                            ByVal DocName As String, ByVal docAddress As String, _
                            ByVal DocTele As String) As Integer

        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(connectionString)

        Dim queryString As String = "Update DoctorsInfo" & _
                                    " Set TrainID=@trainID,LivedAbroad=@liveAbrd,AbroadAddress=@abrdAdd," & _
                                    " LivedAbroadPeriod=@liveabrdPeriod,travelledRecently=@travRecently," & _
                                    " travelledWhere=@travWhere,TravelledWhen=@travWhen,MedicallyAccepted=@medAcceptable," & _
                                    " Literate=@literate,DoctorsName=@DocName,DoctorsAddress=@docAddress,TelephoneNo=@DocTele"
        Dim dbCommand As System.Data.IDbCommand = New System.Data.SqlClient.SqlCommand
        dbCommand.CommandText = queryString
        dbCommand.Connection = dbConnection

        Dim dbParam_trainID As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_trainID.ParameterName = "@trainID"
        dbParam_trainID.Value = TrainID
        dbParam_trainID.DbType = System.Data.DbType.Int32
        dbCommand.Parameters.Add(dbParam_trainID)

        Dim dbParam_appId As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_appId.ParameterName = "@appId"
        dbParam_appId.Value = appId
        dbParam_appId.DbType = System.Data.DbType.String
        dbCommand.Parameters.Add(dbParam_appId)

        Dim dbParam_liveAbrd As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_liveAbrd.ParameterName = "@liveAbrd"
        dbParam_liveAbrd.Value = liveAbrd
        dbParam_liveAbrd.DbType = System.Data.DbType.Int32
        dbCommand.Parameters.Add(dbParam_liveAbrd)

        Dim dbParam_abrdAdd As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_abrdAdd.ParameterName = "@abrdAdd"
        dbParam_abrdAdd.Value = abrdAdd
        dbParam_abrdAdd.DbType = System.Data.DbType.String
        dbCommand.Parameters.Add(dbParam_abrdAdd)

        Dim dbParam_liveabrdPeriod As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_liveabrdPeriod.ParameterName = "@liveabrdPeriod"
        dbParam_liveabrdPeriod.Value = liveabrdPeriod
        dbParam_liveabrdPeriod.DbType = System.Data.DbType.String
        dbCommand.Parameters.Add(dbParam_liveabrdPeriod)

        Dim dbParam_travRecently As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_travRecently.ParameterName = "@travRecently"
        dbParam_travRecently.Value = travRecently
        dbParam_travRecently.DbType = System.Data.DbType.Int32
        dbCommand.Parameters.Add(dbParam_travRecently)

        Dim dbParam_travWhere As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_travWhere.ParameterName = "@travWhere"
        dbParam_travWhere.Value = travWhere
        dbParam_travWhere.DbType = System.Data.DbType.String
        dbCommand.Parameters.Add(dbParam_travWhere)

        Dim dbParam_travWhen As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_travWhen.ParameterName = "@travWhen"
        dbParam_travWhen.Value = travWhen
        dbParam_travWhen.DbType = System.Data.DbType.String
        dbCommand.Parameters.Add(dbParam_travWhen)

        Dim dbParam_medAcceptable As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_medAcceptable.ParameterName = "@medAcceptable"
        dbParam_medAcceptable.Value = medAcceptable
        dbParam_medAcceptable.DbType = System.Data.DbType.String
        dbCommand.Parameters.Add(dbParam_medAcceptable)

        Dim dbParam_Literate As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_Literate.ParameterName = "@Literate"
        dbParam_Literate.Value = Literate
        dbParam_Literate.DbType = System.Data.DbType.Int32
        dbCommand.Parameters.Add(dbParam_Literate)

        Dim dbParam_DocName As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_DocName.ParameterName = "@DocName"
        dbParam_DocName.Value = DocName
        dbParam_DocName.DbType = System.Data.DbType.String
        dbCommand.Parameters.Add(dbParam_DocName)

        Dim dbParam_docAddress As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_docAddress.ParameterName = "@docAddress"
        dbParam_docAddress.Value = docAddress
        dbParam_docAddress.DbType = System.Data.DbType.String
        dbCommand.Parameters.Add(dbParam_docAddress)

        Dim dbParam_DocTele As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_DocTele.ParameterName = "@DocTele"
        dbParam_DocTele.Value = DocTele
        dbParam_DocTele.DbType = System.Data.DbType.String
        dbCommand.Parameters.Add(dbParam_DocTele)


        Dim rowsAffected As Integer = 0
        dbConnection.Open()
        Try
            rowsAffected = dbCommand.ExecuteNonQuery
        Finally
            dbConnection.Close()
        End Try

        Return rowsAffected

    End Function

    Function UpdateHealth(ByVal trainID As Integer, ByVal appId As String, ByVal condition As String) As Integer

        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(connectionString)

        Dim queryString As String = "Update HealthCondition" & _
                                    " Set TrainID=@trainID,Condition=@condition where AppID=@appId"
        Dim dbCommand As System.Data.IDbCommand = New System.Data.SqlClient.SqlCommand
        dbCommand.CommandText = queryString
        dbCommand.Connection = dbConnection

        Dim dbParam_trainID As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_trainID.ParameterName = "@trainID"
        dbParam_trainID.Value = TrainID
        dbParam_trainID.DbType = System.Data.DbType.Int32
        dbCommand.Parameters.Add(dbParam_trainID)

        Dim dbParam_appId As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_appId.ParameterName = "@appId"
        dbParam_appId.Value = appId
        dbParam_appId.DbType = System.Data.DbType.String
        dbCommand.Parameters.Add(dbParam_appId)

        Dim dbParam_condition As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_condition.ParameterName = "@condition"
        dbParam_condition.Value = condition
        dbParam_condition.DbType = System.Data.DbType.String
        dbCommand.Parameters.Add(dbParam_condition)


        Dim rowsAffected As Integer = 0
        dbConnection.Open()
        Try
            rowsAffected = dbCommand.ExecuteNonQuery
        Finally
            dbConnection.Close()
        End Try

        Return rowsAffected
    End Function

    Function GetCategoryID(ByVal catname As String) As Integer

        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(connectionString)

        Dim queryString As String = "select handlerID from FoodHandlersCategories where HandlerName=@catname"
        Dim dbCommand As System.Data.IDbCommand = New System.Data.SqlClient.SqlCommand
        dbCommand.CommandText = queryString
        dbCommand.Connection = dbConnection

        Dim dbParam_catname As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_catname.ParameterName = "@catname"
        dbParam_catname.Value = catname
        dbParam_catname.DbType = System.Data.DbType.String
        dbCommand.Parameters.Add(dbParam_catname)


        dbConnection.Open()


        Dim reader As System.Data.IDataReader = dbCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
        If reader.Read Then
            Return reader("HandlerID")
        End If

    End Function

    Function AddAudit(ByVal appID As String, ByVal trainId As Integer, ByVal dateEntered As Date, ByVal timeEntered As String, ByVal userId As Integer, _
                      ByVal newRen As String) As Integer

        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(connectionString)

        Dim queryString As String = "Insert Into AuditTable (AppID,TrainID,DateEntered,TimeEntered,UserID,New_Renew)" & _
                                    " Values(@appID,@trainId,@dateEntered,@timeEntered,@userId,@newRen)"
        Dim dbCommand As System.Data.IDbCommand = New System.Data.SqlClient.SqlCommand
        dbCommand.CommandText = queryString
        dbCommand.Connection = dbConnection

        Dim dbParam_appID As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_appID.ParameterName = "@appID"
        dbParam_appID.Value = appID
        dbParam_appID.DbType = System.Data.DbType.String
        dbCommand.Parameters.Add(dbParam_appID)

        Dim dbParam_TrainID As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_TrainID.ParameterName = "@TrainID"
        dbParam_TrainID.Value = trainId
        dbParam_TrainID.DbType = System.Data.DbType.String
        dbCommand.Parameters.Add(dbParam_TrainID)

        Dim dbParam_dateEntered As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_dateEntered.ParameterName = "@dateEntered"
        dbParam_dateEntered.Value = dateEntered
        dbParam_dateEntered.DbType = System.Data.DbType.Date
        dbCommand.Parameters.Add(dbParam_dateEntered)

        Dim dbParam_timeEntered As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_timeEntered.ParameterName = "@timeEntered"
        dbParam_timeEntered.Value = timeEntered
        dbParam_timeEntered.DbType = System.Data.DbType.String
        dbCommand.Parameters.Add(dbParam_timeEntered)

        Dim dbParam_userId As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_userId.ParameterName = "@userId"
        dbParam_userId.Value = userId
        dbParam_userId.DbType = System.Data.DbType.Int32
        dbCommand.Parameters.Add(dbParam_userId)


        Dim dbParam_newRen As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_newRen.ParameterName = "@newRen"
        dbParam_newRen.Value = newRen
        dbParam_newRen.DbType = System.Data.DbType.String
        dbCommand.Parameters.Add(dbParam_newRen)


        Dim rowsAffected As Integer = 0
        dbConnection.Open()
        Try
            rowsAffected = dbCommand.ExecuteNonQuery
        Finally
            dbConnection.Close()
        End Try

        Return rowsAffected
    End Function


    Function SearchSchedules(ByVal facID As Integer, ByVal month As Integer, ByVal year As Integer) As System.Data.DataSet


        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(connectionString)
        Dim queryString As String = "select SD.schDate as [Training Date],SD.SchTime as [Training Time],FC.facilityName as [Facility Name],FHC.Handlername as Category,SD.RID from" & _
                                    " Schedules SD,Facility FC, FoodHandlersCategories FHC where DATEPART(m,SchDate)=@month" & _
                                    " and DATEPART(YYYY,SchDate)=@year and SD.facilityID=FC.FacId and SD.facilityID=@facID" & _
                                    " and SD.handlerID=FHC.HandlerID"
        Dim dbCommand As System.Data.IDbCommand = New System.Data.SqlClient.SqlCommand
        dbCommand.CommandText = queryString
        dbCommand.Connection = dbConnection


        Dim dbParam_facID As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_facID.ParameterName = "@facID"
        dbParam_facID.Value = facID
        dbParam_facID.DbType = System.Data.DbType.Int32
        dbCommand.Parameters.Add(dbParam_facID)

        Dim dbParam_month As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_month.ParameterName = "@month"
        dbParam_month.Value = month
        dbParam_month.DbType = System.Data.DbType.Int32
        dbCommand.Parameters.Add(dbParam_month)

        Dim dbParam_year As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_year.ParameterName = "@year"
        dbParam_year.Value = year
        dbParam_year.DbType = System.Data.DbType.Int32
        dbCommand.Parameters.Add(dbParam_year)


        dbConnection.Open()

        Dim dataAdapter As System.Data.IDbDataAdapter = New System.Data.SqlClient.SqlDataAdapter
        dataAdapter.SelectCommand = dbCommand
        Dim dataSet As System.Data.DataSet = New System.Data.DataSet
        dataAdapter.Fill(dataSet)

        Return dataSet


    End Function

    Function SearchDataEntry(ByVal trainID As Integer) As System.Data.DataSet


        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(connectionString)
        Dim queryString As String = "select AI.fname as[First name],AI.lname as [last name],AT.DateEntered,US.username,case when SO.review='1'then CAST('Yes' AS NCHAR)" & _
                                    " Else cast('No' as nchar) end as [Review],case when SO.signed='1' then CAST('Yes' As NCHAR)" & _
                                    " else CAST('No' as NCHAR)end as [Sign Off] from ApplicantsInfo AI,Users US," & _
                                    " AuditTable AT,SignOff SO where AI.AppID=AT.AppID and AT.userID=Us.UserID and SO.AppID= AI.AppID" & _
                                    " and SO.TrainID = AT.TrainId and AT.trainId=@trainId"

        Dim dbCommand As System.Data.IDbCommand = New System.Data.SqlClient.SqlCommand
        dbCommand.CommandText = queryString
        dbCommand.Connection = dbConnection



        Dim dbParam_trainID As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_trainID.ParameterName = "@TrainId"
        dbParam_trainID.Value = trainID
        dbParam_trainID.DbType = System.Data.DbType.Int32
        dbCommand.Parameters.Add(dbParam_trainID)


        dbConnection.Open()

        Dim dataAdapter As System.Data.IDbDataAdapter = New System.Data.SqlClient.SqlDataAdapter
        dataAdapter.SelectCommand = dbCommand
        Dim dataSet As System.Data.DataSet = New System.Data.DataSet
        dataAdapter.Fill(dataSet)

        Return dataSet


    End Function

    Function GetAllSchedulesForBatch() As System.Data.DataSet
        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(connectionString)
        Dim queryString As String = "select distinct Schedules.SchDate as Date,Schedules.SchTime as Time,FoodHandlersCategories.Handlername as Category,Facility.Facilityname as Facility," & _
                                    " Schedules.RID as ID from Schedules,FoodHandlersCategories,Facility,SignOff where Schedules.handlerId=FoodHandlersCategories.HandlerID" & _
                                    " and Schedules.facilityID=Facility.FacId and SignOff.TrainID=Schedules.Rid and SignOff.InBatch='0' and SignOff.signed='1'"


        Dim dbCommand As System.Data.IDbCommand = New System.Data.SqlClient.SqlCommand
        dbCommand.CommandText = queryString
        dbCommand.Connection = dbConnection


        dbConnection.Open()

        Dim dataAdapter As System.Data.IDbDataAdapter = New System.Data.SqlClient.SqlDataAdapter
        dataAdapter.SelectCommand = dbCommand
        Dim dataSet As System.Data.DataSet = New System.Data.DataSet
        dataAdapter.Fill(dataSet)

        Return dataSet
    End Function

    Function GetForPrints(ByVal TrainID As Integer) As System.Data.DataSet
        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(connectionString)
        Dim queryString As String = "select AI.AppId,AI.Fname,AI.Lname,CI.Iss_date,CI.Exp_date,US.mohSig,FHC.HandlerName" & _
                                    " from ApplicantsInfo AI,Card_Info CI, Users US, FoodHandlersCategories FHC,SignOff where" & _
                                    " AI.AppID = CI.AppID And CI.TrainID = SignOff.TrainID And SignOff.MOH_ID = US.UserID And CI.HandlerID = FHC.HandlerID" & _
                                    " and CI.trainID =@TrainID and SignOff.signed='1' and SignOff.InBatch='0'"

        Dim dbCommand As System.Data.IDbCommand = New System.Data.SqlClient.SqlCommand
        dbCommand.CommandText = queryString
        dbCommand.Connection = dbConnection

        Dim dbParam_trainID As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_trainID.ParameterName = "@TrainId"
        dbParam_trainID.Value = TrainID
        dbParam_trainID.DbType = System.Data.DbType.Int32
        dbCommand.Parameters.Add(dbParam_trainID)


        dbConnection.Open()

        Dim dataAdapter As System.Data.IDbDataAdapter = New System.Data.SqlClient.SqlDataAdapter
        dataAdapter.SelectCommand = dbCommand
        Dim dataSet As System.Data.DataSet = New System.Data.DataSet
        dataAdapter.Fill(dataSet)

        Return dataSet
    End Function

    Function AddToIdWorks(ByVal BatchNo As String, ByVal PermitNo As String, _
                          ByVal IsDate As Date, ByVal ExpDate As Date, ByVal Sig As String, _
                          ByVal picpath As String, ByVal fname As String, _
                          ByVal lname As String, ByVal cat As String) As Integer

        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(connectionString)

        Dim queryString As String = "Insert Into IDWorksTable (BatchNum,PermitNumber,IssuedDate,ExpiredDate,Signature,Picture," & _
                                    " Firstname,lastname,Category)Values (@batchno,@permitNo,@IsDate,@ExpDate,@Sig,@picPath,@fname,@lname,@cat)"
        Dim dbCommand As System.Data.IDbCommand = New System.Data.SqlClient.SqlCommand
        dbCommand.CommandText = queryString
        dbCommand.Connection = dbConnection

        Dim dbParam_BatchNo As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_BatchNo.ParameterName = "@BatchNo"
        dbParam_BatchNo.Value = BatchNo
        dbParam_BatchNo.DbType = System.Data.DbType.String
        dbCommand.Parameters.Add(dbParam_BatchNo)

        Dim dbParam_PermitNo As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_PermitNo.ParameterName = "@PermitNo"
        dbParam_PermitNo.Value = PermitNo
        dbParam_PermitNo.DbType = System.Data.DbType.String
        dbCommand.Parameters.Add(dbParam_PermitNo)

        Dim dbParam_IsDate As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_IsDate.ParameterName = "@IsDate"
        dbParam_IsDate.Value = IsDate
        dbParam_IsDate.DbType = System.Data.DbType.Date
        dbCommand.Parameters.Add(dbParam_IsDate)

        Dim dbParam_ExpDate As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_ExpDate.ParameterName = "@ExpDate"
        dbParam_ExpDate.Value = ExpDate
        dbParam_ExpDate.DbType = System.Data.DbType.Date
        dbCommand.Parameters.Add(dbParam_ExpDate)

        Dim dbParam_Sig As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_Sig.ParameterName = "@Sig"
        dbParam_Sig.Value = Sig
        dbParam_Sig.DbType = System.Data.DbType.String
        dbCommand.Parameters.Add(dbParam_Sig)


        Dim dbParam_picpath As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_picpath.ParameterName = "@picpath"
        dbParam_picpath.Value = picpath
        dbParam_picpath.DbType = System.Data.DbType.String
        dbCommand.Parameters.Add(dbParam_picpath)

        Dim dbParam_fname As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_fname.ParameterName = "@fname"
        dbParam_fname.Value = fname
        dbParam_fname.DbType = System.Data.DbType.String
        dbCommand.Parameters.Add(dbParam_fname)

        Dim dbParam_lname As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_lname.ParameterName = "@lname"
        dbParam_lname.Value = lname
        dbParam_lname.DbType = System.Data.DbType.String
        dbCommand.Parameters.Add(dbParam_lname)

        Dim dbParam_cat As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_cat.ParameterName = "@cat"
        dbParam_cat.Value = cat
        dbParam_cat.DbType = System.Data.DbType.String
        dbCommand.Parameters.Add(dbParam_cat)


        Dim rowsAffected As Integer = 0
        dbConnection.Open()
        Try
            rowsAffected = dbCommand.ExecuteNonQuery
        Finally
            dbConnection.Close()
        End Try

        Return rowsAffected
    End Function

    Function UpdateIdWorks(ByVal BatchNo As String, ByVal PermitNo As String, _
                          ByVal IsDate As Date, ByVal ExpDate As Date, ByVal Sig As String, _
                          ByVal picpath As String, ByVal fname As String, _
                          ByVal lname As String, ByVal cat As String) As Integer

        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(connectionString)

        Dim queryString As String = "Update IDWorksTable Set BatchNum=@batchno,PermitNumber=@permitNo,IssuedDate=@IsDate,ExpiredDate=@ExpDate,Signature=@Sig,Picture=@picPath," & _
                                    " Firstname=@fname,lastname=@lname,Category=@cat Where PermitNumber=@PermitNo"
        Dim dbCommand As System.Data.IDbCommand = New System.Data.SqlClient.SqlCommand
        dbCommand.CommandText = queryString
        dbCommand.Connection = dbConnection

        Dim dbParam_BatchNo As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_BatchNo.ParameterName = "@BatchNo"
        dbParam_BatchNo.Value = BatchNo
        dbParam_BatchNo.DbType = System.Data.DbType.String
        dbCommand.Parameters.Add(dbParam_BatchNo)

        Dim dbParam_PermitNo As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_PermitNo.ParameterName = "@PermitNo"
        dbParam_PermitNo.Value = PermitNo
        dbParam_PermitNo.DbType = System.Data.DbType.String
        dbCommand.Parameters.Add(dbParam_PermitNo)

        Dim dbParam_IsDate As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_IsDate.ParameterName = "@IsDate"
        dbParam_IsDate.Value = IsDate
        dbParam_IsDate.DbType = System.Data.DbType.Date
        dbCommand.Parameters.Add(dbParam_IsDate)

        Dim dbParam_ExpDate As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_ExpDate.ParameterName = "@ExpDate"
        dbParam_ExpDate.Value = ExpDate
        dbParam_ExpDate.DbType = System.Data.DbType.Date
        dbCommand.Parameters.Add(dbParam_ExpDate)

        Dim dbParam_Sig As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_Sig.ParameterName = "@Sig"
        dbParam_Sig.Value = Sig
        dbParam_Sig.DbType = System.Data.DbType.String
        dbCommand.Parameters.Add(dbParam_Sig)


        Dim dbParam_picpath As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_picpath.ParameterName = "@picpath"
        dbParam_picpath.Value = picpath
        dbParam_picpath.DbType = System.Data.DbType.String
        dbCommand.Parameters.Add(dbParam_picpath)

        Dim dbParam_fname As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_fname.ParameterName = "@fname"
        dbParam_fname.Value = fname
        dbParam_fname.DbType = System.Data.DbType.String
        dbCommand.Parameters.Add(dbParam_fname)

        Dim dbParam_lname As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_lname.ParameterName = "@lname"
        dbParam_lname.Value = lname
        dbParam_lname.DbType = System.Data.DbType.String
        dbCommand.Parameters.Add(dbParam_lname)

        Dim dbParam_cat As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_cat.ParameterName = "@cat"
        dbParam_cat.Value = cat
        dbParam_cat.DbType = System.Data.DbType.String
        dbCommand.Parameters.Add(dbParam_cat)


        Dim rowsAffected As Integer = 0
        dbConnection.Open()
        Try
            rowsAffected = dbCommand.ExecuteNonQuery
        Finally
            dbConnection.Close()
        End Try

        Return rowsAffected
    End Function
    Function UpdateBatch(ByVal TrainId As Integer) As Integer

        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(connectionString)

        Dim queryString As String = "Update SignOff Set Inbatch='1' where TrainID=@trainId and signOff='1'"
        Dim dbCommand As System.Data.IDbCommand = New System.Data.SqlClient.SqlCommand
        dbCommand.CommandText = queryString
        dbCommand.Connection = dbConnection

        Dim dbParam_TrainId As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_TrainId.ParameterName = "@TrainId"
        dbParam_TrainId.Value = TrainId
        dbParam_TrainId.DbType = System.Data.DbType.Int32
        dbCommand.Parameters.Add(dbParam_TrainId)

        Dim rowsAffected As Integer = 0
        dbConnection.Open()
        Try
            rowsAffected = dbCommand.ExecuteNonQuery
        Finally
            dbConnection.Close()
        End Try

        Return rowsAffected
    End Function
    Function GetNamesInBatch(ByVal batchCode As String) As System.Data.IDataReader

        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(connectionString)

        Dim queryString As String = "Select * from IDWorksTable where batchNum=@batchcode"

        Dim dbCommand As System.Data.IDbCommand = New System.Data.SqlClient.SqlCommand
        dbCommand.CommandText = queryString
        dbCommand.Connection = dbConnection

        Dim dbParam_batchCode As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_batchCode.ParameterName = "@batchCode"
        dbParam_batchCode.Value = batchCode
        dbParam_batchCode.DbType = System.Data.DbType.String
        dbCommand.Parameters.Add(dbParam_batchCode)

        dbConnection.Open()
        Dim dataReader As System.Data.IDataReader = dbCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection)

        Return dataReader

    End Function
    Function CheckRecNo(ByVal RecNo As String) As Boolean
        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(connectionString)

        Dim queryString As String = "select AppID from Card_Info where RecNo=@RecNo"

        Dim dbCommand As System.Data.IDbCommand = New System.Data.SqlClient.SqlCommand
        dbCommand.CommandText = queryString
        dbCommand.Connection = dbConnection

        Dim dbParam_RecNo As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_RecNo.ParameterName = "@RecNo"
        dbParam_RecNo.Value = RecNo
        dbParam_RecNo.DbType = System.Data.DbType.String
        dbCommand.Parameters.Add(dbParam_RecNo)

        dbConnection.Open()
        Dim dataReader As System.Data.IDataReader = dbCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
        If dataReader.Read Then
            Return True
        Else
            Return False
        End If
    End Function

    Function CheckRecNoWID(ByVal RecNo As String, ByVal AppID As Integer) As Boolean
        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(connectionString)

        Dim queryString As String = "select AppID from Card_Info where RecNo=@RecNo and AppID=@AppID"

        Dim dbCommand As System.Data.IDbCommand = New System.Data.SqlClient.SqlCommand
        dbCommand.CommandText = queryString
        dbCommand.Connection = dbConnection

        Dim dbParam_RecNo As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_RecNo.ParameterName = "@RecNo"
        dbParam_RecNo.Value = RecNo
        dbParam_RecNo.DbType = System.Data.DbType.String
        dbCommand.Parameters.Add(dbParam_RecNo)

        Dim dbParam_AppID As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_AppID.ParameterName = "@AppID"
        dbParam_AppID.Value = AppID
        dbParam_AppID.DbType = System.Data.DbType.String
        dbCommand.Parameters.Add(dbParam_AppID)


        dbConnection.Open()
        Dim dataReader As System.Data.IDataReader = dbCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
        If dataReader.Read Then
            Return True
        Else
            Return False
        End If
    End Function

    Function CheckPerrmitIDWorks(ByVal PermitNo As String) As Boolean
        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(connectionString)

        Dim queryString As String = "select Rid from IDWorksTable where PermitNumber=@permitNo"

        Dim dbCommand As System.Data.IDbCommand = New System.Data.SqlClient.SqlCommand
        dbCommand.CommandText = queryString
        dbCommand.Connection = dbConnection

        Dim dbParam_PermitNo As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_PermitNo.ParameterName = "@PermitNo"
        dbParam_PermitNo.Value = PermitNo
        dbParam_PermitNo.DbType = System.Data.DbType.String
        dbCommand.Parameters.Add(dbParam_PermitNo)


        dbConnection.Open()
        Dim dataReader As System.Data.IDataReader = dbCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
        If dataReader.Read Then
            Return True
        Else
            Return False
        End If
    End Function

    Function CheckRenewal(ByVal AppID As String, ByVal TrainId As Integer) As Boolean
        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(connectionString)

        Dim queryString As String = "SELECT RID FROM Card_Info WHERE AppId=@appId AND TrainID=@trainId"

        Dim dbCommand As System.Data.IDbCommand = New System.Data.SqlClient.SqlCommand
        dbCommand.CommandText = queryString
        dbCommand.Connection = dbConnection

        Dim dbParam_AppID As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_AppID.ParameterName = "@AppID"
        dbParam_AppID.Value = AppID
        dbParam_AppID.DbType = System.Data.DbType.String
        dbCommand.Parameters.Add(dbParam_AppID)

        Dim dbParam_TrainId As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_TrainId.ParameterName = "@TrainId"
        dbParam_TrainId.Value = TrainId
        dbParam_TrainId.DbType = System.Data.DbType.Int32
        dbCommand.Parameters.Add(dbParam_TrainId)


        dbConnection.Open()
        Dim dataReader As System.Data.IDataReader = dbCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
        If dataReader.Read Then
            Return True
        Else
            Return False
        End If
    End Function

    Function GetRecNo(ByVal TrainId As Integer) As String
        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(connectionString)

        Dim queryString As String = "select OnsiteRecNo from Schedules where Rid=@TrainId"

        Dim dbCommand As System.Data.IDbCommand = New System.Data.SqlClient.SqlCommand
        dbCommand.CommandText = queryString
        dbCommand.Connection = dbConnection

       

        Dim dbParam_TrainId As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_TrainId.ParameterName = "@TrainId"
        dbParam_TrainId.Value = TrainId
        dbParam_TrainId.DbType = System.Data.DbType.Int32
        dbCommand.Parameters.Add(dbParam_TrainId)


        dbConnection.Open()
        Dim dataReader As System.Data.IDataReader = dbCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
        If dataReader.Read Then
            Return dataReader("OnsiteRecNo")
        Else
            Return ""
        End If
    End Function

    Function UpdatePic(ByVal pic As Byte(), ByVal ID As String)
        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(connectionString)

        Dim queryString As String = "Update ApplicantsInfo Set Picture=@pic Where AppId=@ID"

        Dim dbCommand As System.Data.IDbCommand = New System.Data.SqlClient.SqlCommand
        dbCommand.CommandText = queryString
        dbCommand.Connection = dbConnection



        Dim dbParam_pic As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_pic.ParameterName = "@pic"
        dbParam_pic.Value = pic
        dbParam_pic.DbType = System.Data.DbType.Binary
        dbCommand.Parameters.Add(dbParam_pic)


        Dim dbParam_ID As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_ID.ParameterName = "@ID"
        dbParam_ID.Value = ID
        dbParam_ID.DbType = System.Data.DbType.String
        dbCommand.Parameters.Add(dbParam_ID)

        dbConnection.Open()
        Dim dataReader As System.Data.IDataReader = dbCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection)

    End Function

    Function MohSignOffAll(MOHID As Integer, trainId As Integer) As Integer

        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(connectionString)
        Dim queryString As String = "Update SignOff Set Signed='1', MOH_ID=@MOHID where TrainID=@trainId"
        Dim dbCommand As System.Data.IDbCommand = New System.Data.SqlClient.SqlCommand
        dbCommand.CommandText = queryString
        dbCommand.Connection = dbConnection
        Dim dbParam_trainId As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_trainId.ParameterName = "@trainId"
        dbParam_trainId.Value = trainId
        dbParam_trainId.DbType = System.Data.DbType.Int32
        dbCommand.Parameters.Add(dbParam_trainId)
        Dim dbParam_MOHID As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_MOHID.ParameterName = "@MOHID"
        dbParam_MOHID.Value = MOHID
        dbParam_MOHID.DbType = System.Data.DbType.Int32
        dbCommand.Parameters.Add(dbParam_MOHID)

        Dim rowsAffected As Integer = 0
        dbConnection.Open()
        Try
            rowsAffected = dbCommand.ExecuteNonQuery
        Finally
            dbConnection.Close()
        End Try
        Return rowsAffected
    End Function

    Function SearchApplByEmpName(EmpName As String) As System.Data.DataSet

        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(connectionString)
        Dim queryString As String = "Select AppID as 'Applicant ID', fname as 'First Name', lname as 'Last Name', Address2 as 'Address', Parish FROM ApplicantsInfo WHERE Emp_name like '%'+ @emp_name +'%'"
        Dim dbCommand As System.Data.IDbCommand = New System.Data.SqlClient.SqlCommand
        dbCommand.CommandText = queryString
        dbCommand.Connection = dbConnection
        Dim db_Emp_name As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        db_Emp_name.ParameterName = "@Emp_name"
        db_Emp_name.Value = EmpName
        db_Emp_name.DbType = System.Data.DbType.String
        dbCommand.Parameters.Add(db_Emp_name)
        dbConnection.Open()
        Dim dataAdapter As System.Data.IDbDataAdapter = New System.Data.SqlClient.SqlDataAdapter
        dataAdapter.SelectCommand = dbCommand
        Dim dataSet As System.Data.DataSet = New System.Data.DataSet
        dataAdapter.Fill(dataSet)
        Return dataSet
    End Function
    Function SearchApplByID(AppID As String) As System.Data.DataSet

        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(connectionString)
        Dim queryString As String = "Select AppID as 'Applicant ID', fname as 'First Name', lname as 'Last Name', Address2 as 'Address', Parish FROM ApplicantsInfo WHERE AppID like '%'+ @AppID +'%'"
        Dim dbCommand As System.Data.IDbCommand = New System.Data.SqlClient.SqlCommand
        dbCommand.CommandText = queryString
        dbCommand.Connection = dbConnection
        Dim db_AppID As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        db_AppID.ParameterName = "@AppID"
        db_AppID.Value = AppID
        db_AppID.DbType = System.Data.DbType.String
        dbCommand.Parameters.Add(db_AppID)
        dbConnection.Open()
        Dim dataAdapter As System.Data.IDbDataAdapter = New System.Data.SqlClient.SqlDataAdapter
        dataAdapter.SelectCommand = dbCommand
        Dim dataSet As System.Data.DataSet = New System.Data.DataSet
        dataAdapter.Fill(dataSet)
        Return dataSet
    End Function

    Function getParishes(ParID As Integer, p2 As Integer) As DataSet
        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(connectionString)
        Dim queryString As String = "select * from ParishList"
        Dim dbCommand As System.Data.IDbCommand = New System.Data.SqlClient.SqlCommand
        dbCommand.CommandText = queryString
        dbCommand.Connection = dbConnection

        dbConnection.Open()

        Dim dataAdapter As System.Data.IDbDataAdapter = New System.Data.SqlClient.SqlDataAdapter
        dataAdapter.SelectCommand = dbCommand
        Dim dataSet As System.Data.DataSet = New System.Data.DataSet
        dataAdapter.Fill(dataSet)

        Return dataSet


    End Function

End Class
