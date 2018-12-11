using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Libs.Security;
using Libs.Utils;

public partial class Pages_Admin_Users_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtUserName.Focus();
            linkButtonLogin.TabIndex = 0;
        }
    }

    protected void linkButtonLogin_Click(object sender, EventArgs e)
    {
        Users _User = new Users();
        _User.Username = txtUserName.Text.Trim();
        _User.Password = txtPassword.Text.Trim();
        
        if (string.IsNullOrWhiteSpace(_User.Username))
        {
            Message("Bạn chưa nhập tài khoản!");
            txtUserName.Focus();
            return;
        }

        if (string.IsNullOrWhiteSpace(_User.Password))
        {
            Message("Bạn chưa nhập mật khẩu!");
            txtPassword.Focus();
            return;
        }

        _User.Password = Encrypts.MD5(_User.Password);
        string tokenKey = "";
        DateTime LastLogin = DateTime.Now;
        int userID = 0;

        _User.Authentication(_User.Username, _User.Password, ref tokenKey, ref LastLogin, ref userID);
        if (userID > 0)
        {
            Response.Redirect(Constant.ADMIN_PATH + "users.list.html");
        }
        switch (userID)
        {
            case -1:
                Message("Tài khoản không tồn tại!");
                txtUserName.Focus();
                return;
            case -2:
                Message("Tài khoản bị khóa!");
                txtUserName.Focus();
                return;
            case -3:
                Message("Mật khẩu không chính xác!");
                txtPassword.Focus();
                return;
            default:
                Message("Hệ thống tạm khóa!");
                break;
        }
    }

    private void Message(string content)
    {
        literalMessage.Text= "<div class=\"alert alert-warning\">" + content + "</div>";
    }
}