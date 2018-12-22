<%@ Page Title="" Language="C#" MasterPageFile="~/Controls/AdminPage.master" AutoEventWireup="true" CodeFile="Votes.Edit.aspx.cs" Inherits="Pages_Content_Votes_Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<article>
	<asp:Label ID="lblTtitle" runat="server" Text="Thêm mới chuyên mục" CssClass="title"></asp:Label>
    <div class="uniform">
	    <dl class="inline">
			<dt><label for="site_title">Tên thăm dò *</label></dt>
			<dd>
				<asp:TextBox ID="txtTitle" runat="server" TextMode="MultiLine" Height="80px" CssClass="medium"></asp:TextBox>
			</dd>

			<dt><label for="site_logo">Kích hoạt</label></dt>
			<dd>
				<asp:CheckBox ID="cbxIsActive" Checked="true" runat="server"></asp:CheckBox>
			</dd>

			<dt><label for="tagline">Ngày hết hạn *</label></dt>
			<dd>
				<asp:TextBox ID="txtExpireTime" runat="server" CssClass="medium"></asp:TextBox>
			</dd>

			<dt><label for="tagline">Số lượt tham gia</label></dt>
			<dd>
				<asp:TextBox ID="txtCount" runat="server" CssClass="medium"></asp:TextBox>
			</dd>
			<dt><label for="tagline">Đáp án</label></dt>
			<dd>
		    <table id="table1" width="400px" class="gtable">
			    <thead>
				    <tr>
					    <th>Câu trả lời</th>
					    <th>Số lượng</th>
                        <th>Xóa</th>
				    </tr>
			    </thead>
			    <tbody>
			        <asp:Repeater ID="rptList" runat="server">
			        <ItemTemplate>
				        <tr>
					        <td><asp:TextBox ID="txtName" runat="server" Text='<%#Eval("Name")%>' Width="350px" CssClass="medium"></asp:TextBox></td>
					        <td>
                                <asp:TextBox ID="txtCount" runat="server" Text='<%#Eval("Count")%>' Width="40px" CssClass="medium"></asp:TextBox>
                                <asp:Label ID="lblQuestionID" runat="server" Text='<%#Eval("QuestionID")%>' Visible="false"></asp:Label>
                            </td>
                            <td><asp:CheckBox ID="cbxCheck" runat="server"></asp:CheckBox></td>
				        </tr>
			        </ItemTemplate>
			        </asp:Repeater>
                    <tr>
					        <td><asp:TextBox ID="txtAddName" runat="server" Width="350px" CssClass="medium"></asp:TextBox></td>
					        <td>
                                <asp:TextBox ID="txtAddCount" runat="server" Text="0" Width="40px" CssClass="medium"></asp:TextBox>
                            </td>
                            <td>
                    	        <asp:Button ID="btAdd" runat="server" Text="Thêm, Lưu, Xóa" OnClick="btAdd_Click"></asp:Button>
                            </td>
                    </tr>
			    </tbody>
		    </table>
			</dd>
		</dl>
	    <p>
	        <asp:Button ID="btUpdate" runat="server" Text="LƯU" CssClass="button blue" Width="80px" OnClick="btUpdate_Click"></asp:Button>
	        <asp:Button ID="btDelete" runat="server" Text="XOÁ" CssClass="button red" Width="80px" OnClick="btDelete_Click"></asp:Button>
	        <asp:Button ID="btCancel" runat="server" Text="HUỶ" CssClass="button gray" Width="80px" OnClick="btCancel_Click"></asp:Button>
	    </p>
    </div>
</article>
</asp:Content>

