Imports Infragistics.WebUI.UltraWebGrid
Imports Infragistics.WebUI.WebDataInput

Partial Class NodEd
    Inherits System.Web.UI.Page

    Public Property IdNod() As Integer
        Get
            Return hdnIdNod.Value
        End Get
        Set(ByVal value As Integer)
            hdnIdNod.Value = value
            lblId.Text = IIf(value = 0, "", value)
            txtId.Text = lblId.Text
        End Set
    End Property

    Public Property Index() As Integer
        Get
            Return hdnIndex.Value
        End Get
        Set(ByVal value As Integer)
            hdnIndex.Value = value
        End Set
    End Property

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Save()
    End Sub

    Private Sub Save()
        Using claseN As New DataClassesDataContext
            Dim objN As New NOD
            If IdNod > 0 Then objN = (From c In claseN.NODs Where c.IdNod = IdNod Select c).Single

            objN.ADDRESS = txtSiteHouseNumber.Text & " " & _
                           txtSiteFraction.Text & " " & _
                           txtSiteDirection.Text & " " & _
                           txtSiteStName.Text & " " & _
                           txtSiteSuffix.Text & " " & _
                           txtSitePostDir.Text & " " & _
                           txtSiteUnitPrefix.Text & " " & _
                           txtSiteUnitValue.Text ''txtAddress.Text
            objN.AMOUNT = txtDelAmt.Text
            objN.ASSPAR = MaskASSPAR.Text
            objN.ASOF = DateControlAsOf.Fecha

            objN.B_PHONE = MaskB_PHONE.Value
            objN.BENEFRY = txtBenefry.Text
            objN.CITY = txtSiteCity.Text ''txtCity.Text
            objN.IdCounty = ddlCOUNTY.SelectedValue

            'objN.COUNTY = txtCounty.Text
            objN.DELNIQ = DateControlDelinq.Fecha

            objN.HOEX = txtHoEx.Text
            'objN.L_DATE = 
            objN.LEGAL = txtLegal.Text
            If IsNumeric(txtLoan.Text) Then
                objN.LOAN = CDbl(txtLoan.Text)
            Else
                objN.LOAN = txtLoan.Text
            End If
            'objN.AMOUNT = txtLoanAmt.Text
            objN.LOT = txtLot.Text
            'objN.LST = txtl

            objN.NOD = txtNOD.Text
            'objN.NTS = txtNTS.Text
            objN.OWNER = txtOwner1.Text ''OLD 
            objN.PRCHS_DATE = DateControlPRCHS_DATE.Fecha
            objN.REMARKS = txtRemarks.Text
            objN.ROOMS = txtRooms.Text

            'objN.SALE_DATE = DateControlSaleDate.Fecha
            'objN.SALE_TIME = txtTime.Text
            'objN.SITE = txtSite.Text
            objN.SQFT = txtSqFt.Text
            objN.STORY = txtStory.Text

            'objN.T_PHONE = MaskT_PHONE.Value
            objN.TAX_VALUE = txtTaxVal.Text

            objN.TD1 = txtTD1.Text
            objN.TD1_A = IIf(radTD1_A.Checked, "*", "")
            objN.TD1_D = DateControlTD1_D.Fecha
            objN.TD2 = txtTD2.Text
            objN.TD2_A = IIf(radTD2_A.Checked, "*", "")
            objN.TD2_D = DateControlTD2_D.Fecha

            objN.TD3 = txtTD3.Text
            objN.TD3_A = IIf(radTD3_A.Checked, "*", "")
            objN.TD3_D = DateControlTD3_D.Fecha
            objN.TD4 = txtTD4.Text
            objN.TD4_A = IIf(radTD4_A.Checked, "*", "")
            objN.TD4_D = DateControlTD4_D.Fecha

            objN.TD5 = txtTD5.Text
            objN.TD5_A = IIf(radTD5_A.Checked, "*", "")
            objN.TD5_D = DateControlTD5_D.Fecha
            objN.TD6 = txtTD6.Text
            objN.TD6_A = IIf(radTD6_A.Checked, "*", "")
            objN.TD6_D = DateControlTD6_D.Fecha

            objN.TDID = txtTDID.Text
            'objN.TG = txt

            'objN.TRUSTEE = txtTrustee.Text
            objN.TRUSTOR = txtTrustorFirstName.Text & " " & _
                           txtTrustorSecondName.Text ''txtTrustor.Text
            objN.TX_YR = txtTxYr.Text
            objN.USE = txtUse.Text
            objN.YRBLT = txtYrBit.Text
            'objN.ZIP = txtSiteZip.Text

            ''new fields start
            objN.SA_PROPERTY_ID = txtPropertyID.Text
            objN.SR_UNIQUE_ID = txtUniqueID.Text
            objN.OWNER1 = txtOwner1.Text
            objN.OWNER2 = txtOwner2.Text
            objN.TRUSTOR_FIRST_NAME = txtTrustorFirstName.Text
            objN.TRUSTOR_LAST_NAME = txtTrustorSecondName.Text
            objN.BATHROOMS = txtBathrooms.Text
            objN.BEDROOMS = txtBedrooms.Text
            objN.NBRROOMS = txtNBRooms.Text
            objN.TR_PHONE = MaskTr_PHONE.Value

            objN.TRUSTEE = txtTrustee.Text
            objN.T_PHONE = MaskT_PHONE.Value
            objN.TRUSTEE_HOUSE = txtTrusteeHouseNumber.Text
            objN.TRUSTEE_STNAME = txtTrusteeStreetName.Text
            objN.TRUSTEE_UNITNBR = txtTrusteeUnitNBR.Text
            objN.FD_TRUSTEE_SALE_NBR = txtFD_TRUSTEE_SALE_NBR.Text

            objN.TRUSTEE_ADDRESS = txtTrusteeHouseNumber.Text & " " & _
                     txtTrusteeStreetName.Text & " " & _
                     txtTrusteeUnitNBR.Text

            objN.TRUSTEE_ADDRESS_ID_STATE = txtTrusteeState.Text
            objN.TRUSTEE_ZIP = txtTrusteeZip.Text
            objN.TRUSTEE_CITY = txtTrusteeCity.Text

            objN.BENE_HOUSE = txtBenefryHouseNumber.Text
            objN.BENE_STNAME = txtBenefryStreetName.Text
            objN.BENE_UNITNBR = txtBenefryUnitNBR.Text
            objN.BENE_ADDRESS_ID_STATE = txtBenefryAddressIdState.Text
            objN.BENE_ZIP = txtBenefryZip.Text
            objN.BENE_CITY = txtBenefryCity.Text

            objN.BENE_ADDRESS = txtBenefryHouseNumber.Text & " " & _
                     txtBenefryStreetName.Text & " " & _
                     txtBenefryUnitNBR.Text

            objN.UNITS = txtUnits.Text
            If objN.SA_PROPERTY_ID <> "" Then
                Util.EstimatedValue(objN.SA_PROPERTY_ID)
                Dim oEstimValue = (From ev In claseN.ESTIMATED_VALUEs Where ev.SA_PROPERTY_ID = objN.SA_PROPERTY_ID Select ev).ToList(0)
                oEstimValue.ESTIMATED_PROP_VALUE = txtEstimatedValue.Text
                If IsNumeric(txtEstimatedValue.Text) Then
                    oEstimValue.ESTIMATED_PROP_VALUE = CDbl(txtEstimatedValue.Text)
                Else
                    oEstimValue.ESTIMATED_PROP_VALUE = txtEstimatedValue.Text
                End If
                objN.ESTIMATED_PROP_VALUE = oEstimValue.ESTIMATED_PROP_VALUE
                claseN.SubmitChanges()
            End If

            If IsNumeric(txtTaxStatus1.Text) Then
                objN.PROP_TAX_STATUS_1 = CDbl(txtTaxStatus1.Text)
            Else
                objN.PROP_TAX_STATUS_1 = txtTaxStatus1.Text
            End If
            If IsNumeric(txtTaxStatus2.Text) Then
                objN.PROP_TAX_STATUS_2 = CDbl(txtTaxStatus2.Text)
            Else
                objN.PROP_TAX_STATUS_2 = txtTaxStatus2.Text
            End If
            If IsNumeric(txtTaxStatus3.Text) Then
                objN.PROP_TAX_STATUS_3 = CDbl(txtTaxStatus3.Text)
            Else
                objN.PROP_TAX_STATUS_3 = txtTaxStatus3.Text
            End If
            'objN.PROP_TAX_STATUS_1 = txtTaxStatus1.Text
            'objN.PROP_TAX_STATUS_2 = txtTaxStatus2.Text
            'objN.PROP_TAX_STATUS_3 = txtTaxStatus3.Text

            objN.ADDRESS_ID_STATE = txtSiteState.Text
            objN.ST_CITYSTATE = txtSiteCity.Text
            objN.ST_DIR = txtSiteDirection.Text
            objN.ST_FRACT = txtSiteFraction.Text
            objN.ST_HS_NBR = txtSiteHouseNumber.Text
            objN.ST_POSTD = txtSitePostDir.Text
            objN.ST_STRT = txtSiteStName.Text
            objN.ST_SUF = txtSiteSuffix.Text
            objN.ST_UNTPR = txtSiteUnitPrefix.Text
            objN.ST_UNTVL = txtSiteUnitValue.Text
            objN.ZIP = txtSiteZip.Text

            objN.ML_CITY = txtMailCity.Text
            objN.ML_STATE = txtMailAddressIdState.Text
            objN.ML_ZIP = txtMailZip.Text
            objN.ML_ZIPPLUS4 = txtMailZipPlus4.Text
            objN.ML_DIR = txtMailDirection.Text
            objN.ML_FRACT = txtMailFraction.Text
            objN.ML_HS_NBR = txtMailHouseNumber.Text
            objN.ML_POSTD = txtMailPostDir.Text
            objN.ML_STRT = txtMailStName.Text
            objN.ML_SUF = txtMailSuffix.Text
            objN.ML_UNTPR = txtMailUnitPrefix.Text
            objN.ML_UNTVL = txtMailUnitValue.Text

            objN.SA_OWNR_SC = txtOwnerStatus.Text
            objN.SA_POL_COD = txtPoolCode.Text
            objN.SA_POL_SQF = txtPoolSQFT.Text
            objN.SA_VW_CODE = txtViewCode.Text

            objN.NOD_REC_DT = DateNOD.Fecha
            objN.NTS_REC_DT = DateNTS.Fecha

            objN.SA_ZONING = txtSA_ZONING.Text
            objN.SA_VAL_TRANSFER = txtSA_VAL_TRANSFER.Text
            ''new fields end

            If chkReserved.Checked Then
                objN.IdStatus = 12 'ddlStatus.SelectedValue
            Else
                objN.IdStatus = 3 'ddlStatus.SelectedValue
            End If
            ddlStatus.SelectedValue = objN.IdStatus

            objN.Modified = Now
            objN.Created = DateImported.Fecha

            If IdNod = 0 Then
                claseN.NODs.InsertOnSubmit(objN)
                objN.IdStatus = 1
                objN.Created = Now
            Else
                'objN.IdStatus = 3
            End If
            objN.Locked = 0
            claseN.SubmitChanges()
        End Using
    End Sub

    Private Sub Fill()
        Clean()
        Using claseN As New DataClassesDataContext
            Dim objN = (From c In claseN.NODs Where c.IdNod = IdNod Select c).Single
            Dim objC = (From c In claseN.Counties Where c.IdCounty = objN.IdCounty Select c).ToList

            'If objC.Count > 0 Then
            '  MaskASSPAR.InputMask = objC(0).ASSPARFormat
            'End If
            MaskASSPAR.InputMask = "CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC"
            MaskASSPAR.PromptChar = " "
            If Not objN.ADDRESS Is Nothing Then txtAddress.Text = objN.ADDRESS : lblAddress.Text = objN.ADDRESS
            If Not objN.AMOUNT Is Nothing Then txtDelAmt.Text = objN.AMOUNT
            If Not objN.ASOF Is Nothing Then DateControlAsOf.Fecha = objN.ASOF
            If Not objN.ASSPAR Is Nothing Then MaskASSPAR.Value = objN.ASSPAR
            If Not objN.B_PHONE Is Nothing Then MaskB_PHONE.Value = objN.B_PHONE.Replace(" ", "").Replace("-", "").Replace("/", "")
            If Not objN.BENEFRY Is Nothing Then txtBenefry.Text = objN.BENEFRY
            If Not objN.CITY Is Nothing Then txtCity.Text = objN.CITY
            Try
                ddlCOUNTY.SelectedValue = objN.IdCounty
            Catch ex As Exception
                ddlCOUNTY.SelectedIndex = 0
            End Try
            If Not objN.DELNIQ Is Nothing Then DateControlDelinq.Fecha = objN.DELNIQ

            If Not objN.HOEX Is Nothing Then txtHoEx.Text = objN.HOEX
            'objN.L_DATE = 
            If Not objN.LEGAL Is Nothing Then txtLegal.Text = objN.LEGAL
            txtLoan.Text = objN.LOAN
            'If IsNumeric(objN.LOAN) Then
            '  txtLoan.Text = FormatCurrency(objN.LOAN)
            'ElseIf Not objN.LOAN Is Nothing Then
            'End If
            'If Not objN.AMOUNT Is Nothing Then txtLoanAmt.Text = objN.AMOUNT
            If Not objN.LOT Is Nothing Then txtLot.Text = objN.LOT
            'objN.LST =  If Not objN.ADDRESS Is Nothing Then  txtl

            If Not objN.NOD Is Nothing Then txtNOD.Text = objN.NOD
            'objN.NTS =  If Not objN.ADDRESS Is Nothing Then  txtNTS.Text
            If Not objN.OWNER Is Nothing Then txtOwner.Text = objN.OWNER
            If Not objN.PRCHS_DATE Is Nothing Then DateControlPRCHS_DATE.Fecha = objN.PRCHS_DATE
            If Not objN.REMARKS Is Nothing Then txtRemarks.Text = objN.REMARKS
            If Not objN.ROOMS Is Nothing Then txtRooms.Text = objN.ROOMS

            'objN.SALE_DATE = DateControlSaleDate.Fecha
            'objN.SALE_TIME =  If Not objN.ADDRESS Is Nothing Then  txtTime.Text
            'objN.SITE =  If Not objN.ADDRESS Is Nothing Then  txtSite.Text
            If Not objN.SQFT Is Nothing Then txtSqFt.Text = objN.SQFT
            If Not objN.STORY Is Nothing Then txtStory.Text = objN.STORY

            'objN.T_PHONE = MaskT_PHONE.Value
            If Not objN.TAX_VALUE Is Nothing Then txtTaxVal.Text = objN.TAX_VALUE

            If Not objN.TD1 Is Nothing Then txtTD1.Text = objN.TD1
            If Not objN.TD1_A Is Nothing Then radTD1_A.Checked = (objN.TD1_A = "*")
            If Not objN.TD1_D Is Nothing Then DateControlTD1_D.Fecha = objN.TD1_D

            If Not objN.TD2 Is Nothing Then txtTD2.Text = objN.TD2
            If Not objN.TD2_A Is Nothing Then radTD2_A.Checked = (objN.TD2_A = "*")
            If Not objN.TD2_D Is Nothing Then DateControlTD2_D.Fecha = objN.TD2_D

            If Not objN.TD3 Is Nothing Then txtTD3.Text = objN.TD3
            If Not objN.TD3_A Is Nothing Then radTD3_A.Checked = (objN.TD3_A = "*")
            If Not objN.TD3_D Is Nothing Then DateControlTD3_D.Fecha = objN.TD3_D

            If Not objN.TD4 Is Nothing Then txtTD4.Text = objN.TD4
            If Not objN.TD4_A Is Nothing Then radTD4_A.Checked = (objN.TD4_A = "*")
            If Not objN.TD4_D Is Nothing Then DateControlTD4_D.Fecha = objN.TD4_D

            If Not objN.TD5 Is Nothing Then txtTD5.Text = objN.TD5
            If Not objN.TD5_A Is Nothing Then radTD5_A.Checked = (objN.TD5_A = "*")
            If Not objN.TD5_D Is Nothing Then DateControlTD5_D.Fecha = objN.TD5_D

            If Not objN.TD6 Is Nothing Then txtTD6.Text = objN.TD6
            If Not objN.TD6_A Is Nothing Then radTD6_A.Checked = (objN.TD6_A = "*")
            If Not objN.TD6_D Is Nothing Then DateControlTD6_D.Fecha = objN.TD6_D

            If Not objN.TDID Is Nothing Then txtTDID.Text = objN.TDID
            'objN.TG =  If Not objN.ADDRESS Is Nothing Then  txt

            'objN.TRUSTEE =  If Not objN.ADDRESS Is Nothing Then  txtTrustee.Text
            If Not objN.TRUSTOR Is Nothing Then txtTrustor.Text = objN.TRUSTOR : lblTrustor.Text = objN.TRUSTOR
            If Not objN.TX_YR Is Nothing Then txtTxYr.Text = objN.TX_YR
            If Not objN.USE Is Nothing Then txtUse.Text = objN.USE
            If Not objN.YRBLT Is Nothing Then txtYrBit.Text = objN.YRBLT
            If Not objN.ZIP Is Nothing Then txtZip.Text = objN.ZIP

            ''new fields start
            If Not objN.SA_PROPERTY_ID Is Nothing Then txtPropertyID.Text = objN.SA_PROPERTY_ID
            If Not objN.SR_UNIQUE_ID Is Nothing Then txtUniqueID.Text = objN.SR_UNIQUE_ID
            If Not objN.OWNER1 Is Nothing Then txtOwner1.Text = objN.OWNER1
            If Not objN.OWNER2 Is Nothing Then txtOwner2.Text = objN.OWNER2
            If Not objN.TRUSTOR_FIRST_NAME Is Nothing Then txtTrustorFirstName.Text = objN.TRUSTOR_FIRST_NAME
            If Not objN.TRUSTOR_LAST_NAME Is Nothing Then txtTrustorSecondName.Text = objN.TRUSTOR_LAST_NAME
            If Not objN.BATHROOMS Is Nothing Then txtBathrooms.Text = objN.BATHROOMS
            If Not objN.BEDROOMS Is Nothing Then txtBedrooms.Text = objN.BEDROOMS
            If Not objN.NBRROOMS Is Nothing Then txtNBRooms.Text = objN.NBRROOMS
            If Not objN.TR_PHONE Is Nothing Then MaskTr_PHONE.Value = objN.TR_PHONE.Replace(" ", "").Replace("-", "").Replace("/", "")

            If Not objN.TRUSTEE Is Nothing Then txtTrustee.Text = objN.TRUSTEE
            If Not objN.T_PHONE Is Nothing Then MaskT_PHONE.Value = objN.T_PHONE.Replace(" ", "").Replace("-", "").Replace("/", "")
            If Not objN.TRUSTEE_HOUSE Is Nothing Then txtTrusteeHouseNumber.Text = objN.TRUSTEE_HOUSE
            If Not objN.TRUSTEE_STNAME Is Nothing Then txtTrusteeStreetName.Text = objN.TRUSTEE_STNAME
            If Not objN.TRUSTEE_UNITNBR Is Nothing Then txtTrusteeUnitNBR.Text = objN.TRUSTEE_UNITNBR
            If Not objN.FD_TRUSTEE_SALE_NBR Is Nothing Then txtFD_TRUSTEE_SALE_NBR.Text = objN.FD_TRUSTEE_SALE_NBR

            If Not objN.TRUSTEE_ADDRESS_ID_STATE Is Nothing Then txtTrusteeState.Text = objN.TRUSTEE_ADDRESS_ID_STATE
            If Not objN.TRUSTEE_ZIP Is Nothing Then txtTrusteeZip.Text = objN.TRUSTEE_ZIP
            If Not objN.TRUSTEE_CITY Is Nothing Then txtTrusteeCity.Text = objN.TRUSTEE_CITY

            If Not objN.BENE_HOUSE Is Nothing Then txtBenefryHouseNumber.Text = objN.BENE_HOUSE
            If Not objN.BENE_STNAME Is Nothing Then txtBenefryStreetName.Text = objN.BENE_STNAME
            If Not objN.BENE_UNITNBR Is Nothing Then txtBenefryUnitNBR.Text = objN.BENE_UNITNBR
            If Not objN.BENE_ADDRESS_ID_STATE Is Nothing Then txtBenefryAddressIdState.Text = objN.BENE_ADDRESS_ID_STATE
            If Not objN.BENE_ZIP Is Nothing Then txtBenefryZip.Text = objN.BENE_ZIP
            If Not objN.BENE_CITY Is Nothing Then txtBenefryCity.Text = objN.BENE_CITY

            If Not objN.UNITS Is Nothing Then txtUnits.Text = objN.UNITS
            If Not objN.ESTIMATED_PROP_VALUE Is Nothing Then txtEstimatedValue.Text = objN.ESTIMATED_PROP_VALUE
            If objN.SA_PROPERTY_ID <> "" Then
                Dim oEstimValue = (From ev In claseN.ESTIMATED_VALUEs Where ev.SA_PROPERTY_ID = objN.SA_PROPERTY_ID Select ev).ToList
                If oEstimValue.Count > 0 Then
                    If Not oEstimValue(0).ESTIMATED_PROP_VALUE Is Nothing Then txtEstimatedValue.Text = oEstimValue(0).ESTIMATED_PROP_VALUE
                End If
            End If
            If Not objN.PROP_TAX_STATUS_1 Is Nothing Then txtTaxStatus1.Text = objN.PROP_TAX_STATUS_1
            If Not objN.PROP_TAX_STATUS_2 Is Nothing Then txtTaxStatus2.Text = objN.PROP_TAX_STATUS_2
            If Not objN.PROP_TAX_STATUS_3 Is Nothing Then txtTaxStatus3.Text = objN.PROP_TAX_STATUS_3

            If Not objN.ADDRESS_ID_STATE Is Nothing Then txtSiteState.Text = objN.ADDRESS_ID_STATE
            If Not objN.ST_CITYSTATE Is Nothing Then txtSiteCity.Text = objN.ST_CITYSTATE
            If Not objN.ST_DIR Is Nothing Then txtSiteDirection.Text = objN.ST_DIR
            If Not objN.ST_FRACT Is Nothing Then txtSiteFraction.Text = objN.ST_FRACT
            If Not objN.ST_HS_NBR Is Nothing Then txtSiteHouseNumber.Text = objN.ST_HS_NBR
            If Not objN.ST_POSTD Is Nothing Then txtSitePostDir.Text = objN.ST_POSTD
            If Not objN.ST_STRT Is Nothing Then txtSiteStName.Text = objN.ST_STRT
            If Not objN.ST_SUF Is Nothing Then txtSiteSuffix.Text = objN.ST_SUF
            If Not objN.ST_UNTPR Is Nothing Then txtSiteUnitPrefix.Text = objN.ST_UNTPR
            If Not objN.ST_UNTVL Is Nothing Then txtSiteUnitValue.Text = objN.ST_UNTVL
            If Not objN.ZIP Is Nothing Then txtSiteZip.Text = objN.ZIP

            If Not objN.ML_CITY Is Nothing Then txtMailCity.Text = objN.ML_CITY
            If Not objN.ML_STATE Is Nothing Then txtMailAddressIdState.Text = objN.ML_STATE
            If Not objN.ML_ZIP Is Nothing Then txtMailZip.Text = objN.ML_ZIP
            If Not objN.ML_ZIPPLUS4 Is Nothing Then txtMailZipPlus4.Text = objN.ML_ZIPPLUS4
            If Not objN.ML_DIR Is Nothing Then txtMailDirection.Text = objN.ML_DIR
            If Not objN.ML_FRACT Is Nothing Then txtMailFraction.Text = objN.ML_FRACT
            If Not objN.ML_HS_NBR Is Nothing Then txtMailHouseNumber.Text = objN.ML_HS_NBR
            If Not objN.ML_POSTD Is Nothing Then txtMailPostDir.Text = objN.ML_POSTD
            If Not objN.ML_STRT Is Nothing Then txtMailStName.Text = objN.ML_STRT
            If Not objN.ML_SUF Is Nothing Then txtMailSuffix.Text = objN.ML_SUF
            If Not objN.ML_UNTPR Is Nothing Then txtMailUnitPrefix.Text = objN.ML_UNTPR
            If Not objN.ML_UNTVL Is Nothing Then txtMailUnitValue.Text = objN.ML_UNTVL

            If Not objN.SA_OWNR_SC Is Nothing Then txtOwnerStatus.Text = objN.SA_OWNR_SC
            If Not objN.SA_POL_COD Is Nothing Then txtPoolCode.Text = objN.SA_POL_COD
            If Not objN.SA_POL_SQF Is Nothing Then txtPoolSQFT.Text = objN.SA_POL_SQF
            If Not objN.SA_VW_CODE Is Nothing Then txtViewCode.Text = objN.SA_VW_CODE

            If Not objN.NOD_REC_DT Is Nothing Then DateNOD.Fecha = objN.NOD_REC_DT
            If Not objN.NTS_REC_DT Is Nothing Then DateNTS.Fecha = objN.NTS_REC_DT

            If Not objN.SA_ZONING Is Nothing Then txtSA_ZONING.Text = objN.SA_ZONING
            If Not objN.SA_VAL_TRANSFER Is Nothing Then txtSA_VAL_TRANSFER.Text = objN.SA_VAL_TRANSFER
            ''new fields end

            ddlStatus.SelectedValue = objN.IdStatus
            chkReserved.Checked = (objN.IdStatus = 12)

            DateImported.Fecha = objN.Created
            'objN.IdStatus = 3
            'objN.Modified = Now
            'claseN.SubmitChanges()
        End Using
    End Sub

    Private Sub Clean()
        txtAddress.Text = ""
        'objN.AMOUNT = txta
        DateControlAsOf.Limpiar()
        MaskASSPAR.Value = ""

        MaskB_PHONE.Value = ""
        txtBenefry.Text = ""
        txtCity.Text = ""
        ddlCOUNTY.SelectedIndex = -1
        DateControlDelinq.Limpiar()

        txtHoEx.Text = ""
        'objN.L_DATE = 
        txtLegal.Text = ""
        txtLoan.Text = ""
        txtLoanAmt.Text = ""
        txtLot.Text = ""
        'objN.LST =  If Not objN.ADDRESS Is Nothing Then  txtl

        txtNOD.Text = ""
        'objN.NTS =  If Not objN.ADDRESS Is Nothing Then  txtNTS.Text
        txtOwner.Text = ""
        DateControlPRCHS_DATE.Limpiar()
        txtRemarks.Text = ""
        txtRooms.Text = ""

        'objN.SALE_DATE = DateControlSaleDate.Fecha
        'objN.SALE_TIME =  If Not objN.ADDRESS Is Nothing Then  txtTime.Text
        'objN.SITE =  If Not objN.ADDRESS Is Nothing Then  txtSite.Text
        txtSqFt.Text = ""
        txtStory.Text = ""

        'objN.T_PHONE = MaskT_PHONE.Value
        txtTaxVal.Text = ""

        txtTD1.Text = ""
        radTD1_A.Checked = False
        DateControlTD1_D.Limpiar()

        txtTD2.Text = ""
        radTD2_A.Checked = False
        DateControlTD2_D.Limpiar()

        txtTD3.Text = ""
        radTD3_A.Checked = False
        DateControlTD3_D.Limpiar()

        txtTD4.Text = ""
        radTD4_A.Checked = False
        DateControlTD4_D.Limpiar()

        txtTD5.Text = ""
        radTD5_A.Checked = False
        DateControlTD5_D.Limpiar()

        txtTD6.Text = ""
        radTD6_A.Checked = False
        DateControlTD6_D.Limpiar()

        txtTDID.Text = ""
        'objN.TG =  If Not objN.ADDRESS Is Nothing Then  txt

        'objN.TRUSTEE =  If Not objN.ADDRESS Is Nothing Then  txtTrustee.Text
        txtTrustor.Text = ""
        txtTxYr.Text = ""
        txtUse.Text = ""
        txtYrBit.Text = ""
        txtZip.Text = ""
        chkReserved.Checked = False

        DateImported.Fecha = Now

        'new fields
        txtPropertyID.Text = ""
        txtUniqueID.Text = ""
        txtOwner1.Text = ""
        txtOwner2.Text = ""
        txtTrustorFirstName.Text = ""
        txtTrustorSecondName.Text = ""
        txtBathrooms.Text = ""
        txtBedrooms.Text = ""
        txtNBRooms.Text = ""
        MaskTr_PHONE.Value = ""

        txtTrustee.Text = ""
        MaskT_PHONE.Value = ""
        txtTrusteeHouseNumber.Text = ""
        txtTrusteeStreetName.Text = ""
        txtTrusteeUnitNBR.Text = ""
        txtFD_TRUSTEE_SALE_NBR.Text = ""
        txtTrusteeState.Text = ""
        txtTrusteeZip.Text = ""
        txtTrusteeCity.Text = ""

        txtBenefryHouseNumber.Text = ""
        txtBenefryStreetName.Text = ""
        txtBenefryUnitNBR.Text = ""
        txtBenefryAddressIdState.Text = ""
        txtBenefryZip.Text = ""
        txtBenefryCity.Text = ""

        txtUnits.Text = ""
        txtEstimatedValue.Text = ""
        txtTaxStatus1.Text = ""
        txtTaxStatus2.Text = ""
        txtTaxStatus3.Text = ""

        txtSiteState.Text = ""
        txtSiteCity.Text = ""
        txtSiteDirection.Text = ""
        txtSiteFraction.Text = ""
        txtSiteHouseNumber.Text = ""
        txtSitePostDir.Text = ""
        txtSiteStName.Text = ""
        txtSiteSuffix.Text = ""
        txtSiteUnitPrefix.Text = ""
        txtSiteUnitValue.Text = ""
        txtSiteZip.Text = ""

        txtMailCity.Text = ""
        txtMailAddressIdState.Text = ""
        txtMailZip.Text = ""
        txtMailZipPlus4.Text = ""
        txtMailDirection.Text = ""
        txtMailFraction.Text = ""
        txtMailHouseNumber.Text = ""
        txtMailPostDir.Text = ""
        txtMailStName.Text = ""
        txtMailSuffix.Text = ""
        txtMailUnitPrefix.Text = ""
        txtMailUnitValue.Text = ""

        txtOwnerStatus.Text = ""
        txtPoolCode.Text = ""
        txtPoolSQFT.Text = ""
        txtViewCode.Text = ""
        txtSA_ZONING.Text = ""
        txtSA_VAL_TRANSFER.Text = ""
        DateNOD.Limpiar()
        DateNTS.Limpiar()

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            IdNod = Request("id")
            If IdNod > 0 Then
                Fill()
            End If
        End If
    End Sub

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        Counter()
    End Sub

    Private Sub Counter()
        Using clase As New DataClassesDataContext
            Dim lista = DataFunctions.SelectNodData()
            '(From c In clase.NODs Where (c.ADDRESS.Contains(Session("txtAddress").ToString) Or c.ADDRESS Is Nothing) _
            '      And (c.ST_CITYSTATE.Contains(Session("txtCity").ToString) Or c.ST_CITYSTATE Is Nothing) _
            '      And (c.AMOUNT.Contains(Session("txtAmount").ToString) Or c.AMOUNT Is Nothing) _
            '      And (c.ASSPAR.Contains(Session("txtASSPAR").ToString) Or c.ASSPAR Is Nothing) _
            '      And (c.OWNER.Contains(Session("txtTrusterOwnerBenefry").ToString) Or c.BENEFRY.Contains(Session("txtTrusterOwnerBenefry").ToString) Or c.TRUSTOR.Contains(Session("txtTrusterOwnerBenefry").ToString) Or c.TRUSTEE.Contains(Session("txtTrusterOwnerBenefry").ToString)) _
            '      And (c.IdCounty = CInt(IIf(Session("ddlCounty") = 1, "3", Session("ddlCounty"))) Or _
            '           c.IdCounty = CInt(IIf(Session("ddlCounty") = 1, "4", Session("ddlCounty"))) Or _
            '           c.IdCounty = CInt(IIf(Session("ddlCounty") = 1, "5", Session("ddlCounty"))) Or _
            '           c.IdCounty = CInt(IIf(Session("ddlCounty") = 1, "6", Session("ddlCounty"))) Or Session("ddlCounty").ToString = 0) _
            '      And (c.IdStatus = CInt(Session("ddlStatus")) Or CInt(Session("ddlStatus")) = 0 Or (CInt(Session("ddlStatus")) = 11 And (c.IdStatus = 1 Or c.IdStatus = 3))) _
            '      And (c.Locked = 0) _
            '      And (c.Created >= CDate(Session("dcFrom"))) _
            '      And (c.Created <= CDate(Session("dcTo"))) _
            '      Select c Order By IdNod Descending).ToList
            Dim ListaNod As New ArrayList
            For i As Integer = 0 To lista.Count - 1
                ListaNod.Add(lista(i).IdNod)
                If lista(i).IdNod = IdNod Then Index = i
            Next
            Session("ListaNOD") = ListaNod
            lblCount.Text = lista.Count
        End Using
    End Sub

    Protected Sub btnDel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDel.Click
        Dim IdDel As Integer = IdNod
        Clean()
        IdNod = 0
        Dim allNods = DataFunctions.SelectNodData()
        Dim objNP = (From c In allNods Where c.IdNod > IdDel Order By c.IdNod Select c).Take(1).ToList()
        If objNP.Count > 0 Then
            IdNod = objNP(0).IdNod
        Else
            objNP = (From c In allNods Where c.IdNod < IdDel Order By c.IdNod Descending Select c).Take(1).ToList()
            If objNP.Count > 0 Then
                IdNod = objNP(0).IdNod
            End If
        End If
        '(From c In clase.NODs Where c.IdNod > IdDel And (c.ADDRESS.Contains(Session("txtAddress").ToString) Or c.ADDRESS Is Nothing) _
        '      And (c.ST_CITYSTATE.Contains(Session("txtCity").ToString) Or c.ST_CITYSTATE Is Nothing) _
        '      And (c.AMOUNT.Contains(Session("txtAmount").ToString) Or c.AMOUNT Is Nothing) _
        '      And (c.ASSPAR.Contains(Session("txtASSPAR").ToString) Or c.ASSPAR Is Nothing) _
        '      And (c.OWNER.Contains(Session("txtTrusterOwnerBenefry").ToString) Or c.BENEFRY.Contains(Session("txtTrusterOwnerBenefry").ToString) Or c.TRUSTOR.Contains(Session("txtTrusterOwnerBenefry").ToString) Or c.TRUSTEE.Contains(Session("txtTrusterOwnerBenefry").ToString)) _
        '      And (c.IdCounty = CInt(IIf(Session("ddlCounty") = 1, "3", Session("ddlCounty"))) Or _
        '           c.IdCounty = CInt(IIf(Session("ddlCounty") = 1, "4", Session("ddlCounty"))) Or _
        '           c.IdCounty = CInt(IIf(Session("ddlCounty") = 1, "5", Session("ddlCounty"))) Or _
        '           c.IdCounty = CInt(IIf(Session("ddlCounty") = 1, "6", Session("ddlCounty"))) Or Session("ddlCounty").ToString = 0) _
        '      And (c.IdStatus = CInt(Session("ddlStatus")) Or CInt(Session("ddlStatus")) = 0 Or (CInt(Session("ddlStatus")) = 11 And (c.IdStatus = 1 Or c.IdStatus = 3))) _
        '      And (c.Locked = 0) _
        '      And (c.Created >= CDate(Session("dcFrom"))) _
        '      And (c.Created <= CDate(Session("dcTo"))) _
        '      Order By c.IdNod Select c).ToList
        'If objNP.Count > 0 Then
        '	IdNod = objNP(0).IdNod
        'Else
        'objNP = (From c In clase.NODs Where c.IdNod < IdDel And (c.ADDRESS.Contains(Session("txtAddress").ToString) Or c.ADDRESS Is Nothing) _
        '		 And (c.ST_CITYSTATE.Contains(Session("txtCity").ToString) Or c.ST_CITYSTATE Is Nothing) _
        '		 And (c.AMOUNT.Contains(Session("txtAmount").ToString) Or c.AMOUNT Is Nothing) _
        '		 And (c.ASSPAR.Contains(Session("txtASSPAR").ToString) Or c.ASSPAR Is Nothing) _
        '		 And (c.OWNER.Contains(Session("txtTrusterOwnerBenefry").ToString) Or c.BENEFRY.Contains(Session("txtTrusterOwnerBenefry").ToString) Or c.TRUSTOR.Contains(Session("txtTrusterOwnerBenefry").ToString) Or c.TRUSTEE.Contains(Session("txtTrusterOwnerBenefry").ToString)) _
        '		 And (c.IdCounty = CInt(IIf(Session("ddlCounty") = 1, "3", Session("ddlCounty"))) Or _
        '					c.IdCounty = CInt(IIf(Session("ddlCounty") = 1, "4", Session("ddlCounty"))) Or _
        '					c.IdCounty = CInt(IIf(Session("ddlCounty") = 1, "5", Session("ddlCounty"))) Or _
        '					c.IdCounty = CInt(IIf(Session("ddlCounty") = 1, "6", Session("ddlCounty"))) Or Session("ddlCounty").ToString = 0) _
        '		 And (c.IdStatus = CInt(Session("ddlStatus")) Or CInt(Session("ddlStatus")) = 0 Or (CInt(Session("ddlStatus")) = 11 And (c.IdStatus = 1 Or c.IdStatus = 3))) _
        '		 And (c.Locked = 0) _
        '		 And (c.Created >= CDate(Session("dcFrom"))) _
        '		 And (c.Created <= CDate(Session("dcTo"))) _
        '		 Order By c.IdNod Descending Select c).ToList
        'If objNP.Count > 0 Then
        '	IdNod = objNP(0).IdNod
        'End If
        'End If
        Using clase As New DataClassesDataContext
            Dim objDel = (From c In clase.NODs Where c.IdNod = IdDel Select c).Single
            clase.NODs.DeleteOnSubmit(objDel)
            clase.SubmitChanges()
        End Using
        If IdNod > 0 Then
            Fill()
            Counter()
        Else
            btnClose_Click(Nothing, Nothing)
        End If
    End Sub

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Clean()
        IdNod = 0
    End Sub

    Protected Sub btnGoNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGoNext.Click
        Dim ListaNod As ArrayList = Session("ListaNOD")
        Index += 1
        If Index > ListaNod.Count - 1 Then Index = ListaNod.Count - 1
        IdNod = ListaNod(Index)
        Fill()
    End Sub

    Protected Sub btnGoLast_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGoLast.Click
        Dim ListaNod As ArrayList = Session("ListaNOD")
        Index = ListaNod.Count - 1
        IdNod = ListaNod(Index)
        Fill()
    End Sub

    Protected Sub btnGoPrev_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGoPrev.Click
        Dim ListaNod As ArrayList = Session("ListaNOD")
        Index -= 1
        If Index < 0 Then Index = 0
        IdNod = ListaNod(Index)
        Fill()
    End Sub

    Protected Sub btnGoFirst_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGoFirst.Click
        Dim ListaNod As ArrayList = Session("ListaNOD")
        Index = 0
        IdNod = ListaNod(Index)
        Fill()
    End Sub

    Protected Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        If Request.Browser.Browser = "IE" Then
            Page.ClientScript.RegisterStartupScript(Me.GetType, "script", "<script language='javascript'>window.returnValue = 1; window.close();</script>")
        Else
            Page.ClientScript.RegisterStartupScript(Me.GetType, "script", "<script language='javascript'>window.opener.document.forms(0).submit(); window.close();</script>")
        End If
    End Sub

    Protected Sub btnGo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGo.Click
        If IsNumeric(txtId.Text) Then
            Dim ListaNod As ArrayList = Session("ListaNOD")
            If ListaNod.IndexOf(CInt(txtId.Text)) > -1 Then
                Index = ListaNod.IndexOf(CInt(txtId.Text))
                IdNod = ListaNod(Index)
                Fill()
            End If
        End If
        txtId.Text = IdNod

    End Sub

    Protected Sub txtLoan_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTaxStatus1.PreRender, txtTaxStatus2.PreRender, txtTaxStatus3.PreRender, txtEstimatedValue.PreRender ' txtLoan.PreRender
        Dim txt As TextBox = sender
        txt.Attributes.Add("onkeypress", "return(currencyFormat(this,event));")
        txt.Attributes.Add("onblur", "moneda(this);")
        txt.Attributes.Add("onfocus", "limpiar(this);this.select();")
    End Sub
End Class
