using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.CRM.GerarAgendamentoAutomatico
{
     public class PeticaoGerarAgendamentoAutomatico : PeticaoGenerico
    {

        [Required(ErrorMessage = "Os dados do crm são obrigatório.")]
        public List<Comum.Clases.CRM> CRMs { get; set; }

        [Required(ErrorMessage = "O identificador da empresa é obrigatório.")]
        public string IdentificadorEmpresa { get; set; }
        [Required(ErrorMessage = "O código do crm padrão é obrigatório.")]
        public string CodigoTipoCrmPadrao { get; set; }
        [Required(ErrorMessage = "A descrição do cliente padrão é obrigatório.")]
        public string DescricaoClientePadrao { get; set; }
        public string DescricaoNivelAtendimentoPadrao { get; set; }
        public Boolean Integracao { get; set; }

    }
}
