<%@ Page language="c#" Codebehind="logout.aspx.cs" AutoEventWireup="false" Inherits="consumer_complaints.logout" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>logout</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout" bgColor="#cc9999">
		<form id="Form1" method="post" runat="server">
			<asp:Label id="lblLogoutMsg" style="Z-INDEX: 101; LEFT: 240px; POSITION: absolute; TOP: 48px"
				runat="server" Width="160px" ForeColor="#C0C000" Font-Bold="True" Font-Italic="True" Font-Size="Large">Session Expired</asp:Label>
			<asp:HyperLink id="linkLogout" style="Z-INDEX: 102; LEFT: 424px; POSITION: absolute; TOP: 104px"
				runat="server" Width="104px" ForeColor="Red" Font-Italic="True" Font-Size="Larger" NavigateUrl="default.aspx"
				Target="_top">Login Again</asp:HyperLink>
		</form>
	</body>
</HTML>
