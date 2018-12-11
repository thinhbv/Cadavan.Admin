<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/EditPage.master" AutoEventWireup="true" CodeFile="Roles.Edit.aspx.cs" Inherits="Pages_Admin_Roles_Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="main-container">
        <div class="main-header clearfix">
            <div class="page-title">
                <h3 class="no-margin">
                    <asp:Literal ID="ltrTitle" runat="server">Cập nhật nhóm người dùng</asp:Literal>
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
            <a href="<%=Constant.ADMIN_PATH + Resources.Url.RolesList %>" class="shortcut-link">
                <span class="shortcut-icon">
                    <i class="fa fa-users"></i>
                </span>
                <span class="text">Nhóm người dùng</span>
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
                            <label class="col-lg-2 control-label">Tên nhóm (*)</label>
                            <div class="col-lg-6">
                                <asp:TextBox ID="txtName" class="form-control" runat="server"></asp:TextBox>
                                <span class="help-block"></span>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName"
                                    Display="Dynamic" ErrorMessage="Vui lòng nhập tên nhóm người dùng"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-lg-2 control-label">Tên viết tắt (*)</label>
                            <div class="col-lg-6">
                                <asp:TextBox ID="txtAlias" class="form-control" runat="server"></asp:TextBox>
                                <span class="help-block"></span>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtAlias"
                                    Display="Dynamic" ErrorMessage="Bạn chưa nhập tên viết tắt"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-lg-2 control-label">Trạng thái</label>
                            <div class="col-lg-6">
                                <label class="label-checkbox">
                                    <asp:CheckBox ID="cbStatus" runat="server" Checked="true" />
                                    <span class="custom-checkbox"></span>

                                </label>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-lg-2 control-label">Thứ tự (*)</label>
                            <div class="col-lg-6">
                                <asp:TextBox ID="txtOrder" class="form-control" TextMode="Number" runat="server"></asp:TextBox>
                                <span class="help-block"></span>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtOrder"
                                    Display="Dynamic" ErrorMessage="Bạn chưa nhập thứ tự"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-lg-2 control-label">Mô tả</label>
                            <div class="col-lg-6">
                                <asp:TextBox ID="txtDescription" CssClass="form-control" TextMode="MultiLine" Height="80px" runat="server"></asp:TextBox>
                                <span class="help-block"></span>
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="col-lg-2"></div>
                            <div class="col-lg-5">
                                <asp:Button ID="btSubmit" runat="server" CssClass="btn btn-info" Text="Cập nhật" OnClick="btSubmit_Click" />
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
        <!-- /.padding-md -->
    </div>
</asp:Content>

