Imports System.Net.Http
Imports Newtonsoft.Json
Imports System.Net.Http.Headers
Imports System.Text
Imports System.Threading
Imports Newtonsoft.Json.Linq


Public Class frmRegistuser
    Private cts As New CancellationTokenSource()

    Private isLoading As Boolean = False


    Private Sub frmRegistuser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim departments() As String = {"ADMIN", "HRMDO", "CMO", "CBO", "CLSO", "OCES", "BAC", "PRICTU", "PESU", "SP", "OCA", "CCRO", "CASSO", "CPDO", "DILG", "CTO", "CTEU", "HCI", "PDAO", "CIPTO", "OGS", "CDRRMO", "CSWDO", "CGSO", "IAS", "SH", "VET", "OCLO", "OCVS", "CENRO", "OCAG", "MARKET", "TERMINAL", "CHU 1", "CHU 2", "CHU 3"}


        For Each department As String In departments
            cmbDept.Items.Add(department)
        Next


        cmbDept.DropDownStyle = ComboBoxStyle.DropDownList
    End Sub

    Private Async Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        Dim textBoxes As TextBox() = {txtLastname, txtFirstname, txtMiddlename, txtPosition, txtSalary, txtContactnumber, txtVacation, txtSickleave, txtForcedleave, txtSpecialpriv, txtSoloparent}

        ' Check if any text box is empty
        For Each txt As TextBox In textBoxes
            If String.IsNullOrWhiteSpace(txt.Text) Then
                MessageBox.Show("Please fill out all fields.")
                Return ' Exit the event handler if any text box is empty
            End If
        Next


        If cmbDept.SelectedItem Is Nothing Then
            MessageBox.Show("Please select a department.")
            Return
        End If
        Dim confirm As DialogResult = MessageBox.Show("Are you sure you want to save?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If confirm = DialogResult.Yes Then


            btnSave.Enabled = False
            btnCancel.Enabled = False



            Dim characters As String = "abcdefghijkmnpqrstuvwxyz23456789"
            Dim random As New Random()
            Dim result As New StringBuilder(6)

            For i As Integer = 0 To 5
                result.Append(characters(random.Next(characters.Length)))
            Next
            Dim department As String = cmbDept.SelectedItem.ToString()

            Dim host As String = My.Settings.host
            Dim content As New StringContent(JsonConvert.SerializeObject(New With {
                .password = result.ToString(),
                .lastname = txtLastname.Text,
                .firstname = txtFirstname.Text,
                .middlename = txtMiddlename.Text,
                .department = department,
                .position = txtPosition.Text,
                .salary = txtSalary.Text,
                .contactnumber = txtContactnumber.Text,
                .vacation = txtVacation.Text,
                .sickleave = txtSickleave.Text,
                .forcedleave = txtForcedleave.Text,
                .special_privilege_leave = txtSpecialpriv.Text,
                .solo_parent_leave = txtSoloparent.Text
            }), Encoding.UTF8, "application/json")

            Dim response As HttpResponseMessage = Await HttpClientSingleton.SharedClient.PostAsync("http://" & host & ":3000/adminside/registeruser", content, cts.Token)
            response.EnsureSuccessStatusCode()

            If response.IsSuccessStatusCode Then
                Dim responseString As String = Await response.Content.ReadAsStringAsync()
                Dim responseObject As JObject = JsonConvert.DeserializeObject(Of JObject)(responseString)
                Dim userId As String = responseObject("userId").ToString()




                ' Display the userId in a message box
                MessageBox.Show("Registered Successfully.   [ User ID: " & userId & ", Password: " & result.ToString())
                isLoading = True

                Me.Close()
                ' The request was successful
            Else
                ' The request failed
                MessageBox.Show("Something went wrong")
                Me.Close()
            End If
        Else
            'if no/cancel
        End If
    End Sub

    Protected Overrides Sub OnFormClosing(e As FormClosingEventArgs)
        If String.IsNullOrEmpty(txtLastname.Text) Then
            If cts IsNot Nothing Then
                cts.Cancel()
            End If
            MyBase.OnFormClosing(e)
        Else
            If Not isLoading Then

                Dim result As DialogResult = MessageBox.Show("Proceed with closing?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                If cts IsNot Nothing Then
                    cts.Cancel()
                End If
                MyBase.OnFormClosing(e)
            Else
                e.Cancel = True
            End If

            End If
        End If

    End Sub

    Private Sub TextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtVacation.KeyPress, txtSickleave.KeyPress, txtForcedleave.KeyPress, txtSpecialpriv.KeyPress, txtSoloparent.KeyPress, txtSalary.KeyPress
        Dim txt As TextBox = CType(sender, TextBox)
        Dim keyChar = e.KeyChar

        ' Allow control characters (like backspace)
        If Char.IsControl(keyChar) Then
            Return
        End If

        ' For decimal text boxes, allow digits, a single decimal point, and backspace
        If txt.Name = "txtSalary" Or txt.Name = "txtVacation" Or txt.Name = "txtSickleave" Or txt.Name = "txtForcedleave" Or txt.Name = "txtSpecialpriv" Or txt.Name = "txtSoloparent" Then
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

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click

        If String.IsNullOrEmpty(txtLastname.Text) Then
            Me.Close()
        Else


            Dim result As DialogResult = MessageBox.Show("Are you sure you want to cancel?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If result = DialogResult.Yes Then
                Me.Close()
            Else
                'if no / cancel
            End If

        End If

    End Sub
End Class