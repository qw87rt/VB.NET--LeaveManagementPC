Imports System.Drawing.Printing
Imports System.Drawing.Text
Imports System.Net.Http
Imports System.Net.Http.Headers
Imports Newtonsoft.Json
Imports System.Text
Imports System.Threading
Imports System.Globalization

Public Class frmApproved

    Private _mainForm As mainform

    Private searchreq As List(Of Request)
    Private dt As DataTable
    Private isLoading As Boolean = False
    Private cts As New CancellationTokenSource()



    Public Sub New(mainForm As mainform)
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        _mainForm = mainForm
    End Sub

    Private Async Sub frmApproved_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.WindowState = FormWindowState.Maximized

        Dim accessToken As String = My.Settings.accessToken
        Dim refreshToken As String = My.Settings.refreshToken

        isLoading = True
        If isLoading Then
            btnFilterdept.Enabled = False
            TextBoxSearch.Enabled = False
            btnView.Enabled = False
            print.Enabled = False
            btnPrint.Enabled = False
            pagesetup.Enabled = False
            btnFilter.Enabled = False
        End If

        Try
            Dim host As String = My.Settings.host
            HttpClientSingleton.SharedClient.DefaultRequestHeaders.Authorization = New AuthenticationHeaderValue("Bearer", accessToken)
            Dim response As HttpResponseMessage = Await HttpClientSingleton.SharedClient.GetAsync("http://" & host & ":3000/adminside/approvedrequest", cts.Token)
            'response.EnsureSuccessStatusCode()

            Dim responseString As String = Await response.Content.ReadAsStringAsync()

            ' Deserialize the JSON response into a list of Request objects
            'Dim requests As List(Of Request) = JsonConvert.DeserializeObject(Of List(Of Request))(responseString)

            searchreq = JsonConvert.DeserializeObject(Of List(Of Request))(responseString)

            PopulateDataGridView(searchreq)

        Catch ex As OperationCanceledException
            '    MessageBox.Show("Request Cancelled", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As HttpRequestException
            MessageBox.Show($"Request failed: {ex.Message}. Please contact support.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'mainform.Close()
            ' Form1.Show()
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

        cmbYear.SelectedItem = "none"
        cmbMonth.SelectedItem = "none"
        cmbYear.DropDownStyle = ComboBoxStyle.DropDownList
        cmbMonth.DropDownStyle = ComboBoxStyle.DropDownList

        Dim accessLevel As String = My.Settings.accessLevel
        If accessLevel = "d033e22ae348aeb5660fc2140aec35850c4da997" Then
            btnFilterdept.Visible = True
            Label3.Visible = True
            cmbDept.Visible = True
        End If

        Dim departments() As String = {"none", "ADMIN", "HRMDO", "CMO", "CBO", "CLSO", "OCES", "BAC", "PRICTU", "PESU", "SP", "OCA", "CCRO", "CASSO", "CPDO", "DILG", "CTO", "CTEU", "HCI", "PDAO", "CIPTO", "OGS", "CDRRMO", "CSWDO", "CGSO", "IAS", "SH", "VET", "OCLO", "OCVS", "CENRO", "OCAG", "MARKET", "TERMINAL", "CHU 1", "CHU 2", "CHU 3"}

        ' Add years to the Year ComboBox
        For Each department As String In departments
            cmbDept.Items.Add(department)
        Next

        cmbDept.SelectedItem = "none"
        cmbDept.DropDownStyle = ComboBoxStyle.DropDownList
    End Sub

    Private Sub ApplyCommonDataGridViewSettings(dgv As DataGridView)

        Try
            dgv.Columns("User ID").Visible = False
            dgv.Columns("reasonid").Visible = False
            dgv.Columns("Firstname").Visible = False
            dgv.Columns("Lastname").Visible = False
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
            ' dgv.Columns("Date Received").Visible = False
            dgv.Columns("Date Updated").Visible = False

            dgv.DefaultCellStyle.BackColor = Color.White
            dgv.ColumnHeadersDefaultCellStyle.Font = New Font("Arial", 14)
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.DeepPink
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            dgv.DefaultCellStyle.Font = New Font("Arial", 12)
            dgv.MultiSelect = False
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            dgv.RowHeadersVisible = False

            dgv.DefaultCellStyle.ForeColor = Color.Black
            dgv.Columns("Control No.").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            dgv.Columns("Name").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            dgv.Columns("Leave Type").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            dgv.Columns("Inclusive Dates").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            dgv.Columns("Office/Dept").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            dgv.Columns("Position").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            dgv.Columns("Date Filed").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells

            isLoading = False
            TextBoxSearch.Enabled = True
            btnFilterdept.Enabled = True
            btnView.Enabled = True
            print.Enabled = True
            btnPrint.Enabled = True
            pagesetup.Enabled = True
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
            dt.Columns.Add("Date Approved", GetType(String))
            dt.Columns.Add("Date Updated", GetType(String))

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

                Dim dateString As String = request.updated_at.ToString()
                Dim dateValue As DateTime
                Dim formatProvider As IFormatProvider = CultureInfo.InvariantCulture
                Dim formattedUpdatedAt As String = ""

                If DateTime.TryParseExact(dateString, New String() {"yyyy-MM-dd", "MM-dd-yyyy"}, formatProvider, DateTimeStyles.None, dateValue) Then
                    formattedUpdatedAt = dateValue.ToString("MMMM yyyy", formatProvider)
                End If

                Dim name As String = String.Concat(request.lastname.FirstOrDefault(), ", ", request.firstname.FirstOrDefault(), " ", request.middlename.FirstOrDefault())

                dt.Rows.Add(request.userid, request.requestid, name, request.firstname.FirstOrDefault(), request.lastname.FirstOrDefault(), sLeavetype, request.inclusivedates, request.department, request.reasonid, request.middlename.FirstOrDefault(), request.salary, request.position, request.datefiled.ToString().Substring(0, 10), request.description, request.duration, request.commutation, request.vacationCreds, request.sickCreds, request.deducted_vacation, request.deducted_sick, request.process_no, request.request_status, request.datereceived, formattedUpdatedAt)
            Next

            tblApproved.DataSource = dt
            tblApproved.Refresh()
            tblApproved.ReadOnly = True
            tblApproved.GridColor = Color.FloralWhite

            ApplyCommonDataGridViewSettings(tblApproved)
        Catch ex As Exception
            ' Handle any other unexpected exceptions
            MessageBox.Show("An unexpected error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Protected Overrides Sub OnFormClosing(e As FormClosingEventArgs)
        If cts IsNot Nothing Then
            cts.Cancel()
        End If
        MyBase.OnFormClosing(e)
    End Sub

    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        Dim selectedRow = tblApproved.CurrentRow
        If selectedRow IsNot Nothing AndAlso selectedRow.Cells("Control No.").Value IsNot Nothing Then
            Try
                Dim userid = Convert.ToInt32(selectedRow.Cells("User ID").Value)
                Dim requestId = Convert.ToInt32(selectedRow.Cells("Control No.").Value)
                Dim request_status = Convert.ToString(selectedRow.Cells("request_status").Value)

                ' Check if an instance of frmLeavecard already exists
                Dim existingForm As frmView = Application.OpenForms.OfType(Of frmView)().FirstOrDefault()

                If existingForm IsNot Nothing Then
                    ' If an instance exists, close it
                    existingForm.Close()
                End If

                Dim frmViewInstance As New frmView(requestId, userid, _mainForm)

                Close()

                frmViewInstance.Show()
            Catch ex As Exception
                MessageBox.Show("Invalid request ID. Please select a valid row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            MessageBox.Show("No row selected. Please select a row to view details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
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
        Public Property datereceived As String
        Public Property updated_at As String

    End Class

    Private Sub docLeavereq_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles docLeavereq.PrintPage
        Dim font As New Font("Arial", 16, FontStyle.Regular)
        Dim selectedRow As DataGridViewRow = tblApproved.CurrentRow

        ' Check if a row is selected
        If selectedRow IsNot Nothing Then
            Dim requestId As Integer = Convert.ToInt32(selectedRow.Cells("Control No.").Value)
            Dim firstName As String = Convert.ToString(selectedRow.Cells("Firstname").Value)
            Dim lastName As String = Convert.ToString(selectedRow.Cells("Lastname").Value)
            Dim middleName As String = Convert.ToString(selectedRow.Cells("middlename").Value)
            Dim dateFiled As String = Convert.ToString(selectedRow.Cells("Date Filed").Value)
            Dim position As String = Convert.ToString(selectedRow.Cells("Position").Value)
            Dim salary As String = Convert.ToString(selectedRow.Cells("salary").Value)
            Dim department As String = Convert.ToString(selectedRow.Cells("Office/Dept").Value)
            Dim leaveid As String = Convert.ToString(selectedRow.Cells("Leave Type").Value)
            Dim reasonid As Integer = Convert.ToInt32(selectedRow.Cells("reasonid").Value)
            Dim description As String = Convert.ToString(selectedRow.Cells("description").Value)
            Dim duration As Integer = Convert.ToInt32(selectedRow.Cells("duration").Value)
            Dim inclusivedates As String = Convert.ToString(selectedRow.Cells("Inclusive Dates").Value)
            Dim commutation As String = Convert.ToString(selectedRow.Cells("commutation").Value)
            Dim vacation As Double = Math.Round(Convert.ToDouble(selectedRow.Cells("vacation").Value), 3)
            Dim sickleave As Double = Math.Round(Convert.ToDouble(selectedRow.Cells("sickleave").Value), 3)
            Dim deducted_vacation As Double = Math.Round(Convert.ToDouble(selectedRow.Cells("deducted_vacation").Value), 3)
            Dim deducted_sick As Double = Math.Round(Convert.ToDouble(selectedRow.Cells("deducted_sick").Value), 3)
            Dim process_no As Integer = Convert.ToInt32(selectedRow.Cells("process_no").Value)
            Dim request_status As String = Convert.ToString(selectedRow.Cells("request_status").Value)
            Dim dateReceived As String = Convert.ToString(selectedRow.Cells("Date Approved").Value)
            Dim dateUpdated As String = Convert.ToString(selectedRow.Cells("Date Updated").Value)

            Dim titleFont As New Font("Arial", 14, FontStyle.Bold)
            Dim logo As Image = Image.FromFile("./Logo.png")
            Dim header1 As New Font("Arial", 7, FontStyle.Italic)
            Dim header2 As New Font("Arial", 9, FontStyle.Bold)
            Dim header3 As New Font("Arial", 7, FontStyle.Regular)
            Dim logoSize As New Rectangle(270, 25, 80, 80)
            Dim blackPen As New Pen(Brushes.Black)
            Dim tableFont1 As New Font("Arial", 9, FontStyle.Regular)
            Dim tableFont1a As New Font("Arial", 8.2, FontStyle.Regular)
            Dim tableFont1b As New Font("Arial", 7.5, FontStyle.Regular)
            Dim tableFont2 As New Font("Arial", 11, FontStyle.Bold)
            Dim tableFont3 As New Font("Arial", 6, FontStyle.Regular)
            Dim tableFont4 As New Font("Arial", 9, FontStyle.Italic)
            Dim tableFont5 As New Font("Arial", 6.5, FontStyle.Regular)
            Dim tableFont6 As New Font("Arial", 6.5, FontStyle.Italic)


            ' Create a string with the data
            Dim dtRequestid As String = $" #{requestId}"
            Dim dtDepartment As String = $"{department}"
            Dim dtLastname As String = $"{lastName}"
            Dim dtFirstname As String = $"{firstName}"
            Dim dtMiddlename As String = $"{middleName}"
            Dim dtDatefiled As String = $"{dateFiled}"
            Dim dtPosition As String = $"{position}"
            Dim dtSalary As String = $"{salary}"
            Dim dtLeaveid As String = $"{leaveid}"
            Dim dtReasonid As String = $"{reasonid}"
            Dim dtDescription As String = $"{description}"
            Dim dtDuration As String = $"{duration}"
            Dim dtInclusivedates As String = $"{inclusivedates}"
            Dim dtCommutation As String = $"{commutation}"
            Dim dtVacation As String = $"{vacation}"
            Dim dtSickleave As String = $"{sickleave}"
            Dim dtDeductedvac As String = $"{deducted_vacation}"
            Dim dtDeductedsick As String = $"{deducted_sick}"
            Dim dtProcessno As String = $"{process_no}"
            Dim dtRequeststatus As String = $"{request_status}"
            Dim dtDatereceived As String = $"{dateReceived}"

            ' Draw the string on the page
            e.Graphics.DrawString("Civil Service Form No. 6", header1, Brushes.Black, 30, 10)
            e.Graphics.DrawString("Revised 2020", header1, Brushes.Black, 30, 20)
            e.Graphics.DrawImage(logo, logoSize)
            e.Graphics.DrawString("Republic of the Philippines", header2, Brushes.Black, 360, 45)
            e.Graphics.DrawString("Province of Southern Leyte", header2, Brushes.Black, 360, 60)
            e.Graphics.DrawString("City of Maasin", header2, Brushes.Black, 400, 75)
            e.Graphics.DrawString("Stamp of Date of Receipt", header3, Brushes.Black, 650, 60)
            e.Graphics.DrawString("APPLICATION FOR LEAVE", titleFont, Brushes.Black, 300, 110)
            e.Graphics.DrawString(dtRequestid, tableFont1, Brushes.Black, 680, 30)

            If dtDatereceived <> "0" Then
                e.Graphics.DrawString(dtDatereceived, header3, Brushes.Black, 680, 45)
            End If

            e.Graphics.DrawString("1.  OFFICE/DEPARTMENT", tableFont1, Brushes.Black, 70, 150)
            e.Graphics.DrawString(dtDepartment, tableFont1a, Brushes.Black, 93, 170)

            e.Graphics.DrawString("2.  NAME:", tableFont1, Brushes.Black, 330, 150)

            e.Graphics.DrawString("(Last)", tableFont1, Brushes.Black, 440, 150)
            e.Graphics.DrawString(dtLastname, tableFont1a, Brushes.Black, 420, 170)

            e.Graphics.DrawString("(First)", tableFont1, Brushes.Black, 540, 150)
            e.Graphics.DrawString(dtFirstname, tableFont1a, Brushes.Black, 503, 170)

            e.Graphics.DrawString("(Middle)", tableFont1, Brushes.Black, 640, 150)
            e.Graphics.DrawString(dtMiddlename, tableFont1a, Brushes.Black, 650, 170)

            e.Graphics.DrawString("3.  DATE OF FILING ________________", tableFont1, Brushes.Black, 70, 200)
            e.Graphics.DrawString(dtDatefiled, tableFont1a, Brushes.Black, 200, 200)

            e.Graphics.DrawString("4.  POSITION ______________________", tableFont1, Brushes.Black, 330, 200)
            e.Graphics.DrawString(dtPosition, tableFont1a, Brushes.Black, 425, 200)

            e.Graphics.DrawString("5.  SALARY _____________", tableFont1, Brushes.Black, 580, 200)
            e.Graphics.DrawString(dtSalary, tableFont1a, Brushes.Black, 665, 200)

            e.Graphics.DrawString("6. DETAILS OF APPLICATION", tableFont2, Brushes.Black, 345, 225)
            e.Graphics.DrawString("6.A  TYPE OF LEAVE TO BE AVAILED OF", tableFont1, Brushes.Black, 70, 250)
            e.Graphics.DrawString("6.B  DETAILS OF LEAVE", tableFont1, Brushes.Black, 495, 250)



            e.Graphics.DrawString("Vacation Leave ", tableFont1a, Brushes.Black, 93, 275)
            e.Graphics.DrawString("(Sec. 51, Rule XVI, Omnibus Rules Implementing E.O. No. 292)", tableFont3, Brushes.Black, 93 + e.Graphics.MeasureString("Vacation Leave ", tableFont1a).Width - 5, 275)

            e.Graphics.DrawString("Mandatory/Forced Leave", tableFont1a, Brushes.Black, 93, 292)
            e.Graphics.DrawString("(Sec. 25, Rule XVI, Omnibus Rules Implementing E.O. No. 292)", tableFont3, Brushes.Black, 93 + e.Graphics.MeasureString("Mandatory/Forced Leave", tableFont1a).Width - 5, 295)

            e.Graphics.DrawString("Sick Leave", tableFont1a, Brushes.Black, 93, 312)

            e.Graphics.DrawString("(Sec. 43, Rule XVI, Omnibus Rules Implementing E.O. No. 292)", tableFont3, Brushes.Black, 93 + e.Graphics.MeasureString("Sick Leave", tableFont1a).Width - 5, 315)

            e.Graphics.DrawString("Maternity Leave", tableFont1a, Brushes.Black, 93, 332)
            e.Graphics.DrawString("(R.A. No. 11210 / IRR issued by CSC, DOLE and SSS)", tableFont3, Brushes.Black, 93 + e.Graphics.MeasureString("Maternity Leave", tableFont1a).Width - 5, 335)

            e.Graphics.DrawString("Paternity Leave", tableFont1a, Brushes.Black, 93, 352)
            e.Graphics.DrawString("(R.A. No. 8187 / CSC MC No. 71, s. 1998, as amended)", tableFont3, Brushes.Black, 93 + e.Graphics.MeasureString("Paternity Leave", tableFont1a).Width - 5, 355)

            e.Graphics.DrawString("Special Privilege Leave", tableFont1a, Brushes.Black, 93, 372)
            e.Graphics.DrawString("(Sec. 21, Rule XVI,Omnibus Rules Implementing E.O. No. 292)", tableFont3, Brushes.Black, 93 + e.Graphics.MeasureString("Special Privilege Leave", tableFont1a).Width - 5, 375)

            e.Graphics.DrawString("Solo Parent Leave", tableFont1a, Brushes.Black, 93, 392)
            e.Graphics.DrawString("(R.A. No. 8972 / CSC MC No. 8, s. 2004)", tableFont3, Brushes.Black, 93 + e.Graphics.MeasureString("Solo Parent Leave", tableFont1a).Width - 5, 395)

            e.Graphics.DrawString("Study Leave", tableFont1a, Brushes.Black, 93, 412)
            e.Graphics.DrawString("(Sec. 68, Rule XVI, Omnibus Rules Implementing E.O. No. 292)", tableFont3, Brushes.Black, 93 + e.Graphics.MeasureString("Study Leave", tableFont1a).Width - 5, 415)

            e.Graphics.DrawString("10-Day VAWC Leave", tableFont1a, Brushes.Black, 93, 432)
            e.Graphics.DrawString("(R.A. No. 9262 / CSC MC No. 15, s. 2005)", tableFont3, Brushes.Black, 93 + e.Graphics.MeasureString("10-Day VAWC Leave", tableFont1a).Width - 5, 435)

            e.Graphics.DrawString("Rehabilitation Privilege", tableFont1a, Brushes.Black, 93, 452)
            e.Graphics.DrawString("(Sec. 55, Rule XVI, Omnibus Rules Implementing E.O. No. 292)", tableFont3, Brushes.Black, 93 + e.Graphics.MeasureString("Rehabilitation Privilege", tableFont1a).Width - 5, 455)

            e.Graphics.DrawString("Special Leave Benefits for Women", tableFont1a, Brushes.Black, 93, 472)
            e.Graphics.DrawString("(R.A. No. 9710 / CSC MC No. 25, s. 2010)", tableFont3, Brushes.Black, 93 + e.Graphics.MeasureString("Special Leave Benefits For Women", tableFont1a).Width - 5, 475)

            e.Graphics.DrawString("Special Emergency (Calamity) Leave", tableFont1a, Brushes.Black, 93, 492)
            e.Graphics.DrawString("(CSC MC No. 2, s. 2012, as amended)", tableFont3, Brushes.Black, 93 + e.Graphics.MeasureString("Special Emergency (Calamity) Leave", tableFont1a).Width - 5, 495)

            e.Graphics.DrawString("Adoption Leave", tableFont1a, Brushes.Black, 93, 512)
            e.Graphics.DrawString("(R.A. No. 8552)", tableFont3, Brushes.Black, 93 + e.Graphics.MeasureString("Adoption Leave", tableFont1a).Width - 5, 515)


            e.Graphics.DrawString("Others: ", tableFont1a, Brushes.Black, 85, 552)
            e.Graphics.DrawString("      _________________________________________", tableFont1a, Brushes.Black, 85, 570)


            e.Graphics.DrawString("In case of Vacation/Special Privilege Leave:", tableFont6, Brushes.Black, 505, 275)
            e.Graphics.DrawString("Within the Philippines _____________________________", tableFont5, Brushes.Black, 515, 292)
            e.Graphics.DrawString("Abroad (Specify) ________________________________", tableFont5, Brushes.Black, 515, 312)
            e.Graphics.DrawString("In case of Sick Leave:", tableFont6, Brushes.Black, 505, 332)
            e.Graphics.DrawString("In Hospital (Specify Illness)) _______________________", tableFont5, Brushes.Black, 515, 352)
            e.Graphics.DrawString("Out Patient (Specify Illness) ________________________", tableFont5, Brushes.Black, 515, 372)
            e.Graphics.DrawString("_________________________________________________", tableFont5, Brushes.Black, 505, 392)
            e.Graphics.DrawString("In case of Special Leave Benefits for Women: ", tableFont6, Brushes.Black, 505, 412)
            e.Graphics.DrawString("(Specify Illness) ____________________________________", tableFont5, Brushes.Black, 505, 432)
            e.Graphics.DrawString("_________________________________________________", tableFont5, Brushes.Black, 505, 452)
            e.Graphics.DrawString("In case of Study Leave:", tableFont6, Brushes.Black, 505, 472)
            e.Graphics.DrawString("Completion of Master's Degree", tableFont5, Brushes.Black, 515, 492)
            e.Graphics.DrawString("BAR/Board Examination Review", tableFont5, Brushes.Black, 515, 512)
            e.Graphics.DrawString("Other Purpose:", tableFont6, Brushes.Black, 505, 530)
            e.Graphics.DrawString("Monetization of Leave Credits", tableFont5, Brushes.Black, 515, 552)
            e.Graphics.DrawString("Terminal Leave", tableFont5, Brushes.Black, 515, 570)


            e.Graphics.DrawString("6.C NUMBER OF WORKING DAYS APPLIED FOR", tableFont1, Brushes.Black, 70, 593)
            e.Graphics.DrawString(dtDuration, tableFont1, Brushes.Black, 200, 610)
            e.Graphics.DrawString("______________________________________________", tableFont1a, Brushes.Black, 93, 615)
            e.Graphics.DrawString("INCLUSIVE DATES", tableFont1a, Brushes.Black, 93, 635)
            e.Graphics.DrawString(dtInclusivedates, tableFont1, Brushes.Black, 160, 650)

            e.Graphics.DrawString("______________________________________________", tableFont1a, Brushes.Black, 93, 657)

            e.Graphics.DrawString("6.D COMMUTATION", tableFont1, Brushes.Black, 495, 593)
            e.Graphics.DrawString("Not Requested", tableFont1a, Brushes.Black, 515, 615)
            e.Graphics.DrawString("Requested", tableFont1a, Brushes.Black, 515, 635)
            e.Graphics.DrawString("____________________________", tableFont1a, Brushes.Black, 545, 652)
            e.Graphics.DrawString("(Signature of Applicant)", tableFont1a, Brushes.Black, 575, 665)

            e.Graphics.DrawString("6. DETAILS OF ACTION ON APPLICATION", tableFont2, Brushes.Black, 303, 685)

            e.Graphics.DrawString("7.A CERTIFICATION OF LEAVE CREDITS", tableFont1, Brushes.Black, 70, 705)
            e.Graphics.DrawString("As of:", tableFont1a, Brushes.Black, 170, 730)
            e.Graphics.DrawString(dateUpdated, tableFont1, Brushes.Black, 205, 730)


            e.Graphics.DrawLine(blackPen, 85, 745, 450, 745) 'horizontal
            e.Graphics.DrawLine(blackPen, 85, 765, 450, 765) 'horizontal
            e.Graphics.DrawLine(blackPen, 85, 785, 450, 785) 'horizontal
            e.Graphics.DrawLine(blackPen, 85, 805, 450, 805) 'horizontal
            e.Graphics.DrawLine(blackPen, 85, 825, 450, 825) 'horizontal 

            e.Graphics.DrawLine(blackPen, 85, 745, 85, 825) 'vertical
            e.Graphics.DrawLine(blackPen, 250, 745, 250, 825) 'vertical
            e.Graphics.DrawLine(blackPen, 350, 745, 350, 825) 'vertical
            e.Graphics.DrawLine(blackPen, 450, 745, 450, 825) 'vertical

            e.Graphics.DrawString("Vacation Leave", tableFont1b, Brushes.Black, 260, 750)
            e.Graphics.DrawString(dtVacation, tableFont1, Brushes.Black, 285, 770)
            e.Graphics.DrawString(dtDeductedvac, tableFont1, Brushes.Black, 285, 790)
            Dim result As Decimal = vacation - deducted_vacation
            Dim formattedResult1 As String = result.ToString("0.###") ' Displays up to 3 decimal places
            e.Graphics.DrawString(formattedResult1, tableFont1, Brushes.Black, 285, 810)
            'e.Graphics.DrawString(vacation - deducted_vacation, tableFont1, Brushes.Black, 285, 810)
            e.Graphics.DrawString("Sick Leave", tableFont1b, Brushes.Black, 370, 750)
            e.Graphics.DrawString(dtSickleave, tableFont1, Brushes.Black, 385, 770)
            e.Graphics.DrawString(dtDeductedsick, tableFont1, Brushes.Black, 385, 790)
            Dim result2 As Decimal = sickleave - deducted_sick
            Dim formattedResult2 As String = result2.ToString("0.###") ' Displays up to 3 decimal places
            e.Graphics.DrawString(formattedResult2, tableFont1, Brushes.Black, 385, 810)
            'e.Graphics.DrawString(sickleave - deducted_sick, tableFont1, Brushes.Black, 385, 810)
            e.Graphics.DrawString("Total Earned", tableFont1b, Brushes.Black, 135, 770)
            e.Graphics.DrawString("Less this application", tableFont1b, Brushes.Black, 118, 790)
            e.Graphics.DrawString("Balance", tableFont1b, Brushes.Black, 145, 810)
            e.Graphics.DrawString("RAUL A. INOCANDO, JR.", header2, Brushes.Black, 220, 850)
            e.Graphics.DrawString("City HRMO", header2, Brushes.Black, 250, 863)

            e.Graphics.DrawString("7.B RECOMMENDATION", tableFont1, Brushes.Black, 495, 705)
            e.Graphics.DrawString("For approval", tableFont1b, Brushes.Black, 515, 730)
            e.Graphics.DrawString("For disapproval due to ___________________", tableFont1b, Brushes.Black, 515, 745)
            e.Graphics.DrawString("________________________________________", tableFont1b, Brushes.Black, 515, 765)
            e.Graphics.DrawString("________________________________________", tableFont1b, Brushes.Black, 515, 785)
            e.Graphics.DrawString("________________________________________", tableFont1b, Brushes.Black, 515, 845)
            e.Graphics.DrawString("(Authorized Officer)", header2, Brushes.Black, 575, 863)


            e.Graphics.DrawString("7.C APPROVED FOR:", tableFont1, Brushes.Black, 70, 895)
            e.Graphics.DrawString("7.D DISAPPROVED DUE TO:", tableFont1, Brushes.Black, 495, 895)
            e.Graphics.DrawString("______ days with pay", tableFont1b, Brushes.Black, 93, 920)
            e.Graphics.DrawString("______ days without pay", tableFont1b, Brushes.Black, 93, 940)
            e.Graphics.DrawString("______ others (Specify)", tableFont1b, Brushes.Black, 93, 960)
            e.Graphics.DrawString("________________________________________", tableFont1b, Brushes.Black, 515, 920)
            e.Graphics.DrawString("________________________________________", tableFont1b, Brushes.Black, 515, 940)
            e.Graphics.DrawString("________________________________________", tableFont1b, Brushes.Black, 515, 960)
            e.Graphics.DrawString("HON. NACIONAL V. MERCADO", header2, Brushes.Black, 345, 1020)
            e.Graphics.DrawString("________________________________________", tableFont1b, Brushes.Black, 320, 1037)
            e.Graphics.DrawString("(Authorized Official)", header2, Brushes.Black, 370, 1050)


            Dim checkboxes As New List(Of Rectangle) From {
                New Rectangle(82, 277, 8, 8),
                New Rectangle(82, 295, 8, 8),
                New Rectangle(82, 315, 8, 8),
                New Rectangle(82, 335, 8, 8),
                New Rectangle(82, 355, 8, 8),
                New Rectangle(82, 375, 8, 8),
                New Rectangle(82, 395, 8, 8),
                New Rectangle(82, 415, 8, 8),
                New Rectangle(82, 435, 8, 8),
                New Rectangle(82, 455, 8, 8),'10-1
                New Rectangle(82, 475, 8, 8),
                New Rectangle(82, 495, 8, 8),
                New Rectangle(82, 515, 8, 8),
                New Rectangle(504, 292, 8, 8),
                New Rectangle(504, 312, 8, 8),'15-1
                New Rectangle(504, 352, 8, 8),
                New Rectangle(504, 372, 8, 8),
                New Rectangle(504, 492, 8, 8),
                New Rectangle(504, 512, 8, 8),
                New Rectangle(504, 552, 8, 8),'20-1
                New Rectangle(504, 570, 8, 8),
                New Rectangle(504, 615, 8, 8),
                New Rectangle(504, 635, 8, 8),
                New Rectangle(504, 730, 8, 8),
                New Rectangle(504, 745, 8, 8)'25-1
            }


            e.Graphics.DrawString("For approval", tableFont1b, Brushes.Black, 515, 730)
            e.Graphics.DrawString("For disapproval due to ___________________", tableFont1b, Brushes.Black, 515, 745)

            For Each checkbox As Rectangle In checkboxes
                e.Graphics.DrawRectangle(Pens.Black, checkbox)
                'e.Graphics.FillRectangle(Brushes.Red, checkbox)
            Next
            '----------------------------

            ' Create a Brush object to define the color of the rectangles
            Dim brush As SolidBrush = New SolidBrush(Color.Red)

            Dim sLeavetype As String
            Select Case leaveid
                Case "Vacation Leave"
                    sLeavetype = 1
                Case "Mandatory/Forced"
                    sLeavetype = 2
                Case "Sick Leave"
                    sLeavetype = 3
                Case "Maternity Leave"
                    sLeavetype = 4
                Case "Paternity Leave"
                    sLeavetype = 5
                Case "Special Privilege"
                    sLeavetype = 6
                Case "Solo Parent Leave"
                    sLeavetype = 7
                Case "Study Leave"
                    sLeavetype = 8
                Case "10-Day VAWC Leave"
                    sLeavetype = 9
                Case "Rehabilitation Privilege"
                    sLeavetype = 10
                Case "Special Leave For Women"
                    sLeavetype = 11
                Case "Special Emergency"
                    sLeavetype = 12
                Case "Adoption Leave"
                    sLeavetype = 13
                Case "Monetization of Leave Credits"
                    sLeavetype = 14
                Case "Terminal Leave"
                    sLeavetype = 15
                Case Else
                    sLeavetype = 16
            End Select
            ' Check the value of leaveId and fill the corresponding rectangle
            If sLeavetype = 1 Then
                e.Graphics.FillRectangle(brush, checkboxes(0))
            ElseIf sLeavetype = 2 Then
                e.Graphics.FillRectangle(brush, checkboxes(1))
            ElseIf sLeavetype = 3 Then
                e.Graphics.FillRectangle(brush, checkboxes(2))
            ElseIf sLeavetype = 4 Then
                e.Graphics.FillRectangle(brush, checkboxes(3))
            ElseIf sLeavetype = 5 Then
                e.Graphics.FillRectangle(brush, checkboxes(4))
            ElseIf sLeavetype = 6 Then
                e.Graphics.FillRectangle(brush, checkboxes(5))
            ElseIf sLeavetype = 7 Then
                e.Graphics.FillRectangle(brush, checkboxes(6))
            ElseIf sLeavetype = 8 Then
                e.Graphics.FillRectangle(brush, checkboxes(7))
            ElseIf sLeavetype = 9 Then
                e.Graphics.FillRectangle(brush, checkboxes(8))
            ElseIf sLeavetype = 10 Then
                e.Graphics.FillRectangle(brush, checkboxes(9))
            ElseIf sLeavetype = 11 Then
                e.Graphics.FillRectangle(brush, checkboxes(10))
            ElseIf sLeavetype = 12 Then
                e.Graphics.FillRectangle(brush, checkboxes(11))
            ElseIf sLeavetype = 13 Then
                e.Graphics.FillRectangle(brush, checkboxes(12))
            ElseIf sLeavetype = 14 Then
                e.Graphics.FillRectangle(brush, checkboxes(19))
            ElseIf sLeavetype = 15 Then
                e.Graphics.FillRectangle(brush, checkboxes(20))
            End If


            If dtReasonid = 1 Then
                e.Graphics.FillRectangle(brush, checkboxes(13))
                e.Graphics.DrawString(dtDescription, tableFont5, Brushes.Black, 620, 289)
            ElseIf dtReasonid = 2 Then
                e.Graphics.FillRectangle(brush, checkboxes(14))
                e.Graphics.DrawString(dtDescription, tableFont5, Brushes.Black, 610, 309)
            ElseIf dtReasonid = 3 Then
                e.Graphics.FillRectangle(brush, checkboxes(15))
                e.Graphics.DrawString(dtDescription, tableFont5, Brushes.Black, 650, 349)
            ElseIf dtReasonid = 4 Then
                e.Graphics.FillRectangle(brush, checkboxes(16))
                e.Graphics.DrawString(dtDescription, tableFont5, Brushes.Black, 650, 369)
            ElseIf dtReasonid = 5 Then
                e.Graphics.DrawString(dtDescription, tableFont5, Brushes.Black, 577, 432)
            ElseIf dtReasonid = 6 Then
                e.Graphics.FillRectangle(brush, checkboxes(17))
            ElseIf dtReasonid = 7 Then
                e.Graphics.FillRectangle(brush, checkboxes(18))
            End If

            If dtCommutation = "requested" Then
                e.Graphics.FillRectangle(brush, checkboxes(22))
            Else
                e.Graphics.FillRectangle(brush, checkboxes(21))
            End If

            If dtProcessno > 2 Then
                'e.Graphics.DrawString("E- SIGNATURE HERE", header2, Brushes.Black, 220, 840)
            End If

            If dtProcessno > 1 Then
                e.Graphics.FillRectangle(brush, checkboxes(23))
                ' e.Graphics.DrawString("E- SIGNATURE HERE", header2, Brushes.Black, 515, 830)
            End If

            If dtRequeststatus = "Approved" Then
                'e.Graphics.DrawString("E- SIGNATURE HERE", header2, Brushes.Black, 345, 1030)
            End If

            brush.Dispose()
            '-------------------

            e.Graphics.DrawLine(blackPen, 65, 145, 755, 145) 'horizontal
            e.Graphics.DrawLine(blackPen, 65, 190, 755, 190) 'horizontal
            e.Graphics.DrawLine(blackPen, 65, 220, 755, 220) 'horizontal
            e.Graphics.DrawLine(blackPen, 65, 243, 755, 243) 'horizontal
            e.Graphics.DrawLine(blackPen, 65, 588, 755, 588) 'horizontal
            e.Graphics.DrawLine(blackPen, 65, 680, 755, 680) 'horizontal
            e.Graphics.DrawLine(blackPen, 65, 703, 755, 703) 'horizontal
            e.Graphics.DrawLine(blackPen, 65, 890, 755, 890) 'horizontal
            e.Graphics.DrawLine(blackPen, 65, 1070, 755, 1070) 'horizontal

            e.Graphics.DrawLine(blackPen, 65, 145, 65, 1070) 'vertical
            e.Graphics.DrawLine(blackPen, 755, 145, 755, 1070) 'vertical
            e.Graphics.DrawLine(blackPen, 490, 243, 490, 680) 'vertical
            e.Graphics.DrawLine(blackPen, 490, 703, 490, 890) 'vertical

            'e.Graphics.DrawString(printData, font, Brushes.Black, 100, 300)
        End If
    End Sub

    Private Sub print_Click(sender As Object, e As EventArgs) Handles print.Click
        printdialogLeavereq.Document = docLeavereq
        If printdialogLeavereq.ShowDialog = Windows.Forms.DialogResult.OK Then
            docLeavereq.Print()
        End If
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Dim zoomFactor As Single = 1.5 ' 150%
        previewLeavereq.PrintPreviewControl.Zoom = zoomFactor
        previewLeavereq.Document = docLeavereq
        previewLeavereq.ShowDialog()
        Dim pd As New PrintDocument
        For Each size As PaperSize In pd.PrinterSettings.PaperSizes
            If size.Kind = PaperKind.Letter Then
                pd.DefaultPageSettings.PaperSize = size
                Exit For
            End If
        Next

    End Sub

    Private Sub pagesetup_Click(sender As Object, e As EventArgs) Handles pagesetup.Click
        PageSetupDialog1.Document = docLeavereq
        PageSetupDialog1.Document.DefaultPageSettings.Color = False
        PageSetupDialog1.ShowDialog()
    End Sub

    Dim months() As String = {"none", "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"}

    Private Async Sub btnFilter_Click(sender As Object, e As EventArgs) Handles btnFilter.Click
        Dim host As String = My.Settings.host
        Dim accessToken As String = My.Settings.accessToken

        isLoading = True
        If isLoading Then
            btnFilterdept.Enabled = False
            TextBoxSearch.Enabled = False
            btnView.Enabled = False
            print.Enabled = False
            btnPrint.Enabled = False
            pagesetup.Enabled = False
            btnFilter.Enabled = False
        End If

        If cmbYear.SelectedItem Is Nothing OrElse cmbMonth.SelectedItem Is Nothing Then
            isLoading = False
            TextBoxSearch.Enabled = True
            btnFilterdept.Enabled = True
            btnView.Enabled = True
            print.Enabled = True
            btnPrint.Enabled = True
            pagesetup.Enabled = True
            txtLoading.Visible = False
            btnFilter.Enabled = True

            PopulateDataGridView(searchreq)

            MessageBox.Show("Please select.")

        Else
            ' Execute your code if both ComboBoxes have selections
            Dim year As String = cmbYear.SelectedItem.ToString()
            Dim month As String = cmbMonth.SelectedItem.ToString()

            Dim reqStatus As String = "Approved" ' or get this value from somewhere else if it's dynamic

            ' Check if both combo boxes are empty or set to none
            If (year = "none" And month = "none") Or (year = "" And month = "") Then
                _mainForm.frmApprovedOpen()

                MessageBox.Show("Filtered None")
                'PopulateDataGridView(searchreq)

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
                Dim response As HttpResponseMessage = Await HttpClientSingleton.SharedClient.PostAsync("http://" & host & ":3000/adminside/reqFilter", content, cts.Token)

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
            btnView.Enabled = False
            print.Enabled = False
            btnPrint.Enabled = False
            pagesetup.Enabled = False
            btnFilter.Enabled = False
        End If

        If cmbDept.SelectedItem Is Nothing Then

            isLoading = False
            TextBoxSearch.Enabled = True
            btnFilterdept.Enabled = True
            btnView.Enabled = True
            print.Enabled = True
            btnPrint.Enabled = True
            pagesetup.Enabled = True
            txtLoading.Visible = False
            btnFilter.Enabled = True

            PopulateDataGridView(searchreq)

            MessageBox.Show("Please select.")
        Else
            ' Execute your code if both ComboBoxes have selections
            Dim department As String = cmbDept.SelectedItem.ToString()

            Dim reqStatus As String = "Approved" ' or get this value from somewhere else if it's dynamic

            ' Check if both combo boxes are empty or set to none
            If (department = "none") Then

                _mainForm.frmApprovedOpen()

                MessageBox.Show("Filtered None")
                'PopulateDataGridView(searchreq)

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
                Dim response As HttpResponseMessage = Await HttpClientSingleton.SharedClient.PostAsync("http://" & host & ":3000/adminside/reqdeptfilter", content, cts.Token)

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
            If request.lastname.Any(Function(n) n.ToLower().Contains(searchTerm)) Or request.department.ToLower().Contains(searchTerm) Then
                newsearchreq.Add(request)

            End If
        Next

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
        dt.Columns.Add("Date Approved", GetType(String))
        dt.Columns.Add("Date Updated", GetType(String))

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

            Dim dateString As String = request.updated_at.ToString().Substring(0, 10)
            Dim dateValue As DateTime = DateTime.Parse(dateString)
            Dim formattedUpdatedAt As String = dateValue.ToString("MMMM yyyy")

            Dim name As String = String.Concat(request.lastname.FirstOrDefault(), ", ", request.firstname.FirstOrDefault(), " ", request.middlename.FirstOrDefault())


            dt.Rows.Add(request.userid, request.requestid, name, request.firstname.FirstOrDefault(), request.lastname.FirstOrDefault(), sLeavetype, request.inclusivedates, request.department, request.reasonid, request.middlename.FirstOrDefault(), request.salary, request.position, request.datefiled.ToString().Substring(0, 10), request.description, request.duration, request.commutation, request.vacationCreds, request.sickCreds, request.deducted_vacation, request.deducted_sick, request.process_no, request.request_status, request.datereceived, formattedUpdatedAt)

        Next

        tblApproved.DataSource = dt
        tblApproved.Refresh()
        tblApproved.ReadOnly = True
        tblApproved.GridColor = Color.FloralWhite


        ApplyCommonDataGridViewSettings(tblApproved)
    End Sub
End Class
