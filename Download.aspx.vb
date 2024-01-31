Imports System.Configuration.ConfigurationManager

Partial Class Download
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
      Response.ContentType = "application/vnd.ms-excel"
      'Response.ContentType = "application/octet-stream"
            Response.AddHeader("Content-Disposition", "attachment;filename=" & Request("file"))
            Response.WriteFile(AppSettings("OutputPath").Replace("[SYSTEM]", Request("type")) & "\" & Request("file"))
            Response.Flush()
            Response.Close()
            Response.End()
        End If
    End Sub
End Class
