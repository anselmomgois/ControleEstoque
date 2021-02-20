QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFM_BAIRRO') and   type = 'U'
BANCODEDADOS IGERENCE
create table INFM_BAIRRO (
   IDBAIRRO             OBJETOID             not null,
   IDCIDADE             OBJETO_ID            null,
   DESBAIRRO            DESCRICAO50          not null,
   CODBAIRRO            INTEIROSEQ           identity,
   constraint PK_INFM_BAIRRO primary key (IDBAIRRO))