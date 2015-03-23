<%@ Page language="c#" Codebehind="default.aspx.cs" AutoEventWireup="false" Inherits="consumer_complaints.WebForm1" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>WebForm1</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script>
		window.resizeTo (1000,700)
		function fun1()
		{
			history.go (1);
		}							
		</script>
	</HEAD>
	<body bgColor="#cc9999" onload="fun1()" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:label id="lblLoginHeading" style="Z-INDEX: 102; LEFT: 240px; POSITION: absolute; TOP: 24px"
				runat="server" Font-Size="X-Large" Font-Names="Times New Roman" ForeColor="#400040" Font-Bold="True"
				Width="248px" Height="64px">
				<u>APSEB Fuse Call</u>
				<h4 align="center">complaints storer</h4>
			</asp:label>
			<asp:RegularExpressionValidator id="txtUserIDRegExValidator" style="Z-INDEX: 112; LEFT: 696px; POSITION: absolute; TOP: 256px"
				runat="server" ValidationExpression="[0-9]{1,4}" ErrorMessage="Must contain numbers" ControlToValidate="txtUserID"></asp:RegularExpressionValidator><asp:regularexpressionvalidator id="txtPasswdRegExValidator" style="Z-INDEX: 111; LEFT: 672px; POSITION: absolute; TOP: 288px"
				runat="server" Width="250px" ControlToValidate="txtPasswd" ErrorMessage="Password must be six characters long" ValidationExpression="[A-Za-z0-9]{6,12}"></asp:regularexpressionvalidator><asp:panel id="pnlDefaultPageFeatures" style="Z-INDEX: 110; LEFT: 64px; POSITION: absolute; TOP: 192px"
				runat="server" Width="312px" Height="114px">
				<H3>Features:
					<UL style="COLOR: gray" type="disc">
						<LI>
						Entering new Complaints
						<LI>
						Work assignment to Linemen
						<LI>
						Incentives to Linemen for quicker work completion
						<LI>
							Reports keeping track of status
						</LI>
					</UL>
				</H3>
			</asp:panel><asp:panel id="pnlDefaultPageLogin" style="Z-INDEX: 101; LEFT: 416px; POSITION: absolute; TOP: 224px"
				runat="server" Width="252px" Height="128px" BorderStyle="Dotted"></asp:panel><asp:requiredfieldvalidator id="txtPasswdReqdValidator" style="Z-INDEX: 107; LEFT: 680px; POSITION: absolute; TOP: 288px"
				runat="server" Width="184px" Display="Dynamic" ControlToValidate="txtPasswd" ErrorMessage="Empty Password not allowed"></asp:requiredfieldvalidator><asp:requiredfieldvalidator id="txtUserIDReqdValidator" style="Z-INDEX: 106; LEFT: 680px; POSITION: absolute; TOP: 256px"
				runat="server" Width="176px" Display="Dynamic" ControlToValidate="txtUserID" ErrorMessage="Empty User ID not allowed"></asp:requiredfieldvalidator><asp:textbox id="txtPasswd" style="Z-INDEX: 105; LEFT: 496px; POSITION: absolute; TOP: 280px"
				tabIndex="2" runat="server" TextMode="Password" MaxLength="12"></asp:textbox><asp:textbox id="txtUserID" style="Z-INDEX: 104; LEFT: 496px; POSITION: absolute; TOP: 248px"
				tabIndex="1" runat="server" MaxLength="4"></asp:textbox><asp:label id="lblPasswd" style="Z-INDEX: 103; LEFT: 432px; POSITION: absolute; TOP: 280px"
				runat="server">Password</asp:label><asp:label id="lblUserID" style="Z-INDEX: 108; LEFT: 424px; POSITION: absolute; TOP: 248px"
				runat="server">UserName</asp:label>
			<asp:Button id="cmdLogin" style="Z-INDEX: 109; LEFT: 608px; POSITION: absolute; TOP: 312px"
				runat="server" Text="Login" tabIndex="3"></asp:Button></form>
	</body>
</HTML>
