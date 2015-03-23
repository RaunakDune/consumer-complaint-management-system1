<%@ Page language="c#" Codebehind="report_rangeSelection.aspx.cs" AutoEventWireup="false" Inherits="consumer_complaints.report_rangeSelection" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>report_rangeSelection</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body bgColor="#cc9999" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:Label id="lblRptStartDate" style="Z-INDEX: 101; LEFT: 232px; POSITION: absolute; TOP: 24px"
				runat="server">Start Date</asp:Label>
			<asp:DataGrid id="dataGridReportStaff" style="Z-INDEX: 111; LEFT: 24px; POSITION: absolute; TOP: 272px"
				runat="server" Width="728px" Visible="False" Height="216px" BorderColor="White" BorderStyle="Ridge"
				CellSpacing="1" BorderWidth="2px" BackColor="White" CellPadding="3" GridLines="None">
				<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#9471DE"></SelectedItemStyle>
				<ItemStyle ForeColor="Black" BackColor="#DEDFDE"></ItemStyle>
				<HeaderStyle Font-Bold="True" ForeColor="#E7E7FF" BackColor="#4A3C8C"></HeaderStyle>
				<FooterStyle ForeColor="Black" BackColor="#C6C3C6"></FooterStyle>
				<PagerStyle HorizontalAlign="Right" ForeColor="Black" BackColor="#C6C3C6"></PagerStyle>
			</asp:DataGrid>
			<asp:Label id="lblReportStaffMsg" style="Z-INDEX: 110; LEFT: 200px; POSITION: absolute; TOP: 144px"
				runat="server" Width="250px"></asp:Label>
			<asp:Button id="cmdViewRpt" style="Z-INDEX: 109; LEFT: 352px; POSITION: absolute; TOP: 96px"
				tabIndex="3" runat="server" Text="View Report"></asp:Button>
			<asp:Calendar id="calendarEnd" style="Z-INDEX: 108; LEFT: 512px; POSITION: absolute; TOP: 40px"
				runat="server" Visible="False" Height="184px"></asp:Calendar>
			<asp:ImageButton id="imgEndDate" style="Z-INDEX: 107; LEFT: 472px; POSITION: absolute; TOP: 64px"
				runat="server" ImageUrl="file:///C:\Inetpub\wwwroot\consumer_complaints\imageButton2.bmp" tabIndex="2"></asp:ImageButton>
			<asp:ImageButton id="imgStartDate" style="Z-INDEX: 106; LEFT: 472px; POSITION: absolute; TOP: 32px"
				runat="server" Width="24px" AlternateText="ClickToViewCalender" ImageUrl="file:///C:\Inetpub\wwwroot\consumer_complaints\imageButton.bmp"
				tabIndex="1"></asp:ImageButton>
			<asp:TextBox id="txtEndDate" style="Z-INDEX: 105; LEFT: 304px; POSITION: absolute; TOP: 56px"
				runat="server" Enabled="False"></asp:TextBox>
			<asp:TextBox id="txtStartDate" style="Z-INDEX: 104; LEFT: 304px; POSITION: absolute; TOP: 24px"
				runat="server" Enabled="False"></asp:TextBox>
			<asp:Calendar id="calendarStart" style="Z-INDEX: 103; LEFT: 512px; POSITION: absolute; TOP: 16px"
				runat="server" Visible="False" Height="168px"></asp:Calendar>
			<asp:Label id="lblRptEndDate" style="Z-INDEX: 102; LEFT: 232px; POSITION: absolute; TOP: 56px"
				runat="server">End Date</asp:Label></form>
	</body>
</HTML>
