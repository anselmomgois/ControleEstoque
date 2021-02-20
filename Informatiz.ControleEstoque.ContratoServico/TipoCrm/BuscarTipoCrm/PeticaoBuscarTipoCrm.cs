using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.TipoCrm.BuscarTipoCrm
{
     public class PeticaoBuscarTipoCrm : PeticaoGenerico
    {

        public string Identificador { get; set; }
        public string Codigo { get; set; }
        public string IdentificadorEmpresa { get; set; }
    }
}
