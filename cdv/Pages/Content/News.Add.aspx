<%@ Page Language="C#" MasterPageFile="~/Controls/AdminPage.master" AutoEventWireup="true" CodeFile="News.Add.aspx.cs" Inherits="Pages_Content_News_Add" ValidateRequest="false" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<article>
    <asp:Label ID="lblTtitle" runat="server" Text="Thêm mới tin bài" CssClass="title"></asp:Label>
    <asp:Label ID="lblNewsID" runat="server" Text="0" Visible="false"></asp:Label>
    <asp:Label ID="lblMediaPath" runat="server" Text="" Visible="false"></asp:Label>
    <asp:Label ID="lblMediaPathFull" runat="server" Text="" Visible="false"></asp:Label>
    <div class="uniform">
	    <dl>
		    <dt><label for="newstitle">Tiêu đề</label></dt>
		    <dd><asp:TextBox ID="txtTitle" runat="server" CssClass="big"></asp:TextBox></dd>

		    <dt><label for="newstitle">Tiêu đề phụ</label></dt>
		    <dd><asp:TextBox ID="txtSubTitle" runat="server" CssClass="big"></asp:TextBox></dd>

		    <dt><label for="newstitle">Ảnh đại diện</label></dt>
		    <dd>
		        <small>Upload ảnh ở cuối bài, bài viết nên có ảnh đại diện.</small>
		        <asp:Image ID="imgImageUrl" runat="server"></asp:Image>
		    </dd>

		    <dt><label for="newsintro">Trích dẫn</label></dt>
		    <dd><asp:TextBox ID="txtLead" runat="server" CssClass="big" TextMode="MultiLine" Height="60px"></asp:TextBox></dd>


		    <dt><label for="newsintro">Trích dẫn ngắn</label></dt>
		    <dd><asp:TextBox ID="txtSubLead" runat="server" CssClass="big" TextMode="MultiLine" Height="60px"></asp:TextBox></dd>

		    <dt><label for="newscontent">Nội dung</label></dt>
		    <dd>
                <FTB:FreeTextBox ID="ftbContent" SupportFolder="~/aspnet_client/FreeTextBox/" runat="Server" Width="700px" Height="600px"
                  ToolbarLayout="FontFacesMenu,FontSizesMenu,FontForeColorsMenu,FontForeColorPicker,FontBackColorsMenu,FontBackColorPicker|Bold,Italic,Underline,Strikethrough,Superscript,Subscript,RemoveFormat|JustifyLeft,JustifyRight,JustifyCenter,JustifyFull;BulletedList,NumberedList,Indent,Outdent;CreateLink,Unlink,InsertImage|Cut,Copy,Paste,Delete;Undo,Redo,Print,Save|InsertRule,InsertDate,InsertTime|InsertDiv,EditStyle,InsertImageFromGallery,Preview,SelectAll,WordClean,NetSpell" StartMode="DesignMode" BreakMode="Paragraph" AllowHtmlMode="True"  ToolbarStyleConfiguration="NotSet" UpdateToolbar="True" />
		    </dd>
            <dd>
                <asp:DropDownList ID="drpTool" runat="server">
                    <asp:ListItem Value="1">Thêm box</asp:ListItem>
                </asp:DropDownList>
                <asp:Button ID="btTool" OnClick="btTool_Click" runat="server" Text="Thực hiện"></asp:Button>
            </dd>

		    <dt><label for="newscategory">Chuyên mục xuất bản</label></dt>
		    <dd>
		        <asp:DropDownList ID="drpCate1" DataTextField="Alias" DataValueField="CateID" CssClass="medium" runat="server" onselectedindexchanged="drpCate1_SelectedIndexChanged" AutoPostBack="true">
		        </asp:DropDownList>
		        <asp:DropDownList ID="drpOrder1" runat="server">
		            <asp:ListItem Value="0">Thứ tự:</asp:ListItem>
		        </asp:DropDownList>
		    </dd>
		    <dd>
		        <asp:DropDownList ID="drpCate2" DataTextField="Alias" DataValueField="CateID" CssClass="medium" runat="server" onselectedindexchanged="drpCate2_SelectedIndexChanged" AutoPostBack="true">
		        </asp:DropDownList>
		        <asp:DropDownList ID="drpOrder2" runat="server">
		            <asp:ListItem Value="0">Thứ tự:</asp:ListItem>
		        </asp:DropDownList>
		    </dd>
		    <dd>
		        <asp:DropDownList ID="drpCate3" DataTextField="Alias" DataValueField="CateID" CssClass="medium" runat="server" onselectedindexchanged="drpCate3_SelectedIndexChanged" AutoPostBack="true">
		        </asp:DropDownList>
		        <asp:DropDownList ID="drpOrder3" runat="server">
		            <asp:ListItem Value="0">Thứ tự:</asp:ListItem>
		        </asp:DropDownList>
		    </dd>
		    <dd>
		        <asp:DropDownList ID="drpCate4" DataTextField="Alias" DataValueField="CateID" CssClass="medium" runat="server" onselectedindexchanged="drpCate4_SelectedIndexChanged" AutoPostBack="true">
		        </asp:DropDownList>
		        <asp:DropDownList ID="drpOrder4" runat="server">
		            <asp:ListItem Value="0">Thứ tự:</asp:ListItem>
		        </asp:DropDownList>
		    </dd>
		    <dd>
		        <asp:DropDownList ID="drpCate5" DataTextField="Alias" DataValueField="CateID" CssClass="medium" runat="server" onselectedindexchanged="drpCate5_SelectedIndexChanged" AutoPostBack="true">
		        </asp:DropDownList>
		        <asp:DropDownList ID="drpOrder5" runat="server">
		            <asp:ListItem Value="0">Thứ tự:</asp:ListItem>
		        </asp:DropDownList>
		    </dd>

		    <dt><label for="newsdate">Thời gian xuất bản</label></dt>
		    <dd><asp:TextBox ID="txtPublishTime" runat="server" Width="200px"></asp:TextBox></dd>

		    <dt>
                <asp:CheckBox ID="chkIsPhoto" runat="server" Text="Photo"></asp:CheckBox>
                <asp:CheckBox ID="chkIsVideo" runat="server" Text="Video"></asp:CheckBox>
                <asp:CheckBox ID="chkIsAudio" runat="server" Text="Audio"></asp:CheckBox>
            </dt>
		    <dd></dd>

		    <dt><label for="newstitle">Từ khóa</label></dt>
		    <dd>
		        <asp:TextBox ID="txtTags" runat="server" CssClass="big"></asp:TextBox>
		        <small>Mỗi từ khóa cách nhau một dấu phẩy ','</small>
		    </dd>
	    </dl>
	    <p>
	        <asp:Button ID="btSave" runat="server" Text="LƯU" OnClick="btSave_Click" CssClass="button small blue" Width="80px"></asp:Button>
	        <asp:Button ID="btPublish" runat="server" Text="XUẤT BẢN" OnClick="btPubish_Click" CssClass="button small green" Width="80px"></asp:Button>
	        <asp:Button ID="btDelete" runat="server" Text="XOÁ" OnClick="btDelete_Click" CssClass="button small red" Width="80px"></asp:Button>
	        <asp:Button ID="btCancel" runat="server" Text="HUỶ" OnClick="btCancel_Click" CssClass="button small gray" Width="80px"></asp:Button>
	    </p>
    </div>
