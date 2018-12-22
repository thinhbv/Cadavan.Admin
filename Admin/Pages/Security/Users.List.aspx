<%@ Page Language="C#" MasterPageFile="~/Controls/AdminPage.master" AutoEventWireup="true" CodeFile="Users.List.aspx.cs" Inherits="Pages_Security_Users_List" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<article>
	<asp:Label ID="lblTtitle" runat="server" Text="Danh sách người dùng" CssClass="title"></asp:Label>
	<div>
		<table id="table1" class="gtable sortable">
			<thead>
				<tr>
					<th>Email</th>
					<th>Họ tên</th>
					<th>Kích hoạt</th>
					<th>Thời gian tạo</th>
					<th>Đăng nhập lần cuối</th>
					<th>Tác vụ</th>
				</tr>
			</thead>
			<tbody>
			    <asp:Repeater ID="rptList" runat="server">
			    <ItemTemplate>
				    <tr>
					    <td><a href="<%=Constant.ADMIN_PATH %><%=Resources.Url.UsersEdit %>?id=<%#Eval("UserID") %>"><%#Eval("Email") %></a></td>
					    <td><%#Eval("FullName") %></td>
					    <td><asp:CheckBox ID="cbxStatus" runat="server" Checked='<%#Convert.ToBoolean(Eval("Status")) %>'></asp:CheckBox>&nbsp;</td>
					    <td><%#Eval("CreatedTime")%></td>
					    <td><%#Eval("LastestTime")%></td>
					    <td>
						    <img class="move" src="/resources/images/icons/arrow-move.png" alt="Move" title="Move" />
						    <a href="<%=Constant.ADMIN_PATH %><%=Resources.Url.UsersEdit %>?id=<%#Eval("UserID") %>" title="Edit"><img src="/resources/images/icons/edit.png" alt="Edit" /></a>
						    <asp:Label ID="lblUserID" runat="server" Visible="false" Text='<%#Eval("UserID") %>'></asp:Label>
					    </td>
				    </tr>
			    </ItemTemplate>
			    </asp:Repeater>
			</tbody>
		</table>
		<div class="tablefooter clearfix">
			<div class="actions">
			    <asp:Button ID="btApply" CssClass="button small" runat="server" Width="80px" OnClick="btApply_Click" Text="Thực hiện"></asp:Button>
			</div>
			<div class="pagination">
                <asp:DropDownList ID="drpGroup" runat="server" DataTextField="Name" DataValueField="GroupID"></asp:DropDownList>
			    <asp:DropDownList ID="drpStatus" runat="server">
			        <asp:ListItem Value="-1">Active:</asp:ListItem>
			        <asp:ListItem Value="1">True</asp:ListItem>
			        <asp:ListItem Value="0">False</asp:ListItem>
			    </asp:DropDownList>
			    <asp:Button ID="btView" CssClass="button small" runat="server" Width="50px" OnClick="btView_Click" Text="Xem"></asp:Button>
			    <asp:Button ID="btAdd" CssClass="button small" runat="server" Width="80px" OnClick="btAdd_Click" Text="Thêm mới"></asp:Button>
			</div>
		</div>
	</div>
</article>
</asp:Content>

