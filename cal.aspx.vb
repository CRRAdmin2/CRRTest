Imports System.Configuration.ConfigurationManager

Partial Class cal
    Inherits System.Web.UI.Page

  Protected Sub Cal_Calendar_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cal_Calendar.SelectionChanged
    'Dim script As String
    'script = "window.opener.document.getElementById('" & Request("object").Replace("hypFecha", "txtFecha") & "').value = '" & Cal_Calendar.SelectedDate.ToString("MM/dd/yyyy") & "';"
    'script &= "window.close();"
    'Page.ClientScript.RegisterStartupScript(Me.GetType, "scriptDate", script, True)
    If Request.Browser.Browser = "IE" Then
      Page.ClientScript.RegisterStartupScript(Me.GetType, "script", "<script language='javascript'>window.returnValue = '" & Cal_Calendar.SelectedDate.ToString("MM/dd/yyyy") & "'; window.close();</script>")
    Else
      Page.ClientScript.RegisterStartupScript(Me.GetType, "script", "<script language='javascript'>window.opener.document.forms(0).submit(); window.close();</script>")
      'Page.ClientScript.RegisterStartupScript(Me.GetType, "script", "<script language='javascript'>window.opener.location.reload(); window.close();</script>")
    End If

  End Sub
End Class
