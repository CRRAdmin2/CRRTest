
Partial Class Principal
    Inherits System.Web.UI.MasterPage

  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    Context.Request.Cookies(FormsAuthentication.FormsCookieName).Expires = Now.AddDays(1) 'Now.AddMinutes(AppSettings("TiempoFuera"))
    Context.User = Util.UsuarioAutentificado(Context.Request.Cookies(FormsAuthentication.FormsCookieName))

    ScriptManager.RegisterClientScriptInclude(Page, Me.GetType(), "GeneralScript", ResolveUrl("~/general.js"))
  End Sub

  Protected Sub lnkExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkExit.Click
    Session.Abandon()
    FormsAuthentication.SignOut()
    Response.Redirect("~/Login.aspx")
  End Sub
End Class

