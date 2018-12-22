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
using System.IO;
using Libs.Content;

public partial class Pages_Content_MediaFile_List : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AppUtils.CheckLogin();
        Title = Title + " - Danh sách file";
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
        string ext = drpExt.SelectedValue;
        int userID = Convert.ToInt32(drpUser.SelectedValue);
        string keyword = txtKeyword.Text.Trim();
        int pageSize = Convert.ToInt32(drpPageSize.SelectedValue);
        int pageIndex = Convert.ToInt32(drpPage.SelectedValue);
        rptList.DataSource = _MediaFile.Search(ext, userID, keyword, pageIndex, pageSize, ref total);
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
            return string.Format("<img src=\"{0}\" width=\"100\" />", url);
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

    protected void btApply_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < rptList.Items.Count; i++)
        {
            CheckBox cbx = (CheckBox)rptList.Items[i].FindControl("cbxAction");
            if (cbx.Checked)
            {
                Label lbl = (Label)rptList.Items[i].FindControl("lblFileID");
                MediaFile _MediaFile = new MediaFile() { FileID = Convert.ToInt32(lbl.Text) };
                _MediaFile = _MediaFile.Get();
                lblFileID.Text = _MediaFile.FileID.ToString();
                txtDescription.Text = _MediaFile.Description;
                txtTags.Text = _MediaFile.Tags;
                txtPath.Text = Constant.MEDIA_URL + _MediaFile.Path;
                txtHTML.Text = GetHtml(_MediaFile.Path);
                ltrHTML.Text = GetHtml(_MediaFile.Path);
                btUpload.Visible = false;
                btSave.Visible = true;
                return;
            }
        }
        Message.Alert(Page, "Bạn chưa chọn file!");
    }

    protected void btSearch_Click(object sender, EventArgs e)
    {
        BindData();
    }

    protected void btPage_Click(object sender, EventArgs e)
    {
        BindData();
    }

    protected void btUpload_Click(object sender, EventArgs e)
    {
        if (!AppUtils.CheckPath()) Message.Alert(Page, "Không tạo được thư mục!");

        if (fuFileUpload.PostedFile == null || fuFileUpload.PostedFile.ContentLength == 0)
        {
            Message.Alert(Page, "Bạn chưa chọn file!");
            return;
        }

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
            BindData();
        }
        catch
        {
            Message.Alert(Page, "Có lỗi khi upload file!");
        }

        txtPath.Text = Constant.MEDIA_URL + _MediaFile.Path;
        btSave.Visible = true;
        btUpload.Visible = false;
    }

    protected void btSave_Click(object sender, EventArgs e)
    {
        MediaFile _MediaFile = new MediaFile() { FileID = Convert.ToInt32(lblFileID.Text) };
        _MediaFile = _MediaFile.Get();
        _MediaFile.Tags = txtTags.Text.Trim();
        _MediaFile.Description = txtDescription.Text.Trim();
        _MediaFile.Update();
        Response.Redirect(Request.Url.ToString());        
    }

    protected void btCancel_Click(object sender, EventArgs e)
    {
        txtDescription.Text = "";
        txtTags.Text = "";
        txtHTML.Text = "";
        ltrHTML.Text = "";
        txtPath.Text = "";
    }
}
