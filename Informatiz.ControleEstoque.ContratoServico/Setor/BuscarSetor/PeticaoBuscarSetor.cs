using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.Setor.BuscarSetor
{
    public class PeticaoBuscarSetor : PeticaoGenerico
    {


        [Required(ErrorMessage = "O identificador do setor é obrigatório.")]
        public string IdentificadorSetorEmpresa { get; set; }
    }
}
