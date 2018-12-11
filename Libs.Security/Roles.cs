using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Libs.Db;


namespace Libs.Security
{
    public class Roles
    {
        public int RoleID { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public bool Status { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }
        public DateTime Created { get; set; }
        public int ReturnValue { get; set; }

        public Roles()
        {

        }

        ~Roles()
        {

        }

        public virtual void Dispose()
        {

        }

        public Roles Get(int roleID)
        {
            DbHelper db = new DbHelper(Config.SecurityConnectionStrings);
            return db.GetInstanceSP<Roles>("sp_Roles_Select",
                new SqlParameter("@RoleID", roleID));
        }

        public Roles Get()
        {
            DbHelper db = new DbHelper(Config.SecurityConnectionStrings);
            return db.GetInstanceSP<Roles>("sp_Roles_Select",
                new SqlParameter("@RoleID", RoleID));
        }

        public void Add()
        {
            DbHelper db = new DbHelper(Config.SecurityConnectionStrings);
            SqlParameter[] pars = new SqlParameter[6];
            pars[0] = new SqlParameter("@ReturnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            pars[1] = new SqlParameter("@Name", Name);
            pars[2] = new SqlParameter("@Alias", Alias);
            pars[3] = new SqlParameter("@Status", Status);
            pars[4] = new SqlParameter("@Description", Description);
            pars[5] = new SqlParameter("@Order", Order);

            db.ExecuteNonQuerySP("sp_Roles_Insert", pars);
            RoleID = Convert.ToInt32(pars[0].Value);
        }

        public void Update()
        {
            DbHelper db = new DbHelper(Config.SecurityConnectionStrings);
            SqlParameter[] pars = new SqlParameter[7];
            pars[0] = new SqlParameter("@RoleID", RoleID);
            pars[1] = new SqlParameter("@Name", Name);
            pars[2] = new SqlParameter("@Alias", Alias);
            pars[3] = new SqlParameter("@Status", Status);
            pars[4] = new SqlParameter("@Description", Description);
            pars[5] = new SqlParameter("@Order", Order);
            pars[6] = new SqlParameter("@ReturnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };

            db.ExecuteNonQuerySP("sp_Roles_Update", pars);
            ReturnValue = Convert.ToInt32(pars[6].Value);
        }

        public void Delete(int roleID)
        {
            DbHelper db = new DbHelper(Config.SecurityConnectionStrings);
            SqlParameter[] pars = new SqlParameter[2];
            pars[0] = new SqlParameter("@RoleID", roleID);
            pars[1] = new SqlParameter("@ReturnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };

            db.ExecuteNonQuerySP("sp_Roles_Delete", pars);
            ReturnValue = Convert.ToInt32(pars[1].Value);
        }

        public void Delete()
        {
            DbHelper db = new DbHelper(Config.SecurityConnectionStrings);
            SqlParameter[] pars = new SqlParameter[2];
            pars[0] = new SqlParameter("@RoleID", RoleID);
            pars[1] = new SqlParameter("@ReturnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };

            db.ExecuteNonQuerySP("sp_Roles_Delete", pars);
            ReturnValue = Convert.ToInt32(pars[1].Value);
        }

        public List<Roles> GetList()
        {
            DbHelper db = new DbHelper(Config.SecurityConnectionStrings);
            return db.GetListSP<Roles>("sp_Roles_SelectList");
        }

        public DataTable GetTList()
        {
            DbHelper db = new DbHelper(Config.SecurityConnectionStrings);
            return db.GetDataTableSP("sp_Roles_SelectList");
        }
    }
}
