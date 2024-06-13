Imports Microsoft.VisualBasic.ApplicationServices
Imports Newtonsoft.Json
Imports System.Net.Http
Imports System.Net.Http.Headers
Imports System.Text

Public Class frmViewadmin


    Private _mainForm As mainform

    Private adminid As Integer
    Private lastname As String
    Private firstname As String
    Private middlename As String
    Private password As String
    Private department As String
    Private contactnumber As String
    Private access_level As String




    Dim isButtonClicked As Boolean = False


    Public Sub New(adminid As Integer, lastname As String, firstname As String, middlename As String, department As String, password As String, contactnumber As String, access_level As String, mainForm As mainform)
        ' This call is required by the designer.
        InitializeComponent()


        Me.adminid = adminid
        Me.lastname = lastname
        Me.firstname = firstname
        Me.middlename = middlename
        Me.password = password
        Me.department = department
        Me.access_level = access_level
        Me.contactnumber = contactnumber

        _mainForm = mainForm


        AddHandler Me.FormClosed, AddressOf frmViewadmin_FormClosed


    End Sub
    Private Sub frmViewadmin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _mainForm.ToggleLogoutExit(False)

        txtAdminid.Enabled = False
        txtLastname.Enabled = False
        txtFirstname.Enabled = False
        txtMiddlename.Enabled = False
        txtPassword.Enabled = False
        cmbDept.Enabled = False
        txtContactnumber.Enabled = False
        cmbAccess_level.Enabled = False


        Dim accessLevel As String = My.Settings.accessLevel
        If accessLevel = "d033e22ae348aeb5660fc2140aec35850c4da997" Then

            btnedit_save.Visible = True

        End If


        txtAdminid.Text = adminid
        txtLastname.Text = lastname
        txtFirstname.Text = firstname
        txtMiddlename.Text = middlename
        txtPassword.Text = password
        txtContactnumber.Text = contactnumber




        Dim departments() As String = {"none", "ADMIN", "HRMDO", "CMO", "CBO", "CLSO", "OCES", "BAC", "PRICTU", "PESU", "SP", "OCA", "CCRO", "CASSO", "CPDO", "DILG", "CTO", "CTEU", "HCI", "PDAO", "CIPTO", "OGS", "CDRRMO", "CSWDO", "CGSO", "IAS", "SH", "VET", "OCLO", "OCVS", "CENRO", "OCAG", "MARKET", "TERMINAL", "CHU 1", "CHU 2", "CHU 3"}


        For Each department As String In departments
            cmbDept.Items.Add(department)
        Next


        cmbDept.DropDownStyle = ComboBoxStyle.DropDownList

        cmbDept.SelectedIndex = cmbDept.FindStringExact(department)


        Dim access_levels() As String = {"1", "2"}

        For Each level As String In access_levels
            cmbAccess_level.Items.Add(level)
        Next
        cmbAccess_level.DropDownStyle = ComboBoxStyle.DropDownList

        cmbAccess_level.SelectedIndex = cmbAccess_level.FindStringExact(access_level)

    End Sub
    Private Sub frmViewadmin_FormClosed(sender As Object, e As FormClosedEventArgs)

        _mainForm.ToggleLogoutExit(True)

        _mainForm.frmListAdminOpen()

    End Sub

    Private Async Sub btnedit_save_Click(sender As Object, e As EventArgs) Handles btnedit_save.Click
        Dim accessToken As String = My.Settings.accessToken
        Dim refreshToken As String = My.Settings.refreshToken
        If isButtonClicked Then
            btnedit_save.Enabled = False
            Dim host As String = My.Settings.host


            Dim updateObject As New Dictionary(Of String, Object)
            updateObject.Add("adminid", adminid)

            Dim fields As New Dictionary(Of TextBox, String) From {
            {txtLastname, lastname},
            {txtFirstname, firstname},
            {txtMiddlename, middlename},
            {txtPassword, password},
            {txtContactnumber, contactnumber}
        }

            For Each field In fields
                If Not field.Key.Text.Equals(field.Value) Then
                    updateObject.Add(field.Key.Name.Substring(3).ToLower(), field.Key.Text) ' Substring(3) to remove "txt" prefix
                End If
            Next

            updateObject.Add("department", cmbDept.SelectedItem.ToString())
            updateObject.Add("access_level", cmbAccess_level.SelectedItem.ToString())


            Dim content As New StringContent(JsonConvert.SerializeObject(updateObject), Encoding.UTF8, "application/json")
            HttpClientSingleton.SharedClient.DefaultRequestHeaders.Authorization = New AuthenticationHeaderValue("Bearer", accessToken)
            Dim response As HttpResponseMessage = Await HttpClientSingleton.SharedClient.PutAsync("http://" & host & ":3000/adminside/update_admin", content)
            MessageBox.Show("Saved")
            btnedit_save.Enabled = True
            Me.Close()

            _mainForm.frmListAdminOpen()
        Else
            'txtUserid.Enabled = True
            txtLastname.Enabled = True
            txtFirstname.Enabled = True
            txtMiddlename.Enabled = True
            txtPassword.Enabled = True
            cmbDept.Enabled = True
            cmbAccess_level.Enabled = True
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
End Class