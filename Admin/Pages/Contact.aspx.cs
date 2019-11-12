using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Libs.Content;

public partial class Pages_Contact : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		try
		{
			if (!IsPostBack)
			{
				Contact contact = new Contact();
				List<Contact> lstCon = contact.Get(999);
				rptList.DataSource = lstCon;
				rptList.DataBind();
				lblTotalRecord.Text = "Tổng số bản ghi: " + lstCon.Count.ToString();
			}
		}
		catch (Exception)
		{
			
			throw;
		}
    }

	public string ShowStatus(string status)
	{
		switch (status)
		{
			case "0":
				return string.Format("<span class=\"label label-danger\">{0}</span>", "Chưa hỗ trợ");
			default:
				return string.Format("<span class=\"label label-success\">{0}</span>", "Đã hỗ trợ");
		}
	}
}