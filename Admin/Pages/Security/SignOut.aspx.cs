using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class Pages_Security_SignOut : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session.Abandon();
        Session.RemoveAll();
        if (string.IsNullOrEmpty(Request["u"]))
        {
            Response.Redirect(Constant.ADMIN_PATH + Resources.Url.SignIn);
        }
        else
        {
            Response.Redirect(Constant.ADMIN_PATH + Resources.Url.SignIn + "?u=" + HttpUtility.UrlEncode(Request["u"].ToLower()));
        }

    }
}
