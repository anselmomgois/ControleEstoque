QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFMA_EMPRESA') and   type = 'U'
BANCODEDADOS INFORMATIZ
create table INFMA_EMPRESA (
   IDEMPRESA            OBJETO_ID            not null,
   IDLICENCA            OBJETO_ID            null,
   CODEMPRESA           INTEIRO              not null,
   DESEMPRESA           DESCRICAO50          not null,
   constraint PK_INFMA_EMPRESA primary key (IDEMPRESA))