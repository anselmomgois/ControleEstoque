using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AmgSistemas.Framework.AcessoDados;
using System.Data;
using frmUtil = AmgSistemas.Framework.Utilitarios;

namespace Informatiz.ControleEstoque.AcessoDados.Classes
{
    public class ProdutoFilial
    {

        public static Comum.Clases.ProdutoFilial RecuperarProdutoFilial(string IdentificadorFilial, string IdentificadorProdutoServico)
        {

            if (string.IsNullOrEmpty(IdentificadorFilial) || string.IsNullOrEmpty(IdentificadorProdutoServico))
            {
                return null;
            }

            Sql objSql = new Sql();
            Comum.Clases.ProdutoFilial objProdutoFilial = null;

            objSql.AdicionarParametro("IDFILIAL", IdentificadorFilial);
            objSql.AdicionarParametro("IDPRODUTOSERVICO", IdentificadorProdutoServico);

            DataTable dt = objSql.ExecutarDataTableArquivo(Properties.Resources.ProdutoFilialRecuperar, Comum.Clases.Constantes.ARQUIVO_CONEXAO);

            if (dt != null && dt.Rows.Count > 0)
            {

                objProdutoFilial = new Comum.Clases.ProdutoFilial()
                {
                    Identificador = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["IDPRODUTOFILIAL"], typeof(string)) as string,
                    Comissao = ProdutoComissao.RecuperarProdutoComissao(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["IDPRODUTOCOMISSAO"], typeof(string)) as string),
                    UnidadeMediaEstoque = UnidadesMedida.RecuperarUnidadeMedida(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["IDUNIDADEMEDIDAESTOQUE"], typeof(string)) as string),
                    UnidadeMedidaVenda = UnidadesMedida.RecuperarUnidadeMedida(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["IDUNIDADEMEDIDAVENDA"], typeof(string)) as string),
                    DesPrateleira = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["DESPRATELEIRA"], typeof(string)) as string,
                    NumEmbalagemPercentual = (Nullable<decimal>)(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["NUMEMBALAGEMPER"], typeof(Nullable<decimal>))),
                    NumEstoqueMinimo = (Nullable<decimal>)(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["NUMESTOQUEMINIMO"], typeof(Nullable<decimal>))),
                    NumFretePercentual = (Nullable<decimal>)(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["NUMFRETEPER"], typeof(Nullable<decimal>))),
                    NumIPIPercentual = (Nullable<decimal>)(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["NUMIPIPER"], typeof(Nullable<decimal>))),
                    NumOutrasDespesasPercentual = (Nullable<decimal>)(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["NUMOUTDESPPER"], typeof(Nullable<decimal>))),
                    NumMinimoVenda = (Nullable<decimal>)(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["NUMMINIMOVENDA"], typeof(Nullable<decimal>))),
                    UnidadeMedidaVendaVarejo = UnidadesMedida.RecuperarUnidadeMedida(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["IDUMVALORVENDAVAREJO"], typeof(string)) as string),
                    UnidadeMedidaVendaAtacado = UnidadesMedida.RecuperarUnidadeMedida(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["IDUMVALORVENATACADO"], typeof(string)) as string),
                    UnidadeMedidaQuantidadeVendaAtacado = UnidadesMedida.RecuperarUnidadeMedida(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["IDUMVENDAATACADO"], typeof(string)) as string),
                    NumValorVendaVarejo= (Nullable<decimal>)(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["NUMVALORVENDAVAREJO"], typeof(Nullable<decimal>))),
                    NumValorVendaAtacado = (Nullable<decimal>)(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["NUMVALORVENDAATACADO"], typeof(Nullable<decimal>))),
                    NumQuantidadeVendaAtacado = (Nullable<Int32>)(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["NUMQUANTVENDAATACADO"], typeof(Nullable<Int32>))),
                    NumDescontoAtacadoPercentual = (Nullable<decimal>)(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["NUMPERCENTDESCONTATAC"], typeof(Nullable<decimal>))),
                    SetorEmpresa = new Comum.Clases.SetorEmpresa() { IdentificadorSetorEmpresa = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["IDSETOREMPRESA"], typeof(string)) as string}
                };


            }

            return objProdutoFilial;
        }

        public static void InserirProdutoFilial(Comum.Clases.ProdutoFilial objProdutoFilial, string IdentificadorFilial,
                                                string IdentificadorProdutoServico, ref Sql objSql)
        {

            objSql.AdicionarParametro("IDPRODUTOFILIAL", Guid.NewGuid(), true);
            objSql.AdicionarParametro("IDPRODUTOSERVICO", IdentificadorProdutoServico);
            objSql.AdicionarParametro("IDFILIAL", IdentificadorFilial);

            if (objProdutoFilial.Comissao == null)
            {
                objSql.AdicionarParametro("IDPRODUTOCOMISSAO", DBNull.Value);
            }
            else
            {
                objSql.AdicionarParametro("IDPRODUTOCOMISSAO", objProdutoFilial.Comissao.Identificador);
            }

            if (objProdutoFilial.UnidadeMediaEstoque == null)
            {
                objSql.AdicionarParametro("IDUNIDADEMEDIDAESTOQUE", DBNull.Value);
            }
            else
            {
                objSql.AdicionarParametro("IDUNIDADEMEDIDAESTOQUE", objProdutoFilial.UnidadeMediaEstoque.Identificador);
            }

            if (objProdutoFilial.UnidadeMedidaVenda == null)
            {
                objSql.AdicionarParametro("IDUNIDADEMEDIDAVENDA", DBNull.Value);
            }
            else
            {
                objSql.AdicionarParametro("IDUNIDADEMEDIDAVENDA", objProdutoFilial.UnidadeMedidaVenda.Identificador);
            }

            if (string.IsNullOrEmpty(objProdutoFilial.DesPrateleira))
            {
                objSql.AdicionarParametro("DESPRATELEIRA", DBNull.Value);
            }
            else
            {
                objSql.AdicionarParametro("DESPRATELEIRA", objProdutoFilial.DesPrateleira);
            }

            if (objProdutoFilial.NumEstoqueMinimo == null)
            {
                objSql.AdicionarParametro("NUMESTOQUEMINIMO", DBNull.Value);
            }
            else
            {
                objSql.AdicionarParametro("NUMESTOQUEMINIMO", objProdutoFilial.NumEstoqueMinimo);
            }

            if (objProdutoFilial.NumMinimoVenda == null)
            {
                objSql.AdicionarParametro("NUMMINIMOVENDA", DBNull.Value);
            }
            else
            {
                objSql.AdicionarParametro("NUMMINIMOVENDA", objProdutoFilial.NumMinimoVenda);
            }

            if (objProdutoFilial.NumIPIPercentual == null)
            {
                objSql.AdicionarParametro("NUMIPIPER", DBNull.Value);
            }
            else
            {
                objSql.AdicionarParametro("NUMIPIPER", objProdutoFilial.NumIPIPercentual);
            }

            if (objProdutoFilial.NumEmbalagemPercentual == null)
            {
                objSql.AdicionarParametro("NUMEMBALAGEMPER", DBNull.Value);
            }
            else
            {
                objSql.AdicionarParametro("NUMEMBALAGEMPER", objProdutoFilial.NumEmbalagemPercentual);
            }

            if (objProdutoFilial.NumFretePercentual == null)
            {
                objSql.AdicionarParametro("NUMFRETEPER", DBNull.Value);
            }
            else
            {
                objSql.AdicionarParametro("NUMFRETEPER", objProdutoFilial.NumFretePercentual);
            }

            if (objProdutoFilial.NumOutrasDespesasPercentual == null)
            {
                objSql.AdicionarParametro("NUMOUTDESPPER", DBNull.Value);
            }
            else
            {
                objSql.AdicionarParametro("NUMOUTDESPPER", objProdutoFilial.NumOutrasDespesasPercentual);
            }
            if (objProdutoFilial.NumValorVendaVarejo == null)
            {
                objSql.AdicionarParametro("NUMVALORVENDAVAREJO", DBNull.Value);
            }
            else
            {
                objSql.AdicionarParametro("NUMVALORVENDAVAREJO", objProdutoFilial.NumValorVendaVarejo);
            }
            if (objProdutoFilial.NumValorVendaAtacado == null)
            {
                objSql.AdicionarParametro("NUMVALORVENDAATACADO", DBNull.Value);
            }
            else
            {
                objSql.AdicionarParametro("NUMVALORVENDAATACADO", objProdutoFilial.NumValorVendaAtacado);
            }
            if (objProdutoFilial.NumQuantidadeVendaAtacado == null)
            {
                objSql.AdicionarParametro("NUMQUANTVENDAATACADO", DBNull.Value);
            }
            else
            {
                objSql.AdicionarParametro("NUMQUANTVENDAATACADO", objProdutoFilial.NumQuantidadeVendaAtacado);
            }
            if (objProdutoFilial.NumDescontoAtacadoPercentual == null)
            {
                objSql.AdicionarParametro("NUMPERCENTDESCONTATAC", DBNull.Value);
            }
            else
            {
                objSql.AdicionarParametro("NUMPERCENTDESCONTATAC", objProdutoFilial.NumDescontoAtacadoPercentual);
            }
            if (objProdutoFilial.UnidadeMedidaVendaVarejo == null)
            {
                objSql.AdicionarParametro("IDUMVALORVENDAVAREJO", DBNull.Value);
            }
            else
            {
                objSql.AdicionarParametro("IDUMVALORVENDAVAREJO", objProdutoFilial.UnidadeMedidaVendaVarejo.Identificador);
            }
            if (objProdutoFilial.UnidadeMedidaVendaAtacado == null)
            {
                objSql.AdicionarParametro("IDUMVALORVENATACADO", DBNull.Value);
            }
            else
            {
                objSql.AdicionarParametro("IDUMVALORVENATACADO", objProdutoFilial.UnidadeMedidaVendaAtacado.Identificador);
            }
            if (objProdutoFilial.UnidadeMedidaQuantidadeVendaAtacado == null)
            {
                objSql.AdicionarParametro("IDUMVENDAATACADO", DBNull.Value);
            }
            else
            {
                objSql.AdicionarParametro("IDUMVENDAATACADO", objProdutoFilial.UnidadeMedidaQuantidadeVendaAtacado.Identificador);
            }

            if (objProdutoFilial.SetorEmpresa == null)
            {
                objSql.AdicionarParametro("IDSETOREMPRESA", DBNull.Value);
            }
            else
            {
                objSql.AdicionarParametro("IDSETOREMPRESA", objProdutoFilial.SetorEmpresa.IdentificadorSetorEmpresa);
            }

            objSql.AdicionarTransacao(Properties.Resources.ProdutoFilialInserir);
        }

        public static void AtualizarProdutoFilial(Comum.Clases.ProdutoFilial objProdutoFilial)
        {

            Sql objSql = new Sql();

            objSql.AdicionarParametro("IDPRODUTOFILIAL", objProdutoFilial.Identificador);

            if (objProdutoFilial.Comissao == null)
            {
                objSql.AdicionarParametro("IDPRODUTOCOMISSAO", DBNull.Value);
            }
            else
            {
                objSql.AdicionarParametro("IDPRODUTOCOMISSAO", objProdutoFilial.Comissao.Identificador);
            }

            if (objProdutoFilial.UnidadeMediaEstoque == null)
            {
                objSql.AdicionarParametro("IDUNIDADEMEDIDAESTOQUE", DBNull.Value);
            }
            else
            {
                objSql.AdicionarParametro("IDUNIDADEMEDIDAESTOQUE", objProdutoFilial.UnidadeMediaEstoque.Identificador);
            }

            if (objProdutoFilial.UnidadeMedidaVenda == null)
            {
                objSql.AdicionarParametro("IDUNIDADEMEDIDAVENDA", DBNull.Value);
            }
            else
            {
                objSql.AdicionarParametro("IDUNIDADEMEDIDAVENDA", objProdutoFilial.UnidadeMedidaVenda.Identificador);
            }

            if (string.IsNullOrEmpty(objProdutoFilial.DesPrateleira))
            {
                objSql.AdicionarParametro("DESPRATELEIRA", DBNull.Value);
            }
            else
            {
                objSql.AdicionarParametro("DESPRATELEIRA", objProdutoFilial.DesPrateleira);
            }

            if (objProdutoFilial.NumEstoqueMinimo == null)
            {
                objSql.AdicionarParametro("NUMESTOQUEMINIMO", DBNull.Value);
            }
            else
            {
                objSql.AdicionarParametro("NUMESTOQUEMINIMO", objProdutoFilial.NumEstoqueMinimo);
            }

            if (objProdutoFilial.NumMinimoVenda == null)
            {
                objSql.AdicionarParametro("NUMMINIMOVENDA", DBNull.Value);
            }
            else
            {
                objSql.AdicionarParametro("NUMMINIMOVENDA", objProdutoFilial.NumMinimoVenda);
            }

            if (objProdutoFilial.NumIPIPercentual == null)
            {
                objSql.AdicionarParametro("NUMIPIPER", DBNull.Value);
            }
            else
            {
                objSql.AdicionarParametro("NUMIPIPER", objProdutoFilial.NumIPIPercentual);
            }

            if (objProdutoFilial.NumEmbalagemPercentual == null)
            {
                objSql.AdicionarParametro("NUMEMBALAGEMPER", DBNull.Value);
            }
            else
            {
                objSql.AdicionarParametro("NUMEMBALAGEMPER", objProdutoFilial.NumEmbalagemPercentual);
            }

            if (objProdutoFilial.NumFretePercentual == null)
            {
                objSql.AdicionarParametro("NUMFRETEPER", DBNull.Value);
            }
            else
            {
                objSql.AdicionarParametro("NUMFRETEPER", objProdutoFilial.NumFretePercentual);
            }

            if (objProdutoFilial.NumOutrasDespesasPercentual == null)
            {
                objSql.AdicionarParametro("NUMOUTDESPPER", DBNull.Value);
            }
            else
            {
                objSql.AdicionarParametro("NUMOUTDESPPER", objProdutoFilial.NumOutrasDespesasPercentual);
            }
            if (objProdutoFilial.NumValorVendaVarejo == null)
            {
                objSql.AdicionarParametro("NUMVALORVENDAVAREJO", DBNull.Value);
            }
            else
            {
                objSql.AdicionarParametro("NUMVALORVENDAVAREJO", objProdutoFilial.NumValorVendaVarejo);
            }
            if (objProdutoFilial.NumValorVendaAtacado == null)
            {
                objSql.AdicionarParametro("NUMVALORVENDAATACADO", DBNull.Value);
            }
            else
            {
                objSql.AdicionarParametro("NUMVALORVENDAATACADO", objProdutoFilial.NumValorVendaAtacado);
            }
            if (objProdutoFilial.NumQuantidadeVendaAtacado == null)
            {
                objSql.AdicionarParametro("NUMQUANTVENDAATACADO", DBNull.Value);
            }
            else
            {
                objSql.AdicionarParametro("NUMQUANTVENDAATACADO", objProdutoFilial.NumQuantidadeVendaAtacado);
            }
            if (objProdutoFilial.NumDescontoAtacadoPercentual == null)
            {
                objSql.AdicionarParametro("NUMPERCENTDESCONTATAC", DBNull.Value);
            }
            else
            {
                objSql.AdicionarParametro("NUMPERCENTDESCONTATAC", objProdutoFilial.NumDescontoAtacadoPercentual);
            }
            if (objProdutoFilial.UnidadeMedidaVendaVarejo == null)
            {
                objSql.AdicionarParametro("IDUMVALORVENDAVAREJO", DBNull.Value);
            }
            else
            {
                objSql.AdicionarParametro("IDUMVALORVENDAVAREJO", objProdutoFilial.UnidadeMedidaVendaVarejo.Identificador);
            }
            if (objProdutoFilial.UnidadeMedidaVendaAtacado == null)
            {
                objSql.AdicionarParametro("IDUMVALORVENATACADO", DBNull.Value);
            }
            else
            {
                objSql.AdicionarParametro("IDUMVALORVENATACADO", objProdutoFilial.UnidadeMedidaVendaAtacado.Identificador);
            }
            if (objProdutoFilial.UnidadeMedidaQuantidadeVendaAtacado == null)
            {
                objSql.AdicionarParametro("IDUMVENDAATACADO", DBNull.Value);
            }
            else
            {
                objSql.AdicionarParametro("IDUMVENDAATACADO", objProdutoFilial.UnidadeMedidaQuantidadeVendaAtacado.Identificador);
            }

            if (objProdutoFilial.SetorEmpresa == null)
            {
                objSql.AdicionarParametro("IDSETOREMPRESA", DBNull.Value);
            }
            else
            {
                objSql.AdicionarParametro("IDSETOREMPRESA", objProdutoFilial.SetorEmpresa.IdentificadorSetorEmpresa);
            }


            
            objSql.ExecutarNonQueryArquivo(Properties.Resources.ProdutoFilialAtualizar, Comum.Clases.Constantes.ARQUIVO_CONEXAO);
        }

        public static Comum.Clases.ProdutoFilial RecuperarProdutoFilial(string IdentificadorProdutoFilia)
        {

            if (string.IsNullOrEmpty(IdentificadorProdutoFilia))
            {
                return null;
            }

            Sql objSql = new Sql();
            Comum.Clases.ProdutoFilial objProdutoFilial = null;

            objSql.AdicionarParametro("IDPRODUTOFILIAL", IdentificadorProdutoFilia);

            DataTable dt = objSql.ExecutarDataTableArquivo(Properties.Resources.ProdutoFilialRecuperarComIdentificador, Comum.Clases.Constantes.ARQUIVO_CONEXAO);

            if (dt != null && dt.Rows.Count > 0)
            {

                objProdutoFilial = new Comum.Clases.ProdutoFilial()
                {
                    Identificador = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["IDPRODUTOFILIAL"], typeof(string)) as string,
                    Comissao = ProdutoComissao.RecuperarProdutoComissao(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["IDPRODUTOCOMISSAO"], typeof(string)) as string),
                    UnidadeMediaEstoque = UnidadesMedida.RecuperarUnidadeMedida(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["IDUNIDADEMEDIDAESTOQUE"], typeof(string)) as string),
                    UnidadeMedidaVenda = UnidadesMedida.RecuperarUnidadeMedida(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["IDUNIDADEMEDIDAVENDA"], typeof(string)) as string),
                    DesPrateleira = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["DESPRATELEIRA"], typeof(string)) as string,
                    NumEmbalagemPercentual = (Nullable<decimal>)(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["NUMEMBALAGEMPER"], typeof(Nullable<decimal>))),
                    NumEstoqueMinimo = (Nullable<decimal>)(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["NUMESTOQUEMINIMO"], typeof(Nullable<decimal>))),
                    NumFretePercentual = (Nullable<decimal>)(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["NUMFRETEPER"], typeof(Nullable<decimal>))),
                    NumIPIPercentual = (Nullable<decimal>)(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["NUMIPIPER"], typeof(Nullable<decimal>))),
                    NumOutrasDespesasPercentual = (Nullable<decimal>)(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["NUMOUTDESPPER"], typeof(Nullable<decimal>))),
                    NumMinimoVenda = (Nullable<decimal>)(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["NUMMINIMOVENDA"], typeof(Nullable<decimal>)))


                };


            }

            return objProdutoFilial;
        }

    }
}
