<%@ Page Title="" Language="C#" Theme="AutoUpdater" MasterPageFile="~/masters/AUPMaster.master" AutoEventWireup="true" CodeFile="Manage.aspx.cs" Inherits="catalogs_apps_Manage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainPlaceHolder" Runat="Server">
    <asp:FormView ID="AppsFormView" runat="server" DataKeyNames="App_ID" 
        DataSourceID="AppsSQLDS" EnableModelValidation="True">
        <EditItemTemplate>
            App_ID:
            <asp:Label ID="App_IDLabel1" runat="server" Text='<%# Eval("App_ID") %>' />
            <br />
            AppName:
            <asp:TextBox ID="AppNameTextBox" runat="server" Text='<%# Bind("AppName") %>' />
            <br />
            <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" 
                CommandName="Update" Text="Update" />
            &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" 
                CausesValidation="False" CommandName="Cancel" Text="Cancel" />
        </EditItemTemplate>
        <InsertItemTemplate>
            AppName:
            <asp:TextBox ID="AppNameTextBox" runat="server" Text='<%# Bind("AppName") %>' />
            <br />
            <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" 
                CommandName="Insert" Text="Insert" />
            &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" 
                CausesValidation="False" CommandName="Cancel" Text="Cancel" />
        </InsertItemTemplate>
        <ItemTemplate>
            App_ID:
            <asp:Label ID="App_IDLabel" runat="server" Text='<%# Eval("App_ID") %>' />
            <br />
            AppName:
            <asp:Label ID="AppNameLabel" runat="server" Text='<%# Bind("AppName") %>' />
            <br />
            Fecha:
            <asp:Label ID="FechaLabel" runat="server" Text='<%# Bind("Fecha") %>' />
            <br />
            Usuario_ID:
            <asp:Label ID="Usuario_IDLabel" runat="server" 
                Text='<%# Bind("Usuario_ID") %>' />
            <br />
            <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" 
                CommandName="Edit" Text="Edit" />
            &nbsp;<asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" 
                CommandName="Delete" Text="Delete" />
            &nbsp;<asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" 
                CommandName="New" Text="New" />
        </ItemTemplate>
    </asp:FormView>
    <asp:SqlDataSource ID="AppsSQLDS" runat="server" 
        ConnectionString="<%$ ConnectionStrings:SICASDistroConnString %>" 
        DeleteCommand="DELETE FROM [Apps] WHERE [App_ID] = @App_ID" 
        InsertCommand="INSERT INTO [Apps] ([AppName], [Fecha], [Usuario_ID]) VALUES (@AppName, GETDATE(), @Usuario_ID)" 
        SelectCommand="SELECT * FROM [Apps] WHERE ([App_ID] = @App_ID)" 
        UpdateCommand="UPDATE [Apps] SET [AppName] = @AppName, [Fecha] = GETDATE(), [Usuario_ID] = @Usuario_ID WHERE [App_ID] = @App_ID">
        <DeleteParameters>
            <asp:Parameter Name="App_ID" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="AppName" Type="String" />            
            <asp:CookieParameter Name="Usuario_ID" Type="Int32" CookieName="UID" />
        </InsertParameters>
        <SelectParameters>
            <asp:QueryStringParameter Name="App_ID" QueryStringField="App_ID" 
                Type="Int32" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="AppName" Type="String" />                      
            <asp:CookieParameter Name="Usuario_ID" Type="Int32" CookieName="UID" DefaultValue="1" />
            <asp:Parameter Name="App_ID" Type="Int32" />                                    
        </UpdateParameters>
    </asp:SqlDataSource>
</asp:Content>

