using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Informatiz.ControleEstoque.Comum.Clases
{
    public class ProdutoCST
    {

        public string Identificador { get; set; }
        public Int32 Codigo { get; set; }
        public string Descricao { get; set; }
        public Int32 CST { get; set; }
        public Boolean TemCST { get; set; }
        public string DesMensagemNotaFiscal { get; set; }

    }
}
