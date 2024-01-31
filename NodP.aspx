<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="NodP.aspx.vb" Inherits="NodP" %>

<%@ Register assembly="Infragistics2.WebUI.UltraWebGrid.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" namespace="Infragistics.WebUI.UltraWebGrid" tagprefix="igtbl" %>
<%@ Register Assembly="Infragistics2.WebUI.WebDataInput.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.WebUI.WebDataInput" TagPrefix="igtxt" %>

<%@ Register src="DateControl.ascx" tagname="DateControl" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="scripts/jquery-3.3.1.min.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">  
<table cellpadding="0" cellspacing="0" border="0">
  <tr>
    <td class="title">N<br />O<br />D
    </td>
    <td>
      <table cellpadding="1" cellspacing="1" border="0">
        <tr>
          <td>Status</td>
          <td><asp:DropDownList ID="ddlStatus" runat="server" DataSourceID="sourceStatus"
              DataTextField="Description" DataValueField="IdStatus"></asp:DropDownList></td>
          <td style="width: 20px"></td>
          <td>Trustor/Owner/Benefry:</td>
          <td><asp:TextBox ID="txtTrusterOwnerBenefry" runat="server"></asp:TextBox></td>
          <td style="width: 20px"></td>
          <td>Address:</td>
          <td><asp:TextBox ID="txtAddress" runat="server"></asp:TextBox></td>
          <td style="width: 20px"></td>
        </tr>
      </table>
      <table cellpadding="1" cellspacing="1" border="0">
        <tr>
            <td>States:</td>
            <td colspan="11">
                <asp:CheckBoxList id="chklstStates" 
                   AutoPostBack="True"
                   CellPadding="5"
                   CellSpacing="5"
                   RepeatColumns="10"
                   RepeatDirection="Horizontal"
                   RepeatLayout="Flow"
                   TextAlign="Right"
                   runat="server"
                   DataSourceID="sourceState"
                   DataTextField="StateName" 
                   DataValueField="IdState">
                </asp:CheckBoxList>
            </td>
        </tr>
        <tr>
          <td>County:</td>
          <td><asp:DropDownList ID="ddlCounty" runat="server" 
              DataSourceID="sourceCounty" DataTextField="Name" DataValueField="IdCounty"></asp:DropDownList></td>
          <td style="width: 20px"></td>
          <td>City:</td>
          <td><asp:TextBox ID="txtCity" runat="server"></asp:TextBox></td>
          <td style="width: 20px"></td>
          <td>Del Amt:</td>
          <td><asp:TextBox ID="txtAmount" runat="server" Width="50px"></asp:TextBox>
              <asp:TextBox ID="txtZipcode" runat="server" Width="71px" ReadOnly="true" Visible="false"></asp:TextBox></td>
          <td style="width: 20px"></td>
          <td>ASSPAR:</td>
          <td><asp:TextBox ID="txtASSPAR" runat="server" Width="50px"></asp:TextBox></td>
          <td style="width: 20px"></td>
        </tr>
      </table>
    </td>
    <td>
      <table cellpadding="1" cellspacing="1" border="0">
        <tr>
          <td rowspan="2">Imported&nbsp;&nbsp;&nbsp;</td>
          <td>From:</td>
          <td><uc1:DateControl ID="dcFrom" runat="server" /></td>
          <td style="width: 20px"></td>
          <td>Records: <asp:Label ID="lblCount" runat="server" Text="0" Font-Bold="true"></asp:Label></td>
        </tr>
        <tr>
          <td>To:</td>
          <td><uc1:DateControl ID="dcTo" runat="server" /></td>
          <td style="width: 20px"></td>
          <td><asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="ButtonNew" /></td>
        </tr>
      </table>
    </td>
  </tr>
</table>
<div id="divGridPrincipal" style="overflow:scroll; width:900%;">
</div>
	<input type="hidden" id="hdnselected" runat="server" />
      <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
        CellPadding="3" DataKeyNames="IdNod" DataSourceID="LinqDataSource1" 
        ForeColor="Black" GridLines="Vertical" AllowPaging="True" 
        AllowSorting="True" RowStyle-Wrap="False" PageSize="20" TabIndex="10" >
