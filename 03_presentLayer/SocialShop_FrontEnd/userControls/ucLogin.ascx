<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucLogin.ascx.cs" Inherits="userControls_ucLogin" %>
<div class="box clear usermenu">
     <div class="title" style="margin-bottom:0; text-align:left;height:22px; color:#000">
        <%if (Convert.ToBoolean(Session[VTCO.Config.Constants.SESSION_USER_ISLOGIN] ?? false))
          { %>
            Chào, <a style="color:#FF8040" href="/userinfo"><%=Session[VTCO.Config.Constants.SESSION_USER_FULLNAME]??"" %></a>
        <%}
          else
          { %>
             <a style="color:#000" href="/register"><img src="/images/newdref.png" width="12" /> Đăng ký</a>
             <a style="color:#000; margin-left:20px" href="/login"><img src="/images/icon_users.png" width="12" /> Đăng nhập</a>
             <a style="color:#000; margin-left:20px" href="/addrealtymarket"><img width="12" src="/images/addnew_16.png" /> Đăng bất động sản </a>
         <%} %>         
      </div>      
      <%if (Convert.ToBoolean(Session[VTCO.Config.Constants.SESSION_USER_ISLOGIN] ?? false))
          { %>
        <div style="height:130px;">
            <ul class="spTitle">
                <li><a class="usermenuitem" href="/userinfo"><img src="/images/newdref.png" width="12" /> Thông tin cá nhân</a></li>
                <li><a class="usermenuitem" href="/userchangepass"><img src="/images/change_password.png" width="12" /> Đổi mật khẩu</a></li>
                <li><a class="usermenuitem" href="/myrealtymarket"><img width="12" src="/images/icon_2.png" /> Bất động sản của tôi </a></li>
                <li><a class="usermenuitem" href="/addrealtymarket"><img width="12" src="/images/addnew_16.png" /> Đăng bất động sản </a></li>
                <li><asp:LinkButton runat="server" ID="lbtLogout" CssClass="usermenuitem" OnClick="lbtLogout_Click"><img width="12" src="/images/logout.png" /> Đăng xuất </asp:LinkButton></li>
            </ul>
        </div>
        <%}%>
    <div class="clear"></div>
</div>