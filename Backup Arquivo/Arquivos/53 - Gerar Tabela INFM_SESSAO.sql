QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFM_SESSAO') and   type = 'U'
BANCODEDADOS INFORMATIZ
create table INFM_SESSAO (
   IDSESSAO             OBJETO_ID            not null,
   IDPESSOA             OBJETOID             null,
   IDFILIAL             OBJETOID             null,
   DTHINICIO            DATAHORA             not null,
   DTHFIM               DATAHORA             null,
   DTHULTIMOUSO         DATAHORA             not null,
   constraint PK_INFM_SESSAO primary key (IDSESSAO))