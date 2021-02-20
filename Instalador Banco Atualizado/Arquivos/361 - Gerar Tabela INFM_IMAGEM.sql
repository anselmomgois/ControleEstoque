QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFM_IMAGEM') and   type = 'U'
BANCODEDADOS IGERENCE
create table INFM_IMAGEM (
   IDIMAGEM             OBJETO_ID            not null,
   BITIMAGEMCENTRAL     OBJETO_IMAGEM        not null,
   constraint PK_INFM_IMAGEM primary key (IDIMAGEM))