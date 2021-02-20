using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Informatiz.ControleEstoque.ContratoServico.RecuperarVersao
{
    [Serializable]
    [XmlType(Namespace = "urn:RecuperarVersao")]
    [XmlRoot(Namespace = "urn:RecuperarVersao")]
    public class Resposta : RespostaGenerica
    {

        public string CodigoVersao;

    }
}
