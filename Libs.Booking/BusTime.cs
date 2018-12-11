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
    public class BusTime
    {
        public int BusTimeID { get; set; }
        public int RouteID { get; set; }
        public int Date { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int BusTypeID { get; set; }
        public int BusID { get; set; }
        public int Seats { get; set; }
        public int Price { get; set; }
        public int Status { get; set; }
        public int DriverID { get; set; }
        public DateTime Created { get; set; }
        public int TotalCustomer { get; set; }
        public int ReturnValue { get; set; }

        public BusTime()
        {

        }

        ~BusTime()
        {

        }

        public virtual void Dispose()
        {

        }

        public BusTime Get()
        {
            DbHelper db = new DbHelper(Config.BookingConnectionStrings);
            return db.GetInstanceSP<BusTime>("sp_BusTime_Select"
                , new SqlParameter("@BusID", BusID));
        }

        public BusTime Get(int busID)
        {
            DbHelper db = new DbHelper(Config.BookingConnectionStrings);
            return db.GetInstanceSP<BusTime>("sp_BusTime_Select"
                , new SqlParameter("@BusID", busID));
        }

        public void Delete()
        {
            DbHelper db = new DbHelper(Config.BookingConnectionStrings);
            db.ExecuteNonQuerySP("sp_BusTime_Delete"
                , new SqlParameter("@BusID", BusID));
        }

        public void Delete(int busID)
        {
            DbHelper db = new DbHelper(Config.BookingConnectionStrings);
            db.ExecuteNonQuerySP("sp_BusTime_Delete"
                , new SqlParameter("@BusID", busID));
        }

        public void Add()
        {
            DbHelper db = new DbHelper(Config.BookingConnectionStrings);
            SqlParameter[] pars = new SqlParameter[8];
            pars[0] = new SqlParameter("@ReturnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            pars[1] = new SqlParameter("@RouteID", RouteID);
            pars[2] = new SqlParameter("@Price", Price);
            pars[3] = new SqlParameter("@BusTypeID", BusTypeID);
            pars[4] = new SqlParameter("@StartTime", StartTime);
            pars[5] = new SqlParameter("@BusID", BusID);
            pars[6] = new SqlParameter("@Status", Status);
            pars[7] = new SqlParameter("@DriverID", DriverID);

            db.ExecuteNonQuerySP("sp_BusTime_Insert", pars);
            BusTimeID = Convert.ToInt32(pars[0].Value);
        }

        public void Update()
        {
            DbHelper db = new DbHelper(Config.BookingConnectionStrings);
            SqlParameter[] pars = new SqlParameter[9];
            pars[0] = new SqlParameter("@ReturnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            pars[1] = new SqlParameter("@BusTimeID", BusTimeID);
            pars[2] = new SqlParameter("@RouteID", RouteID);
            pars[3] = new SqlParameter("@Price", Price);
            pars[4] = new SqlParameter("@BusTypeID", BusTypeID);
            pars[5] = new SqlParameter("@StartTime", StartTime);
            pars[6] = new SqlParameter("@BusID", BusID);
            pars[7] = new SqlParameter("@Status", Status);
            pars[8] = new SqlParameter("@DriverID", DriverID);

            db.ExecuteNonQuerySP("sp_BusTime_Update", pars);
            ReturnValue = Convert.ToInt32(pars[0].Value);
        }

        public DataTable GetTList(int routeID, int date)
        {
            DbHelper db = new DbHelper(Config.BookingConnectionStrings);
            return db.GetDataTableSP("sp_BusTime_SelectList",
                new SqlParameter("@RouteID", routeID),
                new SqlParameter("@Date", date)
                );
        }
    }
}
