using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Libs.Content;

public partial class Pages_Content_Categories_Edit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AppUtils.CheckSecurity();

        if (!IsPostBack)
        {
            Title = "BusTime - Cập nhật chuyên mục";

            init();
        }
    }

    private void init()
    {
        Categories _Cate = new Categories() { CateID = AppUtils.Request("id") };
        _Cate = _Cate.Get();
        if (_Cate == null)
        {
            Response.Redirect(Constant.ADMIN_PATH + Resources.Url.Error404);
        }

        drpFather.DataSource = _Cate.GetTList();
        drpFather.DataBind();

        for (int i = 0; i < drpFather.Items.Count; i++)
        {
            drpFather.Items[i].Text = "- " + drpFather.Items[i].Text;
        }
        drpFather.Items.Insert(0, new ListItem("Chọn chuyên mực cha:", "0"));

        txtName.Text = _Cate.Name;
        txtAlias.Text = _Cate.Alias;
        txtUrl.Text = _Cate.Url;
        drpFather.SelectedValue = _Cate.FatherID.ToString();
        txtOrder.Text = _Cate.Order.ToString();
        txtDescription.Text = _Cate.Description;
    }

    protected void btSubmit_Click(object sender, EventArgs e)
    {
        Categories _Cate = new Categories() { CateID = AppUtils.Request("id") };
        _Cate = _Cate.Get();

        _Cate.Name = txtName.Text.Trim();
        _Cate.Alias = txtAlias.Text.Trim();
        _Cate.Url = txtUrl.Text.Trim();
        _Cate.FatherID = Convert.ToInt32(drpFather.SelectedValue);
        _Cate.Order = Convert.ToInt32(txtOrder.Text);
        _Cate.Status = cbStatus.Checked;
        _Cate.Description = txtDescription.Text.Trim();
        _Cate.Update();

        if (_Cate.ReturnValue == 0)
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