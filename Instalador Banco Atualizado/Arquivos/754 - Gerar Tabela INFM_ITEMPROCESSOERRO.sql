QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFM_ITEMPROCESSOERRO') and   type = 'U'
BANCODEDADOS IGERENCE
create table INFM_ITEMPROCESSOERRO (
   IDITEMPROCESSOERRO   OBJETO_ID            not null,
   IDITEMPROCESSO       OBJETO_ID            null,
   DESERRO              OBSERVACAOLONGA      not null,
   DTHERRO              DATAHORA             null,
   constraint PK_INFM_ITEMPROCESSOERRO primary key (IDITEMPROCESSOERRO))