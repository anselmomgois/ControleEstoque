using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using Informatiz.ControleEstoque.Comum.Atributos;
using Informatiz.ControleEstoque.Comum.Extencoes;
using System.Windows.Forms;
using System.Configuration;

namespace Informatiz.ControleEstoque.SDK
{
    public class Operacoes
    {
        public enum operacao
        {
            [ValorEnum("/api/StatusCrm/SetStatusCrm")]
            SetStatusCrm,
            [ValorEnum("/api/StatusCrm/BuscarStatusCrm")]
            BuscarStatusCrm,
            [ValorEnum("/api/StatusCrm/ExcluirSetStatusCrm")]
            ExcluirSetStatusCrm,
            [ValorEnum("/api/StatusCrm/BuscarStatusCrmDetalhe")]
            BuscarStatusCrmDetalhe,
            [ValorEnum("/api/acao/RecuperarAcoes")]
            RecuperarAcoes,
            [ValorEnum("/api/CRM/RecuperarAgendamentosSimples")]
            RecuperarAgendamentosSimples,
            [ValorEnum("/api/CRM/DesativarAgendamento")]
            DesativarAgendamento,
            [ValorEnum("/api/CRM/RecuperarAgendamentos")]
            RecuperarAgendamentos,
            [ValorEnum("/api/CRM/RecuperarAgendamento")]
            RecuperarAgendamento,
            [ValorEnum("/api/GrupoCompromisso/RecuperarGruposCompromisso")]
            RecuperarGruposCompromisso,
            [ValorEnum("/api/GrupoCompromisso/DeletarGrupoCompromisso")]
            DeletarGrupoCompromisso,
            [ValorEnum("/api/Pessoa/RecuperarPessoas")]
            RecuperarPessoas,
            [ValorEnum("/api/CRM/AtualizarAgendamento")]
            AtualizarAgendamento,
            [ValorEnum("/api/CRM/InserirAgendamento")]
            InserirAgendamento,
            [ValorEnum("/api/Administradora/RecuperarAdministradoras")]
            RecuperarAdministradoras,
            [ValorEnum("/api/Administradora/InserirAdministradora")]
            InserirAdministradora,
            [ValorEnum("/api/Administradora/AtualizarAdministradora")]
            AtualizarAdministradora,
            [ValorEnum("/api/Administradora/DeletarAdministradora")]
            DeletarAdministradora,
            [ValorEnum("/api/Administradora/RecuperarAdministradora")]
            RecuperarAdministradora,
            [ValorEnum("/api/Usuario/Logar")]
            Logar,
            [ValorEnum("/api/Usuario/DeletarSessao")]
            DeletarSessao,
            [ValorEnum("/api/Usuario/AtivarSessao")]
            AtivarSessao,
            [ValorEnum("/api/TipoEmpregado/SetTipoEmpregado")]
            SetTipoEmpregado,
            [ValorEnum("/api/TipoEmpregado/BuscarTipoEmpregado")]
            BuscarTipoEmpregado,
            [ValorEnum("/api/TipoEmpregado/PesquisarTipoEmpregado")]
            PesquisarTipoEmpregado,
            [ValorEnum("/api/TipoEmpregado/ExcluirTipoEmpregado")]
            ExcluirTipoEmpregado,
            [ValorEnum("/api/TipoCrm/SetTipoCrm")]
            SetTipoCrm,
            [ValorEnum("/api/TipoCrm/PesquisarTipoCrm")]
            PesquisarTipoCrm,
            [ValorEnum("/api/TipoCrm/BuscarTipoCrm")]
            BuscarTipoCrm,
            [ValorEnum("/api/TipoCrm/ExcluirTipoCrm")]
            ExcluirTipoCrm,
            [ValorEnum("/api/Parametro/RecuperarParametros")]
            RecuperarParametros,
            [ValorEnum("/api/Parametro/SetParametros")]
            SetParametros,
            [ValorEnum("/api/GuardarFuncionario/Carregar")]
            CarregarGuardarFuncionario,
            [ValorEnum("/api/GuardarCRM/Carregar")]
            CarregarGuardarCRM,
            [ValorEnum("/api/GuardarCliente/Carregar")]
            CarregarGuardarCliente,
            [ValorEnum("/api/GuardarAgendamento/Carregar")]
            CarregarGuardarAgendamento,
            [ValorEnum("/api/Endereco/RegistrarEndereco")]
            RegistrarEndereco,
            [ValorEnum("/api/BuscarCRM/Carregar")]
            CarregarBuscarCRM,
            [ValorEnum("/api/Pessoa/InserirPessoa")]
            InserirPessoa,
            [ValorEnum("/api/Pessoa/AtualizarPessoa")]
            AtualizarPessoa,
            [ValorEnum("/api/GuardarFornecedor/Carregar")]
            CarregarGuardarFornecedor,
            [ValorEnum("/api/Pessoa/DesativarPessoa")]
            DesativarPessoa,
            [ValorEnum("/api/Permissao/Carregar")]
            CarregarPermissao,
            [ValorEnum("/api/Permissao/GravarPermissoesUsuario")]
            GravarPermissoesUsuario,
            [ValorEnum("/api/Permissao/GravarGrupoPermissao")]
            GravarGrupoPermissao,
            [ValorEnum("/api/GuardarEmpresa/Carregar")]
            CarregarGuardarEmpresa,
            [ValorEnum("/api/Empresa/AtualizarEmpresa")]
            AtualizarEmpresa,
            [ValorEnum("/api/ProdutoServico/RecuperarProdutosServicos")]
            RecuperarProdutosServicos,
            [ValorEnum("/api/ProdutoServico/RecuperarProdutos")]
            RecuperarProdutos,
            [ValorEnum("/api/ProdutoServico/DeletarProdutoServico")]
            DeletarProdutoServico,
            [ValorEnum("/api/Cor/RecuperarCores")]
            RecuperarCores,
            [ValorEnum("/api/Cor/DeletarCor")]
            DeletarCor,
            [ValorEnum("/api/Cor/RecuperarCor")]
            RecuperarCor,
            [ValorEnum("/api/GrupoPermissao/RecuperarGrupos")]
            RecuperarGrupos,
            [ValorEnum("/api/GrupoPermissao/DeletarGrupoPermissao")]
            DeletarGrupoPermissao,
            [ValorEnum("/api/Filial/RecuperarFiliais")]
            RecuperarFiliais,
            [ValorEnum("/api/Compra/RecuperarCompras")]
            RecuperarCompras,
            [ValorEnum("/api/Compra/SetEstoqueAtual")]
            SetEstoqueAtual,
            [ValorEnum("/api/Compra/RecuperarProdutoCompras")]
            RecuperarProdutoCompras,
            [ValorEnum("/api/GuardarCompra/Carregar")]
            CarregarGuardarCompra,
            [ValorEnum("/api/UnidadeMedida/RecuperarUnidadesMedida")]
            RecuperarUnidadesMedida,
            [ValorEnum("/api/FormaPagamento/SetFormaPagamento")]
            SetFormaPagamento,
            [ValorEnum("/api/FormaPagamento/BuscarFormaPagamentoDetalhe")]
            BuscarFormaPagamentoDetalhe,
            [ValorEnum("/api/FormaPagamento/BuscarFormaPagamento")]
            BuscarFormaPagamento,
            [ValorEnum("/api/FormaPagamento/ExcluirSetFormaPagamento")]
            ExcluirSetFormaPagamento,
            [ValorEnum("/api/Compra/SetCompra")]
            SetCompra,
            [ValorEnum("/api/Erro/InserirErro")]
            InserirErro,
            [ValorEnum("/api/GuardarProdutoServico/Carregar")]
            CarregarGuardarProdutoServico,
            [ValorEnum("/api/ProdutoServico/SetProdutoServico")]
            SetProdutoServico,
            [ValorEnum("/api/Parametro/RecuperarGrupoParametros")]
            RecuperarGrupoParametros,
            [ValorEnum("/api/GuardarProdutoFilial/Carregar")]
            CarregarGuardarProdutoFilial,
            [ValorEnum("/api/GuardarProdutoPromocao/Carregar")]
            CarregarGuardarProdutoPromocao,
            [ValorEnum("/api/GuardarVendaSupermercado/Carregar")]
            CarregarGuardarVendaSupermercado,
            [ValorEnum("/api/ProdutoPromocao/SetProdutoPromocao")]
            SetProdutoPromocao,
            [ValorEnum("/api/Caixa/BuscarCaixa")]
            BuscarCaixa,
            [ValorEnum("/api/Caixa/BuscarCaixaByHost")]
            BuscarCaixaByHost,
            [ValorEnum("/api/Caixa/BuscarCaixaDetalhe")]
            BuscarCaixaDetalhe,
            [ValorEnum("/api/Caixa/ExcluirSetCaixa")]
            ExcluirSetCaixa,
            [ValorEnum("/api/Caixa/FecharCaixa")]
            FecharCaixa,
            [ValorEnum("/api/Caixa/SetCaixa")]
            SetCaixa,
            [ValorEnum("/api/GuardarTipoCrmConfig/Carregar")]
            CarregarGuardarTipoCrmConfig,
            [ValorEnum("/api/GuardarIntegracaoAPI/Carregar")]
            CarregarGuardarIntegracaoAPI,
            [ValorEnum("/api/Chave/ValidarChave")]
            ValidarChave,
            [ValorEnum("/api/Chave/RecuperarChaves")]
            RecuperarChaves,
            [ValorEnum("/api/Proposta/RecuperarProposta")]
            RecuperarProposta,
            [ValorEnum("/api/Proposta/SetProposta")]
            SetProposta,
            [ValorEnum("/api/Sessao/AtualizarSessao")]
            AtualizarSessao,
            [ValorEnum("/api/Pessoa/TrocarSenhaPessoa")]
            TrocarSenhaPessoa,
            [ValorEnum("/api/Cor/SetCor")]
            SetCor,
            [ValorEnum("/api/GrupoCompromisso/RecuperarGrupoCompromisso")]
            RecuperarGrupoCompromisso,
            [ValorEnum("/api/GrupoCompromisso/SetGrupoCompromisso")]
            SetGrupoCompromisso,
            [ValorEnum("/api/GrupoProduto/RecuperarGruposProduto")]
            RecuperarGruposProduto,
            [ValorEnum("/api/GrupoProduto/DeletarGrupoProduto")]
            DeletarGrupoProduto,
            [ValorEnum("/api/UnidadeMedida/RecuperarUnidadeMedida")]
            RecuperarUnidadeMedida,
            [ValorEnum("/api/UnidadeMedida/SetUnidadeMedida")]
            SetUnidadeMedida,
            [ValorEnum("/api/Informatiz/AlterarImagemCentral")]
            AlterarImagemCentral,
            [ValorEnum("/api/UnidadeMedida/DeletarUnidadeMedida")]
            DeletarUnidadeMedida,
            [ValorEnum("/api/Endereco/RecuperarEstado")]
            RecuperarEstado,
            [ValorEnum("/api/Endereco/RecuperarCidades")]
            RecuperarCidades,
            [ValorEnum("/api/Endereco/RecuperarBairro")]
            RecuperarBairro,
            [ValorEnum("/api/Endereco/PesquisarEndereco")]
            PesquisarEndereco,
            [ValorEnum("/api/Endereco/SetCidades")]
            SetCidades,
            [ValorEnum("/api/Endereco/SetBairro")]
            SetBairro,
            [ValorEnum("/api/Endereco/SetEndereco")]
            SetEndereco,
            [ValorEnum("/api/Caixa/SetAberturaCaixa")]
            SetAberturaCaixa,
            [ValorEnum("/api/Usuario/ValidarTipoEmpregado")]
            ValidarTipoEmpregado,
            [ValorEnum("/api/IntegracaoAPI/BuscaIntegracoesAPI")]
            BuscaIntegracoesAPI,
            [ValorEnum("/api/IntegracaoAPI/DeletarIntegracaoAPI")]
            DeletarIntegracaoAPI,
            [ValorEnum("/api/IntegracaoAPI/RecuperarIntegracaoAPI")]
            RecuperarIntegracaoAPI,
            [ValorEnum("/api/IntegracaoAPI/SetIntegracaoAPI")]
            SetIntegracaoAPI,
            [ValorEnum("/api/SegmentoComercial/PesquisarSegmentoComercial")]
            PesquisarSegmentoComercial,
            [ValorEnum("/api/SegmentoComercial/DeletarSegmentoComercial")]
            DeletarSegmentoComercial,
            [ValorEnum("/api/SegmentoComercial/RecuperarSegmentoComercial")]
            RecuperarSegmentoComercial,
            [ValorEnum("/api/SegmentoComercial/SetSegmentoComercial")]
            SetSegmentoComercial,
            [ValorEnum("/api/StatusCrm/BuscarStatusCrmSimples")]
            BuscarStatusCrmSimples,
            [ValorEnum("/api/GuardarTipoCrm/Carregar")]
            CarregarGuardarTipoCrm,
            [ValorEnum("/api/CRM/GerarAgendamentoAutomatico")]
            GerarAgendamentoAutomatico,
            [ValorEnum("/ExecucaoAPIExterna")]
            ExecucaoAPIExterna,
            [ValorEnum("/api/ProdutoPromocao/PesquisarProdutoPromocao")]
            PesquisarProdutoPromocao,
            [ValorEnum("/api/ProdutoPromocao/DesativarProdutoPromocao")]
            DesativarProdutoPromocao,
            [ValorEnum("/api/Marca/RecuperarMarcas")]
            RecuperarMarcas,
            [ValorEnum("/api/Marca/DeletarProdutoMarca")]
            DeletarProdutoMarca,
            [ValorEnum("/api/ProdutoCategoria/RecuperarCategorias")]
            RecuperarCategorias,
            [ValorEnum("/api/ProdutoCategoria/DeletarProdutoCategoria")]
            DeletarProdutoCategoria,
            [ValorEnum("/api/Observacao/DeletarObservacao")]
            DeletarObservacao,
            [ValorEnum("/api/Observacao/BuscarObservacao")]
            BuscarObservacao,
            [ValorEnum("/api/Observacao/RecuperarObservacao")]
            RecuperarObservacao,
            [ValorEnum("/api/Observacao/SetObservacao")]
            SetObservacao,
            [ValorEnum("/api/Venda/SetVenda")]
            SetVenda,
            [ValorEnum("/api/Venda/FecharVenda")]
            FecharVenda,
            [ValorEnum("/api/Venda/RecuperarVendaEmCurso")]
            RecuperarVendaEmCurso,
            [ValorEnum("/api/Venda/RecuperarVendaPorComanda")]
            RecuperarVendaPorComanda,
            [ValorEnum("/api/Venda/ModificarPrecoProdutoVenda")]
            ModificarPrecoProdutoVenda,
            [ValorEnum("/api/Venda/RegistrarSangria")]
            RegistrarSangria,
            [ValorEnum("/api/Venda/RegistrarSuprimento")]
            RegistrarSuprimento,
            [ValorEnum("/api/Venda/CancelarItems")]
            CancelarItems,
            [ValorEnum("/api/Venda/RecuperarPagamentosCaixa")]
            RecuperarPagamentosCaixa,
            [ValorEnum("/api/Setor/SetSetor")]
            SetSetor,
            [ValorEnum("/api/Setor/BuscarSetores")]
            BuscarSetores,
            [ValorEnum("/api/Setor/BuscarSetor")]
            BuscarSetor,
            [ValorEnum("/api/Setor/ExcluirSetor")]
            ExcluirSetor,
            [ValorEnum("/api/ProdutoFilial/SetProdutoFilial")]
            SetProdutoFilial,
            [ValorEnum("/api/Mesa/BuscarMesas")]
            BuscarMesas,
            [ValorEnum("/api/Mesa/RecuperarMesa")]
            RecuperarMesa,
            [ValorEnum("/api/Mesa/SetMesa")]
            SetMesa,
            [ValorEnum("/api/GuardarMesa/Carregar")]
            CarregarGuardarMesa,
            [ValorEnum("/api/Venda/InformarDadosVenda")]
            InformarDadosVenda,
            [ValorEnum("/api/Venda/RecuperarVendaPorMesa")]
            RecuperarVendaPorMesa,
            [ValorEnum("/api/Processo/RecuperarProcessos")]
            RecuperarProcessos,
            [ValorEnum("/api/Processo/SetProcesso")]
            SetProcesso,
            [ValorEnum("/api/Processo/RecuperarProcesso")]
            RecuperarProcesso,
            [ValorEnum("/api/Processo/RegistrarItemProcesso")]
            RegistrarItemProcesso,
            [ValorEnum("/api/Processo/RecuperarItemsProcesso")]
            RecuperarItemsProcesso,
            [ValorEnum("/api/Relatorio/RecuperarFechamentoCaixa")]
            RecuperarFechamentoCaixa
        }

