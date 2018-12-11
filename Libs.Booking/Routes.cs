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
    public class Routes
    {
        public int RouteID { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public int Order { get; set; }
        public int Distance { get; set; }
        public int TimeLength { get; set; }
        public DateTime Created { get; set; }

        public int ReturnValue { get; set; }

        public Routes()
        {

        }

        ~Routes()
        {

        }

        public virtual void Dispose()
        {

        }

        public Routes Get()
        {
            DbHelper db = new DbHelper(Config.BookingConnectionStrings);
            return db.GetInstanceSP<Routes>("sp_Routes_Select"
                , new SqlParameter("@RouteID", RouteID));
        }

        public Routes Get(int routeID)
        {
            DbHelper db = new DbHelper(Config.BookingConnectionStrings);
            return db.GetInstanceSP<Routes>("sp_Routes_Select"
                , new SqlParameter("@RouteID", routeID));
        }

        public void Delete()
        {
            DbHelper db = new DbHelper(Config.BookingConnectionStrings);
            db.ExecuteNonQuerySP("sp_Routes_Delete"
                , new SqlParameter("@RouteID", RouteID));
        }

        public void Delete(int routeID)
        {
            DbHelper db = new DbHelper(Config.BookingConnectionStrings);
            db.ExecuteNonQuerySP("sp_Routes_Delete"
                , new SqlParameter("@RouteID", routeID));
        }

        public void Add()
        {
            DbHelper db = new DbHelper(Config.BookingConnectionStrings);
            SqlParameter[] pars = new SqlParameter[8];
            pars[0] = new SqlParameter("@ReturnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            pars[1] = new SqlParameter("@Name", Name);
            pars[2] = new SqlParameter("@ShortName", ShortName);
            pars[3] = new SqlParameter("@Description", Description);
            pars[4] = new SqlParameter("@Status", Status);
            pars[5] = new SqlParameter("@Order", Order);
            pars[6] = new SqlParameter("@Distance", Distance);
            pars[7] = new SqlParameter("@TimeLength", TimeLength);

            db.ExecuteNonQuerySP("sp_Routes_Insert", pars);
            RouteID = Convert.ToInt32(pars[0].Value);
        }

        public void Update()
        {
            DbHelper db = new DbHelper(Config.BookingConnectionStrings);
            SqlParameter[] pars = new SqlParameter[9];
            pars[0] = new SqlParameter("@ReturnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            pars[1] = new SqlParameter("@RouteID", RouteID);
            pars[2] = new SqlParameter("@Name", Name);
            pars[3] = new SqlParameter("@ShortName", ShortName);
            pars[4] = new SqlParameter("@Description", Description);
            pars[5] = new SqlParameter("@Status", Status);
            pars[6] = new SqlParameter("@Order", Order);
            pars[7] = new SqlParameter("@Distance", Distance);
            pars[8] = new SqlParameter("@TimeLength", TimeLength);


            db.ExecuteNonQuerySP("sp_Routes_Update", pars);
            ReturnValue = Convert.ToInt32(pars[0].Value);
        }

        public List<Routes> GetList()
        {
            DbHelper db = new DbHelper(Config.BookingConnectionStrings);
            return db.GetListSP<Routes>("sp_Routes_SelectListByStatus"
                , new SqlParameter("@Status", 1)
                );
        }

        public DataTable GetTList()
        {
            DbHelper db = new DbHelper(Config.BookingConnectionStrings);
            return db.GetDataTableSP("sp_Routes_SelectListByStatus"
                , new SqlParameter("@Status", 1)
                );
        }

        public DataTable GetTList(bool status)
        {
            DbHelper db = new DbHelper(Config.BookingConnectionStrings);
            return db.GetDataTableSP("sp_Routes_SelectListByStatus"
                , new SqlParameter("@Status", status)
                );
        }

        public DataTable GetTListAll()
        {
            DbHelper db = new DbHelper(Config.BookingConnectionStrings);
            return db.GetDataTableSP("sp_Routes_SelectList");
        }
    }
}
