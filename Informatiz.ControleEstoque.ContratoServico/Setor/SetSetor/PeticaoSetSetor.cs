using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.Setor.SetSetor
{
    public class PeticaoSetSetor : PeticaoGenerico
    {


        [Required(ErrorMessage = "O identificador da empresa é obrigatório.")]
        public string IdentificadorEmpresa { get; set; }
        [Required(ErrorMessage = "O identificador da filial é obrigatório.")]
        public string IdentificadorFilial{ get; set; }
        public Comum.Clases.SetorEmpresa SetorEmpresa { get; set; }
    }
}
