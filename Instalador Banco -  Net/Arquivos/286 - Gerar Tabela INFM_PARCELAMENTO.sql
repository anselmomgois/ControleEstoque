QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFM_PARCELAMENTO') and   type = 'U'
BANCODEDADOS INFORMATIZ
create table INFM_PARCELAMENTO (
   IDPARCELAMENTO       OBJETO_ID            not null,
   IDDOCUMENTO          OBJETO_ID            null,
   DTHVENCATUAL         DATAHORA             not null,
   DTHVENCORIGINAL      DATAHORA             not null,
   NUMVALORORIGINAL     DECIMAL1             not null,
   NUMPARCELA           INTEIRO              not null,
   constraint PK_INFM_PARCELAMENTO primary key (IDPARCELAMENTO))