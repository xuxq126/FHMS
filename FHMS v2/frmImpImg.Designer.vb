<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImpImg
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmImpImg))
        Me.cmbBatchNum = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnImport = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtpath = New System.Windows.Forms.TextBox()
        Me.btnRestoreTo = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnCancelImport = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.AppPic = New System.Windows.Forms.PictureBox()
        Me.pb1 = New System.Windows.Forms.ProgressBar()
        Me.lblImageLink = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.AppPic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmbBatchNum
        '
        Me.cmbBatchNum.FormattingEnabled = True
        Me.cmbBatchNum.Location = New System.Drawing.Point(99, 17)
        Me.cmbBatchNum.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbBatchNum.Name = "cmbBatchNum"
        Me.cmbBatchNum.Size = New System.Drawing.Size(256, 23)
        Me.cmbBatchNum.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(34, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 15)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Batch No:"
        '
        'btnImport
        '
        Me.btnImport.Location = New System.Drawing.Point(99, 88)
        Me.btnImport.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Size = New System.Drawing.Size(105, 29)
        Me.btnImport.TabIndex = 2
        Me.btnImport.Text = "&Import"
        Me.btnImport.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(28, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 15)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Restore To:"
        '
        'txtpath
        '
        Me.txtpath.Location = New System.Drawing.Point(99, 57)
        Me.txtpath.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtpath.Name = "txtpath"
        Me.txtpath.Size = New System.Drawing.Size(256, 23)
        Me.txtpath.TabIndex = 5
        '
        'btnRestoreTo
        '
        Me.btnRestoreTo.Location = New System.Drawing.Point(359, 56)
        Me.btnRestoreTo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnRestoreTo.Name = "btnRestoreTo"
        Me.btnRestoreTo.Size = New System.Drawing.Size(90, 24)
        Me.btnRestoreTo.TabIndex = 6
        Me.btnRestoreTo.Text = "Browse..."
        Me.btnRestoreTo.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(267, 24)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(87, 26)
        Me.btnClose.TabIndex = 7
        Me.btnClose.Text = "&Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnCancelImport)
        Me.GroupBox1.Controls.Add(Me.btnClose)
        Me.GroupBox1.Location = New System.Drawing.Point(-13, 459)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(477, 63)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        '
        'btnCancelImport
        '
        Me.btnCancelImport.Enabled = False
        Me.btnCancelImport.Location = New System.Drawing.Point(149, 24)
        Me.btnCancelImport.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnCancelImport.Name = "btnCancelImport"
        Me.btnCancelImport.Size = New System.Drawing.Size(99, 26)
        Me.btnCancelImport.TabIndex = 8
        Me.btnCancelImport.Text = "Stop"
        Me.btnCancelImport.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'AppPic
        '
        Me.AppPic.BackColor = System.Drawing.Color.LightGray
        Me.AppPic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.AppPic.Location = New System.Drawing.Point(99, 137)
        Me.AppPic.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.AppPic.Name = "AppPic"
        Me.AppPic.Size = New System.Drawing.Size(256, 256)
        Me.AppPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.AppPic.TabIndex = 3
        Me.AppPic.TabStop = False
        '
        'pb1
        '
        Me.pb1.Location = New System.Drawing.Point(99, 428)
        Me.pb1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pb1.Name = "pb1"
        Me.pb1.Size = New System.Drawing.Size(256, 26)
        Me.pb1.TabIndex = 9
        '
        'lblImageLink
        '
        Me.lblImageLink.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblImageLink.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImageLink.ForeColor = System.Drawing.Color.Blue
        Me.lblImageLink.Location = New System.Drawing.Point(99, 398)
        Me.lblImageLink.Name = "lblImageLink"
        Me.lblImageLink.Size = New System.Drawing.Size(256, 23)
        Me.lblImageLink.TabIndex = 10
        Me.lblImageLink.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmImpImg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(461, 522)
        Me.Controls.Add(Me.lblImageLink)
        Me.Controls.Add(Me.pb1)
        Me.Controls.Add(Me.btnRestoreTo)
        Me.Controls.Add(Me.txtpath)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.AppPic)
        Me.Controls.Add(Me.btnImport)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbBatchNum)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmImpImg"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Image Imports"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.AppPic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmbBatchNum As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnImport As System.Windows.Forms.Button
    Friend WithEvents AppPic As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtpath As System.Windows.Forms.TextBox
    Friend WithEvents btnRestoreTo As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancelImport As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents pb1 As System.Windows.Forms.ProgressBar
    Friend WithEvents lblImageLink As Label
End Class
