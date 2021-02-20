QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFM_FILIALPESSOA') and   type = 'U'
BANCODEDADOS INFORMATIZ
create table INFM_FILIALPESSOA (
   IDFILIALPESSOA       OBJETOID             not null,
   IDFILIAL             OBJETOID             null,
   IDPESSOA             OBJETOID             null,
   constraint PK_INFM_FILIALPESSOA primary key (IDFILIALPESSOA))