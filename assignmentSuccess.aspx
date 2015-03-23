<%@ Page language="c#" Codebehind="assignmentSuccess.aspx.cs" AutoEventWireup="false" Inherits="consumer_complaints.assignmentSuccess" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>assignmentSuccess</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout" bgColor="#cc9999">
		<form id="Form1" method="post" runat="server">
			<asp:Label id="lblAssignmentSuccessMsg" style="Z-INDEX: 101; LEFT: 152px; POSITION: absolute; TOP: 72px"
				runat="server" Width="432px" ForeColor="Aqua" Font-Bold="True" Font-Size="Large">Complaint is assigned to selected lineman</asp:Label>
			<asp:HyperLink id="linkAssignAnother" style="Z-INDEX: 102; LEFT: 472px; POSITION: absolute; TOP: 128px"
				runat="server" ForeColor="Red" NavigateUrl="assignment.aspx">Assign Another</asp:HyperLink>
		</form>
	</body>
</HTML>
