using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Libs.Security;
using Libs.Content;
using System.Globalization;

public partial class Pages_Content_Tours_Order : System.Web.UI.Page
{
	List<OrdersTours> lstOrder = null;
	protected string lstStatus = string.Empty;
	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			if (!IsPostBack)
			{
				Title = "Cadavan - Danh sách đơn hàng đặt tour";
				if (Application["Config"] != null)
				{
					Libs.Content.Config con = (Libs.Content.Config)Application["Config"];
					lstStatus = con.StatusTour;
					AppUtils.LoadDropDownList(drpStatus, lstStatus);
				}
				GetList();
			}
		}
		catch (Exception)
		{

			throw;
		}
	}
	private void GetList()
	{
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
		lstOrder = new OrdersTours().GetOrder(status, startdate, enddate);
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
}