Imports System.IO
Imports GdPicture14

Public Class AnnotateLocal
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        DocuVieware1.Timeout = [Global_asax].SESSION_TIMEOUT
        Dim oPDF As GdPicturePDF = Nothing

        If Not IsPostBack Then
            Dim testDoc As String = "OnePage.pdf"
            Dim testDocPath As String = "C:\Code.DocuVieware\TestDoc\OnePage.pdf"
            DocuVieware1.LoadFromStream(New System.IO.FileStream(testDocPath, FileMode.Open, FileAccess.Read), True, testDoc)
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