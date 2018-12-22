using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Libs.Security;

public partial class Pages_Security_Groups_List : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Title = Constant.TITLE + " - Danh sách nhóm người dùng";
        AppUtils.CheckLogin();
        if (!IsPostBack) BindData();
    }

    private void BindData()
    {
        var _Group = new Groups();
        rptList.DataSource = _Group.GetList();
        rptList.DataBind();
    }

    protected void btAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect(Constant.ADMIN_PATH + Resources.Url.GroupsAdd);
    }
}