using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.Endereco.RecuperarCidades
{
     public class PeticaoRecuperarCidades : PeticaoGenerico
    {

        public Nullable<int> Codigo { get; set; }
        public string Nome { get; set; }
        public string IdentificadorEstado { get; set; }
        public string Identificador { get; set; }
    }
}
