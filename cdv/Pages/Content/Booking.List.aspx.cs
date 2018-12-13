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
	List<Orders> lstOrder = null;
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
		lstOrder = new Orders().Get(status, airline);
		if (Session["Orders"] != null)
		{
			Session.Remove("Orders");
			Session["Orders"] = null;
		}
		Session.Add("Orders", lstOrder);
		List<int> lstId = new List<int>();
		List<Orders> lstTemp = new List<Orders>();
		for (int i = 0; i < lstOrder.Count; i++)
		{
			bool isExist = false;
			for (int j = 0; j < lstTemp.Count; j++)
			{
				if (lstOrder[i].OrderId == lstTemp[j].OrderId)
				{
					isExist = true;
					lstTemp[j].TicketId += "<br/>" + lstOrder[i].TicketId;
					lstTemp[j].TicketClassName += "<br/>" + lstOrder[i].TicketClassName;
					lstTemp[j].CompanyName += "<br/>" + lstOrder[i].CompanyName;
					break;
				}
			}
			if (!isExist)
			{
				lstTemp.Add(lstOrder[i]);
			}
		}
		rptList.DataSource = lstTemp;
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
	protected string ShowPlan(int id)
	{
		string sReturn = "";
		List<Orders> lst = lstOrder.Where(o => o.OrderId == id).ToList();
		if (lst != null && lst.Count > 0)
		{
			sReturn += " <b>" + lst[0].FromCity + "</b> - <b>" + lst[0].ToCity + "</b> ";
			//for (int i = 0; i < lst.Count; i++)
			//{
				//sReturn += lst[i].DepTime.ToString().Substring(0, lst[i].DepTime.ToString().LastIndexOf(":")) + " " + lst[i].StartDate.ToString("dd/MM/yyyy").Substring(0, lst[i].StartDate.ToString("dd/MM/yyyy").LastIndexOf("/"));
				//sReturn += " <b>" + lst[i].FromCity + "</b> - <b>" + lst[i].ToCity + "</b> ";
				//sReturn += lst[i].DicTime.ToString().Substring(0, lst[i].DicTime.ToString().LastIndexOf(":")) + " " + lst[i].EndDate.ToString("dd/MM/yyyy").Substring(0, lst[i].EndDate.ToString("dd/MM/yyyy").LastIndexOf("/"));
				//if (i == 0)
				//{
					//sReturn += "<br/>";
				//}
			//}

		}
		return sReturn;
	}
	protected string ShowCustomerInfo(string firstname, string lastname, string phone, string email)
	{
		return lastname + " " + firstname + " - " + phone + "<br/>" + email;
	}
}