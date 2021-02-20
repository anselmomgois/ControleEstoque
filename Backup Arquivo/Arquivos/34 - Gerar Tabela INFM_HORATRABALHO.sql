QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFM_HORATRABALHO') and   type = 'U'
BANCODEDADOS INFORMATIZ
create table INFM_HORATRABALHO (
   IDHORATRABALHO       OBJETOID             not null,
   IDPESSOA             OBJETOID             null,
   CODDIASEMANA         INTEIRO              not null,
   DTHINICIO            CODIGO20             not null,
   DTHFIM               CODIGO20             not null,
   constraint PK_INFM_HORATRABALHO primary key (IDHORATRABALHO))