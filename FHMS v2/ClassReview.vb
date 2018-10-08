Imports System.Configuration
Imports System.Data.SqlClient

Public Class ClassReview
    Public connectionString As String = "Data Source=ROMONE-PC\SQL2008EXP; Initial Catalog=FHMS2;Integrated Security=True"
    ' Public connectionstring As String = ConfigurationSettings.AppSettings("DBConnection")

    Function GetDemoG(ByVal trainId As Integer, ByVal sign As Integer, ByVal review As Integer) As System.Data.DataSet

        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(connectionString)
        Dim queryString As String = "select AI.*,DI.*,FHC.handlerName from ApplicantsInfo AI, DoctorsInfo DI, Card_Info CI, FoodHandlersCategories FHC where AI.AppID=DI.AppID and CI.HandlerID=FHC.HandlerID and" &
                                    " DI.AppID=CI.AppID and CI.TrainID=@trainId and CI.AppID in (select SO.AppID from SignOff So where signed=@sign and review=@review)"

        Dim dbCommand As System.Data.IDbCommand = New System.Data.SqlClient.SqlCommand
        dbCommand.CommandText = queryString
        dbCommand.Connection = dbConnection

        Dim dbParam_sign As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_sign.ParameterName = "@sign"
        dbParam_sign.Value = sign
        dbParam_sign.DbType = System.Data.DbType.Int32
        dbCommand.Parameters.Add(dbParam_sign)

        Dim dbParam_trainID As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_trainID.ParameterName = "@TrainId"
        dbParam_trainID.Value = trainId
        dbParam_trainID.DbType = System.Data.DbType.Int32
        dbCommand.Parameters.Add(dbParam_trainID)

        Dim dbParam_review As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_review.ParameterName = "@review"
        dbParam_review.Value = review
        dbParam_review.DbType = System.Data.DbType.Int32
        dbCommand.Parameters.Add(dbParam_review)


        Dim dataAdapter As System.Data.IDbDataAdapter = New System.Data.SqlClient.SqlDataAdapter
        dataAdapter.SelectCommand = dbCommand
        Dim dataSet As System.Data.DataSet = New System.Data.DataSet
        dataAdapter.Fill(dataSet)
        Return dataSet
    End Function

    Function GetApplicants(ByVal BatchID As Integer) As System.Data.DataSet
        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(connectionString)

        Dim queryString As String = "select AI.*,DI.*,FHC.handlerName from ApplicantsInfo AI, DoctorsInfo DI, Card_Info CI, FoodHandlersCategories FHC where AI.AppID=DI.AppID and CI.HandlerID=FHC.HandlerID and" &
                                    " DI.AppID=CI.AppID and CI.TrainID=@BatchID and CI.AppID in (SELECT SO.AppID FROM SignOff SO WHERE signed=0 AND review=1)"

        Dim dbCommand As System.Data.IDbCommand = New System.Data.SqlClient.SqlCommand
        dbCommand.CommandText = queryString
        dbCommand.Connection = dbConnection

        Dim dbParam_trainID As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_trainID.ParameterName = "@BatchID"
        dbParam_trainID.Value = BatchID
        dbParam_trainID.DbType = System.Data.DbType.String
        dbCommand.Parameters.Add(dbParam_trainID)

        Dim dataAdapter As System.Data.IDbDataAdapter = New System.Data.SqlClient.SqlDataAdapter
        dataAdapter.SelectCommand = dbCommand
        Dim dataSet As System.Data.DataSet = New System.Data.DataSet
        dataAdapter.Fill(dataSet)
        Return dataSet
    End Function

    Function GetApplicantInfoReview(ByVal trainId As Integer, ByVal sign As Integer, ByVal review As Integer) As System.Data.DataSet

        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(connectionString)
        Dim queryString As String = "SELECT AI.*,DI.*,FHC.handlerName FROM ApplicantsInfo AI " &
                                    "JOIN DoctorsInfo DI ON AI.AppID = DI.AppID " &
                                    "JOIN Card_Info CI ON AI.AppID = CI.AppID " &
                                    "JOIN FoodHandlersCategories FHC ON CI.HandlerID = FHC.HandlerID " &
                                    "WHERE CI.TrainID=@trainId and CI.AppID in (SELECT SO.AppID FROM SignOff SO WHERE review=@review)"

        Dim dbCommand As System.Data.IDbCommand = New System.Data.SqlClient.SqlCommand
        dbCommand.CommandText = queryString
        dbCommand.Connection = dbConnection

        'Dim dbParam_sign As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        'dbParam_sign.ParameterName = "@sign"
        'dbParam_sign.Value = sign
        'dbParam_sign.DbType = System.Data.DbType.Int32
        'dbCommand.Parameters.Add(dbParam_sign)

        Dim dbParam_trainID As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_trainID.ParameterName = "@TrainId"
        dbParam_trainID.Value = trainId
        dbParam_trainID.DbType = System.Data.DbType.Int32
        dbCommand.Parameters.Add(dbParam_trainID)

        Dim dbParam_review As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_review.ParameterName = "@review"
        dbParam_review.Value = review
        dbParam_review.DbType = System.Data.DbType.Int32
        dbCommand.Parameters.Add(dbParam_review)


        Dim dataAdapter As System.Data.IDbDataAdapter = New System.Data.SqlClient.SqlDataAdapter
        dataAdapter.SelectCommand = dbCommand
        Dim dataSet As System.Data.DataSet = New System.Data.DataSet
        dataAdapter.Fill(dataSet)
        Return dataSet


    End Function
    Function GetTestG(ByVal trainId As Integer, ByVal AppId As String) As System.Data.IDataReader

        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(connectionString)
        Dim queryString As String = "select * from Score_Reg where TrainID=@trainID and AppId=@AppID"

        Dim dbCommand As System.Data.IDbCommand = New System.Data.SqlClient.SqlCommand
        dbCommand.CommandText = queryString
        dbCommand.Connection = dbConnection

        Dim dbParam_trainID As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_trainID.ParameterName = "@TrainId"
        dbParam_trainID.Value = trainId
        dbParam_trainID.DbType = System.Data.DbType.Int32
        dbCommand.Parameters.Add(dbParam_trainID)

        Dim dbParam_AppId As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_AppId.ParameterName = "@AppId"
        dbParam_AppId.Value = AppId
        dbParam_AppId.DbType = System.Data.DbType.String
        dbCommand.Parameters.Add(dbParam_AppId)


        dbConnection.Open()
        Dim dataReader As System.Data.IDataReader = dbCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection)

        Return dataReader



    End Function

    Function GetMedicalG(ByVal AppId As String) As System.Data.IDataReader

        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(connectionString)
        Dim queryString As String = "select condition from HealthCondition where AppId=@AppId"

        Dim dbCommand As System.Data.IDbCommand = New System.Data.SqlClient.SqlCommand
        dbCommand.CommandText = queryString
        dbCommand.Connection = dbConnection

        Dim dbParam_AppId As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_AppId.ParameterName = "@AppId"
        dbParam_AppId.Value = AppId
        dbParam_AppId.DbType = System.Data.DbType.String
        dbCommand.Parameters.Add(dbParam_AppId)

        Try
            dbConnection.Open()
            Dim dataReader As System.Data.IDataReader = dbCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection)

            Return dataReader

        Catch ex As Exception

        End Try

    End Function

    Function GetBatchCodes() As SqlDataReader
        Dim DbConnection = New SqlConnection(connectionString)
        Dim queryString As String = "select distinct batchnum from IDWorksTable order by batchnum desc"
        Dim command As SqlCommand = New SqlCommand(queryString, DbConnection)

        Try
            DbConnection.Open()
            Dim dataReader As SqlDataReader = command.ExecuteReader()

            Return dataReader
        Catch ex As Exception
            MessageBox.Show("Could not retrieve batch numbers from database.")
        End Try
    End Function

    Function GetImages(ByVal batchNum As String) As System.Data.DataSet
        Dim dbConnection As System.Data.IDbConnection = New System.Data.SqlClient.SqlConnection(connectionString)
        Dim queryString As String = "SELECT AI.picture, ID.Picture as path from ApplicantsInfo AI, IDWorksTable ID where ID.PermitNumber=AI.AppID and ID.BatchNum=@batchNum"

        Dim dbCommand As System.Data.IDbCommand = New System.Data.SqlClient.SqlCommand
        dbCommand.CommandText = queryString
        dbCommand.Connection = dbConnection

        Dim dbParam_batchNum As System.Data.IDataParameter = New System.Data.SqlClient.SqlParameter
        dbParam_batchNum.ParameterName = "@batchNum"
        dbParam_batchNum.Value = batchNum
        dbParam_batchNum.DbType = System.Data.DbType.String
        dbCommand.Parameters.Add(dbParam_batchNum)



        Dim dataAdapter As System.Data.IDbDataAdapter = New System.Data.SqlClient.SqlDataAdapter
        dataAdapter.SelectCommand = dbCommand
        Dim dataSet As System.Data.DataSet = New System.Data.DataSet
        dataAdapter.Fill(dataSet)
        Return dataSet

    End Function

End Class
