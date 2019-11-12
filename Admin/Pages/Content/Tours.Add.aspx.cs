using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Libs.Content;
using System.IO;

public partial class Pages_Content_Tours_Add : System.Web.UI.Page
{
	protected string imgPath = "";
	int id = 0;
	protected string pagetitle = "Thêm mới Tour";
    protected void Page_Load(object sender, EventArgs e)
    {
		if (!IsPostBack)
		{
			Tours tour = new Tours();
			if (Request.QueryString["id"] != null)
			{
				btnDelete.Attributes.Add("onClick", "javascript:return confirm('Bạn có muốn xóa?');");
				pagetitle = "Cập nhật thông tin Tour";
				btnUpdate.Visible = true;
				btnDelete.Visible = true;
				btnRegister.Visible = false;
				id = int.Parse(Request.QueryString["id"]);
				List<Tours> lstTours = new List<Tours>();
				lstTours = tour.GetById(id);
				if (lstTours.Count > 0)
				{
					txtName.Value = lstTours[0].Name;
					txtAgenda.Value = lstTours[0].Agenda;
					txtPeriod.Value = lstTours[0].Period;
					txtPrice.Value = lstTours[0].Price.ToString();
					chkPriority.Checked = lstTours[0].Priority == 1;
					drpStatus.SelectedValue = lstTours[0].Active.ToString();
					ftbContent.Text = lstTours[0].Detail;
					ddlType.SelectedValue = lstTours[0].Type.ToString();
					imgImage.ImageUrl = lstTours[0].Image;
				}
			}
			else
			{
				ftbContent.Text = " ";
				id = tour.GetMaxId() + 1;
				btnUpdate.Visible = false;
				btnDelete.Visible = false;
				btnRegister.Visible = true;
			}
			hdId.Value = id.ToString();
			string path = Server.MapPath("/wmedia/Tours/") + id.ToString();
			if (!Directory.Exists(path))
			{
				Directory.CreateDirectory(path);
			}
			ftbContent.ImageGalleryPath = "/wmedia/Tours/" + id;
		}
    }
	protected void btnRegister_Click(object sender, EventArgs e)
	{
		if (Page.IsValid)
		{
			try
			{				
				Tours tour = new Tours();
				tour.Active = int.Parse(drpStatus.SelectedValue);
				tour.Agenda = txtAgenda.Value.Trim();
				tour.CreateDate = DateTime.Now;
				tour.Detail = ftbContent.Text;
				if (fuImage.HasFile)
				{
					fuImage.SaveAs(Server.MapPath("/wmedia/Tours/") + hdId.Value + "/" + fuImage.FileName);
					tour.Image = "/wmedia/Tours/" + hdId.Value + "/" + fuImage.FileName;
				}
				else
				{
					tour.Image = "";
				}
				tour.Name = txtName.Value.Trim();
				tour.Period = txtPeriod.Value.Trim();
				if (string.IsNullOrEmpty(txtPrice.Value))
				{
					tour.Price = 0;
				}
				else
				{
					tour.Price = double.Parse(txtPrice.Value.Trim());
				}
				tour.Type = int.Parse(ddlType.SelectedValue);
				tour.Priority = chkPriority.Checked ? 1 : 0;
				tour.Keywords = txtKeywords.Value.Trim();
				tour.Insert();
				Response.Redirect("tours.list.html", false);
			}
			catch (Exception)
			{
				throw;
			}			
		}
	}
	protected void btnUpdate_Click(object sender, EventArgs e)
	{
		if (Page.IsValid)
		{
			try
			{
				if (Request.QueryString["id"] != null)
				{
					int id = int.Parse(Request.QueryString["id"].ToString());
					Tours tour = new Tours();
					tour.Id = id;
					tour.Active = int.Parse(drpStatus.SelectedValue);
					tour.Agenda = txtAgenda.Value.Trim();
					tour.CreateDate = DateTime.Now;
					tour.Detail = ftbContent.Text;
					if (fuImage.HasFile)
					{
						fuImage.SaveAs(Server.MapPath("/wmedia/Tours/") + hdId.Value + "/" + fuImage.FileName);
						tour.Image = "/wmedia/Tours/" + hdId.Value + "/" + fuImage.FileName;
					}
					else
					{
						tour.Image = imgImage.ImageUrl;
					}
					tour.Name = txtName.Value.Trim();
					tour.Period = txtPeriod.Value.Trim();
					if (string.IsNullOrEmpty(txtPrice.Value))
					{
						tour.Price = 0;
					}
					else
					{
						tour.Price = double.Parse(txtPrice.Value.Trim());
					}
					tour.Type = int.Parse(ddlType.SelectedValue);
					tour.Priority = chkPriority.Checked ? 1 : 0;
					tour.Keywords = txtKeywords.Value.Trim();
					tour.Update();
					Response.Redirect("tours.list.html", false);
				}
				
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
	protected void btnUpLoad_Click(object sender, EventArgs e)
	{
		try
		{
			dynamic fileUploadControl = fuImages;
			if (fileUploadControl.PostedFiles.Count == 0)
			{
				Message.Alert(this, "Vui lòng chọn file upload!");
				return;
			}
			foreach (HttpPostedFile userPostedFile in fileUploadControl.PostedFiles) 
			{
				string filename = userPostedFile.FileName;
				userPostedFile.SaveAs(Server.MapPath("/wmedia/Tours/") + hdId.Value + "/" + filename);
			}
		}
		catch (Exception)
		{
			
			throw;
		}
	}
	protected void btnDelete_Click(object sender, EventArgs e)
	{
		try
		{
			Tours tour = new Tours();
			tour.Delete(hdId.Value);
			Response.Redirect("tours.list.html", false);
		}
		catch (Exception)
		{	
			throw;
		}
	}
}