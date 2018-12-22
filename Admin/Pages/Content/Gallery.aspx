<%@ Page Language="C#" MasterPageFile="~/Controls/AdminPage.master" AutoEventWireup="true" CodeFile="Gallery.aspx.cs" Inherits="Pages_Content_Gallery" ValidateRequest="false" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<article>
    <asp:Panel ID="upload_HeaderPanel" runat="server" style="cursor: pointer;">
        <asp:ImageButton ID="upload_ToggleImage" runat="server" AlternateText="collapse" />
        <span class="titlesmall">Upload ảnh</span>
    </asp:Panel>
    <asp:Panel ID="upload_ContentPanel" style="overflow:hidden;" runat="server">
	<form class="uniform">
		<dl class="inline">
			<dt><label for="site_title">Chọn ảnh: </label></dt>
			<dd>
			    <asp:FileUpload ID="fuFileUpload" runat="server"></asp:FileUpload><br />
			    <asp:Label ID="lblFileID" runat="server" Visible="false"></asp:Label>
			</dd>

            <dt></dt>			
			<dd>
			    <asp:Image ID="imgMediaUpload" runat="server"></asp:Image>
			</dd>

			<dt><label for="site_title">Url:</label></dt>
			<dd><asp:TextBox ID="txtPath" runat="server" ReadOnly="" CssClass="medium" TextMode="MultiLine" Width="500px" Rows="3"></asp:TextBox></dd>

			<dt><label for="site_title">Chú thích ảnh:</label></dt>
			<dd><asp:TextBox ID="txtDescription" runat="server" CssClass="medium" Width="500px"></asp:TextBox></dd>

			<dt><label for="site_title">Từ khóa:</label></dt>
			<dd>
			    <asp:TextBox ID="txtTags" TextMode="MultiLine" Rows="3" class="medium" Width="500px" runat="server"></asp:TextBox>
			    <small>Từ khóa để tìm kiếm ảnh</small>
			</dd>
		</dl>
	    <asp:Button ID="btUpload" CssClass="button green" runat="server" Text="Upload" OnClick="btUpload_Click"></asp:Button>
		<asp:Button ID="btSave" CssClass="button" runat="server" Text="Lưu" Visible="false" OnClick="btSave_Click"></asp:Button>
		<asp:Button ID="btCancel" CssClass="button white" runat="server" Text="Hủy" OnClick="btCancel_Click"></asp:Button>
	</form>
    </asp:Panel>
</article>
<article>
    <span class="titlesmall">Photo Gallery</span>
	<ul class="photos sortable">
	    <asp:Repeater ID="rptPhotoList" runat="server">
	        <ItemTemplate>
		        <li>
			        <img src="<%#AppUtils.ImageUrl(Eval("Path").ToString(), "100", "100") %>" width="100" height="100" />
			        <div class="links">
				        <a href="<%=Constant.MEDIA_PATH %><%#Eval("Path") %>" rel="facebox">View</a>
				        <asp:CheckBox ID="cbxAction" runat="server"></asp:CheckBox>
				        <asp:Label ID="lblFileID" runat="server" Text='<%#Eval("FileID") %>' Visible="false"></asp:Label>
			        </div>
		        </li>
	        </ItemTemplate>
	    </asp:Repeater>
	</ul>
	<div class="tablefooter clearfix">
		<div class="actions">
		    <asp:TextBox ID="txtKeyword" Width="120px" CssClass="medium" MaxLength="80" runat="server"></asp:TextBox>
		    <asp:DropDownList ID="drpUser" runat="server">
		        <asp:ListItem Value="0">File của bạn</asp:ListItem>
		        <asp:ListItem Value="0">Tất cả</asp:ListItem>
		    </asp:DropDownList>
		    <asp:Button ID="btSearch" CssClass="button small" runat="server" Width="50px" OnClick="btSearch_Click" Text="Tìm"></asp:Button>
	    <asp:Button ID="btApply" CssClass="button small" runat="server" Width="50px" OnClick="btApply_Click" Text="Xem"></asp:Button>
		</div>
		<div class="pagination">
		    Page:
		    <asp:DropDownList ID="drpPage" runat="server">
		        <asp:ListItem>1</asp:ListItem>
		        <asp:ListItem>2</asp:ListItem>
		    </asp:DropDownList>
		    (All: <asp:Label ID="lblTotal" runat="server" Text="0"></asp:Label>)
		    <asp:Button ID="btPage" CssClass="button small" runat="server" Width="50px" OnClick="btPage_Click" Text="Chuyển"></asp:Button>
		</div>
	</div>
</article>

<ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server" TargetControlID="txtKeyword" WatermarkText="Nhập từ khóa"  />

<ajaxToolkit:CollapsiblePanelExtender ID="cpeUpload" runat="Server"
    TargetControlID="upload_ContentPanel"
    ExpandControlID="upload_HeaderPanel"
    CollapseControlID="upload_HeaderPanel"
    ExpandedSize="0"
    ExpandDirection="Vertical"
    ExpandedImage="~/resources/images/collapse.jpg"
    CollapsedImage="~/resources/images/expand.jpg" 
    ImageControlID="upload_ToggleImage" /> 
</asp:Content>

