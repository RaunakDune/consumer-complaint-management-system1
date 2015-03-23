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
	public class report_rangeSelection : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblRptStartDate;
		protected System.Web.UI.WebControls.TextBox txtStartDate;
		protected System.Web.UI.WebControls.TextBox txtEndDate;
		protected System.Web.UI.WebControls.Calendar calendarStart;
		protected System.Web.UI.WebControls.Calendar calendarEnd;
		protected System.Web.UI.WebControls.Button cmdViewRpt;
		protected System.Web.UI.WebControls.ImageButton imgEndDate;
		protected System.Web.UI.WebControls.ImageButton imgStartDate;
		protected System.Web.UI.WebControls.Label lblRptEndDate;
		protected System.Web.UI.WebControls.DataGrid dataGridReportStaff;

		private string strConnectionString=ConfigurationSettings .AppSettings ["connectionString"].ToString ();
		protected System.Web.UI.WebControls.Label lblReportStaffMsg;
		private string strCommandString="";

		private void Page_Load(object sender, System.EventArgs e)
		{
			//checking whether user is logged in
			if(Session["user_id"]==null)
				Response.Redirect ("errorPage.aspx");
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
			this.cmdViewRpt.Click += new System.EventHandler(this.cmdViewRpt_Click);
			this.calendarEnd.SelectionChanged += new System.EventHandler(this.calendarEnd_SelectionChanged);
			this.imgEndDate.Click += new System.Web.UI.ImageClickEventHandler(this.ImageButton2_Click);
			this.imgStartDate.Click += new System.Web.UI.ImageClickEventHandler(this.ImageButton1_Click);
			this.calendarStart.SelectionChanged += new System.EventHandler(this.calendarStart_SelectionChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void ImageButton1_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			calendarStart.Visible =true;
		}
		private void ImageButton2_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			calendarEnd.Visible =true;
		}
		private void calendarStart_SelectionChanged(object sender, System.EventArgs e)
		{
			txtStartDate.Text =calendarStart.SelectedDate.ToShortDateString () .ToString ();
			calendarStart .Visible =false;
		}
		private void calendarEnd_SelectionChanged(object sender, System.EventArgs e)
		{
			txtEndDate.Text =calendarEnd.SelectedDate.ToShortDateString()  .ToString ();
			calendarEnd .Visible =false;
		}

		private void cmdViewRpt_Click(object sender, System.EventArgs e)
		{
			//checking whether dates entered
			if(txtStartDate.Text.Equals ("") | txtEndDate.Text .Equals (""))
			{
				lblReportStaffMsg .Text ="Select dates";
				return;
			}
			try
			{
				int intResult;
				//checking whether range selected is valid
				intResult=DateTime .Compare(Convert.ToDateTime (txtStartDate.Text) ,Convert.ToDateTime (txtEndDate.Text) );
				if(intResult>0)
				{
					lblReportStaffMsg  .Text ="invalid date range";
					return;
				}
				/* query to fetch results from view */
				strCommandString="select [Consumer Name],[Complaint Nature],[Given Date],[Given Time],[Closed Date],[Closed Time],[Lineman Number],[Complaint Status],[Reason for Delay] from complaints_report_staff_vw where staff_id='"+Session ["user_id"].ToString ()+"' and (cast([Given Date] as datetime)>'"+txtStartDate.Text +"' and cast([Given Date] as datetime)<'"+txtEndDate.Text +"')";
				DataSet dataSet=ComplaintsDB .FetchDataSet (strConnectionString ,strCommandString ,"complaints_report_staff_vw");
				/* updating closed date and times to null for which complaints or not closed */
				for(int intTraverser=0;intTraverser<dataSet .Tables [0].Rows .Count ;intTraverser++)
					if(dataSet .Tables [0].Rows [intTraverser]["Complaint Status"].ToString ().Equals ("PENDING")|dataSet .Tables [0].Rows [intTraverser]["Complaint Status"].ToString ().Equals ("PENDING"))
					{
						dataSet.Tables [0].Rows [intTraverser]["Closed Date"]=null;
						dataSet.Tables [0].Rows [intTraverser]["Closed Time"]=null;
					}
				/* binding data to datagrid */
				dataGridReportStaff.DataSource =dataSet;
				dataGridReportStaff .DataBind ();
				dataGridReportStaff .Visible =true;
				lblReportStaffMsg .Text ="";
			}
			catch(Exception exception)
			{
				lblReportStaffMsg .Text ="Database error: "+exception .Message .ToString ();
				return;
			}
		}
	}
}
