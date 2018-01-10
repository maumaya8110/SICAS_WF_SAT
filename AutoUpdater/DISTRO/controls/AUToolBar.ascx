<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AUToolBar.ascx.cs" Inherits="controls_AUToolBar" %>

<asp:Panel ID="ToolBarPanel" CssClass="toolBar" runat="server">
    <div style="text-align:left">        
        
        <asp:HyperLink ID="HomeHyperLink" runat="server" ImageUrl="home.png" 
            ToolTip="Home" NavigateUrl="">
        </asp:HyperLink>
        |
        <asp:HyperLink ID="NewHyperLink" runat="server" ImageUrl="new.png" 
            ToolTip="Nuevo" NavigateUrl="">
        </asp:HyperLink>

    </div>
</asp:Panel>