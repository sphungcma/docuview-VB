Imports System.IO
Imports System.Net.Http
Imports System.Net.Http.Headers
Imports GdPicture14

Public Class AnnotateApi
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        DocuVieware1.Timeout = [Global_asax].SESSION_TIMEOUT
        Dim oPDF As GdPicturePDF = Nothing

        Dim docId As String = Request.QueryString("docId")
        Dim ppAPIpath As String
        Dim client = New HttpClient()

        If Not IsPostBack Then

            If String.IsNullOrEmpty(docId) Then
                ppAPIpath = "https://localhost:44360/api/getimage"
            Else
                ppAPIpath = "https://localhost:44360/api/getimage/" + docId
            End If

            client.BaseAddress = New Uri(ppAPIpath)
            client.DefaultRequestHeaders.Accept.Clear()
            client.DefaultRequestHeaders.Accept.Add(New MediaTypeWithQualityHeaderValue("application/json"))
            Dim responseTask = client.GetStringAsync(ppAPIpath)
            responseTask.Wait()

            Try
                Dim result As String = responseTask.Result.Replace("""", "")
                Dim myarray As Byte() = Convert.FromBase64String(result)
                Dim ms As MemoryStream = New MemoryStream(myarray)
                DocuVieware1.LoadFromStream(ms, True)
            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try

        Else

            docId = documentId.Value
            ppAPIpath = "https://localhost:44360/api/getimage/" + docId

            client.BaseAddress = New Uri(ppAPIpath)
            client.DefaultRequestHeaders.Accept.Clear()
            client.DefaultRequestHeaders.Accept.Add(New MediaTypeWithQualityHeaderValue("application/json"))
            Dim responseTask = client.GetStringAsync(ppAPIpath)
            responseTask.Wait()

            Try
                Dim result As String = responseTask.Result.Replace("""", "")
                Dim myarray As Byte() = Convert.FromBase64String(result)
                Dim ms As MemoryStream = New MemoryStream(myarray)
                DocuVieware1.LoadFromStream(ms, True)
                DocuVieware1.RedrawPage()
            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try
        End If

    End Sub

End Class