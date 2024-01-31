<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.master" AutoEventWireup="true" CodeFile="FtpData.aspx.cs" Inherits="Import_FtpData" %>

<%@ Register src="DateControl.ascx" tagname="DateControl" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <table cellpadding="5" cellspacing="0" border="0" style="text-align: center; width: 60%;">
  <tr>
    <td>NOD</td>
    <td>NTS</td>
  </tr>
  <tr>
    <td><asp:ListBox ID="listBoxNOD" runat="server" Height="350px" Width="220px"></asp:ListBox>
    </td>
    <td><asp:ListBox ID="ListBox1" runat="server" Height="350px" Width="220px"></asp:ListBox>
    </td>
  </tr>
  <tr>  
    <td>
      <asp:Button ID="btnUploadNOD" runat="server" Text="Upload 'NOD' Files" 
        onclick="btnUploadNOD_Click" CssClass="ButtonNew" />
    </td>
    <td>
      <asp:Button ID="btnUploadNTS" runat="server" Text="Upload 'NTS' Files" 
        onclick="btnUploadNTS_Click" CssClass="ButtonNew" />
    </td>
  </tr>
  <tr>
    <td colspan="2">
      Select the files to be uploaded
    </td>
  </tr>
</table>
</asp:Content>

