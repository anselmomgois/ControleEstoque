QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFM_TIPODOCUMENTO') and   type = 'U'
BANCODEDADOS INFORMATIZ
create table INFM_TIPODOCUMENTO (
   IDTIPODOCUMENTO      OBJETO_ID            not null,
   CODTIPODOCUMENTO     CODIGO20             not null,
   DESTIPODOCUMENTO     DESCRICAO50          not null,
   constraint PK_INFM_TIPODOCUMENTO primary key (IDTIPODOCUMENTO))