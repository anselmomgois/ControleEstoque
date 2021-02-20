using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Informatiz.ControleEstoque.Web
{
    public partial class SouCadastrado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtUsuarioExistente.Focus();
        }

        protected void btnProseguir_Click(object sender, EventArgs e)
        {
            try
            {

                System.Text.StringBuilder objErros = new System.Text.StringBuilder();

                if (string.IsNullOrEmpty(txtUsuarioExistente.Text.Trim()))
                {
                    objErros.AppendLine("Usuário é obrigatório. </br>");
                }

                if (objErros.Length > 0)
                {
                    throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, objErros.ToString());
                }

                ContratoServico.ValidarUsuario.Peticao objPeticao = new ContratoServico.ValidarUsuario.Peticao();
                ContratoServico.ValidarUsuario.Respuesta objRespuesta = null;
                LogicaNegocio.Servico.Empresa objAcao = new LogicaNegocio.Servico.Empresa();

                objPeticao.Usuario = txtUsuarioExistente.Text.Trim();

                objRespuesta = objAcao.ValidarUsuario(objPeticao);

                if (objRespuesta != null && objRespuesta.CodigoErro != Convert.ToInt32(Execao.Constantes.CodigoErro.SEM_ERRO))
                {
                    throw new Execao.ExecaoNegocio((Execao.Constantes.CodigoErro)(objRespuesta.CodigoErro), objRespuesta.DescricaoErro);
                }

                if (!objRespuesta.UsuarioOK)
                {
                    throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "Usuário invalido");
                }

                Session["Identificador"] = "OK";

                Response.Redirect("~/Download.aspx");

            }
            catch (Execao.ExecaoNegocio ex)
            {
                lblError.Text = ex.Descricao;
                DivError.Visible = true;
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                DivError.Visible = true;
            }
        }
    }
}