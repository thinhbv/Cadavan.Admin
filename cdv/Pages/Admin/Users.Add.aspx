<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/EditPage.master" AutoEventWireup="true" CodeFile="Users.Add.aspx.cs" Inherits="Pages_Admin_Users_Add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main-container">
        <div class="main-header clearfix">
            <div class="page-title">
                <h3 class="no-margin">
                    <asp:Literal ID="ltrTitle" runat="server">Thêm mới tài khoản</asp:Literal>
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
                    <i class="fa fa-sitemap"></i>
                </span>
                <span class="text">Nhóm quyền</span>
            </a>
            <a href="<%=Constant.ADMIN_PATH + Resources.Url.PermissionsList %>" class="shortcut-link">
                <span class="shortcut-icon">
                    <i class="fa fa-users"></i>
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
                            <label class="col-lg-2 control-label">Tài khoản (*)</label>
                            <div class="col-lg-6">
                                <asp:TextBox ID="txtUserName" class="form-control" Style="text-transform: lowercase;" runat="server"></asp:TextBox>
                                <span class="help-block">Tài khoản gồm các ký tự a-z, 0-9, độ dài 4-25 ký tự.</span>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtUserName"
                                    Display="Dynamic" ErrorMessage="Vui lòng nhập tài khoản"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                                    ControlToValidate="txtUserName" ErrorMessage="Tài khoản không đúng định dạng" Display="Dynamic"
                                    ValidationExpression="[0-9a-z]{4,25}">
                                </asp:RegularExpressionValidator>
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
                            <label class="col-lg-2 control-label">Nhóm quyền (*)</label>
                            <div class="col-lg-6">
                                <asp:DropDownList ID="drpRole" DataTextField="Name" CssClass="form-control chzn-select" DataValueField="RoleID" runat="server"></asp:DropDownList>
                                <span class="help-block"></span>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="drpRole"
                                    Display="Dynamic" ErrorMessage="Vui lòng chọn nhóm quyền" InitialValue="0"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-lg-2 control-label">Họ tên (*)</label>
                            <div class="col-lg-6">
                                <div class="row">
                                    <div class="col-lg-3">
                                        <asp:TextBox ID="txtFirstName" class="form-control" placeholder="Tên" runat="server"></asp:TextBox>
                                        <span class="help-block"></span>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFirstName"
                                            Display="Dynamic" ErrorMessage="Nhập tên"></asp:RequiredFieldValidator>
                                    </div>

                                    <div class="col-lg-4">
                                        <asp:TextBox ID="txtLastName" class="form-control" placeholder="Họ và đệm" runat="server"></asp:TextBox>
                                        <span class="help-block"></span>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtLastName"
                                            Display="Dynamic" ErrorMessage="Nhập họ & đệm"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-lg-2 control-label">Giới tính</label>
                            <div class="col-lg-6">
                                <asp:DropDownList ID="drpGender" CssClass="form-control chzn-select" runat="server">
                                    <asp:ListItem Text="Chọn giới tính:" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="- Nam" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="- Nữ" Value="2"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-lg-2 control-label">Ngày sinh (*)</label>
                            <div class="col-lg-6">
                                <div class="input-group">
                                    <asp:TextBox ID="txtBirthday" class="datepicker form-control" runat="server"></asp:TextBox>
                                    <span class="input-group-addon"><i class="fa fa-calendar"></i></span>
                                </div>
                                <span class="help-block">Định dạng dd/mm/yyyy, ví dụ 24/04/1986</span>
                                <asp:RangeValidator runat="server" ID="RangeValidatorBirthday" Type="Date" CultureInvariantValues="true"
                                    ControlToValidate="txtBirthday" ErrorMessage="enter valid date" Display="Dynamic" />
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-lg-2 control-label">Di động</label>
                            <div class="col-lg-6">
                                <asp:TextBox ID="txtMobile" class="form-control" TextMode="Number" runat="server"></asp:TextBox>
                                <span class="help-block">Ví dụ 0936987234</span>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server"
                                    ControlToValidate="txtMobile" ErrorMessage="Di động không đúng định dạng" Display="Dynamic"
                                    ValidationExpression="[0-9]{8,15}">
                                </asp:RegularExpressionValidator>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-lg-2 control-label">Email</label>
                            <div class="col-lg-6">
                                <asp:TextBox ID="txtEmail" class="form-control" TextMode="Email" Style="text-transform: lowercase;" runat="server"></asp:TextBox>
                                <span class="help-block">Ví dụ: hoten@congty.vn</span>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-lg-2 control-label">Phòng ban</label>
                            <div class="col-lg-10">
                                <p class="form-control-static">Bỏ qua thông tin này</p>
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="col-lg-2"></div>
                            <div class="col-lg-5">
                                <asp:Button ID="btSubmit" runat="server" CssClass="btn btn-info" Text="Thêm mới" OnClick="btSubmit_Click" />
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
        <!-- /.padding-md -->
    </div>
    <!-- /main-container -->
</asp:Content>

