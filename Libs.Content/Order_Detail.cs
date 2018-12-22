using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Libs.Db;

namespace Libs.Content
{
	public class Order_Detail
	{
		public int OrderId { get; set; }
		public string TicketId { get; set; }
		public string CompanyName { get; set; }
		public string Code { get; set; }
		public DateTime StartDate { get; set; }
		public string DepTime { get; set; }
		public DateTime EndDate { get; set; }
		public string DicTime { get; set; }
		public string FirmImage { get; set; }
		public string TicketClassName { get; set; }
		public double AdultPriceNet { get; set; }
		public double AdultTaxAndFee { get; set; }
		public double AdultTotalPrice { get; set; }
		public double ChildPriceNet { get; set; }
		public double ChildTaxAndFee { get; set; }
		public double ChildTotalPrice { get; set; }
		public double BabyPriceNet { get; set; }
		public double BabyTaxAndFee { get; set; }
		public double BabyTotalPrice { get; set; }
		public string Type { get; set; }
		public bool Hold { get; set; }
		public int Transit { get; set; }
		public Order_Detail()
        {
        }
		public bool CopyToOrderDetailHistory(int orderid, SqlTransaction mTran, SqlConnection mCon)
		{
			string sSQL;
			SqlCommand sqlCmd;
			DbHelper db = new DbHelper(Config.BookingConnectionStrings);
			try
			{
				//Copy data to history table
				sSQL = "INSERT Order_Detail_History SELECT * FROM Order_Detail WHERE Id=@Id";
				sqlCmd = new SqlCommand(sSQL, mCon, mTran);
				sqlCmd.Parameters.Add(new SqlParameter("@Id", orderid));
				sqlCmd.ExecuteNonQuery();
				//Delete data completed
				sSQL = "DELETE Order_Detail WHERE Id=@Id";
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
	}
}
