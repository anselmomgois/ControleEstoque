using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Informatiz.ControleEstoque.ContratoServico.RecuperarImagem
{
    [Serializable]
    [XmlType(Namespace = "urn:RecuperarImagem")]
    [XmlRoot(Namespace = "urn:RecuperarImagem")]
    public class Peticao
    {

        public string Usuario;
    }
}
