QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFM_ITEMPROCESSO') and   type = 'U'
BANCODEDADOS IGERENCE
create table INFM_ITEMPROCESSO (
   IDITEMPROCESSO       OBJETO_ID            not null,
   IDPROCESSO           OBJETO_ID            null,
   DESVALOR             OBSERVACAOLONGA      null,
   DTHCRIACAO           DATAHORA             not null,
   DTHEXECUCAO          DATAHORA             null,
   NELTENTATIVAS        INTEIRO              null,
   BOLCONCLUIDO         LOGICO               not null,
   constraint PK_INFM_ITEMPROCESSO primary key (IDITEMPROCESSO))