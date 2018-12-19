<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/ListPage.master" AutoEventWireup="true" CodeFile="DashBoards.aspx.cs" Inherits="Pages_Content_DashBoards" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
	<script type="text/javascript" src="Charts/code/highcharts.js"></script>
	<script type="text/javascript" src="Charts/code/modules/exporting.js"></script>
	<script type="text/javascript" src="Charts/code/modules/export-data.js"></script>
	<div id="main-container">
		<div class="main-header clearfix">
			<div class="page-title">
				<h3 class="no-margin">
					<asp:Literal ID="ltrTitle" runat="server">Biểu đồ bán vé</asp:Literal>
				</h3>
			</div>
		</div>
		<div id="container" style="min-width: 310px; height: 400px; margin: 0 auto"></div>
	</div>
	<script type="text/javascript">
		var cate = new Array('Tháng 1', 'Tháng 2', 'Tháng 3', 'Tháng 4', 'Tháng 5', 'Tháng 6');
		Highcharts.chart('container', {
			chart: {
				type: 'column',
				width: 1150
			},
			title: {
				text: 'Biểu đồ vé các hãng hàng không theo tháng'
			},
			xAxis: {
				categories: cate
			},
			yAxis: {
				min:0,
				title: {
					text: 'Tổng số vé bán được'
				}
			},
			tooltip: {
				pointFormat: '<span style="color:{series.color}">{series.name}</span>: <b>{point.y}</b> ({point.percentage:.0f}%)<br/>',
				shared: true
			},
			plotOptions: {
				column: {
					stacking: 'percent'
				}
			},
			series: [{
				name: 'John',
				data: [5, 3, 4, 7, 2, 0]
			}, {
				name: 'Jane',
				data: [2, 2, 3, 2, 1, 0]
			}, {
				name: 'Joe',
				data: [3, 4, 4, 2, 5, 0]
			}]
		});
		</script>
</asp:Content>

