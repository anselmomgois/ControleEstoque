using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.Compra.RecuperarCompras
{
     public class PeticaoRecuperarCompras : PeticaoGenerico
    {

       public List<string> IdentificadorFiliais { get; set; }
        public Nullable<DateTime> DataVencimentoInicio { get; set; }
        public Nullable<DateTime> DataVencimentoFim { get; set; }
        public Nullable<DateTime> DataInicio { get; set; }
        public Nullable<DateTime> DataFim { get; set; }
        public Nullable<Comum.Enumeradores.EstadoCompra> EstadoCompra { get; set; }
        public string Codigo { get; set; }

    }
}
