<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUser
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUser))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtfname = New System.Windows.Forms.TextBox()
        Me.txtlname = New System.Windows.Forms.TextBox()
        Me.txtpsw = New System.Windows.Forms.TextBox()
        Me.txtcpsw = New System.Windows.Forms.TextBox()
        Me.cbxUserType = New System.Windows.Forms.ComboBox()
        Me.cbxParish = New System.Windows.Forms.ComboBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(70, 96)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 19)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "First Name:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(71, 127)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 19)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Last Name:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(78, 220)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 19)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Password:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(25, 254)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(123, 19)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Confirm Password:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(76, 285)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(72, 19)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "User Type:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(99, 189)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(49, 19)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Parish:"
        '
        'txtfname
        '
        Me.txtfname.Location = New System.Drawing.Point(154, 93)
        Me.txtfname.Name = "txtfname"
        Me.txtfname.Size = New System.Drawing.Size(140, 25)
        Me.txtfname.TabIndex = 1
        '
        'txtlname
        '
        Me.txtlname.Location = New System.Drawing.Point(154, 124)
        Me.txtlname.Name = "txtlname"
        Me.txtlname.Size = New System.Drawing.Size(140, 25)
        Me.txtlname.TabIndex = 2
        '
        'txtpsw
        '
        Me.txtpsw.Location = New System.Drawing.Point(154, 217)
        Me.txtpsw.MaxLength = 10
        Me.txtpsw.Name = "txtpsw"
        Me.txtpsw.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtpsw.Size = New System.Drawing.Size(140, 25)
        Me.txtpsw.TabIndex = 5
        '
        'txtcpsw
        '
        Me.txtcpsw.Location = New System.Drawing.Point(154, 251)
        Me.txtcpsw.MaxLength = 10
        Me.txtcpsw.Name = "txtcpsw"
        Me.txtcpsw.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtcpsw.Size = New System.Drawing.Size(140, 25)
        Me.txtcpsw.TabIndex = 6
        '
        'cbxUserType
        '
        Me.cbxUserType.FormattingEnabled = True
        Me.cbxUserType.Items.AddRange(New Object() {"Data Entry", "MOH", "PHI", "Trainer", "MIS"})
        Me.cbxUserType.Location = New System.Drawing.Point(154, 282)
        Me.cbxUserType.Name = "cbxUserType"
        Me.cbxUserType.Size = New System.Drawing.Size(140, 25)
        Me.cbxUserType.TabIndex = 6
        '
        'cbxParish
        '
        Me.cbxParish.FormattingEnabled = True
        Me.cbxParish.ItemHeight = 17
        Me.cbxParish.Location = New System.Drawing.Point(154, 186)
        Me.cbxParish.Name = "cbxParish"
        Me.cbxParish.Size = New System.Drawing.Size(140, 25)
        Me.cbxParish.TabIndex = 4
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(120, 15)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(118, 31)
        Me.btnSave.TabIndex = 14
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(244, 15)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(118, 31)
        Me.btnClose.TabIndex = 15
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(300, 93)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(31, 25)
        Me.Button3.TabIndex = 16
        Me.Button3.Text = "?"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.btnClose)
        Me.Panel1.Controls.Add(Me.btnSave)
        Me.Panel1.Location = New System.Drawing.Point(-9, 363)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(386, 84)
        Me.Panel1.TabIndex = 17
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(73, 34)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(187, 30)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Create New User"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(74, 158)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(74, 19)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Username:"
        '
        'txtUsername
        '
        Me.txtUsername.Location = New System.Drawing.Point(154, 155)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(140, 25)
        Me.txtUsername.TabIndex = 3
        '
        'frmUser
        '
        Me.AcceptButton = Me.btnSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(366, 439)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.cbxParish)
        Me.Controls.Add(Me.cbxUserType)
        Me.Controls.Add(Me.txtcpsw)
        Me.Controls.Add(Me.txtpsw)
        Me.Controls.Add(Me.txtUsername)
        Me.Controls.Add(Me.txtlname)
        Me.Controls.Add(Me.txtfname)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmUser"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "New User"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtfname As System.Windows.Forms.TextBox
    Friend WithEvents txtlname As System.Windows.Forms.TextBox
    Friend WithEvents txtpsw As System.Windows.Forms.TextBox
    Friend WithEvents txtcpsw As System.Windows.Forms.TextBox
    Friend WithEvents cbxUserType As System.Windows.Forms.ComboBox
    Friend WithEvents cbxParish As System.Windows.Forms.ComboBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents txtUsername As TextBox
End Class
