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
    public class Bus
    {
        public int BusID { get; set; }
        public string BusNumber { get; set; }
        public int BusTypeID { get; set; }
        public int Seats { get; set; }
        public int DriverID { get; set; }
        public bool Status { get; set; }
        public string Description { get; set; }
        public int InUse { get; set; }
        public DateTime Created { get; set; }
        public int ReturnValue { get; set; }

        public Bus()
        {

        }

        ~Bus()
        {

        }

        public virtual void Dispose()
        {

        }

        public Bus Get()
        {
            DbHelper db = new DbHelper(Config.BookingConnectionStrings);
            return db.GetInstanceSP<Bus>("sp_Bus_Select"
                , new SqlParameter("@BusID", BusID));
        }

        public Bus Get(int busID)
        {
            DbHelper db = new DbHelper(Config.BookingConnectionStrings);
            return db.GetInstanceSP<Bus>("sp_Bus_Select"
                , new SqlParameter("@BusID", busID));
        }

        public void Delete()
        {
            DbHelper db = new DbHelper(Config.BookingConnectionStrings);
            db.ExecuteNonQuerySP("sp_Bus_Delete"
                , new SqlParameter("@BusID", BusID));
        }

        public void Delete(int busID)
        {
            DbHelper db = new DbHelper(Config.BookingConnectionStrings);
            db.ExecuteNonQuerySP("sp_Bus_Delete"
                , new SqlParameter("@BusID", busID));
        }

        public void Add()
        {
            DbHelper db = new DbHelper(Config.BookingConnectionStrings);
            SqlParameter[] pars = new SqlParameter[7];
            pars[0] = new SqlParameter("@ReturnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            pars[1] = new SqlParameter("@BusTypeID", BusTypeID);
            pars[2] = new SqlParameter("@BusNumber", BusNumber);
            pars[3] = new SqlParameter("@Status", Status);
            pars[4] = new SqlParameter("@DriverID", DriverID);
            pars[5] = new SqlParameter("@Description", Description);
            pars[6] = new SqlParameter("@InUse", InUse);

            db.ExecuteNonQuerySP("sp_Bus_Insert", pars);
            BusID = Convert.ToInt32(pars[0].Value);
        }

        public void Update()
        {
            DbHelper db = new DbHelper(Config.BookingConnectionStrings);
            SqlParameter[] pars = new SqlParameter[8];
            pars[0] = new SqlParameter("@ReturnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            pars[1] = new SqlParameter("@BusID", BusID);
            pars[2] = new SqlParameter("@BusNumber", BusNumber);
            pars[3] = new SqlParameter("@BusTypeID", BusTypeID);
            pars[4] = new SqlParameter("@Status", Status);
            pars[5] = new SqlParameter("@DriverID", DriverID);
            pars[6] = new SqlParameter("@Description", Description);
            pars[7] = new SqlParameter("@InUse", InUse);

            db.ExecuteNonQuerySP("sp_Bus_Update", pars);
            ReturnValue = Convert.ToInt32(pars[0].Value);
        }

        public DataTable GetTList()
        {
            DbHelper db = new DbHelper(Config.BookingConnectionStrings);
            return db.GetDataTableSP("sp_Bus_SelectList",
                new SqlParameter("@BusTypeID", DBNull.Value),
                new SqlParameter("@Status", DBNull.Value)
                );
        }

        public DataTable GetTList(int busTypeID)
        {
            DbHelper db = new DbHelper(Config.BookingConnectionStrings);
            return db.GetDataTableSP("sp_Bus_SelectList",
                busTypeID == 0 ? new SqlParameter("@BusTypeID", DBNull.Value) : new SqlParameter("@BusTypeID", busTypeID),
                new SqlParameter("@Status", DBNull.Value)
                );
        }

        public DataTable GetTList(int busTypeID, bool status)
        {
            DbHelper db = new DbHelper(Config.BookingConnectionStrings);
            return db.GetDataTableSP("sp_Bus_SelectList",
                busTypeID == 0 ? new SqlParameter("@BusTypeID", DBNull.Value) : new SqlParameter("@BusTypeID", busTypeID),
                new SqlParameter("@Status", status)
                );
        }

        public DataTable BusStatusTList()
        {
            DbHelper db = new DbHelper(Config.BookingConnectionStrings);
            return db.GetDataTableSP("sp_BusStatus_SelectList");
        }

        public DataTable Report()
        {
            DbHelper db = new DbHelper(Config.BookingConnectionStrings);
            return db.GetDataTableSP("sp_Bus_Report");
        }
    }
}
