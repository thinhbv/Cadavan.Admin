using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Libs.Db;

namespace Libs.Content
{
	public class Customers
	{
		public int Id { get; set; }
		public string LastName { get; set; }
		public string FirstName { get; set; }
		public int OrderId { get; set; }
		public int PassengerType { get; set; }
		public DateTime Birthday { get; set; }
		public string Sex { get; set; }
		public int DepartBagValue { get; set; }
		public int ReturnBagValue { get; set; }
		public Customers()
        {

        }
		public bool CopyToCustomerHistory(int orderid, SqlTransaction mTran, SqlConnection mCon)
		{
			string sSQL;
			SqlCommand sqlCmd;
			DbHelper db = new DbHelper(Config.BookingConnectionStrings);
			try
			{
				//Copy data to history table
				sSQL = "INSERT m_Customers_History SELECT * FROM m_Customers WHERE Id=@Id";
				sqlCmd = new SqlCommand(sSQL, mCon, mTran);
				sqlCmd.Parameters.Add(new SqlParameter("@Id", orderid));
				sqlCmd.ExecuteNonQuery();
				//Delete data completed
				sSQL = "DELETE m_Customers WHERE Id=@Id";
				sqlCmd = new SqlCommand(sSQL, mCon, mTran);
				sqlCmd.Parameters.Add(new SqlParameter("@Id", orderid));
				sqlCmd.ExecuteNonQuery();
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<Customers> GetByOrderId(int orderid)
		{
			DbHelper db = new DbHelper(Config.BookingConnectionStrings);
			return db.GetListSP<Customers>("sp_m_Customers_Select_ByOrderId"
				, new SqlParameter("@OrderId", orderid));
		}
	}
}
