Imports System.Net.Http
Imports System.Net.Http.Headers
Imports System.Text
Imports Newtonsoft.Json
Imports System.Threading


Public Class frmDTRentry
    Private isLoading As Boolean = False
    Private _mainForm As mainform

    Private userID As Integer
    Private vacbal As Integer
    Private sickbal As Integer
    Private employeename As String

    Private cts As New CancellationTokenSource()

    Public Sub New(userID As Integer, vacbal As Double, sickbal As Double, employeename As String, mainForm As mainform)
        InitializeComponent()
        Me.userID = userID
        Me.vacbal = vacbal
        Me.sickbal = sickbal
        Me.employeename = employeename

        _mainForm = mainForm

        AddHandler Me.FormClosed, AddressOf frmViewuser_FormClosed

    End Sub

    Private Sub frmDTRentry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim host As String = My.Settings.host
        _mainForm.ToggleLogoutExit(False)

        txtName.Text = employeename
        txtVacbal.Text = vacbal
        txtSickbal.Text = sickbal


        btnSave.Visible = True

        ' Add event handlers for TextChanged events
        AddHandler txtVacleave_earned.LostFocus, AddressOf HandleLostFocus
        AddHandler txtSickleave_earned.LostFocus, AddressOf HandleLostFocus
        AddHandler txtVactardy.LostFocus, AddressOf HandleLostFocus
        AddHandler txtSicktardy.LostFocus, AddressOf HandleLostFocus

    End Sub
    Protected Overrides Sub OnFormClosing(e As FormClosingEventArgs)
        If cts IsNot Nothing Then
            cts.Cancel()
        End If
        MyBase.OnFormClosing(e)
    End Sub
    Private Sub HandleLostFocus(sender As Object, e As EventArgs)
        Dim newVacbal As Double = Convert.ToDouble(txtVacbal.Text)
        Dim newSickbal As Double = Convert.ToDouble(txtSickbal.Text)

        ' Update balances based on the sender textbox
        Select Case CType(sender, TextBox).Name
            Case "txtVacleave_earned"
                If Not String.IsNullOrWhiteSpace(CType(sender, TextBox).Text) Then
                    newVacbal += Convert.ToDouble(CType(sender, TextBox).Text)
                End If
            Case "txtSickleave_earned"
                If Not String.IsNullOrWhiteSpace(CType(sender, TextBox).Text) Then
                    newSickbal += Convert.ToDouble(CType(sender, TextBox).Text)
                End If
            Case "txtVactardy"
                If Not String.IsNullOrWhiteSpace(CType(sender, TextBox).Text) Then
                    newVacbal -= Convert.ToDouble(CType(sender, TextBox).Text)
                End If
            Case "txtSicktardy"
                If Not String.IsNullOrWhiteSpace(CType(sender, TextBox).Text) Then
                    newSickbal -= Convert.ToDouble(CType(sender, TextBox).Text)
                End If
        End Select

        ' Update the textbox values with the new balances
        txtVacbal.Text = newVacbal.ToString()
        txtSickbal.Text = newSickbal.ToString()
    End Sub

    Private Sub frmViewuser_FormClosed(sender As Object, e As FormClosedEventArgs)

        _mainForm.ToggleLogoutExit(True)

        _mainForm.frmLeavecardOpen()
    End Sub

    Private Sub TextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtVacleave_earned.KeyPress, txtSickleave_earned.KeyPress, txtVactardy.KeyPress, txtSicktardy.KeyPress, txtVacbal.KeyPress, txtSickbal.KeyPress, txtSickWOP.KeyPress, txtVacWOP.KeyPress
        Dim txt As TextBox = CType(sender, TextBox)
        Dim keyChar = e.KeyChar

        ' Allow control characters (like backspace)
        If Char.IsControl(keyChar) Then
            Return
        End If

        ' For decimal text boxes, allow digits, a single decimal point, and backspace
        If txt.Name = "txtVacleave_earned" Or txt.Name = "txtSickleave_earned" Or txt.Name = "txtVactardy" Or txt.Name = "txtSicktardy" Or txt.Name = "txtVacbal" Or txt.Name = "txtSickbal" Or txt.Name = "txtVacWOP" Or txt.Name = "txtSickWOP" Then
            If Char.IsDigit(keyChar) OrElse keyChar = "."c Then
                If keyChar = "."c AndAlso txt.Text.IndexOf("."c) <> -1 Then
                    ' Prevent more than one decimal point
                    e.Handled = True
                End If
            Else
                ' Reject all other characters
                e.Handled = True
            End If
        Else
            ' For other text boxes, allow only digits and backspace
            If Not Char.IsDigit(keyChar) AndAlso Not Char.IsControl(keyChar) Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Async Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click


        ' Calculate the final balances
        Dim finalVacbal As Double = vacbal
        Dim finalSickbal As Double = sickbal

        Dim result As DialogResult = MessageBox.Show("Are you sure you want to save?", "Confirm Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            If String.IsNullOrEmpty(txtPeriod.Text) Then
                txtPeriod.Text = " "
            End If

            If String.IsNullOrEmpty(txtParticulars.Text) Then
                txtParticulars.Text = " "
            End If

            If Not String.IsNullOrWhiteSpace(txtVacleave_earned.Text) Then
                finalVacbal += Convert.ToDouble(txtVacleave_earned.Text)
            Else
                txtVacleave_earned.Text = 0
            End If

            If Not String.IsNullOrWhiteSpace(txtSickleave_earned.Text) Then
                finalSickbal += Convert.ToDouble(txtSickleave_earned.Text)
            Else
                txtSickleave_earned.Text = 0
            End If

            If Not String.IsNullOrWhiteSpace(txtVactardy.Text) Then
                finalVacbal -= Convert.ToDouble(txtVactardy.Text)
            Else
                txtVactardy.Text = 0
            End If

            If Not String.IsNullOrWhiteSpace(txtSicktardy.Text) Then
                finalSickbal -= Convert.ToDouble(txtSicktardy.Text)
            Else
                txtSicktardy.Text = 0
            End If

            If String.IsNullOrWhiteSpace(txtVacWOP.Text) Then
                txtVacWOP.Text = 0
            End If

            If String.IsNullOrWhiteSpace(txtSickWOP.Text) Then
                txtSickWOP.Text = 0
            End If

            Dim host As String = My.Settings.host
            Dim accessToken As String = My.Settings.accessToken
            Dim refreshToken As String = My.Settings.refreshToken

            Dim content As New StringContent(JsonConvert.SerializeObject(New With {
            .userid = userID,
            .period = txtPeriod.Text,
            .particulars = txtParticulars.Text,
            .vacleave_earned = txtVacleave_earned.Text,
            .sickleave_earned = txtSickleave_earned.Text,
            .vactardy = txtVactardy.Text,
            .sicktardy = txtSicktardy.Text,
            .Vacbal = finalVacbal,
            .Sickbal = finalSickbal,
            .vacWOP = txtVacWOP.Text,
            .sickWOP = txtSickWOP.Text
        }), Encoding.UTF8, "application/json")

            Dim response As HttpResponseMessage = Await HttpClientSingleton.SharedClient.PostAsync("http://" & host & ":3000/adminside/Lcinsertdtr", content, cts.Token)
            response.EnsureSuccessStatusCode()


            If response.IsSuccessStatusCode Then
                ' Prepare content for the second request
                Dim insertContent As New StringContent(JsonConvert.SerializeObject(New With {
                .userid = userID,
                .vacation = finalVacbal,
                .sickleave = finalSickbal
            }), Encoding.UTF8, "application/json")

                HttpClientSingleton.SharedClient.DefaultRequestHeaders.Authorization = New AuthenticationHeaderValue("Bearer", accessToken)

                ' Execute the second request
                Dim insertResponse As HttpResponseMessage = Await HttpClientSingleton.SharedClient.PutAsync("http://" & host & ":3000/adminside/update_user", insertContent, cts.Token)

                ' Ensure the second request was successful
                insertResponse.EnsureSuccessStatusCode()

                MessageBox.Show("Updated Successfully")
                _mainForm.ToggleLogoutExit(True)
                Me.Close()
                _mainForm.frmLeavecardOpen()
            Else
                MessageBox.Show("First request failed. Status code: " & response.StatusCode)
                _mainForm.ToggleLogoutExit(True)

                Me.Close()
                _mainForm.frmLeavecardOpen()

            End If
        Else
            'User click No / Cancel
        End If

    End Sub
End Class