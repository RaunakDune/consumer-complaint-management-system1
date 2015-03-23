<%@ Page language="c#" Codebehind="closeComplaint.aspx.cs" AutoEventWireup="false" Inherits="consumer_complaints.closeComplaint" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>closeComplaint</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body bgColor="#cc9999" MS_POSITIONING="GridLayout"> <!--#cccc66 -->
		<form id="Form1" method="post" runat="server">
			<asp:label id="lblCloseComplaintHeading" style="Z-INDEX: 101; LEFT: 232px; POSITION: absolute; TOP: 16px"
				runat="server" Font-Bold="True" Font-Italic="True" Font-Size="Larger">Complaint Closing</asp:label>
			<asp:RegularExpressionValidator id="txtCloseComplaintRefNumRegExValidator" style="Z-INDEX: 126; LEFT: 376px; POSITION: absolute; TOP: 80px"
				runat="server" ControlToValidate="txtCloseComplaintRefNum" ErrorMessage="Can't contain other than numbers" ValidationExpression="[1-9]{1}[0-9]{0,5}">*</asp:RegularExpressionValidator><asp:label id="lblCloseComplaintClosedDateMsg" style="Z-INDEX: 125; LEFT: 384px; POSITION: absolute; TOP: 144px"
				runat="server" ForeColor="Red" Width="268px"></asp:label><asp:validationsummary id="ValidationSummary1" style="Z-INDEX: 123; LEFT: 432px; POSITION: absolute; TOP: 200px"
				runat="server" Width="202px" Height="72px"></asp:validationsummary><asp:label id="lblCloseComplaintRefNumMsg" style="Z-INDEX: 122; LEFT: 368px; POSITION: absolute; TOP: 104px"
				runat="server" ForeColor="Red" Width="486px"></asp:label><asp:rangevalidator id="txtCloseComplaintClosedTimeMinuteRangeValidator" style="Z-INDEX: 121; LEFT: 288px; POSITION: absolute; TOP: 216px"
				runat="server" MaximumValue="59" MinimumValue="00" ErrorMessage="Minutes between 00 and 59" ControlToValidate="txtCloseComplaintClosedTimeMinute">*</asp:rangevalidator><asp:rangevalidator id="txtCloseComplaintClosedTimeHourRangeValidator" style="Z-INDEX: 120; LEFT: 232px; POSITION: absolute; TOP: 216px"
				runat="server" MaximumValue="23" MinimumValue="0" ErrorMessage="Hours between 0 and 23" ControlToValidate="txtCloseComplaintClosedTimeHour">*</asp:rangevalidator><asp:textbox id="txtCloseComplaintClosedTimeMinute" style="Z-INDEX: 119; LEFT: 248px; POSITION: absolute; TOP: 208px"
				tabIndex="5" runat="server" Width="32px" MaxLength="2"></asp:textbox><asp:textbox id="txtCloseComplaintClosedTimeHour" style="Z-INDEX: 118; LEFT: 192px; POSITION: absolute; TOP: 208px"
				tabIndex="4" runat="server" Width="32px" MaxLength="2"></asp:textbox><asp:button id="cmdCloseComplaintClose" style="Z-INDEX: 117; LEFT: 192px; POSITION: absolute; TOP: 328px"
				tabIndex="6" runat="server" Enabled="False" Text="Close"></asp:button><asp:calendar id="calendarClosedDate" style="Z-INDEX: 116; LEFT: 384px; POSITION: absolute; TOP: 184px"
				runat="server" Visible="False"></asp:calendar><asp:imagebutton id="imgCmdCloseComplaintClosedDate" style="Z-INDEX: 115; LEFT: 352px; POSITION: absolute; TOP: 184px"
				tabIndex="3" runat="server" ImageUrl="file:///C:\Inetpub\wwwroot\consumer_complaints\imageButton.bmp"></asp:imagebutton><asp:requiredfieldvalidator id="txtCloseComplaintRefNumReqdValidator" style="Z-INDEX: 114; LEFT: 360px; POSITION: absolute; TOP: 80px"
				runat="server" ErrorMessage="Reference Number can't be empty" ControlToValidate="txtCloseComplaintRefNum">*</asp:requiredfieldvalidator><asp:textbox id="txtCloseComplaintDelayReason" style="Z-INDEX: 113; LEFT: 192px; POSITION: absolute; TOP: 272px"
				runat="server" MaxLength="35" Enabled="False"></asp:textbox><asp:textbox id="txtCloseComplaintTimeTaken" style="Z-INDEX: 112; LEFT: 192px; POSITION: absolute; TOP: 240px"
				runat="server" Enabled="False"></asp:textbox><asp:textbox id="txtCloseComplaintClosedTime" style="Z-INDEX: 111; LEFT: 304px; POSITION: absolute; TOP: 208px"
				tabIndex="3" runat="server" Width="40px" MaxLength="5" Visible="False"></asp:textbox><asp:textbox id="txtCloseComplaintClosedDate" style="Z-INDEX: 110; LEFT: 192px; POSITION: absolute; TOP: 176px"
				tabIndex="2" runat="server" Enabled="False"></asp:textbox><asp:textbox id="txtCloseComplaintAssignedDate" style="Z-INDEX: 109; LEFT: 192px; POSITION: absolute; TOP: 144px"
				runat="server" Enabled="False"></asp:textbox><asp:textbox id="txtCloseComplaintRefNum" style="Z-INDEX: 108; LEFT: 192px; POSITION: absolute; TOP: 72px"
				tabIndex="1" runat="server" MaxLength="6"></asp:textbox><asp:label id="lblCloseComplaintDelayReason" style="Z-INDEX: 107; LEFT: 64px; POSITION: absolute; TOP: 272px"
				runat="server">Delay Reason</asp:label><asp:label id="lblCloseComplaintTimeTaken" style="Z-INDEX: 106; LEFT: 64px; POSITION: absolute; TOP: 240px"
				runat="server">Time Taken(Minutes)</asp:label><asp:label id="lblCloseComplaintClosedTime" style="Z-INDEX: 105; LEFT: 64px; POSITION: absolute; TOP: 208px"
				runat="server">Closed Time</asp:label><asp:label id="lblCloseComplaintClosedDate" style="Z-INDEX: 104; LEFT: 64px; POSITION: absolute; TOP: 176px"
				runat="server">Closed Date</asp:label><asp:label id="lblCloseComplaintAssignedDate" style="Z-INDEX: 103; LEFT: 64px; POSITION: absolute; TOP: 144px"
				runat="server">Assigned Date</asp:label><asp:label id="lblCloseComplaintRefNum" style="Z-INDEX: 102; LEFT: 64px; POSITION: absolute; TOP: 72px"
				runat="server">Reference Number</asp:label><asp:button id="cmdCloseComplaintGenerate" style="Z-INDEX: 124; LEFT: 64px; POSITION: absolute; TOP: 112px"
				tabIndex="2" runat="server" Width="289px" Text="Generate Assign Date and Delay Reason"></asp:button></form>
	</body>
</HTML>
