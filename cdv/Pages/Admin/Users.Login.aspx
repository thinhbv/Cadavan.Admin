<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Users.Login.aspx.cs" Inherits="Pages_Admin_Users_Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>BusTime: Đăng nhập hệ thống</title>
    <!-- Bootstrap core CSS -->
    <link href="../../resources/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
	
	<!-- Font Awesome -->
	<link href="../../resources/css/font-awesome.min.css" rel="stylesheet" />
	
	<!-- Endless -->
	<link href="../../resources/css/endless.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server" defaultbutton="linkButtonLogin">
    <div class="login-wrapper">
		<div class="text-center">
			<h2 class="fadeInUp animation-delay8" style="font-weight:bold">
				<span class="text-success">BusTime</span> <span style="color:#ccc; text-shadow:0 1px #fff">Admin</span>
			</h2>
		</div>
		<div class="login-widget animation-delay1">	
			<div class="panel panel-default">
				<div class="panel-heading clearfix">
					<div class="pull-left">
						<i class="fa fa-lock fa-lg"></i> Đăng nhập hệ thống
					</div>
				</div>
				<div class="panel-body">
					<div class="form-login">
						<div class="form-group">
							<label>Tài khoản</label>
                            <asp:TextBox ID="txtUserName" autocomplete="off" placeholder="Nhập tài khoản" CssClass="form-control input-sm bounceIn animation-delay2" runat="server"></asp:TextBox>
						</div>

						<div class="form-group">
							<label>Mật khẩu</label>
							<asp:TextBox ID="txtPassword" TextMode="Password" placeholder="Nhập mật khẩu" CssClass="form-control input-sm bounceIn animation-delay4" runat="server"></asp:TextBox>
						</div>
                        
                        <asp:Literal ID="literalMessage" runat="server"></asp:Literal>
						<hr/>
							
                        <asp:LinkButton ID="linkButtonLogin" CssClass="btn btn-success btn-sm bounceIn animation-delay5 login-link pull-right" runat="server" OnClick="linkButtonLogin_Click"><i class="fa fa-sign-in"></i> Đăng nhập</asp:LinkButton>
					</div>
				</div>
			</div><!-- /panel -->
		</div><!-- /login-widget -->
	</div><!-- /login-wrapper -->

    <!-- Le javascript
    ================================================== -->
    <!-- Placed at the end of the document so the pages load faster -->
    
    <!-- Jquery -->
	<script src="./resources/js/jquery-1.10.2.min.js"></script>
    
    <!-- Bootstrap -->
    <script src="./resources/bootstrap/js/bootstrap.min.js"></script>
   
	<!-- Modernizr -->
	<script src='./resources/js/modernizr.min.js'></script>
   
    <!-- Pace -->
	<script src='./resources/js/pace.min.js'></script>
   
	<!-- Popup Overlay -->
	<script src='./resources/js/jquery.popupoverlay.min.js'></script>
   
    <!-- Slimscroll -->
	<script src='./resources/js/jquery.slimscroll.min.js'></script>
   
	<!-- Cookie -->
	<script src='./resources/js/jquery.cookie.min.js'></script>

	<!-- Endless -->
	<script src="./resources/js/endless/endless.js"></script>
    </form>
</body>
</html>
