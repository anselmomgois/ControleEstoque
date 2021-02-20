using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Informatiz.ControleEstoque.LogicaNegocio
{
    public class FilialPessoa
    {

        public static List<Comum.Clases.Filiais> RecuperarFilialPessoa(string identificadorPessoa, string Usuario)
        {

            List<Comum.Clases.Filiais> Filiais = null;
            try
            {
                Filiais = AcessoDados.Classes.FilialPessoa.RecuperarFiliaisPessoa(identificadorPessoa);
            }
            catch (Execao.ExecaoNegocio ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                Erro.InserirErro(new Comum.Clases.Erro() { DesErro = ex.Message, Usuario = Usuario });
                throw ex;
            }

            return Filiais;
        }

    }
}
