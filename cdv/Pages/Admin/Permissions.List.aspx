﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/ListPage.master" AutoEventWireup="true" CodeFile="Permissions.List.aspx.cs" Inherits="Pages_Admin_Permissions_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="main-container">
        <div class="main-header clearfix">
            <div class="page-title">
                <h3 class="no-margin">
                    <asp:Literal ID="ltrTitle" runat="server">Danh sách quyền</asp:Literal>
                </h3>
                <span>
                    <asp:Literal ID="ltrSubTitle" runat="server"></asp:Literal>
                </span>
            </div>

            <ul class="page-stats">
                <asp:Repeater ID="rptReport" runat="server">
                    <ItemTemplate>
                        <li>
                            <div class="value">
                                <span><%#Eval("Name") %></span>
                                <h4><%#Eval("Value") %></h4>
                            </div>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
        <div class="grey-container shortcut-wrapper">
            <a href="<%=Constant.ADMIN_PATH + Resources.Url.PermissionsAdd %>" class="shortcut-link">
                <span class="shortcut-icon">
                    <i class="fa fa-plus"></i>
                </span>
                <span class="text">Thêm quyền</span>
            </a>
            <a href="<%=Constant.ADMIN_PATH + Resources.Url.UsersList %>" class="shortcut-link">
                <span class="shortcut-icon">
                    <i class="fa fa-user"></i>
                </span>
                <span class="text">Tài khoản</span>
            </a>
            <a href="<%=Constant.ADMIN_PATH + Resources.Url.RolesList %>" class="shortcut-link">
                <span class="shortcut-icon">
                    <i class="fa fa-users"></i>
                </span>
                <span class="text">Nhóm quyền</span>
            </a>
        </div>
        <div class="padding-md">
            <div class="panel panel-default">
                <div class="panel-body">
                    <div class="form-inline no-margin">
                        <div class="form-group">
                            <asp:DropDownList ID="drpFather" DataTextField="Name" CssClass="form-control" DataValueField="PermissionID" runat="server"></asp:DropDownList>
                        </div>
                        <asp:Button ID="btView" runat="server" CssClass="btn btn-sm btn-success" Text="Lọc" OnClick="btView_Click" />
                    </div>
                </div>
            </div>
            <div class="panel panel-default table-responsive">
                <div class="padding-md clearfix">
                    <table class="table table-striped" id="responsiveTable">
                            <thead>
                                <tr>
                                    <th>Tên quyền</th>
                                    <th>Url</th>
                                    <th>Trạng thái</th>
                                    <th>Hiện menu</th>
                                    <th>Thứ tự</th>
                                    <th>Ngày tạo</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="rptList" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td><a href="<%=Constant.ADMIN_PATH %><%=Resources.Url.PermissionsEdit %>?id=<%#Eval("PermissionID") %>"><%#Eval("Alias") %></a></td>
                                            <td><%#Eval("Url") %></td>
                                            <td>
                                                <label class="label-checkbox">
                                                    <asp:CheckBox ID="checkBoxStatus" Checked='<%#Eval("Status") %>' runat="server" />
                                                    <span class="custom-checkbox"></span>
                                                </label>
                                            </td>
                                            <td>
                                                <label class="label-checkbox">
                                                    <asp:CheckBox ID="checkBoxShowMenu" Checked='<%#Eval("ShowMenu") %>' runat="server" />
                                                    <span class="custom-checkbox"></span>
                                                </label>
                                            </td>
                                            <td><%#Eval("Order") %></td>
                                            <td><%# string.Format("{0:yyyy/MM/dd}", Eval("Created"))%></td>
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
    </div>
</asp:Content>