<RowStyle Wrap="False"></RowStyle>
        <Columns>
          <asp:TemplateField>
            <HeaderTemplate>
              <asp:CheckBox ID="chkSelectAll" runat="server" OnCheckedChanged="chkSelectAll_CheckedChanged" AutoPostBack="true" />
            </HeaderTemplate>
            <ItemTemplate>
              <asp:CheckBox ID="chkSelect" runat="server"/>
            </ItemTemplate>
          </asp:TemplateField>
          <asp:BoundField DataField="IdNod" HeaderText="IdNod" InsertVisible="False" 
            ReadOnly="True" SortExpression="IdNod" />
          <asp:TemplateField HeaderText="STATUS">
            <ItemTemplate>
              <%# Eval("Status.Description")%>
            </ItemTemplate>
          </asp:TemplateField>
          <asp:TemplateField HeaderText="COUNTY">
            <ItemTemplate>
              <asp:Label ID="lblCounty" runat="server"></asp:Label>
            </ItemTemplate>
          </asp:TemplateField>
          <asp:BoundField DataField="LST" HeaderText="LST" 
            SortExpression="LST" />
          <asp:BoundField DataField="ADDRESS" HeaderText="ADDRESS" 
            SortExpression="ADDRESS" />
          <asp:BoundField DataField="ST_CITYSTATE" HeaderText="CITY" 
            SortExpression="ST_CITYSTATE" />
          <asp:BoundField DataField="ZIP" HeaderText="ZIP" SortExpression="ZIP" />
          <asp:BoundField DataField="TG" HeaderText="TG" SortExpression="TG" />
          <asp:BoundField DataField="HOEX" HeaderText="HOEX" SortExpression="HOEX" />
          <asp:BoundField DataField="TRUSTOR" HeaderText="TRUSTOR" 
            SortExpression="TRUSTOR" />
          <asp:BoundField DataField="OWNER" HeaderText="OWNER" 
            SortExpression="OWNER" />
          <asp:BoundField DataField="BENEFRY" HeaderText="BENEFRY" 
            SortExpression="BENEFRY" />
          <asp:TemplateField HeaderText="B_PHONE">
            <HeaderTemplate>
                <asp:LinkButton ID="LinkButtonB_PHONE" runat="server" Text="B_PHONE" ForeColor="White" 
                CommandName="Sort" CommandArgument="B_PHONE"></asp:LinkButton>
            </HeaderTemplate>
            <ItemTemplate>
              <igtxt:WebMaskEdit ID="MaskB_PHONE" runat="server" 
                  InputMask="(###) ###-####" Width="100px" Height="15px" BorderStyle="None" ReadOnly="true"
                  Font-Size="10px" Value='<%# Replace(Replace(Eval("B_PHONE"), " ", ""), "-", "") %>' CssClass="TextGrid"></igtxt:WebMaskEdit>
            </ItemTemplate>
          </asp:TemplateField>
          <asp:BoundField DataField="TAX_VALUE" HeaderText="TAX_VALUE" 
            SortExpression="TAX_VALUE" />
          <asp:BoundField DataField="TX_YR" HeaderText="TX_YR" 
            SortExpression="TX_YR" />
          <asp:BoundField DataField="PRCHS_DATE" HeaderText="PRCHS_DATE" 
            SortExpression="PRCHS_DATE" DataFormatString="{0:MM/dd/yyyy}" />
          <asp:BoundField DataField="AMOUNT" HeaderText="DEL AMT" 
            SortExpression="AMOUNT" />
          <asp:BoundField DataField="TD1_A" HeaderText="TD1_A" 
            SortExpression="TD1_A" />
          <asp:BoundField DataField="TD1" HeaderText="TD1" SortExpression="TD1" />
          <asp:BoundField DataField="TD1_D" HeaderText="TD1_D" 
            SortExpression="TD1_D" DataFormatString="{0:MM/dd/yyyy}" />
          <asp:BoundField DataField="TD2_A" HeaderText="TD2_A" SortExpression="TD2_A" />
          <asp:BoundField DataField="TD2" HeaderText="TD2" 
            SortExpression="TD2" />
          <asp:BoundField DataField="TD2_D" HeaderText="TD2_D" 
            SortExpression="TD2_D" DataFormatString="{0:MM/dd/yyyy}" />
          <asp:BoundField DataField="TD3_A" HeaderText="TD3_A" SortExpression="TD3_A" />
          <asp:BoundField DataField="TD3" HeaderText="TD3" SortExpression="TD3" />
          <asp:BoundField DataField="TD3_D" HeaderText="TD3_D" SortExpression="TD3_D" DataFormatString="{0:MM/dd/yyyy}" />
          <asp:BoundField DataField="TD4_A" HeaderText="TD4_A" SortExpression="TD4_A" />
          <asp:BoundField DataField="TD4" HeaderText="TD4" SortExpression="TD4" />
          <asp:BoundField DataField="TD4_D" HeaderText="TD4_D" SortExpression="TD4_D" DataFormatString="{0:MM/dd/yyyy}" />
          <asp:BoundField DataField="TD5_A" HeaderText="TD5_A" SortExpression="TD5_A" />
          <asp:BoundField DataField="TD5" HeaderText="TD5" SortExpression="TD5" />
          <asp:BoundField DataField="TD5_D" HeaderText="TD5_D" SortExpression="TD5_D" DataFormatString="{0:MM/dd/yyyy}" />
          <asp:BoundField DataField="TD6_A" HeaderText="TD6_A" SortExpression="TD6_A" />
          <asp:BoundField DataField="TD6" HeaderText="TD6" SortExpression="TD6" />
          <asp:BoundField DataField="TD6_D" HeaderText="TD6_D" SortExpression="TD6_D" DataFormatString="{0:MM/dd/yyyy}" />
          <asp:BoundField DataField="USE" HeaderText="USE" SortExpression="USE" />
          <asp:BoundField DataField="YRBLT" HeaderText="YRBLT" SortExpression="YRBLT" />
          <asp:BoundField DataField="SQFT" HeaderText="SQFT" SortExpression="SQFT" />
          <asp:BoundField DataField="STORY" HeaderText="STORY" SortExpression="STORY" />
          <asp:BoundField DataField="ROOMS" HeaderText="ROOMS" SortExpression="ROOMS" />
          <asp:BoundField DataField="LOT" HeaderText="LOT" SortExpression="LOT" />
          <asp:BoundField DataField="LEGAL" HeaderText="LEGAL" SortExpression="LEGAL" />
          <asp:BoundField DataField="ASSPAR" HeaderText="ASSPAR" 
            SortExpression="ASSPAR" />
          <asp:BoundField DataField="NOD" HeaderText="NOD" SortExpression="NOD" />
          <asp:BoundField DataField="LOAN" HeaderText="LOAN" SortExpression="LOAN" />
          <asp:BoundField DataField="TDID" HeaderText="TDID" SortExpression="TDID" />
          <asp:BoundField DataField="REMARKS" HeaderText="REMARKS" 
            SortExpression="REMARKS" />
          <asp:BoundField DataField="L_DATE" HeaderText="L_DATE" 
            SortExpression="L_DATE" DataFormatString="{0:MM/dd/yyyy}" />
          <asp:BoundField DataField="ASOF" HeaderText="ASOF" SortExpression="ASOF" DataFormatString="{0:MM/dd/yyyy}" />
          <asp:BoundField DataField="DELNIQ" HeaderText="DELNIQ" 
            SortExpression="DELNIQ" DataFormatString="{0:MM/dd/yyyy}" />
          <asp:BoundField DataField="TRUSTEE" HeaderText="TRUSTEE" 
            SortExpression="TRUSTEE" />
          <asp:BoundField DataField="SALE_TIME" HeaderText="SALE_TIME" 
            SortExpression="SALE_TIME" />
          <asp:BoundField DataField="NTS" HeaderText="NTS" 
            SortExpression="NTS" />
          <asp:TemplateField HeaderText="T_PHONE">
            <ItemTemplate>
              <igtxt:WebMaskEdit ID="MaskT_PHONE" runat="server" 
                  InputMask="(###) ###-####" Width="100px" Height="15px" BorderStyle="None" ReadOnly="true"
                  Font-Size="10px" Value='<%# Eval("T_PHONE") %>' CssClass="TextGrid"></igtxt:WebMaskEdit>
            </ItemTemplate>
          </asp:TemplateField>
          <asp:BoundField DataField="SALE_DATE" HeaderText="SALE_DATE" 
            SortExpression="SALE_DATE" DataFormatString="{0:MM/dd/yyyy}" />
          <asp:BoundField DataField="SITE" HeaderText="SITE" 
            SortExpression="SITE" />
          <asp:BoundField DataField="Created" HeaderText="Imported" 
            SortExpression="Created" DataFormatString="{0:MM/dd/yyyy}" />
          <asp:BoundField DataField="Modified" HeaderText="Modified" 
            SortExpression="Modified" DataFormatString="{0:MM/dd/yyyy}" />
          <asp:BoundField DataField="IdStatus" HeaderText="IdStatus" 
            SortExpression="IdStatus" />
          <asp:BoundField DataField="IdStatusDBF" HeaderText="IdStatusDBF" 
            SortExpression="IdStatusDBF" />
          <asp:BoundField DataField="DateDBF" HeaderText="DateDBF" 
            SortExpression="DateDBF" DataFormatString="{0:MM/dd/yyyy}" />
          <asp:BoundField DataField="Locked" HeaderText="Locked" 
            SortExpression="Locked" />
          <asp:BoundField DataField="SA_PROPERTY_ID" HeaderText="SA_PROPERTY_ID" SortExpression="SA_PROPERTY_ID" />
          <asp:BoundField DataField="SR_UNIQUE_ID" HeaderText="SR_UNIQUE_ID" SortExpression="SR_UNIQUE_ID" />
          <asp:BoundField DataField="OWNER1" HeaderText="OWNER1" SortExpression="OWNER1" />
          <asp:BoundField DataField="OWNER2" HeaderText="OWNER2" SortExpression="OWNER2" />
          <asp:BoundField DataField="TRUSTOR_FIRST_NAME" HeaderText="TRUSTOR_FIRST_NAME" SortExpression="TRUSTOR_FIRST_NAME" />
          <asp:BoundField DataField="TRUSTOR_LAST_NAME" HeaderText="TRUSTOR_LAST_NAME" SortExpression="TRUSTOR_LAST_NAME" />
          <asp:BoundField DataField="BATHROOMS" HeaderText="BATHROOMS" SortExpression="BATHROOMS" />
          <asp:BoundField DataField="BEDROOMS" HeaderText="BEDROOMS" SortExpression="BEDROOMS" />
          <asp:BoundField DataField="ADDRESS_ID_STATE" HeaderText="ADDRESS_ID_STATE" SortExpression="ADDRESS_ID_STATE" />
          <asp:BoundField DataField="TR_PHONE" HeaderText="TR_PHONE" SortExpression="TR_PHONE" />
          <asp:BoundField DataField="TRUSTEE_ADDRESS" HeaderText="TRUSTEE_ADDRESS" SortExpression="TRUSTEE_ADDRESS" />
          <asp:BoundField DataField="TRUSTEE_CITY" HeaderText="TRUSTEE_CITY" SortExpression="TRUSTEE_CITY" />
          <asp:BoundField DataField="TRUSTEE_ZIP" HeaderText="TRUSTEE_ZIP" SortExpression="TRUSTEE_ZIP" />
          <asp:BoundField DataField="TRUSTEE_ADDRESS_ID_STATE" HeaderText="TRUSTEE_ADDRESS_ID_STATE" SortExpression="TRUSTEE_ADDRESS_ID_STATE" />
          <asp:BoundField DataField="BENE_ADDRESS" HeaderText="BENE_ADDRESS" SortExpression="BENE_ADDRESS" />
          <asp:BoundField DataField="BENE_CITY" HeaderText="BENE_CITY" SortExpression="BENE_CITY" />
          <asp:BoundField DataField="BENE_ZIP" HeaderText="BENE_ZIP" SortExpression="BENE_ZIP" />
          <asp:BoundField DataField="BENE_ADDRESS_ID_STATE" HeaderText="BENE_ADDRESS_ID_STATE" SortExpression="BENE_ADDRESS_ID_STATE" />
          <asp:BoundField DataField="UNITS" HeaderText="UNITS" SortExpression="UNITS" />
          <asp:BoundField DataField="ESTIMATED_PROP_VALUE" HeaderText="ESTIMATED_PROP_VALUE" SortExpression="ESTIMATED_PROP_VALUE" />
          <asp:BoundField DataField="PROP_TAX_STATUS_1" HeaderText="PROP_TAX_STATUS_1" SortExpression="PROP_TAX_STATUS_1" />
          <asp:BoundField DataField="PROP_TAX_STATUS_2" HeaderText="PROP_TAX_STATUS_2" SortExpression="PROP_TAX_STATUS_2" />
          <asp:BoundField DataField="PROP_TAX_STATUS_3" HeaderText="PROP_TAX_STATUS_3" SortExpression="PROP_TAX_STATUS_3" />
          <asp:BoundField DataField="NOD_REC_DT" HeaderText="NOD_REC_DT" 
            SortExpression="NOD_REC_DT" DataFormatString="{0:MM/dd/yyyy}" />
        </Columns>
        <FooterStyle BackColor="#CCCCCC" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Left" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle CssClass="gridAlternado" />
      </asp:GridView>
