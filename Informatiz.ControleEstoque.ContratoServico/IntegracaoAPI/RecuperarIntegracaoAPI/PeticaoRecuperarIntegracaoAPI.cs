﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.IntegracaoAPI.RecuperarIntegracaoAPI
{
    public class PeticaoRecuperarIntegracaoAPI : PeticaoGenerico
    {

       public string Identificador{ get; set; }
    }
}