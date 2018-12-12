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

		public List<Orders> Get(int status, string code)
		{
			DbHelper db = new DbHelper(Config.BookingConnectionStrings);
			return db.GetListSP<Orders>("sp_Orders_Select_All"
				, new SqlParameter("@status", status)
				, new SqlParameter("@aircode", code));
		}
	}
}
