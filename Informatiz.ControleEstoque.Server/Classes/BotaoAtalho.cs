using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Informatiz.ControleEstoque.Server.Classes
{
   public class BotaoAtalho
    {
        public string NomeTab { get; set; }
        public string NomeGrupo { get; set; }
        public string NomeBotao { get; set; }
        public Boolean Alt { get; set; }
        public Boolean Control { get; set; }
        public Boolean Shift { get; set; }
        public System.Windows.Forms.Keys Key { get; set; }
    }
}
