QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFM_CAIXA') and   type = 'U'
BANCODEDADOS IGERENCE
create table INFM_CAIXA (
   IDCAIXA              OBJETO_ID            not null,
   IDEMPRESA            OBJETOID             null,
   IDFILIAL             OBJETOID             null,
   BOLABERTO            BOLEANO              not null,
   CODCAIXA             INTEIRO              not null,
   constraint PK_INFM_CAIXA primary key (IDCAIXA))