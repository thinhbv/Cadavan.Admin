using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Libs.Content;

public partial class Pages_Content_Categories_List : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Title = "BusTime - Danh sách chuyên mục";

            GetList();
        }

    }

    private void GetList()
    {
        rptList.DataSource = new Categories().GetTList();
        rptList.DataBind();
    }
}