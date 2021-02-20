using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Informatiz.ControleEstoque.ContratoServico.Telas.GuardarAgendamento.Carregar
{

    public class RespostaGuardarAgendamentoCarregar : RespostaGenerica
    {
        public List<Comum.Clases.GrupoCompromisso> GruposCompromisso { get; set; }
        public List<Comum.Clases.Pessoa> Funcionarios { get; set; }
    }
}
