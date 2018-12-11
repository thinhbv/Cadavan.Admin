using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Libs.Content;

public partial class Pages_Content_Categories_Add : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AppUtils.CheckSecurity();

        if (!IsPostBack)
        {
            Title = "BusTime - Thêm mới chuyên mục";

            init();
        }
    }

    private void init()
    {
        drpFather.DataSource = new Categories().GetTList();
        drpFather.DataBind();

        for (int i = 0; i < drpFather.Items.Count; i++)
        {
            drpFather.Items[i].Text = "- " + drpFather.Items[i].Text;
        }
        drpFather.Items.Insert(0, new ListItem("Chọn chuyên mực cha:", "0"));
    }

    protected void btSubmit_Click(object sender, EventArgs e)
    {
        Categories _Cate = new Categories();
        _Cate.Name = txtName.Text.Trim();
        _Cate.Alias = txtAlias.Text.Trim();
        _Cate.Url = txtUrl.Text.Trim();
        _Cate.FatherID = Convert.ToInt32(drpFather.SelectedValue);
        _Cate.Order = Convert.ToInt32(txtOrder.Text);
        _Cate.Status = cbStatus.Checked;
        _Cate.Description = txtDescription.Text.Trim();
        _Cate.Add();

        if (_Cate.ReturnValue > 0)
        {
            Response.Redirect(Constant.ADMIN_PATH + Resources.Url.CategoriesList);
        }
        else
        {
            switch (_Cate.ReturnValue)
            {
                default:
                    literalMessage.Text = AppUtils.Alert("warning", "Lỗi hệ thống!", "Có lỗi khi thêm mới người dùng.");
                    break;
            }
        }

    }
}