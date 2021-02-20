QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFM_PRODUTOVALORDINAMICO') and   type = 'U'
BANCODEDADOS IGERENCE
create table INFM_PRODUTOVALORDINAMICO (
   IDPRODUTOVALORDINAMICO OBJETO_ID            not null,
   IDPRODUTOFILIAL      OBJETOID             null,
   DESHORAINICIO        DESCRICAO50          not null,
   DESHORAFIM           DESCRICAO50          null,
   BOLHORARIO           BOLEANO              not null,
   CODDIA               CODIGO20             null,
   NUMVALORDESCONTO     NUMERO_DECIMAL       null,
   NUMPERCENTDESCONTO   NUMERO_DECIMAL       null,
   constraint PK_INFM_PRODUTOVALORDINAMICO primary key (IDPRODUTOVALORDINAMICO)
)