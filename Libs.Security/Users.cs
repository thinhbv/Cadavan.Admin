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
        public string Username { get; set; }
        public string Password { get; set; }
        public int Status { get; set; }
        public string Fullname { get; set; }
        public int RoleID { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastLogin { get; set; }
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
        /// Lấy thông tin tài khoản
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
        /// Lấy thông tin tài khoản
        /// </summary>
        /// <returns></returns>
        public Users Get()
        {
            DbHelper db = new DbHelper(Config.SecurityConnectionStrings);
            return db.GetInstanceSP<Users>("sp_Users_Select",
                new SqlParameter("@UserID", UserID));
        }

        /// <summary>
        /// Thêm mới tài khoản
        /// </summary>
        public void Add()
        {
            DbHelper db = new DbHelper(Config.SecurityConnectionStrings);
            SqlParameter[] pars = new SqlParameter[6];
            pars[0] = new SqlParameter("@ReturnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            pars[1] = new SqlParameter("@Username", Username);
            pars[2] = new SqlParameter("@Password", Password);
            pars[3] = new SqlParameter("@Status", Status);
            pars[4] = new SqlParameter("@Fullname", Fullname);
            pars[5] = new SqlParameter("@RoleID", RoleID);

            db.ExecuteNonQuerySP("sp_Users_Insert", pars);
            UserID = Convert.ToInt32(pars[0].Value);
            ReturnValue = UserID;
        }

        public void Add(Users user, UserInfo userInfo)
        {
            DbHelper db = new DbHelper(Config.SecurityConnectionStrings);
            SqlParameter[] pars = new SqlParameter[12];
            pars[0] = new SqlParameter("@ReturnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            pars[1] = new SqlParameter("@Username", user.Username);
            pars[2] = new SqlParameter("@Password", user.Password);
            pars[3] = new SqlParameter("@Status", user.Status);
            pars[4] = new SqlParameter("@RoleID", user.RoleID);
            pars[5] = new SqlParameter("@FirstName", userInfo.FirstName);
            pars[6] = new SqlParameter("@LastName", userInfo.LastName);
            pars[7] = new SqlParameter("@Gender", userInfo.Gender);
            pars[8] = new SqlParameter("@Birthday", userInfo.Birthday);
            pars[9] = new SqlParameter("@Mobile", userInfo.Mobile);
            pars[10] = new SqlParameter("@Email", userInfo.Email);
            pars[11] = new SqlParameter("@DepartmentID", userInfo.DepartmentID);

            db.ExecuteNonQuerySP("sp_Users_InsertFull", pars);
            UserID = Convert.ToInt32(pars[0].Value);
            ReturnValue = UserID;
        }

        /// <summary>
        /// Cập nhật tài khoản
        /// </summary>
        public void Update()
        {
            DbHelper db = new DbHelper(Config.SecurityConnectionStrings);
            SqlParameter[] pars = new SqlParameter[5];
            pars[0] = new SqlParameter("@UserID", UserID);
            pars[1] = new SqlParameter("@Status", Status);
            pars[2] = new SqlParameter("@Fullname", Fullname);
            pars[3] = new SqlParameter("@RoleID", RoleID);
            pars[4] = new SqlParameter("@ReturnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };

            db.ExecuteNonQuerySP("sp_Users_Update", pars);
            ReturnValue = Convert.ToInt32(pars[4].Value);
        }

        /// <summary>
        /// Xoá tài khoản
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

        /// <summary>
        /// Xoá tài khoản
        /// </summary>
        /// <param name="userID"></param>
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
        /// Đăng nhập
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public void Authentication(string username, string password, ref string tokenKey, ref DateTime lastLogin, ref int userID)
        {
            DbHelper db = new DbHelper(Config.SecurityConnectionStrings);
            SqlParameter[] pars = new SqlParameter[5];
            pars[0] = new SqlParameter("@UserName", username);
            pars[1] = new SqlParameter("@Password", password);
            pars[2] = new SqlParameter("@TokenKey", SqlDbType.NVarChar, 50) { Direction = ParameterDirection.Output };
            pars[3] = new SqlParameter("@LastLogin", SqlDbType.DateTime) { Direction = ParameterDirection.Output };
            pars[4] = new SqlParameter("@ReturnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            db.ExecuteNonQuerySP("sp_Users_Authentication", pars);

            userID = Convert.ToInt32(pars[4].Value);
            if (userID > 0)
            {
                ReturnValue = userID;
                tokenKey = pars[2].Value.ToString();
                if (pars[3] != null)
                {
                    lastLogin = Convert.ToDateTime(pars[3].Value);
                }
            }
        }

        public List<Users> GetList(int status)
        {
            DbHelper db = new DbHelper(Config.SecurityConnectionStrings);
            return db.GetListSP<Users>("sp_Users_SelectList",
                status == 0 ? new SqlParameter("@Status", DBNull.Value) : new SqlParameter("@Status", status));
        }

        public List<Users> GetList()
        {
            DbHelper db = new DbHelper(Config.SecurityConnectionStrings);
            return db.GetListSP<Users>("sp_Users_SelectList",
                new SqlParameter("@Status", DBNull.Value),
                new SqlParameter("@RoleID", DBNull.Value));
        }

        public DataTable GetTList()
        {
            DbHelper db = new DbHelper(Config.SecurityConnectionStrings);
            return db.GetDataTableSP("sp_Users_SelectListFull",
                new SqlParameter("@Status", DBNull.Value),
                new SqlParameter("@RoleID", DBNull.Value));
        }

        public DataTable GetTList(int roleID, int status)
        {
            DbHelper db = new DbHelper(Config.SecurityConnectionStrings);
            return db.GetDataTableSP("sp_Users_SelectListFull",
                status == 0 ? new SqlParameter("@Status", DBNull.Value) : new SqlParameter("@Status", status),
                roleID == 0 ? new SqlParameter("@RoleID", DBNull.Value) : new SqlParameter("@RoleID", roleID));
        }

        public void ResetPassword(int userID, string password)
        {
            DbHelper db = new DbHelper(Config.SecurityConnectionStrings);
            SqlParameter[] pars = new SqlParameter[3];
            pars[0] = new SqlParameter("@UserID", userID);
            pars[1] = new SqlParameter("@Password", password);
            pars[2] = new SqlParameter("@ReturnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            db.ExecuteNonQuerySP("sp_Users_ResetPassword", pars);

            ReturnValue = Convert.ToInt32(pars[2].Value);
        }

        public void ChangePassword(int userID, string password, string newPassword)
        {
            DbHelper db = new DbHelper(Config.SecurityConnectionStrings);
            SqlParameter[] pars = new SqlParameter[4];
            pars[0] = new SqlParameter("@UserID", userID);
            pars[1] = new SqlParameter("@Password", password);
            pars[2] = new SqlParameter("@NewPassword", newPassword);
            pars[3] = new SqlParameter("@ReturnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            db.ExecuteNonQuerySP("sp_Users_ChangePassword", pars);

            ReturnValue = Convert.ToInt32(pars[3].Value);
        }

        public DataTable Report()
        {
            DbHelper db = new DbHelper(Config.SecurityConnectionStrings);
            return db.GetDataTableSP("sp_Users_Report");
        }
    }
}
