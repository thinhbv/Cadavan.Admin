<%@ Page Title="" Language="C#" MasterPageFile="~/Controls/AdminPage.master" AutoEventWireup="true" CodeFile="Tours.List.aspx.cs" Inherits="Pages_Content_Tours_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
	<article>
		<div class="main-header clearfix">
			<div class="page-title">
				<h3 class="no-margin">
					Danh sách Tours
				</h3>
			</div>
		</div>
		<div class="padding-md">
			<div class="panel panel-default">
				<div class="panel-body">
					<div class="form-inline no-margin">
						<div class="form-group">
							<asp:DropDownList ID="drpStatus" CssClass="form-control input-sm inline-block" runat="server">
								<asp:ListItem Value="">- Tất cả trạng thái -</asp:ListItem>
								<asp:ListItem Value="0">Kích hoạt</asp:ListItem>
								<asp:ListItem Value="1">Hết hạn</asp:ListItem>
							</asp:DropDownList>
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
								<th>Tên Tours</th>
								<th>Thời gian</th>
								<th>Lịch khởi hành</th>
								<th>Giá</th>
								<th>Ưu tiên</th>
								<th>Trạng thái</th>
							</tr>
						</thead>
						<tbody>
							<asp:Repeater ID="rptList" runat="server">
								<ItemTemplate>
									<tr>
										<td><a class="edit" href='tour.edit.html?id=<%#Eval("Id") %>'><i class="fa fa-edit fa-lg"></i></a></td>
										<td><%#Eval("Name") %></td>
										<td><%#Eval("Period") %></td>
										<td><%#Eval("Agenda") %></td>
										<td><%#AppUtils.ConvertPrice(Eval("Price").ToString()) %></td>
										<td><%# Eval("Priority")%></td>
										<td><%#AppUtils.ShowStatusTicket(Eval("Active").ToString()) %></td>
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

