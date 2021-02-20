using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.Comum.Clases
{
    public class Caixa
    {
        public string Identificador { get; set; }
        public int Codigo { get; set; }
        public bool EstaAberto { get; set; }
        public string HostName { get; set; }
        public Comum.Clases.OperacaoCaixa OperacaoCaixa { get; set; }

    }
}
