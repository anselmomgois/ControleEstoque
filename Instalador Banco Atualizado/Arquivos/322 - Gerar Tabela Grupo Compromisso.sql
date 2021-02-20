QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFM_GRUPOCOMPROMISSO') and   type = 'U'
BANCODEDADOS IGERENCE
create table INFM_GRUPOCOMPROMISSO (
   IDGRUPOCOMPROMISSO   OBJETO_ID            not null,
   CODGRUPOCOMPROMISSO  INTEIROSEQ           identity,
   DESGRUPOCOMPROMISSO  DESCRICAO50          not null,
   IDEMPRESA            OBJETOID             null,
   constraint PK_INFM_GRUPOCOMPROMISSO primary key (IDGRUPOCOMPROMISSO))