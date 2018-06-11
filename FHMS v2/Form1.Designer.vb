<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.txtPermitNo = New System.Windows.Forms.TextBox()
        Me.btnLookupApplicant = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtfname = New System.Windows.Forms.TextBox()
        Me.txtmname = New System.Windows.Forms.TextBox()
        Me.txtlname = New System.Windows.Forms.TextBox()
        Me.dtpDOB = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtage = New System.Windows.Forms.TextBox()
        Me.cmbGender = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtaddress1 = New System.Windows.Forms.TextBox()
        Me.txtAddress2 = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cmbparish = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtempname = New System.Windows.Forms.TextBox()
        Me.txtempaddress1 = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cmbempparish = New System.Windows.Forms.ComboBox()
        Me.chkLiterate = New System.Windows.Forms.CheckBox()
        Me.cbxLiveAbroad = New System.Windows.Forms.CheckBox()
        Me.txtabroadaddress = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtabroadperiod = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.cmbMedicallyAccp = New System.Windows.Forms.ComboBox()
        Me.txtcomments = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtdoctorname = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtdoctorAdd = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.dgvSchedule = New System.Windows.Forms.DataGridView()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.cmbpaid = New System.Windows.Forms.ComboBox()
        Me.btnScanImage = New System.Windows.Forms.Button()
        Me.btnBrowseImage = New System.Windows.Forms.Button()
        Me.btnClearImage = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.txtTelephone = New System.Windows.Forms.MaskedTextBox()
        Me.txtDocTelephone = New System.Windows.Forms.MaskedTextBox()
        Me.txtrecipNo = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.cbxTravelledAbroad = New System.Windows.Forms.CheckBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.MaskedTextBox1 = New System.Windows.Forms.MaskedTextBox()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.pnlScore = New System.Windows.Forms.Panel()
        Me.rdFailed = New System.Windows.Forms.RadioButton()
        Me.rbPassed = New System.Windows.Forms.RadioButton()
        Me.txtScore = New System.Windows.Forms.TextBox()
        Me.lblcategory = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.btnGetCurrentSchedule = New System.Windows.Forms.Button()
        Me.dgvSymptoms = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvTests = New System.Windows.Forms.DataGridView()
        Me.Column3 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.btnRenewPermit = New System.Windows.Forms.Button()
        Me.btnUpdateImage = New System.Windows.Forms.Button()
        Me.btnEditSchedule = New System.Windows.Forms.Button()
        Me.VsTwain1 = New Vintasoft.Twain.VSTwain()
        Me.gpxApplicantPhoto = New System.Windows.Forms.GroupBox()
        Me.pnlAppPhoto = New System.Windows.Forms.Panel()
        Me.appPic = New System.Windows.Forms.PictureBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.cbxNewPermit = New System.Windows.Forms.CheckBox()
        CType(Me.dgvSchedule, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlScore.SuspendLayout()
        CType(Me.dgvSymptoms, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvTests, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxApplicantPhoto.SuspendLayout()
        Me.pnlAppPhoto.SuspendLayout()
        CType(Me.appPic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(104, 218)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Date:"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(145, 214)
        Me.DateTimePicker1.Margin = New System.Windows.Forms.Padding(4)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(160, 25)
        Me.DateTimePicker1.TabIndex = 1
        '
        'txtPermitNo
        '
        Me.txtPermitNo.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPermitNo.Location = New System.Drawing.Point(145, 247)
        Me.txtPermitNo.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPermitNo.MaxLength = 20
        Me.txtPermitNo.Name = "txtPermitNo"
        Me.txtPermitNo.Size = New System.Drawing.Size(160, 25)
        Me.txtPermitNo.TabIndex = 2
        '
        'btnLookupApplicant
        '
        Me.btnLookupApplicant.Location = New System.Drawing.Point(313, 247)
        Me.btnLookupApplicant.Margin = New System.Windows.Forms.Padding(4)
        Me.btnLookupApplicant.Name = "btnLookupApplicant"
        Me.btnLookupApplicant.Size = New System.Drawing.Size(28, 25)
        Me.btnLookupApplicant.TabIndex = 3
        Me.btnLookupApplicant.Text = "?"
        Me.btnLookupApplicant.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(70, 250)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 17)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Permit No:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(66, 282)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 17)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "First Name:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(50, 313)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(92, 17)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Middle Name:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(67, 345)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(75, 17)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Last Name:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(104, 376)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 17)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "DOB:"
        '
        'txtfname
        '
        Me.txtfname.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtfname.Location = New System.Drawing.Point(145, 279)
        Me.txtfname.Margin = New System.Windows.Forms.Padding(4)
        Me.txtfname.MaxLength = 20
        Me.txtfname.Name = "txtfname"
        Me.txtfname.Size = New System.Drawing.Size(160, 25)
        Me.txtfname.TabIndex = 10
        '
        'txtmname
        '
        Me.txtmname.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtmname.Location = New System.Drawing.Point(145, 309)
        Me.txtmname.Margin = New System.Windows.Forms.Padding(4)
        Me.txtmname.MaxLength = 20
        Me.txtmname.Name = "txtmname"
        Me.txtmname.Size = New System.Drawing.Size(160, 25)
        Me.txtmname.TabIndex = 11
        '
        'txtlname
        '
        Me.txtlname.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtlname.Location = New System.Drawing.Point(145, 341)
        Me.txtlname.Margin = New System.Windows.Forms.Padding(4)
        Me.txtlname.MaxLength = 20
        Me.txtlname.Name = "txtlname"
        Me.txtlname.Size = New System.Drawing.Size(160, 25)
        Me.txtlname.TabIndex = 12
        '
        'dtpDOB
        '
        Me.dtpDOB.CalendarFont = New System.Drawing.Font("Segoe UI Semibold", 9.75!)
        Me.dtpDOB.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDOB.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDOB.Location = New System.Drawing.Point(145, 372)
        Me.dtpDOB.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpDOB.Name = "dtpDOB"
        Me.dtpDOB.Size = New System.Drawing.Size(160, 25)
        Me.dtpDOB.TabIndex = 13
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(107, 407)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(35, 17)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Age:"
        '
        'txtage
        '
        Me.txtage.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtage.Location = New System.Drawing.Point(145, 404)
        Me.txtage.Margin = New System.Windows.Forms.Padding(4)
        Me.txtage.MaxLength = 10
        Me.txtage.Name = "txtage"
        Me.txtage.Size = New System.Drawing.Size(58, 25)
        Me.txtage.TabIndex = 15
        '
        'cmbGender
        '
        Me.cmbGender.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbGender.FormattingEnabled = True
        Me.cmbGender.Items.AddRange(New Object() {"Male", "Female"})
        Me.cmbGender.Location = New System.Drawing.Point(145, 434)
        Me.cmbGender.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbGender.Name = "cmbGender"
        Me.cmbGender.Size = New System.Drawing.Size(160, 25)
        Me.cmbGender.TabIndex = 16
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(86, 437)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(56, 17)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "Gender:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(70, 470)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(73, 17)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "Telephone:"
        '
        'txtaddress1
        '
        Me.txtaddress1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtaddress1.Location = New System.Drawing.Point(145, 496)
        Me.txtaddress1.Margin = New System.Windows.Forms.Padding(4)
        Me.txtaddress1.MaxLength = 25
        Me.txtaddress1.Name = "txtaddress1"
        Me.txtaddress1.Size = New System.Drawing.Size(160, 25)
        Me.txtaddress1.TabIndex = 20
        '
        'txtAddress2
        '
        Me.txtAddress2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAddress2.Location = New System.Drawing.Point(145, 526)
        Me.txtAddress2.Margin = New System.Windows.Forms.Padding(4)
        Me.txtAddress2.MaxLength = 25
        Me.txtAddress2.Name = "txtAddress2"
        Me.txtAddress2.Size = New System.Drawing.Size(160, 25)
        Me.txtAddress2.TabIndex = 21
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(74, 500)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(69, 17)
        Me.Label10.TabIndex = 22
        Me.Label10.Text = "Address 1:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(71, 529)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(71, 17)
        Me.Label11.TabIndex = 23
        Me.Label11.Text = "Address 2:"
        '
        'cmbparish
        '
        Me.cmbparish.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbparish.FormattingEnabled = True
        Me.cmbparish.Location = New System.Drawing.Point(145, 557)
        Me.cmbparish.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbparish.Name = "cmbparish"
        Me.cmbparish.Size = New System.Drawing.Size(159, 25)
        Me.cmbparish.TabIndex = 24
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(95, 561)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(48, 17)
        Me.Label12.TabIndex = 25
        Me.Label12.Text = "Parish:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(41, 592)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(102, 17)
        Me.Label13.TabIndex = 26
        Me.Label13.Text = "Emp/Co. Name:"
        '
        'txtempname
        '
        Me.txtempname.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtempname.Location = New System.Drawing.Point(145, 588)
        Me.txtempname.Margin = New System.Windows.Forms.Padding(4)
        Me.txtempname.MaxLength = 25
        Me.txtempname.Name = "txtempname"
        Me.txtempname.Size = New System.Drawing.Size(159, 25)
        Me.txtempname.TabIndex = 27
        '
        'txtempaddress1
        '
        Me.txtempaddress1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtempaddress1.Location = New System.Drawing.Point(145, 618)
        Me.txtempaddress1.Margin = New System.Windows.Forms.Padding(4)
        Me.txtempaddress1.MaxLength = 20
        Me.txtempaddress1.Name = "txtempaddress1"
        Me.txtempaddress1.Size = New System.Drawing.Size(159, 25)
        Me.txtempaddress1.TabIndex = 28
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(73, 621)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(69, 17)
        Me.Label14.TabIndex = 29
        Me.Label14.Text = "Address 1:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(95, 652)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(48, 17)
        Me.Label15.TabIndex = 31
        Me.Label15.Text = "Parish:"
        '
        'cmbempparish
        '
        Me.cmbempparish.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbempparish.FormattingEnabled = True
        Me.cmbempparish.Location = New System.Drawing.Point(145, 649)
        Me.cmbempparish.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbempparish.Name = "cmbempparish"
        Me.cmbempparish.Size = New System.Drawing.Size(160, 25)
        Me.cmbempparish.TabIndex = 30
        '
        'chkLiterate
        '
        Me.chkLiterate.AutoSize = True
        Me.chkLiterate.Location = New System.Drawing.Point(133, 114)
        Me.chkLiterate.Margin = New System.Windows.Forms.Padding(4)
        Me.chkLiterate.Name = "chkLiterate"
        Me.chkLiterate.Size = New System.Drawing.Size(139, 21)
        Me.chkLiterate.TabIndex = 32
        Me.chkLiterate.Text = "Applicant Literate?"
        Me.chkLiterate.UseVisualStyleBackColor = True
        '
        'cbxLiveAbroad
        '
        Me.cbxLiveAbroad.AutoSize = True
        Me.cbxLiveAbroad.Location = New System.Drawing.Point(178, 13)
        Me.cbxLiveAbroad.Margin = New System.Windows.Forms.Padding(4)
        Me.cbxLiveAbroad.Name = "cbxLiveAbroad"
        Me.cbxLiveAbroad.Size = New System.Drawing.Size(138, 21)
        Me.cbxLiveAbroad.TabIndex = 42
        Me.cbxLiveAbroad.Text = "Ever lived abroad?"
        Me.cbxLiveAbroad.UseVisualStyleBackColor = True
        '
        'txtabroadaddress
        '
        Me.txtabroadaddress.Location = New System.Drawing.Point(178, 44)
        Me.txtabroadaddress.Margin = New System.Windows.Forms.Padding(4)
        Me.txtabroadaddress.MaxLength = 25
        Me.txtabroadaddress.Name = "txtabroadaddress"
        Me.txtabroadaddress.Size = New System.Drawing.Size(259, 25)
        Me.txtabroadaddress.TabIndex = 44
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(113, 47)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(60, 17)
        Me.Label16.TabIndex = 45
        Me.Label16.Text = "Address:"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(122, 80)
        Me.Label17.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(50, 17)
        Me.Label17.TabIndex = 46
        Me.Label17.Text = "Period:"
        '
        'txtabroadperiod
        '
        Me.txtabroadperiod.Location = New System.Drawing.Point(178, 77)
        Me.txtabroadperiod.Margin = New System.Windows.Forms.Padding(4)
        Me.txtabroadperiod.MaxLength = 10
        Me.txtabroadperiod.Name = "txtabroadperiod"
        Me.txtabroadperiod.Size = New System.Drawing.Size(177, 25)
        Me.txtabroadperiod.TabIndex = 47
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(31, 325)
        Me.Label18.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(143, 17)
        Me.Label18.TabIndex = 48
        Me.Label18.Text = "Medically Acceptable?:"
        '
        'cmbMedicallyAccp
        '
        Me.cmbMedicallyAccp.FormattingEnabled = True
        Me.cmbMedicallyAccp.Items.AddRange(New Object() {"Yes", "No", "Pending", "refered"})
        Me.cmbMedicallyAccp.Location = New System.Drawing.Point(178, 322)
        Me.cmbMedicallyAccp.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbMedicallyAccp.Name = "cmbMedicallyAccp"
        Me.cmbMedicallyAccp.Size = New System.Drawing.Size(120, 25)
        Me.cmbMedicallyAccp.TabIndex = 49
        '
        'txtcomments
        '
        Me.txtcomments.Location = New System.Drawing.Point(178, 355)
        Me.txtcomments.Margin = New System.Windows.Forms.Padding(4)
        Me.txtcomments.MaxLength = 50
        Me.txtcomments.Multiline = True
        Me.txtcomments.Name = "txtcomments"
        Me.txtcomments.Size = New System.Drawing.Size(306, 73)
        Me.txtcomments.TabIndex = 50
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(96, 358)
        Me.Label19.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(77, 17)
        Me.Label19.TabIndex = 51
        Me.Label19.Text = "Comments:"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(73, 113)
        Me.Label20.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(100, 17)
        Me.Label20.TabIndex = 52
        Me.Label20.Text = "Doctor's Name:"
        '
        'txtdoctorname
        '
        Me.txtdoctorname.Location = New System.Drawing.Point(178, 110)
        Me.txtdoctorname.Margin = New System.Windows.Forms.Padding(4)
        Me.txtdoctorname.MaxLength = 15
        Me.txtdoctorname.Name = "txtdoctorname"
        Me.txtdoctorname.Size = New System.Drawing.Size(259, 25)
        Me.txtdoctorname.TabIndex = 53
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(110, 146)
        Me.Label21.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(60, 17)
        Me.Label21.TabIndex = 54
        Me.Label21.Text = "Address:"
        '
        'txtdoctorAdd
        '
        Me.txtdoctorAdd.Location = New System.Drawing.Point(178, 143)
        Me.txtdoctorAdd.Margin = New System.Windows.Forms.Padding(4)
        Me.txtdoctorAdd.MaxLength = 25
        Me.txtdoctorAdd.Name = "txtdoctorAdd"
        Me.txtdoctorAdd.Size = New System.Drawing.Size(259, 25)
        Me.txtdoctorAdd.TabIndex = 55
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(100, 180)
        Me.Label22.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(73, 17)
        Me.Label22.TabIndex = 56
        Me.Label22.Text = "Telephone:"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label24.Location = New System.Drawing.Point(10, 23)
        Me.Label24.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(162, 21)
        Me.Label24.TabIndex = 60
        Me.Label24.Text = "Schedule Infomation"
        '
        'dgvSchedule
        '
        Me.dgvSchedule.AllowUserToAddRows = False
        Me.dgvSchedule.AllowUserToResizeRows = False
        Me.dgvSchedule.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvSchedule.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.dgvSchedule.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dgvSchedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSchedule.GridColor = System.Drawing.Color.Gainsboro
        Me.dgvSchedule.Location = New System.Drawing.Point(14, 53)
        Me.dgvSchedule.Margin = New System.Windows.Forms.Padding(4)
        Me.dgvSchedule.Name = "dgvSchedule"
        Me.dgvSchedule.ReadOnly = True
        Me.dgvSchedule.Size = New System.Drawing.Size(565, 156)
        Me.dgvSchedule.TabIndex = 61
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(34, 79)
        Me.Label25.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(91, 17)
        Me.Label25.TabIndex = 63
        Me.Label25.Text = "Amount Paid:"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(15, 48)
        Me.Label26.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(110, 17)
        Me.Label26.TabIndex = 64
        Me.Label26.Text = "Receipt Number:"
        '
        'cmbpaid
        '
        Me.cmbpaid.FormattingEnabled = True
        Me.cmbpaid.Location = New System.Drawing.Point(133, 76)
        Me.cmbpaid.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbpaid.Name = "cmbpaid"
        Me.cmbpaid.Size = New System.Drawing.Size(164, 25)
        Me.cmbpaid.TabIndex = 66
        '
        'btnScanImage
        '
        Me.btnScanImage.Location = New System.Drawing.Point(190, 49)
        Me.btnScanImage.Margin = New System.Windows.Forms.Padding(4)
        Me.btnScanImage.Name = "btnScanImage"
        Me.btnScanImage.Size = New System.Drawing.Size(116, 30)
        Me.btnScanImage.TabIndex = 68
        Me.btnScanImage.Text = "Scan Image"
        Me.btnScanImage.UseVisualStyleBackColor = True
        '
        'btnBrowseImage
        '
        Me.btnBrowseImage.Location = New System.Drawing.Point(190, 87)
        Me.btnBrowseImage.Margin = New System.Windows.Forms.Padding(4)
        Me.btnBrowseImage.Name = "btnBrowseImage"
        Me.btnBrowseImage.Size = New System.Drawing.Size(116, 30)
        Me.btnBrowseImage.TabIndex = 69
        Me.btnBrowseImage.Text = "Browse Image"
        Me.btnBrowseImage.UseVisualStyleBackColor = True
        '
        'btnClearImage
        '
        Me.btnClearImage.Location = New System.Drawing.Point(190, 125)
        Me.btnClearImage.Margin = New System.Windows.Forms.Padding(4)
        Me.btnClearImage.Name = "btnClearImage"
        Me.btnClearImage.Size = New System.Drawing.Size(116, 30)
        Me.btnClearImage.TabIndex = 70
        Me.btnClearImage.Text = "Clear Image"
        Me.btnClearImage.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(460, 674)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(100, 30)
        Me.btnSave.TabIndex = 73
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'txtTelephone
        '
        Me.txtTelephone.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTelephone.Location = New System.Drawing.Point(145, 466)
        Me.txtTelephone.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTelephone.Mask = "(999) 000-0000"
        Me.txtTelephone.Name = "txtTelephone"
        Me.txtTelephone.Size = New System.Drawing.Size(160, 25)
        Me.txtTelephone.TabIndex = 74
        '
        'txtDocTelephone
        '
        Me.txtDocTelephone.Location = New System.Drawing.Point(178, 176)
        Me.txtDocTelephone.Margin = New System.Windows.Forms.Padding(4)
        Me.txtDocTelephone.Mask = "(999) 000-0000"
        Me.txtDocTelephone.Name = "txtDocTelephone"
        Me.txtDocTelephone.Size = New System.Drawing.Size(259, 25)
        Me.txtDocTelephone.TabIndex = 75
        '
        'txtrecipNo
        '
        Me.txtrecipNo.Location = New System.Drawing.Point(133, 45)
        Me.txtrecipNo.Margin = New System.Windows.Forms.Padding(4)
        Me.txtrecipNo.MaxLength = 10
        Me.txtrecipNo.Name = "txtrecipNo"
        Me.txtrecipNo.Size = New System.Drawing.Size(164, 25)
        Me.txtrecipNo.TabIndex = 65
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(119, 259)
        Me.Label28.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(51, 17)
        Me.Label28.TabIndex = 76
        Me.Label28.Text = "Where:"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(126, 292)
        Me.Label29.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(47, 17)
        Me.Label29.TabIndex = 77
        Me.Label29.Text = "When:"
        '
        'cbxTravelledAbroad
        '
        Me.cbxTravelledAbroad.AutoSize = True
        Me.cbxTravelledAbroad.Location = New System.Drawing.Point(178, 227)
        Me.cbxTravelledAbroad.Margin = New System.Windows.Forms.Padding(4)
        Me.cbxTravelledAbroad.Name = "cbxTravelledAbroad"
        Me.cbxTravelledAbroad.Size = New System.Drawing.Size(212, 21)
        Me.cbxTravelledAbroad.TabIndex = 78
        Me.cbxTravelledAbroad.Text = "Has Travelled abroad recently?"
        Me.cbxTravelledAbroad.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(178, 256)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(259, 25)
        Me.TextBox1.TabIndex = 79
        '
        'MaskedTextBox1
        '
        Me.MaskedTextBox1.Location = New System.Drawing.Point(178, 289)
        Me.MaskedTextBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.MaskedTextBox1.Mask = "2000"
        Me.MaskedTextBox1.Name = "MaskedTextBox1"
        Me.MaskedTextBox1.Size = New System.Drawing.Size(259, 25)
        Me.MaskedTextBox1.TabIndex = 80
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'pnlScore
        '
        Me.pnlScore.BackColor = System.Drawing.Color.WhiteSmoke
        Me.pnlScore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlScore.Controls.Add(Me.rdFailed)
        Me.pnlScore.Controls.Add(Me.rbPassed)
        Me.pnlScore.Controls.Add(Me.txtScore)
        Me.pnlScore.Controls.Add(Me.lblcategory)
        Me.pnlScore.Location = New System.Drawing.Point(14, 295)
        Me.pnlScore.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlScore.Name = "pnlScore"
        Me.pnlScore.Size = New System.Drawing.Size(565, 60)
        Me.pnlScore.TabIndex = 81
        Me.pnlScore.Visible = False
        '
        'rdFailed
        '
        Me.rdFailed.AutoSize = True
        Me.rdFailed.Location = New System.Drawing.Point(479, 17)
        Me.rdFailed.Margin = New System.Windows.Forms.Padding(4)
        Me.rdFailed.Name = "rdFailed"
        Me.rdFailed.Size = New System.Drawing.Size(61, 21)
        Me.rdFailed.TabIndex = 85
        Me.rdFailed.TabStop = True
        Me.rdFailed.Text = "Failed"
        Me.rdFailed.UseVisualStyleBackColor = True
        '
        'rbPassed
        '
        Me.rbPassed.AutoSize = True
        Me.rbPassed.Location = New System.Drawing.Point(391, 18)
        Me.rbPassed.Margin = New System.Windows.Forms.Padding(4)
        Me.rbPassed.Name = "rbPassed"
        Me.rbPassed.Size = New System.Drawing.Size(68, 21)
        Me.rbPassed.TabIndex = 84
        Me.rbPassed.TabStop = True
        Me.rbPassed.Text = "Passed"
        Me.rbPassed.UseVisualStyleBackColor = True
        '
        'txtScore
        '
        Me.txtScore.Location = New System.Drawing.Point(298, 17)
        Me.txtScore.Margin = New System.Windows.Forms.Padding(4)
        Me.txtScore.Name = "txtScore"
        Me.txtScore.Size = New System.Drawing.Size(69, 25)
        Me.txtScore.TabIndex = 83
        '
        'lblcategory
        '
        Me.lblcategory.AutoSize = True
        Me.lblcategory.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcategory.Location = New System.Drawing.Point(17, 14)
        Me.lblcategory.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblcategory.Name = "lblcategory"
        Me.lblcategory.Size = New System.Drawing.Size(0, 20)
        Me.lblcategory.TabIndex = 82
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(133, 14)
        Me.ComboBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(164, 25)
        Me.ComboBox1.TabIndex = 82
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(72, 17)
        Me.Label23.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(53, 17)
        Me.Label23.TabIndex = 83
        Me.Label23.Text = "Trainer:"
        '
        'btnGetCurrentSchedule
        '
        Me.btnGetCurrentSchedule.Location = New System.Drawing.Point(180, 22)
        Me.btnGetCurrentSchedule.Margin = New System.Windows.Forms.Padding(4)
        Me.btnGetCurrentSchedule.Name = "btnGetCurrentSchedule"
        Me.btnGetCurrentSchedule.Size = New System.Drawing.Size(24, 24)
        Me.btnGetCurrentSchedule.TabIndex = 84
        Me.btnGetCurrentSchedule.Text = "?"
        Me.btnGetCurrentSchedule.UseVisualStyleBackColor = True
        '
        'dgvSymptoms
        '
        Me.dgvSymptoms.AllowUserToAddRows = False
        Me.dgvSymptoms.BackgroundColor = System.Drawing.Color.White
        Me.dgvSymptoms.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvSymptoms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSymptoms.ColumnHeadersVisible = False
        Me.dgvSymptoms.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2})
        Me.dgvSymptoms.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvSymptoms.GridColor = System.Drawing.Color.White
        Me.dgvSymptoms.Location = New System.Drawing.Point(3, 3)
        Me.dgvSymptoms.Margin = New System.Windows.Forms.Padding(4)
        Me.dgvSymptoms.Name = "dgvSymptoms"
        Me.dgvSymptoms.RowHeadersVisible = False
        Me.dgvSymptoms.Size = New System.Drawing.Size(584, 445)
        Me.dgvSymptoms.TabIndex = 85
        '
        'Column1
        '
        Me.Column1.HeaderText = ""
        Me.Column1.Name = "Column1"
        Me.Column1.Width = 50
        '
        'Column2
        '
        Me.Column2.HeaderText = ""
        Me.Column2.Name = "Column2"
        Me.Column2.Width = 400
        '
        'dgvTests
        '
        Me.dgvTests.AllowUserToResizeRows = False
        Me.dgvTests.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvTests.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.dgvTests.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dgvTests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTests.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column3, Me.Column4, Me.Column6, Me.Column5})
        Me.dgvTests.GridColor = System.Drawing.Color.Gainsboro
        Me.dgvTests.Location = New System.Drawing.Point(14, 224)
        Me.dgvTests.Margin = New System.Windows.Forms.Padding(4)
        Me.dgvTests.Name = "dgvTests"
        Me.dgvTests.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dgvTests.Size = New System.Drawing.Size(565, 216)
        Me.dgvTests.TabIndex = 86
        Me.dgvTests.Visible = False
        '
        'Column3
        '
        Me.Column3.FillWeight = 50.0!
        Me.Column3.HeaderText = ""
        Me.Column3.Name = "Column3"
        '
        'Column4
        '
        Me.Column4.FillWeight = 99.49239!
        Me.Column4.HeaderText = "Test Name"
        Me.Column4.Name = "Column4"
        '
        'Column6
        '
        Me.Column6.FillWeight = 50.0!
        Me.Column6.HeaderText = "Score"
        Me.Column6.Name = "Column6"
        '
        'Column5
        '
        Me.Column5.FillWeight = 50.0!
        Me.Column5.HeaderText = "Grade"
        Me.Column5.Name = "Column5"
        Me.Column5.Text = "Grade"
        '
        'btnRenewPermit
        '
        Me.btnRenewPermit.Location = New System.Drawing.Point(426, 19)
        Me.btnRenewPermit.Margin = New System.Windows.Forms.Padding(4)
        Me.btnRenewPermit.Name = "btnRenewPermit"
        Me.btnRenewPermit.Size = New System.Drawing.Size(153, 30)
        Me.btnRenewPermit.TabIndex = 87
        Me.btnRenewPermit.Text = "Renew Permit"
        Me.btnRenewPermit.UseVisualStyleBackColor = True
        Me.btnRenewPermit.Visible = False
        '
        'btnUpdateImage
        '
        Me.btnUpdateImage.Enabled = False
        Me.btnUpdateImage.Location = New System.Drawing.Point(190, 11)
        Me.btnUpdateImage.Margin = New System.Windows.Forms.Padding(4)
        Me.btnUpdateImage.Name = "btnUpdateImage"
        Me.btnUpdateImage.Size = New System.Drawing.Size(116, 30)
        Me.btnUpdateImage.TabIndex = 88
        Me.btnUpdateImage.Text = "Update Image"
        Me.btnUpdateImage.UseVisualStyleBackColor = True
        '
        'btnEditSchedule
        '
        Me.btnEditSchedule.Location = New System.Drawing.Point(265, 19)
        Me.btnEditSchedule.Margin = New System.Windows.Forms.Padding(4)
        Me.btnEditSchedule.Name = "btnEditSchedule"
        Me.btnEditSchedule.Size = New System.Drawing.Size(153, 30)
        Me.btnEditSchedule.TabIndex = 89
        Me.btnEditSchedule.Text = " Update Schedule"
        Me.btnEditSchedule.UseVisualStyleBackColor = True
        Me.btnEditSchedule.Visible = False
        '
        'VsTwain1
        '
        Me.VsTwain1.AllowExceptions = True
        Me.VsTwain1.AppProductName = "VintaSoftTwain.NET"
        Me.VsTwain1.AutoCleanBuffer = True
        Me.VsTwain1.DisableAfterAcquire = False
        Me.VsTwain1.FileFormat = Vintasoft.Twain.FileFormat.Bmp
        Me.VsTwain1.FileName = "c:\test.bmp"
        Me.VsTwain1.IsTwain2Compatible = False
        Me.VsTwain1.JpegQuality = 90
        Me.VsTwain1.MaxImages = 1
        Me.VsTwain1.ModalUI = False
        Me.VsTwain1.Parent = Me
        Me.VsTwain1.PdfImageCompression = Vintasoft.Twain.PdfImageCompression.[Auto]
        Me.VsTwain1.PdfMultiPage = True
        Me.VsTwain1.ShowIndicators = True
        Me.VsTwain1.ShowUI = True
        Me.VsTwain1.TiffCompression = Vintasoft.Twain.TiffCompression.[Auto]
        Me.VsTwain1.TiffMultiPage = True
        Me.VsTwain1.TransferMode = Vintasoft.Twain.TransferMode.Memory
        Me.VsTwain1.TwainDllPath = "C:\Windows\twain_32.dll"
        '
        'gpxApplicantPhoto
        '
        Me.gpxApplicantPhoto.BackColor = System.Drawing.Color.White
        Me.gpxApplicantPhoto.Controls.Add(Me.pnlAppPhoto)
        Me.gpxApplicantPhoto.Controls.Add(Me.DateTimePicker1)
        Me.gpxApplicantPhoto.Controls.Add(Me.Label1)
        Me.gpxApplicantPhoto.Controls.Add(Me.txtPermitNo)
        Me.gpxApplicantPhoto.Controls.Add(Me.btnLookupApplicant)
        Me.gpxApplicantPhoto.Controls.Add(Me.Label2)
        Me.gpxApplicantPhoto.Controls.Add(Me.cbxNewPermit)
        Me.gpxApplicantPhoto.Controls.Add(Me.Label3)
        Me.gpxApplicantPhoto.Controls.Add(Me.Label4)
        Me.gpxApplicantPhoto.Controls.Add(Me.Label5)
        Me.gpxApplicantPhoto.Controls.Add(Me.Label6)
        Me.gpxApplicantPhoto.Controls.Add(Me.txtfname)
        Me.gpxApplicantPhoto.Controls.Add(Me.txtmname)
        Me.gpxApplicantPhoto.Controls.Add(Me.txtlname)
        Me.gpxApplicantPhoto.Controls.Add(Me.dtpDOB)
        Me.gpxApplicantPhoto.Controls.Add(Me.Label7)
        Me.gpxApplicantPhoto.Controls.Add(Me.txtage)
        Me.gpxApplicantPhoto.Controls.Add(Me.txtTelephone)
        Me.gpxApplicantPhoto.Controls.Add(Me.cmbGender)
        Me.gpxApplicantPhoto.Controls.Add(Me.Label8)
        Me.gpxApplicantPhoto.Controls.Add(Me.Label9)
        Me.gpxApplicantPhoto.Controls.Add(Me.txtaddress1)
        Me.gpxApplicantPhoto.Controls.Add(Me.txtAddress2)
        Me.gpxApplicantPhoto.Controls.Add(Me.Label10)
        Me.gpxApplicantPhoto.Controls.Add(Me.Label11)
        Me.gpxApplicantPhoto.Controls.Add(Me.cmbparish)
        Me.gpxApplicantPhoto.Controls.Add(Me.Label12)
        Me.gpxApplicantPhoto.Controls.Add(Me.Label13)
        Me.gpxApplicantPhoto.Controls.Add(Me.txtempname)
        Me.gpxApplicantPhoto.Controls.Add(Me.txtempaddress1)
        Me.gpxApplicantPhoto.Controls.Add(Me.Label14)
        Me.gpxApplicantPhoto.Controls.Add(Me.cmbempparish)
        Me.gpxApplicantPhoto.Controls.Add(Me.Label15)
        Me.gpxApplicantPhoto.Location = New System.Drawing.Point(8, 7)
        Me.gpxApplicantPhoto.Name = "gpxApplicantPhoto"
        Me.gpxApplicantPhoto.Size = New System.Drawing.Size(438, 697)
        Me.gpxApplicantPhoto.TabIndex = 90
        Me.gpxApplicantPhoto.TabStop = False
        Me.gpxApplicantPhoto.Text = "Personal Information"
        '
        'pnlAppPhoto
        '
        Me.pnlAppPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlAppPhoto.Controls.Add(Me.btnUpdateImage)
        Me.pnlAppPhoto.Controls.Add(Me.appPic)
        Me.pnlAppPhoto.Controls.Add(Me.btnScanImage)
        Me.pnlAppPhoto.Controls.Add(Me.btnBrowseImage)
        Me.pnlAppPhoto.Controls.Add(Me.btnClearImage)
        Me.pnlAppPhoto.Location = New System.Drawing.Point(48, 24)
        Me.pnlAppPhoto.Name = "pnlAppPhoto"
        Me.pnlAppPhoto.Size = New System.Drawing.Size(363, 174)
        Me.pnlAppPhoto.TabIndex = 91
        '
        'appPic
        '
        Me.appPic.BackColor = System.Drawing.Color.Transparent
        Me.appPic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.appPic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.appPic.Image = Global.FHMS_v2.My.Resources.Resources.blank
        Me.appPic.InitialImage = Global.FHMS_v2.My.Resources.Resources.blank
        Me.appPic.Location = New System.Drawing.Point(20, 11)
        Me.appPic.Margin = New System.Windows.Forms.Padding(4)
        Me.appPic.Name = "appPic"
        Me.appPic.Size = New System.Drawing.Size(149, 144)
        Me.appPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.appPic.TabIndex = 67
        Me.appPic.TabStop = False
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(456, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(598, 481)
        Me.TabControl1.TabIndex = 91
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.White
        Me.TabPage1.Controls.Add(Me.cbxLiveAbroad)
        Me.TabPage1.Controls.Add(Me.txtabroadaddress)
        Me.TabPage1.Controls.Add(Me.Label16)
        Me.TabPage1.Controls.Add(Me.Label17)
        Me.TabPage1.Controls.Add(Me.txtabroadperiod)
        Me.TabPage1.Controls.Add(Me.Label20)
        Me.TabPage1.Controls.Add(Me.txtdoctorname)
        Me.TabPage1.Controls.Add(Me.Label21)
        Me.TabPage1.Controls.Add(Me.txtdoctorAdd)
        Me.TabPage1.Controls.Add(Me.Label22)
        Me.TabPage1.Controls.Add(Me.MaskedTextBox1)
        Me.TabPage1.Controls.Add(Me.txtDocTelephone)
        Me.TabPage1.Controls.Add(Me.TextBox1)
        Me.TabPage1.Controls.Add(Me.cbxTravelledAbroad)
        Me.TabPage1.Controls.Add(Me.Label18)
        Me.TabPage1.Controls.Add(Me.Label29)
        Me.TabPage1.Controls.Add(Me.cmbMedicallyAccp)
        Me.TabPage1.Controls.Add(Me.Label28)
        Me.TabPage1.Controls.Add(Me.txtcomments)
        Me.TabPage1.Controls.Add(Me.Label19)
        Me.TabPage1.Location = New System.Drawing.Point(4, 26)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(590, 451)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Travel Information"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.dgvSymptoms)
        Me.TabPage2.Location = New System.Drawing.Point(4, 26)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(590, 451)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Symptoms"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.White
        Me.TabPage3.Controls.Add(Me.dgvSchedule)
        Me.TabPage3.Controls.Add(Me.Label24)
        Me.TabPage3.Controls.Add(Me.btnRenewPermit)
        Me.TabPage3.Controls.Add(Me.btnEditSchedule)
        Me.TabPage3.Controls.Add(Me.pnlScore)
        Me.TabPage3.Controls.Add(Me.btnGetCurrentSchedule)
        Me.TabPage3.Controls.Add(Me.dgvTests)
        Me.TabPage3.Location = New System.Drawing.Point(4, 26)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(590, 451)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Schedule Information"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.ComboBox1)
        Me.Panel2.Controls.Add(Me.chkLiterate)
        Me.Panel2.Controls.Add(Me.Label25)
        Me.Panel2.Controls.Add(Me.Label23)
        Me.Panel2.Controls.Add(Me.Label26)
        Me.Panel2.Controls.Add(Me.txtrecipNo)
        Me.Panel2.Controls.Add(Me.cmbpaid)
        Me.Panel2.Location = New System.Drawing.Point(456, 499)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(336, 154)
        Me.Panel2.TabIndex = 92
        '
        'cbxNewPermit
        '
        Me.cbxNewPermit.AutoSize = True
        Me.cbxNewPermit.Checked = True
        Me.cbxNewPermit.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbxNewPermit.Location = New System.Drawing.Point(333, 326)
        Me.cbxNewPermit.Margin = New System.Windows.Forms.Padding(4)
        Me.cbxNewPermit.Name = "cbxNewPermit"
        Me.cbxNewPermit.Size = New System.Drawing.Size(98, 21)
        Me.cbxNewPermit.TabIndex = 5
        Me.cbxNewPermit.Text = "New Permit"
        Me.cbxNewPermit.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AcceptButton = Me.btnSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(1061, 716)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.gpxApplicantPhoto)
        Me.Controls.Add(Me.btnSave)
        Me.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.dgvSchedule, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlScore.ResumeLayout(False)
        Me.pnlScore.PerformLayout()
        CType(Me.dgvSymptoms, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvTests, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxApplicantPhoto.ResumeLayout(False)
        Me.gpxApplicantPhoto.PerformLayout()
        Me.pnlAppPhoto.ResumeLayout(False)
        CType(Me.appPic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtPermitNo As System.Windows.Forms.TextBox
    Friend WithEvents btnLookupApplicant As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtfname As System.Windows.Forms.TextBox
    Friend WithEvents txtmname As System.Windows.Forms.TextBox
    Friend WithEvents txtlname As System.Windows.Forms.TextBox
    Friend WithEvents dtpDOB As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtage As System.Windows.Forms.TextBox
    Friend WithEvents cmbGender As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtaddress1 As System.Windows.Forms.TextBox
    Friend WithEvents txtAddress2 As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cmbparish As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtempname As System.Windows.Forms.TextBox
    Friend WithEvents txtempaddress1 As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cmbempparish As System.Windows.Forms.ComboBox
    Friend WithEvents chkLiterate As System.Windows.Forms.CheckBox
    Friend WithEvents cbxLiveAbroad As System.Windows.Forms.CheckBox
    Friend WithEvents txtabroadaddress As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtabroadperiod As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents cmbMedicallyAccp As System.Windows.Forms.ComboBox
    Friend WithEvents txtcomments As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtdoctorname As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtdoctorAdd As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents dgvSchedule As System.Windows.Forms.DataGridView
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents cmbpaid As System.Windows.Forms.ComboBox
    Friend WithEvents appPic As System.Windows.Forms.PictureBox
    Friend WithEvents btnScanImage As System.Windows.Forms.Button
    Friend WithEvents btnBrowseImage As System.Windows.Forms.Button
    Friend WithEvents btnClearImage As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents txtTelephone As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtDocTelephone As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtrecipNo As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents cbxTravelledAbroad As System.Windows.Forms.CheckBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents MaskedTextBox1 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents pnlScore As System.Windows.Forms.Panel
    Friend WithEvents txtScore As System.Windows.Forms.TextBox
    Friend WithEvents lblcategory As System.Windows.Forms.Label
    Friend WithEvents rdFailed As System.Windows.Forms.RadioButton
    Friend WithEvents rbPassed As System.Windows.Forms.RadioButton
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents btnGetCurrentSchedule As System.Windows.Forms.Button
    Friend WithEvents dgvSymptoms As System.Windows.Forms.DataGridView
    Friend WithEvents dgvTests As System.Windows.Forms.DataGridView
    Friend WithEvents btnRenewPermit As System.Windows.Forms.Button
    Friend WithEvents btnUpdateImage As System.Windows.Forms.Button
    Friend WithEvents btnEditSchedule As System.Windows.Forms.Button
    Friend WithEvents VsTwain1 As Vintasoft.Twain.VSTwain
    Friend WithEvents pnlAppPhoto As Panel
    Friend WithEvents gpxApplicantPhoto As GroupBox
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents Column1 As DataGridViewCheckBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Column3 As DataGridViewCheckBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewLinkColumn
    Friend WithEvents cbxNewPermit As CheckBox
End Class
