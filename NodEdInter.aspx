<%@ Page Language="VB" AutoEventWireup="false" CodeFile="NodEdInter.aspx.vb" Inherits="NodEdInter" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>NOD-Edit</title>
</head>
<body>
    <iframe width="100%" height="100%" src='NodEd.aspx?id=<%=Request("id")%>' scrolling="no"></iframe>
</body>
</html>
