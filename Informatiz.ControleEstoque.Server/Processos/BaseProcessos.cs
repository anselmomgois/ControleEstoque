using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Informatiz.ControleEstoque.Server.Classes;
using Informatiz.ControleEstoque.Comum.Extencoes;
namespace Informatiz.ControleEstoque.Server.Processos
{
    public class BaseProcessos
    {
        #region"Variaveis"
        public AgenteServico Agente { get; set; }
        public List<SDK.Operacoes.operacao> ServicosEmProcesamento { get; set; }
        private object objLockItemProcesso = new object();
        private object objLockFinalizarProcesso = new object();
        private Comum.Clases.Processo _ProcessoCorrente = null;
        private Comum.Clases.ItemProcesso _ItemProcessoCorrente = null;

        #endregion

        #region "Construtor"


        public BaseProcessos()
        {

            Agente = new AgenteServico();

            Agente.Agente.StatusOperacao += Agente_StatusOperacao;
            Agente.Agente.SetarCursorWait += Agente_SetarCursorWait;
            Agente.Agente.DesabilitarControles += Agente_DesabilitarControles;
            Agente.Agente.InicioOperacao += Agente_InicioOperacao;
            Agente.Agente.FimOperacao += Agente_FimOperacao;
        }


        #endregion

        #region "Propriedades"

        public string IdentificadorProcesso
        {
            get
            {
                return _ProcessoCorrente != null ? _ProcessoCorrente.Identificador : string.Empty;
            }
        }


        #endregion

        #region "Metodos"

        private void Agente_DesabilitarControles(List<string> NomeControles, bool Habilitado, SDK.Operacoes.operacao operacao)
        {

        }

        private void Agente_SetarCursorWait(object sender, EventArgs e)
        {

        }

        protected virtual void RespostaAgente(object objSaida, SDK.Operacoes.operacao operacao, Comum.ParametrosTela.Generica Parametros)
        {

        }

