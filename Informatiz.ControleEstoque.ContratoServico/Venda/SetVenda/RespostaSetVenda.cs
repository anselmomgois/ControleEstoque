﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Informatiz.ControleEstoque.ContratoServico.Venda.SetVenda
{

   public class RespostaSetVenda : RespostaGenerica
    {
       public Comum.Clases.Venda Venda { get; set; }         
    }
}