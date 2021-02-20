using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Informatiz.ControleEstoque.API.Entity;

namespace Informatiz.ControleEstoque.API.Controllers
{
    [RoutePrefix("api/Setor")]
    public class SetorController : ApiController
    {

        [AcceptVerbs("POST")]
        [Route("SetSetor")]
        [Classes.ValidateModel]
        public ContratoServico.Setor.SetSetor.RespostaSetSetor SetSetor(ContratoServico.Setor.SetSetor.PeticaoSetSetor Peticao)
        {

            ContratoServico.Setor.SetSetor.RespostaSetSetor objSaida = new ContratoServico.Setor.SetSetor.RespostaSetSetor();

            try
            {
                IGERENCEEntities objBD = new IGERENCEEntities();

                if(string.IsNullOrEmpty(Peticao.SetorEmpresa.IdentificadorSetorEmpresa))
                {
                    objBD.INFM_SETOREMPRESA.Add(new INFM_SETOREMPRESA()
                    {
                        DESIMPRESSORA = Peticao.SetorEmpresa.DescricaoImpressora,
                        DESSETOR = Peticao.SetorEmpresa.DescricaoSetorEmpresa,
                        IDEMPRESA = Peticao.IdentificadorEmpresa,
                        IDFILIAL = Peticao.IdentificadorFilial,
                        IDSETOREMPRESA = Guid.NewGuid().ToString()
                    });

                }
                else
                {

                    INFM_SETOREMPRESA objSetor = (from INFM_SETOREMPRESA s in objBD.INFM_SETOREMPRESA
                                                  where s.IDSETOREMPRESA == Peticao.SetorEmpresa.IdentificadorSetorEmpresa select s).FirstOrDefault();

                    objSetor.DESIMPRESSORA = Peticao.SetorEmpresa.DescricaoImpressora;
                    objSetor.DESSETOR = Peticao.SetorEmpresa.DescricaoSetorEmpresa;
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
        [Route("BuscarSetores")]
        [Classes.ValidateModel]
        public ContratoServico.Setor.BuscarSetores.RespostaBuscarSetores BuscarSetores(ContratoServico.Setor.BuscarSetores.PeticaoBuscarSetores Peticao)
        {

            ContratoServico.Setor.BuscarSetores.RespostaBuscarSetores objSaida = new ContratoServico.Setor.BuscarSetores.RespostaBuscarSetores();

            try
            {
                IGERENCEEntities objBD = new IGERENCEEntities();

                if (Peticao.Descricao == null  || (Peticao.Descricao != null && string.IsNullOrEmpty(Peticao.Descricao.Trim())))
                {

                    objSaida.Setores = (from INFM_SETOREMPRESA s in objBD.INFM_SETOREMPRESA
                                        where s.IDEMPRESA == Peticao.IdentificadorEmpresa && s.IDFILIAL == Peticao.IdentificadorFilial
                                        select new Comum.Clases.SetorEmpresa()
                                        {
                                            DescricaoImpressora = s.DESIMPRESSORA,
                                            DescricaoSetorEmpresa = s.DESSETOR,
                                            IdentificadorSetorEmpresa = s.IDSETOREMPRESA
                                        }).ToList();
                }
                else
                {

                    objSaida.Setores = (from INFM_SETOREMPRESA s in objBD.INFM_SETOREMPRESA
                                        where s.IDEMPRESA == Peticao.IdentificadorEmpresa && s.IDFILIAL == Peticao.IdentificadorFilial &&
                                              s.DESSETOR.Contains(Peticao.Descricao)
                                        select new Comum.Clases.SetorEmpresa()
                                        {
                                            DescricaoImpressora = s.DESIMPRESSORA,
                                            DescricaoSetorEmpresa = s.DESSETOR,
                                            IdentificadorSetorEmpresa = s.IDSETOREMPRESA
                                        }).ToList();
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
        [Route("BuscarSetor")]
        [Classes.ValidateModel]
        public ContratoServico.Setor.BuscarSetor.RespostaBuscarSetor BuscarSetor(ContratoServico.Setor.BuscarSetor.PeticaoBuscarSetor Peticao)
        {

            ContratoServico.Setor.BuscarSetor.RespostaBuscarSetor objSaida = new ContratoServico.Setor.BuscarSetor.RespostaBuscarSetor();

            try
            {
                IGERENCEEntities objBD = new IGERENCEEntities();



                objSaida.Setor = (from INFM_SETOREMPRESA s in objBD.INFM_SETOREMPRESA
                                  where s.IDSETOREMPRESA == Peticao.IdentificadorSetorEmpresa
                                  select new Comum.Clases.SetorEmpresa()
                                  {
                                      DescricaoImpressora = s.DESIMPRESSORA,
                                      DescricaoSetorEmpresa = s.DESSETOR,
                                      IdentificadorSetorEmpresa = s.IDSETOREMPRESA
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
        [Route("ExcluirSetor")]
        [Classes.ValidateModel]
        public ContratoServico.Setor.ExcluirSetor.RespostaExcluirSetor ExcluirSetor(ContratoServico.Setor.ExcluirSetor.PeticaoExcluirSetor Peticao)
        {

            ContratoServico.Setor.ExcluirSetor.RespostaExcluirSetor objSaida = new ContratoServico.Setor.ExcluirSetor.RespostaExcluirSetor();

            try
            {
                IGERENCEEntities objBD = new IGERENCEEntities();

                Int32 QuantidadeRegistros = (from INFM_PRODUTOSERVICO p in objBD.INFM_PRODUTOSERVICO where p.IDSETOREMPRESA == Peticao.IdentificadorSetorEmpresa select p).Count();

                if (QuantidadeRegistros > 0)
                {
                    throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "O tipo do empregado já está sendo utilizado.");
                }

                INFM_SETOREMPRESA objSetorEmpresa = (from INFM_SETOREMPRESA icrm in objBD.INFM_SETOREMPRESA
                                                       where icrm.IDSETOREMPRESA == Peticao.IdentificadorSetorEmpresa
                                                       select icrm).FirstOrDefault();

                objBD.INFM_SETOREMPRESA.Remove(objSetorEmpresa);

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
