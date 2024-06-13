Imports System.Net.Http
Imports Newtonsoft.Json
Imports System.Net.Http.Headers
Imports System.Text
Imports System.Threading
Imports Microsoft.VisualBasic.ApplicationServices
Imports System.Reflection


Public Class frmListadmin
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
    Private Async Sub frmListadmin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized

        Dim host As String = My.Settings.host
        Dim accessToken As String = My.Settings.accessToken
        Dim refreshToken As String = My.Settings.refreshToken

        isLoading = True
        If isLoading Then
            TextBoxSearch.Enabled = False
            btnView.Enabled = False
        End If

        Try
            HttpClientSingleton.SharedClient.DefaultRequestHeaders.Authorization = New AuthenticationHeaderValue("Bearer", accessToken)
            Dim response As HttpResponseMessage = Await HttpClientSingleton.SharedClient.GetAsync("http://" & host & ":3000/adminside/getAdmins", cts.Token)
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
            dgv.Columns("Contact No.").Visible = False
            dgv.Columns("Access Level").Visible = False




            ' Change the text color of all cells to blue
            dgv.DefaultCellStyle.ForeColor = Color.Black

            dgv.Columns("Admin ID").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            dgv.Columns("Name").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            dgv.Columns("Office/Dept").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells

            isLoading = False
            TextBoxSearch.Enabled = True
            btnView.Enabled = True
            txtLoading.Visible = False

        Catch ex As Exception
            ' Handle any other unexpected exceptions
            MessageBox.Show("An unexpected error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PopulateDataGridView(requests As List(Of List))
        Try
            dt = New DataTable()

            dt.Columns.Add("Admin ID", GetType(Integer))
            dt.Columns.Add("Name", GetType(String))
            dt.Columns.Add("Firstname", GetType(String))
            dt.Columns.Add("Lastname", GetType(String))
            dt.Columns.Add("Office/Dept", GetType(String))

            dt.Columns.Add("Middlename", GetType(String))
            dt.Columns.Add("Password", GetType(String))
            dt.Columns.Add("Contact No.", GetType(String))
            dt.Columns.Add("Access Level", GetType(String))




            ' Add rows to the DataTable for each Request in the list
            For Each user As List In searchreq
                Dim name As String = String.Concat(user.lastname.FirstOrDefault(), ", ", user.firstname.FirstOrDefault(), " ", user.middlename.FirstOrDefault())


                dt.Rows.Add(user.adminid, name, user.firstname.FirstOrDefault(), user.lastname.FirstOrDefault(), user.department, user.middlename.FirstOrDefault(), user.password, user.contactnumber.FirstOrDefault(), user.access_level)
            Next

            ' Assign the DataTable to the DataSource of the tblPending control
            tblAdmins.DataSource = dt
            tblAdmins.Refresh()
            tblAdmins.ReadOnly = True


            ApplyCommonDataGridViewSettings(tblAdmins)

        Catch ex As Exception
            ' Handle any other unexpected exceptions
            MessageBox.Show("An unexpected error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Public Class List
        Public Property adminid As Integer
        Public Property password As String
        Public Property middlename As List(Of String)
        Public Property contactnumber As List(Of String)
        Public Property firstname As List(Of String)
        Public Property lastname As List(Of String)
        Public Property department As String
        Public Property access_level As String



    End Class

    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        Dim selectedRow As DataGridViewRow = tblAdmins.CurrentRow
        Dim adminid As String = selectedRow.Cells("Admin ID").Value.ToString()
        Dim lastname As String = selectedRow.Cells("Lastname").Value.ToString()
        Dim firstname As String = selectedRow.Cells("Firstname").Value.ToString()
        Dim middlename As String = selectedRow.Cells("Middlename").Value.ToString()
        Dim department As String = selectedRow.Cells("Office/Dept").Value.ToString()

        Dim password As String = selectedRow.Cells("Password").Value.ToString()
        Dim contactnumber As String = selectedRow.Cells("Contact No.").Value.ToString()
        Dim access_level As Double = Convert.ToDouble(selectedRow.Cells("Access Level").Value)

        ' Check if an instance of frmLeavecard already exists
        Dim existingForm As frmViewadmin = Application.OpenForms.OfType(Of frmViewadmin)().FirstOrDefault()

        If existingForm IsNot Nothing Then
            ' If an instance exists, close it
            existingForm.Close()
        End If


        Dim frmViewadminInstance As New frmViewadmin(adminid, lastname, firstname, middlename, department, password, contactnumber, access_level, _mainForm)
        Me.Close()
        frmViewadminInstance.Show()
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

        dt.Columns.Add("Admin ID", GetType(Integer))
        dt.Columns.Add("Name", GetType(String))
        dt.Columns.Add("Firstname", GetType(String))
        dt.Columns.Add("Lastname", GetType(String))
        dt.Columns.Add("Office/Dept", GetType(String))

        dt.Columns.Add("Middlename", GetType(String))
        dt.Columns.Add("Password", GetType(String))
        dt.Columns.Add("Contact No.", GetType(String))
        dt.Columns.Add("Access Level", GetType(String))



        For Each user As List In newsearchreq
            Dim name As String = String.Concat(user.lastname.FirstOrDefault(), ", ", user.firstname.FirstOrDefault(), " ", user.middlename.FirstOrDefault())


            dt.Rows.Add(user.adminid, name, user.firstname.FirstOrDefault(), user.lastname.FirstOrDefault(), user.department, user.middlename.FirstOrDefault(), user.password, user.contactnumber.FirstOrDefault(), user.access_level)
        Next

        ' Assign the DataTable to the DataSource of the tblPending control
        tblAdmins.DataSource = dt
        tblAdmins.Refresh()
        tblAdmins.ReadOnly = True


        ApplyCommonDataGridViewSettings(tblAdmins)
    End Sub


End Class