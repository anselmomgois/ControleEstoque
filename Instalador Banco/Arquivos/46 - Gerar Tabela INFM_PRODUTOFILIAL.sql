QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFM_PRODUTOFILIAL') and   type = 'U'
BANCODEDADOS INFORMATIZ
create table INFM_PRODUTOFILIAL (
   IDPRODUTOFILIAL      OBJETOID             not null,
   IDPRODUTOSERVICO     OBJETOID             not null,
   IDFILIAL             OBJETOID             not null,
   IDPRODUTOCOMISSAO    OBJETOID             null,
   IDUNIDADEMEDIDAESTOQUE OBJETOID             null,
   IDUNIDADEMEDIDAVENDA OBJETOID             null,
   DESPRATELEIRA        DESCRICAO50          null,
   NUMESTOQUEMINIMO     DECIMAL1             null,
   NUMMINIMOVENDA       DECIMAL1             null,
   NUMIPIPER            NUMERO_DECIMAL       null,
   NUMEMBALAGEMPER      NUMERO_DECIMAL       null,
   NUMFRETEPER          NUMERO_DECIMAL       null,
   NUMOUTDESPPER        NUMERO_DECIMAL       null,
   constraint PK_INFM_PRODUTOFILIAL primary key (IDPRODUTOFILIAL))