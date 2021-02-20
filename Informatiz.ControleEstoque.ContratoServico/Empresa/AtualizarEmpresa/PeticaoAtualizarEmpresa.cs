using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.Empresa.AtualizarEmpresa
{
     public class PeticaoAtualizarEmpresa : PeticaoGenerico
    {

        [Required(ErrorMessage = "Os dados da empresa são obrigatório.")]
        public Comum.Clases.Empresa Empresa { get; set; }

    }
}
