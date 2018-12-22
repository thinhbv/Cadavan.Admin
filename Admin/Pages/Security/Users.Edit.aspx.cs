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

public partial class Pages_Security_Users_Edit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AppUtils.CheckLogin();

        if (IsPostBack) return;
        GetDropDownList();
        init();
    }

    private void GetDropDownList()
    {
        var _Group = new Groups();
        drpGroup.DataSource = _Group.GetList();
        drpGroup.DataBind();
        drpGroup.Items.Insert(0, new ListItem("Nhóm người dùng:", "0"));
    }

    private void init()
    {
        var _User = new Users();
        _User = _User.Get(AppUtils.Request("id"));
        if (_User == null) Response.Redirect(Constant.ADMIN_PATH + Resources.Url.UsersList);

        txtEmail.Text = _User.Email;
        txtFullName.Text = _User.FullName;
        chkIsActive.Checked = Convert.ToBoolean(_User.Status);
        drpGroup.SelectedValue = _User.GroupID.ToString();

        // Gán quyền
        var _Function = new Functions();
        rptFunctionList.DataSource = _Function.GetList();
        rptFunctionList.DataBind();

        var _UserFunction = new UserFunction();
        List<UserFunction> list = _UserFunction.GetList(_User.UserID);
        for (int i = 0; i < rptFunctionList.Items.Count; i++)
        {
            CheckBox cbx = (CheckBox)rptFunctionList.Items[i].FindControl("cbxRole");
            Label lbl = (Label)rptFunctionList.Items[i].FindControl("lblFunctionID");
            int functionID = Convert.ToInt32(lbl.Text);
            for (int j = 0; j < list.Count; j++)
            {
                _UserFunction = list[j];
                if (functionID == _UserFunction.FunctionID)
                {
                    cbx.Checked = true;
                    break;
                }
            }
        }
    }

    protected void btUpdate_Click(object sender, EventArgs e)
    {
        var _User = new Users() { UserID = AppUtils.Request("id") };
        _User = _User.Get();

        if (txtPassword.Text.Length > 0)
        {
            _User.Password = Encrypts.MD5(txtPassword.Text);
        }

        _User.FullName = txtFullName.Text;
        _User.Status = Convert.ToInt32(chkIsActive.Checked);
        _User.GroupID = Convert.ToInt32(drpGroup.SelectedValue);
        _User.Update();
        Response.Redirect(Constant.ADMIN_PATH + Resources.Url.UsersList);
    }

    protected void btCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect(Constant.ADMIN_PATH + Resources.Url.UsersList);
    }

    protected void btApply_Click(object sender, EventArgs e)
    {
        int userID = AppUtils.Request("id");
        var _UserFunction = new UserFunction();
        List<UserFunction> list = _UserFunction.GetList(userID);
        for (int i = 0; i < rptFunctionList.Items.Count; i++)
        {
            CheckBox cbx = (CheckBox)rptFunctionList.Items[i].FindControl("cbxRole");
            Label lbl = (Label)rptFunctionList.Items[i].FindControl("lblFunctionID");
            int functionID = Convert.ToInt32(lbl.Text);

            _UserFunction.Update(userID, functionID, Convert.ToInt32(cbx.Checked));
        }
    }
}
