﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/EditPage.master" AutoEventWireup="true" CodeFile="Users.ResetPassword.aspx.cs" Inherits="Pages_Admin_Users_ResetPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="main-container">
        <div class="main-header clearfix">
            <div class="page-title">
                <h3 class="no-margin">
                    <asp:Literal ID="ltrTitle" runat="server">Đặt lại mật khẩu</asp:Literal>
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
            <a href="<%=Constant.ADMIN_PATH + Resources.Url.PermissionsList %>" class="shortcut-link">
                <span class="shortcut-icon">
                    <i class="fa fa-lock"></i>
                </span>
                <span class="text">Quyền</span>
            </a>
        </div>
        <div class="padding-md">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <asp:Literal ID="literalMessage" runat="server"></asp:Literal>
                    Lưu ý: dấu (*) là bắt buộc phải nhập dữ liệu.
					
                    <span class="pull-right">
                        <label class="label-checkbox inline">
                            <input type="checkbox" id="toggleLine" checked />
                            <span class="custom-checkbox"></span>
                            Hiện dòng kẻ
                       
                        </label>
                    </span>
                </div>
                <div class="panel-body">
                    <div id="formToggleLine" class="form-horizontal no-margin form-border">

                        <div class="form-group">
                            <label class="col-lg-2 control-label">Tài khoản</label>
                            <div class="col-lg-6">
                                <p class="form-control-static">
                                    <asp:Literal ID="ltrUserName" runat="server">Tài khoản</asp:Literal></p>
                                <span class="help-block"></span>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-lg-2 control-label">Mật khẩu (*)</label>
                            <div class="col-lg-6">
                                <asp:TextBox ID="txtPassword" TextMode="Password" CssClass="form-control" runat="server"></asp:TextBox>
                                <span class="help-block">Mật khẩu có độ dài tối thiểu 6 ký tự, tối thiểu 1 chữ cái (a-z), một chữ số (0-9).</span>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtPassword"
                                    Display="Dynamic" ErrorMessage="Bạn chưa nhập mật khẩu"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                                    ControlToValidate="txtPassword" ErrorMessage="Mật khẩu không đúng định dạng" Display="Dynamic"
                                    ValidationExpression="^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{6,}$">
                                </asp:RegularExpressionValidator>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-lg-2 control-label">Nhập lại mật khẩu (*)</label>
                            <div class="col-lg-6">
                                <asp:TextBox ID="txtRePassword" TextMode="Password" CssClass="form-control" runat="server"></asp:TextBox>
                                <span class="help-block">Cần nhập lại mật khẩu trùng khớp.</span>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtRePassword"
                                    Display="Dynamic" ErrorMessage="Bạn chưa nhập lại mật khẩu"></asp:RequiredFieldValidator>
                                <asp:CompareValidator runat="server" ID="CompareValidator1" ControlToCompare="txtPassword" ControlToValidate="txtRePassword"
                                    Display="Dynamic" ErrorMessage="Mật khẩu nhập lại không khớp" />
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-lg-2 control-label">Trạng thái</label>
                            <div class="col-lg-6">
                                <label class="label-checkbox">
                                    <asp:CheckBox ID="cbStatus" runat="server" Checked="true" />
                                    <span class="custom-checkbox"></span>
                                    Bỏ chọn người dùng sẽ không đăng nhập được vào hệ thống
                               
                                </label>
                            </div>
                        </div>
                        
                        <div class="form-group">
                            <div class="col-lg-2"></div>
                            <div class="col-lg-5">
                                <asp:Button ID="btSubmit" runat="server" CssClass="btn btn-info" Text="Đổi mật khẩu" OnClick="btSubmit_Click" />
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
        <!-- /.padding-md -->
    </div>
</asp:Content>

