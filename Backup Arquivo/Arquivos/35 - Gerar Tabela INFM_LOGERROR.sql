QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFM_LOGERROR') and   type = 'U'
BANCODEDADOS INFORMATIZ
create table INFM_LOGERROR (
   IDLOGERROR           OBJETOID             not null,
   DESERROR             OBSERVACAOLONGA      not null,
   DESPESSOA            DESCRICAO50          null,
   DTHERROR             DATAHORA             not null,
   constraint PK_INFM_LOGERROR primary key (IDLOGERROR))