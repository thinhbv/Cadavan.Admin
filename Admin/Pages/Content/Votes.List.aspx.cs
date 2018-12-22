using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Libs.Content;

public partial class Pages_Content_Votes_List : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AppUtils.CheckLogin();
        Title = Constant.TITLE + " - Thăm dò dư luận";
        if (!IsPostBack) BindData();
    }

    private void BindData()
    {
        var _Vote = new Votes();
        rptList.DataSource = _Vote.GetTList();
        rptList.DataBind();
    }

    protected void btAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect(Constant.ADMIN_PATH + Resources.Url.VotesAdd);
    }
}