Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine

Public Class frmMohSignOff
    'TODO: Add table view to see each applicant individually in a batch and to sign off on each.

    Dim BatchesDS As DataSet
    Dim ApplicantsDS As DataSet

    Dim CurrentPosition As Integer
    Dim review As New ClassReview
    Dim Query As New SqlClass
    Dim User As String

    Private Sub frmMohSignOff_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ApplicantReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None

        Select Case AccessLevel
            Case 0
            Case 2
            Case 3
            Case 4
                User = "PHI"
            Case 1
                User = "MOH"
        End Select

        LoadBatches()
    End Sub

    Sub LoadBatches()
        dgvBatches.DataSource = GetBatches()
        dgvBatches.DataMember = ("table")
    End Sub

    Function GetBatches() As DataSet
        BatchesDS = Query.GetBatchesforSignOffReview()
        Return BatchesDS
    End Function

    Private Sub dgvBatches_CellClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgvBatches.CellClick
        If User = "PHI" Then
            ApplicantsDS = review.GetApplicantInfoReview(dgvBatches.Rows(dgvBatches.CurrentRow.Index).Cells(5).Value, 0, 0)
            dgvApplications.DataSource = ApplicantsDS
            dgvApplications.DataMember = "table"
        ElseIf User = "MOH" Then
            dgvApplications.DataSource = GetApplicants(Convert.ToInt32(dgvBatches("ID", e.RowIndex).Value))
            dgvApplications.DataMember = "table"
            'btnSubmit.Enabled = True
            btnSubmitAll.Enabled = True
        End If

        If dgvApplications.RowCount > 0 Then
            dgvApplications.Rows(0).Selected = True
            LoadApplication(dgvApplications.SelectedRows(0).Index, ApplicantsDS)
        End If
    End Sub

    Function GetApplicants(BatchID As Integer) As DataSet
        ' Write method to get applicant
        ApplicantsDS = review.GetApplicants(BatchID)
        Return ApplicantsDS
    End Function

    Private Sub dgvApplications_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvApplications.CellClick
        ' Get single applicant from batch based on one selected.
        LoadApplication(dgvApplications.SelectedRows(0).Index, ApplicantsDS)
    End Sub

    Dim appid As String
    Dim subrpt As ReportDocument
    Dim subrpt2 As ReportDocument

    Sub LoadApplication(ByVal currPos As Integer, ByRef ds As DataSet)
        CurrentPosition = currPos
        'Show select applicant from batch in ReportView

        Dim DStarget As New dsBatch
        Dim BatchInfo As New dsBatch.DataTable2DataTable
        Dim trainInfo As New dsBatch.DTTestResultDataTable
        Dim docInfo As New dsBatch.DTMedicalDataTable
        Dim dr As dsBatch.DataTable2Row
        Dim mainrpt As New rptReview

        If currPos < ds.Tables(0).Rows.Count Then
            If ds.Tables(0).Rows.Count > currPos And currPos > 0 Then
                btnPrevious.Enabled = True
                btnNext.Enabled = True
            End If

            If currPos > 0 Then
                btnPrevious.Enabled = True
            Else
                btnPrevious.Enabled = False
            End If

            If currPos + 1 = ds.Tables(0).Rows.Count Then
                btnNext.Enabled = False
            Else
                btnNext.Enabled = True
            End If

            appid = ds.Tables(0).Rows(currPos).Item("AppId")
            CheckApplicationStatus(appid)
            dr = BatchInfo.NewDataTable2Row

            With dr
                .fname = ds.Tables(0).Rows(currPos).Item("fname")
                .Lname = ds.Tables(0).Rows(currPos).Item("lname")
                .Address = ds.Tables(0).Rows(currPos).Item("address1") & ", " & ds.Tables(0).Rows(currPos).Item("address2") & ", " & ds.Tables(0).Rows(currPos).Item("parish")
                .age = Query.GetAge(CDate(ds.Tables(0).Rows(currPos).Item("dob")))
                .sex = ds.Tables(0).Rows(currPos).Item("gender")
                .empName = ds.Tables(0).Rows(currPos).Item("emp_name")
                .EmpAddress = ds.Tables(0).Rows(currPos).Item("Emp_address") & ", " & ds.Tables(0).Rows(currPos).Item("emp_parish")
                .trainID = CInt(dgvBatches.Rows(dgvBatches.CurrentRow.Index).Cells(5).Value)
                .image = CType(ds.Tables(0).Rows(currPos).Item("picture"), Byte())
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
            Catch ex As EngineException
                Throw ex
            End Try
        Else
            MessageBox.Show("There are no more applications in this batch.", "No More Records", MessageBoxButtons.OK, MessageBoxIcon.Information)
            currPos = 0
            btnSubmit.Enabled = False
        End If
    End Sub

    Private Sub btnNext_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnNext.Click
        'next to retreive approved applicants
        ApplicantReportViewer.ReportSource = Nothing
        'BatchesDS = review.GetDemoG(dgvBatches.Rows(dgvBatches.CurrentRow.Index).Cells(5).Value, 0, 1)
        CurrentPosition += 1
        LoadApplication(CurrentPosition, ApplicantsDS)
        CheckApplicationStatus(appid)

        CloseReport(subrpt)
        CloseReport(subrpt2)
    End Sub

    Private Sub btnPrevious_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnPrevious.Click
        'prev
        ApplicantReportViewer.ReportSource = Nothing
        'BatchesDS = review.GetDemoG(dgvBatches.Rows(dgvBatches.CurrentRow.Index).Cells(5).Value, 0, 1)
        CurrentPosition -= 1
        LoadApplication(CurrentPosition, ApplicantsDS)

        CheckApplicationStatus(appid)

        CloseReport(subrpt)
        CloseReport(subrpt2)
    End Sub

    Private Sub CloseReport(ByVal ReportDoc As ReportDocument)
        Dim Sections As Sections = ReportDoc.ReportDefinition.Sections

        For Each section As Section In Sections
            Dim ReptObjects As ReportObjects = section.ReportObjects
            For Each RprtObject As ReportObject In ReptObjects
                If RprtObject.Kind = CrystalDecisions.Shared.ReportObjectKind.SubreportObject Then
                    Dim subrptObj As SubreportObject = RprtObject
                    Dim subRprtDocument As ReportDocument = subrptObj.OpenSubreport(subrptObj.SubreportName)
                    subRprtDocument.Close()
                End If
            Next
        Next

        ReportDoc.Close()
        ReportDoc.Dispose()
    End Sub

    Private Function CheckApplicationStatus(AppID As String) As Boolean
        Dim Status As Integer

        If User = "PHI" Then
            Status = Query.GetReviewedApplications(AppID)
        ElseIf User = "MOH" Then
            Status = Query.GetSignedApplications(AppID)
        End If

        If Status = 1 Then ' Application is already reviewed or submitted
            btnSubmit.Text = "Processed"
            btnSubmit.Enabled = False
        Else
            btnSubmit.Text = "Process"
            btnSubmit.Enabled = True
        End If
    End Function

    Private Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        If User = "PHI" Then
            If MsgBox("Are you sure you want to submit this application for MOH approval?", MsgBoxStyle.Information + vbYesNo) = MsgBoxResult.Yes Then
                Try
                    Dim ApplicationsApproved As Integer = Query.ReviewSignOff(UserID, appid, dgvBatches.Rows(dgvBatches.CurrentRow.Index).Cells(5).Value)

                    If ApplicationsApproved > 0 Then
                        MessageBox.Show("Application has been successfully processed. Thank you.", "Successfully Processed", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        'If more records exist then load them else reload application.
                        If btnNext.Enabled = False Then
                            LoadApplication(CurrentPosition, ApplicantsDS)
                        Else
                            btnNext.PerformClick()
                        End If
                    Else
                        MessageBox.Show("Could not approve this application, please try again.", "Failed to Approve Application", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If
                Catch ex As Exception
                    MessageBox.Show("Could not approve application, please try again." + vbNewLine + "Reason: " + ex.Message, "Approval Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        ElseIf User = "MOH" Then
            If MsgBox("are you sure you want to sign off this application?", MsgBoxStyle.Information + vbYesNo) = MsgBoxResult.Yes Then
                Try
                    Dim num As Integer = Query.MohSignOff(appid, dgvBatches.Rows(dgvBatches.CurrentRow.Index).Cells("ID").Value, UserID)

                    If num > 0 Then
                        MessageBox.Show("Application successfully signed.", "Signing Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Could not submit application, please try again.", "Signing Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If

                    'If more records exist then load them else reload application.
                    If btnNext.Enabled = False Then
                        LoadApplication(CurrentPosition, ApplicantsDS)
                    Else
                        btnNext.PerformClick()
                    End If
                Catch ex As Exception
                    MessageBox.Show("Could not submit application, please try again." + vbNewLine + "Reason: " + ex.Message, "Signing Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End Try
            Else
                Exit Sub
            End If
        End If
    End Sub

    Private Sub btnSubmitAll_Click(sender As Object, e As EventArgs) Handles btnSubmitAll.Click
        If User = "PHI" Then
            If Query.CountApplicationstoReview(dgvBatches.Rows(dgvBatches.CurrentRow.Index).Cells("ID").Value) < 1 Then
                MessageBox.Show("There are no applicants remaining to be approved.", "No Applications", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            If MsgBox("Are you sure you want to approve all applications in this batch?", MsgBoxStyle.Information + vbYesNo) = MsgBoxResult.Yes Then
                Try
                    Dim num As Integer = Query.ReviewSignOffAll(UserID, dgvBatches.Rows(dgvBatches.CurrentRow.Index).Cells("ID").Value)

                    If num > 0 Then
                        MessageBox.Show("Applications successfully approved for MOH Sign off.", "Batch Approval Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Could not approve all applications, please try again.", "Approval Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Catch ex As Exception
                    MessageBox.Show("Could not approve all applications. " + vbNewLine + "Reason: " + ex.Message, "Approval Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End Try
            Else
                Exit Sub
            End If

        ElseIf User = "MOH" Then
            If Query.CountApplicationstoSubmit(dgvBatches.Rows(dgvBatches.CurrentRow.Index).Cells("ID").Value) < 1 Then
                MessageBox.Show("There are no applicants remaining to be signed off.", "No Applications", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            If MsgBox("Are you sure you want to sign off all applications in this batch?", MsgBoxStyle.Information + vbYesNo) = MsgBoxResult.Yes Then
                Try
                    Dim num As Integer = Query.MohSignOffAll(UserID, dgvBatches.Rows(dgvBatches.CurrentRow.Index).Cells("ID").Value)

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
        End If
    End Sub

    Private Sub frmMohSignOff_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If Not IsNothing(subrpt) Then
            CloseReport(subrpt)
        ElseIf Not IsNothing(subrpt2) Then
            CloseReport(subrpt2)
        End If
    End Sub
End Class