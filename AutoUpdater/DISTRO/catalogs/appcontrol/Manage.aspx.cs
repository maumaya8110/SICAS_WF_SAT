using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class catalogs_appcontrol_Manage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        WebHelper.RedirectUrl = "Default.aspx";
        WebHelper.SetFormViewMethods(this.AppControlFormView);
    }
}