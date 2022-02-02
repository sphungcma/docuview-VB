Imports System.IO
Imports System.Net.Http
Imports System.Net.Http.Headers
Imports GdPicture14

Public Class AnnotateApi
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        DocuVieware1.Timeout = [Global_asax].SESSION_TIMEOUT
        Dim oPDF As GdPicturePDF = Nothing

        If Not IsPostBack Then

            Dim ppAPIpath As String = "https://localhost:44360/api/getimage"
            Dim client = New HttpClient()
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

            Try
                Dim outputFile = "C:\Code.DocuVieware\Result\ResultFile.pdf"
                Dim ms As FileStream = New FileStream(outputFile, FileMode.OpenOrCreate)
                DocuVieware1.GetNativePDF(oPDF)
                oPDF.SaveToStream(ms)
                ms.Dispose()
            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try
        End If

    End Sub

End Class