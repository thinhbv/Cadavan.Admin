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

public partial class Pages_Security_Functions_Edit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AppUtils.CheckLogin();
        Title = Title + " - Thêm mới quyền hệ thống";
        if (!IsPostBack)
        {
            btDelete.Attributes.Add("onclick", "return confirm('Bạn có đồng ý xóa?');");
            GetDropDownList();
            init();
        }
    }

    private void GetDropDownList()
    {
        var _Function = new Functions();

        drpFather.DataSource = _Function.GetSunList(0);
        drpFather.DataBind();
        drpFather.Items.Insert(0, new ListItem("N/A", "0"));
    }

    private void GetDropDownListOrder(int fatherID)
    {
        var _Function = new Functions();
        List<Functions> list = _Function.GetSunList(fatherID);
        for (int i = 0; i < list.Count; i++)
        {
            _Function = list[i];
            _Function.Alias = _Function.Alias + " (" + _Function.Order + ")";
        }
        drpOrder.DataSource = list;
        drpOrder.DataBind();
        drpOrder.Items.Insert(0, new ListItem("N/A (0)", "0"));
    }

    private void init()
    {
        var _Function = new Functions() { FunctionID = AppUtils.Request("id") };
        _Function = _Function.Get();
        if (_Function == null) Response.Redirect(Constant.ADMIN_PATH + Resources.Url.FunctionsList);

        txtName.Text = _Function.Name;
        txtAlias.Text = _Function.Alias;
        txtUrl.Text = _Function.Url;
        txtNote.Text = _Function.Note;
        drpFather.SelectedValue = _Function.FatherID.ToString();
        cbxIsDisplay.Checked = _Function.IsDisplay;
        cbxIsActive.Checked = _Function.IsActive;
        GetDropDownListOrder(_Function.FatherID);
        drpOrder.SelectedValue = _Function.Order.ToString();
    }

    protected void drpFather_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetDropDownListOrder(Convert.ToInt32(drpFather.SelectedValue));
    }

    protected void btUpdate_Click(object sender, EventArgs e)
    {
        var _Function = new Functions() { FunctionID = AppUtils.Request("id") };
        _Function = _Function.Get();
        _Function.Name = txtName.Text.Trim();
        _Function.Alias = txtAlias.Text.Trim();
        _Function.Url = txtUrl.Text.Trim().ToLower();
        _Function.FatherID = Convert.ToInt32(drpFather.SelectedValue);
        _Function.Note = txtNote.Text.Trim();
        if (_Function.Order != Convert.ToInt32(drpOrder.SelectedValue)) _Function.Order = Convert.ToInt32(drpOrder.SelectedValue) + 1;
        _Function.IsActive = cbxIsActive.Checked;
        _Function.IsDisplay = cbxIsDisplay.Checked;
        _Function.Update();

        Response.Redirect(Constant.ADMIN_PATH + Resources.Url.FunctionsList);
    }

    protected void btDelete_Click(object sender, EventArgs e)
    {
        Functions _Function = new Functions() { FunctionID = AppUtils.Request("id") };
        _Function.Delete();
        Response.Redirect(Constant.ADMIN_PATH + Resources.Url.FunctionsList);
    }

    protected void btCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect(Constant.ADMIN_PATH + Resources.Url.FunctionsList);
    }
}