        private void Agente_StatusOperacao(Exception ex, object objSaida, SDK.Operacoes.operacao operacao, Comum.ParametrosTela.Generica Parametros)
        {
            try
            {
                if (objSaida != null)
                {

                    if (objSaida.GetType() == typeof(ContratoServico.RespostaGenerica))
                    {

                        if (!Parametros.NaoTratarErro)
                        {
                            ContratoServico.RespostaGenerica objSaidaConvertido = (ContratoServico.RespostaGenerica)objSaida;

                            if (objSaidaConvertido.CodigoErro != Convert.ToInt32(Execao.Constantes.CodigoErro.SEM_ERRO) &&
                                objSaidaConvertido.CodigoErro != Convert.ToInt32(Execao.Constantes.CodigoErro.ERRO_ESPERADO))
                            {
                                throw new Exception(objSaidaConvertido.DescricaoErro);
                            }
                        }

                        RespostaAgente(objSaida, operacao, Parametros);
                    }
                    else
                    {
                        RespostaAgente(objSaida, operacao, Parametros);
                    }
                }
                else
                {
                    Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
                }

            }
            catch (Execao.ExecaoNegocio ex1)
            {
                Util.ExibirMensagemErro(ex1.Descricao);
            }
            catch (Exception ex1)
            {
                Util.LogarErro(new Comum.Clases.Erro { Execao = ex1, DesErro = ex1.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void Agente_FimOperacao(SDK.Operacoes.operacao operacao, List<string> NomeControles, Boolean ExecutarFimProcessamento, Boolean NaoDesabilitarControles)
        {

        }

        private void Agente_InicioOperacao(SDK.Operacoes.operacao operacao)
        {

        }

        protected virtual void ExecutarProcesso(Comum.Clases.Processo Processo, Comum.Clases.ItemProcesso ItemProcesso)
        {

        }

        protected virtual void FinalizarProcesso(Comum.Clases.Processo Processo, Comum.Clases.ItemProcesso ItemProcesso)
        {

        }

        public void Executar(Comum.Clases.Processo processo, Comum.Clases.ItemProcesso ItemProcesso)
        {
            try
            {
                _ProcessoCorrente = Classes.Processos.ListaProcessos.FirstOrDefault(p => p.Identificador == processo.Identificador);

                if (!processo.PorHorario && ItemProcesso != null)
                {
                    if (_ProcessoCorrente.Items != null && _ProcessoCorrente.Items.Count > 0)
                    {
                        _ItemProcessoCorrente = _ProcessoCorrente.Items.Find(ip => ip.Identificador == ItemProcesso.Identificador);

                        if (_ItemProcessoCorrente != null)
                        {
                            _ItemProcessoCorrente.EmExecucao = true;
                            _ItemProcessoCorrente.InicioExecucao = DateTime.Now;
                        }
                    }

                }

                if (!_ProcessoCorrente.EmExecucao)
                {
                    _ProcessoCorrente.InicioExecucao = DateTime.Now;
                    _ProcessoCorrente.EmExecucao = true;
                }


                ExecutarProcesso(processo, ItemProcesso);
            }
            catch (Exception ex)
            {
                Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = Parametros.Parametros.InformacaoUsuario.Login });
            }

        }

        public void AdicionarItemProcessoMemoria(Comum.Clases.Processo Processo, ref Comum.Clases.ItemProcesso ItemProcesso)
        {
            lock (objLockItemProcesso)
            {
                Comum.Clases.Processo objProcesso = (from p in Server.Classes.Processos.ListaProcessos
                                                     where p.Identificador == Processo.Identificador
                                                     select p).FirstOrDefault();

                if (objProcesso != null)
                {

                    if (objProcesso.Items == null) objProcesso.Items = new List<Comum.Clases.ItemProcesso>();

                    ItemProcesso.EmExecucao = true;
                    ItemProcesso.Identificador = Guid.NewGuid().ToString();
                    ItemProcesso.InicioExecucao = DateTime.Now;

                    objProcesso.Items.Add(ItemProcesso);
                }
            }
        }
        public void FinalizarItemProcessoMemoria(Comum.Clases.Processo Processo, Comum.Clases.ItemProcesso ItemProcesso, Exception objException)
        {
            lock (objLockItemProcesso)
            {
                Comum.Clases.Processo objProcesso = (from p in Server.Classes.Processos.ListaProcessos
                                                     where p.Identificador == Processo.Identificador
                                                     select p).FirstOrDefault();

                if (objProcesso != null && objProcesso.Items != null && objProcesso.Items.Count > 0)
                {

                    Comum.Clases.ItemProcesso objItemProcesso = objProcesso.Items.Find(ip => ip.Identificador == ItemProcesso.Identificador);

                    if (objItemProcesso != null)
                    {
                        objItemProcesso.FimExecucao = DateTime.Now;
                        objItemProcesso.EmExecucao = false;

                        if (objItemProcesso.LogProcesso == null) objItemProcesso.LogProcesso = new List<Comum.Clases.LogProcesso>();

                        objItemProcesso.LogProcesso.Add(new Comum.Clases.LogProcesso()
                        {
                            Data = DateTime.Now,
                            Log = objException != null ? objException.ToString() : null
                        });
                    }

                }


            }
        }

        public void FinalizarItemProcessoMemoria(Comum.Clases.Processo Processo, Comum.Clases.ItemProcesso ItemProcesso, string objDescricaoErro)
        {
            lock (objLockItemProcesso)
            {
                Comum.Clases.Processo objProcesso = (from p in Server.Classes.Processos.ListaProcessos
                                                     where p.Identificador == Processo.Identificador
                                                     select p).FirstOrDefault();

                if (objProcesso != null && objProcesso.Items != null && objProcesso.Items.Count > 0)
                {

                    Comum.Clases.ItemProcesso objItemProcesso = objProcesso.Items.Find(ip => ip.Identificador == ItemProcesso.Identificador);

                    if (objItemProcesso != null)
                    {
                        objItemProcesso.FimExecucao = DateTime.Now;
                        objItemProcesso.EmExecucao = false;

                        if (objItemProcesso.LogProcesso == null) objItemProcesso.LogProcesso = new List<Comum.Clases.LogProcesso>();

                        objItemProcesso.LogProcesso.Add(new Comum.Clases.LogProcesso()
                        {
                            Data = DateTime.Now,
                            Log = !string.IsNullOrEmpty(objDescricaoErro) ? objDescricaoErro : "Item Executado com sucesso."
                        });
                    }

                }


            }
        }
        public void Finalizar(Comum.Clases.Processo processo, Comum.Clases.ItemProcesso ItemProcesso, Exception objException)
        {
            try
            {
                lock (objLockFinalizarProcesso)
                {
                    _ProcessoCorrente = Classes.Processos.ListaProcessos.FirstOrDefault(p => p.Identificador == processo.Identificador);

                    if (_ProcessoCorrente.ItemsExecutados == null) _ProcessoCorrente.ItemsExecutados = new List<Comum.Clases.ItemProcesso>();
                    if (_ProcessoCorrente.Items != null && _ProcessoCorrente.Items.Count > 0)
                    {
                        foreach (var i in _ProcessoCorrente.Items)
                        {
                            _ProcessoCorrente.ItemsExecutados.Add(i.Clone<Comum.Clases.ItemProcesso>());
                        }

                        _ProcessoCorrente.Items.Clear();
                    }
                    _ProcessoCorrente.UltimaExecucao = DateTime.Now;
                    FinalizarProcesso(processo, ItemProcesso);
                    _ProcessoCorrente.EmExecucao = false;

                }
            }
            catch (Exception ex)
            {
                Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = Parametros.Parametros.InformacaoUsuario.Login });
            }
        }
        #endregion

        #region "Eventos"


        #endregion
    }
}
