using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Libs.Security;
using Libs.Utils;

public partial class Pages_Admin_Users_Add : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AppUtils.CheckSecurity();

        if (!IsPostBack)
        {
            Title = "Cadavan - Thêm mới tài khoản";

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
    }

    protected void btSubmit_Click(object sender, EventArgs e)
    {
        // Thêm bảng Users, sau đó thêm vào bảng UserInfo
        Users _User = new Users();
        UserInfo _UserInfo = new UserInfo();

        _User.Username = txtUserName.Text.Trim().ToLower();
        _User.Password = Encrypts.MD5(txtPassword.Text);
        _User.Status = cbStatus.Checked ? 1 : -1;
        _User.RoleID = Convert.ToInt32(drpRole.SelectedValue);

        _UserInfo.FirstName = txtFirstName.Text.Trim();
        _UserInfo.LastName = txtLastName.Text.Trim();
        _UserInfo.Gender = Convert.ToInt32(drpGender.SelectedValue);
        _UserInfo.Birthday = Convert.ToDateTime(txtBirthday.Text);
        _UserInfo.Mobile = txtMobile.Text;
        _UserInfo.Email = txtEmail.Text.Trim().ToLower();
        _UserInfo.DepartmentID = _User.RoleID;

        _User.Add(_User, _UserInfo);

        if (_User.ReturnValue > 0)
        {
            Response.Redirect(Constant.ADMIN_PATH + Resources.Url.UsersList);
        }
        else
        {
            switch (_User.ReturnValue)
            {
                case -11:
                    literalMessage.Text = AppUtils.Alert("warning", "Lỗi dữ liệu!", "Tên truy cập đã tồn tại.");
                    txtUserName.Focus();
                    break;
                default:
                    literalMessage.Text = AppUtils.Alert("warning", "Lỗi hệ thống!", "Có lỗi khi thêm mới người dùng.");
                    break;
            }
        }
    }

    protected void CustomValidator2_ServerValidate(object source, ServerValidateEventArgs args)
    {
        args.IsValid = true;
    }
}