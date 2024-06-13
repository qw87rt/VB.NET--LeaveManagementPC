Imports System.Net.Http
Imports Newtonsoft.Json
Imports System.Net.Http.Headers
Imports System.Text
Imports System.Threading
Imports Newtonsoft.Json.Linq

Public Class frmRegistadmin

    Private cts As New CancellationTokenSource()
    Private isLoading As Boolean = False

    Private Sub frmRegistadmin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim access_levels() As String = {"1", "2"}
        Dim departments() As String = {"ADMIN", "HRMDO", "CMO", "CBO", "CLSO", "OCES", "BAC", "PRICTU", "PESU", "SP", "OCA", "CCRO", "CASSO", "CPDO", "DILG", "CTO", "CTEU", "HCI", "PDAO", "CIPTO", "OGS", "CDRRMO", "CSWDO", "CGSO", "IAS", "SH", "VET", "OCLO", "OCVS", "CENRO", "OCAG", "MARKET", "TERMINAL", "CHU 1", "CHU 2", "CHU 3"}



        For Each department As String In departments
            cmbDept.Items.Add(department)
        Next


        cmbDept.DropDownStyle = ComboBoxStyle.DropDownList

        ' Add levels to the accesslevel ComboBox
        For Each level As String In access_levels
            cmbAccesslevel.Items.Add(level)
        Next

        cmbAccesslevel.DropDownStyle = ComboBoxStyle.DropDownList



    End Sub

    Private Async Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim textBoxes As TextBox() = {txtLastname, txtFirstname, txtMiddlename, txtContactnumber}

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

        If cmbAccesslevel.SelectedItem Is Nothing Then
            MessageBox.Show("Please fill out all fields.")
            Return
        End If

        Dim result As DialogResult = MessageBox.Show("Are you sure you want to save?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then



            btnSave.Enabled = False
            btnCancel.Enabled = False
            Dim host As String = My.Settings.host


            Dim access_level As String = cmbAccesslevel.SelectedItem.ToString()

            Dim department As String = cmbDept.SelectedItem.ToString()
            Dim content As New StringContent(JsonConvert.SerializeObject(New With {
                .password = txtPassword.Text,
                .lastname = txtLastname.Text,
                .firstname = txtFirstname.Text,
                .middlename = txtMiddlename.Text,
                .contactnumber = txtContactnumber.Text,
                .department = department,
                .access_level = access_level
            }), Encoding.UTF8, "application/json")

            Dim response As HttpResponseMessage = Await HttpClientSingleton.SharedClient.PostAsync("http://" & host & ":3000/adminside/registeradmin", content, cts.Token)
            response.EnsureSuccessStatusCode()

            If response.IsSuccessStatusCode Then
                Dim responseString As String = Await response.Content.ReadAsStringAsync()

                Dim responseObject As JObject = JsonConvert.DeserializeObject(Of JObject)(responseString)

                Dim userId As String = responseObject("adminId").ToString()

                ' Display the userId in a message box
                MessageBox.Show("Registered Successfully.    [ Admin ID: " & userId & ", Password: " & txtPassword.Text)
                isLoading = True

                Me.Close()
                ' The request was successful
            Else
                ' The request failed
                MessageBox.Show("Something went wrong")
                Me.Close()
            End If
        Else
            'If no/cancel
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