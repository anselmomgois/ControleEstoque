using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.Endereco.RecuperarBairro
{
     public class PeticaoRecuperarBairro : PeticaoGenerico
    {

        public Nullable<int> Codigo { get; set; }
        public string Nome { get; set; }
        public string IdentificadorCidade { get; set; }
        public string Identificador { get; set; }
    }
}
