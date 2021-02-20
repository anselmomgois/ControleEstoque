using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Informatiz.ControleEstoque.ContratoServico.Telas.Permissoes.Carregar
{

   public class RespostaPermissoesCarregar : RespostaGenerica
    {
        public List<Comum.Clases.GrupoPermissao> GruposPermissoes { get; set; }
        public List<Comum.Clases.Permissao> Permissoes { get; set; }
        public Comum.Clases.GrupoPermissao GrupoPermissao { get; set; }
        public List<Comum.Clases.Acao> Acoes { get; set; }
        public List<Comum.Clases.Permissao> PermissoesFuncionario { get; set; }
    }
}
