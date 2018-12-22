using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Libs.Db;

namespace Libs.Content
{
    public class NewsPublish
    {
        public int PublishID { get; set; }
        public int NewsID { get; set; }
        public int CateID { get; set; }
        public int Order { get; set; }
        public int ReturnValue { get; set; }

        public NewsPublish()
        {

        }

        ~NewsPublish()
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
            SqlParameter[] pars = new SqlParameter[4];
            pars[0] = new SqlParameter("@ReturnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            pars[1] = new SqlParameter("@NewsID", NewsID);
            pars[2] = new SqlParameter("@CateID", CateID);
            pars[3] = new SqlParameter("@Order", Order);

            db.ExecuteNonQuerySP("sp_NewsPublish_Insert", pars);
            PublishID = Convert.ToInt32(pars[0].Value);
        }

        /// <summary>
        /// Xoá theo ID
        /// </summary>
        /// <param name="newsID">ID bài viết</param>
        public void Delete(int newsID)
        {
            DbHelper db = new DbHelper(Config.NewsConnectionStrings);
            db.ExecuteNonQuerySP("sp_NewsPublish_Delete", new SqlParameter("@NewsID", newsID));
        }

        /// <summary>
        /// Lấy danh sách NewsPublist của một bài viết
        /// </summary>
        /// <param name="newsID">ID bài viết</param>
        /// <returns></returns>
        public List<NewsPublish> GetList(int newsID)
        {
            DbHelper db = new DbHelper(Config.NewsConnectionStrings);
            return db.GetListSP<NewsPublish>("sp_NewsPublish_SelectList", new SqlParameter("@NewsID", newsID));
        }
    }
}
