Public Class frmBatchRpt
    Dim sql As New SqlClass
    Public batchCode As String

    Private Sub frmBatchRpt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Then
            MsgBox("Please enter a batch code", MsgBoxStyle.Information + vbOKOnly)
            Exit Sub
        Else
            Dim DStarget As New dsBatch
            Dim BatchInfo As New dsBatch.DataTable1DataTable
            Dim dr As dsBatch.DataTable1Row
            Dim rpt As New rptbatch
            Dim reader As System.Data.IDataReader
            reader = sql.GetNamesInBatch(TextBox1.Text.Trim)
            While reader.Read
                dr = BatchInfo.NewDataTable1Row
                With dr
                    .BatchCode = reader("BatchNum")
                    .fname = reader("firstname")
                    .lname = reader("lastname")
                    .PerMitNo = reader("PermitNumber")
                    .Expired = reader("ExpiredDate")
                    .Cat = reader("category")
                End With
                BatchInfo.AddDataTable1Row(dr)

            End While

            With rpt
                .SetDataSource(CType(BatchInfo, DataTable))
            End With
            CrystalReportViewer1.ReportSource = rpt





        End If
    End Sub
End Class