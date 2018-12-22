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
using Libs.Utils;

public partial class Pages_Security_Users_Add : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AppUtils.CheckLogin();
        Title = Title + " - Thêm mới người dùng";

        if (!IsPostBack)
        {
            GetDropDownList();
        }
    }

    private void GetDropDownList()
    {
        var _Group = new Groups();
        drpGroup.DataSource = _Group.GetList();
        drpGroup.DataBind();
        drpGroup.Items.Insert(0, new ListItem("Nhóm người dùng:", "0"));
    }

    protected void btAdd_Click(object sender, EventArgs e)
    {
        var _User = new Users();
        _User.Email = txtEmail.Text.Trim().ToLower();
        _User.FullName = txtFullName.Text.Trim();
        _User.Password = Encrypts.MD5(txtPassword.Text);
        _User.Status = Convert.ToInt32(chkIsActive.Checked);
        _User.Add();

        Response.Redirect(Constant.ADMIN_PATH + Resources.Url.UsersEdit);
    }

    protected void btCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect(Constant.ADMIN_PATH + Resources.Url.UsersList);
    }
}