</article>
	
<asp:Panel ID="Panel1" runat="server" Visible="false">
<article>
    <span class="title">Tin bài liên quan</span>
    <p>
        <asp:TextBox ID="txtRelatedID" runat="server"></asp:TextBox>
        <asp:Button ID="btRelatedAdd" runat="server" Text="Thêm" OnClick="btRelatedAdd_Click" CssClass="button blue" Width="80px"></asp:Button>
    </p>
    <ul class="news">
        <asp:Repeater ID="rptRelatedList" runat="server">
        <ItemTemplate>
	    <li>
		    <asp:CheckBox ID="cbxRelatedStatus" runat="server"></asp:CheckBox> <%#Eval("Title") %>
		    <asp:Label ID="lblRelatedID" Visible="false" runat="server" Text='<%#Eval("NewsID") %>'></asp:Label>
		    <div class="date"><%#Eval("PublishedTime")%></div>
	    </li>
        </ItemTemplate>
        </asp:Repeater>
    </ul>
    <p>
        <asp:Button ID="btRelatedRemove" runat="server" Text="Xóa" OnClick="btRelatedRemove_Click" CssClass="button red" Width="80px" ></asp:Button>
    </p>
</article>
<ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server"
    TargetControlID="txtRelatedID" WatermarkText="Nhập ID bài viết" />
</asp:Panel>

