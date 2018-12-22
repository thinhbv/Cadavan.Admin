using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Libs.Security;

public partial class Pages_Security_Functions_List : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AppUtils.CheckLogin();
        Title = Title + " - Danh sách quyền hệ thống";
        if (!IsPostBack) BindData();
    }

    private void BindData()
    {
        var _Function = new Functions();
        rptList.DataSource = _Function.GetList(Convert.ToInt32(drpActive.SelectedValue), Convert.ToInt32(drpDisplay.SelectedValue));
        rptList.DataBind();
    }

    protected void btApply_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < rptList.Items.Count; i++)
        {
            var _Functions = new Functions();
            CheckBox cbxActive = (CheckBox)rptList.Items[i].FindControl("cbxActive");
            CheckBox cbxDisplay = (CheckBox)rptList.Items[i].FindControl("cbxDisplay");
            Label lblFunctionID = (Label)rptList.Items[i].FindControl("lblFunctionID");
            _Functions.FunctionID = Convert.ToInt32(lblFunctionID.Text);
            _Functions = _Functions.Get();

            _Functions.IsActive = cbxActive.Checked;
            _Functions.IsDisplay = cbxDisplay.Checked;
            _Functions.Update();
        }
        BindData();
    }

    protected void btView_Click(object sender, EventArgs e)
    {
        BindData();
    }

    protected void btAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect(Constant.ADMIN_PATH + Resources.Url.FunctionsAdd);
    }

}
