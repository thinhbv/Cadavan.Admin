using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Libs.Security;

public partial class Pages_Security_Groups_Edit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AppUtils.CheckLogin();

        if (!IsPostBack)
        {
            init();
        }
    }

    private void init()
    {
        var _Group = new Groups();
        _Group = _Group.Get(AppUtils.Request("id"));
        if (_Group == null) Response.Redirect(Constant.ADMIN_PATH + Resources.Url.GroupsList);

        txtName.Text = _Group.Name;
        txtOrder.Text = _Group.Order.ToString();
        txtDescription.Text = _Group.Description;

        // Gán quyền
        var _Function = new Functions();
        rptList.DataSource = _Function.GetList();
        rptList.DataBind();

        var _GroupFunction = new GroupFunction();
        List<GroupFunction> list = _GroupFunction.GetList(_Group.GroupID);
        for (int i = 0; i < rptList.Items.Count; i++)
        {
            CheckBox cbx = (CheckBox)rptList.Items[i].FindControl("cbxRole");
            Label lbl = (Label)rptList.Items[i].FindControl("lblFunctionID");
            int functionID = Convert.ToInt32(lbl.Text);
            for (int j = 0; j < list.Count; j++)
            {
                _GroupFunction = list[j];
                if (functionID == _GroupFunction.FunctionID)
                {
                    cbx.Checked = true;
                    break;
                }
            }
        }
    }

    protected void btUpdate_Click(object sender, EventArgs e)
    {
        var _Group = new Groups() { GroupID = AppUtils.Request("id") };
        _Group = _Group.Get();

        _Group.Name = txtName.Text.Trim();
        _Group.Order = Convert.ToInt32(txtOrder.Text);
        _Group.Description = txtDescription.Text.Trim();
        _Group.Update();
        Response.Redirect(Constant.ADMIN_PATH + Resources.Url.GroupsList);
    }

    protected void btCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect(Constant.ADMIN_PATH + Resources.Url.GroupsList);
    }

    protected void btApply_Click(object sender, EventArgs e)
    {
        int groupID = AppUtils.Request("id");
        var _GroupFunction = new GroupFunction();
        List<GroupFunction> list = _GroupFunction.GetList(groupID);
        for (int i = 0; i < rptList.Items.Count; i++)
        {
            CheckBox cbx = (CheckBox)rptList.Items[i].FindControl("cbxRole");
            Label lbl = (Label)rptList.Items[i].FindControl("lblFunctionID");
            int functionID = Convert.ToInt32(lbl.Text);

            _GroupFunction.Update(groupID, functionID, Convert.ToInt32(cbx.Checked));
        }
    }
}