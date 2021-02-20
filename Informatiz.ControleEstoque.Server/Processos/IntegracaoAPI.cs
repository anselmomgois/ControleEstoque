using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Informatiz.ControleEstoque.Comum.Clases;
using Informatiz.ControleEstoque.Comum.ParametrosTela;
using Informatiz.ControleEstoque.SDK;
using Informatiz.ControleEstoque.Comum.Extencoes;
using System.IO;
using System.Configuration;

namespace Informatiz.ControleEstoque.Server.Processos
{
    public class IntegracaoAPI : BaseProcessos
    {

        private string _TempPath = string.Format("{0}\\IGERENCE\\TEMP\\", Path.GetTempPath());
        private string _ExecutionTempPath = string.Format("{0}\\IGERENCE\\EXECUTION_TEMP\\", Path.GetTempPath());

        protected override void ExecutarProcesso(Processo Processo, Comum.Clases.ItemProcesso ItemProcesso)
        {
            if (!Directory.Exists(_TempPath))
            {
                Directory.CreateDirectory(_TempPath);
            }

            if (!Directory.Exists(_ExecutionTempPath))
            {
                Directory.CreateDirectory(_ExecutionTempPath);
            }


            RecuperarIntegracoesAPI(Processo);

            base.ExecutarProcesso(Processo, ItemProcesso);

        }

        private void RecuperarIntegracoesAPI(Comum.Clases.Processo objProcesso)
        {
            if (Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada != null && Parametros.Parametros.InformacaoUsuario.FilialSelecionada != null &&
                !string.IsNullOrEmpty(Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador) && !string.IsNullOrEmpty(Parametros.Parametros.InformacaoUsuario.FilialSelecionada.Identificador))
            {
                ContratoServico.IntegracaoAPI.BuscaIntegracoesAPI.PeticaoBuscaIntegracoesAPI Peticao = new ContratoServico.IntegracaoAPI.BuscaIntegracoesAPI.PeticaoBuscaIntegracoesAPI();

                Peticao.IdentificadorEmpresa = ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador;
                Peticao.Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login;

                Agente.Agente.InvocarServico<ContratoServico.IntegracaoAPI.BuscaIntegracoesAPI.RespostaBuscaIntegracoesAPI, ContratoServico.IntegracaoAPI.BuscaIntegracoesAPI.PeticaoBuscaIntegracoesAPI>(Peticao,
                    SDK.Operacoes.operacao.BuscaIntegracoesAPI, new Comum.ParametrosTela.Generica()
                    {
                        PreencherObjeto = true,
                        ExibirMensagemNenhumRegistro = false,
                        Processo = objProcesso
                    }, null, true);
            }
        }

        protected override void FinalizarProcesso(Processo Processo, Comum.Clases.ItemProcesso ItemProcesso)
        {
            base.FinalizarProcesso(Processo, ItemProcesso);
        }
        private void ApagarArquivos()
        {

            var Arquivos = Directory.GetFiles(_ExecutionTempPath);
            foreach (var temp in Arquivos)
            {
                FileInfo objFile = new FileInfo(temp);


                if (File.Exists(temp))
                {

                    DateTime objData = ConverterNomeArquivoToDate(objFile.Name);

                    System.TimeSpan objDiferenca = (DateTime.Now - objData);

                    if (objDiferenca.Hours > 2)
                    {
                        File.Delete(temp);
                    }

                }

            }


        }

        private DateTime ConverterNomeArquivoToDate(string NomeArquivo)
        {
            return Convert.ToDateTime(NomeArquivo.Replace("_", "/").Replace("#", ":").Replace("-", " ").Replace(".txt", ""));

        }
        private string CriarNomeArquivo()
        {
            return DateTime.Now.ToString().Replace("/", "_").Replace(":", "#").Replace(" ", "-");
        }

