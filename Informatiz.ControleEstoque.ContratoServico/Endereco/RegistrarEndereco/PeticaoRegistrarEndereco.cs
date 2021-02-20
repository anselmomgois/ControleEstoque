using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.Endereco.RegistrarEndereco
{
     public class PeticaoRegistrarEndereco : PeticaoGenerico
    {

       public string Cep { get; set; }
       public string IdentificadorEstado { get; set; }
        public    string IdentificadorCidade { get; set; }
        public string IdentificadorBairro { get; set; }
        public string Rua { get; set; }
        public string RuaPesquisar { get; set; }
        public string IdentificadorEndereco { get; set; }
    }
}
