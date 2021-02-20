using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.Sessao.AtualizarSessao
{
    public class PeticaoAtualizarSessao : PeticaoGenerico
    {

        [Required(ErrorMessage = "O identificador da sessão é obrigatório.")]
        public string IdentificadorSessao { get; set; }
    }
}
