<%@ Page language="c#" Codebehind="Welcome_JE.aspx.cs" AutoEventWireup="false" Inherits="consumer_complaints.Welcome_JE" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Welcome_JE</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script>
		if(window.history .forward (1)!=-1)
			window.history .forward (1);
		</script>
	</HEAD>
	<body bgColor="#cc9999" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:Button id="cmdJEViewReprt" style="Z-INDEX: 101; LEFT: 464px; POSITION: absolute; TOP: 64px"
				runat="server" Text="View Complaints Report" BorderColor="Blue" BackColor="PeachPuff" ForeColor="#8080FF"
				Font-Bold="True"></asp:Button>
			<asp:Label id="Label1" style="Z-INDEX: 104; LEFT: 536px; POSITION: absolute; TOP: 16px" runat="server"
				Font-Bold="True" ForeColor="#8080FF" Width="310px" Font-Italic="True" Font-Size="Large">Welcome to APSEB Fuse Call</asp:Label>
			<asp:HyperLink id="mgrLogoutLink" style="Z-INDEX: 103; LEFT: 968px; POSITION: absolute; TOP: 64px"
				runat="server" ForeColor="Red" Font-Bold="True" NavigateUrl="default.aspx" Target="_parent">Logout</asp:HyperLink>
			<asp:DataGrid id="dataGridReportJE" style="Z-INDEX: 102; LEFT: 8px; POSITION: absolute; TOP: 104px"
				runat="server" Height="248px" Width="1072px" Visible="False" BorderColor="White" BorderStyle="Ridge"
				CellSpacing="1" BorderWidth="2px" BackColor="White" CellPadding="3" GridLines="None" AllowSorting="True">
				<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#9471DE"></SelectedItemStyle>
				<ItemStyle ForeColor="Black" BackColor="#DEDFDE"></ItemStyle>
				<HeaderStyle Font-Bold="True" ForeColor="#E7E7FF" BackColor="#4A3C8C"></HeaderStyle>
				<FooterStyle ForeColor="Black" BackColor="#C6C3C6"></FooterStyle>
				<PagerStyle HorizontalAlign="Right" ForeColor="Black" BackColor="#C6C3C6"></PagerStyle>
			</asp:DataGrid></form>
	</body>
</HTML>
