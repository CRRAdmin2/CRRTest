Imports Microsoft.VisualBasic
Imports System.IO
Imports System.Net

Public Class FTPClient

  Private _currentDirectory As String
  Private _hostname As String
  Private _password As String
  Private _username As String

  Public Property Hostname() As String
    Get
      If Me._hostname.StartsWith("ftp://") Then
        Return Me._hostname
      End If
      Return ("ftp://" & Me._hostname)
    End Get
    Set(ByVal value As String)
      Me._hostname = value
    End Set
  End Property

  Public Property CurrentDirectory() As String
    Get
      Return (Me._currentDirectory + (If(Me._currentDirectory.EndsWith("/"), "", "/")).ToString())
    End Get
    Set(ByVal value As String)
      'If Not value.StartsWith("/") Then
      '  Throw New ApplicationException("Directory should start with /")
      'End If
      Me._currentDirectory = value
    End Set
  End Property

  Public Property Password() As String
    Get
      Return Me._password
    End Get
    Set(ByVal value As String)
      Me._password = value
    End Set
  End Property

  Public Property Username() As String
    Get
      Return (If((Me._username = ""), "anonymous", Me._username))
    End Get
    Set(ByVal value As String)
      Me._username = value
    End Set
  End Property


  Private Function AdjustDir(ByVal path As String) As String
    Return ((If(path.StartsWith("/"), "", "/")).ToString() + path)
  End Function

  Private Function GetRequest(ByVal URI As String) As FtpWebRequest
    Dim result As FtpWebRequest = DirectCast(WebRequest.Create(URI), FtpWebRequest)
    result.Credentials = Me.GetCredentials()
    result.KeepAlive = False
    Return result
  End Function

  Private Function GetCredentials() As ICredentials
    Return New NetworkCredential(Me.Username, Me.Password)
  End Function

  Public Function Upload(ByVal fi As FileInfo, ByVal targetFilename As String) As Boolean
    Dim target As String
    If targetFilename.Trim() = "" Then
      target = Me.CurrentDirectory + fi.Name
    ElseIf targetFilename.Contains("/") Then
      target = Me.AdjustDir(targetFilename)
    Else
      target = Me.CurrentDirectory + targetFilename
    End If
    Dim URI As String = Me.Hostname + target
    Dim ftp As FtpWebRequest = Me.GetRequest(URI)
    ftp.Method = "STOR"
    ftp.UseBinary = True
    ftp.ContentLength = fi.Length
    Dim content As Byte() = New Byte(2047) {}
    Using fs As FileStream = fi.OpenRead()
      Try
        Try
          Using rs As Stream = ftp.GetRequestStream()
            Dim dataRead As Integer
            Do
              dataRead = fs.Read(content, 0, &H800)
              rs.Write(content, 0, dataRead)
            Loop While dataRead >= &H800
            rs.Close()
          End Using
        Catch generatedExceptionName As Exception

        End Try
      Finally
        fs.Close()
      End Try
    End Using
    ftp = Nothing
    Return True
  End Function

  Public Function Upload(ByVal localFilename As String, ByVal targetFilename As String) As Boolean
    If Not System.IO.File.Exists(localFilename) Then
      Throw New ApplicationException("File " & localFilename & " not found")
    End If
    Dim fi As New FileInfo(localFilename)
    Return Me.Upload(fi, targetFilename)
  End Function

End Class
