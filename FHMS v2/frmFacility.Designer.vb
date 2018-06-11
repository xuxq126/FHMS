<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFacility
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFacility))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbname = New System.Windows.Forms.ComboBox()
        Me.chkreg = New System.Windows.Forms.RadioButton()
        Me.chkonsite = New System.Windows.Forms.RadioButton()
        Me.cmbparish = New System.Windows.Forms.ComboBox()
        Me.btnSaveFacility = New System.Windows.Forms.Button()
        Me.btnNewFacility = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(24, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 19)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Facility Name:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(71, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 19)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Parish:"
        '
        'cmbname
        '
        Me.cmbname.FormattingEnabled = True
        Me.cmbname.Location = New System.Drawing.Point(123, 26)
        Me.cmbname.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbname.Name = "cmbname"
        Me.cmbname.Size = New System.Drawing.Size(220, 25)
        Me.cmbname.TabIndex = 2
        '
        'chkreg
        '
        Me.chkreg.AutoSize = True
        Me.chkreg.Checked = True
        Me.chkreg.Location = New System.Drawing.Point(123, 107)
        Me.chkreg.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chkreg.Name = "chkreg"
        Me.chkreg.Size = New System.Drawing.Size(73, 23)
        Me.chkreg.TabIndex = 4
        Me.chkreg.TabStop = True
        Me.chkreg.Text = "Regular"
        Me.chkreg.UseVisualStyleBackColor = True
        '
        'chkonsite
        '
        Me.chkonsite.AutoSize = True
        Me.chkonsite.Location = New System.Drawing.Point(123, 138)
        Me.chkonsite.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chkonsite.Name = "chkonsite"
        Me.chkonsite.Size = New System.Drawing.Size(67, 23)
        Me.chkonsite.TabIndex = 5
        Me.chkonsite.Text = "Onsite"
        Me.chkonsite.UseVisualStyleBackColor = True
        '
        'cmbparish
        '
        Me.cmbparish.FormattingEnabled = True
        Me.cmbparish.Location = New System.Drawing.Point(123, 59)
        Me.cmbparish.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbparish.Name = "cmbparish"
        Me.cmbparish.Size = New System.Drawing.Size(220, 25)
        Me.cmbparish.TabIndex = 6
        '
        'btnSaveFacility
        '
        Me.btnSaveFacility.Location = New System.Drawing.Point(147, 18)
        Me.btnSaveFacility.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnSaveFacility.Name = "btnSaveFacility"
        Me.btnSaveFacility.Size = New System.Drawing.Size(119, 30)
        Me.btnSaveFacility.TabIndex = 8
        Me.btnSaveFacility.Text = "&Save"
        Me.btnSaveFacility.UseVisualStyleBackColor = True
        '
        'btnNewFacility
        '
        Me.btnNewFacility.Location = New System.Drawing.Point(24, 18)
        Me.btnNewFacility.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnNewFacility.Name = "btnNewFacility"
        Me.btnNewFacility.Size = New System.Drawing.Size(117, 30)
        Me.btnNewFacility.TabIndex = 9
        Me.btnNewFacility.Text = "&New"
        Me.btnNewFacility.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmbname)
        Me.GroupBox1.Controls.Add(Me.chkonsite)
        Me.GroupBox1.Controls.Add(Me.cmbparish)
        Me.GroupBox1.Controls.Add(Me.chkreg)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 8)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(367, 191)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(272, 18)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(119, 30)
        Me.btnClose.TabIndex = 10
        Me.btnClose.Text = "&Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.btnSaveFacility)
        Me.Panel1.Controls.Add(Me.btnClose)
        Me.Panel1.Controls.Add(Me.btnNewFacility)
        Me.Panel1.Location = New System.Drawing.Point(-13, 224)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(415, 100)
        Me.Panel1.TabIndex = 11
        '
        'frmFacility
        '
        Me.AcceptButton = Me.btnSaveFacility
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(391, 310)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmFacility"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Setup Facilities"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbname As System.Windows.Forms.ComboBox
    Friend WithEvents chkreg As System.Windows.Forms.RadioButton
    Friend WithEvents chkonsite As System.Windows.Forms.RadioButton
    Friend WithEvents cmbparish As System.Windows.Forms.ComboBox
    Friend WithEvents btnSaveFacility As System.Windows.Forms.Button
    Friend WithEvents btnNewFacility As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents Panel1 As Panel
End Class
