using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Libs.Db;

namespace Libs.Security
{
    public class GroupFunction
    {
        public int GroupID { get; set; }
        public int FunctionID { get; set; }
        public DateTime CreatedTime { get; set; }
        public int ReturnValue { get; set; }

        public GroupFunction()
        {

        }

        ~GroupFunction()
        {

        }

        public virtual void Dispose()
        {

        }

        /// <summary>
        /// Thêm mới quyền truy cập cho nhóm quyền
        /// </summary>
        public void Add()
        {
            DbHelper db = new DbHelper(Config.SecurityConnectionStrings);
            SqlParameter[] pars = new SqlParameter[3];
            pars[0] = new SqlParameter("@ReturnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            pars[1] = new SqlParameter("@GroupID", GroupID);
            pars[2] = new SqlParameter("@FunctionID", FunctionID);

            db.ExecuteNonQuerySP("sp_GroupFunction_Insert", pars);
            ReturnValue = Convert.ToInt32(pars[0].Value);
        }

        public List<GroupFunction> GetList(int groupID)
        {
            DbHelper db = new DbHelper(Config.SecurityConnectionStrings);
            return db.GetListSP<GroupFunction>("sp_GroupFunction_SelectList",
                new SqlParameter("@GroupID", groupID));
        }

        public void Update(int groupID, int functionID, int isActive)
        {
            DbHelper db = new DbHelper(Config.SecurityConnectionStrings);
            SqlParameter[] pars = new SqlParameter[4];
            pars[0] = new SqlParameter("@ReturnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            pars[1] = new SqlParameter("@GroupID", groupID);
            pars[2] = new SqlParameter("@FunctionID", functionID);
            pars[3] = new SqlParameter("@IsActive", isActive);

            db.ExecuteNonQuerySP("sp_GroupFunction_Update", pars);
            ReturnValue = Convert.ToInt32(pars[0].Value);
        }


    }
}
