QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFM_RESPOSTAPERGUNTA') and   type = 'U'
BANCODEDADOS IGERENCE
create table INFM_RESPOSTAPERGUNTA (
   IDRESPOSTAPERGUNTA   OBJETOID             not null,
   IDPERGUNTA           OBJETO_ID            null,
   IDCRM                OBJETO_ID            null,
   DESVALOR             OBSERVACAOLONGA      not null,
   constraint PK_INFM_RESPOSTAPERGUNTA primary key (IDRESPOSTAPERGUNTA))