<%@ Page Title="" Language="C#" MasterPageFile="~/Controls/AdminPage.master" AutoEventWireup="true" CodeFile="CheapTicket.aspx.cs" Inherits="Pages_Content_CheapTicket" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<article>
		<div class="main-header clearfix">
			<div class="page-title">
				<h3 class="no-margin">
					<asp:Literal ID="ltrTitle" runat="server">Danh sách vé rẻ</asp:Literal>
				</h3>
				<span>
					<asp:Literal ID="ltrSubTitle" runat="server"></asp:Literal>
				</span>
			</div>
		</div>
		<div class="padding-md">
			<div class="panel panel-default">
				<div class="panel-body">
					<div class="form-inline no-margin">
						<div class="form-group">
							<asp:DropDownList ID="drpStatus" CssClass="form-control input-sm inline-block" runat="server">
								<asp:ListItem Value="-1" Selected="True">- Tất cả trạng thái -</asp:ListItem>
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
								<th>Tên hãng</th>
								<th>Mã ticket</th>
								<th>Hạng vé</th>
								<th>Ngày khởi hành</th>
								<th>Ngày tạo</th>
								<th>Hành trình</th>
								<th>Đối tượng</th>
								<th>Số lượng</th>
								<th>Giá</th>
								<th>Trạng thái</th>
							</tr>
						</thead>
						<tbody>
							<asp:Repeater ID="rptList" runat="server">
								<ItemTemplate>
									<tr>
										<td><a class="edit" href="cheapticket.edit.html?id=<%#Eval("Id") %>"><i class="fa fa-edit fa-lg"></i></a></td>
										<td><%#Eval("CompanyName") %></td>
										<td><%#Eval("TicketID") %></td>
										<td><%#Eval("TicketClassName") %></td>
										<td><%# string.Format("{0:dd/MM/yyyy}", Eval("StartDate"))%></td>
										<td><%# string.Format("{0:dd/MM/yyyy}", Eval("CreateDate"))%></td>
										<td><%#Eval("FromCity").ToString() + " - " + Eval("ToCity").ToString() %></td>
										<td><%#ShowTarget(Eval("Target").ToString()) %></td>
										<td><%#Eval("Quantity")%></td>
										<td><%#AppUtils.ConvertPrice(Eval("AdultPriceNet").ToString())%></td>
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

