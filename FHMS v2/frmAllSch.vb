Public Class frmAllSch
    Dim sql As New SqlClass
    Public itrainID As Integer
    Private Sub frmAllSch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ds As System.Data.DataSet = sql.GetFullSch()
        DataGridView1.DataSource = ds
        DataGridView1.DataMember = ("table")
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        '  itrainID = CInt(DataGridView1.Item(4, DataGridView1.CurrentRow.Index).Value)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        itrainID = CInt(DataGridView1.Item(4, DataGridView1.CurrentRow.Index).Value)
    End Sub
End Class