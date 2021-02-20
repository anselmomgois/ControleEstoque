using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.SegmentoComercial.DeletarSegmentoComercial
{
    public class PeticaoDeletarSegmentoComercial : PeticaoGenerico
    {


        [Required(ErrorMessage = "O identificador do segmento é obrigatório.")]
        public string Identificador { get; set; }
    }
}
