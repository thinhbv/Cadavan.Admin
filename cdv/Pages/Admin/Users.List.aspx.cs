using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Libs.Security;

public partial class Pages_Admin_Users_List : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AppUtils.CheckSecurity();

        if (!IsPostBack)
        {
            init();

            GetList();
        }
    }

    private void init()
    {
        Title = "Cadavan - Danh sách người dùng";

        drpRole.DataSource = new Roles().GetTList();
        drpRole.DataBind();

        for (int i = 0; i < drpRole.Items.Count; i++)
        {
            drpRole.Items[i].Text = "- " + drpRole.Items[i].Text;
        }

        drpRole.Items.Insert(0, new ListItem("Nhóm quyền:", "0"));

        rptReport.DataSource = new Users().Report();
        rptReport.DataBind();
    }

    private void GetList()
    {
        int roleID = Convert.ToInt32(drpRole.SelectedValue);
        int status = Convert.ToInt32(drpStatus.SelectedValue);

        rptList.DataSource = new Users().GetTList(roleID, status);
        rptList.DataBind();

        lblTotalRecord.Text = "Tổng số bản ghi: " + rptList.Items.Count;
    }

    protected void btView_Click(object sender, EventArgs e)
    {
        GetList();
    }

    protected string StatusName(string status)
    {
        switch (status)
        {
            case "1":
                return "<span class=\"label label-success\">Đang sử dụng</span>";
            default:
                return "<span class=\"label label-danger\">Ngừng hoạt động</span>"; 
        }
    }
}