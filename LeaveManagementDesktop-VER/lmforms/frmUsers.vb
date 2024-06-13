Imports System.Net.Http
Imports Newtonsoft.Json
Imports System.Net.Http.Headers
Imports System.Text
Imports System.Threading
Imports Microsoft.VisualBasic.ApplicationServices

Public Class frmUsers

    Private _mainForm As mainform


    Private searchreq As List(Of List)
    Private dt As DataTable
    Private cts As New CancellationTokenSource()


    Private isLoading As Boolean = False

    Public Sub New(mainForm As mainform)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _mainForm = mainForm
    End Sub
    Private Async Sub frmUsers_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.WindowState = FormWindowState.Maximized

        Dim host As String = My.Settings.host
        Dim accessToken As String = My.Settings.accessToken
        Dim refreshToken As String = My.Settings.refreshToken

        isLoading = True
        If isLoading Then
            btnFilterdept.Enabled = False
            TextBoxSearch.Enabled = False
            btnView.Enabled = False
            btnLeavecard.Enabled = False
            btnHistory.Enabled = False
            btnDtr.Enabled = False
        End If

        Try
            HttpClientSingleton.SharedClient.DefaultRequestHeaders.Authorization = New AuthenticationHeaderValue("Bearer", accessToken)
            Dim response As HttpResponseMessage = Await HttpClientSingleton.SharedClient.GetAsync("http://" & host & ":3000/adminside/getUsers", cts.Token)
            'response.EnsureSuccessStatusCode()

            Dim responseString As String = Await response.Content.ReadAsStringAsync()
            'Dim listUsers As List(Of List) = JsonConvert.DeserializeObject(Of List(Of List))(responseString)

            searchreq = JsonConvert.DeserializeObject(Of List(Of List))(responseString)

            PopulateDataGridView(searchreq)

        Catch ex As OperationCanceledException
            '  MessageBox.Show("Request Cancelled", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As HttpRequestException
            MessageBox.Show("Request failed: Please ensure you have an active internet connection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'mainform.Close()
            'Form1.Show()

        End Try

        Dim accessLevel As String = My.Settings.accessLevel
        If accessLevel = "d033e22ae348aeb5660fc2140aec35850c4da997" Then
            'btnFilterdept.Visible = True
            'Label3.Visible = True
            'cmbDept.Visible = True
            btnDtr.Visible = True
        End If




        Dim departments() As String = {"none", "ADMIN", "HRMDO", "CMO", "CBO", "CLSO", "OCES", "BAC", "PRICTU", "PESU", "SP", "OCA", "CCRO", "CASSO", "CPDO", "DILG", "CTO", "CTEU", "HCI", "PDAO", "CIPTO", "OGS", "CDRRMO", "CSWDO", "CGSO", "IAS", "SH", "VET", "OCLO", "OCVS", "CENRO", "OCAG", "MARKET", "TERMINAL", "CHU 1", "CHU 2", "CHU 3"}


        ' Add years to the Year ComboBox
        For Each department As String In departments
            cmbDept.Items.Add(department)
        Next


        cmbDept.DropDownStyle = ComboBoxStyle.DropDownList

    End Sub

    Protected Overrides Sub OnFormClosing(e As FormClosingEventArgs)
        If cts IsNot Nothing Then
            cts.Cancel()
        End If
        MyBase.OnFormClosing(e)
    End Sub


    Private Sub ApplyCommonDataGridViewSettings(dgv As DataGridView)

        Try
            'Change the background color of all cells to light gray
            dgv.DefaultCellStyle.BackColor = Color.White
            dgv.ColumnHeadersDefaultCellStyle.Font = New Font("Arial", 14)
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.DeepPink
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            ' Change the font size of all cells to 14
            dgv.DefaultCellStyle.Font = New Font("Arial", 12)
            ' Set the SelectionMode to FullRowSelect
            dgv.MultiSelect = False
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            dgv.RowHeadersVisible = False


            dgv.Columns("Firstname").Visible = False
            dgv.Columns("Lastname").Visible = False

            dgv.Columns("Middlename").Visible = False
            dgv.Columns("Password").Visible = False
            dgv.Columns("Salary").Visible = False
            dgv.Columns("Contact No.").Visible = False
            ' dgv.Columns("Vacation Leave").Visible = False
            ' dgv.Columns("Sick Leave").Visible = False
            dgv.Columns("Forced Leave").Visible = False
            dgv.Columns("Special Privilege").Visible = False
            dgv.Columns("Solo Parent").Visible = False



            ' Change the text color of all cells to blue
            dgv.DefaultCellStyle.ForeColor = Color.Black

            dgv.Columns("User ID").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            dgv.Columns("Name").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            dgv.Columns("Office/Dept").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            dgv.Columns("Position").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells

            isLoading = False
            TextBoxSearch.Enabled = True
            btnFilterdept.Enabled = True
            btnView.Enabled = True
            btnLeavecard.Enabled = True
            btnDtr.Enabled = True
            btnHistory.Enabled = True
            txtLoading.Visible = False

        Catch ex As Exception
            ' Handle any other unexpected exceptions
            MessageBox.Show("An unexpected error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

    Private Sub PopulateDataGridView(requests As List(Of List))
        Try
            dt = New DataTable()

            dt.Columns.Add("User ID", GetType(Integer))
            dt.Columns.Add("Name", GetType(String))
            dt.Columns.Add("Firstname", GetType(String))
            dt.Columns.Add("Lastname", GetType(String))
            dt.Columns.Add("Office/Dept", GetType(String))
            dt.Columns.Add("Position", GetType(String))

            dt.Columns.Add("Middlename", GetType(String))
            dt.Columns.Add("Password", GetType(String))
            dt.Columns.Add("Salary", GetType(Double))
            dt.Columns.Add("Contact No.", GetType(String))
            dt.Columns.Add("Vacation Leave", GetType(String))
            dt.Columns.Add("Sick Leave", GetType(String))
            dt.Columns.Add("Forced Leave", GetType(String))
            dt.Columns.Add("Special Privilege", GetType(String))
            dt.Columns.Add("Solo Parent", GetType(String))



            ' Add rows to the DataTable for each Request in the list
            For Each user As List In searchreq
                Dim name As String = String.Concat(user.lastname.FirstOrDefault(), ", ", user.firstname.FirstOrDefault(), " ", user.middlename.FirstOrDefault())


                dt.Rows.Add(user.userid, name, user.firstname.FirstOrDefault(), user.lastname.FirstOrDefault(), user.department, user.position, user.middlename.FirstOrDefault(), user.password, user.salary, user.contactnumber.FirstOrDefault(), user.vacation, user.sickleave, user.forcedleave, user.special_privilege_leave, user.solo_parent_leave)
            Next

            ' Assign the DataTable to the DataSource of the tblPending control
            tblUsers.DataSource = dt
            tblUsers.Refresh()
            tblUsers.ReadOnly = True


            ApplyCommonDataGridViewSettings(tblUsers)

        Catch ex As Exception
            ' Handle any other unexpected exceptions
            MessageBox.Show("An unexpected error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Class List
        Public Property userid As Integer
        Public Property password As String
        Public Property middlename As List(Of String)
        Public Property salary As Double
        Public Property contactnumber As List(Of String)
        Public Property firstname As List(Of String)
        Public Property lastname As List(Of String)
        Public Property department As String
        Public Property position As String
        Public Property vacation As Double
        Public Property sickleave As Double
        Public Property special_privilege_leave As Double
        Public Property solo_parent_leave As Double
        Public Property forcedleave As Double



    End Class


    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        Dim selectedRow As DataGridViewRow = tblUsers.CurrentRow
        Dim userid As String = selectedRow.Cells("User ID").Value.ToString()
        Dim lastname As String = selectedRow.Cells("Lastname").Value.ToString()
        Dim firstname As String = selectedRow.Cells("Firstname").Value.ToString()
        Dim middlename As String = selectedRow.Cells("Middlename").Value.ToString()
        Dim department As String = selectedRow.Cells("Office/Dept").Value.ToString()
        Dim position As String = selectedRow.Cells("Position").Value.ToString()

        Dim password As String = selectedRow.Cells("Password").Value.ToString()
        Dim salary As Double = Convert.ToDouble(selectedRow.Cells("Salary").Value)
        Dim contactnumber As String = selectedRow.Cells("Contact No.").Value.ToString()
        Dim vacation As Double = Convert.ToDouble(selectedRow.Cells("Vacation Leave").Value)
        Dim sickleave As Double = Convert.ToDouble(selectedRow.Cells("Sick Leave").Value)
        Dim forcedleave As Double = Convert.ToDouble(selectedRow.Cells("Forced Leave").Value)
        Dim special_privilege_leave As Double = Convert.ToDouble(selectedRow.Cells("Special Privilege").Value)
        Dim solo_parent_leave As Double = Convert.ToDouble(selectedRow.Cells("Solo Parent").Value)

        ' Check if an instance of frmLeavecard already exists
        Dim existingForm As frmViewuser = Application.OpenForms.OfType(Of frmViewuser)().FirstOrDefault()

        If existingForm IsNot Nothing Then
            ' If an instance exists, close it
            existingForm.Close()
        End If


        Dim frmViewuserInstance As New frmViewuser(userid, lastname, firstname, middlename, password, department, position, salary, contactnumber, vacation, sickleave, forcedleave, special_privilege_leave, solo_parent_leave, _mainForm)
        Me.Close()
        frmViewuserInstance.Show()
    End Sub



    Private Sub TextBoxSearch_TextChanged(sender As Object, e As EventArgs) Handles TextBoxSearch.TextChanged

        dt.Rows.Clear()
        Dim searchTerm As String = TextBoxSearch.Text.Trim().ToLower()

        Dim newsearchreq As New List(Of List)

        For Each request As List In searchreq ' You should keep a copy of the original list
            ' If request.firstname.Any(Function(n) n.ToLower().Contains(searchTerm)) _
            ' Or request.lastname.Any(Function(n) n.ToLower().Contains(searchTerm)) _
            ' Or request.department.ToLower().Contains(searchTerm) Then
            ' MessageBox.Show("Last Name: " & request.lastname.FirstOrDefault())
            'newsearchreq.Add(request)
            'End If
            If request.lastname.Any(Function(n) n.ToLower().Contains(searchTerm)) Or request.department.ToLower().Contains(searchTerm) Then
                newsearchreq.Add(request)

            End If

        Next


        dt = New DataTable()

        dt.Columns.Add("User ID", GetType(Integer))
        dt.Columns.Add("Name", GetType(String))
        dt.Columns.Add("Firstname", GetType(String))
        dt.Columns.Add("Lastname", GetType(String))
        dt.Columns.Add("Office/Dept", GetType(String))
        dt.Columns.Add("Position", GetType(String))

        dt.Columns.Add("Middlename", GetType(String))
        dt.Columns.Add("Password", GetType(String))
        dt.Columns.Add("Salary", GetType(Double))
        dt.Columns.Add("Contact No.", GetType(String))
        dt.Columns.Add("Vacation Leave", GetType(String))
        dt.Columns.Add("Sick Leave", GetType(String))
        dt.Columns.Add("Forced Leave", GetType(String))
        dt.Columns.Add("Special Privilege", GetType(String))
        dt.Columns.Add("Solo Parent", GetType(String))


        ' Add rows to the DataTable for each Request in the list
        For Each user As List In newsearchreq
            Dim name As String = String.Concat(user.lastname.FirstOrDefault(), ", ", user.firstname.FirstOrDefault(), " ", user.middlename.FirstOrDefault())


            dt.Rows.Add(user.userid, name, user.firstname.FirstOrDefault(), user.lastname.FirstOrDefault(), user.department, user.position, user.middlename.FirstOrDefault(), user.password, user.salary, user.contactnumber.FirstOrDefault(), user.vacation, user.sickleave, user.forcedleave, user.special_privilege_leave, user.solo_parent_leave)
        Next

        ' Assign the DataTable to the DataSource of the tblPending control
        tblUsers.DataSource = dt
        tblUsers.Refresh()
        tblUsers.ReadOnly = True


        ApplyCommonDataGridViewSettings(tblUsers)
    End Sub

    Private Async Sub btnFilterdept_Click(sender As Object, e As EventArgs) Handles btnFilterdept.Click
        Dim host As String = My.Settings.host
        Dim accessToken As String = My.Settings.accessToken

        isLoading = True
        If isLoading Then
            btnFilterdept.Enabled = False
            TextBoxSearch.Enabled = False
            btnView.Enabled = False
        End If

        If cmbDept.SelectedItem Is Nothing Then
            MessageBox.Show("Please select a department.")
        Else
            ' Execute your code if both ComboBoxes have selections
            Dim department As String = cmbDept.SelectedItem.ToString()




            ' Check if both combo boxes are empty or set to none
            If (department = "none") Then
                MessageBox.Show("Filtered None")
                Return
            End If

            Try
                ' Create the headers
                HttpClientSingleton.SharedClient.DefaultRequestHeaders.Authorization = New AuthenticationHeaderValue("Bearer", accessToken)

                ' Create the URL with query parameters
                Dim content As New StringContent(JsonConvert.SerializeObject(New With {
                .department = If(department = "none" Or department = "", Nothing, department)
            }), Encoding.UTF8, "application/json")

                ' Create the URL with path parameters
                Dim response As HttpResponseMessage = Await HttpClientSingleton.SharedClient.PostAsync("http://" & host & ":3000/adminside/filteruser", content, cts.Token)

                'response.EnsureSuccessStatusCode()

                Dim responseString As String = Await response.Content.ReadAsStringAsync()

                'Dim requests As List(Of Request) = JsonConvert.DeserializeObject(Of List(Of Request))(responseString)
                searchreq.Clear()
                searchreq = JsonConvert.DeserializeObject(Of List(Of List))(responseString)

                PopulateDataGridView(searchreq)

            Catch ex As OperationCanceledException
                ' MessageBox.Show("Request Cancelled", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Catch ex As HttpRequestException
                MessageBox.Show("Request failed: Please ensure you have an active internet connection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'mainform.Close()
                'Form1.Show()

            End Try

        End If
    End Sub

    Private Sub btnLeavecard_Click(sender As Object, e As EventArgs) Handles btnLeavecard.Click
        Dim selectedRow As DataGridViewRow = tblUsers.CurrentRow
        Dim userID As Integer = Convert.ToInt32(selectedRow.Cells("User ID").Value)

        ' Check if an instance of frmLeavecard already exists
        Dim existingForm As frmLeavecard = Application.OpenForms.OfType(Of frmLeavecard)().FirstOrDefault()

        If existingForm IsNot Nothing Then
            ' If an instance exists, close it
            existingForm.Close()
        End If

        ' Create a new instance of frmLeavecard
        Dim frmViewInstance As New frmLeavecard(userID, _mainForm)

        frmViewInstance.StartPosition = FormStartPosition.Manual
        frmViewInstance.Location = New Point(10, 50) ' Set the desired coordinates here

        ' Close the current form
        Me.Close()

        ' Show the new form
        frmViewInstance.Show()
    End Sub

    Private Sub btnHistory_Click(sender As Object, e As EventArgs) Handles btnHistory.Click
        Dim selectedRow As DataGridViewRow = tblUsers.CurrentRow
        Dim userID As Integer = Convert.ToInt32(selectedRow.Cells("User ID").Value)

        ' Check if an instance of frmLeavecard already exists
        Dim existingForm As frmLeave_history = Application.OpenForms.OfType(Of frmLeave_history)().FirstOrDefault()

        If existingForm IsNot Nothing Then
            ' If an instance exists, close it
            existingForm.Close()
        End If

        ' Create a new instance of frmLeavecard
        Dim frmViewInstance As New frmLeave_history(userID)
        frmViewInstance.Show()
    End Sub

    Private Sub btnDtr_Click(sender As Object, e As EventArgs) Handles btnDtr.Click
        Dim selectedRow As DataGridViewRow = tblUsers.CurrentRow
        Dim userID As Integer = Convert.ToInt32(selectedRow.Cells("User ID").Value)
        Dim employeename As String = Convert.ToString(selectedRow.Cells("Name").Value)
        Dim vacbal As Double = Convert.ToDouble(selectedRow.Cells("Vacation Leave").Value)
        Dim sickbal As Double = Convert.ToDouble(selectedRow.Cells("Sick Leave").Value)

        ' Check if an instance of frmLeavecard already exists
        Dim existingForm As frmDTRentry = Application.OpenForms.OfType(Of frmDTRentry)().FirstOrDefault()

        If existingForm IsNot Nothing Then
            ' If an instance exists, close it
            existingForm.Close()
        End If
        Me.Close()
        ' Create a new instance of frmLeavecard
        Dim frmViewInstance As New frmDTRentry(userID, vacbal, sickbal, employeename, _mainForm)
        frmViewInstance.Show()
    End Sub
End Class
