using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Diagnostics;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Serialization;
using System.Configuration;



namespace Informatiz.ControleEstoque.Comunicacao
{

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.1433"),
    System.ComponentModel.DesignerCategoryAttribute("code"),
    System.Web.Services.WebServiceBindingAttribute(Name = "InformatizSoap", Namespace = "http://Informatiz.ControleEstoque")]
    public class Proxy : System.Web.Services.Protocols.SoapHttpClientProtocol
    {

        private Boolean useDefaultCredentialsSetExplicitly;

        public Proxy()
        {
            base.Url = ConfigurationManager.AppSettings["UrlServico"] + "CE.asmx";
            this.useDefaultCredentialsSetExplicitly = true;
        }

        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://Informatiz.ControleEstoque/ValidarChave", RequestNamespace = "http://Informatiz.ControleEstoque", ResponseNamespace = "http://Informatiz.ControleEstoque", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public ContratoServico.ValidarChave.Respuesta ValidarChave(ContratoServico.ValidarChave.Peticao Peticao)
        {
            object[] results = this.Invoke("ValidarChave", new object[] { Peticao });
            return (ContratoServico.ValidarChave.Respuesta)results[0];
        }

        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://Informatiz.ControleEstoque/GerarChave", RequestNamespace = "http://Informatiz.ControleEstoque", ResponseNamespace = "http://Informatiz.ControleEstoque", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public ContratoServico.GerarChave.Respuesta GerarChave(ContratoServico.GerarChave.Peticao Peticao)
        {
            object[] results = this.Invoke("GerarChave", new object[] { Peticao });
            return (ContratoServico.GerarChave.Respuesta)results[0];
        }

        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://Informatiz.ControleEstoque/AtivarChave", RequestNamespace = "http://Informatiz.ControleEstoque", ResponseNamespace = "http://Informatiz.ControleEstoque", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public ContratoServico.AtivarChave.Respuesta AtivarChave(ContratoServico.AtivarChave.Peticao Peticao)
        {
            object[] results = this.Invoke("AtivarChave", new object[] { Peticao });
            return (ContratoServico.AtivarChave.Respuesta)results[0];
        }
               
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://Informatiz.ControleEstoque/InserirEmpresa", RequestNamespace = "http://Informatiz.ControleEstoque", ResponseNamespace = "http://Informatiz.ControleEstoque", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public ContratoServico.InserirEmpresa.Respuesta InserirEmpresa(ContratoServico.InserirEmpresa.Peticao Peticao)
        {
            object[] results = this.Invoke("InserirEmpresa", new object[] { Peticao });
            return (ContratoServico.InserirEmpresa.Respuesta)results[0];
        }

        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://Informatiz.ControleEstoque/ValidarUsuario", RequestNamespace = "http://Informatiz.ControleEstoque", ResponseNamespace = "http://Informatiz.ControleEstoque", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public ContratoServico.ValidarUsuario.Respuesta ValidarUsuario(ContratoServico.ValidarUsuario.Peticao Peticao)
        {
            object[] results = this.Invoke("ValidarUsuario", new object[] { Peticao });
            return (ContratoServico.ValidarUsuario.Respuesta)results[0];
        }

        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://Informatiz.ControleEstoque/RecuperarImagem", RequestNamespace = "http://Informatiz.ControleEstoque", ResponseNamespace = "http://Informatiz.ControleEstoque", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public ContratoServico.RecuperarImagem.Resposta RecuperarImagem(ContratoServico.RecuperarImagem.Peticao Peticao)
        {
            object[] results = this.Invoke("RecuperarImagem", new object[] { Peticao });
            return (ContratoServico.RecuperarImagem.Resposta)results[0];
        }

        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://Informatiz.ControleEstoque/RecuperarVersao", RequestNamespace = "http://Informatiz.ControleEstoque", ResponseNamespace = "http://Informatiz.ControleEstoque", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public ContratoServico.RecuperarVersao.Resposta RecuperarVersao(ContratoServico.RecuperarVersao.Peticao Peticao)
        {
            object[] results = this.Invoke("RecuperarVersao", new object[] { Peticao });
            return (ContratoServico.RecuperarVersao.Resposta)results[0];
        }

     
    }
}
