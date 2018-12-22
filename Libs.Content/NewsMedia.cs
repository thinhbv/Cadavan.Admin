using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Libs.Db;

namespace Libs.Content
{
    public class NewsMedia
    {
        public int NewsMediaID { get; set; }
        public int NewsID { get; set; }
        public int FileID { get; set; }
        public int Order { get; set; }
        public int ReturnValue { get; set; }

        public NewsMedia()
        {

        }

        ~NewsMedia()
        {

        }

        public virtual void Dispose()
        {

        }

        public NewsMedia Get()
        {
            DbHelper db = new DbHelper(Config.NewsConnectionStrings);
            return db.GetInstanceSP<NewsMedia>("sp_NewsMedia_Select"
                , new SqlParameter("@NewsMediaID", NewsMediaID));
        }

        public NewsMedia Get(int fileID)
        {
            DbHelper db = new DbHelper(Config.NewsConnectionStrings);
            return db.GetInstanceSP<NewsMedia>("sp_NewsMedia_Select"
                , new SqlParameter("@NewsMediaID", NewsMediaID));
        }

        public void Delete()
        {
            DbHelper db = new DbHelper(Config.NewsConnectionStrings);
            db.ExecuteNonQuerySP("sp_NewsMedia_Delete"
                , new SqlParameter("@NewsMediaID", NewsMediaID));
        }

        public void Delete(int newsMediaID)
        {
            DbHelper db = new DbHelper(Config.NewsConnectionStrings);
            db.ExecuteNonQuerySP("sp_NewsMedia_Delete"
                , new SqlParameter("@NewsMediaID", newsMediaID));
        }

        public void Add()
        {
            DbHelper db = new DbHelper(Config.NewsConnectionStrings);
            SqlParameter[] pars = new SqlParameter[4];
            pars[0] = new SqlParameter("@ReturnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            pars[1] = new SqlParameter("@NewsID", NewsID);
            pars[2] = new SqlParameter("@FileID", FileID);
            pars[3] = new SqlParameter("@Order", Order);

            db.ExecuteNonQuerySP("sp_NewsMedia_Insert", pars);
            NewsMediaID = Convert.ToInt32(pars[0].Value);
        }

        public void Update()
        {
            DbHelper db = new DbHelper(Config.NewsConnectionStrings);
            SqlParameter[] pars = new SqlParameter[5];
            pars[0] = new SqlParameter("@ReturnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            pars[1] = new SqlParameter("@NewsMediaID", NewsMediaID);
            pars[2] = new SqlParameter("@NewsID", NewsID);
            pars[3] = new SqlParameter("@FileID", FileID);
            pars[4] = new SqlParameter("@Order", Order);

            db.ExecuteNonQuerySP("sp_NewsMedia_Update", pars);
            ReturnValue = Convert.ToInt32(pars[0].Value);
        }

        public DataTable GetList(int newsID)
        {
            DbHelper db = new DbHelper(Config.NewsConnectionStrings);
            return db.GetDataTableSP("sp_NewsMedia_SelectList", new SqlParameter("@NewsID", newsID));
        }
    }
}
