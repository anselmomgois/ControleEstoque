using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.Venda.RecuperarPagamentosCaixa
{
     public class PeticaoRecuperarPagamentosCaixa : PeticaoGenerico
    {
        [Required(ErrorMessage = "O identificador responsável caixa obrigatório.")]
        public string IdentificadorResponsavelCaixa { get; set; }
        [Required(ErrorMessage = "O identificador da empresa é obrigatório.")]
        public string IdentificadorEmpresa { get; set; }
        
    }
}
