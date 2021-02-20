QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFM_TIPOPESSOA') and   type = 'U'
BANCODEDADOS IGERENCE
create table INFM_TIPOPESSOA (
   IDTIPOPESSOA         OBJETOID             not null,
   DESTIPOPESSOA        DESCRICAO50          not null,
   CODTIPOPESSOA        INTEIRO              not null,
   constraint PK_INFM_TIPOPESSOA primary key (IDTIPOPESSOA))