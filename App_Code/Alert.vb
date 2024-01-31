Imports Microsoft.VisualBasic

Public Class Alert


  Public Shared Sub Status(ByVal strMessage As String)
    Dim strScript As String = "alert('" & strMessage & "');"
    Dim guidKey As Guid = Guid.NewGuid()
    Dim pg As Page = HttpContext.Current.Handler
    pg.ClientScript.RegisterStartupScript(pg.GetType(), guidKey.ToString(), strScript, True)
  End Sub

  Public Shared Sub Status(ByVal up As UpdatePanel, ByVal strMessage As String)
    Dim strScript As String = "Status('" & strMessage & "');"
    Dim guidKey As Guid = Guid.NewGuid()
    ScriptManager.RegisterStartupScript(up, up.GetType(), guidKey.ToString(), strScript, True)
  End Sub

  Public Shared Sub ShowInUpdatePanel(ByVal up As UpdatePanel, ByVal strMessage As String)
    Dim strScript As String = "alert('" & strMessage & "');"
    Dim guidKey As Guid = Guid.NewGuid()
    ScriptManager.RegisterStartupScript(up, up.GetType(), guidKey.ToString(), strScript, True)
    End Sub

  Public Shared Sub ShowInUpdatePanel(ByVal strMessage As String)
    Dim strScript As String = "Status('" & strMessage & "');"
    Dim guidKey As Guid = Guid.NewGuid()
    Dim pg As Page = HttpContext.Current.Handler
    'pg.ClientScript.RegisterStartupScript(pg.GetType(), guidKey.ToString(), strScript, True)

    'Dim strScript As String = "alert('" & strMessage & "');"
    'Dim guidKey As Guid = Guid.NewGuid()
    ScriptManager.RegisterStartupScript(pg, pg.GetType(), guidKey.ToString(), strScript, True)
  End Sub

  Public Shared Sub Script(ByVal up As UpdatePanel, ByVal strJavascript As String)
    Dim strScript As String = strJavascript
    Dim guidKey As Guid = Guid.NewGuid
    ScriptManager.RegisterStartupScript(up, up.GetType, guidKey.ToString, strScript, True)
  End Sub

  Public Shared Sub Script(ByVal strJavascript As String)
    Dim strScript As String = strJavascript
    Dim guidKey As Guid = Guid.NewGuid
    Dim pg As Page = HttpContext.Current.Handler
    ScriptManager.RegisterStartupScript(pg, pg.GetType, guidKey.ToString, strScript, True)
  End Sub
End Class
