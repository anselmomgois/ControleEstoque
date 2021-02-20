﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Informatiz.ControleEstoque.Comum.Clases
{
    public class ProdutoComissao
    {
        public string Identificador { get; set; }
        public Int32 Codigo { get; set; }
        public string Descricao { get; set; }
        public Nullable<decimal> NumPercentual { get; set; }
        public Nullable<decimal> NumValor { get; set; }
        public Boolean Habilitada { get; set; }
    }
}