QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFM_PRODUTOPROMOCAO') and   type = 'U'
BANCODEDADOS IGERENCE
create table INFM_PRODUTOPROMOCAO (
   IDPRODUTOPROMOCAO    OBJETOID             not null,
   CODPRODUTOPROMOCAO   INTEIROSEQ           identity,
   DESPRODUTOPROMOCAO   DESCRICAO100         not null,
   NUMPROMOCAOPER       NUMERO_DECIMAL       null,
   NUMPROMOCAOVALOR     NUMERO_DECIMAL       null,
   BOLHABILITADA        BOLEANO              not null,
   DTHINICIO            DATAHORA             not null,
   DTHFIM               DATAHORA             not null,
   CODTIPOPROMOCAO      CODIGO20             not null,
   constraint PK_INFM_PRODUTOPROMOCAO primary key (IDPRODUTOPROMOCAO))