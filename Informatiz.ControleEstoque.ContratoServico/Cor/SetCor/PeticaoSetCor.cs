﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.Cor.SetCor
{
    public class PeticaoSetCor : PeticaoGenerico
    {

        public string IdentificadorEmpresa { get; set; }
        public Comum.Clases.Cor Cor { get; set; }
    }
}