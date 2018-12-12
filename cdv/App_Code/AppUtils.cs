using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Routing;

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

    public static void Routes()
    {
        //RouteTable.Routes.MapPageRoute("BusTypeAdd", Resources.Url.BusTypeAdd, "~/pages/bus/bustype.add.aspx");
        //RouteTable.Routes.MapPageRoute("BusTypeEdit", Resources.Url.BusTypeEdit, "~/pages/bus/bustype.edit.aspx");
        //RouteTable.Routes.MapPageRoute("BusTypeList", Resources.Url.BusTypeList, "~/pages/bus/bustype.list.aspx");
        //RouteTable.Routes.MapPageRoute("BusAdd", Resources.Url.BusAdd, "~/pages/bus/bus.add.aspx");
        //RouteTable.Routes.MapPageRoute("BusEdit", Resources.Url.BusEdit, "~/pages/bus/bus.edit.aspx");
        //RouteTable.Routes.MapPageRoute("BusList", Resources.Url.BusList, "~/pages/bus/bus.list.aspx");
        //RouteTable.Routes.MapPageRoute("DriversAdd", Resources.Url.DriversAdd, "~/pages/bus/drivers.add.aspx");
        //RouteTable.Routes.MapPageRoute("DriversEdit", Resources.Url.DriversEdit, "~/pages/bus/drivers.edit.aspx");
        //RouteTable.Routes.MapPageRoute("DriversList", Resources.Url.DriversList, "~/pages/bus/drivers.list.aspx");
        //RouteTable.Routes.MapPageRoute("RoutesAdd", Resources.Url.RoutesAdd, "~/pages/bus/routes.add.aspx");
        //RouteTable.Routes.MapPageRoute("RoutesEdit", Resources.Url.RoutesEdit, "~/pages/bus/routes.edit.aspx");
        //RouteTable.Routes.MapPageRoute("RoutesList", Resources.Url.RoutesList, "~/pages/bus/routes.list.aspx");
        //RouteTable.Routes.MapPageRoute("RouteStationList", Resources.Url.RouteStationList, "~/pages/bus/routestation.list.aspx");
        //RouteTable.Routes.MapPageRoute("RouteStationAdd", Resources.Url.RouteStationAdd, "~/pages/bus/routestation.add.aspx");
        //RouteTable.Routes.MapPageRoute("RouteStationEdit", Resources.Url.RouteStationEdit, "~/pages/bus/routestation.edit.aspx");
        //RouteTable.Routes.MapPageRoute("StationsAdd", Resources.Url.StationsAdd, "~/pages/bus/stations.add.aspx");
        //RouteTable.Routes.MapPageRoute("StationsEdit", Resources.Url.StationsEdit, "~/pages/bus/stations.edit.aspx");
        //RouteTable.Routes.MapPageRoute("StationsList", Resources.Url.StationsList, "~/pages/bus/stations.list.aspx");
        //RouteTable.Routes.MapPageRoute("BusScheduleAdd", Resources.Url.BusScheduleAdd, "~/pages/bus/busschedule.add.aspx");
        //RouteTable.Routes.MapPageRoute("BusScheduleEdit", Resources.Url.BusScheduleEdit, "~/pages/bus/busschedule.edit.aspx");
        //RouteTable.Routes.MapPageRoute("BusScheduleList", Resources.Url.BusScheduleList, "~/pages/bus/busschedule.list.aspx");	
        //RouteTable.Routes.MapPageRoute("BusTimeAdd", Resources.Url.BusTimeAdd, "~/pages/bus/bustime.add.aspx");
        //RouteTable.Routes.MapPageRoute("BusTimeEdit", Resources.Url.BusTimeEdit, "~/pages/bus/bustime.edit.aspx");
        //RouteTable.Routes.MapPageRoute("BusTimeList", Resources.Url.BusTimeList, "~/pages/bus/bustime.list.aspx");

        RouteTable.Routes.MapPageRoute("Login", Resources.Url.Login, "~/pages/admin/users.login.aspx");
        RouteTable.Routes.MapPageRoute("UsersAdd", Resources.Url.UsersAdd, "~/pages/admin/users.add.aspx");
        RouteTable.Routes.MapPageRoute("UsersEdit", Resources.Url.UsersEdit, "~/pages/admin/users.edit.aspx");
        RouteTable.Routes.MapPageRoute("UsersList", Resources.Url.UsersList, "~/pages/admin/users.list.aspx");
        RouteTable.Routes.MapPageRoute("UsersResetPassword", Resources.Url.UsersResetPassword, "~/pages/admin/users.resetpassword.aspx");
        RouteTable.Routes.MapPageRoute("UsersChangePassword", Resources.Url.UsersChangePassword, "~/pages/admin/users.changepassword.aspx");
        RouteTable.Routes.MapPageRoute("RolesAdd", Resources.Url.RolesAdd, "~/pages/admin/roles.add.aspx");
        RouteTable.Routes.MapPageRoute("RolesEdit", Resources.Url.RolesEdit, "~/pages/admin/roles.edit.aspx");
        RouteTable.Routes.MapPageRoute("RolesList", Resources.Url.RolesList, "~/pages/admin/roles.list.aspx");
        RouteTable.Routes.MapPageRoute("RolesPermission", Resources.Url.RolesPermission, "~/pages/admin/roles.permission.aspx");
        RouteTable.Routes.MapPageRoute("PermissionsAdd", Resources.Url.PermissionsAdd, "~/pages/admin/permissions.add.aspx");
        RouteTable.Routes.MapPageRoute("PermissionsEdit", Resources.Url.PermissionsEdit, "~/pages/admin/permissions.edit.aspx");
		RouteTable.Routes.MapPageRoute("PermissionsList", Resources.Url.PermissionsList, "~/pages/admin/permissions.list.aspx");
		RouteTable.Routes.MapPageRoute("BookingList", Resources.Url.BookingList, "~/pages/content/booking.list.aspx");

        RouteTable.Routes.MapPageRoute("Error404", Resources.Url.Error404, "~/pages/error/error404.aspx");
        RouteTable.Routes.MapPageRoute("Error500", Resources.Url.Error500, "~/pages/error/error500.aspx");

        RouteTable.Routes.MapPageRoute("Edit", "edit.html", "~/pages/edit.aspx");

        RouteNews();
    }

    public static void RouteNews()
    {
        RouteTable.Routes.MapPageRoute("CategoriesAdd", Resources.Url.CategoriesAdd, "~/pages/content/categories.add.aspx");
        RouteTable.Routes.MapPageRoute("CategoriesEdit", Resources.Url.CategoriesEdit, "~/pages/content/categories.edit.aspx");
        RouteTable.Routes.MapPageRoute("Categoriesist", Resources.Url.CategoriesList, "~/pages/content/categories.list.aspx");

        RouteTable.Routes.MapPageRoute("NewsAdd", Resources.Url.NewsAdd, "~/pages/content/news.add.aspx");
        RouteTable.Routes.MapPageRoute("NewsEdit", Resources.Url.NewsEdit, "~/pages/content/news.edit.aspx");
        RouteTable.Routes.MapPageRoute("NewsList", Resources.Url.NewsList, "~/pages/content/news.list.aspx");
    }

    public static void CheckSecurity()
    {

    }

    public static string ConfirmMessage()
    {
        return HttpContext.Current.Session["ConfirmMessage"] == null ? "" : HttpContext.Current.Session["ConfirmMessage"].ToString();
    }

    public static string ConfirmUrl()
    {
        return HttpContext.Current.Session["ConfirmUrl"] == null ? "" : HttpContext.Current.Session["ConfirmUrl"].ToString();
    }

    public static string Alert(string mtype, string title, string content)
    {
        return "<div class=\"alert alert-" + mtype + "\"><strong>" + title + "</strong> " + content + "</div>";
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
        return 1;
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
}