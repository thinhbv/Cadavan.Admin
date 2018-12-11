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
    public class Drivers
    {
        public int DriverID { get; set; }
        public bool Status { get; set; }
        public string License { get; set; }
        public DateTime CreatedTime { get; set; }
        public int ReturnValue { get; set; }

        public Drivers()
        {

        }

        ~Drivers()
        {

        }

        public virtual void Dispose()
        {

        }

        public Drivers Get()
        {
            DbHelper db = new DbHelper(Config.BookingConnectionStrings);
            return db.GetInstanceSP<Drivers>("sp_Drivers_Select"
                , new SqlParameter("@DriverID", DriverID));
        }

        public Drivers Get(int driverID)
        {
            DbHelper db = new DbHelper(Config.BookingConnectionStrings);
            return db.GetInstanceSP<Drivers>("sp_Drivers_Select"
                , new SqlParameter("@DriverID", driverID));
        }

        public void Delete()
        {
            DbHelper db = new DbHelper(Config.BookingConnectionStrings);
            db.ExecuteNonQuerySP("sp_Drivers_Delete"
                , new SqlParameter("@DriverID", DriverID));
        }

        public void Delete(int driverID)
        {
            DbHelper db = new DbHelper(Config.BookingConnectionStrings);
            db.ExecuteNonQuerySP("sp_Drivers_Delete"
                , new SqlParameter("@DriverID", driverID));
        }

        public void Add()
        {
            DbHelper db = new DbHelper(Config.BookingConnectionStrings);
            SqlParameter[] pars = new SqlParameter[4];
            pars[0] = new SqlParameter("@ReturnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            pars[1] = new SqlParameter("@DriverID", DriverID);
            pars[2] = new SqlParameter("@Status", Status);
            pars[3] = new SqlParameter("@License", License);

            db.ExecuteNonQuerySP("sp_Drivers_Insert", pars);
            ReturnValue = Convert.ToInt32(pars[0].Value);
        }

        public void Update()
        {
            DbHelper db = new DbHelper(Config.BookingConnectionStrings);
            SqlParameter[] pars = new SqlParameter[4];
            pars[0] = new SqlParameter("@ReturnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            pars[1] = new SqlParameter("@DriverID", DriverID);
            pars[2] = new SqlParameter("@Status", Status);
            pars[3] = new SqlParameter("@License", License);

            db.ExecuteNonQuerySP("sp_Drivers_Update", pars);
            ReturnValue = Convert.ToInt32(pars[0].Value);
        }

        public DataTable GetTList(bool status, string license)
        {
            DbHelper db = new DbHelper(Config.BookingConnectionStrings);
            return db.GetDataTableSP("sp_Drivers_SelectList",
                license == "" ? new SqlParameter("@License", DBNull.Value) : new SqlParameter("@License", license),
                new SqlParameter("@Status", status)
                );
        }

        public DataTable GetTList(string license)
        {
            DbHelper db = new DbHelper(Config.BookingConnectionStrings);
            return db.GetDataTableSP("sp_Drivers_SelectList",
                license == "" ? new SqlParameter("@License", DBNull.Value) : new SqlParameter("@License", license),
                new SqlParameter("@Status", DBNull.Value)
                );
        }

        public DataTable GetTList()
        {
            DbHelper db = new DbHelper(Config.BookingConnectionStrings);
            return db.GetDataTableSP("sp_Drivers_SelectList",
                new SqlParameter("@License", DBNull.Value),
                new SqlParameter("@Status", DBNull.Value)
                );
        }

        public DataTable GetLicenseList()
        {
            DbHelper db = new DbHelper(Config.BookingConnectionStrings);
            return db.GetDataTableSP("sp_Drivers_SelectLicenseList");
        }

        public DataTable GetTListNotIn()
        {
            DbHelper db = new DbHelper(Config.BookingConnectionStrings);
            return db.GetDataTableSP("sp_Drivers_SelectListNotIn");
        }

        public DataTable Report()
        {
            DbHelper db = new DbHelper(Config.BookingConnectionStrings);
            return db.GetDataTableSP("sp_Drivers_Report");
        }

    }
}
