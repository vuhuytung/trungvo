<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucSuport.ascx.cs" Inherits="userControls_ucSuport" %>
 <div class="box clear" style="border:none; background-color:#FFF; margin-top:10px" id="divDoitac" runat="server">
     <div class="title" style="margin-bottom:0;">
         <span><a>Hỗ trợ trực tuyến</a></span>
      </div>
    <div align="center" style="border:solid 1px #459B30; font-weight:bold">
        <a href="ymsgr:sendIM?trongtrung.vo_1110">
            <img src="http://mail.opi.yahoo.com/online?u=trongtrung.vo_1110&amp;t=2&amp;m=g" vspace="6" border="0" title="Trọng Trung">
        </a><br/>
        <a href="ymsgr:sendIM?trongtrung.vo_1110">Mr Trung - 0168 282 7659</a>
        <br />
        <a href="ymsgr:sendIM?giangsinhbuon2010">
            <img src="http://mail.opi.yahoo.com/online?u=giangsinhbuon2010&amp;t=2&amp;m=g" vspace="6" border="0" title="Hữu Mỹ">
        </a><br/>
        <a href="ymsgr:sendIM?giangsinhbuon2010">Mr Mỹ - 0932 376 249</a>
        <div style="margin:20px 0; color:#666">
            Số lượt truy cập: <%=Application["So_Nguoi_TruyCap"]%>
            - Online: <%=Application["So_Nguoi_Online"]%>
        </div>
    </div>
    <div class="clear"></div>
</div>

