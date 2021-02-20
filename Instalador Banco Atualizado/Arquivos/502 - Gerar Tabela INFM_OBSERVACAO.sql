QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFM_OBSERVACAO') and   type = 'U'
BANCODEDADOS IGERENCE
create table INFM_OBSERVACAO (
   IDOBSERVACAO         OBJETO_ID            not null,
   IDEMPRESA            OBJETOID             null,
   DESOBSERVACAO        DESCRICAO200         not null,
   constraint PK_INFM_OBSERVACAO primary key (IDOBSERVACAO))