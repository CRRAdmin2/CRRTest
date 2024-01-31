Imports Microsoft.VisualBasic
Imports System.Xml.Serialization
Imports System.IO
Imports System.Xml
Imports System.Text
Imports System.Runtime.Serialization
Imports System.Security.Cryptography
Imports System.Security.Principal
Imports System.Configuration.ConfigurationManager

Public Module Util

  Public Function StringDate(ByVal strDate As String) As Date
    Try
      Dim strSplit() As String = Split(strDate, "/")
      If strSplit.Count < 2 Then
        strSplit = Split(strDate, "-")
      End If
      If strSplit.Count < 2 Then Return New Date(CInt(strDate.Substring(6, 4)), CInt(strDate.Substring(0, 2)), CInt(strDate.Substring(3, 2)))
      Return New Date(strSplit(2), strSplit(0), strSplit(1))
    Catch ex As Exception
      Return New Date(1900, 1, 1)
    End Try
  End Function

  Public Function StringDateMax(ByVal strDate As String) As Date
    Try
      Return New Date(CInt(strDate.Substring(6, 4)), CInt(strDate.Substring(0, 2)), CInt(strDate.Substring(3, 2)))
    Catch ex As Exception
      Return New Date(9900, 1, 1)
    End Try
  End Function

  Public Function Serializar(ByVal objeto As Object) As String
    Dim dcs As New DataContractSerializer(objeto.GetType)

    Dim sb As New StringBuilder()
    Dim writer As XmlWriter = XmlWriter.Create(sb)
    dcs.WriteObject(writer, objeto)
    writer.Close()
    Dim xml As String = sb.ToString()
    Return xml
  End Function

  Public Function Deserializar(ByVal objeto As String, ByVal tipo As Type) As Object
    Dim dcs As New DataContractSerializer(tipo)

    Dim sb As New StringReader(objeto)
    Dim reader As XmlReader = XmlReader.Create(sb)
    Dim clase = dcs.ReadObject(reader, True)
    reader.Close()
    Return clase
  End Function

  Public Function GetColumnIndexByHeaderText(ByVal aGridView As GridView, ByVal ColumnText As String) As Integer
    Dim celda As String
    For Index As Integer = 0 To aGridView.Columns.Count - 1 ' aGridView.HeaderRow.Cells.Count - 1
      celda = aGridView.Columns(Index).HeaderText
      If celda = ColumnText Then
        Return Index
      End If
    Next
    Return -1
  End Function

  Public Function Usuario() As Integer
    Return CInt(HttpContext.Current.User.Identity.Name)
  End Function

  Public Function AutentificarUsuario(ByVal objU As Usuario) As HttpCookie
    Dim authTicket As New FormsAuthenticationTicket(objU.IdUsuario, objU.IdUsuario, DateTime.Now, _
                                                    DateTime.Now.AddMinutes(AppSettings("TiempoFuera")), False, "")
    Dim encTicket As String = FormsAuthentication.Encrypt(authTicket)
    FormsAuthentication.GetRedirectUrl(objU.IdUsuario, True)
    Return New HttpCookie(FormsAuthentication.FormsCookieName, encTicket)
  End Function

  Public Function UsuarioAutentificado(ByVal authCookie As HttpCookie) As GenericPrincipal
    'authCookie.Expires = DateTime.Now.AddSeconds(AppSettings("TiempoFuera"))
    Dim authticket As FormsAuthenticationTicket = FormsAuthentication.Decrypt(authCookie.Value)

    Dim newTicket As New FormsAuthenticationTicket(authticket.Version, authticket.Name, Now, Now.AddSeconds(AppSettings("TiempoFuera")), False, authticket.UserData)

    Dim Roles() As String = newTicket.UserData.Split("|")
    Dim UserIdentity As New GenericIdentity(newTicket.Name)

    Return New GenericPrincipal(UserIdentity, Roles)
  End Function


  Private Cadena As String = "%&*@?#:,"

  'The function used to encrypt the text
  Public Function Encriptar(ByVal strText As String) As String
    Dim strEncrKey As String = Cadena
    Dim byKey() As Byte = {}
    Dim IV() As Byte = {&H12, &H34, &H56, &H78, &H90, &HAB, &HCD, &HEF}

    Try
      byKey = System.Text.Encoding.UTF8.GetBytes(Left(strEncrKey, 8))

      Dim des As New DESCryptoServiceProvider()
      Dim inputByteArray() As Byte = Encoding.UTF8.GetBytes(strText)
      Dim ms As New MemoryStream()
      Dim cs As New CryptoStream(ms, des.CreateEncryptor(byKey, IV), CryptoStreamMode.Write)
      cs.Write(inputByteArray, 0, inputByteArray.Length)
      cs.FlushFinalBlock()
      Return Convert.ToBase64String(ms.ToArray())

    Catch ex As Exception
      Return ex.Message
    End Try

  End Function

  'The function used to decrypt the text
  Public Function DesEncriptar(ByVal strText As String) As String
    Dim sDecrKey As String = Cadena
    Dim byKey() As Byte = {}
    Dim IV() As Byte = {&H12, &H34, &H56, &H78, &H90, &HAB, &HCD, &HEF}
    Dim inputByteArray(strText.Length) As Byte

    Try
      byKey = System.Text.Encoding.UTF8.GetBytes(Left(sDecrKey, 8))
      Dim des As New DESCryptoServiceProvider()
      inputByteArray = Convert.FromBase64String(strText)
      Dim ms As New MemoryStream()
      Dim cs As New CryptoStream(ms, des.CreateDecryptor(byKey, IV), CryptoStreamMode.Write)

      cs.Write(inputByteArray, 0, inputByteArray.Length)
      cs.FlushFinalBlock()
      Dim encoding As System.Text.Encoding = System.Text.Encoding.UTF8

      Return encoding.GetString(ms.ToArray())

    Catch ex As Exception
      Return ex.Message
    End Try

  End Function

  Public Sub EstimatedValue(ByVal propID As String)
    Using clase As New DataClassesDataContext
      Dim oLista = (From t In clase.ESTIMATED_VALUEs Where t.SA_PROPERTY_ID = propID Select t).ToList
      If oLista.Count = 0 Then
        Dim newEst As New ESTIMATED_VALUE
        newEst.SA_PROPERTY_ID = propID
        clase.ESTIMATED_VALUEs.InsertOnSubmit(newEst)
        clase.SubmitChanges()
      End If
    End Using
  End Sub

  Public Sub LogRec(ByVal MainFolder As String, ByVal message As String)
    Dim archivo As String
    Dim fs As New FileStream(MainFolder & "log.txt", FileMode.OpenOrCreate, FileAccess.Write)
    Dim s As New StreamWriter(fs)
    s.BaseStream.Seek(0, SeekOrigin.End)
    s.WriteLine(Now.ToString("yyyy/MMM/dd hh:mm:ss") & " / " & message)
    s.Close()
  End Sub

End Module
