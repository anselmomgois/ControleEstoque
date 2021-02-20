using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.Relatorios.RecuperarFechamentoCaixa
{
    public class PeticaoRecuperarFechamentoCaixa : PeticaoGenerico
    {

        public string IdentificadorResponsavelCaixa{ get; set; }
        public string IdentificadorEmpresa { get; set; }
    }
}