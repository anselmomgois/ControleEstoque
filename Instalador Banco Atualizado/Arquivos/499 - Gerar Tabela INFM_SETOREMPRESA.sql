QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFM_SETOREMPRESA') and   type = 'U'
BANCODEDADOS IGERENCE
create table INFM_SETOREMPRESA (
   IDSETOREMPRESA       OBJETO_ID            not null,
   IDEMPRESA            OBJETOID             not null,
   IDFILIAL             OBJETOID             not null,
   DESIMPRESSORA        OBSERVACAOMIN        null,
   DESSETOR             DESCRICAO200         not null,
   constraint PK_INFM_SETOREMPRESA primary key (IDSETOREMPRESA))