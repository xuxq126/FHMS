Public Class frmFac
    Dim sql As New SqlClass

    Private Sub frmFac_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dataset1 As New System.Data.DataSet
        dataset1 = Sql.getParishes
        With ComboBox1
            .DataSource = dataset1.Tables(0)
            .DisplayMember = "ParishName"
            .ValueMember = "ParishId"
            .SelectedIndex = 0
        End With
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class