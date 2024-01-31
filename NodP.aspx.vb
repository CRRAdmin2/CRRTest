Imports Infragistics.WebUI.UltraWebGrid
Imports Infragistics.WebUI.WebDataInput
Imports System.Configuration.ConfigurationManager
Imports System.IO
Imports WinSCP
Imports System.Linq
Imports System.Collections.Generic


Partial Class NodP
	Inherits System.Web.UI.Page
	'Public ReadOnly Property UpdatePanelMaster() As UpdatePanel
	'  Get
	'    Return Master.FindControl("UpdatePanel1")
	'  End Get
	'End Property

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		Try
			If Not IsPostBack Then
				chklstStates.DataBind()
				ddlCounty.DataBind()
				ddlStatus.DataBind()

				If Request.Cookies("PageSizeNod") Is Nothing Then
					Response.Cookies("PageSizeNod").Value = 20
				ElseIf Not IsNumeric(Request.Cookies("PageSizeNod")) Then
					Response.Cookies("PageSizeNod").Value = 20
				End If
				txtPageSize.Text = Request.Cookies("PageSizeNod").Value
				If Not dcFrom.EsValido Then dcFrom.Fecha = Now
				If Not dcTo.EsValido Then dcTo.Fecha = Now

				Paging(CInt(Request.Cookies("PageSizeNod").Value))
				DateControlCreateDBF.Fecha = Now
				PonerColumnas()
			End If
			If Request("flag") = "YES" Then
				Paging(CInt(Request.Cookies("PageSizeNod").Value))
			End If
		Catch ex As Exception
			LogRec(AppSettings("MainFolder"), ex.Message)
		End Try

	End Sub

	Protected Sub GridView1_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowCreated
		If e.Row.RowType = DataControlRowType.DataRow And e.Row.RowIndex <> GridView1.EditIndex Then
			e.Row.Attributes("onmouseover") = "this.style.cursor='hand';this.style.textDecoration='underline';this.className='menuGridSobre';"
			e.Row.Attributes("onmouseout") = "this.style.textDecoration='none';this.className='" & IIf(e.Row.RowIndex Mod 2 = 0, "", "gridAlternado") & "';"
		End If
	End Sub

	Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
		If e.Row.RowType = DataControlRowType.DataRow Then
			e.Row.Attributes("onclick") = "javascript:NodEd(" & DataBinder.Eval(e.Row.DataItem, "IdNod") & ")" 'Page.ClientScript.GetPostBackClientHyperlink(GridView1, "Select$" + e.Row.RowIndex.ToString)
			Using clase As New DataClassesDataContext

				If Not DataBinder.Eval(e.Row.DataItem, "IdCounty") Is Nothing Then
					Dim objCounts = (From c In clase.Counties Where c.IdCounty = CInt(DataBinder.Eval(e.Row.DataItem, "IdCounty")) Select c).ToList
					If objCounts.Count > 0 Then
						Dim lblCounty As Label = e.Row.FindControl("lblCounty")
						lblCounty.Text = objCounts(0).CountyName
					End If
				End If
			End Using

			If DataBinder.Eval(e.Row.DataItem, "PRCHS_DATE") = New Date(1900, 1, 1) Then e.Row.Cells(GetColumnIndexByHeaderText(GridView1, "PRCHS_DATE")).Text = ""
			If DataBinder.Eval(e.Row.DataItem, "TD1_D") = New Date(1900, 1, 1) Then e.Row.Cells(GetColumnIndexByHeaderText(GridView1, "TD1_D")).Text = ""
			If DataBinder.Eval(e.Row.DataItem, "TD2_D") = New Date(1900, 1, 1) Then e.Row.Cells(GetColumnIndexByHeaderText(GridView1, "TD2_D")).Text = ""
			If DataBinder.Eval(e.Row.DataItem, "TD3_D") = New Date(1900, 1, 1) Then e.Row.Cells(GetColumnIndexByHeaderText(GridView1, "TD3_D")).Text = ""
			If DataBinder.Eval(e.Row.DataItem, "TD4_D") = New Date(1900, 1, 1) Then e.Row.Cells(GetColumnIndexByHeaderText(GridView1, "TD4_D")).Text = ""
			If DataBinder.Eval(e.Row.DataItem, "TD5_D") = New Date(1900, 1, 1) Then e.Row.Cells(GetColumnIndexByHeaderText(GridView1, "TD5_D")).Text = ""
			If DataBinder.Eval(e.Row.DataItem, "TD6_D") = New Date(1900, 1, 1) Then e.Row.Cells(GetColumnIndexByHeaderText(GridView1, "TD6_D")).Text = ""
			If DataBinder.Eval(e.Row.DataItem, "L_DATE") = New Date(1900, 1, 1) Then e.Row.Cells(GetColumnIndexByHeaderText(GridView1, "L_DATE")).Text = ""
			If DataBinder.Eval(e.Row.DataItem, "ASOF") = New Date(1900, 1, 1) Then e.Row.Cells(GetColumnIndexByHeaderText(GridView1, "ASOF")).Text = ""
			If DataBinder.Eval(e.Row.DataItem, "DELNIQ") = New Date(1900, 1, 1) Then e.Row.Cells(GetColumnIndexByHeaderText(GridView1, "DELNIQ")).Text = ""
			If DataBinder.Eval(e.Row.DataItem, "SALE_DATE") = New Date(1900, 1, 1) Then e.Row.Cells(GetColumnIndexByHeaderText(GridView1, "SALE_DATE")).Text = ""
			If DataBinder.Eval(e.Row.DataItem, "DateDBF") = New Date(1900, 1, 1) Then e.Row.Cells(GetColumnIndexByHeaderText(GridView1, "DateDBF")).Text = ""

		End If
	End Sub

	Private pageIndex As Integer

	Protected Sub chkColumns_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkColumns.PreRender
		If Not IsPostBack Then

		End If
	End Sub

	Private Sub PonerColumnas()
		If Request.Cookies("ColumnsNod") Is Nothing Then Response.Cookies("ColumnsNod").Value = ""
		'Dim col As gridv Object ' GridViewc
		For i As Integer = 1 To GridView1.Columns.Count - 1	'For Each col As UltraGridColumn In UltraWebGrid1.Columns
			'col = GridView1.Columns(i)
			chkColumns.Items.Add(New ListItem(GridView1.Columns(i).HeaderText, GridView1.Columns(i).HeaderText))
			If Request.Cookies("ColumnsNod").Value.Length >= chkColumns.Items.Count Then
				chkColumns.Items(chkColumns.Items.Count - 1).Selected = IIf(Request.Cookies("ColumnsNod").Value.Substring(chkColumns.Items.Count - 1, 1) = 0, False, True)
				'UltraWebGrid1.Columns.FromKey(chkColumns.Items(chkColumns.Items.Count - 1).Value).Hidden = Not chkColumns.Items(chkColumns.Items.Count - 1).Selected
				GridView1.Columns(i).Visible = chkColumns.Items(chkColumns.Items.Count - 1).Selected
			Else
				chkColumns.Items(chkColumns.Items.Count - 1).Selected = True
			End If
		Next
	End Sub

	Protected Sub btnColumns_Click(ByVal sender As Object, ByVal e As System.EventArgs)	'Handles btnColumns.Click
		Dim strSelected As String = ""
		For Each item As ListItem In chkColumns.Items
			'UltraWebGrid1.Columns.FromKey(item.Value).Hidden = Not item.Selected
			GridView1.Columns(GetColumnIndexByHeaderText(GridView1, item.Text)).Visible = item.Selected	'chkColumns.Items(chkColumns.Items.Count - 1).Selected
			strSelected &= IIf(item.Selected, 1, 0)
		Next
		Response.Cookies("ColumnsNod").Value = strSelected
		Response.Cookies("ColumnsNod").Expires = Now.AddYears(100)
	End Sub

	'Protected Sub chkSelectAll_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkSelectAll.CheckedChanged
	'  For Each item As ListItem In chkColumns.Items
	'    item.Selected = chkSelectAll.Checked
	'  Next
	'  btnColumns_Click(Nothing, Nothing)
	'End Sub

	Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
		Dim intPageSize As Integer = 20
		If IsNumeric(txtPageSize.Text) Then If CInt(txtPageSize.Text) > 0 Then intPageSize = CInt(txtPageSize.Text)
		Paging(intPageSize)
	End Sub

	Private Sub Paging(ByVal intPageSize As Integer)
		If intPageSize < 1 Then intPageSize = 20
		GridView1.PageSize = intPageSize
		GridBind()
		Response.Cookies("PageSizeNod").Value = intPageSize
		Response.Cookies("PageSizeNod").Expires = Now.AddYears(100)
	End Sub

	Private Sub GridBind()
		GridView1.DataBind()
	End Sub

	Protected Sub ddlCounty_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCounty.DataBound
		ddlCounty.Items.Insert(0, New ListItem("- Select -", "0"))
	End Sub

	Protected Sub ddlCounties_DataBound(ByVal sender As Object, ByVal e As System.EventArgs)
		Dim ddl As DropDownList = sender
		ddl.Items.Insert(0, New ListItem("- No County -", "0"))
	End Sub

	Protected Sub ddlStatus_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlStatus.DataBound
		ddlStatus.Items.Insert(0, New ListItem("- Select -", "0"))
	End Sub

	Protected Sub btnSaveChanges_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSaveChanges.Click
		'Session("txtAddress") = txtAddress.Text.Trim
		'Session("txtCity") = txtCity.Text.Trim
		'Session("txtAmount") = txtAmount.Text.Trim
		'Session("txtTrusterOwnerBenefry") = txtTrusterOwnerBenefry.Text.Trim
		'Session("ddlStatus") = ddlStatus.SelectedValue
		'Session("ddlCounty") = ddlCounty.SelectedValue
		'Session("dcFrom") = dcFrom.Fecha
		'Session("dcTo") = dcTo.Fecha.AddDays(1).AddSeconds(-1)
		'      Session("txtASSPAR") = txtASSPAR.Text.Trim
		SetSessionValues()
		Dim obj = SelectData()
		Using clase As New DataClassesDataContext
			For i As Integer = 0 To obj.Count - 1
				Dim objN = (From c In clase.NODs Where c.IdNod = obj(i).IdNod Select c).Single
				objN.IdStatus = 12
				clase.SubmitChanges()
			Next
		End Using
		GridBind()
	End Sub

	Public Function PutMask(ByVal obj As Object) As String
		If Not obj Is Nothing Then
			Return obj.ToString().Replace(" ", "").Replace("-", "")
		End If
	End Function

	Protected Sub btnCreateDBF_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCreateDBF.Click
		If Session("ddlCounty") <> "0" Then
			'Session("txtAddress") = txtAddress.Text.Trim
			'Session("txtCity") = txtCity.Text.Trim
			'Session("txtAmount") = txtAmount.Text.Trim
			'Session("txtTrusterOwnerBenefry") = txtTrusterOwnerBenefry.Text.Trim
			'Session("ddlStatus") = ddlStatus.SelectedValue
			'Session("ddlCounty") = ddlCounty.SelectedValue
			'Session("dcFrom") = dcFrom.Fecha
			'Session("dcTo") = dcTo.Fecha.AddDays(1).AddSeconds(-1)
			'Session("txtASSPAR") = txtASSPAR.Text.Trim
			SetSessionValues()
			Dim pp As New ImportVB
			Dim obj = SelectData()
			pp.ProcessNod(AppSettings("OutputPath").Replace("[SYSTEM]", "NOD"), DateControlCreateDBF.Fecha, AppSettings("MainFolder"), obj, ddlCounty.SelectedValue)
			'Page.ClientScript.RegisterStartupScript(Me.GetType, "CREATEDBF", "alert('The DBF files were created successfully');", True)
			Alert.ShowInUpdatePanel("The DBF files were created in \n\n  " & AppSettings("OutputPath").Replace("[SYSTEM]", "NTS").Replace("\", "\\"))
			GridBind()
		Else
			'Page.ClientScript.RegisterStartupScript(Me.GetType, "countySelect", "alert('The County should be selected and searched');", True)
			Alert.ShowInUpdatePanel("The County should be selected and searched")
		End If
	End Sub

	'Protected Sub lblCount_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblCount.PreRender
	'	Session("txtAddress") = txtAddress.Text.Trim
	'	Session("txtCity") = txtCity.Text.Trim
	'	Session("txtAmount") = txtAmount.Text.Trim
	'	Session("txtTrusterOwnerBenefry") = txtTrusterOwnerBenefry.Text.Trim
	'	Session("ddlStatus") = ddlStatus.SelectedValue
	'	Session("ddlCounty") = ddlCounty.SelectedValue
	'	Session("dcFrom") = dcFrom.Fecha
	'	Session("dcTo") = dcTo.Fecha.AddDays(1).AddSeconds(-1)
	'	Session("txtASSPAR") = txtASSPAR.Text.Trim
	'	Using clase As New DataClassesDataContext
	'		Dim objCount = (From c In clase.NODs Where (c.ADDRESS.Contains(Session("txtAddress").ToString) Or c.ADDRESS Is Nothing) _
	'					 And (c.ST_CITYSTATE.Contains(Session("txtCity").ToString) Or c.ST_CITYSTATE Is Nothing) _
	'					 And (c.AMOUNT.Contains(Session("txtAmount").ToString) Or c.AMOUNT Is Nothing) _
	'					 And (c.ASSPAR.Contains(Session("txtASSPAR").ToString) Or c.ASSPAR Is Nothing) _
	'					 And (c.OWNER.Contains(Session("txtTrusterOwnerBenefry").ToString) Or c.BENEFRY.Contains(Session("txtTrusterOwnerBenefry").ToString) Or c.TRUSTOR.Contains(Session("txtTrusterOwnerBenefry").ToString) Or c.TRUSTEE.Contains(Session("txtTrusterOwnerBenefry").ToString)) _
	'					 And (c.IdCounty = CInt(IIf(Session("ddlCounty") = 1, "3", Session("ddlCounty"))) Or _
	'								c.IdCounty = CInt(IIf(Session("ddlCounty") = 1, "4", Session("ddlCounty"))) Or _
	'								c.IdCounty = CInt(IIf(Session("ddlCounty") = 1, "5", Session("ddlCounty"))) Or _
	'								c.IdCounty = CInt(IIf(Session("ddlCounty") = 1, "6", Session("ddlCounty"))) Or CInt(Session("ddlCounty")) = 0) _
	'					 And (c.IdStatus = CInt(Session("ddlStatus")) Or CInt(Session("ddlStatus")) = 0 Or (CInt(Session("ddlStatus")) = 11 And (c.IdStatus = 1 Or c.IdStatus = 3))) _
	'					 And (c.Locked = 0) _
	'					 And (c.Created >= CDate(Session("dcFrom"))) _
	'					 And (c.Created <= CDate(Session("dcTo"))) _
	'										Select c).Count
	'		lblCount.Text = objCount
	'	End Using
	'End Sub

	Protected Sub btnShowHideCols_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnShowHideCols.Click
		'If btnShowHideCols.Text = "Show Columns" Then
		'  panelChk.Visible = True
		'  btnShowHideCols.Text = "Hide columns"
		'Else
		'  panelChk.Visible = False
		'  btnShowHideCols.Text = "Show Columns"
		'End If
		btnColumns_Click(Nothing, Nothing)

	End Sub

	Protected Sub txtPageSize_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPageSize.TextChanged
		btnSubmit_Click(Nothing, Nothing)
	End Sub

	Protected Sub btnCreateDBFnFTP_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCreateDBFnFTP.Click
		If Session("ddlCounty") <> "0" Then
			btnCreateDBF_Click(Nothing, Nothing)
			UploadNODFTP()
		Else
			'Page.ClientScript.RegisterStartupScript(Me.GetType, "countySelect", "alert('The County should be selected and searched');", True)
			Alert.ShowInUpdatePanel("The County should be selected and searched")
		End If
	End Sub

	Protected Sub UploadNODFTP()
		Dim lista As New ListBox
		lista.SelectionMode = ListSelectionMode.Multiple
		Using clase As New DataClassesDataContext
			Dim cc = (From c In clase.Counties Where c.IdCounty = CInt(Session("ddlCounty")) Select c.FilePrefix).ToList(0)
			Dim lsi As New ListItem(System.IO.Path.GetFileName(cc & "DF" & DateControlCreateDBF.Fecha.ToString("MMdd") & ".DBF"))
			lsi.Selected = True
			lista.Items.Add(lsi)
		End Using
		Try
			Dim bolSubio As Boolean = False
			Dim ftpC As New FTPClient
			Dim directorio As String = AppSettings("OutputPath").Replace("[SYSTEM]", "NOD")
			Dim ArchivoName As String
			Dim sNewFile As String
			'ftpC.CurrentDirectory = directorio
			'ftpC.Hostname = AppSettings("FTPUploadHost")
			'ftpC.Username = AppSettings("FTPUploadUser")
			'ftpC.Password = AppSettings("FTPUploadPassword")
			'For Each item As ListItem In lista.Items
			'  If item.Selected Then
			'    ArchivoName = item.Text
			'    ftpC.Upload(directorio & "\" & ArchivoName, AppSettings("FtpNODFolder") & item.Text)
			'    sNewFile = RenameFile(directorio, item.Text)
			'    item.Text = sNewFile '"up" & ArchivoName
			'    bolSubio = True
			'  End If
			'Next
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

				For Each item As ListItem In lista.Items
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

			If bolSubio Then
				'Page.ClientScript.RegisterStartupScript(Me.GetType, "ftpalert", "alert('The DBF files were uploaded');", True)
				Alert.ShowInUpdatePanel("The DBF files were uploaded")
			Else
				'Page.ClientScript.RegisterStartupScript(Me.GetType, "SELECTDBF", "alert('');", True)
				Alert.ShowInUpdatePanel("Please select a DBF file to upload")
			End If
		Catch ex As Exception
			'Page.ClientScript.RegisterStartupScript(Me.GetType, "ftpalert", "alert('There was an error... the FTP did not work');", True)
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
			'File.Move(directorio & "\" & archivo, directorio & "\" & sNewFile)
		End If
		Return sNewFile
	End Function

	Protected Sub btnDownload_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDownload.Click
		If Session("ddlCounty") <> "0" Then
			btnCreateDBF_Click(Nothing, Nothing)
			Using clase As New DataClassesDataContext
				Dim cc = (From c In clase.Counties Where c.IdCounty = CInt(Session("ddlCounty")) Select c.FilePrefix).ToList(0)

				Alert.Script("open('Download.aspx?file=" & cc & "DF" & DateControlCreateDBF.Fecha.ToString("MMdd") & ".DBF&type=NOD" & "');")

			End Using
		Else
			'Page.ClientScript.RegisterStartupScript(Me.GetType, "countySelect", "alert('The County should be selected and searched');", True)
			Alert.ShowInUpdatePanel("The County should be selected and searched")
		End If
	End Sub

	Protected Sub chkSelectAll_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
		Dim chkSelectAll As CheckBox = sender
		Dim chkSelect As CheckBox
		For Each row As GridViewRow In GridView1.Rows

			chkSelect = row.FindControl("chkSelect")
			chkSelect.Checked = chkSelectAll.Checked
		Next

	End Sub

	Protected Sub btnDel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDel.Click
        'Dim chkSelect As CheckBox
        'Dim val As VariantType
        'Dim Ids As String = ""
        'Dim IdDel As Integer

        'Using clase As New DataClassesDataContext
        '	'Alert.Status("Properties " + GridView1.Rows.Count.ToString())
        '	Dim strSelected = hdnselected.Value
        '	Dim arrSelected = strSelected.Split(",")
        '	For Each id As String In arrSelected
        '		If (id <> "") Then
        '			IdDel = Integer.Parse(id)
        '			Ids = Ids & ", " & IdDel.ToString()
        '			Dim objDel = (From c In clase.NODs Where c.IdNod = IdDel Select c).Single
        '			clase.NODs.DeleteOnSubmit(objDel)
        '			Ids = Ids & ", " & IdDel.ToString()
        '		End If
        '	Next
        '	'For Each row As GridViewRow In GridView1.Rows
        '	'	chkSelect = row.Cells(0).FindControl("chkSelect")
        '	'	val = Request.Form(chkSelect.ClientID.ToString())
        '	'	'Alert.Status(val.ToString())
        '	'	'Alert.Status("chkSelect " + chkSelect.ClientID.ToString() + " checked " + chkSelect.Checked.ToString())
        '	'	If chkSelect.Checked Then
        '	'		IdDel = GridView1.DataKeys(row.RowIndex).Value
        '	'		Dim objDel = (From c In clase.NODs Where c.IdNod = IdDel Select c).Single
        '	'		'clase.NODs.DeleteOnSubmit(objDel)
        '	'		Ids = Ids & ", " & IdDel.ToString()
        '	'	End If
        '	'Next
        '	'clase.SubmitChanges()
        '	'Alert.Status("Properties deleted")
        '	Alert.Status(Ids)
        'End Using

        GridBind()
	End Sub

    <Services.WebMethod> _
    Public Shared Function deleteRows(ids As String()) As Boolean
        Using clase As New DataClassesDataContext
            For Each IdDel In ids
                Dim objDel = (From c In clase.NODs Where c.IdNod = IdDel Select c).Single
                clase.NODs.DeleteOnSubmit(objDel)
            Next
            clase.SubmitChanges()
        End Using
        Return True
    End Function

    Protected Sub btnToNTS_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnToNTS.Click
		'Alert.Status("Feature temporarily unvailable.")

		Dim chkSelect As CheckBox
		Dim IdCopy As Integer

		Using clase As New DataClassesDataContext
			For Each row As GridViewRow In GridView1.Rows
				chkSelect = row.FindControl("chkSelect")
				If chkSelect.Checked Then
					IdCopy = GridView1.DataKeys(row.RowIndex).Value
					clase.NTStoNOD(IdCopy)
					Dim objDel = (From c In clase.NTs Where c.IdNts = IdCopy Select c).Single
					clase.NTs.DeleteOnSubmit(objDel)
					clase.SubmitChanges()
				End If
			Next
		End Using
		GridBind()
	End Sub

	Protected Sub chklstStates_DataBound(sender As Object, e As EventArgs) Handles chklstStates.DataBound
		For Each item As ListItem In chklstStates.Items
			item.Selected = True
		Next

	End Sub

	Protected Sub sourceCounty_Selecting(sender As Object, e As LinqDataSourceSelectEventArgs) Handles sourceCounty.Selecting
		Dim selected = New List(Of String)()
		For Each item As ListItem In chklstStates.Items
			If item.Selected Then
				selected.Add(item.Value)
			End If
		Next
		Dim clase As New DataClassesDataContext
		e.Result = (From c In clase.Counties Where selected.Contains(c.IdState) Select Name = c.IdState & " " & c.CountyName, IdCounty = c.IdCounty Order By Name)
	End Sub

	Protected Sub chklstStates_SelectedIndexChanged(sender As Object, e As EventArgs) Handles chklstStates.SelectedIndexChanged
		Dim county = ddlCounty.SelectedValue
		ddlCounty.DataBind()
		If Not ddlCounty.Items().FindByValue(county) Is Nothing Then
			ddlCounty.SelectedValue = county
		End If
	End Sub

	Protected Sub LinqDataSource1_Selecting(sender As Object, e As LinqDataSourceSelectEventArgs) Handles LinqDataSource1.Selecting
		SetSessionValues()
		Dim results = SelectData()
		lblCount.Text = results.Count
		e.Result = results
	End Sub

	Private Sub SetSessionValues()
		Dim selected = New List(Of Integer)()
		Dim all = New List(Of Integer)()
		Session("txtAddress") = txtAddress.Text.Trim
		Session("txtCity") = txtCity.Text.Trim
		Session("txtAmount") = txtAmount.Text.Trim
		Session("txtTrusterOwnerBenefry") = txtTrusterOwnerBenefry.Text.Trim
		Session("ddlStatus") = ddlStatus.SelectedValue
		Session("ddlCounty") = ddlCounty.SelectedValue
		Session("dcFrom") = dcFrom.Fecha
		Session("dcTo") = dcTo.Fecha.AddDays(1).AddSeconds(-1)
		Session("txtASSPAR") = txtASSPAR.Text.Trim
		If Session("ddlCounty") = "" Then
			Session("ddlCounty") = "0"
		End If
		For Each item As ListItem In ddlCounty.Items
			If item.Selected Then
				selected.Add(item.Value)
			End If
			all.Add(item.Value)
		Next
		Session("SelectedCounties") = selected
		Session("AllCounties") = all
	End Sub

	Public Function SelectData() As List(Of NOD)
		Return DataFunctions.SelectNodData()
		'Dim clase As New DataClassesDataContext
		'Dim all = New List(Of Integer)()
		'all = Session("AllCounties")
		'Dim results As New List(Of NOD)
		'If Session("ddlCounty") <> "0" Then
		'	results = (From c In clase.NODs Where (c.ADDRESS.Contains(Session("txtAddress").ToString) Or c.ADDRESS Is Nothing) _
		'									 And (c.ST_CITYSTATE.Contains(Session("txtCity").ToString) Or c.ST_CITYSTATE Is Nothing) _
		'									 And (c.AMOUNT.Contains(Session("txtAmount").ToString) Or c.AMOUNT Is Nothing) _
		'									 And (c.ASSPAR.Contains(Session("txtASSPAR").ToString) Or c.ASSPAR Is Nothing) _
		'									 And (c.OWNER.Contains(Session("txtTrusterOwnerBenefry").ToString) Or c.BENEFRY.Contains(Session("txtTrusterOwnerBenefry").ToString) Or c.TRUSTOR.Contains(Session("txtTrusterOwnerBenefry").ToString) Or c.TRUSTEE.Contains(Session("txtTrusterOwnerBenefry").ToString)) _
		'									 And (c.IdCounty = CInt(IIf(Session("ddlCounty") = 1, "3", Session("ddlCounty"))) Or _
		'															c.IdCounty = CInt(IIf(Session("ddlCounty") = 1, "4", Session("ddlCounty"))) Or _
		'															c.IdCounty = CInt(IIf(Session("ddlCounty") = 1, "5", Session("ddlCounty"))) Or _
		'															c.IdCounty = CInt(IIf(Session("ddlCounty") = 1, "6", Session("ddlCounty"))) Or CInt(Session("ddlCounty")) = 0) _
		'									 And (c.IdStatus = CInt(Session("ddlStatus")) Or CInt(Session("ddlStatus")) = 0 Or (CInt(Session("ddlStatus")) = 11 And (c.IdStatus = 1 Or c.IdStatus = 3))) _
		'									 And (c.Locked = 0) _
		'									 And (c.Created >= CDate(Session("dcFrom"))) _
		'									 And (c.Created <= CDate(Session("dcTo"))) _
		'													 Select c).ToList
		'Else
		'	results = (From c In clase.NODs Where (c.ADDRESS.Contains(Session("txtAddress").ToString) Or c.ADDRESS Is Nothing) _
		'									 And (c.ST_CITYSTATE.Contains(Session("txtCity").ToString) Or c.ST_CITYSTATE Is Nothing) _
		'									 And (c.AMOUNT.Contains(Session("txtAmount").ToString) Or c.AMOUNT Is Nothing) _
		'									 And (c.ASSPAR.Contains(Session("txtASSPAR").ToString) Or c.ASSPAR Is Nothing) _
		'									 And (c.OWNER.Contains(Session("txtTrusterOwnerBenefry").ToString) Or c.BENEFRY.Contains(Session("txtTrusterOwnerBenefry").ToString) Or c.TRUSTOR.Contains(Session("txtTrusterOwnerBenefry").ToString) Or c.TRUSTEE.Contains(Session("txtTrusterOwnerBenefry").ToString)) _
		'									 And (all.Contains(c.IdCounty)) _
		'									 And (c.IdStatus = CInt(Session("ddlStatus")) Or CInt(Session("ddlStatus")) = 0 Or (CInt(Session("ddlStatus")) = 11 And (c.IdStatus = 1 Or c.IdStatus = 3))) _
		'									 And (c.Locked = 0) _
		'									 And (c.Created >= CDate(Session("dcFrom"))) _
		'									 And (c.Created <= CDate(Session("dcTo"))) _
		'													 Select c).ToList
		'End If
		'Return results
	End Function

	Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
		GridView1.DataBind()
	End Sub
End Class