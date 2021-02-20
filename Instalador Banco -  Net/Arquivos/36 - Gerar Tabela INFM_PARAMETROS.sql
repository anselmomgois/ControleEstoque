QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFM_PARAMETROS') and   type = 'U'
BANCODEDADOS INFORMATIZ
create table INFM_PARAMETROS (
   IDPARAMETRO          OBJETOID             not null,
   CODPARAMETRO         DESCRICAO50          not null,
   DESPARAMETRO         DESCRICAO100         not null,
   TIPOCOMPONENTE       INTEIRO              not null,
   BOLNIVELFILIAL       LOGICO               not null,
   constraint PK_INFM_PARAMETROS primary key (IDPARAMETRO))