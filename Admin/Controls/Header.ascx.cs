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

public partial class Controls_Header : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
		if (string.IsNullOrEmpty(AppUtils.FullName()))
		{
			string url = Request.Path;
			Response.Redirect("security.signin.html?u=" + Server.UrlEncode(url), false);
			Response.Flush();
			Response.End();
		}
		else
		{
			lblName.Text = AppUtils.FullName() + " (" + AppUtils.Email() + ")";
		}
		
    }
}
