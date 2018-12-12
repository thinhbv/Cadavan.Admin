﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/ListPage.master" AutoEventWireup="true" CodeFile="Booking.List.aspx.cs" Inherits="Pages_Content_Booking_List" %>

<%@ Import Namespace="Libs.Content" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
	<script type="text/javascript">

		$(function () {
			$(".edit").on("click", function () {
				$(".modal-body").html("");
				var orderid = $(this).attr("data");
				$.ajax({
					type: "GET",
					url: "Pages/DetailInfo.aspx",
					data: { id: orderid },
					contentType: "application/html",
					dataType: "html",
					success: function (data) {
						$(".modal-body").html($(data).find(".modal-body").html());
					},
					failure: function (response) {
					}
				});
			})
		})
		</script>
	<div id="main-container">
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
								<asp:ListItem Value="999">- Tất cả -</asp:ListItem>
								<asp:ListItem Value="0">Chưa thanh toán</asp:ListItem>
								<asp:ListItem Value="1">Đã thanh toán</asp:ListItem>
								<asp:ListItem Value="2">Đã nhận vé</asp:ListItem>
								<asp:ListItem Value="3">Hủy đặt hàng</asp:ListItem>
							</asp:DropDownList>
						</div>
						<div class="form-group">
							<asp:DropDownList ID="drpAir" CssClass="form-control input-sm inline-block" runat="server"></asp:DropDownList>
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
										<td><%#ShowPlan(Eval("DepTime").ToString(), Eval("StartDate").ToString(), Eval("DicTime").ToString(), Eval("EndDate").ToString(), Eval("FromCity").ToString(), Eval("ToCity").ToString()) %></td>
										<td><%#ShowCustomerInfo(Eval("LastName").ToString(), Eval("FirstName").ToString(), Eval("Phone").ToString(), Eval("Email").ToString()) %></td>
										<td><%#AppUtils.ConvertPrice(Eval("Price").ToString()) %></td>
										<%--<td><%# string.Format("{0:yyyy/MM/dd HH:mm}", Eval("LastLogin"))%></td>--%>
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
									<a href="#" class="btn btn-danger btn-sm">Submit</a>
									<button class="btn btn-success btn-sm" data-dismiss="modal" aria-hidden="true">Close</button>
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
	</div>
</asp:Content>

