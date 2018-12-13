<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Left.ascx.cs" Inherits="Controls_Left" %>
<aside class="fixed skin-6">
    <div class="sidebar-inner scrollable-sidebars">
        <div class="size-toggle">
            <a class="btn btn-sm" id="sizeToggle">
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
            </a>
            <a class="btn btn-sm pull-right logoutConfirm_open" href="#logoutConfirm">
                <i class="fa fa-power-off"></i>
            </a>
        </div>
        <div class="main-menu">
            <ul>
                <%--<li class="openable open">
                    <a href="#">
                        <span class="menu-icon">
                            <i class="fa fa-car fa-lg"></i>
                        </span>
                        <span class="text">Quản lý xe</span>
                        <span class="menu-hover"></span>
                    </a>
                    <ul class="submenu">
                        <li><a href="<%=Constant.ADMIN_PATH %><%=Resources.Url.BusList %>"><span class="submenu-label">Danh sách xe</span></a></li>
                        <li><a href="<%=Constant.ADMIN_PATH %><%=Resources.Url.DriversList %>"><span class="submenu-label">Lái xe</span></a></li>
                        <li><a href="<%=Constant.ADMIN_PATH %><%=Resources.Url.BusTypeList %>"><span class="submenu-label">Loại xe</span></a></li>
                        <li><a href="<%=Constant.ADMIN_PATH %><%=Resources.Url.RoutesList %>"><span class="submenu-label">Tuyến xe</span></a></li>
                        <li><a href="<%=Constant.ADMIN_PATH %><%=Resources.Url.StationsList %>"><span class="submenu-label">Trạm dừng</span></a></li>
                    </ul>
                </li>--%>
                <li class="openable">
                    <a href="#">
                        <span class="menu-icon">
                            <i class="fa fa-cog fa-lg"></i>
                        </span>
                        <span class="text">Hệ thống</span>
                        <span class="menu-hover"></span>
                    </a>
                    <ul class="submenu">
                        <li><a href="<%=Constant.ADMIN_PATH %><%=Resources.Url.UsersList %>"><span class="submenu-label">Người dùng</span></a></li>
                        <li><a href="<%=Constant.ADMIN_PATH %><%=Resources.Url.RolesList %>"><span class="submenu-label">Nhóm quyền</span></a></li>
                        <li><a href="<%=Constant.ADMIN_PATH %><%=Resources.Url.PermissionsList %>"><span class="submenu-label">Quyền hệ thống</span></a></li>
                    </ul>
                </li>
                <li class="openable">
                    <a href="#">
                        <span class="menu-icon">
                            <i class="fa fa-desktop fa-lg"></i>
                        </span>
                        <span class="text">Quản lý đơn hàng</span>
                        <span class="menu-hover"></span>
                    </a>
                    <ul class="submenu">
                        <%--<li><a href="<%=Constant.ADMIN_PATH %><%=Resources.Url.BusScheduleList %>"><span class="submenu-label">Lịch hàng tuần</span></a></li>--%>
                        <li><a href="<%=Constant.ADMIN_PATH %><%=Resources.Url.BookingList %>"><span class="submenu-label">Bán vé</span></a></li>
                    </ul>
                </li>
                <%--<li class="openable">
                    <a href="#">
                        <span class="menu-icon">
                            <i class="fa fa-book fa-lg"></i>
                        </span>
                        <span class="text">Tin tức</span>
                        <span class="menu-hover"></span>
                    </a>
                    <ul class="submenu">
                        <li><a href="<%=Constant.ADMIN_PATH %><%=Resources.Url.CategoriesList %>"><span class="submenu-label">Chuyên mục</span></a></li>
                    </ul>
                </li>--%>
            </ul>

            <%--<div class="alert alert-info">
                Welcome to Endless Admin. Do not forget to check all my pages. 
				
            </div>--%>
        </div>
        <!-- /main-menu -->
    </div>
    <!-- /sidebar-inner -->
</aside>
