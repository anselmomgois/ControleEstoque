QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFM_PRODUTOPROMOCAOPRODF') and   type = 'U'
BANCODEDADOS INFORMATIZ
create table INFM_PRODUTOPROMOCAOPRODF (
   IDPRODUTOPROMOCAOPRODF OBJETOID             not null,
   IDPRODUTOPROMOCAO    OBJETOID             null,
   IDPRODUTOFILIAL      OBJETOID             null,
   IDDATOSCOMPRAPROD    OBJETOID             null,
   IDPRODUTOSERVICO     OBJETOID             null,
   constraint PK_INFM_PRODUTOPROMOCAOPRODF primary key (IDPRODUTOPROMOCAOPRODF))