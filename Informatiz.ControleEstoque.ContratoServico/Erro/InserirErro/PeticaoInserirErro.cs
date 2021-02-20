using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.Erro.InserirErro
{
    public class PeticaoInserirErro : PeticaoGenerico
    {
        public Comum.Clases.Erro Erro { get; set; }
    }
}
