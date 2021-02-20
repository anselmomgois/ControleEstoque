QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFM_COMPRA') and   type = 'U'
BANCODEDADOS IGERENCE
create table INFM_COMPRA (
   IDCOMPRA             OBJETO_ID            not null,
   IDFORNECEDOR         OBJETOID             null,
   IDEMPRESA            OBJETOID             null,
   IDFILIAL             OBJETOID             null,
   CODCOMPRA            DESCRICAO50          not null,
   DTHCOMPRA            DATAHORA             not null,
   CODESTADO            CODIGO20             not null,
   OBSCOMPRA            OBSERVACAOLONGA      null,
   CODNOTAFISCAL        DESCRICAO50          null,
   CODRASTREIO          DESCRICAO50          null,
   DTHRECEBIMENTO       DATAHORA             null,
   constraint PK_INFM_COMPRA primary key (IDCOMPRA))