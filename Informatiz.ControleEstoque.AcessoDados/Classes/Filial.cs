using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AmgSistemas.Framework.AcessoDados;
using frmUtil = AmgSistemas.Framework.Utilitarios;
using System.Data;

namespace Informatiz.ControleEstoque.AcessoDados.Classes
{
   public class Filial
    {

       public static List<Comum.Clases.Filiais> RecuperarFiliaisSimples(string identificadorEmpresa)
       {

           List<Comum.Clases.Filiais> Filiais = null;

           Sql objsql = new Sql();

           objsql.AdicionarParametro("IDEMPRESA", identificadorEmpresa);

           DataTable dt = objsql.ExecutarDataTableArquivo(Properties.Resources.FilialRecuperarSimples, Comum.Clases.Constantes.ARQUIVO_CONEXAO);

           if (dt != null && dt.Rows.Count > 0)
           {
               Filiais = new List<Comum.Clases.Filiais>();

               foreach (DataRow dr in dt.Rows)
               {
                   Filiais.Add(new Comum.Clases.Filiais
                   {
                       Codigo = (int)(frmUtil.Util.AtribuirValorObj(dr["CODFILIAL"], typeof(int))),
                       Identificador = frmUtil.Util.AtribuirValorObj(dr["IDFILIAL"], typeof(string)) as string,
                       Nome = frmUtil.Util.AtribuirValorObj(dr["DESFILIAL"], typeof(string)) as string,
                       Matriz = (Boolean)(frmUtil.Util.AtribuirValorObj(dr["BOLMATRIZ"], typeof(Boolean)))
                   });

               }
           }

           return Filiais;
       }

