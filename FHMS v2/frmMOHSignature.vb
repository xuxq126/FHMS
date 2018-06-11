Public Class frmMOHSignature

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        pbxSignature.Image = Nothing

        If ofdFindSignature.ShowDialog() = Windows.Forms.DialogResult.OK Then
            With pbxSignature
                .Image = Image.FromFile(ofdFindSignature.FileName)
                .SizeMode = PictureBoxSizeMode.StretchImage
            End With
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Me.Close()
    End Sub
End Class