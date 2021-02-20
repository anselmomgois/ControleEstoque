QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFM_CODIGOBARRASPESSOA') and   type = 'U'
BANCODEDADOS IGERENCE
create table INFM_CODIGOBARRASPESSOA (
   IDCODIGOBARRASPESSOA OBJETO_ID            not null,
   IDPESSOA             OBJETOID             null,
   DESCODIGOBARRASPESSOA DESCRICAO100         not null,
   BOLATIVO             BOLEANO              not null,
   DTHCODIGO            DATAHORA             not null,
   NUMVALOR             NUMERO_DECIMAL       null,
   constraint PK_INFM_CODIGOBARRASPESSOA primary key (IDCODIGOBARRASPESSOA))