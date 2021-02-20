QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFM_ITEMVENDAOBSERVACAO') and   type = 'U'
BANCODEDADOS IGERENCE
create table INFM_ITEMVENDAOBSERVACAO (
   IDITEMVENDAOBSERVACAO OBJETO_ID            not null,
   IDOBSERVACAO         OBJETO_ID            null,
   IDITEMVENDA          OBJETO_ID            null,
   constraint PK_INFM_ITEMVENDAOBSERVACAO primary key (IDITEMVENDAOBSERVACAO))