using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Informatiz.ControleEstoque.API.Entity;
using Informatiz.ControleEstoque.Comum.Extencoes;

namespace Informatiz.ControleEstoque.API.Controllers
{
    [RoutePrefix("api/Venda")]
    public class VendaController : ApiController
    {

        [AcceptVerbs("POST")]
        [Route("SetVenda")]
        [Classes.ValidateModel]
        public ContratoServico.Venda.SetVenda.RespostaSetVenda SetVenda(ContratoServico.Venda.SetVenda.PeticaoSetVenda objEntrada)
        {

            ContratoServico.Venda.SetVenda.RespostaSetVenda objSaida = new ContratoServico.Venda.SetVenda.RespostaSetVenda();

            try
            {

                Comum.Clases.Venda objVenda = AcessoDados.Classes.Venda.RegistrarVenda(objEntrada.Venda, objEntrada.IdentificadorEmpresa, objEntrada.TelaPorComanda);

                if (objEntrada.TelaPorComanda)
                {

                    ContratoServico.Venda.RecuperarVendaPorComanda.RespostaRecuperarVendaPorComanda objSaidaRecuperar = RecuperarVendaPorComanda(new ContratoServico.Venda.RecuperarVendaPorComanda.PeticaoRecuperarVendaPorComanda()
                    {
                        IdentificadorEmpresa = objEntrada.IdentificadorEmpresa,
                        IdentificadorFilial = objEntrada.Venda.IdentificadorFilial,
                        CodigoComanda = objVenda.CodigoComanda,
                        Usuario = objEntrada.Usuario
                    });

                    if (objSaidaRecuperar != null) objSaida.Venda = objSaidaRecuperar.Venda;

                }
                else if (objEntrada.Venda.Estado != Comum.Enumeradores.EstadoVenda.Cancelada)
                {
                    ContratoServico.Venda.RecuperarVendaEmCurso.RespostaRecuperarVendaEmCurso objSaidaRecuperar = RecuperarVendaEmCurso(new ContratoServico.Venda.RecuperarVendaEmCurso.PeticaoRecuperarVendaEmCurso()
                    {
                        IdentificadorEmpresa = objEntrada.IdentificadorEmpresa,
                        IdentificadorResponsavelCaixa = objEntrada.Venda.IdentificadorResponsavelCaixa,
                        Usuario = objEntrada.Usuario
                    });

                    if (objSaidaRecuperar != null) objSaida.Venda = objSaidaRecuperar.Venda;

                }

                objSaida.CodigoErro = Convert.ToInt32(Execao.Constantes.CodigoErro.SEM_ERRO);

            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                objSaida.CodigoErro = (ex.Number == 99001 ? Convert.ToInt32(Execao.Constantes.CodigoErro.ERRO_TRATADO_TELA) : Convert.ToInt32(Execao.Constantes.CodigoErro.ERRO_EXECUCAO));
                objSaida.DescricaoErro = ex.Message;
            }
            catch (Execao.ExecaoNegocio ex)
            {
                objSaida.CodigoErro = Convert.ToInt32(ex.Codigo);
                objSaida.DescricaoErro = ex.Descricao;

            }
            catch (Exception ex)
            {

                objSaida.CodigoErro = Convert.ToInt32(Execao.Constantes.CodigoErro.ERRO_EXECUCAO);
                objSaida.DescricaoErro = "Aconteceu um erro inesperado.";
            }
            return objSaida;
        }

