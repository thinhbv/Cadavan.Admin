using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Libs.Security;
using Libs.Content;


public partial class Pages_OrdersTourInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
	{
		OrdersTours order = new OrdersTours();
		int id = int.Parse(Request.QueryString["id"].ToString());
		
		if (Request.QueryString["action"] != null)
		{
			if (Request.QueryString["status"] != null)
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
		}
		List<OrdersTours> lstOrder = new List<OrdersTours>();
		lstOrder = order.GetById(id);
		if (lstOrder.Count > 0)
		{
			if (Application["Config"] != null)
			{
				Libs.Content.Config con = (Libs.Content.Config)Application["Config"];
				AppUtils.LoadDropDownList(drpStatus, con.StatusTour);
			}
			lblContactName.Text = lstOrder[0].FirstName + " " + lstOrder[0].LastName;
			lblContactEmail.Text = lstOrder[0].Email;
			lblContactPhone.Text = lstOrder[0].Phone;
			lblContactAddress.Text = lstOrder[0].Address;
			lblRemarks.Text = lstOrder[0].Remarks;
			lblContactPhone.Text = lstOrder[0].Phone;
			drpStatus.SelectedValue = lstOrder[0].Status.ToString();
			if (lstOrder[0].Status == 1 || lstOrder[0].Status == 2)
			{
				drpStatus.Enabled = false;
			}
		}
    }
}