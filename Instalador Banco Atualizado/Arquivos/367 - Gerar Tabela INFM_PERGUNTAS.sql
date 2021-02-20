QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFM_PERGUNTAS') and   type = 'U'
BANCODEDADOS IGERENCE
create table INFM_PERGUNTAS (
   IDPERGUNTA           OBJETO_ID            not null,
   IDGRUPOCOMPROMISSO   OBJETO_ID            null,
   DESPERGUNTA          OBSERVACAOLONGA      not null,
   BOLOBRIGATORIA       LOGICO               not null,
   CODTIPOCOMPONENTE    CODIGO20             not null,
   BOLNUMERICO          LOGICO               not null,
   constraint PK_INFM_PERGUNTAS primary key (IDPERGUNTA))