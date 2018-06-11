Imports System.IO
Imports System.Data.SqlClient
Imports Vintasoft.Twain

Public Class Form1
    Dim Pnum As Integer
    Dim permitNum As String
    Dim SQLHelper As New SqlClass
    Dim hdib As IntPtr

    ' Dim connectionString As String = "data source =system-admin; initial catalog=FHMS2; User Id=sa; password=splus317; Connect Timeout=200; pooling='true'; Max Pool Size=200"
    Private Sub btnLookupApplicant_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLookupApplicant.Click
        If frmQlookup.ShowDialog = DialogResult.OK Then
            txtPermitNo.Text = frmQlookup.ApplicantID

            If (Not String.IsNullOrEmpty(txtPermitNo.Text)) Then
                'clearform()
                ' Applicants Info must be retrieved separately from Doctors Info otherwise both Doctors Info and
                ' Applicants Info must be retrieved.

                PopulateApp()
            End If
            NewApp = False
        End If
        Renewal = False

    End Sub
    Sub PopulateApp()
        Dim reader As SqlDataReader = SQLHelper.SearchGeneralInfo(txtPermitNo.Text)
        If reader.Read() Then
            Try
                txtmname.Text = If(reader("mname") IsNot (DBNull.Value), reader("mname"), String.Empty)
                DateTimePicker1.Value = reader("AppDate")
                txtfname.Text = Trim(reader("fname"))
                txtlname.Text = Trim(reader("lname"))
                dtpDOB.Value = Trim(reader("Dob"))
                txtage.Text = Trim(SQLHelper.GetAge(dtpDOB.Value))
                cmbGender.Text = Trim(reader("gender"))
                txtTelephone.Text = Trim(reader("telephone"))
                txtaddress1.Text = Trim(reader("address1"))
                txtAddress2.Text = Trim(reader("address2"))
                cmbparish.Text = Trim(reader("parish"))
                txtempname.Text = Trim(reader("emp_name"))
                txtempaddress1.Text = Trim(reader("emp_address"))
                cmbempparish.Text = If(reader("emp_parish") IsNot (DBNull.Value), reader("emp_parish"), String.Empty)
                cbxLiveAbroad.CheckState = If(reader("LivedAbroad") IsNot (DBNull.Value), reader("LivedAbroad"), cbxLiveAbroad.CheckState = False)
                txtabroadaddress.Text = Trim(reader("abroadAddress"))
                txtabroadperiod.Text = Trim(reader("livedabroadperiod"))
                cbxTravelledAbroad.CheckState = reader("travelledrecently")
                TextBox1.Text = Trim(reader("travelledwhere"))
                MaskedTextBox1.Text = Trim(reader("travelledWhen"))
                cmbMedicallyAccp.Text = Trim(reader("medicallyAccepted"))
                chkLiterate.CheckState = reader("literate")
                txtdoctorname.Text = Trim(reader("Doctorsname"))
                txtdoctorAdd.Text = Trim(reader("doctorsAddress"))
                txtDocTelephone.Text = Trim(reader("telephoneNo"))
            Catch ex As Exception
            End Try

            LoadMedical()
            'load card history
            LoadCardHistory()
            'card and score info
            ScoreCard()
            pnlScore.Visible = False
            'load images
            LoadPicture()
        End If
    End Sub

    Private Sub dtpDOB_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpDOB.LostFocus
        txtage.Text = SQLHelper.GetAge(dtpDOB.Value)
    End Sub

    Private Sub txtPermitNo_Leave(sender As Object, e As EventArgs) Handles txtPermitNo.Leave
        PopulateApp()
    End Sub

    'Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If cbxNewPermit.Checked = True Then
    '        txtPermitNo.Focus()
    '        txtPermitNo.Enabled = False
    '        NewApp = True
    '        ' clearform()
    '    ElseIf cbxNewPermit.Checked = False Then
    '        txtPermitNo.Enabled = True
    '        NewApp = False

    '    End If
    'End Sub

    Sub ScoreCard()
        'Dim reader As System.Data.IDataReader = sql.GetScoreCard(txtPermitNo.Text.Trim, )
        'If reader.Read Then
        '    txtscore.Text = Trim(reader("Score"))
        '    txtrecipNo.Text = Trim(reader("recNo"))
        '    cmbpaid.Text = FormatCurrency(reader("paid"), 2)
        '    ComboBox1.Text = Trim(reader("trainer"))
        '    Panel1.Visible = True
        'End If
    End Sub
    Sub LoadCardHistory()
        Dim ds As System.Data.DataSet = SQLHelper.GetCardHistory(txtPermitNo.Text.Trim)
        dgvSchedule.DataSource = ds
        dgvSchedule.DataMember = ("table")
        'GetCardHistory
    End Sub
    Sub LoadPicture()
        Using dbConnection As New SqlConnection(SQLHelper.connectionString)
            dbConnection.Open()
            Dim queryString As String = "SELECT Picture FROM ApplicantsInfo WHERE AppID='" & (txtPermitNo.Text.Trim) & "'"
            Dim cmd As New SqlCommand(queryString, dbConnection)
            Dim Picture As Object = cmd.ExecuteScalar()
            Dim bits As Byte() = CType(Picture, Byte())
            Dim memorybits As New MemoryStream(bits)
            Dim bitmap As New Bitmap(memorybits)
            appPic.Image = bitmap
            dbConnection.Close()
        End Using

        appPic.SizeMode = PictureBoxSizeMode.StretchImage
        btnUpdateImage.Enabled = True
    End Sub
    Dim ImageBinary As Byte()

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim HandlerId As Integer = SQLHelper.GetCategoryID(dgvSchedule.Item(2, dgvSchedule.CurrentRow.Index).Value)

        If (Not txtPermitNo.Text.Trim = "") And Renewal = True Then

            'renew permit
            Dim Scheduled As Boolean = SQLHelper.CheckRenewal(txtPermitNo.Text.Trim, CInt(dgvSchedule.Item(4, dgvSchedule.CurrentRow.Index).Value))
            If Scheduled = True Then
                MsgBox("You cannot renew to the same schedule, please select another schedule", MsgBoxStyle.Exclamation + vbOKOnly)
                Exit Sub
            End If

            If txtrecipNo.Text = "" Or txtrecipNo.Text.Trim = "0" Or txtrecipNo.Text.Length < 3 Then
                MsgBox("you entered an invalid Receipt No. please verify and try again", MsgBoxStyle.Critical + vbOKOnly)
                Exit Sub
            End If

            'Dim RecNoExists As Boolean = SQLHelper.CheckRecNo(txtrecipNo.Text.Trim)
            'If RecNoExists Then
            'MsgBox("The receipt number you entered is already in the system, please verify that you have entered the correct one." &" You cannot proceed until you have entered a valid Receipt Number", MsgBoxStyle.Critical + vbOKOnly)

            ' Exit Sub
            ' End If
            If MsgBox("Are you sure you want to renew this permit", MsgBoxStyle.Exclamation + vbOKCancel) = MsgBoxResult.Ok Then
                ImageBinary = SQLHelper.GetImageBytes(appPic.Image)
                updateApp()
                '  sql.UpdatePic(ImageBinary, txtPermitNo.Text.Trim)
                'Dim updateApp As Integer = sql.UpdateAppInfo2(txtPermitNo.Text.Trim, DateTimePicker1.Value, txtfname.Text.Trim, txtmname.Text.Trim, _
                '                                            txtlname.Text.Trim, DateTimePicker2.Value, cmbGender.Text.Trim, _
                '                                            txtTelephone.Text.Trim, txtaddress1.Text.Trim, txtAddress2.Text.Trim, cmbparish.Text.Trim, _
                '                                            txtempname.Text.Trim, txtempaddress1.Text.Trim, cmbempparish.Text.Trim, ImageBinary)

                Dim updateDoc As Integer = SQLHelper.UpateDoctorInfo(TrainID, txtPermitNo.Text.Trim, cbxLiveAbroad.CheckState, txtabroadaddress.Text.Trim, txtabroadperiod.Text.Trim,
                                                           cbxTravelledAbroad.CheckState, TextBox1.Text.Trim, MaskedTextBox1.Text.Trim, cmbMedicallyAccp.Text.Trim, chkLiterate.CheckState,
                                                           txtdoctorname.Text.Trim, txtdoctorAdd.Text.Trim, txtDocTelephone.Text.Trim)

                UpdateMedical()
                Dim SignOff As Integer = SQLHelper.AddToSignOff(TrainID, txtPermitNo.Text.Trim, 0, 0, 0, 0)
                addMedical()

                Select Case type
                    Case 1
                        Dim num2 As Integer = SQLHelper.AddTrainingInfo(TrainID, txtPermitNo.Text.Trim, CInt(txtScore.Text.Trim), lblcategory.Text.Trim, ComboBox1.Text.Trim)
                    Case 2
                        addOnsiteScores()
                End Select
                'Dim score As Integer = sql.AddTrainingInfo(TrainID, txtPermitNo.Text.Trim, CInt(txtscore.Text.Trim), lblcategory.Text.Trim, ComboBox1.Text.Trim)
                Dim cardInfo As Integer = SQLHelper.AddCardInfo(DateTimePicker1.Value, DateTimePicker1.Value.AddYears(1), TrainID, txtPermitNo.Text.Trim, txtrecipNo.Text.Trim, cmbpaid.Text.Trim, HandlerId)
                Dim audit As Integer = SQLHelper.AddAudit(txtPermitNo.Text.Trim, TrainID, Now.Date.Date, String.Format("{0:T}", DateTime.Now), UserID, "Renew")
                'updateApp > 0 And 
                If updateDoc > 0 And SignOff > 0 And cardInfo > 0 Then
                    MsgBox("Card Successfully renewed", MsgBoxStyle.Information + vbOKOnly)
                Else
                    MsgBox("One or Items could not be updated please try again, this time verify that all required information are supplied", MsgBoxStyle.Critical + vbOKOnly)
                    Exit Sub
                End If
            Else
                Exit Sub
            End If

        ElseIf (Not txtPermitNo.Text.Trim = "") And Renewal = False Then
            'Update application
            If SQLHelper.AppExists(txtPermitNo.Text.Trim) = True Then
                'sql.CheckRecNoID

                ImageBinary = SQLHelper.GetImageBytes(appPic.Image)
                updateApp()
                ' sql.UpdatePic(ImageBinary, txtPermitNo.Text.Trim)
                'Dim updateApp As Integer = sql.UpdateAppInfo2(txtPermitNo.Text.Trim, DateTimePicker1.Value, txtfname.Text.Trim, txtmname.Text.Trim, _
                '                                            txtlname.Text.Trim, DateTimePicker2.Value, cmbGender.Text.Trim, _
                '                                            txtTelephone.Text.Trim, txtaddress1.Text.Trim, txtAddress2.Text.Trim, cmbparish.Text.Trim, _
                '                                            txtempname.Text.Trim, txtempaddress1.Text.Trim, cmbempparish.Text.Trim, ImageBinary)

                Dim updateDoc As Integer = SQLHelper.UpateDoctorInfo(TrainID, txtPermitNo.Text.Trim, cbxLiveAbroad.CheckState, txtabroadaddress.Text.Trim, txtabroadperiod.Text.Trim,
                                                           cbxTravelledAbroad.CheckState, TextBox1.Text.Trim, MaskedTextBox1.Text.Trim, cmbMedicallyAccp.Text.Trim, chkLiterate.CheckState,
                                                          txtdoctorname.Text.Trim, txtdoctorAdd.Text.Trim, txtDocTelephone.Text.Trim)
                UpdateMedical()
                Dim audit As Integer = SQLHelper.AddAudit(txtPermitNo.Text.Trim, TrainID, Now.Date.Date, String.Format("{0:T}", DateTime.Now), UserID, "Edit")
                'updateApp > 0 And
                If updateDoc > 0 Then  '("hh:mm tt")
                    MsgBox("Update successfull", MsgBoxStyle.Exclamation + vbOKOnly)
                Else
                    MsgBox("One or Items could not be updated please try again, this time verify that all required information are supplied", MsgBoxStyle.Critical + vbOKOnly)
                    Exit Sub
                End If
            End If

        ElseIf (txtPermitNo.Text.Trim = "") And cbxNewPermit.Checked = True Then

            'add application

            If txtfname.Text = String.Empty Or txtlname.Text = String.Empty Then
                MsgBox("Please enter Applicant first and last name.", MsgBoxStyle.Exclamation + vbOKOnly)
                Exit Sub
            End If

            If CInt(txtage.Text.Trim) < 16 Then
                MsgBox("Applicants must be at least 16 years old!", MsgBoxStyle.Exclamation + vbOKOnly)
                Exit Sub
            End If

            If txtrecipNo.Text = "" Or txtrecipNo.Text.Trim = "0" Or txtrecipNo.Text.Length < 3 Then
                MsgBox("Invalid Receipt Number, please verify and try again.", MsgBoxStyle.Critical + vbOKOnly)
                Exit Sub
            End If

            'Dim RecNoExists As Boolean = SQLHelper.CheckRecNo(txtrecipNo.Text.Trim)
            ' If RecNoExists Then
            'MsgBox("Receipt No. you specify already in the system, please verify that you have entered the correct one." &
            ' " you cannot proceed until you entered a valid Receipt No.", MsgBoxStyle.Critical + vbOKOnly)
            'Exit Sub
            'End If

            createPermitNo()

            ImageBinary = SQLHelper.GetImageBytes(appPic.Image)
            Dim num As Integer = SQLHelper.AddRegApplication(permitNum, DateTimePicker1.Value, txtfname.Text.Trim, txtmname.Text.Trim,
                                                    txtlname.Text.Trim, dtpDOB.Value, cmbGender.Text.Trim,
                                                    txtTelephone.Text.Trim, txtaddress1.Text.Trim, txtAddress2.Text.Trim, cmbparish.Text.Trim,
                                                    txtempname.Text.Trim, txtempaddress1.Text.Trim, cmbempparish.Text.Trim, ImageBinary)
            Dim num1 As Integer = SQLHelper.UpdatePermitNumber(Pnum, ParID)
            addMedical()
            Select Case type
                Case 1
                    Dim num2 As Integer = SQLHelper.AddTrainingInfo(TrainID, permitNum, CInt(txtScore.Text.Trim), lblcategory.Text.Trim, ComboBox1.Text.Trim)
                Case 2
                    addOnsiteScores()
            End Select

            Dim num3 As Integer = SQLHelper.AddToSignOff(TrainID, permitNum, 0, 0, 0, 0)
            Dim num4 As Integer = SQLHelper.AddDoctorsInfo(TrainID, permitNum, cbxLiveAbroad.CheckState, txtabroadaddress.Text.Trim, txtabroadperiod.Text.Trim,
                                                  cbxTravelledAbroad.CheckState, TextBox1.Text.Trim, MaskedTextBox1.Text.Trim, cmbMedicallyAccp.Text.Trim, chkLiterate.CheckState,
                                                  txtdoctorname.Text.Trim, txtdoctorAdd.Text.Trim, txtDocTelephone.Text.Trim)
            Dim num5 As Integer = SQLHelper.AddCardInfo(DateTimePicker1.Value, DateTimePicker1.Value.AddYears(1), TrainID, permitNum, txtrecipNo.Text.Trim, cmbpaid.Text.Trim, HandlerId)

            Dim audit As Integer = SQLHelper.AddAudit(txtPermitNo.Text.Trim, TrainID, Now.Date.Date, String.Format("{0:T}", DateTime.Now), UserID, "New")
            If num > 0 Then
                MsgBox("success", vbOKOnly)
                If MsgBox("Would you like to enter another application now ?", MsgBoxStyle.Information + vbYesNo) = MsgBoxResult.Yes Then
                    ClearForm()
                End If
            End If

        End If

    End Sub
    Sub updateApp()

        Dim cn As SqlConnection = New SqlConnection(SQLHelper.connectionString)
        Dim cmdSave As New SqlCommand("[UpdateApplicants]", cn)
        Dim prmParam As SqlParameter

        With cmdSave
            .CommandType = CommandType.StoredProcedure
            prmParam = New SqlParameter
            prmParam.ParameterName = "@AppID"
            prmParam.DbType = DbType.String
            prmParam.Size = 30
            prmParam.Value = Me.txtPermitNo.Text.Trim
            .Parameters.Add(prmParam)
            prmParam = Nothing

            prmParam = New SqlParameter
            prmParam.ParameterName = "@Apdate"
            prmParam.DbType = DbType.Date
            'prmParam.Size = 10
            prmParam.Value = Me.DateTimePicker1.Value
            .Parameters.Add(prmParam)
            prmParam = Nothing

            prmParam = New SqlParameter
            prmParam.ParameterName = "@fname"
            prmParam.DbType = DbType.String
            prmParam.Size = 15
            prmParam.Value = txtfname.Text.Trim
            .Parameters.Add(prmParam)
            prmParam = Nothing

            prmParam = New SqlParameter
            prmParam.ParameterName = "@mname"
            prmParam.DbType = DbType.String
            prmParam.Size = 15
            prmParam.Value = txtmname.Text.Trim
            .Parameters.Add(prmParam)
            prmParam = Nothing

            prmParam = New SqlParameter
            prmParam.ParameterName = "@lname"
            prmParam.DbType = DbType.String
            prmParam.Size = 15
            prmParam.Value = txtlname.Text.Trim
            .Parameters.Add(prmParam)
            prmParam = Nothing

            prmParam = New SqlParameter
            prmParam.ParameterName = "@dob"
            prmParam.DbType = DbType.Date
            ' prmParam.Size = 15
            prmParam.Value = dtpDOB.Value
            .Parameters.Add(prmParam)
            prmParam = Nothing

            prmParam = New SqlParameter
            prmParam.ParameterName = "@gender"
            prmParam.DbType = DbType.String
            prmParam.Size = 10
            prmParam.Value = cmbGender.Text.Trim
            .Parameters.Add(prmParam)
            prmParam = Nothing

            prmParam = New SqlParameter
            prmParam.ParameterName = "@tel"
            prmParam.DbType = DbType.String
            prmParam.Size = 15
            prmParam.Value = txtTelephone.Text.Trim
            .Parameters.Add(prmParam)
            prmParam = Nothing

            prmParam = New SqlParameter
            prmParam.ParameterName = "@add1"
            prmParam.DbType = DbType.String
            prmParam.Size = 50
            prmParam.Value = txtaddress1.Text.Trim
            .Parameters.Add(prmParam)
            prmParam = Nothing

            prmParam = New SqlParameter
            prmParam.ParameterName = "@add2"
            prmParam.DbType = DbType.String
            prmParam.Size = 50
            prmParam.Value = txtAddress2.Text.Trim
            .Parameters.Add(prmParam)
            prmParam = Nothing

            prmParam = New SqlParameter
            prmParam.ParameterName = "@parish"
            prmParam.DbType = DbType.String
            prmParam.Size = 20
            prmParam.Value = cmbparish.Text.Trim
            .Parameters.Add(prmParam)
            prmParam = Nothing

            prmParam = New SqlParameter
            prmParam.ParameterName = "@empname"
            prmParam.DbType = DbType.String
            prmParam.Size = 20
            prmParam.Value = txtempname.Text.Trim
            .Parameters.Add(prmParam)
            prmParam = Nothing

            prmParam = New SqlParameter
            prmParam.ParameterName = "@empAdd"
            prmParam.DbType = DbType.String
            prmParam.Size = 50
            prmParam.Value = txtempaddress1.Text.Trim
            .Parameters.Add(prmParam)
            prmParam = Nothing

            prmParam = New SqlParameter
            prmParam.ParameterName = "@empparish"
            prmParam.DbType = DbType.String
            prmParam.Size = 50
            prmParam.Value = cmbempparish.Text.Trim
            .Parameters.Add(prmParam)
            prmParam = Nothing



            Try
                If .Connection.State = ConnectionState.Closed Then .Connection.Open()

                If .ExecuteNonQuery() > 0 Then

                    ' Return True
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message) ', ERRORCAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                If .Connection.State = ConnectionState.Open Then .Connection.Close()
            End Try
        End With
        ' Return False

    End Sub


    Public Sub FormatImageParameter(ByRef prmParam As SqlClient.SqlParameter, ByVal img As Image)
        prmParam.SqlDbType = SqlDbType.Image
        prmParam.Value = DBNull.Value

        If Not IsNothing(img) Then
            prmParam.Value = GetImageBytes(img)
        End If
    End Sub
    Public Function GetImageBytes(ByVal img As Image) As Byte()

        If img Is Nothing Then Return Nothing

        Dim bImg() As Byte
        Dim imgLength As ImageConverter

        imgLength = New ImageConverter

        bImg = imgLength.ConvertTo(img, GetType(Byte()))

        Return bImg
    End Function


    Sub addOnsiteScores()
        Dim i As Integer

        For i = 0 To dgvTests.Rows.Count - 1
            If CBool(dgvTests.Rows(i).Cells("column3").Value) = True Then

                ' num = sql.addMedicalCond(TrainID, permitNum, DGVmedical.Rows(i).Cells("column2").Value)
                Dim num As Integer = SQLHelper.AddTrainingInfo(TrainID, txtPermitNo.Text.Trim, dgvTests.Rows(i).Cells("column6").Value, dgvTests.Rows(i).Cells("column4").Value, ComboBox1.Text.Trim)

            End If
        Next

    End Sub
    Sub UpdateOnsiteScores()
        Dim i As Integer

        For i = 0 To dgvTests.Rows.Count - 1
            If CBool(dgvTests.Rows(i).Cells("column3").Value) = True Then

                ' num = sql.addMedicalCond(TrainID, permitNum, DGVmedical.Rows(i).Cells("column2").Value)
                Dim num As Integer = SQLHelper.UpdateTrainingInfo(TrainID, oldTrainID, txtPermitNo.Text.Trim, dgvTests.Rows(i).Cells("column6").Value, dgvTests.Rows(i).Cells("column4").Value, ComboBox1.Text.Trim)

            End If
        Next

    End Sub

    Sub addMedical()
        Dim i As Integer
        Dim num As Integer
        For i = 0 To dgvSymptoms.Rows.Count - 1
            If CBool(dgvSymptoms.Rows(i).Cells("column1").Value) = True Then

                num = SQLHelper.addMedicalCond(TrainID, txtPermitNo.Text.Trim, dgvSymptoms.Rows(i).Cells("column2").Value)

            Else


            End If
        Next

    End Sub
    Sub UpdateMedical()
        Dim i As Integer
        Dim num As Integer
        For i = 0 To dgvSymptoms.Rows.Count - 1
            If CBool(dgvSymptoms.Rows(i).Cells("column1").Value) = True Then
                num = SQLHelper.UpdateHealth(TrainID, txtPermitNo.Text.Trim, dgvSymptoms.Rows(i).Cells("column2").Value)
            Else
            End If
        Next

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        hdib = System.IntPtr.Zero
        NewApp = True
        'clearform()
        loadAppParish()
        loadEmpParish()
        LoadMedical()

        Dim ds As System.Data.DataSet = SQLHelper.GetAllSchedules(Now.Year)
        dgvSchedule.DataSource = ds
        dgvSchedule.DataMember = ("table")

        Dim dsTrainer As System.Data.DataSet = SQLHelper.getTrainers(ParID, 2)

        Dim i As Integer
        For i = 0 To dsTrainer.Tables(0).Rows.Count - 1
            ComboBox1.Items.Add(dsTrainer.Tables(0).Rows(i)("firstname") & " " & dsTrainer.Tables(0).Rows(i)("lastname"))
        Next


    End Sub
    Sub ClearForm()
        loadAppParish()
        loadEmpParish()
        LoadMedical()

        Dim ds As System.Data.DataSet = SQLHelper.GetAllSchedules(Now.Month)
        dgvSchedule.DataSource = ds
        dgvSchedule.DataMember = ("table")
        txtPermitNo.Text = ""
        txtfname.Text = ""
        txtmname.Text = ""
        txtlname.Text = ""
        txtage.Text = ""
        txtTelephone.Text = ""
        txtaddress1.Text = ""
        txtAddress2.Text = ""
        cmbparish.Text = ""
        txtempname.Text = ""
        txtempaddress1.Text = ""
        cmbempparish.Text = ""
        appPic.Image = Nothing
        txtrecipNo.Text = ""
        ComboBox1.Text = ""
        cmbpaid.Text = ""
        chkLiterate.Checked = False
        cbxLiveAbroad.Checked = False
        chkLiterate.Checked = False
        TextBox1.Text = ""
        MaskedTextBox1.Text = ""
        cmbMedicallyAccp.Text = ""
        txtdoctorname.Text = ""
        txtDocTelephone.Text = ""
        txtabroadaddress.Text = ""
        txtabroadperiod.Text = ""
    End Sub

    Sub LoadMedical()
        dgvSymptoms.Rows.Clear()
        With dgvSymptoms
            .Rows.Add()
            .Item(1, 0).Value = "Skin Rash"
            .Rows.Add()
            .Item(1, 1).Value = "Boils or Sores"
            .Rows.Add()
            .Item(1, 2).Value = "Diarrhoea and/or vomitting within the last 7 days"
            .Rows.Add()
            .Item(1, 3).Value = "Discharge from the eyes"
            .Rows.Add()
            .Item(1, 4).Value = "Discharge from the ears"
            .Rows.Add()
            .Item(1, 5).Value = "Discharge from the nose"
            .Rows.Add()
            .Item(1, 6).Value = "Has whitlow"
            .Rows.Add()
            .Item(1, 7).Value = "Condition of hands is unsatisfactory"
            .Rows.Add()
            .Item(1, 8).Value = "Condition of teeth is unsatisfactory"
        End With

        Dim MedReader As SqlDataReader = SQLHelper.gethealth(txtPermitNo.Text.Trim)

        While MedReader.Read()
            For i As Integer = 0 To dgvSymptoms.Rows.Count - 1
                If String.Compare(dgvSymptoms.Rows(i).Cells("column2").Value, MedReader("Condition")) Then
                Else
                    dgvSymptoms.Rows(i).Cells("column1").Value = True
                End If
            Next
        End While
    End Sub

    Sub loadAppParish()
        Dim dataset1 As New System.Data.DataSet
        dataset1 = SQLHelper.getParishes
        With cmbparish
            .DataSource = dataset1.Tables(0)
            .DisplayMember = "ParishName"
            .ValueMember = "ParishId"
            .SelectedIndex = 0
        End With
    End Sub
    Sub loadEmpParish()
        Dim dataset1 As New System.Data.DataSet
        dataset1 = SQLHelper.getParishes
        With cmbempparish
            .DataSource = dataset1.Tables(0)
            .DisplayMember = "ParishName"
            .ValueMember = "ParishId"
            .SelectedIndex = 0
        End With

    End Sub
    Private Sub btnBrowseImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowseImage.Click
        appPic.Image = Nothing

        With OpenFileDialog1
            .Filter = "All Files|*.*|JPEGs|*.jpg|Bitmaps|*.bmp|GIFs|*.gif"
            .FilterIndex = 0
        End With
        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            With appPic
                .Image = Image.FromFile(OpenFileDialog1.FileName)
                .SizeMode = PictureBoxSizeMode.StretchImage
                .BorderStyle = BorderStyle.Fixed3D
            End With
        End If

    End Sub


    Dim cat As String
    Dim type As String
    Private Sub DataGridView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvSchedule.DoubleClick
        If NewApp = True Then
            cat = dgvSchedule.Item(2, dgvSchedule.CurrentRow.Index).Value
            TrainID = CInt(dgvSchedule.Item(4, dgvSchedule.CurrentRow.Index).Value)
            Dim recNo As String = SQLHelper.GetRecNo(TrainID)

            type = SQLHelper.GetTrainingType(TrainID)

            Select Case Trim(type)
                Case 1
                    lblcategory.Text = cat
                    lblcategory.Visible = True
                    pnlScore.Visible = True
                    dgvTests.Visible = False
                    txtrecipNo.Text = ""
                    txtrecipNo.Enabled = True
                Case 2
                    lblcategory.Visible = False
                    pnlScore.Visible = False
                    dgvTests.Visible = True
                    LoadTests()
                    txtrecipNo.Text = Trim(recNo)
                    txtrecipNo.Enabled = False

            End Select






        ElseIf NewApp = False Then

            Dim reader As System.Data.IDataReader = SQLHelper.GetScoreCard(txtPermitNo.Text.Trim, dgvSchedule.Item(4, dgvSchedule.CurrentRow.Index).Value)
            If reader.Read Then
                type = SQLHelper.GetTrainingType(CInt(dgvSchedule.Item(4, dgvSchedule.CurrentRow.Index).Value))
                Select Case type
                    Case 1

                        txtScore.Text = Trim(reader("Score"))
                        txtrecipNo.Text = Trim(reader("recNo"))
                        cmbpaid.Text = FormatCurrency(reader("paid"), 2)
                        ComboBox1.Text = Trim(reader("trainer"))
                        lblcategory.Text = Trim(reader("TestName"))
                        pnlScore.Visible = True
                        btnRenewPermit.Visible = True
                        btnEditSchedule.Visible = True


                    Case 2
                        lblcategory.Visible = False
                        pnlScore.Visible = False
                        dgvTests.Visible = True

                        Dim ds As System.Data.DataSet = SQLHelper.GetScoreDS(txtPermitNo.Text.Trim, dgvSchedule.Item(4, dgvSchedule.CurrentRow.Index).Value)
                        'Dim i As Integer
                        dgvTests.Rows.Add()
                        Dim i As Integer
                        For i = 0 To ds.Tables(0).Rows.Count - 1
                            With dgvTests
                                .Rows.Add()
                                .Item(1, i).Value = ds.Tables(0).Rows(i).Item("TestName")
                                '.Item(1, i).Value = reader.Item(i)("Score")
                                .Rows.Add()
                            End With
                            If String.Compare(dgvTests.Rows(i).Cells("column4").Value, ds.Tables(0).Rows(i).Item("TestName")) Then
                            Else
                                dgvTests.Rows(i).Cells("column3").Value = True
                            End If
                        Next

                        txtrecipNo.Text = Trim(reader("recNo"))
                        cmbpaid.Text = FormatCurrency(reader("paid"), 2)
                        ComboBox1.Text = Trim(reader("trainer"))
                        btnRenewPermit.Visible = True
                        btnEditSchedule.Visible = True

                End Select

            End If


        End If

    End Sub
    Sub LoadTestsResult()
        Dim ds As System.Data.DataSet = SQLHelper.GetTests
        Dim i As Integer
        dgvTests.Rows.Add()
        For i = 0 To ds.Tables(0).Rows.Count - 1
            With dgvTests
                .Rows.Add()
                .Item(1, i).Value = ds.Tables(0).Rows(i).Item("TestName")
                .Rows.Add()
            End With
        Next

    End Sub
    Sub LoadTests()
        Dim ds As System.Data.DataSet = SQLHelper.GetTests
        Dim i As Integer
        dgvTests.Rows.Add()
        For i = 0 To ds.Tables(0).Rows.Count - 1
            With dgvTests
                .Rows.Add()
                .Item(1, i).Value = ds.Tables(0).Rows(i).Item("TestName")
                .Rows.Add()
            End With
        Next

    End Sub



    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtScore.TextChanged
        If Val(txtScore.Text) >= 70 Then
            'pass
            rbPassed.Checked = True
            rdFailed.Checked = False
        Else
            'fail
            rbPassed.Checked = False
            rdFailed.Checked = True
        End If
    End Sub

    Function createPermitNo() As String
        Dim reader As System.Data.IDataReader
        Dim Pinfo As String
        Dim appdate As Date

        reader = SQLHelper.getPermitINfo(ParID)  'collects permit number from database to be used for permit number creation

        'GET application number from database
        If reader.Read Then
            Pinfo = reader.Item("PermitCode") ' first part of the application number
            Pnum = reader.Item("Range") + 1 ' the number itself
        Else
            MsgBox("please configure permit number codes, then try again", MsgBoxStyle.Critical + vbOKOnly)
            Me.Dispose()

        End If

        'testing the number  not needed.. please remove
        Dim te As String
        te = Pinfo & Pnum
        appdate = DateTimePicker1.Text


        permitNum = Trim(Pinfo.Trim & appdate.ToString("yy") & appdate.ToString("MM") & Pnum)
        txtPermitNo.Text = permitNum

    End Function

    Private Sub btnRenewPermit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRenewPermit.Click

        Renewal = True
        Dim ds As System.Data.DataSet = SQLHelper.GetAllSchedules(Now.Month)
        dgvSchedule.DataSource = ds
        dgvSchedule.DataMember = ("table")
        pnlScore.Visible = False
        dgvTests.Visible = False
        NewApp = True

    End Sub

    Public oldTrainID As Integer = Nothing

    Private Sub btnGetCurrentSchedule_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetCurrentSchedule.Click
        oldTrainID = dgvSchedule.Item(4, dgvSchedule.CurrentRow.Index).Value

        Dim frm As New frmAllSch
        If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim ds As System.Data.DataSet = SQLHelper.GetCurrSchedule(frm.itrainID)
            dgvSchedule.DataSource = ds
            dgvSchedule.DataMember = ("table")
            txtScore.Text = ""
        End If

        NewApp = True
        'End If
        Renewal = False
    End Sub

    Private Sub btnUpdateImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdateImage.Click
        ImageBinary = SQLHelper.GetImageBytes(appPic.Image)
        If SQLHelper.UpdatePic(ImageBinary, txtPermitNo.Text.Trim) = True Then
            MsgBox("Image Update Sucessfully", MsgBoxStyle.Information + vbOKOnly)
        End If
    End Sub

    Private Sub VSTwain1_ImageAcquired(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VsTwain1.ImageAcquired
        If Not (appPic.Image Is Nothing) Then
            appPic.Image.Dispose()
            appPic.Image = Nothing
        End If
        appPic.Image = VsTwain1.GetCurrentImage
    End Sub

    Private Sub VSTwain1_ScanCompleted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VsTwain1.ScanCompleted
        If VsTwain1.ErrorCode <> Vintasoft.Twain.ErrorCode.None Then
            MsgBox(VsTwain1.ErrorString)
        Else
            MsgBox("Scan completed.")
        End If
    End Sub




    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSchedule.CellContentClick

    End Sub

    Private Sub btnedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditSchedule.Click

        If txtrecipNo.Text = "" Or txtrecipNo.Text.Trim = "0" Or txtrecipNo.Text.Length < 3 Then
            MsgBox("you entered an invalid Receipt No. please verify and try again", MsgBoxStyle.Critical + vbOKOnly)
            Exit Sub
        End If
        Dim oTrainID As Integer

        If oldTrainID = Nothing Then
            oTrainID = CInt(dgvSchedule.Item(4, dgvSchedule.CurrentRow.Index).Value)
        Else

            oTrainID = oldTrainID
        End If

        TrainID = CInt(dgvSchedule.Item(4, dgvSchedule.CurrentRow.Index).Value)
        'Dim recNo As String = sql.GetRecNo(TrainID)

        type = SQLHelper.GetTrainingType(TrainID)

        Select Case type
            Case 1
                Dim num2 As Integer = SQLHelper.UpdateTrainingInfo(TrainID, oTrainID, txtPermitNo.Text.Trim, CInt(txtScore.Text.Trim), lblcategory.Text.Trim, ComboBox1.Text.Trim)
            Case 2
                UpdateOnsiteScores()
        End Select

        'UpdateCardInfo
        Dim HandlerId As Integer = SQLHelper.GetCategoryID(dgvSchedule.Item(2, dgvSchedule.CurrentRow.Index).Value)
        Dim num As Integer = SQLHelper.UpdateCardInfo(DateTimePicker1.Value, DateTimePicker1.Value.AddYears(1), TrainID, oTrainID, txtPermitNo.Text.Trim, txtrecipNo.Text.Trim, cmbpaid.Text.Trim, HandlerId)
        If num > 0 Then
            MsgBox("Schedule Updated", MsgBoxStyle.Information + vbOKOnly)
            NewApp = False
            PopulateApp()

        End If



    End Sub



    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnScanImage.Click
        Try
            VsTwain1.StartDevice()
            If VsTwain1.SelectSource() Then
                VsTwain1.ShowUI = True
                VsTwain1.DisableAfterAcquire = False
                VsTwain1.Acquire()
            End If
        Catch ex As TwainException
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnGetCurrentScheduleClick(sender As Object, e As EventArgs) Handles btnGetCurrentSchedule.Click

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub txtrecipNo_TextChanged(sender As Object, e As EventArgs) Handles txtrecipNo.TextChanged

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles cbxNewPermit.CheckedChanged

    End Sub
End Class
