<%@ Page Language="C#" MasterPageFile="~/Controls/AdminPage.master" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="Pages_Security_ChangePassword" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<article>
	<asp:Label ID="lblTtitle" runat="server" Text="Đổi mật khẩu" CssClass="title"></asp:Label><br /><br />
    <form class="uniform">
	    <dl class="inline">
			<dt><label for="site_title">Mật khẩu cũ *</label></dt>
			<dd>
				<asp:TextBox ID="txtPasswordOld" TextMode="Password" runat="server" CssClass="medium"></asp:TextBox>
			</dd>

			<dt><label for="tagline">Mật khẩu mới *</label></dt>
			<dd>
				<asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="medium"></asp:TextBox>
			</dd>

			<dt><label for="site_url">Nhập lại mật khẩu *</label></dt>
			<dd>
				<asp:TextBox ID="txtPasswordAgain" runat="server" TextMode="Password" CssClass="medium"></asp:TextBox>
			</dd>
		</dl>
	    <p>
	        <asp:Button ID="btSubmit" runat="server" Text="ĐỔI" CssClass="button blue" OnClick="btSubmit_Click" Width="80px"></asp:Button>
	    </p>
    </form>
</article>
<%--txtPassword--%>
<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Mật khẩu tối thiểu phải có 6 ký tự"
    Display="None" ControlToValidate="txtPassword" ValidationExpression=".{6}.*"></asp:RegularExpressionValidator>
<ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender2"
    Width="160px" HighlightCssClass="validatorCalloutHighlight" TargetControlID="RegularExpressionValidator2" WarningIconImageUrl="" />
<asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtPassword"
    ControlToValidate="txtPasswordAgain" Display="None" ErrorMessage="Mật khẩu nhật lại không khớp"></asp:CompareValidator>
<ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender3"
    HighlightCssClass="validatorCalloutHighlight"  TargetControlID="CompareValidator1" WarningIconImageUrl="" />
</asp:Content>

