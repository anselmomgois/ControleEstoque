using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Informatiz.ControleEstoque.ContratoServico.Parametro.RecuperarParametros
{
    public class RespostaRecuperarParametros : RespostaGenerica
    {

        public List<Comum.Clases.Parametro> Parametros;
    }
}
