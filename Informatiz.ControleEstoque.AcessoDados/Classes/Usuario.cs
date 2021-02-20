using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Informatiz.ControleEstoque.Comum;
using Informatiz.ControleEstoque.Execao;
using AmgSistemas.Framework.AcessoDados;
using AmgSistemas.Framework.Criptografia;
using frmUtil = AmgSistemas.Framework.Utilitarios;

namespace Informatiz.ControleEstoque.AcessoDados.Classes
{
    public class Usuario
    {

        #region"Consultas"

        public static Comum.Clases.Usuario Logar(string Usuario, string Senha)
        {

            Comum.Clases.Usuario ObjUsuario = null;

            Sql objFrm = new Sql();

            objFrm.AdicionarParametro("CODLOGIN", Usuario, true);
            objFrm.AdicionarParametro("DESSENHA", Senha);

            DataTable dt = objFrm.ExecutarDataTableArquivo(Properties.Resources.UsuarioLogar, Comum.Clases.Constantes.ARQUIVO_CONEXAO);
           
            if (dt != null && dt.Rows.Count > 0)
            {

                string IdentificadorUsuario = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["IDPESSOA"], typeof(string)) as string;

                List<Comum.Clases.Permissao> objPermissoes = Permissao.RecuperarPermissaoUsuario(IdentificadorUsuario);

                if (objPermissoes == null) return null;

                ObjUsuario = new Comum.Clases.Usuario()
                {
                    Codigo = (int)frmUtil.Util.AtribuirValorObj(dt.Rows[0]["CODPESSOA"], typeof(int)),
                    Login = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["CODLOGIN"], typeof(string)) as string,
                    Identificador = IdentificadorUsuario,
                    Consultor = (Boolean)frmUtil.Util.AtribuirValorObj(dt.Rows[0]["BOLCONSULTOR"], typeof(Boolean)),
                    Supervisor =  (Boolean)frmUtil.Util.AtribuirValorObj(dt.Rows[0]["BOLSUPERVISOR"], typeof(Boolean)),
                    ResponsavelFinanceiro = (Boolean)frmUtil.Util.AtribuirValorObj(dt.Rows[0]["BOLRESPFINANCEIRO"], typeof(Boolean)),
                    Entregador = (Boolean)frmUtil.Util.AtribuirValorObj(dt.Rows[0]["BOLENTREGADOR"], typeof(Boolean)),
                    Gerente = (Boolean)frmUtil.Util.AtribuirValorObj(dt.Rows[0]["BOLGERENTE"], typeof(Boolean)),
                    Nome = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["DESNOME"], typeof(string)) as string,
                    Permissoes = objPermissoes,
                    AlterarSenha = (Boolean)frmUtil.Util.AtribuirValorObj(dt.Rows[0]["BOLALTERARSENHA"],typeof (Boolean)),
                    Empresas = Empresa.RecuperarEmpresasFuncionario(IdentificadorUsuario)
                };
                                                
            }

            return ObjUsuario;
        }


        #endregion

    }
}