       public static string InserirFilial(Comum.Clases.Filiais objFilial, string IdentificadorEmpresa, ref Sql objSql)
       {

           string IdentificadorFilial = Convert.ToString(Guid.NewGuid());

           objSql.AdicionarParametro("IDFILIAL", IdentificadorFilial, true);
           objSql.AdicionarParametro("IDEMPRESA", IdentificadorEmpresa);
           objSql.AdicionarParametro("BOLATIVA", true);

           if (objFilial.Endereco != null && objFilial.Endereco.Cidades != null && objFilial.Endereco.Cidades.Count > 0
               && objFilial.Endereco.Cidades.First().Bairros != null && objFilial.Endereco.Cidades.First().Bairros.Count > 0
               && objFilial.Endereco.Cidades.First().Bairros.First().Enderecos != null && objFilial.Endereco.Cidades.First().Bairros.First().Enderecos.Count > 0)
           {
               objSql.AdicionarParametro("IDENDERECO", objFilial.Endereco.Cidades.First().Bairros.First().Enderecos.First().Identificador);
               objSql.AdicionarParametro("NUMENDERECO", objFilial.Endereco.Cidades.First().Bairros.First().Enderecos.First().Numero);

               if (!string.IsNullOrEmpty(objFilial.Endereco.Cidades.First().Bairros.First().Enderecos.First().DesReferencia))
               {
                   objSql.AdicionarParametro("DESPONTREFENDERECO", objFilial.Endereco.Cidades.First().Bairros.First().Enderecos.First().DesReferencia.ToUpper());
               }
               else
               {
                   objSql.AdicionarParametro("DESPONTREFENDERECO", DBNull.Value);
               }

               if (!string.IsNullOrEmpty(objFilial.Endereco.Cidades.First().Bairros.First().Enderecos.First().Complemento))
               {
                   objSql.AdicionarParametro("DESCOMPENDERECO", objFilial.Endereco.Cidades.First().Bairros.First().Enderecos.First().Complemento.ToUpper());
               }
               else
               {
                   objSql.AdicionarParametro("DESCOMPENDERECO", DBNull.Value);
               }
           }
           else
           {
               objSql.AdicionarParametro("IDENDERECO", DBNull.Value);
               objSql.AdicionarParametro("NUMENDERECO", DBNull.Value);
               objSql.AdicionarParametro("DESPONTREFENDERECO", DBNull.Value);
               objSql.AdicionarParametro("DESCOMPENDERECO", DBNull.Value);
           }

           if (objFilial.Gerente != null)
           {
               objSql.AdicionarParametro("IDPESSOA", objFilial.Gerente.Identificador);
           }
           else
           {
               objSql.AdicionarParametro("IDPESSOA", DBNull.Value);
           }

           objSql.AdicionarParametro("DESFILIAL", objFilial.Nome.ToUpper());
           objSql.AdicionarParametro("BOLMATRIZ", objFilial.Matriz);

           if (!string.IsNullOrEmpty(objFilial.Observacao))
           {
               objSql.AdicionarParametro("OBSFILIAL", objFilial.Observacao.ToUpper());
           }
           else
           {
               objSql.AdicionarParametro("OBSFILIAL", DBNull.Value);
           }

           if (!string.IsNullOrEmpty(objFilial.TelefoneFixo))
           {
               objSql.AdicionarParametro("DESTELEFONEFIXO", objFilial.TelefoneFixo);
           }
           else
           {
               objSql.AdicionarParametro("DESTELEFONEFIXO", DBNull.Value);
           }

           if (!string.IsNullOrEmpty(objFilial.TelefoneFax))
           {
               objSql.AdicionarParametro("DESTELEFONEFAX", objFilial.TelefoneFax);
           }
           else
           {
               objSql.AdicionarParametro("DESTELEFONEFAX", DBNull.Value);
           }

           if (!string.IsNullOrEmpty(objFilial.TelefoneMovel))
           {
               objSql.AdicionarParametro("DESTELEFONECEL", objFilial.TelefoneMovel);
           }
           else
           {
               objSql.AdicionarParametro("DESTELEFONECEL", DBNull.Value);
           }

           if (!string.IsNullOrEmpty(objFilial.Email))
           {
               objSql.AdicionarParametro("DESEMAIL", objFilial.Email);
           }
           else
           {
               objSql.AdicionarParametro("DESEMAIL", DBNull.Value);
           }
           
           if(objFilial.DataAbertura != null)
           {
               objSql.AdicionarParametro("DTHABERTURA", objFilial.DataAbertura);
           }
           else
           {
               objSql.AdicionarParametro("DTHABERTURA", DBNull.Value);
           }

           if (objFilial.NumContribuicaoSocialPer != null)
           {
               objSql.AdicionarParametro("NUMCONTSOCPER", objFilial.NumContribuicaoSocialPer);
           }
           else
           {
               objSql.AdicionarParametro("NUMCONTSOCPER", DBNull.Value);
           }


           if (objFilial.NumOutrasDespesas != null)
           {
               objSql.AdicionarParametro("NUMOUTDESPPER", objFilial.NumOutrasDespesas);
           }
           else
           {
               objSql.AdicionarParametro("NUMOUTDESPPER", DBNull.Value);
           }


           if (objFilial.NumPercentualConfins != null)
           {
               objSql.AdicionarParametro("NUMCONFINSPER", objFilial.NumPercentualConfins);
           }
           else
           {
               objSql.AdicionarParametro("NUMCONFINSPER", DBNull.Value);
           }

           if (objFilial.NumPercentualPis != null)
           {
               objSql.AdicionarParametro("NUMPISPER", objFilial.NumPercentualPis);
           }
           else
           {
               objSql.AdicionarParametro("NUMPISPER", DBNull.Value);
           }

           if (objFilial.CodigoTabelaMercadoria != null)
           {
               objSql.AdicionarParametro("CODTABMERCADORIA", objFilial.CodigoTabelaMercadoria);
           }
           else
           {
               objSql.AdicionarParametro("CODTABMERCADORIA", DBNull.Value);
           }

           objSql.AdicionarTransacao(Properties.Resources.FilialInserir);

           return IdentificadorFilial;
       }

       public static void DesativarFilial(string IdentificadorFilial, ref Sql objSql)
       {

           objSql.AdicionarParametro("IDFILIAL", IdentificadorFilial, true);
           objSql.AdicionarParametro("BOLATIVA", false);

           objSql.AdicionarTransacao(Properties.Resources.FilialDesativar);

       }

