Imports Microsoft.VisualBasic
Imports System.Web
Imports System.Web.Script.Services
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports Newtonsoft.Json
Imports Linq

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
<ScriptService()> _
<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<CompilerServices.DesignerGenerated()> _
Public Class WebService
    Inherits System.Web.Services.WebService
    Private ReadOnly _jsonSerializerSettings As JsonSerializerSettings
	Private _db As DataClassesDataContext
    Sub New()
		_jsonSerializerSettings = New JsonSerializerSettings() With {.NullValueHandling = NullValueHandling.Ignore}
		_db = New DataClassesDataContext()
    End Sub

    <WebMethod()> _
    Public Function HelloWorld() As String
        Return "Hello World"
    End Function

	<WebMethod()> _
	<ScriptMethod(UseHttpGet:=False, ResponseFormat:=ResponseFormat.Json)> _
	Public Function Search(ByVal Updates As List(Of PropertyUpdate)) As Object
		Dim tsNumbers = Updates.Select(Function(u) u.TsNumber).ToList()
		Dim res = _db.NTSMatchings.Where(Function(n As NTSMatching) tsNumbers.Contains(n.tsno) And Not n.IdStatus = 2 And Not n.IdStatus = 4 And n.Locked = 0).ToList()
		Return res
		
	End Function

End Class

Public Class PropertyUpdate
	Public TsNumber As String
	Public TsUpdateDate As DateTime?
	Public County As Integer?
	Public State As String
End Class

