QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFM_TIPOPESSOA_PESSOA') and   type = 'U'
BANCODEDADOS INFORMATIZ
create table INFM_TIPOPESSOA_PESSOA (
   IDTIPOPESSOAPESSOA   OBJETOID             not null,
   IDTIPOPESSOA         OBJETOID             null,
   IDPESSOA             OBJETOID             null,
   constraint PK_INFM_TIPOPESSOA_PESSOA primary key (IDTIPOPESSOAPESSOA))