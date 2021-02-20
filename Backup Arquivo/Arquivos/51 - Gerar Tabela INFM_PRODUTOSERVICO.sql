QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFM_PRODUTOSERVICO') and   type = 'U'
BANCODEDADOS INFORMATIZ
create table INFM_PRODUTOSERVICO (
   IDPRODUTOSERVICO     OBJETOID             not null,
   IDTIPOPRODUTO        OBJETO_ID            null,
   IDGRUPOPRODUTO       OBJETOID             null,
   IDCOR                OBJETOID             null,
   IDPRODUTODERIVACAO   OBJETOID             null,
   IDPRODCATEGORIA      OBJETOID             null,
   IDPRODUTOMARCA       OBJETOID             null,
   IDEMPRESA            OBJETOID             null,
   IDPRODUTONCM         OBJETOID             null,
   IDPRODUTOCST         OBJETOID             null,
   IDPRODUTOCFOP        OBJETO_ID            null,
   CODPRODUTO           INTEIROSEQ           identity,
   DESPRODUTO           DESCRICAO100         not null,
   DESCODBARRAS         DESCRICAO50          null,
   OBSPRODUTO           OBSERVACAOMIN        null,
   NUMPESOPRODUTO       NUMERO_DECIMAL       null,
   BITIMGPRODUTO        OBJETO_IMAGEM        null,
   constraint PK_INFM_PRODUTOSERVICO primary key (IDPRODUTOSERVICO))