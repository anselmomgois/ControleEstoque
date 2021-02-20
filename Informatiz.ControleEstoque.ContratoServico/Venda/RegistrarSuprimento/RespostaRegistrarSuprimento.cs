using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Informatiz.ControleEstoque.ContratoServico.Venda.RegistrarSuprimento
{

   public class RespostaRegistrarSuprimento : RespostaGenerica
    {
       public decimal Saldo { get; set; }       
    }
}
