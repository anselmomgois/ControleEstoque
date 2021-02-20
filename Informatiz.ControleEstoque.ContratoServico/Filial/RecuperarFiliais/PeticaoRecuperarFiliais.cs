using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.Filial.RecuperarFiliais
{
     public class PeticaoRecuperarFiliais : PeticaoGenerico
    {

        [Required(ErrorMessage = "Os dados da empresa são obrigatório.")]
        public string IdentificadorEmpresa { get; set; }

    }
}
