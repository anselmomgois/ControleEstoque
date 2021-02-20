using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.Pessoa.InserirPessoa
{
    public class PeticaoInserirPessoa : PeticaoGenerico
    {

        public Comum.Clases.Pessoa Pessoa { get; set; }
    }
}