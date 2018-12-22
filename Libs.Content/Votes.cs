using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Libs.Db;

namespace Libs.Content
{
    public class Votes
    {
        public int VoteID { get; set; }
        public string Title { get; set; }
        public DateTime CreatedTime { get; set; }
        public int Count { get; set; }
        public int UserID { get; set; }
        public bool IsActive { get; set; }
        public DateTime ExpireTime { get; set; }
        public int ReturnValue { get; set; }

        public Votes()
        {

        }

        ~Votes()
        {

        }

        public virtual void Dispose()
        {

        }

        /// <summary>
        /// Lấy giá trị của thăm dò theo ID
        /// </summary>
        /// <param name="voteID"></param>
        /// <returns></returns>
        public Votes Get(int voteID)
        {
            DbHelper db = new DbHelper(Config.NewsConnectionStrings);
            return db.GetInstanceSP<Votes>("sp_Votes_Select", new SqlParameter("@VoteID", voteID));
        }

        /// <summary>
        /// Lấy giá trị của thăm dò theo ID
        /// </summary>
        /// <returns></returns>
        public Votes Get()
        {
            DbHelper db = new DbHelper(Config.NewsConnectionStrings);
            return db.GetInstanceSP<Votes>("sp_Votes_Select", new SqlParameter("@VoteID", VoteID));
        }

        /// <summary>
        /// Lấy danh sách danh mục
        /// </summary>
        /// <returns></returns>
        public DataTable GetTList()
        {
            DbHelper db = new DbHelper(Config.NewsConnectionStrings);
            return db.GetDataTableSP("sp_Votes_SelectList");
        }

        public List<Votes> GetList()
        {
            DbHelper db = new DbHelper(Config.NewsConnectionStrings);
            return db.GetListSP<Votes>("sp_Votes_SelectList");
        }

        /// <summary>
        /// Thêm mới thăm dò
        /// </summary>
        public void Add()
        {
            DbHelper db = new DbHelper(Config.NewsConnectionStrings);
            SqlParameter[] pars = new SqlParameter[5];
            pars[0] = new SqlParameter("@ReturnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            pars[1] = new SqlParameter("@Title", Title);
            pars[2] = new SqlParameter("@UserID", UserID);
            pars[3] = new SqlParameter("@IsActive", IsActive);
            pars[4] = new SqlParameter("@ExpireTime", ExpireTime);

            db.ExecuteNonQuerySP("sp_Votes_Insert", pars);
            VoteID = Convert.ToInt32(pars[0].Value);
        }

        /// <summary>
        /// Xóa thăm dò
        /// </summary>
        public void Delete()
        {
            DbHelper db = new DbHelper(Config.NewsConnectionStrings);
            SqlParameter[] pars = new SqlParameter[2];
            pars[0] = new SqlParameter("@ReturnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            pars[1] = new SqlParameter("@VoteID", VoteID);

            db.ExecuteNonQuerySP("sp_Votes_Delete", pars);
            ReturnValue = Convert.ToInt32(pars[0].Value);
        }

        /// <summary>
        /// Xóa thăm dò
        /// </summary>
        public void Delete(int voteID)
        {
            DbHelper db = new DbHelper(Config.NewsConnectionStrings);
            SqlParameter[] pars = new SqlParameter[2];
            pars[0] = new SqlParameter("@ReturnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            pars[1] = new SqlParameter("@VoteID", voteID);

            db.ExecuteNonQuerySP("sp_Votes_Delete", pars);
            ReturnValue = Convert.ToInt32(pars[0].Value);
        }

        /// <summary>
        /// Cập nhật thăm dò
        /// </summary>
        public void Update()
        {
            DbHelper db = new DbHelper(Config.NewsConnectionStrings);
            SqlParameter[] pars = new SqlParameter[7];
            pars[0] = new SqlParameter("@ReturnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            pars[1] = new SqlParameter("@VoteID", VoteID);
            pars[2] = new SqlParameter("@Title", Title);
            pars[3] = new SqlParameter("@Count", Count);
            pars[4] = new SqlParameter("@UserID", UserID);
            pars[5] = new SqlParameter("@IsActive", IsActive);
            pars[6] = new SqlParameter("@ExpireTime", ExpireTime);

            db.ExecuteNonQuerySP("sp_Votes_Update", pars);
            VoteID = Convert.ToInt32(pars[0].Value);
        }
    }
}
