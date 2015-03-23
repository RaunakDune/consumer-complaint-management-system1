using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration ;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using DBActions;

namespace consumer_complaints
{
	/// <summary>
	/// Summary description for closeComplaint.
	/// </summary>
	public class closeComplaint : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblCloseComplaintRefNum;
		protected System.Web.UI.WebControls.Label lblCloseComplaintAssignedDate;
		protected System.Web.UI.WebControls.Label lblCloseComplaintClosedDate;
		protected System.Web.UI.WebControls.Label lblCloseComplaintClosedTime;
		protected System.Web.UI.WebControls.Label lblCloseComplaintTimeTaken;
		protected System.Web.UI.WebControls.Label lblCloseComplaintDelayReason;
		protected System.Web.UI.WebControls.TextBox txtCloseComplaintRefNum;
		protected System.Web.UI.WebControls.TextBox txtCloseComplaintAssignedDate;
		protected System.Web.UI.WebControls.TextBox txtCloseComplaintClosedDate;
		protected System.Web.UI.WebControls.TextBox txtCloseComplaintTimeTaken;
		protected System.Web.UI.WebControls.TextBox txtCloseComplaintDelayReason;
		protected System.Web.UI.WebControls.RequiredFieldValidator txtCloseComplaintRefNumReqdValidator;
		protected System.Web.UI.WebControls.Calendar calendarClosedDate;
		protected System.Web.UI.WebControls.TextBox txtCloseComplaintClosedTime;
		protected System.Web.UI.WebControls.ImageButton imgCmdCloseComplaintClosedDate;
		protected System.Web.UI.WebControls.Button cmdCloseComplaintClose;
		protected System.Web.UI.WebControls.TextBox txtCloseComplaintClosedTimeHour;
		protected System.Web.UI.WebControls.TextBox txtCloseComplaintClosedTimeMinute;
		protected System.Web.UI.WebControls.RangeValidator txtCloseComplaintClosedTimeHourRangeValidator;
		protected System.Web.UI.WebControls.RangeValidator txtCloseComplaintClosedTimeMinuteRangeValidator;
		protected System.Web.UI.WebControls.Label lblCloseComplaintRefNumMsg;
		protected System.Web.UI.WebControls.Label lblCloseComplaintHeading;
		protected System.Web.UI.WebControls.Button cmdCloseComplaintGenerate;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.Label lblCloseComplaintClosedDateMsg;
	
		private string strConnectionString=ConfigurationSettings .AppSettings ["connectionString"].ToString ();
		protected System.Web.UI.WebControls.RegularExpressionValidator txtCloseComplaintRefNumRegExValidator;
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
			this.cmdCloseComplaintClose.Click += new System.EventHandler(this.cmdCloseComplaintClose_Click);
			this.calendarClosedDate.SelectionChanged += new System.EventHandler(this.calendarClosedDate_SelectionChanged);
			this.imgCmdCloseComplaintClosedDate.Click += new System.Web.UI.ImageClickEventHandler(this.imgCmdCloseComplaintClosedDate_Click);
			this.cmdCloseComplaintGenerate.Click += new System.EventHandler(this.cmdCloseComplaintGenerate_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void imgCmdCloseComplaintClosedDate_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			calendarClosedDate.Visible =true;
		}
		private void calendarClosedDate_SelectionChanged(object sender, System.EventArgs e)
		{
			txtCloseComplaintClosedDate.Text =calendarClosedDate.SelectedDate.ToShortDateString () .ToString ();
			//txtCloseComplaintClosedDate.Text =calendarClosedDate.SelectedDate.ToString ();
			calendarClosedDate .Visible =false;
		}

