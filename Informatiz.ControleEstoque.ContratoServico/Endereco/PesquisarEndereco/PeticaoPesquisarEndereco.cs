using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.Endereco.PesquisarEndereco
{
     public class PeticaoPesquisarEndereco : PeticaoGenerico
    {

        public Nullable<int> Codigo { get; set; }
        public string IdentificadorBairro { get; set; }
        public string Identificador { get; set; }
        public string Cep { get; set; }
        public string Rua { get; set; }
    }
}
