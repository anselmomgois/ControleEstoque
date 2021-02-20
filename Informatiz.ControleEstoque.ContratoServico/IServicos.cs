using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Informatiz.ControleEstoque.ContratoServico
{
   public interface IServicos
    {
  
        ContratoServico.Administradora.InserirAdministradora.RespostaInserirAdministradora InserirAdministradora(ContratoServico.Administradora.InserirAdministradora.PeticaoInserirAdministradora Peticao);

        ContratoServico.Administradora.RecuperarAdministradoras.RespostaRecuperarAdministradoras RecuperarAdministradoras(ContratoServico.Administradora.RecuperarAdministradoras.PeticaoRecuperarAdministradoras Peticao);

        ContratoServico.Administradora.AtualizarAdministradora.RespostaAtualizarAdministradora AtualizarAdministradora(ContratoServico.Administradora.AtualizarAdministradora.PeticaoAtualizarAdministradora Peticao);

        ContratoServico.Administradora.DeletarAdministradora.RespostaDeletarAdministradora DeletarAdministradora(ContratoServico.Administradora.DeletarAdministradora.PeticaoDeletarAdministradora Peticao);

        ContratoServico.Administradora.RecuperarAdministradora.RespostaRecuperarAdministradora RecuperarAdministradora(ContratoServico.Administradora.RecuperarAdministradora.PeticaoRecuperarAdministradora Peticao);

        ContratoServico.Usuario.Logar.RespostaLogar Logar(ContratoServico.Usuario.Logar.PeticaoLogar Peticao);

        ContratoServico.Usuario.DeletarSessao.RespostaDeletarSessao DeletarSessao(ContratoServico.Usuario.DeletarSessao.PeticaoDeletarSessao Peticao);

        ContratoServico.Usuario.AtivarSessao.RespostaAtivarSessao AtivarSessao(ContratoServico.Usuario.AtivarSessao.PeticaoAtivarSessao Peticao);

    }
}
