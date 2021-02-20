QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFM_SITUACAO_PESSOA') and   type = 'U'
BANCODEDADOS IGERENCE
create table INFM_SITUACAO_PESSOA (
   IDSITUACAOPESSOA     OBJETOID             not null,
   DESSITUACAO          DESCRICAO50          not null,
   CODSITUACAO          CODIGO20             not null,
   constraint PK_INFM_SITUACAO_PESSOA primary key (IDSITUACAOPESSOA))