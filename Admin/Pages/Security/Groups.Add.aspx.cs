using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Libs.Security;

public partial class Pages_Security_Groups_Add : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AppUtils.CheckLogin();
        Title = Constant.TITLE + " - Thêm mới nhóm người dùng";
    }

    protected void btAdd_Click(object sender, EventArgs e)
    {
        var _Group = new Groups();
        _Group.Name = txtName.Text.Trim();
        _Group.Order = Convert.ToInt32(txtOrder.Text.Trim());
        _Group.Description = txtDescription.Text.Trim();
        _Group.Add();

        Response.Redirect(Constant.ADMIN_PATH + Resources.Url.GroupsEdit + "?id=" + _Group.GroupID.ToString());
    }

    protected void btCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect(Constant.ADMIN_PATH + Resources.Url.UsersList);
    }
}