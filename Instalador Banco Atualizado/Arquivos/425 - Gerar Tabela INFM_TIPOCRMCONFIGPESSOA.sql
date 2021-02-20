QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFM_TIPOCRMCONFIGPESSOA') and   type = 'U'
BANCODEDADOS IGERENCE
create table INFM_TIPOCRMCONFIGPESSOA (
   IDTIPOCRMCONFIGPESSOA OBJETO_ID            not null,
   IDTIPOCRMCONFIG      OBJETO_ID            null,
   IDPESSOA             OBJETOID             null,
   constraint PK_INFM_TIPOCRMCONFIGPESSOA primary key (IDTIPOCRMCONFIGPESSOA))