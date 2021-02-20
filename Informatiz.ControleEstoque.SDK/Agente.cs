using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;


namespace Informatiz.ControleEstoque.SDK
{
    public class AgenteApi
    {
        private static SDK.Operacoes _agente;
        public  static SDK.Operacoes Agente
        {
            get
            {
                if (_agente == null)
                {
                    _agente = new SDK.Operacoes();

#if DEBUG
                    _agente.UriServidor = ConfigurationManager.AppSettings["UrlAPIDebug"];
#else
                    _agente.UriServidor = ConfigurationManager.AppSettings["UrlAPI"];
#endif
                    _agente.DesabilitarControles += _agente_DesabilitarControles;
                    _agente.FimOperacao += _agente_FimOperacao;
                    _agente.InicioOperacao += _agente_InicioOperacao;
                    _agente.SetarCursorWait += _agente_SetarCursorWait;
                    _agente.StatusOperacao += _agente_StatusOperacao;
                    
                }
                return _agente;
            }
        }

        private static void _agente_StatusOperacao(Exception ex, object objSaida, Operacoes.operacao operacao, Comum.ParametrosTela.Generica Parametros)
        {
            
        }

        private static void _agente_SetarCursorWait(object sender, EventArgs e)
        {
            
        }

        private static void _agente_InicioOperacao(Operacoes.operacao operacao)
        {
            
        }

        private static void _agente_FimOperacao(Operacoes.operacao operacao, List<string> NomeControles, bool ExecutarFimProcesamento, Boolean NaoDesabilitarControles)
        {
            
        }

        private static void _agente_DesabilitarControles(List<string> NomeControles, bool Habilitado, Operacoes.operacao operacao)
        {
            
        }
    }
}
