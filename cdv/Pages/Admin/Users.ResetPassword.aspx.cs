using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Libs.Security;
using Libs.Utils;

public partial class Pages_Admin_Users_ResetPassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AppUtils.CheckSecurity();

        if (!IsPostBack)
        {
            Title = "Cadavan - Đặt lại mật khẩu";
            init();
        }
    }

    private void init()
    {
        Session["ConfirmMessage"] = "Bạn có đồng ý hủy dữ liệu!";
        Session["ConfirmUrl"] = Constant.ADMIN_PATH + Resources.Url.UsersList;

        Users _User = new Users() { UserID = AppUtils.Request("id") };
        _User = _User.Get();

        if (_User == null)
        {
            Response.Redirect(Constant.ADMIN_PATH + Resources.Url.Error404);
        }

        ltrSubTitle.Text = "Tài khoản: " + _User.Username + " (" + _User.Fullname + ")";
        ltrUserName.Text = _User.Username;
     }

    protected void btSubmit_Click(object sender, EventArgs e)
    {        
        Users _User = new Users();
        _User.UserID = AppUtils.Request("id");
        _User = _User.Get();

        _User.Status = cbStatus.Checked ? 1 : -1;
        _User.Update();

        _User.Password = Encrypts.MD5(txtPassword.Text);

        _User.ResetPassword(_User.UserID, _User.Password);
        if (_User.ReturnValue == 0)
        {
            literalMessage.Text = AppUtils.Alert("success", "Thành công!", "Cập nhật mật khẩu thành công.");
        }
        else
        {
            literalMessage.Text = AppUtils.Alert("warning", "Lỗi!", "Cập nhật mật khẩu không thành công.");
        }
    }
}