<%@ Control Language="VB" AutoEventWireup="false" CodeFile="DateControl.ascx.vb" Inherits="DateControl" %>
<table cellpadding="0" cellspacing="0" border="0">
  <tr>
    <td><asp:TextBox ID="txtFecha" runat="server" Width="67px" MaxLength="10"></asp:TextBox></td>
    <td><asp:HyperLink ID="hypFecha" runat="server" ImageUrl="~/Images/calendar.png" CssClass="selcal"></asp:HyperLink></td>
  </tr>
</table>