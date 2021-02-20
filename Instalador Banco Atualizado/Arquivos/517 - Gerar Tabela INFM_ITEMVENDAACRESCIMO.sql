QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFM_ITEMVENDAACRESCIMO') and   type = 'U'
BANCODEDADOS IGERENCE
create table INFM_ITEMVENDAACRESCIMO (
   IDITEMVENDAACRESCIMO OBJETO_ID            not null,
   IDITEMVENDA          OBJETO_ID            not null,
   IDACRESCIMO          OBJETOID             not null,
   constraint PK_INFM_ITEMVENDAACRESCIMO primary key (IDITEMVENDAACRESCIMO))