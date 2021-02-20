using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.UnidadeMedida.RecuperarUnidadesMedida
{
     public class PeticaoRecuperarUnidadesMedida : PeticaoGenerico
    {

        [Required(ErrorMessage = "O identificador empresa é obrigatório.")]
        public string IdentificadorEmpresa { get; set; }
        public string Descricao { get; set; }
        public Boolean RecuperarUnidadesFilhas { get; set; }
        
    }
}
