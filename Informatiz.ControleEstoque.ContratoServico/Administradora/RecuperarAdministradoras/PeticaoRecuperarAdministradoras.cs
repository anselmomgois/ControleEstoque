﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Informatiz.ControleEstoque.ContratoServico.Administradora.RecuperarAdministradoras
{
    public class PeticaoRecuperarAdministradoras : PeticaoGenerico
    {

        public string Descricao { get; set; }
        public string IdentificadorEmpresa { get; set; }
        public string Usuario { get; set; }
                
    }
}
