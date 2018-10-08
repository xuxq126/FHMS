Imports System.IO
Imports System.Data.SqlClient
Imports Vintasoft.Twain

Public Class Form1
    Dim NextPermitNumber As Integer
    Dim PermitNumber As String
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
            NewApplication = False
        End If
        ApplicationRenewal = False

    End Sub

    Sub PopulateApp()
        Dim reader As SqlDataReader = SQLHelper.SearchGeneralInfo(txtPermitNo.Text)
        If reader.Read() Then
            Try
                txtmname.Text = If(reader("mname") IsNot (DBNull.Value), reader("mname"), String.Empty)
                dtpApplicationDate.Value = reader("AppDate")
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
        'Save Personal Info


        'Save Travel Information
        'Save Symptoms
        'Save Schedule Information
        'Save Meta Info

    End Sub

    Sub UpdateApplication()
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
            prmParam.Value = Me.dtpApplicationDate.Value
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
                Dim num As Integer = SQLHelper.AddTrainingInfo(TrainerID, txtPermitNo.Text.Trim, dgvTests.Rows(i).Cells("column6").Value, dgvTests.Rows(i).Cells("column4").Value, ComboBox1.Text.Trim)

            End If
        Next

    End Sub
    Sub UpdateOnsiteScores()
        Dim i As Integer

        For i = 0 To dgvTests.Rows.Count - 1
            If CBool(dgvTests.Rows(i).Cells("column3").Value) = True Then

                ' num = sql.addMedicalCond(TrainID, permitNum, DGVmedical.Rows(i).Cells("column2").Value)
                Dim num As Integer = SQLHelper.UpdateTrainingInfo(TrainerID, oldTrainID, txtPermitNo.Text.Trim, dgvTests.Rows(i).Cells("column6").Value, dgvTests.Rows(i).Cells("column4").Value, ComboBox1.Text.Trim)

            End If
        Next

    End Sub

    Sub addMedical()
        Dim i As Integer
        Dim num As Integer
        For i = 0 To dgvSymptoms.Rows.Count - 1
            If CBool(dgvSymptoms.Rows(i).Cells("column1").Value) = True Then

                num = SQLHelper.addMedicalCond(TrainerID, txtPermitNo.Text.Trim, dgvSymptoms.Rows(i).Cells("column2").Value)

            Else


            End If
        Next

    End Sub
    Sub UpdateMedical()
        Dim i As Integer
        Dim num As Integer
        For i = 0 To dgvSymptoms.Rows.Count - 1
            If CBool(dgvSymptoms.Rows(i).Cells("column1").Value) = True Then
                num = SQLHelper.UpdateHealth(TrainerID, txtPermitNo.Text.Trim, dgvSymptoms.Rows(i).Cells("column2").Value)
            Else
            End If
        Next

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        hdib = System.IntPtr.Zero
        NewApplication = True
        'clearform()
        loadAppParish()
        loadEmpParish()
        LoadMedical()

        Dim ds As System.Data.DataSet = SQLHelper.GetAllSchedules(Now.Year)
        dgvSchedule.DataSource = ds
        dgvSchedule.DataMember = ("table")

        Dim dsTrainer As System.Data.DataSet = SQLHelper.getTrainers(ParishID, 2)

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
        txtReceiptNumber.Text = ""
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
            .Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.bmp, *.png, *.gif) | *.jpg; *.jpeg; *.jpe; *.bmp; *.png; *.gif"
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
    Private Sub dgvSchedule_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvSchedule.DoubleClick
        If NewApplication = True Then
            cat = dgvSchedule.Item(2, dgvSchedule.CurrentRow.Index).Value
            TrainerID = CInt(dgvSchedule.Item(4, dgvSchedule.CurrentRow.Index).Value)
            Dim recNo As String = SQLHelper.GetRecNo(TrainerID)

            type = SQLHelper.GetTrainingType(TrainerID)

            Select Case Trim(type)
                Case 1
                    lblcategory.Text = cat
                    lblcategory.Visible = True
                    pnlScore.Visible = True
                    dgvTests.Visible = False
                    txtReceiptNumber.Text = ""
                    txtReceiptNumber.Enabled = True
                Case 2
                    lblcategory.Visible = False
                    pnlScore.Visible = False
                    dgvTests.Visible = True
                    LoadTests()
                    txtReceiptNumber.Text = Trim(recNo)
                    txtReceiptNumber.Enabled = False

            End Select

        ElseIf NewApplication = False Then
            Dim reader As System.Data.IDataReader = SQLHelper.GetScoreCard(txtPermitNo.Text.Trim, dgvSchedule.Item(4, dgvSchedule.CurrentRow.Index).Value)
            If reader.Read Then
                type = SQLHelper.GetTrainingType(CInt(dgvSchedule.Item(4, dgvSchedule.CurrentRow.Index).Value))
                Select Case type
                    Case 1

                        txtScore.Text = Trim(reader("Score"))
                        txtReceiptNumber.Text = Trim(reader("recNo"))
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

                        txtReceiptNumber.Text = Trim(reader("recNo"))
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

    Function CreatePermitNo() As String
        Dim reader As System.Data.IDataReader
        Dim PermitCode As String
        Dim ApplicationDate As Date

        Try
            reader = SQLHelper.getPermitInfo(ParishID)         'collects permit number from database to be used for permit number creation

            'GET application number from database
            If reader.Read Then
                PermitCode = reader.Item("PermitCode")      ' first part of the application number
                NextPermitNumber = reader.Item("Range") + 1 ' the number itself

                ApplicationDate = dtpApplicationDate.Text

                PermitNumber = Trim(PermitCode.Trim & ApplicationDate.ToString("yy") & ApplicationDate.ToString("MM") & NextPermitNumber)
                'txtPermitNo.Text = PermitNumber
            Else
                MsgBox("Please configure Permit Number codes and try again.", MsgBoxStyle.Critical + vbOKOnly)
                Exit Function
            End If
        Catch ex As Exception
            MessageBox.Show("An error occurred. Details: " & ex.Message)
            Exit Function
        End Try

        Return PermitNumber
    End Function

    Private Sub btnRenewPermit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRenewPermit.Click

        ApplicationRenewal = True
        Dim ds As System.Data.DataSet = SQLHelper.GetAllSchedules(Now.Month)
        dgvSchedule.DataSource = ds
        dgvSchedule.DataMember = ("table")
        pnlScore.Visible = False
        dgvTests.Visible = False
        NewApplication = True

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

        NewApplication = True
        'End If
        ApplicationRenewal = False
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

        If txtReceiptNumber.Text = "" Or txtReceiptNumber.Text.Trim = "0" Or txtReceiptNumber.Text.Length < 3 Then
            MsgBox("you entered an invalid Receipt No. please verify and try again", MsgBoxStyle.Critical + vbOKOnly)
            Exit Sub
        End If
        Dim oTrainID As Integer

        If oldTrainID = Nothing Then
            oTrainID = CInt(dgvSchedule.Item(4, dgvSchedule.CurrentRow.Index).Value)
        Else

            oTrainID = oldTrainID
        End If

        TrainerID = CInt(dgvSchedule.Item(4, dgvSchedule.CurrentRow.Index).Value)
        'Dim recNo As String = sql.GetRecNo(TrainID)

        type = SQLHelper.GetTrainingType(TrainerID)

        Select Case type
            Case 1
                Dim num2 As Integer = SQLHelper.UpdateTrainingInfo(TrainerID, oTrainID, txtPermitNo.Text.Trim, CInt(txtScore.Text.Trim), lblcategory.Text.Trim, ComboBox1.Text.Trim)
            Case 2
                UpdateOnsiteScores()
        End Select

        'UpdateCardInfo
        Dim HandlerId As Integer = SQLHelper.GetCategoryID(dgvSchedule.Item(2, dgvSchedule.CurrentRow.Index).Value)
        Dim num As Integer = SQLHelper.UpdateCardInfo(dtpApplicationDate.Value, dtpApplicationDate.Value.AddYears(1), TrainerID, oTrainID, txtPermitNo.Text.Trim, txtReceiptNumber.Text.Trim, cmbpaid.Text.Trim, HandlerId)
        If num > 0 Then
            MsgBox("Schedule Updated", MsgBoxStyle.Information + vbOKOnly)
            NewApplication = False
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

    Private Sub txtrecipNo_TextChanged(sender As Object, e As EventArgs) Handles txtReceiptNumber.TextChanged

    End Sub

    Private Sub cbxNewPermit_CheckedChanged(sender As Object, e As EventArgs) Handles cbxNewPermit.CheckedChanged
        If cbxNewPermit.Checked Then
            btnLookupApplicant.Enabled = False


        Else
            btnLookupApplicant.Enabled = True
        End If
    End Sub
End Class
