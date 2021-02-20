using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Informatiz.ControleEstoque.Web
{
    public partial class Download : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if(string.IsNullOrEmpty(Session["Identificador"] as string))
            {
                Response.Redirect("/Default.aspx");
            }
        }
    }
}