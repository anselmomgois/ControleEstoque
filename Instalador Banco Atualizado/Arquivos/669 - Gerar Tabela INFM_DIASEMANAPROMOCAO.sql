QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFM_DIASEMANAPROMOCAO') and   type = 'U'
BANCODEDADOS IGERENCE
create table INFM_DIASEMANAPROMOCAO (
   IDDIASEMANAPROMOCAO  OBJETO_ID            not null,
   IDPRODUTOPROMOCAO    OBJETOID             null,
   CODDIASEMANA         CODIGO20             not null,
   constraint PK_INFM_DIASEMANAPROMOCAO primary key (IDDIASEMANAPROMOCAO))