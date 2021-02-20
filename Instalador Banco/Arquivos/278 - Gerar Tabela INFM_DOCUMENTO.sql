QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFM_DOCUMENTO') and   type = 'U'
BANCODEDADOS INFORMATIZ
create table INFM_DOCUMENTO (
   IDDOCUMENTO          OBJETO_ID            not null,
   IDFILIAL             OBJETOID             not null,
   IDPESSOA             OBJETOID             null,
   IDTIPODOCUMENTO      OBJETO_ID            null,
   IDLOCALDOCUMENTO     OBJETO_ID            null,
   IDFORMAPAGAMENTO     OBJETO_ID            null,
   IDADMINISTRADORA     OBJETO_ID            null,
   IDDOCUMENTOPAI       OBJETO_ID            null,
   CODTRANSACAO         DESCRICAO100         not null,
   DESNUMBOLETOBANCARIO DESCRICAO200         null,
   DTHEMISSAO           DATAHORA             not null,
   DTHVENCORIGINAL      DATAHORA             not null,
   DTHVENCATUAL         DATAHORA             not null,
   NUMVALORORIGINAL     NUMERO_DECIMAL       not null,
   BOLPARCELADO         LOGICO               not null,
   OBSDOCUMENTO         OBSERVACAOLONGA      null,
   constraint PK_INFM_DOCUMENTO primary key (IDDOCUMENTO))