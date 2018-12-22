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

public partial class Pages_Content_NewsCategories_Add : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AppUtils.CheckLogin();
        Title = Title + " - Thêm mới chuyên mục";
        if (IsPostBack) return;
        GetDrpFather();
        GetDrpOrder();
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

    protected void btAdd_Click(object sender, EventArgs e)
    {
        var _Cate = new NewsCategories();
        _Cate.Name = txtName.Text.Trim();
        _Cate.Alias = txtAlias.Text.Trim();
        _Cate.Url = txtUrl.Text.Trim();
        _Cate.FatherID = Convert.ToInt32(drpFather.SelectedValue);
        _Cate.Order = Convert.ToInt32(drpOrder.SelectedValue) + 1;
        _Cate.Note = txtNote.Text.Trim();
        _Cate.IsDisplay = cbxIsActive.Checked;
        _Cate.Add();
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