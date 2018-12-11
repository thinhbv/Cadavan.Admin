using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Libs.Db;

namespace Libs.Content
{
	public class Address
	{
		public int id { get; set; }
		public int countryid { get; set; }
		public string name { get; set; }
		public string code { get; set; }
		public string flyname { get; set; }
		public int ord { get; set; }
		public bool active { get; set; }
		public Address()
        {

        }
		public List<Address> Get(int countryid)
		{
			DbHelper db = new DbHelper(Config.BookingConnectionStrings);
			return db.GetListSP<Address>("sp_Address_Select"
				, new SqlParameter("@countryid", countryid));
		}
		public List<Address> GetForAuto()
		{
			DbHelper db = new DbHelper(Config.BookingConnectionStrings);
			return db.GetListSP<Address>("sp_Address_Select_ForAuto");
		}
		public List<Address> GetName(string code)
		{
			DbHelper db = new DbHelper(Config.BookingConnectionStrings);
			return db.GetListSP<Address>("sp_Address_Select_Name", new SqlParameter("@code", code));
		}
	}

	public class Countries
	{
		public int id { get; set; }
		public string name { get; set; }
		public int ord { get; set; }
		public bool active { get; set; }
		public Countries()
		{

		}
		public List<Countries> Get()
		{
			DbHelper db = new DbHelper(Config.BookingConnectionStrings);
			return db.GetListSP<Countries>("sp_Countries_Select");
		}
		public List<Countries> GetForAuto()
		{
			DbHelper db = new DbHelper(Config.BookingConnectionStrings);
			return db.GetListSP<Countries>("sp_Countries_Select_ForAuto");
		}
	}

	public class Airlines
	{
		public int id { get; set; }
		public string name { get; set; }
		public string code { get; set; }
		public int ord { get; set; }
		public bool active { get; set; }
		public Airlines()
		{

		}
		public List<Airlines> Get()
		{
			DbHelper db = new DbHelper(Config.BookingConnectionStrings);
			return db.GetListSP<Airlines>("sp_Airlines_Select");
		}
	}
}