        public delegate void StatusOperacaoDelegate(Exception ex, object objSaida, operacao operacao, Comum.ParametrosTela.Generica Parametros);
        public event StatusOperacaoDelegate StatusOperacao;
        public event EventHandler SetarCursorWait;
        public delegate void DesabilitarControlesDelegate(List<string> NomeControles, Boolean Habilitado, operacao operacao);
        public event DesabilitarControlesDelegate DesabilitarControles;
        public delegate void InicioProcesamentoDelegate(operacao operacao);
        public event InicioProcesamentoDelegate InicioOperacao;
        public delegate void FimProcesamentoDelegate(operacao operacao, List<string> NomeControles, Boolean ExecutarFimProcesamento, Boolean NaoDesabilitarControles);
        public event FimProcesamentoDelegate FimOperacao;

        public string UriServidor { get; set; }
        private Int32 TimeOut
        {
            get
            {
                return !string.IsNullOrEmpty(ConfigurationManager.AppSettings["TimeOut"]) && Util.IsNumeric(ConfigurationManager.AppSettings["TimeOut"]) ? 
                                             Convert.ToInt32(ConfigurationManager.AppSettings["TimeOut"]) : 2;
            }
        }
        public async void InvocarServico<S, E>(E objEntrada, operacao operacao, Comum.ParametrosTela.Generica Parametros, List<string> NomeControles, Boolean ExecutarFimProcesamento)
        {

            try
            {

                if (string.IsNullOrEmpty(UriServidor))
                {
                    throw new Exception("URL servidor não informada");
                }

                if (objEntrada == null)
                {
                    throw new Exception("objento de entrada vazio");
                }

                InicioOperacao(operacao);
                SetarCursorWait(null, null);
                if (Parametros != null && !Parametros.NaoDesabilitarControles) { DesabilitarControles(NomeControles, false,operacao); }

                S objSaida;

                using (var client = new HttpClient())
                {
                    var serializedProduto = JsonConvert.SerializeObject(objEntrada);
                    var content = new StringContent(serializedProduto, Encoding.UTF8, "application/json");

                    client.Timeout = new TimeSpan(0, TimeOut, 0);
                    var result = await client.PostAsync(UriServidor + operacao.RecuperarValor(), content);

                    var ItemsJsonString = await result.Content.ReadAsStringAsync();

                    if (ItemsJsonString.Contains("Message"))
                    {
                        ContratoServico.RespostaGenerica objSaidaGenerico = new ContratoServico.RespostaGenerica();
                        string objStringTradada = ItemsJsonString;

                        string[] objStrCor = objStringTradada.Split(Convert.ToChar(":"));

                        if (objStrCor != null && objStrCor.Count() > 0)
                        {
                            if (objStrCor.Count() > 1)
                            {
                                objStringTradada = objStrCor.LastOrDefault().Replace("\\r\\n", " ");
                            }
                            else
                            {
                                objStringTradada = objStrCor.FirstOrDefault();
                            }
                        }

                        objSaidaGenerico.CodigoErro = (Int32)Execao.Constantes.CodigoErro.ERRO_NEGOCIO;
                        objSaidaGenerico.DescricaoErro = objStringTradada;

                        StatusOperacao(null, objSaidaGenerico, operacao, Parametros);
                    }
                    else
                    {
                        //{"Message":"O código do status é obrigatório.\r\n"}
                        objSaida = JsonConvert.DeserializeObject<S>(ItemsJsonString);

                        StatusOperacao(null, objSaida, operacao, Parametros);
                    }



                }

                FimOperacao(operacao, NomeControles, ExecutarFimProcesamento, (Parametros != null ? Parametros.NaoDesabilitarControles :false));
            }
            catch (Exception ex)
            {

                StatusOperacao(ex, null, operacao, Parametros);
                FimOperacao(operacao, NomeControles, ExecutarFimProcesamento, (Parametros != null ? Parametros.NaoDesabilitarControles : false));

            }
        }
        public async void InvocarServico<S>(operacao operacao, Comum.ParametrosTela.Generica Parametros, List<string> NomeControles, Boolean ExecutarFimProcesamento)
        {

            try
            {

                if (string.IsNullOrEmpty(UriServidor))
                {
                    throw new Exception("URL servidor não informada");
                }

                InicioOperacao(operacao);
                if (Parametros != null && !Parametros.NaoDesabilitarControles) { DesabilitarControles(NomeControles, false,operacao); }
                SetarCursorWait(null, null);

                S objSaida;

                using (var client = new HttpClient())
                {
                    client.Timeout = new TimeSpan(0, TimeOut, 0);
                    var result = await client.PostAsync(UriServidor + operacao.RecuperarValor(), null);

                    var ItemsJsonString = await result.Content.ReadAsStringAsync();
                    objSaida = JsonConvert.DeserializeObject<S>(ItemsJsonString);


                }

                StatusOperacao(null, objSaida, operacao, Parametros);
                FimOperacao(operacao, NomeControles, ExecutarFimProcesamento, (Parametros != null ? Parametros.NaoDesabilitarControles : false));
            }
            catch (Exception ex)
            {

                StatusOperacao(ex, null, operacao, Parametros);
                FimOperacao(operacao, NomeControles, ExecutarFimProcesamento, (Parametros != null ? Parametros.NaoDesabilitarControles : false));
            }
        }

