QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFM_ACAO') and   type = 'U'
BANCODEDADOS IGERENCE
create table INFM_ACAO (
   IDACAO               OBJETOID             not null,
   CODACAO              CODIGO20             not null,
   DESACAO              DESCRICAO50          not null,
   constraint PK_INFM_ACAO primary key (IDACAO))