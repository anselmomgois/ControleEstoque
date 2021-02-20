using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.SegmentoComercial.PesquisarSegmentoComercial
{
     public class PeticaoPesquisarSegmentoComercial : PeticaoGenerico
    {

        public Int32 Codigo { get; set; }

        public string Descricao { get; set; }
        [Required(ErrorMessage = "O identificador da empresa é obrigatório.")]
        public string IdentificadorEmpresa { get; set; }
        public string Identificador { get; set; }
    }
}
