using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Libs.Db;

namespace Libs.Security
{
    public class Permissions
    {
        public int PermissionID { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public int FatherID { get; set; }
        public int Order { get; set; }
        public string ShortOrder { get; set; }
        public bool Status { get; set; }
        public bool ShowMenu { get; set; }
        public DateTime Created { get; set; }
        public int ReturnValue { get; set; }

        public Permissions()
        {

        }

        ~Permissions()
        {

        }

        public virtual void Dispose()
        {

        }

        public Permissions Get(int permissionID)
        {
            DbHelper db = new DbHelper(Config.SecurityConnectionStrings);
            return db.GetInstanceSP<Permissions>("sp_Permissions_Select",
                new SqlParameter("@PermissionID", permissionID));
        }

        public Permissions Get()
        {
            DbHelper db = new DbHelper(Config.SecurityConnectionStrings);
            return db.GetInstanceSP<Permissions>("sp_Permissions_Select",
                new SqlParameter("@PermissionID", PermissionID));
        }

        public void Add()
        {
            DbHelper db = new DbHelper(Config.SecurityConnectionStrings);
            SqlParameter[] pars = new SqlParameter[9];
            pars[0] = new SqlParameter("@ReturnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            pars[1] = new SqlParameter("@Name", Name);
            pars[2] = new SqlParameter("@Alias", Alias);
            pars[3] = new SqlParameter("@Url", Url);
            pars[4] = new SqlParameter("@Description", Description);
            pars[5] = new SqlParameter("@FatherID", FatherID);
            pars[6] = new SqlParameter("@Order", Order);
            pars[7] = new SqlParameter("@Status", Status);
            pars[8] = new SqlParameter("@ShowMenu", ShowMenu);

            db.ExecuteNonQuerySP("sp_Permissions_Insert", pars);
            PermissionID = Convert.ToInt32(pars[0].Value);
        }

        public void Update()
        {
            DbHelper db = new DbHelper(Config.SecurityConnectionStrings);
            SqlParameter[] pars = new SqlParameter[10];
            pars[0] = new SqlParameter("@PermissionID", PermissionID);
            pars[1] = new SqlParameter("@Name", Name);
            pars[2] = new SqlParameter("@Alias", Alias);
            pars[3] = new SqlParameter("@Url", Url);
            pars[4] = new SqlParameter("@Description", Description);
            pars[5] = new SqlParameter("@FatherID", FatherID);
            pars[6] = new SqlParameter("@Order", Order);
            pars[7] = new SqlParameter("@Status", Status);
            pars[8] = new SqlParameter("@ShowMenu", ShowMenu);
            pars[9] = new SqlParameter("@ReturnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };

            db.ExecuteNonQuerySP("sp_Permissions_Update", pars);
            ReturnValue = Convert.ToInt32(pars[9].Value);
        }

        public void Delete(int permissionID)
        {
            DbHelper db = new DbHelper(Config.SecurityConnectionStrings);
            SqlParameter[] pars = new SqlParameter[2];
            pars[0] = new SqlParameter("@PermissionID", permissionID);
            pars[1] = new SqlParameter("@ReturnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };

            db.ExecuteNonQuerySP("sp_Permissions_Delete", pars);
            ReturnValue = Convert.ToInt32(pars[1].Value);
        }

        public void Delete()
        {
            DbHelper db = new DbHelper(Config.SecurityConnectionStrings);
            SqlParameter[] pars = new SqlParameter[2];
            pars[0] = new SqlParameter("@PermissionID", PermissionID);
            pars[1] = new SqlParameter("@ReturnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };

            db.ExecuteNonQuerySP("sp_Permissions_Delete", pars);
            ReturnValue = Convert.ToInt32(pars[1].Value);
        }

        public List<Permissions> GetList()
        {
            DbHelper db = new DbHelper(Config.SecurityConnectionStrings);
            return db.GetListSP<Permissions>("sp_Permissions_SelectList"
                ,new SqlParameter("@Status", DBNull.Value)
                , new SqlParameter("@ShowMenu", DBNull.Value)
                , new SqlParameter("@FatherID", DBNull.Value)
                );
        }

        public List<Permissions> GetList(int fatherID)
        {
            DbHelper db = new DbHelper(Config.SecurityConnectionStrings);
            return db.GetListSP<Permissions>("sp_Permissions_SelectList"
                , new SqlParameter("@Status", DBNull.Value)
                , new SqlParameter("@ShowMenu", DBNull.Value)
                , new SqlParameter("@FatherID", fatherID)
                );
        }


        public DataTable GetTList()
        {
            DbHelper db = new DbHelper(Config.SecurityConnectionStrings);
            return db.GetDataTableSP("sp_Permissions_SelectList"
                , new SqlParameter("@Status", DBNull.Value)
                , new SqlParameter("@ShowMenu", DBNull.Value)
                , new SqlParameter("@FatherID", DBNull.Value)
                );
        }

        public DataTable GetTList(int fatherID)
        {
            DbHelper db = new DbHelper(Config.SecurityConnectionStrings);
            return db.GetDataTableSP("sp_Permissions_SelectList"
                , new SqlParameter("@Status", DBNull.Value)
                , new SqlParameter("@ShowMenu", DBNull.Value)
                , new SqlParameter("@FatherID", fatherID)
                );
        }

        public DataTable GetTListFather(int fatherID)
        {
            DbHelper db = new DbHelper(Config.SecurityConnectionStrings);
            return db.GetDataTableSP("sp_Permissions_SelectWithFather"
                , new SqlParameter("@FatherID", fatherID)
                );
        }
    }
}
