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

public partial class Pages_Content_News_Edit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AppUtils.CheckLogin();
        Title = Title + " - Cập nhật tin bài";

        if (IsPostBack) return;
        btDelete.Attributes.Add("onclick", "return confirm('Bạn có đồng ý xóa?');");
        GetDrpCate();
        GetDrpOrder();
        init();
    }

    private void init()
    {
        if (!AppUtils.CheckPath()) Message.Alert(Page, "Không tạo được thư mục!");

        News _News = new News() { NewsID = AppUtils.Request("id") };
        _News = _News.Get();

        if (_News == null || _News.Status < 2)
        {
            Response.Redirect(Constant.ADMIN_PATH + Resources.Url.SignOut);
        }

        txtTitle.Text = _News.Title;
        txtSubTitle.Text = _News.SubTitle;
        txtLead.Text = _News.Lead;
        txtSubLead.Text = _News.SubLead;
        ftbContent.Text = _News.Content;
        chkIsPhoto.Checked = _News.IsPhoto;
        chkIsVideo.Checked = _News.IsVideo;
        chkIsAudio.Checked = _News.IsAudio;
        txtPublishTime.Text = _News.PublishedTime.ToString();
        imgImageUrl.ImageUrl = Constant.MEDIA_PATH + _News.ImageUrl;
        txtTags.Text = _News.Tags;

        lblMediaPath.Text = _News.CreatedTime.ToString("yyyy/MM/dd/") + _News.NewsID.ToString() + "/";
        lblMediaPathFull.Text = Constant.MEDIA_PATH + lblMediaPath.Text;

        NewsPublish _NewsPublish = new NewsPublish();
        List<NewsPublish> list = _NewsPublish.GetList(_News.NewsID);
        var _NewsAdmin = new NewsAdmin();
        List<NewsAdmin> listNews;
        for (int i = 0; i < list.Count; i++)
        {
            _NewsPublish = (NewsPublish)list[i];
            string title = _News.Title;
            if (title.Length > 50) title = title.Substring(0, 50);
            switch (i)
            {
                case 0:
                    drpCate1.SelectedValue = _NewsPublish.CateID.ToString();

                    drpOrder1.Items.Clear();
                    drpOrder1.Items.Insert(0, new ListItem("Thứ tự:", "0"));
                    listNews = _NewsAdmin.GetList(Convert.ToInt32(drpCate1.SelectedValue), 100);
                    for (int j = 0; j < listNews.Count; j++)
                    {
                        _NewsAdmin = listNews[j];
                        if (_NewsAdmin.Title.Length > 50) _NewsAdmin.Title = _NewsAdmin.Title.Substring(0, 50) + "...";
                        drpOrder1.Items.Add(new ListItem("(" + _NewsAdmin.Order.ToString() + ") " + _NewsAdmin.Title, _NewsAdmin.Order.ToString()));
                    }
                    drpOrder1.SelectedValue = _NewsPublish.Order.ToString();
                    if (drpOrder1.SelectedIndex == 0)
                    {
                        drpOrder1.Items.Add(new ListItem("(" + _NewsPublish.Order.ToString() + ") " + title, _NewsPublish.Order.ToString()));
                        drpOrder1.SelectedValue = _NewsPublish.Order.ToString();
                    }
                    break;
                case 1:
                    drpCate2.SelectedValue = _NewsPublish.CateID.ToString();

                    drpOrder2.Items.Clear();
                    drpOrder2.Items.Insert(0, new ListItem("Thứ tự:", "0"));
                    listNews = _NewsAdmin.GetList(Convert.ToInt32(drpCate2.SelectedValue), 100);
                    for (int j = 0; j < listNews.Count; j++)
                    {
                        _NewsAdmin = listNews[j];
                        if (_NewsAdmin.Title.Length > 50) _NewsAdmin.Title = _NewsAdmin.Title.Substring(0, 50) + "...";
                        drpOrder2.Items.Add(new ListItem("(" + _NewsAdmin.Order.ToString() + ") " + _NewsAdmin.Title, _NewsAdmin.Order.ToString()));
                    }
                    drpOrder2.SelectedValue = _NewsPublish.Order.ToString();
                    if (drpOrder2.SelectedIndex == 0)
                    {
                        drpOrder2.Items.Add(new ListItem("(" + _NewsPublish.Order.ToString() + ") " + title, _NewsPublish.Order.ToString()));
                        drpOrder2.SelectedValue = _NewsPublish.Order.ToString();
                    }
                    break;
                case 2:
                    drpCate3.SelectedValue = _NewsPublish.CateID.ToString();

                    drpOrder3.Items.Clear();
                    drpOrder3.Items.Insert(0, new ListItem("Thứ tự:", "0"));
                    listNews = _NewsAdmin.GetList(Convert.ToInt32(drpCate3.SelectedValue), 100);
                    for (int j = 0; j < listNews.Count; j++)
                    {
                        _NewsAdmin = listNews[j];
                        if (_NewsAdmin.Title.Length > 50) _NewsAdmin.Title = _NewsAdmin.Title.Substring(0, 50) + "...";
                        drpOrder3.Items.Add(new ListItem("(" + _NewsAdmin.Order.ToString() + ") " + _NewsAdmin.Title, _NewsAdmin.Order.ToString()));
                    }
                    drpOrder3.SelectedValue = _NewsPublish.Order.ToString();
                    if (drpOrder3.SelectedIndex == 0)
                    {
                        drpOrder3.Items.Add(new ListItem("(" + _NewsPublish.Order.ToString() + ") " + title, _NewsPublish.Order.ToString()));
                        drpOrder3.SelectedValue = _NewsPublish.Order.ToString();
                    }
                    break;
                case 3:
                    drpCate4.SelectedValue = _NewsPublish.CateID.ToString();

                    drpOrder4.Items.Clear();
                    drpOrder4.Items.Insert(0, new ListItem("Thứ tự:", "0"));
                    listNews = _NewsAdmin.GetList(Convert.ToInt32(drpCate4.SelectedValue), 100);
                    for (int j = 0; j < listNews.Count; j++)
                    {
                        _NewsAdmin = listNews[j];
                        if (_NewsAdmin.Title.Length > 50) _NewsAdmin.Title = _NewsAdmin.Title.Substring(0, 50) + "...";
                        drpOrder4.Items.Add(new ListItem("(" + _NewsAdmin.Order.ToString() + ") " + _NewsAdmin.Title, _NewsAdmin.Order.ToString()));
                    }
                    drpOrder4.SelectedValue = _NewsPublish.Order.ToString();
                    if (drpOrder4.SelectedIndex == 0)
                    {
                        drpOrder4.Items.Add(new ListItem("(" + _NewsPublish.Order.ToString() + ") " + title, _NewsPublish.Order.ToString()));
                        drpOrder4.SelectedValue = _NewsPublish.Order.ToString();
                    }
                    break;
                case 4:
                    drpCate5.SelectedValue = _NewsPublish.CateID.ToString();

                    drpOrder5.Items.Clear();
                    drpOrder5.Items.Insert(0, new ListItem("Thứ tự:", "0"));
                    listNews = _NewsAdmin.GetList(Convert.ToInt32(drpCate5.SelectedValue), 100);
                    for (int j = 0; j < listNews.Count; j++)
                    {
                        _NewsAdmin = listNews[j];
                        if (_NewsAdmin.Title.Length > 50) _NewsAdmin.Title = _NewsAdmin.Title.Substring(0, 50) + "...";
                        drpOrder5.Items.Add(new ListItem("(" + _NewsAdmin.Order.ToString() + ") " + _NewsAdmin.Title, _NewsAdmin.Order.ToString()));
                    }
                    drpOrder5.SelectedValue = _NewsPublish.Order.ToString();
                    if (drpOrder5.SelectedIndex == 0)
                    {
                        drpOrder5.Items.Add(new ListItem("(" + _NewsPublish.Order.ToString() + ") " + title, _NewsPublish.Order.ToString()));
                        drpOrder5.SelectedValue = _NewsPublish.Order.ToString();
                    }
                    break;
                default:
                    break;
            }
        }

        // Tin liên quan
        NewsRelated _NewsRelated = new NewsRelated();
        rptRelatedList.DataSource = _NewsRelated.GetList(_News.NewsID);
        rptRelatedList.DataBind();

        ftbContent.ImageGalleryPath = lblMediaPathFull.Text;

        if (_News.Status == 3)
        {
            btPublish.Visible = false;
        }

        // Lấy danh sách ảnh
        BindMedia();

    }

    private void GetDrpCate()
    {
        List<NewsCategories> list = new NewsCategories().GetListDrp();
        drpCate1.DataSource = list;
        drpCate1.DataBind();
        drpCate1.Items.Insert(0, new ListItem("Chuyên mục:", "0"));

        drpCate2.DataSource = list;
        drpCate2.DataBind();
        drpCate2.Items.Insert(0, new ListItem("Chuyên mục:", "0"));

        drpCate3.DataSource = list;
        drpCate3.DataBind();
        drpCate3.Items.Insert(0, new ListItem("Chuyên mục:", "0"));

        drpCate4.DataSource = list;
        drpCate4.DataBind();
        drpCate4.Items.Insert(0, new ListItem("Chuyên mục:", "0"));

        drpCate5.DataSource = list;
        drpCate5.DataBind();
        drpCate5.Items.Insert(0, new ListItem("Chuyên mục:", "0"));
    }

    private void GetDrpOrder()
    {
        List<ListItem> list = new List<ListItem>();
        list.Add(new ListItem("Thứ tự:", "0"));
        for (int i = 1; i <= 100; i++)
        {
            list.Add(new ListItem(i.ToString()));
        }
        drpOrder1.DataSource = list;
        drpOrder1.DataBind();

        drpOrder2.DataSource = list;
        drpOrder2.DataBind();

        drpOrder3.DataSource = list;
        drpOrder3.DataBind();

        drpOrder4.DataSource = list;
        drpOrder4.DataBind();

        drpOrder5.DataSource = list;
        drpOrder5.DataBind();
    }

    protected void drpCate1_SelectedIndexChanged(object sender, EventArgs e)
    {
        drpOrder1.Items.Clear();
        drpOrder1.Items.Insert(0, new ListItem("Thứ tự:", "0"));

        if (drpCate1.SelectedValue == "0") return;
        var _NewsAdmin = new NewsAdmin();
        List<NewsAdmin> list = _NewsAdmin.GetList(Convert.ToInt32(drpCate1.SelectedValue), 100);
        for (int i = 0; i < list.Count; i++)
        {
            _NewsAdmin = list[i];
            if (_NewsAdmin.Title.Length > 50) _NewsAdmin.Title = _NewsAdmin.Title.Substring(0, 50) + "...";
            drpOrder1.Items.Add(new ListItem("(" + _NewsAdmin.Order.ToString() + ") " + _NewsAdmin.Title, _NewsAdmin.Order.ToString()));
            drpOrder1.DataBind();
        }
    }

    protected void drpCate2_SelectedIndexChanged(object sender, EventArgs e)
    {
        drpOrder2.Items.Clear();
        drpOrder2.Items.Insert(0, new ListItem("Thứ tự:", "0"));

        if (drpCate2.SelectedValue == "0") return;
        var _NewsAdmin = new NewsAdmin();
        List<NewsAdmin> list = _NewsAdmin.GetList(Convert.ToInt32(drpCate2.SelectedValue), 100);
        for (int i = 0; i < list.Count; i++)
        {
            _NewsAdmin = list[i];
            if (_NewsAdmin.Title.Length > 50) _NewsAdmin.Title = _NewsAdmin.Title.Substring(0, 50) + "...";
            drpOrder2.Items.Add(new ListItem("(" + _NewsAdmin.Order.ToString() + ") " + _NewsAdmin.Title, _NewsAdmin.Order.ToString()));
            drpOrder2.DataBind();
        }
    }

    protected void drpCate3_SelectedIndexChanged(object sender, EventArgs e)
    {
        drpOrder3.Items.Clear();
        drpOrder3.Items.Insert(0, new ListItem("Thứ tự:", "0"));

        if (drpCate3.SelectedValue == "0") return;
        var _NewsAdmin = new NewsAdmin();
        List<NewsAdmin> list = _NewsAdmin.GetList(Convert.ToInt32(drpCate3.SelectedValue), 100);
        for (int i = 0; i < list.Count; i++)
        {
            _NewsAdmin = list[i];
            if (_NewsAdmin.Title.Length > 50) _NewsAdmin.Title = _NewsAdmin.Title.Substring(0, 50) + "...";
            drpOrder3.Items.Add(new ListItem("(" + _NewsAdmin.Order.ToString() + ") " + _NewsAdmin.Title, _NewsAdmin.Order.ToString()));
            drpOrder3.DataBind();
        }
    }

    protected void drpCate4_SelectedIndexChanged(object sender, EventArgs e)
    {
        drpOrder4.Items.Clear();
        drpOrder4.Items.Insert(0, new ListItem("Thứ tự:", "0"));

        if (drpCate4.SelectedValue == "0") return;
        var _NewsAdmin = new NewsAdmin();
        List<NewsAdmin> list = _NewsAdmin.GetList(Convert.ToInt32(drpCate4.SelectedValue), 100);
        for (int i = 0; i < list.Count; i++)
        {
            _NewsAdmin = list[i];
            if (_NewsAdmin.Title.Length > 50) _NewsAdmin.Title = _NewsAdmin.Title.Substring(0, 50) + "...";
            drpOrder4.Items.Add(new ListItem("(" + _NewsAdmin.Order.ToString() + ") " + _NewsAdmin.Title, _NewsAdmin.Order.ToString()));
            drpOrder4.DataBind();
        }
    }

    protected void drpCate5_SelectedIndexChanged(object sender, EventArgs e)
    {
        drpOrder5.Items.Clear();
        drpOrder5.Items.Insert(0, new ListItem("Thứ tự:", "0"));

        if (drpCate5.SelectedValue == "0") return;
        var _NewsAdmin = new NewsAdmin();
        List<NewsAdmin> list = _NewsAdmin.GetList(Convert.ToInt32(drpCate5.SelectedValue), 100);
        for (int i = 0; i < list.Count; i++)
        {
            _NewsAdmin = list[i];
            if (_NewsAdmin.Title.Length > 50) _NewsAdmin.Title = _NewsAdmin.Title.Substring(0, 50) + "...";
            drpOrder5.Items.Add(new ListItem("(" + _NewsAdmin.Order.ToString() + ") " + _NewsAdmin.Title, _NewsAdmin.Order.ToString()));
            drpOrder5.DataBind();
        }
    }

    private void UpdatePublish()
    {
        int newsID = AppUtils.Request("id");
        NewsPublish _NewsPublish = new NewsPublish();
        _NewsPublish.Delete(newsID);
        if (drpCate1.SelectedValue != "0")
        {
            _NewsPublish.NewsID = newsID;
            _NewsPublish.CateID = Convert.ToInt32(drpCate1.SelectedValue);
            _NewsPublish.Order = Convert.ToInt32(drpOrder1.Text);
            _NewsPublish.Add();
        }

        if (drpCate2.SelectedValue != "0")
        {
            _NewsPublish.NewsID = newsID;
            _NewsPublish.CateID = Convert.ToInt32(drpCate2.SelectedValue);
            _NewsPublish.Order = Convert.ToInt32(drpOrder2.Text);
            _NewsPublish.Add();
        }

        if (drpCate3.SelectedValue != "0")
        {
            _NewsPublish.NewsID = newsID;
            _NewsPublish.CateID = Convert.ToInt32(drpCate3.SelectedValue);
            _NewsPublish.Order = Convert.ToInt32(drpOrder3.Text);
            _NewsPublish.Add();
        }


        if (drpCate4.SelectedValue != "0")
        {
            _NewsPublish.NewsID = newsID;
            _NewsPublish.CateID = Convert.ToInt32(drpCate4.SelectedValue);
            _NewsPublish.Order = Convert.ToInt32(drpOrder4.Text);
            _NewsPublish.Add();
        }

        if (drpCate5.SelectedValue != "0")
        {
            _NewsPublish.NewsID = newsID;
            _NewsPublish.CateID = Convert.ToInt32(drpCate5.SelectedValue);
            _NewsPublish.Order = Convert.ToInt32(drpOrder5.Text);
            _NewsPublish.Add();
        }
    }

    private void BindMedia()
    {
        var _NewsMedia = new NewsMedia();
        rptMediaList.DataSource = _NewsMedia.GetList(AppUtils.Request("id"));
        rptMediaList.DataBind();
    }

    protected void btSave_Click(object sender, EventArgs e)
    {
        if (drpCate1.SelectedValue == "0")
        {
            Message.Alert(Page, "Bạn chưa chọn chuyên mục xuất bản!");
            return;
        }

        News _News = new News() { NewsID = AppUtils.Request("id") };
        _News = _News.Get();

        _News.Title = txtTitle.Text.Trim();
        _News.SubTitle = txtSubTitle.Text.Trim();
        _News.ImageUrl = imgImageUrl.ImageUrl.Replace(Constant.MEDIA_PATH, "");
        _News.Lead = txtLead.Text.Trim();
        _News.SubLead = txtSubLead.Text.Trim();
        _News.Content = ftbContent.Text.Trim();
        _News.IsPhoto = chkIsPhoto.Checked;
        _News.IsVideo = chkIsVideo.Checked;
        _News.IsAudio = chkIsAudio.Checked;
        _News.PublishedTime = Convert.ToDateTime(txtPublishTime.Text);
        _News.CateID = Convert.ToInt32(drpCate1.SelectedValue);
        _News.UserID = AppUtils.UserID();
        _News.Tags = txtTags.Text.Trim();

        _News.Update();
        UpdatePublish();

        Redirect();
    }

    protected void btPubish_Click(object sender, EventArgs e)
    {
        if (drpCate1.SelectedValue == "0")
        {
            Message.Alert(Page, "Bạn chưa chọn chuyên mục xuất bản!");
            return;
        }

        News _News = new News() { NewsID = AppUtils.Request("id") };

        _News = _News.Get();

        _News.Title = txtTitle.Text.Trim();
        _News.SubTitle = txtSubTitle.Text.Trim();
        _News.ImageUrl = imgImageUrl.ImageUrl.Replace(Constant.MEDIA_PATH, "");
        _News.Lead = txtLead.Text.Trim();
        _News.SubLead = txtSubLead.Text.Trim();
        _News.Content = ftbContent.Text.Trim();
        _News.IsPhoto = chkIsPhoto.Checked;
        _News.IsVideo = chkIsVideo.Checked;
        _News.IsAudio = chkIsAudio.Checked;
        _News.PublishedTime = Convert.ToDateTime(txtPublishTime.Text);
        _News.CateID = Convert.ToInt32(drpCate1.SelectedValue);
        _News.Status = 3;
        _News.UserID = AppUtils.UserID();
        _News.Tags = txtTags.Text.Trim();
        _News.Update();
        UpdatePublish();


        Redirect();
    }

    protected void btReject_Click(object sender, EventArgs e)
    {
        if (drpCate1.SelectedValue == "0")
        {
            Message.Alert(Page, "Bạn chưa chọn chuyên mục xuất bản!");
            return;
        }

        News _News = new News() { NewsID = AppUtils.Request("id") };

        _News = _News.Get();

        _News.Title = txtTitle.Text.Trim();
        _News.SubTitle = txtSubTitle.Text.Trim();
        _News.ImageUrl = imgImageUrl.ImageUrl.Replace(Constant.MEDIA_PATH, "");
        _News.Lead = txtLead.Text.Trim();
        _News.SubLead = txtSubLead.Text.Trim();
        _News.Content = ftbContent.Text.Trim();
        _News.IsPhoto = chkIsPhoto.Checked;
        _News.IsVideo = chkIsVideo.Checked;
        _News.IsAudio = chkIsAudio.Checked;
        _News.PublishedTime = Convert.ToDateTime(txtPublishTime.Text);
        _News.CateID = Convert.ToInt32(drpCate1.SelectedValue);
        if (_News.Status > 1) _News.Status = _News.Status - 1;
        _News.UserID = AppUtils.UserID();
        _News.Tags = txtTags.Text.Trim();
        _News.Update();
        UpdatePublish();
        Redirect();
    }

    protected void btDelete_Click(object sender, EventArgs e)
    {
        News _News = new News() { NewsID = AppUtils.Request("id"), UserID = AppUtils.UserID() };
        _News.Delete();
        Redirect();
    }

    protected void btCancel_Click(object sender, EventArgs e)
    {
        Redirect();
    }

    protected void btRelatedAdd_Click(object sender, EventArgs e)
    {
        if (AppUtils.Request("id") == 0) Message.Alert(Page, "Bạn cần lưu bài viết trước khi nhập tin liên quan");

        NewsRelated _NewsRelated = new NewsRelated();
        _NewsRelated.NewsID = AppUtils.Request("id");
        _NewsRelated.RelateID = Convert.ToInt32(txtRelatedID.Text);
        _NewsRelated.Add();
        txtRelatedID.Text = "";

        // Lấy lại danh sách
        rptRelatedList.DataSource = _NewsRelated.GetList(_NewsRelated.NewsID);
        rptRelatedList.DataBind();
    }

    protected void btRelatedRemove_Click(object sender, EventArgs e)
    {
        NewsRelated _NewsRelated = new NewsRelated();
        for (int i = 0; i < rptRelatedList.Items.Count; i++)
        {
            CheckBox cbx = (CheckBox)rptRelatedList.Items[i].FindControl("cbxRelatedStatus");
            Label labelNewsID = (Label)rptRelatedList.Items[i].FindControl("lblRelatedID");
            if (cbx.Checked)
            {
                _NewsRelated.NewsID = AppUtils.Request("id");
                _NewsRelated.RelateID = Convert.ToInt32(labelNewsID.Text);
                _NewsRelated.Delete(_NewsRelated.NewsID, _NewsRelated.RelateID);
            }
        }

        // Lấy lại danh sách
        rptRelatedList.DataSource = _NewsRelated.GetList(_NewsRelated.NewsID);
        rptRelatedList.DataBind();
    }

    private void Redirect()
    {
        if (Request["u"] != null)
        {
            Response.Redirect(Request["u"]);
        }
        else
        {
            Response.Redirect(Constant.ADMIN_PATH + Resources.Url.NewsPendingList);
        }
    }

    protected void btUpdateImage_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < rptMediaList.Items.Count; i++)
        {
            Label lbl = (Label)rptMediaList.Items[i].FindControl("lblNewsMediaID");
            TextBox txt = (TextBox)rptMediaList.Items[i].FindControl("txtMediaOrder");

            var _NewsMedia = new NewsMedia() { NewsMediaID = Convert.ToInt32(lbl.Text) };
            _NewsMedia = _NewsMedia.Get();
            _NewsMedia.Order = Convert.ToInt32(txt.Text);
            _NewsMedia.Update();

            var _MediaFile = new MediaFile() { FileID = _NewsMedia.FileID };
            _MediaFile = _MediaFile.Get();
            txt = (TextBox)rptMediaList.Items[i].FindControl("txtMediaDescription");
            _MediaFile.Description = txt.Text;
            _MediaFile.Update();
        }
        BindMedia();
    }

    protected void btDeleteImage_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < rptMediaList.Items.Count; i++)
        {
            CheckBox cbx = (CheckBox)rptMediaList.Items[i].FindControl("cbxMediaAction");
            Label lbl = (Label)rptMediaList.Items[i].FindControl("lblNewsMediaID");

            if (cbx.Checked)
            {
                var _NewsMedia = new NewsMedia() { NewsMediaID = Convert.ToInt32(lbl.Text) };
                _NewsMedia.Delete();
            }
        }
        BindMedia();
    }

    protected void btUpdateAvatar_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < rptMediaList.Items.Count; i++)
        {
            CheckBox cbx = (CheckBox)rptMediaList.Items[i].FindControl("cbxMediaAction");
            Label lbl = (Label)rptMediaList.Items[i].FindControl("lblNewsMediaID");

            if (cbx.Checked)
            {
                var _NewsMedia = new NewsMedia() { NewsMediaID = Convert.ToInt32(lbl.Text) };
                _NewsMedia = _NewsMedia.Get();

                var _MediaFile = new MediaFile();
                _MediaFile = _MediaFile.Get(_NewsMedia.FileID);

                var _News = new News();
                _News = _News.Get(AppUtils.Request("id"));
                _News.ImageUrl = _MediaFile.Path;
                _News.Update();

                imgImageUrl.ImageUrl = Constant.MEDIA_PATH + _News.ImageUrl;
                return;
            }
        }
    }

    protected void btImageUpload_Click(object sender, EventArgs e)
    {
        // Kiểm tra đã tạo thư mục lưu ảnh, dạng thư mục yyyy/mm/dd/newsid/
        if (!AppUtils.CheckPath(lblMediaPathFull.Text))
        {
            Message.Alert(Page, "Không tạo được thư mục lưu trữ ảnh, vui lòng báo người quản trị!");
            return;
        }

        if (FileUpload1.PostedFile != null && FileUpload1.PostedFile.ContentLength > 0)
        {
            Upload(FileUpload1, txtImageDescription1, cbIsAvatar1);
        }

        if (FileUpload2.PostedFile != null && FileUpload2.PostedFile.ContentLength > 0)
        {
            Upload(FileUpload2, txtImageDescription2, cbIsAvatar2);
        }

        if (FileUpload3.PostedFile != null && FileUpload3.PostedFile.ContentLength > 0)
        {
            Upload(FileUpload3, txtImageDescription3, cbIsAvatar3);
        }

        if (FileUpload4.PostedFile != null && FileUpload4.PostedFile.ContentLength > 0)
        {
            Upload(FileUpload4, txtImageDescription4, cbIsAvatar4);
        }

        if (FileUpload5.PostedFile != null && FileUpload5.PostedFile.ContentLength > 0)
        {
            Upload(FileUpload5, txtImageDescription5, cbIsAvatar5);
        }

        BindMedia();
    }

    private void Upload(FileUpload fileUpload, TextBox textBox, CheckBox checkBox)
    {
        if (textBox.Text.Trim().Length < 1)
        {
            return;
        }

        MediaFile _MediaFile = new MediaFile();
        _MediaFile.Name = AppUtils.MediaFileName(fileUpload.PostedFile.FileName.ToLower());
        _MediaFile.Ext = Path.GetExtension(_MediaFile.Name).Replace(".", "");
        _MediaFile.Path = lblMediaPath.Text + _MediaFile.Name;
        _MediaFile.Size = fileUpload.PostedFile.ContentLength;
        _MediaFile.UserID = AppUtils.UserID();
        _MediaFile.Description = textBox.Text.Trim();
        _MediaFile.Tags = "";

        try
        {
            fileUpload.SaveAs(Server.MapPath(Constant.MEDIA_PATH + _MediaFile.Path));
            _MediaFile.Add();

            var _NewsMedia = new NewsMedia();
            _NewsMedia.NewsID = AppUtils.Request("id");
            _NewsMedia.FileID = _MediaFile.FileID;
            _NewsMedia.Order = 0;
            _NewsMedia.Add();

            if (checkBox.Checked || string.IsNullOrEmpty(imgImageUrl.ImageUrl))
            {
                imgImageUrl.ImageUrl = Constant.MEDIA_PATH + _MediaFile.Path;
                var _News = new News() { NewsID = AppUtils.Request("id") };
                _News = _News.Get();
                _News.ImageUrl = imgImageUrl.ImageUrl.Replace(Constant.MEDIA_PATH, "");
                _News.Update();
            }

            // Khởi tạo lại form upload ảnh
            textBox.Text = "";
            checkBox.Checked = false;
        }
        catch
        {
            Message.Alert(Page, "Có lỗi khi upload ảnh, vui lòng báo người quản trị!");
        }
    }

    protected void btTool_Click(object sender, EventArgs e)
    {
        switch (drpTool.SelectedValue)
        {
            case "1":
                ftbContent.Text = ftbContent.Text + Resources.Config.Box;
                break;
            default:
                break;
        }
    }
}
