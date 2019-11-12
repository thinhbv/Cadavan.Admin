using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Libs.Content;

public partial class Pages_Config : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		if (!IsPostBack)
		{
			try
			{
				Config mCon = new Config();
				if (Application["Config"] != null)
				{
					mCon = (Config)Application["Config"];
				}
				else { mCon = mCon.Get(); }

				if (mCon != null)
				{
					txtAddress1.Value = mCon.Address1;
					txtAddress2.Value = mCon.Address2;
					txthotline.Value = mCon.HotLine;
					ftbContent.Text = mCon.ContactInfo;
					imgLogo.ImageUrl = mCon.Logo;
					imgTourPage.ImageUrl = mCon.BannerTourPage;
					imgHomePage.ImageUrl = mCon.BannerHomePage;
					imgBannerTop.ImageUrl = mCon.BannerTop;
					txtStatusTicket.Value = mCon.StatusTicket;
					txtStatusCheapTicket.Value = mCon.StatusCheapTicket;
					txtStatusContact.Value = mCon.StatusContact;
					txtStatusTour.Value = mCon.StatusTour;
				}
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
				Config mCon = new Config();
				if (Application["Config"] != null)
				{
					mCon = (Config)Application["Config"];
				}
				else { mCon = mCon.Get(); }
				if (mCon == null)
				{
					mCon = new Config();
				}
				mCon.ContactInfo = ftbContent.Text;
				mCon.HotLine = txthotline.Value.Trim();
				mCon.Address1 = txtAddress1.Value.Trim();
				mCon.Address2 = txtAddress2.Value.Trim();
				if (fuLogo.HasFile)
				{
					fuLogo.SaveAs(Server.MapPath("/wmedia/Config/") + fuLogo.FileName);
					mCon.Logo = "/wmedia/Config/" + fuLogo.FileName;
				}
				if (fuBannerTop.HasFile)
				{
					fuBannerTop.SaveAs(Server.MapPath("/wmedia/Config/") + fuBannerTop.FileName);
					mCon.BannerTop = "/wmedia/Config/" + fuBannerTop.FileName;
				}
				if (fuHomePage.HasFile)
				{
					fuHomePage.SaveAs(Server.MapPath("/wmedia/Config/") + fuHomePage.FileName);
					mCon.BannerHomePage = "/wmedia/Config/" + fuHomePage.FileName;
				}
				if (fuTourPage.HasFile)
				{
					fuTourPage.SaveAs(Server.MapPath("/wmedia/Config/") + fuTourPage.FileName);
					mCon.BannerTourPage = "/wmedia/Config/" + fuTourPage.FileName;
				}
				mCon.StatusTicket = txtStatusTicket.Value.Trim();
				mCon.StatusCheapTicket = txtStatusCheapTicket.Value.Trim();
				mCon.StatusTour = txtStatusTour.Value.Trim();
				mCon.StatusContact = txtStatusContact.Value.Trim();
				if (mCon.Id ==0)
				{
					mCon.Insert();
				}
				else
				{
					mCon.Update();
				}
			}
			catch (Exception)
			{			
				throw;
			}
		}
	}
}