        [AcceptVerbs("POST")]
        [Route("RecuperarVendaEmCurso")]
        [Classes.ValidateModel]
        public ContratoServico.Venda.RecuperarVendaEmCurso.RespostaRecuperarVendaEmCurso RecuperarVendaEmCurso(ContratoServico.Venda.RecuperarVendaEmCurso.PeticaoRecuperarVendaEmCurso objEntrada)
        {

            ContratoServico.Venda.RecuperarVendaEmCurso.RespostaRecuperarVendaEmCurso objSaida = new ContratoServico.Venda.RecuperarVendaEmCurso.RespostaRecuperarVendaEmCurso();

            try
            {
                IGERENCEEntities objBD = new IGERENCEEntities();
                string CodigoEstado = Comum.Enumeradores.EstadoVenda.EmCurso.RecuperarValor();
                string CodigoEstadoItem = Comum.Enumeradores.EstadoItemVenda.Registrado.RecuperarValor();
                objSaida.Venda = (from INFM_VENDA v in objBD.INFM_VENDA
                                  join INFM_RESPONSAVELCAIXA rc in objBD.INFM_RESPONSAVELCAIXA on v.IDRESPONSAVELCAIXA equals rc.IDRESPONSAVELCAIXA
                                  where v.IDRESPONSAVELCAIXA == objEntrada.IdentificadorResponsavelCaixa && v.CODESTADOVENDA == CodigoEstado && v.CODCOMANDA == null
                                  select new Comum.Clases.Venda()
                                  {
                                      Identificador = v.IDVENDA,
                                      Cliente = new Comum.Clases.Pessoa() { Identificador = v.IDPESSOACLIENTE },
                                      DataInicio = v.DTHVENDAINICIO,
                                      Estado = Comum.Enumeradores.EstadoVenda.EmCurso,
                                      FuncionarioCaixa = new Comum.Clases.Pessoa() { Identificador = rc.IDPESSOARESPONSAVEL },
                                      IdentificadorFilial = v.IDFILIAL,
                                      IdentificadorResponsavelCaixa = v.IDRESPONSAVELCAIXA,
                                      ValorDesconto = v.NUMDESCONTO != null ? (decimal)v.NUMDESCONTO : 0,
                                      ValorEntrega = v.NUMVALORTAXAENTREGA != null ? (decimal)v.NUMVALORTAXAENTREGA : 0,
                                      ValorServico = v.NUMVALORSERVICO != null ? (decimal)v.NUMVALORSERVICO : 0,
                                      ValorTotal = v.NUMVALORTOTAL,
                                      ValorVenda = v.NUMVALORVENDA,
                                      Items = (from INFM_ITEMVENDA iv in objBD.INFM_ITEMVENDA
                                               join INFM_PRODUTOSERVICO ps in objBD.INFM_PRODUTOSERVICO on iv.IDPRODUTOSERVICO equals ps.IDPRODUTOSERVICO
                                               where iv.IDVENDA == v.IDVENDA && iv.CODESTADO == CodigoEstadoItem
                                               select new Comum.Clases.ItemVenda()
                                               {
                                                   Cancelado = iv.BOLCANCELADO,
                                                   Identificador = iv.IDITEMVENDA,
                                                   Produto = new Comum.Clases.ProdutoServico()
                                                   {
                                                       Identificador = iv.IDPRODUTOSERVICO,
                                                       Codigo = ps.CODPRODUTO,
                                                       Descricao = ps.DESPRODUTO
                                                   },
                                                   Quantidade = iv.NUMQUANTIDADE != null ? (decimal)iv.NUMQUANTIDADE : 0,
                                                   ValorDesconto = iv.NUMVALORDESCONTO != null ? (decimal)iv.NUMVALORDESCONTO : 0,
                                                   ValorItem = iv.NUMVALORITEM,
                                                   ValorTotal = iv.NUMVALORTOTAL,
                                                   Acrescimos = (from INFM_ITEMVENDAACRESCIMO a in objBD.INFM_ITEMVENDAACRESCIMO
                                                                 join INFM_PRODUTOSERVICO psa in objBD.INFM_PRODUTOSERVICO on a.IDACRESCIMO equals psa.IDPRODUTOSERVICO
                                                                 where a.IDITEMVENDA == iv.IDITEMVENDA
                                                                 select new Comum.Clases.Acrescimo()
                                                                 {
                                                                     Identificador = a.IDACRESCIMO,
                                                                     Codigo = psa.CODPRODUTO,
                                                                     Descricao = psa.DESPRODUTO,
                                                                     Quantidade = a.NUMQUANTIDADE,
                                                                     ValorDesconto = 0,
                                                                     ValorItem = a.NUMVALOR,
                                                                     ValorTotal = a.NUMVALORTOTAL
                                                                 }).ToList(),
                                                   Observacoes = (from INFM_ITEMVENDAOBSERVACAO ivo in objBD.INFM_ITEMVENDAOBSERVACAO
                                                                  join INFM_OBSERVACAO o in objBD.INFM_OBSERVACAO on ivo.IDOBSERVACAO equals o.IDOBSERVACAO
                                                                  where ivo.IDITEMVENDA == iv.IDITEMVENDA
                                                                  select new Comum.Clases.ProdutoObservacao()
                                                                  {
                                                                      Identificador = ivo.IDOBSERVACAO,
                                                                      Descricao = o.DESOBSERVACAO
                                                                  }).ToList(),
                                                   Acrescimo = iv.NUMVALORACRESCIMO != null ? (decimal)iv.NUMVALORACRESCIMO : 0,
                                                   Sequencia = iv.NUMSEQUENCIA != null ? (Int32)iv.NUMSEQUENCIA : 0
                                               }).ToList(),
                                      Pagamentos = (from INFM_PAGAMENTO p in objBD.INFM_PAGAMENTO
                                                    where p.IDVENDA == v.IDVENDA
                                                    select new Comum.Clases.Pagamento()
                                                    {
                                                        Identificador = p.IDPAGAMENTO,
                                                        Valor = p.NUMVALOR,
                                                        IdentificadoresProdutosPagos = (from INFM_ITEMVENDA iv in objBD.INFM_ITEMVENDA
                                                                                        where iv.IDPAGAMENTO == p.IDPAGAMENTO
                                                                                        select iv.IDITEMVENDA).ToList(),
                                                        FormaPagamento = (from INFM_FORMAPAGAMENTO fp in objBD.INFM_FORMAPAGAMENTO
                                                                          where fp.IDFORMAPAGAMENTO == p.IDFORMAPAGAMENTO
                                                                          select new Comum.Clases.FormaPagamento()
                                                                          {
                                                                              Codigo = fp.CODFORMAPAGAMENTO,
                                                                              Descricao = fp.DESFORMAPAGAMENTO,
                                                                              Identificador = fp.IDFORMAPAGAMENTO,
                                                                              PercentualAcrescimo = (fp.NUMPERCENTACRESCIMO != null ? (decimal)fp.NUMPERCENTACRESCIMO : 0),
                                                                              PercentualDesconto = (fp.NUMPERCENTDESCONTO != null ? (decimal)fp.NUMPERCENTDESCONTO : 0),
                                                                              ValorAcrescimo = (fp.NUMVALORACRESCIMO != null ? (decimal)fp.NUMVALORACRESCIMO : 0),
                                                                              ValorDesconto = (fp.NUMVALORDESCONTO != null ? (decimal)fp.NUMVALORDESCONTO : 0)
                                                                          }).FirstOrDefault()
                                                    }).ToList()
                                  }).FirstOrDefault();



                objSaida.CodigoErro = Convert.ToInt32(Execao.Constantes.CodigoErro.SEM_ERRO);

            }
            catch (Execao.ExecaoNegocio ex)
            {
                objSaida.CodigoErro = Convert.ToInt32(ex.Codigo);
                objSaida.DescricaoErro = ex.Descricao;

            }
            catch (Exception ex)
            {
                objSaida.CodigoErro = Convert.ToInt32(Execao.Constantes.CodigoErro.ERRO_EXECUCAO);
                objSaida.DescricaoErro = "Aconteceu um erro inesperado.";
            }
            return objSaida;
        }

