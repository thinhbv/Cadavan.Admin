<%@ Page Title="" Language="C#" ValidateRequest="false" MasterPageFile="~/Controls/AdminPage.master" AutoEventWireup="true" CodeFile="Config.aspx.cs" Inherits="Pages_Config" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
	<article>
		<div class="main-header clearfix">
			<div class="page-title">
				<h3 class="no-margin">
					Cấu hình trang web
				</h3>
			</div>
		</div>
		<div class="padding-md">
			<div class="panel panel-default table-responsive">
				<div class="padding-md clearfix">
					<div class="panel panel-default">
						<div class="panel-body">
							<div class="row">
								<label class="col-lg-2 control-label">Thông tin liên hệ</label>
								<div class="col-md-10">
									<div class="form-group">
										<FTB:FreeTextBox ID="ftbContent" SupportFolder="~/aspnet_client/FreeTextBox/" runat="Server" Width="100%" Height="300px"
										 ToolbarLayout="FontFacesMenu,FontSizesMenu,FontForeColorsMenu,FontForeColorPicker,FontBackColorsMenu,FontBackColorPicker|Bold,Italic,Underline,Strikethrough,Superscript,Subscript,RemoveFormat|JustifyLeft,JustifyRight,JustifyCenter,JustifyFull;BulletedList,NumberedList,Indent,Outdent;CreateLink,Unlink,InsertImage|Cut,Copy,Paste,Delete;Undo,Redo,Print,Save|InsertRule,InsertDate,InsertTime|InsertDiv,EditStyle,InsertImageFromGallery,Preview,SelectAll,WordClean,NetSpell" StartMode="DesignMode" BreakMode="Paragraph" AllowHtmlMode="True"  ToolbarStyleConfiguration="NotSet" UpdateToolbar="True" />
									</div>
									<!-- /form-group -->
								</div>
							</div>
							<div class="row">
								<label class="col-lg-2 control-label">HotLine</label>
								<div class="col-md-10">
									<div class="form-group">
										<input type="text" runat="server" class="form-control input-sm" id="txthotline" placeholder="Số HotLine">
									</div>
									<!-- /form-group -->
								</div>
							</div>
							<div class="row">
								<label class="col-lg-2 control-label">Chi nhánh số 1</label>
								<div class="col-md-10">
									<div class="form-group">
										<input type="text" runat="server" class="form-control input-sm" id="txtAddress1" placeholder="Chi nhánh số 1">
									</div>
									<!-- /form-group -->
								</div>
							</div>
							<div class="row">
								<label class="col-lg-2 control-label">Chi nhánh số 2</label>
								<div class="col-md-10">
									<div class="form-group">
										<input type="text" runat="server" class="form-control input-sm" id="txtAddress2" placeholder="Chi nhánh số 2">
									</div>
									<!-- /form-group -->
								</div>
							</div>
							<div class="row">
								<label class="col-lg-2 control-label">Logo</label>
								<div class="col-md-10">
									<div class="form-group">
										<asp:Image ID="imgLogo" runat="server" Width="300" />
									</div>
									<!-- /form-group -->
									<div class="form-group">
										<asp:FileUpload ID="fuLogo" runat="server"></asp:FileUpload>
									</div>
									<!-- /form-group -->
								</div>
							</div>
							<div class="row">
								<label class="col-lg-2 control-label">Hình ảnh cạnh logo</label>
								<div class="col-md-10">
									<div class="form-group">
										<asp:Image ID="imgBannerTop" runat="server" Width="300" />
									</div>
									<!-- /form-group -->
									<div class="form-group">
										<asp:FileUpload ID="fuBannerTop" runat="server"></asp:FileUpload>
									</div>
									<!-- /form-group -->
								</div>
							</div>
							<div class="row">
								<label class="col-lg-2 control-label">Hình ảnh ở trang chủ</label>
								<div class="col-md-10">
									<div class="form-group">
										<asp:Image ID="imgHomePage" runat="server" Width="300" />
									</div>
									<!-- /form-group -->
									<div class="form-group">
										<asp:FileUpload ID="fuHomePage" runat="server"></asp:FileUpload>
									</div>
									<!-- /form-group -->
								</div>
							</div>
							<div class="row">
								<label class="col-lg-2 control-label">Hình ảnh ở trang Tour</label>
								<div class="col-md-10">
									<div class="form-group">
										<asp:Image ID="imgTourPage" runat="server" Width="300" />
									</div>
									<!-- /form-group -->
									<div class="form-group">
										<asp:FileUpload ID="fuTourPage" runat="server"></asp:FileUpload>
									</div>
									<!-- /form-group -->
								</div>
							</div>
							<div class="row">
								<label class="col-lg-2 control-label">Trạng thái đơn hàng vé máy bay</label>
								<div class="col-md-10">
									<div class="form-group">
										<input type="text" runat="server" class="form-control input-sm" id="txtStatusTicket" placeholder="Trạng thái đơn hàng vé máy bay">
									</div>
									<!-- /form-group -->
								</div>
							</div>
							<div class="row">
								<label class="col-lg-2 control-label">Trạng thái đơn hàng vé máy bay giá rẻ</label>
								<div class="col-md-10">
									<div class="form-group">
										<input type="text" runat="server" class="form-control input-sm" id="txtStatusCheapTicket" placeholder="Trạng thái đơn hàng vé máy bay giá rẻ">
									</div>
									<!-- /form-group -->
								</div>
							</div>
							<div class="row">
								<label class="col-lg-2 control-label">Trạng thái đơn hàng tour</label>
								<div class="col-md-10">
									<div class="form-group">
										<input type="text" runat="server" class="form-control input-sm" id="txtStatusTour" placeholder="Trạng thái đơn hàng tour">
									</div>
									<!-- /form-group -->
								</div>
							</div>
							<div class="row">
								<label class="col-lg-2 control-label">Trạng thái liên hệ</label>
								<div class="col-md-10">
									<div class="form-group">
										<input type="text" runat="server" class="form-control input-sm" id="txtStatusContact" placeholder="Trạng thái liên hệ">
									</div>
									<!-- /form-group -->
								</div>
							</div>
							<div class="row">
								<div class="col-sm-12">
									<button type="reset" class="btn btn-success btn-sm">Nhập lại</button>
									<asp:Button id="btnUpdate" type="button" runat="server" cssclass="btn btn-success btn-sm" Text="Cập nhật" OnClick="btnUpdate_Click"></asp:Button>	
								</div>
							</div>
						</div>
					</div>
				</div>
				<!-- /.padding-md -->
			</div>
			<!-- /panel -->
		</div>
		<!-- /.padding-md -->
	</article>
	<!-- Le javascript-->
</asp:Content>

