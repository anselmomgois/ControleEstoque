using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Informatiz.ControleEstoque.ContratoServico.GerarChave
{
    [Serializable]
    [XmlType(Namespace = "urn:GerarChave")]
    [XmlRoot(Namespace = "urn:GerarChave")]
    public class Peticao : PeticaoGenerico
    {

        public Boolean SessoesInfinita;
        public Int32 QuantidadeSessoes;
        public Int32 NumValidade;
        public Boolean ValidadeInfinita;
        public Int32 NumQuantidadeAcessos;
               
    }
}
