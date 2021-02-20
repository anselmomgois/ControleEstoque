QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFM_OBSERVACAOPRODUTO') and   type = 'U'
BANCODEDADOS IGERENCE
create table INFM_OBSERVACAOPRODUTO (
   IDOBSERVACAOPRODUTO  OBJETO_ID            not null,
   IDOBSERVACAO         OBJETO_ID            not null,
   IDPRODUTOSERVICO     OBJETOID             not null,
   constraint PK_INFM_OBSERVACAOPRODUTO primary key (IDOBSERVACAOPRODUTO))