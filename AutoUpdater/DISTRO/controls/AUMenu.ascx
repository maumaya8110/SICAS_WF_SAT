<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AUMenu.ascx.cs" Inherits="controls_AUMenu" %>

<table class="menuBar">
    <tr>
        <td>
            <a href='<%=ConfigurationManager.AppSettings["SiteName"].ToString() %>/Home.aspx'>
                <img alt="" src="<%=ConfigurationManager.AppSettings["ImagePath"] %>home.png" />
                <br />
                Inicio
            </a>
        </td>
        <td>
            <a href='<%=ConfigurationManager.AppSettings["SiteName"].ToString() %>/catalogs/apps/'>
                <img alt="" src="<%=ConfigurationManager.AppSettings["ImagePath"] %>openapp.png" />
                <br />
                Aplicaciones
            </a>
        </td>
        <td>
            <a href='<%=ConfigurationManager.AppSettings["SiteName"].ToString() %>/catalogs/users/'>
                <img alt="" src="<%=ConfigurationManager.AppSettings["ImagePath"] %>users.png" />
                <br />
                Usuarios
            </a>    
        </td>
        <td>
            <a href='<%=ConfigurationManager.AppSettings["SiteName"].ToString() %>/estadisticas/'>
                <img alt="" src="<%=ConfigurationManager.AppSettings["ImagePath"] %>stats.png" />
                <br />
                Estadísticas
            </a>
        </td>
        <td>
            <a href='<%=ConfigurationManager.AppSettings["SiteName"].ToString() %>/admin/'>
                <img alt="" src="<%=ConfigurationManager.AppSettings["ImagePath"] %>settings.png" />
                <br />
                Administración
            </a>
        </td>
        <td>
            <a href='<%=ConfigurationManager.AppSettings["SiteName"].ToString() %>/about/'>
                <img alt="" src="<%=ConfigurationManager.AppSettings["ImagePath"] %>prosyss.png" />
                <br />
                Prosyss
            </a>            
        </td>
    </tr>
</table>