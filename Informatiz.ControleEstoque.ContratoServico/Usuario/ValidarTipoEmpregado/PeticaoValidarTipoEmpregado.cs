using System.Collections.Generic;
using Informatiz.ControleEstoque.Comum.Enumeradores;

namespace Informatiz.ControleEstoque.ContratoServico.Usuario.ValidarTipoEmpregado
{
    public class PeticaoValidarTipoEmpregado : PeticaoGenerico
    {

        public string nomeUsuario;
        public string senhaUsuario;
        public bool validarPermissao;
        public bool usuarioLogado;
        public List<Enumeradores.TipoEmpregado> TiposEmpregado { get; set; }

    }
}
