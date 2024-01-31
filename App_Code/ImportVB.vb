Imports Microsoft.VisualBasic
Imports System
Imports System.ComponentModel
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Configuration.ConfigurationManager
Imports WindowsFormsApplication2

Public Class ImportVB

    Private Const CLARK_COUNTY_CODE As String = "C"
    Private Const DQ_ROW_LENGTH As Integer = &HF00
    Private Const LA_COUNTY_CODE As String = "LA"
    Private Const LA_EAST_CODE As String = "6"
    Private Const LA_NORTH_CODE As String = "4"
    Private Const LA_SOUTH_CODE As String = "5"
    Private Const LA_WEST_CODE As String = "7"
    Private mNumberOfRows As Long = 0L
    Private mProcessedRows As Long = 0L
    Private Const NOD_PREFIX As String = "DF"
    Private Const NOD_TEMPLATE As String = "DF.DBF"
    Private Const NTS_PREFIX As String = "TS"
    Private Const NTS_TEMPLATE As String = "TS.DBF"
    Private sCountyToRun As String = ""

    Public Sub New()

    End Sub

    Public Function CreateDBFNTS(ByVal strPath As String, ByVal dDate As DateTime, ByVal mainFolder As String, ByVal county As Integer) As String
        'EmptyFolder(New DirectoryInfo(strPath))
        'Dim dsCounties As New DataSet()
        'dsCounties.ReadXml(mainFolder & "DBF\CRRCounties.xml", XmlReadMode.InferSchema)
        Dim archivo As String = ""
        Using clase As New DataClassesDataContext
            Dim objCounty = (From c In clase.Counties Where (c.IdCounty = county Or county = 0) Select c).ToList 'c.CRRCode <> "LA" And 
            For i As Integer = 0 To objCounty.Count - 1
                'File.Copy(mainFolder & "DBF\DF.DBF", ((strPath & "\") & objCounty(i).FilePrefix & "DF") & dDate.ToString("MMdd") & ".DBF")
                If File.Exists(strPath & "\" & objCounty(i).FilePrefix & "TS" & dDate.ToString("MMdd") & ".DBF") Then
                    BackFile(strPath, objCounty(i).FilePrefix & "TS" & dDate.ToString("MMdd") & ".DBF")
                End If
                File.Copy(mainFolder & "DBF\TS.DBF", strPath & "\" & objCounty(i).FilePrefix & "TS" & dDate.ToString("MMdd") & ".DBF")
                archivo = objCounty(i).FilePrefix & "TS" & dDate.ToString("MMdd") & ".DBF"
            Next
        End Using
        Return archivo
        'For Each dr As DataRow In dsCounties.Tables(1).Rows
        '  If dr("CRRCode").ToString() <> "LA" Then
        '    File.Copy(mainFolder & "DBF\DF.DBF", ((strPath & "\") + dr("FilePrefix").ToString() & "DF") + dDate.ToString("MMdd") & ".DBF")
        '    File.Copy(mainFolder & "DBF\TS.DBF", ((strPath & "\") + dr("FilePrefix").ToString() & "TS") + dDate.ToString("MMdd") & ".DBF")
        '  End If
        'Next
    End Function

    Public Function CreateDBFNOD(ByVal strPath As String, ByVal dDate As DateTime, ByVal mainFolder As String, ByVal county As Integer) As String
        'EmptyFolder(New DirectoryInfo(strPath))
        'Dim dsCounties As New DataSet()
        'dsCounties.ReadXml(mainFolder & "DBF\CRRCounties.xml", XmlReadMode.InferSchema)
        Dim archivo As String = ""
        Using clase As New DataClassesDataContext
            Dim objCounty = (From c In clase.Counties Where (c.IdCounty = county Or county = 0) Select c).ToList 'c.CRRCode <> "LA" And 
            For i As Integer = 0 To objCounty.Count - 1
                If File.Exists(strPath & "\" & objCounty(i).FilePrefix & "DF" & dDate.ToString("MMdd") & ".DBF") Then
                    BackFile(strPath, objCounty(i).FilePrefix & "DF" & dDate.ToString("MMdd") & ".DBF")
                End If
                File.Copy(mainFolder & "DBF\DF.DBF", strPath & "\" & objCounty(i).FilePrefix & "DF" & dDate.ToString("MMdd") & ".DBF")
                archivo = objCounty(i).FilePrefix & "DF" & dDate.ToString("MMdd") & ".DBF"
                'File.Copy(mainFolder & "DBF\TS.DBF", ((strPath & "\") & objCounty(i).FilePrefix & "TS") & dDate.ToString("MMdd") & ".DBF")
            Next
        End Using
        Return archivo
        'For Each dr As DataRow In dsCounties.Tables(1).Rows
        '  If dr("CRRCode").ToString() <> "LA" Then
        '    File.Copy(mainFolder & "DBF\DF.DBF", ((strPath & "\") + dr("FilePrefix").ToString() & "DF") + dDate.ToString("MMdd") & ".DBF")
        '    File.Copy(mainFolder & "DBF\TS.DBF", ((strPath & "\") + dr("FilePrefix").ToString() & "TS") + dDate.ToString("MMdd") & ".DBF")
        '  End If
        'Next
    End Function

    Public Sub EmptyFolder(ByVal directoryInfo As DirectoryInfo)
        For Each file As FileInfo In directoryInfo.GetFiles()
            file.Delete()
        Next
        For Each subfolder As DirectoryInfo In directoryInfo.GetDirectories()
            EmptyFolder(subfolder)
        Next
    End Sub

    Public Sub BackFile(ByVal directorio As String, ByVal archivo As String)
        If Not Directory.Exists(directorio & "\" & Now.Year) Then Directory.CreateDirectory(directorio & "\" & Now.Year)
        If File.Exists(directorio & "\" & archivo) Then
            If File.Exists(directorio & "\" & Now.Year & "\" & archivo) Then File.Delete(directorio & "\" & Now.Year & "\" & archivo)
            File.Copy(directorio & "\" & archivo, directorio & "\" & Now.Year & "\" & archivo)
            Try
                File.Delete(directorio & "\" & archivo)
            Catch ex As Exception


            End Try
        End If
    End Sub

    'Public Function GetLAZone(ByVal sCity As String, ByVal mainFolder As String) As String
    '  Dim dsCities As New DataSet()
    '  dsCities.ReadXml("LACities.xml", XmlReadMode.InferSchema)
    '  Dim drCounty As DataRow() = dsCities.Tables(0).[Select](String.Format("CityName='{0}'", sCity.ToUpper()))
    '  If drCounty.Length > 0 Then
    '    Return drCounty(0)("CountyCode").ToString()
    '  End If
    '  Return ""
    'End Function

    Public Function GetNODFileName(ByVal iCounty As Integer, ByVal dDate As DateTime, ByVal mainFolder3 As String) As String
        Using clase As New DataClassesDataContext
            Dim cCounty = (From c In clase.Counties Where c.IdCounty = iCounty Select c.FilePrefix).ToList(0)
            Return cCounty & "DF" & dDate.ToString("MMdd") & ".DBF"
        End Using
        'Dim dsCounties As New DataSet()
        'dsCounties.ReadXml(mainFolder & "DBF\CRRCounties.xml", XmlReadMode.InferSchema)
        'Return ((dsCounties.Tables(1).[Select](String.Format("CRRCode='{0}'", sCounty))(0)("FilePrefix").ToString() & "DF") + dDate.ToString("MMdd") & ".DBF")
    End Function

    Public Function GetNTSFileName(ByVal iCounty As Integer, ByVal dDate As DateTime, ByVal mainFolder3 As String) As String
        Using clase As New DataClassesDataContext
            Dim cCounty = (From c In clase.Counties Where c.IdCounty = iCounty Select c.FilePrefix).ToList(0)
            Return cCounty & "TS" & dDate.ToString("MMdd") & ".DBF"
        End Using
        'Dim dsCounties As New DataSet()
        'dsCounties.ReadXml(mainFolder & "DBF\CRRCounties.xml", XmlReadMode.InferSchema)
        'Return ((dsCounties.Tables(1).[Select](String.Format("CRRCode='{0}'", sCounty))(0)("FilePrefix").ToString() & "TS") + dDate.ToString("MMdd") & ".DBF")
    End Function

    Public Function ParseDate(ByVal sDate As Date) As Object
        Try
            'Return sDate.ToString("MM/dd/yyyy")
            If sDate = New Date(1900, 1, 1) Then
                Return Nothing
            Else
                Return sDate.ToString("MM/dd/yyyy")
            End If
        Catch
            Return Nothing
        End Try
    End Function

    Public Function ParseDate8(ByVal sDate As Date) As Object
        Try
            'Return sDate.ToString("MM/dd/yyyy")
            If sDate = New Date(1900, 1, 1) Then
                Return Nothing
            Else
                Return sDate.ToString("MM/dd/yy")
            End If
        Catch
            Return Nothing
        End Try
    End Function

    Public Function ParseInt(ByVal sInt As String) As Object
        Try
            Return System.Convert.ToInt32(System.Math.Floor(Double.Parse(sInt)))
        Catch
            Return 0
        End Try
    End Function

    Public Function ParseIntEmpty(ByVal sInt As String) As Object
        Try
            Return System.Convert.ToInt32(System.Math.Floor(Double.Parse(sInt)))
        Catch
            Return ""
        End Try
    End Function

    Public Function ParsePhone(ByVal sPhone As String) As Object
        Try
            sPhone = Replace(sPhone, " ", "")
            sPhone = Replace(sPhone, "-", "")
            sPhone = Replace(sPhone, "(", "")
            sPhone = Replace(sPhone, ")", "")
            sPhone = Replace(sPhone, "/", "")
            sPhone = Replace(sPhone, "*", "")
            sPhone = Replace(sPhone, "+", "")
            Return Double.Parse(sPhone).ToString("### ###-####")
        Catch
            Return Nothing
        End Try
    End Function

    Public Shared Function StripNonNumeric(ByVal Value As String) As String
        Return Regex.Replace(Value, "\D", "")
    End Function

    Public ReadOnly Property dPercent() As Double
        Get
            If Me.mNumberOfRows <> 0L Then
                Return CDbl((Me.mProcessedRows / Me.mNumberOfRows))
            End If
            Return 0.0R
        End Get
    End Property

    Public Function ProcessNod(ByVal sPath As String, ByVal dDate As DateTime, ByVal mainFolder As String, ByVal objNod As List(Of NOD), ByVal county As String) As Boolean

        Dim sSQL As String
        Dim cmd As New OleDbCommand()
        Dim sqlcmd As New SqlCommand
        Dim cn As New OleDbConnection
        CreateDBFNOD(AppSettings("OutputPath").Replace("[SYSTEM]", "NOD"), dDate, mainFolder, county)
        'CreateDBFs(AppSettings("ErrorOutputPath").ToString(), dDate, mainFolder)
        'CreateDBFs(AppSettings("DuplicatesOutputPath").ToString(), dDate, mainFolder)
        Dim x As Integer = 0
        Dim q As WindowsFormsApplication2.Insert
        Dim i As Integer
        Dim IdError As Integer

        cn.ConnectionString = AppSettings("DBFConnection").Replace("[SYSTEM]", "NOD")
        cn.Open()
        cmd.Connection = cn

        For i = 0 To objNod.Count - 1
            Try
                With objNod(i)
                    IdError = .IdNod
                    q = New Insert("")
                    If Not .ADDRESS Is Nothing Then q.Add("ADDRESS", .ADDRESS) Else q.Add("ADDRESS", Nothing)
                    If Not .ST_CITYSTATE Is Nothing Then q.Add("CITY", .ST_CITYSTATE) Else q.Add("CITY", Nothing)
                    If Not .ZIP Is Nothing Then q.Add("ZIP", .ZIP) Else q.Add("ZIP", Nothing)
                    If Not .TG Is Nothing Then q.Add("TG", .TG) Else q.Add("TG", Nothing)
                    If Not .HOEX Is Nothing Then q.Add("HOEX", .HOEX) Else q.Add("HOEX", Nothing)
                    If Not .TRUSTOR Is Nothing Then q.Add("TRUSTOR", .TRUSTOR) Else q.Add("TRUSTOR", Nothing)
                    If Not .OWNER Is Nothing Then q.Add("OWNER", .OWNER) Else q.Add("OWNER", Nothing)
                    If Not .BENEFRY Is Nothing Then q.Add("BENEFRY", .BENEFRY) Else q.Add("BENEFRY", Nothing)
                    If Not .B_PHONE Is Nothing Then q.Add("B_PHONE", ParsePhone(.B_PHONE)) Else q.Add("B_PHONE", Nothing)
                    If Not .TAX_VALUE Is Nothing Then q.Add("TAX_VALUE", ParseInt(.TAX_VALUE)) Else q.Add("TAX_VALUE", Nothing)
                    If Not .TX_YR Is Nothing Then q.Add("TX_YR", ParseInt(.TX_YR)) Else q.Add("TX_YR", Nothing)
                    If Not .PRCHS_DATE Is Nothing Then q.Add("PRCHS_DATE", ParseDate(.PRCHS_DATE)) Else q.Add("PRCHS_DATE", Nothing)
                    If Not .AMOUNT Is Nothing Then q.Add("AMOUNT", ParseInt(.AMOUNT)) Else q.Add("AMOUNT", Nothing)
                    If Not .TD1_A Is Nothing Then q.Add("TD1_A", .TD1_A) Else q.Add("TD1_A", Nothing)
                    If Not .TD1 Is Nothing Then q.Add("TD1", ParseIntEmpty(.TD1)) Else q.Add("TD1", Nothing)
                    If Not .TD1_D Is Nothing Then q.Add("TD1_D", ParseDate(.TD1_D)) Else q.Add("TD1_D", Nothing)
                    If Not .TD2_A Is Nothing Then q.Add("TD2_A", .TD2_A) Else q.Add("TD2_A", Nothing)
                    If Not .TD2 Is Nothing Then q.Add("TD2", ParseIntEmpty(.TD2)) Else q.Add("TD2", Nothing)
                    If Not .TD2_D Is Nothing Then q.Add("TD2_D", ParseDate(.TD2_D)) Else q.Add("TD2_D", Nothing)
                    If Not .TD3_A Is Nothing Then q.Add("TD3_A", .TD3_A) Else q.Add("TD3_A", Nothing)
                    If Not .TD3 Is Nothing Then q.Add("TD3", ParseIntEmpty(.TD3)) Else q.Add("TD3", Nothing)
                    If Not .TD3_D Is Nothing Then q.Add("TD3_D", ParseDate(.TD3_D)) Else q.Add("TD3_D", Nothing)
                    If Not .TD4_A Is Nothing Then q.Add("TD4_A", .TD4_A) Else q.Add("TD4_A", Nothing)
                    If Not .TD4 Is Nothing Then q.Add("TD4", ParseIntEmpty(.TD4)) Else q.Add("TD4", Nothing)
                    If Not .TD4_D Is Nothing Then q.Add("TD4_D", ParseDate(.TD4_D)) Else q.Add("TD4_D", Nothing)
                    If Not .TD5_A Is Nothing Then q.Add("TD5_A", .TD5_A) Else q.Add("TD5_A", Nothing)
                    If Not .TD5 Is Nothing Then q.Add("TD5", ParseIntEmpty(.TD5)) Else q.Add("TD5", Nothing)
                    If Not .TD5_D Is Nothing Then q.Add("TD5_D", ParseDate(.TD5_D)) Else q.Add("TD5_D", Nothing)
                    If Not .TD6_A Is Nothing Then q.Add("TD6_A", .TD6_A) Else q.Add("TD6_A", Nothing)
                    If Not .TD6 Is Nothing Then q.Add("TD6", ParseIntEmpty(.TD6)) Else q.Add("TD6", Nothing)
                    If Not .TD6_D Is Nothing Then q.Add("TD6_D", ParseDate(.TD6_D)) Else q.Add("TD6_D", Nothing)
                    If Not .USE Is Nothing Then q.Add("USE", .USE) Else q.Add("USE", Nothing)
                    If Not .YRBLT Is Nothing Then q.Add("YRBLT", .YRBLT) Else q.Add("YRBLT", Nothing)
                    If Not .SQFT Is Nothing Then q.Add("SQFT", .SQFT) Else q.Add("SQFT", Nothing)
                    If Not .STORY Is Nothing Then q.Add("STORY", .STORY) Else q.Add("STORY", Nothing)
                    If Not .ROOMS Is Nothing Then q.Add("ROOMS", .ROOMS) Else q.Add("ROOMS", Nothing)
                    If Not .LOT Is Nothing Then q.Add("LOT", .LOT) Else q.Add("LOT", Nothing)
                    If Not .LEGAL Is Nothing Then q.Add("LEGAL", .LEGAL) Else q.Add("LEGAL", Nothing)
                    If Not .NOD Is Nothing Then q.Add("NOD", .NOD) Else q.Add("NOD", Nothing)
                    If Not .LOAN Is Nothing Then q.Add("LOAN", .LOAN) Else q.Add("LOAN", Nothing)
                    If Not .TDID Is Nothing Then q.Add("TDID", .TDID) Else q.Add("TDID", Nothing)
                    If Not .REMARKS Is Nothing Then q.Add("REMARKS", .REMARKS) Else q.Add("REMARKS", Nothing)
                    If Not .COUNTY Is Nothing Then q.Add("COUNTY", .COUNTY) Else q.Add("COUNTY", Nothing)
                    'If Not .L_DATE Is Nothing Then q.Add("L_DATE", ParseDate(.L_DATE)) Else q.Add("L_DATE", Nothing)
                    q.Add("L_DATE", ParseDate(dDate))
                    If Not .ASOF Is Nothing Then q.Add("ASOF", .ASOF) Else q.Add("ASOF", Nothing)
                    If Not .DELNIQ Is Nothing Then q.Add("DELNIQ", ParseDate(.DELNIQ)) Else q.Add("DELNIQ", Nothing)
                    If Not .ASSPAR Is Nothing Then q.Add("ASSPAR", .ASSPAR) Else q.Add("ASSPAR", Nothing)
                    'new fields
                    If Not .SA_PROPERTY_ID Is Nothing Then q.Add("SA_PROP_ID", .SA_PROPERTY_ID) Else q.Add("SA_PROP_ID", Nothing)
                    If Not .SR_UNIQUE_ID Is Nothing Then q.Add("SR_UNIQ_ID", .SR_UNIQUE_ID) Else q.Add("SR_UNIQ_ID", Nothing)
                    If Not .OWNER1 Is Nothing Then q.Add("OWNER1", .OWNER1) Else q.Add("OWNER1", Nothing)
                    If Not .OWNER2 Is Nothing Then q.Add("OWNER2", .OWNER2) Else q.Add("OWNER2", Nothing)
                    If Not .TRUSTOR_FIRST_NAME Is Nothing Then q.Add("TR_F_NAME", .TRUSTOR_FIRST_NAME) Else q.Add("TR_F_NAME", Nothing)
                    If Not .TRUSTOR_LAST_NAME Is Nothing Then q.Add("TR_L_NAME", .TRUSTOR_LAST_NAME) Else q.Add("TR_L_NAME", Nothing)
                    If Not .BATHROOMS Is Nothing Then q.Add("BATHROOMS", .BATHROOMS) Else q.Add("BATHROOMS", Nothing)
                    If Not .BEDROOMS Is Nothing Then q.Add("BEDROOMS", .BEDROOMS) Else q.Add("BEDROOMS", Nothing)
                    If Not .TRUSTEE_ADDRESS Is Nothing Then q.Add("TRE_ADRS", .TRUSTEE_ADDRESS) Else q.Add("TRE_ADRS", Nothing)
                    If Not .TRUSTEE_ZIP Is Nothing Then q.Add("TRE_ZIP", .TRUSTEE_ZIP) Else q.Add("TRE_ZIP", Nothing)
                    If Not .BENE_ADDRESS Is Nothing Then q.Add("BENE_ADRS", .BENE_ADDRESS) Else q.Add("BENE_ADRS", Nothing)
                    If Not .BENE_CITY Is Nothing Then q.Add("BENE_CITY", .BENE_CITY) Else q.Add("BENE_CITY", Nothing)
                    If Not .ESTIMATED_PROP_VALUE Is Nothing Then q.Add("EST_PR_VAL", .ESTIMATED_PROP_VALUE) Else q.Add("EST_PR_VAL", Nothing)
                    If Not .PROP_TAX_STATUS_1 Is Nothing Then q.Add("PR_TAX_ST1", .PROP_TAX_STATUS_1) Else q.Add("PR_TAX_ST1", Nothing)
                    If Not .PROP_TAX_STATUS_3 Is Nothing Then q.Add("PR_TAX_ST3", .PROP_TAX_STATUS_3) Else q.Add("PR_TAX_ST3", Nothing)
                    If Not .NBRROOMS Is Nothing Then q.Add("NBRROOMS", .NBRROOMS) Else q.Add("NBRROOMS", Nothing)
                    If Not .ST_HS_NBR Is Nothing Then q.Add("ST_HS_NBR", .ST_HS_NBR) Else q.Add("ST_HS_NBR", Nothing)
                    If Not .ST_FRACT Is Nothing Then q.Add("ST_FRACT", .ST_FRACT) Else q.Add("ST_FRACT", Nothing)
                    If Not .ST_DIR Is Nothing Then q.Add("ST_DIR", .ST_DIR) Else q.Add("ST_DIR", Nothing)
                    If Not .ST_STRT Is Nothing Then q.Add("ST_STRT", .ST_STRT) Else q.Add("ST_STRT", Nothing)
                    If Not .ST_SUF Is Nothing Then q.Add("ST_SUF", .ST_SUF) Else q.Add("ST_SUF", Nothing)
                    If Not .ST_POSTD Is Nothing Then q.Add("ST_POSTD", .ST_POSTD) Else q.Add("ST_POSTD", Nothing)
                    If Not .ST_UNTPR Is Nothing Then q.Add("ST_UNTPR", .ST_UNTPR) Else q.Add("ST_UNTPR", Nothing)
                    If Not .ST_UNTVL Is Nothing Then q.Add("ST_UNTVL", .ST_UNTVL) Else q.Add("ST_UNTVL", Nothing)
                    If Not .ML_HS_NBR Is Nothing Then q.Add("ML_HS_NBR", .ML_HS_NBR) Else q.Add("ML_HS_NBR", Nothing)
                    If Not .ML_FRACT Is Nothing Then q.Add("ML_FRACT", .ML_FRACT) Else q.Add("ML_FRACT", Nothing)
                    If Not .ML_DIR Is Nothing Then q.Add("ML_DIR", .ML_DIR) Else q.Add("ML_DIR", Nothing)
                    If Not .ML_STRT Is Nothing Then q.Add("ML_STRT", .ML_STRT) Else q.Add("ML_STRT", Nothing)
                    If Not .ML_SUF Is Nothing Then q.Add("ML_SUF", .ML_SUF) Else q.Add("ML_SUF", Nothing)
                    If Not .ML_POSTD Is Nothing Then q.Add("ML_POSTD", .ML_POSTD) Else q.Add("ML_POSTD", Nothing)
                    If Not .ML_UNTPR Is Nothing Then q.Add("ML_UNTPR", .ML_UNTPR) Else q.Add("ML_UNTPR", Nothing)
                    If Not .ML_UNTVL Is Nothing Then q.Add("ML_UNTVL", .ML_UNTVL) Else q.Add("ML_UNTVL", Nothing)
                    If Not .ML_CITY Is Nothing Then q.Add("ML_CITY", .ML_CITY) Else q.Add("ML_CITY", Nothing)
                    If Not .ML_STATE Is Nothing Then q.Add("ML_STATE", .ML_STATE) Else q.Add("ML_STATE", Nothing)
                    If Not .ML_ZIP Is Nothing Then q.Add("ML_ZIP", .ML_ZIP) Else q.Add("ML_ZIP", Nothing)
                    If Not .ML_ZIPPLUS4 Is Nothing Then q.Add("ML_PLUS4", .ML_ZIPPLUS4) Else q.Add("ML_PLUS4", Nothing)
                    If Not .TRUSTEE_CITY Is Nothing Then q.Add("TRE_CITY", .TRUSTEE_CITY) Else q.Add("TRE_CITY", Nothing)
                    If Not .ST_CITYSTATE Is Nothing Then q.Add("ST_CITY", .ST_CITYSTATE) Else q.Add("ST_CITY", Nothing)
                    If Not .ADDRESS_ID_STATE Is Nothing Then q.Add("ST_STATE", .ADDRESS_ID_STATE) Else q.Add("ST_STATE", Nothing)
                    'If Not .UNITS Is Nothing Then q.Add("UNQIDNOT", .SA_PROPERTY_ID) Else q.Add("UNQIDNOT", Nothing)
                    If Not .BENE_ADDRESS_ID_STATE Is Nothing Then q.Add("BENE_STATE", .BENE_ADDRESS_ID_STATE) Else q.Add("BENE_STATE", Nothing)
                    If Not .BENE_ZIP Is Nothing Then q.Add("BENE_ZIP", .BENE_ZIP) Else q.Add("BENE_ZIP", Nothing)
                    If Not .SA_OWNR_SC Is Nothing Then q.Add("SA_OWNR_SC", .SA_OWNR_SC) Else q.Add("SA_OWNR_SC", Nothing)
                    If Not .SA_POL_COD Is Nothing Then q.Add("SA_POL_COD", .SA_POL_COD) Else q.Add("SA_POL_COD", Nothing)
                    'If Not .SA_POL_SQF Is Nothing Then q.Add("SA_POL_SQF", .SA_POL_SQF) Else q.Add("SA_POL_SQF", Nothing)
                    If Not .SA_VW_CODE Is Nothing Then q.Add("SA_VW_CODE", .SA_VW_CODE) Else q.Add("SA_VW_CODE", Nothing)
                    If Not .NOD_REC_DT Is Nothing Then q.Add("NOD_REC_DT", ParseDate8(.NOD_REC_DT)) Else q.Add("NOD_REC_DT", Nothing)
                    If Not .NTS_REC_DT Is Nothing Then q.Add("NTS_REC_DT", ParseDate8(.NTS_REC_DT)) Else q.Add("NTS_REC_DT", Nothing)
                    If Not .TRUSTEE_ADDRESS_ID_STATE Is Nothing Then q.Add("TRE_STATE", .TRUSTEE_ADDRESS_ID_STATE) Else q.Add("TRE_STATE", Nothing)
                    If Not .UNITS Is Nothing Then q.Add("UNITS", .UNITS) Else q.Add("UNITS", Nothing)
                    If Not .PROP_TAX_STATUS_2 Is Nothing Then q.Add("PR_TAX_ST2", .PROP_TAX_STATUS_2) Else q.Add("PR_TAX_ST2", Nothing)
                    Dim ML_ADDR As String = ""
                    If Not .ML_HS_NBR Is Nothing Then ML_ADDR &= .ML_HS_NBR & " "
                    If Not .ML_FRACT Is Nothing Then ML_ADDR &= .ML_FRACT & " "
                    If Not .ML_DIR Is Nothing Then ML_ADDR &= .ML_DIR & " "
                    If Not .ML_STRT Is Nothing Then ML_ADDR &= .ML_STRT & " "
                    If Not .ML_SUF Is Nothing Then ML_ADDR &= .ML_SUF & " "
                    If Not .ML_POSTD Is Nothing Then ML_ADDR &= .ML_POSTD & " "
                    If Not .ML_UNTPR Is Nothing Then ML_ADDR &= .ML_UNTPR & " "
                    If Not .ML_UNTVL Is Nothing Then ML_ADDR &= .ML_UNTVL '& " "
                    'If Not .ML_CITY Is Nothing Then ML_ADDR &= .ML_CITY & " "
                    'If Not .ML_STATE Is Nothing Then ML_ADDR &= .ML_STATE
                    Dim ML_PLUS4 As String = ""
                    If Not .ML_ZIP Is Nothing Then ML_PLUS4 &= .ML_ZIP & " "
                    If Not .ML_ZIPPLUS4 Is Nothing Then ML_PLUS4 &= .ML_ZIPPLUS4

                    q.Add("ML_ADDR", ML_ADDR)
                    q.Add("ML_ZIP_TTL", ML_PLUS4)
                    'If Not .m Is Nothing Then q.Add("ML_ADDR", .SA_PROPERTY_ID) Else q.Add("ML_ADDR", Nothing)
                    'If Not .m Is Nothing Then q.Add("ML_ZIP_TTL", .SA_PROPERTY_ID) Else q.Add("ML_ZIP_TTL", Nothing)
                    If Not .TR_PHONE Is Nothing Then q.Add("TR_PHONE", ParsePhone(.TR_PHONE)) Else q.Add("TR_PHONE", Nothing)

                    If Not .FD_TRUSTEE_SALE_NBR Is Nothing Then q.Add("TS_NBR", .FD_TRUSTEE_SALE_NBR) Else q.Add("TS_NBR", Nothing)

                    If Not .SA_ZONING Is Nothing Then q.Add("SA_ZONING", .SA_ZONING) Else q.Add("SA_ZONING", Nothing)
                    If Not .SA_VAL_TRANSFER Is Nothing Then q.Add("SA_VAL_TRA", .SA_VAL_TRANSFER) Else q.Add("SA_VAL_TRA", Nothing)

                    Dim sTableName As String 'sCountyCode,
                    Dim iCounty As Integer
                    'sCountyCode = .COUNTY
                    If county = "1" Then
                        iCounty = 1
                    Else
                        iCounty = .IdCounty
                    End If
                    If iCounty <> 0 Then
                        x += 1
                        sTableName = GetNODFileName(iCounty, dDate, mainFolder)
                        q.ChangeTable(sTableName)
                        q.DateFormat = "MM/dd/yy"
                        sSQL = q.ToString()
                        cmd.CommandText = sSQL
                        cmd.ExecuteNonQuery()
                    Else
                        x += 1
                        iCounty = 4 '"4"
                        sTableName = GetNODFileName(iCounty, dDate, mainFolder)
                        q.ChangeTable(sTableName)
                        q.Remove("COUNTY")
                        If Not .ADDRESS Is Nothing Then q.Add("COUNTY", iCounty)
                        q.DateFormat = "MM/dd/yy"
                        sSQL = q.ToString()
                        cmd.CommandText = sSQL
                        cmd.ExecuteNonQuery()
                        iCounty = 5 '"5"
                        sTableName = GetNODFileName(iCounty, dDate, mainFolder)
                        q.ChangeTable(sTableName)
                        q.Remove("COUNTY")
                        If Not .ADDRESS Is Nothing Then q.Add("COUNTY", iCounty)
                        q.DateFormat = "MM/dd/yy"
                        sSQL = q.ToString()
                        cmd.CommandText = sSQL
                        cmd.ExecuteNonQuery()
                        iCounty = 3 '"6"
                        sTableName = GetNODFileName(iCounty, dDate, mainFolder)
                        q.ChangeTable(sTableName)
                        q.Remove("COUNTY")
                        If Not .ADDRESS Is Nothing Then q.Add("COUNTY", iCounty)
                        q.DateFormat = "MM/dd/yy"
                        sSQL = q.ToString()
                        cmd.CommandText = sSQL
                        cmd.ExecuteNonQuery()
                        iCounty = 6 '"7"
                        sTableName = GetNODFileName(iCounty, dDate, mainFolder)
                        q.ChangeTable(sTableName)
                        q.Remove("COUNTY")
                        If Not .ADDRESS Is Nothing Then q.Add("COUNTY", iCounty)
                        q.DateFormat = "MM/dd/yy"
                        sSQL = q.ToString()
                        cmd.CommandText = sSQL
                        cmd.ExecuteNonQuery()
                    End If
                End With
                Using clase As New DataClassesDataContext
                    Dim objN = (From c In clase.NODs Where c.IdNod = objNod(i).IdNod Select c).Single
                    objN.IdStatusDBF = 5
                    objN.IdStatus = 10
                    objN.DateDBF = dDate
                    objN.Locked = 0
                    clase.SubmitChanges()
                End Using
            Catch ex As Exception
                LogRec(mainFolder, IdError & " - " & ex.Message)
                LogRec(mainFolder, IdError & " - " & q.ToString())
            End Try

        Next
        cn.Close()
    End Function

    Public Function ProcessNts(ByVal sPath As String, ByVal dDate As DateTime, ByVal mainFolder As String, ByVal objNts As List(Of NT), ByVal county As String) As Boolean
        Dim sSQL As String
        Dim cmd As New OleDbCommand()
        Dim sqlcmd As New SqlCommand
        Dim cn As New OleDbConnection
        CreateDBFNTS(AppSettings("OutputPath").Replace("[SYSTEM]", "NTS"), dDate, mainFolder, county)
        'CreateDBFs(AppSettings("ErrorOutputPath").ToString(), dDate, mainFolder)
        'CreateDBFs(AppSettings("DuplicatesOutputPath").ToString(), dDate, mainFolder)
        Dim x As Integer = 0
        Dim q As WindowsFormsApplication2.Insert
        Dim i As Integer
        Dim IdError As Integer

        cn.ConnectionString = AppSettings("DBFConnection").Replace("[SYSTEM]", "NTS")
        cn.Open()
        cmd.Connection = cn

        For i = 0 To objNts.Count - 1
            Try
                With objNts(i)
                    IdError = .IdNts
                    q = New Insert("")
                    If Not .T_S_NO Is Nothing Then q.Add("T_S_NO", .T_S_NO) Else q.Add("T_S_NO", Nothing)
                    If Not .ADDRESS Is Nothing Then q.Add("ADDRESS", .ADDRESS) Else q.Add("ADDRESS", Nothing)
                    If Not .ST_CITYSTATE Is Nothing Then q.Add("CITY", .ST_CITYSTATE) Else q.Add("CITY", Nothing)
                    If Not .ZIP Is Nothing Then q.Add("ZIP", .ZIP) Else q.Add("ZIP", Nothing)
                    If Not .TG Is Nothing Then q.Add("TG", .TG) Else q.Add("TG", Nothing)
                    If Not .HOEX Is Nothing Then q.Add("HOEX", .HOEX) Else q.Add("HOEX", Nothing)
                    If Not .TRUSTOR Is Nothing Then q.Add("TRUSTOR", .TRUSTOR) Else q.Add("TRUSTOR", Nothing)
                    If Not .OWNER Is Nothing Then q.Add("OWNER", .OWNER) Else q.Add("OWNER", Nothing)
                    If Not .TRUSTEE Is Nothing Then q.Add("TRUSTEE", .TRUSTEE) Else q.Add("TRUSTEE", Nothing)
                    If Not .T_PHONE Is Nothing Then q.Add("T_PHONE", ParsePhone(.T_PHONE)) Else q.Add("T_PHONE", Nothing)
                    If Not .BENEFRY Is Nothing Then q.Add("BENEFRY", .BENEFRY) Else q.Add("BENEFRY", Nothing)
                    If Not .B_PHONE Is Nothing Then q.Add("B_PHONE", ParsePhone(.B_PHONE)) Else q.Add("B_PHONE", Nothing)
                    If Not .SALE_DATE Is Nothing Then q.Add("SALE_DATE", ParseDate(.SALE_DATE)) Else q.Add("SALE_DATE", Nothing)
                    If Not .SALE_TIME Is Nothing Then q.Add("SALE_TIME", .SALE_TIME) Else q.Add("SALE_TIME", Nothing)
                    If Not .SITE Is Nothing Then q.Add("SITE", .SITE) Else q.Add("SITE", Nothing)
                    If Not .TAX_VALUE Is Nothing Then q.Add("TAX_VALUE", ParseInt(.TAX_VALUE)) Else q.Add("TAX_VALUE", Nothing)
                    If Not .TX_YR Is Nothing Then q.Add("TX_YR", ParseInt(.TX_YR)) Else q.Add("TX_YR", Nothing)
                    If Not .PRCHS_DATE Is Nothing Then q.Add("PRCHS_DATE", ParseDate(.PRCHS_DATE)) Else q.Add("PRCHS_DATE", Nothing)
                    If Not .AMOUNT Is Nothing Then q.Add("AMOUNT", ParseInt(.AMOUNT)) Else q.Add("AMOUNT", Nothing)
                    If Not .TD1_A Is Nothing Then q.Add("TD1_A", .TD1_A) Else q.Add("TD1_A", Nothing)
                    If Not .TD1 Is Nothing Then q.Add("TD1", ParseIntEmpty(.TD1)) Else q.Add("TD1", Nothing)
                    If Not .TD1_D Is Nothing Then q.Add("TD1_D", ParseDate(.TD1_D)) Else q.Add("TD1_D", Nothing)
                    If Not .TD2_A Is Nothing Then q.Add("TD2_A", .TD2_A) Else q.Add("TD2_A", Nothing)
                    If Not .TD2 Is Nothing Then q.Add("TD2", ParseIntEmpty(.TD2)) Else q.Add("TD2", Nothing)
                    If Not .TD2_D Is Nothing Then q.Add("TD2_D", ParseDate(.TD2_D)) Else q.Add("TD2_D", Nothing)
                    If Not .TD3_A Is Nothing Then q.Add("TD3_A", .TD3_A) Else q.Add("TD3_A", Nothing)
                    If Not .TD3 Is Nothing Then q.Add("TD3", ParseIntEmpty(.TD3)) Else q.Add("TD3", Nothing)
                    If Not .TD3_D Is Nothing Then q.Add("TD3_D", ParseDate(.TD3_D)) Else q.Add("TD3_D", Nothing)
                    If Not .TD4_A Is Nothing Then q.Add("TD4_A", .TD4_A) Else q.Add("TD4_A", Nothing)
                    If Not .TD4 Is Nothing Then q.Add("TD4", ParseIntEmpty(.TD4)) Else q.Add("TD4", Nothing)
                    If Not .TD4_D Is Nothing Then q.Add("TD4_D", ParseDate(.TD4_D)) Else q.Add("TD4_D", Nothing)
                    If Not .TD5_A Is Nothing Then q.Add("TD5_A", .TD5_A) Else q.Add("TD5_A", Nothing)
                    If Not .TD5 Is Nothing Then q.Add("TD5", ParseIntEmpty(.TD5)) Else q.Add("TD5", Nothing)
                    If Not .TD5_D Is Nothing Then q.Add("TD5_D", ParseDate(.TD5_D)) Else q.Add("TD5_D", Nothing)
                    If Not .TD6_A Is Nothing Then q.Add("TD6_A", .TD6_A) Else q.Add("TD6_A", Nothing)
                    If Not .TD6 Is Nothing Then q.Add("TD6", ParseIntEmpty(.TD6)) Else q.Add("TD6", Nothing)
                    If Not .TD6_D Is Nothing Then q.Add("TD6_D", ParseDate(.TD6_D)) Else q.Add("TD6_D", Nothing)
                    If Not .USE Is Nothing Then q.Add("USE", .USE) Else q.Add("USE", Nothing)
                    If Not .YRBLT Is Nothing Then q.Add("YRBLT", .YRBLT) Else q.Add("YRBLT", Nothing)
                    If Not .SQFT Is Nothing Then q.Add("SQFT", .SQFT) Else q.Add("SQFT", Nothing)
                    If Not .STORY Is Nothing Then q.Add("STORY", .STORY) Else q.Add("STORY", Nothing)
                    If Not .ROOMS Is Nothing Then q.Add("ROOMS", .ROOMS.Substring(0, If((.ROOMS.Length > 8), 8, .ROOMS.Length))) Else q.Add("ROOMS", Nothing)
                    If Not .LOT Is Nothing Then q.Add("LOT", .LOT.Substring(0, If((.LOT.Length > 7), 7, .LOT.Length))) Else q.Add("LOT", Nothing)
                    If Not .LEGAL Is Nothing Then q.Add("LEGAL", .LEGAL.Substring(0, If((.LEGAL.Length > &H33), &H33, .LEGAL.Length))) Else q.Add("LEGAL", Nothing)
                    If Not .NOD Is Nothing Then q.Add("NOD", .NOD.Substring(0, If((.NOD.Length > 10), 10, .NOD.Length))) Else q.Add("NOD", Nothing)
                    If Not .LOAN Is Nothing Then q.Add("LOAN", .LOAN.Substring(0, If((.LOAN.Length > 20), 20, .LOAN.Length))) Else q.Add("LOAN", Nothing)
                    If Not .NTS Is Nothing Then q.Add("NTS", .NTS.Substring(0, If((.NTS.Length > 14), 14, .NTS.Length))) Else q.Add("NTS", Nothing)
                    If Not .TDID Is Nothing Then q.Add("TDID", .TDID) Else q.Add("TDID", Nothing)
                    If Not .REMARKS Is Nothing Then q.Add("REMARKS", .REMARKS) Else q.Add("REMARKS", Nothing)
                    If Not .COUNTY Is Nothing Then q.Add("COUNTY", .COUNTY) Else q.Add("COUNTY", Nothing)
                    'If Not .L_DATE Is Nothing Then q.Add("L_DATE", ParseDate(.L_DATE)) Else q.Add("L_DATE", Nothing)
                    q.Add("L_DATE", ParseDate(dDate))
                    If Not .ASSPAR Is Nothing Then q.Add("ASSPAR", .ASSPAR) Else q.Add("ASSPAR", Nothing)
                    'new fields
                    If Not .SA_PROPERTY_ID Is Nothing Then q.Add("SA_PROP_ID", .SA_PROPERTY_ID) Else q.Add("SA_PROP_ID", Nothing)
                    If Not .SR_UNIQUE_ID Is Nothing Then q.Add("SR_UNIQ_ID", .SR_UNIQUE_ID) Else q.Add("SR_UNIQ_ID", Nothing)
                    If Not .OWNER1 Is Nothing Then q.Add("OWNER1", .OWNER1) Else q.Add("OWNER1", Nothing)
                    If Not .OWNER2 Is Nothing Then q.Add("OWNER2", .OWNER2) Else q.Add("OWNER2", Nothing)
                    If Not .TRUSTOR_FIRST_NAME Is Nothing Then q.Add("TR_F_NAME", .TRUSTOR_FIRST_NAME) Else q.Add("TR_F_NAME", Nothing)
                    If Not .TRUSTOR_LAST_NAME Is Nothing Then q.Add("TR_L_NAME", .TRUSTOR_LAST_NAME) Else q.Add("TR_L_NAME", Nothing)
                    If Not .BATHROOMS Is Nothing Then q.Add("BATHROOMS", .BATHROOMS) Else q.Add("BATHROOMS", Nothing)
                    If Not .BEDROOMS Is Nothing Then q.Add("BEDROOMS", .BEDROOMS) Else q.Add("BEDROOMS", Nothing)
                    If Not .TRUSTEE_ADDRESS Is Nothing Then q.Add("TRE_ADRS", .TRUSTEE_ADDRESS) Else q.Add("TRE_ADRS", Nothing)
                    If Not .TRUSTEE_ZIP Is Nothing Then q.Add("TRE_ZIP", .TRUSTEE_ZIP) Else q.Add("TRE_ZIP", Nothing)
                    If Not .BENE_ADDRESS Is Nothing Then q.Add("BENE_ADRS", .BENE_ADDRESS) Else q.Add("BENE_ADRS", Nothing)
                    If Not .BENE_CITY Is Nothing Then q.Add("BENE_CITY", .BENE_CITY) Else q.Add("BENE_CITY", Nothing)
                    If Not .ESTIMATED_PROP_VALUE Is Nothing Then q.Add("EST_PR_VAL", .ESTIMATED_PROP_VALUE) Else q.Add("EST_PR_VAL", Nothing)
                    If Not .PROP_TAX_STATUS_1 Is Nothing Then q.Add("PR_TAX_ST1", .PROP_TAX_STATUS_1) Else q.Add("PR_TAX_ST1", Nothing)
                    If Not .PROP_TAX_STATUS_3 Is Nothing Then q.Add("PR_TAX_ST3", .PROP_TAX_STATUS_3) Else q.Add("PR_TAX_ST3", Nothing)
                    If Not .NBRROOMS Is Nothing Then q.Add("NBRROOMS", .NBRROOMS) Else q.Add("NBRROOMS", Nothing)
                    If Not .ST_HS_NBR Is Nothing Then q.Add("ST_HS_NBR", .ST_HS_NBR) Else q.Add("ST_HS_NBR", Nothing)
                    If Not .ST_FRACT Is Nothing Then q.Add("ST_FRACT", .ST_FRACT) Else q.Add("ST_FRACT", Nothing)
                    If Not .ST_DIR Is Nothing Then q.Add("ST_DIR", .ST_DIR) Else q.Add("ST_DIR", Nothing)
                    If Not .ST_STRT Is Nothing Then q.Add("ST_STRT", .ST_STRT) Else q.Add("ST_STRT", Nothing)
                    If Not .ST_SUF Is Nothing Then q.Add("ST_SUF", .ST_SUF) Else q.Add("ST_SUF", Nothing)
                    If Not .ST_POSTD Is Nothing Then q.Add("ST_POSTD", .ST_POSTD) Else q.Add("ST_POSTD", Nothing)
                    If Not .ST_UNTPR Is Nothing Then q.Add("ST_UNTPR", .ST_UNTPR) Else q.Add("ST_UNTPR", Nothing)
                    If Not .ST_UNTVL Is Nothing Then q.Add("ST_UNTVL", .ST_UNTVL) Else q.Add("ST_UNTVL", Nothing)
                    If Not .ML_HS_NBR Is Nothing Then q.Add("ML_HS_NBR", .ML_HS_NBR) Else q.Add("ML_HS_NBR", Nothing)
                    If Not .ML_FRACT Is Nothing Then q.Add("ML_FRACT", .ML_FRACT) Else q.Add("ML_FRACT", Nothing)
                    If Not .ML_DIR Is Nothing Then q.Add("ML_DIR", .ML_DIR) Else q.Add("ML_DIR", Nothing)
                    If Not .ML_STRT Is Nothing Then q.Add("ML_STRT", .ML_STRT) Else q.Add("ML_STRT", Nothing)
                    If Not .ML_SUF Is Nothing Then q.Add("ML_SUF", .ML_SUF) Else q.Add("ML_SUF", Nothing)
                    If Not .ML_POSTD Is Nothing Then q.Add("ML_POSTD", .ML_POSTD) Else q.Add("ML_POSTD", Nothing)
                    If Not .ML_UNTPR Is Nothing Then q.Add("ML_UNTPR", .ML_UNTPR) Else q.Add("ML_UNTPR", Nothing)
                    If Not .ML_UNTVL Is Nothing Then q.Add("ML_UNTVL", .ML_UNTVL) Else q.Add("ML_UNTVL", Nothing)
                    If Not .ML_CITY Is Nothing Then q.Add("ML_CITY", .ML_CITY) Else q.Add("ML_CITY", Nothing)
                    If Not .ML_STATE Is Nothing Then q.Add("ML_STATE", .ML_STATE) Else q.Add("ML_STATE", Nothing)
                    If Not .ML_ZIP Is Nothing Then q.Add("ML_ZIP", .ML_ZIP) Else q.Add("ML_ZIP", Nothing)
                    If Not .ML_ZIPPLUS4 Is Nothing Then q.Add("ML_PLUS4", .ML_ZIPPLUS4) Else q.Add("ML_PLUS4", Nothing)
                    If Not .TRUSTEE_CITY Is Nothing Then q.Add("TRE_CITY", .TRUSTEE_CITY) Else q.Add("TRE_CITY", Nothing)
                    If Not .ST_CITYSTATE Is Nothing Then q.Add("ST_CITY", .ST_CITYSTATE) Else q.Add("ST_CITY", Nothing)
                    If Not .ADDRESS_ID_STATE Is Nothing Then q.Add("ST_STATE", .ADDRESS_ID_STATE) Else q.Add("ST_STATE", Nothing)
                    'If Not .UNITS Is Nothing Then q.Add("UNQIDNOT", .SA_PROPERTY_ID) Else q.Add("UNQIDNOT", Nothing)
                    If Not .BENE_ADDRESS_ID_STATE Is Nothing Then q.Add("BENE_STATE", .BENE_ADDRESS_ID_STATE) Else q.Add("BENE_STATE", Nothing)
                    If Not .BENE_ZIP Is Nothing Then q.Add("BENE_ZIP", .BENE_ZIP) Else q.Add("BENE_ZIP", Nothing)
                    If Not .SA_OWNR_SC Is Nothing Then q.Add("SA_OWNR_SC", .SA_OWNR_SC) Else q.Add("SA_OWNR_SC", Nothing)
                    If Not .SA_POL_COD Is Nothing Then q.Add("SA_POL_COD", .SA_POL_COD) Else q.Add("SA_POL_COD", Nothing)
                    If Not .SA_POL_SQF Is Nothing Then q.Add("SA_POL_SQF", .SA_POL_SQF) Else q.Add("SA_POL_SQF", Nothing)
                    If Not .SA_VW_CODE Is Nothing Then q.Add("SA_VW_CODE", .SA_VW_CODE) Else q.Add("SA_VW_CODE", Nothing)
                    If Not .NOD_REC_DT Is Nothing Then q.Add("NOD_REC_DT", ParseDate8(.NOD_REC_DT)) Else q.Add("NOD_REC_DT", Nothing)
                    If Not .NTS_REC_DT Is Nothing Then q.Add("NTS_REC_DT", ParseDate8(.NTS_REC_DT)) Else q.Add("NTS_REC_DT", Nothing)
                    If Not .TRUSTEE_ADDRESS_ID_STATE Is Nothing Then q.Add("TRE_STATE", .TRUSTEE_ADDRESS_ID_STATE) Else q.Add("TRE_STATE", Nothing)
                    If Not .UNITS Is Nothing Then q.Add("UNITS", .UNITS) Else q.Add("UNITS", Nothing)
                    If Not .PROP_TAX_STATUS_2 Is Nothing Then q.Add("PR_TAX_ST2", .PROP_TAX_STATUS_2) Else q.Add("PR_TAX_ST2", Nothing)
                    Dim ML_ADDR As String = ""
                    If Not .ML_HS_NBR Is Nothing Then ML_ADDR &= .ML_HS_NBR & " "
                    If Not .ML_FRACT Is Nothing Then ML_ADDR &= .ML_FRACT & " "
                    If Not .ML_DIR Is Nothing Then ML_ADDR &= .ML_DIR & " "
                    If Not .ML_STRT Is Nothing Then ML_ADDR &= .ML_STRT & " "
                    If Not .ML_SUF Is Nothing Then ML_ADDR &= .ML_SUF & " "
                    If Not .ML_POSTD Is Nothing Then ML_ADDR &= .ML_POSTD & " "
                    If Not .ML_UNTPR Is Nothing Then ML_ADDR &= .ML_UNTPR & " "
                    If Not .ML_UNTVL Is Nothing Then ML_ADDR &= .ML_UNTVL '& " "
                    'If Not .ML_CITY Is Nothing Then ML_ADDR &= .ML_CITY & " "
                    'If Not .ML_STATE Is Nothing Then ML_ADDR &= .ML_STATE
                    Dim ML_PLUS4 As String = ""
                    If Not .ML_ZIP Is Nothing Then ML_PLUS4 &= .ML_ZIP & " "
                    If Not .ML_ZIPPLUS4 Is Nothing Then ML_PLUS4 &= .ML_ZIPPLUS4

                    q.Add("ML_ADDR", ML_ADDR)
                    q.Add("ML_ZIP_TTL", ML_PLUS4)
                    'If Not .m Is Nothing Then q.Add("ML_ADDR", .SA_PROPERTY_ID) Else q.Add("ML_ADDR", Nothing)
                    'If Not .m Is Nothing Then q.Add("ML_ZIP_TTL", .SA_PROPERTY_ID) Else q.Add("ML_ZIP_TTL", Nothing)
                    If Not .TR_PHONE Is Nothing Then q.Add("TR_PHONE", ParsePhone(.TR_PHONE)) Else q.Add("TR_PHONE", Nothing)

                    If Not .SA_ZONING Is Nothing Then q.Add("SA_ZONING", .SA_ZONING) Else q.Add("SA_ZONING", Nothing)
                    If Not .SA_VAL_TRANSFER Is Nothing Then q.Add("SA_VAL_TRA", .SA_VAL_TRANSFER) Else q.Add("SA_VAL_TRA", Nothing)

                    Dim sTableName As String ' sCountyCode, 
                    Dim iCounty As Integer
                    'sCountyCode = .COUNTY
                    If county = "1" Then
                        iCounty = 1
                    Else
                        iCounty = .IdCounty
                    End If
                    If iCounty <> 0 Then
                        x += 1
                        sTableName = GetNTSFileName(iCounty, dDate, mainFolder)
                        q.ChangeTable(sTableName)
                        q.DateFormat = "MM/dd/yy"
                        sSQL = q.ToString()
                        cmd.CommandText = sSQL
                        cmd.ExecuteNonQuery()
                    Else
                        x += 1
                        iCounty = 4 '"4"
                        sTableName = GetNTSFileName(iCounty, dDate, mainFolder)
                        q.ChangeTable(sTableName)
                        q.Remove("COUNTY")
                        q.Add("COUNTY", iCounty)
                        q.DateFormat = "MM/dd/yy"
                        sSQL = q.ToString()
                        cmd.CommandText = sSQL
                        cmd.ExecuteNonQuery()
                        iCounty = 5 '"5"
                        sTableName = GetNTSFileName(iCounty, dDate, mainFolder)
                        q.ChangeTable(sTableName)
                        q.Remove("COUNTY")
                        q.Add("COUNTY", iCounty)
                        q.DateFormat = "MM/dd/yy"
                        sSQL = q.ToString()
                        cmd.CommandText = sSQL
                        cmd.ExecuteNonQuery()
                        iCounty = 3 '"6"
                        sTableName = GetNTSFileName(iCounty, dDate, mainFolder)
                        q.ChangeTable(sTableName)
                        q.Remove("COUNTY")
                        q.Add("COUNTY", iCounty)
                        q.DateFormat = "MM/dd/yy"
                        sSQL = q.ToString()
                        cmd.CommandText = sSQL
                        cmd.ExecuteNonQuery()
                        iCounty = 6 '"7"
                        sTableName = GetNTSFileName(iCounty, dDate, mainFolder)
                        q.ChangeTable(sTableName)
                        q.Remove("COUNTY")
                        q.Add("COUNTY", iCounty)
                        q.DateFormat = "MM/dd/yy"
                        sSQL = q.ToString()
                        cmd.CommandText = sSQL
                        cmd.ExecuteNonQuery()
                    End If
                End With
                Using clase As New DataClassesDataContext
                    Dim objN = (From c In clase.NTs Where c.IdNts = objNts(i).IdNts Select c).Single
                    objN.IdStatusDBF = 5
                    objN.IdStatus = 10
                    objN.DateDBF = dDate
                    objN.Locked = 0
                    clase.SubmitChanges()
                End Using
            Catch ex As Exception
                LogRec(mainFolder, IdError & " - " & ex.Message)
                LogRec(mainFolder, IdError & " - " & q.ToString())
            End Try
        Next

    End Function
End Class
