<%@ Page Language="C#" MasterPageFile="~/Controls/AdminPage.master" AutoEventWireup="true"
    CodeFile="Users.Edit.aspx.cs" Inherits="Pages_Security_Users_Edit" EnableEventValidation="false" %>
<%@ Register Src="~/Controls/Progress.ascx" TagName="ProgressControl" TagPrefix="uc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<article id="settings">
	<asp:Label ID="lblTtitle" runat="server" Text="Cập nhật thông tin người dùng" CssClass="title"></asp:Label>
	<form class="uniform">
		<ul class="tabs">
			<li><a href="#general">Thông tin</a></li>
			<li><a href="#security">Gán quyền</a></li>
			<li><a href="#history">Lịch sử</a></li>
		</ul>
		<div class="tabcontent">
			<div id="general">
				<dl class="inline">
					<dt><label for="site_title">Email *</label></dt>
					<dd>
						<asp:TextBox ID="txtEmail" runat="server" CssClass="medium" ReadOnly="true"></asp:TextBox>
						<small>Email sử dụng để đăng nhập hệ thống.</small>
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

					<dt><label for="site_logo">Nhóm người dùng</label></dt>
					<dd>
                        <asp:DropDownList ID="drpGroup" DataTextField="Name" DataValueField="GroupID" runat="server"></asp:DropDownList>
					</dd>

					<dt><label for="site_logo">Kích hoạt</label></dt>
					<dd>
						<asp:CheckBox ID="chkIsActive" runat="server"></asp:CheckBox>
						<small>Chọn để cho phép người dùng đăng nhập</small>
					</dd>
				</dl>
		        <div class="buttons">
		            <asp:Button ID="btUpdate" runat="server" CssClass="button" Text="Cập nhật" OnClick="btUpdate_Click"></asp:Button>
		            <asp:Button ID="btCancel" runat="server" CssClass="button white" Text="Bỏ qua" CausesValidation="false" OnClick="btCancel_Click"></asp:Button>
		        </div>
			</div>
			<div id="security">
	            <table id="table1" class="gtable sortable">
		            <thead>
			            <tr>
				            <th>Tên quyền</th>
				            <th>Url</th>
					        <th>Kích hoạt</th>
					        <th>Hiển thị</th>
				            <th>Gán quyền</th>
			            </tr>
		            </thead>
		            <tbody>
		                <asp:Repeater ID="rptFunctionList" runat="server">
		                <ItemTemplate>
			                <tr>
				                <td><a href="<%=Constant.ADMIN_PATH %><%=Resources.Url.FunctionsEdit %>?id=<%#Eval("FunctionID") %>"><%#Eval("Alias") %></a></td>
				                <td><%#Eval("Url") %></td>
				                <td><asp:CheckBox ID="cbxActive" runat="server" Checked='<%#Eval("IsActive") %>'></asp:CheckBox>&nbsp;</td>
        					    <td><asp:CheckBox ID="cbxDisplay" runat="server" Checked='<%#Eval("IsDisplay") %>'></asp:CheckBox>&nbsp;</td>
        					    <td><asp:CheckBox ID="cbxRole" runat="server"></asp:CheckBox>&nbsp;<asp:Label ID="lblFunctionID" Visible="false" runat="server" Text='<%#Eval("FunctionID") %>'></asp:Label></td>
			                </tr>
		                </ItemTemplate>
		                </asp:Repeater>
		            </tbody>
	            </table>
	            <div class="tablefooter clearfix">
		            <div class="actions">
		                <asp:Button ID="btApply" CssClass="button small" runat="server" Width="80px" Text="Gán quyền" OnClick="btApply_Click"></asp:Button>
		            </div>
		            <div class="pagination">
		            </div>
	            </div>
			</div>
			<div id="history">
			</div>
		</div>
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
<%--txtFullName--%>
<asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ControlToValidate="txtFullName"
    Display="None" ErrorMessage="Bạn chưa nhập họ tên!" />
<ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender5" WarningIconImageUrl=""
    HighlightCssClass="validatorCalloutHighlight" TargetControlID="RequiredFieldValidator2" />        
</asp:Content>