        [AcceptVerbs("POST")]
        [Route("RecuperarVendaPorComanda")]
        [Classes.ValidateModel]
        public ContratoServico.Venda.RecuperarVendaPorComanda.RespostaRecuperarVendaPorComanda RecuperarVendaPorComanda(ContratoServico.Venda.RecuperarVendaPorComanda.PeticaoRecuperarVendaPorComanda objEntrada)
        {

            ContratoServico.Venda.RecuperarVendaPorComanda.RespostaRecuperarVendaPorComanda objSaida = new ContratoServico.Venda.RecuperarVendaPorComanda.RespostaRecuperarVendaPorComanda();

            try
            {
                IGERENCEEntities objBD = new IGERENCEEntities();
                string CodigoEstado = Comum.Enumeradores.EstadoVenda.EmCurso.RecuperarValor();
                string CodigoEstadoItem = Comum.Enumeradores.EstadoItemVenda.Registrado.RecuperarValor();

                objSaida.Venda = (from INFM_VENDA v in objBD.INFM_VENDA
                                  where v.CODCOMANDA == objEntrada.CodigoComanda && v.CODESTADOVENDA == CodigoEstado &&
                                        v.IDEMPRESA == objEntrada.IdentificadorEmpresa && v.IDFILIAL == objEntrada.IdentificadorFilial
                                  select new Comum.Clases.Venda()
                                  {
                                      Identificador = v.IDVENDA,
                                      Cliente = new Comum.Clases.Pessoa() { Identificador = v.IDPESSOACLIENTE },
                                      DataInicio = v.DTHVENDAINICIO,
                                      CodigoComanda = v.CODCOMANDA,
                                      Estado = Comum.Enumeradores.EstadoVenda.EmCurso,
                                      FuncionarioCaixa = (from INFM_RESPONSAVELCAIXA rc in objBD.INFM_RESPONSAVELCAIXA
                                                          where rc.IDRESPONSAVELCAIXA == v.IDRESPONSAVELCAIXA
                                                          select new Comum.Clases.Pessoa()
                                                          {
                                                              Identificador = rc.IDPESSOARESPONSAVEL
                                                          }).FirstOrDefault(),
                                      Atendente = (from p in objBD.INFM_PESSOA
                                                   where p.IDPESSOA == v.IDPESSOAVENDA
                                                   select new Comum.Clases.Geral()
                                                   {
                                                       Identificador = p.IDPESSOA,
                                                       Codigo = p.CODPESSOA.ToString(),
                                                       Descricao = p.DESNOME
                                                   }).FirstOrDefault(),
                                      Mesas = (from mv in objBD.INFM_MESAVENDA
                                               join m in objBD.INFM_MESA on mv.IDMESA equals m.IDMESA
                                               where mv.IDVENDA == v.IDVENDA
                                               select new Comum.Clases.Mesa()
                                               {
                                                   Codigo = m.CODMESA,
                                                   Identificador = m.IDMESA
                                               }).ToList(),
                                      IdentificadorFilial = v.IDFILIAL,
                                      IdentificadorResponsavelCaixa = v.IDRESPONSAVELCAIXA,
                                      ValorDesconto = v.NUMDESCONTO != null ? (decimal)v.NUMDESCONTO : 0,
                                      ValorEntrega = v.NUMVALORTAXAENTREGA != null ? (decimal)v.NUMVALORTAXAENTREGA : 0,
                                      ValorServico = v.NUMVALORSERVICO != null ? (decimal)v.NUMVALORSERVICO : 0,
                                      ValorTotal = v.NUMVALORTOTAL,
                                      ValorVenda = v.NUMVALORVENDA,
                                      Items = (from INFM_ITEMVENDA iv in objBD.INFM_ITEMVENDA
                                               join INFM_PRODUTOSERVICO ps in objBD.INFM_PRODUTOSERVICO on iv.IDPRODUTOSERVICO equals ps.IDPRODUTOSERVICO
                                               where iv.IDVENDA == v.IDVENDA && iv.CODESTADO == CodigoEstadoItem
                                               select new Comum.Clases.ItemVenda()
                                               {
                                                   Cancelado = iv.BOLCANCELADO,
                                                   Identificador = iv.IDITEMVENDA,
                                                   Produto = new Comum.Clases.ProdutoServico()
                                                   {
                                                       Identificador = iv.IDPRODUTOSERVICO,
                                                       Codigo = ps.CODPRODUTO,
                                                       Descricao = ps.DESPRODUTO
                                                   },
                                                   Quantidade = iv.NUMQUANTIDADE != null ? (decimal)iv.NUMQUANTIDADE : 0,
                                                   ValorDesconto = iv.NUMVALORDESCONTO != null ? (decimal)iv.NUMVALORDESCONTO : 0,
                                                   ValorItem = iv.NUMVALORITEM,
                                                   ValorTotal = iv.NUMVALORTOTAL,
                                                   Acrescimos = (from INFM_ITEMVENDAACRESCIMO a in objBD.INFM_ITEMVENDAACRESCIMO
                                                                 join INFM_PRODUTOSERVICO psa in objBD.INFM_PRODUTOSERVICO on a.IDACRESCIMO equals psa.IDPRODUTOSERVICO
                                                                 where a.IDITEMVENDA == iv.IDITEMVENDA
                                                                 select new Comum.Clases.Acrescimo()
                                                                 {
                                                                     Identificador = a.IDACRESCIMO,
                                                                     Codigo = psa.CODPRODUTO,
                                                                     Descricao = psa.DESPRODUTO,
                                                                     Quantidade = a.NUMQUANTIDADE,
                                                                     ValorDesconto = 0,
                                                                     ValorItem = a.NUMVALOR,
                                                                     ValorTotal = a.NUMVALORTOTAL
                                                                 }).ToList(),
                                                   Observacoes = (from INFM_ITEMVENDAOBSERVACAO ivo in objBD.INFM_ITEMVENDAOBSERVACAO
                                                                  join INFM_OBSERVACAO o in objBD.INFM_OBSERVACAO on ivo.IDOBSERVACAO equals o.IDOBSERVACAO
                                                                  where ivo.IDITEMVENDA == iv.IDITEMVENDA
                                                                  select new Comum.Clases.ProdutoObservacao()
                                                                  {
                                                                      Identificador = ivo.IDOBSERVACAO,
                                                                      Descricao = o.DESOBSERVACAO
                                                                  }).ToList(),
                                                   Acrescimo = iv.NUMVALORACRESCIMO != null ? (decimal)iv.NUMVALORACRESCIMO : 0,
                                                   Sequencia = iv.NUMSEQUENCIA != null ? (Int32)iv.NUMSEQUENCIA : 0
                                               }).ToList(),
                                      Pagamentos = (from INFM_PAGAMENTO p in objBD.INFM_PAGAMENTO
                                                    where p.IDVENDA == v.IDVENDA
                                                    select new Comum.Clases.Pagamento()
                                                    {
                                                        Identificador = p.IDPAGAMENTO,
                                                        Valor = p.NUMVALOR,
                                                        IdentificadoresProdutosPagos = (from INFM_ITEMVENDA iv in objBD.INFM_ITEMVENDA
                                                                                        where iv.IDPAGAMENTO == p.IDPAGAMENTO
                                                                                        select iv.IDITEMVENDA).ToList(),
                                                        FormaPagamento = (from INFM_FORMAPAGAMENTO fp in objBD.INFM_FORMAPAGAMENTO
                                                                          where fp.IDFORMAPAGAMENTO == p.IDFORMAPAGAMENTO
                                                                          select new Comum.Clases.FormaPagamento()
                                                                          {
                                                                              Codigo = fp.CODFORMAPAGAMENTO,
                                                                              Descricao = fp.DESFORMAPAGAMENTO,
                                                                              Identificador = fp.IDFORMAPAGAMENTO,
                                                                              PercentualAcrescimo = (fp.NUMPERCENTACRESCIMO != null ? (decimal)fp.NUMPERCENTACRESCIMO : 0),
                                                                              PercentualDesconto = (fp.NUMPERCENTDESCONTO != null ? (decimal)fp.NUMPERCENTDESCONTO : 0),
                                                                              ValorAcrescimo = (fp.NUMVALORACRESCIMO != null ? (decimal)fp.NUMVALORACRESCIMO : 0),
                                                                              ValorDesconto = (fp.NUMVALORDESCONTO != null ? (decimal)fp.NUMVALORDESCONTO : 0)
                                                                          }).FirstOrDefault()
                                                    }).ToList()
                                  }).FirstOrDefault();



                objSaida.CodigoErro = Convert.ToInt32(Execao.Constantes.CodigoErro.SEM_ERRO);

            }
            catch (Execao.ExecaoNegocio ex)
            {
                objSaida.CodigoErro = Convert.ToInt32(ex.Codigo);
                objSaida.DescricaoErro = ex.Descricao;

            }
            catch (Exception ex)
            {
                objSaida.CodigoErro = Convert.ToInt32(Execao.Constantes.CodigoErro.ERRO_EXECUCAO);
                objSaida.DescricaoErro = "Aconteceu um erro inesperado.";
            }
            return objSaida;
        }

