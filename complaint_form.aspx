<%@ Page language="c#" Codebehind="complaint_form.aspx.cs" AutoEventWireup="false" Inherits="consumer_complaints.complaint_form" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>complaint_form</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body bgColor="#cc9999" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:label id="lblNewCmplHeading" style="Z-INDEX: 101; LEFT: 288px; POSITION: absolute; TOP: 16px"
				runat="server" Font-Bold="True" Font-Names="Tahoma"> Complaint Form</asp:label><INPUT id="cmdNewFormReset" style="Z-INDEX: 147; LEFT: 384px; POSITION: absolute; TOP: 424px"
				tabIndex="13" type="reset" value="Reset">
			<asp:label id="lblNewComplaintMsg" style="Z-INDEX: 146; LEFT: 472px; POSITION: absolute; TOP: 64px"
				runat="server" Width="264px" ForeColor="SpringGreen"></asp:label><asp:regularexpressionvalidator id="RegularExpressionValidator1" style="Z-INDEX: 145; LEFT: 464px; POSITION: absolute; TOP: 320px"
				runat="server" ControlToValidate="txtPhoneNum" ErrorMessage="Phone Number can contain only numbers" ValidationExpression="[0-9]{10}">*</asp:regularexpressionvalidator><asp:textbox id="txtPhoneNum" style="Z-INDEX: 144; LEFT: 304px; POSITION: absolute; TOP: 320px"
				tabIndex="9" runat="server" MaxLength="10"></asp:textbox><asp:label id="lblPhoneNum" style="Z-INDEX: 143; LEFT: 184px; POSITION: absolute; TOP: 320px"
				runat="server">PhoneNumber</asp:label><asp:textbox id="txtGivenTime" style="Z-INDEX: 142; LEFT: 416px; POSITION: absolute; TOP: 192px"
				runat="server" Width="64px" MaxLength="8" Enabled="False" Visible="False"></asp:textbox><asp:regularexpressionvalidator id="txtCityRegExValidator" style="Z-INDEX: 141; LEFT: 480px; POSITION: absolute; TOP: 264px"
				runat="server" ControlToValidate="txtCity" ErrorMessage="City can contain only alphabets" ValidationExpression="[A-Za-z]{1,15}">*</asp:regularexpressionvalidator><asp:regularexpressionvalidator id="txtAreaRegExValidator" style="Z-INDEX: 140; LEFT: 480px; POSITION: absolute; TOP: 232px"
				runat="server" Width="8px" ControlToValidate="txtArea" ErrorMessage="Area can contain only alphabets" ValidationExpression="[A-Za-z]{1,10}">*</asp:regularexpressionvalidator><asp:validationsummary id="newComplaintValidationSummary" style="Z-INDEX: 138; LEFT: 520px; POSITION: absolute; TOP: 200px"
				runat="server" Width="225px" Height="136px"></asp:validationsummary><asp:rangevalidator id="txtGivenTimeMinuteRangeValidator" style="Z-INDEX: 137; LEFT: 400px; POSITION: absolute; TOP: 200px"
				runat="server" ControlToValidate="txtGivenTimeMinute" ErrorMessage="Minutes value in between 00 and 59" MaximumValue="59" MinimumValue="00">*</asp:rangevalidator><asp:regularexpressionvalidator id="txtConsumerNameRegExValidator" style="Z-INDEX: 136; LEFT: 480px; POSITION: absolute; TOP: 136px"
				runat="server" ControlToValidate="txtConsumerName" ErrorMessage="Name contain only alphabets" ValidationExpression="[A-Za-z]{1,15}">*</asp:regularexpressionvalidator><asp:rangevalidator id="txtGivenTimeHourRangeValidator" style="Z-INDEX: 135; LEFT: 384px; POSITION: absolute; TOP: 200px"
				runat="server" ControlToValidate="txtGivenTimeHour" ErrorMessage="Hour Value between 0 and 23" MaximumValue="23" MinimumValue="0">*</asp:rangevalidator><asp:textbox id="txtGivenTimeMinute" style="Z-INDEX: 133; LEFT: 344px; POSITION: absolute; TOP: 192px"
				tabIndex="5" runat="server" Width="32px" MaxLength="2"></asp:textbox><asp:textbox id="txtGivenTimeHour" style="Z-INDEX: 132; LEFT: 304px; POSITION: absolute; TOP: 192px"
				tabIndex="4" runat="server" Width="32px" MaxLength="2"></asp:textbox><asp:comparevalidator id="cboFaultAtCmpValidator" style="Z-INDEX: 131; LEFT: 400px; POSITION: absolute; TOP: 352px"
				runat="server" ControlToValidate="cboFaultAt" ErrorMessage="Select Fault At" Operator="GreaterThan" ValueToCompare="0">*</asp:comparevalidator><asp:comparevalidator id="cboStateCmpValidator" style="Z-INDEX: 130; LEFT: 408px; POSITION: absolute; TOP: 288px"
				runat="server" ControlToValidate="cboState" ErrorMessage="Select the State" Operator="GreaterThan" ValueToCompare="0">*</asp:comparevalidator><asp:comparevalidator id="cboNatureCmpValidator" style="Z-INDEX: 129; LEFT: 608px; POSITION: absolute; TOP: 160px"
				runat="server" Width="16px" ControlToValidate="cboNature" ErrorMessage="Select any kind of nature" Operator="GreaterThan" ValueToCompare="0">*</asp:comparevalidator><asp:calendar id="calendarGivenDate" style="Z-INDEX: 128; LEFT: 504px; POSITION: absolute; TOP: 344px"
				runat="server" Width="192px" Visible="False" Height="182px"></asp:calendar><asp:imagebutton id="imgGivenDate" style="Z-INDEX: 127; LEFT: 472px; POSITION: absolute; TOP: 392px"
				tabIndex="11" runat="server" ImageUrl="file:///C:\Inetpub\wwwroot\consumer_complaints\imageButton.bmp"></asp:imagebutton><asp:textbox id="txtRefNum" style="Z-INDEX: 126; LEFT: 304px; POSITION: absolute; TOP: 64px"
				runat="server" Enabled="False"></asp:textbox><asp:label id="lblRefNum" style="Z-INDEX: 125; LEFT: 184px; POSITION: absolute; TOP: 64px"
				runat="server">Reference Number</asp:label><asp:comparevalidator id="txtConsumerNumCmpValidator" style="Z-INDEX: 124; LEFT: 480px; POSITION: absolute; TOP: 104px"
				runat="server" Width="8px" ControlToValidate="txtConsumerNum" ErrorMessage="Cant have otherthan digits" Operator="DataTypeCheck" Type="Integer">*</asp:comparevalidator><asp:dropdownlist id="cboState" style="Z-INDEX: 123; LEFT: 304px; POSITION: absolute; TOP: 288px"
				tabIndex="8" runat="server">
				<asp:ListItem Value="0">Select</asp:ListItem>
				<asp:ListItem Value="1">AP</asp:ListItem>
				<asp:ListItem Value="2">Tamil Nadu</asp:ListItem>
				<asp:ListItem Value="3">Karnataka</asp:ListItem>
				<asp:ListItem Value="4">UP</asp:ListItem>
				<asp:ListItem Value="5">Bihar</asp:ListItem>
				<asp:ListItem Value="6">Maharastra</asp:ListItem>
			</asp:dropdownlist><asp:requiredfieldvalidator id="txtConsumerCityReqdValidator" style="Z-INDEX: 122; LEFT: 464px; POSITION: absolute; TOP: 264px"
				runat="server" ControlToValidate="txtCity" ErrorMessage="City required">*</asp:requiredfieldvalidator><asp:requiredfieldvalidator id="txtConsumerAreaReqdValidator" style="Z-INDEX: 121; LEFT: 464px; POSITION: absolute; TOP: 232px"
				runat="server" ControlToValidate="txtArea" ErrorMessage="Area required">*</asp:requiredfieldvalidator><asp:requiredfieldvalidator id="txtConsumerNameReqdValidator" style="Z-INDEX: 120; LEFT: 464px; POSITION: absolute; TOP: 136px"
				runat="server" ControlToValidate="txtConsumerName" ErrorMessage="Name can't be empty">*</asp:requiredfieldvalidator><asp:requiredfieldvalidator id="txtConsumerNumReqdValidator" style="Z-INDEX: 119; LEFT: 464px; POSITION: absolute; TOP: 104px"
				runat="server" ControlToValidate="txtConsumerNum" ErrorMessage="Meter Reading can't be empty">*</asp:requiredfieldvalidator><asp:button id="cmdNewFormSubmit" style="Z-INDEX: 118; LEFT: 304px; POSITION: absolute; TOP: 424px"
				tabIndex="12" runat="server" Enabled="False" Text="Submit" ToolTip="Click on Image Button and select a date to make it enabled"></asp:button><asp:dropdownlist id="cboFaultAt" style="Z-INDEX: 117; LEFT: 304px; POSITION: absolute; TOP: 352px"
				tabIndex="10" runat="server">
				<asp:ListItem Value="0">Select</asp:ListItem>
				<asp:ListItem Value="1">POLE</asp:ListItem>
				<asp:ListItem Value="2">SUB-STATION</asp:ListItem>
			</asp:dropdownlist><asp:textbox id="txtCity" style="Z-INDEX: 116; LEFT: 304px; POSITION: absolute; TOP: 256px" tabIndex="7"
				runat="server" MaxLength="12"></asp:textbox><asp:textbox id="txtArea" style="Z-INDEX: 115; LEFT: 304px; POSITION: absolute; TOP: 224px" tabIndex="6"
				runat="server" MaxLength="10"></asp:textbox><asp:textbox id="txtGivenDate" style="Z-INDEX: 114; LEFT: 304px; POSITION: absolute; TOP: 384px"
				runat="server" MaxLength="12" Enabled="False"></asp:textbox><asp:dropdownlist id="cboNature" style="Z-INDEX: 113; LEFT: 304px; POSITION: absolute; TOP: 160px"
				tabIndex="3" runat="server">
				<asp:ListItem Value="0">Select</asp:ListItem>
				<asp:ListItem Value="1">Deliberate shutdown for maintenance/repairs</asp:ListItem>
				<asp:ListItem Value="2">Disconnection due to rains</asp:ListItem>
				<asp:ListItem Value="3">Disconnection due to digging of roads</asp:ListItem>
			</asp:dropdownlist><asp:textbox id="txtConsumerName" style="Z-INDEX: 112; LEFT: 304px; POSITION: absolute; TOP: 128px"
				tabIndex="2" runat="server" MaxLength="15"></asp:textbox><asp:textbox id="txtConsumerNum" style="Z-INDEX: 111; LEFT: 304px; POSITION: absolute; TOP: 96px"
				tabIndex="1" runat="server" MaxLength="7"></asp:textbox><asp:label id="lblFaultAt" style="Z-INDEX: 110; LEFT: 184px; POSITION: absolute; TOP: 352px"
				runat="server">Fault At</asp:label><asp:label id="lblState" style="Z-INDEX: 109; LEFT: 184px; POSITION: absolute; TOP: 288px"
				runat="server">State</asp:label><asp:label id="lblCity" style="Z-INDEX: 108; LEFT: 184px; POSITION: absolute; TOP: 256px" runat="server">City</asp:label><asp:label id="lblArea" style="Z-INDEX: 107; LEFT: 184px; POSITION: absolute; TOP: 224px" runat="server">Area</asp:label><asp:label id="lblGivenTime" style="Z-INDEX: 106; LEFT: 184px; POSITION: absolute; TOP: 192px"
				runat="server">GivenTime[hh:mm]</asp:label><asp:label id="lblGivenDate" style="Z-INDEX: 105; LEFT: 184px; POSITION: absolute; TOP: 384px"
				runat="server">Given Date</asp:label><asp:label id="lblNature" style="Z-INDEX: 104; LEFT: 184px; POSITION: absolute; TOP: 160px"
				runat="server">Nature</asp:label><asp:label id="lblConsumerName" style="Z-INDEX: 103; LEFT: 184px; POSITION: absolute; TOP: 128px"
				runat="server">Consumer Name</asp:label><asp:label id="lblConsumerNum" style="Z-INDEX: 102; LEFT: 184px; POSITION: absolute; TOP: 96px"
				runat="server">Consumer Number</asp:label></form>
	</body>
</HTML>
