using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Informatiz.ControleEstoque.ContratoServico.InserirEmpresa
{
    [Serializable]
    [XmlType(Namespace = "urn:InserirEmpresa")]
    [XmlRoot(Namespace = "urn:InserirEmpresa")]
    public class Peticao : PeticaoGenerico
    {

        public string DescricaoEmpresa;
        public string Usuario;
        public string NomeUsuario;
        public string Senha;
        public Int32 Numero;
        public Int32 CEP;
        public string TelefoneFixo;
        public string TelefoneCelular;
        public string Email;
        public string DescricaoBairro;
        public string Logradouro;
        public Comum.Clases.Cidade objCidade;
        public Comum.Clases.Estado objEstado;
        public Comum.Clases.Estado objEndereco;
        public string IdentificadorPublicidade;
        public string IdentificadorConsultor;
        public string DescricaoIndicacao;

    }
}
