<%@ Page Language="VB" AutoEventWireup="false" CodeFile="cal.aspx.vb" Inherits="cal" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Calendar</title>
    <style type="text/css">
      BODY
      {
        font-family: Arial;
        font-size: 10px;
        margin: 0px 0px 0px 0px;	
      }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:calendar id="Cal_Calendar" runat="server" BackColor="White" Width="242px" 
          ForeColor="Black" Height="38px" Font-Size="8pt" Font-Names="Verdana" 
          BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest">
				    <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black"></TodayDayStyle>
				    <NextPrevStyle VerticalAlign="Bottom"></NextPrevStyle>
				    <DayHeaderStyle Font-Size="7pt" Font-Bold="True" BackColor="#CCCCCC"></DayHeaderStyle>
				    <SelectedDayStyle ForeColor="White" BackColor="#666666" Font-Bold="True"></SelectedDayStyle>
				    <TitleStyle Font-Bold="True" BorderColor="Black" BackColor="#999999"></TitleStyle>
				    <SelectorStyle BackColor="#CCCCCC" />
            <WeekendDayStyle BackColor="#FFFFCC" />
				    <OtherMonthDayStyle ForeColor="#808080"></OtherMonthDayStyle>
			  </asp:calendar>
    </form>
</body>
</html>
