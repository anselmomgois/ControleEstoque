QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFM_SANGRIA') and   type = 'U'
BANCODEDADOS IGERENCE
create table INFM_SANGRIA (
   IDSANGRIA            OBJETO_ID            not null,
   IDRESPONSAVELCAIXA   OBJETO_ID            null,
   IDPESSOASUPERVISOR   OBJETOID             null,
   NUMVALORSANGRIA      NUMERO_DECIMAL       not null,
   OBSSANGRIA           OBSERVACAOMIN        null,
   constraint PK_INFM_SANGRIA primary key (IDSANGRIA))