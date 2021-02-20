using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Informatiz.ControleEstoque.Web
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
             
            }
            catch (Exception ex)
            {

            }
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/CadastroClientes.aspx");
            }
            catch (Exception ex)
            {

            }
        }

        protected void btnCandastrado_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/SouCadastrado.aspx");
            }
            catch (Exception ex)
            {

            }
        }

        protected void btnConsultor_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {

            }
        }

      

    }
}
