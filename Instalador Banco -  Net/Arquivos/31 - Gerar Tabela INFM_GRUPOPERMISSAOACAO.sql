QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFM_GRUPOPERMISSAOACAO') and   type = 'U'
BANCODEDADOS INFORMATIZ
create table INFM_GRUPOPERMISSAOACAO (
   IDGRUPOPERMISSAOACAO OBJETOID             not null,
   IDPERMISSAO          OBJETOID             null,
   IDACAO               OBJETOID             null,
   IDGRUPOPERMISSAO     OBJETOID             null,
   constraint PK_INFM_GRUPOPERMISSAOACAO primary key (IDGRUPOPERMISSAOACAO))