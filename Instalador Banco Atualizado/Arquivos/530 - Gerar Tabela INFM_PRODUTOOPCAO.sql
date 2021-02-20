QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFM_PRODUTOOPCAO') and   type = 'U'
BANCODEDADOS IGERENCE
create table INFM_PRODUTOOPCAO (
   IDPRODUTOOPCAO       OBJETO_ID            not null,
   IDPRODUTOSERVICO     OBJETOID             null,
   CODPRODUTOOPCAO      CODIGO20             not null,
   DESPRODUTOOPCAO      DESCRICAO50          not null,
   DESCODBARRAS         DESCRICAO50          null,
   constraint PK_INFM_PRODUTOOPCAO primary key (IDPRODUTOOPCAO))