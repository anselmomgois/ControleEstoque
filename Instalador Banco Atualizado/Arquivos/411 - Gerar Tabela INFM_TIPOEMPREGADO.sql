QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFM_TIPOEMPREGADO') and   type = 'U'
BANCODEDADOS IGERENCE
create table INFM_TIPOEMPREGADO (
   IDTIPOEMPREGADO      OBJETO_ID            not null,
   IDEMPRESA            OBJETOID             null,
   DESTIPOEMPREGADO     DESCRICAO200         not null,
   constraint PK_INFM_TIPOEMPREGADO primary key (IDTIPOEMPREGADO))