<table cellpadding="1" cellspacing="1" border="0" title="more than 20 records per page can cause slow speed">
  <tr>
    <td style="white-space: nowrap;">
        <asp:Button ID="btnDel" runat="server" Text="Delete" 
              onclientclick="jsDelete()" CssClass="ButtonNew" /><br />
        <script type="text/javascript">
            function jsDelete() {
                var $checkboxes = $('[id*="_chkSelect"]:checked');
                var ids = [];
                var i;
                for (i = 0; i < $checkboxes.length; i++) {
                    var id = $($($checkboxes[i]).parent().parent().children()[1]).text();
                    if (!isNaN(id))
                        ids.push(id);
                }
                if (ids.length > 0) {
                    if (confirm('Are you sure to delete?')) {
                        $.ajax({
                            url: 'NodP.aspx/deleteRows',
                            method: 'post',
                            contentType: "application/json",
                            data: '{"ids":' + JSON.stringify(ids) + "}",
                            dataType: "json",
                            success: function (data) {
                                alert('Properties deleted')
                            },
                            error: function (err) {
                                alert(err);
                            }
                        });
                    }
                }
            }
        </script>
        <asp:Button ID="btnToNTS" runat="server" Text="To NTS" CssClass="ButtonNew" />
        <asp:CheckBox ID="chkSelectAll" runat="server" Text="Select All" Checked="true" Visible="false" /></td>
    <td style="width: 30px"></td>
    <td style="white-space: nowrap;">Page Size:</td>
    <td><asp:TextBox ID="txtPageSize" runat="server" Width="25" TabIndex="10">20</asp:TextBox></td>
    <td><asp:Button ID="btnSubmit" runat="server" Text="Repage" TabIndex="11" CssClass="ButtonNew" /></td>
    <td style="width: 30px"></td>
    <td><asp:Button ID="btnSaveChanges" runat="server" Text="Reserve" CssClass="ButtonNew" /></td>
    <td style="width: 30px">&nbsp;</td>
    <td><input type="button" value="Add a New One" onclick="javascript:NodEd(0)" class="ButtonNew" /></td>
    <td style="width: 30px"></td>
    <td style="text-align: right;"></td>
    <td><uc1:DateControl ID="DateControlCreateDBF" runat="server" CssClass="TextDate" /></td>
    <td>
      <asp:Button ID="btnCreateDBF" runat="server" Text="Create DBF" CssClass="ButtonNew" /><br />
      <asp:Button ID="btnCreateDBFnFTP" runat="server" Text="Create DBF & FTP" CssClass="ButtonNew" /><br />
      <asp:Button ID="btnDownload" runat="server" Text="Create DBF & Download" CssClass="ButtonNew" />
    </td>
  </tr>
