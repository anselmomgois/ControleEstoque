﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Informatiz.ControleEstoque.ContratoServico.UnidadeMedida.RecuperarUnidadesMedida
{

   public class RespostaRecuperarUnidadesMedida : RespostaGenerica
    {
        public List<Comum.Clases.UnidadeMedida> UnidadesMedida { get; set; }
    }
}
