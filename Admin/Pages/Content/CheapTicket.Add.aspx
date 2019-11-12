<%@ Page Title="" Language="C#" MasterPageFile="~/Controls/AdminPage.master" AutoEventWireup="true" CodeFile="CheapTicket.Add.aspx.cs" Inherits="Pages_Content_CheapTicket_Add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
	<script type="text/javascript">
		$(function () {
			'use strict';
			var nowTemp = new Date();
			var now = new Date(nowTemp.getFullYear(), nowTemp.getMonth(), nowTemp.getDate(), 0, 0, 0, 0);

			var checkin = $('#<%=txtStartDate.ClientID%>').datepicker({
				onRender: function (date) {
					return date.valueOf() < now.valueOf() ? 'disabled' : '';
				}
			}).on('changeDate', function (ev) {
				if (ev.date.valueOf() > checkout.date.valueOf()) {
					var newDate = new Date(ev.date)
					newDate.setDate(newDate.getDate());
					checkout.setValue(newDate);
				}
				checkin.hide();
				$('#<%=txtEndDate.ClientID%>').focus();
			}).data('datepicker');
			var checkout = $('#<%=txtEndDate.ClientID%>').datepicker({
				onRender: function (date) {
					return date.valueOf() < now.valueOf() ? 'disabled' : '';
				}
			}).on('changeDate', function (ev) {
				checkout.hide();
			}).data('datepicker');
			$('.timepicker').timepicker({
				maxHours: 24,
				showMeridian: false
			});
			$('#<%=txtQuantity.ClientID%>').keyup(function (e) {
				if (/\D/g.test(this.value)) {
					// Filter non-digits from input value.
					this.value = this.value.replace(/\D/g, '');
				}
			});
		});
	</script>
	<article>
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
				<div class="col-md-3">
					<div class="form-group">
						<input type="text" runat="server" class="form-control input-sm" id="txtTicketId" placeholder="Mã ticket">
					</div>
					<!-- /form-group -->
					<div class="form-group">
						<input type="text" runat="server" class="form-control input-sm" id="txtCompanyName" placeholder="Tên hãng">
					</div>
					<!-- /form-group -->
					<div class="form-group">
						<input type="text" runat="server" class="form-control input-sm" id="txtCode" placeholder="Mã chuyến bay">
					</div>
					<!-- /form-group -->
					<div class="form-group">
						<input type="text" runat="server" class="form-control input-sm" id="txtTicketClassName" placeholder="Hạng vé">
					</div>
					<!-- /form-group -->
					<div class="form-group">
						<input type="text" name="number" runat="server" class="form-control input-sm" id="txtQuantity" placeholder="Số lượng vé">
					</div>
					<!-- /form-group -->
				</div>
				<div class="col-md-3">
					<div class="form-group">
						<input type="text" runat="server" class="form-control input-sm" id="txtFromCity" placeholder="Điểm khởi hành">
					</div>
					<!-- /form-group -->
					<div class="form-group">
						<input type="text" runat="server" class="form-control input-sm" id="txtToCity" placeholder="Điểm hạ cánh">
					</div>
					<!-- /form-group -->
					<div class="form-group">
						<input type="text" runat="server" class="form-control input-sm" id="txtPrice" placeholder="Giá khuyến mại">
					</div>
					<!-- /form-group -->
					<div class="form-group">
						<select id="ddlTarget" runat="server" class="form-control" style="height: 40px; width: 276px;">
							<option value="0" selected="selected">Người lớn</option>
							<option value="1">Trẻ em</option>
							<option value="2">Em bé</option>
						</select>
					</div>
					<!-- /form-group -->
				</div>
						
				<div class="col-md-3">
					<div class="form-group">
						<div class="input-group date">
							<input type="text" id="txtStartDate" runat="server" class="datepicker form-control" onfocus="this.blur()" style="height:30px;width:234px;"  placeholder="Ngày khởi hành">
							<span class="input-group-addon"><i class="fa fa-calendar"></i></span>
						</div>
					</div>
					<div class="form-group">
						<div class="input-group bootstrap-timepicker">
							<input id="txtDepTime" runat="server" class="timepicker form-control" type="text" style="height:30px;width:234px;" placeholder="Giờ khởi hành"/>
							<span class="input-group-addon"><i class="fa fa-clock-o"></i></span>
						</div>
					</div>
					<!-- /form-group -->
					<div class="form-group">
						<div class="input-group date">
							<input type="text" id="txtEndDate" runat="server" class="datepicker form-control" onfocus="this.blur()" style="height:30px;width:234px;"  placeholder="Ngày hạ cánh">
							<span class="input-group-addon"><i class="fa fa-calendar"></i></span>
						</div>
					</div>
					<div class="form-group">
						<div class="input-group bootstrap-timepicker">
							<input id="txtDicTime" runat="server" class="timepicker form-control" type="text" style="height:30px;width:234px;" placeholder="Giờ hạ cánh"/>
							<span class="input-group-addon"><i class="fa fa-clock-o"></i></span>
						</div>
					</div>
					<!-- /form-group -->
					<div class="form-group">
						<select id="ddlActive" runat="server" class="form-control" style="height: 40px; width: 283px;">
							<option value="0" selected="selected">Kích hoạt</option>
							<option value="1">Hết hạn</option>
						</select>
					</div>
					<!-- /form-group -->
				</div>
			</div>
					<div class="row">
						<div class="col-sm-12">
							<button type="reset" class="btn btn-success btn-sm">Nhập lại</button>
							<asp:Button id="btnRegister" type="button" runat="server" cssclass="btn btn-success btn-sm" Text="Đăng ký" OnClick="btnRegister_Click"></asp:Button>
							<asp:Button id="btnUpdate" type="button" runat="server" cssclass="btn btn-success btn-sm" Text="Cập nhật" OnClick="btnUpdate_Click" Visible ="false"></asp:Button>
							<asp:Button id="btnDelete" type="button" runat="server" cssclass="btn btn-success btn-sm" Text="Xóa vé" OnClick="btnDelete_Click" Visible ="false"></asp:Button>
						</div>
					</div>
				</div>
			</div>
		</div>
	</article>
</asp:Content>

