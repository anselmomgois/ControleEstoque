using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Informatiz.ControleEstoque.Parametros
{
    public static class Parametros
    {

        public static Comum.Clases.Usuario InformacaoUsuario { get; set; }
        public static string IdentificadorSessao { get; set; }
        public static string DiretorioArquivos { get; set; }
        public static string Versao { get; set; }
        public static ParametrosAplicacao ParametrosAplicacao { get; set; }
    }
}
