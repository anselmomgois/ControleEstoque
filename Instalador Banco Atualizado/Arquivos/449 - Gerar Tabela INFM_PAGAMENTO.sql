QUERYVALIDACAO select 1 from  sysobjects where  id = object_id('INFM_PAGAMENTO') and   type = 'U'
BANCODEDADOS IGERENCE
create table INFM_PAGAMENTO (
   IDPAGAMENTO          OBJETO_ID            not null,
   IDVENDA              OBJETO_ID            not null,
   IDFORMAPAGAMENTO     OBJETO_ID            not null,
   NUMVALOR             NUMERO_DECIMAL       not null,
   constraint PK_INFM_PAGAMENTO primary key (IDPAGAMENTO))