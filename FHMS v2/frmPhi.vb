Public Class frmPhi
    Dim sql As New SqlClass
    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked = True Then

            Dim ds As New System.Data.DataSet
            ds = sql.SelectFacilities(1, ParishID)
            With ComboBox1
                .DataSource = ds.Tables(0)
                .DisplayMember = "FacilityName"
                .ValueMember = "FacId"
                .SelectedIndex = 0
            End With


        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked = True Then

            Dim ds As New System.Data.DataSet
            ds = sql.SelectFacilities(2, ParishID)
            With ComboBox1
                .DataSource = ds.Tables(0)
                .DisplayMember = "FacilityName"
                .ValueMember = "FacId"
                .SelectedIndex = 0
            End With


        End If
    End Sub

    Private Sub frmPhi_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ds As New System.Data.DataSet
        Dim years As System.Data.IDataReader
        ds = sql.AllFacilities
        With ComboBox1
            .DataSource = ds.Tables(0)
            .DisplayMember = "FacilityName"
            .ValueMember = "FacId"
            .SelectedIndex = 0
        End With
        years = sql.Years()
        While years.Read
            ComboBox3.Items.Add(years("syear"))
        End While
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If ComboBox1.Text = "" Or ComboBox2.Text = "" Or ComboBox3.Text = "" Then
            MsgBox("Please enter all field", MsgBoxStyle.Information + vbOKOnly)
            Exit Sub
        Else
            Dim month As Integer
            Select Case ComboBox2.Text.Trim
                Case "January"
                    month = 1
                Case "Febuary"
                    month = 2
                Case "March"
                    month = 3
                Case "April"
                    month = 4
                Case "May"
                    month = 5
                Case "June"
                    month = 6
                Case "July"
                    month = 7
                Case "August"
                    month = 8
                Case "September"
                    month = 9
                Case "October"
                    month = 10
                Case "November"
                    month = 11
                Case "December"
                    month = 12
            End Select

            Dim ds As System.Data.DataSet = sql.SearchSchedules(ComboBox1.SelectedValue, month, CInt(ComboBox3.Text.Trim))
            If ds.Tables(0).Rows.Count = 0 Then

                MsgBox("no schedules found for the period", MsgBoxStyle.Information + vbOKOnly)
                Exit Sub
            Else
                DataGridView1.DataSource = ds
                DataGridView1.DataMember = ("table")

            End If
        End If
    End Sub

    

    Private Sub DataGridView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.DoubleClick
        TrainerID = CInt(DataGridView1.Item(4, DataGridView1.CurrentRow.Index).Value)
        Dim ds As System.Data.DataSet = sql.SearchDataEntry(TrainerID)
        DataGridView2.DataSource = ds
        DataGridView2.DataMember = ("table")



    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class