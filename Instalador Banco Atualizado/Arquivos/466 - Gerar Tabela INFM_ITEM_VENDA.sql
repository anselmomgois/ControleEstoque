QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFM_ITEMVENDA') and   type = 'U'
BANCODEDADOS IGERENCE
create table INFM_ITEMVENDA (
   IDITEMVENDA          OBJETO_ID            not null,
   IDVENDA              OBJETO_ID            null,
   IDPESSOAVENDA        OBJETOID             null,
   IDPRODUTOSERVICO     OBJETOID             null,
   BOLCANCELADO         BOLEANO              not null,
   NUMVALORITEM         NUMERO_DECIMAL       not null,
   NUMVALORDESCONTO     NUMERO_DECIMAL       null,
   NUMVALORTOTAL        NUMERO_DECIMAL       not null,
   NUMQUANTIDADE        NUMERO_DECIMAL_10_3  not null,
   NUMVALORACRESCIMO    NUMERO_DECIMAL       null,
   NUMSEQUENCIA         INTEIRO              not null,
   constraint PK_INFM_ITEMVENDA primary key (IDITEMVENDA))