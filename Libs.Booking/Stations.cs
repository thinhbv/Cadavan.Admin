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
    public class Stations
    {
        public int StationID { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public string Latitude { get; set; }
        public string Longtitude { get; set; }
        public DateTime Created { get; set; }

        public int ReturnValue { get; set; }

        public Stations()
        {

        }

        ~Stations()
        {

        }

        public virtual void Dispose()
        {

        }

        public Stations Get()
        {
            DbHelper db = new DbHelper(Config.BookingConnectionStrings);
            return db.GetInstanceSP<Stations>("sp_Stations_Select"
                , new SqlParameter("@StationID", StationID));
        }

        public Stations Get(int stationID)
        {
            DbHelper db = new DbHelper(Config.BookingConnectionStrings);
            return db.GetInstanceSP<Stations>("sp_Stations_Select"
                , new SqlParameter("@StationID", stationID));
        }

        public void Delete()
        {
            DbHelper db = new DbHelper(Config.BookingConnectionStrings);
            db.ExecuteNonQuerySP("sp_Stations_Delete"
                , new SqlParameter("@StationID", StationID));
        }

        public void Delete(int stationID)
        {
            DbHelper db = new DbHelper(Config.BookingConnectionStrings);
            db.ExecuteNonQuerySP("sp_Stations_Delete"
                , new SqlParameter("@StationID", stationID));
        }

        public void Add()
        {
            DbHelper db = new DbHelper(Config.BookingConnectionStrings);
            SqlParameter[] pars = new SqlParameter[7];
            pars[0] = new SqlParameter("@ReturnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            pars[1] = new SqlParameter("@Name", Name);
            pars[2] = new SqlParameter("@ShortName", ShortName);
            pars[3] = new SqlParameter("@Description", Description);
            pars[4] = new SqlParameter("@Status", Status);
            pars[5] = new SqlParameter("@Latitude", Latitude);
            pars[6] = new SqlParameter("@Longtitude", Longtitude);

            db.ExecuteNonQuerySP("sp_Stations_Insert", pars);
            StationID = Convert.ToInt32(pars[0].Value);
        }

        public void Update()
        {
            DbHelper db = new DbHelper(Config.BookingConnectionStrings);
            SqlParameter[] pars = new SqlParameter[8];
            pars[0] = new SqlParameter("@ReturnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            pars[1] = new SqlParameter("@StationID", StationID);
            pars[2] = new SqlParameter("@Name", Name);
            pars[3] = new SqlParameter("@ShortName", ShortName);
            pars[4] = new SqlParameter("@Description", Description);
            pars[5] = new SqlParameter("@Status", Status);
            pars[6] = new SqlParameter("@Latitude", Latitude);
            pars[7] = new SqlParameter("@Longtitude", Longtitude);


            db.ExecuteNonQuerySP("sp_Stations_Update", pars);
            ReturnValue = Convert.ToInt32(pars[0].Value);
        }

        public List<Stations> GetList()
        {
            DbHelper db = new DbHelper(Config.BookingConnectionStrings);
            return db.GetListSP<Stations>("sp_Stations_SelectList");
        }
        
        public DataTable GetTList()
        {
            DbHelper db = new DbHelper(Config.BookingConnectionStrings);
            return db.GetDataTableSP("sp_Stations_SelectList");
        }

        public DataTable GetTListNotIn(int routeID)
        {
            DbHelper db = new DbHelper(Config.BookingConnectionStrings);
            return db.GetDataTableSP("sp_Stations_SelectListNotIn", new SqlParameter("@RouteID", routeID));
        }
    }
}
