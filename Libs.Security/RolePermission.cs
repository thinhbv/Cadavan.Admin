using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Libs.Db;

namespace Libs.Security
{
    public class RolePermission
    {
        public int RolePermissionID { get; set; }
        public int RoleID { get; set; }
        public int PermissionID { get; set; }
        public DateTime Created { get; set; }
        public int ReturnValue { get; set; }

        public RolePermission()
        {

        }

        ~RolePermission()
        {

        }

        public virtual void Dispose()
        {

        }

        public void Add()
        {
            DbHelper db = new DbHelper(Config.SecurityConnectionStrings);
            SqlParameter[] pars = new SqlParameter[3];
            pars[0] = new SqlParameter("@ReturnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            pars[1] = new SqlParameter("@RoleID", RoleID);
            pars[2] = new SqlParameter("@PermissionID", PermissionID);

            db.ExecuteNonQuerySP("sp_RolePermission_Insert", pars);
            PermissionID = Convert.ToInt32(pars[0].Value);
        }

        public void Delete(int roleID, int permissionID)
        {
            DbHelper db = new DbHelper(Config.SecurityConnectionStrings);
            SqlParameter[] pars = new SqlParameter[3];
            pars[0] = new SqlParameter("@ReturnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            pars[1] = new SqlParameter("@RoleID", roleID);
            pars[2] = new SqlParameter("@PermissionID", permissionID);

            db.ExecuteNonQuerySP("sp_RolePermission_Delete", pars);
            ReturnValue = Convert.ToInt32(pars[1].Value);
        }

        public List<RolePermission> GetList(int roleID)
        {
            DbHelper db = new DbHelper(Config.SecurityConnectionStrings);
            return db.GetListSP<RolePermission>("sp_RolePermission_SelectList"
                , new SqlParameter("@RoleID", roleID)
                );
        }


    }
}
