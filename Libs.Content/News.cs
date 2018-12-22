using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Libs.Db;

namespace Libs.Content
{
    public class News
    {
        public int NewsID { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string TitleEn { get; set; }
        public string SubTitle { get; set; }
        public string Lead { get; set; }
        public string SubLead { get; set; }
        public string Content { get; set; }
        public int CateID { get; set; }
        public int UserID { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime PublishedTime { get; set; }
        public int Status { get; set; }
        public bool IsTop { get; set; }
        public int Royalty { get; set; }
        public string Tags { get; set; }
        public int Hits { get; set; }
        public bool IsPhoto { get; set; }
        public bool IsVideo { get; set; }
        public bool IsAudio { get; set; }
        public int ReturnValue { get; set; }

        public News()
        {

        }

        ~News()
        {

        }

        public virtual void Dispose()
        {

        }

        /// <summary>
        /// Lấy thông tin của tin bài theo ID
        /// </summary>
        /// <returns></returns>
        public News Get()
        {
            DbHelper db = new DbHelper(Config.NewsConnectionStrings);
            return db.GetInstanceSP<News>("sp_News_Select"
                , new SqlParameter("@NewsID", NewsID));
        }

        /// <summary>
        /// Lấy thông tin của tin bài theo ID
        /// </summary>
        /// <param name="newsID"></param>
        /// <returns></returns>
        public News Get(int newsID)
        {
            DbHelper db = new DbHelper(Config.NewsConnectionStrings);
            return db.GetInstanceSP<News>("sp_News_Select"
                , new SqlParameter("@NewsID", newsID));
        }

        public List<News> GetList()
        {
            DbHelper db = new DbHelper(Config.NewsConnectionStrings);
            return db.GetListSP<News>("sp_News_SelectList");
        }


        /// <summary>
        /// Xoá tin bài theo ID
        /// </summary>
        public void Delete()
        {
            DbHelper db = new DbHelper(Config.NewsConnectionStrings);
            db.ExecuteNonQuerySP("sp_News_Delete"
                , new SqlParameter("@NewsID", NewsID)
                , new SqlParameter("@UserID", UserID));
        }

        /// <summary>
        /// Xoá tin bài theo ID
        /// </summary>
        /// <param name="newsID"></param>
        public void Delete(int newsID, int userID)
        {
            DbHelper db = new DbHelper(Config.NewsConnectionStrings);
            db.ExecuteNonQuerySP("sp_News_Delete"
                , new SqlParameter("@NewsID", newsID)
                , new SqlParameter("@UserID", userID));
        }

        /// <summary>
        /// Thêm mới tin bài
        /// </summary>
        public void Add()
        {
            DbHelper db = new DbHelper(Config.NewsConnectionStrings);
            SqlParameter[] pars = new SqlParameter[17];
            pars[0] = new SqlParameter("@ReturnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            pars[1] = new SqlParameter("@ImageUrl", ImageUrl);
            pars[2] = new SqlParameter("@Title", Title);
            pars[3] = new SqlParameter("@TitleEn", UCS2Lower(Title));
            pars[4] = new SqlParameter("@SubTitle", SubTitle);
            pars[5] = new SqlParameter("@Lead", Lead);
            pars[6] = new SqlParameter("@SubLead", SubLead);
            pars[7] = new SqlParameter("@Content", Content);
            pars[8] = new SqlParameter("@CateID", CateID);
            pars[9] = new SqlParameter("@UserID", UserID);
            pars[10] = new SqlParameter("@PublishedTime", PublishedTime);
            pars[11] = new SqlParameter("@Status", Status);
            pars[12] = new SqlParameter("@IsTop", IsTop);
            pars[13] = new SqlParameter("@Tags", Tags);
            pars[14] = new SqlParameter("@IsPhoto", IsPhoto);
            pars[15] = new SqlParameter("@IsVideo", IsVideo);
            pars[16] = new SqlParameter("@IsAudio", IsAudio);

            db.ExecuteNonQuerySP("sp_News_Insert", pars);
            
            NewsID = Convert.ToInt32(pars[0].Value);

        }

        /// <summary>
        /// Cập nhật tin bài
        /// </summary>
        public void Update()
        {
            DbHelper db = new DbHelper(Config.NewsConnectionStrings);
            SqlParameter[] pars = new SqlParameter[20];
            pars[0] = new SqlParameter("@ReturnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
            pars[1] = new SqlParameter("@NewsID", NewsID);
            pars[2] = new SqlParameter("@ImageUrl", ImageUrl);
            pars[3] = new SqlParameter("@Title", Title);
            pars[4] = new SqlParameter("@TitleEn", UCS2Lower(Title));
            pars[5] = new SqlParameter("@SubTitle", SubTitle);
            pars[6] = new SqlParameter("@Lead", Lead);
            pars[7] = new SqlParameter("@SubLead", SubLead);
            pars[8] = new SqlParameter("@Content", Content);
            pars[9] = new SqlParameter("@CateID", CateID);
            pars[10] = new SqlParameter("@UserID", UserID);
            pars[11] = new SqlParameter("@PublishedTime", PublishedTime);
            pars[12] = new SqlParameter("@Status", Status);
            pars[13] = new SqlParameter("@IsTop", IsTop);
            pars[14] = new SqlParameter("@Royalty", Royalty);
            pars[15] = new SqlParameter("@Tags", Tags);
            pars[16] = new SqlParameter("@Hits", Hits);
            pars[17] = new SqlParameter("@IsPhoto", IsPhoto);
            pars[18] = new SqlParameter("@IsVideo", IsVideo);
            pars[19] = new SqlParameter("@IsAudio", IsAudio);

            db.ExecuteNonQuerySP("sp_News_Update", pars);
            ReturnValue = Convert.ToInt32(pars[0].Value);
        }

        /// <summary>
        /// Tăng Hits
        /// </summary>
        public void AddHits()
        {
            DbHelper db = new DbHelper(Config.NewsConnectionStrings);
            db.ExecuteNonQuerySP("sp_News_AddHits", new SqlParameter("@NewsID", NewsID));
        }

        /// <summary>
        /// Tăng Hits
        /// </summary>
        public void AddHits(int newsID)
        {
            DbHelper db = new DbHelper(Config.NewsConnectionStrings);
            db.ExecuteNonQuerySP("sp_News_AddHits", new SqlParameter("@NewsID", newsID));
        }

        /// <summary>
        /// Chuyển chữ tiếng Việt sang không dấu
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static String UCS2Lower(String s)
        {
            string[] aUTF8Lower = { "a", "á", "à", "ả", "ã", "ạ", "ă", "ắ", "ằ", "ẳ", "ẵ", "ặ", "â", "ấ", "ầ", "ẩ", "ẫ", "ậ", "đ", "e", "é", "è", "ẻ", "ẽ", "ẹ", "ê", "ế", "ề", "ể", "ễ", "ệ", "i", "í", "ì", "ỉ", "ĩ", "ị", "o", "ó", "ò", "ỏ", "õ", "ọ", "ô", "ố", "ồ", "ổ", "ỗ", "ộ", "ơ", "ớ", "ờ", "ở", "ỡ", "ợ", "u", "ú", "ù", "ủ", "ũ", "ụ", "ư", "ứ", "ừ", "ử", "ữ", "ự", "y", "ý", "ỳ", "ỷ", "ỹ", "ỵ" };
            String[] aUCS2Lower = { "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "d", "e", "e", "e", "e", "e", "e", "e", "e", "e", "e", "e", "e", "i", "i", "i", "i", "i", "i", "o", "o", "o", "o", "o", "o", "o", "o", "o", "o", "o", "o", "o", "o", "o", "o", "o", "o", "u", "u", "u", "u", "u", "u", "u", "u", "u", "u", "u", "u", "y", "y", "y", "y", "y", "y" };

            // Chuyển sang chữ không dấu
            s = s.Trim().ToLower().Replace(" ", "-");
            int n = aUTF8Lower.Length;
            for (int i = 0; i < n; i++)
            {
                s = s.Replace(aUTF8Lower[i], aUCS2Lower[i]);
            }

            // Lọc các ký tự
            string Filter = "-0123456789abcdefghijklmnopqrstuvwxyz";
            string Temp = "";
            for (int i = 0; i < s.Length; i++)
            {
                if (Filter.IndexOf(s[i]) >= 0)
                {
                    Temp = Temp + s[i];
                }
            }
            while (Temp.IndexOf("--") >= 0)
            {
                Temp = Temp.Replace("--", "-");
            }

            return Temp;
        }
    }
}
