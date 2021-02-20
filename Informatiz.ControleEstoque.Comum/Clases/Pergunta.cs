using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Informatiz.ControleEstoque.Comum.Clases
{
   public class Pergunta
    {
       public string Identificador { get; set; }
        public string IdentificadorPessoaCRM { get; set; }
       public string IdentificadorAuxiliar { get; set; }
       public string DesPergunta { get; set; }
       public Boolean Obrigatoria { get; set; }
       public string Resposta { get; set; }
       public Enumeradores.Enumeradores.TipoComponente TipoComponente { get; set; }
       public Boolean Numerico { get; set; }
       public Boolean Deletar { get; set; }
       public List<PerguntaOpcao> Opcoes { get; set; }
    }
}
