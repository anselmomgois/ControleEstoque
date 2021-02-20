using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.Processo.RecuperarProcessos
{
    public class PeticaoRecuperarProcessos : PeticaoGenerico
    {

        public string IdentificadorEmpresa{ get; set; }
        public Nullable<Boolean> Ativo { get; set; }
        public Boolean RecuperarItemProcesso { get; set; }
    }
}