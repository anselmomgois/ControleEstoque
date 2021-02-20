using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Informatiz.ControleEstoque.ContratoServico.Parametro.RecuperarGrupoParametros
{
    public class RespostaRecuperarGrupoParametros : RespostaGenerica
    {

        public List<Comum.Clases.GrupoParametro> GrupoParametros;
    }
}
