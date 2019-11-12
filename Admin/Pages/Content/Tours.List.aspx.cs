using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Libs.Content;

public partial class Pages_Content_Tours_List : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			if (!IsPostBack)
			{
				Tours tour = new Tours();
				List<Tours> lstTours = new List<Tours>();
				if (drpStatus.SelectedValue == "")
				{
					lstTours = tour.Get();
				}
				else
				{
					lstTours = tour.GetByActive(int.Parse(drpStatus.SelectedValue));
				}
				rptList.DataSource = lstTours;
				rptList.DataBind();
				lblTotalRecord.Text = "Tổng số bản ghi: " + lstTours.Count.ToString();
			}
		}
		catch (Exception ex)
		{
			throw;
		}

	}
	protected void btView_Click(object sender, EventArgs e)
	{
		try
		{
			Tours tour = new Tours();
			List<Tours> lstTours = new List<Tours>();
			if (drpStatus.SelectedValue == "")
			{
				lstTours = tour.Get();
			}
			else
			{
				lstTours = tour.GetByActive(int.Parse(drpStatus.SelectedValue));
			}
			rptList.DataSource = lstTours;
			rptList.DataBind();
		}
		catch (Exception)
		{

			throw;
		}
	}
}