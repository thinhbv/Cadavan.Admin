using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Libs.Db;

namespace Libs.Security
{
    public class UserInfo
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Gender { get; set; }
        public DateTime Birthday { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public int DepartmentID { get; set; }
        public int ReturnValue { get; set; }

        public UserInfo()
        {

        }

        ~UserInfo()
        {

        }

        public virtual void Dispose()
        {

        }

        public UserInfo Get(int userID)
        {
            DbHelper db = new DbHelper(Config.SecurityConnectionStrings);
            return db.GetInstanceSP<UserInfo>("sp_UserInfo_Select",
                new SqlParameter("@UserID", userID));
        }

        public UserInfo Get()
        {
            DbHelper db = new DbHelper(Config.SecurityConnectionStrings);
            return db.GetInstanceSP<UserInfo>("sp_UserInfo_Select",
                new SqlParameter("@UserID", UserID));
        }

        public void Update()
        {
            DbHelper db = new DbHelper(Config.SecurityConnectionStrings);
            SqlParameter[] pars = new SqlParameter[9];
            pars[0] = new SqlParameter("@UserID", UserID);
            pars[1] = new SqlParameter("@FirstName", FirstName);
            pars[2] = new SqlParameter("@LastName", LastName);
            pars[3] = new SqlParameter("@Gender", Gender);
            pars[4] = new SqlParameter("@Birthday", Birthday);
            pars[5] = new SqlParameter("@Mobile", Mobile);
            pars[6] = new SqlParameter("@Email", Email);
            pars[7] = new SqlParameter("@DepartmentID", DepartmentID);
            pars[8] = new SqlParameter("@ReturnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };

            db.ExecuteNonQuerySP("sp_UserInfo_Update", pars);
            ReturnValue = Convert.ToInt32(pars[8].Value);
        }

    }
}