</table>
<table cellpadding="1" cellspacing="1" border="0">
  <tr>
    <td></td>
    <td><asp:Button ID="btnPublish" runat="server" Text="Publish All Completed Files" Visible="false" CssClass="ButtonNew" /></td>
  </tr>
</table>
<div class="relieve">
<div onclick="getElementById('divCheckboxColumns').style.visibility = 'visible';" style="color: White; cursor: hand;">Show/Hide Columns</div>
<div id="divCheckboxColumns" style="visibility: hidden;">
  <asp:CheckBoxList ID="chkColumns" runat="server" RepeatDirection="Horizontal" 
      Width="100%" RepeatColumns="7">
    </asp:CheckBoxList><asp:Button ID="btnShowHideCols" runat="server" Text="Affect Columns" CssClass="ButtonNew" />
</div></div>
<asp:Panel ID="panelChk" runat="server" Visible="false">
</asp:Panel>
  <asp:LinqDataSource ID="LinqDataSource1" runat="server" >
     <%--ContextTypeName="DataClassesDataContext" TableName="NODs" OrderBy="IdNod DESC"  EnableViewState="true">
       Where="(ADDRESS.Contains(@ADDRESS) || ADDRESS = NULL) && (ST_CITYSTATE.Contains(@CITY) || ST_CITYSTATE = NULL) && (AMOUNT.Contains(@AMOUNT) || AMOUNT = NULL) 
        && (ASSPAR.Contains(@ASSPAR) || ASSPAR = NULL)
        && (OWNER.Contains(@TRUSTOR) || BENEFRY.Contains(@TRUSTOR) || TRUSTOR.Contains(@TRUSTOR) || TRUSTEE.Contains(@TRUSTOR))
        && (IdCounty == (@COUNTY = 1 ? 3 : @COUNTY) || IdCounty == (@COUNTY = 1 ? 4 : @COUNTY) || IdCounty == (@COUNTY = 1 ? 5 : @COUNTY) || IdCounty == (@COUNTY = 1 ? 6 : @COUNTY) || @COUNTY = 0)
        && (IdStatus == @STATUS || @STATUS == 0 || (@STATUS == 11 && (IdStatus == 1 || IdStatus == 3)))
        && Locked == 0
        && (Created &gt;= @DCFROM)
        && (Created &lt;= @DCTO.AddDays(1).AddSeconds(-1))" >
