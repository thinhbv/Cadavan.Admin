using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Libs.Content;

public partial class Pages_Content_Votes_Add : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AppUtils.CheckLogin();
        Title = Constant.TITLE + " - Thêm mới thăm dò";
        if (!IsPostBack)
        {
            txtExpireTime.Text = DateTime.Now.AddDays(7).ToString();
        }
    }

    protected void btAdd_Click(object sender, EventArgs e)
    {
        var _Vote = new Votes();
        _Vote.Title = txtTitle.Text.Trim();
        _Vote.IsActive = cbxIsActive.Checked;
        _Vote.ExpireTime = Convert.ToDateTime(txtExpireTime.Text);
        _Vote.UserID = AppUtils.UserID();
        _Vote.Add();
        Response.Redirect(Constant.ADMIN_PATH + Resources.Url.VotesEdit + "?id=" + _Vote.VoteID.ToString());
    }

    protected void btCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect(Constant.ADMIN_PATH + Resources.Url.VotesList);
    }
}