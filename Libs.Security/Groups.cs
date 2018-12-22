using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Libs.Db;

namespace Libs.Security
{
    public class Groups
    {
        public int GroupID { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
        public string Description { get; set; }
        public int ReturnValue { get; set; }

        public Groups()
        {

        }

        ~Groups()
        {

        }

        public virtual void Dispose()
        {

        }

        /// <summary>
        /// Lấy giá trị của group theo ID
        /// </summary>
        /// <param name="functionID"></param>
        /// <returns></returns>
        public Groups Get(int groupID)
        {
            DbHelper db = new DbHelper(Config.SecurityConnectionStrings);
            return db.GetInstanceSP<Groups>("sp_Groups_Select", new SqlParameter("@GroupID", groupID));
        }

        /// <summary>
        /// Lấy giá trị của group theo ID
        /// </summary>
        /// <returns></returns>
        public Groups Get()
        {
            DbHelper db = new DbHelper(Config.SecurityConnectionStrings);
            return db.GetInstanceSP<Groups>("sp_Groups_Select", new SqlParameter("@GroupID", GroupID));
        }

        /// <summary>
        /// Thêm mới function
        /// </summary>
        public void Add()
        {
            DbHelper db = new DbHelper(Config.SecurityConnectionStrings);
            SqlParameter[] pars = new SqlParameter[4];
            pars[0] = new SqlParameter("@ReturnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            pars[1] = new SqlParameter("@Name", Name);
            pars[2] = new SqlParameter("@Order", Order);
            pars[3] = new SqlParameter("@Description", Description);

            db.ExecuteNonQuerySP("sp_Groups_Insert", pars);
            GroupID = Convert.ToInt32(pars[0].Value);
        }

        /// <summary>
        /// Cập nhật function
        /// </summary>
        public void Update()
        {
            DbHelper db = new DbHelper(Config.SecurityConnectionStrings);
            SqlParameter[] pars = new SqlParameter[5];
            pars[0] = new SqlParameter("@GroupID", GroupID);
            pars[1] = new SqlParameter("@Name", Name);
            pars[2] = new SqlParameter("@Order", Order);
            pars[3] = new SqlParameter("@Description", Description);
            pars[4] = new SqlParameter("@ReturnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };

            db.ExecuteNonQuerySP("sp_Groups_Update", pars);
            ReturnValue = Convert.ToInt32(pars[4].Value);
        }

        /// <summary>
        /// Xoá group
        /// </summary>
        /// <param name="functionID"></param>
        public void Delete(int groupID)
        {
            DbHelper db = new DbHelper(Config.SecurityConnectionStrings);
            db.ExecuteNonQuerySP("sp_Groups_Delete", new SqlParameter("@GroupID", groupID));
        }

        /// <summary>
        /// Xoá group
        /// </summary>
        public void Delete()
        {
            DbHelper db = new DbHelper(Config.SecurityConnectionStrings);
            db.ExecuteNonQuerySP("sp_Groups_Delete", new SqlParameter("@GroupID", GroupID));
        }

        /// <summary>
        /// Lấy danh sách function
        /// </summary>
        /// <returns></returns>
        public List<Groups> GetList()
        {
            DbHelper db = new DbHelper(Config.SecurityConnectionStrings);
            return db.GetListSP<Groups>("sp_Groups_SelectList");
        }


    }
}
