QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFM_ADMINISTRADORA') and   type = 'U'
BANCODEDADOS INFORMATIZ
create table INFM_ADMINISTRADORA (
   IDADMINISTRADORA     OBJETO_ID            not null,
   IDEMPRESA            OBJETOID             not null,
   CODADMINISTRADORA    INTEIROSEQ           identity,
   DESADMINISTRADORA    DESCRICAO50          not null,
   DESTELADMINISTRADORA DESCRICAO50          null,
   OBSREFADMINISTRADORA OBSERVACAOLONGA      null,
   NUMTARIFAPERCENT     DECIMAL1             null,
   NUMTARIFAVALOR       DECIMAL1             null,
   NUMTARIFAANTPERCENT  DECIMAL1             null,
   NUMTARIFAANTVALOR    DECIMAL1             null,
   NUMDESCONTPERCENT    DECIMAL1             null,
   NUMDESCONTVALOR      DECIMAL1             null,
   constraint PK_INFM_ADMINISTRADORA primary key (IDADMINISTRADORA))