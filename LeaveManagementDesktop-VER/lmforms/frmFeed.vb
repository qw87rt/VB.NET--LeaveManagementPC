Imports System.Net.Http
Imports System.Net.Http.Headers
Imports System.Text
Imports Newtonsoft.Json

Public Class frmFeed

    Dim accessToken As String = My.Settings.accessToken
    Dim refreshToken As String = My.Settings.refreshToken


    Private Async Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim feedback = txtFeedback.Text

        If String.IsNullOrEmpty(feedback) Then
            MessageBox.Show("No feedback provided. ")
            Return
        End If

        Dim host As String = My.Settings.host
        HttpClientSingleton.SharedClient.DefaultRequestHeaders.Authorization = New AuthenticationHeaderValue("Bearer", accessToken)
        Dim content As New StringContent(JsonConvert.SerializeObject(New With {
        .feedback = feedback
    }), Encoding.UTF8, "application/json")

        Dim response As HttpResponseMessage = Await HttpClientSingleton.SharedClient.PostAsync("http://" & host & ":3000/adminside/feedback", content)

        If response.IsSuccessStatusCode Then
            MessageBox.Show("Feedback submitted successfully!")
            Me.Close()
        Else
            MessageBox.Show("Something went wrong")
            Me.Close()
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub frmFeed_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class