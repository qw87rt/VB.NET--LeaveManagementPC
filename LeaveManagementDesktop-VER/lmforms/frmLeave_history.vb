Imports System.Drawing.Printing
Imports System.Drawing.Text
Imports System.Net.Http
Imports System.Net.Http.Headers
Imports Newtonsoft.Json
Imports System.Text
Imports System.Threading
Imports System.Globalization
Imports LeaveManagementDesktop_VER.frmLeavecard
Imports System.Reflection.Metadata



Public Class frmLeave_history


    Private dt As DataTable
    Private isLoading As Boolean = False
    Private cts As New CancellationTokenSource()
    Private searchreq As List(Of Request)
    Private userID As Integer


    Dim currentPageIndex As Integer = 0
    Const ROWS_PER_PAGE As Integer = 5

    Public Sub New(userID As Integer)
        InitializeComponent()
        Me.userID = userID
    End Sub

    Private Async Sub frmLeave_history_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim accessToken As String = My.Settings.accessToken
        Dim refreshToken As String = My.Settings.refreshToken

        isLoading = True
        If isLoading Then
            'pagesetup.Enabled = False
        End If


        Try
            Dim host As String = My.Settings.host

            Using client As New HttpClient()
                client.DefaultRequestHeaders.Authorization = New AuthenticationHeaderValue("Bearer", accessToken)

                ' Construct the request URL
                Dim requestUrl As String = $"http://" & host & ":3000/adminside/leave_history"

                ' Create the request body
                Dim requestBody As New Dictionary(Of String, String) From {
                    {"userid", userID.ToString()}
                }
                Dim jsonContent As New StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json")

                ' Send the POST request
                Dim response As HttpResponseMessage = Await HttpClientSingleton.SharedClient.PostAsync(requestUrl, jsonContent, cts.Token)

                ' Check if the response is successful
                If response.IsSuccessStatusCode Then
                    ' Read the response content as a string
                    Dim responseContent As String = Await response.Content.ReadAsStringAsync()

                    ' Deserialize the JSON response into a list of Request objects
                    searchreq = JsonConvert.DeserializeObject(Of List(Of Request))(responseContent)

                    ' Populate the DataGridView with the fetched data
                    PopulateDataGridView(searchreq)
                Else
                    ' Handle the error case
                    MessageBox.Show($"Request failed: {response.StatusCode} - {response.ReasonPhrase}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End Using

        Catch ex As OperationCanceledException
            '    MessageBox.Show("Request Cancelled", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)


        Catch ex As HttpRequestException
            MessageBox.Show($"Request failed: {ex.Message}. Please contact support.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'mainform.Close()
            ' Form1.Show()

        End Try

    End Sub


    Private Sub ApplyCommonDataGridViewSettings(dgv As DataGridView)

        Try
            dgv.Columns("User ID").Visible = False
            dgv.Columns("reasonid").Visible = False
            dgv.Columns("Firstname").Visible = False
            dgv.Columns("Lastname").Visible = False
            dgv.Columns("Name").Visible = False
            dgv.Columns("Office/Dept").Visible = False
            dgv.Columns("Position").Visible = False

            dgv.Columns("middlename").Visible = False
            dgv.Columns("salary").Visible = False
            dgv.Columns("description").Visible = False
            dgv.Columns("duration").Visible = False
            dgv.Columns("commutation").Visible = False
            dgv.Columns("vacation").Visible = False
            dgv.Columns("sickleave").Visible = False
            dgv.Columns("deducted_vacation").Visible = False
            dgv.Columns("deducted_sick").Visible = False
            dgv.Columns("process_no").Visible = False
            dgv.Columns("request_status").Visible = False


            dgv.DefaultCellStyle.BackColor = Color.White
            dgv.ColumnHeadersDefaultCellStyle.Font = New Font("Arial", 11)
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.DeepPink
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            dgv.DefaultCellStyle.Font = New Font("Arial", 9)
            dgv.MultiSelect = False
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            dgv.RowHeadersVisible = False


            dgv.DefaultCellStyle.ForeColor = Color.Black
            dgv.Columns("Control No.").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            'dgv.Columns("Name").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            dgv.Columns("Leave Type").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            dgv.Columns("Inclusive Dates").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            ' dgv.Columns("Office/Dept").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            ' dgv.Columns("Position").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            dgv.Columns("Date Filed").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells


            isLoading = False

            txtLoading.Visible = False
        Catch ex As NullReferenceException
            ' Handle the exception, e.g., by logging the error or displaying a message to the user.
            ' For example:
            ' MessageBox.Show("An error occurred while applying settings to the DataGridView: " & ex.Message)
        End Try
    End Sub


    Private Sub PopulateDataGridView(requests As List(Of Request))
        dt = New DataTable()

        dt.Columns.Add("User ID", GetType(Integer))
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

        dt.Columns.Add("description", GetType(String))
        dt.Columns.Add("duration", GetType(Double))
        dt.Columns.Add("commutation", GetType(String))
        dt.Columns.Add("vacation", GetType(Double))
        dt.Columns.Add("sickleave", GetType(Double))
        dt.Columns.Add("deducted_vacation", GetType(Double))
        dt.Columns.Add("deducted_sick", GetType(Double))
        dt.Columns.Add("process_no", GetType(Integer))
        dt.Columns.Add("request_status", GetType(String))


        Dim name As String = " "

        For Each request As Request In searchreq

            Dim sLeavetype As String = ""
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

            name = String.Concat(request.lastname.FirstOrDefault(), ", ", request.firstname.FirstOrDefault(), " ", request.middlename.FirstOrDefault())
            txtName.Text = name

            dt.Rows.Add(request.userid, request.requestid, Name, request.firstname.FirstOrDefault(), request.lastname.FirstOrDefault(), sLeavetype, request.inclusivedates, request.department, request.reasonid, request.middlename.FirstOrDefault(), request.salary, request.position, request.datefiled.ToString().Substring(0, 10), request.description, request.duration, request.commutation, request.vacationCreds, request.sickCreds, request.deducted_vacation, request.deducted_sick, request.process_no, request.request_status)
        Next

        tblHistory.DataSource = dt
        tblHistory.Refresh()
        tblHistory.ReadOnly = True
        tblHistory.GridColor = Color.FloralWhite

        ApplyCommonDataGridViewSettings(tblHistory)

    End Sub

    Protected Overrides Sub OnFormClosing(e As FormClosingEventArgs)
        If cts IsNot Nothing Then
            cts.Cancel()
        End If
        MyBase.OnFormClosing(e)
    End Sub








    Public Class Request
        Public Property userid As Integer
        Public Property requestid As Integer
        Public Property firstname As List(Of String)
        Public Property lastname As List(Of String)
        Public Property middlename As List(Of String)
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



End Class
