QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFM_GRUPOPRODUTOSUBGRUPO') and   type = 'U'
BANCODEDADOS IGERENCE
create table INFM_GRUPOPRODUTOSUBGRUPO (
   IDGRUPOPRODUTOSUBGRUPO OBJETOID             not null,
   IDGRUPOPRODUTOPAI    OBJETOID             not null,
   IDGRUPOPRODUTO       OBJETOID             not null,
   constraint PK_INFM_GRUPOPRODUTOSUBGRUPO primary key (IDGRUPOPRODUTOSUBGRUPO))