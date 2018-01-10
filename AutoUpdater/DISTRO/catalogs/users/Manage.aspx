<%@ Page Title="" Language="C#" Theme="AutoUpdater" MasterPageFile="~/masters/AUPMaster.master" AutoEventWireup="true" CodeFile="Manage.aspx.cs" Inherits="catalogs_users_Manage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainPlaceHolder" Runat="Server">
    <asp:FormView ID="UsuariosFormView" runat="server" DataKeyNames="Usuario_ID" 
        DataSourceID="UsuariosSQLDS" EnableModelValidation="True">
        <EditItemTemplate>
            Usuario_ID:
            <asp:Label ID="Usuario_IDLabel1" runat="server" 
                Text='<%# Eval("Usuario_ID") %>' />
            <br />
            UserName:
            <asp:TextBox ID="UserNameTextBox" runat="server" 
                Text='<%# Bind("UserName") %>' />
            <br />
            Nombre:
            <asp:TextBox ID="NombreTextBox" runat="server" Text='<%# Bind("Nombre") %>' />
            <br />
            Apellidos:
            <asp:TextBox ID="ApellidosTextBox" runat="server" 
                Text='<%# Bind("Apellidos") %>' />
            <br />
            Email:
            <asp:TextBox ID="EmailTextBox" runat="server" Text='<%# Bind("Email") %>' />
            <br />
            <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" 
                CommandName="Update" Text="Update" />
            &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" 
                CausesValidation="False" CommandName="Cancel" Text="Cancel" />
        </EditItemTemplate>
        <InsertItemTemplate>
            UserName:
            <asp:TextBox ID="UserNameTextBox" runat="server" 
                Text='<%# Bind("UserName") %>' />
            <br />
            Nombre:
            <asp:TextBox ID="NombreTextBox" runat="server" Text='<%# Bind("Nombre") %>' />
            <br />
            Apellidos:
            <asp:TextBox ID="ApellidosTextBox" runat="server" 
                Text='<%# Bind("Apellidos") %>' />
            <br />
            Email:
            <asp:TextBox ID="EmailTextBox" runat="server" Text='<%# Bind("Email") %>' />
            <br />
            Pwd:
            <asp:TextBox ID="PwdTextBox" TextMode="Password" runat="server" Text='<%# Bind("Pwd") %>' />
            <br />
            <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" 
                CommandName="Insert" Text="Insert" />
            &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" 
                CausesValidation="False" CommandName="Cancel" Text="Cancel" />
        </InsertItemTemplate>
        <ItemTemplate>
            Usuario_ID:
            <asp:Label ID="Usuario_IDLabel" runat="server" 
                Text='<%# Eval("Usuario_ID") %>' />
            <br />
            UserName:
            <asp:Label ID="UserNameLabel" runat="server" Text='<%# Bind("UserName") %>' />
            <br />
            Nombre:
            <asp:Label ID="NombreLabel" runat="server" Text='<%# Bind("Nombre") %>' />
            <br />
            Apellidos:
            <asp:Label ID="ApellidosLabel" runat="server" Text='<%# Bind("Apellidos") %>' />
            <br />
            Email:
            <asp:Label ID="EmailLabel" runat="server" Text='<%# Bind("Email") %>' />
            <br />
            <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" 
                CommandName="Edit" Text="Edit" />
            &nbsp;<asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" 
                CommandName="Delete" Text="Delete" />
            &nbsp;<asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" 
                CommandName="New" Text="New" />
        </ItemTemplate>
    </asp:FormView>
    <asp:SqlDataSource ID="UsuariosSQLDS" runat="server" 
        ConnectionString="<%$ ConnectionStrings:SICASDistroConnString %>" 
        DeleteCommand="DELETE FROM [Usuarios] WHERE [Usuario_ID] = @Usuario_ID" 
        InsertCommand="INSERT INTO [Usuarios] ([UserName], [Nombre], [Apellidos], [Email], [Pwd]) VALUES (@UserName, @Nombre, @Apellidos, @Email, @Pwd)" 
        SelectCommand="SELECT * FROM [Usuarios] WHERE ([Usuario_ID] = @Usuario_ID)" 
        UpdateCommand="UPDATE [Usuarios] SET [UserName] = @UserName, [Nombre] = @Nombre, [Apellidos] = @Apellidos, [Email] = @Email WHERE [Usuario_ID] = @Usuario_ID">
        <DeleteParameters>
            <asp:Parameter Name="Usuario_ID" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="UserName" Type="String" />
            <asp:Parameter Name="Nombre" Type="String" />
            <asp:Parameter Name="Apellidos" Type="String" />
            <asp:Parameter Name="Email" Type="String" />
            <asp:Parameter Name="Pwd" Type="Object" />
        </InsertParameters>
        <SelectParameters>
            <asp:QueryStringParameter Name="Usuario_ID" QueryStringField="Usuario_ID" 
                Type="Int32" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="UserName" Type="String" />
            <asp:Parameter Name="Nombre" Type="String" />
            <asp:Parameter Name="Apellidos" Type="String" />
            <asp:Parameter Name="Email" Type="String" />
            <asp:Parameter Name="Pwd" Type="Object" />
            <asp:Parameter Name="Usuario_ID" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
</asp:Content>

