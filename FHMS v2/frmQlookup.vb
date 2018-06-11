Public Class frmQlookup
    Dim sql As New SqlClass

    Public Property ApplicantID() As String
        Get
            Return Me.dgvApplicants.Item(0, dgvApplicants.CurrentRow.Index).Value
        End Get
        Set(ByVal value As String)
            Me.dgvApplicants.Item(0, dgvApplicants.CurrentRow.Index).Value = value
        End Set
    End Property

    Private Sub btnLookup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLookup.Click
        If txtFilter.Text = String.Empty Then
            Return
        End If

        If cbxFilterMode.SelectedIndex = 0 Then
            Dim ds As DataSet = sql.SearchApplByName(txtFilter.Text.Trim)
            dgvApplicants.DataSource = ds
            dgvApplicants.DataMember = ("table")
        ElseIf cbxFilterMode.SelectedIndex = 1 Then
            Dim ds As DataSet = sql.SearchApplByEmpName(txtFilter.Text.Trim)
            dgvApplicants.DataSource = ds
            dgvApplicants.DataMember = ("table")
        ElseIf cbxFilterMode.SelectedIndex = 2 Then
            Dim ds As DataSet = sql.SearchApplByID(txtFilter.Text.Trim)
            dgvApplicants.DataSource = ds
            dgvApplicants.DataMember = ("table")
        End If

    End Sub

    Private Sub frmQlookup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtFilter.Focus()
        cbxFilterMode.SelectedIndex = 0
    End Sub

    Private Sub dgvApplicants_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvApplicants.Click
        btnView.Enabled = True
    End Sub

    Private Sub dgvApplicants_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvApplicants.DoubleClick
        btnView.Enabled = True
    End Sub

    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        DialogResult = DialogResult.OK
    End Sub

    Private Sub btnAllApplicants_Click(sender As Object, e As EventArgs) Handles btnAllApplicants.Click
        'SelectAllApplicants
        Dim ds As DataSet = sql.SelectAllApplicants()
        dgvApplicants.DataSource = ds
        dgvApplicants.DataMember = ("table")
    End Sub
End Class