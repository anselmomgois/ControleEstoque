QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFM_UNIDADEMEDPRODUTO') and   type = 'U'
BANCODEDADOS INFORMATIZ
create table INFM_UNIDADEMEDPRODUTO (
   IDUNIDADEMEDPRODUTO  OBJETO_ID            not null,
   IDUNIDADEMEDIDA      OBJETOID             null,
   IDPRODUTOSERVICO     OBJETOID             null,
   constraint PK_INFM_UNIDADEMEDPRODUTO primary key (IDUNIDADEMEDPRODUTO))