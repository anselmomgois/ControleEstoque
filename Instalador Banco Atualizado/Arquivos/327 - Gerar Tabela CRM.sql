QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFM_CRM') and   type = 'U'
BANCODEDADOS IGERENCE
create table INFM_CRM (
   IDCRM                OBJETO_ID            not null,
   IDEMPRESA            OBJETOID             null,
   IDGRUPOCOMPROMISSO   OBJETO_ID            null,
   IDPESSOACADASTRO     OBJETOID             null,
   IDPESSOACLIENTE      OBJETOID             null,
   CODCRM               INTEIROSEQ           identity,
   OBSCOMPROMISSO       OBSERVACAOLONGA      not null,
   constraint PK_INFM_CRM primary key (IDCRM))