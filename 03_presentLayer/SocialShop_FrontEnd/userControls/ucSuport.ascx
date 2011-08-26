<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucSuport.ascx.cs" Inherits="userControls_ucSuport" %>
 <div class="box clear" style="border:none; background-color:#FFF; margin-top:10px" id="divDoitac" runat="server">
     <div class="title" style="margin-bottom:0;">
         <span><a>Hỗ trợ trực tuyến</a></span>
      </div>
    <div align="center" style="border:solid 1px #459B30; font-weight:bold; border-top:none">
        &nbsp;
        <asp:Repeater ID="rptYahoo" runat="server">
            <ItemTemplate>
                <a href="ymsgr:sendIM?<%#Eval("YahooID") %>">
            <img src="http://mail.opi.yahoo.com/online?u=<%#Eval("YahooID") %>&amp;t=2&amp;m=g" vspace="6" border="0" title="<%#Eval("YahooText").ToString().Replace("\"","'") %>" height="25" width="125">
            </a><br/>
            <a href="ymsgr:sendIM?<%#Eval("YahooID") %>"><%#Eval("YahooText") %></a>
            <br />
            </ItemTemplate>
        </asp:Repeater>
        <asp:Repeater ID="rptSkype" runat="server">
            <ItemTemplate>
                <a href="skype:<%#Eval("SkypeID") %>">
                <img src="http://mystatus.skype.com/bigclassic/<%#Eval("SkypeID") %>" vspace="6" border="0" title="<%#Eval("SkypeText").ToString().Replace("\"","'") %>" height="30" width="145">
            </a><br/>
            <a href="skype:<%#Eval("SkypeID") %>"><%#Eval("SkypeText") %></a>
            <br />
            </ItemTemplate>
        </asp:Repeater>   
        <div style="margin:20px 0; color:#666">
            Số lượt truy cập: <%=Application["So_Nguoi_TruyCap"]%>
            - Online: <%=Application["So_Nguoi_Online"]%>
        </div>

    </div>
    <div class="clear"></div>
</div>

