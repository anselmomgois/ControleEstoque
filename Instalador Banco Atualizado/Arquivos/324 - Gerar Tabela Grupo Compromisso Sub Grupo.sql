QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFM_GRUPOCOMPROMISSOSUBGRUPO') and   type = 'U'
BANCODEDADOS IGERENCE
create table INFM_GRUPOCOMPROMISSOSUBGRUPO (
   IDGRUPOCOMPROMISSOSUBGRUPO OBJETO_ID            not null,
   IDGRUPOCOMPROMISSOPAI OBJETO_ID            null,
   IDGRUPOCOMPROMISSO   OBJETO_ID            null,
   constraint PK_INFM_GRUPOCOMPROMISSOSUBGRU primary key (IDGRUPOCOMPROMISSOSUBGRUPO))