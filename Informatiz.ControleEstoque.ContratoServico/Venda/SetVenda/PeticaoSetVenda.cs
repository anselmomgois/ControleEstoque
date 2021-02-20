using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.Venda.SetVenda
{
     public class PeticaoSetVenda : PeticaoGenerico
    {

        public Comum.Clases.Venda Venda { get; set; }
        [Required(ErrorMessage = "O identificador da empresa é obrigatório.")]
        public string IdentificadorEmpresa { get; set; }
        public Boolean TelaPorComanda { get; set; }
        
    }
}
