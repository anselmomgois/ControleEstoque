using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using Informatiz.ControleEstoque.API.Entity;
using Informatiz.ControleEstoque.Comum.Extencoes;
using System.Collections.Concurrent;

namespace Informatiz.ControleEstoque.API.Controllers
{
    [RoutePrefix("api/CRM")]
    public class CRMController : ApiController
    {

        [AcceptVerbs("POST")]
        [Route("RecuperarAgendamentosSimples")]
        [Classes.ValidateModel]
        public ContratoServico.CRM.RecuperarAgendamentosSimples.RespostaRecuperarAgendamentosSimples RecuperarAgendamentosSimples(ContratoServico.CRM.RecuperarAgendamentosSimples.PeticaoRecuperarAgendamentosSimples Peticao)
        {
            ContratoServico.CRM.RecuperarAgendamentosSimples.RespostaRecuperarAgendamentosSimples objSaida = new ContratoServico.CRM.RecuperarAgendamentosSimples.RespostaRecuperarAgendamentosSimples();

            try
            {

                objSaida = LogicaNegocio.CRM.RecuperarAgendamentosSimples(Peticao);

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
        [Route("RecuperarAgendamentos")]
        [Classes.ValidateModel]
        public ContratoServico.CRM.RecuperarAgendamentos.RespostaRecuperarAgendamentos RecuperarAgendamentos(ContratoServico.CRM.RecuperarAgendamentos.PeticaoRecuperarAgendamentos Peticao)
        {
            ContratoServico.CRM.RecuperarAgendamentos.RespostaRecuperarAgendamentos objSaida = new ContratoServico.CRM.RecuperarAgendamentos.RespostaRecuperarAgendamentos();

            try
            {

                objSaida = LogicaNegocio.CRM.RecuperarAgendamentos(Peticao);

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
        [Route("RecuperarAgendamento")]
        [Classes.ValidateModel]
        public ContratoServico.CRM.RecuperarAgendamento.RespostaRecuperarAgendamento RecuperarAgendamento(ContratoServico.CRM.RecuperarAgendamento.PeticaoRecuperarAgendamento Peticao)
        {
            ContratoServico.CRM.RecuperarAgendamento.RespostaRecuperarAgendamento objSaida = new ContratoServico.CRM.RecuperarAgendamento.RespostaRecuperarAgendamento();

            try
            {

                objSaida = LogicaNegocio.CRM.RecuperarAgendamento(Peticao);

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
        [Route("InserirAgendamento")]
        [Classes.ValidateModel]
        public ContratoServico.CRM.InserirAgendamento.RespostaInserirAgendamento InserirAgendamento(ContratoServico.CRM.InserirAgendamento.PeticaoInserirAgendamento Peticao)
        {
            ContratoServico.CRM.InserirAgendamento.RespostaInserirAgendamento objSaida = new ContratoServico.CRM.InserirAgendamento.RespostaInserirAgendamento();

            try
            {

                LogicaNegocio.CRM.InserirAgendamento(Peticao);

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

        private Nullable<Int32> GerarIndice(int IndiceMaximo, List<Int32> IndicesEscolhidos)
        {
            if (IndiceMaximo == IndicesEscolhidos.Count)
            {
                return null;
            }

            Int32 Indice = GerarIndice(IndiceMaximo - 1);

            if (IndicesEscolhidos.Exists(ie => ie == Indice))
            {
                while (IndicesEscolhidos.Exists(ie => ie == Indice))
                {
                    Indice = GerarIndice(IndiceMaximo - 1);
                }

            }

            return Indice;
        }

        private Int32 GerarIndice(int IndiceMaximo)
        {
            Int32 Indice = 0;
            Int64 QuantidadeVezes = DateTime.Now.Second;

            for (int i = 0; i < QuantidadeVezes; i++)
            {
                if (Indice == IndiceMaximo)
                {
                    Indice = -1;
                }

                Indice += 1;
            }


            return Indice;
        }

        private List<Comum.Clases.Agendamento> GerarAgendamento(Comum.Clases.TipoCrm TipoCrm)
        {
            List<Comum.Clases.Agendamento> Agendamentos = new List<Comum.Clases.Agendamento>();

            Int32 nivel = 0;

            Comum.Clases.TipoCrmConfig TipoConfigNivel = TipoCrm.TiposCrmConfig.FindAll(tc => tc.Nivel == 1).FirstOrDefault();
            DateTime DataAtendimentoInicio = DateTime.Now;
            DateTime DataAtendimentoFim = DateTime.Now;

            if (TipoConfigNivel != null)
            {
                DataAtendimentoInicio = DateTime.Now;
                DataAtendimentoFim = DateTime.Now.AddMinutes(TipoConfigNivel.QuantidadeDiasData);
                List<Comum.Clases.Pessoa> objFuncionarios =  Classes.CRM.SortearFuncionariosCompromisso(TipoCrm);
                

                Agendamentos.Add(new Comum.Clases.Agendamento()
                {
                    Identificador = Guid.NewGuid().ToString(),
                    FuncionariosResponsaveis = objFuncionarios,
                    DataAtendimento = DataAtendimentoInicio,
                    DataAtendimentoFim = DataAtendimentoFim,
                    Descricao = TipoConfigNivel.DescricaoNivel
                });
            }
            else
            {
                throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "Tipo de CRM default não cadastrado.");
            }

            return Agendamentos;
        }

        [AcceptVerbs("POST")]
        [Route("GerarAgendamentoAutomatico")]
        [Classes.ValidateModel]
        public ContratoServico.CRM.GerarAgendamentoAutomatico.RespostaGerarAgendamentoAutomatico GerarAgendamentoAutomatico(ContratoServico.CRM.GerarAgendamentoAutomatico.PeticaoGerarAgendamentoAutomatico Peticao)
        {
            ContratoServico.CRM.GerarAgendamentoAutomatico.RespostaGerarAgendamentoAutomatico objSaida = new ContratoServico.CRM.GerarAgendamentoAutomatico.RespostaGerarAgendamentoAutomatico();

            try
            {
                if (Peticao.CRMs != null && Peticao.CRMs.Count > 0)
                {

                    ContratoServico.Pessoa.RecuperarPessoas.RespostaRecuperarPessoas objSaidaPessoa = null;
                    ContratoServico.TipoCrm.BuscarTipoCrm.RespostaBuscarTipoCrm objSaidaBuscarTipoCrm = null;
                    ContratoServico.Pessoa.RecuperarPessoas.RespostaRecuperarPessoas objSaidaFuncionarios = null;
                    List<Comum.Clases.Pessoa> Funcionarios = null;
                    Comum.Clases.GrupoCompromisso objGrupoCompromisso = null;
                    Comum.Clases.TipoCrm TipoCrm = null;
                    Task objTaskNivelAtendimento = null;

                    TipoCrmController objControllerTipoCrm = new TipoCrmController();


                    Task objTaskPessoa = new Task(() => objSaidaPessoa = LogicaNegocio.Pessoa.RecuperarPessoas(new ContratoServico.Pessoa.RecuperarPessoas.PeticaoRecuperarPessoas()
                    {
                        Descricao = Peticao.DescricaoClientePadrao,
                        TipoPessoa = Comum.Enumeradores.Enumeradores.TipoPessoaEnum.CLIENTE,
                        IdentificadorEmpresa = Peticao.IdentificadorEmpresa
                    }));

                    Task objTaskTipoCrm = new Task(() => objSaidaBuscarTipoCrm = objControllerTipoCrm.BuscarTipoCrm(new ContratoServico.TipoCrm.BuscarTipoCrm.PeticaoBuscarTipoCrm()
                    {
                        Codigo = Peticao.CodigoTipoCrmPadrao,                        
                        Usuario = Peticao.Usuario,
                        IdentificadorEmpresa = Peticao.IdentificadorEmpresa
                    }));

                    Task objTaskListaFuncionarios = new Task(() => objSaidaFuncionarios = LogicaNegocio.Pessoa.RecuperarPessoas(new ContratoServico.Pessoa.RecuperarPessoas.PeticaoRecuperarPessoas()
                    {
                        IdentificadorEmpresa = Peticao.IdentificadorEmpresa,
                        Usuario = Peticao.Usuario,
                        TipoPessoa = Comum.Enumeradores.Enumeradores.TipoPessoaEnum.FUNCIONARIO,
                        FuncionarioAtivo = true
                    }));

                    if (!string.IsNullOrEmpty(Peticao.DescricaoNivelAtendimentoPadrao))
                    {
                        IGERENCEEntities objBD = new IGERENCEEntities();

                        objTaskNivelAtendimento = new Task(() => objGrupoCompromisso = (from INFM_GRUPOCOMPROMISSO gp in objBD.INFM_GRUPOCOMPROMISSO
                                                                                        where gp.DESGRUPOCOMPROMISSO.ToUpper() == Peticao.DescricaoNivelAtendimentoPadrao.ToUpper() &&
                                                                                               gp.IDEMPRESA == Peticao.IdentificadorEmpresa
                                                                                        select new Comum.Clases.GrupoCompromisso()
                                                                                        {
                                                                                            Identificador = gp.IDGRUPOCOMPROMISSO
                                                                                        }).FirstOrDefault());

                    }
                    else
                    {
                        objTaskNivelAtendimento = new Task(() => objGrupoCompromisso = null);


                    }

                    objTaskNivelAtendimento.Start();
                    objTaskListaFuncionarios.Start();
                    objTaskPessoa.Start();
                    objTaskTipoCrm.Start();

                    Task.WaitAll(new Task[] { objTaskTipoCrm, objTaskPessoa, objTaskListaFuncionarios, objTaskNivelAtendimento });

                    if (objSaidaBuscarTipoCrm != null && objSaidaBuscarTipoCrm.TipoCrm != null)
                    {
                        TipoCrm = objSaidaBuscarTipoCrm.TipoCrm;
                    }
                    else
                    {
                        if (Peticao.Integracao)
                            throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_ESPERADO, "Tipo CRM Default não encontrado");
                        else
                            throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "Tipo CRM Default não encontrado");
                    }

                    if (objSaidaFuncionarios != null && objSaidaFuncionarios.Pessoas != null && objSaidaFuncionarios.Pessoas.Count > 0)
                    {
                        Funcionarios = objSaidaFuncionarios.Pessoas;
                    }

                    Classes.CRM.CarregarFuncionarios(Funcionarios);

                    Comum.Clases.Pessoa ClienteDefault = null;

                    List<Comum.Clases.TipoPessoa> TipoPessoa = new List<Comum.Clases.TipoPessoa>();

                    TipoPessoa.Add(new Comum.Clases.TipoPessoa
                    {
                        Codigo = Comum.Enumeradores.Enumeradores.TipoPessoaEnum.CLIENTE,
                        Identificador = Comum.Enumeradores.Enumeradores.TipoPessoaEnum.CLIENTE.RecuperarValor()
                    });

                    if (objSaidaPessoa == null || (objSaidaPessoa != null && (objSaidaPessoa.Pessoas == null || objSaidaPessoa.Pessoas.Count == 0)))
                    {

                        string IdentificadorClienteDefault = LogicaNegocio.Pessoa.InserirPessoa(new Comum.Clases.Pessoa()
                        {
                            DesNome = Peticao.DescricaoClientePadrao,
                            TiposPessoa = TipoPessoa,
                            Empresa = new Comum.Clases.Empresa() { Identificador = Peticao.IdentificadorEmpresa }
                        }, Peticao.Usuario);

                        if (!string.IsNullOrEmpty(IdentificadorClienteDefault))
                        {
                            ClienteDefault = new Comum.Clases.Pessoa()
                            {
                                Identificador = IdentificadorClienteDefault
                            };
                        }
                    }
                    else
                    {
                        ClienteDefault = objSaidaPessoa.Pessoas.FirstOrDefault();
                    }

                    if (ClienteDefault == null)
                    {
                        if (Peticao.Integracao)
                            throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_ESPERADO, "Não foi possível cadastrar o cliente default.");
                        else
                            throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "Não foi possível cadastrar o cliente default.");
                    }


                    ConcurrentBag<string> objErros = new ConcurrentBag<string>();
                    Parallel.ForEach(Peticao.CRMs, objCrm =>
                    {
                        try
                        {
                            IGERENCEEntities objBD = new IGERENCEEntities();
                            Boolean bolCadastrarCliente = false;

                            Boolean ExisteCrm = (from INFM_CRM c in objBD.INFM_CRM where c.DESCRM == objCrm.Descricao && c.IDEMPRESA == Peticao.IdentificadorEmpresa select c).Count() > 0;

                            if (!ExisteCrm)
                            {
                                string IdentificadorCliente = string.Empty;
                                List<Comum.Clases.Agendamento> objAgendamentos = GerarAgendamento(TipoCrm);

                                if (objCrm.Atendimentos != null && objCrm.Atendimentos.Count > 0)
                                {
                                    if (objAgendamentos == null || objAgendamentos.Count == 0) { objAgendamentos = new List<Comum.Clases.Agendamento>(); }

                                    if (Funcionarios != null && Funcionarios.Count > 0 && !string.IsNullOrEmpty(objCrm.Consultor))
                                    {
                                        Comum.Clases.Pessoa objFuncionario = Funcionarios.Find(f => f.Usuario.ToUpper() == objCrm.Consultor.ToUpper());

                                        if (objFuncionario != null)
                                        {
                                            objAgendamentos.FirstOrDefault().FuncionariosResponsaveis = new List<Comum.Clases.Pessoa>();
                                            objAgendamentos.FirstOrDefault().FuncionariosResponsaveis.Add(objFuncionario);
                                            Classes.CRM.InformarAgendamento(objFuncionario.Usuario);
                                        }
                                        else
                                        {
                                            objCrm.Descricao = string.Format(objCrm.Descricao + " | ({0})", objCrm.Consultor);
                                        }

                                        if (objCrm.Atendimentos.FirstOrDefault().DataAtendimento != DateTime.MinValue)
                                        {
                                            objAgendamentos.FirstOrDefault().DataAtendimento = objCrm.Atendimentos.FirstOrDefault().DataAtendimento;
                                            if (TipoCrm != null && TipoCrm.TiposCrmConfig != null && TipoCrm.TiposCrmConfig.Count > 0)
                                            {
                                                objAgendamentos.FirstOrDefault().DataAtendimentoFim = objCrm.Atendimentos.FirstOrDefault().DataAtendimento.AddMinutes(TipoCrm.TiposCrmConfig.Find(tc => tc.Nivel == 1).QuantidadeDiasData);
                                            }
                                        }

                                        if (!string.IsNullOrEmpty(objCrm.Atendimentos.FirstOrDefault().Descricao))
                                        {
                                            objAgendamentos.FirstOrDefault().Descricao = objCrm.Atendimentos.FirstOrDefault().Descricao;
                                        }
                                    }
                                }

                                objCrm.Atendimentos = objAgendamentos;

                                if (objCrm.Atendimentos == null || objCrm.Atendimentos.Count == 0)
                                {
                                    if (ClienteDefault == null)
                                    {
                                        if (Peticao.Integracao)
                                            throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_ESPERADO, "Revise suas configurações do tipo crm, não foi possivel gerar o agendamento.");
                                        else
                                            throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "Revise suas configurações do tipo crm, não foi possivel gerar o agendamento.");
                                    }
                                }
                                else if (objGrupoCompromisso != null && !string.IsNullOrEmpty(objGrupoCompromisso.Identificador))
                                {
                                    objCrm.Atendimentos.FirstOrDefault().NivelAtendimento = objGrupoCompromisso;
                                }

                                objCrm.TipoCrm = TipoCrm;
                                objCrm.StatusCrm = new Comum.Clases.StatusCrm() { Identificador = TipoCrm.IdentificadorStatusPadrao };

                                if (objCrm.Cliente != null)
                                {
                                    if (!string.IsNullOrEmpty(objCrm.Cliente.cpf))
                                    {
                                        objCrm.Cliente.cpf = objCrm.Cliente.cpf.Replace(".", string.Empty).Replace("-", string.Empty).Replace(" ", string.Empty);
                                        objCrm.Cliente.cpf = Convert.ToUInt64(objCrm.Cliente.cpf).ToString(@"000\.000\.000\-00");
                                    }

                                    if (!Peticao.Integracao && !string.IsNullOrEmpty(objCrm.Cliente.DesNome) &&
                                                             (!string.IsNullOrEmpty(objCrm.Cliente.Identificador) ||
                                                             !string.IsNullOrEmpty(objCrm.Cliente.DesNomeFantasia) ||
                                                             !string.IsNullOrEmpty(objCrm.Cliente.RG) ||
                                                             !string.IsNullOrEmpty(objCrm.Cliente.cnpj) ||
                                                             !string.IsNullOrEmpty(objCrm.Cliente.cpf) ||
                                                             !string.IsNullOrEmpty(objCrm.Cliente.DesEmail) ||
                                                             !string.IsNullOrEmpty(objCrm.Cliente.DesTelefoneCelular) ||
                                                             !string.IsNullOrEmpty(objCrm.Cliente.DesTelefoneFixo)))
                                    {
                                        IdentificadorCliente = (from INFM_PESSOA p in objBD.INFM_PESSOA
                                                                join INFM_TIPOPESSOA_PESSOA tpp in objBD.INFM_TIPOPESSOA_PESSOA on p.IDPESSOA equals tpp.IDPESSOA
                                                                join INFM_TIPOPESSOA tp in objBD.INFM_TIPOPESSOA on tpp.IDTIPOPESSOA equals tp.IDTIPOPESSOA
                                                                where tp.CODTIPOPESSOA == (int)Comum.Enumeradores.Enumeradores.TipoPessoaEnum.CLIENTE &&
                                                                (!string.IsNullOrEmpty(objCrm.Cliente.DesNome) && p.DESNOME.ToUpper() == objCrm.Cliente.DesNome.ToUpper()) &&
                                                                ((!string.IsNullOrEmpty(objCrm.Cliente.Identificador) && p.IDPESSOA == objCrm.Cliente.Identificador) ||
                                                                (!string.IsNullOrEmpty(objCrm.Cliente.DesNomeFantasia) && p.DESNOMEFANTASIA.ToUpper() == objCrm.Cliente.DesNomeFantasia.ToUpper()) ||
                                                                (!string.IsNullOrEmpty(objCrm.Cliente.RG) && p.DESRG.ToUpper() == objCrm.Cliente.RG.ToUpper()) ||
                                                                (!string.IsNullOrEmpty(objCrm.Cliente.cnpj) && p.DESCNPJ.ToUpper() == objCrm.Cliente.cnpj.ToUpper()) ||
                                                                (!string.IsNullOrEmpty(objCrm.Cliente.cpf) && p.DESCPF.ToUpper() == objCrm.Cliente.cpf.ToUpper()) ||
                                                                (!string.IsNullOrEmpty(objCrm.Cliente.DesEmail) && p.DESEMAIL.ToUpper() == objCrm.Cliente.DesEmail.ToUpper()) ||
                                                                (!string.IsNullOrEmpty(objCrm.Cliente.DesTelefoneCelular) && p.DESTELEFONECELULAR.ToUpper() == objCrm.Cliente.DesTelefoneCelular.ToUpper()) ||
                                                                (!string.IsNullOrEmpty(objCrm.Cliente.DesTelefoneFixo) && p.DESTELEFONEFIXO.ToUpper() == objCrm.Cliente.DesTelefoneFixo.ToUpper()))
                                                                select p.IDPESSOA).FirstOrDefault();
                                        bolCadastrarCliente = true;
                                    }
                                    else if (Peticao.Integracao && !string.IsNullOrEmpty(objCrm.Cliente.DesTelefoneCelular))
                                    {
                                        IdentificadorCliente = (from INFM_PESSOA p in objBD.INFM_PESSOA
                                                                join INFM_TIPOPESSOA_PESSOA tpp in objBD.INFM_TIPOPESSOA_PESSOA on p.IDPESSOA equals tpp.IDPESSOA
                                                                join INFM_TIPOPESSOA tp in objBD.INFM_TIPOPESSOA on tpp.IDTIPOPESSOA equals tp.IDTIPOPESSOA
                                                                where tp.CODTIPOPESSOA == (int)Comum.Enumeradores.Enumeradores.TipoPessoaEnum.CLIENTE &&
                                                                ((!string.IsNullOrEmpty(objCrm.Cliente.DesTelefoneCelular) && p.DESTELEFONECELULAR.Replace(" ", string.Empty).Replace("-", string.Empty).Replace("(", string.Empty).Replace(")", string.Empty).Replace("+", string.Empty) == objCrm.Cliente.DesTelefoneCelular.Replace(" ", string.Empty).Replace("-", string.Empty).Replace("(", string.Empty).Replace(")", string.Empty).Replace("+", string.Empty)) ||
                                                                (!string.IsNullOrEmpty(objCrm.Cliente.DesTelefoneCelular) && p.DESTELEFONEFIXO.Replace(" ", string.Empty).Replace("-", string.Empty).Replace("(", string.Empty).Replace(")", string.Empty).Replace("+", string.Empty) == objCrm.Cliente.DesTelefoneCelular.Replace(" ", string.Empty).Replace("-", string.Empty).Replace("(", string.Empty).Replace(")", string.Empty).Replace("+", string.Empty)))
                                                                select p.IDPESSOA).FirstOrDefault();
                                        bolCadastrarCliente = false;
                                    }
                                    else
                                    {
                                        bolCadastrarCliente = false;
                                    }

                                }

                                if (string.IsNullOrEmpty(IdentificadorCliente))
                                {

                                    if (objCrm.Cliente != null && bolCadastrarCliente)
                                    {
                                        Nullable<Int32> numero = null;
                                        string DesPontoReferencia = string.Empty;

                                        if (!string.IsNullOrEmpty(objCrm.Cliente.DesNome))
                                        {
                                            if (objCrm.Cliente.EnderecoCompleto != null)
                                            {

                                                if (objCrm.Cliente.EnderecoCompleto.Cidades != null && objCrm.Cliente.EnderecoCompleto.Cidades.Count > 0)
                                                {

                                                    if (objCrm.Cliente.EnderecoCompleto.Cidades.FirstOrDefault().Bairros != null &&
                                                       objCrm.Cliente.EnderecoCompleto.Cidades.FirstOrDefault().Bairros.Count > 0)
                                                    {

                                                        if (objCrm.Cliente.EnderecoCompleto.Cidades.FirstOrDefault().Bairros.FirstOrDefault().Enderecos != null &&
                                                           objCrm.Cliente.EnderecoCompleto.Cidades.FirstOrDefault().Bairros.FirstOrDefault().Enderecos.Count > 0)
                                                        {
                                                            string cep = objCrm.Cliente.EnderecoCompleto.Cidades.FirstOrDefault().Bairros.FirstOrDefault().Enderecos.FirstOrDefault().DescricaoCep;

                                                            Comum.Clases.Estado objEnderecoCompleto = LogicaNegocio.Endereco.RegistrarEndereco(cep, string.Empty, string.Empty, string.Empty, string.Empty, Peticao.Usuario, string.Empty, string.Empty);

                                                            if (objEnderecoCompleto != null)
                                                            {

                                                                numero = objCrm.Cliente.EnderecoCompleto.Cidades.FirstOrDefault().Bairros.FirstOrDefault().Enderecos.FirstOrDefault().Numero;
                                                                DesPontoReferencia = objCrm.Cliente.EnderecoCompleto.Cidades.FirstOrDefault().Bairros.FirstOrDefault().Enderecos.FirstOrDefault().DesReferencia;

                                                                if (numero != null)
                                                                {
                                                                    objCrm.Cliente.Endereco = new Comum.Clases.Endereco()
                                                                    {
                                                                        Numero = numero,
                                                                        DescricaoCep = cep,
                                                                        DesReferencia = DesPontoReferencia,
                                                                        Identificador = objEnderecoCompleto.Cidades.FirstOrDefault().Bairros.FirstOrDefault().Enderecos.FirstOrDefault().Identificador
                                                                    };
                                                                }
                                                            }

                                                        }
                                                    }
                                                }
                                            }

                                            objCrm.Cliente.TiposPessoa = TipoPessoa;

                                            string IdentificadorClienteNovo = LogicaNegocio.Pessoa.InserirPessoa(objCrm.Cliente, Peticao.Usuario);

                                            if (!string.IsNullOrEmpty(IdentificadorClienteNovo))
                                            {
                                                objCrm.Cliente.Identificador = IdentificadorClienteNovo;
                                            }
                                        }
                                        else
                                        {
                                            objCrm.Cliente = ClienteDefault;
                                        }
                                    }
                                    else
                                    {
                                        if (objCrm.Cliente != null)
                                        {
                                            objCrm.Observacao = string.Format(objCrm.Observacao + " Cliente não cadastrado: {0}", objCrm.Cliente.DesNome);
                                        }
                                        objCrm.Cliente = ClienteDefault;
                                    }
                                }
                                else
                                {
                                    objCrm.Cliente.Identificador = IdentificadorCliente;
                                }

                                LogicaNegocio.CRM.InserirAgendamento(new ContratoServico.CRM.InserirAgendamento.PeticaoInserirAgendamento()
                                {
                                    CRM = objCrm,
                                    IdentificadorEmpresa = Peticao.IdentificadorEmpresa,
                                    Usuario = Peticao.Usuario
                                });
                            }
                        }
                        catch (Execao.ExecaoNegocio ex)
                        {
                            objErros.Add(string.Format("Agendamento '{0}' não cadastrado - {1}", objCrm.Descricao, ex.Descricao));
                        }
                        catch (Exception ex)
                        {
                            objErros.Add(string.Format("Agendamento '{0}' não cadastrado - {1}", objCrm.Descricao, ex.Message));
                        }

                    });

                    if (objErros != null && objErros.Count > 0)
                    {
                        System.Text.StringBuilder Erros = new System.Text.StringBuilder();
                        foreach (string se in objErros)
                        {
                            Erros.AppendLine(se);
                        }

                        if (Peticao.Integracao)
                            throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_ESPERADO, Erros.ToString());
                        else
                            throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, Erros.ToString());
                    }
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
        [Route("AtualizarAgendamento")]
        [Classes.ValidateModel]
        public ContratoServico.CRM.AtualizarAgendamento.RespostaAtualizarAgendamento AtualizarAgendamento(ContratoServico.CRM.AtualizarAgendamento.PeticaoAtualizarAgendamento Peticao)
        {
            ContratoServico.CRM.AtualizarAgendamento.RespostaAtualizarAgendamento objSaida = new ContratoServico.CRM.AtualizarAgendamento.RespostaAtualizarAgendamento();

            try
            {

                LogicaNegocio.CRM.AtualizarAgendamento(Peticao);

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
        [Route("DesativarAgendamento")]
        [Classes.ValidateModel]
        public ContratoServico.CRM.DesativarAgendamento.RespostaDesativarAgendamento DesativarAgendamento(ContratoServico.CRM.DesativarAgendamento.PeticaoDesativarAgendamento Peticao)
        {
            ContratoServico.CRM.DesativarAgendamento.RespostaDesativarAgendamento objSaida = new ContratoServico.CRM.DesativarAgendamento.RespostaDesativarAgendamento();

            try
            {

                LogicaNegocio.CRM.DesativarAgendamento(Peticao.IdentificadorCRM, Peticao.Usuario);

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
