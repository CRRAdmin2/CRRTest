
Partial Class User
    Inherits System.Web.UI.Page

  Protected Sub btnCambiarContrasena_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    If ValidaPagina() Then
      Using clase As New DataClassesDataContext
        Dim objS = (From s In clase.Usuarios Where s.IdUsuario = Util.Usuario Select s).Single
        If Util.DesEncriptar(objS.Password) = txtContrasena.Text.Trim Then
          Dim objU = (From c In clase.Usuarios Where c.IdUsuario = Util.Usuario Select c).Single
          objU.Password = Util.Encriptar(txtNuevaContrasena.Text)
          clase.SubmitChanges()
          ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Alert", "alert('Password Changed Successfully');", True)
        Else
          ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Alert", "alert('Wrong Current Password');", True)
        End If
      End Using
    End If
  End Sub

  Private Function ValidaPagina() As Boolean
    Dim errores As String = ""
    If txtContrasena.Text.Trim = "" Then errores &= "- Current password required \n"
    If txtNuevaContrasena.Text.Trim = "" Then errores &= "- New password required \n"
    If txtConfirmacion.Text.Trim = "" Then errores &= "- Confirm password required \n"
    If errores = "" Then
      Return True
    Else
      ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Alert", "alert('" & errores & "');", True)
      Return False
    End If
  End Function
End Class
