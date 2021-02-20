QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFM_CODIGOBARRASPRODSERV') and   type = 'U'
BANCODEDADOS IGERENCE
create table INFM_CODIGOBARRASPRODSERV (
   IDCODIGOBARRASPRODSERV OBJETO_ID            not null,
   IDPRODUTOSERVICO     OBJETOID             null,
   IDEMPRESA            OBJETOID             null,
   DESCODBARRAS         DESCRICAO50          not null,
   constraint PK_INFM_CODIGOBARRASPRODSERV primary key (IDCODIGOBARRASPRODSERV))