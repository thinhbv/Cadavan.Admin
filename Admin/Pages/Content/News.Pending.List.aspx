<%@ Page Language="C#" MasterPageFile="~/Controls/AdminPage.master" AutoEventWireup="true" CodeFile="News.Pending.List.aspx.cs" Inherits="Pages_Content_News_Pending_List" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<article>
	<asp:Label ID="lblTtitle" runat="server" Text="Danh sách tin bài chờ duyệt" CssClass="title"></asp:Label>
	<form>
			<div>
			    <asp:DropDownList ID="drpCate" DataTextField="Alias" DataValueField="CateID" runat="server">
			    </asp:DropDownList>
			    <asp:Button ID="btView" runat="server" CssClass="button" OnClick="btView_Click" Text="Xem"></asp:Button>
			    <br /><br />
			</div>
		<table id="table1" class="gtable sortable">
			<thead>
				<tr>
					<th>TT</th>
					<th>Tiêu đề</th>
					<th>Chuyên mục</th>
					<th>Tác giả</th>
					<th>Thời gian tạo</th>
				</tr>
			</thead>
			<tbody>
			    <asp:Repeater ID="rptList" runat="server">
			    <ItemTemplate>
				    <tr>
					    <td><%#Eval("rownumber")%></td>
					    <td><a href="<%=Constant.ADMIN_PATH %><%=Resources.Url.NewsEdit %>?id=<%#Eval("NewsID") %>&u=<%=HttpUtility.UrlEncode(Request.Url.ToString()) %>"><%#Eval("Title") %></a></td>
					    <td><%#Eval("CateName") %></td>
					    <td><%#Eval("Email") %></td>
					    <td><%# Eval("CreatedTime", "{0:dd/MM/yyyy HH':'mm}")%></td>
				    </tr>
			    </ItemTemplate>
			    </asp:Repeater>
			</tbody>
		</table>
			<div class="pagination">
			    Page:
			    <asp:DropDownList ID="drpPage" runat="server">
			        <asp:ListItem>1</asp:ListItem>
			        <asp:ListItem>2</asp:ListItem>
			    </asp:DropDownList>
			    Size:
			    <asp:DropDownList ID="drpPageSize" runat="server">
			        <asp:ListItem>5</asp:ListItem>
			        <asp:ListItem>10</asp:ListItem>
			        <asp:ListItem Selected="True">20</asp:ListItem>
			        <asp:ListItem>30</asp:ListItem>
			        <asp:ListItem>50</asp:ListItem>
			    </asp:DropDownList>
			    <asp:Label ID="lblTotal" runat="server" Text="(0)"></asp:Label>
			    <asp:Button ID="btPage" CssClass="button small" runat="server" Width="50px" OnClick="btPage_Click" Text="Chuyển"></asp:Button>
			</div>
	</form>
</article>
</asp:Content>

