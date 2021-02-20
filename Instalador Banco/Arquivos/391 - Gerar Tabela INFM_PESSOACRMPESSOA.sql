QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFM_PESSOACRMPESSOA') and   type = 'U'
BANCODEDADOS INFORMATIZ
create table INFM_PESSOACRMPESSOA (
   IDPESSOACRMPESSOA    OBJETO_ID            not null,
   IDPESSOACRM          OBJETO_ID            null,
   IDPESSOA             OBJETOID             null,
   constraint PK_INFM_PESSOACRMPESSOA primary key (IDPESSOACRMPESSOA))