<%@ Page Title="" Language="C#" Theme="AutoUpdater" MasterPageFile="~/masters/AUPMaster.master" AutoEventWireup="true" CodeFile="Manage.aspx.cs" Inherits="catalogs_appcontrol_Manage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainPlaceHolder" Runat="Server">
    <asp:FormView ID="AppControlFormView" runat="server" 
        DataKeyNames="AppControl_ID" DataSourceID="AppControlSQLDS" 
        EnableModelValidation="True">
        <EditItemTemplate>
            AppControl_ID:
            <asp:Label ID="AppControl_IDLabel1" runat="server" 
                Text='<%# Eval("AppControl_ID") %>' />
            <br />
            App_ID:
            <asp:TextBox ID="App_IDTextBox" runat="server" Text='<%# Bind("App_ID") %>' />
            <br />
            MainFile:
            <asp:TextBox ID="MainFileTextBox" runat="server" 
                Text='<%# Bind("MainFile") %>' />
            <br />
            CurrentVersion:
            <asp:TextBox ID="CurrentVersionTextBox" runat="server" 
                Text='<%# Bind("CurrentVersion") %>' />
            <br />
            Descripcion:
            <asp:TextBox ID="DescripcionTextBox" runat="server" 
                Text='<%# Bind("Descripcion") %>' />
            <br />
            ImageUrl:
            <asp:TextBox ID="ImageUrlTextBox" runat="server" 
                Text='<%# Bind("ImageUrl") %>' />
            <br />
            PackageLocation:
            <asp:TextBox ID="PackageLocationTextBox" runat="server" 
                Text='<%# Bind("PackageLocation") %>' />
            <br />
            Comments:
            <asp:TextBox ID="CommentsTextBox" runat="server" 
                Text='<%# Bind("Comments") %>' />
            <br />
            <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" 
                CommandName="Update" Text="Update" />
            &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" 
                CausesValidation="False" CommandName="Cancel" Text="Cancel" />
        </EditItemTemplate>
        <InsertItemTemplate>
            App_ID:
            <asp:TextBox ID="App_IDTextBox" runat="server" Text='<%# Bind("App_ID") %>' />
            <br />
            MainFile:
            <asp:TextBox ID="MainFileTextBox" runat="server" 
                Text='<%# Bind("MainFile") %>' />
            <br />
            CurrentVersion:
            <asp:TextBox ID="CurrentVersionTextBox" runat="server" 
                Text='<%# Bind("CurrentVersion") %>' />
            <br />
            Descripcion:
            <asp:TextBox ID="DescripcionTextBox" runat="server" 
                Text='<%# Bind("Descripcion") %>' />
            <br />
            ImageUrl:
            <asp:TextBox ID="ImageUrlTextBox" runat="server" 
                Text='<%# Bind("ImageUrl") %>' />
            <br />
            PackageLocation:
            <asp:TextBox ID="PackageLocationTextBox" runat="server" 
                Text='<%# Bind("PackageLocation") %>' />
            <br />
            Comments:
            <asp:TextBox ID="CommentsTextBox" runat="server" 
                Text='<%# Bind("Comments") %>' />
            <br />
            <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" 
                CommandName="Insert" Text="Insert" />
            &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" 
                CausesValidation="False" CommandName="Cancel" Text="Cancel" />
        </InsertItemTemplate>
        <ItemTemplate>
            AppControl_ID:
            <asp:Label ID="AppControl_IDLabel" runat="server" 
                Text='<%# Eval("AppControl_ID") %>' />
            <br />
            App_ID:
            <asp:Label ID="App_IDLabel" runat="server" Text='<%# Bind("App_ID") %>' />
            <br />
            MainFile:
            <asp:Label ID="MainFileLabel" runat="server" Text='<%# Bind("MainFile") %>' />
            <br />
            CurrentVersion:
            <asp:Label ID="CurrentVersionLabel" runat="server" 
                Text='<%# Bind("CurrentVersion") %>' />
            <br />
            Descripcion:
            <asp:Label ID="DescripcionLabel" runat="server" 
                Text='<%# Bind("Descripcion") %>' />
            <br />
            ImageUrl:
            <asp:Label ID="ImageUrlLabel" runat="server" Text='<%# Bind("ImageUrl") %>' />
            <br />
            PackageLocation:
            <asp:Label ID="PackageLocationLabel" runat="server" 
                Text='<%# Bind("PackageLocation") %>' />
            <br />
            Comments:
            <asp:Label ID="CommentsLabel" runat="server" Text='<%# Bind("Comments") %>' />
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
    <asp:SqlDataSource ID="AppControlSQLDS" runat="server" 
        ConnectionString="<%$ ConnectionStrings:SICASDistroConnString %>" 
        DeleteCommand="DELETE FROM [AppControl] WHERE [AppControl_ID] = @AppControl_ID" 
        InsertCommand="INSERT INTO [AppControl] ([App_ID], [MainFile], [CurrentVersion], [Descripcion], [ImageUrl], [PackageLocation], [Comments], [Usuario_ID]) VALUES (@App_ID, @MainFile, @CurrentVersion, @Descripcion, @ImageUrl, @PackageLocation, @Comments, @Usuario_ID)" 
        SelectCommand="SELECT * FROM [AppControl] WHERE ([AppControl_ID] = @AppControl_ID)" 
        UpdateCommand="UPDATE [AppControl] SET [App_ID] = @App_ID, [MainFile] = @MainFile, [CurrentVersion] = @CurrentVersion, [Descripcion] = @Descripcion, [ImageUrl] = @ImageUrl, [PackageLocation] = @PackageLocation, [Comments] = @Comments, [Usuario_ID] = @Usuario_ID WHERE [AppControl_ID] = @AppControl_ID">
        <DeleteParameters>
            <asp:Parameter Name="AppControl_ID" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="App_ID" Type="Int32" />
            <asp:Parameter Name="MainFile" Type="String" />
            <asp:Parameter Name="CurrentVersion" Type="String" />
            <asp:Parameter Name="Descripcion" Type="String" />
            <asp:Parameter Name="ImageUrl" Type="String" />
            <asp:Parameter Name="PackageLocation" Type="String" />
            <asp:Parameter Name="Comments" Type="String" />
            <asp:CookieParameter Name="Usuario_ID" Type="Int32" CookieName="UID" />
        </InsertParameters>
        <SelectParameters>
            <asp:QueryStringParameter Name="AppControl_ID" QueryStringField="AppControl_ID" 
                Type="Int32" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="App_ID" Type="Int32" />
            <asp:Parameter Name="MainFile" Type="String" />
            <asp:Parameter Name="CurrentVersion" Type="String" />
            <asp:Parameter Name="Descripcion" Type="String" />
            <asp:Parameter Name="ImageUrl" Type="String" />
            <asp:Parameter Name="PackageLocation" Type="String" />
            <asp:Parameter Name="Comments" Type="String" />
            <asp:CookieParameter Name="Usuario_ID" Type="Int32" CookieName="UID" DefaultValue="1" />
            <asp:Parameter Name="AppControl_ID" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
</asp:Content>

