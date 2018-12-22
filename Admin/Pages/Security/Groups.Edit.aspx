<%@ Page Title="" Language="C#" MasterPageFile="~/Controls/AdminPage.master" AutoEventWireup="true" CodeFile="Groups.Edit.aspx.cs" Inherits="Pages_Security_Groups_Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<article id="settings">
	<asp:Label ID="lblTtitle" runat="server" Text="Cập nhật thông tin người dùng" CssClass="title"></asp:Label>
	<div class="uniform">
		<ul class="tabs">
			<li><a href="#general">Thông tin</a></li>
			<li><a href="#security">Gán quyền</a></li>
		</ul>
		<div class="tabcontent">
			<div id="general">
				<dl class="inline">
					<dt><label for="site_title">Tên nhóm quyền *</label></dt>
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
		                <asp:Repeater ID="rptList" runat="server">
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
		</div>
	</div>
</article>
<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Tên nhóm quá ngắn" Display="None" ControlToValidate="txtName" ValidationExpression=".{2}.*"></asp:RegularExpressionValidator>
<ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender1" Width="160px" HighlightCssClass="validatorCalloutHighlight" TargetControlID="RegularExpressionValidator1" WarningIconImageUrl="" />
</asp:Content>

