Imports System.Data.SqlClient
Public Class frmBatch
    Dim sql As New SqlClass
    Dim cn As SqlConnection

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub frmBatch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'GetAllSchedulesForBatch
        Dim ds As System.Data.DataSet = sql.GetAllSchedulesForBatch
        If ds.Tables(0).Rows.Count = 0 Then
            Button1.Enabled = False

        Else

            DataGridView1.DataSource = ds
            DataGridView1.DataMember = ("table")
            Button1.Enabled = True

        End If

    End Sub
    Dim i As Integer
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim tdate As Date
        Dim ttime As Date
        Dim tfac As String
        If DataGridView1.SelectedRows.Count = 0 Then
            MsgBox("please select a schedule to continue", MsgBoxStyle.Critical + vbOKOnly)
            Exit Sub

        Else

            tdate = CDate(DataGridView1.Item(0, DataGridView1.CurrentRow.Index).Value)
            ttime = CDate(DataGridView1.Item(1, DataGridView1.CurrentRow.Index).Value)
            tfac = DataGridView1.Item(3, DataGridView1.CurrentRow.Index).Value
            tfac.Trim()
            Dim batchCode As String = (tfac.Substring(0, 5).Trim & tdate.ToString("yyMMdd") & ttime.ToString("hhmm"))

            Dim ds As System.Data.DataSet
            ds = sql.GetForPrints(CInt(DataGridView1.Item(4, DataGridView1.CurrentRow.Index).Value))

            Dim count As Integer = ds.Tables(0).Rows.Count
            If ds.Tables(0).Rows.Count <= 0 Then
                MsgBox("No Items found in batch", MsgBoxStyle.Information + vbOKOnly)
            Else

                For i = 0 To ds.Tables(0).Rows.Count - 1
                    'add to idworks table

                    cn = New SqlConnection(sql.connectionString)
                    Dim cmdsave As New SqlCommand("SaveToIDWorks", cn)
                    Dim prmParam As SqlParameter

                    With cmdsave
                        .CommandType = CommandType.StoredProcedure
                        prmParam = New SqlParameter
                        prmParam.ParameterName = "@AppID"
                        prmParam.DbType = DbType.String
                        prmParam.Size = 30
                        prmParam.Value = ds.Tables(0).Rows(i).Item("AppId")
                        .Parameters.Add(prmParam)
                        prmParam = Nothing

                        prmParam = New SqlParameter
                        prmParam.ParameterName = "@batchNum"
                        prmParam.DbType = DbType.String
                        prmParam.Size = 30
                        prmParam.Value = batchCode
                        .Parameters.Add(prmParam)
                        prmParam = Nothing

                        prmParam = New SqlParameter
                        prmParam.ParameterName = "@Iss_Date"
                        prmParam.DbType = DbType.Date
                        'prmParam.Size = 30
                        prmParam.Value = ds.Tables(0).Rows(i).Item("Iss_date")
                        .Parameters.Add(prmParam)
                        prmParam = Nothing

                        prmParam = New SqlParameter
                        prmParam.ParameterName = "@Exp_date"
                        prmParam.DbType = DbType.Date
                        ' prmParam.Size = 30
                        prmParam.Value = ds.Tables(0).Rows(i).Item("Exp_date")
                        .Parameters.Add(prmParam)
                        prmParam = Nothing

                        prmParam = New SqlParameter
                        prmParam.ParameterName = "@mohsig"
                        prmParam.DbType = DbType.String
                        prmParam.Size = 30
                        prmParam.Value = ds.Tables(0).Rows(i).Item("mohSig")
                        .Parameters.Add(prmParam)
                        prmParam = Nothing

                        prmParam = New SqlParameter
                        prmParam.ParameterName = "@fname"
                        prmParam.DbType = DbType.String
                        prmParam.Size = 30
                        prmParam.Value = ds.Tables(0).Rows(i).Item("fname")
                        .Parameters.Add(prmParam)
                        prmParam = Nothing

                        prmParam = New SqlParameter
                        prmParam.ParameterName = "@lname"
                        prmParam.DbType = DbType.String
                        prmParam.Size = 30
                        prmParam.Value = ds.Tables(0).Rows(i).Item("lname")
                        .Parameters.Add(prmParam)
                        prmParam = Nothing

                        prmParam = New SqlParameter
                        prmParam.ParameterName = "@HandlerName"
                        prmParam.DbType = DbType.String
                        prmParam.Size = 30
                        prmParam.Value = ds.Tables(0).Rows(i).Item("Handlername")
                        .Parameters.Add(prmParam)
                        prmParam = Nothing

                        prmParam = New SqlParameter
                        prmParam.ParameterName = "@Image"
                        prmParam.DbType = DbType.String
                        prmParam.Size = 30
                        prmParam.Value = "V:\" & ds.Tables(0).Rows(i).Item("AppId") & "-" & DataGridView1.Item(4, DataGridView1.CurrentRow.Index).Value & ".jpg"
                        .Parameters.Add(prmParam)
                        prmParam = Nothing
                        Try
                            If .Connection.State = ConnectionState.Closed Then .Connection.Open()
                            .ExecuteNonQuery()
                            'Return True
                        Catch ex As Exception
                            MsgBox(ex.Message, MsgBoxStyle.Information + vbOKOnly)
                        Finally
                            If .Connection.State = ConnectionState.Open Then .Connection.Close()
                        End Try
                    End With

                    'Dim num As Integer
                    'If sql.CheckPerrmitIDWorks(ds.Tables(0).Rows(i).Item("AppId")) = True Then
                    '    num = sql.UpdateIdWorks(batchCode.Trim, ds.Tables(0).Rows(i).Item("AppId"), _
                    '                       ds.Tables(0).Rows(i).Item("Iss_date"), _
                    '                       ds.Tables(0).Rows(i).Item("Exp_date"), _
                    '                       ds.Tables(0).Rows(i).Item("mohSig"), _
                    '                       "", ds.Tables(0).Rows(i).Item("fname"), _
                    '                       ds.Tables(0).Rows(i).Item("lname"), _
                    '                       ds.Tables(0).Rows(i).Item("Handlername"))
                    'Else

                    '    num = sql.AddToIdWorks(batchCode.Trim, ds.Tables(0).Rows(i).Item("AppId"), _
                    '                       ds.Tables(0).Rows(i).Item("Iss_date"), _
                    '                       ds.Tables(0).Rows(i).Item("Exp_date"), _
                    '                       ds.Tables(0).Rows(i).Item("mohSig"), _
                    '                       "", ds.Tables(0).Rows(i).Item("fname"), _
                    '                       ds.Tables(0).Rows(i).Item("lname"), _
                    '                       ds.Tables(0).Rows(i).Item("Handlername"))



                    'End If
                Next

                Label1.Text = count & " Item(s) found"
                TextBox1.Text = batchCode.Trim.ToUpper
                Dim num1 As Integer = sql.UpdateBatch(CInt(DataGridView1.Item(4, DataGridView1.CurrentRow.Index).Value))


            End If



        End If
    End Sub
   

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()

    End Sub
End Class