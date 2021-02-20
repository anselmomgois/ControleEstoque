QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFM_PERMISSAOACAO') and   type = 'U'
BANCODEDADOS INFORMATIZ
create table INFM_PERMISSAOACAO (
   IDPERMISSAOACAO      OBJETOID             not null,
   IDPERMISSAO          OBJETOID             null,
   IDACAO               OBJETOID             null,
   constraint PK_INFM_PERMISSAOACAO primary key (IDPERMISSAOACAO))