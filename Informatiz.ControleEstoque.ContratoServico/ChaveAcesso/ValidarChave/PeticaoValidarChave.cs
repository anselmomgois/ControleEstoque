using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Informatiz.ControleEstoque.ContratoServico.ChaveAcesso.ValidarChave
{
    public class PeticaoValidarChave : PeticaoGenerico
    {

        public string Chave { get; set; }
        public Int32 CodigoEmpresa { get; set; }
        public string IdentificadorEmpresa { get; set; }

    }
}
