<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Error500.aspx.cs" Inherits="Pages_Error_Error500" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>BusTime - Lỗi hệ thống</title>
    <!-- Bootstrap core CSS -->
    <link href="/admin/resources/bootstrap/css/bootstrap.min.css" rel="stylesheet" />

    <!-- Font Awesome -->
    <link href="/admin/resources/css/font-awesome.min.css" rel="stylesheet" />

    <!-- Endless -->
    <link href="/admin/resources/css/endless.min.css" rel="stylesheet" />
    <link href="/admin/resources/css/endless-skin.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="wrapper">
            <div class="padding-md" style="margin-top: 50px;">
                <div class="row">
                    <div class="col-md-4 col-md-offset-4 col-sm-6 col-sm-offset-3 text-center">
                        <div class="h5">Lỗi hệ thống</div>
                        <h1 class="m-top-none error-heading">500</h1>

                        <div class="m-bottom-md">Bạn có thể thử lại, nếu không được hãy liên hệ với người quản trị!</div>
                        <a class="btn btn-success m-bottom-sm" href="/admin/login.html"><i class="fa fa-home"></i>Back to Dashboard</a>
                        <a class="btn btn-success m-bottom-sm" href="#"><i class="fa fa-envelope"></i>Contact Us</a>
                    </div>
                    <!-- /.col -->
                </div>
                <!-- /.row -->
            </div>
            <!-- /.padding-md -->
        </div>
        <!-- /wrapper -->

        <!-- Le javascript
    ================================================== -->
        <!-- Placed at the end of the document so the pages load faster -->

        <!-- Jquery -->
        <script src="/admin/resources/js/jquery-1.10.2.min.js"></script>

        <!-- Bootstrap -->
        <script src="/admin/resources/bootstrap/js/bootstrap.min.js"></script>

        <!-- Modernizr -->
        <script src='/admin/resources/js/modernizr.min.js'></script>

        <!-- Pace -->
        <script src='/admin/resources/js/pace.min.js'></script>

        <!-- Popup Overlay -->
        <script src='/admin/resources/js/jquery.popupoverlay.min.js'></script>

        <!-- Slimscroll -->
        <script src='/admin/resources/js/jquery.slimscroll.min.js'></script>

        <!-- Cookie -->
        <script src='/admin/resources/js/jquery.cookie.min.js'></script>

        <!-- Endless -->
        <script src="/admin/resources/js/endless/endless.js"></script>
    </form>
</body>
</html>
