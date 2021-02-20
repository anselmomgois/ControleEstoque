using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Informatiz.ControleEstoque.ContratoServico.Telas.GuardarVendaSupermercado.Carregar
{

   public class RespostaGuardarVendaSupermercadoCarregar : RespostaGenerica
    {
        public List<Comum.Clases.ProdutoDisponivelVenda> ProdutosDisponiveisVenda { get; set; }
        public Comum.Clases.Venda Venda { get; set; }
    }
}
