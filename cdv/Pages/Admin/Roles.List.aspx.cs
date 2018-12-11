using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Libs.Security;

public partial class Pages_Admin_Roles_List : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AppUtils.CheckSecurity();
        if (!IsPostBack)
        {
            Title = "Cadavan - Danh sách nhóm quyền";

            GetList();
        }
    }

    private void GetList()
    {
        rptList.DataSource = new Roles().GetTList();
        rptList.DataBind();
    }

    protected string StatusName(string status)
    {
        status = status.ToLower();
        switch (status)
        {
            case "true":
                return "<span class=\"label label-success\">Hoạt động</span>";
            default:
                return "<span class=\"label label-danger\">Ngừng hoạt động</span>";
        }
    }
}