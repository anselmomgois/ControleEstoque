using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Informatiz.ControleEstoque.ContratoServico.Parametro.RecuperarParametros
{
    public class PeticaoRecuperarParametros : PeticaoGenerico
    {

        public List<Comum.Clases.Parametro> Parametros { get; set; }
        public string IdentificadorFilial { get; set; }
        public string IdentificadorEmpresa { get; set; }

    }
}
