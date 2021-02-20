using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.Processo.SetProcesso
{
    public class PeticaoSetProcesso : PeticaoGenerico
    {

        public string IdentificadorEmpresa{ get; set; }
        public Comum.Clases.Processo Processo { get; set; }
    }
}