QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFM_VALORFECHAMENTO') and   type = 'U'
BANCODEDADOS IGERENCE
create table INFM_VALORFECHAMENTO (
   IDVALORFECHAMENTO    OBJETO_ID            not null,
   IDRESPONSAVELCAIXA   OBJETO_ID            null,
   IDFORMAPAGAMENTO     OBJETO_ID            null,
   IDPESSOASUPERVISOR   OBJETOID             null,
   NUMVALOR             NUMERO_DECIMAL       null,
   NUMVALORDIFERENCA    NUMERO_DECIMAL       null,
   constraint PK_INFM_VALORFECHAMENTO primary key (IDVALORFECHAMENTO))