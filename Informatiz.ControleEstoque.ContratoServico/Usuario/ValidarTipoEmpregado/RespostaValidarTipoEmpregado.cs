using System.Collections.Generic;
using Informatiz.ControleEstoque.Comum.Enumeradores;

namespace Informatiz.ControleEstoque.ContratoServico.Usuario.ValidarTipoEmpregado
{

    public class RespostaValidarTipoEmpregado : RespostaGenerica
    {

        public List<Enumeradores.TipoEmpregado> TiposEmpregado { get; set; }
        public bool AcessoPermitido;
        public string IdentificadorUsuario { get; set; }
        public string NomeUsuario { get; set; }
    }
}
