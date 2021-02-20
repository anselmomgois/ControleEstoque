using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.Processo.RecuperarProcesso
{
    public class PeticaoRecuperarProcesso : PeticaoGenerico
    {

        public string IdentificadorProcesso{ get; set; }
    }
}