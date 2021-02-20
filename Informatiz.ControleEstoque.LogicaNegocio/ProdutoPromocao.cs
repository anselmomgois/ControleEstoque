using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using frmUtil = AmgSistemas.Framework.Utilitarios;
using AmgSistemas.Framework.AcessoDados;

namespace Informatiz.ControleEstoque.LogicaNegocio
{
    public class ProdutoPromocao
    {

        public static List<Comum.Clases.ProdutoPromocao> PesquisarProdutoPromocao(string Descricao,
                                                                                  string DescricaoProduto,
                                                                                  string IdentificadorEmpresa,
                                                                                  string IdentificadorFilial,
                                                                                  string Usuario)
        {

            List<Comum.Clases.ProdutoPromocao> ProdutosPromocoes = null;

            try
            {

                ProdutosPromocoes = AcessoDados.Classes.ProdutoPromocao.PesquisarProdutoPromocao(Descricao, DescricaoProduto, IdentificadorEmpresa, IdentificadorFilial);

            }
            catch (Exception ex)
            {
                Erro.InserirErro(new Comum.Clases.Erro() { DesErro = ex.Message, Usuario = Usuario });
                throw ex;
            }

            return ProdutosPromocoes;
        }

        public static void InserirProdutoPromocao(Comum.Clases.ProdutoPromocao objProdutoPromocao,
                                                  string identificadorEmpresa,
                                                  string identificadorFilial,
                                                  string Usuario)
        {

            try
            {

                System.Text.StringBuilder Erros = new System.Text.StringBuilder();

                frmUtil.Util.ValidarCampo(objProdutoPromocao.Descricao, "Favor informar a descrição", typeof(string), false, ref Erros);

                if ((objProdutoPromocao.ProdutosCompra == null || objProdutoPromocao.ProdutosCompra.Count == 0) &&
                   (objProdutoPromocao.ProdutosPorFilial == null || objProdutoPromocao.ProdutosPorFilial.Count == 0) &&
                   (objProdutoPromocao.PrudutosEmpresa == null || objProdutoPromocao.PrudutosEmpresa.Count == 0))
                {
                    Erros.AppendLine("E obrigatório informar um produto.");
                }

                if (Erros.Length > 0)
                {
                    throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, Erros.ToString());
                }

                Sql objSql = new Sql();

                objSql.IniciarTransacaoArquivo(Comum.Clases.Constantes.ARQUIVO_CONEXAO);

                string IdentificadorProdutoPromocao =
                AcessoDados.Classes.ProdutoPromocao.InserirProdutoPromocao(objProdutoPromocao,
                                                                           identificadorEmpresa,
                                                                           identificadorFilial,
                                                                           ref objSql);

                if (objProdutoPromocao.PrudutosEmpresa != null && objProdutoPromocao.PrudutosEmpresa.Count > 0)
                {

                    foreach (Comum.Clases.ProdutoServico ps in objProdutoPromocao.PrudutosEmpresa)
                    {

                        AcessoDados.Classes.ProdutoPromocao.InserirItensProdutoPromocao(IdentificadorProdutoPromocao, ps.Identificador, string.Empty, string.Empty, ref objSql);
                    }
                }

                if (objProdutoPromocao.ProdutosCompra != null && objProdutoPromocao.ProdutosCompra.Count > 0)
                {

                    foreach (Comum.Clases.ProdutoServico pc in objProdutoPromocao.ProdutosCompra)
                    {

                        AcessoDados.Classes.ProdutoPromocao.InserirItensProdutoPromocao(IdentificadorProdutoPromocao, pc.Identificador, pc.IdentificadorProdutoFilial, pc.IdentificadorProdutoCompra, ref objSql);
                    }
                }

                if (objProdutoPromocao.ProdutosPorFilial != null && objProdutoPromocao.ProdutosPorFilial.Count > 0)
                {

                    foreach (Comum.Clases.ProdutoServico pf in objProdutoPromocao.ProdutosPorFilial)
                    {

                        AcessoDados.Classes.ProdutoPromocao.InserirItensProdutoPromocao(IdentificadorProdutoPromocao, pf.Identificador, pf.IdentificadorProdutoFilial, string.Empty, ref objSql);
                    }
                }

                objSql.ExecutarTransacao();
            }
            catch (Execao.ExecaoNegocio ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                Erro.InserirErro(new Comum.Clases.Erro() { DesErro = ex.Message, Usuario = Usuario });
                throw ex;
            }
        }

