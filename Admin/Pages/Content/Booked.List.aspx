<%@ Page Title="" Language="C#" MasterPageFile="~/Controls/AdminPage.master" AutoEventWireup="true" CodeFile="Booked.List.aspx.cs" Inherits="Pages_Content_Booked_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
	<!-- Bootstrap core CSS -->
	<link href="../resources/bootstrap/css/bootstrap.min.css" rel="stylesheet" />

	<!-- Font Awesome-->
	<link href="../resources/css/font-awesome.min.css" rel="stylesheet" />

	<!-- Pace -->
	<link href="../resources/css/pace.css" rel="stylesheet" />

	<!-- Datatable -->
	<link href="../resources/css/jquery.dataTables_themeroller.css" rel="stylesheet" />

	<!-- Endless -->
	<link href="../resources/css/endless.min.css" rel="stylesheet" />
	<link href="../resources/css/endless-skin.css" rel="stylesheet" />

	<!-- Chosen -->
	<link href="../resources/css/chosen/chosen.min.css" rel="stylesheet" />

	<!-- Dropzone -->
	<link href='../resources/css/dropzone/dropzone.css' rel="stylesheet" />

	<!-- Datepicker -->
	<link href="../resources/css/datepicker.css" rel="stylesheet" />

	<!-- Timepicker -->
	<link href="../resources/css/bootstrap-timepicker.css" rel="stylesheet" />
	<!-- Jquery -->
	<script type="text/javascript" src="../resources/js/jquery-1.10.2.min.js"></script>
	<script type="text/javascript">

		$(function () {

			'use strict';
			var nowTemp = new Date();
			var now = new Date(nowTemp.getFullYear(), nowTemp.getMonth(), nowTemp.getDate(), 0, 0, 0, 0);

			var checkin = $('#<%=txtFromDate.ClientID%>').datepicker({
				onRender: function (date) {
					return date.valueOf() > now.valueOf() ? 'disabled' : '';
				}
			}).on('changeDate', function (ev) {
				if (ev.date.valueOf() > checkout.date.valueOf()) {
					var newDate = new Date(ev.date)
					newDate.setDate(newDate.getDate() + 1);
					checkout.setValue(newDate);
				}
				checkin.hide();
				$('#<%=txtToDate.ClientID%>').focus();
			}).data('datepicker');
			var checkout = $('#<%=txtToDate.ClientID%>').datepicker({
				onRender: function (date) {
					return date.valueOf() > now.valueOf() ? 'disabled' : '';
				}
			}).on('changeDate', function (ev) {
				checkout.hide();
			}).data('datepicker');

			$('#<%=btView.ClientID%>').on('click', function () {
				if (checkin.date.valueOf() > checkout.date.valueOf()) {
					alert("Vui lòng chọn ngày bắt đầu nhỏ hơn ngày kết thúc!");
					$('#<%=txtFromDate.ClientID%>').focus();
					return false;
				}
				return true;
			})
			//$.fn.datepicker.dates['vi'] = {
			//	days: ["Chủ Nhật", "Thứ Hai", "Thứ Ba", "Thứ Tư", "Thứ Năm", "Thứ Sáu", "Thứ Bảy", "Chủ Nhật"],
			//	daysShort: ["CN", "T2", "T3", "T4", "T5", "T6", "T7", "CN"],
			//	daysMin: ["CN", "T2", "T3", "T4", "T5", "T6", "T7", "CN"],
			//	months: ["Tháng Một", "Tháng Hai", "Tháng Ba", "Tháng Tư", "Tháng Năm", "Tháng Sáu", "Tháng Bảy", "Tháng Tám", "Tháng Chín", "Tháng Mười", "Tháng Mười Một", "Tháng Mười Hai"],
			//	monthsShort: ["Tháng 1", "Tháng 2", "Tháng 3", "Tháng 4", "Tháng 5", "Tháng 6", "Tháng 7", "Tháng 8", "Tháng 9", "Tháng 10", "Tháng 11", "Tháng 12"]
			//};
			var orderid;
			$(".edit").on("click", function () {
				$(".modal-body").html("");
				orderid = $(this).attr("data");
				var status = $('#<%=drpStatus.ClientID%>').val();
				var aircode = $('#<%=drpAir.ClientID%>').val();
				$.ajax({
					type: "GET",
					url: "Pages/DetailInfo.aspx",
					data: { id: orderid, status: status, air: aircode, ishis: 1},
					contentType: "application/html",
					dataType: "html",
					success: function (data) {
						$(".modal-body").html($(data).find(".modal-body").html());
					},
					failure: function (response) {
					}
				});
			})

			$("#btnupdate").on("click", function () {
				var status = $("#drpStatus").val();
				$.ajax({
					type: "GET",
					url: "Pages/DetailInfo.aspx",
					data: { id: orderid, status: status, action: 'update' },
					contentType: "application/html",
					dataType: "html",
					success: function (data) {
						$("#btnClose").trigger("click");
						window.location.reload();
					},
					failure: function (response) {
						$("#btnClose").trigger("click");
						window.location.reload();
					}
				});
			})
		})
	</script>
	<style type="text/css">
		.ticket-flight-ic-plane {
			position: relative;
			display: flex;
			min-width: 90px;
			height: 24px;
			line-height: 24px;
			justify-content: center;
			font-size: 18px;
			color: #ff662c;
			flex-flow: row wrap;
		}
	</style>
	<article>
		<div class="main-header clearfix">
			<div class="page-title">
				<h3 class="no-margin">
					<asp:Literal ID="ltrTitle" runat="server">Danh sách đơn hàng</asp:Literal>
				</h3>
				<span>
					<asp:Literal ID="ltrSubTitle" runat="server"></asp:Literal>
				</span>
			</div>

			<ul class="page-stats">
				<asp:Repeater ID="rptReport" runat="server">
					<ItemTemplate>
						<li>
							<div class="value">
								<span><%#Eval("Name") %></span>
								<h4><%#Eval("Value") %></h4>
							</div>
						</li>
					</ItemTemplate>
				</asp:Repeater>
			</ul>
		</div>
		<div class="padding-md">
			<div class="panel panel-default">
				<div class="panel-body">
					<div class="form-inline no-margin">
						<div class="form-group">
							<asp:DropDownList ID="drpStatus" CssClass="form-control input-sm inline-block" runat="server">
								<asp:ListItem Value="999">- Tất cả trạng thái -</asp:ListItem>
								<asp:ListItem Value="2">Đã nhận vé</asp:ListItem>
								<asp:ListItem Value="3">Hủy đặt hàng</asp:ListItem>
							</asp:DropDownList>
						</div>
						<div class="form-group">
							<asp:DropDownList ID="drpAir" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
						</div>
						<div class="form-group">
							<div class="input-group date">
								<input type="text" id="txtFromDate" runat="server" class="datepicker form-control" onfocus="this.blur()" style="height:20px;width:159px;" placeholder="Từ ngày">
								<span class="input-group-addon"><i class="fa fa-calendar"></i></span>
							</div>
						</div>
						<div class="form-group date">
							<div class="input-group">
								<input type="text" id="txtToDate" runat="server" class="datepicker form-control" onfocus="this.blur()" style="height:20px;width:159px;" placeholder="Đến ngày">
								<span class="input-group-addon"><i class="fa fa-calendar"></i></span>
							</div>
						</div>
						<asp:Button ID="btView" runat="server" CssClass="btn btn-sm btn-success" Text="Lọc" OnClick="btView_Click" />
					</div>
				</div>
			</div>
			<!-- /panel -->
			<div class="panel panel-default table-responsive">
				<div class="panel-heading">
					<asp:Label ID="lblTotalRecord" runat="server" Text="0"></asp:Label>
				</div>
				<div class="padding-md clearfix">
					<table class="table table-striped" id="dataTable">
						<thead>
							<tr>
								<th>Edit</th>
								<th>Tên hãng</th>
								<th>Mã ticket</th>
								<th>Hạng vé</th>
								<th>Trạng thái</th>
								<th>Ngày đặt</th>
								<th>Hành trình</th>
								<th>Lịch trình</th>
								<th>Thông tin khách hàng</th>
								<th>Tổng giá</th>
							</tr>
						</thead>
						<tbody>
							<asp:Repeater ID="rptList" runat="server">
								<ItemTemplate>
									<tr>
										<td><a class="edit" data='<%#Eval("OrderId") %>' href="#formModal" role="button" data-toggle="modal"><i class="fa fa-edit fa-lg"></i></a></td>
										<td><%#Eval("CompanyName") %></td>
										<td><%#Eval("TicketID") %></td>
										<td><%#Eval("TicketClassName") %></td>
										<td><%#AppUtils.ShowStatusCart(Eval("Status").ToString()) %></td>
										<td><%# string.Format("{0:yyyy/MM/dd}", Eval("CreateDate"))%></td>
										<td><%#RoundTripName(Eval("RoundTrip").ToString()) %></td>
										<td><%#ShowPlan(int.Parse(Eval("OrderId").ToString())) %></td>
										<td><%#ShowCustomerInfo(Eval("LastName").ToString(), Eval("FirstName").ToString(), Eval("Phone").ToString(), Eval("Email").ToString()) %></td>
										<td><%#AppUtils.ConvertPrice(Eval("Price").ToString()) %></td>
									</tr>
								</ItemTemplate>
							</asp:Repeater>
						</tbody>
					</table>

					<div class="modal fade" id="formModal">
						<div class="modal-dialog">
							<div class="modal-content">
								<div class="modal-header">
									<button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
									<h4>Chi tiết đơn hàng</h4>
								</div>
								<div class="modal-body">
								</div>
								<div class="modal-footer">
									<button id="btnClose" class="btn btn-success btn-sm" data-dismiss="modal" aria-hidden="true">Đóng</button>
								</div>
							</div>
							<!-- /.modal-content -->
						</div>
						<!-- /.modal-dialog -->
					</div>
					<!-- /.modal -->
				</div>
				<!-- /.padding-md -->
			</div>
			<!-- /panel -->
		</div>
		<!-- /.padding-md -->
	</article>
	<!-- Le javascript
    ================================================== -->
	<!-- Placed at the end of the document so the pages load faster -->

	<!-- Bootstrap -->
	<script src="resources/bootstrap/js/bootstrap.min.js"></script>

	<!-- Datatable -->
	<script src='resources/js/jquery.dataTables.min.js'></script>

	<!-- Datepicker -->
	<script src='resources/js/bootstrap-datepicker.min.js'></script>

	<!-- Timepicker -->
	<script src='resources/js/bootstrap-timepicker.min.js'></script>

	<!-- Modernizr -->
	<script src='resources/js/modernizr.min.js'></script>

	<!-- Pace -->
	<script src='resources/js/pace.min.js'></script>

	<!-- Popup Overlay -->
	<script src='resources/js/jquery.popupoverlay.min.js'></script>

	<!-- Slimscroll -->
	<script src='resources/js/jquery.slimscroll.min.js'></script>

	<!-- Cookie -->
	<script src='resources/js/jquery.cookie.min.js'></script>

	<!-- Endless -->
	<script src='resources/js/endless/endless.js'></script>

	<!-- Chosen -->
	<script src='resources/js/chosen.jquery.min.js'></script>

	<!-- Dropzone -->
	<script src='resources/js/dropzone.min.js'></script>

	<script>
		$(function () {
			$('#dataTable').dataTable({
				"bJQueryUI": true,
				"sPaginationType": "full_numbers"
			});

			$('#chk-all').click(function () {
				if ($(this).is(':checked')) {
					$('#responsiveTable').find('.chk-row').each(function () {
						$(this).prop('checked', true);
						$(this).parent().parent().parent().addClass('selected');
					});
				}
				else {
					$('#responsiveTable').find('.chk-row').each(function () {
						$(this).prop('checked', false);
						$(this).parent().parent().parent().removeClass('selected');
					});
				}
			});
		});
	</script>
</asp:Content>

