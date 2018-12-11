<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/HomePage.master" AutoEventWireup="true" CodeFile="Permissions.Edit.aspx.cs" Inherits="Pages_Admin_Permissions_Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main-container">
        <div class="main-header clearfix">
            <div class="page-title">
                <h3 class="no-margin">
                    <asp:Literal ID="ltrTitle" runat="server">Cập nhật quyền</asp:Literal>
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
            <a href="<%=Constant.ADMIN_PATH + Resources.Url.PermissionsList %>" class="shortcut-link">
                <span class="shortcut-icon">
                    <i class="fa fa-lock"></i>
                </span>
                <span class="text">Quyền</span>
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
                            <label class="col-lg-2 control-label">Tên quyền (*)</label>
                            <div class="col-lg-6">
                                <asp:TextBox ID="txtName" class="form-control" runat="server"></asp:TextBox>
                                <span class="help-block"></span>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtName"
                                    Display="Dynamic" ErrorMessage="Vui lòng nhập tên quyền"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-lg-2 control-label">Tên viết tắt (*)</label>
                            <div class="col-lg-6">
                                <asp:TextBox ID="txtAlias" class="form-control" runat="server"></asp:TextBox>
                                <span class="help-block"></span>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtAlias"
                                    Display="Dynamic" ErrorMessage="Bạn chưa nhập tên viết tắt"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-lg-2 control-label">Url (*)</label>
                            <div class="col-lg-6">
                                <asp:TextBox ID="txtUrl" class="form-control" runat="server"></asp:TextBox>
                                <span class="help-block"></span>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtUrl"
                                    Display="Dynamic" ErrorMessage="Bạn chưa nhập Url"></asp:RequiredFieldValidator>
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
                            <label class="col-lg-2 control-label">Hiển thị ở menu</label>
                            <div class="col-lg-6">
                                <label class="label-checkbox">
                                    <asp:CheckBox ID="cbShowMenu" runat="server" />
                                    <span class="custom-checkbox"></span>
                               
                                </label>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-lg-2 control-label">Quyền mức cha</label>
                            <div class="col-lg-6">
                                <asp:DropDownList ID="drpFather" DataTextField="Name" CssClass="form-control chzn-select" DataValueField="PermissionID" AutoPostBack="true" runat="server" OnSelectedIndexChanged="drpFather_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-lg-2 control-label">Thứ tự</label>
                            <div class="col-lg-6">
                                <asp:DropDownList ID="drpOrder" DataTextField="Name" CssClass="form-control chzn-select" DataValueField="PermissionID" runat="server"></asp:DropDownList>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-lg-2 control-label">Mô tả</label>
                            <div class="col-lg-6">
                                <asp:TextBox ID="txtDescription" CssClass="form-control" TextMode="MultiLine" Height="80px" runat="server"></asp:TextBox>
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

