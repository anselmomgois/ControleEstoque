QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFM_ACRESCIMOPRODUTO') and   type = 'U'
BANCODEDADOS IGERENCE
create table INFM_ACRESCIMOPRODUTO (
   IDACRESCIMOPRODUTO   OBJETO_ID            not null,
   IDPRODUTOSERVICO     OBJETOID             not null,
   IDACRESCIMO          OBJETOID             not null,
   constraint PK_INFM_ACRESCIMOPRODUTO primary key (IDACRESCIMOPRODUTO))