using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class catalogs_apps_Manage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        WebHelper.RedirectUrl = "Default.aspx";
        WebHelper.SetFormViewMethods(this.AppsFormView);

        //LinkButton lbtn;
        //lbtn = (LinkButton)this.AppsFormView.FindControl("UpdateButton");
        //lbtn.Text = WebHelper.ResolveUrlImage("save.png", true);
        foreach (Control c in this.AppsFormView.Controls)
        {
            Response.Write(c.ID + "<br />");
        }
    }
}