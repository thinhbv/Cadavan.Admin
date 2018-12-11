using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Libs.Content;

public partial class Pages_Content_News_Add : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AppUtils.CheckSecurity();

        if (!IsPostBack)
        {
            Title = "BusTime - Thêm mới bài viết";
        }

    }

    protected void btSubmit_Click(object sender, EventArgs e)
    {
        News _News = new News();
        _News.Title = txtTitle.Text.Trim();
        _News.Lead = txtLead.Text.Trim();
        _News.UserID = AppUtils.UserID();

        _News.QuickAdd(_News.Title, _News.Lead, _News.UserID);

        if (_News.ReturnValue > 0)
        {
            Response.Redirect(Constant.ADMIN_PATH + Resources.Url.NewsEdit);
        }
        else
        {
            switch (_News.ReturnValue)
            {
                default:
                    literalMessage.Text = AppUtils.Alert("warning", "Lỗi hệ thống!", "Có lỗi khi thêm mới bài viết.");
                    break;
            }
        }

    }
}