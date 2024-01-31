Imports Microsoft.VisualBasic

Public Class DataFunctions

	Public Shared Function SelectNodData() As List(Of NOD)
		Dim Session = System.Web.HttpContext.Current.Session
		Dim clase As New DataClassesDataContext
		Dim all = New List(Of Integer)()
		all = Session("AllCounties")
		Dim results As New List(Of NOD)
		If Session("ddlCounty") <> "0" Then
			results = (From c In clase.NODs Where (c.ADDRESS.Contains(Session("txtAddress").ToString) Or c.ADDRESS Is Nothing) _
											 And (c.ST_CITYSTATE.Contains(Session("txtCity").ToString) Or c.ST_CITYSTATE Is Nothing) _
											 And (c.AMOUNT.Contains(Session("txtAmount").ToString) Or c.AMOUNT Is Nothing) _
											 And (c.ASSPAR.Contains(Session("txtASSPAR").ToString) Or c.ASSPAR Is Nothing) _
											 And (c.OWNER.Contains(Session("txtTrusterOwnerBenefry").ToString) Or c.BENEFRY.Contains(Session("txtTrusterOwnerBenefry").ToString) Or c.TRUSTOR.Contains(Session("txtTrusterOwnerBenefry").ToString) Or c.TRUSTEE.Contains(Session("txtTrusterOwnerBenefry").ToString)) _
											 And (c.IdCounty = CInt(IIf(Session("ddlCounty") = 1, "3", Session("ddlCounty"))) Or _
																	c.IdCounty = CInt(IIf(Session("ddlCounty") = 1, "4", Session("ddlCounty"))) Or _
																	c.IdCounty = CInt(IIf(Session("ddlCounty") = 1, "5", Session("ddlCounty"))) Or _
																	c.IdCounty = CInt(IIf(Session("ddlCounty") = 1, "6", Session("ddlCounty"))) Or CInt(Session("ddlCounty")) = 0) _
											 And (c.IdStatus = CInt(Session("ddlStatus")) Or CInt(Session("ddlStatus")) = 0 Or (CInt(Session("ddlStatus")) = 11 And (c.IdStatus = 1 Or c.IdStatus = 3))) _
											 And (c.Locked = 0) _
											 And (c.Created >= CDate(Session("dcFrom"))) _
											 And (c.Created <= CDate(Session("dcTo"))) _
															 Select c Order By c.IdNod Descending).ToList
		Else
      results = (From c In clase.NODs Where (c.ADDRESS.Contains(Session("txtAddress").ToString) Or c.ADDRESS Is Nothing) _
            And (c.ST_CITYSTATE.Contains(Session("txtCity").ToString) Or c.ST_CITYSTATE Is Nothing) _
            And (c.AMOUNT.Contains(Session("txtAmount").ToString) Or c.AMOUNT Is Nothing) _
            And (c.ASSPAR.Contains(Session("txtASSPAR").ToString) Or c.ASSPAR Is Nothing) _
            And (c.OWNER.Contains(Session("txtTrusterOwnerBenefry").ToString) Or c.BENEFRY.Contains(Session("txtTrusterOwnerBenefry").ToString) Or c.TRUSTOR.Contains(Session("txtTrusterOwnerBenefry").ToString) Or c.TRUSTEE.Contains(Session("txtTrusterOwnerBenefry").ToString)) _
            And (all.Contains(c.IdCounty)) _
            And (c.IdStatus = CInt(Session("ddlStatus")) Or CInt(Session("ddlStatus")) = 0 Or (CInt(Session("ddlStatus")) = 11 And (c.IdStatus = 1 Or c.IdStatus = 3))) _
            And (c.Locked = 0) _
            And (c.Created >= CDate(Session("dcFrom"))) _
            And (c.Created <= CDate(Session("dcTo"))) _
                Select c Order By c.IdNod Descending).ToList()
    End If
    Return results
  End Function

	Public Shared Function SelectNtsData() As List(Of NT)
		Dim Session = System.Web.HttpContext.Current.Session
		Dim clase As New DataClassesDataContext
		Dim all = New List(Of Integer)()
		all = Session("AllCounties")
		Dim results As New List(Of NT)
		If Session("ddlCounty") <> "0" Then
			results = (From c In clase.NTs Where (c.ADDRESS.Contains(Session("txtAddress").ToString) Or c.ADDRESS Is Nothing) _
											 And (c.ST_CITYSTATE.Contains(Session("txtCity").ToString) Or c.ST_CITYSTATE Is Nothing) _
											 And (c.AMOUNT.Contains(Session("txtAmount").ToString) Or c.AMOUNT Is Nothing) _
											 And (c.ASSPAR.Contains(Session("txtASSPAR").ToString) Or c.ASSPAR Is Nothing) _
											 And (c.OWNER.Contains(Session("txtTrusterOwnerBenefry").ToString) Or c.BENEFRY.Contains(Session("txtTrusterOwnerBenefry").ToString) Or c.TRUSTOR.Contains(Session("txtTrusterOwnerBenefry").ToString) Or c.TRUSTEE.Contains(Session("txtTrusterOwnerBenefry").ToString)) _
											 And (c.IdCounty = CInt(IIf(Session("ddlCounty") = 1, "3", Session("ddlCounty"))) Or _
																	c.IdCounty = CInt(IIf(Session("ddlCounty") = 1, "4", Session("ddlCounty"))) Or _
																	c.IdCounty = CInt(IIf(Session("ddlCounty") = 1, "5", Session("ddlCounty"))) Or _
																	c.IdCounty = CInt(IIf(Session("ddlCounty") = 1, "6", Session("ddlCounty"))) Or CInt(Session("ddlCounty")) = 0) _
											 And (c.IdStatus = CInt(Session("ddlStatus")) Or CInt(Session("ddlStatus")) = 0 Or (CInt(Session("ddlStatus")) = 11 And (c.IdStatus = 1 Or c.IdStatus = 3))) _
											 And (c.Locked = 0) _
											 And (c.Created >= CDate(Session("dcFrom"))) _
											 And (c.Created <= CDate(Session("dcTo"))) _
															 Select c Order By c.IdNts Descending).ToList
		Else
			results = (From c In clase.NTs Where (c.ADDRESS.Contains(Session("txtAddress").ToString) Or c.ADDRESS Is Nothing) _
											 And (c.ST_CITYSTATE.Contains(Session("txtCity").ToString) Or c.ST_CITYSTATE Is Nothing) _
											 And (c.AMOUNT.Contains(Session("txtAmount").ToString) Or c.AMOUNT Is Nothing) _
											 And (c.ASSPAR.Contains(Session("txtASSPAR").ToString) Or c.ASSPAR Is Nothing) _
											 And (c.OWNER.Contains(Session("txtTrusterOwnerBenefry").ToString) Or c.BENEFRY.Contains(Session("txtTrusterOwnerBenefry").ToString) Or c.TRUSTOR.Contains(Session("txtTrusterOwnerBenefry").ToString) Or c.TRUSTEE.Contains(Session("txtTrusterOwnerBenefry").ToString)) _
											 And (all.Contains(c.IdCounty)) _
											 And (c.IdStatus = CInt(Session("ddlStatus")) Or CInt(Session("ddlStatus")) = 0 Or (CInt(Session("ddlStatus")) = 11 And (c.IdStatus = 1 Or c.IdStatus = 3))) _
											 And (c.Locked = 0) _
											 And (c.Created >= CDate(Session("dcFrom"))) _
											 And (c.Created <= CDate(Session("dcTo"))) _
															 Select c Order By c.IdNts Descending).ToList
		End If
		Return results
	End Function
End Class
