Imports Newtonsoft.Json
Imports System.Net.Http
Imports System.Net.Http.Headers
Imports System.Text
Imports System.Threading


Public Class frmUpdatecreds


    Private creditreq As List(Of Request)
    Private userid As Integer
    Dim isButtonClicked As Boolean = False
    Private cts As New CancellationTokenSource()


    Public Sub New(userid As Integer)
        ' This call is required by the designer.
        InitializeComponent()

        Me.userid = userid
    End Sub


    Private Async Function GetUserDetails(userid As Integer) As Task(Of String)
        Dim responseString As String = String.Empty

        Try
            Dim host As String = My.Settings.host
            Dim response As HttpResponseMessage = Await HttpClientSingleton.SharedClient.GetAsync("http://" & host & ":3000/adminside/getusercredits/" & userid, cts.Token)
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


    Private Async Sub frmUpdatecreds_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim responseString As String = Await GetUserDetails(userid)
        creditreq = JsonConvert.DeserializeObject(Of List(Of Request))(responseString)



        For Each request As Request In creditreq

            txtVacation.Text = request.vacation
            txtSickleave.Text = request.sickleave
            txtForcedleave.Text = request.forcedleave
            txtSpecial_privilege_leave.Text = request.special_privilege_leave
            txtSolo_parent_leave.Text = request.solo_parent_leave

        Next


        txtVacation.Enabled = False
        txtSickleave.Enabled = False
        txtForcedleave.Enabled = False
        txtSpecial_privilege_leave.Enabled = False
        txtSolo_parent_leave.Enabled = False


    End Sub


    Public Class Request

        Public Property firstname As List(Of String)
        Public Property lastname As List(Of String)
        Public Property vacation As Double
        Public Property sickleave As Double
        Public Property forcedleave As Double
        Public Property special_privilege_leave As Double
        Public Property solo_parent_leave As Double



    End Class
    Private Async Sub btnedit_save_Click(sender As Object, e As EventArgs) Handles btnedit_save.Click
        Dim accessToken As String = My.Settings.accessToken
        Dim refreshToken As String = My.Settings.refreshToken

        If isButtonClicked Then

            Dim result As DialogResult = MessageBox.Show("Are you sure you want to save?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If result = DialogResult.Yes Then


                Dim host As String = My.Settings.host
                Dim updateObject As New Dictionary(Of String, Object)
                updateObject.Add("userid", userid)


                ' Assign default values to the variables
                Dim vacation As String = ""
                Dim sickleave As String = ""
                Dim forcedleave As String = ""
                Dim special_privilege_leave As String = ""
                Dim solo_parent_leave As String = ""

                For Each request As Request In creditreq

                    vacation = request.vacation
                    sickleave = request.sickleave
                    forcedleave = request.forcedleave
                    special_privilege_leave = request.special_privilege_leave
                    solo_parent_leave = request.solo_parent_leave

                Next


                Dim fields As New Dictionary(Of TextBox, String) From {
            {txtVacation, vacation},
            {txtSickleave, sickleave},
            {txtForcedleave, forcedleave},
            {txtSpecial_privilege_leave, special_privilege_leave},
            {txtSolo_parent_leave, solo_parent_leave}
        }

                For Each field In fields
                    If Not field.Key.Text.Equals(field.Value) Then
                        updateObject.Add(field.Key.Name.Substring(3).ToLower(), field.Key.Text) ' Substring(3) to remove "txt" prefix
                    End If
                Next

                Dim content As New StringContent(JsonConvert.SerializeObject(updateObject), Encoding.UTF8, "application/json")
                HttpClientSingleton.SharedClient.DefaultRequestHeaders.Authorization = New AuthenticationHeaderValue("Bearer", accessToken)
                Dim response As HttpResponseMessage = Await HttpClientSingleton.SharedClient.PutAsync("http://" & host & ":3000/adminside/update_user", content)
                MessageBox.Show("Saved")
                Me.Close()
            Else
                'if no/cancel
            End If
        Else
            'txtUserid.Enabled = True

            txtVacation.Enabled = True
            txtSickleave.Enabled = True
            txtForcedleave.Enabled = True
            txtSpecial_privilege_leave.Enabled = True
            txtSolo_parent_leave.Enabled = True
            btnedit_save.Text = "Save"
            isButtonClicked = True
        End If
    End Sub

    Private Sub btnDone_Click(sender As Object, e As EventArgs) Handles btnDone.Click
        Me.Close()
    End Sub
End Class