QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFM_PARAMETROVALOR') and   type = 'U'
BANCODEDADOS INFORMATIZ
create table INFM_PARAMETROVALOR (
   IDPARAMETROVALOR     OBJETO_ID            not null,
   IDPARAMETRO          OBJETOID             null,
   IDFILIAL             OBJETOID             null,
   DESVALORPARAMETRO    DESCRICAO200         null,
   constraint PK_INFM_PARAMETROVALOR primary key (IDPARAMETROVALOR))