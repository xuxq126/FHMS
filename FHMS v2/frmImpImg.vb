Imports System.IO

Public Class frmImpImg
    Dim clsReview As New ClassReview

    Private Sub frmImpImg_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pb1.Value = 0
        pb1.Step = 1

        Dim reader As System.Data.IDataReader
        reader = clsReview.GetBatchCodes()
        While reader.Read()
            cmbBatchNum.Items.Add(reader("batchNum"))
        End While

        cmbBatchNum.SelectedIndex = 0
    End Sub

    Private Sub btnRestoreTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRestoreTo.Click
        FolderBrowserDialog1.Description = "Select a Folder"
        FolderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer

        If FolderBrowserDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtpath.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Dim CancelImport As Boolean = False

    Private Sub btnImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImport.Click
        If String.IsNullOrEmpty(txtpath.Text) Or String.IsNullOrEmpty(cmbBatchNum.Text) Then
            MessageBox.Show("Please ensure the batch number and restore to path is set.", "Values not set", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Dim count As Integer = 0
        Dim filename As String
        Dim ImagesDataset As DataSet

        Try
            ImagesDataset = clsReview.GetImages(cmbBatchNum.Text.Trim(",.&*#`!@$%^()+{}|\'<>/~".ToCharArray()))
        Catch ex As Exception
            MessageBox.Show("Sorry, could not retrieve image from database. Please try again.", "Could not retrieve image", MessageBoxButtons.OK, MessageBoxIcon.Error)
            btnCancelImport.Enabled = False
            Exit Sub
        End Try

        If ImagesDataset.Tables(0).Rows.Count = 0 Then
            MessageBox.Show("No images found for this batch.", "Import Image", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            btnCancelImport.Enabled = False
            Exit Sub
        Else
            btnCancelImport.Enabled = True
            pb1.Maximum = ImagesDataset.Tables(0).Rows.Count

            For count = 0 To ImagesDataset.Tables(0).Rows.Count - 1
                If CancelImport Then Exit For

                ' Retrieves image from database, converts it to bytes and assigns to PictureBox
                ' for viewing.
                Dim imgdata As Byte() = CType(ImagesDataset.Tables(0).Rows(count)("picture"), Byte())
                AppPic.Image = Image.FromStream(New MemoryStream(imgdata))

                ' In order to use filename from path, this extracts the drive letter which
                ' is always the first three characters in the path
                filename = ImagesDataset.Tables(0).Rows(count).Item("path").ToString.Remove(0, 3)
                lblImageLink.Text = filename
                Try
                    'Saves file to path selected
                    File.WriteAllBytes(txtpath.Text + "\" + filename, imgdata)
                    pb1.PerformStep()
                Catch ex As Exception

                End Try
            Next

            MessageBox.Show("All images imported succesfully.", "Import Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        btnCancelImport.Enabled = False
    End Sub
    Public Function GetImageBytes(ByVal img As Image) As Byte()

        If img Is Nothing Then Return Nothing

        Dim bImg() As Byte
        Dim imgLength As ImageConverter

        imgLength = New ImageConverter

        bImg = imgLength.ConvertTo(img, GetType(Byte()))

        Return bImg
    End Function

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnCancelImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelImport.Click
        CancelImport = True
    End Sub

    Private Sub lblImageLink_Click(sender As Object, e As EventArgs) Handles lblImageLink.Click
        Diagnostics.Process.Start("explorer.exe", txtpath.Text)
    End Sub
End Class