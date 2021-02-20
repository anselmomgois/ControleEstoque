QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFM_TIPOCRM') and   type = 'U'
BANCODEDADOS IGERENCE
create table INFM_TIPOCRM (
   IDTIPOCRM            OBJETO_ID            not null,
   IDEMPRESA            OBJETOID             null,
   DESTIPOCRM           DESCRICAO100         not null,
   constraint PK_INFM_TIPOCRM primary key (IDTIPOCRM))