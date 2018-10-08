Imports System.Windows.Forms

Public Class Main

   

    Private Sub OpenFile(ByVal sender As Object, ByVal e As EventArgs)
        Dim OpenFileDialog As New OpenFileDialog
        OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        OpenFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
        If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = OpenFileDialog.FileName
            ' TODO: Add code here to open the file.
        End If
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim SaveFileDialog As New SaveFileDialog
        SaveFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        SaveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"

        If (SaveFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = SaveFileDialog.FileName
            ' TODO: Add code here to save the current contents of the form to a file.
        End If
    End Sub


    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ExitToolStripMenuItem.Click
        Global.System.Windows.Forms.Application.Exit()
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        'Use My.Computer.Clipboard.GetText() or My.Computer.Clipboard.GetData to retrieve information from the clipboard.
    End Sub


    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticleToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Close all child forms of the parent.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private m_ChildFormNumber As Integer = 0

    Private Sub RegularApplicationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frm As New Form1
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub RegularToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub OptionsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptionsToolStripMenuItem.Click

    End Sub

    Private Sub UserSetupToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserSetupToolStripMenuItem.Click
        Dim frm As New frmUser
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub Main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Login.IsLoggedIn = False
        Login.ShowDialog()

        If Login.IsLoggedIn = False Then
            Application.Exit()
        End If

        Select Case AccessLevel
            Case 0
                NewToolStripMenuItem.Enabled = True ' new
                ToolsMenu.Enabled = False
                PHIToolStripMenuItem.Enabled = True
                MOHMenu.Enabled = False
            Case 1 'MOH Access Level?
                NewToolStripMenuItem.Enabled = False
                MOHMenu.Enabled = True
                ToolsMenu.Enabled = False
                PHIToolStripMenuItem.Enabled = False
            Case 2 'Data Entry and PHI Access
                NewToolStripMenuItem.Enabled = True
                MOHMenu.Enabled = False
                ToolsMenu.Enabled = True
                PHIToolStripMenuItem.Enabled = True
            Case 3 'PHI Access Level
                NewToolStripMenuItem.Enabled = False
                MOHMenu.Enabled = False
                ToolsMenu.Enabled = False
                PHIToolStripMenuItem.Enabled = True
            Case 4 'Administrator
                NewToolStripMenuItem.Enabled = True
                MOHMenu.Enabled = True
                ToolsMenu.Enabled = True
                PHIToolStripMenuItem.Enabled = True
        End Select
    End Sub

    Private Sub NewWindowToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewWindowToolStripMenuItem.Click
        Dim frm As New frmMohSignOff
        frm.MdiParent = Me
        SignedbyMOH = 0
        Reviewed = 1
        frm.Show()


    End Sub

    Private Sub ApplicationStatusToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ApplicationStatusToolStripMenuItem.Click
        Dim frm As New frmPhi
        frm.MdiParent = Me
        frm.Show()

    End Sub

    Private Sub BatchCreationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BatchCreationToolStripMenuItem.Click
        Dim frm As New frmBatch
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub BatchSheetToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BatchSheetToolStripMenuItem.Click
        Dim frm As New frmBatchRpt
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub SignOffStatusToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SignOffStatusToolStripMenuItem.Click
        Dim frm As New frmMohSignOff
        frm.MdiParent = Me
        SignedbyMOH = 0
        Reviewed = 0
        frm.Show()
        
    End Sub

    Private Sub ContentsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContentsToolStripMenuItem.Click

    End Sub

    Private Sub ImportImagesForPrintToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportImagesForPrintToolStripMenuItem.Click
        Dim frm As New frmImpImg
        frm.MdiParent = Me
        frm.Show()

    End Sub

   

    Private Sub ScheduleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ScheduleToolStripMenuItem.Click
        Dim frm As New frmRegSchedule
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub OnsiteApplicationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OnsiteApplicationToolStripMenuItem.Click
        Dim frm As New Form1
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem3.Click
        Call Main_Load(sender, e)

    End Sub

    Private Sub ToolsMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolsMenu.Click

    End Sub

    Private Sub BatchCreationToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BatchCreationToolStripMenuItem1.Click
        Dim frm As New frmBatch
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub FacilitySetupToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FacilitySetupToolStripMenuItem.Click
        Dim frm As New frmFacility
        frm.Owner = Me.Owner
        frm.Show()
    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        Dim frm As New frmCategory
        frm.Owner = Me.Owner
        frm.Show()
    End Sub
End Class
