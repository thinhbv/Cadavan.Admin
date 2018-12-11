using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Libs.Security;

public partial class Pages_Admin_Permissions_List : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AppUtils.CheckSecurity();

        if (!IsPostBack)
        {
            Title = "Cadavan - Danh sách quyền";

            init();

            GetList();
        }
    }

    private void init()
    {
        drpFather.DataSource = new Permissions().GetTList(0);
        drpFather.DataBind();

        for (int i = 0; i < drpFather.Items.Count; i++)
        {
            drpFather.Items[i].Text = "- " + drpFather.Items[i].Text;
        }
        drpFather.Items.Insert(0, new ListItem("Xem hết:", "0"));
    }

    private void GetList()
    {
        int fatherID = Convert.ToInt32(drpFather.SelectedValue);

        if (fatherID == 0)
        {
            rptList.DataSource = new Permissions().GetTList();
            rptList.DataBind();
        }
        else
        {
            rptList.DataSource = new Permissions().GetTListFather(fatherID);
            rptList.DataBind();
        }
    }

    protected void btView_Click(object sender, EventArgs e)
    {
        GetList();
    }
}