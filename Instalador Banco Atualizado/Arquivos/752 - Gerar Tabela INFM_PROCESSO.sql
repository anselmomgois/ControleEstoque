QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFM_PROCESSO') and   type = 'U'
BANCODEDADOS IGERENCE
create table INFM_PROCESSO (
   IDPROCESSO           OBJETO_ID            not null,
   IDEMPRESA            OBJETOID             null,
   BOLATIVO             LOGICO               not null,
   CODTIPOPROCESSO      DESCRICAO50          not null,
   NELINTERVALO         INTEIRO              not null,
   NELTENTATIVAS        INTEIRO              not null,
   DESPROCESSO          DESCRICAO100         not null,
   constraint PK_INFM_PROCESSO primary key (IDPROCESSO))