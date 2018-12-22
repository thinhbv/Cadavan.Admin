<%@ Page Language="C#" MasterPageFile="~/Controls/AdminPage.master" AutoEventWireup="true" CodeFile="News.List.aspx.cs" Inherits="Pages_Content_News_List" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<article>
	<asp:Label ID="lblTtitle" runat="server" Text="Danh sách tin bài của bạn" CssClass="title"></asp:Label>
	<form>
		<div style="margin: 0px 0px 10px 0px;">
		    Trạng thái: <asp:DropDownList ID="drpStatus" runat="server">
		        <asp:ListItem Text="Chờ duyệt" Value="2"></asp:ListItem>
		        <asp:ListItem Text="Đã xuất bản" Value="3"></asp:ListItem>
		    </asp:DropDownList>
		    <asp:Button ID="btView" runat="server" CssClass="button" OnClick="btView_Click" Text="Xem"></asp:Button>
		</div>
		<table id="table1" class="gtable">
			<thead>
				<tr>
					<th>TT</th>
					<th style="width:400px;">Tiêu đề</th>
					<th>Chuyên mục</th>
					<th>Thời gian tạo</th>
					<th>TG xuất bản</th>
					<th>Lịch sử</th>
				</tr>
			</thead>
			<tbody>
			    <asp:Repeater ID="rptList" runat="server">
			    <ItemTemplate>
				    <tr>
					    <td><%#Eval("rownumber")%></td>
					    <td style="width:420px;"><a href="#"><%#Eval("Title") %></a></td>
					    <td><%#Eval("CateName") %></td>
					    <td><%# Eval("CreatedTime", "{0:dd/MM/yyyy HH':'mm}")%></td>
					    <td><%# Eval("PublishedTime", "{0:dd/MM/yyyy HH':'mm}")%></td>
					    <td><a href="#">xem</a></td>
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

