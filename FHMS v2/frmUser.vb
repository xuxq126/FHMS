Public Class frmUser
    Dim sql As New SqlClass

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        MsgBox("search for all users", MsgBoxStyle.Information + vbOKOnly)
    End Sub

    Private Sub frmUser_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dataset1 As New System.Data.DataSet
        dataset1 = Sql.getParishes
        With cbxParish
            .DataSource = dataset1.Tables(0)
            .DisplayMember = "ParishName"
            .ValueMember = "ParishId"
            .SelectedIndex = 0
        End With
    End Sub

    Private Sub cbxUserType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxUserType.SelectedIndexChanged
        If cbxUserType.Text.Trim = "MOH" Then
            Dim frm As New frmMOHSignature
            frm.ShowDialog()
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If txtfname.Text = "" Or txtlname.Text = "" Or txtpsw.Text = "" Or cbxUserType.Text = "" Or cbxParish.Text = "" Then
            MsgBox("All fields are required.", MsgBoxStyle.Critical + vbOKOnly)
            Exit Sub
        End If

        Dim Password As String = SqlClass.EncryptText(txtpsw.Text.Trim)
        Dim result As Integer = sql.AddUser(txtfname.Text.Trim, txtlname.Text.Trim, txtUsername.Text, Password, cbxUserType.SelectedIndex, cbxParish.SelectedValue)

        If result > 0 Then
            MsgBox(txtfname.Text & " " & txtlname.Text & " Added Successfully", MsgBoxStyle.Information + vbOKOnly)
            txtfname.Text = ""
            txtlname.Text = ""
            txtpsw.Text = ""
            cbxUserType.Text = ""
            cbxParish.Text = ""
        Else
            MsgBox("Error", MsgBoxStyle.Critical + vbOKOnly)

        End If

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class