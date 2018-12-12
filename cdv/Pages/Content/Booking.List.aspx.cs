using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Libs.Security;
using Libs.Content;

public partial class Pages_Content_Booking_List : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		AppUtils.CheckSecurity();

		if (!IsPostBack)
		{
			init();

			GetList();
		}
    }
	private void init()
	{
		Title = "Cadavan - Danh sách đơn hàng";

		drpAir.DataSource = new Airlines().Get();
		drpAir.DataTextField = "Name";
		drpAir.DataValueField = "Code";
		drpAir.DataBind();
		drpAir.Items.Insert(0, new ListItem("- Chọn hãng hàng không -", ""));

		rptReport.DataSource = new Users().Report();
		rptReport.DataBind();
	}
	private void GetList()
	{
		
		string airline = drpAir.SelectedValue;
		int status = Convert.ToInt32(drpStatus.SelectedValue);
		List<Orders> lstOrder = new Orders().Get(status, airline);
		if (Session["Orders"] != null)
		{
			Session.Remove("Orders");
			Session["Orders"] = null;
		}
		Session.Add("Orders", lstOrder);
		rptList.DataSource = lstOrder;
		rptList.DataBind();

		lblTotalRecord.Text = "Tổng số bản ghi: " + rptList.Items.Count;
	}

	protected void btView_Click(object sender, EventArgs e)
	{
		GetList();
	}

	protected string StatusName(string status)
	{
		switch (status)
		{
			case "1":
				return "<span class=\"label label-success\">Đang sử dụng</span>";
			default:
				return "<span class=\"label label-danger\">Ngừng hoạt động</span>";
		}
	}
	protected string RoundTripName(string roundtrip)
	{
		switch (roundtrip)
		{
			case "1":
				return "<span class=\"label label-success\">Khứ hồi</span>";
			default:
				return "<span class=\"label label-danger\">Một chiều</span>";
		}
	}
	protected string ShowPlan(string deptime, string startdate, string dictime, string enddate, string fromcity, string tocity)
	{
		return deptime.Substring(0, deptime.LastIndexOf(":")) + " " + startdate.Substring(0, startdate.LastIndexOf("/")) + " <b>" + fromcity + "</b> - <b>" + tocity + "</b> " + dictime.Substring(0, deptime.LastIndexOf(":")) + " " + enddate.Substring(0, enddate.LastIndexOf("/"));
	}
	protected string ShowCustomerInfo(string firstname, string lastname, string phone, string email)
	{
		return lastname + " " + firstname + " - " + phone + "<br/>" + email;
	}
}