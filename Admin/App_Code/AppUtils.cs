using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.IO;
using Libs.Utils;
using Libs.Security;
using System.Web.Routing;
using System.Globalization;

/// <summary>
/// Summary description for AppUtils
/// </summary>
public class AppUtils
{
    public AppUtils()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static void CheckLogin()
    {
        if (HttpContext.Current.Session["Email"] == null)
        {
            HttpContext.Current.Response.Redirect(Constant.ADMIN_PATH + Resources.Url.SignOut + "?u=" + HttpUtility.UrlEncode(HttpContext.Current.Request.Url.ToString()));
        }

        if (!new Users().CheckUrl(UserID(), HttpContext.Current.Request.Url.LocalPath.ToLower().Replace(Constant.ADMIN_PATH.ToLower(), ""))) HttpContext.Current.Response.Redirect(Constant.ADMIN_PATH + Resources.Url.SignOut);
    }

    public static int Request(string name)
    {
        try
        {
            return Convert.ToInt32(HttpContext.Current.Request[name]);
        }
        catch
        {
            return 0;
        }
    }

    public static int UserID()
    {
        return Convert.ToInt32(HttpContext.Current.Session["UserID"]);
    }

    public static string LastestTime()
    {
        return HttpContext.Current.Session["LastestTime"].ToString();
    }

    public static string Email()
    {
        return HttpContext.Current.Session["Email"].ToString();
    }

    public static string FullName()
    {
		if (HttpContext.Current.Session["FullName"] == null)
		{
			return string.Empty;
		}
        return HttpContext.Current.Session["FullName"].ToString();
    }

    public static bool CheckPath()
    {
        string path = Constant.MEDIA_PATH + DateTime.Now.ToString("yyyy/MM/dd/");
        try
        {
            if (!Directory.Exists(HttpContext.Current.Server.MapPath(path))) Directory.CreateDirectory(HttpContext.Current.Server.MapPath(path));
            return true;
        }
        catch
        {
            return false;
        }
    }

