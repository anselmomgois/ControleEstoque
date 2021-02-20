using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.SegmentoComercial.SetSegmentoComercial
{
    public class PeticaoRecuperarSetSegmentoComercial : PeticaoGenerico
    {


        [Required(ErrorMessage = "O identificador da empresa é obrigatório.")]
        public string IdentificadorEmpresa { get; set; }
        public Comum.Clases.SegmentoComercial SegmentoComercial { get; set; }
    }
}