		private void cmdCloseComplaintClose_Click(object sender, System.EventArgs e)
		{
			/* checking whether closed date is null */
			if(txtCloseComplaintClosedDate .Text .Equals (""))
			{
				lblCloseComplaintClosedDateMsg .Text ="Select closed date";
				return;
			}
			try
			{
				/* comparing complaint assigned date and date to be closed */
				int intFlag=ComplaintsDB .CompareDates (strConnectionString ,strCommandString,txtCloseComplaintRefNum .Text ,txtCloseComplaintAssignedDate .Text ,txtCloseComplaintClosedDate .Text,"complaints_validateDates_proc");
				if(intFlag<0) /* invalid date of closing */
				{
					lblCloseComplaintClosedDateMsg .Text ="Date clsoed is before complaint assigned.";
					return;
				}
				/* checking whether closed time is null */
				if(txtCloseComplaintClosedTimeHour .Text .Trim ().Equals ("") || txtCloseComplaintClosedTimeMinute .Text.Trim () .Equals (""))
				{
					lblCloseComplaintClosedDateMsg .Text ="Enter valid closed time";
					return;
				}
				/* combining hour and minute together */
				txtCloseComplaintClosedTime .Text=txtCloseComplaintClosedTimeHour .Text +":"+txtCloseComplaintClosedTimeMinute .Text ;
				lblCloseComplaintClosedDateMsg .Text ="";
				/* calculating time taken in hrs */
				/*getting complaint given date and time */
				strCommandString="select given_date,given_time from complaints_new_tb where ref_num='"+txtCloseComplaintRefNum  .Text +"'";
				DataSet dataSet=ComplaintsDB.FetchDataSet (strConnectionString ,strCommandString,"complaints_new_tb" );
				string strGiven_date_string=dataSet.Tables ["complaints_new_tb"].Rows [0]["given_date"].ToString ();
				string strGiven_time_string=dataSet .Tables ["complaints_new_tb"].Rows [0]["given_time"].ToString ();
				/* combining complaint given date and time */
				string strGiven_date =strGiven_date_string+" "+strGiven_time_string;
				/* combining complaint closed date and time */
				string strClosed_date=txtCloseComplaintClosedDate.Text +" "+txtCloseComplaintClosedTime .Text ;
				/* retrieving difference between complaint given date and closed date in hours */
				intFlag=ComplaintsDB.CompareDates (strConnectionString ,strCommandString,txtCloseComplaintRefNum .Text ,strGiven_date,strClosed_date,"complaints_validateDatesWithTimes_proc");
				txtCloseComplaintTimeTaken .Text =intFlag.ToString ();
				if(intFlag<0)
				{
					lblCloseComplaintClosedDateMsg .Text ="Invalid times: closed time is before given time as on same day";
					return;
				}
				// checcking fault-at
				int intIncentive;
				strCommandString="select falut_at from complaints_new_tb where ref_num='"+txtCloseComplaintRefNum .Text +"'";
				string strFaultAt=ComplaintsDB .FetchScalar (strConnectionString,strCommandString);
				if(strFaultAt.Equals ("POLE"))
				{
					/* retrieving previous incentive value */ 
					strCommandString ="select incentive_earned from complaints_linemen_tb,complaints_assignment_tb where complaints_assignment_tb.ref_num='"+txtCloseComplaintRefNum .Text +"' and complaints_assignment_tb.lineman_num=complaints_linemen_tb.lineman_num ";
					string strIncentive=ComplaintsDB .FetchScalar (strConnectionString ,strCommandString );
					intIncentive=int.Parse (strIncentive);
					if(intFlag<60)
						intIncentive+=5;
				}
				else
					intIncentive=0;
				string strIncentive_earned=intIncentive.ToString ();
				/* qry to update incentive and status of lineman to 'AVAILABLE' for given reference number */
				strCommandString ="update complaints_linemen_tb set incentive_earned='"+strIncentive_earned+"',status='AVAILABLE' where lineman_num = (select lineman_num from complaints_assignment_tb where ref_num='"+txtCloseComplaintRefNum .Text+"')" ;
				ComplaintsDB .ChangeStatus (strConnectionString ,strCommandString );
				/* query to update complaint status to 'CLOSED' */ 
				strCommandString ="update complaints_assignment_tb set status='CLOSED',delay_reason='delayed as no lineman available' where ref_num='"+txtCloseComplaintRefNum .Text +"'";
				ComplaintsDB .ChangeStatus (strConnectionString ,strCommandString );
				/* inserting complaints closed details into close_list table */
				strCommandString ="insert into complaints_close_list_tb values('"+txtCloseComplaintRefNum .Text +"','"+txtCloseComplaintClosedDate .Text +"','"+txtCloseComplaintClosedTime .Text +"','"+txtCloseComplaintTimeTaken.Text +"')";
				ComplaintsDB .ChangeStatus (strConnectionString ,strCommandString );
				lblCloseComplaintClosedDateMsg  .Text="";
			}
			catch(Exception exception)
			{
				lblCloseComplaintClosedDateMsg .Text ="Database error: insertion failed-"+exception .Message .ToString ();
				return;
			}
		}
		private void cmdCloseComplaintGenerate_Click(object sender, System.EventArgs e)
		{
			try
			{
				/*checking whether given reference number exists or not */
				strCommandString="select ref_num from complaints_new_tb where ref_num='"+txtCloseComplaintRefNum .Text +"'";
				bool blnResult=ComplaintsDB .CheckForExistance(strConnectionString,strCommandString );
				if(!blnResult)
				{
					lblCloseComplaintRefNumMsg .Text ="Entered reference number doesn't exist";
					return;
				}
				/* checking whether complaint with given reference number is tried for assignment or not */
				strCommandString ="select ref_num from complaints_assignment_tb where ref_num='"+txtCloseComplaintRefNum  .Text +"'";
				blnResult=ComplaintsDB .CheckForExistance(strConnectionString,strCommandString );
				if(!blnResult)
				{
					lblCloseComplaintRefNumMsg .Text ="Complaint for given reference number is not yet assigned ";
					return;
				}
				/*checking status of complaint with given reference number */
				strCommandString ="select status from complaints_assignment_tb where ref_num='"+txtCloseComplaintRefNum  .Text +"'";
				string strStatus=ComplaintsDB .FetchScalar (strConnectionString ,strCommandString );
				if(strStatus.Equals ("PENDING"))
				{
					lblCloseComplaintRefNumMsg .Text ="Complaint for given reference number is not yet assigned bcz of non availability of linemen";
					return;
				}
				else if(strStatus.Equals ("CLOSED"))
				{
					lblCloseComplaintRefNumMsg.Text ="complaint already closed";
					return;
				}
				/*retrieving assigned date and delay reason for entered reference number */
				strCommandString ="select assign_date,delay_reason from complaints_assignment_tb where ref_num='"+txtCloseComplaintRefNum  .Text +"'";
				
				DataSet dataSet=ComplaintsDB .FetchDataSet (strConnectionString ,strCommandString ,"complaints_assignment_tb");
				
				txtCloseComplaintAssignedDate .Text =dataSet.Tables ["complaints_assignment_tb"].Rows [0]["assign_date"].ToString ();
				txtCloseComplaintDelayReason .Text =dataSet.Tables ["complaints_assignment_tb"].Rows [0]["delay_reason"].ToString ();
				
				cmdCloseComplaintClose .Enabled =true;
			}
			catch(Exception exception)
			{
				lblCloseComplaintClosedDateMsg .Text ="insertion failed:"+exception .Message .ToString ();
				return;
			}
		}
	}
}
