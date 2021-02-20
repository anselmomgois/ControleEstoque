QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFM_MESA') and   type = 'U'
BANCODEDADOS IGERENCE
create table INFM_MESA (
   IDMESA               OBJETO_ID            not null,
   IDFILIAL             OBJETOID             null,
   CODMESA              CODIGO20             not null,
   NELQUANTIDADELUGAR   INTEIRO              not null,
   CODESTADO            CODIGO20             not null,
   constraint PK_INFM_MESA primary key (IDMESA))