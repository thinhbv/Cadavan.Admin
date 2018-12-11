using System;
using System.Configuration;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Libs.Db;

namespace Libs.Content
{
    public sealed class Config
    {
        private static readonly Config instance = new Config();

        private string _ContentConnectionStrings;
		private string _BookingConnectionStrings;
        public static string ContentConnectionStrings
        {
            get
            {
                return instance._ContentConnectionStrings;
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
            _ContentConnectionStrings = GetConnectionString("ContentConnectionStrings");
			_BookingConnectionStrings = GetConnectionString("BookingConnectionStrings");
        }

        public string GetConnectionString(string Name)
        {
            if (ConfigurationManager.ConnectionStrings[Name] == null) return "";
            RijndaelEnhanced rijndaelKey = new RijndaelEnhanced("20b2xa", "@1B2c3D4e5F6g7H8");
            return rijndaelKey.Decrypt(ConfigurationManager.ConnectionStrings[Name].ConnectionString);
        }

        public static Config Instance
        {
            get { return instance; }
        }

    }
}
