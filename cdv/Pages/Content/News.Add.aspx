<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/EditPage.master" AutoEventWireup="true" CodeFile="News.Add.aspx.cs" Inherits="Pages_Content_News_Add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="main-container">
        <div class="main-header clearfix">
            <div class="page-title">
                <h3 class="no-margin">
                    <asp:Literal ID="ltrTitle" runat="server">Thêm mới bài viết</asp:Literal>
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
            <a href="<%=Constant.ADMIN_PATH + Resources.Url.CategoriesList %>" class="shortcut-link">
                <span class="shortcut-icon">
                    <i class="fa fa-user"></i>
                </span>
                <span class="text">Chuyên mục</span>
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
                            <label class="col-lg-2 control-label">Tiêu đề (*)</label>
                            <div class="col-lg-6">
                                <asp:TextBox ID="txtTitle" class="form-control" runat="server"></asp:TextBox>
                                <span class="help-block">Bạn có thể nhập tạm tiêu đề</span>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTitle"
                                    Display="Dynamic" ErrorMessage="Vui lòng nhập tiêu đề"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-lg-2 control-label">Trích dẫn (*)</label>
                            <div class="col-lg-6">
                                <asp:TextBox ID="txtLead" CssClass="form-control" TextMode="MultiLine" Height="80px" runat="server"></asp:TextBox>
                                <span class="help-block"></span>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtLead"
                                    Display="Dynamic" ErrorMessage="Bạn chưa nhập trích dẫn"></asp:RequiredFieldValidator>
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
</asp:Content>

