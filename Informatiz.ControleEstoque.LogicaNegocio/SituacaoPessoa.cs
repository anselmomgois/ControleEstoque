using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Informatiz.ControleEstoque.LogicaNegocio
{
    public class SituacaoPessoa
    {

        public static List<Comum.Clases.SituacaoPessoa> RecuperarSituacoesPessoa(string Usuario, string Identificador)
        {

            List<Comum.Clases.SituacaoPessoa> Situacoes = null;

            try
            {

                Situacoes = AcessoDados.Classes.SituacaoPessoa.RecuperarSituacaoPessoa(Identificador);

            }
            catch (Exception ex)
            {
                Erro.InserirErro(new Comum.Clases.Erro() { DesErro = ex.Message, Usuario = Usuario });
                throw ex;
            }

            return Situacoes;
        }
    }
}
