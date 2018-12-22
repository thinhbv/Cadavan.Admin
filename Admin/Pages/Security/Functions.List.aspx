<%@ Page Language="C#" MasterPageFile="~/Controls/AdminPage.master" AutoEventWireup="true" CodeFile="Functions.List.aspx.cs" Inherits="Pages_Security_Functions_List" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<article>
	<asp:Label ID="lblTtitle" runat="server" Text="Danh sách người dùng" CssClass="title"></asp:Label>
	<form>
		<table id="table1" class="gtable">
			<thead>
				<tr>
					<th>Tên quyền</th>
					<th>Url</th>
					<th>Kích hoạt</th>
					<th>Hiển thị</th>
					<th>Thời gian tạo</th>
					<th>Thứ tự</th>
					<th>Tác vụ</th>
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
					    <td><%#Eval("CreatedTime")%></td>
					    <td><%#Eval("Order")%></td>
					    <td>
						    <img class="move" src="/resources/images/icons/arrow-move.png" alt="Move" title="Move" />
						    <a href="<%=Constant.ADMIN_PATH %><%=Resources.Url.FunctionsEdit %>?id=<%#Eval("FunctionID") %>" title="Edit"><img src="/resources/images/icons/edit.png" alt="Edit" /></a>
						    <asp:Label ID="lblFunctionID" runat="server" Visible="false" Text='<%#Eval("FunctionID") %>'></asp:Label>
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
			    <asp:DropDownList ID="drpActive" runat="server">
			        <asp:ListItem Value="-1">Kích hoạt:</asp:ListItem>
			        <asp:ListItem Value="1">True</asp:ListItem>
			        <asp:ListItem Value="0">False</asp:ListItem>
			    </asp:DropDownList>
			    <asp:DropDownList ID="drpDisplay" runat="server">
			        <asp:ListItem Value="-1">Hiển thị:</asp:ListItem>
			        <asp:ListItem Value="1">True</asp:ListItem>
			        <asp:ListItem Value="0">False</asp:ListItem>
			    </asp:DropDownList>
			    <asp:Button ID="btView" CssClass="button small" runat="server" Width="50px" OnClick="btView_Click" Text="Xem"></asp:Button>
			    <asp:Button ID="btAdd" CssClass="button small" runat="server" Width="80px" OnClick="btAdd_Click" Text="Thêm mới"></asp:Button>
			</div>
		</div>
	</form>
</article>
</asp:Content>

