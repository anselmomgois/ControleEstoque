using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Informatiz.ControleEstoque.ContratoServico.Acao.RecuperarAcoes
{
    public class RespostaRecuperarAcoes :RespostaGenerica
    {

        public List<Comum.Clases.Acao> Acoes { get; set; }
    }
}
