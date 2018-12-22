<%@ Page Language="C#" MasterPageFile="~/Controls/AdminPage.master" AutoEventWireup="true" CodeFile="NewsCategories.List.aspx.cs" Inherits="Pages_Content_NewsCategories_List" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<article>
	<asp:Label ID="lblTtitle" runat="server" Text="Danh sách chuyên mục tin bài" CssClass="title"></asp:Label>
	<form>
		<table id="table1" class="gtable">
			<thead>
				<tr>
					<th>Tên chuyên mục</th>
					<th>Url</th>
					<th>Hiển thị</th>
					<th>Thứ tự</th>
					<th>Thứ tự</th>
					<th>Tác vụ</th>
				</tr>
			</thead>
			<tbody>
			    <asp:Repeater ID="rptList" runat="server">
			    <ItemTemplate>
				    <tr>
					    <td><a href="<%=Constant.ADMIN_PATH %><%=Resources.Url.NewsCategoriesEdit %>?id=<%#Eval("CateID") %>"><%#Eval("Alias") %></a></td>
					    <td><%#Eval("Url") %></td>
					    <td><asp:CheckBox ID="cbxDisplay" runat="server" Checked='<%#Eval("IsDisplay") %>'></asp:CheckBox>&nbsp;</td>
					    <td><%#Eval("Order")%></td>
					    <td><%#Eval("TotalOrder")%></td>
					    <td>
						    <img class="move" src="/resources/images/icons/arrow-move.png" alt="Move" title="Move" />
						    <a href="<%=Constant.ADMIN_PATH %><%=Resources.Url.NewsCategoriesEdit %>?id=<%#Eval("CateID") %>" title="Edit"><img src="/resources/images/icons/edit.png" alt="Edit" /></a>
					    </td>
				    </tr>
			    </ItemTemplate>
			    </asp:Repeater>
			</tbody>
		</table>
		<div class="tablefooter clearfix">
			<div class="actions">
			</div>
			<div class="pagination">
			    <asp:Button ID="btAdd" CssClass="button small" runat="server" Width="80px" OnClick="btAdd_Click" Text="Thêm mới"></asp:Button>
			</div>
		</div>
	</form>
</article>
</asp:Content>

