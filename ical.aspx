<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ical.aspx.vb" Inherits="ical" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
  <form id="Form1" runat="server">
    <iframe scrolling="no" width="100%" height="100%" src='cal.aspx?object=<%=Request("object")%>'></iframe>
  </form>
</body>
</html>
