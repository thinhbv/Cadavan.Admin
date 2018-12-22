using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Libs.Db;

namespace Libs.Content
{
    public class NewsRoyalties
    {
        public int ReturnValue { get; set; }
        public int NewsID { get; set; }
        public string FullName { get; set; }
        public string Class { get; set; }
        public int Royalties { get; set; }
        public int Points { get; set; }

        public NewsRoyalties()
        {

        }

        ~NewsRoyalties()
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
            SqlParameter[] pars = new SqlParameter[6];
            pars[0] = new SqlParameter("@ReturnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            pars[1] = new SqlParameter("@NewsID", NewsID);
            pars[2] = new SqlParameter("@FullName", FullName);
            pars[3] = new SqlParameter("@Class", Class);
            pars[4] = new SqlParameter("@Royalties", Royalties);
            pars[5] = new SqlParameter("@Points", Points);

            db.ExecuteNonQuerySP("sp_NewsRoyalties_Insert", pars);
            ReturnValue = Convert.ToInt32(pars[0].Value);
        }

        /// <summary>
        /// Cập nhật
        /// </summary>
        public void Update()
        {
            DbHelper db = new DbHelper(Config.NewsConnectionStrings);
            SqlParameter[] pars = new SqlParameter[6];
            pars[0] = new SqlParameter("@ReturnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            pars[1] = new SqlParameter("@NewsID", NewsID);
            pars[2] = new SqlParameter("@FullName", FullName);
            pars[3] = new SqlParameter("@Class", Class);
            pars[4] = new SqlParameter("@Royalties", Royalties);
            pars[5] = new SqlParameter("@Points", Points);

            db.ExecuteNonQuerySP("sp_NewsRoyalties_Update", pars);
            ReturnValue = Convert.ToInt32(pars[0].Value);
        }

        /// <summary>
        /// Cập nhật
        /// </summary>
        public void Update(int userID)
        {
            DbHelper db = new DbHelper(Config.NewsConnectionStrings);
            SqlParameter[] pars = new SqlParameter[7];
            pars[0] = new SqlParameter("@ReturnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            pars[1] = new SqlParameter("@NewsID", NewsID);
            pars[2] = new SqlParameter("@FullName", FullName);
            pars[3] = new SqlParameter("@Class", Class);
            pars[4] = new SqlParameter("@Royalties", Royalties);
            pars[5] = new SqlParameter("@Points", Points);
            pars[6] = new SqlParameter("@UserID", userID);

            db.ExecuteNonQuerySP("sp_NewsRoyalties_UpdateWithLog", pars);
            ReturnValue = Convert.ToInt32(pars[0].Value);
        }

        public NewsRoyalties Get()
        {
            DbHelper db = new DbHelper(Config.NewsConnectionStrings);
            return db.GetInstanceSP<NewsRoyalties>("sp_NewsRoyalties_Select", new SqlParameter("@NewsID", NewsID));
        }

        /// <summary>
        /// Lấy giá trị theo ID
        /// </summary>
        /// <param name="forumID"></param>
        /// <returns></returns>
        public NewsRoyalties Get(int forumID)
        {
            DbHelper db = new DbHelper(Config.NewsConnectionStrings);
            return db.GetInstanceSP<NewsRoyalties>("sp_NewsRoyalties_Select", new SqlParameter("@NewsID", NewsID));
        }

        /// <summary>
        /// Báo cáo nhuận bút
        /// </summary>
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

            DataTable dt = db.GetDataTableSP("sp_NewsRoyalties_Report", pars);
            totalRecord = Convert.ToInt32(pars[6].Value);
            totalRoyalty = Convert.ToInt32(pars[7].Value);
            return dt;
        }

    }
}
