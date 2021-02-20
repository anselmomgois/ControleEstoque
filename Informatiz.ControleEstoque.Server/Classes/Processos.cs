using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace Informatiz.ControleEstoque.Server.Classes
{
   public class Processos
    {
        public static ConcurrentBag<Comum.Clases.Processo> ListaProcessos { get; set; }
    }
}
