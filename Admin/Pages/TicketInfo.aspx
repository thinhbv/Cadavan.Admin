<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TicketInfo.aspx.cs" Inherits="Pages_TicketInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
</head>
<body>
	<form id="form1" runat="server">
		<div class="modal-body">
			<div class="row">
				<div class="col-md-6">
					<div class="form-group">
						<input type="text" class="form-control input-sm" id="txtTicketId" placeholder="Mã ticket">
					</div>
					<!-- /form-group -->
					<div class="form-group">
						<input type="text" class="form-control input-sm" id="txtCompanyName" placeholder="Tên hãng">
					</div>
					<!-- /form-group -->
					<div class="form-group">
						<input type="text" class="form-control input-sm" id="txtCode" placeholder="Mã chuyến bay">
					</div>
				</div>
				<div class="col-md-6">
					<div class="input-group">
						<input type="text" id="txtStartDate" placeholder="Ngày khởi hành" class="datepicker form-control">
						<span class="input-group-addon"><i class="fa fa-calendar"></i></span>
					</div>
					<div class="form-group">
						<input type="text" class="form-control input-sm" id="txtDepTime" placeholder="Giờ khởi hành">
					</div>
					<!-- /form-group -->
					<div class="input-group">
						<input type="text" id="txtEndDate" placeholder="Ngày hạ cánh" class="datepicker form-control">
						<span class="input-group-addon"><i class="fa fa-calendar"></i></span>
					</div>
					<div class="form-group">
						<input type="text" class="form-control input-sm" id="txtDicTime" placeholder="Giờ hạ cánh">
					</div>
					<!-- /form-group -->
				</div>
				<div class="col-md-6">
					<div class="form-group">
						<select id="ddlActive" class="form-control">
							<option value="0" selected="selected">Kích hoạt</option>
							<option value="1">Hết hạn</option>
						</select>
					</div>
					<!-- /form-group -->
				</div>
			</div>
		</div>
	</form>
</body>
</html>
