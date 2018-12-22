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

public partial class Pages_Content_NewsForum_List : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AppUtils.CheckLogin();
        if (IsPostBack) return;

        init();
        BindData();
    }

    private void init()
    {

    }

    private void BindData()
    {
        NewsForum _NewsForum = new NewsForum();
        int newsID = AppUtils.Request("newsid");
        int status = Convert.ToInt32(drpStatus.SelectedValue);
        int pageIndex = Convert.ToInt32(drpPage.SelectedValue);
        int pageSize = Convert.ToInt32(drpPageSize.SelectedValue); ;
        int total = 0;
        rptList.DataSource = _NewsForum.GetList(newsID, status, pageIndex, pageSize, ref total);
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

    protected void btPage_Click(object sender, EventArgs e)
    {
        BindData();
    }

    protected void btView_Click(object sender, EventArgs e)
    {
        BindData();
    }

    protected string Path(string id)
    {
        if (id != "0" && id != "")
        {
            return string.Format("<a href=\"{0}\">{1}</a>", Resources.Url.MediaFileDownload + "?id=" + id, "download");
        }
        else
        {
            return "-";
        }
    }
}
