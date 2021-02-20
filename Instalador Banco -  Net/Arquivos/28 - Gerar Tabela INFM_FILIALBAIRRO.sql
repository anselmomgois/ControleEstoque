QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFM_FILIALBAIRRO') and   type = 'U'
BANCODEDADOS INFORMATIZ
create table INFM_FILIALBAIRRO (
   IDFILIALBAIRRO       OBJETOID             not null,
   IDFILIAL             OBJETOID             null,
   IDBAIRRO             OBJETOID             null,
   constraint PK_INFM_FILIALBAIRRO primary key (IDFILIALBAIRRO))