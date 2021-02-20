using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Informatiz.ControleEstoque.ContratoServico.Observacao.RecuperarObservacao
{

   public class RespostaRecuperarObservacao : RespostaGenerica
    {
        public Comum.Clases.ProdutoObservacao Observacao { get; set; }
    }
}
