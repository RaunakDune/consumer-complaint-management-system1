<%@ Page language="c#" Codebehind="insertionSuccess.aspx.cs" AutoEventWireup="false" Inherits="consumer_complaints.WebForm3" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>WebForm3</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout" bgColor="#cc9999">
		<form id="Form1" method="post" runat="server">
			<asp:Label id="lblInsertionSuccessMsg" style="Z-INDEX: 101; LEFT: 96px; POSITION: absolute; TOP: 104px"
				runat="server" Width="536px" ForeColor="Aqua" Font-Bold="True" Font-Size="Large">The record is inserted successfully into the database</asp:Label>
			<asp:HyperLink id="linkInsertAnotherComplaint" style="Z-INDEX: 102; LEFT: 480px; POSITION: absolute; TOP: 160px"
				runat="server" ForeColor="Red" NavigateUrl="complaint_form.aspx" Target="_self">Insert another complaint</asp:HyperLink>
		</form>
	</body>
</HTML>
