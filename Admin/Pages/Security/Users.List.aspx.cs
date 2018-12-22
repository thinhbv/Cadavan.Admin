using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Libs.Security;

public partial class Pages_Security_Users_List : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Title = Title + " - Danh sách người dùng";
        AppUtils.CheckLogin();
        if (!IsPostBack)
        {
            GetDropDownList();
            BindData();
        }
    }

    private void GetDropDownList()
    {
        Groups _Group = new Groups();
        drpGroup.DataSource = _Group.GetList();
        drpGroup.DataBind();
        drpGroup.Items.Insert(0, new ListItem("Nhóm người dùng:", "0"));
    }

    private void BindData()
    {
        var _User = new Users();
        rptList.DataSource = _User.GetTList(Convert.ToInt32(drpStatus.SelectedValue), Convert.ToInt32(drpGroup.SelectedValue));
        rptList.DataBind();
    }

    protected void btApply_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < rptList.Items.Count; i++)
        {
            var _User = new Users();
            CheckBox cbx = (CheckBox)rptList.Items[i].FindControl("cbxStatus");
            Label labelUserID = (Label)rptList.Items[i].FindControl("lblUserID");
            _User.UserID = Convert.ToInt32(labelUserID.Text);
            _User = _User.Get();
            _User.Status = cbx.Checked ? 1 : 0;
            _User.Update();
        }
        BindData();
    }

    protected void btView_Click(object sender, EventArgs e)
    {
        BindData();
    }

    protected void btAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect(Constant.ADMIN_PATH + Resources.Url.UsersAdd);
    }
}