        [AcceptVerbs("POST")]
        [Route("RecuperarVendaPorMesa")]
        [Classes.ValidateModel]
        public ContratoServico.Venda.RecuperarVendaPorMesa.RespostaRecuperarVendaPorMesa RecuperarVendaPorMesa(ContratoServico.Venda.RecuperarVendaPorMesa.PeticaoRecuperarVendaPorMesa objEntrada)
        {

            ContratoServico.Venda.RecuperarVendaPorMesa.RespostaRecuperarVendaPorMesa objSaida = new ContratoServico.Venda.RecuperarVendaPorMesa.RespostaRecuperarVendaPorMesa();

            try
            {
                IGERENCEEntities objBD = new IGERENCEEntities();
                string CodigoEstado = Comum.Enumeradores.EstadoVenda.EmCurso.RecuperarValor();
                string CodigoEstadoItem = Comum.Enumeradores.EstadoItemVenda.Registrado.RecuperarValor();

                objSaida.Venda = (from INFM_VENDA v in objBD.INFM_VENDA
                                  join INFM_MESAVENDA mv in objBD.INFM_MESAVENDA on v.IDVENDA equals mv.IDVENDA
                                  join INFM_MESA m in objBD.INFM_MESA on mv.IDMESA equals m.IDMESA
                                  where m.CODMESA == objEntrada.CodigoMesa && v.CODESTADOVENDA == CodigoEstado &&
                                        v.IDEMPRESA == objEntrada.IdentificadorEmpresa && v.IDFILIAL == objEntrada.IdentificadorFilial
                                  select new Comum.Clases.Venda()
                                  {
                                      Identificador = v.IDVENDA,
                                      Cliente = new Comum.Clases.Pessoa() { Identificador = v.IDPESSOACLIENTE },
                                      DataInicio = v.DTHVENDAINICIO,
                                      CodigoComanda = v.CODCOMANDA,
                                      Estado = Comum.Enumeradores.EstadoVenda.EmCurso,
                                      FuncionarioCaixa = (from INFM_RESPONSAVELCAIXA rc in objBD.INFM_RESPONSAVELCAIXA
                                                          where rc.IDRESPONSAVELCAIXA == v.IDRESPONSAVELCAIXA
                                                          select new Comum.Clases.Pessoa()
                                                          {
                                                              Identificador = rc.IDPESSOARESPONSAVEL
                                                          }).FirstOrDefault(),
                                      Atendente = (from p in objBD.INFM_PESSOA
                                                   where p.IDPESSOA == v.IDPESSOAVENDA
                                                   select new Comum.Clases.Geral()
                                                   {
                                                       Identificador = p.IDPESSOA,
                                                       Codigo = p.CODPESSOA.ToString(),
                                                       Descricao = p.DESNOME
                                                   }).FirstOrDefault(),
                                      Mesas = (from mv in objBD.INFM_MESAVENDA
                                               join m in objBD.INFM_MESA on mv.IDMESA equals m.IDMESA
                                               where mv.IDVENDA == v.IDVENDA
                                               select new Comum.Clases.Mesa()
                                               {
                                                   Codigo = m.CODMESA,
                                                   Identificador = m.IDMESA
                                               }).ToList(),
                                      IdentificadorFilial = v.IDFILIAL,
                                      IdentificadorResponsavelCaixa = v.IDRESPONSAVELCAIXA,
                                      ValorDesconto = v.NUMDESCONTO != null ? (decimal)v.NUMDESCONTO : 0,
                                      ValorEntrega = v.NUMVALORTAXAENTREGA != null ? (decimal)v.NUMVALORTAXAENTREGA : 0,
                                      ValorServico = v.NUMVALORSERVICO != null ? (decimal)v.NUMVALORSERVICO : 0,
                                      ValorTotal = v.NUMVALORTOTAL,
                                      ValorVenda = v.NUMVALORVENDA,
                                      Items = (from INFM_ITEMVENDA iv in objBD.INFM_ITEMVENDA
                                               join INFM_PRODUTOSERVICO ps in objBD.INFM_PRODUTOSERVICO on iv.IDPRODUTOSERVICO equals ps.IDPRODUTOSERVICO
                                               where iv.IDVENDA == v.IDVENDA && iv.CODESTADO == CodigoEstadoItem
                                               select new Comum.Clases.ItemVenda()
                                               {
                                                   Cancelado = iv.BOLCANCELADO,
                                                   Identificador = iv.IDITEMVENDA,
                                                   Produto = new Comum.Clases.ProdutoServico()
                                                   {
                                                       Identificador = iv.IDPRODUTOSERVICO,
                                                       Codigo = ps.CODPRODUTO,
                                                       Descricao = ps.DESPRODUTO
                                                   },
                                                   Quantidade = iv.NUMQUANTIDADE != null ? (decimal)iv.NUMQUANTIDADE : 0,
                                                   ValorDesconto = iv.NUMVALORDESCONTO != null ? (decimal)iv.NUMVALORDESCONTO : 0,
                                                   ValorItem = iv.NUMVALORITEM,
                                                   ValorTotal = iv.NUMVALORTOTAL,
                                                   Acrescimos = (from INFM_ITEMVENDAACRESCIMO a in objBD.INFM_ITEMVENDAACRESCIMO
                                                                 join INFM_PRODUTOSERVICO psa in objBD.INFM_PRODUTOSERVICO on a.IDACRESCIMO equals psa.IDPRODUTOSERVICO
                                                                 where a.IDITEMVENDA == iv.IDITEMVENDA
                                                                 select new Comum.Clases.Acrescimo()
                                                                 {
                                                                     Identificador = a.IDACRESCIMO,
                                                                     Codigo = psa.CODPRODUTO,
                                                                     Descricao = psa.DESPRODUTO,
                                                                     Quantidade = a.NUMQUANTIDADE,
                                                                     ValorDesconto = 0,
                                                                     ValorItem = a.NUMVALOR,
                                                                     ValorTotal = a.NUMVALORTOTAL
                                                                 }).ToList(),
                                                   Observacoes = (from INFM_ITEMVENDAOBSERVACAO ivo in objBD.INFM_ITEMVENDAOBSERVACAO
                                                                  join INFM_OBSERVACAO o in objBD.INFM_OBSERVACAO on ivo.IDOBSERVACAO equals o.IDOBSERVACAO
                                                                  where ivo.IDITEMVENDA == iv.IDITEMVENDA
                                                                  select new Comum.Clases.ProdutoObservacao()
                                                                  {
                                                                      Identificador = ivo.IDOBSERVACAO,
                                                                      Descricao = o.DESOBSERVACAO
                                                                  }).ToList(),
                                                   Acrescimo = iv.NUMVALORACRESCIMO != null ? (decimal)iv.NUMVALORACRESCIMO : 0,
                                                   Sequencia = iv.NUMSEQUENCIA != null ? (Int32)iv.NUMSEQUENCIA : 0
                                               }).ToList(),
                                      Pagamentos = (from INFM_PAGAMENTO p in objBD.INFM_PAGAMENTO
                                                    where p.IDVENDA == v.IDVENDA
                                                    select new Comum.Clases.Pagamento()
                                                    {
                                                        Identificador = p.IDPAGAMENTO,
                                                        Valor = p.NUMVALOR,
                                                        IdentificadoresProdutosPagos = (from INFM_ITEMVENDA iv in objBD.INFM_ITEMVENDA
                                                                                        where iv.IDPAGAMENTO == p.IDPAGAMENTO
                                                                                        select iv.IDITEMVENDA).ToList(),
                                                        FormaPagamento = (from INFM_FORMAPAGAMENTO fp in objBD.INFM_FORMAPAGAMENTO
                                                                          where fp.IDFORMAPAGAMENTO == p.IDFORMAPAGAMENTO
                                                                          select new Comum.Clases.FormaPagamento()
                                                                          {
                                                                              Codigo = fp.CODFORMAPAGAMENTO,
                                                                              Descricao = fp.DESFORMAPAGAMENTO,
                                                                              Identificador = fp.IDFORMAPAGAMENTO,
                                                                              PercentualAcrescimo = (fp.NUMPERCENTACRESCIMO != null ? (decimal)fp.NUMPERCENTACRESCIMO : 0),
                                                                              PercentualDesconto = (fp.NUMPERCENTDESCONTO != null ? (decimal)fp.NUMPERCENTDESCONTO : 0),
                                                                              ValorAcrescimo = (fp.NUMVALORACRESCIMO != null ? (decimal)fp.NUMVALORACRESCIMO : 0),
                                                                              ValorDesconto = (fp.NUMVALORDESCONTO != null ? (decimal)fp.NUMVALORDESCONTO : 0)
                                                                          }).FirstOrDefault()
                                                    }).ToList()
                                  }).FirstOrDefault();



                objSaida.CodigoErro = Convert.ToInt32(Execao.Constantes.CodigoErro.SEM_ERRO);

            }
            catch (Execao.ExecaoNegocio ex)
            {
                objSaida.CodigoErro = Convert.ToInt32(ex.Codigo);
                objSaida.DescricaoErro = ex.Descricao;

            }
            catch (Exception ex)
            {
                objSaida.CodigoErro = Convert.ToInt32(Execao.Constantes.CodigoErro.ERRO_EXECUCAO);
                objSaida.DescricaoErro = "Aconteceu um erro inesperado.";
            }
            return objSaida;
        }

