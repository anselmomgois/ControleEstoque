QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFM_VENDA') and   type = 'U'
BANCODEDADOS IGERENCE
create table INFM_VENDA (
   IDFILIAL             OBJETOID             null,
   IDVENDA              OBJETO_ID            not null,
   IDPESSOACLIENTE      OBJETOID             null,
   IDRESPONSAVELCAIXA   OBJETO_ID            null,
   IDPESSOAENTREGADOR   OBJETOID             null,
   IDENDERECOENTREGA    OBJETOID             null,
   IDEMPRESA            OBJETOID             null,
   DTHVENDAINICIO       DATAHORA             not null,
   DTHVENDAFIM          DATAHORA             null,
   NUMVALORSERVICO      NUMERO_DECIMAL       null,
   NUMVALORTAXAENTREGA  NUMERO_DECIMAL       null,
   COD_ESTADO           CODIGO20             not null,
   NUMDESCONTO          NUMERO_DECIMAL       null,
   NUMVALORVENDA        NUMERO_DECIMAL       not null,
   NUMVALORTOTAL        NUMERO_DECIMAL       not null,
   CODCOMANDA           CODIGO20             null,
   CODESTADOVENDA       CODIGO20             not null,
   NUMQUANTIDADEPESSOAS INTEIRO              null,
   OBSVENDA             OBSERVACAOMIN        null,
   constraint PK_INFM_VENDA primary key (IDVENDA))