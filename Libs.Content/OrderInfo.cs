using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Libs.Db;

namespace Libs.Content
{
	public class OrdersInfo
	{
		public int NewsID { get; set; }
		public string Title { get; set; }
		public string SubTitle { get; set; }
		public string Url { get; set; }
		public string ImageUrl { get; set; }
		public string Lead { get; set; }
		public string SubLead { get; set; }
		public string Content { get; set; }
		public int CateID { get; set; }
		public int UserID { get; set; }
		public int Status { get; set; }
		public string Tags { get; set; }
		public int Hits { get; set; }
		public DateTime PublishTime { get; set; }
		public DateTime Created { get; set; }
		public int ReturnValue { get; set; }

		public OrdersInfo()
		{

		}

		~OrdersInfo()
		{

		}

		public virtual void Dispose()
		{

		}

		public News Get(int newsID)
		{
			DbHelper db = new DbHelper(Config.ContentConnectionStrings);
			return db.GetInstanceSP<News>("sp_News_Select",
				new SqlParameter("@NewsID", newsID));
		}

		public News Get()
		{
			DbHelper db = new DbHelper(Config.ContentConnectionStrings);
			return db.GetInstanceSP<News>("sp_News_Select",
				new SqlParameter("@NewsID", NewsID));
		}

		public void Add()
		{
			DbHelper db = new DbHelper(Config.ContentConnectionStrings);
			SqlParameter[] pars = new SqlParameter[11];
			pars[0] = new SqlParameter("@ReturnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
			pars[1] = new SqlParameter("@Title", Title);
			pars[2] = new SqlParameter("@SubTitle", SubTitle);
			pars[3] = new SqlParameter("@Url", Url);
			pars[4] = new SqlParameter("@ImageUrl", ImageUrl);
			pars[5] = new SqlParameter("@Lead", Lead);
			pars[6] = new SqlParameter("@SubLead", SubLead);
			pars[7] = new SqlParameter("@Content", Content);
			pars[8] = new SqlParameter("@CateID", CateID);
			pars[9] = new SqlParameter("@UserID", UserID);
			pars[10] = new SqlParameter("@Tags", Tags);

			db.ExecuteNonQuerySP("sp_News_Insert", pars);
			ReturnValue = Convert.ToInt32(pars[0].Value);
		}

		public void QuickAdd(string title, string lead, int userID)
		{
			DbHelper db = new DbHelper(Config.ContentConnectionStrings);
			SqlParameter[] pars = new SqlParameter[5];
			pars[0] = new SqlParameter("@ReturnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
			pars[1] = new SqlParameter("@Title", title);
			pars[2] = new SqlParameter("@Url", UCS2Lower(title));
			pars[3] = new SqlParameter("@Lead", lead);
			pars[4] = new SqlParameter("@UserID", userID);

			db.ExecuteNonQuerySP("sp_News_QuickInsert", pars);
			ReturnValue = Convert.ToInt32(pars[0].Value);
		}

		public void Update()
		{
			DbHelper db = new DbHelper(Config.ContentConnectionStrings);
			SqlParameter[] pars = new SqlParameter[14];
			pars[0] = new SqlParameter("@ReturnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
			pars[1] = new SqlParameter("@NewsID", NewsID);
			pars[2] = new SqlParameter("@Title", Title);
			pars[3] = new SqlParameter("@SubTitle", SubTitle);
			pars[4] = new SqlParameter("@Url", Url);
			pars[5] = new SqlParameter("@ImageUrl", ImageUrl);
			pars[6] = new SqlParameter("@Lead", Lead);
			pars[7] = new SqlParameter("@SubLead", SubLead);
			pars[8] = new SqlParameter("@Content", Content);
			pars[9] = new SqlParameter("@CateID", CateID);
			pars[10] = new SqlParameter("@UserID", UserID);
			pars[11] = new SqlParameter("@Status", Status);
			pars[12] = new SqlParameter("@Tags", Tags);
			pars[13] = new SqlParameter("@PublishTime", PublishTime);

			db.ExecuteNonQuerySP("sp_Categories_Update", pars);
			ReturnValue = Convert.ToInt32(pars[0].Value);
		}

		public void Delete(int newsID)
		{
			DbHelper db = new DbHelper(Config.ContentConnectionStrings);
			SqlParameter[] pars = new SqlParameter[2];
			pars[0] = new SqlParameter("@ReturnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
			pars[1] = new SqlParameter("@NewsID", newsID);

			db.ExecuteNonQuerySP("sp_News_Delete", pars);
			ReturnValue = Convert.ToInt32(pars[0].Value);
		}

		public void Delete()
		{
			DbHelper db = new DbHelper(Config.ContentConnectionStrings);
			SqlParameter[] pars = new SqlParameter[2];
			pars[0] = new SqlParameter("@ReturnValue", SqlDbType.Int) { Direction = ParameterDirection.Output };
			pars[1] = new SqlParameter("@NewsID", NewsID);

			db.ExecuteNonQuerySP("sp_News_Delete", pars);
			ReturnValue = Convert.ToInt32(pars[0].Value);
		}


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
