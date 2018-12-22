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
using System.IO;
using Libs.Content;

public partial class Pages_Content_Gallery : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AppUtils.CheckLogin();
        Title = Title + " - Photo gallery";

        if (IsPostBack) return;
        init();
        BindData();
    }

    private void init()
    {
        drpUser.Items.Clear();
        drpUser.Items.Add(new ListItem("Của bạn", AppUtils.UserID().ToString()));
        drpUser.Items.Add(new ListItem("Tất cả", "0"));

    }

    private void BindData()
    {
        MediaFile _MediaFile = new MediaFile();
        int total = 0;
        int userID = Convert.ToInt32(drpUser.SelectedValue);
        string keyword = txtKeyword.Text.Trim();
        int pageIndex = Convert.ToInt32(drpPage.SelectedValue);
        int pageSize = 49;
        rptPhotoList.DataSource = _MediaFile.PhotoSearch("", userID, keyword, pageIndex, pageSize, ref total);
        rptPhotoList.DataBind();

        lblTotal.Text = total.ToString();
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

    protected void btUpload_Click(object sender, EventArgs e)
    {
        if (!AppUtils.CheckPath()) Message.Alert(Page, "Không tạo được thư mục!");

        if (fuFileUpload.PostedFile == null || fuFileUpload.PostedFile.ContentLength == 0) return;

        MediaFile _MediaFile = new MediaFile();
        _MediaFile.Name = AppUtils.MediaFileName(fuFileUpload.PostedFile.FileName.ToLower());
        _MediaFile.Ext = Path.GetExtension(_MediaFile.Name).Replace(".", "");
        _MediaFile.Path = DateTime.Now.ToString("yyyy/MM/dd/") + _MediaFile.Name;
        _MediaFile.Size = fuFileUpload.PostedFile.ContentLength;
        _MediaFile.UserID = AppUtils.UserID();
        _MediaFile.Description = txtDescription.Text.Trim();
        _MediaFile.Tags = txtTags.Text.Trim();

        try
        {
            fuFileUpload.SaveAs(Server.MapPath(Constant.MEDIA_PATH + _MediaFile.Path));
            _MediaFile.Add();
            txtKeyword.Text = "";
            BindData();
        }
        catch
        {
            Message.Alert(Page, "Có lỗi khi upload file!");
        }

        txtPath.Text = Constant.MEDIA_URL + _MediaFile.Path;
        imgMediaUpload.ImageUrl = Constant.MEDIA_URL + _MediaFile.Path;
        Response.Redirect(Constant.ADMIN_PATH + Resources.Url.Gallery);
    }

    protected void btApply_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < rptPhotoList.Items.Count; i++)
        {
            CheckBox cbx = (CheckBox)rptPhotoList.Items[i].FindControl("cbxAction");
            if (cbx.Checked)
            {
                Label lbl = (Label)rptPhotoList.Items[i].FindControl("lblFileID");
                MediaFile _MediaFile = new MediaFile() { FileID = Convert.ToInt32(lbl.Text) };
                _MediaFile = _MediaFile.Get();
                lblFileID.Text = _MediaFile.FileID.ToString();
                imgMediaUpload.ImageUrl = Constant.MEDIA_URL + _MediaFile.Path;
                txtPath.Text = Constant.MEDIA_URL + _MediaFile.Path;
                txtDescription.Text = _MediaFile.Description;
                txtTags.Text = _MediaFile.Tags;
                Response.Redirect(Constant.ADMIN_PATH + Resources.Url.Gallery);
            }
        }
        Message.Alert(Page, "Bạn chưa chọn ảnh!");
    }

    protected void btSave_Click(object sender, EventArgs e)
    {
        MediaFile _MediaFile = new MediaFile() { FileID = Convert.ToInt32(lblFileID.Text) };
        _MediaFile = _MediaFile.Get();
        _MediaFile.Description = txtDescription.Text.Trim();
        _MediaFile.Tags = txtTags.Text.Trim();
        _MediaFile.Update();
        Response.Redirect(Constant.ADMIN_PATH + Resources.Url.Gallery);
    }

    protected void btCancel_Click(object sender, EventArgs e)
    {
        imgMediaUpload.ImageUrl = "";
        txtPath.Text = "";
        txtDescription.Text = "";
        txtTags.Text = "";
        btSave.Visible = false;
        btUpload.Visible = true;
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