        [AcceptVerbs("POST")]
        [Route("RecuperarPagamentosCaixa")]
        [Classes.ValidateModel]
        public ContratoServico.Venda.RecuperarPagamentosCaixa.RespostaRecuperarPagamentosCaixa RecuperarPagamentosCaixa(ContratoServico.Venda.RecuperarPagamentosCaixa.PeticaoRecuperarPagamentosCaixa objEntrada)
        {

            ContratoServico.Venda.RecuperarPagamentosCaixa.RespostaRecuperarPagamentosCaixa objSaida = new ContratoServico.Venda.RecuperarPagamentosCaixa.RespostaRecuperarPagamentosCaixa();

            try
            {
                IGERENCEEntities objBD = new IGERENCEEntities();
                string CodigoEstado = Comum.Enumeradores.EstadoVenda.Finalizada.RecuperarValor();

                string TipoCartao = Comum.Enumeradores.TipoPagamento.Cartao.RecuperarValor();
                string TipoEfetivo = Comum.Enumeradores.TipoPagamento.Efetivo.RecuperarValor();
                string TipoPrePago = Comum.Enumeradores.TipoPagamento.PrePago.RecuperarValor();

                objSaida.Vendas = (from INFM_VENDA v in objBD.INFM_VENDA
                                   join INFM_RESPONSAVELCAIXA rc in objBD.INFM_RESPONSAVELCAIXA on v.IDRESPONSAVELCAIXA equals rc.IDRESPONSAVELCAIXA
                                   where v.IDRESPONSAVELCAIXA == objEntrada.IdentificadorResponsavelCaixa && v.CODESTADOVENDA == CodigoEstado
                                   select new Comum.Clases.Venda()
                                   {
                                       Identificador = v.IDVENDA,
                                       CodigoVenda = v.CODVENDA.ToString(),
                                       Cliente = new Comum.Clases.Pessoa() { Identificador = v.IDPESSOACLIENTE },
                                       DataInicio = v.DTHVENDAINICIO,
                                       Estado = Comum.Enumeradores.EstadoVenda.EmCurso,
                                       FuncionarioCaixa = new Comum.Clases.Pessoa() { Identificador = rc.IDPESSOARESPONSAVEL },
                                       IdentificadorFilial = v.IDFILIAL,
                                       IdentificadorResponsavelCaixa = v.IDRESPONSAVELCAIXA,
                                       ValorDesconto = v.NUMDESCONTO != null ? (decimal)v.NUMDESCONTO : 0,
                                       ValorEntrega = v.NUMVALORTAXAENTREGA != null ? (decimal)v.NUMVALORTAXAENTREGA : 0,
                                       ValorServico = v.NUMVALORSERVICO != null ? (decimal)v.NUMVALORSERVICO : 0,
                                       ValorTotal = v.NUMVALORTOTAL,
                                       ValorVenda = v.NUMVALORVENDA,
                                       ValorTroco = v.NUMTROCO != null ? (decimal)v.NUMTROCO : 0,
                                       Pagamentos = (from INFM_PAGAMENTO p in objBD.INFM_PAGAMENTO
                                                     where p.IDVENDA == v.IDVENDA
                                                     select new Comum.Clases.Pagamento()
                                                     {
                                                         Identificador = p.IDPAGAMENTO,
                                                         Valor = p.NUMVALOR,
                                                         IdentificadoresProdutosPagos = (from INFM_ITEMVENDA iv in objBD.INFM_ITEMVENDA
                                                                                         where iv.IDPAGAMENTO == p.IDPAGAMENTO
                                                                                         select iv.IDITEMVENDA).ToList(),
                                                         FormaPagamento = (from INFM_FORMAPAGAMENTO fp in objBD.INFM_FORMAPAGAMENTO
                                                                           where fp.IDFORMAPAGAMENTO == p.IDFORMAPAGAMENTO
                                                                           select new Comum.Clases.FormaPagamento()
                                                                           {
                                                                               Codigo = fp.CODFORMAPAGAMENTO,
                                                                               Descricao = fp.DESFORMAPAGAMENTO,
                                                                               Identificador = fp.IDFORMAPAGAMENTO,
                                                                               PercentualAcrescimo = (fp.NUMPERCENTACRESCIMO != null ? (decimal)fp.NUMPERCENTACRESCIMO : 0),
                                                                               PercentualDesconto = (fp.NUMPERCENTDESCONTO != null ? (decimal)fp.NUMPERCENTDESCONTO : 0),
                                                                               ValorAcrescimo = (fp.NUMVALORACRESCIMO != null ? (decimal)fp.NUMVALORACRESCIMO : 0),
                                                                               ValorDesconto = (fp.NUMVALORDESCONTO != null ? (decimal)fp.NUMVALORDESCONTO : 0),
                                                                               TipoPagamento = (fp.CODTIPOPAGAMENTO == TipoEfetivo ? Comum.Enumeradores.TipoPagamento.Efetivo :
                                                                                                (fp.CODTIPOPAGAMENTO == TipoCartao ? Comum.Enumeradores.TipoPagamento.Cartao :
                                                                                                (fp.CODTIPOPAGAMENTO == TipoPrePago ? Comum.Enumeradores.TipoPagamento.PrePago : Comum.Enumeradores.TipoPagamento.Nulo)))
                                                                           }).FirstOrDefault()
                                                     }).ToList()
                                   }).ToList();

                objSaida.Sangrias = (from INFM_SANGRIA s in objBD.INFM_SANGRIA
                                     where s.IDRESPONSAVELCAIXA == objEntrada.IdentificadorResponsavelCaixa
                                     select new Comum.Clases.Sangria()
                                     {
                                         Identificador = s.IDSANGRIA,
                                         IdentificadorResponsavelCaixa = s.IDRESPONSAVELCAIXA,
                                         Valor = s.NUMVALORSANGRIA
                                     }).ToList();
                objSaida.Suprimentos = (from INFM_SUPRIMENTO s in objBD.INFM_SUPRIMENTO
                                        where s.IDRESPONSAVELCAIXA == objEntrada.IdentificadorResponsavelCaixa
                                        select new Comum.Clases.Suprimento()
                                        {
                                            Identificador = s.IDSUPRIMENTO,
                                            IdentificadorResponsavelCaixa = s.IDRESPONSAVELCAIXA,
                                            Valor = s.NUMVALORSUPRIMENTO
                                        }).ToList();

                objSaida.SaldoInicial = (from INFM_RESPONSAVELCAIXA rc in objBD.INFM_RESPONSAVELCAIXA
                                         where rc.IDRESPONSAVELCAIXA == objEntrada.IdentificadorResponsavelCaixa
                                         select rc.NUMVALORINICIAL).FirstOrDefault();

                if (objSaida.Vendas != null && objSaida.Vendas.Count > 0)
                {
                    objSaida.Vendas.ForEach(v => v.CodigoVenda = v.CodigoVenda.PadLeft(15, Convert.ToChar("0")));
                }

                objSaida.CodigoErro = Convert.ToInt32(Execao.Constantes.CodigoErro.SEM_ERRO);

            }
            catch (Execao.ExecaoNegocio ex)
            {
                objSaida.CodigoErro = Convert.ToInt32(ex.Codigo);
                objSaida.DescricaoErro = ex.Descricao;

            }
            catch (Exception ex)
            {
                objSaida.CodigoErro = Convert.ToInt32(Execao.Constantes.CodigoErro.ERRO_EXECUCAO);
                objSaida.DescricaoErro = "Aconteceu um erro inesperado.";
            }
            return objSaida;
        }

