<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMohSignOff
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMohSignOff))
        Me.dgvBatches = New System.Windows.Forms.DataGridView()
        Me.ApplicantReportViewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.btnSubmit = New System.Windows.Forms.Button()
        Me.btnPrevious = New System.Windows.Forms.Button()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.dgvApplications = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnSubmitAll = New System.Windows.Forms.Button()
        CType(Me.dgvBatches, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvApplications, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvBatches
        '
        Me.dgvBatches.AllowUserToAddRows = False
        Me.dgvBatches.AllowUserToDeleteRows = False
        Me.dgvBatches.AllowUserToResizeRows = False
        Me.dgvBatches.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvBatches.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.dgvBatches.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ActiveCaption
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvBatches.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvBatches.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvBatches.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvBatches.GridColor = System.Drawing.Color.Silver
        Me.dgvBatches.Location = New System.Drawing.Point(12, 31)
        Me.dgvBatches.MultiSelect = False
        Me.dgvBatches.Name = "dgvBatches"
        Me.dgvBatches.ReadOnly = True
        Me.dgvBatches.RowHeadersVisible = False
        Me.dgvBatches.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvBatches.Size = New System.Drawing.Size(621, 220)
        Me.dgvBatches.TabIndex = 13
        '
        'ApplicantReportViewer
        '
        Me.ApplicantReportViewer.ActiveViewIndex = -1
        Me.ApplicantReportViewer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ApplicantReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ApplicantReportViewer.Cursor = System.Windows.Forms.Cursors.Default
        Me.ApplicantReportViewer.DisplayBackgroundEdge = False
        Me.ApplicantReportViewer.DisplayStatusBar = False
        Me.ApplicantReportViewer.DisplayToolbar = False
        Me.ApplicantReportViewer.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ApplicantReportViewer.Location = New System.Drawing.Point(12, 257)
        Me.ApplicantReportViewer.Name = "ApplicantReportViewer"
        Me.ApplicantReportViewer.SelectionFormula = ""
        Me.ApplicantReportViewer.ShowCloseButton = False
        Me.ApplicantReportViewer.ShowGroupTreeButton = False
        Me.ApplicantReportViewer.Size = New System.Drawing.Size(960, 394)
        Me.ApplicantReportViewer.TabIndex = 12
        Me.ApplicantReportViewer.ViewTimeSelectionFormula = ""
        '
        'btnSubmit
        '
        Me.btnSubmit.Enabled = False
        Me.btnSubmit.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnSubmit.Location = New System.Drawing.Point(56, 361)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(108, 38)
        Me.btnSubmit.TabIndex = 10
        Me.btnSubmit.Text = "Process"
        Me.btnSubmit.UseVisualStyleBackColor = True
        '
        'btnPrevious
        '
        Me.btnPrevious.Enabled = False
        Me.btnPrevious.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnPrevious.Location = New System.Drawing.Point(56, 273)
        Me.btnPrevious.Name = "btnPrevious"
        Me.btnPrevious.Size = New System.Drawing.Size(108, 38)
        Me.btnPrevious.TabIndex = 9
        Me.btnPrevious.Text = "Previous"
        Me.btnPrevious.UseVisualStyleBackColor = True
        '
        'btnNext
        '
        Me.btnNext.Enabled = False
        Me.btnNext.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnNext.Location = New System.Drawing.Point(56, 317)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(108, 38)
        Me.btnNext.TabIndex = 8
        Me.btnNext.Text = "Next"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'dgvApplications
        '
        Me.dgvApplications.AllowUserToAddRows = False
        Me.dgvApplications.AllowUserToDeleteRows = False
        Me.dgvApplications.AllowUserToResizeRows = False
        Me.dgvApplications.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvApplications.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.dgvApplications.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ActiveCaption
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvApplications.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvApplications.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvApplications.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgvApplications.GridColor = System.Drawing.Color.Silver
        Me.dgvApplications.Location = New System.Drawing.Point(639, 31)
        Me.dgvApplications.MultiSelect = False
        Me.dgvApplications.Name = "dgvApplications"
        Me.dgvApplications.ReadOnly = True
        Me.dgvApplications.RowHeadersVisible = False
        Me.dgvApplications.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvApplications.Size = New System.Drawing.Size(333, 220)
        Me.dgvApplications.TabIndex = 13
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(8, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 19)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "BATCHES"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(635, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(94, 19)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "APPLICANTS"
        '
        'btnSubmitAll
        '
        Me.btnSubmitAll.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnSubmitAll.Location = New System.Drawing.Point(56, 405)
        Me.btnSubmitAll.Name = "btnSubmitAll"
        Me.btnSubmitAll.Size = New System.Drawing.Size(108, 38)
        Me.btnSubmitAll.TabIndex = 10
        Me.btnSubmitAll.Text = "Process All"
        Me.btnSubmitAll.UseVisualStyleBackColor = True
        '
        'frmMohSignOff
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.AutoScrollMargin = New System.Drawing.Size(10, 10)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(984, 661)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnSubmitAll)
        Me.Controls.Add(Me.btnSubmit)
        Me.Controls.Add(Me.btnPrevious)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.dgvApplications)
        Me.Controls.Add(Me.dgvBatches)
        Me.Controls.Add(Me.ApplicantReportViewer)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(1000, 700)
        Me.Name = "frmMohSignOff"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MO(H) Sign Off"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgvBatches, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvApplications, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvBatches As System.Windows.Forms.DataGridView
    Friend WithEvents ApplicantReportViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents btnSubmit As System.Windows.Forms.Button
    Friend WithEvents btnPrevious As System.Windows.Forms.Button
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents dgvApplications As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents btnSubmitAll As Button
End Class
