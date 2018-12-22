<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Header.ascx.cs" Inherits="Controls_Header" %>
<header id="top">
    <div class="container_12 clearfix">
	    <div id="logo" class="grid_6">
		    <!-- replace with your website title or logo -->
		    <a id="site-title" href="dashboard.html"><span>CADAVAN</span>CMS</a>
		    <a id="view-site" href="#">View Site</a>
	    </div>
	    <div id="userinfo" class="grid_6">
		    Xin chào, <a href="#"><asp:Label ID="lblName" runat="server" Text=""></asp:Label></a>
	    </div>
    </div>
</header>
