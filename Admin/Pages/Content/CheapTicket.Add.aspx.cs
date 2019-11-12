using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Libs.Content;

public partial class Pages_Content_CheapTicket_Add : System.Web.UI.Page
{
	int id = 0;
	protected string pagetitle = "Thêm mới vé rẻ";
    protected void Page_Load(object sender, EventArgs e)
    {
		if (!IsPostBack)
		{
			if (Request.QueryString["id"] != null)
			{
				pagetitle = "Cập nhật thông tin vé rẻ";
				btnDelete.Attributes.Add("onClick", "javascript:return confirm('Bạn có muốn xóa?');");
				btnUpdate.Visible = true;
				btnRegister.Visible = false;
				btnDelete.Visible = true;
				id = int.Parse(Request.QueryString["id"]);
				TicketInfo ticket = new TicketInfo();
				List<TicketInfo> lstticket = new List<TicketInfo>();
				lstticket = ticket.GetById(id);
				if (lstticket.Count > 0)
				{
					txtCode.Value = lstticket[0].Code;
					txtCompanyName.Value = lstticket[0].CompanyName;
					txtDepTime.Value = lstticket[0].DepTime.ToString();
					txtDicTime.Value = lstticket[0].DicTime.ToString();
					txtEndDate.Value = lstticket[0].EndDate.ToString("dd/MM/yyyy");
					txtFromCity.Value = lstticket[0].FromCity;
					txtPrice.Value = lstticket[0].AdultPriceNet.ToString();
					txtQuantity.Value = lstticket[0].Quantity.ToString();
					txtStartDate.Value = lstticket[0].StartDate.ToString("dd/MM/yyyy");
					txtTicketClassName.Value = lstticket[0].TicketClassName;
					txtTicketId.Value = lstticket[0].TicketId;
					txtToCity.Value = lstticket[0].ToCity;
					ddlTarget.Value = lstticket[0].Target.ToString();
					ddlActive.Value = lstticket[0].Active.ToString();
				}
			}
			else
			{
				btnUpdate.Visible = false;
				btnDelete.Visible = false;
				btnRegister.Visible = true;
			}
		}
    }
	protected void btnRegister_Click(object sender, EventArgs e)
	{
		if (Page.IsValid)
		{
			try
			{
				TicketInfo ticket = new TicketInfo();
				ticket.TicketId = txtTicketId.Value.Trim();
				ticket.TicketClassName = txtTicketClassName.Value.Trim();
				ticket.Code = txtCode.Value.Trim();
				ticket.CompanyName = txtCompanyName.Value.Trim();
				if (txtStartDate.Value.Trim() == string.Empty)
				{
					
				}
				else
				{
					ticket.StartDate = DateTime.Parse(txtStartDate.Value.Trim(), new CultureInfo("vi-VN", true));
				}
				if (txtDepTime.Value.Trim() == string.Empty)
				{

				}
				else
				{
					ticket.DepTime = TimeSpan.Parse(txtDepTime.Value.Trim());
				}
				if (txtEndDate.Value.Trim() == string.Empty)
				{

				}
				else
				{
					ticket.EndDate = DateTime.Parse(txtEndDate.Value.Trim(), new CultureInfo("vi-VN", true));
				}
				if (txtDicTime.Value.Trim() == string.Empty)
				{

				}
				else
				{
					ticket.DicTime = TimeSpan.Parse(txtDicTime.Value.Trim());
				}
				ticket.FromCity = txtFromCity.Value.Trim();
				ticket.ToCity = txtToCity.Value.Trim();
				ticket.AdultPriceNet = Double.Parse(txtPrice.Value.Trim());
				ticket.Active = int.Parse(ddlActive.Value);

				//Default item
				ticket.Hold = true;
				ticket.AdultTaxAndFee = 0;
				ticket.AdultTotalPrice = 0;
				ticket.Target = int.Parse(ddlTarget.Value);
				if (txtQuantity.Value.Trim() == string.Empty)
				{

				}
				else
				{
					ticket.Quantity = int.Parse(txtQuantity.Value.Trim());
				}
				ticket.FirmImage = "";
				ticket.Transit = 1;
				ticket.Type = "";
				ticket.CreateDate = DateTime.Now;
				ticket.Insert(ticket);
				Response.Redirect("cheapticket.list.html", false);
			}
			catch (Exception)
			{
				Message.Alert(Page, "Đăng kí vé rẻ thất bại. Vui lòng thử lại!");
			}
		}
	}
	protected void btnUpdate_Click(object sender, EventArgs e)
	{
		if (Page.IsValid)
		{
			try
			{
				if (Request.QueryString["id"] == null)
				{
					return;
				}
				id = int.Parse(Request.QueryString["id"]);
				TicketInfo ticket = new TicketInfo();
				ticket.Id = id;
				ticket.TicketId = txtTicketId.Value.Trim();
				ticket.TicketClassName = txtTicketClassName.Value.Trim();
				ticket.Code = txtCode.Value.Trim();
				ticket.CompanyName = txtCompanyName.Value.Trim();
				if (txtStartDate.Value.Trim() == string.Empty)
				{

				}
				else
				{
					ticket.StartDate = DateTime.Parse(txtStartDate.Value.Trim(), new CultureInfo("vi-VN", true));
				}
				if (txtDepTime.Value.Trim() == string.Empty)
				{

				}
				else
				{
					ticket.DepTime = TimeSpan.Parse(txtDepTime.Value.Trim());
				}
				if (txtEndDate.Value.Trim() == string.Empty)
				{

				}
				else
				{
					ticket.EndDate = DateTime.Parse(txtEndDate.Value.Trim(), new CultureInfo("vi-VN", true));
				}
				if (txtDicTime.Value.Trim() == string.Empty)
				{

				}
				else
				{
					ticket.DicTime = TimeSpan.Parse(txtDicTime.Value.Trim());
				}
				ticket.FromCity = txtFromCity.Value.Trim();
				ticket.ToCity = txtToCity.Value.Trim();
				ticket.AdultPriceNet = Double.Parse(txtPrice.Value.Trim());
				ticket.Active = int.Parse(ddlActive.Value);

				//Default item
				ticket.Target = int.Parse(ddlTarget.Value);
				if (txtQuantity.Value.Trim() == string.Empty)
				{

				}
				else
				{
					ticket.Quantity = int.Parse(txtQuantity.Value.Trim());
				}
				ticket.CreateDate = DateTime.Now;
				ticket.Update(ticket);
				Response.Redirect("cheapticket.list.html", false);
			}
			catch (Exception)
			{
				Message.Alert(Page, "Cập nhật vé rẻ thất bại. Vui lòng thử lại!");
			}
		}
	}
	protected void btnDelete_Click(object sender, EventArgs e)
	{
		try
		{
			if (Request.QueryString["id"] == null)
			{
				return;
			}
			TicketInfo ticket = new TicketInfo();
			ticket.Delete(Request.QueryString["id"].ToString());
			Response.Redirect("cheapticket.list.html", false);
		}
		catch (Exception)
		{
			throw;
		}
	}
}