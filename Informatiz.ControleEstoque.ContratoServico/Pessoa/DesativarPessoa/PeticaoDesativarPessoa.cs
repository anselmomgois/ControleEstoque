using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.Pessoa.DesativarPessoa
{
    public class PeticaoDesativarPessoa : PeticaoGenerico
    {

        public string Identificador { get; set; }

        public Comum.Enumeradores.Enumeradores.TipoPessoaEnum TipoPessoa { get; set; }
    }
}