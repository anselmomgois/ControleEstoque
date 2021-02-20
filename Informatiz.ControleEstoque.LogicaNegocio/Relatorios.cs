using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Informatiz.ControleEstoque.LogicaNegocio
{
   public class Relatorios
    {

       public static List<Comum.Clases.Relatorios.RelatorioEstoque> RecuperarItensRelatorioEstoque(string IdentificadorFilial, 
                                                                                            string IdentificadorProduto,
                                                                                            string IdentificadorEmpresa,
                                                                                            string CodigoUsuario)
       {
           List<Comum.Clases.Relatorios.RelatorioEstoque> Produtos = null;

           try
           {

               Produtos = AcessoDados.Classes.Relatorio.RecuperarItensRelatorioEstoque(IdentificadorFilial, IdentificadorProduto, IdentificadorEmpresa);

           }
           catch (Exception ex)
           {
               Erro.InserirErro(new Comum.Clases.Erro() { DesErro = ex.Message, Usuario = CodigoUsuario });
               throw ex;
           }

           return Produtos;
       }

       public static List<Comum.Clases.Relatorios.RelatorioPessoas> RecuperarPessoas(string IdentificadorFilial,
                                                                                     string IdentificadorEmpresa,
                                                                                     string Nome,
                                                                                     string CPF,
                                                                                     string CNPJ,
                                                                                     string IdentificadortipoPessoa,
                                                                                     string CodigoUsuario)
       {

           List<Comum.Clases.Relatorios.RelatorioPessoas> Pessoas = null;

           try
           {

               Pessoas = AcessoDados.Classes.Relatorio.RecuperarPessoas(IdentificadorFilial, IdentificadorEmpresa, Nome, CPF, CNPJ, IdentificadortipoPessoa);

           }
           catch (Exception ex)
           {
               Erro.InserirErro(new Comum.Clases.Erro() { DesErro = ex.Message, Usuario = CodigoUsuario });
               throw ex;
           }

           return Pessoas;
       }
                                                                                     
    }
}
