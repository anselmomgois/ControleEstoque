QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFM_GRUPOPARAMETRO') and   type = 'U'
BANCODEDADOS IGERENCE
create table INFM_GRUPOPARAMETRO (
   IDGRUPOPARAMETRO          OBJETOID             not null,
   CODGRUPOPARAMETRO         DESCRICAO50          not null,
   DESGRUPOPARAMETRO         DESCRICAO100         not null,
   constraint PK_INFM_GRUPOPARAMETRO primary key (IDGRUPOPARAMETRO))