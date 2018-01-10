<%@ Page Title="" Language="C#" Theme="AutoUpdater" MasterPageFile="~/masters/AUPMaster.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="catalogs_users_Default" %>

<%@ Register src="../../controls/AUToolBar.ascx" tagname="AUToolBar" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainPlaceHolder" Runat="Server">

    <!-- ToolBar -->
    <uc1:AUToolBar ID="AUToolBar1" runat="server" NewNavigateUrl="Manage.aspx?Mode=Create" />
    <br />
    <!-- Tabla de usuarios --> 
    <asp:GridView ID="UsuariosGridView" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="Usuario_ID" DataSourceID="UsuariosSQLDS" 
        EnableModelValidation="True">
        <Columns>
            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <a href="Manage.aspx?Mode=Update&Usuario_ID=<%# Eval("Usuario_ID") %>">
                        <img alt="Modificar" src="<%=ConfigurationManager.AppSettings["ImagePath"] %>edit.png" />
                    </a>
                </ItemTemplate>
            </asp:TemplateField>
                    
            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <a href="Manage.aspx?Mode=Delete&Usuario_ID=<%# Eval("Usuario_ID") %>">
                        <img alt="Eliminar" src="<%=ConfigurationManager.AppSettings["ImagePath"] %>delete.png" />
                    </a>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:BoundField DataField="Usuario_ID" HeaderText="Usuario_ID" 
                InsertVisible="False" ReadOnly="True" SortExpression="Usuario_ID" />
            <asp:BoundField DataField="UserName" HeaderText="UserName" 
                SortExpression="UserName" />
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" 
                SortExpression="Nombre" />
            <asp:BoundField DataField="Apellidos" HeaderText="Apellidos" 
                SortExpression="Apellidos" />
            <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="UsuariosSQLDS" runat="server" 
        ConnectionString="<%$ ConnectionStrings:SICASDistroConnString %>" 
        SelectCommand="SELECT * FROM [Usuarios]"></asp:SqlDataSource>
</asp:Content>

