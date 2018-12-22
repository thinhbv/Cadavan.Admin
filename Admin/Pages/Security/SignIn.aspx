<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SignIn.aspx.cs" Inherits="SignIn" EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="shortcut icon" href="../../resources/images/favicon.ico" type="image/x-icon">    
    <link rel="stylesheet" type="text/css" href="../../resources/css/style.css" />
    <title>Hệ thống quản trị nội dung - Đăng nhập</title>
    <link rel="stylesheet" type="text/css" href="../../resources/css/style.css" />
    <script type="text/javascript" src="../../resources/js/jquery-1.4.4.min.js"></script>
    <script type="text/javascript" src="../../resources/js/cufon-yui.js"></script>
    <script type="text/javascript" src="../../resources/js/Delicious_500.font.js"></script>
    <script type="text/javascript">
    $(function() {
	    Cufon.replace('#site-title');
	    $('.msg').click(function() {
		    $(this).fadeTo('slow', 0);
		    $(this).slideUp(341);
	    });
    });
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <header id="top">
	        <div class="container_12 clearfix">
		        <div id="logo" class="grid_12">
			        <!-- replace with your website title or logo -->
			        <a id="site-title" href="#"><span>ThaiBinh</span>Hospital</a>
			        <a id="view-site" href="#">View Site</a>
		        </div>
	        </div>
        </header>
        <div id="login" class="box">
	        <h2>Đăng nhập hệ thống</h2>
	        <section>
	            <asp:Panel ID="PanelMessage" runat="server" Visible="false">
		        <div class="error msg"><asp:Label ID="lblMessage" runat="server" Text="Message if login failed"></asp:Label></div>
		        </asp:Panel>
		        <form>
			        <dl>
				        <dt><label for="username">Tên đăng nhập</label></dt>
				        <dd><asp:TextBox ID="txtUserName" Width="230px" autocomplete="off" runat="server"></asp:TextBox></dd>
        			
				        <dt><label for="adminpassword">Mật khẩu</label></dt>
				        <dd><asp:TextBox ID="txtPassword" Width="230px" TextMode="Password" runat="server"></asp:TextBox></dd>
			        </dl>
			        <label><input type="checkbox" />Lưu trạng thái đăng nhập</label>
			        <p>
			            <asp:Button ID="btSignIn" runat="server" CssClass="button gray" 
                            Text="Đăng nhập" onclick="btSignIn_Click"></asp:Button>
				        <a id="forgot" href="#">Quên mật khẩu?</a>
			        </p>
		        </form>
	        </section>
        </div>
    </form>
</body>
</html>
