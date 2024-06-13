Imports System.Net.Http
Imports Newtonsoft.Json
Imports System.Net.Http.Headers
Imports System.Text
Imports System.Threading

Public Class frmReports
    Private searchreq As List(Of Request)
    Private dt As DataTable
    Private isLoading As Boolean = False
    Private cts As New CancellationTokenSource()


    Dim currentPageIndex As Integer = 0
    Const ROWS_PER_PAGE As Integer = 5
    Private Async Sub frmReports_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.WindowState = FormWindowState.Maximized

        Dim accessToken As String = My.Settings.accessToken
        Dim refreshToken As String = My.Settings.refreshToken

        isLoading = True
        If isLoading Then
            btnFilterdept.Enabled = False
            TextBoxSearch.Enabled = False
            btnFilter.Enabled = False
        End If

        Dim accessLevel As String = My.Settings.accessLevel
        If accessLevel = "d033e22ae348aeb5660fc2140aec35850c4da997" Then
            cmbDept.Visible = True
            btnFilterdept.Visible = True
            Label3.Visible = True
        End If

        Try
            Dim host As String = My.Settings.host
            HttpClientSingleton.SharedClient.DefaultRequestHeaders.Authorization = New AuthenticationHeaderValue("Bearer", accessToken)
            Dim response As HttpResponseMessage = Await HttpClientSingleton.SharedClient.GetAsync("http://" & host & ":3000/adminside/reportreq", cts.Token)
            'response.EnsureSuccessStatusCode()

            Dim responseString As String = Await response.Content.ReadAsStringAsync()

            ' Deserialize the JSON response into a list of Request objects
            'Dim requests As List(Of Request) = JsonConvert.DeserializeObject(Of List(Of Request))(responseString)

            searchreq = JsonConvert.DeserializeObject(Of List(Of Request))(responseString)

            PopulateDataGridView(searchreq)



        Catch ex As OperationCanceledException
            ' MessageBox.Show("Request Cancelled", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As HttpRequestException
            MessageBox.Show("Request failed: Please ensure you have an active internet connection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'mainform.Close()
            'Form1.Show()

        End Try


        ' Define arrays for years and months
        Dim years() As String = {"none", "2024", "2023", "2022", "2021", "2020"}
        Dim months() As String = {"none", "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"}


        ' Add years to the Year ComboBox
        For Each year As String In years
            cmbYear.Items.Add(year)
        Next

        ' Add months to the Month ComboBox
        For Each month As String In months
            cmbMonth.Items.Add(month)
        Next
        cmbYear.DropDownStyle = ComboBoxStyle.DropDownList
        cmbMonth.DropDownStyle = ComboBoxStyle.DropDownList
        cmbMonth.SelectedItem = "none"
        cmbYear.SelectedItem = "none"


        Dim departments() As String = {"none", "ADMIN", "HRMDO", "CMO", "CBO", "CLSO", "OCES", "BAC", "PRICTU", "PESU", "SP", "OCA", "CCRO", "CASSO", "CPDO", "DILG", "CTO", "CTEU", "HCI", "PDAO", "CIPTO", "OGS", "CDRRMO", "CSWDO", "CGSO", "IAS", "SH", "VET", "OCLO", "OCVS", "CENRO", "OCAG", "MARKET", "TERMINAL", "CHU 1", "CHU 2", "CHU 3"}

        ' Add years to the Year ComboBox
        For Each department As String In departments
            cmbDept.Items.Add(department)
        Next


        cmbDept.DropDownStyle = ComboBoxStyle.DropDownList
        cmbDept.SelectedItem = "none"
    End Sub


    Protected Overrides Sub OnFormClosing(e As FormClosingEventArgs)
        If cts IsNot Nothing Then
            cts.Cancel()
        End If
        MyBase.OnFormClosing(e)
    End Sub


    Private Sub ApplyCommonDataGridViewSettings(dgv As DataGridView)
        Try
            dgv.Columns("reasonid").Visible = False
            dgv.Columns("middlename").Visible = False
            dgv.Columns("Firstname").Visible = False
            dgv.Columns("Lastname").Visible = False
            dgv.Columns("Position").Visible = False
            dgv.Columns("salary").Visible = False
            dgv.Columns("description").Visible = False
            dgv.Columns("duration").Visible = False
            dgv.Columns("commutation").Visible = False
            dgv.Columns("Contact No.").Visible = False

            dgv.Columns("vacation").Visible = False
            dgv.Columns("sickleave").Visible = False
            dgv.Columns("deducted_vacation").Visible = False
            dgv.Columns("deducted_sick").Visible = False
            dgv.Columns("process_no").Visible = False
            dgv.Columns("request_status").Visible = False

            dgv.DefaultCellStyle.BackColor = Color.White
            dgv.ColumnHeadersDefaultCellStyle.Font = New Font("Arial", 14)
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.DeepPink
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            dgv.DefaultCellStyle.Font = New Font("Arial", 12)
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            dgv.RowHeadersVisible = False


            dgv.DefaultCellStyle.ForeColor = Color.Black
            dgv.Columns("Control No.").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            dgv.Columns("Leave Type").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            dgv.Columns("Inclusive Dates").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            dgv.Columns("Office/Dept").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            dgv.Columns("Name").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            dgv.Columns("Date Filed").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells


            isLoading = False
            TextBoxSearch.Enabled = True
            btnFilterdept.Enabled = True
            txtLoading.Visible = False
            btnFilter.Enabled = True

        Catch ex As Exception
            ' Handle any other unexpected exceptions
            MessageBox.Show("An unexpected error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub PopulateDataGridView(requests As List(Of Request))
        Try
            dt = New DataTable()

            dt.Columns.Add("Control No.", GetType(Integer))
            dt.Columns.Add("Name", GetType(String))
            dt.Columns.Add("Firstname", GetType(String))
            dt.Columns.Add("Lastname", GetType(String))
            dt.Columns.Add("Leave Type", GetType(String))
            dt.Columns.Add("Inclusive Dates", GetType(String))
            dt.Columns.Add("Office/Dept", GetType(String))

            dt.Columns.Add("reasonid", GetType(Integer))


            dt.Columns.Add("middlename", GetType(String))
            dt.Columns.Add("salary", GetType(Double))
            dt.Columns.Add("Position", GetType(String))
            dt.Columns.Add("Date Filed", GetType(String))
            dt.Columns.Add("Contact No.", GetType(String))
            dt.Columns.Add("Remarks", GetType(String))

            dt.Columns.Add("description", GetType(String))
            dt.Columns.Add("duration", GetType(Double))
            dt.Columns.Add("commutation", GetType(String))
            dt.Columns.Add("vacation", GetType(Double))
            dt.Columns.Add("sickleave", GetType(Double))
            dt.Columns.Add("deducted_vacation", GetType(Double))
            dt.Columns.Add("deducted_sick", GetType(Double))
            dt.Columns.Add("process_no", GetType(Integer))
            dt.Columns.Add("request_status", GetType(String))

            For Each request As Request In searchreq
                Dim sLeavetype As String
                Select Case request.leaveid
                    Case 1
                        sLeavetype = "Vacation Leave"
                    Case 2
                        sLeavetype = "Mandatory/Forced"
                    Case 3
                        sLeavetype = "Sick Leave"
                    Case 4
                        sLeavetype = "Maternity Leave"
                    Case 5
                        sLeavetype = "Paternity Leave"
                    Case 6
                        sLeavetype = "Special Privilege"
                    Case 7
                        sLeavetype = "Solo Parent Leave"
                    Case 8
                        sLeavetype = "Study Leave"
                    Case 9
                        sLeavetype = "10-Day VAWC Leave"
                    Case 10
                        sLeavetype = "Rehabilitation Privilege"
                    Case 11
                        sLeavetype = "Special Leave For Women"
                    Case 12
                        sLeavetype = "Special Emergency"
                    Case 13
                        sLeavetype = "Adoption Leave"
                    Case 14
                        sLeavetype = "Monetization of Leave Credits"
                    Case 15
                        sLeavetype = "Terminal Leave"
                    Case Else
                        sLeavetype = request.description
                End Select
                Dim fullName As String = String.Concat(request.lastname.FirstOrDefault(), ", ", request.firstname.FirstOrDefault(), " ", request.middlename.FirstOrDefault())

                dt.Rows.Add(request.requestid, fullName, request.firstname.FirstOrDefault(), request.lastname.FirstOrDefault(), sLeavetype, request.inclusivedates, request.department, request.reasonid, request.middlename.FirstOrDefault(), request.salary, request.position, request.datefiled.ToString().Substring(0, 10), request.contactnumber.FirstOrDefault(), request.request_status, request.description, request.duration, request.commutation, request.vacationCreds, request.sickCreds, request.deducted_vacation, request.deducted_sick, request.process_no, request.request_status)
            Next

            tblReports.DataSource = dt
            tblReports.Refresh()
            tblReports.ReadOnly = True
            tblReports.GridColor = Color.FloralWhite

            ApplyCommonDataGridViewSettings(tblReports)
        Catch ex As Exception
            ' Handle any other unexpected exceptions
            MessageBox.Show("An unexpected error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



    Public Class Request
        Public Property requestid As Integer
        Public Property firstname As List(Of String)
        Public Property lastname As List(Of String)
        Public Property middlename As List(Of String)
        Public Property contactnumber As List(Of String)
        Public Property salary As Double
        Public Property position As String
        Public Property department As String
        Public Property leaveid As Integer
        Public Property reasonid As Integer
        Public Property datefiled As String
        Public Property description As String
        Public Property duration As Double
        Public Property inclusivedates As String
        Public Property commutation As String
        Public Property vacation As Double
        Public Property sickleave As Double
        Public Property vacationCreds As Double
        Public Property sickCreds As Double
        Public Property deducted_vacation As Double
        Public Property deducted_sick As Double
        Public Property process_no As Integer
        Public Property request_status As String
    End Class

    Dim months() As String = {"none", "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"}

    Private Async Sub btnFilter_Click(sender As Object, e As EventArgs) Handles btnFilter.Click
        Dim host As String = My.Settings.host
        Dim accessToken As String = My.Settings.accessToken

        isLoading = True
        If isLoading Then
            btnFilterdept.Enabled = False
            TextBoxSearch.Enabled = False
            btnFilter.Enabled = False
        End If

        If cmbYear.SelectedItem Is Nothing OrElse cmbMonth.SelectedItem Is Nothing Then
            MessageBox.Show("Please select both year and month.")
        Else
            ' Execute your code if both ComboBoxes have selections
            Dim year As String = cmbYear.SelectedItem.ToString()
            Dim month As String = cmbMonth.SelectedItem.ToString()



            Dim reqStatus As String = "Approved" ' or get this value from somewhere else if it's dynamic

            ' Check if both combo boxes are empty or set to none
            If (year = "none" And month = "none") Or (year = "" And month = "") Then
                MessageBox.Show("Filtered None")
                PopulateDataGridView(searchreq)
                btnFilterdept.Enabled = True
                TextBoxSearch.Enabled = True
                btnFilter.Enabled = True
                Return
            End If


            ' Convert month name to number
            Dim monthNumber As Integer = Array.IndexOf(months, month)
            If monthNumber < 10 Then
                month = "0" & monthNumber.ToString()
            Else
                month = monthNumber.ToString()
            End If

            Try
                ' Create the headers
                HttpClientSingleton.SharedClient.DefaultRequestHeaders.Authorization = New AuthenticationHeaderValue("Bearer", accessToken)

                ' Create the URL with query parameters
                Dim content As New StringContent(JsonConvert.SerializeObject(New With {
                .year = If(year = "none" Or year = "", Nothing, year),
                .month = If(month = "none" Or month = "" Or month = "00", Nothing, month),
                .reqStatus = reqStatus
            }), Encoding.UTF8, "application/json")

                ' Create the URL with path parameters
                Dim response As HttpResponseMessage = Await HttpClientSingleton.SharedClient.PostAsync("http://" & host & ":3000/adminside/reportreqfilter", content, cts.Token)

                'response.EnsureSuccessStatusCode()

                Dim responseString As String = Await response.Content.ReadAsStringAsync()

                searchreq = JsonConvert.DeserializeObject(Of List(Of Request))(responseString)


                PopulateDataGridView(searchreq)

            Catch ex As OperationCanceledException
                'MessageBox.Show("Request Cancelled", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Catch ex As HttpRequestException
                MessageBox.Show("Request failed: Please ensure you have an active internet connection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'mainform.Close()
                'Form1.Show()

            End Try

        End If
    End Sub

    Private Async Sub btnFilterdept_Click(sender As Object, e As EventArgs) Handles btnFilterdept.Click
        Dim host As String = My.Settings.host
        Dim accessToken As String = My.Settings.accessToken

        isLoading = True
        If isLoading Then
            btnFilterdept.Enabled = False
            TextBoxSearch.Enabled = False
            btnFilter.Enabled = False
        End If

        If cmbDept.SelectedItem Is Nothing Then
            MessageBox.Show("Please select both year and month.")
        Else
            ' Execute your code if both ComboBoxes have selections
            Dim department As String = cmbDept.SelectedItem.ToString()




            ' Check if both combo boxes are empty or set to none
            If (department = "none") Then
                MessageBox.Show("Filtered None")
                PopulateDataGridView(searchreq)
                btnFilterdept.Enabled = True
                TextBoxSearch.Enabled = True
                btnFilter.Enabled = True
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
                Dim response As HttpResponseMessage = Await HttpClientSingleton.SharedClient.PostAsync("http://" & host & ":3000/adminside/reportdeptfilter", content, cts.Token)

                'response.EnsureSuccessStatusCode()

                Dim responseString As String = Await response.Content.ReadAsStringAsync()

                'Dim requests As List(Of Request) = JsonConvert.DeserializeObject(Of List(Of Request))(responseString)
                searchreq.Clear()
                searchreq = JsonConvert.DeserializeObject(Of List(Of Request))(responseString)

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

        Dim newsearchreq As New List(Of Request)


        For Each request As Request In searchreq ' You should keep a copy of the original list
            ' If request.firstname.Any(Function(n) n.ToLower().Contains(searchTerm)) _
            ' Or request.lastname.Any(Function(n) n.ToLower().Contains(searchTerm)) _
            ' Or request.department.ToLower().Contains(searchTerm) Then
            ' MessageBox.Show("Last Name: " & request.lastname.FirstOrDefault())
            'newsearchreq.Add(request)
            'End If
            If request.lastname.Any(Function(n) n.ToLower().Contains(searchTerm)) Or request.department.ToLower().Contains(searchTerm) Or request.request_status.ToLower().Contains(searchTerm) Then
                newsearchreq.Add(request)
            End If
        Next



        dt = New DataTable()

        dt.Columns.Add("Control No.", GetType(Integer))
        dt.Columns.Add("Name", GetType(String))
        dt.Columns.Add("Firstname", GetType(String))
        dt.Columns.Add("Lastname", GetType(String))
        dt.Columns.Add("Leave Type", GetType(String))
        dt.Columns.Add("Inclusive Dates", GetType(String))
        dt.Columns.Add("Office/Dept", GetType(String))

        dt.Columns.Add("reasonid", GetType(Integer))


        dt.Columns.Add("middlename", GetType(String))
        dt.Columns.Add("salary", GetType(Double))
        dt.Columns.Add("Position", GetType(String))
        dt.Columns.Add("Date Filed", GetType(String))
        dt.Columns.Add("Contact No.", GetType(String))
        dt.Columns.Add("Remarks", GetType(String))

        dt.Columns.Add("description", GetType(String))
        dt.Columns.Add("duration", GetType(Double))
        dt.Columns.Add("commutation", GetType(String))
        dt.Columns.Add("vacation", GetType(Double))
        dt.Columns.Add("sickleave", GetType(Double))
        dt.Columns.Add("deducted_vacation", GetType(Double))
        dt.Columns.Add("deducted_sick", GetType(Double))
        dt.Columns.Add("process_no", GetType(Integer))
        dt.Columns.Add("request_status", GetType(String))

        For Each request As Request In newsearchreq
            Dim sLeavetype As String
            Select Case request.leaveid
                Case 1
                    sLeavetype = "Vacation Leave"
                Case 2
                    sLeavetype = "Mandatory/Forced"
                Case 3
                    sLeavetype = "Sick Leave"
                Case 4
                    sLeavetype = "Maternity Leave"
                Case 5
                    sLeavetype = "Paternity Leave"
                Case 6
                    sLeavetype = "Special Privilege"
                Case 7
                    sLeavetype = "Solo Parent Leave"
                Case 8
                    sLeavetype = "Study Leave"
                Case 9
                    sLeavetype = "10-Day VAWC Leave"
                Case 10
                    sLeavetype = "Rehabilitation Privilege"
                Case 11
                    sLeavetype = "Special Leave For Women"
                Case 12
                    sLeavetype = "Special Emergency"
                Case 13
                    sLeavetype = "Adoption Leave"
                Case 14
                    sLeavetype = "Monetization of Leave Credits"
                Case 15
                    sLeavetype = "Terminal Leave"
                Case Else
                    sLeavetype = request.description
            End Select

            Dim fullName As String = String.Concat(request.lastname.FirstOrDefault(), ", ", request.firstname.FirstOrDefault(), " ", request.middlename.FirstOrDefault())

            dt.Rows.Add(request.requestid, fullName, request.firstname.FirstOrDefault(), request.lastname.FirstOrDefault(), sLeavetype, request.inclusivedates, request.department, request.reasonid, request.middlename.FirstOrDefault(), request.salary, request.position, request.datefiled.ToString().Substring(0, 10), request.contactnumber.FirstOrDefault(), request.request_status, request.description, request.duration, request.commutation, request.vacationCreds, request.sickCreds, request.deducted_vacation, request.deducted_sick, request.process_no, request.request_status)
        Next

        tblReports.DataSource = dt
        tblReports.Refresh()
        tblReports.ReadOnly = True
        tblReports.GridColor = Color.FloralWhite

        ApplyCommonDataGridViewSettings(tblReports)
    End Sub


End Class