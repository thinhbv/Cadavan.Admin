using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Libs.Content;

public partial class Pages_Content_MediaFile_Download : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var _MediaFile = new MediaFile() { FileID = AppUtils.Request("id") };
        _MediaFile = _MediaFile.Get();
        if (_MediaFile == null) return;
        Response.Clear();
        Response.ContentType = _MediaFile.FileType;
        Response.OutputStream.Write(_MediaFile.Data, 0, _MediaFile.Size);
        Response.AppendHeader("Content-Disposition", String.Format("attachment; filename={0}", _MediaFile.Name.Replace(" ", "-")));
        Response.End();
    }
}