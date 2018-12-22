<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test.aspx.cs" Inherits="Pages_Content_test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
	<!-- Bootstrap core CSS -->
	<link href="/resources/bootstrap/css/bootstrap.min.css" rel="stylesheet" />

	<!-- Font Awesome-->
	<link href="/resources/css/font-awesome.min.css" rel="stylesheet" />

	<!-- Pace -->
	<link href="/resources/css/pace.css" rel="stylesheet" />

	<!-- Datatable -->
	<link href="/resources/css/jquery.dataTables_themeroller.css" rel="stylesheet" />

	<!-- Endless -->
	<link href="/resources/css/endless.min.css" rel="stylesheet" />
	<link href="/resources/css/endless-skin.css" rel="stylesheet" />

	<!-- Chosen -->
	<link href="/resources/css/chosen/chosen.min.css" rel="stylesheet" />

	<!-- Dropzone -->
	<link href='/resources/css/dropzone/dropzone.css' rel="stylesheet" />

	<!-- Datepicker -->
	<link href="/resources/css/datepicker.css" rel="stylesheet" />

	<!-- Timepicker -->
	<link href="/resources/css/bootstrap-timepicker.css" rel="stylesheet" />
	<!-- Jquery -->
	<script src="/resources/js/jquery-1.10.2.min.js"></script>
	