<article>
    <asp:Panel ID="panelImageList" runat="server">
    <span class="titlesmall">Ảnh trong bài</span>
	<table id="table1" class="gtable">
		<tbody>
			<asp:Repeater ID="rptMediaList" runat="server">
			<ItemTemplate>
				<tr>
					<td><%#Eval("rownumber")%></td>
					<td><img src="<%=Constant.MEDIA_PATH %><%#Eval("Path") %>" width="100"/></td>
					<td><asp:TextBox ID="txtMediaDescription" Text='<%#Eval("Description") %>' Width="400px" runat="server"></asp:TextBox></td>
					<td><asp:TextBox ID="txtMediaOrder" Text='<%#Eval("Order") %>' Width="20px" MaxLength="2" runat="server"></asp:TextBox></td>
					<td><asp:CheckBox ID="cbxMediaAction" runat="server"></asp:CheckBox>&nbsp;<asp:Label ID="lblNewsMediaID" runat="server" Text='<%#Eval("NewsMediaID") %>' Visible="false"></asp:Label></td>
				</tr>
			</ItemTemplate>
			</asp:Repeater>
		</tbody>
	</table>
	<div class="tablefooter clearfix" style="padding: 5px 30px 0 0; text-align:right;">
	    <asp:Button ID="btUpdateImage" CssClass="button small" runat="server" Width="60px" OnClick="btUpdateImage_Click" Text="Cập nhật"></asp:Button>
	    <asp:Button ID="btDeleteImage" CssClass="button small" runat="server" Width="50px" OnClick="btDeleteImage_Click" Text="Xóa"></asp:Button>
	    <asp:Button ID="btUpdateAvatar" CssClass="button small" runat="server" Width="90px" OnClick="btUpdateAvatar_Click" Text="Thay đại diện"></asp:Button>
	</div>
    </asp:Panel>
    <span class="titlesmall" style="padding-top:10px;">Upload nhiều ảnh</span>
    <div class="uniform">
	    <dl>
		    <dd style="padding-top:10px;">
		        <small>Chú ý: các ảnh upload đều cần có chú thích ảnh, kích cỡ tối đa 800 x 600 px, độ lớn 200Kb.</small>
		    </dd>
	        <dt>
                <asp:TextBox ID="txtImageDescription1"  Width="400px" runat="server"></asp:TextBox>
                <asp:FileUpload ID="FileUpload1" runat="server"></asp:FileUpload>
                <asp:CheckBox ID="cbIsAvatar1" runat="server" Text="Chọn là ảnh đại diện"></asp:CheckBox>
            </dt>
	        <dt style="padding-top:10px;">
                <asp:TextBox ID="txtImageDescription2"  Width="400px" runat="server"></asp:TextBox>
                <asp:FileUpload ID="FileUpload2" runat="server"></asp:FileUpload>
                <asp:CheckBox ID="cbIsAvatar2" runat="server" Text="Chọn là ảnh đại diện"></asp:CheckBox>
            </dt>
	        <dt style="padding-top:10px;">
                <asp:TextBox ID="txtImageDescription3"  Width="400px" runat="server"></asp:TextBox>
                <asp:FileUpload ID="FileUpload3" runat="server"></asp:FileUpload>
                <asp:CheckBox ID="cbIsAvatar3" runat="server" Text="Chọn là ảnh đại diện"></asp:CheckBox>
            </dt>
	        <dt style="padding-top:10px;">
                <asp:TextBox ID="txtImageDescription4"  Width="400px" runat="server"></asp:TextBox>
                <asp:FileUpload ID="FileUpload4" runat="server"></asp:FileUpload>
                <asp:CheckBox ID="cbIsAvatar4" runat="server" Text="Chọn là ảnh đại diện"></asp:CheckBox>
            </dt>
	        <dt style="padding-top:10px;">
                <asp:TextBox ID="txtImageDescription5"  Width="400px" runat="server"></asp:TextBox>
                <asp:FileUpload ID="FileUpload5" runat="server"></asp:FileUpload>
                <asp:CheckBox ID="cbIsAvatar5" runat="server" Text="Chọn là ảnh đại diện"></asp:CheckBox>
            </dt>
        </dl>
    <//div>
	<div class="tablefooter clearfix" style="padding: 5px 30px 0 0; text-align:right;">
	    <asp:Button ID="btImageUpload" CssClass="button small" runat="server" Width="60px" OnClick="btImageUpload_Click" Text="Upload"></asp:Button>
	</div>
</article>

<%--txtTitle--%>
<asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="txtTitle" Display="None" ErrorMessage="Bạn chưa nhập tiêu đề!" />
<ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender1" WarningIconImageUrl="" HighlightCssClass="validatorCalloutHighlight" TargetControlID="RequiredFieldValidator1" />        

<%--Upload ảnh--%>
<ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server" TargetControlID="txtImageDescription1" WatermarkText="Nhập chú thích ảnh" />
<ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender3" runat="server" TargetControlID="txtImageDescription2" WatermarkText="Nhập chú thích ảnh" />
<ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender4" runat="server" TargetControlID="txtImageDescription3" WatermarkText="Nhập chú thích ảnh" />
<ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender5" runat="server" TargetControlID="txtImageDescription4" WatermarkText="Nhập chú thích ảnh" />
<ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender6" runat="server" TargetControlID="txtImageDescription5" WatermarkText="Nhập chú thích ảnh" />
<ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender7" runat="server" TargetControlID="txtTitle" WatermarkText="Nhập tiêu đề bài viết" />
<ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender8" runat="server" TargetControlID="txtLead" WatermarkText="Nhập trích dẫn của bài viết, độ dài không quá 90 từ, tương đương 5 dòng nhập liệu." />
<ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender9" runat="server" TargetControlID="txtSubLead" WatermarkText="Nhập trích dẫn ngắn, độ dài không quá 60 từ, tương đương 3 dòng nhập liệu." />
</asp:Content>

