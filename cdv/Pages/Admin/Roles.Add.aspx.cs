using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Libs.Security;

public partial class Pages_Admin_Roles_Add : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AppUtils.CheckSecurity();

        if (!IsPostBack)
        {
            Title = "Cadavan - Thêm mới nhóm người dùng";
        }

    }

    protected void btSubmit_Click(object sender, EventArgs e)
    {
        Roles _Role = new Roles();

        _Role.Name = txtName.Text.Trim();
        _Role.Alias = txtAlias.Text.Trim();
        _Role.Status = cbStatus.Checked;
        _Role.Order = Convert.ToInt32(txtOrder.Text);
        _Role.Description = txtDescription.Text.Trim();

        _Role.Add();

        if (_Role.ReturnValue > 0)
        {
            Response.Redirect(Constant.ADMIN_PATH + Resources.Url.RolesList);
        }
        else
        {
            switch (_Role.ReturnValue)
            {
                default:
                    literalMessage.Text = AppUtils.Alert("warning", "Lỗi hệ thống!", "Có lỗi khi thêm mới người dùng.");
                    break;
            }
        }
    }
}