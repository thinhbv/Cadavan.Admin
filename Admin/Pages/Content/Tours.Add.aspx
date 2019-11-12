<%@ Page Title="" Language="C#" MasterPageFile="~/Controls/AdminPage.master" ValidateRequest="false" AutoEventWireup="true" CodeFile="Tours.Add.aspx.cs" Inherits="Pages_Content_Tours_Add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
	<article>
		<asp:HiddenField ID="hdId" runat="server" />
		<div class="main-header clearfix">
			<div class="page-title">
				<h3 class="no-margin">
					<%=pagetitle %>
				</h3>
			</div>
		</div>
		<div class="padding-md">
			<div class="panel panel-default">
				<div class="panel-body">
					<div class="row">
						<label class="col-lg-2 control-label">Tên Tour</label>
						<div class="col-md-10">
							<div class="form-group">
								<input type="text" runat="server" class="form-control input-sm" id="txtName" placeholder="Tên tour">
							</div>
							<!-- /form-group -->
						</div>
						</div>
					<div class="row">
						<label class="col-lg-2 control-label">Hình ảnh đại diện</label>
						<div class="col-md-10">
							<div class="form-group">
								<asp:Image ID="imgImage" runat="server" Width="300" />
							</div>
							<!-- /form-group -->
							<div class="form-group">
								<asp:FileUpload ID="fuImage" runat="server"></asp:FileUpload>
							</div>
							<!-- /form-group -->
						</div>
					</div>
					<div class="row">
						<label class="col-lg-2 control-label">Thời gian tour</label>
						<div class="col-md-10">
							<div class="form-group">
								<input type="text" runat="server" class="form-control input-sm" id="txtPeriod" placeholder="Thời gian Tour">
							</div>
							<!-- /form-group -->
						</div>
						</div>
					<div class="row">
						<label class="col-lg-2 control-label">Lịch khởi hành</label>
						<div class="col-md-10">
							<div class="form-group">
								<input type="text" runat="server" class="form-control input-sm" id="txtAgenda" placeholder="Lịch khởi hành">
							</div>
							<!-- /form-group -->
						</div>
						</div>
					<div class="row">
						<label class="col-lg-2 control-label">Giá Tour</label>
						<div class="col-md-10">
							<div class="form-group">
								<input type="text" runat="server" class="form-control input-sm" id="txtPrice" placeholder="Giá">
							</div>
							<!-- /form-group -->
						</div>
					</div>
					<div class="row">
						<label class="col-lg-2 control-label">Hình ảnh về Tour</label>
						<div class="col-md-10">
							<div class="form-group">
								<asp:FileUpload ID="fuImages" runat="server" AllowMultiple="true"></asp:FileUpload>
							</div>
							<!-- /form-group -->
						</div>
						<div class="col-md-10">		
							<div class="form-group">
								<asp:Button id="btnUpLoad" type="button" runat="server" cssclass="btn btn-success btn-sm" Text="Upload" OnClick="btnUpLoad_Click"></asp:Button>
							</div>
							<!-- /form-group -->
						</div>
					</div>
					<div class="row">
						<label class="col-lg-2 control-label">Chi tiết Tour</label>
						<div class="col-md-10">
							<div class="form-group">
								<FTB:FreeTextBox ID="ftbContent" SupportFolder="~/aspnet_client/FreeTextBox/" runat="Server" Width="100%" Height="600px"
									 ToolbarLayout="FontFacesMenu,FontSizesMenu,FontForeColorsMenu,FontForeColorPicker,FontBackColorsMenu,FontBackColorPicker|Bold,Italic,Underline,Strikethrough,Superscript,Subscript,RemoveFormat|JustifyLeft,JustifyRight,JustifyCenter,JustifyFull;BulletedList,NumberedList,Indent,Outdent;CreateLink,Unlink,InsertImage|Cut,Copy,Paste,Delete;Undo,Redo,Print,Save|InsertRule,InsertDate,InsertTime|InsertDiv,EditStyle,InsertImageFromGallery,Preview,SelectAll,WordClean,NetSpell" StartMode="DesignMode" BreakMode="Paragraph" AllowHtmlMode="True"  ToolbarStyleConfiguration="NotSet" UpdateToolbar="True" />
							</div>
							<!-- /form-group -->
						</div>
					</div>
					<div class="row">
						<label class="col-lg-2 control-label">Loại Tour</label>
						<div class="col-md-10">
							<div class="form-group">
								<asp:DropDownList ID="ddlType" CssClass="form-control input-sm inline-block" runat="server">
									<asp:ListItem Value="0">Nội địa</asp:ListItem>
									<asp:ListItem Value="1">Quốc tế</asp:ListItem>
								</asp:DropDownList>
							</div>
							<!-- /form-group -->
						</div>
					</div>
					<div class="row">
						<label class="col-lg-2 control-label">Ưu tiên hiển thị</label>
						<div class="col-md-10">
							<div class="form-group">
								<label class="label-checkbox">
									<input id="chkPriority" runat="server" type="checkbox" />
									<span class="custom-checkbox"></span>
									Ưu tiên hiển thị
								</label>
							</div>
							<!-- /form-group -->
						</div>
					</div>
					<div class="row">
						<label class="col-lg-2 control-label">Từ khóa</label>
						<div class="col-md-10">
							<div class="form-group">
								<input type="text" runat="server" class="form-control input-sm" id="txtKeywords" placeholder="Từ khóa tìm kiếm" />
							</div>
							<!-- /form-group -->
						</div>
					</div>
					<div class="row">
						<label class="col-lg-2 control-label">Trạng thái</label>
						<div class="col-md-10">
							<div class="form-group">
								<asp:DropDownList ID="drpStatus" CssClass="form-control input-sm inline-block" runat="server">
									<asp:ListItem Value="0">Kích hoạt</asp:ListItem>
									<asp:ListItem Value="1">Hết hạn</asp:ListItem>
								</asp:DropDownList>
							</div>
							<!-- /form-group -->
						</div>
					</div>
					<div class="row">
						<div class="col-sm-12">
							<button type="reset" class="btn btn-success btn-sm">Nhập lại</button>
							<asp:Button id="btnRegister" type="button" runat="server" cssclass="btn btn-success btn-sm" Text="Đăng ký" OnClick="btnRegister_Click"></asp:Button>
							<asp:Button id="btnUpdate" type="button" runat="server" cssclass="btn btn-success btn-sm" Text="Cập nhật" OnClick="btnUpdate_Click" Visible ="false"></asp:Button>					
							<asp:Button id="btnDelete" type="button" runat="server" cssclass="btn btn-success btn-sm" Text="Xóa Tour" OnClick="btnDelete_Click" Visible ="false"></asp:Button>
						</div>
					</div>
				</div>
			</div>
		</div>
	</article>

	<asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="txtName" Display="None" ErrorMessage="Bạn chưa nhập tiêu đề!" />
	<ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender1" WarningIconImageUrl="" HighlightCssClass="validatorCalloutHighlight" TargetControlID="RequiredFieldValidator1" />
</asp:Content>

