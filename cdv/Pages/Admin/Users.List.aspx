<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/ListPage.master" AutoEventWireup="true" CodeFile="Users.List.aspx.cs" Inherits="Pages_Admin_Users_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main-container">
        <div class="main-header clearfix">
            <div class="page-title">
                <h3 class="no-margin">
                    <asp:Literal ID="ltrTitle" runat="server">Danh sách tài khoản</asp:Literal>
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
            <a href="<%=Constant.ADMIN_PATH + Resources.Url.UsersAdd %>" class="shortcut-link">
                <span class="shortcut-icon">
                    <i class="fa fa-plus"></i>
                </span>
                <span class="text">Thêm tài khoản</span>
            </a>
            <a href="<%=Constant.ADMIN_PATH + Resources.Url.RolesList %>" class="shortcut-link">
                <span class="shortcut-icon">
                    <i class="fa fa-users"></i>
                </span>
                <span class="text">Nhóm quyền</span>
            </a>
            <a href="<%=Constant.ADMIN_PATH + Resources.Url.PermissionsList %>" class="shortcut-link">
                <span class="shortcut-icon">
                    <i class="fa fa-lock"></i>
                </span>
                <span class="text">Quyền</span>
            </a>
        </div>
        <div class="padding-md">
            <div class="panel panel-default">
                <div class="panel-body">
                    <div class="form-inline no-margin">
                        <div class="form-group">
                            <asp:DropDownList ID="drpStatus" CssClass="form-control input-sm inline-block" runat="server">
                                <asp:ListItem Value="1">- Đang hoạt động</asp:ListItem>
                                <asp:ListItem Value="-1">- Ngừng hoạt động</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <asp:DropDownList ID="drpRole" DataTextField="Name" CssClass="form-control input-sm inline-block" DataValueField="RoleID" runat="server"></asp:DropDownList>
                        </div>
                        <asp:Button ID="btView" runat="server" CssClass="btn btn-sm btn-success" Text="Lọc" OnClick="btView_Click" />
                    </div>
                </div>
            </div>
            <!-- /panel -->


            <div class="panel panel-default table-responsive">
                <div class="panel-heading">
                    <asp:Label ID="lblTotalRecord" runat="server" Text="0"></asp:Label>
                </div>
                <div class="padding-md clearfix">
                    <table class="table table-striped" id="dataTable">
                        <thead>
                            <tr>
                                <th>Người dùng</th>
                                <th>Họ tên</th>
                                <th>Trạng thái</th>
                                <th>Nhóm quyền</th>
                                <th>Đổi mật khẩu</th>
                                <th>Ngày tạo</th>
                                <th>Lần đăng nhập cuối</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rptList" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td><a href="<%=Constant.ADMIN_PATH %><%=Resources.Url.UsersEdit %>?id=<%#Eval("UserID") %>"><%#Eval("Username") %></a></td>
                                        <td><%#Eval("Fullname") %></td>
                                        <td><%#StatusName(Eval("Status").ToString()) %></td>
                                        <td><%#Eval("RoleName") %></td>
                                        <td><a href="<%=Constant.ADMIN_PATH %><%=Resources.Url.UsersResetPassword %>?id=<%#Eval("UserID") %>"><span class="label label-success">Đổi mật khẩu</span></a></td>
                                        <td><%# string.Format("{0:yyyy/MM/dd}", Eval("Created"))%></td>
                                        <td><%# string.Format("{0:yyyy/MM/dd HH:mm}", Eval("Created"))%></td>
                                        <%--<td><%# string.Format("{0:yyyy/MM/dd HH:mm}", Eval("LastLogin"))%></td>--%>
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

