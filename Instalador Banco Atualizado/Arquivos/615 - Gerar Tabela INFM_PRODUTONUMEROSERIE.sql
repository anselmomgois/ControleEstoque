QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFM_PRODUTONUMEROSERIE') and   type = 'U'
BANCODEDADOS IGERENCE
create table INFM_PRODUTONUMEROSERIE (
   IDPRODUTONUMEROSERIE OBJETO_ID            not null,
   IDDATOSCOMPRAPROD    OBJETOID             null,
   IDEMPRESA            OBJETOID             null,
   DESNUMEROSERIE       DESCRICAO100         not null,
   BOLVENDIDO           LOGICO               not null,
   constraint PK_INFM_PRODUTONUMEROSERIE primary key (IDPRODUTONUMEROSERIE)
)