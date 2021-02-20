QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFM_VERSAO') and   type = 'U'
BANCODEDADOS INFORMATIZ
create table INFM_VERSAO (
   CODVERSAO            CODIGO20             not null,
   constraint PK_INFM_VERSAO primary key (CODVERSAO))