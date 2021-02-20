QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFM_RESPONSAVELCAIXA') and   type = 'U'
BANCODEDADOS IGERENCE
create table INFM_RESPONSAVELCAIXA (
   IDRESPONSAVELCAIXA   OBJETO_ID            not null,
   IDCAIXA              OBJETO_ID            null,
   IDPESSOARESPONSAVEL  OBJETOID             null,
   NUMVALORINICIAL      NUMERO_DECIMAL       not null,
   NUMSALDO             NUMERO_DECIMAL       not null,
   DTHINICIOOPERACAO    DATAHORA             not null,
   DTHFIMOPERACAO       DATAHORA            null,
   constraint PK_INFM_RESPONSAVELCAIXA primary key (IDRESPONSAVELCAIXA))