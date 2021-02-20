QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFM_DATOSCOMPRAPROD') and   type = 'U'
BANCODEDADOS IGERENCE
create table INFM_DATOSCOMPRAPROD (
   IDDATOSCOMPRAPROD    OBJETOID             not null,
   IDUNIDADEMEDIDA      OBJETOID             null,
   IDPRODUTOFILIAL      OBJETOID             null,
   NUMUNIDADECOMPRA     NUMERO_DECIMAL_10_3  not null,
   NUMVALORCOMPRA       NUMERO_DECIMAL       not null,
   NUMESTOQUE           NUMERO_DECIMAL_10_3  not null,
   constraint PK_INFM_DATOSCOMPRAPROD primary key (IDDATOSCOMPRAPROD))