        private void InvocarAPI(Processo Processo, Comum.Clases.ItemProcesso ItemProcesso)
        {

            switch (ItemProcesso.TipoIntegracao)
            {
                case Comum.Enumeradores.TipoIntegracao.SHORT:

                    Agente.Agente.InvocarServicoExterno<Comum.APIExterna.Modelo1.RootObject>(
          SDK.Operacoes.operacao.ExecucaoAPIExterna, new Comum.ParametrosTela.Generica()
          {
              PreencherObjeto = true,
              ExibirMensagemNenhumRegistro = false,
              Processo = Processo,
              ItemProcesso = ItemProcesso
          }, null, true, ItemProcesso.Valor);
                    break;

                case Comum.Enumeradores.TipoIntegracao.SMS:

                    Agente.Agente.InvocarServicoExterno<Comum.APIExterna.Modelo1.RootObject>(
          SDK.Operacoes.operacao.ExecucaoAPIExterna, new Comum.ParametrosTela.Generica()
          {
              PreencherObjeto = true,
              ExibirMensagemNenhumRegistro = false,
              Processo = Processo,
              ItemProcesso = ItemProcesso
          }, null, true, ItemProcesso.Valor);

                    break;

                case Comum.Enumeradores.TipoIntegracao.ZERO800:

                    Agente.Agente.InvocarServicoExterno<List<Comum.APIExterna.Modelo2.RootObject>>(
          SDK.Operacoes.operacao.ExecucaoAPIExterna, new Comum.ParametrosTela.Generica()
          {
              PreencherObjeto = true,
              ExibirMensagemNenhumRegistro = false,
              Processo = Processo,
              ItemProcesso = ItemProcesso
          }, null, true, ItemProcesso.Valor);

                    break;
                case Comum.Enumeradores.TipoIntegracao.SHORT2:


                    if (!Directory.Exists(_ExecutionTempPath))
                    {
                        Directory.CreateDirectory(_ExecutionTempPath);
                    }

                    ApagarArquivos();

                    var Arquivos = Directory.GetFiles(_TempPath);

                    if (Arquivos != null && Arquivos.Count() > 0)
                    {

                        foreach (var temp in Arquivos)
                        {
                            FileInfo objFile = new FileInfo(temp);
                            string Conteudo = File.ReadAllText(temp);
                            string FileName = string.Format("{0}\\{1}", _ExecutionTempPath, objFile.Name);

                            File.Move(temp, FileName);

                            if (!string.IsNullOrEmpty(Conteudo))
                            {
                                var objConteudo = Newtonsoft.Json.JsonConvert.DeserializeObject<Comum.APIExterna.Modelo1.RootObject>(Conteudo);


                                RespostaAgente(objConteudo, SDK.Operacoes.operacao.ExecucaoAPIExterna,
                                    new Comum.ParametrosTela.Generica()
                                    {
                                        Processo = Processo,
                                        FazerBackupExecucaoExterna = false,
                                        ParametroGenerico = FileName
                                    });
                            }
                        }
                    }
                    else
                    {

                        Agente.Agente.InvocarServicoExterno<Comum.APIExterna.Modelo1.RootObject, Comum.APIExterna.Modelo3.RootObject>(
              SDK.Operacoes.operacao.ExecucaoAPIExterna, new Comum.ParametrosTela.Generica()
              {
                  PreencherObjeto = true,
                  ExibirMensagemNenhumRegistro = false,
                  Processo = Processo,
                  ItemProcesso = ItemProcesso,
                  FazerBackupExecucaoExterna = true
              }, null, true, ItemProcesso.Valor);

                    }

                    break;
            }
        }

