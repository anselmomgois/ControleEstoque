QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFM_MESAVENDA') and   type = 'U'
BANCODEDADOS IGERENCE
create table INFM_MESAVENDA (
   IDMESAVENDA          OBJETO_ID            not null,
   IDMESA               OBJETO_ID            null,
   IDVENDA              OBJETO_ID            null,
   constraint PK_INFM_MESAVENDA primary key (IDMESAVENDA))