        [AcceptVerbs("POST")]
        [Route("FecharVenda")]
        [Classes.ValidateModel]
        public ContratoServico.Venda.FecharVenda.RespostaFecharVenda FecharVenda(ContratoServico.Venda.FecharVenda.PeticaoFecharVenda Peticao)
        {

            ContratoServico.Venda.FecharVenda.RespostaFecharVenda objSaida = new ContratoServico.Venda.FecharVenda.RespostaFecharVenda();

            try
            {
                IGERENCEEntities objBD = new IGERENCEEntities();

                INFM_VENDA objVenda = (from INFM_VENDA v in objBD.INFM_VENDA where v.IDVENDA == Peticao.IdentificadorVenda select v).FirstOrDefault();

                if (objVenda != null)
                {

                    INFM_RESPONSAVELCAIXA objResponsavelCaixa = objBD.INFM_RESPONSAVELCAIXA.FirstOrDefault(rc => rc.IDRESPONSAVELCAIXA == Peticao.IdentificadorResponsavelCaixa);

                    foreach (var p in Peticao.Pagamentos)
                    {
                        if (!objBD.INFM_PAGAMENTO.Where(pg => pg.IDPAGAMENTO == p.Identificador).Any())
                        {

                            string IdentificadorPagamento = Guid.NewGuid().ToString();

                            p.Identificador = IdentificadorPagamento;

                            INFM_PAGAMENTO objPagamento = new INFM_PAGAMENTO()
                            {
                                IDFORMAPAGAMENTO = p.FormaPagamento.Identificador,
                                IDPAGAMENTO = IdentificadorPagamento,
                                IDVENDA = Peticao.IdentificadorVenda,
                                NUMVALOR = p.Valor,
                                IDRESPONSAVELCAIXA = Peticao.IdentificadorResponsavelCaixa
                            };

                            objBD.INFM_PAGAMENTO.Add(objPagamento);

                            if (p.FormaPagamento.TipoPagamento == Comum.Enumeradores.TipoPagamento.Efetivo)
                            {
                                objResponsavelCaixa.NUMSALDO += Peticao.ValorTotalVenda;
                            }

                            if (p.IdentificadoresProdutosPagos != null && p.IdentificadoresProdutosPagos.Count > 0)
                            {
                                foreach (var pp in p.IdentificadoresProdutosPagos)
                                {

                                    INFM_ITEMVENDA objItemVenda = objBD.INFM_ITEMVENDA.Where(iv => iv.IDITEMVENDA == pp).FirstOrDefault();

                                    if (objItemVenda != null)
                                    {
                                        objItemVenda.IDPAGAMENTO = IdentificadorPagamento;
                                    }
                                }
                            }

                        }
                    }

                    if (!string.IsNullOrEmpty(Peticao.IdentificadorVendedor))
                    {
                        var ItemsVenda = (from INFM_ITEMVENDA iv in objBD.INFM_ITEMVENDA where iv.IDVENDA == objVenda.IDVENDA select iv).ToList();

                        foreach (var iv in ItemsVenda)
                        {
                            iv.IDPESSOAVENDA = Peticao.IdentificadorVendedor;
                        }
                    }



                    if (!Peticao.PagamentoParcial)
                    {
                        objVenda.CODESTADOVENDA = Comum.Enumeradores.EstadoVenda.Finalizada.RecuperarValor();
                        objVenda.COD_ESTADO = Comum.Enumeradores.EstadoVenda.Finalizada.RecuperarValor();
                        objVenda.DTHVENDAFIM = DateTime.Now;
                        objVenda.IDPESSOACLIENTE = !string.IsNullOrEmpty(Peticao.IdentificadorCliente) ? Peticao.IdentificadorCliente : null;
                        objVenda.NUMACRESCIMO = Peticao.ValorAcrescimo;
                        objVenda.NUMDESCONTO = Peticao.ValorDesconto;

                        if (Peticao.ValorTotalVenda != objVenda.NUMVALORTOTAL) objVenda.NUMVALORTOTAL = Peticao.ValorTotalVenda;

                        if (Peticao.Pagamentos != null && Peticao.Pagamentos.Count > 0)
                        {

                            var Somatorio = from Comum.Clases.Pagamento p in Peticao.Pagamentos
                                            group p by p.FormaPagamento.Codigo into Soma
                                            select new
                                            {
                                                FormaPagamento = Soma.First().FormaPagamento.Descricao,
                                                Total = Soma.Sum(su => su.Valor),
                                                Identificador = Soma.First().FormaPagamento.Identificador
                                            };




                            decimal ValorPagamentos = Peticao.Pagamentos.Sum(s => s.Valor);


                            if (Peticao.FormasPagamento != null && Peticao.FormasPagamento.Count > 0 && ValorPagamentos > objVenda.NUMVALORTOTAL)
                            {
                                Comum.Clases.FormaPagamento objFormaPagamentoEfetivo = Peticao.FormasPagamento.Find(fp => fp.TipoPagamento == Comum.Enumeradores.TipoPagamento.Efetivo);

                                if (objFormaPagamentoEfetivo != null)
                                {
                                    var SomatorioEfetivo = (from s in Somatorio where s.Identificador == objFormaPagamentoEfetivo.Identificador select s).FirstOrDefault();

                                    if (SomatorioEfetivo != null)
                                    {
                                        decimal troco = ValorPagamentos - objVenda.NUMVALORTOTAL;
                                        objSaida.Troco = troco;
                                        objVenda.NUMTROCO = troco;
                                    }
                                }
                            }



                        }

                        List<INFM_MESA> objMesas = (from INFM_MESA m in objBD.INFM_MESA
                                                    join INFM_MESAVENDA mv in objBD.INFM_MESAVENDA on m.IDMESA equals mv.IDMESA
                                                    where mv.IDVENDA == Peticao.IdentificadorVenda
                                                    select m).ToList();

                        if(objMesas != null && objMesas.Count > 0)
                        {
                            foreach( var m in objMesas)
                            {
                                m.CODESTADO = Comum.Enumeradores.EstadoMesa.Livre.RecuperarValor();
                            }
                        }

                    }

                    if (!string.IsNullOrEmpty(Peticao.IdentificadorCliente))
                    {
                        objVenda.IDPESSOACLIENTE = Peticao.IdentificadorCliente;
                    }

                    objBD.SaveChanges();

                    objSaida.SaldoCaixa = objResponsavelCaixa.NUMSALDO;
                    objSaida.Pagamentos = Peticao.Pagamentos;
                }

                objSaida.CodigoErro = Convert.ToInt32(Execao.Constantes.CodigoErro.SEM_ERRO);


            }
            catch (Execao.ExecaoNegocio ex)
            {
                objSaida.CodigoErro = Convert.ToInt32(ex.Codigo);
                objSaida.DescricaoErro = ex.Descricao;
                objSaida.Troco = 0;

            }
            catch (Exception ex)
            {

                objSaida.CodigoErro = Convert.ToInt32(Execao.Constantes.CodigoErro.ERRO_EXECUCAO);
                objSaida.DescricaoErro = "Aconteceu um erro inesperado.";
                objSaida.Troco = 0;

            }
            return objSaida;
        }

