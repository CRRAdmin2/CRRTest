<%@ Page Language="VB" AutoEventWireup="false" CodeFile="NtsEdInter.aspx.vb" Inherits="NtsEdInter" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>NTS-Edit</title>
</head>
<body>
    <iframe width="100%" height="100%" src='NtsEd.aspx?id=<%=Request("id")%>' scrolling="no"></iframe>
</body>
</html>
