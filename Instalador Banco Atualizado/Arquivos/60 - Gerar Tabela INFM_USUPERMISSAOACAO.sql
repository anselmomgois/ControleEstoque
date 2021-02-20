QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFM_USUPERMISSAOACAO') and   type = 'U'
BANCODEDADOS IGERENCE
create table INFM_USUPERMISSAOACAO (
   IDUSUPERMISSAOACAO   OBJETOID             not null,
   IDPERMISSAO          OBJETOID             null,
   IDACAO               OBJETOID             null,
   IDPESSOA             OBJETOID             null,
   IDGRUPOPERMISSAO     OBJETOID             null,
   constraint PK_INFM_USUPERMISSAOACAO primary key (IDUSUPERMISSAOACAO))