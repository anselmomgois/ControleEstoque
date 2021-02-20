﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Informatiz.ControleEstoque.API.Entity
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class IGERENCEEntities : DbContext
    {
        public IGERENCEEntities()
            : base("name=IGERENCEEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<INFM_ACAO> INFM_ACAO { get; set; }
        public virtual DbSet<INFM_ACRESCIMOPRODUTO> INFM_ACRESCIMOPRODUTO { get; set; }
        public virtual DbSet<INFM_ADMINISTRADORA> INFM_ADMINISTRADORA { get; set; }
        public virtual DbSet<INFM_BAIRRO> INFM_BAIRRO { get; set; }
        public virtual DbSet<INFM_CAIXA> INFM_CAIXA { get; set; }
        public virtual DbSet<INFM_CIDADE> INFM_CIDADE { get; set; }
        public virtual DbSet<INFM_CODIGOBARRASPESSOA> INFM_CODIGOBARRASPESSOA { get; set; }
        public virtual DbSet<INFM_CODIGOBARRASPRODSERV> INFM_CODIGOBARRASPRODSERV { get; set; }
        public virtual DbSet<INFM_COMPRA> INFM_COMPRA { get; set; }
        public virtual DbSet<INFM_COR> INFM_COR { get; set; }
        public virtual DbSet<INFM_CRM> INFM_CRM { get; set; }
        public virtual DbSet<INFM_DATOSCOMPRAPROD> INFM_DATOSCOMPRAPROD { get; set; }
        public virtual DbSet<INFM_DIASEMANAPROMOCAO> INFM_DIASEMANAPROMOCAO { get; set; }
        public virtual DbSet<INFM_DOCUMENTO> INFM_DOCUMENTO { get; set; }
        public virtual DbSet<INFM_EMPRESA> INFM_EMPRESA { get; set; }
        public virtual DbSet<INFM_ENDERECO> INFM_ENDERECO { get; set; }
        public virtual DbSet<INFM_ESTADO> INFM_ESTADO { get; set; }
        public virtual DbSet<INFM_FILIAL> INFM_FILIAL { get; set; }
        public virtual DbSet<INFM_FILIALBAIRRO> INFM_FILIALBAIRRO { get; set; }
        public virtual DbSet<INFM_FILIALPESSOA> INFM_FILIALPESSOA { get; set; }
        public virtual DbSet<INFM_FORMAPAGAMENTO> INFM_FORMAPAGAMENTO { get; set; }
        public virtual DbSet<INFM_GRUPOCOMPROMISSO> INFM_GRUPOCOMPROMISSO { get; set; }
        public virtual DbSet<INFM_GRUPOCOMPROMISSOSUBGRUPO> INFM_GRUPOCOMPROMISSOSUBGRUPO { get; set; }
        public virtual DbSet<INFM_GRUPOPARAMETRO> INFM_GRUPOPARAMETRO { get; set; }
        public virtual DbSet<INFM_GRUPOPERMISSAO> INFM_GRUPOPERMISSAO { get; set; }
        public virtual DbSet<INFM_GRUPOPERMISSAOACAO> INFM_GRUPOPERMISSAOACAO { get; set; }
        public virtual DbSet<INFM_GRUPOPRODUTO> INFM_GRUPOPRODUTO { get; set; }
        public virtual DbSet<INFM_GRUPOPRODUTOSUBGRUPO> INFM_GRUPOPRODUTOSUBGRUPO { get; set; }
        public virtual DbSet<INFM_HORATRABALHO> INFM_HORATRABALHO { get; set; }
        public virtual DbSet<INFM_IMAGEM> INFM_IMAGEM { get; set; }
        public virtual DbSet<INFM_INTEGRACAOAPI> INFM_INTEGRACAOAPI { get; set; }
        public virtual DbSet<INFM_ITEMVENDA> INFM_ITEMVENDA { get; set; }
        public virtual DbSet<INFM_ITEMVENDA_NUMSERIE> INFM_ITEMVENDA_NUMSERIE { get; set; }
        public virtual DbSet<INFM_ITEMVENDAACRESCIMO> INFM_ITEMVENDAACRESCIMO { get; set; }
        public virtual DbSet<INFM_ITEMVENDAOBSERVACAO> INFM_ITEMVENDAOBSERVACAO { get; set; }
        public virtual DbSet<INFM_LICENCA> INFM_LICENCA { get; set; }
        public virtual DbSet<INFM_LOCALDOCUMENTO> INFM_LOCALDOCUMENTO { get; set; }
        public virtual DbSet<INFM_LOGERROR> INFM_LOGERROR { get; set; }
        public virtual DbSet<INFM_MESA> INFM_MESA { get; set; }
        public virtual DbSet<INFM_MESAAGRUPAR> INFM_MESAAGRUPAR { get; set; }
        public virtual DbSet<INFM_MESAVENDA> INFM_MESAVENDA { get; set; }
        public virtual DbSet<INFM_OBSERVACAO> INFM_OBSERVACAO { get; set; }
        public virtual DbSet<INFM_OBSERVACAOPRODUTO> INFM_OBSERVACAOPRODUTO { get; set; }
        public virtual DbSet<INFM_PAGAMENTO> INFM_PAGAMENTO { get; set; }
        public virtual DbSet<INFM_PARAMETROOPCAO> INFM_PARAMETROOPCAO { get; set; }
        public virtual DbSet<INFM_PARAMETROS> INFM_PARAMETROS { get; set; }
        public virtual DbSet<INFM_PARAMETROVALOR> INFM_PARAMETROVALOR { get; set; }
        public virtual DbSet<INFM_PARCELAMENTO> INFM_PARCELAMENTO { get; set; }
        public virtual DbSet<INFM_PERGUNTAOPCAO> INFM_PERGUNTAOPCAO { get; set; }
        public virtual DbSet<INFM_PERGUNTAS> INFM_PERGUNTAS { get; set; }
        public virtual DbSet<INFM_PERMISSAO> INFM_PERMISSAO { get; set; }
        public virtual DbSet<INFM_PERMISSAOACAO> INFM_PERMISSAOACAO { get; set; }
        public virtual DbSet<INFM_PESSOA> INFM_PESSOA { get; set; }
        public virtual DbSet<INFM_PESSOACRM> INFM_PESSOACRM { get; set; }
        public virtual DbSet<INFM_PESSOACRMPESSOA> INFM_PESSOACRMPESSOA { get; set; }
        public virtual DbSet<INFM_PESSOAMESA> INFM_PESSOAMESA { get; set; }
        public virtual DbSet<INFM_PESSOAMESAXMESA> INFM_PESSOAMESAXMESA { get; set; }
        public virtual DbSet<INFM_PRODCATEGORIA> INFM_PRODCATEGORIA { get; set; }
        public virtual DbSet<INFM_PRODUTOCFOP> INFM_PRODUTOCFOP { get; set; }
        public virtual DbSet<INFM_PRODUTOCOMISSAO> INFM_PRODUTOCOMISSAO { get; set; }
        public virtual DbSet<INFM_PRODUTOCST> INFM_PRODUTOCST { get; set; }
        public virtual DbSet<INFM_PRODUTODERIVACAO> INFM_PRODUTODERIVACAO { get; set; }
        public virtual DbSet<INFM_PRODUTOFILIAL> INFM_PRODUTOFILIAL { get; set; }
        public virtual DbSet<INFM_PRODUTOMARCA> INFM_PRODUTOMARCA { get; set; }
        public virtual DbSet<INFM_PRODUTONCM> INFM_PRODUTONCM { get; set; }
        public virtual DbSet<INFM_PRODUTONUMEROSERIE> INFM_PRODUTONUMEROSERIE { get; set; }
        public virtual DbSet<INFM_PRODUTOOPCAO> INFM_PRODUTOOPCAO { get; set; }
        public virtual DbSet<INFM_PRODUTOPROMOCAO> INFM_PRODUTOPROMOCAO { get; set; }
        public virtual DbSet<INFM_PRODUTOPROMOCAOPRODF> INFM_PRODUTOPROMOCAOPRODF { get; set; }
        public virtual DbSet<INFM_PRODUTOSERVICO> INFM_PRODUTOSERVICO { get; set; }
        public virtual DbSet<INFM_PRODUTOVALORDINAMICO> INFM_PRODUTOVALORDINAMICO { get; set; }
        public virtual DbSet<INFM_PROPOSTA> INFM_PROPOSTA { get; set; }
        public virtual DbSet<INFM_PUBLICIDADE> INFM_PUBLICIDADE { get; set; }
        public virtual DbSet<INFM_RESPONSAVELCAIXA> INFM_RESPONSAVELCAIXA { get; set; }
        public virtual DbSet<INFM_RESPOSTAPERGUNTA> INFM_RESPOSTAPERGUNTA { get; set; }
        public virtual DbSet<INFM_SALDOFILIAL> INFM_SALDOFILIAL { get; set; }
        public virtual DbSet<INFM_SALDOPESSOA> INFM_SALDOPESSOA { get; set; }
        public virtual DbSet<INFM_SANGRIA> INFM_SANGRIA { get; set; }
        public virtual DbSet<INFM_SEGMENTOCOMERCIAL> INFM_SEGMENTOCOMERCIAL { get; set; }
        public virtual DbSet<INFM_SESSAO> INFM_SESSAO { get; set; }
        public virtual DbSet<INFM_SETOREMPRESA> INFM_SETOREMPRESA { get; set; }
        public virtual DbSet<INFM_SITUACAO_PESSOA> INFM_SITUACAO_PESSOA { get; set; }
        public virtual DbSet<INFM_STATUS_CRM> INFM_STATUS_CRM { get; set; }
        public virtual DbSet<INFM_STATUSCRMAGRUP> INFM_STATUSCRMAGRUP { get; set; }
        public virtual DbSet<INFM_SUPRIMENTO> INFM_SUPRIMENTO { get; set; }
        public virtual DbSet<INFM_TIPOCRM> INFM_TIPOCRM { get; set; }
        public virtual DbSet<INFM_TIPOCRMCONFIG> INFM_TIPOCRMCONFIG { get; set; }
        public virtual DbSet<INFM_TIPOCRMCONFIGPESSOA> INFM_TIPOCRMCONFIGPESSOA { get; set; }
        public virtual DbSet<INFM_TIPODOCUMENTO> INFM_TIPODOCUMENTO { get; set; }
        public virtual DbSet<INFM_TIPOEMPREGADO> INFM_TIPOEMPREGADO { get; set; }
        public virtual DbSet<INFM_TIPOPESSOA> INFM_TIPOPESSOA { get; set; }
        public virtual DbSet<INFM_TIPOPESSOA_PESSOA> INFM_TIPOPESSOA_PESSOA { get; set; }
        public virtual DbSet<INFM_TIPOPRODUTO> INFM_TIPOPRODUTO { get; set; }
        public virtual DbSet<INFM_TRANSACOES> INFM_TRANSACOES { get; set; }
        public virtual DbSet<INFM_UNIDADEMEDIDA> INFM_UNIDADEMEDIDA { get; set; }
        public virtual DbSet<INFM_UNIDADEMEDPRODUTO> INFM_UNIDADEMEDPRODUTO { get; set; }
        public virtual DbSet<INFM_USUPERMISSAOACAO> INFM_USUPERMISSAOACAO { get; set; }
        public virtual DbSet<INFM_VENDA> INFM_VENDA { get; set; }
        public virtual DbSet<INFM_VERSAO> INFM_VERSAO { get; set; }
        public virtual DbSet<INFMA_EMPRESA> INFMA_EMPRESA { get; set; }
        public virtual DbSet<INFMA_LICENCA> INFMA_LICENCA { get; set; }
        public virtual DbSet<INFM_VALORFECHAMENTO> INFM_VALORFECHAMENTO { get; set; }
        public virtual DbSet<INFM_ITEMPROCESSO> INFM_ITEMPROCESSO { get; set; }
        public virtual DbSet<INFM_ITEMPROCESSOERRO> INFM_ITEMPROCESSOERRO { get; set; }
        public virtual DbSet<INFM_PROCESSO> INFM_PROCESSO { get; set; }
    }
}