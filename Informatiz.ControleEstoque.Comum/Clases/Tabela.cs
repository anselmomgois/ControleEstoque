using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Informatiz.ControleEstoque.Comum.Clases
{
    public class Tabela
    {

        public string NomeTabela { get; set; }
        public List<Linha> Linhas { get; set; }
        public List<Coluna> Colunas { get; set; }
        public List<Coluna> ColunasValidacao { get; set; }
        public List<Coluna> ColunasOrderBy { get; set; }
        public Boolean ValidarComTodasColunas { get; set; }
    }
}