        public async void InvocarServicoExterno<S>(operacao operacao,Comum.ParametrosTela.Generica Parametros, List<string> NomeControles, Boolean ExecutarFimProcesamento, string UrlAPI)
        {

            try
            {

                if (string.IsNullOrEmpty(UriServidor))
                {
                    throw new Exception("URL servidor não informada");
                }

                InicioOperacao(operacao);
                if (Parametros != null && !Parametros.NaoDesabilitarControles) { DesabilitarControles(NomeControles, false, operacao); }
                SetarCursorWait(null, null);

                S objSaida;

                using (var client = new HttpClient())
                {
                    var result = await client.GetAsync(UrlAPI);

                    var ItemsJsonString = await result.Content.ReadAsStringAsync();
                    objSaida = JsonConvert.DeserializeObject<S>(ItemsJsonString);

                }

                StatusOperacao(null, objSaida, operacao, Parametros);
                FimOperacao(operacao, NomeControles, ExecutarFimProcesamento, (Parametros != null ? Parametros.NaoDesabilitarControles : false));
            }
            catch (Exception ex)
            {

                StatusOperacao(ex, null, operacao, Parametros);
                FimOperacao(operacao, NomeControles, ExecutarFimProcesamento, (Parametros != null ? Parametros.NaoDesabilitarControles : false));
            }
        }

