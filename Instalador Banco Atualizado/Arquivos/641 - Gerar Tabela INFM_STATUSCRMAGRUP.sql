QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFM_STATUSCRMAGRUP') and   type = 'U'
BANCODEDADOS IGERENCE
create table INFM_STATUSCRMAGRUP (
   IDSTATUSCRMAGRUP     OBJETO_ID            not null,
   IDEMPRESA            OBJETOID             null,
   DESSTATUSCRMAGRUP    DESCRICAO100         not null,
   constraint PK_INFM_STATUSCRMAGRUP primary key (IDSTATUSCRMAGRUP))