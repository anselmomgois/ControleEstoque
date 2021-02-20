using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.Venda.RegistrarSuprimento
{
     public class PeticaoRegistrarSuprimento : PeticaoGenerico
    {

        public Comum.Clases.Suprimento Suprimento { get; set; }
        
    }
}
