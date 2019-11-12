<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DetailInfoCheap.aspx.cs" Inherits="Pages_DetailInfoCheap" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
</head>
<body>
	<form id="form1" runat="server">
		<div class="modal-body">
			<div class="row">
				<div class="col-md-item">
					<div class="panel panel-default table-responsive">
						<div class="panel-heading">
							Hành trình
						</div>
						<table class="table table-striped" id="responsiveTable">
							<tbody>
								<tr>
									<td class="text-right"><%=fromname %></td>
									<td class="text-center ticket-flight-ic-plane">----------<i class="fa fa-plane"></i>----------</td>
									<td class="text-left"><%=toname %></td>
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
				</div>
				<div class="col-md-item">
					<div class="panel panel-default table-responsive">
						<div class="panel-heading">
							Chi tiết giá vé
						</div>
						<table class="table table-striped" id="responsiveTable">
							<thead>
								<tr>
									<th>Khách hàng</th>
									<th>Số lượng</th>
									<th>Giá vé</th>
								</tr>
							</thead>
							<tbody>
								<tr>
									<td><asp:Label ID="lblTarget" runat="server"></asp:Label></td>
									<td><asp:Label ID="lblQuantity" runat="server"></asp:Label></td>
									<td><asp:Label ID="lblPrice" runat="server"></asp:Label></td>
								</tr>
							</tbody>
						</table>
					</div>
				</div>
			</div>
			
			<div class="panel panel-default table-responsive">
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
					<div class="col-md-3" style="margin-top: 5px;">
						<asp:DropDownList ID="drpStatus" CssClass="form-control input-sm inline-block" runat="server">
						</asp:DropDownList>
					</div>
				</div>
			</div>
		</div>
	</form>
</body>
</html>
