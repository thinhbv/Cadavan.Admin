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
using Libs.Content;

public partial class Pages_Content_NewsCategories_List : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AppUtils.CheckLogin();
        Title = Title + " - Danh sách chuyên mục";
        if (!IsPostBack) BindData();
    }

    private void BindData()
    {
        var _Cate = new NewsCategories();
        rptList.DataSource = _Cate.GetList();
        rptList.DataBind();
    }

    protected void btAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect(Constant.ADMIN_PATH + Resources.Url.NewsCategoriesAdd);
    }
}
