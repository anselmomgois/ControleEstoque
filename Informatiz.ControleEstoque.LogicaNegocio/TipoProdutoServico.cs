using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Informatiz.ControleEstoque.LogicaNegocio
{
    public class TipoProdutoServico
    {

        public static Comum.Clases.TipoProdutoServico RecuperarTipoProdutoServico(string Usuario, string Identificador)
        {

            Comum.Clases.TipoProdutoServico objTipo = null;

            try
            {

                objTipo = AcessoDados.Classes.TipoProdutoServico.RecuperarTipoProdutoServico(Identificador);

            }
            catch (Exception ex)
            {
                Erro.InserirErro(new Comum.Clases.Erro() { DesErro = ex.Message, Usuario = Usuario });
                throw ex;
            }

            return objTipo;
        }

        public static Comum.Clases.TipoProdutoServico RecuperarTipoProdutoServicoComCodigo(string Usuario, string Codigo)
        {

            Comum.Clases.TipoProdutoServico objTipo = null;

            try
            {

                objTipo = AcessoDados.Classes.TipoProdutoServico.RecuperarTipoProdutoServicoComCodigo(Codigo);

            }
            catch (Exception ex)
            {
                Erro.InserirErro(new Comum.Clases.Erro() { DesErro = ex.Message, Usuario = Usuario });
                throw ex;
            }

            return objTipo;
        }

    }
}
