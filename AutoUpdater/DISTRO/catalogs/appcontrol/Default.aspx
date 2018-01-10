<%@ Page Title="" Language="C#" Theme="AutoUpdater" MasterPageFile="~/masters/AUPMaster.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="catalogs_appcontrol_Default" %>

<%@ Register src="../../controls/AUToolBar.ascx" tagname="AUToolBar" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainPlaceHolder" Runat="Server">

    <!-- ToolBar -->
    <uc1:AUToolBar ID="AUToolBar1" runat="server" NewNavigateUrl="Manage.aspx?Mode=Create" />
    <br />
    <!-- Tabla de control de aplicaciones -->     
    <asp:GridView ID="AppControlGridView" runat="server" 
            AutoGenerateColumns="False" DataKeyNames="AppControl_ID" 
            DataSourceID="AppControlSQLDS" EnableModelValidation="True">
            <Columns>
                
                <asp:TemplateField HeaderText="">
                    <ItemTemplate>
                        <a href="Manage.aspx?Mode=Update&AppControl_ID=<%# Eval("AppControl_ID") %>">
                            <img alt="Modificar" src="<%=ConfigurationManager.AppSettings["ImagePath"] %>edit.png" />
                        </a>
                    </ItemTemplate>
                </asp:TemplateField>
                    
                <asp:TemplateField HeaderText="">
                    <ItemTemplate>
                        <a href="Manage.aspx?Mode=Delete&AppControl_ID=<%# Eval("AppControl_ID") %>">
                            <img alt="Eliminar" src="<%=ConfigurationManager.AppSettings["ImagePath"] %>delete.png" />
                        </a>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:BoundField DataField="AppControl_ID" HeaderText="AppControl_ID" 
                    InsertVisible="False" ReadOnly="True" SortExpression="AppControl_ID" />
                <asp:BoundField DataField="App_ID" HeaderText="App_ID" 
                    SortExpression="App_ID" />
                <asp:BoundField DataField="AppName" HeaderText="AppName" 
                    SortExpression="AppName" />
                <asp:BoundField DataField="MainFile" HeaderText="MainFile" 
                    SortExpression="MainFile" />
                <asp:BoundField DataField="CurrentVersion" HeaderText="CurrentVersion" 
                    SortExpression="CurrentVersion" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" 
                    SortExpression="Descripcion" />
                <asp:BoundField DataField="ImageUrl" HeaderText="ImageUrl" 
                    SortExpression="ImageUrl" />
                <asp:BoundField DataField="PackageLocation" HeaderText="PackageLocation" 
                    SortExpression="PackageLocation" />
                <asp:BoundField DataField="Comments" HeaderText="Comments" 
                    SortExpression="Comments" />
                <asp:BoundField DataField="Usuario" HeaderText="Usuario" ReadOnly="True" 
                    SortExpression="Usuario" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="AppControlSQLDS" runat="server" 
            ConnectionString="<%$ ConnectionStrings:SICASDistroConnString %>" SelectCommand="SELECT	AC.AppControl_ID, AC.App_ID, A.AppName,
		            AC.MainFile, AC.CurrentVersion, AC.Descripcion,
		            AC.ImageUrl, AC.PackageLocation, AC.Comments,
		            (U.Nombre + ' ' + U.Apellidos) Usuario
            FROM	AppControl AC
            INNER JOIN	Apps A
            ON		AC.App_ID = A.App_ID
            INNER JOIN	Usuarios U
            ON		AC.Usuario_ID = U.Usuario_ID"></asp:SqlDataSource>

</asp:Content>

