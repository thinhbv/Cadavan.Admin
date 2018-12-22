<%@ Page Title="" Language="C#" MasterPageFile="~/Controls/AdminPage.master" AutoEventWireup="true" CodeFile="Votes.Add.aspx.cs" Inherits="Pages_Content_Votes_Add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<article>
	<asp:Label ID="lblTtitle" runat="server" Text="Thêm mới chuyên mục" CssClass="title"></asp:Label>
    <div class="uniform">
	    <dl class="inline">
			<dt><label for="site_title">Tên thăm dò *</label></dt>
			<dd>
				<asp:TextBox ID="txtTitle" runat="server" CssClass="medium"></asp:TextBox>
			</dd>

			<dt><label for="site_logo">Kích hoạt</label></dt>
			<dd>
				<asp:CheckBox ID="cbxIsActive" Checked="true" runat="server"></asp:CheckBox>
			</dd>

			<dt><label for="tagline">Ngày hết hạn *</label></dt>
			<dd>
				<asp:TextBox ID="txtExpireTime" runat="server" CssClass="medium"></asp:TextBox>
			</dd>
		</dl>
	    <p>
	        <asp:Button ID="btAdd" runat="server" Text="THÊM" CssClass="button blue" Width="80px" OnClick="btAdd_Click"></asp:Button>
	        <asp:Button ID="btCancel" runat="server" Text="HUỶ" CssClass="button gray" Width="80px" OnClick="btCancel_Click"></asp:Button>
	    </p>
    </div>
</article>
</asp:Content>

