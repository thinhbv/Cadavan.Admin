using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Libs.Db;

namespace Libs.Content
{
    public class NewsCategories
    {
        public int CateID { get; set; }
        public int FatherID { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public int Level { get; set; }
        public string Note { get; set; }
        public int Order { get; set; }
        public string TotalOrder { get; set; }
        public bool IsDisplay { get; set; }
        public string Url { get; set; }
        public int ReturnValue { get; set; }

        public NewsCategories()
        {

        }

        ~NewsCategories()
        {

        }

        public virtual void Dispose()
        {

        }

        /// <summary>
        /// Lấy giá trị của chuyên mục theo ID
        /// </summary>
        /// <param name="cateID"></param>
        /// <returns></returns>
        public NewsCategories Get(int cateID)
        {
            DbHelper db = new DbHelper(Config.NewsConnectionStrings);
            return db.GetInstanceSP<NewsCategories>("sp_NewsCategories_Select", new SqlParameter("@CateID", cateID));
        }

        /// <summary>
        /// Lấy giá trị của chuyên mục theo ID
        /// </summary>
        /// <returns></returns>
        public NewsCategories Get()
        {
            DbHelper db = new DbHelper(Config.NewsConnectionStrings);
            return db.GetInstanceSP<NewsCategories>("sp_NewsCategories_Select", new SqlParameter("@CateID", CateID));
        }

        /// <summary>
        /// Lấy danh sách danh mục
        /// </summary>
        /// <returns></returns>
        public List<NewsCategories> GetList()
        {
            DbHelper db = new DbHelper(Config.NewsConnectionStrings);
            return db.GetListSP<NewsCategories>("sp_NewsCategories_Selectall");
        }

        public List<NewsCategories> GetList(int fatherID)
        {
            DbHelper db = new DbHelper(Config.NewsConnectionStrings);
            return db.GetListSP<NewsCategories>("sp_NewsCategories_SelectList"
                , new SqlParameter("@FatherID", fatherID),
                new SqlParameter("@IsDisplay", DBNull.Value));
        }

        public List<NewsCategories> GetListDrp()
        {
            DbHelper db = new DbHelper(Config.NewsConnectionStrings);
            return db.GetListSP<NewsCategories>("sp_NewsCategories_SelectList"
                , new SqlParameter("@FatherID", DBNull.Value),
                new SqlParameter("@IsDisplay", true));
        }

        /// <summary>
        /// Thêm mới chuyên mục
        /// </summary>
        public void Add()
        {
            DbHelper db = new DbHelper(Config.NewsConnectionStrings);
            SqlParameter[] pars = new SqlParameter[8];
            pars[0] = new SqlParameter("@ReturnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            pars[1] = new SqlParameter("@FatherID", FatherID);
            pars[2] = new SqlParameter("@Name", Name);
            pars[3] = new SqlParameter("@Alias", Alias);
            pars[4] = new SqlParameter("@Note", Note);
            pars[5] = new SqlParameter("@Order", Order);
            pars[6] = new SqlParameter("@IsDisplay", IsDisplay);
            pars[7] = new SqlParameter("@Url", Url);

            db.ExecuteNonQuerySP("sp_NewsCategories_Insert", pars);
            CateID = Convert.ToInt32(pars[0].Value);
        }

        /// <summary>
        /// Cập nhật chuyên mục
        /// </summary>
        public void Update()
        {
            DbHelper db = new DbHelper(Config.NewsConnectionStrings);
            SqlParameter[] pars = new SqlParameter[9];
            pars[0] = new SqlParameter("@ReturnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            pars[1] = new SqlParameter("@CateID", CateID);
            pars[2] = new SqlParameter("@FatherID", FatherID);
            pars[3] = new SqlParameter("@Name", Name);
            pars[4] = new SqlParameter("@Alias", Alias);
            pars[5] = new SqlParameter("@Note", Note);
            pars[6] = new SqlParameter("@Order", Order);
            pars[7] = new SqlParameter("@IsDisplay", IsDisplay);
            pars[8] = new SqlParameter("@Url", Url);

            db.ExecuteNonQuerySP("sp_NewsCategories_Update", pars);
            ReturnValue = Convert.ToInt32(pars[0].Value);
        }

        /// <summary>
        /// Xoá chuyên mục
        /// </summary>
        /// <param name="cateID"></param>
        public void Delete(int cateID)
        {
            DbHelper db = new DbHelper(Config.NewsConnectionStrings);
            SqlParameter[] pars = new SqlParameter[2];
            pars[0] = new SqlParameter("@ReturnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            pars[1] = new SqlParameter("@CateID", cateID);

            db.ExecuteNonQuerySP("sp_NewsCategories_Delete", pars);
            ReturnValue = Convert.ToInt32(pars[0].Value);
        }

        /// <summary>
        /// Xoá chuyên mục
        /// </summary>
        public void Delete()
        {
            DbHelper db = new DbHelper(Config.NewsConnectionStrings);
            SqlParameter[] pars = new SqlParameter[2];
            pars[0] = new SqlParameter("@ReturnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            pars[1] = new SqlParameter("@CateID", CateID);

            db.ExecuteNonQuerySP("sp_NewsCategories_Delete", pars);
            ReturnValue = Convert.ToInt32(pars[0].Value);
        }

        /// <summary>
        /// Chuyển thứ tự xuống dưới một vị trí
        /// </summary>
        /// <param name="cateID"></param>
        public void OrderDown(int cateID)
        {
            DbHelper db = new DbHelper(Config.NewsConnectionStrings);
            db.ExecuteNonQuerySP("sp_NewsCategories_OrderDown", new SqlParameter("@CateID", cateID));
        }

        /// <summary>
        /// Chuyển thứ tự lên trên một vị trí
        /// </summary>
        /// <param name="cateID"></param>
        public void OrderUp(int cateID)
        {
            DbHelper db = new DbHelper(Config.NewsConnectionStrings);
            db.ExecuteNonQuerySP("sp_NewsCategories_OrderUp", new SqlParameter("@CateID", cateID));
        }

        /// <summary>
        /// Lấy giá trị chuyên mục theo Url
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public NewsCategories GetByUrl(string url)
        {
            DbHelper db = new DbHelper(Config.NewsConnectionStrings);
            return db.GetInstanceSP<NewsCategories>("sp_NewsCategories_SelectByUrl", new SqlParameter("@Url", url));
        }
    }
}
