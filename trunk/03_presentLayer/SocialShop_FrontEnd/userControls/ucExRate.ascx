<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucExRate.ascx.cs" Inherits="userControls_ucExRate" %>
 <div class="box clear" style="border:none; background-color:#FFF; margin-top:10px" id="divExRate" runat="server">
     <div class="title" style="margin-bottom:0;">
         <span><a>Tỷ giá ngoại tệ</a></span>
      </div>
      <div style="border:solid 1px #459B30;">
     <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CssClass="tb_tygia">
         <Columns>
             <asp:TemplateField HeaderText="Đơn vị"  ItemStyle-CssClass="item_tygia1" HeaderStyle-CssClass="item_head"  ItemStyle-Width="100" >
                 <ItemTemplate>
                     <%#Eval("CurrencyCode")%>
                 </ItemTemplate>
             </asp:TemplateField>
             <asp:TemplateField HeaderText="Mua (VNĐ)" ItemStyle-Width="100" HeaderStyle-CssClass="item_head" ItemStyle-CssClass="item_tygia" >
                 <ItemTemplate>
                     <%#Eval("Buy")%>
                 </ItemTemplate>
             </asp:TemplateField>
             <asp:TemplateField HeaderText="Bán (VNĐ)" ItemStyle-Width="100" ItemStyle-CssClass="item_tygia" HeaderStyle-CssClass="item_head" >
                 <ItemTemplate>
                     <%#Eval("Sell")%>
                 </ItemTemplate>
             </asp:TemplateField>
         </Columns>
     </asp:GridView>
     </div>
     <div class="clear">
     </div>
 </div>     