        public async void InvocarServicoExterno<S,B>(operacao operacao, Comum.ParametrosTela.Generica Parametros, List<string> NomeControles, Boolean ExecutarFimProcesamento, string UrlAPI)
        {

            try
            {

                if (string.IsNullOrEmpty(UriServidor))
                {
                    throw new Exception("URL servidor não informada");
                }

                InicioOperacao(operacao);
                if (Parametros != null && !Parametros.NaoDesabilitarControles) { DesabilitarControles(NomeControles, false,operacao); }
                SetarCursorWait(null, null);

                object objSaida;

                using (var client = new HttpClient())
                {
                    var result = await client.GetAsync(UrlAPI);

                    var ItemsJsonString = await result.Content.ReadAsStringAsync();

                    if (Parametros != null && Parametros.Processo != null && Parametros.ItemProcesso.TipoIntegracao == Comum.Enumeradores.TipoIntegracao.SHORT2)
                    {
                        try
                        {
                            objSaida = JsonConvert.DeserializeObject<S>(ItemsJsonString);
                        }
                        catch (Exception ex)
                        {

                            try
                            {
                                objSaida = JsonConvert.DeserializeObject<B>(ItemsJsonString);

                            }
                            catch (Exception ex1)
                            {
                                throw ex;
                            }

                        }
                                              

                    }
                    else
                    {
                        objSaida = JsonConvert.DeserializeObject<S>(ItemsJsonString);
                    }

                }

                StatusOperacao(null, objSaida, operacao, Parametros);
                FimOperacao(operacao, NomeControles, ExecutarFimProcesamento, (Parametros != null ? Parametros.NaoDesabilitarControles : false));
            }
            catch (Exception ex)
            {

                StatusOperacao(ex, null, operacao, Parametros);
                FimOperacao(operacao, NomeControles, ExecutarFimProcesamento, (Parametros != null ? Parametros.NaoDesabilitarControles : false));
            }
        }

    }
}
