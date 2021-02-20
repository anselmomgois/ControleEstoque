QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFM_COR') and   type = 'U'
BANCODEDADOS INFORMATIZ
create table INFM_COR (
   IDCOR                OBJETOID             not null,
   IDEMPRESA            OBJETOID             null,
   CODCOR               INTEIROSEQ           identity,
   CODCORRGB            DESCRICAO50          not null,
   DESCOR               DESCRICAO50          not null,
   constraint PK_INFM_COR primary key (IDCOR))