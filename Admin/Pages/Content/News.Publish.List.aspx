<%@ Page Language="C#" MasterPageFile="~/Controls/AdminPage.master" AutoEventWireup="true" CodeFile="News.Publish.List.aspx.cs" Inherits="Pages_Content_News_All_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<article>
	<asp:Label ID="lblTtitle" runat="server" Text="Danh sách tin bài đã xuất bản" CssClass="title"></asp:Label>
	<form>
			<div>
			    <asp:DropDownList ID="drpCate" DataTextField="Alias" DataValueField="CateID" runat="server">
			    </asp:DropDownList>
			    <asp:DropDownList ID="drpAuthor" DataTextField="Email" DataValueField="UserID" runat="server">
			    </asp:DropDownList>
			    <asp:Button ID="btView" runat="server" CssClass="button" OnClick="btView_Click" Text="Xem"></asp:Button>
			    <br /><br />
			</div>
		<table id="table1" class="gtable">
			<thead>
				<tr>
					<th>TT</th>
					<th style="width:400px;">Tiêu đề</th>
					<th>Chuyên mục</th>
					<th>Tác giả</th>
					<th>TG tạo/xuất bản</th>
					<th>Tác vụ</th>
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
					    <td>
					        <%# Eval("CreatedTime", "{0:yyyy-MM-dd HH'h'mm }")%><br />
					        <%# Eval("PublishedTime", "{0:yyyy-MM-dd HH'h'mm }")%><br />
					    </td>
					    <td>
					        <a href="<%=Constant.ADMIN_PATH %><%=Resources.Url.NewsForumList %>?newsid=<%#Eval("NewsID") %>">phản hồi</a><br />
					        <a href="<%=Constant.ADMIN_PATH %><%=Resources.Url.NewsLog %>?newsid=<%#Eval("NewsID") %>">lịch sử</a>
					    </td>
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

