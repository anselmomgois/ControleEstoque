using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;


namespace Informatiz.ControleEstoque.Server.Classes
{
    public class AgenteServico
    {
        private SDK.Operacoes _agente;
        public SDK.Operacoes Agente
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
                }
                return _agente;
            }
        }

   
       public static string Usuario { get; set; }
 
    }
}
