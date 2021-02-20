QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFM_PARAMETROOPCAO') and   type = 'U'
BANCODEDADOS IGERENCE
create table INFM_PARAMETROOPCAO (
   IDPARAMETROOPCAO          OBJETOID             not null,
   IDPARAMETRO	          	 OBJETOID,
   CODPARAMETROOPCAO         DESCRICAO50		  not null,
   DESPARAMETROOPCAO         DESCRICAO50		  not null,
   constraint PK_INFM_PARAMETROOPCAO primary key (IDPARAMETROOPCAO))