       public static void AtualizarFilial(Comum.Clases.Filiais objFilial, ref Sql objSql)
       {

           objSql.AdicionarParametro("IDFILIAL", objFilial.Identificador, true);
           objSql.AdicionarParametro("BOLATIVA", objFilial.Ativa);

           if (objFilial.Endereco != null && objFilial.Endereco.Cidades != null && objFilial.Endereco.Cidades.Count > 0
               && objFilial.Endereco.Cidades.First().Bairros != null && objFilial.Endereco.Cidades.First().Bairros.Count > 0
               && objFilial.Endereco.Cidades.First().Bairros.First().Enderecos != null && objFilial.Endereco.Cidades.First().Bairros.First().Enderecos.Count > 0)
           {
               objSql.AdicionarParametro("IDENDERECO", objFilial.Endereco.Cidades.First().Bairros.First().Enderecos.First().Identificador);
               objSql.AdicionarParametro("NUMENDERECO", objFilial.Endereco.Cidades.First().Bairros.First().Enderecos.First().Numero);
               
               if(!string.IsNullOrEmpty(objFilial.Endereco.Cidades.First().Bairros.First().Enderecos.First().DesReferencia))
               {
               objSql.AdicionarParametro("DESPONTREFENDERECO", objFilial.Endereco.Cidades.First().Bairros.First().Enderecos.First().DesReferencia.ToUpper());
               }else
               {
               objSql.AdicionarParametro("DESPONTREFENDERECO", DBNull.Value);
               }

               if(!string.IsNullOrEmpty( objFilial.Endereco.Cidades.First().Bairros.First().Enderecos.First().Complemento))
               {
                   objSql.AdicionarParametro("DESCOMPENDERECO", objFilial.Endereco.Cidades.First().Bairros.First().Enderecos.First().Complemento.ToUpper());
               }
               else
               {
               objSql.AdicionarParametro("DESCOMPENDERECO", DBNull.Value);
               }
           }
           else
           {
               objSql.AdicionarParametro("IDENDERECO", DBNull.Value);
               objSql.AdicionarParametro("NUMENDERECO", DBNull.Value);
               objSql.AdicionarParametro("DESPONTREFENDERECO", DBNull.Value);
               objSql.AdicionarParametro("DESCOMPENDERECO", DBNull.Value);
           }

           if (objFilial.Gerente != null)
           {
               objSql.AdicionarParametro("IDPESSOA", objFilial.Gerente.Identificador);
           }
           else
           {
               objSql.AdicionarParametro("IDPESSOA", DBNull.Value);
           }

           objSql.AdicionarParametro("DESFILIAL", objFilial.Nome.ToUpper());
           objSql.AdicionarParametro("BOLMATRIZ", objFilial.Matriz);

           if (!string.IsNullOrEmpty(objFilial.Observacao))
           {
               objSql.AdicionarParametro("OBSFILIAL", objFilial.Observacao.ToUpper());
           }
           else
           {
               objSql.AdicionarParametro("OBSFILIAL", DBNull.Value);
           }

           if (!string.IsNullOrEmpty(objFilial.TelefoneFixo))
           {
               objSql.AdicionarParametro("DESTELEFONEFIXO", objFilial.TelefoneFixo);
           }
           else
           {
               objSql.AdicionarParametro("DESTELEFONEFIXO", DBNull.Value);
           }

           if (!string.IsNullOrEmpty(objFilial.TelefoneFax))
           {
               objSql.AdicionarParametro("DESTELEFONEFAX", objFilial.TelefoneFax);
           }
           else
           {
               objSql.AdicionarParametro("DESTELEFONEFAX", DBNull.Value);
           }

           if (!string.IsNullOrEmpty(objFilial.TelefoneMovel))
           {
               objSql.AdicionarParametro("DESTELEFONECEL", objFilial.TelefoneMovel);
           }
           else
           {
               objSql.AdicionarParametro("DESTELEFONECEL", DBNull.Value);
           }

           if (!string.IsNullOrEmpty(objFilial.Email))
           {
               objSql.AdicionarParametro("DESEMAIL", objFilial.Email);
           }
           else
           {
               objSql.AdicionarParametro("DESEMAIL", DBNull.Value);
           }

           if (objFilial.DataAbertura != null)
           {
               objSql.AdicionarParametro("DTHABERTURA", objFilial.DataAbertura);
           }
           else
           {
               objSql.AdicionarParametro("DTHABERTURA", DBNull.Value);
           }

           if (objFilial.NumContribuicaoSocialPer != null)
           {
               objSql.AdicionarParametro("NUMCONTSOCPER", objFilial.NumContribuicaoSocialPer);
           }
           else
           {
               objSql.AdicionarParametro("NUMCONTSOCPER", DBNull.Value);
           }


           if (objFilial.NumOutrasDespesas != null)
           {
               objSql.AdicionarParametro("NUMOUTDESPPER", objFilial.NumOutrasDespesas);
           }
           else
           {
               objSql.AdicionarParametro("NUMOUTDESPPER", DBNull.Value);
           }


           if (objFilial.NumPercentualConfins != null)
           {
               objSql.AdicionarParametro("NUMCONFINSPER", objFilial.NumPercentualConfins);
           }
           else
           {
               objSql.AdicionarParametro("NUMCONFINSPER", DBNull.Value);
           }

           if (objFilial.NumPercentualPis != null)
           {
               objSql.AdicionarParametro("NUMPISPER", objFilial.NumPercentualPis);
           }
           else
           {
               objSql.AdicionarParametro("NUMPISPER", DBNull.Value);
           }

           if (objFilial.CodigoTabelaMercadoria != null)
           {
               objSql.AdicionarParametro("CODTABMERCADORIA", objFilial.CodigoTabelaMercadoria);
           }
           else
           {
               objSql.AdicionarParametro("CODTABMERCADORIA", DBNull.Value);
           }

           objSql.AdicionarTransacao(Properties.Resources.FilialAtualizar);
       }
    }
}
