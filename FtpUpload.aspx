<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="FtpUpload.aspx.vb" Inherits="FtpUpload" %>

<%@ Register src="DateControl.ascx" tagname="DateControl" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <table cellpadding="5" cellspacing="0" border="0" style="text-align: center; width: 60%;">
  <tr>
    <td>NOD</td>
    <td></td>
    <td>NTS</td>
  </tr>
  <tr>
    <td><asp:ListBox ID="listBoxNOD" runat="server" Height="350px" Width="220px" 
        SelectionMode="Multiple"></asp:ListBox>
    </td>
    <td style="vertical-align: top; text-align: left; padding-left: 30px; padding-right: 30px;">
      Date:<br />
      <uc1:DateControl ID="dcDate" runat="server" />
      <br />
      <br />
      <asp:Button ID="btnRefresh" runat="server" Text="Refresh" Width="90px" CssClass="ButtonNew" />
    </td>
    <td><asp:ListBox ID="listBoxNTS" runat="server" Height="350px" Width="220px" 
        SelectionMode="Multiple"></asp:ListBox>
    </td>
  </tr>
  <tr>  
    <td>
      <asp:Button ID="btnUploadNOD" runat="server" Text="Upload 'NOD' Files" CssClass="ButtonNew" />
    </td>
    <td></td>
    <td>
      <asp:Button ID="btnUploadNTS" runat="server" Text="Upload 'NTS' Files" CssClass="ButtonNew" />
    </td>
  </tr>
  <tr>
    <td colspan="2">
        <asp:Label ID="lblMsg" runat="server" Text="" />
      Select the files to be uploaded
    </td>
  </tr>
</table>
</asp:Content>

