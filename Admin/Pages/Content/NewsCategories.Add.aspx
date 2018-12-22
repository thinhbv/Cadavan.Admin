<%@ Page Language="C#" MasterPageFile="~/Controls/AdminPage.master" AutoEventWireup="true" CodeFile="NewsCategories.Add.aspx.cs" Inherits="Pages_Content_NewsCategories_Add" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<article>
	<asp:Label ID="lblTtitle" runat="server" Text="Thêm mới chuyên mục" CssClass="title"></asp:Label>
    <form class="uniform">
	    <dl class="inline">
			<dt><label for="site_title">Tên chuyên mục *</label></dt>
			<dd>
				<asp:TextBox ID="txtName" runat="server" CssClass="medium"></asp:TextBox>
			</dd>

			<dt><label for="tagline">Tên đại diện *</label></dt>
			<dd>
				<asp:TextBox ID="txtAlias" runat="server" CssClass="medium"></asp:TextBox>
			</dd>

			<dt><label for="site_url">Url *</label></dt>
			<dd>
				<asp:TextBox ID="txtUrl" runat="server" CssClass="medium"></asp:TextBox>
			</dd>

			<dt><label for="footer_text">Chuyên mục cha *</label></dt>
			<dd>
			    <asp:DropDownList ID="drpFather" DataTextField="Alias" DataValueField="CateID" runat="server" onselectedindexchanged="drpFather_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
				<small>Để mặc định nếu là chuyên mục mức 1</small>
			</dd>

			<dt><label for="footer_text">Thứ tự *</label></dt>
			<dd>
			    <asp:DropDownList ID="drpOrder" runat="server"></asp:DropDownList>
				<small>Chọn chuyên mục đứng liền trước</small>
			</dd>

			<dt><label for="footer_text">Chú thích</label></dt>
			<dd>
				<asp:TextBox ID="txtNote" runat="server" TextMode="MultiLine" CssClass="medium"></asp:TextBox>
				<small>Thông tin ghi chú nếu cần thiết</small>
			</dd>

			<dt><label for="footer_text">Meta Keywords</label></dt>
			<dd>
				<asp:TextBox ID="txtMetaKeywords" runat="server" TextMode="MultiLine" CssClass="big" Height="60px"></asp:TextBox>
				<small>Thông tin ghi chú nếu cần thiết</small>
			</dd>

			<dt><label for="footer_text">Meta Description</label></dt>
			<dd>
				<asp:TextBox ID="txtMetaDescription" runat="server" TextMode="MultiLine" CssClass="big" Height="60px"></asp:TextBox>
				<small>Thông tin ghi chú nếu cần thiết</small>
			</dd>

			<dt><label for="site_logo">Kích hoạt</label></dt>
			<dd>
				<asp:CheckBox ID="cbxIsActive" Checked="true" runat="server"></asp:CheckBox>
			</dd>
		</dl>
	    <p>
	        <asp:Button ID="btAdd" runat="server" Text="THÊM" CssClass="button blue" Width="80px" OnClick="btAdd_Click"></asp:Button>
	        <asp:Button ID="btCancel" runat="server" Text="HUỶ" CssClass="button gray" Width="80px" OnClick="btCancel_Click"></asp:Button>
	    </p>
    </form>
</article>
</asp:Content>

