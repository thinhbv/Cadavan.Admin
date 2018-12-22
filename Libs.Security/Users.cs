using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Libs.Db;

namespace Libs.Security
{
    public class Users
    {
        public int UserID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public DateTime CreatedTime { get; set; }
        public int Status { get; set; }
        public int GroupID { get; set; }
        public DateTime LastestTime { get; set; }
        public int ReturnValue { get; set; }

        public Users()
        {

        }

        ~Users()
        {

        }

        public virtual void Dispose()
        {

        }

        /// <summary>
        /// Lấy giá trị user theo ID
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public Users Get(int userID)
        {
            DbHelper db = new DbHelper(Config.SecurityConnectionStrings);
            return db.GetInstanceSP<Users>("sp_Users_Select",
                new SqlParameter("@UserID", userID));
        }

        /// <summary>
        /// Lấy giá trị user theo ID
        /// </summary>
        /// <returns></returns>
        public Users Get()
        {
            DbHelper db = new DbHelper(Config.SecurityConnectionStrings);
            return db.GetInstanceSP<Users>("sp_Users_Select",
                new SqlParameter("@UserID", UserID));
        }

        /// <summary>
        /// Thêm mới user
        /// </summary>
        public void Add()
        {
            DbHelper db = new DbHelper(Config.SecurityConnectionStrings);
            SqlParameter[] pars = new SqlParameter[6];
            pars[0] = new SqlParameter("@ReturnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            pars[1] = new SqlParameter("@Email", Email);
            pars[2] = new SqlParameter("@Password", Password);
            pars[3] = new SqlParameter("@FullName", FullName);
            pars[4] = new SqlParameter("@Status", Status);
            pars[5] = new SqlParameter("@GroupID", GroupID);

            db.ExecuteNonQuerySP("sp_Users_Insert", pars);
            UserID = Convert.ToInt32(pars[0].Value);
        }

        /// <summary>
        /// Cập nhật user
        /// </summary>
        public void Update()
        {
            DbHelper db = new DbHelper(Config.SecurityConnectionStrings);
            SqlParameter[] pars = new SqlParameter[8];
            pars[0] = new SqlParameter("@UserID", UserID);
            pars[1] = new SqlParameter("@Email", Email);
            pars[2] = new SqlParameter("@Password", Password);
            pars[3] = new SqlParameter("@FullName", FullName);
            pars[4] = new SqlParameter("@Status", Status);
            pars[5] = new SqlParameter("@LastestTime", LastestTime);
            pars[6] = new SqlParameter("@GroupID", GroupID);
            pars[7] = new SqlParameter("@ReturnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };

            db.ExecuteNonQuerySP("sp_Users_Update", pars);
            ReturnValue = Convert.ToInt32(pars[7].Value);
        }

        /// <summary>
        /// Xoá user
        /// </summary>
        /// <param name="userID"></param>
        public void Delete(int userID)
        {
            DbHelper db = new DbHelper(Config.SecurityConnectionStrings);
            SqlParameter[] pars = new SqlParameter[2];
            pars[0] = new SqlParameter("@UserID", userID);
            pars[1] = new SqlParameter("@ReturnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };

            db.ExecuteNonQuerySP("sp_Users_Delete", pars);
            ReturnValue = Convert.ToInt32(pars[1].Value);
        }

        public void Delete()
        {
            DbHelper db = new DbHelper(Config.SecurityConnectionStrings);
            SqlParameter[] pars = new SqlParameter[2];
            pars[0] = new SqlParameter("@UserID", UserID);
            pars[1] = new SqlParameter("@ReturnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };

            db.ExecuteNonQuerySP("sp_Users_Delete", pars);
            ReturnValue = Convert.ToInt32(pars[1].Value);
        }

        /// <summary>
        /// Kiểm tra quyền truy cập
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public bool CheckUrl(int userID, string url)
        {
            DbHelper db = new DbHelper(Config.SecurityConnectionStrings);
            SqlParameter[] pars = new SqlParameter[3];
            pars[0] = new SqlParameter("@ReturnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            pars[1] = new SqlParameter("@UserID", userID);
            pars[2] = new SqlParameter("@Url", url);
            db.ExecuteNonQuerySP("sp_Users_CheckUrl", pars);
            return Convert.ToInt32(pars[0].Value) == 1;
        }

        public Users Authentication(string username, string password)
        {
            DbHelper db = new DbHelper(Config.SecurityConnectionStrings);
            return db.GetInstanceSP<Users>("sp_Users_Authentication",
                new SqlParameter("@Email", username),
                new SqlParameter("@Password", password));
        }

        public List<Users> GetList(int status)
        {
            DbHelper db = new DbHelper(Config.SecurityConnectionStrings);
            return db.GetListSP<Users>("sp_Users_SelectList",
                status == -1 ? new SqlParameter("@Status", DBNull.Value) : new SqlParameter("@Status", status));
        }

        public List<Users> GetList()
        {
            DbHelper db = new DbHelper(Config.SecurityConnectionStrings);
            return db.GetListSP<Users>("sp_Users_SelectList",
                new SqlParameter("@Status", DBNull.Value));
        }

        public DataTable GetTList(int status)
        { 
            DbHelper db = new DbHelper(Config.SecurityConnectionStrings);
            return db.GetDataTableSP("sp_Users_SelectList",
                status == -1 ? new SqlParameter("@Status", DBNull.Value) : new SqlParameter("@Status", status));
        }

        public DataTable GetTList()
        {
            DbHelper db = new DbHelper(Config.SecurityConnectionStrings);
            return db.GetDataTableSP("sp_Users_SelectList",
                new SqlParameter("@Status", DBNull.Value));
        }

        public DataTable GetTList(int status, int groupID)
        {
            DbHelper db = new DbHelper(Config.SecurityConnectionStrings);
            return db.GetDataTableSP("sp_Users_SelectList_Full",
                status == -1 ? new SqlParameter("@Status", DBNull.Value) : new SqlParameter("@Status", status),
                groupID == 0 ? new SqlParameter("@GroupID", DBNull.Value) : new SqlParameter("@GroupID", groupID)
                );
        }

    }
}
