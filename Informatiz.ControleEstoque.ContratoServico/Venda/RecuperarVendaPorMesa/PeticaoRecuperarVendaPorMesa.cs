using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.Venda.RecuperarVendaPorMesa
{
     public class PeticaoRecuperarVendaPorMesa : PeticaoGenerico
    {
        [Required(ErrorMessage = "O código da mesa é obrigatório.")]
        public string CodigoMesa{ get; set; }
        [Required(ErrorMessage = "O identificador da empresa é obrigatório.")]
        public string IdentificadorEmpresa { get; set; }
        [Required(ErrorMessage = "O identificador da filial é obrigatório.")]
        public string IdentificadorFilial { get; set; }

    }
}
