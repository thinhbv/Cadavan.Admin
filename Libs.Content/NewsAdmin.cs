using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Libs.Db;

namespace Libs.Content
{
    public class NewsAdmin
    {
        public int NewsID { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public int UserID { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime PublishedTime { get; set; }
        public int Status { get; set; }
        public int CateID { get; set; }
        public int Order { get; set; }
        public string CateName { get; set; }
        public string Email { get; set; }

        public NewsAdmin()
        {

        }

        ~NewsAdmin()
        {

        }

        public virtual void Dispose()
        {

        }

        public DataTable GetTable(int userID, int status, int pageIndex, int pageSize, ref int totalRecord)
        {
            DbHelper db = new DbHelper(Config.NewsConnectionStrings);
            SqlParameter[] pars = new SqlParameter[5];
            pars[0] = new SqlParameter("@TotalRecord", SqlDbType.Int) { Direction = ParameterDirection.Output };
            pars[1] = userID == 0 ? new SqlParameter("@UserID", DBNull.Value) : new SqlParameter("@UserID", userID);
            pars[2] = status == 0 ? new SqlParameter("@Status", DBNull.Value) : new SqlParameter("@Status", status);
            pars[3] = new SqlParameter("@PageIndex", pageIndex);
            pars[4] = new SqlParameter("@PageSize", pageSize);

            DataTable dt = db.GetDataTableSP("sp_NewsAdmin_SelectListOfUser", pars);
            totalRecord = Convert.ToInt32(pars[0].Value);
            return dt;
        }

        public DataTable GetTable(int cateID, int userID, int status, int pageIndex, int pageSize, ref int totalRecord)
        {
            DbHelper db = new DbHelper(Config.NewsConnectionStrings);
            SqlParameter[] pars = new SqlParameter[6];
            pars[0] = new SqlParameter("@TotalRecord", SqlDbType.Int) { Direction = ParameterDirection.Output };
            pars[1] = cateID == 0 ? new SqlParameter("@CateID", DBNull.Value) : new SqlParameter("@CateID", cateID);
            pars[2] = userID == 0 ? new SqlParameter("@UserID", DBNull.Value) : new SqlParameter("@UserID", userID);
            pars[3] = status == 0 ? new SqlParameter("@Status", DBNull.Value) : new SqlParameter("@Status", status);
            pars[4] = new SqlParameter("@PageIndex", pageIndex);
            pars[5] = new SqlParameter("@PageSize", pageSize);

            DataTable dt = db.GetDataTableSP("sp_NewsAdmin_SelectListPage", pars);
            totalRecord = Convert.ToInt32(pars[0].Value);
            return dt;
        }

        public DataTable Search(string keyword, int cateID, int userID, int status, int pageIndex, int pageSize, ref int totalRecord)
        {
            DbHelper db = new DbHelper(Config.NewsConnectionStrings);
            SqlParameter[] pars = new SqlParameter[7];
            pars[0] = new SqlParameter("@TotalRecord", SqlDbType.Int) { Direction = ParameterDirection.Output };
            pars[1] = cateID == 0 ? new SqlParameter("@CateID", DBNull.Value) : new SqlParameter("@CateID", cateID);
            pars[2] = userID == 0 ? new SqlParameter("@UserID", DBNull.Value) : new SqlParameter("@UserID", userID);
            pars[3] = status == 0 ? new SqlParameter("@Status", DBNull.Value) : new SqlParameter("@Status", status);
            pars[4] = new SqlParameter("@PageIndex", pageIndex);
            pars[5] = new SqlParameter("@PageSize", pageSize);
            pars[6] = new SqlParameter("@Keyword", keyword);

            DataTable dt = db.GetDataTableSP("sp_NewsAdmin_Search", pars);
            totalRecord = Convert.ToInt32(pars[0].Value);
            return dt;
        }

        // Báo cáo nhuận bút
        public DataTable Report(int year, int month, int day, int userID, int pageIndex, int pageSize, ref int totalRecord, ref int totalRoyalty)
        {
            DbHelper db = new DbHelper(Config.NewsConnectionStrings);
            SqlParameter[] pars = new SqlParameter[8];
            pars[0] = year == 0 ? new SqlParameter("@Year", DBNull.Value) : new SqlParameter("@Year", year);
            pars[1] = month == 0 ? new SqlParameter("@Month", DBNull.Value) : new SqlParameter("@Month", month);
            pars[2] = day == 0 ? new SqlParameter("@Day", DBNull.Value) : new SqlParameter("@Day", day);
            pars[3] = userID == 0 ? new SqlParameter("@UserID", DBNull.Value) : new SqlParameter("@UserID", userID);
            pars[4] = new SqlParameter("@PageIndex", pageIndex);
            pars[5] = new SqlParameter("@PageSize", pageSize);
            pars[6] = new SqlParameter("@TotalRecord", SqlDbType.Int) { Direction = ParameterDirection.Output };
            pars[7] = new SqlParameter("@TotalRoyalty", SqlDbType.Int) { Direction = ParameterDirection.Output };

            DataTable dt = db.GetDataTableSP("sp_News_Report", pars);
            totalRecord = Convert.ToInt32(pars[6].Value);
            totalRoyalty = Convert.ToInt32(pars[7].Value);
            return dt;
        }

        public List<NewsAdmin> GetList(int cateID, int top)
        {
            DbHelper db = new DbHelper(Config.NewsConnectionStrings);
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@CateID", cateID);
            parameters[1] = new SqlParameter("@Top", top);
            return db.GetListSP<NewsAdmin>("sp_NewsAdmin_SelectTopList", parameters);
        }

        public DataTable GetLog(int newsID)
        {
            DbHelper db = new DbHelper(Config.NewsConnectionStrings);
            return db.GetDataTableSP("sp_NewsLog_SelectList",
                new SqlParameter("@NewsID", newsID));
        }

    }
}
