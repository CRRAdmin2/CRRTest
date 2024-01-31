<%@ Page Language="VB" AutoEventWireup="false" CodeFile="NtsEd.aspx.vb" Inherits="NtsEd" %>
<%@ Register assembly="Infragistics2.WebUI.UltraWebGrid.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" namespace="Infragistics.WebUI.UltraWebGrid" tagprefix="igtbl" %>
<%@ Register Assembly="Infragistics2.WebUI.WebDataInput.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.WebUI.WebDataInput" TagPrefix="igtxt" %>

<%@ Register src="DateControl.ascx" tagname="DateControl" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta http-equiv="Cache-Control" content="No-Cache" />
    <link href="Estilo.css" rel="stylesheet" type="text/css" />
    <script src="general.js" language="javascript"></script>
    <style>
			.ButtonNew
			{
				background-color: Navy;
				color: White;
				font-weight: bold;
				}
    </style>
</head>
<body bgcolor="#DDDDEE">
    <form id="form1" runat="server">
    <asp:HiddenField ID="hdnIdNts" runat="server" Value="0" />
    <asp:HiddenField ID="hdnIndex" runat="server" Value="0" />
    <div class="Edition">
      <table cellpadding="3" cellspacing="1" border="0">
        <tr>
          <td valign="top">
            <table cellpadding="2" cellspacing="0" border="0">
              <tr>
                <td>IdNts</td>
                <td colspan="5">
                  <asp:TextBox ID="txtId" runat="server" Width="100px"></asp:TextBox>
                  <asp:Button ID="btnGo" runat="server" Text="Go" CssClass="ButtonNew" />
                  <asp:Label ID="lblId" runat="server" Text="0" Font-Bold="true" Visible="false"></asp:Label>
                  <FONT STYLE="color: red;">*** NEW FIELDS IN GREEN</FONT></td>
              </tr>
              <tr>
                <td>TDID</td>
                <td colspan="5"><asp:TextBox ID="txtTDID" runat="server" Width="194px"></asp:TextBox></td>
              </tr>
              <tr>
                <td>Prop. ID</td>
                <td colspan="5"><asp:TextBox ID="txtPropertyID" runat="server" Width="194px"></asp:TextBox></td>
              </tr>
              <tr>
                <td>Uniq. ID</td>
                <td colspan="5"><asp:TextBox ID="txtUniqueID" runat="server" Width="194px"></asp:TextBox></td>
              </tr>
              <tr>
                <td>County</td>
                <td colspan="5">
                  <asp:DropDownList ID="ddlCOUNTY" runat="server" AutoPostBack="True" Width="205px"
                     DataSourceID="sourceCounty" DataTextField="Name" DataValueField="IdCounty"
                     AppendDataBoundItems="true">
                      <asp:ListItem Value="">- Select -</asp:ListItem>  
                   </asp:DropDownList></td>
              </tr>
              <tr>
                <td>Owner 1</td>
                <td colspan="5"><asp:TextBox ID="txtOwner1" runat="server" Width="300px" MaxLength="50"></asp:TextBox></td>
              </tr>
              <tr>
                <td>Owner 2</td>
                <td colspan="5"><asp:TextBox ID="txtOwner2" runat="server" Width="300px" MaxLength="50"></asp:TextBox>
                &nbsp;&nbsp;Status <asp:TextBox ID="txtOwnerStatus" runat="server" Width="22px" MaxLength="2" ToolTip="Ownership Vesting"></asp:TextBox></td>
              </tr>
              <tr>
                <td colspan="100%"><br />
                  <table cellpadding="2" cellspacing="0" border="0" class="boxIsland">
                    <tr>
                      <th colspan="4" class="titleEd">Property</th>
                    </tr>
                    <tr>
                      <td>Address</td>
                      <td><asp:Label ID="lblAddress" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                      <td>House #</td>
                      <td><asp:TextBox ID="txtSiteHouseNumber" runat="server" MaxLength="20"></asp:TextBox>
                        &nbsp;&nbsp;&nbsp;
                        Fraction <asp:TextBox ID="txtSiteFraction" runat="server" Width="70px" MaxLength="10"></asp:TextBox></td>
                    </tr>
                    <tr>
                      <td>Direction</td>
                      <td><asp:TextBox ID="txtSiteDirection" runat="server" Width="22px" MaxLength="2"></asp:TextBox>
                        &nbsp;&nbsp;&nbsp;
                        St Name <asp:TextBox ID="txtSiteStName" runat="server" Width="200px" MaxLength="50"></asp:TextBox></td>
                    </tr>
                    <tr>
                      <td>Suffix</td>
                      <td><asp:TextBox ID="txtSiteSuffix" runat="server" Width="30px" MaxLength="4"></asp:TextBox>
                        &nbsp;&nbsp;&nbsp;
                        Post Dir <asp:TextBox ID="txtSitePostDir" runat="server" Width="22px" MaxLength="2"></asp:TextBox>
                        &nbsp;&nbsp;&nbsp;
                        Unit Prefix <asp:TextBox ID="txtSiteUnitPrefix" runat="server" Width="70px" MaxLength="10"></asp:TextBox></td>
                    </tr>
                    <tr>
                      <td>Unit Value</td>
                      <td><asp:TextBox ID="txtSiteUnitValue" runat="server" Width="40px" MaxLength="6"></asp:TextBox>
                        &nbsp;&nbsp;
                        City <asp:TextBox ID="txtSiteCity" runat="server" Width="130px" MaxLength="55"></asp:TextBox>
                        &nbsp;&nbsp;
                        ID State <asp:TextBox ID="txtSiteState" runat="server" Width="22px"></asp:TextBox>
                        &nbsp;&nbsp;
                        Zip <asp:TextBox ID="txtSiteZip" runat="server" Width="50px"></asp:TextBox>          
                        </td>              
                    </tr>
                  </table>
                </td>
              </tr>
              <!--TRUSTEE STARTS-->
              <tr>
                <td colspan="100%"><br />
                  <table cellpadding="2" cellspacing="0" border="0" class="boxIsland">
                    <tr>
                      <th colspan="100%" class="titleEd">Trustee</th>
                    </tr>
                    <tr>
                      <td>Trustee</td>
                      <td><asp:TextBox ID="txtTrustee" runat="server" Width="200px"></asp:TextBox>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        Phone<igtxt:WebMaskEdit ID="MaskT_PHONE" runat="server" 
                        InputMask="(###) ###-####" Width="100px"></igtxt:WebMaskEdit></td>
                    </tr>
                    <tr>
                      <td>House #</td>
                      <td><asp:TextBox ID="txtTrusteeHouseNumber" runat="server" Width="60px" MaxLength="10"></asp:TextBox>
                        &nbsp;&nbsp;
                        St Name <asp:TextBox ID="txtTrusteeStreetName" runat="server" Width="150px" MaxLength="50"></asp:TextBox>
                        &nbsp;&nbsp;
                        Unit NBR <asp:TextBox ID="txtTrusteeUnitNBR" runat="server" Width="40px" MaxLength="5"></asp:TextBox></td>
                    </tr>
                    <tr>
                      <td>City</td>
                      <td><asp:TextBox ID="txtTrusteeCity" runat="server" Width="200px"></asp:TextBox>
                        &nbsp;&nbsp;&nbsp;
                        ID State <asp:TextBox ID="txtTrusteeState" runat="server" Width="22px"></asp:TextBox>
                        &nbsp;&nbsp;&nbsp;
                        Zip <asp:TextBox ID="txtTrusteeZip" runat="server" Width="50px"></asp:TextBox></td>
                    </tr>
                  </table><br />
                </td>
              </tr>
              <!--TRUSTEE ENDS-->
              <tr>
                <td>Sale Date</td>
                <td><uc1:DateControl ID="DateControlSaleDate" runat="server" /></td>
                <td>Time</td>
                <td><asp:TextBox ID="txtTime" runat="server" Width="42px"></asp:TextBox></td>
                <td>Min Bid</td>
                <td><asp:TextBox ID="txtMidBid" runat="server" Width="85px"></asp:TextBox></td>
              </tr>
               <tr>
                <td>Site</td>
                <td colspan="3"><asp:TextBox ID="txtSite" runat="server" Width="230px"></asp:TextBox></td>
                <td>Sale No.</td>
                <td><asp:TextBox ID="txtSaleNo" runat="server" Width="85px"></asp:TextBox></td>
              </tr>
              <tr>
                <td colspan="100%"><br />
                  <table cellpadding="2" cellspacing="0" border="0" class="boxIsland">
                    <tr>
                      <th colspan="100%" class="titleEd">Trustor</th>
                    </tr>
                    <tr>
                      <td>Trustor</td>
                      <td><asp:Label ID="lblTrustor" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                      <td>1st Name</td>
                      <td><asp:TextBox ID="txtTrustorFirstName" runat="server" Width="300px"></asp:TextBox></td>
                    </tr>
                    <tr>
                      <td>2nd Name</td>
                      <td><asp:TextBox ID="txtTrustorSecondName" runat="server" Width="300px"></asp:TextBox></td>
                    </tr>
                    <tr>
                      <td>Phone</td>
                      <td><igtxt:WebMaskEdit ID="MaskTr_PHONE" runat="server" 
                        InputMask="(###) ###-####" Width="100px"></igtxt:WebMaskEdit></td>
                    </tr>
                  </table>
                </td>
              </tr>
              <tr>
                <td>Puch Date</td>
                <td><uc1:DateControl ID="DateControlPRCHS_DATE" runat="server" /></td>
                <td>Tax Val</td>
                <td><asp:TextBox ID="txtTaxVal" runat="server" Width="85px"></asp:TextBox></td>
                <td>Tx Yr</td>
                <td><asp:TextBox ID="txtTxYr" runat="server" Width="85px"></asp:TextBox></td>
              </tr>
              <tr>
                <td>SqFt</td>
                <td><asp:TextBox ID="txtSqFt" runat="server" Width="85px"></asp:TextBox></td>
                <td>Yr Bit</td>
                <td><asp:TextBox ID="txtYrBit" runat="server" Width="85px"></asp:TextBox></td>
                <td>Ho Ex</td>
                <td><asp:TextBox ID="txtHoEx" runat="server" Width="85px"></asp:TextBox></td>
              </tr>
              <tr>
                <td>Lot</td>
                <td><asp:TextBox ID="txtLot" runat="server" Width="85px"></asp:TextBox></td>
                <td>Use</td>
                <td><asp:TextBox ID="txtUse" runat="server" Width="85px"></asp:TextBox></td>
                <td>TMG</td>
                <td><asp:TextBox ID="txtTMG" runat="server" Width="85px"></asp:TextBox></td>
              </tr>
              <tr>
                <td>Rooms</td>
                <td><asp:TextBox ID="txtRooms" runat="server" Width="85px"></asp:TextBox></td>
                <td>Story</td>
                <td><asp:TextBox ID="txtStory" runat="server" Width="85px"></asp:TextBox></td>
                <td></td>
                <td></td>
              </tr>
              <tr>
                <td>Bathrooms</td>
                <td><asp:TextBox ID="txtBathrooms" runat="server" Width="85px"></asp:TextBox></td>
                <td>Bedrooms</td>
                <td><asp:TextBox ID="txtBedrooms" runat="server" Width="85px"></asp:TextBox></td>
                <td>NBRooms</td>
                <td><asp:TextBox ID="txtNBRooms" runat="server" Width="85px"></asp:TextBox></td>
              </tr>
              <tr>
                <td>Pool Cd</td>
                <td><asp:TextBox ID="txtPoolCode" runat="server" Width="22px" MaxLength="2"></asp:TextBox></td>
                <td>Pool SqFt</td>
                <td><asp:TextBox ID="txtPoolSQFT" runat="server" Width="60px" MaxLength="12"></asp:TextBox></td>
                <td>View Cd</td>
                <td><asp:TextBox ID="txtViewCode" runat="server" Width="22px" MaxLength="2"></asp:TextBox></td>
              </tr>
              <tr>
                <td colspan="100%"><br />
                  <table cellpadding="2" cellspacing="0" border="0" class="boxIsland">
                    <tr>
                      <th colspan="100%" class="titleEd">Benefry</th>
                    </tr>
                    <tr>
                      <td>Benefry</td>
                      <td><asp:TextBox ID="txtBenefry" runat="server" Width="200px"></asp:TextBox>
                        &nbsp;&nbsp;&nbsp;Phone
                        <igtxt:WebMaskEdit ID="MaskB_PHONE" runat="server" 
                          InputMask="(###) ###-####" Width="100px"></igtxt:WebMaskEdit>
                      </td>
                    </tr>
                    <tr>
                      <td>House #</td>
                      <td><asp:TextBox ID="txtBenefryHouseNumber" runat="server" Width="60px" MaxLength="10"></asp:TextBox>
                        &nbsp;&nbsp;
                        St Name <asp:TextBox ID="txtBenefryStreetName" runat="server" Width="150px" MaxLength="50"></asp:TextBox>
                        &nbsp;&nbsp;
                        Unit NBR <asp:TextBox ID="txtBenefryUnitNBR" runat="server" Width="40px" MaxLength="5"></asp:TextBox></td>
                    </tr>
                    <tr>
                      <td>City</td>
                      <td><asp:TextBox ID="txtBenefryCity" runat="server" Width="200px"></asp:TextBox>
                        &nbsp;&nbsp;&nbsp;ID State <asp:TextBox ID="txtBenefryAddressIdState" runat="server" Width="22px"></asp:TextBox>
                        &nbsp;&nbsp;&nbsp;Zip <asp:TextBox ID="txtBenefryZip" runat="server" Width="50px"></asp:TextBox></td>
                    </tr>
                  </table>
                </td>
              </tr>
           </table>
          </td>
          <td width="20px">
          
          </td>
          <td class="ColumnEd">
            <table cellpadding="0" cellspacing="0" border="0" width="100%">
              <tr>
                <td colspan="100%" align="right"><asp:Label ID="lblCount" runat="server" Text="0"></asp:Label></td>
              </tr>
              <tr>
                <td>APN</td>
                <td><igtxt:WebMaskEdit ID="MaskASSPAR" runat="server"></igtxt:WebMaskEdit></td>
              </tr>
              <tr>
                <td></td>
                <td></td>
              </tr>
            </table><br />
            <table cellpadding="2" cellspacing="0" border="0" class="boxIsland">
              <tr>
                <th class="titleEd">Trust Deeds</th>
              </tr>
              <tr>
                <td>
                  <table cellpadding="1" cellspacing="0" border="0" align="center">
                    <tr>
                      <td><asp:RadioButton ID="radTD1_A" runat="server" GroupName="TD_A" /></td>
                      <td><asp:TextBox ID="txtTD1" runat="server" Width="100px" /></td>
                      <td><uc1:DateControl ID="DateControlTD1_D" runat="server" /></td>
                    </tr>
                    <tr>
                      <td><asp:RadioButton ID="radTD2_A" runat="server" GroupName="TD_A" /></td>
                      <td><asp:TextBox ID="txtTD2" runat="server" Width="100px"></asp:TextBox></td>
                      <td><uc1:DateControl ID="DateControlTD2_D" runat="server" /></td>
                    </tr>
                    <tr>
                      <td><asp:RadioButton ID="radTD3_A" runat="server" GroupName="TD_A" /></td>
                      <td><asp:TextBox ID="txtTD3" runat="server" Width="100px"></asp:TextBox></td>
                      <td><uc1:DateControl ID="DateControlTD3_D" runat="server" /></td>
                    </tr>
                    <tr>
                      <td><asp:RadioButton ID="radTD4_A" runat="server" GroupName="TD_A" /></td>
                      <td><asp:TextBox ID="txtTD4" runat="server" Width="100px"></asp:TextBox></td>
                      <td><uc1:DateControl ID="DateControlTD4_D" runat="server" /></td>
                    </tr>
                    <tr>
                      <td><asp:RadioButton ID="radTD5_A" runat="server" GroupName="TD_A" /></td>
                      <td><asp:TextBox ID="txtTD5" runat="server" Width="100px"></asp:TextBox></td>
                      <td><uc1:DateControl ID="DateControlTD5_D" runat="server" /></td>
                    </tr>
                    <tr>
                      <td><asp:RadioButton ID="radTD6_A" runat="server" GroupName="TD_A" /></td>
                      <td><asp:TextBox ID="txtTD6" runat="server" Width="100px"></asp:TextBox></td>
                      <td><uc1:DateControl ID="DateControlTD6_D" runat="server" /></td>
                    </tr>
                  </table>
                </td>
              </tr>
            </table><br />
            <table cellpadding="1" cellspacing="0" border="0">
              <tr>
                <td>Loan</td>
                <td><asp:TextBox ID="txtLoan" runat="server" Width="120px"></asp:TextBox>
                <asp:TextBox ID="txtLoanAmt" runat="server" Width="120px" Visible="false"></asp:TextBox></td>
              </tr>
              <tr>
                <td>NOD</td>
                <td><asp:TextBox ID="txtNOD" runat="server" Width="120px"></asp:TextBox></td>
                <td><uc1:DateControl ID="DateNOD" runat="server" ToolTip="NOD Recording Date" /></td>
              </tr>
              <tr>
                <td>NTS</td>
                <td><asp:TextBox ID="txtNTS" runat="server" Width="120px"></asp:TextBox></td>
                <td><uc1:DateControl ID="DateNTS" runat="server" ToolTip="NTS Recording Date" /></td>
              </tr>
              <tr>
                <td>Imported</td>
                <td><uc1:DateControl ID="DateImported" runat="server" /></td>
                <td>Status <asp:DropDownList ID="ddlStatus" runat="server" DataSourceID="sourceStatus"
              DataTextField="Description" DataValueField="IdStatus" Enabled="false"></asp:DropDownList></td>
              </tr>
              <tr>
                <td>Units</td>
                <td><asp:TextBox ID="txtUnits" runat="server" Width="120px"></asp:TextBox></td>
              </tr>
            </table>
            <br />
            <table cellpadding="2" cellspacing="0" border="0" class="boxIsland">
              <tr>
                <th colspan="100%" class="titleEd">Mail</th>
              </tr>
              <tr>
                <td>House #</td>
                <td><asp:TextBox ID="txtMailHouseNumber" runat="server" MaxLength="10"></asp:TextBox>
                  &nbsp;&nbsp;&nbsp;
                  Fraction <asp:TextBox ID="txtMailFraction" runat="server" Width="70px" MaxLength="10"></asp:TextBox></td>
              </tr>
              <tr>
                <td>Direction</td>
                <td><asp:TextBox ID="txtMailDirection" runat="server" Width="22px" MaxLength="2"></asp:TextBox>
                  &nbsp;&nbsp;&nbsp;
                  St Name <asp:TextBox ID="txtMailStName" runat="server" Width="200px" MaxLength="50"></asp:TextBox></td>
              </tr>
              <tr>
                <td>Suffix</td>
                <td><asp:TextBox ID="txtMailSuffix" runat="server" Width="30px" MaxLength="4"></asp:TextBox>
                  &nbsp;&nbsp;&nbsp;
                  Post Dir <asp:TextBox ID="txtMailPostDir" runat="server" Width="22px" MaxLength="2"></asp:TextBox>
                  &nbsp;&nbsp;&nbsp;
                  Unit Prefix <asp:TextBox ID="txtMailUnitPrefix" runat="server" Width="70px" MaxLength="10"></asp:TextBox></td>
              </tr>
              <tr>
                <td>Unit Value</td>
                <td><asp:TextBox ID="txtMailUnitValue" runat="server" Width="40px" MaxLength="6"></asp:TextBox>
                  &nbsp;&nbsp;&nbsp;
                  City <asp:TextBox ID="txtMailCity" runat="server" Width="200px" MaxLength="55"></asp:TextBox></td>
              </tr>
              <tr>
                <td>ID State</td>
                <td><asp:TextBox ID="txtMailAddressIdState" runat="server" Width="22px"></asp:TextBox>
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                  Zip <asp:TextBox ID="txtMailZip" runat="server" Width="35px" MaxLength="5"></asp:TextBox>
                  &nbsp;&nbsp;+4 <asp:TextBox ID="txtMailZipPlus4" runat="server" Width="30px" MaxLength="4"></asp:TextBox>
                </td>
              </tr>
            </table><br />
            <table cellpadding="2" cellspacing="0" border="0" class="boxIsland">
              <tr>
                <th colspan="4" class="titleEd">Property</th>
              </tr>
              <tr>
                <td>Estimated Value</td>
                <td><asp:TextBox ID="txtEstimatedValue" runat="server" Width="252px"></asp:TextBox></td>
              </tr>
              <tr>
                <td>Tax Status 1</td>
                <td><asp:TextBox ID="txtTaxStatus1" runat="server" Width="252px"></asp:TextBox></td>
              </tr>
              <tr>
                <td>Tax Status 2</td>
                <td><asp:TextBox ID="txtTaxStatus2" runat="server" Width="252px"></asp:TextBox></td>
              </tr>
              <tr>
                <td>Tax Status 3</td>
                <td><asp:TextBox ID="txtTaxStatus3" runat="server" Width="252px"></asp:TextBox></td>
              </tr>
            </table>
            <br />
            <table cellpadding="1" cellspacing="0" border="0">
              <tr>
                <td>SA ZONING</td>
                <td><asp:TextBox ID="txtSA_ZONING" runat="server" Width="120px" CssClass="new0511" MaxLength="13"></asp:TextBox></td>
              </tr>
              <tr>
                <td>Value Transfer</td>
                <td><asp:TextBox ID="txtSA_VAL_TRANSFER" runat="server" Width="120px" CssClass="new0511" MaxLength="13"></asp:TextBox></td>
              </tr>
            </table>
          </td>
        </tr>
        <tr>
          <td colspan="100%">
            <table cellpadding="2" cellspacing="0" border="0">
              <tr>
                <td>Legal</td>
                <td><asp:TextBox ID="txtLegal" runat="server" Width="377px"></asp:TextBox></td>
              </tr>
              <tr>
                <td>Remarks</td>
                <td><asp:TextBox ID="txtRemarks" runat="server" Width="613px"></asp:TextBox></td>
              </tr>
            </table>
          </td>
        </tr>
      </table>
    </div>
    <div class="buttonsDown">
      <table cellpadding=0 cellspacing=0 border=0>
        <tr>
          <td>
            <asp:Button ID="btnGoFirst" runat="server" Text="<<" Width="35px" CssClass="ButtonNew" />
            <asp:Button ID="btnGoPrev" runat="server" Text="<" Width="35px" CssClass="ButtonNew" />
            <asp:Button ID="btnGoNext" runat="server" Text=">" Width="35px" CssClass="ButtonNew" />
            <asp:Button ID="btnGoLast" runat="server" Text=">>" Width="35px" CssClass="ButtonNew" />
          </td>
          <td style="width: 100px"></td>
          <td>
            <asp:Button ID="btnAdd" runat="server" Text="Add" Width="50px" CssClass="ButtonNew" />
          </td>
          <td style="width: 10px"></td>
          <td>
            <asp:Button ID="btnSave" runat="server" Text="Save" Width="50px" CssClass="ButtonNew" />
          </td>
          <td style="width: 10px"></td>
          <td>
            <asp:Button ID="btnDel" runat="server" Text="Del" Width="50px" 
              onclientclick="return confirm('Are you sure to delete?');" CssClass="ButtonNew" />
          </td>
          <td style="width: 10px"></td>
          <td>
            <asp:Button ID="btnClose" runat="server" Text="Close" Width="50px" CssClass="ButtonNew" />
          </td>
          <td style="width: 10px"></td>
          <td colspan="100%" align="right">
              <asp:CheckBox ID="chkReserved" runat="server" Text="Reserved" />
          </td>
        </tr>
      </table>
    
    </div>
    <asp:LinqDataSource ID="sourceCounty" runat="server" 
      ContextTypeName="DataClassesDataContext" 
      Select="new (IdState + ' ' + CountyName as Name, IdCounty)" TableName="Counties" OrderBy="IdState, CountyName">
    </asp:LinqDataSource>
    <asp:LinqDataSource ID="sourceStatus" runat="server" 
    ContextTypeName="DataClassesDataContext" 
    Select="new (IdStatus, Description)" TableName="Status">
  </asp:LinqDataSource>
  <asp:TextBox ID="txtOwner" runat="server" Width="300px"></asp:TextBox>
                            <asp:TextBox ID="txtTrustor" runat="server" Width="200px" Visible="false"></asp:TextBox>
                        <asp:TextBox ID="txtAddress" runat="server" Width="250px" Visible="false"></asp:TextBox>
                        <asp:TextBox ID="txtCity" runat="server" Visible="false"></asp:TextBox>
                        <asp:TextBox ID="txtZip" runat="server" Width="50px" Visible="false"></asp:TextBox>
                        &nbsp;&nbsp;&nbsp;ID State <asp:TextBox ID="txtAddressIdState" runat="server" Width="22px" MaxLength="2" Visible="false"></asp:TextBox>
    </form>
</body>
</html>
