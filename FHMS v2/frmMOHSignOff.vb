Imports System.IO
Public Class frmMohSignOff
    'TODO: Add table view to see each applicant individually in a batch and to sign off on each.

    Dim BatchesDS As System.Data.DataSet
    Dim ApplicantsDS As System.Data.DataSet

    Dim currPos As Integer
    Dim review As New ClassReview
    Dim sql As New SqlClass

    Private Sub frmMohSignOff_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ApplicantReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        LoadBatches()
    End Sub

    Function GetBatches() As DataSet
        BatchesDS = sql.GetInfoForSignOff()
        Return BatchesDS
    End Function

    Sub LoadBatches()
        dgvBatches.DataSource = GetBatches()
        dgvBatches.DataMember = ("table")

        For Each col As DataGridViewColumn In dgvBatches.Columns
            col.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Next
    End Sub

    Private Sub dgvBatches_CellClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgvBatches.CellClick
        dgvApplications.DataSource = GetApplicants(Convert.ToInt32(dgvBatches("ID", e.RowIndex).Value))
        dgvApplications.DataMember = "table"
        'btnSubmit.Enabled = True
        btnSubmitAll.Enabled = True
    End Sub

    Function GetApplicants(BatchID As Integer) As DataSet
        ' Write method to get applicant
        ApplicantsDS = review.GetApplicants(BatchID)
        Return ApplicantsDS
    End Function

    Private Sub dgvApplications_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvApplications.CellClick
        ' Get single applicant from batch based on one selected.
        LoadApplication(dgvApplications.SelectedRows(0).Index, ApplicantsDS)
        btnSubmit.Enabled = True
    End Sub

    Dim appid As String
    Sub LoadApplication(ByVal currPos As Integer, ByRef ds As DataSet)
        Me.currPos = currPos

        'Show select applicant from batch in ReportView

        Dim DStarget As New dsBatch
        Dim BatchInfo As New dsBatch.DataTable2DataTable
        Dim trainInfo As New dsBatch.DTTestResultDataTable
        Dim docInfo As New dsBatch.DTMedicalDataTable
        Dim dr As dsBatch.DataTable2Row
        Dim mainrpt As New rptReview
        Dim subrpt As CrystalDecisions.CrystalReports.Engine.ReportDocument
        Dim subrpt2 As CrystalDecisions.CrystalReports.Engine.ReportDocument

        If ds.Tables(0).Rows.Count > currPos Then
            btnSubmit.Enabled = True
            btnSubmitAll.Enabled = True
            If ds.Tables(0).Rows.Count > 1 Then
                btnPrevious.Enabled = True
                btnNext.Enabled = True
            Else
                btnPrevious.Enabled = False
                btnNext.Enabled = False
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
                .trainID = CInt(dgvBatches.Rows(dgvBatches.CurrentRow.Index).Cells(5).Value)
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
            reader2 = review.GetTestG(dgvBatches.Rows(dgvBatches.CurrentRow.Index).Cells(5).Value, appid)
            While reader2.Read
                Dim dr2 As dsBatch.DTTestResultRow
                dr2 = trainInfo.NewDTTestResultRow
                With dr2
                    .TestName = reader2("TestName")
                    .TestScore = reader2("Score")
                    .trainId = CInt(dgvBatches.Rows(dgvBatches.CurrentRow.Index).Cells(5).Value)
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
                ApplicantReportViewer.ReportSource = mainrpt
            Catch ex As CrystalDecisions.CrystalReports.Engine.EngineException
                Throw ex
            End Try
        Else
            MsgBox("End of records", MsgBoxStyle.Information + vbOKOnly)
        End If

        'MsgBox("Applications not yet reviewed", MsgBoxStyle.Information + vbOKOnly)
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        'next
        ApplicantReportViewer.ReportSource = Nothing
        BatchesDS = review.GetDemoG(dgvBatches.Rows(dgvBatches.CurrentRow.Index).Cells(5).Value, 0, 1)
        currPos += 1
        LoadApplication(currPos, BatchesDS)

        Dim SignedApplications As System.Data.DataSet = sql.GetsignedOnes(appid)

        Select Case SignedApplications.Tables(0).Rows(0)("signed")
            Case 0
                btnSubmit.Text = "Submit"
                btnSubmit.Enabled = True
            Case 1
                btnSubmit.Text = "Sign off"
                btnSubmit.Enabled = False
        End Select

    End Sub

    Private Sub btnPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrevious.Click
        'prev
        ApplicantReportViewer.ReportSource = Nothing
        BatchesDS = review.GetDemoG(dgvBatches.Rows(dgvBatches.CurrentRow.Index).Cells(5).Value, 0, 1)
        currPos -= 1
        LoadApplication(currPos, BatchesDS)

        Dim isSign As System.Data.DataSet = sql.GetsignedOnes(appid)
        Select Case isSign.Tables(0).Rows(0)("signed")
            Case 0
                btnSubmit.Text = "Submit"
                btnSubmit.Enabled = True
            Case 1
                btnSubmit.Text = "Sign off"
                btnSubmit.Enabled = False
        End Select
    End Sub

    Private Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        If MsgBox("are you sure you want to sign off this application?", MsgBoxStyle.Information + vbYesNo) = MsgBoxResult.Yes Then
            Try
                Dim num As Integer = sql.MohSignOff(appid, dgvBatches.Rows(dgvBatches.CurrentRow.Index).Cells("ID").Value, UserID)

                If num > 0 Then
                    MessageBox.Show("Application successfully signed.", "Signing Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Could not submit application, please try again.", "Signing Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

                btnNext.PerformClick()
            Catch ex As Exception
                MessageBox.Show("Could not submit application, please try again." + vbNewLine + "Reason: " + ex.Message, "Signing Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
        Else
            Exit Sub
        End If
    End Sub

    Private Sub btnSubmitAll_Click(sender As Object, e As EventArgs) Handles btnSubmitAll.Click
        If MsgBox("are you sure you want to sign off all applications in this batch?", MsgBoxStyle.Information + vbYesNo) = MsgBoxResult.Yes Then
            Try
                Dim num As Integer = sql.MohSignOffAll(UserID, dgvBatches.Rows(dgvBatches.CurrentRow.Index).Cells("ID").Value)

                If num > 0 Then
                    MessageBox.Show("Applications successfully signed.", "Signing Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Could not submit applications, please try again.", "Signing Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Catch ex As Exception
                MessageBox.Show("Could not submit all applications. " + vbNewLine + "Reason: " + ex.Message, "Signing Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
        Else
            Exit Sub
        End If
    End Sub
End Class