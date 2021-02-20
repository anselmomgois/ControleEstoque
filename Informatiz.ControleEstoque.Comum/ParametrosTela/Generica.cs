using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Informatiz.ControleEstoque.Comum.ParametrosTela
{
   public class Generica
    {
        public Boolean PreencherObjeto { get; set; }
        public Boolean ExibirMensagemNenhumRegistro { get; set; }
        public Boolean ExibirMensagemExclusao { get; set; }
        public string DiferenciadorChamada { get; set; }
        public Boolean Enter { get; set; }
        public Boolean Tab { get; set; }
        public Comum.Clases.Processo Processo { get; set; }
        public Comum.Clases.ItemProcesso ItemProcesso { get; set; }
        public Boolean NaoTratarErro { get; set; }
        public Boolean NaoDesabilitarControles { get; set; }
        public Comum.Clases.ProdutoDisponivelVenda ProdutoVenda { get; set; }
        public object ParametroGenerico { get; set; }
        public Boolean FazerBackupExecucaoExterna { get; set; }
        public Boolean CaixaSemDiferenca { get; set; }
        public string NomeSupervisor { get; set; }
        
    }
}
