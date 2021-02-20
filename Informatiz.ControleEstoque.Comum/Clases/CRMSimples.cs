using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Informatiz.ControleEstoque.Comum.Clases
{
    public class CRMSimples
    {

        public string UsuarioCriacao { get; set; }
        public string Identificador { get; set; }
        public string Responsaveis { get; set; }
        public string Cliente { get; set; }
        public string Descricao { get; set; }
        public string CorStatus { get; set; }
        public Boolean Ativo { get; set; }
        public Int32 Itens { get; set; }
        public string TelefoneFixo { get; set; }
        public string TelefoneCelular { get; set; }
        public List<string> UsuariosResponsaveis { get; set; }
        public DateTime DataProximoCompromisso { get; set; }
          
    }
}
