QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFM_ESTADO') and   type = 'U'
BANCODEDADOS INFORMATIZ
create table INFM_ESTADO (
   IDESTADO             OBJETOID             not null,
   CODESTADO            CODIGO20             not null,
   DESESTADO            DESCRICAO50          not null,
   NUMICMS              NUMERO_DECIMAL       null,
   CODIBGE              CODIGO20             null,
   constraint PK_INFM_ESTADO primary key (IDESTADO))