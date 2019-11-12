<%@ Page Title="" Language="C#" MasterPageFile="~/Controls/AdminPage.master" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="Pages_Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<article>
		<div class="main-header clearfix">
			<div class="page-title">
				<h3 class="no-margin">
					Danh sách khách hàng liên hệ
				</h3>
			</div>
		</div>
		<div class="padding-md">
			<div class="panel panel-default table-responsive">
				<div class="panel-heading">
					<asp:Label ID="lblTotalRecord" runat="server" Text="0"></asp:Label>
				</div>
				<div class="padding-md clearfix">
					<table class="table table-striped" id="dataTable">
						<thead>
							<tr>
								<th>Edit</th>
								<th>Tên khách hàng</th>
								<th>Email</th>
								<th>Phone</th>
								<th>Nội dung</th>
								<th>Ngày liên hệ</th>
								<th>Trạng thái</th>
							</tr>
						</thead>
						<tbody>
							<asp:Repeater ID="rptList" runat="server">
								<ItemTemplate>
									<tr>
										<td><a class="edit"><i class="fa fa-edit fa-lg"></i></a></td>
										<td><%#Eval("Name") %></td>
										<td><%#Eval("Email") %></td>
										<td><%#Eval("Phone") %></td>
										<td><%#Eval("Message") %></td>
										<td><%# string.Format("{0:yyyy/MM/dd}", Eval("CreateDate"))%></td>
										<td><%#ShowStatus(Eval("Status").ToString()) %></td>
									</tr>
								</ItemTemplate>
							</asp:Repeater>
						</tbody>
					</table>
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

