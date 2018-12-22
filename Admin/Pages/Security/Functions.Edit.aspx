<%@ Page Language="C#" MasterPageFile="~/Controls/AdminPage.master" AutoEventWireup="true" CodeFile="Functions.Edit.aspx.cs" Inherits="Pages_Security_Functions_Edit"  EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<article>
	<asp:Label ID="lblTtitle" runat="server" Text="Cập nhật quyền hệ thống" CssClass="title"></asp:Label><br /><br />
    <form class="uniform">
	    <dl class="inline">
			<dt><label for="site_title">Tên quyền *</label></dt>
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

			<dt><label for="footer_text">Mức cha *</label></dt>
			<dd>
			    <asp:DropDownList ID="drpFather" DataTextField="Alias" DataValueField="FunctionID" runat="server" onselectedindexchanged="drpFather_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
				<small>Để mặc định nếu là chuyên mục mức 1</small>
			</dd>

			<dt><label for="footer_text">Thứ tự *</label></dt>
			<dd>
			    <asp:DropDownList ID="drpOrder" runat="server" DataTextField="Alias" DataValueField="Order"></asp:DropDownList>
				<small>Chọn quyền đứng liền trước</small>
			</dd>

			<dt><label for="footer_text">Chú thích</label></dt>
			<dd>
				<asp:TextBox ID="txtNote" runat="server" TextMode="MultiLine" CssClass="medium"></asp:TextBox>
				<small>Thông tin ghi chú nếu cần thiết</small>
			</dd>

			<dt><label for="site_logo">Kích hoạt</label></dt>
			<dd>
				<asp:CheckBox ID="cbxIsActive" Checked="true" runat="server"></asp:CheckBox>

			<dt><label for="site_logo">Hiển thị</label></dt>
			<dd>
				<asp:CheckBox ID="cbxIsDisplay" runat="server"></asp:CheckBox>
			</dd>
		</dl>
	    <p>
	        <asp:Button ID="btUpdate" runat="server" Text="LƯU" CssClass="button blue" OnClick="btUpdate_Click" Width="80px"></asp:Button>
	        <asp:Button ID="btDelete" runat="server" Text="XÓA" CssClass="button red" OnClick="btDelete_Click" Width="80px"></asp:Button>
	        <asp:Button ID="btCancel" runat="server" Text="HUỶ" CssClass="button gray" OnClick="btCancel_Click" Width="80px"></asp:Button>
	    </p>
    </form>
</article>
</asp:Content>

