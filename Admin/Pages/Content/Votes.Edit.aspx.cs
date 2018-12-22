using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Libs.Content;

public partial class Pages_Content_Votes_Edit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AppUtils.CheckLogin();
        Title = Constant.TITLE + " - Cập nhật thăm dò";
        if (!IsPostBack)
        {
            init();
        }

    }

    private void init()
    {
        var _Vote = new Votes() { VoteID = AppUtils.Request("id") };
        _Vote = _Vote.Get();
        if (_Vote == null) Response.Redirect(Constant.ADMIN_PATH + Resources.Url.VotesList);
        txtTitle.Text = _Vote.Title;
        cbxIsActive.Checked = _Vote.IsActive;
        txtExpireTime.Text = _Vote.ExpireTime.ToString();
        txtCount.Text = _Vote.Count.ToString();

        BindData();
    }

    protected void btUpdate_Click(object sender, EventArgs e)
    {
        var _Vote = new Votes() { VoteID = AppUtils.Request("id") };
        _Vote = _Vote.Get();
        _Vote.Title = txtTitle.Text.Trim();
        _Vote.IsActive = cbxIsActive.Checked;
        _Vote.ExpireTime = Convert.ToDateTime(txtExpireTime.Text);
        _Vote.Count = Convert.ToInt32(txtCount.Text);
        _Vote.Update();
    }

    protected void btDelete_Click(object sender, EventArgs e)
    {
        var _Vote = new Votes() { VoteID = AppUtils.Request("id") };
        _Vote.Delete();
        Response.Redirect(Constant.ADMIN_PATH + Resources.Url.VotesList);
    }

    protected void btCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect(Constant.ADMIN_PATH + Resources.Url.VotesList);
    }

    private void BindData()
    {
        var _VoteQuestion = new VoteQuestion();
        rptList.DataSource = _VoteQuestion.GetList(AppUtils.Request("id"));
        rptList.DataBind();
    }

    protected void btAdd_Click(object sender, EventArgs e)
    {
        var _VoteQuestion = new VoteQuestion();
        int voteID = AppUtils.Request("id");
        if (txtAddName.Text.Trim().Length > 0 && txtAddCount.Text.Trim().Length > 0)
        {
            _VoteQuestion.VoteID = voteID;
            _VoteQuestion.Name = txtAddName.Text.Trim();
            _VoteQuestion.Count = Convert.ToInt32(txtAddCount.Text);
            _VoteQuestion.Add();
        }

        for (int i = 0; i < rptList.Items.Count; i++)
        {
            CheckBox cbxCheck = (CheckBox)rptList.Items[i].FindControl("cbxCheck");
            TextBox txtUpdateName = (TextBox)rptList.Items[i].FindControl("txtName");
            TextBox txtUpdateCount = (TextBox)rptList.Items[i].FindControl("txtCount");
            Label lblQuestionID = (Label)rptList.Items[i].FindControl("lblQuestionID");

            _VoteQuestion.QuestionID = Convert.ToInt32(lblQuestionID.Text);

            if (cbxCheck.Checked)
            {
                _VoteQuestion.Delete();
            }
            else
            {
                _VoteQuestion = _VoteQuestion.Get();
                _VoteQuestion.Name = txtUpdateName.Text.Trim();
                _VoteQuestion.Count = Convert.ToInt32(txtUpdateCount.Text);
                _VoteQuestion.Update();
            }
        }

        BindData();
        txtAddName.Text = "";
        txtAddCount.Text = "0";
    }

}