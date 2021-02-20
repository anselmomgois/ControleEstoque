QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFM_PRODUTOCFOP') and   type = 'U'
BANCODEDADOS INFORMATIZ
create table INFM_PRODUTOCFOP (
   IDPRODUTOCFOP        OBJETO_ID            not null,
   IDEMPRESA            OBJETOID             null,
   CODPRODUTOCFOP       INTEIROSEQ           identity,
   DESPRODUTOCFOP       DESCRICAO100         not null,
   CODCFOP              INTEIRO              null,
   constraint PK_INFM_PRODUTOCFOP primary key (IDPRODUTOCFOP))