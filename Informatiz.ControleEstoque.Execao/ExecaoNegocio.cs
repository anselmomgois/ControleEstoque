using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Informatiz.ControleEstoque.Execao
{

    public class ExecaoNegocio : System.Exception
    {

        public ExecaoNegocio(Constantes.CodigoErro Codigo, string Descricao)
        {
            _codigo = Codigo;
            _descricao = Descricao;
        }

        #region "Variaveis"

        private Constantes.CodigoErro _codigo;
        private string _descricao;

        #endregion

        #region"Propriedades"

        public Constantes.CodigoErro Codigo
        {
            get
            {
                return _codigo;
            }
        }

        public string Descricao
        {
            get
            {
                return _descricao;
            }
        }

        #endregion
    }
}
