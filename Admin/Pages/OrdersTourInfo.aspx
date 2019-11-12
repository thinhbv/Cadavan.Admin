<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrdersTourInfo.aspx.cs" Inherits="Pages_OrdersTourInfo" %>

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
						<tr>
							<th>Ghi chú:</th>
							<th>
								<asp:Label ID="lblRemarks" runat="server"></asp:Label></th>
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
