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
using Libs.Security;

public partial class Pages_Content_News_Search : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AppUtils.CheckLogin();
        Title = Title + " - Tìm kiếm bài viết";

        if (IsPostBack) return;
        init();
    }

    private void init()
    {
        drpAuthor.DataSource = new Users().GetList();
        drpAuthor.DataBind();
        drpAuthor.Items.Insert(0, new ListItem("Tác giả:", "0"));

        drpCate.DataSource = new NewsCategories().GetListDrp();
        drpCate.DataBind();
        drpCate.Items.Insert(0, new ListItem("Chuyên mục:", "0"));
    }

    private void BindData()
    {
        int newsID = 0;
        if (Int32.TryParse(txtKeyword.Text.Trim(), out newsID))
        {
            Response.Redirect(Constant.ADMIN_PATH + Resources.Url.NewsEdit + "?id=" + newsID.ToString());
        }
        else
        {
            int cateID = Convert.ToInt32(drpCate.SelectedValue);
            int userID = Convert.ToInt32(drpAuthor.SelectedValue);
            int status = 3;
            int total = 0;
            int pageSize = Convert.ToInt32(drpPageSize.SelectedValue);
            int pageIndex = Convert.ToInt32(drpPage.SelectedValue);


            var _NewsAdmin = new NewsAdmin();
            rptList.DataSource = _NewsAdmin.Search(txtKeyword.Text.Trim(), cateID, userID, status, pageIndex, pageSize, ref total);
            rptList.DataBind();

            lblTotal.Text = "(" + total.ToString() + ")";
            total = (total - 1) / pageSize + 1;
            if (total == 0) total = 1;
            drpPage.Items.Clear();
            for (int i = 1; i <= total; i++)
            {
                drpPage.Items.Add(new ListItem(i.ToString()));
            }

            try
            {
                drpPage.SelectedValue = pageIndex.ToString();
            }
            catch
            {
            }
        }
    }

    protected void btSearch_Click(object sender, EventArgs e)
    {
        BindData();
    }

    protected void btPage_Click(object sender, EventArgs e)
    {
        BindData();
    }
}
