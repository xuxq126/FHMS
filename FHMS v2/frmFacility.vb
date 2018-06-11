Public Class frmFacility
    Dim sql As New SqlClass

    Private Sub frmFacility_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Parishes As New System.Data.DataSet
        Parishes = sql.getParishes
        With cmbparish
            .DataSource = Parishes.Tables(0)
            .DisplayMember = "ParishName"
            .ValueMember = "ParishId"
            .SelectedIndex = 0
        End With
    End Sub

    Dim factype As Integer = 0
    Private Sub btnSaveFacility_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveFacility.Click
        If cmbname.Text = "" Or cmbparish.Text = "" Then
            MsgBox("Please enter a Name and choose a Parish.", MsgBoxStyle.Critical + vbOKOnly)
            Exit Sub
        End If

        Dim records As Integer

        Try
            records = sql.AddFacility(cmbname.Text, cmbparish.SelectedValue, factype)

            If records > 0 Then
                MsgBox("Facility successfully added", MsgBoxStyle.Information + vbOKOnly)
            End If
        Catch ex As Exception
            MessageBox.Show("Could not add new facility." & vbNewLine & "Details: " & ex.Message, "Insert Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub chkreg_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkreg.CheckedChanged
        If chkreg.Checked Then
            factype = 1
        Else
            factype = 2
        End If
    End Sub

    Private Sub chkonsite_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkonsite.CheckedChanged
        If chkonsite.Checked Then
            factype = 2
        Else
            factype = 1
        End If
    End Sub
End Class