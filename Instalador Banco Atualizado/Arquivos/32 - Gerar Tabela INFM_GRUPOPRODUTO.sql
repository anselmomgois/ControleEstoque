QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFM_GRUPOPRODUTO') and   type = 'U'
BANCODEDADOS IGERENCE
create table INFM_GRUPOPRODUTO (
   IDGRUPOPRODUTO       OBJETOID             not null,
   IDEMPRESA            OBJETOID             null,
   CODGRUPOPRODUTO      INTEIROSEQ           identity,
   DESGRUPOPRODUTO      DESCRICAO50          not null,
   constraint PK_INFM_GRUPOPRODUTO primary key (IDGRUPOPRODUTO))