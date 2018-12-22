using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Libs.Db;

namespace Libs.Content
{
    public class MediaFile
    {
        public int FileID { get; set; }
        public string Name { get; set; }
        public string Ext { get; set; }
        public int Size { get; set; }
        public DateTime UploadTime { get; set; }
        public string Path { get; set; }
        public int UserID { get; set; }
        public string Description { get; set; }
        public string Tags { get; set; }
        public byte[] Data { get; set; }
        public string FileType { get; set; }
        public int ReturnValue { get; set; }

        public MediaFile()
        {

        }

        ~MediaFile()
        {

        }

        public virtual void Dispose()
        {

        }

        public MediaFile Get()
        {
            DbHelper db = new DbHelper(Config.NewsConnectionStrings);
            return db.GetInstanceSP<MediaFile>("sp_MediaFile_Select"
                , new SqlParameter("@FileID", FileID));
        }

        public MediaFile Get(int fileID)
        {
            DbHelper db = new DbHelper(Config.NewsConnectionStrings);
            return db.GetInstanceSP<MediaFile>("sp_MediaFile_Select"
                , new SqlParameter("@FileID", fileID));
        }

        public void Delete()
        {
            DbHelper db = new DbHelper(Config.NewsConnectionStrings);
            db.ExecuteNonQuerySP("sp_MediaFile_Delete"
                , new SqlParameter("@FileID", FileID));
        }

        public void Delete(int fileID)
        {
            DbHelper db = new DbHelper(Config.NewsConnectionStrings);
            db.ExecuteNonQuerySP("sp_MediaFile_Delete"
                , new SqlParameter("@FileID", fileID));
        }

        public void Add()
        {
            DbHelper db = new DbHelper(Config.NewsConnectionStrings);
            SqlParameter[] pars = new SqlParameter[8];
            pars[0] = new SqlParameter("@ReturnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            pars[1] = new SqlParameter("@Name", Name);
            pars[2] = new SqlParameter("@Ext", Ext);
            pars[3] = new SqlParameter("@Size", Size);
            pars[4] = new SqlParameter("@Path", Path);
            pars[5] = new SqlParameter("@UserID", UserID);
            pars[6] = new SqlParameter("@Description", Description);
            pars[7] = new SqlParameter("@Tags", Tags);

            db.ExecuteNonQuerySP("sp_MediaFile_Insert", pars);
            FileID = Convert.ToInt32(pars[0].Value);
        }

        public void Update()
        {
            DbHelper db = new DbHelper(Config.NewsConnectionStrings);
            SqlParameter[] pars = new SqlParameter[9];
            pars[0] = new SqlParameter("@ReturnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            pars[1] = new SqlParameter("@FileID", FileID);
            pars[2] = new SqlParameter("@Name", Name);
            pars[3] = new SqlParameter("@Ext", Ext);
            pars[4] = new SqlParameter("@Size", Size);
            pars[5] = new SqlParameter("@Path", Path);
            pars[6] = new SqlParameter("@UserID", UserID);
            pars[7] = new SqlParameter("@Description", Description);
            pars[8] = new SqlParameter("@Tags", Tags);

            db.ExecuteNonQuerySP("sp_MediaFile_Update", pars);
            ReturnValue = Convert.ToInt32(pars[0].Value);
        }

        public void UpdateData()
        {
            DbHelper db = new DbHelper(Config.NewsConnectionStrings);
            SqlParameter[] pars = new SqlParameter[4];
            pars[0] = new SqlParameter("@ReturnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            pars[1] = new SqlParameter("@FileID", FileID);
            pars[2] = new SqlParameter("@Data", Data);
            pars[3] = new SqlParameter("@FileType", FileType);

            db.ExecuteNonQuerySP("sp_MediaFile_UpdateData", pars);
            ReturnValue = Convert.ToInt32(pars[0].Value);
        }

        public List<MediaFile> GetList()
        {
            DbHelper db = new DbHelper(Config.NewsConnectionStrings);
            return db.GetListSP<MediaFile>("sp_MediaFile_SelectList", new SqlParameter("@Ext", DBNull.Value));
        }

        public List<MediaFile> GetList(string ext)
        {
            DbHelper db = new DbHelper(Config.NewsConnectionStrings);
            return db.GetListSP<MediaFile>("sp_MediaFile_SelectList", new SqlParameter("@Ext", ext));
        }

        public DataTable Search(string ext, int userID, string keyword, int pageIndex, int pageSize, ref int totalRecord)
        {
            DbHelper db = new DbHelper(Config.NewsConnectionStrings);
            SqlParameter[] pars = new SqlParameter[6];
            pars[0] = string.IsNullOrEmpty(ext) ? new SqlParameter("@Ext", DBNull.Value) : new SqlParameter("@Ext", ext);
            pars[1] = userID == 0 ? new SqlParameter("@UserID", DBNull.Value) : new SqlParameter("@UserID", userID);
            pars[2] = string.IsNullOrEmpty(keyword) ? new SqlParameter("@Keyword", DBNull.Value) : new SqlParameter("@Keyword", keyword);
            pars[3] = new SqlParameter("@PageIndex", pageIndex);
            pars[4] = new SqlParameter("@PageSize", pageSize);
            pars[5] = new SqlParameter("@TotalRecord", totalRecord) { Direction = ParameterDirection.Output };
            DataTable dt = db.GetDataTableSP("sp_MediaFile_Search", pars);
            totalRecord = Convert.ToInt32(pars[5].Value);
            return dt;
        }

        public DataTable PhotoSearch(string ext, int userID, string keyword, int pageIndex, int pageSize, ref int totalRecord)
        {
            DbHelper db = new DbHelper(Config.NewsConnectionStrings);
            SqlParameter[] pars = new SqlParameter[6];
            pars[0] = string.IsNullOrEmpty(ext) ? new SqlParameter("@Ext", DBNull.Value) : new SqlParameter("@Ext", ext);
            pars[1] = userID == 0 ? new SqlParameter("@UserID", DBNull.Value) : new SqlParameter("@UserID", userID);
            pars[2] = string.IsNullOrEmpty(keyword) ? new SqlParameter("@Keyword", DBNull.Value) : new SqlParameter("@Keyword", keyword);
            pars[3] = new SqlParameter("@PageIndex", pageIndex);
            pars[4] = new SqlParameter("@PageSize", pageSize);
            pars[5] = new SqlParameter("@TotalRecord", totalRecord) { Direction = ParameterDirection.Output };
            DataTable dt = db.GetDataTableSP("sp_Photo_Search", pars);
            totalRecord = Convert.ToInt32(pars[5].Value);
            return dt;
        }

        public static bool CheckType(string ext, string fileType)
        {
            string extList = "|doc|docx|rar|zip|jpg|xls|xlsx|";
            string typeList = "|application/msword|application/vnd.openxmlformats-officedocument.wordprocessingml.document|application/octet-stream|image/jpeg|application/vnd.ms-excel|application/vnd.openxmlformats-officedocument.spreadsheetml.sheet|";

            if (extList.IndexOf(ext) >= 0) return false;
            if (typeList.IndexOf(fileType) >= 0) return false;
            return true;
        }
    }
}
