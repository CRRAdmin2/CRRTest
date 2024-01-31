Imports System.IO
Imports System.Configuration.ConfigurationManager
'Imports Renci.SshNet
Imports WinSCP

Partial Class FtpUpload
    Inherits System.Web.UI.Page

    'Public ReadOnly Property UpdatePanelMaster() As UpdatePanel
    '  Get
    '    Return Master.FindControl("UpdatePanel1")
    '  End Get
    'End Property

    Protected Sub btnUploadNOD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUploadNOD.Click
        Try
            Dim bolSubio As Boolean = False
            Dim directorio As String = AppSettings("OutputPath").Replace("[SYSTEM]", "NOD")
            Dim ArchivoName As String
            Dim sNewFile As String

            Dim sessionOptions As New SessionOptions
            With sessionOptions
                .Protocol = Protocol.Sftp
                .HostName = AppSettings("FTPUploadHost")
                .UserName = AppSettings("FTPUploadUser")
                .Password = AppSettings("FTPUploadPassword")
                .GiveUpSecurityAndAcceptAnySshHostKey = True
            End With

            Using session As New Session
                ' Connect
                session.Open(sessionOptions)

                ' Upload files
                Dim transferOptions As New TransferOptions
                transferOptions.TransferMode = TransferMode.Binary

                For Each item As ListItem In listBoxNOD.Items
                    If item.Selected Then
                        ArchivoName = item.Text
                        Dim transferResult As TransferOperationResult
                        transferResult = session.PutFiles(directorio & "\" & ArchivoName, AppSettings("FtpNODFolder"), False, transferOptions)
                        ' Throw on any error
                        transferResult.Check()
                        sNewFile = RenameFile(directorio, item.Text)
                        item.Text = sNewFile '"up" & ArchivoName
                        bolSubio = True
                    End If
                Next
            End Using

            'ftpC.Disconnect()
            If bolSubio Then
                Alert.ShowInUpdatePanel("The selected DBF files were uploaded")
            Else
                Alert.ShowInUpdatePanel("Please select a DBF file to upload")
            End If
        Catch ex As Exception
            lblMsg.Text = ex.Message & " - " & ex.StackTrace
            'Alert.ShowInUpdatePanel(ex.Message & " - " & ex.StackTrace)
            'Alert.ShowInUpdatePanel("There was an error... the FTP did not work")
        End Try
    End Sub

    Protected Sub btnUploadNTS_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUploadNTS.Click
        Try
            Dim bolSubio As Boolean = False
            Dim ftpC As New Renci.SshNet.ScpClient(AppSettings("FTPUploadHost"), AppSettings("FTPUploadUser"), AppSettings("FTPUploadPassword"))
            Dim directorio As String = AppSettings("OutputPath").Replace("[SYSTEM]", "NTS")
            Dim ArchivoName As String
            Dim sNewFile As String

            Dim sessionOptions As New SessionOptions
            With sessionOptions
                .Protocol = Protocol.Sftp
                .HostName = AppSettings("FTPUploadHost")
                .UserName = AppSettings("FTPUploadUser")
                .Password = AppSettings("FTPUploadPassword")
                .GiveUpSecurityAndAcceptAnySshHostKey = True
            End With

            Using session As New Session
                ' Connect
                session.Open(sessionOptions)

                ' Upload files
                Dim transferOptions As New TransferOptions
                transferOptions.TransferMode = TransferMode.Binary
                For Each item As ListItem In listBoxNTS.Items
                    If item.Selected Then
                        ArchivoName = item.Text
                        Dim transferResult As TransferOperationResult
                        transferResult = session.PutFiles(directorio & "\" & ArchivoName, AppSettings("FtpNTSFolder"), False, transferOptions)
                        ' Throw on any error
                        transferResult.Check()
                        sNewFile = RenameFile(directorio, item.Text)
                        item.Text = sNewFile '"up" & ArchivoName
                        bolSubio = True
                    End If
                Next
            End Using
            If bolSubio Then
                Alert.ShowInUpdatePanel("The selected DBF files were uploaded")
            Else
                Alert.ShowInUpdatePanel("Please select a DBF file to upload")
            End If
        Catch ex As Exception
            lblMsg.Text = ex.Message & " - " & ex.StackTrace
            Alert.ShowInUpdatePanel("There was an error... the FTP did not work")
        End Try
    End Sub

    Private Function RenameFile(ByVal directorio As String, ByVal archivo As String) As String
        Dim TheFile As New FileInfo(directorio & "\" & archivo)
        Dim sNewFile As String = archivo
        If TheFile.Exists Then

            Dim sPointExt As Integer = archivo.LastIndexOf(".")
            sNewFile = archivo.Substring(0, sPointExt) & "-up." & archivo.Substring(sPointExt + 1, archivo.Length - sPointExt - 1)

            'File.Move(directorio & "\" & archivo, directorio & "\up" & archivo)
            File.Move(directorio & "\" & archivo, directorio & "\" & sNewFile)
        End If
        Return sNewFile
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            dcDate.Fecha = Now
            LoadFiles()
        End If
    End Sub

    Private Sub LoadFiles()
        ' nod
        Dim dir As String
        'Dim fil As FileInfo

        listBoxNOD.Items.Clear()
        dir = AppSettings("OutputPath").Replace("[SYSTEM]", "NOD")
        For Each archivo As String In Directory.GetFiles(AppSettings("OutputPath").Replace("[SYSTEM]", "NOD"))
            If Not dcDate.EsValido Then
                listBoxNOD.Items.Add(System.IO.Path.GetFileName(archivo))
            Else
                If System.IO.File.GetLastWriteTime(archivo).Year = dcDate.Fecha.Year Then
                    If archivo.IndexOf(dcDate.Fecha.ToString("MMdd")) >= 0 Then
                        listBoxNOD.Items.Add(System.IO.Path.GetFileName(archivo))
                    End If
                End If
            End If
        Next

        listBoxNTS.Items.Clear()
        dir = AppSettings("OutputPath").Replace("[SYSTEM]", "NTS")
        For Each archivo As String In Directory.GetFiles(AppSettings("OutputPath").Replace("[SYSTEM]", "NTS"))
            If Not dcDate.EsValido Then
                listBoxNTS.Items.Add(System.IO.Path.GetFileName(archivo))
            Else
                If System.IO.File.GetLastWriteTime(archivo).Year = dcDate.Fecha.Year Then
                    If archivo.IndexOf(dcDate.Fecha.ToString("MMdd")) >= 0 Then
                        listBoxNTS.Items.Add(System.IO.Path.GetFileName(archivo))
                    End If
                End If
            End If
        Next
    End Sub

    Protected Sub btnRefresh_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        LoadFiles()
    End Sub
End Class
