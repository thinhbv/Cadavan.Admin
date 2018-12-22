<%@ Page Title="" Language="C#" MasterPageFile="~/Controls/AdminPage.master" AutoEventWireup="true" CodeFile="Groups.List.aspx.cs" Inherits="Pages_Security_Groups_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<article>
	<asp:Label ID="lblTtitle" runat="server" Text="Danh sách nhóm người dùng" CssClass="title"></asp:Label>
	<div>
		<table id="table1" class="gtable sortable">
			<thead>
				<tr>
					<th>Tên nhóm quyền</th>
					<th>Thứ tự</th>
					<th>Chú thích</th>
					<th>Tác vụ</th>
				</tr>
			</thead>
			<tbody>
			    <asp:Repeater ID="rptList" runat="server">
			    <ItemTemplate>
				    <tr>
					    <td><a href="<%=Constant.ADMIN_PATH %><%=Resources.Url.GroupsEdit %>?id=<%#Eval("GroupID") %>"><%#Eval("Name") %></a></td>
					    <td><%#Eval("Order") %></td>
					    <td><%#Eval("Description")%></td>
					    <td>
						    <img class="move" src="/resources/images/icons/arrow-move.png" alt="Move" title="Move" />
						    <a href="<%=Constant.ADMIN_PATH %><%=Resources.Url.GroupsEdit %>?id=<%#Eval("GroupID") %>" title="Edit"><img src="/resources/images/icons/edit.png" alt="Edit" /></a>
						    <asp:Label ID="lblUserID" runat="server" Visible="false" Text='<%#Eval("GroupID") %>'></asp:Label>
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
	</div>
</article>
</asp:Content>

