Imports System.Web.Security
Imports System.Configuration.ConfigurationManager

Partial Class Login
  Inherits System.Web.UI.Page

  Protected Sub btnEntrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEntrar.Click
    Using clase As New DataClassesDataContext
      Dim objU As Usuario
      Dim objUs = (From c In clase.Usuarios Where c.Usuario = txtUsuario.Text.Trim Select c).ToList
      If objUs.Count = 1 Then
        objU = objUs(0)
        If Util.DesEncriptar(objU.Password) = txtContrasena.Text.Trim Then
          Response.Cookies.Add(Util.AutentificarUsuario(objU))
          Response.Cookies("Usuario_Nombre").Value = objU.Nombre
          Response.Cookies("Usuario_Nombre").Expires = Now.AddYears(1)
          Session("UsuarioLogueado") = True
          clase.SubmitChanges()
          Response.Redirect("Default.aspx")
        Else
          ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('Wrong password');", True)
        End If
      Else
        ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('Not valid user');", True)
      End If
    End Using
  End Sub

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    If Not IsPostBack Then
      txtUsuario.Focus()
    End If
  End Sub
End Class
