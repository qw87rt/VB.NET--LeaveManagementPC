Imports System.Net.Http
Imports System.Text
Imports Newtonsoft.Json



Public Module HttpClientSingleton
    Private ReadOnly client As New HttpClient()

    Public ReadOnly Property SharedClient As HttpClient
        Get
            Return client
        End Get
    End Property
End Module
Public Class Form1
    Private host As String

    Private Async Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        host = My.Settings.host

        Dim accessToken As String = My.Settings.accessToken
        Dim refreshToken As String = My.Settings.refreshToken


        ' Prepare the data to send
        Dim data As New With {Key .token = refreshToken}
        Dim jsonContent As String = JsonConvert.SerializeObject(data)
        Dim content As New StringContent(jsonContent, Encoding.UTF8, "application/json")

        Try
            Dim response As HttpResponseMessage = Await HttpClientSingleton.SharedClient.PostAsync("http://" & host & ":3000/adminside/generatetoken", content)

            ' Check the status code of the response
            If response.IsSuccessStatusCode Then
                Dim responseString As String = Await response.Content.ReadAsStringAsync()
                Dim responseData As Dictionary(Of String, String) = JsonConvert.DeserializeObject(Of Dictionary(Of String, String))(responseString)

                If responseData.ContainsKey("accessToken") Then
                    My.Settings.accessToken = responseData("accessToken")
                    'MessageBox.Show(accessToken)
                    Me.Hide()
                    mainform.Show()
                Else
                    Throw New Exception("Server did not return a new access token.")
                End If
            Else
                Throw New Exception("Server returned status code: " & response.StatusCode)
                'MessageBox.Show("Please Login")
            End If
        Catch ex As Exception
            Console.WriteLine("Error refreshing token: " & ex.Message)
            'MessageBox.Show("Please Login")
        End Try



    End Sub


    Private Async Sub BTNsignin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNsignin.Click

        BTNsignin.BackColor = Color.LightSteelBlue
        BTNsignin.Enabled = False

        Dim adminID As String = TXTadminid.Text
        Dim password As String = TXTpassword.Text
        host = My.Settings.host

        Dim accessToken As String = My.Settings.accessToken
        Dim refreshToken As String = My.Settings.refreshToken
        Dim accessLevel As String = My.Settings.accessLevel

        ' Prepare the data to send
        Dim data As New With {Key .adminid = adminID, Key .password = password}
        Dim jsonContent As String = System.Text.Json.JsonSerializer.Serialize(data)
        Dim content As New StringContent(jsonContent, Encoding.UTF8, "application/json")

        ' Send a POST request
        Try

            Dim response As HttpResponseMessage = Await HttpClientSingleton.SharedClient.PostAsync("http://" & host & ":3000/adminside/login", content)

            ' Check the status code of the response
            If response.IsSuccessStatusCode Then
                Dim responseString As String = Await response.Content.ReadAsStringAsync()
                Dim responseData As Dictionary(Of String, String) = System.Text.Json.JsonSerializer.Deserialize(Of Dictionary(Of String, String))(responseString)
                If responseData.ContainsKey("accessToken") AndAlso responseData.ContainsKey("refreshToken") Then

                    ' MessageBox.Show("Login Success")


                    ' Check if accessLevel is "admin"
                    If responseData.ContainsKey("accessLevel") AndAlso responseData("accessLevel").ToString() = "admin" Then
                        My.Settings.accessLevel = "d033e22ae348aeb5660fc2140aec35850c4da997"
                    End If


                    My.Settings.accessToken = responseData("accessToken")
                    My.Settings.refreshToken = responseData("refreshToken")
                    My.Settings.Save()





                    Me.Hide()

                    mainform.Show()
                    TXTadminid.Text = ""
                    TXTpassword.Text = ""

                Else
                    MessageBox.Show("Login Failed")
                    Console.WriteLine("Login failed")
                End If
            Else
                MessageBox.Show("Login Failed")
                Console.WriteLine("Server returned status code: " & response.StatusCode)
            End If
        Catch ex As InvalidOperationException
            Console.WriteLine("Invalid operation: " & ex.Message)
        Catch ex As UriFormatException
            Console.WriteLine("Invalid URI: " & ex.Message)
        Catch ex As HttpRequestException
            Console.WriteLine("Request failed: " & ex.Message)
        End Try

        BTNsignin.Enabled = True
        BTNsignin.BackColor = Color.DeepPink
    End Sub

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            BTNsignin.PerformClick()

        End If
    End Sub
End Class