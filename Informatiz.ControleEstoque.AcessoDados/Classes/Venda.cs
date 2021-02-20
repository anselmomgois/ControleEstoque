using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmgSistemas.Framework.AcessoDados;
using System.Data;
using Informatiz.ControleEstoque.Comum.Extencoes;
using frmUtil = AmgSistemas.Framework.Utilitarios;

namespace Informatiz.ControleEstoque.AcessoDados.Classes
{
    public static class Venda
    {

        public static Comum.Clases.Venda RegistrarVenda(Comum.Clases.Venda Venda, string IdentificadorEmpresa, Boolean TelaComanda)
        {

            Sql objSql = new Sql();
            Comum.Clases.Venda objVenda = null;
            string objQuery = string.Empty;

            if (!string.IsNullOrEmpty(Venda.Identificador))
            {
                objSql.AdicionarParametro("IDVENDA", Venda.Identificador);
            }
            else
            {
                objSql.AdicionarParametro("IDVENDA", DBNull.Value);
            }

            objSql.AdicionarParametro("CODESTADOVENDA", Venda.Estado.RecuperarValor());

            if (Venda.SupervisorCancelamento != null && !string.IsNullOrEmpty(Venda.SupervisorCancelamento.Identificador))
            {
                objSql.AdicionarParametro("IDPESSOACANCELAMENTO", Venda.SupervisorCancelamento.Identificador);
            }
            else
            {
                objSql.AdicionarParametro("IDPESSOACANCELAMENTO", DBNull.Value);
            }


            if (!string.IsNullOrEmpty(Venda.CodigoComanda))
            {
                objSql.AdicionarParametro("CODCOMANDA", Venda.CodigoComanda);
            }
            else
            {
                objSql.AdicionarParametro("CODCOMANDA", DBNull.Value);
            }

            objSql.AdicionarParametro("IDEMPRESA", IdentificadorEmpresa);

            if (Venda.EnderecoEntrega != null && !string.IsNullOrEmpty(Venda.EnderecoEntrega.Identificador))
            {
                objSql.AdicionarParametro("IDENDERECOENTREGA", Venda.EnderecoEntrega.Identificador);
            }
            else
            {
                objSql.AdicionarParametro("IDENDERECOENTREGA", DBNull.Value);
            }

            if (!string.IsNullOrEmpty(Venda.IdentificadorFilial))
            {
                objSql.AdicionarParametro("IDFILIAL", Venda.IdentificadorFilial);
            }
            else
            {
                objSql.AdicionarParametro("IDFILIAL", DBNull.Value);
            }

            if (!string.IsNullOrEmpty(Venda.IdentificadorResponsavelCaixa))
            {
                objSql.AdicionarParametro("IDRESPONSAVELCAIXA", Venda.IdentificadorResponsavelCaixa);
            }
            else
            {
                objSql.AdicionarParametro("IDRESPONSAVELCAIXA", DBNull.Value);
            }

            objSql.AdicionarParametro("NUMQUANTIDADEPESSOAS", Venda.QuantidadePessoas);

            if (Venda.Cliente != null && !string.IsNullOrEmpty(Venda.Cliente.Identificador))
            {
                objSql.AdicionarParametro("IDPESSOACLIENTE", Venda.Cliente.Identificador);
            }
            else
            {
                objSql.AdicionarParametro("IDPESSOACLIENTE", DBNull.Value);
            }

            if (Venda.FuncionarioEntregador != null && !string.IsNullOrEmpty(Venda.FuncionarioEntregador.Identificador))
            {
                objSql.AdicionarParametro("IDPESSOAENTREGADOR", Venda.FuncionarioEntregador.Identificador);
            }
            else
            {
                objSql.AdicionarParametro("IDPESSOAENTREGADOR", DBNull.Value);
            }

            if (!string.IsNullOrEmpty(Venda.Observacao))
            {
                objSql.AdicionarParametro("OBSVENDA", Venda.Observacao);
            }
            else
            {
                objSql.AdicionarParametro("OBSVENDA", DBNull.Value);
            }

            objSql.AdicionarParametro("NUMVALORSERVICO", Venda.ValorServico);
            objSql.AdicionarParametro("NUMVALORTAXAENTREGA", Venda.ValorEntrega);

            if (Venda.ItemRegistrar != null && Venda.ItemRegistrar.Produto != null && !string.IsNullOrEmpty(Venda.ItemRegistrar.Produto.Identificador))
            {
                objSql.AdicionarParametro("IDPRODUTOSERVICO", Venda.ItemRegistrar.Produto.Identificador);
            }
            else
            {
                objSql.AdicionarParametro("IDPRODUTOSERVICO", DBNull.Value);
            }

            if (Venda.ItemRegistrar != null)
            {
                objSql.AdicionarParametro("QUANTIDADE", Venda.ItemRegistrar.Quantidade);
            }
            else
            {
                objSql.AdicionarParametro("QUANTIDADE", DBNull.Value);
            }

            if (Venda.ItemRegistrar != null && Venda.ItemRegistrar.FuncionarioVenda != null && !string.IsNullOrEmpty(Venda.ItemRegistrar.FuncionarioVenda.Identificador))
            {
                objSql.AdicionarParametro("IDPESSOAVENDAITEM", Venda.ItemRegistrar.FuncionarioVenda.Identificador);
            }
            else
            {
                objSql.AdicionarParametro("IDPESSOAVENDAITEM", DBNull.Value);
            }

            if (Venda.ItemRegistrar != null)
            {
                objSql.AdicionarParametro("NUMSEQUENCIA", Venda.ItemRegistrar.Sequencia);
            }
            else
            {
                objSql.AdicionarParametro("NUMSEQUENCIA", DBNull.Value);
            }

            if (Venda.ItemRegistrar != null)
            {
                objSql.AdicionarParametro("NUMVALORACRESCIMO", Venda.ItemRegistrar.Acrescimo);
            }
            else
            {
                objSql.AdicionarParametro("NUMVALORACRESCIMO", DBNull.Value);
            }

            if (Venda.ItemRegistrar != null)
            {
                objSql.AdicionarParametro("NUMVALORDESCONTO", Venda.ItemRegistrar.ValorDesconto);
            }
            else
            {
                objSql.AdicionarParametro("NUMVALORDESCONTO", DBNull.Value);
            }

            if (Venda.ItemRegistrar != null)
            {
                objSql.AdicionarParametro("NUMVALORITEM", Venda.ItemRegistrar.ValorItem);
            }
            else
            {
                objSql.AdicionarParametro("NUMVALORITEM", DBNull.Value);
            }

            if (Venda.ItemRegistrar != null)
            {
                objSql.AdicionarParametro("NUMVALORTOTAL", Venda.ItemRegistrar.ValorTotal);
            }
            else
            {
                objSql.AdicionarParametro("NUMVALORTOTAL", DBNull.Value);
            }

            objSql.AdicionarParametro("BOLCOMANDA", TelaComanda);

            if (Venda.ItemRegistrar != null && Venda.ItemRegistrar.Acrescimos != null && Venda.ItemRegistrar.Acrescimos.Count > 0)
            {
                string IdentificadorProdutoAcrescimo = System.String.Join("|", Venda.ItemRegistrar.Acrescimos.Select(a => a.Identificador).ToArray()).ToString();
                string QuantidadeAcrescimo = System.String.Join("|", Venda.ItemRegistrar.Acrescimos.Select(a => a.Quantidade).ToArray()).ToString();
                string ValorAcrescimo = System.String.Join("|", Venda.ItemRegistrar.Acrescimos.Select(a => a.ValorItem).ToArray()).ToString();
                string ValorTotal = System.String.Join("|", Venda.ItemRegistrar.Acrescimos.Select(a => a.ValorTotal).ToArray()).ToString();

                if (!string.IsNullOrEmpty(IdentificadorProdutoAcrescimo))
                {
                    objSql.AdicionarParametro("IDPRODUTOACRESCIMO", IdentificadorProdutoAcrescimo);
                }
                else
                {
                    objSql.AdicionarParametro("IDPRODUTOACRESCIMO", DBNull.Value);
                }

                if (!string.IsNullOrEmpty(QuantidadeAcrescimo))
                {
                    objSql.AdicionarParametro("NUMQUANTIDADEACRESCIMO", QuantidadeAcrescimo);
                }
                else
                {
                    objSql.AdicionarParametro("NUMQUANTIDADEACRESCIMO", DBNull.Value);
                }

                if (!string.IsNullOrEmpty(ValorAcrescimo))
                {
                    objSql.AdicionarParametro("NUMVALORPRODACRESCIMO", ValorAcrescimo);
                }
                else
                {
                    objSql.AdicionarParametro("NUMVALORPRODACRESCIMO", DBNull.Value);
                }

                if (!string.IsNullOrEmpty(ValorTotal))
                {
                    objSql.AdicionarParametro("NUMVALORTOTALPRODACRESCIMO", ValorTotal);
                }
                else
                {
                    objSql.AdicionarParametro("NUMVALORTOTALPRODACRESCIMO", DBNull.Value);
                }

            }
            else
            {
                objSql.AdicionarParametro("IDPRODUTOACRESCIMO", DBNull.Value);
                objSql.AdicionarParametro("NUMQUANTIDADEACRESCIMO", DBNull.Value);
                objSql.AdicionarParametro("NUMVALORPRODACRESCIMO", DBNull.Value);
                objSql.AdicionarParametro("NUMVALORTOTALPRODACRESCIMO", DBNull.Value);
            }

            if(Venda.ItemRegistrar != null && Venda.ItemRegistrar.Observacoes != null && Venda.ItemRegistrar.Observacoes.Count > 0)
            {
                string IdentificadoresObservacoes = System.String.Join("|", Venda.ItemRegistrar.Observacoes.Select(a => a.Identificador).ToArray()).ToString();

                if (!string.IsNullOrEmpty(IdentificadoresObservacoes))
                {
                    objSql.AdicionarParametro("IDOBSERVACAO", IdentificadoresObservacoes);
                }
                else
                {
                    objSql.AdicionarParametro("IDOBSERVACAO", DBNull.Value);
                }
            }
            else
            {
                objSql.AdicionarParametro("IDOBSERVACAO", DBNull.Value);
            }

            if (Venda.Mesas != null && Venda.Mesas.Count > 0)
            {
                string IdentificadoresObservacoes = System.String.Join("|", Venda.Mesas.Select(a => a.Identificador).ToArray()).ToString();

                if (!string.IsNullOrEmpty(IdentificadoresObservacoes))
                {
                    objSql.AdicionarParametro("IDMESA", IdentificadoresObservacoes);
                }
                else
                {
                    objSql.AdicionarParametro("IDMESA", DBNull.Value);
                }
            }
            else
            {
                objSql.AdicionarParametro("IDMESA", DBNull.Value);
            }

            if (Venda.Atendente != null && !string.IsNullOrEmpty(Venda.Atendente.Identificador))
            {
                objSql.AdicionarParametro("IDPESSOAVENDA", Venda.Atendente.Identificador);
            }
            else
            {
                objSql.AdicionarParametro("IDPESSOAVENDA", DBNull.Value);
            }

            List<string> objNomesTabelas = new List<string>();

            objNomesTabelas.Add("VENDA");


            List<DataTable> dts = objSql.ExecutarDataTablesArquivo("SP_REGISTRAR_VENDA", Comum.Clases.Constantes.ARQUIVO_CONEXAO, CommandType.StoredProcedure, objNomesTabelas);

            objVenda = new Comum.Clases.Venda();
            DataTable dt = null;

            if (dts != null && dts.Count > 0)
            {
                dt = dts[0];
                objVenda.CodigoComanda = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["CODCOMANDA"], typeof(string)) as string;
            }           


            return objVenda;
        }
    }
}
