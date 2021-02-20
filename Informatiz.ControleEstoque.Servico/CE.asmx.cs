using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Informatiz.ControleEstoque.Servico
{
    /// <summary>
    /// Summary description for CE
    /// </summary>
    [WebService(Namespace = "http://Informatiz.ControleEstoque")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class CE : System.Web.Services.WebService
    {

        [WebMethod]
        public ContratoServico.ValidarChave.Respuesta ValidarChave(ContratoServico.ValidarChave.Peticao Peticao)
        {

            LogicaNegocio.Servico.Chave objAcao = new LogicaNegocio.Servico.Chave();

            return objAcao.ValidarChaveSistema(Peticao);
        }

        [WebMethod]
        public ContratoServico.GerarChave.Respuesta GerarChave(ContratoServico.GerarChave.Peticao Peticao)
        {


            return LogicaNegocio.Servico.Chave.GerarChave(Peticao);
        }

        [WebMethod]
        public ContratoServico.AtivarChave.Respuesta AtivarChave(ContratoServico.AtivarChave.Peticao Peticao)
        {

            LogicaNegocio.Servico.Chave objAcao = new LogicaNegocio.Servico.Chave();

            return objAcao.AtivarChave(Peticao);
        }

        [WebMethod]
        public ContratoServico.InserirEmpresa.Respuesta InserirEmpresa(ContratoServico.InserirEmpresa.Peticao Peticao)
        {

            LogicaNegocio.Servico.Empresa objAcao = new LogicaNegocio.Servico.Empresa();

            return objAcao.InserirEmpresa(Peticao);
        }

        [WebMethod]
        public ContratoServico.ValidarUsuario.Respuesta ValidarUsuario(ContratoServico.ValidarUsuario.Peticao Peticao)
        {

            LogicaNegocio.Servico.Empresa objAcao = new LogicaNegocio.Servico.Empresa();

            return objAcao.ValidarUsuario(Peticao);
        }

        [WebMethod]
        public ContratoServico.RecuperarImagem.Resposta RecuperarImagem(ContratoServico.RecuperarImagem.Peticao Peticao)
        {

            
            return LogicaNegocio.Servico.Imagem.RecuperarImagem(Peticao.Usuario);
        }

        [WebMethod]
        public ContratoServico.RecuperarVersao.Resposta RecuperarVersao(ContratoServico.RecuperarVersao.Peticao Peticao)
        {


            return LogicaNegocio.Servico.Versao.RecuperarVersao(Peticao.Usuario);
        }

       
    }
}
