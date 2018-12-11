<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/ListPage.master" AutoEventWireup="true" CodeFile="Roles.List.aspx.cs" Inherits="Pages_Admin_Roles_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main-container">
        <div class="main-header clearfix">
            <div class="page-title">
                <h3 class="no-margin">
                    <asp:Literal ID="ltrTitle" runat="server">Danh sách nhóm người dùng</asp:Literal>
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
            <a href="<%=Constant.ADMIN_PATH + Resources.Url.RolesAdd %>" class="shortcut-link">
                <span class="shortcut-icon">
                    <i class="fa fa-plus"></i>
                </span>
                <span class="text">Thêm nhóm</span>
            </a>
            <a href="<%=Constant.ADMIN_PATH + Resources.Url.UsersList %>" class="shortcut-link">
                <span class="shortcut-icon">
                    <i class="fa fa-user"></i>
                </span>
                <span class="text">Tài khoản</span>
            </a>
            <a href="<%=Constant.ADMIN_PATH + Resources.Url.PermissionsList %>" class="shortcut-link">
                <span class="shortcut-icon">
                    <i class="fa fa-lock"></i>
                </span>
                <span class="text">Quyền</span>
            </a>
        </div>
        <div class="padding-md">
            <div class="panel panel-default table-responsive">
                <div class="padding-md clearfix">
                    <table class="table table-striped" id="dataTable">
                        <thead>
                            <tr>
                                <th>Thứ tự</th>
                                <th>Nhóm quyền</th>
                                <th>Tên viết tắt</th>
                                <th>Trạng thái</th>
                                <th>Xem quyền</th>
                                <th>Ngày tạo</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rptList" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td><%#Eval("Order") %></td>
                                        <td><a href="<%=Constant.ADMIN_PATH %><%=Resources.Url.RolesEdit %>?id=<%#Eval("RoleID") %>"><%#Eval("Name") %></a></td>
                                        <td><%#Eval("Alias") %></td>
                                        <td><%#StatusName(Eval("Status").ToString()) %></td>
                                        <td><a href="<%=Constant.ADMIN_PATH %><%=Resources.Url.RolesPermission %>?id=<%#Eval("RoleID") %>"><span class="label label-success">Xem</span></a></td>
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

