Imports System.Net.Http
Imports System.Net.Http.Headers
Imports Newtonsoft.Json
Imports System.Text
Imports System.Threading


Public Class frmBalances
    Private isLoading As Boolean = False
    Private searchreq As List(Of Balances)
    Private dt As DataTable
    Private cts As New CancellationTokenSource()



    Private Async Sub frmBalances_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.WindowState = FormWindowState.Maximized

        isLoading = True
        If isLoading Then
            TextBoxSearch.Enabled = False
            btnView.Enabled = False
            btnFilterdept.Enabled = False

        End If

        Try
            Dim host As String = My.Settings.host

            Dim response As HttpResponseMessage = Await HttpClientSingleton.SharedClient.GetAsync("http://" & host & ":3000/adminside/getCredits", cts.Token)
            ' response.EnsureSuccessStatusCode()

            Dim responseString As String = Await response.Content.ReadAsStringAsync()
            ' Dim Credits As List(Of Balances) = JsonConvert.DeserializeObject(Of List(Of Balances))(responseString)
            searchreq = JsonConvert.DeserializeObject(Of List(Of Balances))(responseString)


            PopulateDataGridView(searchreq)




        Catch ex As OperationCanceledException
            'MessageBox.Show("Request Cancelled", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As HttpRequestException
            MessageBox.Show("Request failed: Please ensure you have an active internet connection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'mainform.Close()
            'Form1.Show()

        End Try


        Dim departments() As String = {"none", "CMO", "CTO", "CTEU", "CDRRMO", "CSWDO", "CGSO", "CIPTO", "CHU1", "CHU2", "CHU3", "HRMDO", "IAS", "HCI", "DILG", "OCAd", "OCBO", "OCES", "OCLO", "OCA", "OCAss", "OCCR", "OCVS", "OCAg", "MARKET", "TERMINAL", "PRICTU", "SP-SEC", "PESU", "SH"}

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


        'Change the background color of all cells to light gray
        dgv.DefaultCellStyle.BackColor = Color.White
        dgv.ColumnHeadersDefaultCellStyle.Font = New Font("Arial", 14)
        dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.DeepPink
        dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        ' Change the font size of all cells to 14
        dgv.DefaultCellStyle.Font = New Font("Arial", 12)
        ' Set the SelectionMode to FullRowSelect
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgv.RowHeadersVisible = False


        ' Change the text color of all cells to blue
        dgv.DefaultCellStyle.ForeColor = Color.Black
        dgv.Columns("UserID").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        dgv.Columns("Lastname").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        dgv.Columns("Firstname").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        dgv.Columns("Vacation Leave").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        dgv.Columns("Sick Leave").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells

        isLoading = False
        TextBoxSearch.Enabled = True
        btnFilterdept.Enabled = True
        btnView.Enabled = True
        txtLoading.Visible = False


    End Sub

    Private Sub PopulateDataGridView(requests As List(Of Balances))
        dt = New DataTable()

        dt.Columns.Add("UserID", GetType(Integer))
        dt.Columns.Add("Lastname", GetType(String))
        dt.Columns.Add("Firstname", GetType(String))
        dt.Columns.Add("Vacation Leave", GetType(String))
        dt.Columns.Add("Sick Leave", GetType(String))

        For Each credit As Balances In searchreq

            dt.Rows.Add(credit.userid, credit.lastname.FirstOrDefault(), credit.firstname.FirstOrDefault(), credit.vacation, credit.sickleave)
        Next


        tblBalances.DataSource = dt
        tblBalances.ReadOnly = True

        ApplyCommonDataGridViewSettings(tblBalances)

    End Sub


    Public Class Balances
        Public Property userid As Integer
        Public Property firstname As List(Of String)
        Public Property lastname As List(Of String)
        Public Property vacation As Decimal
        Public Property sickleave As Decimal
    End Class

    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        Dim selectedRow As DataGridViewRow = tblBalances.CurrentRow
        Dim userID As Integer = Convert.ToInt32(selectedRow.Cells("UserID").Value)

        ' Check if an instance of frmLeavecard already exists
        Dim existingForm As frmLeavecard = Application.OpenForms.OfType(Of frmLeavecard)().FirstOrDefault()

        If existingForm IsNot Nothing Then
            ' If an instance exists, close it
            existingForm.Close()
        End If

        ' Create a new instance of frmLeavecard
        ' Dim frmViewInstance As New frmLeavecard(userID)

        ' frmViewInstance.StartPosition = FormStartPosition.Manual
        ' frmViewInstance.Location = New Point(10, 50) ' Set the desired coordinates here

        ' Close the current form
        Me.Close()

        ' Show the new form
        'frmViewInstance.Show()
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
            MessageBox.Show("Please select both year and month.")
        Else
            ' Execute your code if both ComboBoxes have selections
            Dim department As String = cmbDept.SelectedItem.ToString()



            Dim reqStatus As String = "Approved" ' or get this value from somewhere else if it's dynamic

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
                .department = If(department = "none" Or department = "", Nothing, department),
                .reqStatus = reqStatus
            }), Encoding.UTF8, "application/json")

                ' Create the URL with path parameters
                Dim response As HttpResponseMessage = Await HttpClientSingleton.SharedClient.PostAsync("http://" & host & ":3000/adminside/creditsdeptfilter", content, cts.Token)

                'response.EnsureSuccessStatusCode()

                Dim responseString As String = Await response.Content.ReadAsStringAsync()

                'Dim requests As List(Of Request) = JsonConvert.DeserializeObject(Of List(Of Request))(responseString)
                searchreq.Clear()
                searchreq = JsonConvert.DeserializeObject(Of List(Of Balances))(responseString)

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

    Private Sub TextBoxSearch_TextChanged(sender As Object, e As EventArgs) Handles TextBoxSearch.TextChanged
        ' Perform a case-insensitive search on the relevant fields
        dt.Rows.Clear()
        Dim searchTerm As String = TextBoxSearch.Text.Trim().ToLower()

        Dim newsearchreq As New List(Of Balances)


        For Each request As Balances In searchreq ' You should keep a copy of the original list
            ' If request.firstname.Any(Function(n) n.ToLower().Contains(searchTerm)) _
            ' Or request.lastname.Any(Function(n) n.ToLower().Contains(searchTerm)) _
            ' Or request.department.ToLower().Contains(searchTerm) Then
            ' MessageBox.Show("Last Name: " & request.lastname.FirstOrDefault())
            'newsearchreq.Add(request)
            'End If
            If request.lastname.Any(Function(n) n.ToLower().Contains(searchTerm)) Then
                newsearchreq.Add(request)

            End If
        Next

        dt = New DataTable()

        dt.Columns.Add("UserID", GetType(Integer))
        dt.Columns.Add("Lastname", GetType(String))
        dt.Columns.Add("Firstname", GetType(String))
        dt.Columns.Add("Vacation Leave", GetType(String))
        dt.Columns.Add("Sick Leave", GetType(String))

        For Each credit As Balances In newsearchreq

            dt.Rows.Add(credit.userid, credit.lastname.FirstOrDefault(), credit.firstname.FirstOrDefault(), credit.vacation, credit.sickleave)
        Next


        tblBalances.DataSource = dt
        tblBalances.ReadOnly = True


        ApplyCommonDataGridViewSettings(tblBalances)

    End Sub
End Class
