<%@ Page Language="C#" MasterPageFile="~/Controls/AdminPage.master" AutoEventWireup="true" CodeFile="NewsForum.List.aspx.cs" Inherits="Pages_Content_NewsForum_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<article>
	<asp:Label ID="lblTtitle" runat="server" Text="Duyệt phản hồi" CssClass="title"></asp:Label>
	<form>
			<div>
			    <asp:DropDownList ID="drpStatus" runat="server">
			        <asp:ListItem Text="Trạng thái" Value="0"></asp:ListItem>
			        <asp:ListItem Text="Chờ duyệt" Value="1"></asp:ListItem>
			        <asp:ListItem Text="Đã duyệt" Value="2"></asp:ListItem>
			    </asp:DropDownList>
			    <asp:Button ID="btView" runat="server" CssClass="button" OnClick="btView_Click" Text="Xem"></asp:Button>
			    <br /><br />
			</div>
		<table id="table1" class="gtable">
			<thead>
				<tr>
					<th>TT</th>
					<th>Tiêu đề</th>
					<th>Trạng thái</th>
					<th>Email</th>
					<th>Thời gian</th>
					<th>Đính kèm</th>
				</tr>
			</thead>
			<tbody>
			    <asp:Repeater ID="rptList" runat="server">
			    <ItemTemplate>
				    <tr>
					    <td><%#Eval("rownumber")%></td>
					    <td>
					        <a href="<%=Constant.ADMIN_PATH %><%=Resources.Url.NewsForumEdit %>?id=<%#Eval("ForumID") %>&u=<%=HttpUtility.UrlEncode(Request.Url.ToString()) %>"><%#Eval("Title") %></a>
					        <br /><%#Eval("NewsTitle") %> (<a href="<%=Constant.ADMIN_PATH %><%=Resources.Url.NewsForumList %>?newsid=<%#Eval("NewsID") %>">phản hồi</a>)
					    </td>
					    <td><%#Eval("Status") %></td>
					    <td><%#Eval("Email") %></td>
					    <td style="width:120px;"><%#Eval("CreatedTime", "{0:dd-MM-yyyy | HH'h'mm}")%></td>
					    <td align="center"><%#Path(Eval("FileID").ToString()) %></td>
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

