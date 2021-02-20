﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Informatiz.ControleEstoque.ContratoServico.ValidarChave
{
    [Serializable]
    [XmlType(Namespace = "urn:ValidarChave")]
    [XmlRoot(Namespace = "urn:ValidarChave")]
    public class Peticao : PeticaoGenerico
    {

        public Int32 CodigoEmpresa;
        public string Chave;
       
    }
}