        public static void AtualizarProdutoPromocao(Comum.Clases.ProdutoPromocao objProdutoPromocao, 
                                                    string identificadorEmpresa,
                                                    string identificadorFilial,
                                                    string Usuario)
        {

            try
            {

                System.Text.StringBuilder Erros = new System.Text.StringBuilder();

                frmUtil.Util.ValidarCampo(objProdutoPromocao.Descricao, "Favor informar a descrição", typeof(string), false, ref Erros);

                if ((objProdutoPromocao.ProdutosCompra == null || objProdutoPromocao.ProdutosCompra.Count == 0) &&
                   (objProdutoPromocao.ProdutosPorFilial == null || objProdutoPromocao.ProdutosPorFilial.Count == 0) &&
                   (objProdutoPromocao.PrudutosEmpresa == null || objProdutoPromocao.PrudutosEmpresa.Count == 0))
                {
                    Erros.AppendLine("E obrigatório informar um produto.");
                }

                if (Erros.Length > 0)
                {
                    throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, Erros.ToString());
                }

                Sql objSql = new Sql();

                objSql.IniciarTransacaoArquivo(Comum.Clases.Constantes.ARQUIVO_CONEXAO);

                AcessoDados.Classes.ProdutoPromocao.AtualizarProdutoPromocao(objProdutoPromocao,
                                                                             identificadorEmpresa,
                                                                             identificadorFilial,
                                                                             ref objSql);

                AcessoDados.Classes.ProdutoPromocao.DeletarItensProdutoPromocao(objProdutoPromocao.Identificador, ref objSql);

                if (objProdutoPromocao.PrudutosEmpresa != null && objProdutoPromocao.PrudutosEmpresa.Count > 0)
                {

                    foreach (Comum.Clases.ProdutoServico ps in objProdutoPromocao.PrudutosEmpresa)
                    {

                        AcessoDados.Classes.ProdutoPromocao.InserirItensProdutoPromocao(objProdutoPromocao.Identificador, ps.Identificador, string.Empty, string.Empty, ref objSql);
                    }
                }

                if (objProdutoPromocao.ProdutosCompra != null && objProdutoPromocao.ProdutosCompra.Count > 0)
                {

                    foreach (Comum.Clases.ProdutoServico pc in objProdutoPromocao.ProdutosCompra)
                    {

                        AcessoDados.Classes.ProdutoPromocao.InserirItensProdutoPromocao(objProdutoPromocao.Identificador, pc.Identificador, pc.IdentificadorProdutoFilial, pc.IdentificadorProdutoCompra, ref objSql);
                    }
                }

                if (objProdutoPromocao.ProdutosPorFilial != null && objProdutoPromocao.ProdutosPorFilial.Count > 0)
                {

                    foreach (Comum.Clases.ProdutoServico pf in objProdutoPromocao.ProdutosPorFilial)
                    {

                        AcessoDados.Classes.ProdutoPromocao.InserirItensProdutoPromocao(objProdutoPromocao.Identificador, pf.Identificador, pf.IdentificadorProdutoFilial, string.Empty, ref objSql);
                    }
                }

                objSql.ExecutarTransacao();
            }
            catch (Execao.ExecaoNegocio ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                Erro.InserirErro(new Comum.Clases.Erro() { DesErro = ex.Message, Usuario = Usuario });
                throw ex;
            }
        }

        public static void DesativarProdutoPromocao(string IdentificadorProdutoPromocao, string Usuario)
        {

            try
            {

                AcessoDados.Classes.ProdutoPromocao.DesativarProdutoPromocao(IdentificadorProdutoPromocao);

            }
            catch (Execao.ExecaoNegocio ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                Erro.InserirErro(new Comum.Clases.Erro() { DesErro = ex.Message, Usuario = Usuario });
                throw ex;
            }
        }

        public static Comum.Clases.ProdutoPromocao RecuperarProdutoPromocao(string IdentificadorProdutoPromocao, string Usuario)
        {

            Comum.Clases.ProdutoPromocao ProdutoPromocao = null;

            try
            {

                ProdutoPromocao = AcessoDados.Classes.ProdutoPromocao.RecuperarProdutoPromocao(IdentificadorProdutoPromocao);

            }
            catch (Exception ex)
            {
                Erro.InserirErro(new Comum.Clases.Erro() { DesErro = ex.Message, Usuario = Usuario });
                throw ex;
            }

            return ProdutoPromocao;
        }

        public static List<Comum.Clases.ProdutoServico> RecuperarProdutosPromocao(string IdentificadorProdutoPromocao, string Usuario)
        {

            List<Comum.Clases.ProdutoServico> ProdutoPromocao = null;

            try
            {

                ProdutoPromocao = AcessoDados.Classes.ProdutoPromocao.RecuperarProdutosPromocao(IdentificadorProdutoPromocao);

            }
            catch (Exception ex)
            {
                Erro.InserirErro(new Comum.Clases.Erro() { DesErro = ex.Message, Usuario = Usuario });
                throw ex;
            }

            return ProdutoPromocao;
        }
    }
}
