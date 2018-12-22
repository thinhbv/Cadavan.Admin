using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Libs.Db;

namespace Libs.Security
{
    public class Functions
    {
        public int FunctionID { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public string Url { get; set; }
        public int FatherID { get; set; }
        public string Note { get; set; }
        public bool IsActive { get; set; }
        public bool IsDisplay { get; set; }
        public DateTime CreatedTime { get; set; }
        public int Order { get; set; }
        public string TotalOrder { get; set; }
        public int ReturnValue { get; set; }

        public Functions()
        {

        }

        ~Functions()
        {

        }

        public virtual void Dispose()
        {

        }

        /// <summary>
        /// Lấy giá trị của function theo ID
        /// </summary>
        /// <param name="functionID"></param>
        /// <returns></returns>
        public Functions Get(int functionID)
        {
            DbHelper db = new DbHelper(Config.SecurityConnectionStrings);
            return db.GetInstanceSP<Functions>("sp_Functions_Select", new SqlParameter("@FunctionID", functionID));
        }

        /// <summary>
        /// Lấy giá trị của function theo ID
        /// </summary>
        /// <returns></returns>
        public Functions Get()
        {
            DbHelper db = new DbHelper(Config.SecurityConnectionStrings);
            return db.GetInstanceSP<Functions>("sp_Functions_Select", new SqlParameter("@FunctionID", FunctionID));
        }

        /// <summary>
        /// Thêm mới function
        /// </summary>
        public void Add()
        {
            DbHelper db = new DbHelper(Config.SecurityConnectionStrings);
            SqlParameter[] pars = new SqlParameter[9];
            pars[0] = new SqlParameter("@ReturnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            pars[1] = new SqlParameter("@Name", Name);
            pars[2] = new SqlParameter("@Url", Url);
            pars[3] = new SqlParameter("@FatherID", FatherID);
            pars[4] = new SqlParameter("@Note", Note);
            pars[5] = new SqlParameter("@IsActive", IsActive);
            pars[6] = new SqlParameter("@IsDisplay", IsDisplay);
            pars[7] = new SqlParameter("@Order", Order);
            pars[8] = new SqlParameter("@Alias", Alias);

            db.ExecuteNonQuerySP("sp_Functions_Insert", pars);
            FunctionID = Convert.ToInt32(pars[0].Value);
        }

        /// <summary>
        /// Cập nhật function
        /// </summary>
        public void Update()
        {
            DbHelper db = new DbHelper(Config.SecurityConnectionStrings);
            SqlParameter[] pars = new SqlParameter[10];
            pars[0] = new SqlParameter("@FunctionID", FunctionID); 
            pars[1] = new SqlParameter("@Name", Name);
            pars[2] = new SqlParameter("@Alias", Alias);
            pars[3] = new SqlParameter("@Url", Url);
            pars[4] = new SqlParameter("@FatherID", FatherID);
            pars[5] = new SqlParameter("@Note", Note);
            pars[6] = new SqlParameter("@IsActive", IsActive);
            pars[7] = new SqlParameter("@IsDisplay", IsDisplay);
            pars[8] = new SqlParameter("@Order", Order);
            pars[9] = new SqlParameter("@ReturnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };

            db.ExecuteNonQuerySP("sp_Functions_Update", pars);
            ReturnValue = Convert.ToInt32(pars[9].Value);
        }

        /// <summary>
        /// Xoá function
        /// </summary>
        /// <param name="functionID"></param>
        public void Delete(int functionID)
        {
            DbHelper db = new DbHelper(Config.SecurityConnectionStrings);
            db.ExecuteNonQuerySP("sp_Functions_Delete", new SqlParameter("@FunctionID", functionID));
        }

        /// <summary>
        /// Xoá function
        /// </summary>
        public void Delete()
        {
            DbHelper db = new DbHelper(Config.SecurityConnectionStrings);
            db.ExecuteNonQuerySP("sp_Functions_Delete", new SqlParameter("@FunctionID", FunctionID));
        }

        /// <summary>
        /// Lấy danh sách function
        /// </summary>
        /// <returns></returns>
        public List<Functions> GetList()
        {
            DbHelper db = new DbHelper(Config.SecurityConnectionStrings);
            return db.GetListSP<Functions>("sp_Functions_SelectList",
                new SqlParameter("@IsActive", DBNull.Value),
                new SqlParameter("@IsDisplay", DBNull.Value),
                new SqlParameter("@FatherID", DBNull.Value));
        }

        public List<Functions> GetList(int active, int display)
        {
            DbHelper db = new DbHelper(Config.SecurityConnectionStrings);
            return db.GetListSP<Functions>("sp_Functions_SelectList",
                active == -1 ? new SqlParameter("@IsActive", DBNull.Value) : new SqlParameter("@IsActive", active),
                display == -1 ? new SqlParameter("@IsDisplay", DBNull.Value) : new SqlParameter("@IsDisplay", display),
                new SqlParameter("@FatherID", DBNull.Value));
        }

        public List<Functions> GetSunList(int fatherID)
        {
            DbHelper db = new DbHelper(Config.SecurityConnectionStrings);
            return db.GetListSP<Functions>("sp_Functions_SelectList",
                new SqlParameter("@FatherID", fatherID),
                new SqlParameter("@IsDisplay", DBNull.Value),
                new SqlParameter("@IsActive", DBNull.Value));
        }

        public List<Functions> GetMenuList(int userID)
        {
            DbHelper db = new DbHelper(Config.SecurityConnectionStrings);
            return db.GetListSP<Functions>("sp_Functions_SelectMenuList",
                new SqlParameter("@UserID", userID));
        }
    }
}
