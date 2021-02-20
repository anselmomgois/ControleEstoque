using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Informatiz.ControleEstoque.ContratoServico.Venda.RecuperarPagamentosCaixa
{

    public class RespostaRecuperarPagamentosCaixa : RespostaGenerica
    {
        public List<Comum.Clases.Venda> Vendas { get; set; }
        public List<Comum.Clases.Sangria> Sangrias { get; set; }
        public List<Comum.Clases.Suprimento> Suprimentos { get; set; }
        public Decimal SaldoInicial { get; set; }
    }
}
