<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/ListPage.master" AutoEventWireup="true" CodeFile="Categories.List.aspx.cs" Inherits="Pages_Content_Categories_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main-container">
        <div class="main-header clearfix">
            <div class="page-title">
                <h3 class="no-margin">
                    <asp:Literal ID="ltrTitle" runat="server">Danh sách chuyên mục</asp:Literal>
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
                <span class="text">Thêm chuyên mục</span>
            </a>
        </div>
        <div class="padding-md">
            <div class="panel panel-default table-responsive">
                <div class="padding-md clearfix">
                    <table class="table table-striped" id="responsiveTable">
                        <thead>
                            <tr>
                                <th>Chuyên mục</th>
                                <th>Url</th>
                                <th>Trạng thái</th>
                                <th>Thứ tự</th>
                                <th>Ngày tạo</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rptList" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td><a href="<%=Constant.ADMIN_PATH %><%=Resources.Url.CategoriesEdit %>?id=<%#Eval("CateID") %>"><%#Eval("Alias") %></a></td>
                                        <td><%#Eval("Url") %></td>
                                        <td>
                                            <label class="label-checkbox">
                                                <asp:CheckBox ID="checkBoxStatus" Checked='<%#Eval("Status") %>' runat="server" />
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

