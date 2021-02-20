using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Informatiz.ControleEstoque.ContratoServico.Venda.RegistrarSangria
{

   public class RespostaRegistrarSangria : RespostaGenerica
    {
       public decimal Saldo { get; set; }       
    }
}
