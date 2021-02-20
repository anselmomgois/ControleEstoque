using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Informatiz.ControleEstoque.ContratoServico.Venda.RecuperarVendaEmCurso
{

   public class RespostaRecuperarVendaEmCurso : RespostaGenerica
    {
       public Comum.Clases.Venda Venda { get; set; }         
    }
}
