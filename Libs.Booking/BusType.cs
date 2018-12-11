using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Libs.Db;

namespace Libs.Booking
{
    public class BusType
    {
        public int BusTypeID { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Lead { get; set; }
        public string Content { get; set; }
        public int Seats { get; set; }
        public DateTime Created { get; set; }
        public int ReturnValue { get; set; }

        public BusType()
        {

        }

        ~BusType()
        {

        }

        public virtual void Dispose()
        {

        }

        public BusType Get()
        {
            DbHelper db = new DbHelper(Config.BookingConnectionStrings);
            return db.GetInstanceSP<BusType>("sp_BusType_Select"
                , new SqlParameter("@BusTypeID", BusTypeID));
        }

        public BusType Get(int busTypeID)
        {
            DbHelper db = new DbHelper(Config.BookingConnectionStrings);
            return db.GetInstanceSP<BusType>("sp_BusType_Select"
                , new SqlParameter("@BusTypeID", busTypeID));
        }

        public void Delete()
        {
            DbHelper db = new DbHelper(Config.BookingConnectionStrings);
            db.ExecuteNonQuerySP("sp_BusType_Delete"
                , new SqlParameter("@BusTypeID", BusTypeID));
        }

        public void Delete(int busTypeID)
        {
            DbHelper db = new DbHelper(Config.BookingConnectionStrings);
            db.ExecuteNonQuerySP("sp_BusType_Delete"
                , new SqlParameter("@BusTypeID", busTypeID));
        }

        public void Add()
        {
            DbHelper db = new DbHelper(Config.BookingConnectionStrings);
            SqlParameter[] pars = new SqlParameter[6];
            pars[0] = new SqlParameter("@ReturnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            pars[1] = new SqlParameter("@Name", Name);
            pars[2] = new SqlParameter("@ShortName", ShortName);
            pars[3] = new SqlParameter("@Lead", Lead);
            pars[4] = new SqlParameter("@Content", Content);
            pars[5] = new SqlParameter("@Seats", Seats);

            db.ExecuteNonQuerySP("sp_BusType_Insert", pars);
            BusTypeID = Convert.ToInt32(pars[0].Value);
        }

        public void Update()
        {
            DbHelper db = new DbHelper(Config.BookingConnectionStrings);
            SqlParameter[] pars = new SqlParameter[7];
            pars[0] = new SqlParameter("@ReturnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            pars[1] = new SqlParameter("@BusTypeID", BusTypeID);
            pars[2] = new SqlParameter("@Name", Name);
            pars[3] = new SqlParameter("@ShortName", ShortName);
            pars[4] = new SqlParameter("@Lead", Lead);
            pars[5] = new SqlParameter("@Content", Content);
            pars[6] = new SqlParameter("@Seats", Seats);

            db.ExecuteNonQuerySP("sp_BusType_Update", pars);
            ReturnValue = Convert.ToInt32(pars[0].Value);
        }

        public List<BusType> GetList()
        {
            DbHelper db = new DbHelper(Config.BookingConnectionStrings);
            return db.GetListSP<BusType>("sp_BusType_SelectList");
        }

        public DataTable GetTList()
        {
            DbHelper db = new DbHelper(Config.BookingConnectionStrings);
            return db.GetDataTableSP("sp_BusType_SelectList");
        }

    }
}
