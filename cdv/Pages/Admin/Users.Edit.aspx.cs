using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Libs.Security;
using Libs.Utils;

public partial class Pages_Admin_Users_Edit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AppUtils.CheckSecurity();

        if (!IsPostBack)
        {
            Title = "Cadavan - Cập nhật tài khoản";

            init();
        }
    }

    private void init()
    {
        // Cấu hình
        RangeValidatorBirthday.MaximumValue = DateTime.Now.ToString("yyyy/MM/dd");
        RangeValidatorBirthday.MinimumValue = "1900/01/01";

        drpRole.DataSource = new Roles().GetTList();
        drpRole.DataBind();
        for (int i = 0; i < drpRole.Items.Count; i++)
        {
            drpRole.Items[i].Text = "- " + drpRole.Items[i].Text;
        }
        drpRole.Items.Insert(0, new ListItem("Chọn nhóm quyền:", "0"));

        rptReport.DataSource = new Users().Report();
        rptReport.DataBind();

        Users _User = new Users() { UserID = AppUtils.Request("id") };
        _User = _User.Get();

        if (_User == null)
        {
            Response.Redirect(Constant.ADMIN_PATH + Resources.Url.Error404);
        }

        UserInfo _UserInfo = new UserInfo();
        _UserInfo = _UserInfo.Get(_User.UserID);

        ltrSubTitle.Text = "Tài khoản: " + _User.Username;
        ltrUserName.Text = _User.Username;
        cbStatus.Checked = _User.Status == 1;
        drpRole.SelectedValue = _User.RoleID.ToString();
        txtFirstName.Text = _UserInfo.FirstName;
        txtLastName.Text = _UserInfo.LastName;
        drpGender.SelectedValue = _UserInfo.Gender.ToString();
        txtBirthday.Text = _UserInfo.Birthday.ToString("dd/MM/yyyy");
        txtMobile.Text = _UserInfo.Mobile;
        txtEmail.Text = _UserInfo.Email;
    }

    protected void btSubmit_Click(object sender, EventArgs e)
    {
        // 
        Users _User = new Users() { UserID = AppUtils.Request("id") };
        _User = _User.Get();

        if (_User == null)
        {
            Response.Redirect(Constant.ADMIN_PATH + Resources.Url.Error404);
        } 
        
        UserInfo _UserInfo = new UserInfo();
        _UserInfo = _UserInfo.Get(_User.UserID);

        if (!string.IsNullOrWhiteSpace(txtPassword.Text))
        {
            _User.Password = Encrypts.MD5(txtPassword.Text);
            _User.ResetPassword(_User.UserID, _User.Password);
        }
        _User.Status = cbStatus.Checked ? 1 : -1;
        _User.RoleID = Convert.ToInt32(drpRole.SelectedValue);
        _UserInfo.FirstName = txtFirstName.Text.Trim();
        _UserInfo.LastName = txtLastName.Text.Trim();
        _UserInfo.Gender = Convert.ToInt32(drpGender.SelectedValue);
        _UserInfo.Birthday = Convert.ToDateTime(txtBirthday.Text);
        _UserInfo.Mobile = txtMobile.Text;
        _UserInfo.Email = txtEmail.Text.Trim().ToLower();
        _UserInfo.DepartmentID = _User.RoleID;

        _User.Update();
        _UserInfo.Update();

        if (_User.ReturnValue == 0)
        {
            Response.Redirect(Constant.ADMIN_PATH + Resources.Url.UsersList);
        }
        else
        {
            switch (_User.ReturnValue)
            {
                default:
                    literalMessage.Text = AppUtils.Alert("warning", "Lỗi hệ thống!", "Có lỗi khi cập nhật tài khoản.");
                    break;
            }
        }
    }

    protected void CustomValidator2_ServerValidate(object source, ServerValidateEventArgs args)
    {
        args.IsValid = true;
    }
}