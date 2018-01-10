using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;
using System.Configuration;

public partial class controls_AUToolBar : System.Web.UI.UserControl
{ 

    private bool _ShowToolBar = true;
    public bool ShowToolBar
    {
        get { return _ShowToolBar; }
        set { _ShowToolBar = true; }
    }

    private string _NewNavigateUrl;
    public string NewNavigateUrl
    {
        get { return _NewNavigateUrl; }
        set { _NewNavigateUrl = value; }
    }

    private string _QueryStringFields;
    public string QueryStringFields
    {
        get { return _QueryStringFields; }
        set { _QueryStringFields = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        HomeHyperLink.NavigateUrl = 
            ConfigurationManager.AppSettings["SiteName"].ToString() + "/Home.aspx";
        ResolveImagesUrl();

        if (ShowToolBar)
        {
            this.ToolBarPanel.Visible = true;
        }
        else
        {
            this.ToolBarPanel.Visible = false;
        }

        AssignQueryStringFields();
    } // void Page_Load

    private void ResolveImagesUrl()
    {
        foreach (Control ctrl in this.ToolBarPanel.Controls)
        {
            if (ctrl.GetType() == typeof(HyperLink))
            {
                HyperLink link = (HyperLink)ctrl;
                link.ImageUrl = WebHelper.ResolveUrlImage(link.ImageUrl);
            }            
        }   //  foreach
    }   //  method

    private void AssignQueryStringFields()
    {
        // ignorar si no se asigno ruta
        if (!String.IsNullOrEmpty(NewNavigateUrl))
        {
            // verificar si se asignaron parametros
            if (!String.IsNullOrEmpty(QueryStringFields))
            {
                // pasar cada ids. de los campos "Query String",
                // a un arreglo, por separado
                String[] qsFieldNames = QueryStringFields.Split(new Char[] { ',' });

                // declarar coleccion para los valores de los campos
                StringCollection collFieldValues = new StringCollection();

                foreach (string qsFieldName in qsFieldNames)
                {
                    // validar que nos envien esto "x,,y"
                    if (!String.IsNullOrEmpty(qsFieldName))
                    {
                        // validar que exista el campo
                        String eachValue = Request.QueryString[qsFieldName];
                        if (String.IsNullOrEmpty(eachValue))
                        {
                            eachValue = "";
                        }
                        // agregar valor a arreglo
                        collFieldValues.Add(eachValue);
                    }
                } // foreach

                // copiar de lista a arreglo, porque requerimos un arreglo,
                // para String.Format
                String[] qsFieldValues = new String[collFieldValues.Count];
                collFieldValues.CopyTo(qsFieldValues, 0);

                // ahora si, aplicar parametros
                String parametrizedURL = String.Format(NewNavigateUrl, qsFieldValues);
                NewHyperLink.NavigateUrl = Page.ResolveUrl(parametrizedURL);
            }
            else
            {
                // no hay parametros, se asigna U.R.L. tal cual
                NewHyperLink.NavigateUrl = Page.ResolveUrl(NewNavigateUrl);
            }
        } // if (NewNavigateUrl != "")
    } // void AssignQueryStringFields
}   //  End Class