Public Class Login
    Dim sql As New SqlClass
    Private _isLoggedIn As Boolean = False

    Public Property IsLoggedIn As Boolean
        Get
            Return _isLoggedIn
        End Get
        Set(value As Boolean)
            _isLoggedIn = value
        End Set
    End Property

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        If UsernameTextBox.Text = "" Or PasswordTextBox.Text = "" Then
            MsgBox("Please enter your username and password.", MsgBoxStyle.Information + vbOKOnly)
            Exit Sub
        Else
            Dim reader As Data.IDataReader

            Try
                reader = sql.GetUser(UsernameTextBox.Text.Trim, SqlClass.EncryptText(PasswordTextBox.Text.Trim))
            Catch ex As Exception
                MessageBox.Show("Cannot login user, please try again or contact your system administrator.")
                Exit Sub
            End Try

            If reader.Read Then
                IsLoggedIn = True
                AccessLevel = reader("Access_level")
                ParishID = reader("ParishId")
                UserID = reader("UserID")
                Me.Close()
            Else
                MessageBox.Show("Invalid Username and Password, please try again.", "Invalid Login", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        End If
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Application.Exit()
    End Sub

End Class
