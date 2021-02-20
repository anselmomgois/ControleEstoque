QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFM_PRODUTONCM') and   type = 'U'
BANCODEDADOS IGERENCE
create table INFM_PRODUTONCM (
   IDPRODUTONCM         OBJETOID             not null,
   IDEMPRESA            OBJETOID             null,
   CODPRODUTONCM        INTEIROSEQ           identity,
   CODNCM               INTEIRO              null,
   NUMMVAPER            NUMERO_DECIMAL       null,
   DESPRODUTONCM        DESCRICAO100         not null,
   constraint PK_INFM_PRODUTONCM primary key (IDPRODUTONCM))