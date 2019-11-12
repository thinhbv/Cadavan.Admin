using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Libs.Content;

public partial class Pages_Content_CheapTicket : System.Web.UI.Page
{
	List<TicketInfo> lstTicket = null;
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
		catch (Exception ex)
		{
			throw ex;
		}
		
    }
	private void init()
	{
		Title = "Cadavan - Danh sách vé rẻ";
	}
	private void GetList()
	{
		int status = Convert.ToInt32(drpStatus.SelectedValue);
		lstTicket = new TicketInfo().Get(status);
		if (Session["Ticket"] != null)
		{
			Session.Remove("Ticket");
			Session["Ticket"] = null;
		}
		Session.Add("Ticket", lstTicket);
		rptList.DataSource = lstTicket;
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
	protected string ShowTarget(string target)
	{
		switch (target)
		{
			case "0":
				return "Người lớn";
			case "1":
				return "Trẻ em";
			default:
				return "Em bé";
		}
	}
}