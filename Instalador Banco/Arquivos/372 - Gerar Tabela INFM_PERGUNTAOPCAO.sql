QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFM_PERGUNTAOPCAO') and   type = 'U'
BANCODEDADOS INFORMATIZ
create table INFM_PERGUNTAOPCAO (
   IDPERGUNTAOPCAO      OBJETO_ID            not null,
   IDPERGUNTA           OBJETO_ID            null,
   DESPERGUNTAOPCAO     DESCRICAO100         not null,
   constraint PK_INFM_PERGUNTAOPCAO primary key (IDPERGUNTAOPCAO))