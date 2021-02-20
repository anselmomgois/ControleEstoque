using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Informatiz.ControleEstoque.ContratoServico.Observacao.BuscarObservacao
{

   public class RespostaBuscarObservacao : RespostaGenerica
    {
        public List<Comum.Clases.ProdutoObservacao> Observacoes { get; set; }
    }
}
