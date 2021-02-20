QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFM_PRODUTODERIVACAO') and   type = 'U'
BANCODEDADOS IGERENCE
create table INFM_PRODUTODERIVACAO (
   IDPRODUTODERIVACAO   OBJETOID             not null,
   IDEMPRESA            OBJETOID             null,
   CODPRODUTODERIVACAO  INTEIROSEQ           identity,
   DESPRODUTODERIVACAO  DESCRICAO50          not null,
   constraint PK_INFM_PRODUTODERIVACAO primary key (IDPRODUTODERIVACAO))