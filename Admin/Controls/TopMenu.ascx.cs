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
using Libs.Security;

public partial class Controls_TopMenu : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
		// Lấy menu
		List<Functions> list;
		Functions _Function = new Functions();
		string s = "";

		list = _Function.GetMenuList(AppUtils.UserID());
		for (int i = 0; i < list.Count; i++)
		{
			_Function = list[i];
			if (_Function.Url != "#") _Function.Url = Constant.ADMIN_PATH + _Function.Url;
			if (_Function.FatherID == 0)
			{
				if (i > 0) s = s + "</ul></li>";
				s = s + string.Format("<li><a href=\"{0}\">{1}</a><ul>", _Function.Url, _Function.Name);
			}
			else
			{
				s = s + string.Format("<li><a href=\"{0}\">{1}</a></li>", _Function.Url, _Function.Name);
			}
		}
		if (list.Count > 0) s = s + "</ul></li>";
		ltrMenu.Text = s;
    }
}
