
Partial Class Users
  Inherits System.Web.UI.Page

  Protected Sub GridView1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.PreRender
    For i As Integer = 0 To GridView1.Rows.Count - 1
      If GridView1.Rows(i).Cells(1).Text = "1" Then
        GridView1.Rows(i).Cells(0).Enabled = False
      End If
      Dim lnbChangePassword As LinkButton = GridView1.Rows(i).FindControl("lnbChangePassword")
      lnbChangePassword.CommandArgument = GridView1.Rows(i).Cells(1).Text
    Next
  End Sub

  Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
    Dim val As String = Valida()
    If val = "" Then
      Using tablas As New DataClassesDataContext
        Dim usr As New Usuario
        usr.Usuario = txtUser.Text
        usr.Nombre = txtName.Text
        usr.Password = Util.Encriptar(txtPassword.Text)
        tablas.Usuarios.InsertOnSubmit(usr)
        tablas.SubmitChanges()
        Limpia()
      End Using
    Else
      ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('Error list...                \n\n" & val & "');", True)
      panelNewUser_ModalPopupExtender.Show()
    End If
    LinqDataSource1.DataBind()
    GridView1.DataBind()
  End Sub

  Private Function Valida() As String
    Dim val As String = ""

    If txtUser.Text.Trim = "" Then
      val &= " - User is required \n"
    Else
      Using usrs As New DataClassesDataContext
        Dim usr = (From c In usrs.Usuarios Where c.Usuario = txtUser.Text.Trim).ToList
        If usr.Count > 0 Then
          val &= " - User \'" & txtUser.Text & "\' already exists in database \n"
        End If
      End Using
    End If
    If txtUser.Text.Trim.IndexOf(" ") > -1 Then val &= " - no spaces in User \n"
    If txtName.Text.Trim = "" Then val &= " - Name is required \n"
    If txtPassword.Text.Trim = "" Then val &= " - Password is required \n"
    If txtPassword.Text.Trim <> txtConfirmPwd.Text.Trim Then val &= " - Confirmation does not match with password \n"

    Return val
  End Function

  Private Sub Limpia()
    txtUser.Text = ""
    txtName.Text = ""
    txtPassword.Text = ""
    txtConfirmPwd.Text = ""
  End Sub

  Private Sub LimpiaChangePassword()
    lblIdUser.Text = ""
    lblUser.Text = ""
    lblName.Text = ""
    txtChangeOldPassword.Text = ""
    txtChangePassword.Text = ""
    txtChangeConfirmPwd.Text = ""
  End Sub

  Private Sub LlenaChangePassword(ByVal idUser As String)
    lblIdUser.Text = idUser
    Using usrs As New DataClassesDataContext
      Dim usr = (From u In usrs.Usuarios Where u.IdUsuario = CInt(idUser)).ToList(0)
      lblUser.Text = usr.Usuario
      lblName.Text = usr.Nombre
      txtChangeOldPassword.Text = ""
      txtChangePassword.Text = ""
      txtChangeConfirmPwd.Text = ""
    End Using

  End Sub

  Protected Sub chkPasswordMode_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkPasswordMode.CheckedChanged
    If chkPasswordMode.Checked Then
      txtPassword.TextMode = TextBoxMode.Password
    Else
      txtPassword.TextMode = TextBoxMode.SingleLine
    End If
    txtConfirmPwd.TextMode = txtPassword.TextMode
    panelNewUser_ModalPopupExtender.Show()
  End Sub

  Protected Sub lnbChangePassword_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    Dim lnb As LinkButton = sender
    LimpiaChangePassword()
    LlenaChangePassword(lnb.CommandArgument)
    panelChangePassword_ModalPopupExtender1.Show()
  End Sub

  Protected Sub btnChangeOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnChangeOk.Click
    'Using usrs As New DataClassesDataContext
    '  Dim usr = (From u In usrs.Usuarios Where u.IdUsuario = CInt(lblIdUser.Text)).ToList
    '  If usr.Count > 0 Then
    '    If usr(0).Password = Util.Encriptar(txtChangePassword.Text) Then

    '    End If
    '  Else
    '    ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('User not available');", True)
    '  End If
    'End Using
    Dim val As String = ValidaChangePassword(lblIdUser.Text)
    If val = "" Then
      Using tablas As New DataClassesDataContext
        Dim usr = (From c In tablas.Usuarios Where c.IdUsuario = CInt(lblIdUser.Text)).ToList
        If usr.Count > 0 Then
          usr(0).Password = Util.Encriptar(txtChangePassword.Text.Trim)
          tablas.SubmitChanges()
          ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('Password changed successfully');", True)
        Else
          ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('User not available');", True)
        End If
      End Using
    Else
      ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('Cannot change password due to ...                \n\n" & val & "');", True)
      panelChangePassword_ModalPopupExtender1.Show()
    End If
  End Sub

  Private Function ValidaChangePassword(ByVal IdUser As String) As String
    Dim val As String = ""

    If txtChangeOldPassword.Text.Trim = "" Then val &= " - Old Password is required \n"
    If txtChangePassword.Text.Trim = "" Then val &= " - New Password is required \n"
    If txtChangeConfirmPwd.Text.Trim <> txtChangePassword.Text.Trim Then val &= " - Confirmation does not match with new password \n"
    Using usrs As New DataClassesDataContext
      Dim usr = (From c In usrs.Usuarios Where c.IdUsuario = CInt(IdUser)).ToList
      If usr.Count > 0 Then
        If usr(0).Password <> Util.Encriptar(txtChangeOldPassword.Text.Trim) Then val &= " - Old Password is incorrect"
      Else
        val &= " - User not available"
      End If
    End Using

    Return val
  End Function


End Class
