using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Libs.Db;

namespace Libs.Security
{
    public class UserFunction
    {
        public int UserID { get; set; }
        public int FunctionID { get; set; }
        public DateTime CreatedTime { get; set; }
        public int ReturnValue { get; set; }

        /// <summary>
        /// Thêm mới quyền truy cập cho user
        /// </summary>
        public void Add()
        {
            DbHelper db = new DbHelper(Config.SecurityConnectionStrings);
            SqlParameter[] pars = new SqlParameter[3];
            pars[0] = new SqlParameter("@ReturnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            pars[1] = new SqlParameter("@UserID", UserID);
            pars[2] = new SqlParameter("@FunctionID", FunctionID);

            db.ExecuteNonQuerySP("sp_UserFunction_Insert", pars);
            ReturnValue = Convert.ToInt32(pars[0].Value);
        }

        public void Update(int userID, int functionID, int isActive)
        {
            DbHelper db = new DbHelper(Config.SecurityConnectionStrings);
            SqlParameter[] pars = new SqlParameter[4];
            pars[0] = new SqlParameter("@ReturnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            pars[1] = new SqlParameter("@UserID", userID);
            pars[2] = new SqlParameter("@FunctionID", functionID);
            pars[3] = new SqlParameter("@IsActive", isActive);

            db.ExecuteNonQuerySP("sp_UserFunction_Update", pars);
            ReturnValue = Convert.ToInt32(pars[0].Value);
        }

        public List<UserFunction> GetList(int userID)
        {
            DbHelper db = new DbHelper(Config.SecurityConnectionStrings);
            return db.GetListSP<UserFunction>("sp_UserFunction_SelectList",
                new SqlParameter("@UserID", userID));
        }

    }
}
