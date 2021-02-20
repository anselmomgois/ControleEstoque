using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.SegmentoComercial.RecuperarSegmentoComercial
{
    public class PeticaoRecuperarSegmentoComercial : PeticaoGenerico
    {


        [Required(ErrorMessage = "O identificador do segmento é obrigatório.")]
        public string Identificador { get; set; }
    }
}
