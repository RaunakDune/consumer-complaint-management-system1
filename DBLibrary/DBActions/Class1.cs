using System;
using System.Data ;
using System.Data.SqlClient ;
namespace DBActions
{
	public sealed class ComplaintsDB
	{
		private static SqlConnection connection;
		private static SqlCommand command;
		private static SqlDataAdapter dataAdapter;
		private static DataSet dataSet;
		static ComplaintsDB()
		{
		}
		public static bool CheckForExistance(string strConnectionString,string strCommandString)
		{
			connection=new SqlConnection (strConnectionString);
			connection .Open ();
			command=new SqlCommand (strCommandString,connection );
			object objResult=command.ExecuteScalar () ;
			connection.Close ();
			if(objResult==null)
				return false;
			else 
				return true;
		}
		/*following method performs avoiding duplications */
		public static int CheckForDuplicates(string strConnectionString,string strCommandString)
		{
			connection=new SqlConnection (strConnectionString);
			connection .Open ();
			command=new SqlCommand (strCommandString,connection );
			int intCount=int.Parse ( command.ExecuteScalar ().ToString ());
			connection.Close ();
			return intCount;
		}
		/* following method returns a number converted as string*/
		public static string FetchScalar(string strConnectionString,string strCommandString)
		{
			connection=new SqlConnection (strConnectionString);
			connection .Open ();
			command=new SqlCommand (strCommandString,connection );
			string strResult=command.ExecuteScalar ().ToString () ;
			connection.Close ();
			return strResult;
		}
		/* following method inserts new complaints */
		public static void ChangeStatus(string strConnectionString,string strCommandString)
		{
			connection=new SqlConnection (strConnectionString);
			connection .Open ();
			command=new SqlCommand (strCommandString,connection );
			command.ExecuteNonQuery ();
			connection .Close ();
		}
		public static bool FetchBoolean(string strConnectionString,string strCommandString)
		{
			connection=new SqlConnection (strConnectionString);
			connection .Open ();
			command=new SqlCommand (strCommandString,connection );
			int intResult =command.ExecuteNonQuery ();
			connection .Close ();
			if(intResult>0)
				return true;
			else
				return false;
		}
		public static DataSet FetchDataSet(string strConnectionString,string strCommandString,string strTableName)
		{
			connection=new SqlConnection (strConnectionString);
			connection .Open ();
			dataAdapter=new SqlDataAdapter (strCommandString,connection);
			dataSet=new DataSet ();
			dataAdapter.Fill (dataSet ,strTableName);
			connection .Close ();
			return dataSet;
		}
		/*performing comparison of given dates */
		public static int CompareDates(string strConnectionString,string strCommandString,string strRefNum,string strDate_first_string,string strDate_second_string,string strProcedureName)
		{
			connection =new SqlConnection (strConnectionString );
			connection .Open ();
			DateTime dtmDate_first=Convert.ToDateTime (strDate_first_string);
			DateTime dtmDate_second=Convert.ToDateTime (strDate_second_string);
			strCommandString=strProcedureName;
			command =new SqlCommand (strCommandString,connection);
			command .CommandType =CommandType .StoredProcedure ;
			SqlParameter param=new SqlParameter ("@date1" ,SqlDbType.DateTime );
			param.Value =dtmDate_first;
			command.Parameters .Add (param);
			param=new SqlParameter ("@date2" ,SqlDbType.DateTime );
			param.Value =dtmDate_second;
			command.Parameters .Add (param);
			param=new SqlParameter ("@res" ,SqlDbType.Int  );
			param.Direction =ParameterDirection .Output ;
			command.Parameters .Add (param);
			command .ExecuteNonQuery ();
			connection .Close ();
			return int.Parse (command .Parameters[2].Value.ToString ());
		}
	}
}
