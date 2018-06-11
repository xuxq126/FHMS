Public Class frmRegSchedule
    Dim sql As New SqlClass
    Dim scheduleType As String
   
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If cmbfac.Text = "" Or cmbCategory.Text = "" Then
            MsgBox("Please verify that you supply all required information before continuing", MsgBoxStyle.Critical + vbOKOnly)
            Exit Sub
        End If

        Dim TrainID As String
        Dim strFac As String
        Dim strCat As String
        strFac = cmbfac.Text.Trim.Substring(0, 3)
        strCat = cmbCategory.Text.Trim.Substring(0, 3)
        TrainID = strFac & strCat & MonthCalendar1.SelectionRange.Start.Year.ToString & MonthCalendar1.SelectionRange.Start.Month.ToString & MonthCalendar1.SelectionRange.Start.Day.ToString & Now.TimeOfDay.Hours.ToString & Now.TimeOfDay.Minutes.ToString  'Hours.ToString & MonthCalendar1.TodayDate.TimeOfDay.Minutes.ToString
        Dim num As Integer
        If scheduleType = "Regular" Then
            num = sql.AddSchedule(MonthCalendar1.SelectionRange.Start, DateTimePicker1.Value.ToString("hh:mm tt"), TrainID, cmbfac.SelectedValue, cmbCategory.SelectedValue, handlerID, "", cmbparish.SelectedValue)
            If num > 0 Then
                MsgBox("Schedule successfully added", MsgBoxStyle.Information + vbOKOnly)
            End If
        ElseIf scheduleType = "Onsite" Then
            If txtreceipt.Text = "" Or txtreceipt.Text.Trim = "0" Or txtreceipt.Text.Length < 3 Then
                MsgBox("you entered an invalid Receipt No. please verify and try again", MsgBoxStyle.Critical + vbOKOnly)
                Exit Sub
            End If

            Dim RecNoExists As Boolean = sql.CheckRecNo(txtreceipt.Text.Trim)
            If RecNoExists Then
                MsgBox("Receipt No. you specify already in the system, please verify that you have entered the correct one." & _
                      " you cannot proceed until you entered a valid Receipt No.", MsgBoxStyle.Critical + vbOKOnly)
                Exit Sub
            End If

            num = sql.AddSchedule(MonthCalendar1.SelectionRange.Start, DateTimePicker1.Value.ToString("hh:mm tt"), TrainID, cmbfac.SelectedValue, cmbCategory.SelectedValue, handlerID, txtreceipt.Text.Trim, cmbparish.SelectedValue)
            If num > 0 Then
                MsgBox("Schedule successfully added", MsgBoxStyle.Information + vbOKOnly)
            End If

        End If

    End Sub
    Public handlerID As Integer
    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked = True Then
            handlerID = 1
            scheduleType = "Regular"
            Dim ds As New System.Data.DataSet
            ds = sql.SelectFacilities(1, ParID)
            If ds.Tables(0).Rows.Count = 0 Then
                MsgBox("information missing", MsgBoxStyle.Exclamation + vbOKOnly)
                Exit Sub

            Else
                With cmbfac
                    .DataSource = ds.Tables(0)
                    .DisplayMember = "FacilityName"
                    .ValueMember = "FacId"
                    .SelectedIndex = 0
                End With
                ds.Dispose()
                ds = Nothing
            End If
            Dim ds1 As New System.Data.DataSet
            ds1 = sql.SelectHandler(scheduleType)

            If ds1.Tables(0).Rows.Count = 0 Then
                MsgBox("information missing", MsgBoxStyle.Exclamation + vbOKOnly)
                Exit Sub

            Else
                With cmbCategory
                    .DataSource = ds1.Tables(0)
                    .DisplayMember = "Handlername"
                    .ValueMember = "handlerID"
                    .SelectedIndex = 0

                End With
                ds1.Dispose()
                ds1 = Nothing
            End If

            Label5.Visible = False
            txtreceipt.Visible = False
            txtreceipt.Text = ""

        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked = True Then
            handlerID = 2
            scheduleType = "Onsite"
            Dim ds As New System.Data.DataSet
            ds = sql.SelectFacilities(2, ParID)
            If ds.Tables(0).Rows.Count = 0 Then
                MsgBox("information missing", MsgBoxStyle.Exclamation + vbOKOnly)
                Exit Sub

            Else
                With cmbfac
                    .DataSource = ds.Tables(0)
                    .DisplayMember = "FacilityName"
                    .ValueMember = "FacId"
                    .SelectedIndex = 0
                End With
                ds.Dispose()
                ds = Nothing
            End If

            Dim ds1 As New System.Data.DataSet
            ds1 = sql.SelectHandler(scheduleType)
            If ds1.Tables(0).Rows.Count = 0 Then
                MsgBox("information missing", MsgBoxStyle.Exclamation + vbOKOnly)
                Exit Sub

            Else
                With cmbCategory
                    .DataSource = ds1.Tables(0)
                    .DisplayMember = "Handlername"
                    .ValueMember = "handlerID"
                    .SelectedIndex = 0

                End With
                ds1.Dispose()
                ds1 = Nothing
            End If
            Label5.Visible = True
            txtreceipt.Visible = True

        End If
    End Sub

    Private Sub frmRegSchedule_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dataset1 As New System.Data.DataSet
        dataset1 = sql.getParishes
        With cmbparish
            .DataSource = dataset1.Tables(0)
            .DisplayMember = "ParishName"
            .ValueMember = "ParishId"
            .SelectedIndex = 0
        End With
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub cmbfac_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbfac.SelectedIndexChanged

    End Sub
End Class