<%@ Page Title="" Language="C#" MasterPageFile="~/Controls/AdminPage.master" AutoEventWireup="true" CodeFile="OrdersCheap.aspx.cs" Inherits="Pages_Content_OrdersCheap" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
			var orderid;
			$(".edit").on("click", function () {
				$(".modal-body").html("");
				orderid = $(this).attr("data");
				var status = $('#<%=drpStatus.ClientID%>').val();
				var aircode = $('#<%=drpAir.ClientID%>').val();
				$.ajax({
					type: "GET",
					url: "Pages/DetailInfoCheap.aspx",
					data: { id: orderid},
					contentType: "application/html",
					dataType: "html",
					success: function (data) {
						$(".modal-body").html($(data).find(".modal-body").html());
						if ($("#drpStatus").is(":disabled")) {
							$("#btnupdate").hide();
						}
					},
					failure: function (response) {
					}
				});
			})

			$("#btnupdate").on("click", function () {
				var status = $("#drpStatus").val();
				$.ajax({
					type: "GET",
					url: "Pages/DetailInfoCheap.aspx",
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
			});
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
					<asp:Literal ID="ltrTitle" runat="server">Danh sách đơn hàng vé rẻ</asp:Literal>
				</h3>
			</div>
		</div>
		<div class="padding-md">
			<div class="panel panel-default">
				<div class="panel-body">
					<div class="form-inline no-margin">
						<div class="form-group">
							<asp:DropDownList ID="drpStatus" CssClass="form-control input-sm inline-block" runat="server">
								<asp:ListItem Value="999">- Tất cả trạng thái -</asp:ListItem>
							</asp:DropDownList>
						</div>
						<div class="form-group">
							<asp:DropDownList ID="drpAir" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
						</div>
						<div class="form-group">
							<div class="input-group date">
								<input type="text" id="txtFromDate" runat="server" class="datepicker form-control" style="height:20px;width:159px;" placeholder="Từ ngày">
								<span class="input-group-addon"><i class="fa fa-calendar"></i></span>
							</div>
						</div>
						<div class="form-group date">
							<div class="input-group">
								<input type="text" id="txtToDate" runat="server" class="datepicker form-control" style="height:20px;width:159px;" placeholder="Đến ngày">
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
										<td><%#AppUtils.ShowStatusCart(Eval("Status").ToString(), lstStatus) %></td>
										<td><%# string.Format("{0:dd/MM/yyyy}", Eval("CreateDate"))%></td>
										<td><%#ShowPlan(int.Parse(Eval("OrderId").ToString())) %></td>
										<td><%#AppUtils.ShowCustomerInfo(Eval("LastName").ToString(), Eval("FirstName").ToString(), Eval("Phone").ToString(), Eval("Email").ToString()) %></td>
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
									<span id="btnupdate" class="btn btn-danger btn-sm">Cập nhật</span>
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

