<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DetailInfo.aspx.cs" Inherits="Pages_DetailInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
</head>
<body>
	<form id="form1" runat="server">
		<div class="modal-body">
			<div class="panel panel-default table-responsive">
				<div class="panel-heading">
					Thông tin chuyến bay
				</div>
				<div class="row">
					<div class="col-md-6">
						<table class="table table-striped" id="responsiveTable">
							<tbody>
								<tr>
									<th>Chiều đi</th>
									<th></th>
									<th></th>
								</tr>
								<%--<tr>
							<td class="text-right"><%=fromname %></td>
							<td class="text-center">
								<asp:Label ID="lblFlyName" runat="server"></asp:Label></td>
							<td class="text-left"><%=toname %></td>
						</tr>--%>
								<tr>
									<td class="text-right"><%=fromname %> (<%=fromcity %>)</td>
									<td class="text-center ticket-flight-ic-plane">----------<i class="fa fa-plane"></i>----------</td>
									<td class="text-left"><%=toname %> (<%=tocity %>)</td>
								</tr>
								<tr>
									<td class="text-right">
										<asp:Label ID="lblStartDate" runat="server"></asp:Label></td>
									<td class="text-center">
										<asp:Label ID="lblTimeFly" runat="server"></asp:Label></td>
									<td class="text-left">
										<asp:Label ID="lblEndDate" runat="server"></asp:Label></td>
								</tr>
							</tbody>
						</table>
					</div>
					<div class="col-md-6">
						<table class="table table-striped" id="responsiveTable">
							<tbody>
								<tr>
									<th>Chiều về</th>
									<th></th>
									<th></th>
								</tr>
								<%--<tr>
							<td class="text-right"><%=toname %></td>
							<td class="text-center">
								<asp:Label ID="lblReturnFlyName" runat="server"></asp:Label></td>
							<td class="text-left"><%=fromname %></td>
						</tr>--%>
								<tr>
									<td class="text-right"><%=toname %> (<%=tocity %>)</td>
									<td class="text-center ticket-flight-ic-plane">----------<i class="fa fa-plane"></i>----------</td>
									<td class="text-left"><%=fromname %> (<%=fromcity %>)</td>
								</tr>
								<tr>
									<td class="text-right">
										<asp:Label ID="lblReturnStartDate" runat="server"></asp:Label></td>
									<td class="text-center">
										<asp:Label ID="lblReturnTimeFly" runat="server"></asp:Label></td>
									<td class="text-left">
										<asp:Label ID="lblReturnEndDate" runat="server"></asp:Label></td>
								</tr>
							</tbody>
						</table>
					</div>
				</div>
			</div>

			<div class="row">
				<div class="col-md-6">
					<div class="panel panel-default table-responsive">
						<div class="panel-heading">
							Chi tiết giá vé chiều đi
						</div>
						<table class="table table-striped" id="responsiveTable">
							<thead>
								<tr>
									<th>Khách hàng</th>
									<th>Số lượng</th>
									<th>Giá vé</th>
									<th>Thuế & Phí</th>
									<th>Tổng giá vé</th>
								</tr>
							</thead>
							<tbody>
								<asp:Repeater runat="server" ID="rptOrders">
									<ItemTemplate>
										<tr>
											<td><%#Eval("Type") %></td>
											<td><%#Eval("Quanlity") %></td>
											<td><%#AppUtils.ConvertPrice(Eval("PriceNet").ToString()) %></td>
											<td><%#AppUtils.ConvertPrice(Eval("TaxAndFee").ToString()) %></td>
											<td><%#AppUtils.ConvertPrice(Eval("TotalPrice").ToString()) %></td>
										</tr>
									</ItemTemplate>
								</asp:Repeater>
							</tbody>
						</table>
					</div>
				</div>
				<div class="col-md-6">
					<asp:Panel ID="pnReturn" runat="server" Visible="false">
						<div class="panel panel-default table-responsive">
							<div class="panel-heading">
								Chi tiết giá vé chiều về
							</div>
							<table class="table table-striped" id="responsiveTable">
								<thead>
									<tr>
										<th>Khách hàng</th>
										<th>Số lượng</th>
										<th>Giá vé</th>
										<th>Thuế & Phí</th>
										<th>Tổng giá vé</th>
									</tr>
								</thead>
								<tbody>
									<asp:Repeater runat="server" ID="rptReturnOrders">
										<ItemTemplate>
											<tr>
												<td><%#Eval("Type") %></td>
												<td><%#Eval("Quanlity") %></td>
												<td><%#AppUtils.ConvertPrice(Eval("PriceNet").ToString()) %></td>
												<td><%#AppUtils.ConvertPrice(Eval("TaxAndFee").ToString()) %></td>
												<td><%#AppUtils.ConvertPrice(Eval("TotalPrice").ToString()) %></td>
											</tr>
										</ItemTemplate>
									</asp:Repeater>
								</tbody>
							</table>
						</div>
					</asp:Panel>
				</div>
			</div>
			<div class="panel panel-default table-responsive">
				<div class="panel-heading">
					Phí hành lý:
					<asp:Label ID="lblTotalTax" runat="server"></asp:Label>
				</div>
				<div class="panel-heading">
					Tổng tiền thanh toán:
					<asp:Label ID="lblTotalPrice" runat="server"></asp:Label>
				</div>
			</div>
			<div class="panel panel-default table-responsive">
				<div class="panel-heading">
					Thông tin liên hệ
				</div>
				<table class="table table-striped" id="responsiveTable">
					<tbody>
						<tr>
							<th>Họ tên:</th>
							<th>
								<asp:Label ID="lblContactName" runat="server"></asp:Label></th>
						</tr>
						<tr>
							<th>Số điện thoại:</th>
							<th>
								<asp:Label ID="lblContactPhone" runat="server"></asp:Label></th>
						</tr>
						<tr>
							<th>Email:</th>
							<th>
								<asp:Label ID="lblContactEmail" runat="server"></asp:Label></th>
						</tr>
						<tr>
							<th>Địa chỉ:</th>
							<th>
								<asp:Label ID="lblContactAddress" runat="server"></asp:Label></th>
						</tr>
					</tbody>
				</table>
			</div>
			<div class="panel panel-default table-responsive">
				<div class="row">
					<div class="col-md-3">
						<div class="panel-heading">
							Trạng thái giao dịch
						</div>
					</div>
					<div class="col-md-3" style="margin-top:5px;">
						<asp:DropDownList ID="drpStatus" CssClass="form-control input-sm inline-block" runat="server">
							<asp:ListItem Value="0">Chưa thanh toán</asp:ListItem>
							<asp:ListItem Value="1">Đã thanh toán</asp:ListItem>
							<asp:ListItem Value="2">Đã nhận vé</asp:ListItem>
							<asp:ListItem Value="3">Hủy đặt hàng</asp:ListItem>
						</asp:DropDownList>
					</div>
				</div>
			</div>
		</div>
	</form>
</body>
</html>
