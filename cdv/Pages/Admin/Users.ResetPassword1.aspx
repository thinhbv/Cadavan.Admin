<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/HomePage.master" AutoEventWireup="true" CodeFile="Users.ResetPassword1.aspx.cs" Inherits="Pages_Admin_Users_ResetPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="main-container">
        <div class="padding-md">
            <div class="panel panel-default">
                <div class="panel-body">
                    <div class="form-horizontal no-margin form-border">
                        <asp:Literal ID="literalMessage" runat="server"></asp:Literal>
                        <h3 class="headline m-top-md">Thêm mới người dùng
                       
                            <span class="line"></span>
                        </h3>
                        <div class="form-group">
                            <label class="col-lg-2 control-label">Tên truy cập</label>
                            <div class="col-lg-6">
                                <asp:TextBox ID="txtUsername" ReadOnly="true" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-lg-2 control-label">Mật khẩu mới</label>
                            <div class="col-lg-6">
                                <asp:TextBox ID="txtPassword" CssClass="form-control" TextMode="Password" runat="server"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-lg-2 control-label">Nhật lại mật khẩu</label>
                            <div class="col-lg-6">
                                <asp:TextBox ID="txtRePassword" CssClass="form-control" TextMode="Password" runat="server"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="col-lg-2"></div>
                            <div class="col-lg-5">
                                <asp:Button ID="btEdit" runat="server" CssClass="btn btn-success" Text="Cập nhật" OnClick="btEdit_Click" />
                                <a class="btn btn-warning btn-small logoutConfirm_open" href="#logoutConfirm">Huỷ</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

