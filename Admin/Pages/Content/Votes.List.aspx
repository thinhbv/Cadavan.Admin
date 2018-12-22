<%@ Page Title="" Language="C#" MasterPageFile="~/Controls/AdminPage.master" AutoEventWireup="true" CodeFile="Votes.List.aspx.cs" Inherits="Pages_Content_Votes_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<article>
	<asp:Label ID="lblTtitle" runat="server" Text="Danh sách chuyên mục tin bài" CssClass="title"></asp:Label>
	<div>
		<table id="table1" class="gtable">
			<thead>
				<tr>
					<th>Tên thăm dò</th>
					<th>Trả lời</th>
					<th>Thời gian tạo</th>
					<th>Người tạo</th>
					<th>Trạng thái</th>
					<th>Ngày hết hạn</th>
					<th>Tác vụ</th>
				</tr>
			</thead>
			<tbody>
			    <asp:Repeater ID="rptList" runat="server">
			    <ItemTemplate>
				    <tr>
					    <td style="width: 300px;"><a href="<%=Constant.ADMIN_PATH %><%=Resources.Url.VotesEdit %>?id=<%#Eval("VoteID") %>"><%#Eval("Title") %></a></td>
					    <td><%#Eval("Count") %></td>
					    <td><%#Eval("CreatedTime", "{0:dd/MM/yyyy}")%></td>
					    <td><%#Eval("Email")%></td>
					    <td><asp:CheckBox ID="cbxDisplay" runat="server" Checked='<%#Eval("IsActive") %>'></asp:CheckBox>&nbsp;</td>
					    <td><%#Eval("ExpireTime", "{0:dd/MM/yyyy}")%></td>
					    <td>
						    <img class="move" src="/resources/images/icons/arrow-move.png" alt="Move" title="Move" />
						    <a href="<%=Constant.ADMIN_PATH %><%=Resources.Url.VotesEdit %>?id=<%#Eval("VoteID") %>" title="Edit"><img src="/resources/images/icons/edit.png" alt="Edit" /></a>
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

