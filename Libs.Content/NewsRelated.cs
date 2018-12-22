using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Libs.Db;

namespace Libs.Content
{
    public class NewsRelated
    {
        public int NewsRelateID { get; set; }
        public int NewsID { get; set; }
        public int RelateID { get; set; }
        public DateTime CreatedTime { get; set; }
        public int ReturnValue { get; set; }

        public NewsRelated()
        {

        }

        ~NewsRelated()
        {

        }

        public virtual void Dispose()
        {

        }

        public NewsRelated Get()
        {
            DbHelper db = new DbHelper(Config.NewsConnectionStrings);
            return db.GetInstanceSP<NewsRelated>("sp_NewsRelated_Select"
                , new SqlParameter("@NewsRelateID", NewsRelateID));
        }

        public NewsRelated Get(int newsRelateID)
        {
            DbHelper db = new DbHelper(Config.NewsConnectionStrings);
            return db.GetInstanceSP<NewsRelated>("sp_NewsRelated_Select"
                , new SqlParameter("@NewsRelateID", newsRelateID));
        }

        public DataTable GetList(int newsID)
        {
            DbHelper db = new DbHelper(Config.NewsConnectionStrings);
            return db.GetDataTableSP("sp_NewsRelated_SelectList"
                , new SqlParameter("@NewsID", newsID));
        }

        public void Delete(int newsID, int relateID)
        {
            DbHelper db = new DbHelper(Config.NewsConnectionStrings);
            db.ExecuteNonQuerySP("sp_NewsRelated_Delete"
                , new SqlParameter("@NewsID", newsID)
                , new SqlParameter("@RelateID", relateID)
                );
        }

        public void Add()
        {
            DbHelper db = new DbHelper(Config.NewsConnectionStrings);
            SqlParameter[] pars = new SqlParameter[3];
            pars[0] = new SqlParameter("@ReturnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            pars[1] = new SqlParameter("@NewsID", NewsID);
            pars[2] = new SqlParameter("@RelateID", RelateID);

            db.ExecuteNonQuerySP("sp_NewsRelated_Insert", pars);
            NewsRelateID = Convert.ToInt32(pars[0].Value);
        }

    }
}