</head>
<body>
	<form id="form1" runat="server">
		<article>
			<div class="main-header clearfix">
				<div class="page-title">
					<h3 class="no-margin">Danh sách đơn hàng
					</h3>
					<span></span>
				</div>

				<ul class="page-stats">
				</ul>
			</div>
			<div class="padding-md">
				<div class="panel panel-default">
					<div class="panel-body">
						<div class="form-inline no-margin">
							<div class="form-group">
								<select name="ctl00$ContentPlaceHolder1$drpStatus" id="ctl00_ContentPlaceHolder1_drpStatus" class="form-control input-sm inline-block">
									<option selected="selected" value="999">- Tất cả trạng th&#225;i -</option>
									<option value="0">Chưa thanh to&#225;n</option>
									<option value="1">Đ&#227; thanh to&#225;n</option>
									<option value="2">Đ&#227; nhận v&#233;</option>
									<option value="3">Hủy đặt h&#224;ng</option>

								</select>
							</div>
							<div class="form-group">
								<select name="ctl00$ContentPlaceHolder1$drpAir" id="ctl00_ContentPlaceHolder1_drpAir" class="form-control input-sm inline-block">
									<option selected="selected" value="">- Chọn h&#227;ng h&#224;ng kh&#244;ng -</option>
									<option value="VN">VietNam Airline</option>
									<option value="VJ">Vietjet Air</option>
									<option value="JT">Jetstar Pacific</option>

								</select>
							</div>
							<input type="submit" name="ctl00$ContentPlaceHolder1$btView" value="Lọc" id="ctl00_ContentPlaceHolder1_btView" class="btn btn-sm btn-success" />
						</div>
					</div>
				</div>
				<!-- /panel -->
				<div class="panel panel-default table-responsive">
					<div class="panel-heading">
						<span id="ctl00_ContentPlaceHolder1_lblTotalRecord">Tổng số bản ghi: 4</span>
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

								<tr>
									<td><a class="edit" data='9' href="#formModal" role="button" data-toggle="modal"><i class="fa fa-edit fa-lg"></i></a></td>
									<td>VietNam Airline</td>
									<td>VN2_A</td>
									<td>Siêu tiết kiệm</td>
									<td><span class="label label-danger">Chưa thanh toán</span></td>
									<td>2018/12/06</td>
									<td><span class="label label-danger">Một chiều</span></td>
									<td><b>HAN</b> - <b>CXR</b> </td>
									<td>Nguyễn Thị Phượng - 0987848037<br />
										buithinh@gmail.com</td>
									<td>2.789.000 ₫</td>
								</tr>

								<tr>
									<td><a class="edit" data='7' href="#formModal" role="button" data-toggle="modal"><i class="fa fa-edit fa-lg"></i></a></td>
									<td>VietJet Air<br />
										VietJet Air</td>
									<td>VJ1_Eco<br />
										VJ13_Eco</td>
									<td>Phổ thông<br />
										Phổ thông</td>
									<td><span class="label label-success">Đã nhận vé</span></td>
									<td>2018/12/06</td>
									<td><span class="label label-success">Khứ hồi</span></td>
									<td><b>HAN</b> - <b>CXR</b> </td>
									<td>Bùi Văn Thịnh - 0987848037<br />
										buithinh@gmail.com</td>
									<td>6.973.400 ₫</td>
								</tr>

								<tr>
									<td><a class="edit" data='6' href="#formModal" role="button" data-toggle="modal"><i class="fa fa-edit fa-lg"></i></a></td>
									<td>VietNam Airline<br />
										VietNam Airline</td>
									<td>VN1_A<br />
										VN4_N</td>
									<td>Siêu tiết kiệm<br />
										Phổ thông</td>
									<td><span class="label label-danger">Chưa thanh toán</span></td>
									<td>2018/12/05</td>
									<td><span class="label label-success">Khứ hồi</span></td>
									<td><b>HAN</b> - <b>CXR</b> </td>
									<td>Bùi Văn Thịnh - 0987848037<br />
										buithinh@gmail.com</td>
									<td>15.086.000 ₫</td>
								</tr>

								<tr>
									<td><a class="edit" data='4' href="#formModal" role="button" data-toggle="modal"><i class="fa fa-edit fa-lg"></i></a></td>
									<td>Jetstar Pacific<br />
										VietJet Air</td>
									<td>JT1_starter<br />
										VJ44_Eco</td>
									<td>Tiết kiệm<br />
										Phổ thông</td>
									<td><span class="label label-primary">Hủy đặt hàng</span></td>
									<td>2018/12/02</td>
									<td><span class="label label-success">Khứ hồi</span></td>
									<td><b>HAN</b> - <b>SGN</b> </td>
									<td>Bùi Văn Thịnh - 0987848037<br />
										buithinh@gmail.com</td>
									<td>5.505.800 ₫</td>
								</tr>

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

															<tr>
																<td class="text-right">Hà Nội (HAN)</td>
																<td class="text-center ticket-flight-ic-plane">----------<i class="fa fa-plane"></i>----------</td>
																<td class="text-left">Đà Nẵng (DAD)</td>
															</tr>
															<tr>
																<td class="text-right">
																	<span id="lblStartDate">06:00 26/12/2018</span></td>
																<td class="text-center">
																	<span id="lblTimeFly">Thời gian bay 1h20</span></td>
																<td class="text-left">
																	<span id="lblEndDate">07:20 26/12/2018</span></td>
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

															<tr>
																<td class="text-right">Đà Nẵng (DAD)</td>
																<td class="text-center ticket-flight-ic-plane">----------<i class="fa fa-plane"></i>----------</td>
																<td class="text-left">Hà Nội (HAN)</td>
															</tr>
															<tr>
																<td class="text-right">
																	<span id="lblReturnStartDate">14:30 29/12/2018</span></td>
																<td class="text-center">
																	<span id="lblReturnTimeFly">Thời gian bay 1h20</span></td>
																<td class="text-left">
																	<span id="lblReturnEndDate">15:50 29/12/2018</span></td>
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
																<th>Thuế &amp; Phí</th>
																<th>Tổng giá vé</th>
															</tr>
														</thead>
														<tbody>

															<tr>
																<td>Người lớn</td>
																<td>1</td>
																<td>499.000 ₫</td>
																<td>250.000 ₫</td>
																<td>749.000 ₫</td>
															</tr>

														</tbody>
													</table>
												</div>
											</div>
											<div class="col-md-6">
												<div id="pnReturn">

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
																	<th>Thuế &amp; Phí</th>
																	<th>Tổng giá vé</th>
																</tr>
															</thead>
															<tbody>

																<tr>
																	<td>Người lớn</td>
																	<td>1</td>
																	<td>799.000 ₫</td>
																	<td>280.000 ₫</td>
																	<td>1.079.000 ₫</td>
																</tr>

															</tbody>
														</table>
													</div>

												</div>
											</div>
										</div>
										<div class="panel panel-default table-responsive">
											<div class="panel-heading">
												Phí hành lý:
					<span id="lblTotalTax">0 ₫</span>
											</div>
											<div class="panel-heading">
												Tổng tiền thanh toán:
					<span id="lblTotalPrice">1.828.000 ₫</span>
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
															<span id="lblContactName">Bùi Văn Thịnh</span></th>
													</tr>
													<tr>
														<th>Số điện thoại:</th>
														<th>
															<span id="lblContactPhone">0987848037</span></th>
													</tr>
													<tr>
														<th>Email:</th>
														<th>
															<span id="lblContactEmail">buithinh@gmail.com</span></th>
													</tr>
													<tr>
														<th>Địa chỉ:</th>
														<th>
															<span id="lblContactAddress">Quan Hoa</span></th>
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
													<select name="drpStatus" id="drpStatus" class="form-control input-sm inline-block">
														<option selected="selected" value="0">Chưa thanh toán</option>
														<option value="1">Đã thanh toán</option>
														<option value="2">Đã nhận vé</option>
														<option value="3">Hủy đặt hàng</option>

													</select>
												</div>
											</div>
										</div>
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

		<!-- Bootstrap -->
		<script src='/resources/bootstrap/js/bootstrap.min.js'></script>

		<!-- Datatable -->
		<script src='/resources/js/jquery.dataTables.min.js'></script>

		<!-- Datepicker -->
		<script src='/resources/js/bootstrap-datepicker.min.js'></script>

		<!-- Timepicker -->
		<script src='/resources/js/bootstrap-timepicker.min.js'></script>

		<!-- Modernizr -->
		<script src='/resources/js/modernizr.min.js'></script>

		<!-- Pace -->
		<script src='/resources/js/pace.min.js'></script>

		<!-- Popup Overlay -->
		<script src='/resources/js/jquery.popupoverlay.min.js'></script>

		<!-- Slimscroll -->
		<script src='/resources/js/jquery.slimscroll.min.js'></script>

		<!-- Cookie -->
		<script src='/resources/js/jquery.cookie.min.js'></script>

		<!-- Endless -->
		<script src='/resources/js/endless/endless.js'></script>

		<!-- Chosen -->
		<script src='/resources/js/chosen.jquery.min.js'></script>

		<!-- Dropzone -->
		<script src='/resources/js/dropzone.min.js'></script>

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

	</form>
</body>
</html>
