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
	public class complaint_form : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblConsumerNum;
		protected System.Web.UI.WebControls.Label lblConsumerName;
		protected System.Web.UI.WebControls.Label lblNature;
		protected System.Web.UI.WebControls.Label lblGivenDate;
		protected System.Web.UI.WebControls.Label lblGivenTime;
		protected System.Web.UI.WebControls.Label lblArea;
		protected System.Web.UI.WebControls.Label lblCity;
		protected System.Web.UI.WebControls.Label lblState;
		protected System.Web.UI.WebControls.Label lblFaultAt;
		protected System.Web.UI.WebControls.TextBox txtConsumerNum;
		protected System.Web.UI.WebControls.TextBox txtConsumerName;
		protected System.Web.UI.WebControls.DropDownList cboNature;
		protected System.Web.UI.WebControls.TextBox txtGivenDate;
		protected System.Web.UI.WebControls.TextBox txtArea;
		protected System.Web.UI.WebControls.TextBox txtCity;
		protected System.Web.UI.WebControls.DropDownList cboFaultAt;
		protected System.Web.UI.WebControls.Button cmdNewFormSubmit;
		protected System.Web.UI.WebControls.RequiredFieldValidator txtConsumerNumReqdValidator;
		protected System.Web.UI.WebControls.RequiredFieldValidator txtConsumerNameReqdValidator;
		protected System.Web.UI.WebControls.RequiredFieldValidator txtConsumerAreaReqdValidator;
		protected System.Web.UI.WebControls.RequiredFieldValidator txtConsumerCityReqdValidator;
		protected System.Web.UI.WebControls.DropDownList cboState;
		protected System.Web.UI.WebControls.CompareValidator txtConsumerNumCmpValidator;
		protected System.Web.UI.WebControls.Label lblRefNum;
		protected System.Web.UI.WebControls.TextBox txtRefNum;
		protected System.Web.UI.WebControls.Calendar calendarGivenDate;
		protected System.Web.UI.WebControls.ImageButton imgGivenDate;
		protected System.Web.UI.WebControls.CompareValidator cboNatureCmpValidator;
		protected System.Web.UI.WebControls.CompareValidator cboStateCmpValidator;
		protected System.Web.UI.WebControls.CompareValidator cboFaultAtCmpValidator;
		protected System.Web.UI.WebControls.TextBox txtGivenTimeHour;
		protected System.Web.UI.WebControls.TextBox txtGivenTimeMinute;
		protected System.Web.UI.WebControls.RangeValidator txtGivenTimeHourRangeValidator;
		protected System.Web.UI.WebControls.RegularExpressionValidator txtConsumerNameRegExValidator;
		protected System.Web.UI.WebControls.ValidationSummary newComplaintValidationSummary;
		protected System.Web.UI.WebControls.RangeValidator txtGivenTimeMinuteRangeValidator;
		protected System.Web.UI.WebControls.RegularExpressionValidator txtAreaRegExValidator;
		protected System.Web.UI.WebControls.RegularExpressionValidator txtCityRegExValidator;
		protected System.Web.UI.WebControls.TextBox txtGivenTime;
		protected System.Web.UI.WebControls.Label lblNewCmplHeading;
		protected System.Web.UI.WebControls.Label lblPhoneNum;
		protected System.Web.UI.WebControls.TextBox txtPhoneNum;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator1;
		protected System.Web.UI.WebControls.Label lblNewComplaintMsg;
		private string strConnectionString=ConfigurationSettings .AppSettings ["connectionString"];
		private string strCommandString="";
		private void Page_Load(object sender, System.EventArgs e)
		{
			//checking whether user is logged in or not
			if(Session["user_id"]==null)
				Response.Redirect ("errorPage.aspx");
			//auto generating refernce number
			strCommandString="select count(ref_num)+1 from complaints_new_tb";
			txtRefNum .Text =ComplaintsDB .FetchScalar(strConnectionString ,strCommandString );
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
			this.calendarGivenDate.SelectionChanged += new System.EventHandler(this.calendarGivenDate_SelectionChanged);
			this.imgGivenDate.Click += new System.Web.UI.ImageClickEventHandler(this.ImageButton1_Click);
			this.cmdNewFormSubmit.Click += new System.EventHandler(this.cmdNewFormSubmit_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void ImageButton1_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			calendarGivenDate.Visible =true;
		}

		private void calendarGivenDate_SelectionChanged(object sender, System.EventArgs e)
		{
			/*assigning selected date to given date */
			txtGivenDate.Text =calendarGivenDate.SelectedDate.ToShortDateString()  .ToString ();
			/*making calendar invisible*/
			calendarGivenDate .Visible =false;
			/*enabling the submit button*/
			cmdNewFormSubmit.Enabled =true;
		}

		private void cmdNewFormSubmit_Click(object sender, System.EventArgs e)
		{
			bool blnResult=true;
			int intFlag;
			/*combining hour and minute together*/
			txtGivenTime.Text =txtGivenTimeHour .Text +":"+txtGivenTimeMinute .Text;
			/*checking whether consumer details available or not */
			strCommandString ="select count(meter_num) from complaints_consumers_tb where meter_num='"+txtConsumerNum .Text +"'";
			intFlag=int.Parse (ComplaintsDB .FetchScalar (strConnectionString ,strCommandString ));
			if(intFlag==0)	/*new consumer - inserting data into consumers table*/
			{
				strCommandString ="insert into complaints_consumers_tb values('"+txtConsumerNum.Text +"','"+txtConsumerName .Text +"','"+txtPhoneNum .Text+"','"+txtArea .Text +"','"+txtCity .Text +"','"+cboState.Items [cboState .SelectedIndex ]+"')";
				try
				{
					blnResult= ComplaintsDB.FetchBoolean (strConnectionString ,strCommandString );
				}
				catch(Exception exception)
				{
					lblNewComplaintMsg .Text ="Error while insertion " +exception.Message .ToString ();
					return;
				}
			}
			if(blnResult) //previous insertion is successful
			{
				//checking whether consumer complaint already exists
				strCommandString="select count(consumer_num) from complaints_new_tb,complaints_assignment_tb where consumer_num='"+txtConsumerNum .Text +"'";
				//and status not in ('CLOSED',null) and complaints_new_tb.ref_num=complaints_assignment_tb.ref_num"
				intFlag=int.Parse (ComplaintsDB .FetchScalar (strConnectionString ,strCommandString) );
				if(intFlag==1)
				{
					lblNewComplaintMsg .Text ="Complaint is under processing";
					Response.Redirect ("information.html");
				}
				/* inserting complaint details into new complaints table*/
				strCommandString ="insert into complaints_new_tb values('"+txtRefNum.Text +"','"+txtGivenDate .Text +"','"+txtGivenTime .Text +"','"+cboNature .Items [cboNature .SelectedIndex ]+"','"+cboFaultAt .Items [cboFaultAt .SelectedIndex ]+"','"+txtConsumerNum .Text +"','"+ Session["user_id"].ToString ()+"')";
				blnResult= ComplaintsDB.FetchBoolean (strConnectionString ,strCommandString );
				if(blnResult) /*insertion successfull*/
					Response.Redirect ("insertionSuccess.aspx");
			}
			else /* insertion failed*/
				lblNewComplaintMsg .Text ="Insertion failed";
		}
	}
}