        protected override void RespostaAgente(object objSaida, Operacoes.operacao operacao, Generica Parametros)
        {
            try
            {

                if (operacao == SDK.Operacoes.operacao.ExecucaoAPIExterna)
                {
                    try
                    {
                        if (Parametros.ItemProcesso.TipoIntegracao == Comum.Enumeradores.TipoIntegracao.ZERO800)
                        {

                            List<Comum.APIExterna.Modelo2.RootObject> IntegracoesAPI0800 = (List<Comum.APIExterna.Modelo2.RootObject>)objSaida;

                            if (IntegracoesAPI0800 != null && IntegracoesAPI0800.Count > 0)
                            {
                                Comum.Clases.CRM objCrm = null;
                                List<Comum.Clases.CRM> objListaCrm = new List<Comum.Clases.CRM>();

                                foreach (Comum.APIExterna.Modelo2.RootObject d in IntegracoesAPI0800)
                                {
                                    objCrm = new Comum.Clases.CRM()
                                    {

                                        Ativo = true,
                                        Descricao = string.Format("{0} | {1} | {2} | {3}", Parametros.ItemProcesso.TipoIntegracao.RecuperarValor(),
                                                                                    (!string.IsNullOrEmpty(d.data) && !string.IsNullOrEmpty(d.hora) ?
                                                                                    Convert.ToDateTime(string.Format("{0} {1}", d.data, d.hora)).ToString() : string.Format("{0} {1}", d.data, d.hora)),
                                                                                     d.telefone,
                                                                                     d.nome),
                                        FuncionarioCadastro = new Comum.Clases.Pessoa() { Identificador = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Identificador },
                                        Observacao = string.Format("{0}", d.did),
                                        Atendimentos = new List<Comum.Clases.Agendamento>(),
                                        TipoCrm = new Comum.Clases.TipoCrm(),
                                        StatusCrm = new Comum.Clases.StatusCrm() { Identificador = "ID", Codigo = "CODIGO", CorRGB = "COR", Descricao = "DESCRICAO" }
                                    };

                                    objCrm.Cliente = new Comum.Clases.Pessoa();

                                    if (!string.IsNullOrEmpty(d.telefone))
                                    {
                                        objCrm.Cliente.DesTelefoneCelular = d.telefone;
                                    }

                                    objListaCrm.Add(objCrm);
                                }

                                ContratoServico.CRM.GerarAgendamentoAutomatico.PeticaoGerarAgendamentoAutomatico Peticao = new ContratoServico.CRM.GerarAgendamentoAutomatico.PeticaoGerarAgendamentoAutomatico()
                                {
                                    CodigoTipoCrmPadrao = (!string.IsNullOrEmpty(Parametros.ItemProcesso.CodigoTipoCrm) ? Parametros.ItemProcesso.CodigoTipoCrm : ControleEstoque.Parametros.Parametros.ParametrosAplicacao.CodigoTipoCrmDefault),
                                    DescricaoClientePadrao = ControleEstoque.Parametros.Parametros.ParametrosAplicacao.DescricaoClienteDefault,
                                    CRMs = objListaCrm,
                                    IdentificadorEmpresa = ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador,
                                    Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login,
                                    Integracao = true,
                                    DescricaoNivelAtendimentoPadrao = ControleEstoque.Parametros.Parametros.ParametrosAplicacao.NivelAtendimentoPadrao
                                };

                                Agente.Agente.InvocarServico<ContratoServico.CRM.GerarAgendamentoAutomatico.RespostaGerarAgendamentoAutomatico, ContratoServico.CRM.GerarAgendamentoAutomatico.PeticaoGerarAgendamentoAutomatico>(Peticao,
                                         SDK.Operacoes.operacao.GerarAgendamentoAutomatico, new Comum.ParametrosTela.Generica() { Processo = Parametros.Processo, NaoTratarErro = true }, null, true);
                            }
                            else
                            {
                                FinalizarItemProcessoMemoria(Parametros.Processo, Parametros.ItemProcesso, string.Empty);
                            }
                        }
                        else
                        {
                            Comum.APIExterna.Modelo1.RootObject IntegracoesAPI = (Comum.APIExterna.Modelo1.RootObject)objSaida;

                            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["ModoTeste"]) && ConfigurationManager.AppSettings["ModoTeste"].Equals("1"))
                            {
                                if (!(IntegracoesAPI != null && IntegracoesAPI.doc != null && IntegracoesAPI.doc.Count > 0))
                                {
                                    IntegracoesAPI = new Comum.APIExterna.Modelo1.RootObject();
                                    IntegracoesAPI.doc = new List<Comum.APIExterna.Modelo1.Doc>();
                                    IntegracoesAPI.doc.Add(new Comum.APIExterna.Modelo1.Doc()
                                    {
                                        codigo = "123",
                                        destino_celular = "31988533660",
                                        dh_entrada = "2019-03-04 15:17:42",
                                        resposta = Guid.NewGuid().ToString(),
                                        status = "RECEBIDO"
                                    });
                                }
                            }

                            if (IntegracoesAPI != null && IntegracoesAPI.doc != null && IntegracoesAPI.doc.Count > 0)
                            {
                                string NomeArquivo = string.Empty;

                                if (Parametros.FazerBackupExecucaoExterna && Parametros.ItemProcesso.TipoIntegracao == Comum.Enumeradores.TipoIntegracao.SHORT2)
                                {
                                    NomeArquivo = CriarNomeArquivo();

                                    var serializedProduto = Newtonsoft.Json.JsonConvert.SerializeObject(IntegracoesAPI);

                                    Classes.Util.SalvarArquivo(serializedProduto, NomeArquivo, _ExecutionTempPath);

                                    Parametros.ParametroGenerico = string.Format("{0}\\{1}.txt", _ExecutionTempPath, NomeArquivo);
                                }

                                Comum.Clases.CRM objCrm = null;
                                List<Comum.Clases.CRM> objListaCrm = new List<Comum.Clases.CRM>();

                                foreach (Comum.APIExterna.Modelo1.Doc d in IntegracoesAPI.doc)
                                {
                                    objCrm = new Comum.Clases.CRM()
                                    {

                                        Ativo = true,
                                        Descricao = string.Format("{0} | {1} | {2} | {3}", Parametros.ItemProcesso.TipoIntegracao.RecuperarValor(),
                                                                                      (!string.IsNullOrEmpty(d.dh_entrada) ?
                                                                                    Convert.ToDateTime(d.dh_entrada).ToString() : d.dh_entrada),
                                                                                     d.destino_celular,
                                                                                     d.resposta),
                                        FuncionarioCadastro = new Comum.Clases.Pessoa() { Identificador = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Identificador },
                                        Observacao = string.Format("{0} | {1} ", d.status, d.destino_celular),
                                        Atendimentos = new List<Comum.Clases.Agendamento>(),
                                        TipoCrm = new Comum.Clases.TipoCrm(),
                                        StatusCrm = new Comum.Clases.StatusCrm() { Identificador = "ID", Codigo = "CODIGO", CorRGB = "COR", Descricao = "DESCRICAO" }
                                    };

                                    objCrm.Cliente = new Comum.Clases.Pessoa();

                                    if (!string.IsNullOrEmpty(d.destino_celular))
                                    {
                                        objCrm.Cliente.DesTelefoneCelular = d.destino_celular;
                                    }

                                    objListaCrm.Add(objCrm);


                                    ContratoServico.CRM.GerarAgendamentoAutomatico.PeticaoGerarAgendamentoAutomatico Peticao = new ContratoServico.CRM.GerarAgendamentoAutomatico.PeticaoGerarAgendamentoAutomatico()
                                    {
                                        CodigoTipoCrmPadrao = (!string.IsNullOrEmpty(Parametros.ItemProcesso.CodigoTipoCrm) ? Parametros.ItemProcesso.CodigoTipoCrm : ControleEstoque.Parametros.Parametros.ParametrosAplicacao.CodigoTipoCrmDefault),
                                        DescricaoClientePadrao = ControleEstoque.Parametros.Parametros.ParametrosAplicacao.DescricaoClienteDefault,
                                        CRMs = objListaCrm,
                                        IdentificadorEmpresa = ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador,
                                        Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login,
                                        Integracao = true

                                    };

                                    Agente.Agente.InvocarServico<ContratoServico.CRM.GerarAgendamentoAutomatico.RespostaGerarAgendamentoAutomatico, ContratoServico.CRM.GerarAgendamentoAutomatico.PeticaoGerarAgendamentoAutomatico>(Peticao,
                                             SDK.Operacoes.operacao.GerarAgendamentoAutomatico, new Comum.ParametrosTela.Generica() { Processo = Parametros.Processo, NaoTratarErro = true, ParametroGenerico = Parametros.ParametroGenerico }, null, true);
                                }
                            }
                            else
                            {
                                FinalizarItemProcessoMemoria(Parametros.Processo, Parametros.ItemProcesso, string.Empty);
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        FinalizarItemProcessoMemoria(Parametros.Processo, Parametros.ItemProcesso, ex);
                    }
                    base.RespostaAgente(objSaida, operacao, Parametros);
                }
                else if (operacao == SDK.Operacoes.operacao.GerarAgendamentoAutomatico)
                {

                    ContratoServico.CRM.GerarAgendamentoAutomatico.RespostaGerarAgendamentoAutomatico objSaidaConvertido = (ContratoServico.CRM.GerarAgendamentoAutomatico.RespostaGerarAgendamentoAutomatico)objSaida;

                    if (objSaidaConvertido != null)
                    {
                        Comum.Clases.Processo objProcesso = (from p in Server.Classes.Processos.ListaProcessos
                                                                 where p.Identificador == Parametros.Processo.Identificador
                                                                 select p).FirstOrDefault();
                       
                       if (objSaidaConvertido.CodigoErro != Convert.ToInt32(Execao.Constantes.CodigoErro.SEM_ERRO))
                        {


                            if (File.Exists(Parametros.ParametroGenerico.ToString()))
                            {
                                FileInfo objFile = new FileInfo(Parametros.ParametroGenerico.ToString());
                                string FileName = string.Format("{0}\\{1}", _TempPath, objFile.Name);

                                File.Move(Parametros.ParametroGenerico.ToString(), FileName);
                            }

                            FinalizarItemProcessoMemoria(objProcesso, Parametros.ItemProcesso, objSaidaConvertido.DescricaoErro);
                        }
                        else
                        {

                            FinalizarItemProcessoMemoria(objProcesso, Parametros.ItemProcesso, string.Empty);
                        }

                        //base.RespostaAgente(objSaida,operacao,Parametros);
                    }

                }
                else if (operacao == SDK.Operacoes.operacao.BuscaIntegracoesAPI)
                {
                    var IntegracoesAPI = ((ContratoServico.IntegracaoAPI.BuscaIntegracoesAPI.RespostaBuscaIntegracoesAPI)objSaida).IntegracoesAPI;

                    if (IntegracoesAPI != null && IntegracoesAPI.Count > 0)
                    {
                       
                        string url = string.Empty;
                        foreach (Comum.Clases.IntegracaoAPI i in IntegracoesAPI)
                        {
                            var objItemProcesso = new Comum.Clases.ItemProcesso();

                            url = i.Url.Replace(ControleEstoque.Comum.Clases.Constantes.VARIAVEL_INT_DATA_INICIO, DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd"));
                            url = url.Replace(ControleEstoque.Comum.Clases.Constantes.VARIAVEL_INT_DATA_FIM, DateTime.Now.ToString("yyyy-MM-dd"));

                            objItemProcesso = new Comum.Clases.ItemProcesso()
                            {
                                Identificador = Guid.NewGuid().ToString(),
                                Valor = url,
                                CodigoTipoCrm = i.CodigoTipoCrm,
                                TipoIntegracao = (i.TipoIntegracao != null ? (Comum.Enumeradores.TipoIntegracao)i.TipoIntegracao : Comum.Enumeradores.TipoIntegracao.SHORT),
                                Tipo = Comum.Enumeradores.TipoProcesso.API
                            };

                            AdicionarItemProcessoMemoria(Parametros.Processo, ref objItemProcesso);

                            InvocarAPI(Parametros.Processo, objItemProcesso);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }
    }
}
