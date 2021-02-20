using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Informatiz.ControleEstoque.ContratoServico.ValidarUsuario
{
    [Serializable]
    [XmlType(Namespace = "urn:ValidarUsuario")]
    [XmlRoot(Namespace = "urn:ValidarUsuario")]
    public class Peticao : PeticaoGenerico
    {

        public string Usuario;

    }
}
