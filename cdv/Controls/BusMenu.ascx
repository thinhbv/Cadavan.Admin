<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BusMenu.ascx.cs" Inherits="Controls_BusMenu" %>
<div class="grey-container shortcut-wrapper">
    <a href="<%=Constant.ADMIN_PATH + Resources.Url.DriversList %>" class="shortcut-link">
        <span class="shortcut-icon">
            <i class="fa fa-user"></i>
        </span>
        <span class="text">Lái xe</span>
    </a>
    <a href="<%=Constant.ADMIN_PATH + Resources.Url.DriversAdd %>" class="shortcut-link">
        <span class="text"><i class="fa fa-plus"></i> Thêm lái xe</span>
    </a>

    <a href="<%=Constant.ADMIN_PATH + Resources.Url.BusTypeList %>" class="shortcut-link">
        <span class="shortcut-icon">
            <i class="fa fa-dashboard"></i>
        </span>
        <span class="text">Loại xe</span>
    </a>
    <a href="<%=Constant.ADMIN_PATH + Resources.Url.BusTypeAdd %>" class="shortcut-link">
        <span class="text"><i class="fa fa-plus"></i> Thêm loại xe</span>
    </a>

    <a href="<%=Constant.ADMIN_PATH + Resources.Url.BusList %>" class="shortcut-link">
        <span class="shortcut-icon">
            <i class="fa fa-car"></i></span>
        <span class="text">Danh sách xe</span>
    </a>
    <a href="<%=Constant.ADMIN_PATH + Resources.Url.BusAdd %>" class="shortcut-link">
        <span class="text"><i class="fa fa-plus"></i> Thêm xe</span>
    </a>
</div>
