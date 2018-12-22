<%@ Page Language="C#" MasterPageFile="~/Controls/AdminPage.master" AutoEventWireup="true" CodeFile="NewsForum.Edit.aspx.cs" Inherits="Pages_Content_NewsForum_Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<article>
	<asp:Label ID="lblTtitle" runat="server" Text="Duyệt phản hồi" CssClass="title"></asp:Label>
    <form class="uniform">
	    <dl class="inline">
			<dt><label for="site_title">Tiêu đề *</label></dt>
			<dd>
				<asp:TextBox ID="txtTitle" runat="server" Width="400px" CssClass="medium"></asp:TextBox>
			</dd>

			<dt><label for="footer_text">Nội dung</label></dt>
			<dd>
				<asp:TextBox ID="txtContent" runat="server" Width="400px" Rows="15" TextMode="MultiLine" CssClass="medium"></asp:TextBox>
			</dd>

			<dt><label for="site_url">Họ tên người gửi *</label></dt>
			<dd>
				<asp:TextBox ID="txtHeader" runat="server" CssClass="medium"></asp:TextBox>
			</dd>

			<dt><label for="site_url">Email *</label></dt>
			<dd>
				<asp:TextBox ID="txtEmail" runat="server" CssClass="medium"></asp:TextBox>
			</dd>

			<dt><label for="site_logo">Duyệt</label></dt>
			<dd>
				<asp:CheckBox ID="cbxStatus" runat="server"></asp:CheckBox>
			</dd>

			<dt><label for="tagline">Thời gian gửi</label></dt>
			<dd>
				<asp:Label ID="lblCreatedTime" runat="server" Text="Label"></asp:Label>
			</dd>

			<dt><label for="tagline">Bài viết</label></dt>
			<dd>
				<asp:Label ID="lblNewsTitle" runat="server" Text="Label"></asp:Label> (<asp:HyperLink ID="hplNewsForum" runat="server">xem phản hồi</asp:HyperLink>)
			</dd>
		</dl>
	    <p>
	        <asp:Button ID="btUpdate" runat="server" Text="LƯU" CssClass="button blue" Width="80px" OnClick="btUpdate_Click"></asp:Button>
	        <asp:Button ID="btDelete" runat="server" Text="XOÁ" CssClass="button red" Width="80px" OnClick="btDelete_Click"></asp:Button>
	        <asp:Button ID="btCancel" runat="server" Text="HUỶ" CssClass="button gray" Width="80px" OnClick="btCancel_Click"></asp:Button>
	    </p>
    </form>
</article>
</asp:Content>

