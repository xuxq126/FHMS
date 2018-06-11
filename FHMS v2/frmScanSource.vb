Public Class frmScanSource

    Public s As String
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub RefreshSourceList()
        'dim selectedItem as String 
        Dim n, i As Integer
        Dim S As String, Def As String
        Def = EZTwain.DefaultSourceName
        SourceList.Items.Clear()
        n = EZTwain.GetSourceList()
        Do
            S = EZTwain.NextSourceName()
            If S.Length = 0 Then Exit Do
            i = SourceList.Items.Add(S)
            If S = Def Then
                SourceList.SetSelected(i, True)
            End If
        Loop
    End Sub

    Private Sub frmScanSource_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

    End Sub

    Private Sub frmScanSource_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load



    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        s = sourcelist.Items.Item(sourcelist.SelectedIndex)
        'Return s
    End Sub
End Class