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
using Libs.Security;

public partial class Pages_Content_News_Royalty : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AppUtils.CheckLogin();
        if (!IsPostBack)
        {
            init();
            BindData();
        }
    }

    private void init()
    {
        drpAuthor.DataSource = new Users().GetList();
        drpAuthor.DataBind();
        drpAuthor.Items.Insert(0, new ListItem("Người đăng:", "0"));

        drpYear.Items.Add(new ListItem("Năm:", "0"));
        for (int i = 2012; i <= DateTime.Now.Year; i++)
        {
            drpYear.Items.Add(new ListItem(i.ToString()));
        }

        drpMonth.Items.Add(new ListItem("Tháng:", "0"));
        for (int i = 1; i <= 12; i++)
        {
            drpMonth.Items.Add(new ListItem(i.ToString()));
        }

        drpDay.Items.Add(new ListItem("Ngày:", "0"));
        for (int i = 1; i <= 31; i++)
        {
            drpDay.Items.Add(new ListItem(i.ToString()));
        }
    }

    private void BindData()
    {
        NewsRoyalties _NewsRoyalties = new NewsRoyalties();
        int year = Convert.ToInt32(drpYear.SelectedValue);
        int month = Convert.ToInt32(drpMonth.SelectedValue);
        int day = Convert.ToInt32(drpDay.SelectedValue);
        int totalRecord = 0;
        int totalRoyalty = 0;
        int pageSize = Convert.ToInt32(drpPageSize.SelectedValue);
        int pageIndex = Convert.ToInt32(drpPage.SelectedValue);
        int userID = Convert.ToInt32(drpAuthor.SelectedValue);
        rptList.DataSource = _NewsRoyalties.Report(year, month, day, userID, pageIndex, pageSize, ref totalRecord, ref totalRoyalty);
        rptList.DataBind();

        lblTotalRecord.Text = "Bài viết: " + totalRecord.ToString();
        lblTotalRoyalty.Text = "Nhuận bút: " + totalRoyalty.ToString("#,#").Replace(",", ".");
        totalRecord = (totalRecord - 1) / pageSize + 1;
        if (totalRecord == 0) totalRecord = 1;
        drpPage.Items.Clear();
        for (int i = 1; i <= totalRecord; i++)
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

    protected void btSave_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < rptList.Items.Count; i++)
        {
            TextBox txtRoyalties = (TextBox)rptList.Items[i].FindControl("txtRoyalties");
            TextBox txtPoints = (TextBox)rptList.Items[i].FindControl("txtPoints");
            TextBox txtClass = (TextBox)rptList.Items[i].FindControl("txtClass");
            TextBox txtFullName = (TextBox)rptList.Items[i].FindControl("txtFullName");
            Label lbl = (Label)rptList.Items[i].FindControl("lblNewsID");

            NewsRoyalties _NewsRoyalties = new NewsRoyalties() { NewsID = Convert.ToInt32(lbl.Text) };
            _NewsRoyalties = _NewsRoyalties.Get();
            _NewsRoyalties.Royalties = Convert.ToInt32(txtRoyalties.Text);
            _NewsRoyalties.Points = Convert.ToInt32(txtPoints.Text);
            _NewsRoyalties.Class = txtClass.Text.Trim();
            _NewsRoyalties.FullName = txtFullName.Text.Trim();
            _NewsRoyalties.Update();
        }
    }
}
