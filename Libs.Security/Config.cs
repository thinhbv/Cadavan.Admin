using System;
using System.Configuration;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Libs.Db;

namespace Libs.Security
{
    public sealed class Config
    {
        private static readonly Config instance = new Config();

		private string _SecurityConnectionStrings;
		private string _NewsConnectionStrings;
		private string _BookingConnectionStrings;

        public static string SecurityConnectionStrings
        {
            get
            {
                return instance._SecurityConnectionStrings;
            }
        }
		public static string NewsConnectionStrings
		{
			get
			{
				return instance._NewsConnectionStrings;
			}
		}
		public static string BookingConnectionStrings
		{
			get
			{
				return instance._BookingConnectionStrings;
			}
		}

        Config()
        {
			_SecurityConnectionStrings = GetConnectionString("SecurityConnectionStrings");
			_NewsConnectionStrings = GetConnectionString("NewsConnectionStrings");
			_BookingConnectionStrings = GetConnectionString("BookingConnectionStrings");
        }

        public string GetConnectionString(string Name)
        {
            if (ConfigurationManager.ConnectionStrings[Name] == null) return "";
            RijndaelEnhanced rijndaelKey = new RijndaelEnhanced("20b2", "@1B2c3D4e5F6g7H8");
            return rijndaelKey.Decrypt(ConfigurationManager.ConnectionStrings[Name].ConnectionString);
        }

        public static Config Instance
        {
            get { return instance; }
        }

    }
}
