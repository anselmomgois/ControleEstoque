QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFM_ENDERECO') and   type = 'U'
BANCODEDADOS INFORMATIZ
create table INFM_ENDERECO (
   IDENDERECO           OBJETOID             not null,
   IDBAIRRO             OBJETOID             null,
   CODENDERECO          INTEIROSEQ           identity,
   DESRUA               DESCRICAO200         not null,
   CODCEP               CODIGO20             null,
   constraint PK_INFM_ENDERECO primary key (IDENDERECO))