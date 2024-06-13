Imports Newtonsoft.Json
Imports System.Net.Http
Imports System.Net.Http.Headers
Imports System.Text

Public Class frmViewuser

    Private _mainForm As mainform

    Private userid As Integer
    Private lastname As String
    Private firstname As String
    Private middlename As String
    Private password As String
    Private department As String
    Private position As String
    Private salary As Double
    Private contactnumber As String
    Private vacation As Double
    Private sickleave As Double
    Private forcedleave As Double
    Private special_privilege_leave As Double
    Private solo_parent_leave As Double



    Dim isButtonClicked As Boolean = False


    Public Sub New(userid As Integer, lastname As String, firstname As String, middlename As String, password As String, department As String, position As String, salary As Double, contactnumber As String, vacation As Double, sickleave As Double, forcedleave As Double, special_privilege_leave As Double, solo_parent_leave As Double, mainForm As mainform)
        ' This call is required by the designer.
        InitializeComponent()


        Me.userid = userid
        Me.lastname = lastname
        Me.firstname = firstname
        Me.middlename = middlename
        Me.password = password
        Me.department = department
        Me.position = position
        Me.salary = salary
        Me.contactnumber = contactnumber
        Me.vacation = vacation
        Me.sickleave = sickleave
        Me.forcedleave = forcedleave
        Me.special_privilege_leave = special_privilege_leave
        Me.solo_parent_leave = solo_parent_leave
        _mainForm = mainForm


        AddHandler Me.FormClosed, AddressOf frmViewuser_FormClosed


    End Sub


    Private Async Sub btnedit_save_Click(sender As Object, e As EventArgs) Handles btnedit_save.Click

        Dim accessToken As String = My.Settings.accessToken
        Dim refreshToken As String = My.Settings.refreshToken
        If isButtonClicked Then
            btnedit_save.Enabled = False
            Dim host As String = My.Settings.host





            Dim updateObject As New Dictionary(Of String, Object)
            updateObject.Add("userid", userid)

            Dim fields As New Dictionary(Of TextBox, String) From {
            {txtLastname, lastname},
            {txtFirstname, firstname},
            {txtMiddlename, middlename},
            {txtPassword, password},
            {txtPosition, position},
            {txtSalary, salary.ToString()},
            {txtContactnumber, contactnumber},
            {txtVacation, vacation.ToString()},
            {txtSickleave, sickleave.ToString()},
            {txtForcedleave, forcedleave.ToString()},
            {txtSpecial_privilege_leave, special_privilege_leave.ToString()},
            {txtSolo_parent_leave, solo_parent_leave.ToString()}
        }

            For Each field In fields
                If Not field.Key.Text.Equals(field.Value) Then
                    updateObject.Add(field.Key.Name.Substring(3).ToLower(), field.Key.Text) ' Substring(3) to remove "txt" prefix
                End If
            Next

            updateObject.Add("department", cmbDept.SelectedItem.ToString())


            Dim content As New StringContent(JsonConvert.SerializeObject(updateObject), Encoding.UTF8, "application/json")
            HttpClientSingleton.SharedClient.DefaultRequestHeaders.Authorization = New AuthenticationHeaderValue("Bearer", accessToken)
            Dim response As HttpResponseMessage = Await HttpClientSingleton.SharedClient.PutAsync("http://" & host & ":3000/adminside/update_user", content)
            MessageBox.Show("Saved")
            btnedit_save.Enabled = True
            Me.Close()

            _mainForm.frmLeavecardOpen()
        Else
            'txtUserid.Enabled = True
            txtLastname.Enabled = True
            txtFirstname.Enabled = True
            txtMiddlename.Enabled = True
            txtPassword.Enabled = True
            txtPosition.Enabled = True
            cmbDept.Enabled = True
            txtSalary.Enabled = True
            txtContactnumber.Enabled = True
            '  txtVacation.Enabled = True
            '  txtSickleave.Enabled = True
            ' txtForcedleave.Enabled = True
            'txtSpecial_privilege_leave.Enabled = True
            'txtSolo_parent_leave.Enabled = True
            btnedit_save.Text = "Save"
            isButtonClicked = True
        End If
    End Sub


    Private Sub frmViewuser_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        _mainForm.ToggleLogoutExit(False)

        txtUserid.Enabled = False
        txtLastname.Enabled = False
        txtFirstname.Enabled = False
        txtMiddlename.Enabled = False
        txtPassword.Enabled = False
        txtPosition.Enabled = False
        cmbDept.Enabled = False
        txtSalary.Enabled = False
        txtContactnumber.Enabled = False
        txtVacation.Enabled = False
        txtSickleave.Enabled = False
        txtForcedleave.Enabled = False
        txtSpecial_privilege_leave.Enabled = False
        txtSolo_parent_leave.Enabled = False

        Dim accessLevel As String = My.Settings.accessLevel
        If accessLevel = "d033e22ae348aeb5660fc2140aec35850c4da997" Then

            btnedit_save.Visible = True

        End If


        txtUserid.Text = userid
        txtLastname.Text = lastname
        txtFirstname.Text = firstname
        txtMiddlename.Text = middlename
        txtPassword.Text = password
        txtPosition.Text = position
        txtSalary.Text = salary
        txtContactnumber.Text = contactnumber
        txtVacation.Text = vacation
        txtSickleave.Text = sickleave
        txtForcedleave.Text = forcedleave
        txtSpecial_privilege_leave.Text = special_privilege_leave
        txtSolo_parent_leave.Text = solo_parent_leave



        Dim departments() As String = {"none", "ADMIN", "HRMDO", "CMO", "CBO", "CLSO", "OCES", "BAC", "PRICTU", "PESU", "SP", "OCA", "CCRO", "CASSO", "CPDO", "DILG", "CTO", "CTEU", "HCI", "PDAO", "CIPTO", "OGS", "CDRRMO", "CSWDO", "CGSO", "IAS", "SH", "VET", "OCLO", "OCVS", "CENRO", "OCAG", "MARKET", "TERMINAL", "CHU 1", "CHU 2", "CHU 3"}


        For Each department As String In departments
            cmbDept.Items.Add(department)
        Next


        cmbDept.DropDownStyle = ComboBoxStyle.DropDownList

        cmbDept.SelectedIndex = cmbDept.FindStringExact(department)

    End Sub

    Private Sub TextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtVacation.KeyPress, txtSickleave.KeyPress, txtForcedleave.KeyPress, txtSpecial_privilege_leave.KeyPress, txtSolo_parent_leave.KeyPress, txtSalary.KeyPress
        Dim txt As TextBox = CType(sender, TextBox)
        Dim keyChar = e.KeyChar

        ' Allow control characters (like backspace)
        If Char.IsControl(keyChar) Then
            Return
        End If

        ' For decimal text boxes, allow digits, a single decimal point, and backspace
        If txt.Name = "txtSalary" Or txt.Name = "txtVacation" Or txt.Name = "txtSickleave" Or txt.Name = "txtForcedleave" Or txt.Name = "txtSpecial_privilege_leave" Or txt.Name = "txtSolo_parent_leave" Then
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

    Private Sub frmViewuser_FormClosed(sender As Object, e As FormClosedEventArgs)

        _mainForm.ToggleLogoutExit(True)

        _mainForm.frmLeavecardOpen()
    End Sub


End Class
