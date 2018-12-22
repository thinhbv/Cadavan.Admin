using System;
using System.Collections;
using System.Collections.Generic;
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

public partial class SignIn : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) return;
    }

    protected void btSignIn_Click(object sender, EventArgs e)
    {
        Session.RemoveAll();
        var _User = new Users();
        _User = _User.Authentication(txtUserName.Text, Encrypts.MD5(txtPassword.Text));
        if (_User != null)
        {
            Session.Timeout = 120;
            Session["UserID"] = _User.UserID;
            Session["Email"] = _User.Email;
            Session["FullName"] = _User.FullName;
            Session["LastestTime"] = _User.LastestTime.ToString();
            string url = Request["u"];
            url = url == null ? Constant.ADMIN_PATH + Resources.Url.Intro : url;
            Response.Redirect(url);
        }
        else
        {
            PanelMessage.Visible = true;
            lblMessage.Text = "Mật khẩu hoặc tên đăng nhập không hợp lệ";
            txtPassword.Focus();
        }
    }
}
