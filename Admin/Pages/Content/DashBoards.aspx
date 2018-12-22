<%@ Page Title="" Language="C#" MasterPageFile="~/Controls/AdminPage.master" AutoEventWireup="true" CodeFile="DashBoards.aspx.cs" Inherits="Pages_Content_DashBoards" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
	<script type="text/javascript" src="Charts/code/highcharts.js"></script>
	<script type="text/javascript" src="Charts/code/highcharts-3d.js"></script>
	<script type="text/javascript" src="Charts/code/modules/exporting.js"></script>
	<script type="text/javascript" src="Charts/code/modules/export-data.js"></script>
	<article>
	<div id="main-container">
		<div class="main-header clearfix">
			<div class="page-title">
				<h3 class="no-margin">
					<asp:Literal ID="ltrTitle" runat="server">Biểu đồ bán vé</asp:Literal>
				</h3>
			</div>
		</div>
		<div id="container" style="min-width: 310px; height: 400px; margin: 0 auto"></div>
		<div id="container<%=DateTime.Now.Year.ToString() %>" style="height: 400px"></div>
		<div id="container<%=DateTime.Now.AddYears(-1).Year.ToString() %>" style="height: 400px"></div>
	</div>
	</article>
</asp:Content>

