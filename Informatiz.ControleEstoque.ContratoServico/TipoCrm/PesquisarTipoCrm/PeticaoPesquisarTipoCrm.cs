using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.TipoCrm.PesquisarTipoCrm
{
     public class PeticaoPesquisarTipoCrm : PeticaoGenerico
    {

        public string Descricao { get; set; }
        [Required(ErrorMessage = "O identificador da empresa é obrigatório.")]
        public string IdentificadorEmpresa { get; set; }
        
    }
}
