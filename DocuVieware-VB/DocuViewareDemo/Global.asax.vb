Imports System.Web.Optimization
Imports GdPicture14.WEB

Public Class Global_asax
    Inherits HttpApplication

    Public Shared ReadOnly SESSION_TIMEOUT As Integer = 20
    Private Const STICKY_SESSION As Boolean = True
    Private Const DOCUVIEWARE_SESSION_STATE_MODE As DocuViewareSessionStateMode = DocuViewareSessionStateMode.InProc

    Public Shared Function GetCacheDirectory() As String
        Return HttpRuntime.AppDomainAppPath & "\cache"
    End Function

    Public Shared Function GetDocumentsDirectory() As String
        Return HttpRuntime.AppDomainAppPath & "\documents"
    End Function

    Sub Application_Start(sender As Object, e As EventArgs)
        ' Fires when the application is started
        RouteConfig.RegisterRoutes(RouteTable.Routes)
        BundleConfig.RegisterBundles(BundleTable.Bundles)

        DocuViewareLicensing.RegisterKEY("0466417482593787464361772") ' Unlocking DocuVieware
        DocuViewareManager.SetupConfiguration(True, DocuViewareSessionStateMode.InProc, HttpRuntime.AppDomainAppPath + "\\Cache")

    End Sub

    Private Shared Sub NewDocumentLoadedHandler(ByVal sender As Object, ByVal e As NewDocumentLoadedEventArgs)
        e.docuVieware.PagePreload = If(e.docuVieware.PageCount <= 50, PagePreloadMode.AllPages, PagePreloadMode.AdjacentPages)
    End Sub
End Class