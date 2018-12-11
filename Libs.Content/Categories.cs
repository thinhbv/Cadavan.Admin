using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Libs.Db;

namespace Libs.Content
{
    public class Categories
    {
        public int CateID { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Alias { get; set; }
        public int FatherID { get; set; }
        public int Order { get; set; }
        public string ShortOrder { get; set; }
        public bool Status { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public int ReturnValue { get; set; }

        public Categories()
        {

        }

        ~Categories()
        {

        }

        public virtual void Dispose()
        {

        }

        public Categories Get(int cateID)
        {
            DbHelper db = new DbHelper(Config.ContentConnectionStrings);
            return db.GetInstanceSP<Categories>("sp_Categories_Select",
                new SqlParameter("@CateID", cateID));
        }

        public Categories Get()
        {
            DbHelper db = new DbHelper(Config.ContentConnectionStrings);
            return db.GetInstanceSP<Categories>("sp_Categories_Select",
                new SqlParameter("@CateID", CateID));
        }

        public void Add()
        {
            DbHelper db = new DbHelper(Config.ContentConnectionStrings);
            SqlParameter[] pars = new SqlParameter[8];
            pars[0] = new SqlParameter("@ReturnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            pars[1] = new SqlParameter("@Name", Name);
            pars[2] = new SqlParameter("@Url", Url);
            pars[3] = new SqlParameter("@Alias", Alias);
            pars[4] = new SqlParameter("@FatherID", FatherID);
            pars[5] = new SqlParameter("@Order", Order);
            pars[6] = new SqlParameter("@Status", Status);
            pars[7] = new SqlParameter("@Description", Description);

            db.ExecuteNonQuerySP("sp_Categories_Insert", pars);
            ReturnValue = Convert.ToInt32(pars[0].Value);
        }

        public void Update()
        {
            DbHelper db = new DbHelper(Config.ContentConnectionStrings);
            SqlParameter[] pars = new SqlParameter[9];
            pars[0] = new SqlParameter("@ReturnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            pars[1] = new SqlParameter("@CateID", CateID);
            pars[2] = new SqlParameter("@Name", Name);
            pars[3] = new SqlParameter("@Url", Url);
            pars[4] = new SqlParameter("@Alias", Alias);
            pars[5] = new SqlParameter("@FatherID", FatherID);
            pars[6] = new SqlParameter("@Order", Order);
            pars[7] = new SqlParameter("@Status", Status);
            pars[8] = new SqlParameter("@Description", Description);

            db.ExecuteNonQuerySP("sp_Categories_Update", pars);
            ReturnValue = Convert.ToInt32(pars[0].Value);
        }

        public void Delete(int cateID)
        {
            DbHelper db = new DbHelper(Config.ContentConnectionStrings);
            SqlParameter[] pars = new SqlParameter[2];
            pars[0] = new SqlParameter("@ReturnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            pars[1] = new SqlParameter("@CateID", cateID);

            db.ExecuteNonQuerySP("sp_Categories_Delete", pars);
            ReturnValue = Convert.ToInt32(pars[0].Value);
        }

        public void Delete()
        {
            DbHelper db = new DbHelper(Config.ContentConnectionStrings);
            SqlParameter[] pars = new SqlParameter[2];
            pars[0] = new SqlParameter("@ReturnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            pars[1] = new SqlParameter("@CateID", CateID);

            db.ExecuteNonQuerySP("sp_Categories_Delete", pars);
            ReturnValue = Convert.ToInt32(pars[0].Value);
        }

        public List<Categories> GetList()
        {
            DbHelper db = new DbHelper(Config.ContentConnectionStrings);
            return db.GetListSP<Categories>("sp_Categories_SelectList");
        }

        public DataTable GetTList()
        {
            DbHelper db = new DbHelper(Config.ContentConnectionStrings);
            return db.GetDataTableSP("sp_Categories_SelectList");
        }
    }
}
