<%@ Page Title="" Language="C#" Theme="AutoUpdater" MasterPageFile="~/masters/AUPMaster.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="catalogs_apps_Default" %>

<%@ Register src="../../controls/AUToolBar.ascx" tagname="AUToolBar" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainPlaceHolder" Runat="Server">

    <!-- ToolBar -->
    <uc1:AUToolBar ID="AUToolBar1" runat="server" NewNavigateUrl="Manage.aspx?Mode=Create" />
    <br />
    <!-- Tabla de aplicaciones -->    
    <asp:GridView ID="AppsGridView" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="App_ID" DataSourceID="AppsSQLDS" EnableModelValidation="True">        
        <Columns>            
            
            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <a href="Manage.aspx?Mode=Update&App_ID=<%# Eval("App_ID") %>">
                        <img alt="Modificar" src="<%=ConfigurationManager.AppSettings["ImagePath"] %>edit.png" />
                    </a>
                </ItemTemplate>
            </asp:TemplateField>
                    
            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <a href="Manage.aspx?Mode=Delete&App_ID=<%# Eval("App_ID") %>">
                        <img alt="Eliminar" src="<%=ConfigurationManager.AppSettings["ImagePath"] %>delete.png" />
                    </a>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <a href="../appcontrol/?App_ID=<%# Eval("App_ID") %>">
                        <img alt="Control de versiones" src="<%=ConfigurationManager.AppSettings["ImagePath"] %>newapp.png" />
                    </a>
                </ItemTemplate>
            </asp:TemplateField>
                    
            <asp:BoundField DataField="App_ID" HeaderText="App_ID" InsertVisible="False" 
                ReadOnly="True" SortExpression="App_ID" />
            <asp:BoundField DataField="AppName" HeaderText="AppName" 
                SortExpression="AppName" />
            <asp:BoundField DataField="Fecha" HeaderText="Fecha" SortExpression="Fecha" />
            <asp:BoundField DataField="Usuario" HeaderText="Usuario" ReadOnly="True" 
                SortExpression="Usuario" />
        </Columns>
    </asp:GridView>

    <!-- SQL DataSource -->
    <asp:SqlDataSource ID="AppsSQLDS" runat="server" 
        ConnectionString="<%$ ConnectionStrings:SICASDistroConnString %>" 
        SelectCommand="SELECT A.App_ID, A.AppName, A.Fecha, (U.Nombre + ' ' + U.Apellidos) Usuario
        FROM Apps A
        INNER JOIN Usuarios U
        ON A.Usuario_ID = U.Usuario_ID"></asp:SqlDataSource>

</asp:Content>

