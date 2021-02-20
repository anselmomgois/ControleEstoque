QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFM_PROPOSTA') and   type = 'U'
BANCODEDADOS INFORMATIZ
create table INFM_PROPOSTA (
   IDPROPOSTA           OBJETOID             not null,
   IDCRM                OBJETO_ID            null,
   IDEMPRESA            OBJETOID             null,
   DESPROPOSTA          DESCRICAO200         not null,
   NUMPROPOSTAVENDA     DECIMAL1             null,
   NUMPROPOSTAMANUTENCAO DECIMAL1             null,
   NUMCONTRAPROPOSTAVENDA DECIMAL1             null,
   NUMCONTRAPROPOSTAMANUT DECIMAL1             null,
   DESOPNIAO            DESCRICAO200         null,
   DESDUVIDA            DESCRICAO200         null,
   BOLATENDENECESSIDADE LOGICO               null,
   DTINSTALACAO         DATAHORA             null,
   BOLATIVA             LOGICO               not null,
   constraint PK_INFM_PROPOSTA primary key (IDPROPOSTA))