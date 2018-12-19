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
		List<Orders> lstOrder;
		lstOrder = new Orders().GetById(id);
		if (Request.QueryString["action"] != null)
		{
			string action = Request.QueryString["action"].ToString();
			if (action == "update")
			{
				Orders order = new Orders();
				order.UpdateStatus(lstOrder, status);
				Response.StatusCode = 200;
				Response.Flush();
				return;
			}
		}
		
		string air = Request.QueryString["air"].ToString();
		
		if (lstOrder != null && lstOrder.Count > 0)
		{
			List<Address> lstadd = new List<Address>();
			Address add = new Address();
			fromcity = lstOrder[0].FromCity;
			lstadd = add.GetName(fromcity);
			if (lstadd != null && lstadd.Count > 0)
			{
				fromname = lstadd[0].name;
			}
			tocity = lstOrder[0].ToCity;
			lstadd = add.GetName(tocity);
			if (lstadd != null && lstadd.Count > 0)
			{
				toname = lstadd[0].name;
			}
			//Hiển thị thời gian bay
			lblStartDate.Text = lstOrder[0].DepTime.ToString().Substring(0, lstOrder[0].DepTime.ToString().LastIndexOf(":")) + " " + lstOrder[0].StartDate.ToString("dd/MM/yyyy");
			lblEndDate.Text = lstOrder[0].DicTime.ToString().Substring(0, lstOrder[0].DicTime.ToString().LastIndexOf(":")) + " " + lstOrder[0].EndDate.ToString("dd/MM/yyyy");
			lblTimeFly.Text = AppUtils.CalTimeFly(lstOrder[0].StartDate.ToString("dd/MM/yyyy"), lstOrder[0].EndDate.ToString("dd/MM/yyyy"), lstOrder[0].DepTime.ToString(), lstOrder[0].DicTime.ToString());
			List<Info> lstInfo = CreateOrdersInfo(lstOrder[0].Adult, lstOrder[0].Child, lstOrder[0].Infant, lstOrder[0]);
			rptOrders.DataSource = lstInfo;
			rptOrders.DataBind();
			if (lstOrder.Count == 2)
			{
				pnReturn.Visible = true;
				lblReturnStartDate.Text = lstOrder[1].DepTime.ToString().Substring(0, lstOrder[1].DepTime.ToString().LastIndexOf(":")) + " " + lstOrder[1].StartDate.ToString("dd/MM/yyyy");
				lblReturnEndDate.Text = lstOrder[1].DicTime.ToString().Substring(0, lstOrder[1].DicTime.ToString().LastIndexOf(":")) + " " + lstOrder[1].EndDate.ToString("dd/MM/yyyy");
				lblReturnTimeFly.Text = AppUtils.CalTimeFly(lstOrder[1].StartDate.ToString("dd/MM/yyyy"), lstOrder[1].EndDate.ToString("dd/MM/yyyy"), lstOrder[1].DepTime.ToString(), lstOrder[1].DicTime.ToString());
				lstInfo = new List<Info>();
				lstInfo = CreateOrdersInfo(lstOrder[1].Adult, lstOrder[1].Child, lstOrder[1].Infant, lstOrder[1]);
				rptReturnOrders.DataSource = lstInfo;
				rptReturnOrders.DataBind();
			}
			lblTotalTax.Text = AppUtils.ConvertPrice(lstOrder[0].TaxFee.ToString());
			lblTotalPrice.Text = AppUtils.ConvertPrice(lstOrder[0].Price.ToString());
			lblContactName.Text = lstOrder[0].FirstName + " " + lstOrder[0].LastName;
			lblContactPhone.Text = lstOrder[0].Phone;
			lblContactEmail.Text = lstOrder[0].Email;
			lblContactAddress.Text = lstOrder[0].Address;
			drpStatus.SelectedValue = lstOrder[0].Status.ToString();
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