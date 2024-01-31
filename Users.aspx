<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Users.aspx.vb" Inherits="Users" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <div style="height: 81px;"></div>
<div style="text-align: center; width: 100%;">
  <asp:Button ID="btnAddNewUser" runat="server" Text="Add New User" CssClass="ButtonNew" />
  <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
  DataKeyNames="IdUsuario" DataSourceID="LinqDataSource1" CellPadding="4" 
    ForeColor="#333333" GridLines="None" ShowFooter="True" 
    HorizontalAlign="Center" Width="700px" AllowPaging="true">
    <RowStyle BackColor="#EFF3FB" />
  <Columns>
    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
    <asp:BoundField DataField="IdUsuario" HeaderText="Id" 
      InsertVisible="False" ReadOnly="True" SortExpression="IdUsuario" />
    <asp:BoundField DataField="Usuario" HeaderText="User" 
      SortExpression="Usuario" />
    <asp:BoundField DataField="Nombre" HeaderText="Name" 
      SortExpression="Nombre" />
    <asp:BoundField DataField="Password" HeaderText="Password" 
      SortExpression="Password" Visible="false" />
    <asp:TemplateField>
      <ItemTemplate>
        <asp:LinkButton ID="lnbChangePassword" runat="server" OnClick="lnbChangePassword_Click" ForeColor="Black">Change Password</asp:LinkButton>
      </ItemTemplate>
    </asp:TemplateField>
  </Columns>
    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
    <EditRowStyle BackColor="#2461BF" />
    <AlternatingRowStyle BackColor="White" />
</asp:GridView>
<cc1:ModalPopupExtender ID="panelNewUser_ModalPopupExtender" runat="server" 
  DynamicServicePath="" Enabled="True" PopupControlID="panelNewUser"
  TargetControlID="btnAddNewUser" BackgroundCssClass="modalBackground" CancelControlID="btnCancel"
  PopupDragHandleControlID="panelChangePasswordTitle" X="-1" Y="-1" DropShadow="True">
</cc1:ModalPopupExtender>
  <asp:Panel ID="panelNewUser" runat="server" BackColor="White" BorderColor="Black" BorderWidth="1px" BorderStyle="solid">
    <asp:Panel ID="panelNewUserTitle" runat="server" BackColor="Navy" ForeColor="White" CssClass="arrastre" Font-Bold="true">
      <div style="padding: 5px 5px 5px 5px;">New User Info</div>
    </asp:Panel>
    <table>
      <tr>
        <td style="font-weight:bold; text-align: right;">User:</td>
        <td><asp:TextBox ID="txtUser" runat="server"></asp:TextBox></td>
      </tr>
      <tr>
        <td style="font-weight:bold; text-align: right;">Name:</td>
        <td><asp:TextBox ID="txtName" runat="server"></asp:TextBox></td>
      </tr>
      <tr>
        <td style="font-weight:bold; text-align: right;">Password:</td>
        <td><asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox></td>
      </tr>
      <tr>
        <td style="font-weight:bold; text-align: right;">Confirm Password:</td>
        <td><asp:TextBox ID="txtConfirmPwd" runat="server" TextMode="Password"></asp:TextBox></td>
      </tr>
      <tr>
        <td></td>
        <td><asp:CheckBox ID="chkPasswordMode" runat="server" Text="Password Mode" Checked="true" AutoPostBack="true" /></td>
      </tr>
      <tr>
        <td style="text-align: right;"><asp:Button ID="btnSave" runat="server" Text="Save" CssClass="ButtonNew" /></td>
        <td style="text-align: left;"><asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="ButtonNew" /></td>
      </tr>
    </table>
  </asp:Panel>
<cc1:ModalPopupExtender ID="panelChangePassword_ModalPopupExtender1" runat="server" 
  DynamicServicePath="" Enabled="True" PopupControlID="panelChangePassword"
  TargetControlID="hypComodin" BackgroundCssClass="modalBackground" CancelControlID="btnChangeCancel"
  PopupDragHandleControlID="panelNewUserTitle" X="-1" Y="-1" DropShadow="True">
</cc1:ModalPopupExtender>
    <asp:HyperLink ID="hypComodin" runat="server" Text=" "></asp:HyperLink>
    <asp:Panel ID="panelChangePassword" runat="server" BackColor="White" BorderColor="Black" BorderWidth="1px" BorderStyle="solid">
    <asp:Panel ID="panelChangePasswordTitle" runat="server" BackColor="Navy" ForeColor="White" CssClass="arrastre" Font-Bold="true">
      <div style="padding: 5px 5px 5px 5px;">Change Password</div>
    </asp:Panel>
    <table>
      <tr>
        <td style="font-weight:bold; text-align: right;">User:</td>
        <td style="text-align: left;">
          <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
            <tr>
              <td><asp:Label ID="lblUser" runat="server"></asp:Label></td>
              <td style="text-align: right;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Id:</b> <asp:Label ID="lblIdUser" runat="server"></asp:Label></td>
            </tr>
          </table>
        </td>
      </tr>
      <tr>
        <td style="font-weight:bold; text-align: right;">Name:</td>
        <td style="text-align: left;"><asp:Label ID="lblName" runat="server"></asp:Label></td>
      </tr>
      <tr>
        <td style="font-weight:bold; text-align: right;">Old Password:</td>
        <td><asp:TextBox ID="txtChangeOldPassword" runat="server" TextMode="Password"></asp:TextBox></td>
      </tr>
      <tr>
        <td style="font-weight:bold; text-align: right;">New Password:</td>
        <td><asp:TextBox ID="txtChangePassword" runat="server" TextMode="Password"></asp:TextBox></td>
      </tr>
      <tr>
        <td style="font-weight:bold; text-align: right;">Confirm Password:</td>
        <td><asp:TextBox ID="txtChangeConfirmPwd" runat="server" TextMode="Password"></asp:TextBox></td>
      </tr>
      <tr>
        <td colspan="2">
          <asp:Button ID="btnChangeOk" runat="server" Text="Change Password" CssClass="ButtonNew" />
          <asp:Button ID="btnChangeCancel" runat="server" Text="Cancel" CssClass="ButtonNew" /></td>
      </tr>
    </table>
  </asp:Panel>

<asp:LinqDataSource ID="LinqDataSource1" runat="server" 
  ContextTypeName="DataClassesDataContext" EnableDelete="True" 
  EnableInsert="True" EnableUpdate="True" TableName="Usuarios">
</asp:LinqDataSource>
</div>
</asp:Content>

