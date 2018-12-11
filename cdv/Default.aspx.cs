using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string time = "16:23:01";
        DateTime date = Convert.ToDateTime(time);

        Label1.Text = date.ToString();
        Response.Redirect(Resources.Url.Login);
    }
}