using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Libs.Security;

public partial class Pages_Admin_Permissions_Add : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AppUtils.CheckSecurity();

        if (!IsPostBack)
        {
            Title = "Cadavan - Thêm mới quyền";

            init();
        }
    }

    private void init()
    {
        drpFather.DataSource = new Permissions().GetTList(0);
        drpFather.DataBind();

        for (int i = 0; i < drpFather.Items.Count; i++)
        {
            drpFather.Items[i].Text = "- " + drpFather.Items[i].Text;
        }
        drpFather.Items.Insert(0, new ListItem("Chọn quyền mức cha:", "0"));

        GetDrpOrder();
    }

    private void GetDrpOrder()
    {
        drpOrder.Items.Clear();
        drpOrder.Items.Insert(0, new ListItem("Chọn thứ tự:", "0"));

        Permissions _Permission = new Permissions();
        List<Permissions> list = _Permission.GetList(Convert.ToInt32(drpFather.SelectedValue));

        for (int i = 0; i < list.Count; i++)
        {
            _Permission = list[i];
            drpOrder.Items.Add(new ListItem("- " + _Permission.Name + " (" + _Permission.Order.ToString() + ")", _Permission.Order.ToString()));
        }
    }


    protected void btSubmit_Click(object sender, EventArgs e)
    {
        Permissions _Permission = new Permissions();

        _Permission.Name = txtName.Text.Trim();
        _Permission.Alias = txtAlias.Text.Trim();
        _Permission.Url = txtUrl.Text.Trim().ToLower();
        _Permission.Description = txtDescription.Text.Trim();
        _Permission.FatherID = Convert.ToInt32(drpFather.SelectedValue);
        _Permission.Order = Convert.ToInt32(drpOrder.SelectedValue) + 1;
        _Permission.Status = cbStatus.Checked;
        _Permission.ShowMenu = cbShowMenu.Checked;

        _Permission.Add();

        if (_Permission.PermissionID > 0)
        {
            Response.Redirect(Constant.ADMIN_PATH + Resources.Url.PermissionsList);
        }
        else
        {
            switch (_Permission.PermissionID)
            {
                case -11:
                    literalMessage.Text = AppUtils.Alert("warning", "Lỗi dữ liệu!", "Quyền đã tồn tại.");
                    txtUrl.Focus();
                    break;
                default:
                    literalMessage.Text = AppUtils.Alert("warning", "Lỗi hệ thống!", "Có lỗi khi thêm mới quyền.");
                    break;
            }

        }
    }

    protected void drpFather_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetDrpOrder();
    }
}