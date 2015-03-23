<%@ Page language="c#" Codebehind="assignment.aspx.cs" AutoEventWireup="false" Inherits="consumer_complaints.assignment" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>assignment</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout" bgcolor="#cc9999">
		<form id="Form1" method="post" runat="server">
			<asp:Label id="lblAssignmentHeading" style="Z-INDEX: 101; LEFT: 192px; POSITION: absolute; TOP: 24px"
				runat="server" Font-Bold="True" Font-Size="Larger" Font-Italic="True">Assign Work To Lineman</asp:Label>
			<asp:RegularExpressionValidator id="txtAssignmentRefNumRegExValidator" style="Z-INDEX: 119; LEFT: 456px; POSITION: absolute; TOP: 64px"
				runat="server" Width="280px" ErrorMessage="Cant contain other than numbers" ControlToValidate="txtAssignmentRefNum"
				ValidationExpression="[1-9]{1}[0-9]{0,5}"></asp:RegularExpressionValidator>
			<asp:Label id="Label1" style="Z-INDEX: 118; LEFT: 264px; POSITION: absolute; TOP: 312px" runat="server"
				ForeColor="Red"></asp:Label>
			<asp:Label id="lblAssignmentAssignDateMsg" style="Z-INDEX: 117; LEFT: 488px; POSITION: absolute; TOP: 128px"
				runat="server" Width="224px" ForeColor="Red"></asp:Label>
			<asp:Label id="lblAssignmentRefNumMsg" style="Z-INDEX: 116; LEFT: 448px; POSITION: absolute; TOP: 80px"
				runat="server" ForeColor="Red"></asp:Label>
			<asp:RequiredFieldValidator id="txtAssginmentRefNumReqdValidator" style="Z-INDEX: 115; LEFT: 448px; POSITION: absolute; TOP: 64px"
				runat="server" ErrorMessage="Enter the reference number of the complaint" ControlToValidate="txtAssignmentRefNum"
				Display="Dynamic"></asp:RequiredFieldValidator>
			<asp:RequiredFieldValidator id="txtAssignmentDelayReasonReqdValidator" style="Z-INDEX: 114; LEFT: 472px; POSITION: absolute; TOP: 168px"
				runat="server" ErrorMessage="Enter appropriate delay reason" ControlToValidate="txtAssignmentDelayReason"
				Display="Dynamic" Enabled="False"></asp:RequiredFieldValidator>
			<asp:Label id="lblAssignmentMsg" style="Z-INDEX: 113; LEFT: 368px; POSITION: absolute; TOP: 96px"
				runat="server" Width="488px" ForeColor="Red"></asp:Label>
			<asp:Calendar id="calendarAssignmentAssignDate" style="Z-INDEX: 112; LEFT: 464px; POSITION: absolute; TOP: 152px"
				runat="server" Visible="False"></asp:Calendar>
			<asp:ImageButton id="imgAssignmentAssignDate" style="Z-INDEX: 111; LEFT: 448px; POSITION: absolute; TOP: 136px"
				runat="server" ImageUrl="file:///C:\Inetpub\wwwroot\consumer_complaints\imageButton2.bmp" tabIndex="3"></asp:ImageButton>
			<asp:Button id="cmdAssignmentAssign" style="Z-INDEX: 110; LEFT: 280px; POSITION: absolute; TOP: 208px"
				tabIndex="4" runat="server" Text="Assign Work" ToolTip="Click on Image button and select date in order to enable it"></asp:Button>
			<asp:TextBox id="txtAssignmentDelayReason" style="Z-INDEX: 109; LEFT: 280px; POSITION: absolute; TOP: 160px"
				runat="server" Visible="False" MaxLength="35"></asp:TextBox>
			<asp:TextBox id="txtAssignmentAssignDate" style="Z-INDEX: 108; LEFT: 280px; POSITION: absolute; TOP: 128px"
				runat="server" Enabled="False"></asp:TextBox>
			<asp:DropDownList id="cboAssignmentLinemanNum" style="Z-INDEX: 107; LEFT: 280px; POSITION: absolute; TOP: 96px"
				tabIndex="2" runat="server"></asp:DropDownList>
			<asp:TextBox id="txtAssignmentRefNum" style="Z-INDEX: 106; LEFT: 280px; POSITION: absolute; TOP: 64px"
				tabIndex="1" runat="server" MaxLength="6"></asp:TextBox>
			<asp:Label id="lblAssignmentDelayReason" style="Z-INDEX: 105; LEFT: 152px; POSITION: absolute; TOP: 160px"
				runat="server" Visible="False">Delay Reason</asp:Label>
			<asp:Label id="lblAssignmentAssignDate" style="Z-INDEX: 104; LEFT: 152px; POSITION: absolute; TOP: 128px"
				runat="server">Assign Date</asp:Label>
			<asp:Label id="lblAssignmentLinemanNum" style="Z-INDEX: 103; LEFT: 152px; POSITION: absolute; TOP: 96px"
				runat="server">Lineman Number</asp:Label>
			<asp:Label id="lblAssignmentRefNum" style="Z-INDEX: 102; LEFT: 152px; POSITION: absolute; TOP: 64px"
				runat="server">Reference Number</asp:Label>
		</form>
	</body>
</HTML>
