QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFM_STATUS_CRM') and   type = 'U'
BANCODEDADOS IGERENCE
create table INFM_STATUS_CRM (
   IDSTATUSCRM          OBJETO_ID            not null,
   CODSTATUSCRM         CODIGO20             not null,
   DESSTATUSCRM         DESCRICAO100         not null,
   CODCORRGB            DESCRICAO50          not null,
   constraint PK_INFM_STATUS_CRM primary key (IDSTATUSCRM))