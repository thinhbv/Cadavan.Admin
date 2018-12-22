<%@ Page Language="C#" MasterPageFile="~/Controls/AdminPage.master" AutoEventWireup="true" CodeFile="News.Royalty.aspx.cs" Inherits="Pages_Content_News_Royalty" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<article>
    <asp:Label ID="lblTtitle" runat="server" Text="Chấm nhuận bút" CssClass="title"></asp:Label>
    <div class="uniform">
		<div>
		    <asp:DropDownList ID="drpYear" runat="server">
		    </asp:DropDownList>
		    <asp:DropDownList ID="drpMonth" runat="server">
		    </asp:DropDownList>
		    <asp:DropDownList ID="drpDay" runat="server">
		    </asp:DropDownList>
		    <asp:DropDownList ID="drpAuthor" DataTextField="Email" DataValueField="UserID" runat="server">
		    </asp:DropDownList>
		    <asp:Button ID="btView" runat="server" CssClass="button" OnClick="btView_Click" Text="Xem"></asp:Button>
		    <br /><br />
		</div>
        <table id="table2" class="gtable">
			<thead>
				<tr>
					<th>TT</th>
					<th>Tiêu đề</th>
					<th>Thời gian</th>
					<th>Nhuận bút</th>
					<th>Điểm</th>
					<th>Tác giả</th>
					<th>Lớp</th>
				</tr>
			</thead>
			<tbody>
	            <asp:Repeater ID="rptList" runat="server">
	            <ItemTemplate>
	            <tr>
			        <td><%#Eval("rownumber")%></td>
			        <td style="width:400px">
                        <a href="<%=Constant.ADMIN_PATH %><%=Resources.Url.NewsEdit %>?id=<%#Eval("NewsID") %>&u=<%=HttpUtility.UrlEncode(Request.Url.ToString()) %>"><%#Eval("Title") %></a>
                        <br />Chuyên mục: <%#Eval("CateName") %>, người đăng: <%#Eval("Email")%>
                     </td>
			        <td><%# Convert.ToDateTime(Eval("CreatedTime")).ToString("dd/MM/yyyy")%></td>
			        <td><asp:TextBox Width="50px" ID="txtRoyalties" Text='<%#Eval("Royalties")%>' runat="server"></asp:TextBox><asp:Label ID="lblNewsID" runat="server" Text='<%#Eval("NewsID") %>' Visible="false"></asp:Label></td>
			        <td><asp:TextBox Width="30px" ID="txtPoints" Text='<%#Eval("Points")%>' runat="server"></asp:TextBox></td>
			        <td><asp:TextBox Width="120px" ID="txtFullName" Text='<%#Eval("FullName")%>' runat="server"></asp:TextBox></td>
			        <td><asp:TextBox Width="120px" ID="txtClass" Text='<%#Eval("Class")%>' runat="server"></asp:TextBox></td>
			    </tr>
			    </ItemTemplate>
			    </asp:Repeater>
			</tbody>
		</table>
		<div class="pagination">
		    <asp:Label ID="lblTotalRecord" runat="server" Text="Bài viết: 0"></asp:Label>
		    , <asp:Label ID="lblTotalRoyalty" runat="server" Text="Nhuận bút: 0"></asp:Label>, Page:
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
		    <asp:Button ID="btPage" CssClass="button small" runat="server" Width="50px" OnClick="btPage_Click" Text="Chuyển"></asp:Button>
		    <asp:Button ID="btSave" CssClass="button small" runat="server" Width="70px" OnClick="btSave_Click" Text="Cập nhật" Visible="false"></asp:Button>
		</div>
    </div>
</article>
	
</asp:Content>

