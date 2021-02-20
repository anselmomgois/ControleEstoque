QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFM_SALDOFILIAL') and   type = 'U'
BANCODEDADOS IGERENCE
create table INFM_SALDOFILIAL (
   IDSALDOFILIAL        OBJETO_ID            not null,
   IDFILIAL             OBJETOID             not null,
   NUMSALDO             DECIMAL1             not null,
   constraint PK_INFM_SALDOFILIAL primary key (IDSALDOFILIAL))