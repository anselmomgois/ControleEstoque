QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFM_CIDADE') and   type = 'U'
BANCODEDADOS IGERENCE
create table INFM_CIDADE (
   IDCIDADE             OBJETO_ID            not null,
   IDESTADO             OBJETOID             null,
   DESCIDADE            DESCRICAO50          not null,
   CODCIDADE            INTEIROSEQ           identity,
   CODDDD               CODIGO20             null,
   CODIBGE              CODIGO20             null,
   constraint PK_INFM_CIDADE primary key (IDCIDADE))