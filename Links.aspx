<%@ Page language="c#" Codebehind="Links.aspx.cs" AutoEventWireup="false" Inherits="consumer_complaints.Links" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Links</title>
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
			<asp:hyperlink id="LinksComplaintForm" style="Z-INDEX: 101; LEFT: 16px; POSITION: absolute; TOP: 104px"
				runat="server" Target="main" Width="112px" ForeColor="Red" NavigateUrl="complaint_form.aspx">Complaint Form</asp:hyperlink><asp:hyperlink id="LinksLogout" style="Z-INDEX: 105; LEFT: 16px; POSITION: absolute; TOP: 256px"
				runat="server" Target="_parent" ForeColor="Red" NavigateUrl="logout.aspx">Logout</asp:hyperlink>
			<asp:HyperLink id="LinksAssignWork" style="Z-INDEX: 104; LEFT: 16px; POSITION: absolute; TOP: 136px"
				runat="server" Target="main" ForeColor="Red" NavigateUrl="assignment.aspx">AssignWork</asp:HyperLink>
			<asp:HyperLink id="LinksViewReport" style="Z-INDEX: 103; LEFT: 16px; POSITION: absolute; TOP: 200px"
				runat="server" NavigateUrl="report_rangeSelection.aspx" ForeColor="Red" Width="112px" Target="main">View Report</asp:HyperLink>
			<asp:HyperLink id="LinksCloseComplaint" style="Z-INDEX: 102; LEFT: 16px; POSITION: absolute; TOP: 168px"
				runat="server" NavigateUrl="closeComplaint.aspx" ForeColor="Red" Width="112px" Target="main">Close Complaint</asp:HyperLink></form>
	</body>
</HTML>
