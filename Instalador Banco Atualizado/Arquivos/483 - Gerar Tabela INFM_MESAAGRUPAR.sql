QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFM_MESAAGRUPAR') and   type = 'U'
BANCODEDADOS IGERENCE
create table INFM_MESAAGRUPAR (
   IDMESAAGRUPAR        OBJETO_ID            not null,
   IDMESAPRINCIPAL      OBJETO_ID            not null,
   IDMESAAUXILIAR       OBJETO_ID            not null,
   constraint PK_INFM_MESAAGRUPAR primary key (IDMESAAGRUPAR))