<WhereParameters>
  <asp:ControlParameter ControlID="txtAddress" Name="ADDRESS" PropertyName="Text" ConvertEmptyStringToNull="false" />
  <asp:ControlParameter ControlID="txtCity" Name="CITY" PropertyName="Text" ConvertEmptyStringToNull="false" />
  <asp:ControlParameter ControlID="txtZipcode" DefaultValue="" Name="ZIP" PropertyName="Text" ConvertEmptyStringToNull="false" />
  <asp:ControlParameter ControlID="txtTrusterOwnerBenefry" Name="TRUSTOR" PropertyName="Text" ConvertEmptyStringToNull="false" />
  <asp:ControlParameter ControlID="txtAmount" DefaultValue="0" Name="AMOUNT" PropertyName="Text" ConvertEmptyStringToNull="false" />
  <asp:ControlParameter ControlID="ddlCounty" DefaultValue="0" Name="COUNTY" PropertyName="SelectedValue" Type="Int32" />
  <asp:ControlParameter ControlID="ddlStatus" DefaultValue="0" Name="STATUS" PropertyName="SelectedValue" Type="Int32" />
  <asp:ControlParameter ControlID="dcFrom" Name="DCFROM" PropertyName="Fecha" Type="DateTime" DefaultValue="01/01/1900" />
  <asp:ControlParameter ControlID="dcTo" Name="DCTO" PropertyName="FechaMax" Type="DateTime" DefaultValue="01/01/1900" />
  <asp:ControlParameter ControlID="txtASSPAR" Name="ASSPAR" PropertyName="Text" ConvertEmptyStringToNull="false" />
</WhereParameters>--%>
  </asp:LinqDataSource>

  <asp:LinqDataSource ID="sourceCounty" runat="server" 
    ContextTypeName="DataClassesDataContext" 
     TableName="Counties"  OnSelecting="sourceCounty_Selecting">
      <%--OrderBy="IdState, CountyName"--%>
      <%--Select="new (IdState + ' ' + CountyName as Name, IdCounty)"--%>
  </asp:LinqDataSource>
  <asp:LinqDataSource ID="sourceStatus" runat="server" 
    ContextTypeName="DataClassesDataContext" 
    Select="new (IdStatus, Description)" TableName="Status">
  </asp:LinqDataSource>
  <asp:LinqDataSource ID="sourceState" runat="server" ContextTypeName="DataClassesDataContext" TableName="States" Select="new (IdState, StateName)"></asp:LinqDataSource>
</asp:Content>

