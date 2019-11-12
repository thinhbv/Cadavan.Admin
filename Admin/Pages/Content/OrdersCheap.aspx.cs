using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Libs.Content;

public partial class Pages_Content_OrdersCheap : System.Web.UI.Page
{
	List<OrdersCheap> lstOrder = new List<OrdersCheap>();
	protected string lstStatus = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
		try
		{
			if (!IsPostBack)
			{
				init();
				GetList();
			}

		}
		catch (Exception)
		{
			throw;
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

	}
	private void GetList()
	{
		if (Application["Config"] != null)
		{
			Libs.Content.Config con = (Libs.Content.Config)Application["Config"];
			lstStatus = con.StatusTicket;
			AppUtils.LoadDropDownList(drpStatus, lstStatus);
		}
		string airline = drpAir.SelectedValue;
		int status = Convert.ToInt32(drpStatus.SelectedValue);
		string startdate = txtFromDate.Value.Trim();
		if (!string.IsNullOrEmpty(startdate))
		{
			startdate = AppUtils.ConvertDateTimeUTC(startdate);
		}
		string enddate = txtToDate.Value.Trim();
		if (!string.IsNullOrEmpty(enddate))
		{
			enddate = DateTime.Parse(enddate, new CultureInfo("vi-VN", true)).AddDays(1).ToString("MM/dd/yyyy");
		}
		lstOrder = new OrdersCheap().Get(status, airline, startdate, enddate);
		if (Session["OrdersCheap"] != null)
		{
			Session.Remove("OrdersCheap");
			Session["OrdersCheap"] = null;
		}
		Session.Add("OrdersCheap", lstOrder);
		rptList.DataSource = lstOrder;
		rptList.DataBind();

		lblTotalRecord.Text = "Tổng số bản ghi: " + rptList.Items.Count;
	}
	protected void btView_Click(object sender, EventArgs e)
	{
		try
		{
			GetList();
		}
		catch (Exception)
		{
			throw;
		}
	}

	protected string ShowPlan(int id)
	{
		string sReturn = "";
		List<OrdersCheap> lst = lstOrder.Where(o => o.OrderId == id).ToList();
		if (lst != null && lst.Count > 0)
		{
			sReturn += " <b>" + lst[0].FromCity + "</b> - <b>" + lst[0].ToCity + "</b> ";
		}
		return sReturn;
	}
}