    public static bool CheckPath(string path)
    {
        try
        {
            if (!Directory.Exists(HttpContext.Current.Server.MapPath(path))) Directory.CreateDirectory(HttpContext.Current.Server.MapPath(path));
            return true;
        }
        catch
        {
            return false;
        }
    }
    public static string UCS2Lower(string s)
    {
        string[] aUTF8Lower = { "a", "á", "à", "ả", "ã", "ạ", "ă", "ắ", "ằ", "ẳ", "ẵ", "ặ", "â", "ấ", "ầ", "ẩ", "ẫ", "ậ", "đ", "e", "é", "è", "ẻ", "ẽ", "ẹ", "ê", "ế", "ề", "ể", "ễ", "ệ", "i", "í", "ì", "ỉ", "ĩ", "ị", "o", "ó", "ò", "ỏ", "õ", "ọ", "ô", "ố", "ồ", "ổ", "ỗ", "ộ", "ơ", "ớ", "ờ", "ở", "ỡ", "ợ", "u", "ú", "ù", "ủ", "ũ", "ụ", "ư", "ứ", "ừ", "ử", "ữ", "ự", "y", "ý", "ỳ", "ỷ", "ỹ", "ỵ" };
        String[] aUCS2Lower = { "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "d", "e", "e", "e", "e", "e", "e", "e", "e", "e", "e", "e", "e", "i", "i", "i", "i", "i", "i", "o", "o", "o", "o", "o", "o", "o", "o", "o", "o", "o", "o", "o", "o", "o", "o", "o", "o", "u", "u", "u", "u", "u", "u", "u", "u", "u", "u", "u", "u", "y", "y", "y", "y", "y", "y" };

        // Chuyển sang chữ không dấu
        s = s.Trim().ToLower().Replace(" ", "_");
        int n = aUTF8Lower.Length;
        for (int i = 0; i < n; i++)
        {
            s = s.Replace(aUTF8Lower[i], aUCS2Lower[i]);
        }

        // Lọc các ký tự
        string Filter = "._0123456789abcdefghijklmnopqrstuvwxyz";
        string Temp = "";
        for (int i = 0; i < s.Length; i++)
        {
            if (Filter.IndexOf(s[i]) >= 0)
            {
                Temp = Temp + s[i];
            }
        }
        while (Temp.IndexOf("__") >= 0)
        {
            Temp = Temp.Replace("__", "_");
        }

        return Temp;
    }

    public static string MediaFileName(string fileName)
    {
        fileName = UCS2Lower(fileName);
        if (fileName.Length > 50) fileName = fileName.Remove(0, fileName.Length - 50);
        fileName = fileName.Replace("img", "i");
        return Encrypts.MD5(DateTime.Now.ToString("yyMMddHHmmss")).Substring(0, 9) + "_" + fileName;
    }

    public static string MediaPath(string fileName)
    {
        fileName = UCS2Lower(fileName);
        return Encrypts.MD5(DateTime.Now.ToString("yyMMddHHmmss")).Substring(0, 9) + "_" + fileName;
    }

    public static string ImageUrl(string url, string w, string h)
    {
        return Constant.MEDIA + url + "." + w + "." + h + ".image";
    }

    public static void Routes()
    {
        RouteTable.Routes.MapPageRoute("Gallery", "content.gallery.html", "~/pages/content/gallery.aspx");
        RouteTable.Routes.MapPageRoute("MediaFile.download", "content.mediaFile.download.html", "~/pages/content/mediaFile.download.aspx");
        RouteTable.Routes.MapPageRoute("MediaFile.List", "content.mediafile.list.html", "~/pages/content/mediaFile.list.aspx");
        RouteTable.Routes.MapPageRoute("News.Add", "content.news.add.html", "~/pages/content/news.add.aspx");
        RouteTable.Routes.MapPageRoute("News.Add.List", "content.news.add.List.html", "~/pages/content/news.add.list.aspx");
        RouteTable.Routes.MapPageRoute("News.Delete.List", "content.news.delete.list.html", "~/pages/content/news.delete.list.aspx");
        RouteTable.Routes.MapPageRoute("News.Edit", "content.news.edit.html", "~/pages/content/news.edit.aspx");
        RouteTable.Routes.MapPageRoute("News.List", "content.news.list.html", "~/pages/content/news.list.aspx");
        RouteTable.Routes.MapPageRoute("News.Log", "content.news.log.html", "~/pages/content/news.log.aspx");
        RouteTable.Routes.MapPageRoute("News.Media", "content.news.media.html", "~/pages/content/news.media.aspx");
        RouteTable.Routes.MapPageRoute("News.Pending.List", "content.news.pending.list.html", "~/pages/content/news.pending.list.aspx");
        RouteTable.Routes.MapPageRoute("News.Publish.List", "content.News.publish.list.html", "~/pages/content/news.publish.list.aspx");
        RouteTable.Routes.MapPageRoute("News.Royalty", "content.News.royalty.html", "~/pages/content/news.royalty.aspx");
        RouteTable.Routes.MapPageRoute("News.Search", "content.news.search.html", "~/pages/content/news.search.aspx");
        RouteTable.Routes.MapPageRoute("NewsCategories.Add", "content.newscategories.add.html", "~/pages/content/newscategories.add.aspx");
        RouteTable.Routes.MapPageRoute("NewsCategories.Edit", "content.newscategories.edit.html", "~/pages/content/newscategories.edit.aspx");
        RouteTable.Routes.MapPageRoute("NewsCategories.List", "content.newscategories.list.html", "~/pages/content/newscategories.list.aspx");
        RouteTable.Routes.MapPageRoute("NewsForum.Edit", "content.newsforum.edit.html", "~/pages/content/newsforum.edit.aspx");
        RouteTable.Routes.MapPageRoute("NewsForum.List", "content.newsforum.list.html", "~/pages/content/newsforum.list.aspx");
        RouteTable.Routes.MapPageRoute("VoteQuestion.Add", "content.voteQuestion.add.html", "~/pages/content/votequestion.add.aspx");
        RouteTable.Routes.MapPageRoute("VoteQuestion.Edit", "content.voteQuestion.edit.html", "~/pages/content/votequestion.edit.aspx");
        RouteTable.Routes.MapPageRoute("VoteQuestion.List", "content.voteQuestion.list.html", "~/pages/content/votequestion.list.aspx");
        RouteTable.Routes.MapPageRoute("Votes.Add", "content.votes.add.html", "~/pages/content/votes.add.aspx");
        RouteTable.Routes.MapPageRoute("Votes.Edit", "content.votes.edit.html", "~/pages/content/votes.edit.aspx");
        RouteTable.Routes.MapPageRoute("Votes.List", "content.votes.list.html", "~/pages/content/votes.list.aspx");

        RouteTable.Routes.MapPageRoute("ChangePassword", "security.changePassword.html", "~/pages/security/changepassword.aspx");
        RouteTable.Routes.MapPageRoute("Functions.Add", "security.functions.add.html", "~/pages/security/functions.add.aspx");
        RouteTable.Routes.MapPageRoute("functions.List", "security.functions.list.html", "~/pages/security/functions.list.aspx");
        RouteTable.Routes.MapPageRoute("functions.Edit", "security.functions.edit.html", "~/pages/security/functions.edit.aspx");
        RouteTable.Routes.MapPageRoute("Groups.Add", "security.groups.ddd.html", "~/pages/security/groups.add.aspx");
        RouteTable.Routes.MapPageRoute("Groups.Edit", "security.groups.edit.html", "~/pages/security/groups.edit.aspx");
        RouteTable.Routes.MapPageRoute("Groups.List", "security.groups.list.html", "~/pages/security/groups.list.aspx");
        RouteTable.Routes.MapPageRoute("Intro", "security.intro.html", "~/pages/security/intro.aspx");
        RouteTable.Routes.MapPageRoute("SignIn", "security.signIn.html", "~/pages/security/signIn.aspx");
        RouteTable.Routes.MapPageRoute("SignOut", "security.signout.html", "~/pages/security/signout.aspx");
        RouteTable.Routes.MapPageRoute("Users.Add", "security.users.add.html", "~/pages/security/users.add.aspx");
        RouteTable.Routes.MapPageRoute("Users.Edit", "security.users.edit.html", "~/pages/security/users.edit.aspx");
        RouteTable.Routes.MapPageRoute("Users.History", "security.users.history.html", "~/pages/security/users.history.aspx");
        RouteTable.Routes.MapPageRoute("Users.List", "security.users.list.html", "~/pages/security/users.list.aspx");

		RouteTable.Routes.MapPageRoute("BookingList", Resources.Url.BookingList, "~/pages/content/booking.list.aspx");
		RouteTable.Routes.MapPageRoute("BookedList", Resources.Url.BookedList, "~/pages/content/booked.list.aspx");
		RouteTable.Routes.MapPageRoute("DashBoards", Resources.Url.DashBoards, "~/pages/content/DashBoards.aspx");
    }
	public static string ShowStatusCart(string status)
	{
		string strString = "";
		string[] myArr = new string[] { "0,Chưa thanh toán", "1,Đã thanh toán", "2,Đã nhận vé", "3,Hủy đặt hàng" };
		char[] splitter = { ',', ';' };
		for (int i = 0; i < myArr.Length; i++)
		{
			string[] arr = myArr[i].Split(splitter);
			if (arr[0].Equals(status))
			{
				strString = arr[1];
				break;
			}
		}
		switch (status)
		{
			case "0":
				return string.Format("<span class=\"label label-danger\">{0}</span>", strString);
			case "1":
				return string.Format("<span class=\"label label-warning\">{0}</span>", strString);
			case "3":
				return string.Format("<span class=\"label label-primary\">{0}</span>", strString);
			default:
				return string.Format("<span class=\"label label-success\">{0}</span>", strString);
		}
	}
	public static string ConvertPrice(string price)
	{
		if (price.Length > 0)
		{
			if (price.Length > 3)
			{
				int Length = price.Length;
				while (Length > 3)
				{
					price = price.Insert(Length - 3, ".");
					Length = Length - 3;
				}
				return price + " ₫";
			}
			else
			{
				return price + " ₫";
			}
		}
		else
		{
			return "0 ₫";
		}
	}
	public static string CalTimeFly(string StartDate, string EndDate, string DepTime, string DicTime)
	{
		DateTime startDate;
		DateTime endDate;
		startDate = DateTime.Parse(StartDate + " " + DepTime, new CultureInfo("vi-VN", true));
		endDate = DateTime.Parse(EndDate + " " + DicTime, new CultureInfo("vi-VN", true));
		if (startDate > endDate)
		{
			endDate = endDate.AddDays(1);
		}
		double minutes = (endDate - startDate).TotalMinutes;
		return "Thời gian bay " + Math.Floor(minutes / 60).ToString() + "h" + (minutes - Math.Floor(minutes / 60) * 60).ToString();
	}

	public static string ConvertDateTime(string date)
	{
		return DateTime.Parse(date).ToString("dd/MM/yyyy");
	}

	public static string ConvertDateTimeUTC(string date)
	{
		return DateTime.Parse(date, new CultureInfo("vi-VN", true)).ToString("MM/dd/yyyy");
	}
}