        [AcceptVerbs("POST")]
        [Route("RegistrarSangria")]
        [Classes.ValidateModel]
        public ContratoServico.Venda.RegistrarSangria.RespostaRegistrarSangria RegistrarSangria(ContratoServico.Venda.RegistrarSangria.PeticaoRegistrarSangria Peticao)
        {

            ContratoServico.Venda.RegistrarSangria.RespostaRegistrarSangria objSaida = new ContratoServico.Venda.RegistrarSangria.RespostaRegistrarSangria();
            decimal Saldo = 0;

            try
            {
                IGERENCEEntities objBD = new IGERENCEEntities();

                if (Peticao.Sangria != null)
                {

                    INFM_SANGRIA objSangria = new INFM_SANGRIA()
                    {
                        IDPESSOASUPERVISOR = Peticao.Sangria.IdentificadorSupervisor,
                        IDRESPONSAVELCAIXA = Peticao.Sangria.IdentificadorResponsavelCaixa,
                        IDSANGRIA = Guid.NewGuid().ToString(),
                        NUMVALORSANGRIA = Peticao.Sangria.Valor,
                        OBSSANGRIA = Peticao.Sangria.Observacao
                    };

                    objBD.INFM_SANGRIA.Add(objSangria);

                    INFM_RESPONSAVELCAIXA objResponsavelCaixa = (from rc in objBD.INFM_RESPONSAVELCAIXA
                                                                 where rc.IDRESPONSAVELCAIXA == Peticao.Sangria.IdentificadorResponsavelCaixa &&
                                                                       rc.DTHFIMOPERACAO == null
                                                                 select rc).FirstOrDefault();

                    if (objResponsavelCaixa != null)
                    {
                        objResponsavelCaixa.NUMSALDO -= Peticao.Sangria.Valor;
                        Saldo = objResponsavelCaixa.NUMSALDO;
                    }
                    else
                    {
                        throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "Não foi detectado caixa em operação para realizar a sangria.");
                    }

                }

                objBD.SaveChanges();

                objSaida.Saldo = Saldo;
                objSaida.CodigoErro = Convert.ToInt32(Execao.Constantes.CodigoErro.SEM_ERRO);


            }
            catch (Execao.ExecaoNegocio ex)
            {
                objSaida.CodigoErro = Convert.ToInt32(ex.Codigo);
                objSaida.DescricaoErro = ex.Descricao;

            }
            catch (Exception ex)
            {

                objSaida.CodigoErro = Convert.ToInt32(Execao.Constantes.CodigoErro.ERRO_EXECUCAO);
                objSaida.DescricaoErro = "Aconteceu um erro inesperado.";

            }
            return objSaida;
        }

