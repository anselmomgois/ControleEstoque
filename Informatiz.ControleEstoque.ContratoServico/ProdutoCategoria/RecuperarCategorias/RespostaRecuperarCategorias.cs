﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Informatiz.ControleEstoque.ContratoServico.ProdutoCategoria.RecuperarCategorias
{

   public class RespostaRecuperarCategorias : RespostaGenerica
    {
       public List<Comum.Clases.ProdutoCategoria> Categorias { get; set; }
    }
}
