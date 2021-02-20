QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFM_PUBLICIDADE') and   type = 'U'
BANCODEDADOS INFORMATIZ
create table INFM_PUBLICIDADE (
   IDPUBLICIDADE        OBJETO_ID            not null,
   DESPUBLICIDADE       DESCRICAO200         not null,
   CODPUBLICIDADE       INTEIRO              not null,
   constraint PK_INFM_PUBLICIDADE primary key (IDPUBLICIDADE))