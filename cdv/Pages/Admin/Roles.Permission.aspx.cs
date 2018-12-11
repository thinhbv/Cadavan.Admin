using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Libs.Security;

public partial class Pages_Admin_Roles_Permission : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AppUtils.CheckSecurity();

        if (!IsPostBack)
        {
            Title = "Cadavan - Phân quyền cho nhóm quyền";

            init();

            GetList();
        }

    }

    private void init()
    {
        // Kiểm tra người dùng
        Roles _Role = new Roles() { RoleID = AppUtils.Request("id") };
        _Role = _Role.Get();

        //
        if (_Role == null)
        {
            Response.Redirect(Constant.ADMIN_PATH + Resources.Url.Error404);
        }

        drpFather.DataSource = new Permissions().GetTList(0);
        drpFather.DataBind();

        for (int i = 0; i < drpFather.Items.Count; i++)
        {
            drpFather.Items[i].Text = "- " + drpFather.Items[i].Text;
        }
        drpFather.Items.Insert(0, new ListItem("Xem hết:", "0"));
    }

    private void GetList()
    {
        int fatherID = Convert.ToInt32(drpFather.SelectedValue);

        if (fatherID == 0)
        {
            rptList.DataSource = new Permissions().GetTList();
            rptList.DataBind();
        }
        else
        {
            rptList.DataSource = new Permissions().GetTListFather(fatherID);
            rptList.DataBind();
        }

        int roleID = AppUtils.Request("id");
        RolePermission _RolePermission = new RolePermission();
        List<RolePermission> list = _RolePermission.GetList(roleID);

        for (int i = 0; i < rptList.Items.Count; i++)
        {
            Literal ltrPermissionID = (Literal)rptList.Items[i].FindControl("ltrPermissionID");

            int permissionID = Convert.ToInt32(ltrPermissionID.Text);
            for (int j = 0; j < list.Count; j++)
            {
                _RolePermission = list[j];
                if (_RolePermission.PermissionID == permissionID)
                {
                    CheckBox cbx = (CheckBox)rptList.Items[i].FindControl("checkBoxStatus");
                    Literal ltrCreated = (Literal)rptList.Items[i].FindControl("ltrCreated");

                    cbx.Checked = true;
                    ltrCreated.Text = _RolePermission.Created.ToString("yyyy/MM/dd");

                    break;
                }
            }

        }
    }

    protected void btView_Click(object sender, EventArgs e)
    {
        GetList();
    }

    protected void btSubmit_Click(object sender, EventArgs e)
    {
        RolePermission _RolePermission = new RolePermission();
        _RolePermission.RoleID = AppUtils.Request("id");

        for (int i = 0; i < rptList.Items.Count; i++)
        {
            Literal ltrPermissionID = (Literal)rptList.Items[i].FindControl("ltrPermissionID");
            CheckBox cbx = (CheckBox)rptList.Items[i].FindControl("checkBoxStatus");

            _RolePermission.PermissionID = Convert.ToInt32(ltrPermissionID.Text);

            if (cbx.Checked)
            {
                _RolePermission.Add();
            }
            else
            {
                _RolePermission.Delete(_RolePermission.RoleID, _RolePermission.PermissionID);
            }
        }

        literalMessage.Text = AppUtils.Alert("success", "Thành công!", "Bạn đã cập nhật quyền thành công.");
    }
}