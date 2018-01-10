using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using AutoUpDSTableAdapters;
using System.Data;

/// <summary>
/// Summary description for AutoUpWS
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class AutoUpWS : System.Web.Services.WebService {

    public AutoUpWS () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string CurrentVersion(int appID, string user, string pwd)
    {        
        CurrentVersionTableAdapter current = new CurrentVersionTableAdapter();        
        return Convert.ToString(
            ((DataTable)current.GetData(appID, user, pwd)).Rows[0]["CurrentVersion"]);
    }

    [WebMethod]
    public DataSet AppInfo(int appID, string version, string user, string pwd)
    {
        AutoUpDS ds = new AutoUpDS();        
        AppInfoTableAdapter appInfo = new AppInfoTableAdapter();
        appInfo.Fill(ds.AppInfo, appID, version, user, pwd);

        return ds;
    }
    
}
