QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFM_FORMAPAGAMENTO') and   type = 'U'
BANCODEDADOS INFORMATIZ
create table INFM_FORMAPAGAMENTO (
   IDFORMAPAGAMENTO     OBJETO_ID            not null,
   DESFORMAPAGAMENTO    DESCRICAO50          not null,
   CODFORMAPAGAMENTO    CODIGO20             not null,
   constraint PK_INFM_FORMAPAGAMENTO primary key (IDFORMAPAGAMENTO))