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

public partial class Pages_Content_NewsForum_Edit : System.Web.UI.Page
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
        NewsForum _NewsForum = new NewsForum() { ForumID = AppUtils.Request("id") };
        _NewsForum = _NewsForum.Get();
        if (_NewsForum.ForumID == 0) Response.Redirect(Constant.ADMIN_PATH + Resources.Url.SignOut);

        txtTitle.Text = _NewsForum.Title;
        lblCreatedTime.Text = _NewsForum.CreatedTime.ToString("dd/MM/yyyy HH'h'mm");
        txtContent.Text = _NewsForum.Content;
        txtHeader.Text = _NewsForum.Header;
        txtEmail.Text = _NewsForum.Email;
        hplNewsForum.NavigateUrl = Constant.ADMIN_PATH + Resources.Url.NewsForumList + "?newsid=" + _NewsForum.NewsID.ToString();
        cbxStatus.Checked = _NewsForum.Status == 2;

        News _News = new News() { NewsID = _NewsForum.NewsID };
        _News = _News.Get();
        lblNewsTitle.Text = _News.Title;
    }

    protected void btUpdate_Click(object sender, EventArgs e)
    {
        NewsForum _NewsForum = new NewsForum() { ForumID = AppUtils.Request("id") };
        _NewsForum = _NewsForum.Get();
        _NewsForum.Title = txtTitle.Text.Trim();
        _NewsForum.Content = txtContent.Text.Trim();
        _NewsForum.Header = txtHeader.Text.Trim();
        _NewsForum.Email = txtEmail.Text.Trim().ToLower();
        _NewsForum.Status = cbxStatus.Checked ? 2 : 1;
        _NewsForum.Update();
        Response.Redirect(Request["u"]);
    }

    protected void btDelete_Click(object sender, EventArgs e)
    {
        NewsForum _NewsForum = new NewsForum() { ForumID = AppUtils.Request("id") };
        _NewsForum.Delete();
        Response.Redirect(Request["u"]);
    }

    protected void btCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request["u"]);
    }

}
