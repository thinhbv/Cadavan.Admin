using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Libs.Security;

public partial class Pages_Admin_Roles_Edit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AppUtils.CheckSecurity();

        if (!IsPostBack)
        {
            Title = "Cadavan - Cập nhật nhóm người dùng";

            init();
        }
    }

    private void init()
    {
        Roles _Role = new Roles() { RoleID = AppUtils.Request("id") };
        _Role = _Role.Get();

        // Không tồn tại
        if (_Role == null)
        {
            Response.Redirect(Constant.ADMIN_PATH + Resources.Url.Error404);
        }

        txtName.Text = _Role.Name;
        txtAlias.Text = _Role.Alias;
        cbStatus.Checked = _Role.Status;
        txtOrder.Text = _Role.Order.ToString();
        txtDescription.Text = _Role.Description;

        ltrSubTitle.Text = "Nhóm: " + _Role.Name;
    }

    protected void btSubmit_Click(object sender, EventArgs e)
    {
        Roles _Role = new Roles() { RoleID = AppUtils.Request("id") };
        _Role = _Role.Get();

        // Không tồn tại
        if (_Role == null)
        {
            Response.Redirect(Constant.ADMIN_PATH + Resources.Url.Error404);
        }

        _Role.Name = txtName.Text.Trim();
            _Role.Alias = _Role.Name;
        _Role.Status = cbStatus.Checked;
        _Role.Order = Convert.ToInt32(txtOrder.Text);
        _Role.Description = txtDescription.Text.Trim();

        _Role.Update();

        if (_Role.ReturnValue == 0)
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