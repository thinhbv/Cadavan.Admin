using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Libs.Security;
using Libs.Content;

public partial class Pages_DetailInfo : System.Web.UI.Page
{
	protected string fromcity = "";
	protected string tocity = "";
	protected string fromname = "";
	protected string toname = "";
    protected void Page_Load(object sender, EventArgs e)
    {
		int id = int.Parse(Request.QueryString["id"].ToString());
		int status = int.Parse(Request.QueryString["status"].ToString());
		if (Request.QueryString["action"] != null)
		{
			string action = Request.QueryString["action"].ToString();
			if (action == "update")
			{
				Orders order = new Orders();
				order.UpdateStatus(id, status);
				Response.StatusCode = 200;
				Response.Flush();
				return;
			}
		}
		
		string air = Request.QueryString["air"].ToString();
		List<Orders> lstOrder;
		if (Session["Orders"] != null)
		{
			lstOrder = (List<Orders>)Session["Orders"];	
		}
		else
		{
			lstOrder = new Orders().Get(status, air);
		}
		List<Orders> OrderInfo = lstOrder.Where(o => o.OrderId == id).ToList();
		if (OrderInfo != null && OrderInfo.Count > 0)
		{
			List<Address> lstadd = new List<Address>();
			Address add = new Address();
			fromcity = OrderInfo[0].FromCity;
			lstadd = add.GetName(fromcity);
			if (lstadd != null && lstadd.Count > 0)
			{
				fromname = lstadd[0].name;
			}
			tocity = OrderInfo[0].ToCity;
			lstadd = add.GetName(tocity);
			if (lstadd != null && lstadd.Count > 0)
			{
				toname = lstadd[0].name;
			}
			//Hiển thị thời gian bay
			lblStartDate.Text = OrderInfo[0].DepTime.ToString().Substring(0, OrderInfo[0].DepTime.ToString().LastIndexOf(":")) + " " + OrderInfo[0].StartDate.ToString("dd/MM/yyyy");
			lblEndDate.Text = OrderInfo[0].DicTime.ToString().Substring(0, OrderInfo[0].DicTime.ToString().LastIndexOf(":")) + " " + OrderInfo[0].EndDate.ToString("dd/MM/yyyy");
			lblTimeFly.Text = AppUtils.CalTimeFly(OrderInfo[0].StartDate.ToString("dd/MM/yyyy"), OrderInfo[0].EndDate.ToString("dd/MM/yyyy"), OrderInfo[0].DepTime.ToString(), OrderInfo[0].DicTime.ToString());
			List<Info> lstInfo = CreateOrdersInfo(OrderInfo[0].Adult, OrderInfo[0].Child, OrderInfo[0].Infant, OrderInfo[0]);
			rptOrders.DataSource = lstInfo;
			rptOrders.DataBind();
			if (OrderInfo.Count == 2)
			{
				pnReturn.Visible = true;
				lblReturnStartDate.Text = OrderInfo[1].DepTime.ToString().Substring(0, OrderInfo[1].DepTime.ToString().LastIndexOf(":")) + " " + OrderInfo[1].StartDate.ToString("dd/MM/yyyy");
				lblReturnEndDate.Text = OrderInfo[1].DicTime.ToString().Substring(0, OrderInfo[1].DicTime.ToString().LastIndexOf(":")) + " " + OrderInfo[1].EndDate.ToString("dd/MM/yyyy");
				lblReturnTimeFly.Text = AppUtils.CalTimeFly(OrderInfo[1].StartDate.ToString("dd/MM/yyyy"), OrderInfo[1].EndDate.ToString("dd/MM/yyyy"), OrderInfo[1].DepTime.ToString(), OrderInfo[1].DicTime.ToString());
				lstInfo = new List<Info>();
				lstInfo = CreateOrdersInfo(OrderInfo[1].Adult, OrderInfo[1].Child, OrderInfo[1].Infant, OrderInfo[1]);
				rptReturnOrders.DataSource = lstInfo;
				rptReturnOrders.DataBind();
			}
			lblTotalTax.Text = AppUtils.ConvertPrice(OrderInfo[0].TaxFee.ToString());
			lblTotalPrice.Text = AppUtils.ConvertPrice(OrderInfo[0].Price.ToString());
			lblContactName.Text = OrderInfo[0].FirstName + " " + OrderInfo[0].LastName;
			lblContactPhone.Text = OrderInfo[0].Phone;
			lblContactEmail.Text = OrderInfo[0].Email;
			lblContactAddress.Text = OrderInfo[0].Address;
			drpStatus.SelectedValue = OrderInfo[0].Status.ToString();
		}
    }
	public static List<Info> CreateOrdersInfo(int Adult, int Child, int Infant, Orders item)
	{
		List<Info> lstOrder = new List<Info>();
		Info order;
		if (Adult > 0)
		{
			order = new Info();
			order.Type = "Người lớn";
			order.Quanlity = Adult;
			order.PriceNet = item.AdultPriceNet;
			order.TaxAndFee = item.AdultTaxAndFee;
			order.Discount = "0 ₫";
			order.TotalPrice = item.AdultTotalPrice * Adult;
			lstOrder.Add(order);
		}
		if (Child > 0)
		{
			order = new Info();
			order.Type = "Trẻ em";
			order.Quanlity = Child;
			order.PriceNet = item.ChildPriceNet;
			order.TaxAndFee = item.ChildTaxAndFee;
			order.Discount = "0 ₫";
			order.TotalPrice = item.ChildTotalPrice * Child;
			lstOrder.Add(order);
		}
		if (Infant > 0)
		{
			order = new Info();
			order.Type = "Trẻ sơ sinh";
			order.Quanlity = Infant;
			order.PriceNet = item.BabyPriceNet;
			order.TaxAndFee = item.BabyTaxAndFee;
			order.Discount = "0 ₫";
			order.TotalPrice = item.BabyTotalPrice * Infant;
			lstOrder.Add(order);
		}
		return lstOrder;
	}
}