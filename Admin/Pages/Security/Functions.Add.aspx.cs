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

public partial class Pages_Security_Functions_Add : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AppUtils.CheckLogin();
        Title = Title + " - Thêm mới quyền hệ thống";
        if (!IsPostBack) GetDropDownList();
    }

    private void GetDropDownList()
    {
        var _Function = new Functions();

        drpFather.DataSource = _Function.GetSunList(0);
        drpFather.DataBind();
        drpFather.Items.Insert(0, new ListItem("N/A", "0"));

        List<Functions> list = _Function.GetSunList(0);
        for (int i = 0; i < list.Count; i++)
        {
            _Function = list[i];
            _Function.Alias = _Function.Alias + " (" + _Function.Order + ")";
        }
        drpOrder.DataSource = list;
        drpOrder.DataBind();
        drpOrder.Items.Insert(0, new ListItem("N/A (0)", "0"));
    }

    protected void drpFather_SelectedIndexChanged(object sender, EventArgs e)
    {
        var _Function = new Functions();
        List<Functions> list = _Function.GetSunList(Convert.ToInt32(drpFather.SelectedValue));
        for (int i = 0; i < list.Count; i++)
        {
            _Function = list[i];
            _Function.Alias = _Function.Alias + " (" + _Function.Order + ")";
        }
        drpOrder.DataSource = list;
        drpOrder.DataBind();
        drpOrder.Items.Insert(0, new ListItem("N/A (0)", "0"));
    }

    protected void btAdd_Click(object sender, EventArgs e)
    {
        var _Function = new Functions();
        _Function.Name = txtName.Text.Trim();
        _Function.Alias = txtAlias.Text.Trim();
        _Function.Url = txtUrl.Text.Trim().ToLower();
        _Function.FatherID = Convert.ToInt32(drpFather.SelectedValue);
        _Function.Note = txtNote.Text.Trim();
        _Function.Order = Convert.ToInt32(drpOrder.SelectedValue) + 1;
        _Function.IsActive = cbxIsActive.Checked;
        _Function.IsDisplay = cbxIsDisplay.Checked;
        _Function.Add();

        Response.Redirect(Constant.ADMIN_PATH + Resources.Url.FunctionsList);
    }

    protected void btCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect(Constant.ADMIN_PATH + Resources.Url.FunctionsList);
    }
}
