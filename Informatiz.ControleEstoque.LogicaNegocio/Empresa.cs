using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AmgSistemas.Framework.AcessoDados;
using frmUtil = AmgSistemas.Framework.Utilitarios;

namespace Informatiz.ControleEstoque.LogicaNegocio
{
    public class Empresa
    {

        private static StringBuilder ValidarCampos(Comum.Clases.Empresa objEmpresa)
        {

            StringBuilder objErros = new StringBuilder();

            frmUtil.Util.ValidarCampo(objEmpresa.Nome, "Nome da empresa obrigatório", typeof(string), false, ref objErros);

            if (!string.IsNullOrEmpty(objEmpresa.Cnpj) && !frmUtil.Validacao.ValidarValorCampo(objEmpresa.Cnpj, frmUtil.Enumeradores.TipoValidacao.CNPJ))
            {
                objErros.AppendLine("CNPJ invalido.");
            }

            if ((from Comum.Clases.Filiais f in objEmpresa.Filiais where f.Ativa select f).Count() == 0)
            {
                objErros.AppendLine("Obrigatório ter pelo menos uma filial ativa");
            }

            foreach (Comum.Clases.Filiais f in objEmpresa.Filiais)
            {

                frmUtil.Util.ValidarCampo(f.Nome, "Nome da filial é obrigatório", typeof(string), false, ref objErros);

                if (!string.IsNullOrEmpty(f.Email) && !frmUtil.Validacao.ValidarValorCampo(f.Email, frmUtil.Enumeradores.TipoValidacao.EMAIL))
                {
                    objErros.AppendLine("Email invalido.");
                }

                if (f.Endereco != null && f.Endereco.Cidades != null && f.Endereco.Cidades.Count > 0
                   && f.Endereco.Cidades.First().Bairros != null && f.Endereco.Cidades.First().Bairros.Count > 0
                   && f.Endereco.Cidades.First().Bairros.First().Enderecos != null && f.Endereco.Cidades.First().Bairros.First().Enderecos.Count > 0
                   && f.Endereco.Cidades.First().Bairros.First().Enderecos.First().Numero == null)
                {
                    objErros.AppendLine("Obrigatório informar o número do endereço");
                }
            }

            return objErros;
        }

        public static void AtualizarEmpresa(Comum.Clases.Empresa objEmpresa,
                                            string Usuario)
        {
            try
            {

                StringBuilder objErros = ValidarCampos(objEmpresa);

                if (objErros.Length > 0)
                {
                    throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, objErros.ToString());
                }

                Sql objSql = new Sql();

                objSql.IniciarTransacaoArquivo(Comum.Clases.Constantes.ARQUIVO_CONEXAO);

                AcessoDados.Classes.Empresa.AtualizarEmpresa(objEmpresa, ref objSql);

                if (objEmpresa.Filiais != null && objEmpresa.Filiais.Count > 0)
                {

                    foreach (Comum.Clases.Filiais filial in objEmpresa.Filiais)
                    {

                        if (filial.Apagar)
                        {
                            AcessoDados.Classes.Filial.DesativarFilial(filial.Identificador, ref objSql);
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(filial.Identificador))
                            {
                                AcessoDados.Classes.Filial.InserirFilial(filial, objEmpresa.Identificador, ref objSql);
                            }
                            else
                            {
                                AcessoDados.Classes.Filial.AtualizarFilial(filial, ref objSql);
                            }
                        }
                    }
                }

                objSql.ExecutarTransacao();

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

        }

        public static Comum.Clases.Empresa RecuperarEmpresa(string identificadorEmpresa, Nullable<Boolean> EmpresaMestre, string Usuario)
        {

            Comum.Clases.Empresa objEmpresa = null;
            try
            {
                objEmpresa = AcessoDados.Classes.Empresa.RecuperarEmpresa(identificadorEmpresa, EmpresaMestre);
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

            return objEmpresa;
        }
    }
}
