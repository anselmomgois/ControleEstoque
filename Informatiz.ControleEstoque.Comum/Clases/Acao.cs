﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Informatiz.ControleEstoque.Comum.Clases
{
    public class Acao
    {

        public Comum.Enumeradores.Enumeradores.TipoAcao TipoAcao { get; set; }
        public string Identificador { get; set; }
        public string Descricao { get; set; }

    }
}