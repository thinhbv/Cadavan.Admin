<%@ Page Language="C#" MasterPageFile="~/Controls/AdminPage.master" AutoEventWireup="true" CodeFile="News.Log.aspx.cs" Inherits="Pages_Content_News_Log" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<article>
	<asp:Label ID="lblTtitle" runat="server" Text="Lịch sử cập nhật tin bài" CssClass="title"></asp:Label>
	<form>
		<table id="table1" class="gtable">
			<thead>
				<tr>
					<th>TT</th>
					<th style="width:400px;">Tiêu đề</th>
					<th>Người dùng</th>
					<th>Tác vụ</th>
					<th>Thời gian</th>
				</tr>
			</thead>
			<tbody>
			    <asp:Repeater ID="rptList" runat="server">
			    <ItemTemplate>
				    <tr>
					    <td><%#Eval("rownumber")%></td>
					    <td><%# Eval("Title")%></td>
					    <td><%# Eval("Email")%></td>
					    <td><%#Eval("Description")%></td>
					    <td><%# Eval("LogTime", "{0:yyyy-MM-dd HH':'mm}")%></td>
				    </tr>
			    </ItemTemplate>
			    </asp:Repeater>
			</tbody>
		</table>
	</form>
</article>
</asp:Content>

