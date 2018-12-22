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

public partial class Pages_Content_News_Log : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AppUtils.CheckLogin();
        Title = Title + " - Lịch sử cập nhật tin bài";
        if (!IsPostBack)
        {
            BindData();
        }
    }

    private void BindData()
    {
        int newsID = AppUtils.Request("newsid");
        var _NewsAdmin = new NewsAdmin();
        rptList.DataSource = _NewsAdmin.GetLog(newsID);
        rptList.DataBind();
    }
}
