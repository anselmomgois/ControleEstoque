using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.Pessoa.AtualizarPessoa
{
    public class PeticaoAtualizarPessoa : PeticaoGenerico
    {

        public Comum.Clases.Pessoa Pessoa { get; set; }
    }
}