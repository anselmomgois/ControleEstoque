QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFM_LOCALDOCUMENTO') and   type = 'U'
BANCODEDADOS IGERENCE
create table INFM_LOCALDOCUMENTO (
   IDLOCALDOCUMENTO     OBJETO_ID            not null,
   CODLOCALDOCUMENTO    CODIGO20             not null,
   DESLOCALDOCUMENTO    DESCRICAO50          not null,
   constraint PK_INFM_LOCALDOCUMENTO primary key (IDLOCALDOCUMENTO))