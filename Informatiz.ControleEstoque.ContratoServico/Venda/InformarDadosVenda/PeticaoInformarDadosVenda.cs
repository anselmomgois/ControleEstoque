using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.Venda.InformarDadosVenda
{
     public class PeticaoInformarDadosVenda : PeticaoGenerico
    {
        [Required(ErrorMessage = "O identificador da venda é obrigatório")]
        public string IdentificadorVenda { get; set; }
        public string IdentificadorFuncionario { get; set; }
        public List<string> IdentificadoresMesa { get; set; }
    }
}
