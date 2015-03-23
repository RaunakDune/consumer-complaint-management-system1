<%@ Page language="c#" Codebehind="errorPage.aspx.cs" AutoEventWireup="false" Inherits="consumer_complaints.WebForm2" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>WebForm2</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout" bgcolor="#cc9999">
		<form id="Form1" method="post" runat="server">
			<asp:Label id="lblErrorPageMsg" style="Z-INDEX: 101; LEFT: 264px; POSITION: absolute; TOP: 40px"
				runat="server" ForeColor="OrangeRed" Font-Bold="True" Font-Size="X-Large">Login Required</asp:Label>
			<asp:HyperLink id="errorPageLogin" style="Z-INDEX: 102; LEFT: 480px; POSITION: absolute; TOP: 96px"
				runat="server" ForeColor="Red" Font-Size="Larger" NavigateUrl="default.aspx" Target="_parent">Login</asp:HyperLink>
		</form>
	</body>
</HTML>
