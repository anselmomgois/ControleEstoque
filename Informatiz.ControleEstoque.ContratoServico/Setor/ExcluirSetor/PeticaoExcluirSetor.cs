using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.Setor.ExcluirSetor
{
    public class PeticaoExcluirSetor : PeticaoGenerico
    {


        [Required(ErrorMessage = "O identificador do setor é obrigatório.")]
        public string IdentificadorSetorEmpresa { get; set; }
    }
}
