using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using frmUtil = AmgSistemas.Framework.Utilitarios;
using AmgSistemas.Framework.AcessoDados;

namespace Informatiz.ControleEstoque.LogicaNegocio
{
    public class ProdutoServico
    {

        public static List<Comum.Clases.ProdutoServico> RecuperarProdutosServicos(string Descricao, Nullable<Int32> Codigo, string CodigoBarras,
                                                                                  string IdentificadorEmpresa, string Usuario, string CodigoTipoProduto,
                                                                                  string IdentificadorFilial, Boolean RecuperarUnidadesMedida, Boolean RecuperarImagensProduto)
        {

            List<Comum.Clases.ProdutoServico> ProdutosServicos = null;

            try
            {

                ProdutosServicos = AcessoDados.Classes.ProdutoServico.RecuperarProdutosServicos(Descricao, Codigo, CodigoBarras, IdentificadorEmpresa, CodigoTipoProduto, IdentificadorFilial, RecuperarUnidadesMedida, RecuperarImagensProduto);

            }
            catch (Exception ex)
            {
                Erro.InserirErro(new Comum.Clases.Erro() { DesErro = ex.Message, Usuario = Usuario });
                throw ex;
            }

            return ProdutosServicos;
        }


        public static void InserirProdutoServico(Comum.Clases.ProdutoServico objProdutoServico, string IdentificadorEmpresa, string Usuario)
        {

            try
            {

                System.Text.StringBuilder Erros = new System.Text.StringBuilder();

                frmUtil.Util.ValidarCampo(objProdutoServico.Descricao, "Favor informar a descrição", typeof(string), false, ref Erros);

                if (objProdutoServico.CodigosBarras != null && objProdutoServico.CodigosBarras.Count > 0 &&
                    objProdutoServico.CodigosBarras.Exists(cb => !frmUtil.Validacao.ValidarValorCampo(cb.CodigoBarras, frmUtil.Enumeradores.TipoValidacao.EAN13)))
                {
                    Erros.AppendLine("Código de barras inválido");
                }

                if (objProdutoServico.UnidadesMedida != null && objProdutoServico.UnidadesMedida.Count > 1)
                {

                    Boolean Compativel = true;

                    foreach (Comum.Clases.UnidadeMedida objUnidade in objProdutoServico.UnidadesMedida)
                    {


                        if ((from Comum.Clases.UnidadeMedida objU in objProdutoServico.UnidadesMedida
                             where (objU.UnidademedidaPai != null && objU.UnidademedidaPai.Identificador == objUnidade.Identificador) ||
                                   (objUnidade.UnidademedidaPai != null && objU.Identificador == objUnidade.UnidademedidaPai.Identificador)
                             select objU).Count() == 0)
                        {
                            Compativel = false;
                        }

                        if ((from Comum.Clases.UnidadeMedida objU in objProdutoServico.UnidadesMedida
                             where objU.UnidademedidaPai == null
                             select objU).Count() > 1)
                        {
                            Compativel = false;
                        }

                    }

                    if (!Compativel)
                    {
                        Erros.AppendLine("Unidades de medida incompativeis");
                    }
                }

                if (Erros.Length > 0)
                {
                    throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, Erros.ToString());
                }

                Sql objSql = new Sql();

                objSql.IniciarTransacaoArquivo(Comum.Clases.Constantes.ARQUIVO_CONEXAO);

                string IdentificadorProdutoServico =
                AcessoDados.Classes.ProdutoServico.InserirProdutoServico(objProdutoServico, IdentificadorEmpresa, ref objSql);

                if (objProdutoServico.CodigosBarras != null && objProdutoServico.CodigosBarras.Count > 0)
                {
                    foreach (Comum.Clases.ProdutoServicoCodigoBarras cb in objProdutoServico.CodigosBarras)
                    {
                        AcessoDados.Classes.ProdutoServico.InserirCodigoBarras(cb.CodigoBarras, IdentificadorEmpresa, IdentificadorProdutoServico, ref objSql);
                    }
                }

                if (objProdutoServico.Acrescimos != null && objProdutoServico.Acrescimos.Count > 0)
                {
                    foreach (var ac in objProdutoServico.Acrescimos)
                    {
                        AcessoDados.Classes.ProdutoServico.InserirAcrescimo(objProdutoServico.Identificador, ac.Identificador, ref objSql);
                    }
                }

                if (objProdutoServico.ObservacoesProduto != null && objProdutoServico.ObservacoesProduto.Count > 0)
                {
                    foreach (var o in objProdutoServico.ObservacoesProduto)
                    {
                        AcessoDados.Classes.ProdutoServico.InserirObservacoesProduto(objProdutoServico.Identificador, o.Identificador, ref objSql);
                    }
                }

                if (objProdutoServico.UnidadesMedida != null && objProdutoServico.UnidadesMedida.Count > 0)
                {

                    foreach (Comum.Clases.UnidadeMedida um in objProdutoServico.UnidadesMedida)
                    {

                        AcessoDados.Classes.ProdutoServico.InserirUnidadesMedidaProduto(IdentificadorProdutoServico, um.Identificador, ref objSql);
                    }
                }

                List<Comum.Clases.Filiais> objFiliais = Filial.RecuperarFiliaisSimples(IdentificadorEmpresa, Usuario);

                if (objFiliais != null && objFiliais.Count > 0)
                {

                    foreach (Comum.Clases.Filiais objFilial in objFiliais)
                    {
                        AcessoDados.Classes.ProdutoFilial.InserirProdutoFilial(new Comum.Clases.ProdutoFilial(), objFilial.Identificador,
                                                                               IdentificadorProdutoServico, ref objSql);
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

        public static void AtualizarProdutoServico(Comum.Clases.ProdutoServico objProdutoServico, string IdentificadorEmpresa, string Usuario)
        {

            try
            {

                System.Text.StringBuilder Erros = new System.Text.StringBuilder();

                frmUtil.Util.ValidarCampo(objProdutoServico.Descricao, "Favor informar a descrição", typeof(string), false, ref Erros);

                if (objProdutoServico.CodigosBarras != null && objProdutoServico.CodigosBarras.Count > 0 &&
                    objProdutoServico.CodigosBarras.Exists(cb => !frmUtil.Validacao.ValidarValorCampo(cb.CodigoBarras, frmUtil.Enumeradores.TipoValidacao.EAN13)))
                {
                    Erros.AppendLine("Código de barras inválido");
                }

                if (objProdutoServico.UnidadesMedida != null && objProdutoServico.UnidadesMedida.Count > 1)
                {

                    Boolean Compativel = true;

                    foreach (Comum.Clases.UnidadeMedida objUnidade in objProdutoServico.UnidadesMedida)
                    {


                        if ((from Comum.Clases.UnidadeMedida objU in objProdutoServico.UnidadesMedida
                             where (objU.UnidademedidaPai != null && objU.UnidademedidaPai.Identificador == objUnidade.Identificador) ||
                                   (objUnidade.UnidademedidaPai != null && objU.Identificador == objUnidade.UnidademedidaPai.Identificador)
                             select objU).Count() == 0)
                        {
                            Compativel = false;
                        }

                        if ((from Comum.Clases.UnidadeMedida objU in objProdutoServico.UnidadesMedida
                             where objU.UnidademedidaPai == null
                             select objU).Count() > 1)
                        {
                            Compativel = false;
                        }

                    }

                    if (!Compativel)
                    {
                        Erros.AppendLine("Unidades de medida incompativeis");
                    }
                }
                if (Erros.Length > 0)
                {
                    throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, Erros.ToString());
                }

                Sql objSql = new Sql();

                objSql.IniciarTransacaoArquivo(Comum.Clases.Constantes.ARQUIVO_CONEXAO);

                AcessoDados.Classes.ProdutoServico.AtualizarProdutoServico(objProdutoServico, ref objSql);

                AcessoDados.Classes.ProdutoServico.DeletarCodigoBarras(objProdutoServico.Identificador, ref objSql);

                if (objProdutoServico.CodigosBarras != null && objProdutoServico.CodigosBarras.Count > 0)
                {
                    foreach (Comum.Clases.ProdutoServicoCodigoBarras cb in objProdutoServico.CodigosBarras)
                    {
                        AcessoDados.Classes.ProdutoServico.InserirCodigoBarras(cb.CodigoBarras, IdentificadorEmpresa, objProdutoServico.Identificador, ref objSql);
                    }
                }

                AcessoDados.Classes.ProdutoServico.DeletarAcrescimo(objProdutoServico.Identificador, ref objSql);

                if (objProdutoServico.Acrescimos != null && objProdutoServico.Acrescimos.Count > 0)
                {
                    foreach (var ac in objProdutoServico.Acrescimos)
                    {
                        AcessoDados.Classes.ProdutoServico.InserirAcrescimo(objProdutoServico.Identificador, ac.Identificador, ref objSql);
                    }
                }

                AcessoDados.Classes.ProdutoServico.DeletarObservacao(objProdutoServico.Identificador, ref objSql);

                if (objProdutoServico.ObservacoesProduto != null && objProdutoServico.ObservacoesProduto.Count > 0)
                {
                    foreach (var o in objProdutoServico.ObservacoesProduto)
                    {
                        AcessoDados.Classes.ProdutoServico.InserirObservacoesProduto(objProdutoServico.Identificador, o.Identificador, ref objSql);
                    }
                }

                AcessoDados.Classes.ProdutoServico.DeletarUnidadesMedidaProdut(objProdutoServico.Identificador, ref objSql);

                if (objProdutoServico.UnidadesMedida != null && objProdutoServico.UnidadesMedida.Count > 0)
                {

                    foreach (Comum.Clases.UnidadeMedida um in objProdutoServico.UnidadesMedida)
                    {

                        AcessoDados.Classes.ProdutoServico.InserirUnidadesMedidaProduto(objProdutoServico.Identificador, um.Identificador, ref objSql);
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

        public static void DeletarProdutoServico(string IdentificadorProdutoServico, string Usuario)
        {

            try
            {

                if (!AcessoDados.Classes.ProdutoServico.ProdutoServicoEstaSendoUsuado(IdentificadorProdutoServico))
                {

                    Sql objSql = new Sql();

                    objSql.IniciarTransacaoArquivo(Comum.Clases.Constantes.ARQUIVO_CONEXAO);

                    AcessoDados.Classes.ProdutoServico.DeletarUnidadesMedidaProdut(IdentificadorProdutoServico, ref objSql);

                    AcessoDados.Classes.ProdutoServico.DeletarProdutoServico(IdentificadorProdutoServico, ref objSql);

                    objSql.ExecutarTransacao();
                }
                else
                {
                    throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "Existem produtos que estão utilizando esta cor.");
                }
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

        public static Comum.Clases.ProdutoServico RecuperarProdutoServico(string IdentificadorProdutoServico, string Usuario)
        {
            if (string.IsNullOrEmpty(IdentificadorProdutoServico))
            {
                return null;
            }

            Comum.Clases.ProdutoServico objProdutoServico = null;

            try
            {

                objProdutoServico = AcessoDados.Classes.ProdutoServico.RecuperarProdutoServico(IdentificadorProdutoServico);

            }
            catch (Exception ex)
            {
                Erro.InserirErro(new Comum.Clases.Erro() { DesErro = ex.Message, Usuario = Usuario });
                throw ex;
            }

            return objProdutoServico;
        }

        public static Comum.Clases.ProdutosGeral RecuperarProdutoGeral(string IdentificadorEmpresa,
                                                                       string IdentificadorFilial,
                                                                       string Usuario)
        {
            Comum.Clases.ProdutosGeral objProdutoGeral = null;

            try
            {

                objProdutoGeral = AcessoDados.Classes.ProdutoServico.RecuperarProdutosGeral(IdentificadorFilial, IdentificadorEmpresa);

            }
            catch (Exception ex)
            {
                Erro.InserirErro(new Comum.Clases.Erro() { DesErro = ex.Message, Usuario = Usuario });
                throw ex;
            }

            return objProdutoGeral;
        }


    }
}
