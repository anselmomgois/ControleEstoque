QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFM_INTEGRACAOAPI') and   type = 'U'
BANCODEDADOS IGERENCE
create table INFM_INTEGRACAOAPI (
   IDINTEGRACAOAPI      OBJETO_ID            not null,
   IDEMPRESA            OBJETOID             not null,
   CODINTEGRACAOAPI     CODIGO20             not null,
   DESURLINTEGRACAOAPI  OBSERVACAOLONGA      not null,
   constraint PK_INFM_INTEGRACAOAPI primary key (IDINTEGRACAOAPI))