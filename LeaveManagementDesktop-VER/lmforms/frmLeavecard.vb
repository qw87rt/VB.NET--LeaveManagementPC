Imports System.Drawing.Printing
Imports System.Drawing.Text
Imports System.Net.Http
Imports System.Net.Http.Headers
Imports Newtonsoft.Json
Imports System.Text
Imports System.Net.Http.Json
Imports System.Threading


Public Class frmLeavecard
    Private _mainForm As mainform

    Private isLoading As Boolean = False

    Private userID As Integer
    Private rownumList As New List(Of Integer)
    Private lastVac As Decimal
    Private lastSick As Decimal
    Private numRows As Integer

    Private currentRow As Integer = 0
    Private totalRows As Integer = 0
    Private xaxis As Integer
    Private yaxis As Integer = 130
    Private iterator As Double = 0
    Private currentPageRows As Integer
    Private maxRowsPerPage As Integer
    Private isPreview As Boolean = False

    Private selectedPrintRange As System.Drawing.Printing.PrintRange = System.Drawing.Printing.PrintRange.AllPages

    Private cts As New CancellationTokenSource()


    Private modifiedRowNumbers As New List(Of Integer)
    Private dt As DataTable
    Private Async Sub frmLeavecard_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.WindowState = FormWindowState.Maximized

        isLoading = True
        If isLoading Then
            btnPreview.Enabled = False
            print.Enabled = False
            pagesetup.Enabled = False
            btnCredits.Enabled = False
            btnEdit.Enabled = False

        End If

        btnSave.Visible = False

        Try
            Dim host As String = My.Settings.host

            Dim response As HttpResponseMessage = Await HttpClientSingleton.SharedClient.GetAsync("http://" & host & ":3000/adminside/leavecard_data/" & userID, cts.Token)
            response.EnsureSuccessStatusCode()

            Dim responseString As String = Await response.Content.ReadAsStringAsync()
            Dim leavecard As List(Of Leavecard) = JsonConvert.DeserializeObject(Of List(Of Leavecard))(responseString)

            dt = New DataTable()


            dt.Columns.Add(" ", GetType(String))
            dt.Columns.Add("Period", GetType(String))
            dt.Columns.Add("PARTICULARS", GetType(String))
            dt.Columns.Add("EARNED.", GetType(String))
            dt.Columns.Add("UND/TARDY", GetType(String))
            dt.Columns.Add("VL", GetType(String))
            dt.Columns.Add("FL", GetType(String))
            dt.Columns.Add("BALANCE.", GetType(String))
            dt.Columns.Add("ABS-W/O/P", GetType(String))
            dt.Columns.Add("EARNED-", GetType(String))
            dt.Columns.Add("ABS-W/P", GetType(String))
            dt.Columns.Add("BALANCE-", GetType(String))
            dt.Columns.Add("ABS--W/0/P", GetType(String))
            dt.Columns.Add("SPL", GetType(String))
            dt.Columns.Add("SOL", GetType(String))
            dt.Columns.Add("MAL", GetType(String))
            dt.Columns.Add("PAL", GetType(String))
            dt.Columns.Add("MCW", GetType(String))
            dt.Columns.Add("RPL", GetType(String))
            dt.Columns.Add("SEL", GetType(String))
            dt.Columns.Add("OTHERS", GetType(String))
            dt.Columns.Add("DATE & ACTION TAKEN", GetType(String))
            dt.Columns.Add("created_at", GetType(String))

            numRows = leavecard.Count + 2
            totalRows = leavecard.Count
            iterator = 1


            ' Create 30 rows by default
            For i As Integer = 2 To numRows + 5
                dt.Rows.Add()
            Next


            For Each leave As Leavecard In leavecard
                txtDepartment.Text = leave.department
                txtName.Text = String.Concat(leave.lastname.FirstOrDefault(), " ", leave.firstname.FirstOrDefault())

                ' Fill the row based on rownum
                If leave.rownum <> 0 Then

                    dt.Rows(leave.rownum - 1).ItemArray = {leave.rownum, leave.period.ToString(), leave.particulars.ToString(), leave.vacleave_earned.ToString(), leave.vactardy.ToString(), leave.VL.ToString(), leave.FL.ToString(), leave.Vacbal.ToString(), leave.vacWOP.ToString(), leave.sickleave_earned.ToString(), leave.sicktardy.ToString(), leave.Sickbal.ToString(), leave.sickWOP.ToString(), leave.SPL.ToString(), leave.SOL.ToString(), leave.MAL.ToString(), leave.PAL.ToString(), leave.MCW.ToString(), leave.RPL.ToString(), leave.SEL.ToString(), leave.note.ToString(), leave.actiontaken, leave.created_at}
                    rownumList.Add(leave.rownum - 1)
                    lastVac = Convert.ToDecimal(leave.Vacbal)
                    lastSick = Convert.ToDecimal(leave.Sickbal)

                    If leave.rownum > totalRows Then
                        totalRows = leave.rownum
                    End If

                End If
            Next

            tblLeavecard.DataSource = dt
            tblLeavecard.ReadOnly = True

            AddHandler tblLeavecard.CellValueChanged, AddressOf tblLeavecard_CellValueChanged
            ' Add the CellFormatting event handler
            AddHandler tblLeavecard.CellFormatting, AddressOf tblLeavecard_CellFormatting

            tblLeavecard.Columns(" ").Width = 30
            tblLeavecard.Columns("Period").Width = 140
            tblLeavecard.Columns("PARTICULARS").Width = 225
            tblLeavecard.Columns("EARNED.").Width = 60

            tblLeavecard.Columns("UND/TARDY").Width = 65
            tblLeavecard.Columns("VL").Width = 50
            tblLeavecard.Columns("FL").Width = 50
            tblLeavecard.Columns("BALANCE.").Width = 80
            tblLeavecard.Columns("ABS-W/O/P").Width = 65
            tblLeavecard.Columns("EARNED-").Width = 60
            tblLeavecard.Columns("ABS-W/P").Width = 75
            tblLeavecard.Columns("BALANCE-").Width = 80
            tblLeavecard.Columns("ABS--W/0/P").Width = 65
            tblLeavecard.Columns("SPL").Width = 65
            tblLeavecard.Columns("SOL").Width = 65
            tblLeavecard.Columns("MAL").Width = 65
            tblLeavecard.Columns("PAL").Width = 65
            tblLeavecard.Columns("MCW").Width = 65
            tblLeavecard.Columns("RPL").Width = 65
            tblLeavecard.Columns("SEL").Width = 65
            tblLeavecard.Columns("OTHERS").Width = 65
            tblLeavecard.Columns("DATE & ACTION TAKEN").Width = 225


            'tblLeavecard.Columns("EARNED.").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            'tblLeavecard.Columns("VL").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            'tblLeavecard.Columns("FL").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            'tblLeavecard.Columns("PL").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            'tblLeavecard.Columns("UND/TARDY").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            'tblLeavecard.Columns("BALANCE.").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            'tblLeavecard.Columns("EARNED-").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells

            tblLeavecard.Columns(" ").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            tblLeavecard.Columns("EARNED.").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            tblLeavecard.Columns("UND/TARDY").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            tblLeavecard.Columns("VL").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            tblLeavecard.Columns("FL").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            tblLeavecard.Columns("BALANCE.").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            tblLeavecard.Columns("ABS-W/O/P").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            tblLeavecard.Columns("EARNED-").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            tblLeavecard.Columns("ABS-W/P").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            tblLeavecard.Columns("BALANCE-").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            tblLeavecard.Columns("ABS--W/0/P").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            tblLeavecard.Columns("SPL").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            tblLeavecard.Columns("SOL").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            tblLeavecard.Columns("MAL").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            tblLeavecard.Columns("PAL").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            tblLeavecard.Columns("MCW").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            tblLeavecard.Columns("RPL").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            tblLeavecard.Columns("SEL").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            tblLeavecard.Columns("created_at").Visible = False
            tblLeavecard.Columns(" ").Visible = False

            tblLeavecard.DefaultCellStyle.BackColor = Color.White
            tblLeavecard.ColumnHeadersDefaultCellStyle.Font = New Font("Arial", 10)
            tblLeavecard.ColumnHeadersDefaultCellStyle.BackColor = Color.DeepPink
            tblLeavecard.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            tblLeavecard.DefaultCellStyle.Font = New Font("Arial", 10)
            tblLeavecard.DefaultCellStyle.ForeColor = Color.Black
            tblLeavecard.RowHeadersVisible = False
            tblLeavecard.MultiSelect = False
            tblLeavecard.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            tblLeavecard.ColumnHeadersHeight = 35


        Catch ex As OperationCanceledException
            ' MessageBox.Show("Request Cancelled", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As HttpRequestException
            MessageBox.Show("Request failed: Please ensure you have an active internet connection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'mainform.Close()
            'Form1.Show()

        End Try

        Dim accessLevel As String = My.Settings.accessLevel
        If accessLevel = "d033e22ae348aeb5660fc2140aec35850c4da997" Then
            btnEdit.Visible = True
            btnCredits.Visible = True
        End If

        isLoading = False
        btnPreview.Enabled = True
        print.Enabled = True
        pagesetup.Enabled = True
        btnCredits.Enabled = True
        btnEdit.Enabled = True
        txtLoading.Visible = False

    End Sub

    Protected Overrides Sub OnFormClosing(e As FormClosingEventArgs)
        If cts IsNot Nothing Then
            cts.Cancel()
        End If
        MyBase.OnFormClosing(e)
    End Sub

    Public Class Leavecard
        Public Property recordid As Integer
        Public Property userid As Integer
        Public Property lastname As List(Of String)
        Public Property firstname As List(Of String)
        Public Property department As String
        Public Property rownum As Integer
        Public Property period As String
        Public Property particulars As String
        Public Property actiontaken As String
        Public Property vacleave_earned As Double
        Public Property sickleave_earned As Double
        Public Property vactardy As Double
        Public Property sicktardy As Double
        Public Property VL As Double
        Public Property FL As Double
        Public Property vacWOP As Double
        Public Property sickWOP As Double
        Public Property Vacbal As Double
        Public Property Sickbal As Double
        Public Property SPL As Double
        Public Property SOL As Double
        Public Property MAL As Double
        Public Property PAL As Double
        Public Property MCW As Double
        Public Property RPL As Double
        Public Property SEL As Double
        Public Property note As String
        Public Property created_at As String


    End Class

    Private Sub tblLeavecard_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles tblLeavecard.CellValueChanged
        modifiedRowNumbers.Add(e.RowIndex) ' Add the row number to the list when a cell value changes
        Dim newVaclv As Decimal
        Dim newLvsick As Decimal
        Dim earnedVac As Decimal = 0
        Dim deductVac As Decimal = 0
        Dim earnedSick As Decimal = 0
        Dim deductSick As Decimal = 0

        ' Check if the row index of the modified cell is not in rownumList
        If Not rownumList.Contains(e.RowIndex) Then
            ' Proceed with the calculations and updates
            If e.ColumnIndex = tblLeavecard.Columns("EARNED.").Index Then
                ' Retrieve the value of the "EARNED." column
                If Decimal.TryParse(tblLeavecard.Rows(e.RowIndex).Cells("EARNED.").Value.ToString(), earnedVac) Then
                    newVaclv = lastVac + earnedVac '- deductVac
                    tblLeavecard.Rows(e.RowIndex).Cells("BALANCE.").Value = newVaclv.ToString()

                End If
            ElseIf e.ColumnIndex = tblLeavecard.Columns("UND/TARDY").Index Then

                If Decimal.TryParse(tblLeavecard.Rows(e.RowIndex).Cells("UND/TARDY").Value.ToString(), deductVac) Then
                    newVaclv = lastVac - deductVac '+ earnedVac
                    tblLeavecard.Rows(e.RowIndex).Cells("BALANCE.").Value = newVaclv.ToString()
                End If


            ElseIf e.ColumnIndex = tblLeavecard.Columns("EARNED-").Index Then
                ' Retrieve the value of the "EARNED-" column
                If Decimal.TryParse(tblLeavecard.Rows(e.RowIndex).Cells("EARNED-").Value.ToString(), earnedSick) Then
                    ' Calculate the new balance value for "BALANCE-"
                    newLvsick = lastSick + earnedSick
                    tblLeavecard.Rows(e.RowIndex).Cells("BALANCE-").Value = newLvsick.ToString()
                End If

            ElseIf e.ColumnIndex = tblLeavecard.Columns("ABS-W/P").Index Then

                If Decimal.TryParse(tblLeavecard.Rows(e.RowIndex).Cells("EARNED-").Value.ToString(), deductSick) Then
                    ' Calculate the new balance value for "BALANCE-"
                    newLvsick = lastSick - deductSick
                    tblLeavecard.Rows(e.RowIndex).Cells("BALANCE-").Value = newLvsick.ToString()
                End If

            End If
        End If

    End Sub



    Private Sub tblLeavecard_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs)
        ' Check if the cell's value is 0

        If e.Value IsNot Nothing AndAlso e.Value.ToString() = "0" Then
            ' Set the cell's text color to white
            e.CellStyle.ForeColor = Color.White
            ' Optionally, set the cell's background color to white
            e.CellStyle.BackColor = Color.White
        End If
    End Sub

    Private Sub tblLeavecard_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles tblLeavecard.EditingControlShowing
        Dim txtEdit As TextBox = e.Control
        ' Remove any existing handler
        RemoveHandler txtEdit.KeyPress, AddressOf txtEdit_KeyPress
        AddHandler txtEdit.KeyPress, AddressOf txtEdit_KeyPress
    End Sub

    Private Sub txtEdit_KeyPress(sender As Object, e As KeyPressEventArgs)
        Dim txtBox As TextBox = DirectCast(sender, TextBox)
        Dim currentCell As DataGridViewCell = tblLeavecard.CurrentCell

        ' List of column names to apply the decimal number restriction
        Dim decimalColumns As String() = {"EARNED.", "UND/TARDY", "VL", "FL", "BALANCE.", "ABS-W/O/P", "EARNED-", "ABS-W/P", "BALANCE-", "ABS--W/0/P", "SPL", "SOL", "MAL", "PAL", "MCW", "RPL", "SEL"}

        ' Check if the current cell is in one of the specified columns
        If decimalColumns.Contains(currentCell.OwningColumn.Name) Then
            ' Allow only numeric characters, the decimal point, or the backspace key
            If Not (Char.IsDigit(e.KeyChar) OrElse e.KeyChar = "."c OrElse e.KeyChar = ControlChars.Back) Then
                e.Handled = True
            End If
        End If
    End Sub

    Public Sub New(userID As Integer, mainForm As mainform)
        InitializeComponent()
        Me.userID = userID
        _mainForm = mainForm

        AddHandler tblLeavecard.CellFormatting, AddressOf tblLeavecard_CellFormatting

    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click


        tblLeavecard.SelectionMode = DataGridViewSelectionMode.CellSelect

        btnEdit.Visible = False
        btnPreview.Enabled = False
        print.Enabled = False
        pagesetup.Enabled = False
        tblLeavecard.ReadOnly = False
        btnSave.Visible = True
    End Sub

    Private Async Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        Dim accessToken As String = My.Settings.accessToken
        Dim refreshToken As String = My.Settings.refreshToken

        isLoading = True
        If isLoading Then
            btnPreview.Enabled = False
            print.Enabled = False
            pagesetup.Enabled = False
            btnCredits.Enabled = False
            txtLoading.Visible = True
            btnSave.Enabled = False

        End If
        Try

            Dim distinctModifiedRows As IEnumerable(Of Integer) = modifiedRowNumbers.Distinct()
            Dim distinctModifiedRowsList As List(Of Integer) = distinctModifiedRows.ToList()
            Dim modifiedRows() As Integer = distinctModifiedRowsList.ToArray()
            Dim modifiedRowNumbersStr As String = String.Join(", ", modifiedRows)

            Dim leavecards As New List(Of Leavecard)

            For Each rowNum In modifiedRows

                Dim row As DataRow = dt.Rows(rowNum)

                ' Check if "BALANCE." is empty and set its value to lastVac if it is
                If IsDBNull(row("BALANCE.")) Then
                    row("BALANCE.") = lastVac
                Else
                    lastVac = Convert.ToDecimal(row("BALANCE."))
                End If

                ' Check if "BALANCE-" is empty and set its value to lastSick if it is
                If IsDBNull(row("BALANCE-")) Then
                    row("BALANCE-") = lastSick
                Else
                    lastSick = Convert.ToDecimal(row("BALANCE-"))
                End If

                If rowNum + 1 > totalRows Then
                    totalRows = rowNum + 1
                End If


                Dim period As String = If(IsDBNull(tblLeavecard.Rows(rowNum).Cells("Period").Value), "", tblLeavecard.Rows(rowNum).Cells("Period").Value)
                Dim particulars As String = If(IsDBNull(tblLeavecard.Rows(rowNum).Cells("PARTICULARS").Value), "", tblLeavecard.Rows(rowNum).Cells("PARTICULARS").Value)

                Dim vacleave_earned As Double = If(IsDBNull(tblLeavecard.Rows(rowNum).Cells("EARNED.").Value), 0, CDbl(tblLeavecard.Rows(rowNum).Cells("EARNED.").Value))
                Dim vactardy As Double = If(IsDBNull(tblLeavecard.Rows(rowNum).Cells("UND/TARDY").Value), 0, CDbl(tblLeavecard.Rows(rowNum).Cells("UND/TARDY").Value))
                Dim VL As Double = If(IsDBNull(tblLeavecard.Rows(rowNum).Cells("VL").Value), 0, CDbl(tblLeavecard.Rows(rowNum).Cells("VL").Value))
                Dim FL As Double = If(IsDBNull(tblLeavecard.Rows(rowNum).Cells("FL").Value), 0, CDbl(tblLeavecard.Rows(rowNum).Cells("FL").Value))
                Dim Vacbal As Double = If(IsDBNull(tblLeavecard.Rows(rowNum).Cells("BALANCE.").Value), 0, CDbl(tblLeavecard.Rows(rowNum).Cells("BALANCE.").Value))
                Dim vacWOP As Double = If(IsDBNull(tblLeavecard.Rows(rowNum).Cells("ABS-W/O/P").Value), 0, CDbl(tblLeavecard.Rows(rowNum).Cells("ABS-W/O/P").Value))
                Dim sickleave_earned As Double = If(IsDBNull(tblLeavecard.Rows(rowNum).Cells("EARNED-").Value), 0, CDbl(tblLeavecard.Rows(rowNum).Cells("EARNED-").Value))
                Dim sicktardy As Double = If(IsDBNull(tblLeavecard.Rows(rowNum).Cells("ABS-W/P").Value), 0, CDbl(tblLeavecard.Rows(rowNum).Cells("ABS-W/P").Value))
                Dim Sickbal As Double = If(IsDBNull(tblLeavecard.Rows(rowNum).Cells("BALANCE-").Value), 0, CDbl(tblLeavecard.Rows(rowNum).Cells("BALANCE-").Value))
                Dim sickWOP As Double = If(IsDBNull(tblLeavecard.Rows(rowNum).Cells("ABS--W/0/P").Value), 0, CDbl(tblLeavecard.Rows(rowNum).Cells("ABS--W/0/P").Value))
                Dim SPL As Double = If(IsDBNull(tblLeavecard.Rows(rowNum).Cells("SPL").Value), 0, CDbl(tblLeavecard.Rows(rowNum).Cells("SPL").Value))
                Dim SOL As Double = If(IsDBNull(tblLeavecard.Rows(rowNum).Cells("SOL").Value), 0, CDbl(tblLeavecard.Rows(rowNum).Cells("SOL").Value))
                Dim MAL As Double = If(IsDBNull(tblLeavecard.Rows(rowNum).Cells("MAL").Value), 0, CDbl(tblLeavecard.Rows(rowNum).Cells("MAL").Value))
                Dim PAL As Double = If(IsDBNull(tblLeavecard.Rows(rowNum).Cells("PAL").Value), 0, CDbl(tblLeavecard.Rows(rowNum).Cells("PAL").Value))
                Dim MCW As Double = If(IsDBNull(tblLeavecard.Rows(rowNum).Cells("MCW").Value), 0, CDbl(tblLeavecard.Rows(rowNum).Cells("MCW").Value))
                Dim RPL As Double = If(IsDBNull(tblLeavecard.Rows(rowNum).Cells("RPL").Value), 0, CDbl(tblLeavecard.Rows(rowNum).Cells("RPL").Value))
                Dim SEL As Double = If(IsDBNull(tblLeavecard.Rows(rowNum).Cells("SEL").Value), 0, CDbl(tblLeavecard.Rows(rowNum).Cells("SEL").Value))
                Dim OTHERS As String = If(IsDBNull(tblLeavecard.Rows(rowNum).Cells("OTHERS").Value), "", tblLeavecard.Rows(rowNum).Cells("OTHERS").Value)

                Dim actiontaken As String = If(IsDBNull(tblLeavecard.Rows(rowNum).Cells("DATE & ACTION TAKEN").Value), "", tblLeavecard.Rows(rowNum).Cells("DATE & ACTION TAKEN").Value)

                Dim leavecard As New Leavecard With {
               .userid = userID,
               .rownum = rowNum + 1,
               .period = period,
               .particulars = particulars,
               .actiontaken = actiontaken,
               .vacleave_earned = vacleave_earned,
               .sickleave_earned = sickleave_earned,
               .vactardy = vactardy,
               .sicktardy = sicktardy,
               .VL = VL,
               .FL = FL,
               .vacWOP = vacWOP,
               .sickWOP = sickWOP,
               .Vacbal = Vacbal,
               .Sickbal = Sickbal,
               .SPL = SPL,
               .SOL = SOL,
               .MAL = MAL,
               .PAL = PAL,
               .MCW = MCW,
               .RPL = RPL,
               .SEL = SEL,
               .note = OTHERS
           }

                leavecards.Add(leavecard)
            Next

            Dim json As String = JsonConvert.SerializeObject(leavecards)

            Dim content As New StringContent(json, Encoding.UTF8, "application/json")

            Dim host As String = My.Settings.host
            Dim response As HttpResponseMessage = Await HttpClientSingleton.SharedClient.PostAsync("http://" & host & ":3000/adminside/leavecard_req", content, cts.Token)

            ' Ensure the request was successful
            'response.EnsureSuccessStatusCode()

            If response.IsSuccessStatusCode Then
                ' Prepare content for the second request
                Dim insertContent As New StringContent(JsonConvert.SerializeObject(New With {
                .userid = userID,
                .vacation = lastVac,
                .sickleave = lastSick
            }), Encoding.UTF8, "application/json")

                HttpClientSingleton.SharedClient.DefaultRequestHeaders.Authorization = New AuthenticationHeaderValue("Bearer", accessToken)

                ' Execute the second request
                Dim insertResponse As HttpResponseMessage = Await HttpClientSingleton.SharedClient.PutAsync("http://" & host & ":3000/adminside/update_user", insertContent, cts.Token)

                ' Ensure the second request was successful
                insertResponse.EnsureSuccessStatusCode()
                dt.Rows.Add()
                MessageBox.Show("Updated Successfully")
            Else
                MessageBox.Show("First request failed. Status code: " & response.StatusCode)
            End If


            modifiedRowNumbers.Clear() ' Clear the list after showing the messages

        Catch ex As OperationCanceledException
            MessageBox.Show("Request Cancelled", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As HttpRequestException
            MessageBox.Show("Request failed: Please ensure you have an active internet connection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'mainform.Close()
            'Form1.Show()

        End Try

        btnSave.Enabled = True
        btnSave.Visible = False
        btnEdit.Visible = True
        tblLeavecard.ReadOnly = True
        tblLeavecard.SelectionMode = DataGridViewSelectionMode.FullRowSelect

        isLoading = False
        btnPreview.Enabled = True
        print.Enabled = True
        pagesetup.Enabled = True
        btnCredits.Enabled = True
        txtLoading.Visible = False

    End Sub

    Private Sub docLeavereq_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles docLeavereq.PrintPage


        If isPreview And iterator > Math.Round(totalRows / 30) Then
            iterator = 1
            yaxis = 130
            currentRow = 0
            isPreview = False
        End If

        ' Convert centimeters to hundredths of an inch (since 1 inch = 2.54cm)
        ' Dim widthInHundredthsOfAnInch As Integer = 1000
        ' Dim heightInHundredthsOfAnInch As Integer = 660

        ' Dim customSize As New PaperSize("Custom", widthInHundredthsOfAnInch, heightInHundredthsOfAnInch)
        ' docLeavereq.DefaultPageSettings.PaperSize = customSize
        ' docLeavereq.DefaultPageSettings.Landscape = True

        currentPageRows = 0
        maxRowsPerPage = 30

        HeaderPage(e)

        While currentRow < totalRows And currentPageRows < maxRowsPerPage


            PrintDataPage(e, currentRow)
            yaxis += 23
            currentRow += 1
            currentPageRows += 1

        End While

        If currentRow > 0 AndAlso currentRow Mod 30 = 0 Then
            yaxis = 130
        End If

        e.HasMorePages = IIf(iterator < Math.Round(totalRows / 30), True, False)
        iterator += 1


    End Sub

    Private Sub PrintDataPage(e As Printing.PrintPageEventArgs, currentRow As Integer)

        Dim blackPen As New Pen(Brushes.Black)

        Dim font1 As New Font("Arial", 10, FontStyle.Regular)
        Dim font2 As New Font("Arial", 13, FontStyle.Bold)
        Dim font3 As New Font("Arial", 7, FontStyle.Regular)
        Dim font4 As New Font("Arial", 8, FontStyle.Regular)


        If dt.Rows(currentRow).Item("Period") IsNot Nothing Then
            e.Graphics.DrawString(dt.Rows(currentRow).Item("Period").ToString(), font1, Brushes.Black, 25, yaxis + 4)
        End If

        If dt.Rows(currentRow).Item("PARTICULARS") IsNot Nothing Then
            e.Graphics.DrawString(dt.Rows(currentRow).Item("PARTICULARS").ToString(), font1, Brushes.Black, 145, yaxis + 4)
        End If

        If dt.Rows(currentRow).Item("EARNED.") IsNot DBNull.Value AndAlso dt.Rows(currentRow).Item("EARNED.") <> 0 Then
            e.Graphics.DrawString(dt.Rows(currentRow).Item("EARNED.").ToString(), font1, Brushes.Black, 310, yaxis + 4)
        End If

        If dt.Rows(currentRow).Item("UND/TARDY") IsNot DBNull.Value AndAlso dt.Rows(currentRow).Item("UND/TARDY") <> 0 Then
            e.Graphics.DrawString(dt.Rows(currentRow).Item("UND/TARDY").ToString(), font1, Brushes.Black, 355, yaxis + 4)
        End If

        If dt.Rows(currentRow).Item("VL") IsNot DBNull.Value AndAlso dt.Rows(currentRow).Item("VL") <> 0 Then
            e.Graphics.DrawString(dt.Rows(currentRow).Item("VL").ToString(), font1, Brushes.Black, 400, yaxis + 4)
        End If

        If dt.Rows(currentRow).Item("FL") IsNot DBNull.Value AndAlso dt.Rows(currentRow).Item("FL") <> 0 Then
            e.Graphics.DrawString(dt.Rows(currentRow).Item("FL").ToString(), font1, Brushes.Black, 435, yaxis + 4)
        End If

        If dt.Rows(currentRow).Item("BALANCE.") IsNot DBNull.Value AndAlso dt.Rows(currentRow).Item("BALANCE.") <> 0 Then
            e.Graphics.DrawString(dt.Rows(currentRow).Item("BALANCE.").ToString(), font1, Brushes.Black, 470, yaxis + 4)
        End If

        If dt.Rows(currentRow).Item("ABS-W/O/P") IsNot DBNull.Value AndAlso dt.Rows(currentRow).Item("ABS-W/O/P") <> 0 Then
            e.Graphics.DrawString(dt.Rows(currentRow).Item("ABS-W/O/P").ToString(), font1, Brushes.Black, 510, yaxis + 4)
        End If

        If dt.Rows(currentRow).Item("EARNED-") IsNot DBNull.Value AndAlso dt.Rows(currentRow).Item("EARNED-") <> 0 Then
            e.Graphics.DrawString(dt.Rows(currentRow).Item("EARNED-").ToString(), font1, Brushes.Black, 560, yaxis + 4)
        End If

        If dt.Rows(currentRow).Item("ABS-W/P") IsNot DBNull.Value AndAlso dt.Rows(currentRow).Item("ABS-W/P") <> 0 Then
            e.Graphics.DrawString(dt.Rows(currentRow).Item("ABS-W/P").ToString(), font1, Brushes.Black, 615, yaxis + 4)
        End If

        If dt.Rows(currentRow).Item("BALANCE-") IsNot DBNull.Value AndAlso dt.Rows(currentRow).Item("BALANCE-") <> 0 Then
            e.Graphics.DrawString(dt.Rows(currentRow).Item("BALANCE-").ToString(), font1, Brushes.Black, 655, yaxis + 4)
        End If

        If dt.Rows(currentRow).Item("ABS--W/0/P") IsNot DBNull.Value AndAlso dt.Rows(currentRow).Item("ABS--W/0/P") <> 0 Then
            e.Graphics.DrawString(dt.Rows(currentRow).Item("ABS--W/0/P").ToString(), font1, Brushes.Black, 690, yaxis + 4)
        End If

        If dt.Rows(currentRow).Item("SPL") IsNot DBNull.Value AndAlso dt.Rows(currentRow).Item("SPL") <> 0 Then
            e.Graphics.DrawString(dt.Rows(currentRow).Item("SPL").ToString(), font1, Brushes.Black, 730, yaxis + 4)
        End If

        If dt.Rows(currentRow).Item("SOL") IsNot DBNull.Value AndAlso dt.Rows(currentRow).Item("SOL") <> 0 Then
            e.Graphics.DrawString(dt.Rows(currentRow).Item("SOL").ToString(), font1, Brushes.Black, 765, yaxis + 4)
        End If

        If dt.Rows(currentRow).Item("MAL") IsNot DBNull.Value AndAlso dt.Rows(currentRow).Item("MAL") <> 0 Then
            e.Graphics.DrawString(dt.Rows(currentRow).Item("MAL").ToString(), font1, Brushes.Black, 800, yaxis + 4)
        End If

        If dt.Rows(currentRow).Item("PAL") IsNot DBNull.Value AndAlso dt.Rows(currentRow).Item("PAL") <> 0 Then
            e.Graphics.DrawString(dt.Rows(currentRow).Item("PAL").ToString(), font1, Brushes.Black, 835, yaxis + 4)
        End If

        If dt.Rows(currentRow).Item("MCW") IsNot DBNull.Value AndAlso dt.Rows(currentRow).Item("MCW") <> 0 Then
            e.Graphics.DrawString(dt.Rows(currentRow).Item("MCW").ToString(), font1, Brushes.Black, 870, yaxis + 4)
        End If

        If dt.Rows(currentRow).Item("RPL") IsNot DBNull.Value AndAlso dt.Rows(currentRow).Item("RPL") <> 0 Then
            e.Graphics.DrawString(dt.Rows(currentRow).Item("RPL").ToString(), font1, Brushes.Black, 905, yaxis + 4)
        End If

        If dt.Rows(currentRow).Item("SEL") IsNot DBNull.Value AndAlso dt.Rows(currentRow).Item("SEL") <> 0 Then
            e.Graphics.DrawString(dt.Rows(currentRow).Item("SEL").ToString(), font1, Brushes.Black, 945, yaxis + 4)
        End If

        If dt.Rows(currentRow).Item("OTHERS") IsNot Nothing Then
            e.Graphics.DrawString(dt.Rows(currentRow).Item("OTHERS").ToString(), font1, Brushes.Black, 980, yaxis + 4)
        End If

        If dt.Rows(currentRow).Item("DATE & ACTION TAKEN") IsNot Nothing Then
            e.Graphics.DrawString(dt.Rows(currentRow).Item("DATE & ACTION TAKEN").ToString(), font1, Brushes.Black, 1050, yaxis + 4)
        End If

        'e.Graphics.DrawLine(blackPen, 20, yaxis, 1280, yaxis) 'horizontal
    End Sub


    Private Sub HeaderPage(e As Printing.PrintPageEventArgs)

        Dim blackPen As New Pen(Brushes.Black)

        Dim font1 As New Font("Arial", 10, FontStyle.Regular)
        Dim font2 As New Font("Arial", 13, FontStyle.Bold)
        Dim font3 As New Font("Arial", 7, FontStyle.Regular)
        Dim font4 As New Font("Arial", 8, FontStyle.Regular)

        Dim y As Integer = 130
        Dim i As Integer = 0

        While i < 30
            e.Graphics.DrawLine(blackPen, 20, y, 1280, y)
            y += 23
            i += 1
        End While

        Dim nameLabel As String = "NAME: " + txtName.Text
        e.Graphics.DrawString(nameLabel, font1, Brushes.Black, 100, 30)

        Dim deptLabel As String = "DIVISION/OFFICE: " + txtDepartment.Text
        e.Graphics.DrawString(deptLabel, font1, Brushes.Black, 400, 30)

        e.Graphics.DrawString("1st DAY OF SERVICE", font1, Brushes.Black, 720, 30)

        e.Graphics.DrawString("VACATION LEAVE", font2, Brushes.Black, 320, 56)
        e.Graphics.DrawString("SICK LEAVE", font2, Brushes.Black, 610, 56)
        e.Graphics.DrawString("PRIVILEGE LEAVE", font2, Brushes.Black, 820, 56)


        e.Graphics.DrawString("PERIOD", font1, Brushes.Black, 50, 95)
        e.Graphics.DrawString("PARTICULARS", font1, Brushes.Black, 170, 95)
        e.Graphics.DrawString("EARNED", font4, Brushes.Black, 295, 95)

        e.Graphics.DrawString("UND/", font4, Brushes.Black, 349, 84)
        e.Graphics.DrawString("TARDY/", font4, Brushes.Black, 349, 97)
        e.Graphics.DrawString("LATE", font4, Brushes.Black, 349, 109)

        e.Graphics.DrawString("VL", font1, Brushes.Black, 400, 97)
        e.Graphics.DrawString("FL", font1, Brushes.Black, 435, 97)
        e.Graphics.DrawString("BAL", font4, Brushes.Black, 470, 97)

        e.Graphics.DrawString("ABS.", font4, Brushes.Black, 510, 84)
        e.Graphics.DrawString("UND.", font4, Brushes.Black, 510, 97)
        e.Graphics.DrawString("W/O/P", font4, Brushes.Black, 510, 109)

        e.Graphics.DrawString("EARNED", font4, Brushes.Black, 560, 97)

        e.Graphics.DrawString("ABS.", font4, Brushes.Black, 620, 84)
        e.Graphics.DrawString("UND.", font4, Brushes.Black, 620, 97)
        e.Graphics.DrawString("W / P", font4, Brushes.Black, 620, 109)

        e.Graphics.DrawString("BAL", font4, Brushes.Black, 655, 97)

        e.Graphics.DrawString("ABS.", font4, Brushes.Black, 690, 84)
        e.Graphics.DrawString("UND.", font4, Brushes.Black, 690, 97)
        e.Graphics.DrawString("W/O/P", font4, Brushes.Black, 690, 109)

        e.Graphics.DrawString("SPL", font1, Brushes.Black, 725, 97)
        e.Graphics.DrawString("SOP", font1, Brushes.Black, 762, 97)
        e.Graphics.DrawString("MAL", font1, Brushes.Black, 797, 97)
        e.Graphics.DrawString("PAL", font1, Brushes.Black, 835, 97)
        e.Graphics.DrawString("MCW", font1, Brushes.Black, 865, 97)
        e.Graphics.DrawString("RPL", font1, Brushes.Black, 905, 97)
        e.Graphics.DrawString("SEL", font1, Brushes.Black, 940, 97)
        e.Graphics.DrawString("OTHRS", font1, Brushes.Black, 980, 97)

        e.Graphics.DrawString("DATE AND", font4, Brushes.Black, 1130, 59)
        e.Graphics.DrawString("ACTION TAKEN", font4, Brushes.Black, 1120, 73)
        e.Graphics.DrawString("ON APPL.. OR", font4, Brushes.Black, 1120, 88)
        e.Graphics.DrawString("LEAVE", font4, Brushes.Black, 1140, 101)

        e.Graphics.DrawLine(blackPen, 20, 25, 1280, 25) 'horizontal
        e.Graphics.DrawLine(blackPen, 20, 50, 1280, 50) 'horizontal
        e.Graphics.DrawLine(blackPen, 20, 80, 1040, 80) 'horizontal
        'e.Graphics.DrawLine(blackPen, 20, 120, 980, 120) 'horizontal

        'e.Graphics.DrawLine(blackPen, 20, 650, 1280, 650) 'horizontal

        e.Graphics.DrawLine(blackPen, 20, 25, 20, 821) 'vertical 1
        e.Graphics.DrawLine(blackPen, 140, 50, 140, 821) 'vertical 2
        e.Graphics.DrawLine(blackPen, 290, 50, 290, 821) 'vertical 3
        e.Graphics.DrawLine(blackPen, 345, 80, 345, 821) 'vertical 4
        e.Graphics.DrawLine(blackPen, 395, 80, 395, 821) 'vertical vl 5 
        e.Graphics.DrawLine(blackPen, 430, 80, 430, 821) 'vertical fl 6 
        e.Graphics.DrawLine(blackPen, 465, 80, 465, 821) 'vertical pl 7
        e.Graphics.DrawLine(blackPen, 505, 80, 505, 821) 'vertical balance 8
        e.Graphics.DrawLine(blackPen, 555, 50, 555, 821) 'vertical abs 9 

        e.Graphics.DrawLine(blackPen, 610, 80, 610, 821) 'vertical earned 10 
        e.Graphics.DrawLine(blackPen, 650, 80, 650, 821) 'vertical abs 11   
        e.Graphics.DrawLine(blackPen, 685, 80, 685, 821) 'vertical bal 12 
        e.Graphics.DrawLine(blackPen, 725, 50, 725, 821) 'vertical abs 13  
        e.Graphics.DrawLine(blackPen, 760, 80, 760, 821) 'vertical spl 14   
        e.Graphics.DrawLine(blackPen, 795, 80, 795, 821) 'vertical sop 15   
        e.Graphics.DrawLine(blackPen, 830, 80, 830, 821) 'vertical mal 16   
        e.Graphics.DrawLine(blackPen, 865, 80, 865, 821) 'vertical mcw 18   
        e.Graphics.DrawLine(blackPen, 900, 80, 900, 821) 'vertical rpl 19   
        e.Graphics.DrawLine(blackPen, 940, 80, 940, 821) 'vertical sel 20   
        e.Graphics.DrawLine(blackPen, 975, 80, 975, 821) 'vertical others 21  

        e.Graphics.DrawLine(blackPen, 1040, 50, 1040, 821) 'vertical  

        e.Graphics.DrawLine(blackPen, 1280, 25, 1280, 821) 'vertical


        e.Graphics.DrawLine(blackPen, 20, 821, 1280, 821) 'horizontal
    End Sub


    Private Sub btnPreview_Click(sender As Object, e As EventArgs) Handles btnPreview.Click

        isPreview = True

        currentRow = 0
        yaxis = 130

        If iterator > Math.Round(totalRows / 30) Then

            iterator = 1
        End If



        ' Set the paper size to Legal
        Dim legalSize As New PaperSize("Legal", 850, 1300)
        docLeavereq.DefaultPageSettings.PaperSize = legalSize

        ' Set the page orientation to Landscape
        docLeavereq.DefaultPageSettings.Landscape = True

        Dim zoomFactor As Single = 1 ' 100%
        previewLeavereq.PrintPreviewControl.Zoom = zoomFactor

        previewLeavereq.Document = docLeavereq
        ' Convert centimeters to hundredths of an inch (since 1 inch = 2.54cm)
        ' Dim widthInHundredthsOfAnInch As Integer = 1000
        ' Dim heightInHundredthsOfAnInch As Integer = 660

        'Dim customSize As New PaperSize("Custom", widthInHundredthsOfAnInch, heightInHundredthsOfAnInch)
        ' docLeavereq.DefaultPageSettings.PaperSize = customSize

        previewLeavereq.ShowDialog()

    End Sub

    Private Sub print_Click(sender As Object, e As EventArgs) Handles print.Click

        iterator = 1
        yaxis = 130
        currentRow = 0
        'docLeavereq.PrinterSettings.PrintRange = System.Drawing.Printing.PrintRange.AllPages

        printdialogLeavereq.Document = docLeavereq

        If printdialogLeavereq.ShowDialog = Windows.Forms.DialogResult.OK Then
            docLeavereq.Print()

        End If

    End Sub


    Private Sub pagesetup_Click(sender As Object, e As EventArgs) Handles pagesetup.Click
        ' Set the paper size to Legal
        Dim legalSize As New PaperSize("Legal", 850, 1300)
        docLeavereq.DefaultPageSettings.PaperSize = legalSize

        ' Set the page orientation to Landscape
        docLeavereq.DefaultPageSettings.Landscape = True

        ' Show the PageSetupDialog
        PageSetupDialog1.Document = docLeavereq
        PageSetupDialog1.Document.DefaultPageSettings.Color = False
        PageSetupDialog1.ShowDialog()
    End Sub

    Private Sub btnCredits_Click(sender As Object, e As EventArgs) Handles btnCredits.Click

        Dim frmViewInstance As New frmUpdatecreds(userID)

        frmViewInstance.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'frmBalances.Show()

        Me.Close()
        _mainForm.frmLeavecardOpen()
    End Sub

End Class
