<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmQlookup
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmQlookup))
        Me.txtFilter = New System.Windows.Forms.TextBox()
        Me.btnLookup = New System.Windows.Forms.Button()
        Me.dgvApplicants = New System.Windows.Forms.DataGridView()
        Me.btnView = New System.Windows.Forms.Button()
        Me.cbxFilterMode = New System.Windows.Forms.ComboBox()
        Me.btnAllApplicants = New System.Windows.Forms.Button()
        CType(Me.dgvApplicants, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtFilter
        '
        Me.txtFilter.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFilter.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFilter.Location = New System.Drawing.Point(159, 10)
        Me.txtFilter.Margin = New System.Windows.Forms.Padding(4)
        Me.txtFilter.Name = "txtFilter"
        Me.txtFilter.Size = New System.Drawing.Size(207, 25)
        Me.txtFilter.TabIndex = 4
        '
        'btnLookup
        '
        Me.btnLookup.Location = New System.Drawing.Point(374, 10)
        Me.btnLookup.Margin = New System.Windows.Forms.Padding(4)
        Me.btnLookup.Name = "btnLookup"
        Me.btnLookup.Size = New System.Drawing.Size(90, 25)
        Me.btnLookup.TabIndex = 8
        Me.btnLookup.Text = "Lookup"
        Me.btnLookup.UseVisualStyleBackColor = True
        '
        'dgvApplicants
        '
        Me.dgvApplicants.AllowUserToAddRows = False
        Me.dgvApplicants.AllowUserToDeleteRows = False
        Me.dgvApplicants.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Lavender
        Me.dgvApplicants.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvApplicants.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvApplicants.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.dgvApplicants.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dgvApplicants.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvApplicants.GridColor = System.Drawing.Color.Gainsboro
        Me.dgvApplicants.Location = New System.Drawing.Point(10, 44)
        Me.dgvApplicants.Margin = New System.Windows.Forms.Padding(4)
        Me.dgvApplicants.MultiSelect = False
        Me.dgvApplicants.Name = "dgvApplicants"
        Me.dgvApplicants.ReadOnly = True
        Me.dgvApplicants.RowHeadersVisible = False
        Me.dgvApplicants.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvApplicants.Size = New System.Drawing.Size(644, 599)
        Me.dgvApplicants.TabIndex = 9
        '
        'btnView
        '
        Me.btnView.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnView.Enabled = False
        Me.btnView.Location = New System.Drawing.Point(577, 10)
        Me.btnView.Margin = New System.Windows.Forms.Padding(4)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(77, 25)
        Me.btnView.TabIndex = 12
        Me.btnView.Text = "View"
        Me.btnView.UseVisualStyleBackColor = True
        '
        'cbxFilterMode
        '
        Me.cbxFilterMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxFilterMode.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxFilterMode.FormattingEnabled = True
        Me.cbxFilterMode.Items.AddRange(New Object() {"Applicant Name", "Employee Name", "Applicant ID"})
        Me.cbxFilterMode.Location = New System.Drawing.Point(10, 10)
        Me.cbxFilterMode.Name = "cbxFilterMode"
        Me.cbxFilterMode.Size = New System.Drawing.Size(142, 25)
        Me.cbxFilterMode.TabIndex = 14
        '
        'btnAllApplicants
        '
        Me.btnAllApplicants.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnAllApplicants.Location = New System.Drawing.Point(471, 10)
        Me.btnAllApplicants.Name = "btnAllApplicants"
        Me.btnAllApplicants.Size = New System.Drawing.Size(99, 25)
        Me.btnAllApplicants.TabIndex = 16
        Me.btnAllApplicants.Text = "Load All"
        Me.btnAllApplicants.UseVisualStyleBackColor = True
        '
        'frmQlookup
        '
        Me.AcceptButton = Me.btnLookup
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(664, 651)
        Me.Controls.Add(Me.btnAllApplicants)
        Me.Controls.Add(Me.cbxFilterMode)
        Me.Controls.Add(Me.txtFilter)
        Me.Controls.Add(Me.btnView)
        Me.Controls.Add(Me.dgvApplicants)
        Me.Controls.Add(Me.btnLookup)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "frmQlookup"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "FHMS v2 Quick search..."
        CType(Me.dgvApplicants, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtFilter As System.Windows.Forms.TextBox
    Friend WithEvents btnLookup As System.Windows.Forms.Button
    Friend WithEvents dgvApplicants As System.Windows.Forms.DataGridView
    Friend WithEvents rbApplicantName As System.Windows.Forms.RadioButton
    Friend WithEvents rbEmployerName As System.Windows.Forms.RadioButton
    Friend WithEvents btnView As System.Windows.Forms.Button
    Friend WithEvents cbxFilterMode As ComboBox
    Friend WithEvents btnAllApplicants As Button
End Class
