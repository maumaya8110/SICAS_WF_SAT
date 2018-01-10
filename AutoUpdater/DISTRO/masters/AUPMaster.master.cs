using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class masters_AUPMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        HttpCookie cook = new HttpCookie("UID", "1");
        cook.Expires = DateTime.Now.AddDays(1);
        this.Response.SetCookie(cook);
    }
}
