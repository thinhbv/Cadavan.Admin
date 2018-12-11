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
    public class BusSchedule
    {
        public int ScheduleID { get; set; }
        public int Weekday { get; set; }
        public int RouteID { get; set; }
        public int StartTime { get; set; }
        public int BusTypeID { get; set; }
        public int Seats { get; set; }
        public int Price { get; set; }
        public int ReturnValue { get; set; }

        public BusSchedule()
        {
           
        }

        ~BusSchedule()
        {

        }

        public virtual void Dispose()
        {

        }

        public BusSchedule Get()
        {
            DbHelper db = new DbHelper(Config.BookingConnectionStrings);
            return db.GetInstanceSP<BusSchedule>("sp_BusSchedule_Select"
                , new SqlParameter("@ScheduleID", ScheduleID));
        }

        public BusSchedule Get(int scheduleID)
        {
            DbHelper db = new DbHelper(Config.BookingConnectionStrings);
            return db.GetInstanceSP<BusSchedule>("sp_BusSchedule_Select"
                , new SqlParameter("@ScheduleID", scheduleID));
        }

        public void Delete()
        {
            DbHelper db = new DbHelper(Config.BookingConnectionStrings);
            db.ExecuteNonQuerySP("sp_BusSchedule_Delete"
                , new SqlParameter("@ScheduleID", ScheduleID));
        }

        public void Delete(int scheduleID)
        {
            DbHelper db = new DbHelper(Config.BookingConnectionStrings);
            db.ExecuteNonQuerySP("sp_BusSchedule_Delete"
                , new SqlParameter("@ScheduleID", scheduleID));
        }

        public void Add()
        {
            DbHelper db = new DbHelper(Config.BookingConnectionStrings);
            SqlParameter[] pars = new SqlParameter[6];
            pars[0] = new SqlParameter("@ReturnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            pars[1] = new SqlParameter("@Weekday", Weekday);
            pars[2] = new SqlParameter("@RouteID", RouteID);
            pars[3] = new SqlParameter("@StartTime", StartTime);
            pars[4] = new SqlParameter("@BusTypeID", BusTypeID);
            pars[5] = new SqlParameter("@Price", Price);

            db.ExecuteNonQuerySP("sp_BusSchedule_Insert", pars); 
            ScheduleID = Convert.ToInt32(pars[0].Value);
        }

        public void Update()
        {
            DbHelper db = new DbHelper(Config.BookingConnectionStrings);
            SqlParameter[] pars = new SqlParameter[7];
            pars[0] = new SqlParameter("@ReturnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            pars[1] = new SqlParameter("@ScheduleID", ScheduleID);
            pars[2] = new SqlParameter("@Weekday", Weekday);
            pars[3] = new SqlParameter("@RouteID", RouteID);
            pars[4] = new SqlParameter("@StartTime", StartTime);
            pars[5] = new SqlParameter("@BusTypeID", BusTypeID);
            pars[6] = new SqlParameter("@Price", Price);

            db.ExecuteNonQuerySP("sp_BusSchedule_Update", pars);
            ReturnValue = Convert.ToInt32(pars[0].Value);
        }

        public List<BusSchedule> GetList(int routeID, int weekday)
        {
            DbHelper db = new DbHelper(Config.BookingConnectionStrings);
            return db.GetListSP<BusSchedule>("sp_BusSchedule_SelectList",
                routeID == 0 ? new SqlParameter("@RouteID", DBNull.Value) : new SqlParameter("@RouteID", routeID),
                weekday == 0 ? new SqlParameter("@Weekday", DBNull.Value) : new SqlParameter("@Weekday", weekday));
        }

        public DataTable GetTList(int routeID, int weekday)
        {
            DbHelper db = new DbHelper(Config.BookingConnectionStrings);
            return db.GetDataTableSP("sp_BusSchedule_SelectList",
                routeID == 0 ? new SqlParameter("@RouteID", DBNull.Value) : new SqlParameter("@RouteID", routeID),
                weekday == 0 ? new SqlParameter("@Weekday", DBNull.Value) : new SqlParameter("@Weekday", weekday));
        }

        public DataTable ReportRoute()
        {
            DbHelper db = new DbHelper(Config.BookingConnectionStrings);
            return db.GetDataTableSP("sp_BusSchedule_ReportRoute");
        }

        public DataTable ReportWeekday(int routeID)
        {
            DbHelper db = new DbHelper(Config.BookingConnectionStrings);
            return db.GetDataTableSP("sp_BusSchedule_ReportWeekday", routeID == 0 ? new SqlParameter("@RouteID", DBNull.Value) : new SqlParameter("@RouteID", routeID));
        }

    }
}
