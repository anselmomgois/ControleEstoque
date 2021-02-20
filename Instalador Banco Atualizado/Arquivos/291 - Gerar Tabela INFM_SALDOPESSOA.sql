QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFM_SALDOPESSOA') and   type = 'U'
BANCODEDADOS IGERENCE
create table INFM_SALDOPESSOA (
   IDSALDOPESSOA        OBJETO_ID            not null,
   IDDOCUMENTO          OBJETO_ID            null,
   IDPESSOA             OBJETOID             null,
   NUMVALORSALDO        DECIMAL1             not null,
   constraint PK_INFM_SALDOPESSOA primary key (IDSALDOPESSOA))