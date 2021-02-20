QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFM_PRODUTOMARCA') and   type = 'U'
BANCODEDADOS IGERENCE
create table INFM_PRODUTOMARCA (
   IDPRODUTOMARCA       OBJETOID             not null,
   IDEMPRESA            OBJETOID             null,
   CODPRODUTOMARCA      INTEIROSEQ           identity,
   DESPRODUTOMARCA      DESCRICAO50          not null,
   constraint PK_INFM_PRODUTOMARCA primary key (IDPRODUTOMARCA))