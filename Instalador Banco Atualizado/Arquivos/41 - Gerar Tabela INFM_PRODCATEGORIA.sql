QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFM_PRODCATEGORIA') and   type = 'U'
BANCODEDADOS IGERENCE
create table INFM_PRODCATEGORIA (
   IDPRODCATEGORIA      OBJETOID             not null,
   IDEMPRESA            OBJETOID             null,
   CODPRODCATEGORIA     INTEIROSEQ           identity,
   DESPRODCATEGORIA     DESCRICAO50          not null,
   constraint PK_INFM_PRODCATEGORIA primary key (IDPRODCATEGORIA))