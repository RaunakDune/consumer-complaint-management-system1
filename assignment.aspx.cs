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
	/// Summary description for assignment.
	/// </summary>
	public class assignment : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblAssignmentRefNum;
		protected System.Web.UI.WebControls.Label lblAssignmentLinemanNum;
		protected System.Web.UI.WebControls.Label lblAssignmentAssignDate;
		protected System.Web.UI.WebControls.Label lblAssignmentDelayReason;
		protected System.Web.UI.WebControls.TextBox txtAssignmentRefNum;
		protected System.Web.UI.WebControls.DropDownList cboAssignmentLinemanNum;
		protected System.Web.UI.WebControls.TextBox txtAssignmentAssignDate;
		protected System.Web.UI.WebControls.TextBox txtAssignmentDelayReason;
		protected System.Web.UI.WebControls.Button cmdAssignmentAssign;
		protected System.Web.UI.WebControls.ImageButton imgAssignmentAssignDate;
		protected System.Web.UI.WebControls.Calendar calendarAssignmentAssignDate;
		protected System.Web.UI.WebControls.Label lblAssignmentHeading;
		protected System.Web.UI.WebControls.Label lblAssignmentMsg;
		protected System.Web.UI.WebControls.RequiredFieldValidator txtAssignmentDelayReasonReqdValidator;
		protected System.Web.UI.WebControls.RequiredFieldValidator txtAssginmentRefNumReqdValidator;
		protected System.Web.UI.WebControls.Label lblAssignmentRefNumMsg;
		protected System.Web.UI.WebControls.Label lblAssignmentAssignDateMsg;		
		private string strConnectionString=ConfigurationSettings .AppSettings ["connectionString"];
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.RegularExpressionValidator txtAssignmentRefNumRegExValidator;
		string strCommandString="";
		private void Page_Load(object sender, System.EventArgs e)
		{
			//checking whether user is logged in
			if(Session["user_id"]==null)
				Response.Redirect ("errorPage.aspx");
			//generating avalilable linemen number
			if(!Page .IsPostBack )
			{
				cboAssignmentLinemanNum.Items .Clear ();
				strCommandString="select lineman_num from complaints_linemen_tb where status='AVAILABLE'";
				cboAssignmentLinemanNum.DataSource =(ComplaintsDB .FetchDataSet  (strConnectionString,strCommandString,"complaints_linemen_tb")).Tables ["complaints_linemen_tb"];
				cboAssignmentLinemanNum.DataMember ="complaints_linemen_tb";
				cboAssignmentLinemanNum.DataTextField ="lineman_num";
				cboAssignmentLinemanNum.DataBind ();
				if(cboAssignmentLinemanNum.Items .Count ==0)
				{
					//making required fields visible and invisible
					cboAssignmentLinemanNum.Enabled =false;
					lblAssignmentMsg .Text ="No line man is currently available. Enter appropriate delay reason";
					lblAssignmentMsg .Visible =true;
					lblAssignmentDelayReason .Visible =true;
					txtAssignmentDelayReason .Visible =true;
					txtAssignmentDelayReasonReqdValidator .Enabled =true;
				}
				else
					cboAssignmentLinemanNum.Items .Insert (0,"select");
			}
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
			this.calendarAssignmentAssignDate.SelectionChanged += new System.EventHandler(this.calendarAssignmentAssignDate_SelectionChanged);
			this.imgAssignmentAssignDate.Click += new System.Web.UI.ImageClickEventHandler(this.imgAssignmentAssignDate_Click);
			this.cmdAssignmentAssign.Click += new System.EventHandler(this.cmdAssignmentAssign_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		private void imgAssignmentAssignDate_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			calendarAssignmentAssignDate.Visible =true;
		}

		private void calendarAssignmentAssignDate_SelectionChanged(object sender, System.EventArgs e)
		{
			/*setting the date selected to assigndate */
			txtAssignmentAssignDate .Text =calendarAssignmentAssignDate .SelectedDate.ToShortDateString()  .ToString ();
			/*making calendar invisible */
			calendarAssignmentAssignDate  .Visible =false;
			//cmdAssignmentAssign.Enabled =true;
		}
		private void cmdAssignmentAssign_Click(object sender, System.EventArgs e)
		{
			/* checking whether given reference number is existing or not*/
			strCommandString="select ref_num from complaints_new_tb where ref_num='"+txtAssignmentRefNum .Text +"'";
			bool blnResult=ComplaintsDB .CheckForExistance(strConnectionString,strCommandString );
			if(!blnResult)
			{
				lblAssignmentRefNumMsg .Text ="Entered complaint reference number doesn't exist";
				return;
			}
			/* checking whether assign date has choosen or not */
			if(cboAssignmentLinemanNum.Items .Count >0)
			{
				if(txtAssignmentAssignDate .Text.ToString ().Trim ().Equals (""))
				{
					lblAssignmentAssignDateMsg .Text ="Select assign date";
					return;
				}
				/* comparing complaint given date and date to be assigned */
				/*fetching complaint given date for entered refernce number */
				lblAssignmentRefNumMsg .Text ="";
				strCommandString="select given_date from complaints_new_tb where ref_num='"+txtAssignmentRefNum .Text+"'";
				string strDate_first_string=ComplaintsDB .FetchScalar(strConnectionString ,strCommandString );
				int intFlag=ComplaintsDB .CompareDates (strConnectionString ,strCommandString,txtAssignmentRefNum .Text ,strDate_first_string,txtAssignmentAssignDate.Text,"complaints_validateDates_proc");
				if(intFlag<0) /* invalid assign date */
				{
					lblAssignmentAssignDateMsg .Text ="date to be assigned is before complaint given date";
					return;
				}
			}
			/* checking whether complaint with given reference number is considered for assignment */
			strCommandString="select count(ref_num) from complaints_assignment_tb where ref_num='"+txtAssignmentRefNum .Text +"'";
			int intCount=ComplaintsDB.CheckForDuplicates(strConnectionString,strCommandString);
			if(intCount==1) /*reference number existing and now cheking for 'PENDING' status */
			{
				if(cboAssignmentLinemanNum.Items .Count!=0) /* linemen available for assignment */
				{
					try
					{
						/* if no lineman number is selected */
						if(cboAssignmentLinemanNum.SelectedIndex<= 0) 
						{
							Label1 .Text ="select lineman number";
							return;
						}
						/* checking whether complaint with given  reference number is already assigned or not*/
						/* query for getting status for given reference number */
						strCommandString="select status from complaints_assignment_tb where ref_num='"+txtAssignmentRefNum .Text +"'";
						/* getting status for given reference number */
						string strStatus=ComplaintsDB .FetchScalar (strConnectionString ,strCommandString );
						if(strStatus.Equals ("ALLOTTED")|strStatus.Equals ("CLOSED"))
						{
							lblAssignmentMsg .Text ="Already assigned";
							return;
						}
						/* not yet assigned */
						/* assigning work to selected lineman and updating required fileds in assignment table */
						strCommandString="update complaints_assignment_tb set lineman_num='"+cboAssignmentLinemanNum.Items [cboAssignmentLinemanNum.SelectedIndex ]+"',status='ALLOTTED',assign_date='"+txtAssignmentAssignDate .Text +"',delay_reason='delayed-no lineman is available' where ref_num='"+txtAssignmentRefNum .Text +"'";
						ComplaintsDB .ChangeStatus (strConnectionString ,strCommandString );
						/* updating the status of selected lineman to 'ALLOTTED' */
						strCommandString ="update complaints_linemen_tb set status='ALLOTTED' where lineman_num='"+cboAssignmentLinemanNum.Items [cboAssignmentLinemanNum.SelectedIndex ]+"'";
						ComplaintsDB .ChangeStatus (strConnectionString ,strCommandString );
						Response.Redirect ("assignmentSuccess.aspx");
					}
					catch(Exception exception)
					{
						lblAssignmentMsg .Text ="insertion failed"+exception.Message .ToString ();
						return;
					}
				}
				else
				{
					lblAssignmentMsg .Text ="This complaint is already in pending status";
					return;
				}
			}
			else /* not already assigned */
			{
				if(cboAssignmentLinemanNum.Items .Count ==0) /* no lineman available to allot */
				{
					// checking whether delay reason is entered
					if(txtAssignmentDelayReason .Text .Trim ().Equals (""))
					{
						lblAssignmentMsg .Text ="enter delay reason";
						return;
					}
					/* query to perform insertion when no lineman is available */
					strCommandString ="insert into complaints_assignment_tb values('"+txtAssignmentRefNum .Text+"',null,null,'"+txtAssignmentDelayReason .Text +"','PENDING')";
				}
				else  /* lineman is available to allot */
				{
					try
					{
						if(cboAssignmentLinemanNum.SelectedIndex< 1) /* if no lineman number is selected */
						{
							Label1 .Text ="select lineman number";
							return;
						}
						/*updating selected lineman status to 'ALLOTTED' */
						strCommandString="update complaints_linemen_tb set status='ALLOTTED' where lineman_num='"+cboAssignmentLinemanNum.Items [cboAssignmentLinemanNum.SelectedIndex ]+"'";
						ComplaintsDB .ChangeStatus (strConnectionString ,strCommandString );
						/*query to perform insertion when lineman is available */
						strCommandString ="insert into complaints_assignment_tb values('"+txtAssignmentRefNum .Text+"','"+txtAssignmentAssignDate .Text +"','"+cboAssignmentLinemanNum.Items [cboAssignmentLinemanNum.SelectedIndex ]+"',null,'ALLOTTED')";
					}
					catch(Exception exception)
					{
						lblAssignmentMsg .Text ="error while insertion:"+exception.Message .ToString ();
						return;
					}
				}
				/* performing insertion */
				blnResult=ComplaintsDB.FetchBoolean (strConnectionString ,strCommandString );
				if(blnResult)
					Response .Redirect ("assignmentSuccess.aspx");
				else
					Label1.Text ="failed";
			}
		}
	}
}