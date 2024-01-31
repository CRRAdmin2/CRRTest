<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="User.aspx.vb" Inherits="User" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <div style="width: 100%; height: 300px; vertical-align: middle; text-align: center;">
<br /><br /><br />
<asp:Panel ID="panelModal" runat="server" Width="500px" CssClass="modal">
  <asp:Panel ID="panelArrastre" runat="server" CssClass="arrastre">
 <table cellpadding="0" cellspacing="0" border="0" class="tituloPop">
    <tr><td><asp:Label ID="lblTitulo" runat="server" Text="Changing Password"></asp:Label>
      </td></tr>
  </table></asp:Panel>
  <table cellpadding="5" cellspacing="0" border="0" align="center">
    <tr>
     <td>
        <table cellpadding="0" cellspacing="0" border="0">
          <tr>
            <td align="right"><label>Current Password:</label></td>
            <td>
              <asp:TextBox ID="txtContrasena" runat="server" TextMode="Password" MaxLength="20"></asp:TextBox>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtContrasena" 
                ErrorMessage="Contraseña requerida" Display="Dynamic" Enabled="false">*</asp:RequiredFieldValidator>
            </td>
          </tr>
        </table>
      </td>
    </tr>
  </table>
  <table cellpadding="5" cellspacing="0" border="0" align="center">
    <tr>
     <td>
        <table cellpadding="0" cellspacing="0" border="0">
          <tr>
            <td align="right"><label>New Password:</label></td>
            <td>
              <asp:TextBox ID="txtNuevaContrasena" runat="server" TextMode="Password" MaxLength="20"></asp:TextBox>
              <asp:RequiredFieldValidator ID="requireContrasena" runat="server" ControlToValidate="txtNuevaContrasena" 
                ErrorMessage="Nueva Contraseña requerida" Display="Dynamic">*</asp:RequiredFieldValidator>
            </td>
          </tr>
        </table>
      </td>
    </tr>
  </table>
  <table cellpadding="5" cellspacing="0" border="0" align="center">
    <tr>
     <td>
        <table cellpadding="0" cellspacing="0" border="0">
          <tr>
            <td align="right"><label>Confirm Password:</label></td>
            <td>
              <asp:TextBox ID="txtConfirmacion" runat="server" TextMode="Password" MaxLength="20"></asp:TextBox>
              <asp:RequiredFieldValidator ID="requireContrasena0" runat="server" 
                ControlToValidate="txtConfirmacion" Display="Dynamic" 
                ErrorMessage="Confirmación requerida" Enabled="false">*</asp:RequiredFieldValidator>
              <asp:CompareValidator ID="CompareValidator1" runat="server" 
                ControlToCompare="txtNuevaContrasena" ControlToValidate="txtConfirmacion" 
                ErrorMessage="Confirmación no coincide">*</asp:CompareValidator>
            </td>
          </tr>
        </table>
      </td>
    </tr>
  </table>
  <table cellpadding="5" cellspacing="0" border="0" align="center">
    <tr>
      <td>
        <asp:Button ID="btnCambiarContrasena" runat="server" Text="Change Password" 
          OnClick="btnCambiarContrasena_Click" CssClass="ButtonNew" />
      </td>
    </tr>
  </table>
</asp:Panel>
</div>
</asp:Content>

