<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Station.ascx.cs" Inherits="Controls_Menu_Station" %>
<div class="grey-container shortcut-wrapper">
    <a href="<%=Constant.ADMIN_PATH + Resources.Url.RouteStationList %>?id=<%=Request["id"] %>" class="shortcut-link">
        <span class="shortcut-icon">
            <i class="fa fa-map-marker"></i>
        </span>
        <span class="text">Trạm dừng</span>
    </a>
    <a href="<%=Constant.ADMIN_PATH + Resources.Url.RoutesList %>" class="shortcut-link">
        <span class="shortcut-icon">
            <i class="fa fa-list"></i>
        </span>
        <span class="text">Danh sách tuyến</span>
    </a>
    <a href="<%=Constant.ADMIN_PATH + Resources.Url.RoutesAdd %>" class="shortcut-link">
        <span class="shortcut-icon">
            <i class="fa fa-plus"></i>
        </span>
        <span class="text">Thêm tuyến</span>
    </a>
    <a href="<%=Constant.ADMIN_PATH + Resources.Url.BusList %>" class="shortcut-link">
        <span class="shortcut-icon">
            <i class="fa fa-car"></i></span>
        <span class="text">Danh sách xe</span>
    </a>
    <a href="<%=Constant.ADMIN_PATH + Resources.Url.DriversList %>" class="shortcut-link">
        <span class="shortcut-icon">
            <i class="fa fa-car"></i></span>
        <span class="text">Lái xe</span>
    </a>
</div>
