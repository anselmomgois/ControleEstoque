QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFM_TRANSACOES') and   type = 'U'
BANCODEDADOS INFORMATIZ
create table INFM_TRANSACOES (
   IDTRANSACAO          OBJETO_ID            not null,
   IDDOCUMENTO          OBJETO_ID            null,
   IDPARCELAMENTO       OBJETO_ID            null,
   NUMVALORACRESCIMO    DECIMAL1             null,
   NUMVALORDESCONTO     DECIMAL1             null,
   NUMVALORTRANSACAO    DECIMAL1             not null,
   DTHTRANSACAO         DATAHORA             not null,
   constraint PK_INFM_TRANSACOES primary key (IDTRANSACAO))