using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Libs.Content;

public partial class Pages_Content_News_Media : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AppUtils.CheckLogin();
        Title = Title + " - Danh sách file";
        if (!IsPostBack)
        {
            CheckPath();
            BindData();
        }
    }

    private string GetPath()
    {
        var _News = new News() { NewsID = AppUtils.Request("id") };
        _News = _News.Get();
        return _News.CreatedTime.ToString("yyyy/MM/dd") + "/" + _News.NewsID.ToString() + "/";
    }

    private void CheckPath()
    {
        if (!AppUtils.CheckPath(GetPath())) Message.Alert(Page, "Không tạo được thư mục!");
    }

    private void BindData()
    {
        var _NewsMedia = new NewsMedia() { NewsID = AppUtils.Request("id") };
        rptList.DataSource = _NewsMedia.GetList(_NewsMedia.NewsID);
        rptList.DataBind();
    }


    protected string GetHtml(string url)
    {
        url = Constant.MEDIA_URL + url;
        string ext = "";
        for (int i = url.Length; i > 0; i--)
        {
            if (url[i - 1] == '.')
            {
                ext = url.Substring(i);
                break;
            }
        }

        if (ext == "jpg" || ext == "gif" || ext == "png")
        {
            return string.Format("<img src=\"{0}\" width=\"200\" />", url);
        }

        if (ext == "flv")
        {
            return Resources.Html.Flv.Replace("$ImageUrl$", "")
            .Replace("$VideoUrl$", url)
            .Replace("$Width$", "400")
            .Replace("$Height$", "300");
        }

        return string.Format("<a target=\"_blank\" href=\"{0}\">Download</a>", url);
    }

    protected void btUpload_Click(object sender, EventArgs e)
    {
        if (fuFileUpload.PostedFile == null || fuFileUpload.PostedFile.ContentLength == 0)
        {
            Message.Alert(Page, "Bạn chưa chọn file!");
            return;
        }

        MediaFile _MediaFile = new MediaFile();
        _MediaFile.Name = AppUtils.MediaFileName(fuFileUpload.PostedFile.FileName.ToLower());
        _MediaFile.Ext = Path.GetExtension(_MediaFile.Name).Replace(".", "");
        _MediaFile.Path = GetPath() + _MediaFile.Name;
        _MediaFile.Size = fuFileUpload.PostedFile.ContentLength;
        _MediaFile.UserID = AppUtils.UserID();
        _MediaFile.Description = txtDescription.Text.Trim();
        _MediaFile.Tags = txtTags.Text.Trim();

        var _NewsMedia = new NewsMedia();
        _NewsMedia.NewsID = AppUtils.Request("id");
        _NewsMedia.Order = Convert.ToInt32(txtOrder.Text.Trim());

        try
        {
            fuFileUpload.SaveAs(Server.MapPath(Constant.MEDIA_PATH + _MediaFile.Path));
            _MediaFile.Add();
            _NewsMedia.FileID = _MediaFile.FileID;
            _NewsMedia.Add();
            Response.Redirect(Request.Url.ToString());
        }
        catch
        {
            Message.Alert(Page, "Có lỗi khi upload file!");
        }
    }

    protected void btCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.Url.ToString());
    }

    protected void btEdit_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < rptList.Items.Count; i++)
        {
            CheckBox cbx = (CheckBox)rptList.Items[i].FindControl("cbxAction");
            if (cbx.Checked)
            {
                Label lbl = (Label)rptList.Items[i].FindControl("lblFileID");
                MediaFile _MediaFile = new MediaFile() { FileID = Convert.ToInt32(lbl.Text) };
            }
        }
        Message.Alert(Page, "Bạn chưa chọn file!");
    }
}