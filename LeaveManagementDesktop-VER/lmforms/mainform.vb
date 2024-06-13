Imports System.Net.Http
Imports System.Net.Http.Headers
Imports System.Text
Imports System.Text.Json
Imports Newtonsoft.Json

Public Class mainform

    Private currentChildForm As Form = Nothing
    Public Sub New()
        InitializeComponent()
        Me.IsMdiContainer = True
    End Sub






    Private Sub PendingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PendingToolStripMenuItem.Click
        If currentChildForm IsNot Nothing Then
            currentChildForm.Close()
        End If

        Dim childForm As New frmPending(Me)
        childForm.MdiParent = Me
        'childForm.StartPosition = FormStartPosition.Manual
        'childForm.Location = New Point(100, 20) ' Set the desired coordinates here
        childForm.Show()

        currentChildForm = childForm
    End Sub



    Private Sub DeniedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeniedToolStripMenuItem.Click
        If currentChildForm IsNot Nothing Then
            currentChildForm.Close()
        End If

        Dim childForm As New frmDenied(Me)
        childForm.MdiParent = Me
        'childForm.StartPosition = FormStartPosition.Manual
        'childForm.Location = New Point(100, 20) ' Set the desired coordinates here
        childForm.Show()

        currentChildForm = childForm
    End Sub

    Private Sub ApprovedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ApprovedToolStripMenuItem.Click
        If currentChildForm IsNot Nothing Then
            currentChildForm.Close()
        End If

        Dim childForm As New frmApproved(Me)
        childForm.MdiParent = Me
        'childForm.StartPosition = FormStartPosition.Manual
        'childForm.Location = New Point(100, 20) ' Set the desired coordinates here
        childForm.Show()

        currentChildForm = childForm
    End Sub



    Private Sub mainform_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim screenWidth As Integer = Screen.PrimaryScreen.Bounds.Width
        Dim screenHeight As Integer = Screen.PrimaryScreen.Bounds.Height

        Me.Width = screenWidth
        Me.Height = CInt(screenHeight * 0.96)
        'Me.WindowState = FormWindowState.Maximized
        Me.StartPosition = FormStartPosition.Manual
        Me.Location = New Point(0, 0) ' Set the desired coordinates here
        Dim accessLevel As String = My.Settings.accessLevel


        If accessLevel <> "d033e22ae348aeb5660fc2140aec35850c4da997" Then
            'ManageUsersToolStripMenuItem.Visible = False
            RToolStripMenuItem.Visible = False
            AdminListToolStripMenuItem.Visible = False
        End If

        Dim childForm As New frmReports()
        childForm.MdiParent = Me
        'childForm.StartPosition = FormStartPosition.Manual
        'childForm.Location = New Point(130, 10) ' Set the desired coordinates here
        childForm.Show()

        currentChildForm = childForm
    End Sub


    Private Sub mainform_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        ' Close the specific form here
        'Form1.Close()
    End Sub

    Public Sub ToggleLogoutExit(ByVal visible As Boolean)
        LogoutExitToolStripMenuItem.Visible = visible
        Me.ControlBox = visible
    End Sub

    Private Sub LogoutExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogoutExitToolStripMenuItem.Click

        LogoutExitToolStripMenuItem.Enabled = False

        Dim refreshToken As String = My.Settings.refreshToken
        Dim host As String = My.Settings.host
        Dim accessLevel As String = My.Settings.accessLevel
        Dim accessToken As String = My.Settings.accessToken

        'Dim content As New StringContent(JsonConvert.SerializeObject(New With {Key .token = refreshToken}), Encoding.UTF8, "application/json")
        'Dim request As New HttpRequestMessage(HttpMethod.Delete, "http://" & host & ":3000/adminside/logout") With {
        '.Content = content
        '}
        'Dim response As HttpResponseMessage = Await HttpClientSingleton.SharedClient.SendAsync(request)

        'If response.IsSuccessStatusCode Then
        'MessageBox.Show("Logout successful.")





        My.Settings.accessLevel = ""
        My.Settings.refreshToken = ""
        My.Settings.accessToken = ""
        My.Settings.Save()
        Me.Close()
        Form1.Show()
        'Else
        'MessageBox.Show("Logout failed.")
        'End If

        LogoutExitToolStripMenuItem.Enabled = True

    End Sub



    'Private Sub FEEDBACKToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FEEDBACKToolStripMenuItem.Click
    'If currentChildForm IsNot Nothing Then
    '     currentChildForm.Close()
    'End If

    'Dim childForm As New frmFeed()
    '  childForm.MdiParent = Me
    '   'childForm.StartPosition = FormStartPosition.Manual
    ' 'childForm.Location = New Point(130, 10) ' Set the desired coordinates here
    ' childForm.Show()

    '  currentChildForm = childForm
    '  End Sub



    Private Sub ManageUsersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ManageUsersToolStripMenuItem.Click

        If currentChildForm IsNot Nothing Then
            currentChildForm.Close()
        End If

        Dim childForm As New frmUsers(Me)
        childForm.MdiParent = Me
        'childForm.StartPosition = FormStartPosition.Manual
        'childForm.Location = New Point(130, 10) ' Set the desired coordinates here
        childForm.Show()

        currentChildForm = childForm

    End Sub

    Private Sub EmployeeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EmployeeToolStripMenuItem.Click
        If currentChildForm IsNot Nothing Then
            currentChildForm.Close()
        End If

        Dim childForm As New frmRegistuser()
        childForm.MdiParent = Me
        'childForm.StartPosition = FormStartPosition.Manual
        ' childForm.Location = New Point(0, 0) ' Set the desired coordinates here
        childForm.Show()

        currentChildForm = childForm
    End Sub

    Private Sub AdminToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AdminToolStripMenuItem.Click
        If currentChildForm IsNot Nothing Then
            currentChildForm.Close()
        End If

        Dim childForm As New frmRegistadmin()
        childForm.MdiParent = Me
        'childForm.StartPosition = FormStartPosition.Manual
        ' childForm.Location = New Point(0, 0) ' Set the desired coordinates here
        childForm.Show()

        currentChildForm = childForm
    End Sub

    Public Sub frmPendingOpen()
        If currentChildForm IsNot Nothing Then
            currentChildForm.Close()
        End If

        Dim childForm As New frmPending(Me)
        childForm.MdiParent = Me
        'childForm.StartPosition = FormStartPosition.Manual
        'childForm.Location = New Point(100, 20) ' Set the desired coordinates here
        childForm.Show()

        currentChildForm = childForm
    End Sub

    Public Sub frmApprovedOpen()
        If currentChildForm IsNot Nothing Then
            currentChildForm.Close()
        End If

        Dim childForm As New frmApproved(Me)
        childForm.MdiParent = Me
        'childForm.StartPosition = FormStartPosition.Manual
        'childForm.Location = New Point(100, 20) ' Set the desired coordinates here
        childForm.Show()

        currentChildForm = childForm
    End Sub

    Public Sub frmDeniedOpen()
        If currentChildForm IsNot Nothing Then
            currentChildForm.Close()
        End If

        Dim childForm As New frmDenied(Me)
        childForm.MdiParent = Me
        'childForm.StartPosition = FormStartPosition.Manual
        'childForm.Location = New Point(100, 20) ' Set the desired coordinates here
        childForm.Show()

        currentChildForm = childForm
    End Sub


    Public Sub frmLeavecardOpen()
        If currentChildForm IsNot Nothing Then
            currentChildForm.Close()
        End If

        Dim childForm As New frmUsers(Me)
        childForm.MdiParent = Me
        'childForm.StartPosition = FormStartPosition.Manual
        'childForm.Location = New Point(100, 20) ' Set the desired coordinates here
        childForm.Show()

        currentChildForm = childForm
    End Sub

    Public Sub frmListAdminOpen()
        If currentChildForm IsNot Nothing Then
            currentChildForm.Close()
        End If

        Dim childForm As New frmListadmin(Me)
        childForm.MdiParent = Me
        'childForm.StartPosition = FormStartPosition.Manual
        'childForm.Location = New Point(100, 20) ' Set the desired coordinates here
        childForm.Show()

        currentChildForm = childForm
    End Sub
    Private Sub AdminListToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AdminListToolStripMenuItem.Click
        If currentChildForm IsNot Nothing Then
            currentChildForm.Close()
        End If

        Dim childForm As New frmListadmin(Me)
        childForm.MdiParent = Me
        'childForm.StartPosition = FormStartPosition.Manual
        'childForm.Location = New Point(100, 20) ' Set the desired coordinates here
        childForm.Show()

        currentChildForm = childForm
    End Sub

    Private Sub SummaryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SummaryToolStripMenuItem.Click
        If currentChildForm IsNot Nothing Then
            currentChildForm.Close()
        End If

        Dim childForm As New frmReports()
        childForm.MdiParent = Me
        'childForm.StartPosition = FormStartPosition.Manual
        'childForm.Location = New Point(130, 10) ' Set the desired coordinates here
        childForm.Show()

        currentChildForm = childForm
    End Sub
End Class