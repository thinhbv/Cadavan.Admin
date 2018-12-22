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

public partial class Pages_Security_ChangePassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AppUtils.CheckLogin();
        Title = Title + " - Đổi mật khẩu";
    }

    protected void btSubmit_Click(object sender, EventArgs e)
    {
        Users _User = new Users() { UserID = AppUtils.UserID() };
        _User = _User.Get();
        if (Encrypts.MD5(txtPasswordOld.Text.Trim()) != _User.Password)
        {
            Message.Alert(Page, "Mật khẩu cũ không chính xác!");
            return;
        }

        _User.Password = Encrypts.MD5(txtPassword.Text.Trim());
        _User.Update();
        Message.Alert(Page, "Đổi mật khẩu thành công!");
    }
}
