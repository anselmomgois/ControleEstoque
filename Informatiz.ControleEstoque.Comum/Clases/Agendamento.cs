using System;
using System.Collections.Generic;

namespace Informatiz.ControleEstoque.Comum.Clases
{
     public class Agendamento
    {
        public List<Pessoa> FuncionariosResponsaveis { get; set; }
        public DateTime DataAtendimento { get; set; }
        public DateTime DataAtendimentoFim { get; set; }
        public List<Pergunta> Perguntas { get; set; }
        public GrupoCompromisso NivelAtendimento { get; set; }
        public string Identificador { get; set; }
        public string Descricao { get; set; }
        public Boolean Concluido { get; set; }
    }
}
