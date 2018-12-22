<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TopMenu.ascx.cs" Inherits="Controls_TopMenu" %>
    <nav id="topmenu">
	    <div class="container_12 clearfix">
		    <div class="grid_12">
			    <ul id="mainmenu" class="sf-menu">
			    <asp:Literal ID="ltrMenu" runat="server"></asp:Literal>
			    </ul>
			    <ul id="usermenu">
				    <li><a href="<%=Constant.ADMIN_PATH %><%=Resources.Url.ChangePassword %>">Password</a></li>
				    <li><a href="<%=Constant.ADMIN_PATH %><%=Resources.Url.SignOut %>">Logout</a></li>
			    </ul>
		    </div>
	    </div>
    </nav>
