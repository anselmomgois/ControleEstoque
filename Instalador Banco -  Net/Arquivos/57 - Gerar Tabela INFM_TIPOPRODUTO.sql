QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFM_TIPOPRODUTO') and   type = 'U'
BANCODEDADOS INFORMATIZ
create table INFM_TIPOPRODUTO (
   IDTIPOPRODUTO        OBJETO_ID            not null,
   CODTIPOPRODUTO       CODIGO20             not null,
   DESTIPOPRODUTO       DESCRICAO50          not null,
   constraint PK_INFM_TIPOPRODUTO primary key (IDTIPOPRODUTO))