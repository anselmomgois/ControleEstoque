QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFM_PESSOACRM') and   type = 'U'
BANCODEDADOS INFORMATIZ
create table INFM_PESSOACRM (
   IDPESSOACRM          OBJETO_ID            not null,
   IDCRM                OBJETO_ID            null,
   IDPESSOA             OBJETOID             null,
   DTHPROXAGENDAMENTO   DATAHORA             not null,
   constraint PK_INFM_PESSOACRM primary key (IDPESSOACRM))