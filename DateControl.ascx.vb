
Partial Class DateControl
    Inherits System.Web.UI.UserControl

  Public Property Fecha() As Date
    Get
      Return Util.StringDate(txtFecha.Text)
    End Get
    Set(ByVal value As Date)
      If Not (value = #1/1/1900# Or value = #12:00:00 AM#) Then txtFecha.Text = value.ToString("MM/dd/yyyy") Else txtFecha.Text = ""
    End Set
  End Property

  Public Property FechaMax() As Date
    Get
      Return Util.StringDateMax(txtFecha.Text)
    End Get
    Set(ByVal value As Date)
      If value <> #1/1/1900# Then txtFecha.Text = value.ToString("MM/dd/yyyy")
    End Set
  End Property

  Public Property ToolTip() As String
    Get
      Return txtFecha.ToolTip
    End Get
    Set(ByVal value As String)
      txtFecha.ToolTip = value
      hypFecha.ToolTip = value
    End Set
  End Property

  Public ReadOnly Property EsValido() As Boolean
    Get
      Return IsDate(txtFecha.Text)
    End Get
  End Property

  Public Property CssClass() As String
    Get
      Return txtFecha.CssClass
    End Get
    Set(ByVal value As String)
      txtFecha.CssClass = value
    End Set
  End Property

  Public Sub Limpiar()
    txtFecha.Text = ""
  End Sub

  Protected Sub hypFecha_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles hypFecha.PreRender
    If Not IsPostBack Then
      hypFecha.Attributes.Add("onclick", "javascript:Pop_Calendar(this);")
    End If
  End Sub

  Protected Sub txtFecha_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFecha.PreRender
    If Not IsPostBack Then
      txtFecha.Attributes.Add("onfocus", "this.select();")
    End If
  End Sub
End Class
