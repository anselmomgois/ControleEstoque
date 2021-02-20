using System;
using System.Collections.Generic;

namespace Informatiz.ControleEstoque.Comum.Clases
{
    public class Documento
    {

        public string Identificador { get; set; }
        public Filiais Filial { get; set; }
        public Pessoa Pessoa { get; set; }
        public Administradora Administradora { get; set; }
        public Documento DocumentoPai { get; set; }
        public string CodigoTransacao { get; set; }
        public string NumeroBoletoBancario { get; set; }
        public DateTime DataEmissao { get; set; }
        public DateTime DataVencimentoOriginal { get; set; }
        public DateTime DataVencimentoAtual { get; set; }
        public decimal ValorOriginal { get; set; }
        public Boolean Parcelado { get; set; }
        public string ObservacaoDocumento { get; set; }
        public LocalDocumento LocalDocumento { get; set; }
        public TipoDocumento TipoDocumento { get; set; }
        public FormaPagamento FormaPagamento { get; set; }
        public List<Transacao> Transacoes { get; set; }
        public List<Parcelamento> Parcelas { get; set; }
        public string Codigo { get; set; }
    }
}
