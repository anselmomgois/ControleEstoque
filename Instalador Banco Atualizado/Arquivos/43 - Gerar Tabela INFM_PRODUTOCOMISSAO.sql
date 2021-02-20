QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFM_PRODUTOCOMISSAO') and   type = 'U'
BANCODEDADOS IGERENCE
create table INFM_PRODUTOCOMISSAO (
   IDPRODUTOCOMISSAO    OBJETOID             not null,
   IDFILIAL             OBJETOID             null,
   CODPRODUTOCOMISSAO   INTEIROSEQ           identity,
   DESPRODUTOCOMISSAO   DESCRICAO100         not null,
   NUMCOMISSAOPER       NUMERO_DECIMAL       null,
   NUMCOMISSAOVALOR     NUMERO_DECIMAL       null,
   BOLHABILITADA        BOLEANO              null,
   constraint PK_INFM_PRODUTOCOMISSAO primary key (IDPRODUTOCOMISSAO))