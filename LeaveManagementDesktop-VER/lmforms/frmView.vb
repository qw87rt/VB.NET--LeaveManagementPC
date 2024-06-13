Imports System.Net.Http
Imports System.Net.Http.Headers
Imports System.Text
Imports Newtonsoft.Json
Imports System.Threading


Public Class frmView

    Private _mainForm As mainform

    Private requestId As Integer
    Private userid As Integer
    Private leaveid As Integer
    Private reasonid As Integer
    Private request_status As String
    Private description As String
    Private inclusivedates As String
    Private commutation As String
    Private duration As Decimal
    Private vacationCreds As Decimal
    Private sickCreds As Decimal

    Private isLoading As Boolean = False



    Private cts As New CancellationTokenSource()

    Private process_no As Integer


    Dim isButtonClicked As Boolean = False

    Public Class Request
        Public Property requestid As Integer
        Public Property firstname As List(Of String)
        Public Property lastname As List(Of String)
        Public Property middlename As List(Of String)
        Public Property department As String
        Public Property datefiled As String
        Public Property position As String
        Public Property salary As Double
        Public Property deducted_vacation As Double
        Public Property deducted_sick As Double
        Public Property vacation As Double
        Public Property sickleave As Double
        Public Property vacationCreds As Double
        Public Property sickCreds As Double
        Public Property leaveid As Integer
        Public Property reasonid As Integer
        Public Property description As String
        Public Property request_status As String
        Public Property duration As Double
        Public Property inclusivedates As String
        Public Property commutation As String
        Public Property process_no As Integer

    End Class
    Public Sub New(requestId As Integer, userid As Integer, mainForm As mainform)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.requestId = requestId
        Me.userid = userid
        _mainForm = mainForm
        ' Add an event handler for the FormClosed event
        AddHandler Me.FormClosed, AddressOf frmView_FormClosed

    End Sub


    Private Sub frmView_FormClosed(sender As Object, e As FormClosedEventArgs)

        _mainForm.ToggleLogoutExit(True)

        ' Show frmPending when frmView is closed
        If request_status = "Pending" Then
            _mainForm.frmPendingOpen()
        ElseIf request_status = "Approved" Then
            _mainForm.frmApprovedOpen()

        ElseIf request_status = "Denied" Then
            _mainForm.frmDeniedOpen()


        End If
    End Sub

    Private Sub EnableButtons(ByVal enable As Boolean)
        btnApprove.Enabled = enable
        btnDeny.Enabled = enable
        btnRevert.Enabled = enable
        btnSet.Enabled = enable
        btnEdit.Enabled = enable
    End Sub

    Private Async Function GetRequestDetails(requestId As Integer) As Task(Of String)
        Dim responseString As String = String.Empty

        Try
            Dim host As String = My.Settings.host
            Dim response As HttpResponseMessage = Await HttpClientSingleton.SharedClient.GetAsync("http://" & host & ":3000/adminside/btnview/" & requestId, cts.Token)
            response.EnsureSuccessStatusCode()

            responseString = Await response.Content.ReadAsStringAsync()


        Catch ex As OperationCanceledException
            ' MessageBox.Show("Request Cancelled", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As HttpRequestException
            MessageBox.Show("Request failed: Please ensure you have an active internet connection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'mainform.Close()
            'Form1.Show()

        End Try

        Return responseString
    End Function

    Protected Overrides Sub OnFormClosing(e As FormClosingEventArgs)
        If cts IsNot Nothing Then
            cts.Cancel()
        End If
        MyBase.OnFormClosing(e)
    End Sub





    Private Async Sub frmView_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        _mainForm.ToggleLogoutExit(False)
        EnableButtons(False)

        Dim responseString As String = Await GetRequestDetails(requestId)
        Dim request As Request = JsonConvert.DeserializeObject(Of Request)(responseString)
        Dim lessVac As Double = request.deducted_vacation
        Dim lessSick As Double = request.deducted_sick
        request_status = request.request_status

        leaveid = request.leaveid

        cmbReasonid.DropDownStyle = ComboBoxStyle.DropDownList

        Dim leavetypes() As String = {"Vacation Leave", "Mandatory/Forced", "Sick Leave", "Maternity Leave", "Paternity Leave", "Special Privilege", "Solo Parent Leave", "Study Leave", "10-Day VAWC Leave", "Rehabilitation Privilege", "Special Leave For Women", "Special Emergency", "Adoption Leave", "Monetization of Leave Credits", "Terminal Leave", "Other Purpose"}


        ' Add years to the Year ComboBox
        For Each leavetype As String In leavetypes
            cmbLeaveid.Items.Add(leavetype)
        Next


        cmbLeaveid.DropDownStyle = ComboBoxStyle.DropDownList
        cmbLeaveid.SelectedIndex = leaveid - 1

        AddHandler cmbLeaveid.SelectedIndexChanged, AddressOf cmbLeavetype_SelectedIndexChanged

        cmbLeavetype_SelectedIndexChanged(cmbLeaveid, New EventArgs())


        Dim sReasontype As String
        Select Case request.reasonid
            Case 1
                sReasontype = "Within the Philippines"
            Case 2
                sReasontype = "Abroad"
            Case 3
                sReasontype = "In Hospital"
            Case 4
                sReasontype = "Out Patient"
            Case 5
                sReasontype = "Special Leave for Women"
            Case 6
                sReasontype = "Completion of Master's Degree"
            Case 7
                sReasontype = "BAR/Board Exam Review"
            Case Else
                sReasontype = "N/A"
        End Select

        cmbReasonid.SelectedItem = sReasontype

        cmbCommutation.Items.AddRange({"not requested", "requested"})
        cmbCommutation.SelectedItem = request.commutation
        cmbCommutation.DropDownStyle = ComboBoxStyle.DropDownList



        txtRequestid.Text = request.requestid.ToString()
        txtDatefiled.Text = request.datefiled.ToString().Substring(0, 10)
        txtDepartment.Text = request.department
        txtName.Text = String.Concat(request.lastname.FirstOrDefault(), " ", request.firstname.FirstOrDefault(), " ", request.middlename.FirstOrDefault())
        txtPosition.Text = request.position
        txtPosition.Text = request.position
        'txtSalary.Text = request.salary.ToString()

        txtDeductedvacation.Text = lessVac
        txtDeductedsick.Text = lessSick

        txtVacation.Text = request.vacationCreds.ToString()
        txtSickleave.Text = request.sickCreds.ToString()


        txtDuration.Text = request.duration
        txtInclusivedates.Text = String.Concat(request.inclusivedates)
        txtDescription.Text = request.description

        vacationCreds = request.vacationCreds
        sickCreds = request.sickCreds
        txtNetvacation.Text = vacationCreds - lessVac
        txtNetsick.Text = sickCreds - lessSick



        'assign
        description = request.description
        duration = request.duration
        inclusivedates = request.inclusivedates
        commutation = request.commutation
        reasonid = request.reasonid
        request_status = request.request_status
        'read only

        txtRequestid.Enabled = False
        txtDatefiled.Enabled = False
        txtDepartment.Enabled = False
        txtName.Enabled = False
        txtPosition.Enabled = False
        txtSalary.Enabled = False
        'txtDeductedvacation.Enabled = False
        'txtDeductedsick.Enabled = False
        txtVacation.Enabled = False
        txtSickleave.Enabled = False
        txtDuration.Enabled = False
        txtInclusivedates.Enabled = False
        txtDescription.Enabled = False
        txtNetvacation.Enabled = False
        txtNetsick.Enabled = False


        Dim accessLevel As String = My.Settings.accessLevel

        If request.request_status = "Pending" Then

            txtVacation.Text = request.vacation.ToString()
            txtSickleave.Text = request.sickleave.ToString()

            vacationCreds = request.vacation
            sickCreds = request.sickleave
            txtNetvacation.Text = vacationCreds - lessVac
            txtNetsick.Text = sickCreds - lessSick

            If accessLevel = "d033e22ae348aeb5660fc2140aec35850c4da997" Then
                btnSet.Visible = True

            End If

            btnEdit.Visible = True
            btnApprove.Visible = True
            btnDeny.Visible = True

        End If


        If accessLevel <> "d033e22ae348aeb5660fc2140aec35850c4da997" Then
            txtDeductedvacation.Enabled = False
            txtDeductedsick.Enabled = False
        End If
        If request.request_status <> "Pending" Then
            txtDeductedvacation.Enabled = False
            txtDeductedsick.Enabled = False
            'btnSet.Visible = False
            btnApprove.Visible = False
            btnDeny.Visible = False
            btnEdit.Visible = False
        End If

        If accessLevel = "d033e22ae348aeb5660fc2140aec35850c4da997" AndAlso request.request_status <> "Pending" Then


            If request.datefiled > DateTime.Now.AddMonths(-2) Then

                btnRevert.Visible = True
            End If


        End If




        process_no = request.process_no


        EnableButtons(True)

    End Sub

    Private Sub cmbLeavetype_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim leavetypeindex As Integer = cmbLeaveid.SelectedIndex
        cmbReasonid.Items.Clear()


        Select Case leavetypeindex
            Case 0
                cmbReasonid.Items.AddRange({"Within the Philippines", "Abroad"})
            Case 1
                cmbReasonid.Items.AddRange({"Within the Philippines", "Abroad"})
            Case 2
                cmbReasonid.Items.AddRange({"In Hospital", "Out Patient"})
            Case 3
                cmbReasonid.Items.AddRange({"N/A"})
            Case 4
                cmbReasonid.Items.AddRange({"N/A"})
            Case 5
                cmbReasonid.Items.AddRange({"N/A"})
            Case 6
                cmbReasonid.Items.AddRange({"N/A"})
            Case 7
                cmbReasonid.Items.AddRange({"Completion of Master's Degree", "BAR/Board Exam Review"})
            Case 8
                cmbReasonid.Items.AddRange({"N/A"})
            Case 9
                cmbReasonid.Items.AddRange({"N/A"})
            Case 10
                cmbReasonid.Items.AddRange({"N/A"})
            Case 11
                cmbReasonid.Items.AddRange({"N/A"})
            Case 12
                cmbReasonid.Items.AddRange({"N/A"})
            Case 13
                cmbReasonid.Items.AddRange({"N/A"})
            Case 14
                cmbReasonid.Items.AddRange({"N/A"})
            Case Else
                cmbReasonid.Items.AddRange({"N/A"})
        End Select
    End Sub

    Private Async Sub btnSet_Click(sender As Object, e As EventArgs) Handles btnSet.Click
        EnableButtons(False)

        SetEmptyTextBoxesToZero()

        txtNetvacation.Text = vacationCreds - Convert.ToDouble(txtDeductedvacation.Text)
        txtNetsick.Text = sickCreds - Convert.ToDouble(txtDeductedsick.Text)


        Dim host As String = My.Settings.host
        Dim content As New StringContent(JsonConvert.SerializeObject(New With {
            .requestid = requestId,
            .lessVac = txtDeductedvacation.Text,
            .lessSick = txtDeductedsick.Text
        }), Encoding.UTF8, "application/json")

        Dim response As HttpResponseMessage = Await HttpClientSingleton.SharedClient.PutAsync("http://" & host & ":3000/adminside/update_deduction", content, cts.Token)

        If response.IsSuccessStatusCode Then
            MessageBox.Show("Submitted Successfully")
            ' Me.Close()
            ' The request was successful
        Else
            ' The request failed
            MessageBox.Show("Something went wrong")
            Me.Close()
        End If
        EnableButtons(True)

    End Sub


    Private Sub SetEmptyTextBoxesToZero()
        For Each ctrl As Control In Me.Controls
            If TypeOf ctrl Is TextBox Then
                If String.IsNullOrWhiteSpace(CType(ctrl, TextBox).Text) Then
                    CType(ctrl, TextBox).Text = "0"
                End If
            End If
        Next
    End Sub

    Private Async Sub btnDeny_Click(sender As Object, e As EventArgs) Handles btnDeny.Click

        Dim result As DialogResult = MessageBox.Show("Are you sure you want to deny this?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then


            EnableButtons(False)

            Dim host As String = My.Settings.host
            Dim content As New StringContent(JsonConvert.SerializeObject(New With {
           .requestid = requestId
       }), Encoding.UTF8, "application/json")


            Dim response As HttpResponseMessage = Await HttpClientSingleton.SharedClient.PutAsync("http://" & host & ":3000/adminside/deny", content, cts.Token)

            If response.IsSuccessStatusCode Then
                MessageBox.Show("Request Denied Successfully")
                Me.Close()

                _mainForm.ToggleLogoutExit(True)

                _mainForm.frmPendingOpen()


            Else
                MessageBox.Show("Something went wrong")
                Me.Close()
                _mainForm.ToggleLogoutExit(True)

            End If

            EnableButtons(True)
        Else
            'if no/cancel
        End If
    End Sub


    Private Async Sub btnApprove_Click(sender As Object, e As EventArgs) Handles btnApprove.Click

        Dim result As DialogResult = MessageBox.Show("Are you sure you want to approve this?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then


            EnableButtons(False)

            Dim host As String = My.Settings.host
            Dim currentYear As Integer = Date.Now.Year
            Dim txtLeavetype As String = leaveid.ToString()


            ' Get the request details
            Dim responseString As String = Await GetRequestDetails(requestId)
            Dim request As Request = JsonConvert.DeserializeObject(Of Request)(responseString)

            ' Approve the request
            Dim approveContent As New StringContent(JsonConvert.SerializeObject(New With {
        .requestid = requestId,
        .process_no = process_no,
        .vacationCreds = txtVacation.Text,
        .sickCreds = txtSickleave.Text
    }), Encoding.UTF8, "application/json")

            Dim approveResponse As HttpResponseMessage = Await HttpClientSingleton.SharedClient.PutAsync("http://" & host & ":3000/adminside/approve", approveContent, cts.Token)

            If approveResponse.IsSuccessStatusCode AndAlso process_no = 2 Then
                ' Request approved successfully, insert leave
                Dim insertContent As New StringContent(JsonConvert.SerializeObject(New With {
            .userid = userid,
            .requestid = txtRequestid.Text,
            .leaveid = txtLeavetype,
            .inclusivedates = txtInclusivedates.Text,
            .duration = txtDuration.Text,
            .Vacbal = txtNetvacation.Text,
            .Sickbal = txtNetsick.Text,
            .year = currentYear
        }), Encoding.UTF8, "application/json")

                Dim insertResponse As HttpResponseMessage = Await HttpClientSingleton.SharedClient.PostAsync("http://" & host & ":3000/adminside/Lcinsertreq", insertContent, cts.Token)
                insertResponse.EnsureSuccessStatusCode()

                If insertResponse.IsSuccessStatusCode Then
                    MessageBox.Show("Request approved successfully.") 'HR INCHARGE
                    Me.Close()

                    _mainForm.ToggleLogoutExit(True)

                    _mainForm.frmPendingOpen()

                Else
                    MessageBox.Show("Something went wrong!!")
                    _mainForm.ToggleLogoutExit(True)

                    Me.Close()
                End If
            Else
                If approveResponse.IsSuccessStatusCode Then
                    MessageBox.Show("Approved") 'HRLO
                    Me.Close()
                    _mainForm.ToggleLogoutExit(True)

                    _mainForm.frmPendingOpen()
                Else
                    _mainForm.ToggleLogoutExit(True)

                    Me.Close()
                End If
            End If

            EnableButtons(True)
        Else
            'If no/cancel
        End If

    End Sub


    Private Sub TextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDeductedsick.KeyPress, txtDeductedvacation.KeyPress
        Dim txt As TextBox = CType(sender, TextBox)
        Dim keyChar = e.KeyChar

        ' Allow control characters (like backspace)
        If Char.IsControl(keyChar) Then
            Return
        End If

        ' For decimal text boxes, allow digits, a single decimal point, and backspace
        If txt.Name = "txtDeductedvacation" Or txt.Name = "txtDeductedsick" Then
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

    Private Async Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        EnableButtons(False)


        Dim accessToken As String = My.Settings.accessToken
        Dim refreshToken As String = My.Settings.refreshToken

        If isButtonClicked Then
            Dim host As String = My.Settings.host
            Dim updateObject As New Dictionary(Of String, Object)
            updateObject.Add("requestid", requestId)

            SetEmptyTextBoxesToZero()

            Dim varReasonid As Integer

            Select Case cmbReasonid.SelectedItem
                Case "Within the Philippines"
                    varReasonid = 1
                Case "Abroad"
                    varReasonid = 2
                Case "In Hospital"
                    varReasonid = 3
                Case "Out Patient"
                    varReasonid = 4
                Case "Completion of Master's Degree"
                    varReasonid = 6
                Case "BAR/Board Exam Review"
                    varReasonid = 7
                Case Else
                    varReasonid = 8
            End Select



            Dim fields As New Dictionary(Of Object, String) From {
                {txtDescription, description},
                {txtInclusivedates, inclusivedates},
                {txtDuration, duration},
                {cmbCommutation, commutation}
            }



            For Each field In fields
                Dim value As String = Nothing

                If TypeOf field.Key Is ComboBox Then
                    value = CType(field.Key, ComboBox).SelectedItem.ToString()
                ElseIf TypeOf field.Key Is TextBox Then
                    value = field.Key.Text
                End If

                If Not value.Equals(field.Value) Then
                    Dim fieldName As String = If(TypeOf field.Key Is ComboBox, field.Key.Name.Substring(3).ToLower(), field.Key.Name.Substring(3).ToLower())
                    updateObject.Add(fieldName, value)

                End If
            Next


            updateObject.Add("leaveid", cmbLeaveid.SelectedIndex + 1)
            updateObject.Add("reasonid", varReasonid)


            Dim content As New StringContent(JsonConvert.SerializeObject(updateObject), Encoding.UTF8, "application/json")
            HttpClientSingleton.SharedClient.DefaultRequestHeaders.Authorization = New AuthenticationHeaderValue("Bearer", accessToken)
            Dim response As HttpResponseMessage = Await HttpClientSingleton.SharedClient.PutAsync("http://" & host & ":3000/adminside/update_req", content)
            If response.IsSuccessStatusCode Then

                EnableButtons(True)

                btnEdit.Text = "Edit"
                isButtonClicked = False
                cmbCommutation.Enabled = False
                cmbLeaveid.Enabled = False
                cmbReasonid.Enabled = False
                txtDescription.Enabled = False
                txtInclusivedates.Enabled = False
                txtDuration.Enabled = False

                MessageBox.Show("Saved")

            Else

                MessageBox.Show("Something went wrong!!")
                Me.Close()
            End If

        Else

            EnableButtons(True)


            cmbCommutation.Enabled = True
            cmbLeaveid.Enabled = True
            cmbReasonid.Enabled = True
            txtDescription.Enabled = True
            txtInclusivedates.Enabled = True
            txtDuration.Enabled = True

            btnEdit.Text = "Save"
            isButtonClicked = True
        End If
    End Sub

    Private Async Sub btnRevert_Click(sender As Object, e As EventArgs) Handles btnRevert.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to revert this?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then



            btnRevert.Enabled = False
            Dim accessToken As String = My.Settings.accessToken
            Dim refreshToken As String = My.Settings.refreshToken
            Dim host As String = My.Settings.host
            Dim updateObject As New Dictionary(Of String, Object)


            updateObject.Add("requestid", requestId)

            updateObject.Add("request_status", "Pending")

            If request_status = "Approved" Then

                updateObject.Add("revert", "revert")

            End If


            Dim content As New StringContent(JsonConvert.SerializeObject(updateObject), Encoding.UTF8, "application/json")
            HttpClientSingleton.SharedClient.DefaultRequestHeaders.Authorization = New AuthenticationHeaderValue("Bearer", accessToken)
            Dim response As HttpResponseMessage = Await HttpClientSingleton.SharedClient.PutAsync("http://" & host & ":3000/adminside/update_req", content)

            If response.IsSuccessStatusCode Then

                btnRevert.Enabled = True

                MessageBox.Show("Reverted")
                _mainForm.ToggleLogoutExit(True)
                Me.Close()

                If request_status = "Approved" Then
                    _mainForm.frmApprovedOpen()
                ElseIf request_status = "Denied" Then
                    _mainForm.frmDeniedOpen()
                End If


            Else

                MessageBox.Show("Something went wrong!!")
                _mainForm.ToggleLogoutExit(True)
                Me.Close()
            End If

            EnableButtons(True)
        Else
            'If no/cancel
        End If
    End Sub


End Class
