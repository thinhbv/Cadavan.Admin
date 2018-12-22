using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Libs.Db;

namespace Libs.Content
{
    public class NewsForum
    {
        public int ForumID { get; set; }
        public int NewsID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedTime { get; set; }
        public int Status { get; set; }
        public string Header { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public int FileID { get; set; }
        public int ReturnValue { get; set; }

        public NewsForum()
        {

        }

        ~NewsForum()
        {

        }

        public virtual void Dispose()
        {

        }

        /// <summary>
        /// Thêm mới
        /// </summary>
        public void Add()
        {
            DbHelper db = new DbHelper(Config.NewsConnectionStrings);
            SqlParameter[] pars = new SqlParameter[9];
            pars[0] = new SqlParameter("@ReturnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            pars[1] = new SqlParameter("@NewsID", NewsID);
            pars[2] = new SqlParameter("@Title", Title);
            pars[3] = new SqlParameter("@Content", Content);
            pars[4] = new SqlParameter("@Status", Status);
            pars[5] = new SqlParameter("@Header", Header);
            pars[6] = new SqlParameter("@FullName", FullName);
            pars[7] = new SqlParameter("@Email", Email);
            pars[8] = new SqlParameter("@FileID", FileID);

            db.ExecuteNonQuerySP("sp_NewsForum_Insert", pars);
            ForumID = Convert.ToInt32(pars[0].Value);
        }

        /// <summary>
        /// Cập nhật
        /// </summary>
        public void Update()
        {
            DbHelper db = new DbHelper(Config.NewsConnectionStrings);
            SqlParameter[] pars = new SqlParameter[9];
            pars[0] = new SqlParameter("@ReturnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            pars[1] = new SqlParameter("@ForumID", ForumID);
            pars[2] = new SqlParameter("@Title", Title);
            pars[3] = new SqlParameter("@Content", Content);
            pars[4] = new SqlParameter("@Status", Status);
            pars[5] = new SqlParameter("@Header", Header);
            pars[6] = new SqlParameter("@FullName", FullName);
            pars[7] = new SqlParameter("@Email", Email);
            pars[8] = new SqlParameter("@FileID", FileID);

            db.ExecuteNonQuerySP("sp_NewsForum_Update", pars);
            ReturnValue = Convert.ToInt32(pars[0].Value);
        }

        /// <summary>
        /// Xoá
        /// </summary>
        public void Delete()
        {
            DbHelper db = new DbHelper(Config.NewsConnectionStrings);
            SqlParameter[] pars = new SqlParameter[2];
            pars[0] = new SqlParameter("@ReturnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            pars[1] = new SqlParameter("@ForumID", ForumID);

            db.ExecuteNonQuerySP("sp_NewsForum_Delete", pars);
            ReturnValue = Convert.ToInt32(pars[0].Value);
        }

        public NewsForum Get()
        {
            DbHelper db = new DbHelper(Config.NewsConnectionStrings);
            return db.GetInstanceSP<NewsForum>("sp_NewsForum_Select", new SqlParameter("@ForumID", ForumID));
        }

        /// <summary>
        /// Lấy giá trị theo ID
        /// </summary>
        /// <param name="forumID"></param>
        /// <returns></returns>
        public NewsForum Get(int forumID)
        {
            DbHelper db = new DbHelper(Config.NewsConnectionStrings);
            return db.GetInstanceSP<NewsForum>("sp_NewsForum_Select", new SqlParameter("@ForumID", forumID));
        }

        /// <summary>
        /// Lấy danh sách NewsForum theo trạng thái, theo tin bài
        /// </summary>
        /// <param name="newsID"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public DataTable GetList(int newsID, int status)
        {
            DbHelper db = new DbHelper(Config.NewsConnectionStrings);
            SqlParameter[] pars = new SqlParameter[2];
            pars[0] = newsID == 0 ? new SqlParameter("@NewsID", DBNull.Value) : new SqlParameter("@NewsID", newsID);
            pars[1] = status == 0 ? new SqlParameter("@Status", DBNull.Value) : new SqlParameter("@Status", status);
            return db.GetDataTableSP("sp_NewsForum_SelectList", pars);
        }

        /// <summary>
        /// Lấy danh sách NewsForum theo tin bài
        /// </summary>
        /// <param name="newsID"></param>
        /// <returns></returns>
        public DataTable GetList(int newsID)
        {
            DbHelper db = new DbHelper(Config.NewsConnectionStrings);
            SqlParameter[] pars = new SqlParameter[2];
            pars[0] = newsID == 0 ? new SqlParameter("@NewsID", DBNull.Value) : new SqlParameter("@NewsID", newsID);
            pars[1] = new SqlParameter("@Status", DBNull.Value);
            return db.GetDataTableSP("sp_NewsForum_SelectList", pars);
        }

        public DataTable GetList(int newsID, int status, int pageIndex, int pageSize, ref int totalRecord)
        {
            DbHelper db = new DbHelper(Config.NewsConnectionStrings);
            SqlParameter[] pars = new SqlParameter[5];
            pars[0] = new SqlParameter("@TotalRecord", SqlDbType.Int) { Direction = ParameterDirection.Output };
            pars[1] = new SqlParameter("@PageIndex", pageIndex);
            pars[2] = new SqlParameter("@PageSize", pageSize);
            pars[3] = newsID == 0 ? new SqlParameter("@NewsID", DBNull.Value) : new SqlParameter("@NewsID", newsID);
            pars[4] = status == 0 ? new SqlParameter("@Status", DBNull.Value) : new SqlParameter("@Status", status);
            DataTable dt = db.GetDataTableSP("sp_NewsForum_SelectListPage", pars);
            totalRecord = Convert.ToInt32(pars[0].Value);
            return dt;
        }
    }
}
