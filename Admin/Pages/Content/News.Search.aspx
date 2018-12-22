<%@ Page Language="C#" MasterPageFile="~/Controls/AdminPage.master" AutoEventWireup="true" CodeFile="News.Search.aspx.cs" Inherits="Pages_Content_News_Search" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<article>
	<asp:Label ID="lblTtitle" runat="server" Text="Tìm kiếm bài viết" CssClass="title"></asp:Label>
	<form>
			<div>
			    <asp:TextBox ID="txtKeyword" runat="server" Width="150px"></asp:TextBox>
			    <asp:DropDownList ID="drpCate" DataTextField="Alias" DataValueField="CateID" runat="server">
			    </asp:DropDownList>
			    <asp:DropDownList ID="drpAuthor" DataTextField="Email" DataValueField="UserID" runat="server">
			    </asp:DropDownList>
			    <asp:Button ID="btSearch" runat="server" CssClass="button" OnClick="btSearch_Click" Text="Tìm"></asp:Button>
			    <br /><br />
			</div>
		<table id="table1" class="gtable sortable">
			<thead>
				<tr>
					<th>TT</th>
					<th>Tiêu đề</th>
					<th>Chuyên mục</th>
					<th>Tác giả</th>
					<th>TG xuất bản</th>
				</tr>
			</thead>
			<tbody>
			    <asp:Repeater ID="rptList" runat="server">
			    <ItemTemplate>
				    <tr>
					    <td><%#Eval("rownumber")%></td>
					    <td><a href="<%=Constant.ADMIN_PATH %><%=Resources.Url.NewsEdit %>?id=<%#Eval("NewsID") %>"><%#Eval("Title") %></a></td>
					    <td><%#Eval("CateName") %></td>
					    <td><%#Eval("Email") %></td>
					    <td><%# Convert.ToDateTime( Eval("PublishedTime")).ToString("yy/MM/dd HH:mm")%></td>
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
<ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server" TargetControlID="txtKeyword" WatermarkText="Nhập từ khóa"  />
</asp:Content>

