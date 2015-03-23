using System;
using System.Collections;
using System.Configuration ;
using System.ComponentModel;
using DBActions;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace consumer_complaints
{
	public class WebForm1 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblUserID;
		protected System.Web.UI.WebControls.Label lblPasswd;
		protected System.Web.UI.WebControls.TextBox txtUserID;
		protected System.Web.UI.WebControls.TextBox txtPasswd;
		protected System.Web.UI.WebControls.RequiredFieldValidator txtUserIDReqdValidator;
		protected System.Web.UI.WebControls.RequiredFieldValidator txtPasswdReqdValidator;
		protected System.Web.UI.WebControls.Label lblLoginHeading;
		protected System.Web.UI.WebControls.Panel pnlDefaultPageFeatures;
		protected System.Web.UI.WebControls.Panel pnlDefaultPageLogin;
		protected System.Web.UI.WebControls.RegularExpressionValidator txtPasswdRegExValidator;
		protected System.Web.UI.WebControls.Button cmdLogin;
// getting connectionString value from web.config appSettings 
		private string strConnectionString=ConfigurationSettings .AppSettings ["connectionString"];
		protected System.Web.UI.WebControls.RegularExpressionValidator txtUserIDRegExValidator;
		private String strCommandString="";
		private void Page_Load(object sender, System.EventArgs e)
		{
			
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.cmdLogin.Click += new System.EventHandler(this.cmdLogin_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void cmdLogin_Click(object sender, System.EventArgs e)
		{
			/*checking whether user is valid or not based on credentials entered*/
			strCommandString="select user_id from complaints_users_tb where user_id='"+txtUserID .Text +"' and passwd='"+txtPasswd .Text +"'";
			bool blnResult=ComplaintsDB .CheckForExistance(strConnectionString,strCommandString );
			if(blnResult) /*user exists */
			{
				/*creating session for user*/
				Session ["user_id"]=txtUserID.Text ;
				if(int.Parse (txtUserID.Text ) >100)
					Response.Redirect ("Welcome.html");
				else
					Response.Redirect ("Welcome_JE.aspx");
			}
			else  /*user doesn't exist*/
					Response.Write ("Invalid User");
		}
	}
}
