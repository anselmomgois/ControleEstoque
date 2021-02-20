using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Informatiz.ControleEstoque.ContratoServico.Parametro.RecuperarGrupoParametros
{
    public class PeticaoRecuperarGrupoParametros : PeticaoGenerico
    {

        public List<Comum.Clases.GrupoParametro> GrupoParametros;
        public string IdentificadorFilial;
        public string IdentificadorEmpresa;

    }
}
