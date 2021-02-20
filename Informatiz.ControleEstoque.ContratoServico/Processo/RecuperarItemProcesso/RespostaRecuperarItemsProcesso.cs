using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Informatiz.ControleEstoque.ContratoServico.Processo.RecuperarItemsProcesso
{

   public class RespostaRecuperarItemsProcesso : RespostaGenerica
    {
        public List<Comum.Clases.ItemProcesso> ItemsProcesso { get; set; }
    }
}
