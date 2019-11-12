using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Libs.Content;

public partial class Pages_DetailInfoCheap : System.Web.UI.Page
{
	protected string fromname = "";
	protected string toname = "";
    protected void Page_Load(object sender, EventArgs e)
    {
		int id = int.Parse(Request.QueryString["id"].ToString());
		OrdersCheap order = new OrdersCheap();
		if (Request.QueryString["action"] != null)
		{
			int status = int.Parse(Request.QueryString["status"].ToString());
			string action = Request.QueryString["action"].ToString();
			if (action == "update")
			{
				order.UpdateStatus(id, status, AppUtils.UserID().ToString());
				Response.StatusCode = 200;
				Response.Flush();
				return;
			}
		}
		List<OrdersCheap> lstOrder = new List<OrdersCheap>();
		if (Session["OrdersCheap"] != null)
		{
			lstOrder = (List<OrdersCheap>)Session["OrdersCheap"];
			order = lstOrder.Where(o => o.OrderId == id).FirstOrDefault();
		}
		else
		{
			lstOrder = order.GetById(id);
			if (lstOrder.Count > 0)
			{
				order = lstOrder[0];
			}
		}
		if (Application["Config"] != null)
		{
			Libs.Content.Config con = (Libs.Content.Config)Application["Config"];
			AppUtils.LoadDropDownList(drpStatus, con.StatusCheapTicket);
		}
		drpStatus.SelectedValue = order.Status.ToString();
		if (order.Status == 2 || order.Status == 3)
		{
			drpStatus.Enabled = false;
		}
		fromname = order.FromCity;
		toname = order.ToCity;
		lblStartDate.Text = order.DepTime.ToString().Remove(5) + " " + order.StartDate.ToString("dd/MM/yyyy");
		lblEndDate.Text = order.DicTime.ToString().Remove(5) + " " + order.EndDate.ToString("dd/MM/yyyy");
		lblTimeFly.Text = AppUtils.CalTimeFly(order.StartDate.ToString("dd/MM/yyyy"), order.EndDate.ToString("dd/MM/yyyy"), order.DepTime.ToString(), order.DicTime.ToString());
		lblTotalPrice.Text = AppUtils.ConvertPrice(order.Price.ToString());
		lblContactName.Text = order.FirstName + " " + order.LastName;
		lblContactPhone.Text = order.Phone;
		lblContactEmail.Text = order.Email;
		lblContactAddress.Text = order.Address;
		if (order.Target == 0)
		{
			lblTarget.Text = "Người lớn";
		}
		else if (order.Target == 1)
		{
			lblTarget.Text = "Trẻ em";
		}
		else
		{
			lblTarget.Text = "Em bé";
		}
		lblQuantity.Text = order.Num.ToString();
		lblPrice.Text = AppUtils.ConvertPrice(order.AdultPriceNet.ToString());
    }
}