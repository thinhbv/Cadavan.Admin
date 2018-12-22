<%@ Page Language="C#" MasterPageFile="~/Controls/AdminPage.master" AutoEventWireup="true" CodeFile="MediaFile.List.aspx.cs" Inherits="Pages_Content_MediaFile_List" EnableEventValidation="false" %>

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
			<dd><asp:TextBox ID="txtDescription" runat="server" CssClass="medium" Width="500px"></asp:TextBox></dd>

			<dt><label for="site_title">Từ khóa:</label></dt>
			<dd>
			    <asp:TextBox ID="txtTags" TextMode="MultiLine" Rows="3" class="medium" runat="server" Width="500px"></asp:TextBox>
			    <small>Từ khóa để tìm kiếm</small>
			</dd>

			<dt><label for="site_title">Url:</label></dt>
			<dd><asp:TextBox ID="txtPath" runat="server" ReadOnly="" TextMode="MultiLine" Rows="2" CssClass="medium" Width="500px"></asp:TextBox></dd>

			<dt><label for="site_title">Mã HTML:</label></dt>
			<dd>
			    <asp:TextBox ID="txtHTML" TextMode="MultiLine" Rows="3" class="medium" runat="server" Width="500px"></asp:TextBox>
			    <small>Copy mã HTML để sử dụng trong bài viết</small>
			</dd>

			<dt><label for="site_title">Hiển thị:</label></dt>
			<dd>
			<asp:Literal ID="ltrHTML" runat="server"></asp:Literal>
			</dd>

		</dl>
	    <asp:Button ID="btUpload" CssClass="button green" runat="server" Text="Upload" OnClick="btUpload_Click"></asp:Button>
		<asp:Button ID="btSave" CssClass="button" runat="server" Text="Lưu" Visible="false" OnClick="btSave_Click"></asp:Button>
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
					<th style="width: 300px;">Hiển thị</th>
					<th style="width: 180px;">Chú thích</th>
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
					    <td><%#Eval("Email") %></td>
					    <td nowrap><%#Convert.ToDateTime(Eval("UploadTime")).ToString("yy/MM/dd HH'h':mm")%></td>
					    <td><asp:CheckBox ID="cbxAction" runat="server"></asp:CheckBox>&nbsp;<asp:Label ID="lblFileID" runat="server" Text='<%#Eval("FileID") %>' Visible="false"></asp:Label></td>
				    </tr>
			    </ItemTemplate>
			    </asp:Repeater>
			</tbody>
		</table>
	</form>
		<div class="tablefooter clearfix">
			<div class="actions">
			    <asp:TextBox ID="txtKeyword" Width="120px" CssClass="medium" MaxLength="80" runat="server"></asp:TextBox>
			    <asp:DropDownList ID="drpExt" runat="server">
			        <asp:ListItem Value="">Loại file: </asp:ListItem>
			        <asp:ListItem>jpg</asp:ListItem>
			        <asp:ListItem>gif</asp:ListItem>
			        <asp:ListItem>png</asp:ListItem>
			        <asp:ListItem>flv</asp:ListItem>
			        <asp:ListItem>zip</asp:ListItem>
			        <asp:ListItem>rar</asp:ListItem>
			        <asp:ListItem>doc</asp:ListItem>
			        <asp:ListItem>docx</asp:ListItem>
			        <asp:ListItem>pdf</asp:ListItem>
			    </asp:DropDownList>
			    <asp:DropDownList ID="drpUser" runat="server">
			        <asp:ListItem Value="0">File của bạn</asp:ListItem>
			        <asp:ListItem Value="0">Tất cả</asp:ListItem>
			    </asp:DropDownList>
			    <asp:Button ID="btSearch" CssClass="button small" runat="server" Width="50px" OnClick="btSearch_Click" Text="Tìm"></asp:Button>
			    <asp:Button ID="btApply" CssClass="button small" runat="server" Width="50px" OnClick="btApply_Click" Text="Sửa"></asp:Button>
			</div>
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
		</div>
</article>

<ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server" TargetControlID="txtKeyword" WatermarkText="Nhập từ khóa"  />

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

