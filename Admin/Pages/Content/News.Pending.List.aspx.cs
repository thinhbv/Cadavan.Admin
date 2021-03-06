﻿using System;
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

public partial class Pages_Content_News_Pending_List : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AppUtils.CheckLogin();
        Title = Title + " - Tin bài chờ duyệt";
        if (IsPostBack) return;

        init();
        BindData();
    }

    private void init()
    {
        drpCate.DataSource = new NewsCategories().GetListDrp();
        drpCate.DataBind();
        drpCate.Items.Insert(0, new ListItem("Chuyên mục:", "0"));
    }

    private void BindData()
    {
        var _NewsAdmin = new NewsAdmin();
        int total = 0;
        int pageSize = Convert.ToInt32(drpPageSize.SelectedValue);
        int pageIndex = Convert.ToInt32(drpPage.SelectedValue);
        int cateID = Convert.ToInt32(drpCate.SelectedValue);
        int userID = 0;
        rptList.DataSource = _NewsAdmin.GetTable(cateID, userID, 2, pageIndex, pageSize, ref total);
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
}
