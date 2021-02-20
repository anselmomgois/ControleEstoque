QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFM_PRODUTOCST') and   type = 'U'
BANCODEDADOS INFORMATIZ
create table INFM_PRODUTOCST (
   IDPRODUTOCST         OBJETOID             not null,
   IDEMPRESA            OBJETOID             null,
   CODPRODUTOCST        INTEIROSEQ           identity,
   DESPRODUTOCST        DESCRICAO100         not null,
   CODCST               INTEIRO              null,
   BOLTEMST             BOLEANO              null,
   OBSMSGNOTAFISCAL     OBSERVACAOLONGA      null,
   constraint PK_INFM_PRODUTOCST primary key (IDPRODUTOCST))