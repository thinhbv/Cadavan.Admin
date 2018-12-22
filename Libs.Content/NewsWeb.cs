using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Libs.Db;

namespace Libs.Content
{
    public class NewsWeb
    {
        public int NewsID { get; set; }
        public int CateID { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Lead { get; set; }
        public string SubLead { get; set; }
        public DateTime PublishedTime { get; set; }
        public string Url { get; set; }
        public bool IsPhoto { get; set; }
        public bool IsVideo { get; set; }
        public bool IsAudio { get; set; }

        public NewsWeb()
        {

        }

        ~NewsWeb()
        {

        }

        public virtual void Dispose()
        {

        }

        public DataTable GetTable(int cateID, int newsID, int top)
        {
            DbHelper db = new DbHelper(Config.NewsConnectionStrings);
            return db.GetDataTableSP("sp_NewsWeb_SelectList",
                new SqlParameter("@NewsID", newsID),
                new SqlParameter("@CateID", cateID),
                new SqlParameter("@Top", top)
                );
        }

        public List<NewsWeb> GetList(int cateID, int newsID, int top)
        {
            DbHelper db = new DbHelper(Config.NewsConnectionStrings);
            return db.GetListSP<NewsWeb>("sp_NewsWeb_SelectList",
                new SqlParameter("@NewsID", newsID),
                new SqlParameter("@CateID", cateID),
                new SqlParameter("@Top", top)
                );
        }

        public List<NewsWeb> GetListOriginalCate(int cateID, int top)
        {
            DbHelper db = new DbHelper(Config.NewsConnectionStrings);
            return db.GetListSP<NewsWeb>("sp_NewsWeb_SelectListOriginalCate",
                new SqlParameter("@CateID", cateID),
                new SqlParameter("@Top", top)
                );
        }

        public DataTable GetTableOriginalCate(int cateID, int top)
        {
            DbHelper db = new DbHelper(Config.NewsConnectionStrings);
            return db.GetDataTableSP("sp_NewsWeb_SelectListOriginalCate",
                new SqlParameter("@CateID", cateID),
                new SqlParameter("@Top", top)
                );
        }

        public List<NewsWeb> GetLastList(int top)
        {
            DbHelper db = new DbHelper(Config.NewsConnectionStrings);
            return db.GetListSP<NewsWeb>("sp_NewsWeb_SelectLastList"
                , new SqlParameter("@Top", top)
                );
        }

        public List<NewsWeb> GetTopView(DateTime time, int top)
        {
            DbHelper db = new DbHelper(Config.NewsConnectionStrings);
            return db.GetListSP<NewsWeb>("sp_NewsWeb_SelectTopView",
                new SqlParameter("@PublishedTime", time),
                new SqlParameter("@Top", top)
                );
        }

    }
}
