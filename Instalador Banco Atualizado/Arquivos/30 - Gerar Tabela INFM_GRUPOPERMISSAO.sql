QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFM_GRUPOPERMISSAO') and   type = 'U'
BANCODEDADOS IGERENCE
create table INFM_GRUPOPERMISSAO (
   IDGRUPOPERMISSAO     OBJETOID             not null,
   IDEMPRESA            OBJETOID             null,
   DESGRUPO             DESCRICAO50          not null,
   constraint PK_INFM_GRUPOPERMISSAO primary key (IDGRUPOPERMISSAO))