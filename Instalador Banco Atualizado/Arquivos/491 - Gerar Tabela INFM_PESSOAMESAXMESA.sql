QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFM_PESSOAMESAXMESA') and   type = 'U'
BANCODEDADOS IGERENCE
create table INFM_PESSOAMESAXMESA (
   IDPESSOAMESAXMESA    OBJETO_ID            not null,
   IDMESA               OBJETO_ID            null,
   IDPESSOAMESA         OBJETO_ID            null,
   constraint PK_INFM_PESSOAMESAXMESA primary key (IDPESSOAMESAXMESA))