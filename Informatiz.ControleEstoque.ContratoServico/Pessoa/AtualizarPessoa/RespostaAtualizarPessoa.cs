﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Informatiz.ControleEstoque.ContratoServico.Pessoa.AtualizarPessoa
{

   public class RespostaAtualizarPessoa : RespostaGenerica
    {
        public Comum.Clases.Pessoa Pessoa { get; set; }
    }
}
