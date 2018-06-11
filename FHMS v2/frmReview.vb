Imports System.IO
Public Class frmReview
    Dim ds As System.Data.DataSet
    Dim currPos As Integer
    Dim review As New ClassReview
    Dim sql As New SqlClass
    Dim curPos As Integer = 0
    Private Sub frmReview_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loadClinics()

        'If ds.Tables(0).Rows.Count < 0 Then
        '    ds = GetApps()
        'End If

        ' loadApp(0, ds)
    End Sub
    'Function GetApps() As System.Data.DataSet
    '    Dim ds As System.Data.DataSet
    '    ds = review.GetReviewDemoG(DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(5).Value, HasMohSign, HasReview)
    '    Return ds
    'End Function
    Sub loadClinics()
        Dim ds1 As System.Data.DataSet = sql.GetInfoForSignOff
        DataGridView1.DataSource = ds1
        DataGridView1.DataMember = ("table")

    End Sub
    Dim appid As String
    Sub loadApp(ByVal currPos As Integer, ByRef ds As DataSet)

        ' Dim ds As New System.Data.DataSet
        Dim DStarget As New dsBatch
        Dim BatchInfo As New dsBatch.DataTable2DataTable
        Dim trainInfo As New dsBatch.DTTestResultDataTable
        Dim docInfo As New dsBatch.DTMedicalDataTable
        Dim dr As dsBatch.DataTable2Row
        Dim mainrpt As New rptReview
        Dim subrpt As CrystalDecisions.CrystalReports.Engine.ReportDocument
        Dim subrpt2 As CrystalDecisions.CrystalReports.Engine.ReportDocument
        
        If ds.Tables(0).Rows.Count > currPos Then
            Button3.Enabled = True
            If ds.Tables(0).Rows.Count > 1 Then
                Button2.Enabled = True
                Button1.Enabled = True
            Else
                Button2.Enabled = False
                Button1.Enabled = False
            End If
            appid = ds.Tables(0).Rows(currPos).Item("AppId")
            dr = BatchInfo.NewDataTable2Row

            With dr
                .fname = ds.Tables(0).Rows(currPos).Item("fname")
                .Lname = ds.Tables(0).Rows(currPos).Item("lname")
                .Address = ds.Tables(0).Rows(currPos).Item("address1") & ", " & ds.Tables(0).Rows(currPos).Item("address2") & ", " & ds.Tables(0).Rows(currPos).Item("parish")
                .age = sql.GetAge(CDate(ds.Tables(0).Rows(currPos).Item("dob")))
                .sex = ds.Tables(0).Rows(currPos).Item("gender")
                .empName = ds.Tables(0).Rows(currPos).Item("emp_name")
                .EmpAddress = ds.Tables(0).Rows(currPos).Item("Emp_address") & ", " & ds.Tables(0).Rows(currPos).Item("emp_parish")
                .trainID = CInt(DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(5).Value)
                Dim bits As Byte() = CType(ds.Tables(0).Rows(currPos).Item("picture"), Byte())
                .image = bits
                .FHCategory = ds.Tables(0).Rows(currPos).Item("handlerName")
                .doc_name = ds.Tables(0).Rows(currPos).Item("DoctorsName")
                .doc_address = ds.Tables(0).Rows(currPos).Item("DoctorsAddress")
                .doc_tel = ds.Tables(0).Rows(currPos).Item("TelePhoneNo")
                .literate = ds.Tables(0).Rows(currPos).Item("literate")
                .livedAbrd = ds.Tables(0).Rows(currPos).Item("LivedAbroad")
                .TravRec = ds.Tables(0).Rows(currPos).Item("TravelledRecently")
                .abrdadd = ds.Tables(0).Rows(currPos).Item("AbroadAddress")
                .abrdPrd = ds.Tables(0).Rows(currPos).Item("LivedAbroadPeriod")
                .travAdd = ds.Tables(0).Rows(currPos).Item("TravelledWhere")
                .travWhen = ds.Tables(0).Rows(currPos).Item("TravelledWhen")
                .medically_accpted = ds.Tables(0).Rows(currPos).Item("MedicallyAccepted")





            End With
            BatchInfo.AddDataTable2Row(dr)


            Dim reader2 As System.Data.IDataReader
            reader2 = review.GetTestG(DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(5).Value, appid)
            While reader2.Read


                Dim dr2 As dsBatch.DTTestResultRow
                dr2 = trainInfo.NewDTTestResultRow
                With dr2
                    .TestName = reader2("TestName")
                    .TestScore = reader2("Score")
                    .trainId = CInt(DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(5).Value)
                End With
                trainInfo.AddDTTestResultRow(dr2)
            End While
            reader2.Close()

            Dim Mreader As System.Data.IDataReader
            Dim mdr As dsBatch.DTMedicalRow
            Mreader = review.GetMedicalG(appid)
            While Mreader.Read
                mdr = docInfo.NewDTMedicalRow
                With mdr
                    .conditionName = Mreader("condition")
                End With
                docInfo.AddDTMedicalRow(mdr)
            End While
            Mreader.Close()
            Mreader.Dispose()


            Try
                subrpt = mainrpt.OpenSubreport("SubTest.rpt")
                subrpt2 = mainrpt.OpenSubreport("subMedical.rpt")
                subrpt.SetDataSource(CType(trainInfo, DataTable))
                subrpt2.SetDataSource(CType(docInfo, DataTable))
                mainrpt.SetDataSource(CType(BatchInfo, DataTable))
                CrystalReportViewer1.ReportSource = mainrpt




            Catch ex As CrystalDecisions.CrystalReports.Engine.EngineException
                Throw ex
            End Try
        Else
            MsgBox("end of records", MsgBoxStyle.Information + vbOKOnly)
        End If

        BatchInfo = Nothing
        trainInfo = Nothing
        docInfo = Nothing

    End Sub

    Private Sub DataGridView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.DoubleClick

        ds = review.GetReviewDemoG(DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(5).Value, HasMohSign, HasReview)
        loadApp(0, ds)
    End Sub

   

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Me.Close()

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If MsgBox("are you sure you want to submitt this application for MOH sign Off?", MsgBoxStyle.Information + vbYesNo) = MsgBoxResult.Yes Then
            Dim num As Integer = sql.ReviewSignOff(appid, DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(5).Value)
            If num > 0 Then
                'Button3.Text = "Reviewed"
                'Button3.Enabled = False
                Button1.PerformClick()
            Else
                Button3.Text = "Submitt"
                Button3.Enabled = True

            End If
        Else
            Exit Sub
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'next
        CrystalReportViewer1.ReportSource = Nothing
        currPos += 1
        loadApp(currPos, ds)

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        'prev
        CrystalReportViewer1.ReportSource = Nothing
        currPos -= 1
        loadApp(currPos, ds)

        Dim isSign As System.Data.DataSet = sql.GetReviewOnes(appid)
        Select Case isSign.Tables(0).Rows(0)("review")
            Case 0
                Button3.Text = "Submit"
                Button3.Enabled = True
            Case 1
                Button3.Text = "Reviewed"
                Button3.Enabled = False
        End Select
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class