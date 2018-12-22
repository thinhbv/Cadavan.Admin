<%@ Page Language="C#" MasterPageFile="~/Controls/AdminPage.master" AutoEventWireup="true" CodeFile="Users.Add.aspx.cs" Inherits="Pages_Security_Users_Add" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<article id="settings">
	<asp:Label ID="lblTtitle" runat="server" Text="Thêm mới người dùng" CssClass="title"></asp:Label>
	<form class="uniform">
		<ul class="tabs">
			<li><a href="#general">Thông tin</a></li>
			<li><a href="#">Gán quyền</a></li>
			<li><a href="#">Lịch sử</a></li>
		</ul>
		<div class="tabcontent">
			<div id="general">
				<dl class="inline">
					<dt><label for="site_title">Tên truy cập *</label></dt>
					<dd>
						<asp:TextBox ID="txtEmail" runat="server" CssClass="medium"></asp:TextBox>
						<small>Tên truy cập để đăng nhập hệ thống.</small>
					</dd>

					<dt><label for="tagline">Họ tên *</label></dt>
					<dd>
						<asp:TextBox ID="txtFullName" runat="server" CssClass="medium"></asp:TextBox>
						<small>Ví dụ: Nguyễn Văn Bình, Lê Hoàng,...</small>
					</dd>

					<dt><label for="site_url">Mật khẩu *</label></dt>
					<dd>
						<asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="medium"></asp:TextBox>
						<small>Mật khẩu có ít nhất 6 ký tự</small>
					</dd>

					<dt><label for="footer_text">Nhập lại mật khẩu *</label></dt>
					<dd>
						<asp:TextBox ID="txtPasswordAgain" runat="server" TextMode="Password" CssClass="medium"></asp:TextBox>
						<small>Mật khẩu và mật khẩu nhập lại phải giống nhau</small>
					</dd>

					<dt><label for="site_logo">Kích hoạt</label></dt>
					<dd>
						<asp:CheckBox ID="chkIsActive" runat="server"></asp:CheckBox>
						<small>Chọn để cho phép người dùng đăng nhập</small>
					</dd>

					<dt><label for="site_logo">Nhóm người dùng</label></dt>
					<dd>
                        <asp:DropDownList ID="drpGroup" DataTextField="Name" DataValueField="GroupID" runat="server"></asp:DropDownList>
					</dd>
				</dl>
		        <div class="buttons">
		            <asp:Button ID="btAdd" runat="server" CssClass="button" Text="Thêm mới" OnClick="btAdd_Click"></asp:Button>
		            <asp:Button ID="btCancel" runat="server" CssClass="button white" Text="Bỏ qua" CausesValidation="false" OnClick="btCancel_Click"></asp:Button>
		        </div>
			</div>
			<div id="security">
				
			</div>
			<div id="history">

			</div>
		</div>
	</form>
</article>
<%--txtEmail--%>
<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Tên truy cập phải có tối thiểu 4 ký tự"
    Display="None" ControlToValidate="txtPassword" ValidationExpression=".{4}.*"></asp:RegularExpressionValidator>
<ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender1"
    Width="160px" HighlightCssClass="validatorCalloutHighlight" TargetControlID="RegularExpressionValidator1" WarningIconImageUrl="" />
<%--txtPassword--%>
<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Mật khẩu tối thiểu phải có 6 ký tự"
    Display="None" ControlToValidate="txtPassword" ValidationExpression=".{6}.*"></asp:RegularExpressionValidator>
<ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender2"
    Width="160px" HighlightCssClass="validatorCalloutHighlight" TargetControlID="RegularExpressionValidator2" WarningIconImageUrl="" />
<asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtPassword"
    ControlToValidate="txtPasswordAgain" Display="None" ErrorMessage="Mật khẩu nhật lại không khớp"></asp:CompareValidator>
<ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender3"
    HighlightCssClass="validatorCalloutHighlight"  TargetControlID="CompareValidator1" WarningIconImageUrl="" />
<%--txtFullName--%>
<asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ControlToValidate="txtFullName"
    Display="None" ErrorMessage="Bạn chưa nhập họ tên!" />
<ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender5" WarningIconImageUrl=""
    HighlightCssClass="validatorCalloutHighlight" TargetControlID="RequiredFieldValidator2" />        
</asp:Content>

