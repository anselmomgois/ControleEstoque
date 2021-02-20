using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Informatiz.ControleEstoque.Execao
{
    public class Constantes
    {

        public enum CodigoErro
        { 
          ERRO_PARAMETRO = 1,
          ERRO_EXECUCAO = 2,
          ERRO_NEGOCIO = 3,
          ERRO_INDEFINIDO = 4,
          SEM_ERRO = 5,
          ERRO_ADMINISTRADOR = 6,
          ERRO_FIM_APLICACAO = 7,
          ERRO_ESPERADO = 8,
          ERRO_TRATADO_TELA = 9
        }
    }
}
