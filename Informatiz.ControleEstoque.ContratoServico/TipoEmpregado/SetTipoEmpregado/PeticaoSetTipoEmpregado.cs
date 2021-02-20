using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.TipoEmpregado.SetTipoEmpregado
{
    public class PeticaoSetTipoEmpregado : PeticaoGenerico
    {

        public Comum.Clases.TipoEmpregado TipoEmpregado { get; set; }        
        public string IdentificadorEmpresa { get; set; }

    }
}
