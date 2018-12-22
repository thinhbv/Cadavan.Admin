<%@ Page Title="" Language="C#" MasterPageFile="~/Controls/AdminPage.master" AutoEventWireup="true" CodeFile="Groups.Add.aspx.cs" Inherits="Pages_Security_Groups_Add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<article id="settings">
	<asp:Label ID="lblTtitle" runat="server" Text="Thêm mới nhóm người dùng" CssClass="title"></asp:Label>
	<form class="uniform">
		<ul class="tabs">
			<li><a href="#general">Thông tin</a></li>
			<li><a href="#">Gán quyền</a></li>
		</ul>
		<div class="tabcontent">
			<div id="general">
				<dl class="inline">
					<dt><label for="site_title">Tên nhóm *</label></dt>
					<dd>
						<asp:TextBox ID="txtName" runat="server" CssClass="medium"></asp:TextBox>
					</dd>

					<dt><label for="tagline">Thứ tự *</label></dt>
					<dd>
						<asp:TextBox ID="txtOrder" runat="server" Text="0" CssClass="medium"></asp:TextBox>
						<small>Thứ tự hiển thị</small>
					</dd>

					<dt><label for="site_url">Chú thích *</label></dt>
					<dd>
						<asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Height="60px" CssClass="medium"></asp:TextBox>
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
<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Tên nhóm quá ngắn" Display="None" ControlToValidate="txtName" ValidationExpression=".{2}.*"></asp:RegularExpressionValidator>
<ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender1" Width="160px" HighlightCssClass="validatorCalloutHighlight" TargetControlID="RegularExpressionValidator1" WarningIconImageUrl="" />
</asp:Content>

