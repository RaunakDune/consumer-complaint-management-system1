using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Configuration ;
using DBActions;
namespace consumer_complaints
{
	/// <summary>
	/// Summary description for Welcome_JE.
	/// </summary>
	public class Welcome_JE : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button cmdJEViewReprt;
		protected System.Web.UI.WebControls.DataGrid dataGridReportJE;
		protected System.Web.UI.WebControls.HyperLink mgrLogoutLink;

		private string strConnectionString=ConfigurationSettings .AppSettings ["connectionString"];
		protected System.Web.UI.WebControls.Label Label1;
		private string strCommandString="";
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			//checking wheteher user is logged in
			if(Session["user_id"]==null)
				Response .Redirect ("errorPage.aspx");
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
			this.cmdJEViewReprt.Click += new System.EventHandler(this.cmdJEViewReprt_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void cmdJEViewReprt_Click(object sender, System.EventArgs e)
		{
			strCommandString ="select * from complaints_report_mgr_vw";
			dataGridReportJE .Visible =true;
			DataSet dataSet=ComplaintsDB .FetchDataSet (strConnectionString ,strCommandString ,"complaints_report_mgr_vw");
			for(int intTraverser=0;intTraverser<dataSet .Tables [0].Rows .Count ;intTraverser++)
				if(dataSet .Tables [0].Rows [intTraverser]["Complaint Status"].ToString ().Equals ("PENDING")|dataSet .Tables [0].Rows [intTraverser]["Complaint Status"].ToString ().Equals ("PENDING"))
				{
					dataSet.Tables [0].Rows [intTraverser]["Closed Date"]=null;
					dataSet.Tables [0].Rows [intTraverser]["Closed Time"]=null;
				}
			dataGridReportJE .DataSource =dataSet;
			dataGridReportJE .DataBind ();
		}
	}
}
