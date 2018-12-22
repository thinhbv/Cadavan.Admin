<%@ Page Title="" Language="C#" MasterPageFile="~/Controls/AdminPage.master" AutoEventWireup="true" CodeFile="News.Media.aspx.cs" Inherits="Pages_Content_News_Media" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<article>
    <asp:Panel ID="upload_HeaderPanel" runat="server" style="cursor: pointer;">
        <asp:ImageButton ID="upload_ToggleImage" runat="server" AlternateText="collapse" />
        <span class="titlesmall">Upload file</span>
    </asp:Panel>
    <asp:Panel ID="upload_ContentPanel" style="overflow:hidden;" runat="server">
		<dl class="inline">
			<dt><label for="site_title">Chọn file: </label></dt>
			<dd>
			    <asp:FileUpload ID="fuFileUpload" runat="server"></asp:FileUpload><br />
			    <asp:Label ID="lblFileID" runat="server" Visible="false"></asp:Label>
			</dd>

			<dt><label for="site_title">Chú thích:</label></dt>
			<dd>
                <asp:TextBox ID="txtDescription" runat="server" CssClass="medium" Width="500px"></asp:TextBox>
			    <small>Nhập chú thích ảnh, chú thích video,...</small>
            </dd>

			<dt><label for="site_title">Từ khóa:</label></dt>
			<dd>
			    <asp:TextBox ID="txtTags" TextMode="MultiLine" Rows="3" class="medium" runat="server" Width="500px"></asp:TextBox>
			    <small>Từ khóa để tìm kiếm</small>
			</dd>

			<dt><label for="site_title">Thứ tự</label></dt>
			<dd>
			    <asp:TextBox ID="txtOrder" Text="0" class="medium" runat="server" Width="500px"></asp:TextBox>
			    <small>Thứ tự hiển thị nếu làm slide</small>
			</dd>
		</dl>
	    <asp:Button ID="btUpload" CssClass="button green" runat="server" Text="Upload" OnClick="btUpload_Click"></asp:Button>
		<asp:Button ID="btCancel" CssClass="button white" runat="server" Text="Làm lại" OnClick="btCancel_Click"></asp:Button>
    </asp:Panel>
</article>

<article>
	<asp:Label ID="lblTtitle" runat="server" Text="Danh sách file" CssClass="title"></asp:Label>
	<form>
		<table id="table1" class="gtable">
			<thead>
				<tr>
					<th>TT</th>
					<th style="width: 250px;">Hiển thị</th>
					<th style="width: 150px;">Chú thích</th>
                    <th>Url</th>
					<th>Người upload</th>
					<th>Thời gian</th>
					<th>Chọn</th>
				</tr>
			</thead>
			<tbody>
			    <asp:Repeater ID="rptList" runat="server">
			    <ItemTemplate>
				    <tr>
					    <td><%#Eval("rownumber")%></td>
					    <td><asp:Literal ID="ltrHtml" Text='<%#GetHtml(Eval("Path").ToString()) %>' runat="server"></asp:Literal></td>
					    <td><%#Eval("Description") %></td>
                        <td><asp:TextBox ID="txtPath" Text='<%#Eval("Path") %>' TextMode="MultiLine" Width="200px" runat="server"></asp:TextBox></td>
					    <td><%#Eval("Email") %></td>
					    <td nowrap><%#Convert.ToDateTime(Eval("UploadTime")).ToString("yy/MM/dd HH'h':mm")%></td>
					    <td><asp:CheckBox ID="cbxAction" runat="server"></asp:CheckBox>&nbsp;<asp:Label ID="lblNewsMediaID" runat="server" Text='<%#Eval("NewsMediaID") %>' Visible="false"></asp:Label></td>
				    </tr>
			    </ItemTemplate>
			    </asp:Repeater>
			</tbody>
		</table>
	</form>
		<div class="tablefooter clearfix">
			<div class="pagination">
			    <asp:Button ID="btEdit" CssClass="button small" runat="server" Width="50px" OnClick="btEdit_Click" Text="Sửa"></asp:Button>
			</div>
		</div>
</article>

<ajaxToolkit:CollapsiblePanelExtender ID="cpeUpload" runat="Server"
    TargetControlID="upload_ContentPanel"
    ExpandControlID="upload_HeaderPanel"
    CollapseControlID="upload_HeaderPanel"
    ExpandedSize="0"
    ExpandDirection="Vertical"
    Collapsed="true"
    ExpandedImage="~/resources/images/collapse.jpg"
    CollapsedImage="~/resources/images/expand.jpg" 
    ImageControlID="upload_ToggleImage" /> 
</asp:Content>

