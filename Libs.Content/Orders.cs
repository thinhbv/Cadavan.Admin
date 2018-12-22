using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Libs.Db;

namespace Libs.Content
{
	public class Orders
	{
		//Order_Detail
		public int Id { get; set; }
		public int OrderId { get; set; }
		public string TicketId { get; set; }
		public string CompanyName { get; set; }
		public string Code { get; set; }
		public DateTime StartDate { get; set; }
		public TimeSpan DepTime { get; set; }
		public DateTime EndDate { get; set; }
		public TimeSpan DicTime { get; set; }
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
		//Contact info
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Phone { get; set; }
		public string Email { get; set; }
		public string Address { get; set; }
		//Orders
		public int RoundTrip { get; set; }
		public string FromCity { get; set; }
		public string ToCity { get; set; }
		public int Adult { get; set; }
		public int Child { get; set; }
		public int Infant { get; set; }
		public double TaxFee { get; set; }
		public double Price { get; set; }
		public int Status { get; set; }
		public DateTime CreateDate { get; set; }
		public Orders()
		{
		}
		~Orders()
		{

		}

		public List<Orders> Get(int status, string code, string startdate, string enddate)
		{
			DbHelper db = new DbHelper(Config.BookingConnectionStrings);
			return db.GetListSP<Orders>("sp_Orders_Select_All"
				, new SqlParameter("@top", "")
				, new SqlParameter("@status", status)
				, new SqlParameter("@aircode", code)
				, new SqlParameter("@startdate", startdate)
				, new SqlParameter("@enddate", enddate));
		}

		public List<Orders> GetOrdersHistory(int status, string code, string startdate, string enddate)
		{
			DbHelper db = new DbHelper(Config.BookingConnectionStrings);
			return db.GetListSP<Orders>("sp_Orders_History_Select_All"
				, new SqlParameter("@top", "")
				, new SqlParameter("@status", status)
				, new SqlParameter("@aircode", code)
				, new SqlParameter("@startdate", startdate)
				, new SqlParameter("@enddate", enddate));
		}

		public List<Orders> GetById(int id)
		{
			DbHelper db = new DbHelper(Config.BookingConnectionStrings);
			return db.GetListSP<Orders>("sp_Orders_Select_ByID"
				, new SqlParameter("@id", id));
		}

		public List<Orders> GetHistoryById(int id)
		{
			DbHelper db = new DbHelper(Config.BookingConnectionStrings);
			return db.GetListSP<Orders>("sp_Orders_History_Select_ByID"
				, new SqlParameter("@id", id));
		}

		public bool UpdateStatus(List<Orders> lstOrders, int status)
		{
			SqlConnection mCon = null;
			string sSQL;
			SqlTransaction mTran = null;
			SqlCommand sqlCmd;
			DbHelper db = new DbHelper(Config.BookingConnectionStrings);
			try
			{
				mCon = db.OpenConnection();
				mTran = mCon.BeginTransaction();
				sSQL = "UPDATE Orders SET Status =@Status WHERE Id=@Id";
				sqlCmd = new SqlCommand(sSQL, mCon, mTran);
				sqlCmd.Parameters.Add(new SqlParameter("@Id", lstOrders[0].OrderId));
				sqlCmd.Parameters.Add(new SqlParameter("@Status", status));
				sqlCmd.ExecuteNonQuery();

				if (status == 2 || status == 3)
				{
					CopyToOrdersHistory(lstOrders[0].OrderId, mTran, mCon);
					Order_Detail detail = new Order_Detail();
					for (int i = 0; i < lstOrders.Count; i++)
					{
						detail.CopyToOrderDetailHistory(lstOrders[i].Id, mTran, mCon);
					}
					Customers cust = new Customers();
					List<Customers> lstCust = cust.GetByOrderId(lstOrders[0].OrderId);
					for (int i = 0; i < lstCust.Count; i++)
					{
						cust.CopyToCustomerHistory(lstCust[i].Id, mTran, mCon);
					}
				}
				
				mTran.Commit();

				return true;
			}
			catch (Exception ex)
			{
				if (mTran != null)
				{
					mTran.Rollback();
				}
				throw ex;
			}
		}

		public bool CopyToOrdersHistory(int orderid, SqlTransaction mTran, SqlConnection mCon)
		{
			string sSQL;
			SqlCommand sqlCmd;
			try
			{
				//Copy data to history table
				sSQL = "INSERT Orders_History SELECT * FROM Orders WHERE Id=@Id";
				sqlCmd = new SqlCommand(sSQL, mCon, mTran);
				sqlCmd.Parameters.Add(new SqlParameter("@Id", orderid));
				sqlCmd.ExecuteNonQuery();
				//Delete data completed
				sSQL = "DELETE Orders WHERE Id=@Id";
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
