using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Informatiz.ControleEstoque.Aplicacao.Classes
{
    public class Tabelas
    {

        //public static Comum.Clases.TabelaColecao GerarTabelas(string Usuario)
        //{

        //    Comum.Clases.TabelaColecao Tabelas = new Comum.Clases.TabelaColecao();
        //    List<Comum.Clases.Coluna> ColunasValidacao = null;
        //    List<Comum.Clases.Coluna> ColunasOrderBy = null;

        //    Tabelas.Add(new Comum.Clases.Tabela
        //    {
        //        NomeTabela = "INFM_EMPRESA",
        //        Colunas = LogicaNegocio.Backup.RecuperarColunas("INFM_EMPRESA", Usuario)

        //    });

        //    Tabelas.Add(new Comum.Clases.Tabela
        //    {
        //        NomeTabela = "INFM_ESTADO",
        //        Colunas = LogicaNegocio.Backup.RecuperarColunas("INFM_ESTADO", Usuario)
        //    });

        //    Tabelas.Add(new Comum.Clases.Tabela
        //    {
        //        NomeTabela = "INFM_CIDADE",
        //        Colunas = LogicaNegocio.Backup.RecuperarColunas("INFM_CIDADE", Usuario)
        //    });

        //    Tabelas.Add(new Comum.Clases.Tabela
        //    {
        //        NomeTabela = "INFM_BAIRRO",
        //        Colunas = LogicaNegocio.Backup.RecuperarColunas("INFM_BAIRRO", Usuario)
        //    });

        //    Tabelas.Add(new Comum.Clases.Tabela
        //    {
        //        NomeTabela = "INFM_ENDERECO",
        //        Colunas = LogicaNegocio.Backup.RecuperarColunas("INFM_ENDERECO", Usuario)
        //    });

        //    Tabelas.Add(new Comum.Clases.Tabela
        //    {
        //        NomeTabela = "INFM_PARAMETROS",
        //        Colunas = LogicaNegocio.Backup.RecuperarColunas("INFM_PARAMETROS", Usuario)
        //    });

        //    Tabelas.Add(new Comum.Clases.Tabela
        //    {
        //        NomeTabela = "INFM_PARAMETROVALOR",
        //        Colunas = LogicaNegocio.Backup.RecuperarColunas("INFM_PARAMETROVALOR", Usuario)
        //    });

        //    Tabelas.Add(new Comum.Clases.Tabela
        //    {
        //        NomeTabela = "INFM_TIPOPESSOA",
        //        Colunas = LogicaNegocio.Backup.RecuperarColunas("INFM_TIPOPESSOA", Usuario)
        //    });

        //    Tabelas.Add(new Comum.Clases.Tabela
        //    {
        //        NomeTabela = "INFM_SITUACAO_PESSOA",
        //        Colunas = LogicaNegocio.Backup.RecuperarColunas("INFM_SITUACAO_PESSOA", Usuario)
        //    });

        //    Tabelas.Add(new Comum.Clases.Tabela
        //    {
        //        NomeTabela = "INFM_SEGMENTOCOMERCIAL",
        //        Colunas = LogicaNegocio.Backup.RecuperarColunas("INFM_SEGMENTOCOMERCIAL", Usuario)
        //    });

        //    ColunasValidacao = new List<Comum.Clases.Coluna>();
        //    ColunasValidacao.Add(new Comum.Clases.Coluna
        //    {
        //        NomeColuna = "IDPESSOA",
        //        PrimaryKey = true
        //    });

        //    ColunasOrderBy = new List<Comum.Clases.Coluna>();
        //    ColunasOrderBy.Add(new Comum.Clases.Coluna
        //    {
        //        NomeColuna = "IDPESSOARESPONSAVEL"
        //    });

        //    Tabelas.Add(new Comum.Clases.Tabela
        //    {
        //        NomeTabela = "INFM_PESSOA",
        //        Colunas = LogicaNegocio.Backup.RecuperarColunas("INFM_PESSOA", Usuario),
        //        ColunasValidacao = ColunasValidacao,
        //        ColunasOrderBy = ColunasOrderBy

        //    });

        //    Tabelas.Add(new Comum.Clases.Tabela
        //    {
        //        NomeTabela = "INFM_FILIAL",
        //        Colunas = LogicaNegocio.Backup.RecuperarColunas("INFM_FILIAL", Usuario)
        //    });

        //    Tabelas.Add(new Comum.Clases.Tabela
        //    {
        //        NomeTabela = "INFM_HORATRABALHO",
        //        Colunas = LogicaNegocio.Backup.RecuperarColunas("INFM_HORATRABALHO", Usuario)
        //    });

        //    Tabelas.Add(new Comum.Clases.Tabela
        //    {
        //        NomeTabela = "INFM_TIPOPESSOA_PESSOA",
        //        Colunas = LogicaNegocio.Backup.RecuperarColunas("INFM_TIPOPESSOA_PESSOA", Usuario),
        //        ValidarComTodasColunas = true
        //    });

        //    Tabelas.Add(new Comum.Clases.Tabela
        //    {
        //        NomeTabela = "INFM_FILIALPESSOA",
        //        Colunas = LogicaNegocio.Backup.RecuperarColunas("INFM_FILIALPESSOA", Usuario),
        //        ValidarComTodasColunas = true
        //    });

        //    Tabelas.Add(new Comum.Clases.Tabela
        //    {
        //        NomeTabela = "INFM_FILIALBAIRRO",
        //        Colunas = LogicaNegocio.Backup.RecuperarColunas("INFM_FILIALBAIRRO", Usuario),
        //        ValidarComTodasColunas = true
        //    });

        //    Tabelas.Add(new Comum.Clases.Tabela
        //    {
        //        NomeTabela = "INFM_ACAO",
        //        Colunas = LogicaNegocio.Backup.RecuperarColunas("INFM_ACAO", Usuario)
        //    });

        //    Tabelas.Add(new Comum.Clases.Tabela
        //    {
        //        NomeTabela = "INFM_PERMISSAO",
        //        Colunas = LogicaNegocio.Backup.RecuperarColunas("INFM_PERMISSAO", Usuario)
        //    });

        //    Tabelas.Add(new Comum.Clases.Tabela
        //    {
        //        NomeTabela = "INFM_PERMISSAOACAO",
        //        Colunas = LogicaNegocio.Backup.RecuperarColunas("INFM_PERMISSAOACAO", Usuario),
        //        ValidarComTodasColunas = true
        //    });

        //    Tabelas.Add(new Comum.Clases.Tabela
        //    {
        //        NomeTabela = "INFM_GRUPOPERMISSAO",
        //        Colunas = LogicaNegocio.Backup.RecuperarColunas("INFM_GRUPOPERMISSAO", Usuario)
        //    });

        //    Tabelas.Add(new Comum.Clases.Tabela
        //    {
        //        NomeTabela = "INFM_USUPERMISSAOACAO",
        //        Colunas = LogicaNegocio.Backup.RecuperarColunas("INFM_USUPERMISSAOACAO", Usuario),
        //        ValidarComTodasColunas = true
        //    });

        //    Tabelas.Add(new Comum.Clases.Tabela
        //    {
        //        NomeTabela = "INFM_GRUPOPERMISSAOACAO",
        //        Colunas = LogicaNegocio.Backup.RecuperarColunas("INFM_GRUPOPERMISSAOACAO", Usuario),
        //        ValidarComTodasColunas = true
        //    });

        //    Tabelas.Add(new Comum.Clases.Tabela
        //    {
        //        NomeTabela = "INFM_PRODUTOMARCA",
        //        Colunas = LogicaNegocio.Backup.RecuperarColunas("INFM_PRODUTOMARCA", Usuario)
        //    });

        //    Tabelas.Add(new Comum.Clases.Tabela
        //    {
        //        NomeTabela = "INFM_PRODCATEGORIA",
        //        Colunas = LogicaNegocio.Backup.RecuperarColunas("INFM_PRODCATEGORIA", Usuario)
        //    });

        //    Tabelas.Add(new Comum.Clases.Tabela
        //    {
        //        NomeTabela = "INFM_PRODUTODERIVACAO",
        //        Colunas = LogicaNegocio.Backup.RecuperarColunas("INFM_PRODUTODERIVACAO", Usuario)
        //    });

        //    Tabelas.Add(new Comum.Clases.Tabela
        //    {
        //        NomeTabela = "INFM_TIPOPRODUTO",
        //        Colunas = LogicaNegocio.Backup.RecuperarColunas("INFM_TIPOPRODUTO", Usuario)
        //    });

        //    Tabelas.Add(new Comum.Clases.Tabela
        //    {
        //        NomeTabela = "INFM_PRODUTONCM",
        //        Colunas = LogicaNegocio.Backup.RecuperarColunas("INFM_PRODUTONCM", Usuario)
        //    });

        //    Tabelas.Add(new Comum.Clases.Tabela
        //    {
        //        NomeTabela = "INFM_PRODUTOCFOP",
        //        Colunas = LogicaNegocio.Backup.RecuperarColunas("INFM_PRODUTOCFOP", Usuario)
        //    });

        //    Tabelas.Add(new Comum.Clases.Tabela
        //    {
        //        NomeTabela = "INFM_COR",
        //        Colunas = LogicaNegocio.Backup.RecuperarColunas("INFM_COR", Usuario)
        //    });

        //    ColunasOrderBy = new List<Comum.Clases.Coluna>();
        //    ColunasOrderBy.Add(new Comum.Clases.Coluna
        //    {
        //        NomeColuna = "IDUNIDADEMEDIDAPAI"
        //    });

        //    Tabelas.Add(new Comum.Clases.Tabela
        //    {
        //        NomeTabela = "INFM_UNIDADEMEDIDA",
        //        Colunas = LogicaNegocio.Backup.RecuperarColunas("INFM_UNIDADEMEDIDA", Usuario),
        //        ColunasOrderBy = ColunasOrderBy
        //    });

        //    Tabelas.Add(new Comum.Clases.Tabela
        //    {
        //        NomeTabela = "INFM_PRODUTOCST",
        //        Colunas = LogicaNegocio.Backup.RecuperarColunas("INFM_PRODUTOCST", Usuario)
        //    });

        //    Tabelas.Add(new Comum.Clases.Tabela
        //    {
        //        NomeTabela = "INFM_GRUPOPRODUTO",
        //        Colunas = LogicaNegocio.Backup.RecuperarColunas("INFM_GRUPOPRODUTO", Usuario)
        //    });

        //    Tabelas.Add(new Comum.Clases.Tabela
        //    {
        //        NomeTabela = "INFM_GRUPOPRODUTOSUBGRUPO",
        //        Colunas = LogicaNegocio.Backup.RecuperarColunas("INFM_GRUPOPRODUTOSUBGRUPO", Usuario)
        //    });

        //    Tabelas.Add(new Comum.Clases.Tabela
        //    {
        //        NomeTabela = "INFM_PRODUTOCOMISSAO",
        //        Colunas = LogicaNegocio.Backup.RecuperarColunas("INFM_PRODUTOCOMISSAO", Usuario)
        //    });

        //    Tabelas.Add(new Comum.Clases.Tabela
        //    {
        //        NomeTabela = "INFM_PRODUTOSERVICO",
        //        Colunas = LogicaNegocio.Backup.RecuperarColunas("INFM_PRODUTOSERVICO", Usuario)
        //    });

        //    Tabelas.Add(new Comum.Clases.Tabela
        //    {
        //        NomeTabela = "INFM_UNIDADEMEDPRODUTO",
        //        Colunas = LogicaNegocio.Backup.RecuperarColunas("INFM_UNIDADEMEDPRODUTO", Usuario)
        //    });

        //    Tabelas.Add(new Comum.Clases.Tabela
        //    {
        //        NomeTabela = "INFM_PRODUTOFILIAL",
        //        Colunas = LogicaNegocio.Backup.RecuperarColunas("INFM_PRODUTOFILIAL", Usuario)
        //    });

        //    Tabelas.Add(new Comum.Clases.Tabela
        //    {
        //        NomeTabela = "INFM_PRODUTOPROMOCAO",
        //        Colunas = LogicaNegocio.Backup.RecuperarColunas("INFM_PRODUTOPROMOCAO", Usuario)
        //    });

        //    Tabelas.Add(new Comum.Clases.Tabela
        //    {
        //        NomeTabela = "INFM_DATOSCOMPRAPROD",
        //        Colunas = LogicaNegocio.Backup.RecuperarColunas("INFM_DATOSCOMPRAPROD", Usuario)
        //    });

        //    Tabelas.Add(new Comum.Clases.Tabela
        //    {
        //        NomeTabela = "INFM_PRODUTOPROMOCAOPRODF",
        //        Colunas = LogicaNegocio.Backup.RecuperarColunas("INFM_PRODUTOPROMOCAOPRODF", Usuario),
        //        ValidarComTodasColunas = true
        //    });

        //    return Tabelas;
        //}


    }
}
