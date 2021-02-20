using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.Setor.BuscarSetores
{
    public class PeticaoBuscarSetores : PeticaoGenerico
    {


        [Required(ErrorMessage = "O identificador da empresa é obrigatório.")]
        public string IdentificadorEmpresa { get; set; }
        [Required(ErrorMessage = "O identificador da filial é obrigatório.")]
        public string IdentificadorFilial{ get; set; }
        public string Descricao { get; set; }
    }
}
