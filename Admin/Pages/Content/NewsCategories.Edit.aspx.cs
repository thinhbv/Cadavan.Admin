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
using Libs.Content;

public partial class Pages_Content_NewsCategories_Edit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AppUtils.CheckLogin();
        Title = Title + " - Cập nhật chuyên mục";
        if (IsPostBack) return;
        GetDrpFather();
        init();
    }

    private void GetDrpFather()
    {
        var _Cate = new NewsCategories();
        drpFather.DataSource = _Cate.GetList();
        drpFather.DataBind();
        drpFather.Items.Insert(0, new ListItem("N/A", "0"));
    }

    private void GetDrpOrder()
    {
        drpOrder.Items.Clear();
        drpOrder.Items.Insert(0, new ListItem("N/A (0)", "0"));
        var _Cate = new NewsCategories();
        List<NewsCategories> list = _Cate.GetList(Convert.ToInt32(drpFather.SelectedValue));
        for (int i = 0; i < list.Count; i++)
        {
            _Cate = list[i];
            drpOrder.Items.Add(new ListItem(_Cate.Alias + " (" + _Cate.Order.ToString() + ")", _Cate.Order.ToString()));
        }
    }

    private void init()
    {
        var _Cate = new NewsCategories() { CateID = AppUtils.Request("id") };
        _Cate = _Cate.Get();
        if (_Cate == null) Response.Redirect(Constant.ADMIN_PATH + Resources.Url.NewsCategoriesList);
        txtName.Text = _Cate.Name;
        txtAlias.Text = _Cate.Alias;
        txtUrl.Text = _Cate.Url;
        drpFather.SelectedValue = _Cate.FatherID.ToString();
        txtNote.Text = _Cate.Note;
        cbxIsActive.Checked = _Cate.IsDisplay;

        GetDrpOrder();
        drpOrder.SelectedValue = _Cate.Order.ToString();
    }

    protected void btUpdate_Click(object sender, EventArgs e)
    {
        var _Cate = new NewsCategories() { CateID = AppUtils.Request("id") };
        _Cate = _Cate.Get();
        _Cate.Name = txtName.Text.Trim();
        _Cate.Alias = txtAlias.Text.Trim();
        _Cate.Url = txtUrl.Text.Trim();
        _Cate.FatherID = Convert.ToInt32(drpFather.SelectedValue);
        if (Convert.ToInt32(drpOrder.SelectedValue) != _Cate.Order) _Cate.Order = Convert.ToInt32(drpOrder.SelectedValue) + 1;
        _Cate.Note = txtNote.Text.Trim();
        _Cate.IsDisplay = cbxIsActive.Checked;
        _Cate.Update();

        Response.Redirect(Constant.ADMIN_PATH + Resources.Url.NewsCategoriesList);
    }

    protected void btDelete_Click(object sender, EventArgs e)
    {
        Response.Redirect(Constant.ADMIN_PATH + Resources.Url.NewsCategoriesList);
    }

    protected void btCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect(Constant.ADMIN_PATH + Resources.Url.NewsCategoriesList);
    }

    protected void drpFather_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetDrpOrder();
    }
}
