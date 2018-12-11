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
    public class RouteStation
    {
        public int RouteStationID { get; set; }
        public int RouteID { get; set; }
        public int StationID { get; set; }
        public int Distance { get; set; }
        public int TimeLength { get; set; }
        public bool Status { get; set; }
        public DateTime Created { get; set; }
        public int ReturnValue { get; set; }

        public RouteStation()
        {

        }

        ~RouteStation()
        {

        }

        public virtual void Dispose()
        {

        }

        public RouteStation Get()
        {
            DbHelper db = new DbHelper(Config.BookingConnectionStrings);
            return db.GetInstanceSP<RouteStation>("sp_RouteStation_Select"
                , new SqlParameter("@RouteStationID", RouteStationID));
        }

        public Routes Get(int routeStationID)
        {
            DbHelper db = new DbHelper(Config.BookingConnectionStrings);
            return db.GetInstanceSP<Routes>("sp_RouteStation_Select"
                , new SqlParameter("@RouteStationID", routeStationID));
        }

        public void Delete()
        {
            DbHelper db = new DbHelper(Config.BookingConnectionStrings);
            db.ExecuteNonQuerySP("sp_RouteStation_Delete"
                , new SqlParameter("@RouteStationID", RouteStationID));
        }

        public void Delete(int RouteStationID)
        {
            DbHelper db = new DbHelper(Config.BookingConnectionStrings);
            db.ExecuteNonQuerySP("sp_RouteStation_Delete"
                , new SqlParameter("@RouteStationID", RouteStationID));
        }

        public void Add()
        {
            DbHelper db = new DbHelper(Config.BookingConnectionStrings);
            SqlParameter[] pars = new SqlParameter[6];
            pars[0] = new SqlParameter("@ReturnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            pars[1] = new SqlParameter("@RouteID", RouteID);
            pars[2] = new SqlParameter("@StationID", StationID);
            pars[3] = new SqlParameter("@Status", Status);
            pars[4] = new SqlParameter("@Distance", Distance);
            pars[5] = new SqlParameter("@TimeLength", TimeLength);

            db.ExecuteNonQuerySP("sp_RouteStation_Insert", pars);
            RouteStationID = Convert.ToInt32(pars[0].Value);
        }

        public void Update()
        {
            DbHelper db = new DbHelper(Config.BookingConnectionStrings);
            SqlParameter[] pars = new SqlParameter[5];
            pars[0] = new SqlParameter("@ReturnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            pars[1] = new SqlParameter("@RouteStationID", RouteStationID);
            pars[2] = new SqlParameter("@Status", Status);
            pars[3] = new SqlParameter("@Distance", Distance);
            pars[4] = new SqlParameter("@TimeLength", TimeLength);

            db.ExecuteNonQuerySP("sp_RouteStation_Update", pars);
            ReturnValue = Convert.ToInt32(pars[0].Value);
        }

        public List<Routes> GetList(int routeID)
        {
            DbHelper db = new DbHelper(Config.BookingConnectionStrings);
            return db.GetListSP<Routes>("sp_RouteStation_SelectList", new SqlParameter("@RouteID", routeID));
        }

        public DataTable GetTList(int routeID)
        {
            DbHelper db = new DbHelper(Config.BookingConnectionStrings);
            return db.GetDataTableSP("sp_RouteStation_SelectList", new SqlParameter("@RouteID", routeID));
        }
    }
}
