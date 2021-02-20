QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFM_PESSOAMESA') and   type = 'U'
BANCODEDADOS IGERENCE
create table INFM_PESSOAMESA (
   IDPESSOAMESA         OBJETO_ID            not null,
   IDPESSOA             OBJETOID             null,
   DTHLIMITE            DATAHORA             not null,
   CODESTADO            CODIGO20             not null,
   constraint PK_INFM_PESSOAMESA primary key (IDPESSOAMESA))