        [AcceptVerbs("POST")]
        [Route("RegistrarSuprimento")]
        [Classes.ValidateModel]
        public ContratoServico.Venda.RegistrarSuprimento.RespostaRegistrarSuprimento RegistrarSuprimento(ContratoServico.Venda.RegistrarSuprimento.PeticaoRegistrarSuprimento Peticao)
        {

            ContratoServico.Venda.RegistrarSuprimento.RespostaRegistrarSuprimento objSaida = new ContratoServico.Venda.RegistrarSuprimento.RespostaRegistrarSuprimento();
            decimal Saldo = 0;

            try
            {
                IGERENCEEntities objBD = new IGERENCEEntities();

                if (Peticao.Suprimento != null)
                {

                    INFM_SUPRIMENTO objSuprimento = new INFM_SUPRIMENTO()
                    {
                        IDPESSOASUPERVISOR = Peticao.Suprimento.IdentificadorSupervisor,
                        IDRESPONSAVELCAIXA = Peticao.Suprimento.IdentificadorResponsavelCaixa,
                        IDSUPRIMENTO = Guid.NewGuid().ToString(),
                        NUMVALORSUPRIMENTO = Peticao.Suprimento.Valor,
                        OBSSUPRIMENTO = Peticao.Suprimento.Observacao
                    };

                    objBD.INFM_SUPRIMENTO.Add(objSuprimento);

                    INFM_RESPONSAVELCAIXA objResponsavelCaixa = (from rc in objBD.INFM_RESPONSAVELCAIXA
                                                                 where rc.IDRESPONSAVELCAIXA == Peticao.Suprimento.IdentificadorResponsavelCaixa &&
                                                                       rc.DTHFIMOPERACAO == null
                                                                 select rc).FirstOrDefault();

                    if (objResponsavelCaixa != null)
                    {
                        objResponsavelCaixa.NUMSALDO += Peticao.Suprimento.Valor;
                        Saldo = objResponsavelCaixa.NUMSALDO;
                    }
                    else
                    {
                        throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "Não foi detectado caixa em operação para realizar o Suprimento.");
                    }

                }

                objBD.SaveChanges();

                objSaida.Saldo = Saldo;
                objSaida.CodigoErro = Convert.ToInt32(Execao.Constantes.CodigoErro.SEM_ERRO);


            }
            catch (Execao.ExecaoNegocio ex)
            {
                objSaida.CodigoErro = Convert.ToInt32(ex.Codigo);
                objSaida.DescricaoErro = ex.Descricao;

            }
            catch (Exception ex)
            {

                objSaida.CodigoErro = Convert.ToInt32(Execao.Constantes.CodigoErro.ERRO_EXECUCAO);
                objSaida.DescricaoErro = "Aconteceu um erro inesperado.";

            }
            return objSaida;
        }

        [AcceptVerbs("POST")]
        [Route("CancelarItems")]
        [Classes.ValidateModel]
        public ContratoServico.Venda.CancelarItems.RespostaCancelarItems CancelarItems(ContratoServico.Venda.CancelarItems.PeticaoCancelarItems Peticao)
        {

            ContratoServico.Venda.CancelarItems.RespostaCancelarItems objSaida = new ContratoServico.Venda.CancelarItems.RespostaCancelarItems();
            decimal Saldo = 0;

            try
            {
                IGERENCEEntities objBD = new IGERENCEEntities();

                if (Peticao.Items != null && Peticao.Items.Count > 0)
                {
                    foreach (var iv in Peticao.Items)
                    {

                        INFM_ITEMVENDA objItemVenda = objBD.INFM_ITEMVENDA.FirstOrDefault(ivb => ivb.IDITEMVENDA == iv.Identificador);

                        if (objItemVenda != null)
                        {
                            if (!string.IsNullOrEmpty(objItemVenda.IDPAGAMENTO))
                                throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "Existem items que já foram pagos.");

                            INFM_VENDA objVenda = objBD.INFM_VENDA.FirstOrDefault(v => v.IDVENDA == Peticao.IdentificadorVenda);

                            if (objVenda != null)
                            {
                                objItemVenda.CODESTADO = Comum.Enumeradores.EstadoItemVenda.Cancelado.RecuperarValor();
                                objItemVenda.IDPESSOACANCELAMENTO = Peticao.IdentificadorSupervisorCancelamento;

                                objVenda.NUMVALORVENDA -= objItemVenda.NUMVALORTOTAL;
                                objVenda.NUMVALORTOTAL -= objItemVenda.NUMVALORTOTAL;

                                INFM_PRODUTOFILIAL objProdutoFilial = objBD.INFM_PRODUTOFILIAL.FirstOrDefault(pf => pf.IDFILIAL == Peticao.IdentificadorFilial && pf.IDPRODUTOSERVICO == iv.Produto.Identificador);

                                if (objProdutoFilial != null)
                                {
                                    objProdutoFilial.NUMESTOQUE += objItemVenda.NUMQUANTIDADE;

                                    INFM_DATOSCOMPRAPROD objDadosCompra = objBD.INFM_DATOSCOMPRAPROD.FirstOrDefault(dc => dc.IDPRODUTOFILIAL == objProdutoFilial.IDPRODUTOFILIAL &&
                                                                                                                          dc.BOLESTOQUEATUAL == true);

                                    if (objDadosCompra != null)
                                    {
                                        objDadosCompra.NUMESTOQUE += objItemVenda.NUMQUANTIDADE != null ? Convert.ToDecimal(objItemVenda.NUMQUANTIDADE) : 0;
                                    }
                                    else
                                    {
                                        throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "Não foi encontrado produto para regularizar o estoque");
                                    }
                                }
                                else
                                {
                                    throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "Não foi encontrado produto para regularizar o estoque");
                                }
                            }
                            else
                            {
                                throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "Venda não encontrada.");
                            }
                        }
                    }
                }


                objBD.SaveChanges();

                objSaida.CodigoErro = Convert.ToInt32(Execao.Constantes.CodigoErro.SEM_ERRO);
            }
            catch (Execao.ExecaoNegocio ex)
            {
                objSaida.CodigoErro = Convert.ToInt32(ex.Codigo);
                objSaida.DescricaoErro = ex.Descricao;

            }
            catch (Exception ex)
            {

                objSaida.CodigoErro = Convert.ToInt32(Execao.Constantes.CodigoErro.ERRO_EXECUCAO);
                objSaida.DescricaoErro = "Aconteceu um erro inesperado.";

            }
            return objSaida;
        }

        [AcceptVerbs("POST")]
        [Route("ModificarPrecoProdutoVenda")]
        [Classes.ValidateModel]
        public ContratoServico.Venda.ModificarPrecoProdutoVenda.RespostaModificarPrecoProdutoVenda ModificarPrecoProdutoVenda(ContratoServico.Venda.ModificarPrecoProdutoVenda.PeticaoModificarPrecoProdutoVenda Peticao)
        {

            ContratoServico.Venda.ModificarPrecoProdutoVenda.RespostaModificarPrecoProdutoVenda objSaida = new ContratoServico.Venda.ModificarPrecoProdutoVenda.RespostaModificarPrecoProdutoVenda();

            try
            {
                IGERENCEEntities objBD = new IGERENCEEntities();

                if (Peticao.Items != null && Peticao.Items.Count > 0)
                {
                    foreach (var iv in Peticao.Items)
                    {
                        List<INFM_ITEMVENDA> objItemsVenda = (from INFM_ITEMVENDA v in objBD.INFM_ITEMVENDA
                                                              where v.IDVENDA == Peticao.IdentificadorVenda &&
                   v.IDPRODUTOSERVICO == iv.Produto.Identificador
                                                              select v).ToList();

                        if (objItemsVenda != null)
                        {
                            foreach (var ivb in objItemsVenda)
                            {

                                if (!string.IsNullOrEmpty(ivb.IDPAGAMENTO))
                                    throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "Existem items que já foram pagos.");

                                ivb.NUMVALORACRESCIMO = iv.Acrescimo;
                                ivb.NUMVALORDESCONTO = iv.ValorDesconto;
                                ivb.NUMVALORITEM = iv.ValorItem;
                                ivb.NUMVALORTOTAL = ((iv.ValorItem + iv.Acrescimo) - iv.ValorDesconto) * Convert.ToDecimal((ivb.NUMQUANTIDADE != null ? ivb.NUMQUANTIDADE : 1));
                            }
                        }
                    }
                }

                objBD.SaveChanges();
                objSaida.CodigoErro = Convert.ToInt32(Execao.Constantes.CodigoErro.SEM_ERRO);


            }
            catch (Execao.ExecaoNegocio ex)
            {
                objSaida.CodigoErro = Convert.ToInt32(ex.Codigo);
                objSaida.DescricaoErro = ex.Descricao;

            }
            catch (Exception ex)
            {

                objSaida.CodigoErro = Convert.ToInt32(Execao.Constantes.CodigoErro.ERRO_EXECUCAO);
                objSaida.DescricaoErro = "Aconteceu um erro inesperado.";

            }
            return objSaida;
        }

        [AcceptVerbs("POST")]
        [Route("InformarDadosVenda")]
        [Classes.ValidateModel]
        public ContratoServico.Venda.InformarDadosVenda.RespostaInformarDadosVenda InformarDadosVenda(ContratoServico.Venda.InformarDadosVenda.PeticaoInformarDadosVenda Peticao)
        {

            ContratoServico.Venda.InformarDadosVenda.RespostaInformarDadosVenda objSaida = new ContratoServico.Venda.InformarDadosVenda.RespostaInformarDadosVenda();

            try
            {
                IGERENCEEntities objBD = new IGERENCEEntities();

                INFM_VENDA objVenda = (from v in objBD.INFM_VENDA where v.IDVENDA == Peticao.IdentificadorVenda select v).FirstOrDefault();

                if (objVenda != null)
                {
                    if (!string.IsNullOrEmpty(Peticao.IdentificadorFuncionario))
                    {
                        objVenda.IDPESSOAVENDA = Peticao.IdentificadorFuncionario;
                    }

                    List<INFM_MESAVENDA> objMesas = (from mv in objBD.INFM_MESAVENDA where mv.IDVENDA == objVenda.IDVENDA select mv).ToList();

                    if (objMesas != null && objMesas.Count > 0)
                    {

                        List<string> Identificadores = objMesas.Select(m => m.IDMESA).ToList();

                        foreach (var me in (from INFM_MESA mu in objBD.INFM_MESA
                                            where Identificadores.Contains(mu.IDMESA)
                                            select mu).ToList())
                        {
                            me.CODESTADO = Comum.Enumeradores.EstadoMesa.Livre.RecuperarValor();
                        }

                        objBD.INFM_MESAVENDA.RemoveRange(objMesas);
                    }

                    if (Peticao.IdentificadoresMesa != null && Peticao.IdentificadoresMesa.Count > 0)
                    {
                        foreach (var m in Peticao.IdentificadoresMesa)
                        {

                            var mesa = (from ms in objBD.INFM_MESA where ms.IDMESA == m select ms).FirstOrDefault();

                            if (mesa != null)
                            {
                                mesa.CODESTADO = Comum.Enumeradores.EstadoMesa.Ocupada.RecuperarValor();
                            }

                            objBD.INFM_MESAVENDA.Add(new INFM_MESAVENDA()
                            {
                                IDMESA = m,
                                IDMESAVENDA = Guid.NewGuid().ToString(),
                                IDVENDA = objVenda.IDVENDA
                            });
                        }
                    }
                }

                objBD.SaveChanges();
                objSaida.CodigoErro = Convert.ToInt32(Execao.Constantes.CodigoErro.SEM_ERRO);


            }
            catch (Execao.ExecaoNegocio ex)
            {
                objSaida.CodigoErro = Convert.ToInt32(ex.Codigo);
                objSaida.DescricaoErro = ex.Descricao;

            }
            catch (Exception ex)
            {

                objSaida.CodigoErro = Convert.ToInt32(Execao.Constantes.CodigoErro.ERRO_EXECUCAO);
                objSaida.DescricaoErro = "Aconteceu um erro inesperado.";

            }
            return objSaida;
        }
    }
}
